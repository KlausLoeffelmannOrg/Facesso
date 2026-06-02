namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Parsed command line options for the <c>vbconvert</c> tool.
/// </summary>
internal sealed class CliOptions
{
    /// <summary>
    ///  Gets the full path to the Visual Basic project (<c>.vbproj</c>) to convert.
    /// </summary>
    public required string ProjectPath { get; init; }

    /// <summary>
    ///  Gets the optional output directory. When <see langword="null"/> the converted <c>.cs</c> files
    ///  are written next to their <c>.vb</c> originals.
    /// </summary>
    public string? OutputDirectory { get; init; }

    /// <summary>
    ///  Gets a value indicating whether converted <c>.cs</c> files are written to disk. When
    ///  <see langword="false"/> (the default) the tool performs a dry run and only reports.
    /// </summary>
    public bool WriteFiles { get; init; }

    /// <summary>
    ///  Gets the optional path of a report file to write (in addition to the console summary).
    /// </summary>
    public string? ReportPath { get; init; }

    public static CliOptions? Parse(string[] args)
    {
        if (args.Length == 0)
        {
            return null;
        }

        string? projectPath = null;
        string? output = null;
        string? report = null;
        bool write = false;

        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];
            switch (arg)
            {
                case "--out" when i + 1 < args.Length:
                    output = args[++i];
                    break;

                case "--report" when i + 1 < args.Length:
                    report = args[++i];
                    break;

                case "--write":
                    write = true;
                    break;

                default:
                    if (arg.StartsWith('-'))
                    {
                        Console.Error.WriteLine($"Unknown option '{arg}'.");
                        return null;
                    }

                    projectPath = Path.GetFullPath(arg);
                    break;
            }
        }

        if (projectPath is null)
        {
            return null;
        }

        return new CliOptions
        {
            ProjectPath = projectPath,
            OutputDirectory = output is null ? null : Path.GetFullPath(output),
            WriteFiles = write,
            ReportPath = report is null ? null : Path.GetFullPath(report),
        };
    }

    public static void PrintUsage()
    {
        Console.Error.WriteLine("""
            vbconvert - Visual Basic to C# project source converter (WARP)

            Usage:
              vbconvert <project.vbproj> [--write] [--out <dir>] [--report <file>]

            Options:
              --write          Write converted .cs files to disk (default: dry run).
              --out <dir>      Output directory for .cs files (default: next to the .vb files).
              --report <file>  Also write the conversion report to <file>.
            """);
    }
}
