using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using WinForms.Analyzers.Tests.Verifiers;
using Xunit;

namespace WinForms.Analyzers.Tests.AnalyzerTests;

/// <summary>
///  Tests for <see cref="NoControlFlowInInitializeComponent"/>.
/// </summary>
public class NoControlFlowInInitializeComponentTests
{
    [Fact]
    public async Task ForLoop_InInitializeComponent_ReportsDiagnostic()
    {
        var test = new CSharpAnalyzerVerifier<NoControlFlowInInitializeComponent>.Test();

        // Main file (code-behind)
        test.TestState.Sources.Add(("MyForm.cs", """
            using System.Windows.Forms;

            namespace TestApp
            {
                public partial class MyForm : Form
                {
                    public MyForm()
                    {
                        InitializeComponent();
                    }
                }
            }
            """));

        // Designer file
        test.TestState.Sources.Add(("MyForm.designer.cs", """
            namespace TestApp
            {
                partial class MyForm
                {
                    private void InitializeComponent()
                    {
                        for (int i = 0; i < 10; i++)
                        {
                        }
                    }

                    private System.Windows.Forms.Button button1;
                }
            }
            """));

        test.ExpectedDiagnostics.Add(
            CSharpAnalyzerVerifier<NoControlFlowInInitializeComponent>
                .Diagnostic("WFOWARP9902")
                .WithSpan("MyForm.designer.cs", 7, 13, 7, 16));

        await test.RunAsync();
    }

    [Fact]
    public async Task IfStatement_InInitializeComponent_ReportsDiagnostic()
    {
        var test = new CSharpAnalyzerVerifier<NoControlFlowInInitializeComponent>.Test();

        test.TestState.Sources.Add(("MyForm.cs", """
            using System.Windows.Forms;

            namespace TestApp
            {
                public partial class MyForm : Form
                {
                    public MyForm()
                    {
                        InitializeComponent();
                    }
                }
            }
            """));

        test.TestState.Sources.Add(("MyForm.designer.cs", """
            namespace TestApp
            {
                partial class MyForm
                {
                    private void InitializeComponent()
                    {
                        if (true)
                        {
                        }
                    }

                    private System.Windows.Forms.Button button1;
                }
            }
            """));

        test.ExpectedDiagnostics.Add(
            CSharpAnalyzerVerifier<NoControlFlowInInitializeComponent>
                .Diagnostic("WFOWARP9905")
                .WithSpan("MyForm.designer.cs", 7, 13, 7, 15));

        await test.RunAsync();
    }

    [Fact]
    public async Task CleanInitializeComponent_NoDiagnostics()
    {
        var test = new CSharpAnalyzerVerifier<NoControlFlowInInitializeComponent>.Test();

        test.TestState.Sources.Add(("MyForm.cs", """
            using System.Windows.Forms;

            namespace TestApp
            {
                public partial class MyForm : Form
                {
                    public MyForm()
                    {
                        InitializeComponent();
                    }
                }
            }
            """));

        test.TestState.Sources.Add(("MyForm.designer.cs", """
            namespace TestApp
            {
                partial class MyForm
                {
                    private void InitializeComponent()
                    {
                        this.button1 = new System.Windows.Forms.Button();
                        this.button1.Text = "Click me";
                    }

                    private System.Windows.Forms.Button button1;
                }
            }
            """));

        await test.RunAsync();
    }
}
