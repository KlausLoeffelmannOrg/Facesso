using System.Text;
using WarpToolkit.Desktop.Roslyn.VisualBasic.Conversion;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Builds the human-readable conversion report summarising per-file diagnostics, captured event
///  wirings, and the manual-work items left for review.
/// </summary>
internal static class ReportBuilder
{
    public static string Build(string projectPath, IReadOnlyList<FileConversion> conversions, bool wrote)
    {
        StringBuilder builder = new();
        builder.AppendLine("============================================================");
        builder.AppendLine($"VB -> C# conversion report: {Path.GetFileName(projectPath)}");
        builder.AppendLine($"Mode: {(wrote ? "WRITE" : "DRY RUN")}");
        builder.AppendLine($"Files converted: {conversions.Count}");
        builder.AppendLine("============================================================");

        int manual = 0;
        int warnings = 0;
        int handlers = 0;

        foreach (FileConversion conversion in conversions)
        {
            int fileManual = conversion.Diagnostics.Count(d => d.Severity == ConversionSeverity.Manual);
            int fileWarnings = conversion.Diagnostics.Count(d => d.Severity == ConversionSeverity.Warning);

            manual += fileManual;
            warnings += fileWarnings;
            handlers += conversion.Handlers.Count;

            if (fileManual == 0 && fileWarnings == 0 && conversion.Handlers.Count == 0)
            {
                continue;
            }

            builder.AppendLine();
            builder.AppendLine($"{Path.GetFileName(conversion.SourcePath)}  " +
                $"(manual: {fileManual}, warnings: {fileWarnings}, handlers: {conversion.Handlers.Count})");

            foreach (ConversionDiagnostic diagnostic in conversion.Diagnostics
                .Where(d => d.Severity != ConversionSeverity.Info)
                .OrderByDescending(d => d.Severity)
                .ThenBy(d => d.Line))
            {
                builder.AppendLine($"    {diagnostic}");
            }

            foreach (HandlesWiring wiring in conversion.Handlers)
            {
                builder.AppendLine($"    HANDLES  {wiring.Target}.{wiring.EventName} += {wiring.HandlerMethod}");
            }
        }

        builder.AppendLine();
        builder.AppendLine("------------------------------------------------------------");
        builder.AppendLine($"TOTAL  manual: {manual}  warnings: {warnings}  handles-wirings: {handlers}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }
}
