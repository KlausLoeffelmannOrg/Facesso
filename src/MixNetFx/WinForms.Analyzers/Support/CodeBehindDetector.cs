using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Utility class for detecting WinForms code-behind files.
/// </summary>
/// <remarks>
///  <para>
///   A file is considered a code-behind file if ALL of the following conditions are met:
///  </para>
///  <para>
///   1. The file does NOT end with <c>.designer.cs</c>
///  </para>
///  <para>
///   2. A corresponding <c>.designer.cs</c> file exists in the compilation
///  </para>
///  <para>
///   3. Both files contain partial classes with the same namespace and class name
///  </para>
///  <para>
///   4. The partial class contains a parameterless <c>InitializeComponent()</c> method
///  </para>
///  <para>
///   5. The class derives from <c>UserControl</c> (directly or indirectly)
///  </para>
///  <para>
///   This provides ~90% confidence that the file is a code-behind file.
///  </para>
/// </remarks>
internal static class CodeBehindDetector
{
    /// <summary>
    ///  Determines if the specified syntax tree represents a WinForms code-behind file.
    /// </summary>
    public static bool IsCodeBehindFile(SyntaxTree tree, Compilation compilation)
    {
        string filePath = tree.FilePath;

        // 1. File must NOT end with .designer.cs
        if (filePath.EndsWith(".designer.cs", System.StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // 2. Must have a corresponding .designer.cs file
        string designerPath = GetDesignerPath(filePath);
        SyntaxTree? designerTree = compilation
            .SyntaxTrees
            .FirstOrDefault(t => t.FilePath.Equals(designerPath, System.StringComparison.OrdinalIgnoreCase));

        if (designerTree is null)
        {
            return false;
        }

        // 3. Both must have matching partial class
        ClassDeclarationSyntax? codeBehindClass = GetCodeBehindClass(tree);

        if (codeBehindClass is null)
        {
            return false;
        }

        ClassDeclarationSyntax? designerClass = GetCodeBehindClass(designerTree);

        if (designerClass is null)
        {
            return false;
        }

        // Verify same namespace and class name
        string codeBehindFullName = GetFullyQualifiedName(codeBehindClass);
        string designerFullName = GetFullyQualifiedName(designerClass);

        if (!string.Equals(codeBehindFullName, designerFullName, System.StringComparison.Ordinal))
        {
            return false;
        }

        // 4. Must have InitializeComponent method (checked in designer file)
        if (!HasInitializeComponentMethod(designerTree))
        {
            return false;
        }

        // 5. Must derive from UserControl (or Form which derives from UserControl)
        SemanticModel semanticModel = compilation.GetSemanticModel(tree);
        INamedTypeSymbol? classSymbol = semanticModel.GetDeclaredSymbol(codeBehindClass);

        return classSymbol is not null
            && DerivesFromUserControl(classSymbol);
    }

    /// <summary>
    ///  Gets the first partial class declaration in the specified syntax tree.
    /// </summary>
    public static ClassDeclarationSyntax? GetCodeBehindClass(SyntaxTree tree)
    {
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        return root.DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .FirstOrDefault(c => c.Modifiers.Any(SyntaxKind.PartialKeyword));
    }

    /// <summary>
    ///  Determines if the specified type symbol derives from <c>UserControl</c>.
    /// </summary>
    public static bool DerivesFromUserControl(INamedTypeSymbol typeSymbol)
    {
        INamedTypeSymbol? current = typeSymbol.BaseType;

        while (current is not null)
        {
            string fullName = $"{current.ContainingNamespace.ToDisplayString()}.{current.Name}";

            if (fullName == "System.Windows.Forms.UserControl"
                || fullName == "System.Windows.Forms.Form")
            {
                return true;
            }

            current = current.BaseType;
        }

        return false;
    }

    private static string GetDesignerPath(string codeBehindPath)
    {
        int extensionIndex = codeBehindPath.LastIndexOf(".cs", System.StringComparison.OrdinalIgnoreCase);

        if (extensionIndex > 0)
        {
            return codeBehindPath.Insert(extensionIndex, ".designer");
        }

        return codeBehindPath + ".designer";
    }

    private static string GetFullyQualifiedName(ClassDeclarationSyntax classDeclaration)
    {
        string className = classDeclaration.Identifier.Text;

        SyntaxNode? parent = classDeclaration.Parent;

        while (parent is not null)
        {
            if (parent is BaseNamespaceDeclarationSyntax namespaceDecl)
            {
                return $"{namespaceDecl.Name}.{className}";
            }

            parent = parent.Parent;
        }

        return className;
    }

    private static bool HasInitializeComponentMethod(SyntaxTree designerTree)
    {
        CompilationUnitSyntax root = designerTree.GetCompilationUnitRoot();

        return root.DescendantNodes()
            .OfType<MethodDeclarationSyntax>()
            .Any(m => m.Identifier.Text == "InitializeComponent"
                && m.ParameterList.Parameters.Count == 0);
    }
}
