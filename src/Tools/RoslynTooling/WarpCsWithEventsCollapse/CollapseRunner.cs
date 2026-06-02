using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using WarpToolkit.Desktop.Roslyn.CSharp.WithEvents;

namespace Warp.CsWithEventsCollapse.Cli;

/// <summary>
///  Loads a C# project or solution with an MSBuild workspace, runs the WARP
///  <see cref="WithEventsCollapser"/> over each C# project's compilation, optionally writes the rewritten
///  documents back to disk, and reports the collapsed and retained members.
/// </summary>
internal sealed class CollapseRunner
{
    private readonly CollapseCliOptions _options;

    public CollapseRunner(CollapseCliOptions options)
        => _options = options;

    public async Task<int> RunAsync()
    {
        if (!File.Exists(_options.TargetPath))
        {
            Console.Error.WriteLine($"Target not found: {_options.TargetPath}");
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

        IReadOnlyList<Project> projects = await LoadProjectsAsync(workspace).ConfigureAwait(false);
        IReadOnlyList<Project> csharpProjects = projects
            .Where(static p => p.Language == LanguageNames.CSharp)
            .ToList();

        Console.Error.WriteLine(
            $"Loaded {projects.Count} project(s); {csharpProjects.Count} C# project(s) to inspect.");

        WithEventsCollapseOptions collapseOptions = new()
        {
            AnnotateRetainedWithTodo = _options.AnnotateRetained,
        };

        StringBuilder report = new();
        report.AppendLine($"cswithevents report for {_options.TargetPath}");
        report.AppendLine(_options.WriteFiles ? "Mode: WRITE" : "Mode: DRY RUN");
        report.AppendLine();

        int totalCollapsed = 0;
        int totalRetained = 0;
        int totalFilesWritten = 0;

        foreach (Project project in csharpProjects)
        {
            Console.Error.WriteLine($"Inspecting {project.Name} ...");

            Compilation? compilation = await project.GetCompilationAsync().ConfigureAwait(false);
            if (compilation is null)
            {
                Console.Error.WriteLine($"  [skip] no compilation for {project.Name}.");
                continue;
            }

            WithEventsCollapseReport result = WithEventsCollapser.Collapse(compilation, collapseOptions);

            if (result.Collapsed.Count == 0 && result.Retained.Count == 0)
            {
                continue;
            }

            report.AppendLine($"Project: {project.Name}");

            foreach (CollapsedMember collapsed in result.Collapsed)
            {
                report.AppendLine(
                    $"  [collapse] {collapsed.TypeName}.{collapsed.MemberName} ({collapsed.EventCount} event(s))");
            }

            foreach (RetainedMember retained in result.Retained)
            {
                report.AppendLine(
                    $"  [retain ] {retained.TypeName}.{retained.MemberName} :: {retained.Eligibility} - {retained.Detail}");
            }

            totalCollapsed += result.Collapsed.Count;
            totalRetained += result.Retained.Count;

            if (_options.WriteFiles)
            {
                int written = WriteRewrittenRoots(result);
                totalFilesWritten += written;
                report.AppendLine($"  Files rewritten: {written}");
            }
            else
            {
                report.AppendLine($"  Files that would change: {result.RewrittenRoots.Count}");
            }

            report.AppendLine();
        }

        report.AppendLine(
            $"Totals: {totalCollapsed} collapsed, {totalRetained} retained, "
            + (_options.WriteFiles ? $"{totalFilesWritten} file(s) written." : "dry run (no files written)."));

        string reportText = report.ToString();
        Console.WriteLine(reportText);

        if (_options.ReportPath is not null)
        {
            await File.WriteAllTextAsync(_options.ReportPath, reportText).ConfigureAwait(false);
        }

        return 0;
    }

    private async Task<IReadOnlyList<Project>> LoadProjectsAsync(MSBuildWorkspace workspace)
    {
        if (_options.TargetPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase))
        {
            Console.Error.WriteLine($"Opening solution {Path.GetFileName(_options.TargetPath)} ...");
            Solution solution = await workspace.OpenSolutionAsync(_options.TargetPath).ConfigureAwait(false);
            return solution.Projects.ToList();
        }

        Console.Error.WriteLine($"Opening project {Path.GetFileName(_options.TargetPath)} ...");
        Project project = await workspace.OpenProjectAsync(_options.TargetPath).ConfigureAwait(false);
        return [project];
    }

    /// <summary>
    ///  Persists each rewritten syntax-tree root to its originating file, preserving the original encoding.
    /// </summary>
    private static int WriteRewrittenRoots(WithEventsCollapseReport result)
    {
        int written = 0;

        foreach ((SyntaxTree tree, SyntaxNode root) in result.RewrittenRoots)
        {
            string? path = tree.FilePath;
            if (string.IsNullOrEmpty(path))
            {
                Console.Error.WriteLine("  [warn] rewritten tree has no file path; skipped.");
                continue;
            }

            SourceText newText = root.GetText();
            Encoding encoding = newText.Encoding ?? new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

            using StreamWriter writer = new(path, append: false, encoding);
            newText.Write(writer);

            written++;
            Console.Error.WriteLine($"  [write] {path}");
        }

        return written;
    }
}
