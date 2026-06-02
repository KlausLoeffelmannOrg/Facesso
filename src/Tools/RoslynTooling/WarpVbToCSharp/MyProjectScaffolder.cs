using System.Text;
using System.Text.RegularExpressions;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Result of scaffolding a converted <c>My Project</c> folder, describing which canonical
///  C# artifacts were produced so the project-file generator can wire them up.
/// </summary>
internal sealed class MyProjectResult
{
    public bool HasResources { get; init; }

    public bool HasSettings { get; init; }

    public bool HasAssemblyInfo { get; init; }
}

/// <summary>
///  Regenerates the canonical C# <c>My Project</c> artifacts for a converted Visual Basic project.
/// </summary>
/// <remarks>
///  The Visual Basic <c>My</c> namespace is compiler-injected boilerplate. A literal syntax
///  translation of <c>MyResources.Designer.vb</c> / <c>MySettings.Designer.vb</c> would produce
///  the wrong namespaces, type names and embedded-resource base names, so those files are replaced
///  with canonical C# templates parameterised by the project's root namespace. The application
///  framework file (<c>MyApplication.*</c>) is dropped for libraries. <c>AssemblyInfo.vb</c> is
///  transformed mechanically because the source converter does not yet emit assembly-level
///  attribute statements.
/// </remarks>
internal sealed class MyProjectScaffolder
{
    private readonly string _myProjectSourceDir;
    private readonly string _myProjectOutputDir;
    private readonly string _rootNamespace;
    private readonly List<string> _warnings;

    public MyProjectScaffolder(
        string myProjectSourceDir,
        string myProjectOutputDir,
        string rootNamespace,
        List<string> warnings)
    {
        _myProjectSourceDir = myProjectSourceDir;
        _myProjectOutputDir = myProjectOutputDir;
        _rootNamespace = rootNamespace;
        _warnings = warnings;
    }

    public MyProjectResult Run()
    {
        Directory.CreateDirectory(_myProjectOutputDir);

        bool hasResources = EmitResources();
        bool hasSettings = EmitSettings();
        bool hasAssemblyInfo = EmitAssemblyInfo();

        return new MyProjectResult
        {
            HasResources = hasResources,
            HasSettings = hasSettings,
            HasAssemblyInfo = hasAssemblyInfo,
        };
    }

