using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using WarpToolkit.Desktop.Roslyn.VisualBasic.Conversion;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Loads a Visual Basic project with an MSBuild workspace, converts each source document to C# using
///  the WARP <see cref="VisualBasicConverter"/>, and reports the diagnostics and captured event wirings.
/// </summary>
internal sealed class ProjectConverter
{
    private readonly CliOptions _options;

    public ProjectConverter(CliOptions options)
        => _options = options;

    public async Task<int> RunAsync()
    {
        if (!File.Exists(_options.ProjectPath))
        {
            Console.Error.WriteLine($"Project not found: {_options.ProjectPath}");
            return 1;
        }

        using MSBuildWorkspace workspace = MSBuildWorkspace.Create();
        workspace.WorkspaceFailed += (_, e) =>
        {
            if (e.Diagnostic.Kind == WorkspaceDiagnosticKind.Failure)
            {
                Console.Error.WriteLine($"  [workspace] {e.Diagnostic.Message}");
            }
        };

        Console.Error.WriteLine($"Opening {Path.GetFileName(_options.ProjectPath)} ...");
        Project project = await workspace.OpenProjectAsync(_options.ProjectPath).ConfigureAwait(false);

        (string? rootNamespace, IReadOnlyList<string> projectImports) = ReadVbProjectSettings(project);
        Console.Error.WriteLine($"RootNamespace: {rootNamespace ?? "(none)"}");
        Console.Error.WriteLine($"Project-level imports: {projectImports.Count}");

        IReadOnlyList<SyntaxNode> roots = await CollectProjectRootsAsync(project).ConfigureAwait(false);
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, IReadOnlyList<WithEventsHandler>>> projectHandlers =
            VisualBasicConverter.CollectWithEventsHandlers(roots);
        Console.Error.WriteLine($"Types with cross-file WithEvents handlers: {projectHandlers.Count}");

        IReadOnlyDictionary<string, TypeConstructionInfo> projectConstruction =
            VisualBasicConverter.CollectTypeConstruction(roots);
        Console.Error.WriteLine($"Types with construction info: {projectConstruction.Count}");

        List<FileConversion> conversions = [];

        foreach (Document document in project.Documents)
        {
            if (document.FilePath is null
                || !document.FilePath.EndsWith(".vb", StringComparison.OrdinalIgnoreCase)
                || IsGeneratedPath(document.FilePath)
                || IsMyProjectScaffoldFile(document.FilePath))
            {
                continue;
            }

            FileConversion conversion = await ConvertDocumentAsync(
                document,
                rootNamespace,
                projectImports,
                projectHandlers,
                projectConstruction).ConfigureAwait(false);

            conversions.Add(conversion);

            if (_options.WriteFiles)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(conversion.OutputPath)!);
                await File.WriteAllTextAsync(conversion.OutputPath, conversion.CSharp).ConfigureAwait(false);
            }
        }

        List<string> projectWarnings = [];
        if (_options.WriteFiles)
        {
            EmitProjectFile(rootNamespace, projectWarnings);
        }

        string report = ReportBuilder.Build(_options.ProjectPath, conversions, _options.WriteFiles);
        if (projectWarnings.Count > 0)
        {
            report += Environment.NewLine + "Project-file / My-namespace notes:" + Environment.NewLine
                + string.Join(Environment.NewLine, projectWarnings.Select(static w => "  - " + w));
        }

        Console.WriteLine(report);

        if (_options.ReportPath is not null)
        {
            await File.WriteAllTextAsync(_options.ReportPath, report).ConfigureAwait(false);
        }

        return 0;
    }

    private async Task<FileConversion> ConvertDocumentAsync(
        Document document,
        string? rootNamespace,
        IReadOnlyList<string> projectImports,
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, IReadOnlyList<WithEventsHandler>>> projectHandlers,
        IReadOnlyDictionary<string, TypeConstructionInfo> projectConstruction)
    {
        SourceText text = await document.GetTextAsync().ConfigureAwait(false);
        SemanticModel? semanticModel = await document.GetSemanticModelAsync().ConfigureAwait(false);

        ConversionOptions options = new()
        {
            RootNamespace = rootNamespace,
            ProjectLevelImports = projectImports,
            FileName = Path.GetFileName(document.FilePath!),
            ProjectWithEventsHandlers = projectHandlers,
            ProjectTypeConstruction = projectConstruction,
        };

        ConversionResult result = VisualBasicConverter.ConvertText(text.ToString(), options, semanticModel);

        return new FileConversion(
            document.FilePath!,
            DetermineOutputPath(document.FilePath!),
            result.CSharpText,
            result.Diagnostics,
            result.Handlers);
    }

    /// <summary>
    ///  Pre-pass that gathers the syntax root of every Visual Basic document in the project, shared by the
    ///  project-wide <c>WithEvents</c> handler and construction collectors.
    /// </summary>
    private static async Task<IReadOnlyList<SyntaxNode>> CollectProjectRootsAsync(Project project)
    {
        List<SyntaxNode> roots = [];

        foreach (Document document in project.Documents)
        {
            if (document.FilePath is null
                || !document.FilePath.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            SyntaxNode? root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
            if (root is not null)
            {
                roots.Add(root);
            }
        }

        return roots;
    }

    private string DetermineOutputPath(string vbPath)
    {
        string csName = Path.ChangeExtension(Path.GetFileName(vbPath), ".cs");

        if (_options.OutputDirectory is null)
        {
            // A VB project may LINK a source file from a sibling project (path escapes the project cone).
            // Such a file is compiled into THIS assembly with THIS project's root namespace, so its
            // converted output belongs in the project directory, not back in the originating folder.
            string ownerDir = Path.GetDirectoryName(_options.ProjectPath)!;
            string sourceDir = Path.GetDirectoryName(vbPath)!;
            if (!IsWithinDirectory(ownerDir, sourceDir))
            {
                return Path.Combine(ownerDir, csName);
            }

            return Path.Combine(sourceDir, csName);
        }

        string projectDir = Path.GetDirectoryName(_options.ProjectPath)!;
        string relativeDir = Path.GetRelativePath(projectDir, Path.GetDirectoryName(vbPath)!);
        return Path.Combine(_options.OutputDirectory, relativeDir, csName);
    }

    private static bool IsWithinDirectory(string parent, string candidate)
    {
        string relative = Path.GetRelativePath(parent, candidate);
        return relative != ".."
            && !relative.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal)
            && !Path.IsPathRooted(relative);
    }

    private static bool IsGeneratedPath(string path)
    {
        string normalized = path.Replace('/', '\\');
        return normalized.Contains("\\obj\\", StringComparison.OrdinalIgnoreCase)
            || normalized.Contains("\\bin\\", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    ///  Identifies the Visual Basic <c>My Project</c> files that are regenerated from canonical
    ///  C# templates by <see cref="MyProjectScaffolder"/> rather than translated literally.
    /// </summary>
    private static bool IsMyProjectScaffoldFile(string path)
    {
        string normalized = path.Replace('/', '\\');
        if (!normalized.Contains("\\My Project\\", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string fileName = Path.GetFileName(normalized);
        return fileName.Equals("MyResources.Designer.vb", StringComparison.OrdinalIgnoreCase)
            || fileName.Equals("MySettings.Designer.vb", StringComparison.OrdinalIgnoreCase)
            || fileName.Equals("MyApplication.Designer.vb", StringComparison.OrdinalIgnoreCase)
            || fileName.Equals("AssemblyInfo.vb", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    ///  Scaffolds the converted <c>My Project</c> folder and writes the generated SDK-style
    ///  <c>.csproj</c> beside (or under the output mirror of) the original project.
    /// </summary>
    private void EmitProjectFile(string? rootNamespace, List<string> warnings)
    {
        string projectDir = Path.GetDirectoryName(_options.ProjectPath)!;
        string outputProjectDir = _options.OutputDirectory ?? projectDir;
        string root = rootNamespace ?? Path.GetFileNameWithoutExtension(_options.ProjectPath);

        MyProjectResult myProject = new();
        string sourceMyProject = Path.Combine(projectDir, "My Project");
        if (Directory.Exists(sourceMyProject))
        {
            myProject = new MyProjectScaffolder(
                sourceMyProject,
                Path.Combine(outputProjectDir, "My Project"),
                root,
                warnings).Run();
        }

        string csproj = CsprojGenerator.Generate(_options.ProjectPath, root, myProject);
        string csprojPath = Path.Combine(
            outputProjectDir,
            Path.GetFileNameWithoutExtension(_options.ProjectPath) + ".csproj");

        Directory.CreateDirectory(outputProjectDir);
        File.WriteAllText(csprojPath, csproj);
        Console.Error.WriteLine($"Generated project file: {csprojPath}");
    }

    private static (string? RootNamespace, IReadOnlyList<string> Imports) ReadVbProjectSettings(Project project)
    {
        if (project.CompilationOptions is not VisualBasicCompilationOptions vbOptions)
        {
            return (project.DefaultNamespace, []);
        }

        string? rootNamespace = string.IsNullOrEmpty(vbOptions.RootNamespace)
            ? project.DefaultNamespace
            : vbOptions.RootNamespace;

        List<string> imports = [];
        foreach (GlobalImport import in vbOptions.GlobalImports)
        {
            string name = import.Name;

            // Skip aliased imports ('Alias = Namespace'); they need a using-alias and are rare at project level.
            if (!name.Contains('='))
            {
                imports.Add(name);
            }
        }

        return (rootNamespace, imports);
    }
}
