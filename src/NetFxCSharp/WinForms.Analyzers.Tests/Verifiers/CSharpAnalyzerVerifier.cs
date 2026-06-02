using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace WinForms.Analyzers.Tests.Verifiers;

/// <summary>
///  Helper for creating and running C# analyzer verification tests.
/// </summary>
public static class CSharpAnalyzerVerifier<TAnalyzer>
    where TAnalyzer : DiagnosticAnalyzer, new()
{
    /// <summary>
    ///  Creates a diagnostic result for the expected diagnostic from the analyzer.
    /// </summary>
    public static DiagnosticResult Diagnostic(string diagnosticId)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(diagnosticId);

    /// <summary>
    ///  Creates a diagnostic result for the expected diagnostic descriptor.
    /// </summary>
    public static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(descriptor);

    /// <summary>
    ///  Verifies the analyzer produces no diagnostics for the given source.
    /// </summary>
    public static async Task VerifyNoDiagnosticsAsync(string source)
    {
        var test = new Test
        {
            TestCode = source,
        };

        await test.RunAsync(CancellationToken.None);
    }

    /// <summary>
    ///  Verifies the analyzer produces the expected diagnostics for the given source.
    /// </summary>
    public static async Task VerifyAnalyzerAsync(string source, params DiagnosticResult[] expected)
    {
        var test = new Test
        {
            TestCode = source,
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync(CancellationToken.None);
    }

    /// <summary>
    ///  Test class that supports multiple source files (for code-behind + designer scenarios).
    /// </summary>
    public class Test : CSharpAnalyzerTest<TAnalyzer, DefaultVerifier>
    {
        public Test()
        {
            // Add reference to System.Windows.Forms for UserControl/Form base types
            ReferenceAssemblies = ReferenceAssemblies.NetFramework.Net472.WindowsForms;
        }
    }
}
