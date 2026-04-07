using System.Threading.Tasks;
using WinForms.Analyzers.Tests.Verifiers;
using Xunit;

namespace WinForms.Analyzers.Tests.AnalyzerTests;

/// <summary>
///  Tests for <see cref="PropertyCreatesNewInstanceAnalyzer"/>.
/// </summary>
public class PropertyCreatesNewInstanceAnalyzerTests
{
    private static readonly string s_diagnosticId = "WFOWARP9918";

    [Fact]
    public async Task ExpressionBodiedProperty_WithObjectCreation_ReportsDiagnostic()
    {
        const string source = """
            using System.Drawing;

            public class MyControl
            {
                public Brush BackgroundBrush => new SolidBrush(Color.Red);
            }
            """;

        var expected = CSharpAnalyzerVerifier<PropertyCreatesNewInstanceAnalyzer>
            .Diagnostic(s_diagnosticId)
            .WithSpan(5, 18, 5, 33)
            .WithArguments("BackgroundBrush");

        await CSharpAnalyzerVerifier<PropertyCreatesNewInstanceAnalyzer>
            .VerifyAnalyzerAsync(source, expected);
    }

    [Fact]
    public async Task ExpressionBodiedProperty_WithoutObjectCreation_NoDiagnostic()
    {
        const string source = """
            public class MyControl
            {
                private string _name = "test";
                public string Name => _name;
            }
            """;

        await CSharpAnalyzerVerifier<PropertyCreatesNewInstanceAnalyzer>
            .VerifyNoDiagnosticsAsync(source);
    }

    [Fact]
    public async Task AutoProperty_WithInitializer_NoDiagnostic()
    {
        const string source = """
            public class MyControl
            {
                public string Name { get; set; } = "default";
            }
            """;

        await CSharpAnalyzerVerifier<PropertyCreatesNewInstanceAnalyzer>
            .VerifyNoDiagnosticsAsync(source);
    }
}
