using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that detects expression-bodied properties that create new instances
///  on every access, which can cause memory leaks.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class PropertyCreatesNewInstanceAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => [DiagnosticDescriptors.PropertyCreatesNewInstancePerAccess];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(compilationContext =>
        {
            Compilation compilation = compilationContext.Compilation;

            compilationContext.RegisterSyntaxNodeAction(
                nodeContext => AnalyzeProperty(nodeContext, compilation),
                SyntaxKind.PropertyDeclaration);
        });
    }

    private static void AnalyzeProperty(SyntaxNodeAnalysisContext context, Compilation compilation)
    {
        PropertyDeclarationSyntax property = (PropertyDeclarationSyntax)context.Node;

        ExpressionSyntax? expressionToCheck = null;
        string? filePath = context.Node.SyntaxTree.FilePath;

        bool isInDesignerFile = filePath is not null
            && (filePath.EndsWith(".designer.cs", StringComparison.OrdinalIgnoreCase)
            || filePath.EndsWith(".Designer.cs", StringComparison.Ordinal));

        if (property.ExpressionBody is not null)
        {
            expressionToCheck = property.ExpressionBody.Expression;
        }
        else if (isInDesignerFile && property.Initializer is not null)
        {
            expressionToCheck = property.Initializer.Value;
        }

        if (expressionToCheck is null)
        {
            return;
        }

        if (ContainsObjectCreation(expressionToCheck))
        {
            string propertyName = property.Identifier.Text;

            Diagnostic diagnostic = Diagnostic
                .Create(
                    DiagnosticDescriptors.PropertyCreatesNewInstancePerAccess,
                    property.Identifier.GetLocation(),
                    propertyName);

            context.ReportDiagnostic(diagnostic);
        }
    }

    private static bool ContainsObjectCreation(ExpressionSyntax expression)
    {
        if (expression is ObjectCreationExpressionSyntax or ImplicitObjectCreationExpressionSyntax)
        {
            return true;
        }

        foreach (SyntaxNode node in expression.DescendantNodes())
        {
            if (node is ObjectCreationExpressionSyntax or ImplicitObjectCreationExpressionSyntax)
            {
                return true;
            }
        }

        return false;
    }
}
