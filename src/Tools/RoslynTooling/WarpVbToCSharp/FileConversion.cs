using WarpToolkit.Desktop.Roslyn.VisualBasic.Conversion;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  The result of converting one Visual Basic source file to C#.
/// </summary>
/// <param name="SourcePath">The full path of the original <c>.vb</c> file.</param>
/// <param name="OutputPath">The full path the converted <c>.cs</c> file is (or would be) written to.</param>
/// <param name="CSharp">The emitted C# source text.</param>
/// <param name="Diagnostics">The structured conversion diagnostics for this file.</param>
/// <param name="Handlers">The <c>Handles</c> wirings captured from this file.</param>
internal sealed record FileConversion(
    string SourcePath,
    string OutputPath,
    string CSharp,
    IReadOnlyList<ConversionDiagnostic> Diagnostics,
    IReadOnlyList<HandlesWiring> Handlers);
