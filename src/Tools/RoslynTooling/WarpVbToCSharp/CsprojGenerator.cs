using System.Text;
using System.Xml.Linq;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Generates an SDK-style C# project file (<c>.csproj</c>) from a converted Visual Basic
///  project (<c>.vbproj</c>), following the conventions of the already-converted sibling
///  WinForms libraries in the solution.
/// </summary>
/// <remarks>
///  <para>
///   Visual-Basic-only properties (<c>MyType</c>, <c>OptionStrict/Explicit/Infer/Compare</c>,
///   VB warning codes, <c>DefineDebug</c>) are dropped; WinForms desktop properties
///   (<c>UseWindowsForms</c>, <c>ImportWindowsDesktopTargets</c>) and the strong-name key are
///   carried over. Framework <c>Reference</c>s and <c>ProjectReference</c>s are preserved, with any
///   reference to a <c>.vbproj</c> rewritten to the equivalent <c>.csproj</c>.
///  </para>
///  <para>
///   The leftover <c>.vb</c> files are excluded from compilation via <c>DefaultItemExcludes</c> so
///   the originals can remain on disk for comparison until the converted build is green.
///  </para>
/// </remarks>
internal sealed class CsprojGenerator
{
    private static readonly XNamespace None = XNamespace.None;

    public static string Generate(string vbprojPath, string rootNamespace, MyProjectResult myProject)
    {
        XDocument source = XDocument.Load(vbprojPath);
        XElement root = source.Root
            ?? throw new InvalidOperationException($"'{vbprojPath}' has no root element.");

        string projectDir = Path.GetDirectoryName(Path.GetFullPath(vbprojPath)) ?? ".";

        string? outputType = ReadProperty(root, "OutputType") ?? "Library";
        string targetFramework = ReadProperty(root, "TargetFramework") ?? "net472";
        string? assemblyName = ReadProperty(root, "AssemblyName");
        string? keyFile = ReadProperty(root, "AssemblyOriginatorKeyFile");
        bool useWindowsForms = string.Equals(ReadProperty(root, "UseWindowsForms"), "true", StringComparison.OrdinalIgnoreCase);
        bool importDesktop = string.Equals(ReadProperty(root, "ImportWindowsDesktopTargets"), "true", StringComparison.OrdinalIgnoreCase);
        bool needsPreserializedResources = HasBinaryResources(projectDir);

        StringBuilder sb = new();
        sb.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
        sb.AppendLine();
        sb.AppendLine("  <PropertyGroup>");
        sb.AppendLine($"    <TargetFramework>{targetFramework}</TargetFramework>");
        sb.AppendLine($"    <OutputType>{outputType}</OutputType>");
        sb.AppendLine($"    <RootNamespace>{rootNamespace}</RootNamespace>");
        if (!string.IsNullOrEmpty(assemblyName))
        {
            sb.AppendLine($"    <AssemblyName>{assemblyName}</AssemblyName>");
        }

        sb.AppendLine("    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>");
        if (useWindowsForms)
        {
            sb.AppendLine("    <UseWindowsForms>true</UseWindowsForms>");
        }

        if (importDesktop)
        {
            sb.AppendLine("    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>");
        }

        if (!string.IsNullOrEmpty(keyFile))
        {
            sb.AppendLine($"    <AssemblyOriginatorKeyFile>{keyFile}</AssemblyOriginatorKeyFile>");
        }

        sb.AppendLine("    <LangVersion>latest</LangVersion>");
        sb.AppendLine("    <NoWarn>$(NoWarn);1591</NoWarn>");

        // Legacy WinForms .resx carry binary (BinaryFormatter-serialized) resources such as images and
        // icons. Under the .NET SDK resource pipeline these require the preserialized-resources path and
        // the System.Resources.Extensions reader, matching the already-converted sibling WinForms projects.
        if (needsPreserializedResources)
        {
            sb.AppendLine("    <GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>");
        }

        sb.AppendLine("    <DefaultItemExcludes>$(DefaultItemExcludes);$(ProjectDir)**\\*.vb</DefaultItemExcludes>");
        sb.AppendLine("  </PropertyGroup>");

        AppendReferences(sb, root);
        AppendCompileItems(sb, root, myProject);
        AppendControlResources(sb, root, projectDir);
        AppendMyProjectResourceItems(sb, rootNamespace, myProject);
        AppendEntityDeployItems(sb, root);
        AppendProjectReferences(sb, root);

        if (needsPreserializedResources)
        {
            sb.AppendLine();
            sb.AppendLine("  <ItemGroup>");
            sb.AppendLine("    <PackageReference Include=\"System.Resources.Extensions\" Version=\"4.6.0\" />");
            sb.AppendLine("  </ItemGroup>");
        }

        sb.AppendLine();
        sb.AppendLine("</Project>");
        return sb.ToString();
    }

