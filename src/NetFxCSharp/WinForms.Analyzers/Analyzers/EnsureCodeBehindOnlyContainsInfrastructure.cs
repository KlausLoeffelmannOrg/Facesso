using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that ensures WinForms code-behind files (.designer.cs) only contain
///  infrastructure methods and do not include business logic or custom members.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class EnsureCodeBehindOnlyContainsInfrastructure : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => [DiagnosticDescriptors.CodeBehindShouldOnlyContainInfrastructure];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze
            | GeneratedCodeAnalysisFlags.ReportDiagnostics);
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

        if (mainTree is not null
            && CodeBehindDetector.IsCodeBehindFile(mainTree, compilation))
        {
            AnalyzeCodeBehindFile(context, tree);
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

    private static void AnalyzeCodeBehindFile(SyntaxTreeAnalysisContext context, SyntaxTree tree)
    {
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        ClassDeclarationSyntax? codeBehindClass = root
            .DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .FirstOrDefault(c => c.Modifiers.Any(SyntaxKind.PartialKeyword));

        if (codeBehindClass is null)
        {
            return;
        }

        foreach (MemberDeclarationSyntax member in codeBehindClass.Members)
        {
            switch (member)
            {
                case MethodDeclarationSyntax method:
                    AnalyzeMethod(context, method);
                    break;

                case PropertyDeclarationSyntax property:
                    ReportDiagnostic(context, "Property", property.Identifier.Text, property.Identifier.GetLocation());
                    break;

                case EventDeclarationSyntax eventDecl:
                    ReportDiagnostic(context, "Event", eventDecl.Identifier.Text, eventDecl.Identifier.GetLocation());
                    break;

                case EventFieldDeclarationSyntax eventField:
                    foreach (VariableDeclaratorSyntax variable in eventField.Declaration.Variables)
                    {
                        ReportDiagnostic(context, "Event", variable.Identifier.Text, variable.Identifier.GetLocation());
                    }
                    break;

                case FieldDeclarationSyntax:
                    break;

                case ConstructorDeclarationSyntax:
                    break;

                default:
                    if (member is BaseTypeDeclarationSyntax typeDecl)
                    {
                        ReportDiagnostic(context, "Type", typeDecl.Identifier.Text, typeDecl.Identifier.GetLocation());
                    }
                    break;
            }
        }
    }

    private static void AnalyzeMethod(SyntaxTreeAnalysisContext context, MethodDeclarationSyntax method)
    {
        string methodName = method.Identifier.Text;

        if (methodName == "InitializeComponent")
        {
            return;
        }

        if (methodName == "Dispose")
        {
            if (method.ParameterList.Parameters.Count == 1)
            {
                ParameterSyntax param = method.ParameterList.Parameters[0];

                if (param.Type is PredefinedTypeSyntax predefinedType
                    && predefinedType.Keyword.IsKind(SyntaxKind.BoolKeyword))
                {
                    return;
                }
            }
        }

        if (method.ExplicitInterfaceSpecifier is not null)
        {
            return;
        }

        ReportDiagnostic(context, "Method", methodName, method.Identifier.GetLocation());
    }

    private static void ReportDiagnostic(
        SyntaxTreeAnalysisContext context,
        string memberType,
        string memberName,
        Location location)
    {
        Diagnostic diagnostic = Diagnostic.Create(
            DiagnosticDescriptors.CodeBehindShouldOnlyContainInfrastructure,
            location,
            memberType,
            memberName);

        context.ReportDiagnostic(diagnostic);
    }
}
