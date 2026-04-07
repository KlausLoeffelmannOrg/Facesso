using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace WinForms.Analyzers;

/// <summary>
///  Utility class for detecting whether code is inside an InitializeComponent method
///  in a WinForms code-behind file.
/// </summary>
internal static class InitializeComponentDetector
{
    /// <summary>
    ///  Determines if the specified syntax node is inside an InitializeComponent method.
    /// </summary>
    public static bool IsInsideInitializeComponent(SyntaxNode node)
    {
        SyntaxNode? current = node;

        while (current is not null)
        {
            if (current is MethodDeclarationSyntax method
                && method.Identifier.Text == "InitializeComponent"
                && method.ParameterList.Parameters.Count == 0)
            {
                return true;
            }

            current = current.Parent;
        }

        return false;
    }

    /// <summary>
    ///  Gets the InitializeComponent method from a syntax tree if it exists.
    /// </summary>
    public static MethodDeclarationSyntax? GetInitializeComponentMethod(SyntaxTree tree)
    {
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        return root.DescendantNodes()
            .OfType<MethodDeclarationSyntax>()
            .FirstOrDefault(m => m.Identifier.Text == "InitializeComponent"
            && m.ParameterList.Parameters.Count == 0);
    }
}
