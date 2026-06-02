using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Analyzer that ensures backing fields in WinForms designer files
///  are defined at the bottom of the class.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class EnsureFieldsAreDefinedAtBottomOfClass : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => [DiagnosticDescriptors.FieldsShouldBeAtBottom];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(compilationContext =>
        {
            Compilation compilation = compilationContext.Compilation;

            compilationContext.RegisterSemanticModelAction(semanticModelContext =>
            {
                SemanticModel semanticModel = semanticModelContext.SemanticModel;
                SyntaxTree tree = semanticModel.SyntaxTree;

                AnalyzeSyntaxTree(semanticModelContext, tree, compilation);
            });
        });
    }

    private static void AnalyzeSyntaxTree(
        SemanticModelAnalysisContext context,
        SyntaxTree tree,
        Compilation compilation)
    {
        string filePath = tree.FilePath ?? string.Empty;

        bool isDesignerFile = filePath.EndsWith(".designer.cs", System.StringComparison.OrdinalIgnoreCase);

        if (isDesignerFile)
        {
            AnalyzeDesignerFile(context, tree, compilation);
        }
    }

    private static void AnalyzeDesignerFile(
        SemanticModelAnalysisContext context,
        SyntaxTree tree,
        Compilation compilation)
    {
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
        ClassDeclarationSyntax? designerClass = root.DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .FirstOrDefault(c => c.Modifiers.Any(SyntaxKind.PartialKeyword));

        if (designerClass is null)
        {
            return;
        }

        string mainPath = GetMainFilePath(tree.FilePath);
        SyntaxTree? mainTree = compilation.SyntaxTrees
            .FirstOrDefault(t => t.FilePath.Equals(
                mainPath,
                System.StringComparison.OrdinalIgnoreCase));

        ClassDeclarationSyntax? mainClass = null;

        if (mainTree is not null)
        {
            CompilationUnitSyntax mainRoot = mainTree.GetCompilationUnitRoot();
            mainClass = mainRoot.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Modifiers.Any(SyntaxKind.PartialKeyword));
        }

        MemberDeclarationSyntax[] members = [.. designerClass.Members];

        if (members.Length == 0)
        {
            return;
        }

        HashSet<string> fieldsUsedInInitializeComponent = GetFieldsUsedInInitializeComponent(designerClass);

        int lastNonFieldMemberIndex = -1;

        for (int i = members.Length - 1; i >= 0; i--)
        {
            if (members[i] is not FieldDeclarationSyntax)
            {
                lastNonFieldMemberIndex = i;
                break;
            }
        }

        if (lastNonFieldMemberIndex == -1)
        {
            return;
        }

        for (int i = 0; i < lastNonFieldMemberIndex; i++)
        {
            if (members[i] is FieldDeclarationSyntax fieldDeclaration)
            {
                if (ShouldExemptField(fieldDeclaration, context.SemanticModel))
                {
                    continue;
                }

                foreach (VariableDeclaratorSyntax variable in fieldDeclaration.Declaration.Variables)
                {
                    Diagnostic diagnostic = Diagnostic.Create(
                        DiagnosticDescriptors.FieldsShouldBeAtBottom,
                        variable.Identifier.GetLocation(),
                        variable.Identifier.Text);

                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

        if (mainClass is not null)
        {
            foreach (FieldDeclarationSyntax mainFieldDeclaration in mainClass.Members.OfType<FieldDeclarationSyntax>())
            {
                foreach (VariableDeclaratorSyntax variable in mainFieldDeclaration.Declaration.Variables)
                {
                    string fieldName = variable.Identifier.Text;

                    if (fieldsUsedInInitializeComponent.Contains(fieldName))
                    {
                        Diagnostic diagnostic = Diagnostic.Create(
                            DiagnosticDescriptors.FieldsShouldBeAtBottom,
                            variable.Identifier.GetLocation(),
                            fieldName);

                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }
    }

    private static HashSet<string> GetFieldsUsedInInitializeComponent(ClassDeclarationSyntax classDeclaration)
    {
        HashSet<string> fieldsUsed = [];

        MethodDeclarationSyntax? initMethod = classDeclaration.Members
            .OfType<MethodDeclarationSyntax>()
            .FirstOrDefault(m => m.Identifier.Text == "InitializeComponent");

        if (initMethod is null || initMethod.Body is null)
        {
            return fieldsUsed;
        }

        var memberAccesses = initMethod.Body.DescendantNodes()
            .OfType<IdentifierNameSyntax>()
            .Where(id => id.Identifier.Text.StartsWith("_") || char.IsLower(id.Identifier.Text[0]));

        foreach (var identifier in memberAccesses)
        {
            fieldsUsed.Add(identifier.Identifier.Text);
        }

        return fieldsUsed;
    }

    private static string GetMainFilePath(string designerPath)
    {
        if (designerPath.EndsWith(".designer.cs", System.StringComparison.OrdinalIgnoreCase))
        {
            return designerPath[..^".designer.cs".Length] + ".cs";
        }

        return designerPath;
    }

    private static bool ShouldExemptField(
        FieldDeclarationSyntax fieldDeclaration, SemanticModel semanticModel)
    {
        TypeSyntax fieldType = fieldDeclaration.Declaration.Type;

        ITypeSymbol? typeSymbol = semanticModel.GetTypeInfo(fieldType).Type;

        if (typeSymbol is null)
        {
            return false;
        }

        if (typeSymbol.TypeKind == TypeKind.Interface)
        {
            return true;
        }

        return false;
    }
}
