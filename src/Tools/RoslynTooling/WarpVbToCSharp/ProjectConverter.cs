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

        List<FileConversion> conversions = [];

        foreach (Document document in project.Documents)
        {
            if (document.FilePath is null
                || !document.FilePath.EndsWith(".vb", StringComparison.OrdinalIgnoreCase)
                || IsGeneratedPath(document.FilePath))
            {
                continue;
            }

            FileConversion conversion = await ConvertDocumentAsync(
                document,
                rootNamespace,
                projectImports).ConfigureAwait(false);

            conversions.Add(conversion);

            if (_options.WriteFiles)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(conversion.OutputPath)!);
                await File.WriteAllTextAsync(conversion.OutputPath, conversion.CSharp).ConfigureAwait(false);
            }
        }

        string report = ReportBuilder.Build(_options.ProjectPath, conversions, _options.WriteFiles);
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
        IReadOnlyList<string> projectImports)
    {
        SourceText text = await document.GetTextAsync().ConfigureAwait(false);
        SemanticModel? semanticModel = await document.GetSemanticModelAsync().ConfigureAwait(false);

        ConversionOptions options = new()
        {
            RootNamespace = rootNamespace,
            ProjectLevelImports = projectImports,
            FileName = Path.GetFileName(document.FilePath!),
        };

        ConversionResult result = VisualBasicConverter.ConvertText(text.ToString(), options, semanticModel);

        return new FileConversion(
            document.FilePath!,
            DetermineOutputPath(document.FilePath!),
            result.CSharpText,
            result.Diagnostics,
            result.Handlers);
    }

    private string DetermineOutputPath(string vbPath)
    {
        string csName = Path.ChangeExtension(Path.GetFileName(vbPath), ".cs");

        if (_options.OutputDirectory is null)
        {
            return Path.Combine(Path.GetDirectoryName(vbPath)!, csName);
        }

        string projectDir = Path.GetDirectoryName(_options.ProjectPath)!;
        string relativeDir = Path.GetRelativePath(projectDir, Path.GetDirectoryName(vbPath)!);
        return Path.Combine(_options.OutputDirectory, relativeDir, csName);
    }

    private static bool IsGeneratedPath(string path)
    {
        string normalized = path.Replace('/', '\\');
        return normalized.Contains("\\obj\\", StringComparison.OrdinalIgnoreCase)
            || normalized.Contains("\\bin\\", StringComparison.OrdinalIgnoreCase);
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