    private bool EmitResources()
    {
        string sourceResx = Path.Combine(_myProjectSourceDir, "MyResources.resx");
        if (!File.Exists(sourceResx))
        {
            return false;
        }

        if (ResxHasEntries(sourceResx))
        {
            _warnings.Add("My Project\\MyResources.resx has named entries; the generated "
                + "Resources.Designer.cs only provides the ResourceManager plumbing and will NOT expose "
                + "strongly-typed accessors. Regenerate from the .resx after conversion.");
        }

        File.Copy(sourceResx, Path.Combine(_myProjectOutputDir, "Resources.resx"), overwrite: true);
        File.WriteAllText(
            Path.Combine(_myProjectOutputDir, "Resources.Designer.cs"),
            BuildResourcesDesigner(),
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        return true;
    }

    private bool EmitSettings()
    {
        string sourceSettings = Path.Combine(_myProjectSourceDir, "MySettings.settings");
        if (!File.Exists(sourceSettings))
        {
            return false;
        }

        if (SettingsHasEntries(sourceSettings))
        {
            _warnings.Add("My Project\\MySettings.settings has named settings; the generated "
                + "Settings.Designer.cs only provides the Default plumbing and will NOT expose those "
                + "settings. Regenerate from the .settings after conversion.");
        }

        File.WriteAllText(
            Path.Combine(_myProjectOutputDir, "Settings.settings"),
            CanonicalSettingsFile,
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        File.WriteAllText(
            Path.Combine(_myProjectOutputDir, "Settings.Designer.cs"),
            BuildSettingsDesigner(),
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        return true;
    }

    private bool EmitAssemblyInfo()
    {
        string sourceInfo = Path.Combine(_myProjectSourceDir, "AssemblyInfo.vb");
        if (!File.Exists(sourceInfo))
        {
            return false;
        }

        File.WriteAllText(
            Path.Combine(_myProjectOutputDir, "AssemblyInfo.cs"),
            ConvertAssemblyInfo(File.ReadAllLines(sourceInfo)),
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        return true;
    }

    private static bool ResxHasEntries(string resxPath)
    {
        try
        {
            return System.Xml.Linq.XDocument.Load(resxPath)
                .Descendants("data")
                .Any();
        }
        catch (Exception ex) when (ex is IOException or System.Xml.XmlException)
        {
            return false;
        }
    }

    private static bool SettingsHasEntries(string settingsPath)
    {
        try
        {
            return Regex.IsMatch(File.ReadAllText(settingsPath), "<Setting\\b", RegexOptions.IgnoreCase);
        }
        catch (IOException)
        {
            return false;
        }
    }

    private static string ConvertAssemblyInfo(IEnumerable<string> vbLines)
    {
        StringBuilder builder = new();
        builder.AppendLine("using System;");
        builder.AppendLine("using System.Reflection;");
        builder.AppendLine("using System.Runtime.InteropServices;");
        builder.AppendLine();

        foreach (string line in vbLines)
        {
            Match match = Regex.Match(line.Trim(), "^<Assembly:\\s*(?<body>.+?)>\\s*$");
            if (!match.Success)
            {
                continue;
            }

            string body = match.Groups["body"].Value.Trim();
            body = Regex.Replace(body, "\\bTrue\\b", "true");
            body = Regex.Replace(body, "\\bFalse\\b", "false");
            builder.Append("[assembly: ").Append(body).AppendLine("]");
        }

        return builder.ToString();
    }

    private string BuildResourcesDesigner() => $$"""
        //------------------------------------------------------------------------------
        // <auto-generated>
        //     This code was generated by a tool.
        //     Changes to this file may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        using System.ComponentModel;
        using System.Globalization;
        using System.Resources;

        namespace {{_rootNamespace}}.My.Resources
        {
            [global::System.Diagnostics.DebuggerNonUserCode]
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            internal static class Resources
            {
                private static ResourceManager resourceMan;
                private static CultureInfo resourceCulture;

                [EditorBrowsable(EditorBrowsableState.Advanced)]
                internal static ResourceManager ResourceManager
                {
                    get
                    {
                        if (ReferenceEquals(resourceMan, null))
                        {
                            resourceMan = new ResourceManager("{{_rootNamespace}}.Resources", typeof(Resources).Assembly);
                        }

                        return resourceMan;
                    }
                }

                [EditorBrowsable(EditorBrowsableState.Advanced)]
                internal static CultureInfo Culture
                {
                    get { return resourceCulture; }
                    set { resourceCulture = value; }
                }
            }
        }

        """;

    private string BuildSettingsDesigner() => $$"""
        //------------------------------------------------------------------------------
        // <auto-generated>
        //     This code was generated by a tool.
        //     Changes to this file may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        using System.CodeDom.Compiler;
        using System.ComponentModel;
        using System.Configuration;
        using System.Runtime.CompilerServices;

        namespace {{_rootNamespace}}.My
        {
            [CompilerGenerated]
            [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
            [EditorBrowsable(EditorBrowsableState.Advanced)]
            internal sealed partial class Settings : ApplicationSettingsBase
            {
                private static readonly Settings defaultInstance =
                    (Settings)Synchronized(new Settings());

                public static Settings Default
                {
                    get { return defaultInstance; }
                }
            }

            [CompilerGenerated]
            internal static class MySettingsProperty
            {
                internal static Settings Settings
                {
                    get { return {{_rootNamespace}}.My.Settings.Default; }
                }
            }
        }

        """;

    private const string CanonicalSettingsFile =
        "<?xml version='1.0' encoding='utf-8'?>\r\n"
        + "<SettingsFile xmlns=\"http://schemas.microsoft.com/VisualStudio/2004/01/settings\" CurrentProfile=\"(Default)\">\r\n"
        + "  <Profiles>\r\n"
        + "    <Profile Name=\"(Default)\" />\r\n"
        + "  </Profiles>\r\n"
        + "  <Settings />\r\n"
        + "</SettingsFile>";
}
