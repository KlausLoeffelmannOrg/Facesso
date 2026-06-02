namespace Warp.CsWithEventsCollapse.Cli;

/// <summary>
///  Parsed command line options for the <c>cswithevents</c> tool.
/// </summary>
internal sealed class CollapseCliOptions
{
    /// <summary>
    ///  Gets the full path to the C# project (<c>.csproj</c>) or solution (<c>.sln</c>) to process.
    /// </summary>
    public required string TargetPath { get; init; }

    /// <summary>
    ///  Gets a value indicating whether rewritten files are written to disk. When <see langword="false"/>
    ///  (the default) the tool performs a dry run and only reports what it would change.
    /// </summary>
    public bool WriteFiles { get; init; }

    /// <summary>
    ///  Gets the optional path of a report file to write (in addition to the console summary).
    /// </summary>
    public string? ReportPath { get; init; }

    /// <summary>
    ///  Gets a value indicating whether retained (un-collapsed) re-wiring properties are annotated
    ///  with a <c>// TODO(vb-convert):</c> marker. Defaults to <see langword="true"/>.
    /// </summary>
    public bool AnnotateRetained { get; init; } = true;

    public static CollapseCliOptions? Parse(string[] args)
    {
        if (args.Length == 0)
        {
            return null;
        }

        string? targetPath = null;
        string? report = null;
        bool write = false;
        bool annotate = true;

        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];
            switch (arg)
            {
                case "--report" when i + 1 < args.Length:
                    report = args[++i];
                    break;

                case "--write":
                    write = true;
                    break;

                case "--no-todo":
                    annotate = false;
                    break;

                default:
                    if (arg.StartsWith('-'))
                    {
                        Console.Error.WriteLine($"Unknown option '{arg}'.");
                        return null;
                    }

                    targetPath = Path.GetFullPath(arg);
                    break;
            }
        }

        if (targetPath is null)
        {
            return null;
        }

        return new CollapseCliOptions
        {
            TargetPath = targetPath,
            WriteFiles = write,
            ReportPath = report is null ? null : Path.GetFullPath(report),
            AnnotateRetained = annotate,
        };
    }

    public static void PrintUsage()
    {
        Console.Error.WriteLine("""
            cswithevents - collapse VB WithEvents re-wiring properties to classic C# WinForms wiring (WARP)

            Usage:
              cswithevents <project.csproj | solution.sln> [--write] [--no-todo] [--report <file>]

            Options:
              --write          Write rewritten .cs files to disk (default: dry run).
              --no-todo        Do not annotate retained re-wiring properties with TODO markers.
              --report <file>  Also write the collapse report to <file>.
            """);
    }
}
