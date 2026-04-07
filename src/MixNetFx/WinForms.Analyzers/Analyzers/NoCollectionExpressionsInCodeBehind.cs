using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that ensures collection expressions are not used in WinForms code-behind files.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class NoCollectionExpressionsInCodeBehind : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => [DiagnosticDescriptors.NoCollectionExpressionsInCodeBehind];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(compilationContext =>
        {
            Compilation compilation = compilationContext.Compilation;

            compilationContext.RegisterSyntaxTreeAction(treeContext =>
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

        foreach (CollectionExpressionSyntax collectionExpression in root.DescendantNodes().OfType<CollectionExpressionSyntax>())
        {
            Diagnostic diagnostic = Diagnostic.Create(
                DiagnosticDescriptors.NoCollectionExpressionsInCodeBehind,
                collectionExpression.GetLocation());

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
