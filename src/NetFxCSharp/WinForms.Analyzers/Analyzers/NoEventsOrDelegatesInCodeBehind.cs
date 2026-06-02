using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that ensures events and delegates are not defined in WinForms code-behind files.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class NoEventsOrDelegatesInCodeBehind : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        =>
        [
            DiagnosticDescriptors.NoEventsInCodeBehind,
            DiagnosticDescriptors.NoDelegatesInCodeBehind
        ];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(compilationContext =>
        {
            Compilation compilation = compilationContext.Compilation;

            compilationContext.RegisterSyntaxTreeAction(treeContext
                =>
                {
                    AnalyzeSyntaxTree(treeContext, compilation);
                });
        });
    }

    private static void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context, Compilation compilation)
    {
        SyntaxTree tree = context.Tree;
        string filePath = tree.FilePath ?? string.Empty;

        if (!filePath.EndsWith(".designer.cs", System.StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        string mainPath = GetMainFilePath(filePath);
        SyntaxTree? mainTree = compilation
            .SyntaxTrees
            .FirstOrDefault(t => t.FilePath.Equals(mainPath, System.StringComparison.OrdinalIgnoreCase));

        if (mainTree is null || !CodeBehindDetector.IsCodeBehindFile(mainTree, compilation))
        {
            return;
        }

        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        foreach (EventFieldDeclarationSyntax eventField in root.DescendantNodes().OfType<EventFieldDeclarationSyntax>())
        {
            foreach (VariableDeclaratorSyntax variable in eventField.Declaration.Variables)
            {
                Diagnostic diagnostic = Diagnostic.Create(
                    DiagnosticDescriptors.NoEventsInCodeBehind,
                    variable.Identifier.GetLocation(),
                    variable.Identifier.Text);

                context.ReportDiagnostic(diagnostic);
            }
        }

        foreach (DelegateDeclarationSyntax delegateDecl in root.DescendantNodes().OfType<DelegateDeclarationSyntax>())
        {
            Diagnostic diagnostic = Diagnostic.Create(
                DiagnosticDescriptors.NoDelegatesInCodeBehind,
                delegateDecl.Identifier.GetLocation(),
                delegateDecl.Identifier.Text);

            context.ReportDiagnostic(diagnostic);
        }
    }

    private static string GetMainFilePath(string designerPath)
    {
        if (designerPath.EndsWith(".designer.cs", System.StringComparison.OrdinalIgnoreCase))
        {
            return designerPath[..^".designer.cs".Length] + ".cs";
        }

        return designerPath;
    }
}