    /// <summary>
    ///  Returns <see langword="true"/> when any <c>.resx</c> under the project directory contains a
    ///  binary (BinaryFormatter-serialized) resource, identified by a <c>mimetype</c> attribute.
    /// </summary>
    private static bool HasBinaryResources(string projectDir)
    {
        if (!Directory.Exists(projectDir))
        {
            return false;
        }

        foreach (string resx in Directory.EnumerateFiles(projectDir, "*.resx", SearchOption.AllDirectories))
        {
            if (File.ReadLines(resx).Any(static line => line.Contains("mimetype=", StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
        }

        return false;
    }

    private static void AppendReferences(StringBuilder sb, XElement root)
    {
        List<string> references = root
            .Descendants(None + "Reference")
            .Select(r => (string?)r.Attribute("Include"))
            .Where(static include => !string.IsNullOrEmpty(include))
            .Select(static include => include!)
            .ToList();

        // The converter emits 'using Microsoft.VisualBasic;' for the VB default imports, so the
        // assembly must be referenced explicitly under the .NET Framework SDK.
        if (!references.Any(static r => r.Equals("Microsoft.VisualBasic", StringComparison.OrdinalIgnoreCase)))
        {
            references.Insert(0, "Microsoft.VisualBasic");
        }

        if (references.Count == 0)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");
        foreach (string reference in references)
        {
            sb.AppendLine($"    <Reference Include=\"{reference}\" />");
        }

        sb.AppendLine("  </ItemGroup>");
    }

    private static void AppendCompileItems(StringBuilder sb, XElement root, MyProjectResult myProject)
    {
        List<XElement> compiles = root
            .Descendants(None + "Compile")
            .Where(static c => c.Attribute("Update") is not null || c.Attribute("Include") is not null)
            .ToList();

        // Designer code-behind pairing: 'X.Designer.cs' depends upon 'X.cs' (skipping My Project scaffold).
        List<(string Designer, string Code)> designerPairs = compiles
            .Select(static c => ((string?)c.Attribute("Update") ?? (string?)c.Attribute("Include"), c))
            .Where(static t => t.Item1 is not null && t.Item1.EndsWith(".Designer.vb", StringComparison.OrdinalIgnoreCase))
            .Select(static t => (Path: t.Item1!.Replace('/', '\\'), Element: t.c))
            .Where(static t => !t.Path.StartsWith("My Project\\", StringComparison.OrdinalIgnoreCase))
            .Select(static t =>
            {
                string? dep = t.Element.Elements(None + "DependentUpon").Select(static d => d.Value).FirstOrDefault();
                string code = dep is not null
                    ? Path.ChangeExtension(dep, ".cs")
                    : Path.ChangeExtension(t.Path[..^".Designer.vb".Length] + ".vb", ".cs");
                return (Designer: Path.ChangeExtension(t.Path, ".cs"), Code: code);
            })
            .ToList();

        // SubType-tagged files (Component/UserControl/Form) so the Designer recognizes them.
        List<(string File, string SubType)> subTypes = compiles
            .Select(static c => (Path: ((string?)c.Attribute("Update") ?? (string?)c.Attribute("Include"))?.Replace('/', '\\'),
                SubType: c.Elements(None + "SubType").Select(static s => s.Value).FirstOrDefault()))
            .Where(static t => t.Path is not null
                && t.SubType is "Component" or "UserControl" or "Form"
                && t.Path.EndsWith(".vb", StringComparison.OrdinalIgnoreCase)
                && !t.Path.StartsWith("My Project\\", StringComparison.OrdinalIgnoreCase))
            .Select(static t => (File: Path.ChangeExtension(t.Path!, ".cs"), SubType: t.SubType!))
            .ToList();

        bool hasDesignerItems = myProject.HasResources || myProject.HasSettings;
        if (designerPairs.Count == 0 && subTypes.Count == 0 && !hasDesignerItems)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");

        foreach ((string designer, string code) in designerPairs)
        {
            sb.AppendLine($"    <Compile Update=\"{designer}\">");
            sb.AppendLine($"      <DependentUpon>{code}</DependentUpon>");
            sb.AppendLine("    </Compile>");
        }

        foreach ((string file, string subType) in subTypes)
        {
            sb.AppendLine($"    <Compile Update=\"{file}\">");
            sb.AppendLine($"      <SubType>{subType}</SubType>");
            sb.AppendLine("    </Compile>");
        }

        if (myProject.HasResources)
        {
            sb.AppendLine("    <Compile Update=\"My Project\\Resources.Designer.cs\">");
            sb.AppendLine("      <AutoGen>True</AutoGen>");
            sb.AppendLine("      <DesignTime>True</DesignTime>");
            sb.AppendLine("      <DependentUpon>Resources.resx</DependentUpon>");
            sb.AppendLine("    </Compile>");
        }

        if (myProject.HasSettings)
        {
            sb.AppendLine("    <Compile Update=\"My Project\\Settings.Designer.cs\">");
            sb.AppendLine("      <AutoGen>True</AutoGen>");
            sb.AppendLine("      <DependentUpon>Settings.settings</DependentUpon>");
            sb.AppendLine("      <DesignTimeSharedInput>True</DesignTimeSharedInput>");
            sb.AppendLine("    </Compile>");
        }

        sb.AppendLine("  </ItemGroup>");
    }

    /// <summary>
    ///  Pairs each Form/UserControl <c>.resx</c> with its converted <c>.cs</c> code-behind so the
    ///  Designer associates them and the resource embeds under the type's manifest name.
    /// </summary>
    private static void AppendControlResources(StringBuilder sb, XElement root, string projectDir)
    {
        // Control resx are those whose matching '<name>.Designer.vb' is paired with '<name>.vb'.
        List<string> controlResx = root
            .Descendants(None + "Compile")
            .Select(static c => ((string?)c.Attribute("Update") ?? (string?)c.Attribute("Include"))?.Replace('/', '\\'))
            .Where(static path => path is not null && path.EndsWith(".Designer.vb", StringComparison.OrdinalIgnoreCase))
            .Where(static path => !path!.StartsWith("My Project\\", StringComparison.OrdinalIgnoreCase))
            .Select(static path => path![..^".Designer.vb".Length])
            .ToList();

        List<string> existing = controlResx
            .Where(name => File.Exists(Path.Combine(projectDir, name + ".resx")))
            .ToList();

        if (existing.Count == 0)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");
        foreach (string name in existing)
        {
            sb.AppendLine($"    <EmbeddedResource Update=\"{name}.resx\">");
            sb.AppendLine($"      <DependentUpon>{name}.cs</DependentUpon>");
            sb.AppendLine("    </EmbeddedResource>");
        }

        sb.AppendLine("  </ItemGroup>");
    }

    private static void AppendMyProjectResourceItems(StringBuilder sb, string rootNamespace, MyProjectResult myProject)
    {
        if (myProject.HasResources)
        {
            sb.AppendLine();
            sb.AppendLine("  <ItemGroup>");
            sb.AppendLine("    <EmbeddedResource Update=\"My Project\\Resources.resx\">");
            sb.AppendLine("      <Generator>ResXFileCodeGenerator</Generator>");
            sb.AppendLine("      <LastGenOutput>Resources.Designer.cs</LastGenOutput>");
            sb.AppendLine($"      <CustomToolNamespace>{rootNamespace}.My.Resources</CustomToolNamespace>");
            sb.AppendLine($"      <LogicalName>{rootNamespace}.Resources.resources</LogicalName>");
            sb.AppendLine("    </EmbeddedResource>");
            sb.AppendLine("  </ItemGroup>");
        }

        if (myProject.HasSettings)
        {
            sb.AppendLine();
            sb.AppendLine("  <ItemGroup>");
            sb.AppendLine("    <None Update=\"My Project\\Settings.settings\">");
            sb.AppendLine("      <Generator>SettingsSingleFileGenerator</Generator>");
            sb.AppendLine("      <LastGenOutput>Settings.Designer.cs</LastGenOutput>");
            sb.AppendLine($"      <CustomToolNamespace>{rootNamespace}.My</CustomToolNamespace>");
            sb.AppendLine("    </None>");
            sb.AppendLine("  </ItemGroup>");
        }

        if (myProject.HasResources || myProject.HasSettings)
        {
            sb.AppendLine();
            sb.AppendLine("  <ItemGroup>");
            sb.AppendLine("    <AppDesigner Include=\"My Project\\\" />");
            sb.AppendLine("  </ItemGroup>");
        }
    }

    // EF6 EDMX projects deploy the model metadata (csdl/ssdl/msl) via <EntityDeploy>. The original VB
    // project regenerated FacessoModel.Designer.vb from the .edmx with the legacy VB code generator;
    // after conversion the .Designer.cs is a normal compiled source, so carry the .edmx over for its
    // embedded metadata only and drop the code-generator hooks.
    private static void AppendEntityDeployItems(StringBuilder sb, XElement root)
    {
        List<string> edmxFiles = root
            .Descendants(None + "EntityDeploy")
            .Select(static e => (string?)e.Attribute("Include"))
            .Where(static include => !string.IsNullOrEmpty(include))
            .Select(static include => include!)
            .ToList();

        if (edmxFiles.Count == 0)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");
        foreach (string edmx in edmxFiles)
        {
            sb.AppendLine($"    <EntityDeploy Include=\"{edmx}\" />");
        }

        sb.AppendLine("  </ItemGroup>");
    }

    private static void AppendProjectReferences(StringBuilder sb, XElement root)
    {
        List<string> projectReferences = root
            .Descendants(None + "ProjectReference")
            .Select(static r => (string?)r.Attribute("Include"))
            .Where(static include => !string.IsNullOrEmpty(include))
            .Select(static include => RewriteVbProjReference(include!))
            .ToList();

        if (projectReferences.Count == 0)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");
        foreach (string reference in projectReferences)
        {
            sb.AppendLine($"    <ProjectReference Include=\"{reference}\" />");
        }

        sb.AppendLine("  </ItemGroup>");
    }

    private static string RewriteVbProjReference(string include)
        => include.EndsWith(".vbproj", StringComparison.OrdinalIgnoreCase)
            ? string.Concat(include.AsSpan(0, include.Length - ".vbproj".Length), ".csproj")
            : include;

    private static string? ReadProperty(XElement root, string name)
        => root.Descendants(None + name)
            .Select(static e => e.Value)
            .FirstOrDefault(static value => !string.IsNullOrWhiteSpace(value));
}
