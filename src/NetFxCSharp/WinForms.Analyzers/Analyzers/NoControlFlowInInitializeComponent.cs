using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that ensures InitializeComponent methods in WinForms code-behind files
///  do not contain control flow statements or other prohibited constructs.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class NoControlFlowInInitializeComponent : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
    [
        DiagnosticDescriptors.NoForLoopInInitializeComponent,
        DiagnosticDescriptors.NoForEachLoopInInitializeComponent,
        DiagnosticDescriptors.NoWhileLoopInInitializeComponent,
        DiagnosticDescriptors.NoIfStatementInInitializeComponent,
        DiagnosticDescriptors.NoSwitchStatementInInitializeComponent,
        DiagnosticDescriptors.NoSwitchExpressionInInitializeComponent,
        DiagnosticDescriptors.NoLocalFunctionInInitializeComponent,
        DiagnosticDescriptors.NoGotoStatementInInitializeComponent,
        DiagnosticDescriptors.NoNameOfInInitializeComponent,
        DiagnosticDescriptors.NoTernaryOperatorInInitializeComponent,
        DiagnosticDescriptors.NoNullCoalescingOperatorInInitializeComponent,
        DiagnosticDescriptors.NoNullConditionalOperatorInInitializeComponent,
        DiagnosticDescriptors.NoStringInterpolationInInitializeComponent,
        DiagnosticDescriptors.NoLambdaExpressionInInitializeComponent,
        DiagnosticDescriptors.NoTryCatchInInitializeComponent,
        DiagnosticDescriptors.NoLockStatementInInitializeComponent
    ];

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
            .FirstOrDefault(
                t => t.FilePath.Equals(
                    mainPath,
                    System.StringComparison.OrdinalIgnoreCase));

        if (mainTree is null || !CodeBehindDetector.IsCodeBehindFile(mainTree, compilation))
        {
            return;
        }

        MethodDeclarationSyntax? initMethod = InitializeComponentDetector.GetInitializeComponentMethod(tree);

        if (initMethod is null || initMethod.Body is null)
        {
            return;
        }

        AnalyzeInitializeComponentBody(context, initMethod.Body);
    }

    private static void AnalyzeInitializeComponentBody(
        SyntaxTreeAnalysisContext context,
        BlockSyntax methodBody)
    {
        foreach (SyntaxNode node in methodBody.DescendantNodes())
        {
            switch (node)
            {
                case ForStatementSyntax forStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoForLoopInInitializeComponent,
                        forStatement.ForKeyword.GetLocation());
                    break;

                case ForEachStatementSyntax forEachStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoForEachLoopInInitializeComponent,
                        forEachStatement.ForEachKeyword.GetLocation());
                    break;

                case WhileStatementSyntax whileStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoWhileLoopInInitializeComponent,
                        whileStatement.WhileKeyword.GetLocation());
                    break;

                case DoStatementSyntax doStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoWhileLoopInInitializeComponent,
                        doStatement.DoKeyword.GetLocation());
                    break;

                case IfStatementSyntax ifStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoIfStatementInInitializeComponent,
                        ifStatement.IfKeyword.GetLocation());
                    break;

                case SwitchStatementSyntax switchStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoSwitchStatementInInitializeComponent,
                        switchStatement.SwitchKeyword.GetLocation());
                    break;

                case SwitchExpressionSyntax switchExpression:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoSwitchExpressionInInitializeComponent,
                        switchExpression.SwitchKeyword.GetLocation());
                    break;

                case LocalFunctionStatementSyntax localFunction:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoLocalFunctionInInitializeComponent,
                        localFunction.Identifier.GetLocation());
                    break;

                case GotoStatementSyntax gotoStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoGotoStatementInInitializeComponent,
                        gotoStatement.GotoKeyword.GetLocation());
                    break;

                case InvocationExpressionSyntax invocation:
                    if (invocation.Expression is IdentifierNameSyntax identifier &&
                       identifier.Identifier.Text == "nameof")
                    {
                        ReportDiagnostic(
                            context,
                            DiagnosticDescriptors.NoNameOfInInitializeComponent,
                            identifier.GetLocation());
                    }
                    break;

                case ConditionalExpressionSyntax ternary:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoTernaryOperatorInInitializeComponent,
                        ternary.QuestionToken.GetLocation());
                    break;

                case BinaryExpressionSyntax binary when binary.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.CoalesceExpression):
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoNullCoalescingOperatorInInitializeComponent,
                        binary.OperatorToken.GetLocation());
                    break;

                case ConditionalAccessExpressionSyntax conditionalAccess:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoNullConditionalOperatorInInitializeComponent,
                        conditionalAccess.OperatorToken.GetLocation());
                    break;

                case InterpolatedStringExpressionSyntax interpolatedString:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoStringInterpolationInInitializeComponent,
                        interpolatedString.StringStartToken.GetLocation());
                    break;

                case SimpleLambdaExpressionSyntax simpleLambda:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoLambdaExpressionInInitializeComponent,
                        simpleLambda.ArrowToken.GetLocation());
                    break;

                case ParenthesizedLambdaExpressionSyntax parenthesizedLambda:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoLambdaExpressionInInitializeComponent,
                        parenthesizedLambda.ArrowToken.GetLocation());
                    break;

                case TryStatementSyntax tryStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoTryCatchInInitializeComponent,
                        tryStatement.TryKeyword.GetLocation());
                    break;

                case LockStatementSyntax lockStatement:
                    ReportDiagnostic(
                        context,
                        DiagnosticDescriptors.NoLockStatementInInitializeComponent,
                        lockStatement.LockKeyword.GetLocation());
                    break;
            }
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

    private static void ReportDiagnostic(
        SyntaxTreeAnalysisContext context,
        DiagnosticDescriptor descriptor,
        Location location)
    {
        Diagnostic diagnostic = Diagnostic.Create(descriptor, location);
        context.ReportDiagnostic(diagnostic);
    }
}
