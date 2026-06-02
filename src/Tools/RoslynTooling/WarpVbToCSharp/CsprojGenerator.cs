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

        string? outputType = ReadProperty(root, "OutputType") ?? "Library";
        string targetFramework = ReadProperty(root, "TargetFramework") ?? "net472";
        string? assemblyName = ReadProperty(root, "AssemblyName");
        string? keyFile = ReadProperty(root, "AssemblyOriginatorKeyFile");
        bool useWindowsForms = string.Equals(ReadProperty(root, "UseWindowsForms"), "true", StringComparison.OrdinalIgnoreCase);
        bool importDesktop = string.Equals(ReadProperty(root, "ImportWindowsDesktopTargets"), "true", StringComparison.OrdinalIgnoreCase);

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
        sb.AppendLine("    <DefaultItemExcludes>$(DefaultItemExcludes);$(ProjectDir)**\\*.vb</DefaultItemExcludes>");
        sb.AppendLine("  </PropertyGroup>");

        AppendReferences(sb, root);
        AppendComponentCompileItems(sb, root, myProject);
        AppendMyProjectResourceItems(sb, rootNamespace, myProject);
        AppendEntityDeployItems(sb, root);
        AppendProjectReferences(sb, root);

        sb.AppendLine();
        sb.AppendLine("</Project>");
        return sb.ToString();
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

    private static void AppendComponentCompileItems(StringBuilder sb, XElement root, MyProjectResult myProject)
    {
        List<string> componentFiles = root
            .Descendants(None + "Compile")
            .Where(static c => c.Elements(None + "SubType").Any(s => s.Value == "Component"))
            .Select(static c => (string?)c.Attribute("Update") ?? (string?)c.Attribute("Include"))
            .Where(static path => path is not null && path.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
            .Where(static path => !path!.Replace('/', '\\').StartsWith("My Project\\", StringComparison.OrdinalIgnoreCase))
            .Select(static path => Path.ChangeExtension(path!, ".cs"))
            .ToList();

        bool hasDesignerItems = myProject.HasResources || myProject.HasSettings;
        if (componentFiles.Count == 0 && !hasDesignerItems)
        {
            return;
        }

        sb.AppendLine();
        sb.AppendLine("  <ItemGroup>");
        foreach (string file in componentFiles)
        {
            sb.AppendLine($"    <Compile Update=\"{file}\">");
            sb.AppendLine("      <SubType>Component</SubType>");
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
