using Facesso.Tests.Infrastructure;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CSharpSyntax = Microsoft.CodeAnalysis.CSharp.Syntax;
using CSharpSyntaxKind = Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using VBSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VBSyntaxKind = Microsoft.CodeAnalysis.VisualBasic.SyntaxKind;

namespace Facesso.Tests.Reflective
{
    /// <summary>
    /// Uses Roslyn to load the Facesso solution (excluding test projects),
    /// scans every type for SQL command usage, and reports how many commands
    /// use parameterized queries vs. string concatenation.
    /// Fails if any concatenation-based SQL commands are found.
    /// Reports a security score from 1 (worst) to 10 (perfect).
    /// </summary>
    public partial class SqlInjectionAnalysisTests : IDisposable
    {
        private static readonly string SolutionPath = GetSolutionPath();
        private static readonly HashSet<string> ExcludedProjects 
            = new(StringComparer.OrdinalIgnoreCase)
        {
            "Facesso.Tests",
            "WinForms.Analyzers",
            "WinForms.Analyzers.Tests"
        };

        // SQL command types we look for (namespace-qualified).
        private static readonly HashSet<string> SqlCommandTypes 
            = new(StringComparer.OrdinalIgnoreCase)
        {
            "System.Data.SqlClient.SqlCommand",
            "System.Data.OleDb.OleDbCommand",
            "System.Data.SqlClient.SqlDataAdapter",
            "System.Data.OleDb.OleDbDataAdapter"
        };

        // The property/parameter names that carry SQL text.
        private static readonly HashSet<string> SqlTextProperties 
            = new(StringComparer.OrdinalIgnoreCase)
        {
            "CommandText",
            "SelectCommand"
        };

        static SqlInjectionAnalysisTests()
        {
            if (!MSBuildLocator.IsRegistered)
                MSBuildLocator.RegisterDefaults();
        }

        public void Dispose() { }

        private static void Log(string message) =>
            TestContext.Current?.TestOutputHelper?.WriteLine(message);

        private static string GetSolutionPath([CallerFilePath] string callerFilePath = "")
        {
            // Prefer the runtime assembly location over the compile-time source path.
            // [CallerFilePath] is baked at compile time and may point to a different
            // repo clone if the test binary was compiled elsewhere.
            string assemblyDir = Path.GetDirectoryName(
                typeof(SqlInjectionAnalysisTests).Assembly.Location);

            string result = FindSolutionUpward(assemblyDir);
            if (result != null)
                return result;

            // Fall back to compile-time source path.
            result = FindSolutionUpward(Path.GetDirectoryName(callerFilePath));
            if (result != null)
                return result;

            throw new InvalidOperationException(
                $"Could not locate Facesso.sln from assembly at {assemblyDir}" +
                $" or source at {callerFilePath}");
        }

        private static string FindSolutionUpward(string startDir)
        {
            string dir = startDir;
            while (dir != null)
            {
                string sln = Path.Combine(dir, "Facesso.sln");
                if (File.Exists(sln))
                    return sln;
                dir = Path.GetDirectoryName(dir);
            }
            return null;
        }

        [Fact]
        public async Task SqlCommands_MustUseParameterizedQueries()
        {
            using MSBuildWorkspace workspace = MSBuildWorkspace.Create();

            workspace.WorkspaceFailed += (_, e) =>
            {
                if (e.Diagnostic.Kind == WorkspaceDiagnosticKind.Failure)
                    TestRunLogger.Trace($"[Workspace] {e.Diagnostic.Message}");
            };

            TestRunLogger.Trace($"Loading solution: {SolutionPath}");

            Solution solution = await workspace.OpenSolutionAsync(
                SolutionPath,
                cancellationToken: TestContext.Current.CancellationToken);

            List<SqlCommandFinding> allFindings = [];

            foreach (Project project in solution.Projects)
            {
                if (ExcludedProjects.Contains(project.Name))
                    continue;

                TestRunLogger.Trace($"Analyzing project: {project.Name} ({project.Language})");

                Compilation compilation = await project.GetCompilationAsync(
                    TestContext.Current.CancellationToken);

                if (compilation == null)
                {
                    TestRunLogger.Trace($"  WARNING: Could not compile {project.Name}");
                    continue;
                }

                foreach (SyntaxTree tree in compilation.SyntaxTrees)
                {
                    SemanticModel semanticModel = compilation.GetSemanticModel(tree);
                    SyntaxNode root = await tree.GetRootAsync(TestContext.Current.CancellationToken);
                    string relativePath = MakeRelativePath(tree.FilePath);

                    IEnumerable<SqlCommandFinding> findings;

                    if (project.Language == LanguageNames.CSharp)
                        findings = AnalyzeCSharpTree(root, semanticModel, relativePath);
                    else if (project.Language == LanguageNames.VisualBasic)
                        findings = AnalyzeVBTree(root, semanticModel, relativePath);
                    else
                        continue;

                    foreach (var finding in findings)
                    {
                        finding.ProjectName = project.AssemblyName;
                        allFindings.Add(finding);
                    }
                }
            }

            ReportAndAssert(allFindings);
        }

        private IEnumerable<SqlCommandFinding> AnalyzeCSharpTree(
            SyntaxNode root, SemanticModel model, string filePath)
        {
            List<SqlCommandFinding> findings = [];

            // 1. Constructor calls: new SqlCommand("...", conn)
            foreach (CSharpSyntax.ObjectCreationExpressionSyntax creation in root
                .DescendantNodes()
                .OfType<CSharpSyntax.ObjectCreationExpressionSyntax>())
            {
                TypeInfo typeInfo = model.GetTypeInfo(creation);
                string typeName = typeInfo.Type?.ToDisplayString();

                if (typeName == null || !SqlCommandTypes.Contains(typeName))
                    continue;

                SeparatedSyntaxList<CSharpSyntax.ArgumentSyntax>? args = creation.ArgumentList?.Arguments;

                if (args == null || args.Value.Count == 0)
                {
                    // No-arg constructor — the SQL text will come from CommandText assignment.
                    continue;
                }

                // First argument is the command text / SQL string.
                CSharpSyntax.ExpressionSyntax sqlArg = args.Value[0].Expression;
                SqlTextClassification classification = ClassifyCSharpExpression(sqlArg, model);

                findings.Add(new SqlCommandFinding
                {
                    FilePath = filePath,
                    Line = sqlArg.GetLocation().GetLineSpan().StartLinePosition.Line + 1,
                    ContainingType = GetContainingTypeName_CSharp(sqlArg),
                    ContainingMethod = GetContainingMethodName_CSharp(sqlArg),
                    TypeName = typeName,
                    Context = "Constructor",
                    SqlSnippet = Truncate(sqlArg.ToString(), 120),
                    Classification = classification
                });
            }

            // 2. Property assignments: cmd.CommandText = "..."
            foreach (AssignmentExpressionSyntax assignment in root.DescendantNodes().OfType<CSharpSyntax.AssignmentExpressionSyntax>())
            {
                if (!(assignment.Left is CSharpSyntax.MemberAccessExpressionSyntax memberAccess))
                    continue;

                string propName = memberAccess.Name.Identifier.Text;
                if (!SqlTextProperties.Contains(propName))
                    continue;

                // Verify the target is a SQL command type.
                TypeInfo targetTypeInfo = model.GetTypeInfo(memberAccess.Expression);
                string targetTypeName = targetTypeInfo.Type?.ToDisplayString();
                if (targetTypeName == null || !SqlCommandTypes.Contains(targetTypeName))
                    continue;

                SqlTextClassification classification = ClassifyCSharpExpression(assignment.Right, model);

                findings.Add(new SqlCommandFinding
                {
                    FilePath = filePath,
                    Line = assignment.GetLocation().GetLineSpan().StartLinePosition.Line + 1,
                    ContainingType = GetContainingTypeName_CSharp(assignment),
                    ContainingMethod = GetContainingMethodName_CSharp(assignment),
                    TypeName = targetTypeName,
                    Context = $"Assignment to .{propName}",
                    SqlSnippet = Truncate(assignment.Right.ToString(), 120),
                    Classification = classification
                });
            }

            return findings;
        }

        private SqlTextClassification ClassifyCSharpExpression(
            CSharpSyntax.ExpressionSyntax expr, SemanticModel model,
            HashSet<string> visiting = null)
        {
            // Strip parentheses.
            while (expr is CSharpSyntax.ParenthesizedExpressionSyntax paren)
                expr = paren.Expression;

            // A plain string literal is safe (stored procedure name or static SQL).
            if (expr is CSharpSyntax.LiteralExpressionSyntax literal
                && literal.IsKind(CSharpSyntaxKind.StringLiteralExpression))
                return SqlTextClassification.StaticLiteral;

            // Concatenation: "..." + variable
            if (expr is CSharpSyntax.BinaryExpressionSyntax binary
                && binary.IsKind(CSharpSyntaxKind.AddExpression))
            {
                // Recursively classify each leaf in the concatenation.
                // This allows variables that trace back to StaticLiteral
                // (e.g., string sql = "literal"; ... sql + "more")
                // to be recognized as safe.
                var leafClassifications = AllLeavesCSharp(binary)
                    .Select(leaf => ClassifyCSharpExpression(leaf, model, visiting))
                    .ToList();

                if (leafClassifications.All(c => c == SqlTextClassification.StaticLiteral))
                    return SqlTextClassification.StaticLiteral;

                // Any non-static value concatenated into SQL IS the vulnerability.
                return SqlTextClassification.Concatenation;
            }

            // Interpolated string with non-constant parts.
            if (expr is CSharpSyntax.InterpolatedStringExpressionSyntax interp)
            {
                bool hasNonConstant = interp.Contents.OfType<CSharpSyntax.InterpolationSyntax>()
                    .Any(i =>
                    {
                        Optional<object> constVal = model.GetConstantValue(i.Expression);
                        return !constVal.HasValue;
                    });

                return hasNonConstant
                    ? SqlTextClassification.Concatenation
                    : SqlTextClassification.StaticLiteral;
            }

            // Variable reference — trace back to see if it was concatenated.
            if (expr is CSharpSyntax.IdentifierNameSyntax identifier)
                return TraceCSharpVariable(identifier, model, visiting);

            // Constant field/property/expression. Any compile-time constant value
            // (string, char from ChrW(constInt), int, …) is safe because it cannot
            // carry attacker-controlled input.
            Optional<object> constValue = model.GetConstantValue(expr);

            if (constValue.HasValue)
                return SqlTextClassification.StaticLiteral;

            // Method call or other complex expression — genuinely indeterminate.
            return SqlTextClassification.Indeterminate;
        }

        private SqlTextClassification TraceCSharpVariable(
            CSharpSyntax.IdentifierNameSyntax identifier, SemanticModel model,
            HashSet<string> visiting = null)
        {
            ISymbol symbol = model.GetSymbolInfo(identifier).Symbol;

            if (symbol == null)
                return SqlTextClassification.Indeterminate;

            // Constant fields/locals are safe.
            if (symbol is IFieldSymbol field && field.IsConst)
                return SqlTextClassification.StaticLiteral;
            if (symbol is ILocalSymbol local && local.IsConst)
                return SqlTextClassification.StaticLiteral;

            // For local variables, find the most recent assignment in the same method.
            if (symbol is ILocalSymbol localSym)
            {
                // Cycle detection: if we're already tracing this variable, break the cycle.
                string varKey = identifier.Identifier.Text;
                visiting ??= new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (!visiting.Add(varKey))
                    return SqlTextClassification.Indeterminate;

                try
                {
                    SyntaxNode containingMethod = identifier.Ancestors()
                        .OfType<CSharpSyntax.MethodDeclarationSyntax>().FirstOrDefault()
                        ?? (SyntaxNode)identifier.Ancestors()
                            .OfType<CSharpSyntax.ConstructorDeclarationSyntax>().FirstOrDefault();

                    if (containingMethod == null)
                        return SqlTextClassification.Indeterminate;

                    // Find all assignments to this variable that precede the current usage.
                    var assignmentsAndDeclarators = new List<CSharpSyntax.ExpressionSyntax>();

                    // Check declarators (e.g., string sql = "..." + x).
                    foreach (CSharpSyntax.VariableDeclaratorSyntax declarator in containingMethod.DescendantNodes()
                        .OfType<CSharpSyntax.VariableDeclaratorSyntax>()
                        .Where(d => d.Identifier.Text == identifier.Identifier.Text
                                    && d.Initializer != null))
                    {
                        assignmentsAndDeclarators.Add(declarator.Initializer.Value);
                    }

                    // Check assignment expressions (e.g., sql = sql + "...").
                    foreach (AssignmentExpressionSyntax assign in containingMethod.DescendantNodes()
                        .OfType<CSharpSyntax.AssignmentExpressionSyntax>())
                    {
                        if (assign.Left is CSharpSyntax.IdentifierNameSyntax lhs
                            && lhs.Identifier.Text == identifier.Identifier.Text)
                        {
                            assignmentsAndDeclarators.Add(assign.Right);
                        }
                    }

                    // Classify all assignments.
                    var classifications = assignmentsAndDeclarators
                        .Select(rhs => ClassifyCSharpExpression(rhs, model, visiting))
                        .ToList();

                    // If any assignment involves confirmed concatenation, flag it.
                    if (classifications.Any(c => c == SqlTextClassification.Concatenation))
                        return SqlTextClassification.Concatenation;

                    // If all assignments are static literals, it's safe.
                    if (classifications.Count > 0
                        && classifications.All(c => c == SqlTextClassification.StaticLiteral))
                        return SqlTextClassification.StaticLiteral;
                }
                finally
                {
                    visiting.Remove(identifier.Identifier.Text);
                }
            }

            return SqlTextClassification.Indeterminate;
        }

        private IEnumerable<CSharpSyntax.ExpressionSyntax> AllLeavesCSharp(
            CSharpSyntax.ExpressionSyntax expr)
        {
            if (expr is CSharpSyntax.BinaryExpressionSyntax binary
                && binary.IsKind(CSharpSyntaxKind.AddExpression))
            {
                foreach (CSharpSyntax.ExpressionSyntax left in AllLeavesCSharp(binary.Left))
                    yield return left;
                foreach (CSharpSyntax.ExpressionSyntax right in AllLeavesCSharp(binary.Right))
                    yield return right;
            }
            else
            {
                yield return expr;
            }
        }

        // -----------------------------------------------------------------------
        // VB.NET analysis
        // -----------------------------------------------------------------------

        private IEnumerable<SqlCommandFinding> AnalyzeVBTree(
            SyntaxNode root, SemanticModel model, string filePath)
        {
            var findings = new List<SqlCommandFinding>();

            // 1. Constructor calls: New SqlCommand("...", conn)
            foreach (VBSyntax.ObjectCreationExpressionSyntax creation in root.DescendantNodes().OfType<VBSyntax.ObjectCreationExpressionSyntax>())
            {
                TypeInfo typeInfo = model.GetTypeInfo(creation);
                string typeName = typeInfo.Type?.ToDisplayString();
                if (typeName == null || !SqlCommandTypes.Contains(typeName))
                    continue;

                SeparatedSyntaxList<VBSyntax.ArgumentSyntax>? args = creation.ArgumentList?.Arguments;
                if (args == null || args.Value.Count == 0)
                    continue;

                VBSyntax.ExpressionSyntax sqlArg = args.Value[0].GetExpression();
                if (sqlArg == null)
                    continue;

                SqlTextClassification classification = ClassifyVBExpression(sqlArg, model);

                findings.Add(new SqlCommandFinding
                {
                    FilePath = filePath,
                    Line = sqlArg.GetLocation().GetLineSpan().StartLinePosition.Line + 1,
                    ContainingType = GetContainingTypeName_VB(sqlArg),
                    ContainingMethod = GetContainingMethodName_VB(sqlArg),
                    TypeName = typeName,
                    Context = "Constructor",
                    SqlSnippet = Truncate(sqlArg.ToString(), 120),
                    Classification = classification
                });
            }

            // 2. Property assignments: cmd.CommandText = "..."
            foreach (AssignmentStatementSyntax assignment in root.DescendantNodes().OfType<VBSyntax.AssignmentStatementSyntax>())
            {
                if (!(assignment.Left is VBSyntax.MemberAccessExpressionSyntax memberAccess))
                    continue;

                string propName = memberAccess.Name.Identifier.Text;
                if (!SqlTextProperties.Contains(propName))
                    continue;

                TypeInfo targetTypeInfo = model.GetTypeInfo(memberAccess.Expression);
                string targetTypeName = targetTypeInfo.Type?.ToDisplayString();
                if (targetTypeName == null || !SqlCommandTypes.Contains(targetTypeName))
                    continue;

                SqlTextClassification classification = ClassifyVBExpression(assignment.Right, model);

                findings.Add(new SqlCommandFinding
                {
                    FilePath = filePath,
                    Line = assignment.GetLocation().GetLineSpan().StartLinePosition.Line + 1,
                    ContainingType = GetContainingTypeName_VB(assignment),
                    ContainingMethod = GetContainingMethodName_VB(assignment),
                    TypeName = targetTypeName,
                    Context = $"Assignment to .{propName}",
                    SqlSnippet = Truncate(assignment.Right.ToString(), 120),
                    Classification = classification
                });
            }

            return findings;
        }

        private SqlTextClassification ClassifyVBExpression(
            VBSyntax.ExpressionSyntax expr, SemanticModel model,
            HashSet<string> visiting = null)
        {
            while (expr is VBSyntax.ParenthesizedExpressionSyntax paren)
                expr = paren.Expression;

            // String literal.
            if (expr is VBSyntax.LiteralExpressionSyntax literal
                && literal.IsKind(VBSyntaxKind.StringLiteralExpression))
                return SqlTextClassification.StaticLiteral;

            // VB concatenation: "..." & variable or "..." + variable
            if (expr is VBSyntax.BinaryExpressionSyntax binaryExpr)
            {
                if (binaryExpr.IsKind(VBSyntaxKind.ConcatenateExpression))
                {
                    // Recursively classify each leaf in the concatenation.
                    var leafClassifications = AllLeavesVB(binaryExpr)
                        .Select(leaf => ClassifyVBExpression(leaf, model, visiting))
                        .ToList();

                    if (leafClassifications.All(c => c == SqlTextClassification.StaticLiteral))
                        return SqlTextClassification.StaticLiteral;

                    // Any non-static value concatenated into SQL IS the vulnerability.
                    return SqlTextClassification.Concatenation;
                }

                if (binaryExpr.IsKind(VBSyntaxKind.AddExpression))
                {
                    TypeInfo typeInfo = model.GetTypeInfo(binaryExpr);
                    if (typeInfo.Type?.SpecialType == SpecialType.System_String)
                    {
                        var leafClassifications = AllLeavesVB(binaryExpr)
                            .Select(leaf => ClassifyVBExpression(leaf, model, visiting))
                            .ToList();

                        if (leafClassifications.All(c => c == SqlTextClassification.StaticLiteral))
                            return SqlTextClassification.StaticLiteral;

                        return SqlTextClassification.Concatenation;
                    }
                }
            }

            // Interpolated string.
            if (expr is VBSyntax.InterpolatedStringExpressionSyntax interp)
            {
                bool hasNonConstant = interp.Contents
                    .OfType<VBSyntax.InterpolationSyntax>()
                    .Any(i =>
                    {
                        Optional<object> constVal = model.GetConstantValue(i.Expression);
                        return !constVal.HasValue;
                    });

                return hasNonConstant
                    ? SqlTextClassification.Concatenation
                    : SqlTextClassification.StaticLiteral;
            }

            // Variable reference — trace back.
            if (expr is VBSyntax.IdentifierNameSyntax identifier)
                return TraceVBVariable(identifier, model, visiting);

            // Constant. Any compile-time constant (string, char from ChrW(constInt),
            // numeric, …) is safe because it cannot carry attacker-controlled input.
            Optional<object> constValue = model.GetConstantValue(expr);
            if (constValue.HasValue)
                return SqlTextClassification.StaticLiteral;

            // Method call or other complex expression — genuinely indeterminate.
            return SqlTextClassification.Indeterminate;
        }

        private SqlTextClassification TraceVBVariable(
            VBSyntax.IdentifierNameSyntax identifier, SemanticModel model,
            HashSet<string> visiting = null)
        {
            ISymbol symbol = model.GetSymbolInfo(identifier).Symbol;
            if (symbol == null)
                return SqlTextClassification.Indeterminate;

            if (symbol is IFieldSymbol field && field.IsConst)
                return SqlTextClassification.StaticLiteral;
            if (symbol is ILocalSymbol local && local.IsConst)
                return SqlTextClassification.StaticLiteral;

            if (symbol is ILocalSymbol)
            {
                // Cycle detection: if we're already tracing this variable, break the cycle.
                string varKey = identifier.Identifier.Text;
                visiting ??= new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (!visiting.Add(varKey))
                    return SqlTextClassification.Indeterminate;

                try
                {
                    SyntaxNode containingMethod = identifier.Ancestors()
                        .OfType<VBSyntax.MethodBlockSyntax>().FirstOrDefault()
                        ?? (SyntaxNode)identifier.Ancestors()
                            .OfType<VBSyntax.ConstructorBlockSyntax>().FirstOrDefault();

                    if (containingMethod == null)
                        return SqlTextClassification.Indeterminate;

                    var assignedValues = new List<VBSyntax.ExpressionSyntax>();

                    // Variable declarations with initializer.
                    foreach (ModifiedIdentifierSyntax declarator in containingMethod.DescendantNodes()
                        .OfType<VBSyntax.ModifiedIdentifierSyntax>()
                        .Where(d => string.Equals(d.Identifier.Text, identifier.Identifier.Text,
                            StringComparison.OrdinalIgnoreCase)))
                    {
                        var variableDecl = declarator.Parent as VBSyntax.VariableDeclaratorSyntax;
                        if (variableDecl?.Initializer != null)
                            assignedValues.Add(variableDecl.Initializer.Value);
                    }

                    // Assignment statements.
                    foreach (AssignmentStatementSyntax assign in containingMethod.DescendantNodes()
                        .OfType<VBSyntax.AssignmentStatementSyntax>())
                    {
                        if (assign.Left is VBSyntax.IdentifierNameSyntax lhs
                            && string.Equals(lhs.Identifier.Text, identifier.Identifier.Text,
                                StringComparison.OrdinalIgnoreCase))
                        {
                            assignedValues.Add(assign.Right);
                        }
                    }

                    // Classify all assignments.
                    var classifications = assignedValues
                        .Select(rhs => ClassifyVBExpression(rhs, model, visiting))
                        .ToList();

                    // If any assignment involves confirmed concatenation, flag it.
                    if (classifications.Any(c => c == SqlTextClassification.Concatenation))
                        return SqlTextClassification.Concatenation;

                    // If all assignments are static literals, it's safe.
                    if (classifications.Count > 0
                        && classifications.All(c => c == SqlTextClassification.StaticLiteral))
                        return SqlTextClassification.StaticLiteral;
                }
                finally
                {
                    visiting.Remove(identifier.Identifier.Text);
                }
            }

            return SqlTextClassification.Indeterminate;
        }

        private IEnumerable<VBSyntax.ExpressionSyntax> AllLeavesVB(
            VBSyntax.ExpressionSyntax expr)
        {
            if (expr is VBSyntax.BinaryExpressionSyntax binary
                && (binary.IsKind(VBSyntaxKind.ConcatenateExpression)
                    || binary.IsKind(VBSyntaxKind.AddExpression)))
            {
                foreach (VBSyntax.ExpressionSyntax left in AllLeavesVB(binary.Left))
                    yield return left;
                foreach (VBSyntax.ExpressionSyntax right in AllLeavesVB(binary.Right))
                    yield return right;
            }
            else
            {
                yield return expr;
            }
        }

        #region Containing Type/Method Helpers

        private static string GetContainingTypeName_CSharp(SyntaxNode node)
        {
            var typeDecl = node.Ancestors().OfType<CSharpSyntax.TypeDeclarationSyntax>().FirstOrDefault();
            return typeDecl?.Identifier.Text ?? "(top-level)";
        }

        private static string GetContainingMethodName_CSharp(SyntaxNode node)
        {
            var method = node.Ancestors().OfType<CSharpSyntax.MethodDeclarationSyntax>().FirstOrDefault();
            if (method != null) return method.Identifier.Text;

            var ctor = node.Ancestors().OfType<CSharpSyntax.ConstructorDeclarationSyntax>().FirstOrDefault();
            if (ctor != null) return ".ctor";

            var prop = node.Ancestors().OfType<CSharpSyntax.PropertyDeclarationSyntax>().FirstOrDefault();
            if (prop != null) return prop.Identifier.Text;

            return "(initializer)";
        }

        private static string GetContainingTypeName_VB(SyntaxNode node)
        {
            var typeBlock = node.Ancestors().OfType<VBSyntax.TypeBlockSyntax>().FirstOrDefault();
            if (typeBlock != null)
                return typeBlock.BlockStatement.Identifier.Text;

            var moduleBlock = node.Ancestors().OfType<VBSyntax.ModuleBlockSyntax>().FirstOrDefault();
            if (moduleBlock != null)
                return moduleBlock.ModuleStatement.Identifier.Text;

            return "(top-level)";
        }

        private static string GetContainingMethodName_VB(SyntaxNode node)
        {
            var methodBlock = node.Ancestors().OfType<VBSyntax.MethodBlockSyntax>().FirstOrDefault();
            if (methodBlock != null)
                return methodBlock.SubOrFunctionStatement.Identifier.Text;

            var ctorBlock = node.Ancestors().OfType<VBSyntax.ConstructorBlockSyntax>().FirstOrDefault();
            if (ctorBlock != null) return "New";

            var propBlock = node.Ancestors().OfType<VBSyntax.PropertyBlockSyntax>().FirstOrDefault();
            if (propBlock != null)
                return propBlock.PropertyStatement.Identifier.Text;

            return "(initializer)";
        }

        #endregion

        private void ReportAndAssert(List<SqlCommandFinding> allFindings)
        {
            if (allFindings.Count == 0)
            {
                TestRunLogger.Trace("No SQL commands found in the solution.");
                TestRunLogger.Trace("SCORE: 10/10 — no SQL commands to evaluate.");
                return;
            }

            int totalCommands = allFindings.Count;
            int concatenated = allFindings.Count(f => f.Classification == SqlTextClassification.Concatenation);
            int staticLiteral = allFindings.Count(f => f.Classification == SqlTextClassification.StaticLiteral);
            int indeterminate = allFindings.Count(f => f.Classification == SqlTextClassification.Indeterminate);

            // Score: 1 (worst, 100% concatenation) to 10 (perfect, 0% concatenation).
            // We treat indeterminate as suspicious but not as bad as confirmed concatenation.
            double vulnerableRatio = (concatenated + indeterminate * 0.5) / totalCommands;
            int score = Math.Max(1, (int)Math.Round(10 * (1.0 - vulnerableRatio)));

            var report = new StringBuilder();
            report.AppendLine("═══════════════════════════════════════════════════════════════");
            report.AppendLine("  SQL INJECTION VULNERABILITY ANALYSIS REPORT");
            report.AppendLine("═══════════════════════════════════════════════════════════════");
            report.AppendLine();
            report.AppendLine($"  Total SQL commands found:        {totalCommands}");
            report.AppendLine($"  ✓ Static/parameterized:          {staticLiteral}");
            report.AppendLine($"  ✗ String concatenation:          {concatenated}");
            report.AppendLine($"  ? Indeterminate (suspicious):    {indeterminate}");
            report.AppendLine();
            report.AppendLine($"  SECURITY SCORE: {score}/10");
            report.AppendLine();

            if (concatenated > 0 || indeterminate > 0)
            {
                report.AppendLine("───────────────────────────────────────────────────────────────");
                report.AppendLine("  FINDINGS REQUIRING ATTENTION");
                report.AppendLine("───────────────────────────────────────────────────────────────");

                IOrderedEnumerable<SqlCommandFinding> problematic = allFindings
                    .Where(f => f.Classification != SqlTextClassification.StaticLiteral)
                    .OrderBy(f => f.Classification == SqlTextClassification.Concatenation ? 0 : 1)
                    .ThenBy(f => f.FilePath)
                    .ThenBy(f => f.Line);

                foreach (SqlCommandFinding finding in problematic)
                {
                    string icon = finding.Classification == SqlTextClassification.Concatenation ? "✗" : "?";
                    report.AppendLine();
                    report.AppendLine($"  {icon} [{finding.Classification}] {finding.FilePath}:{finding.Line}");
                    report.AppendLine($"    Type:    {finding.TypeName}");
                    report.AppendLine($"    Context: {finding.Context}");
                    report.AppendLine($"    SQL:     {finding.SqlSnippet}");
                }
            }

            if (staticLiteral > 0)
            {
                report.AppendLine();
                report.AppendLine("───────────────────────────────────────────────────────────────");
                report.AppendLine("  SAFE COMMANDS (static literals / stored procedures)");
                report.AppendLine("───────────────────────────────────────────────────────────────");

                foreach (SqlCommandFinding finding in allFindings
                    .Where(f => f.Classification == SqlTextClassification.StaticLiteral)
                    .OrderBy(f => f.FilePath)
                    .ThenBy(f => f.Line))
                {
                    report.AppendLine($"  ✓ {finding.FilePath}:{finding.Line} — {finding.SqlSnippet}");
                }
            }

            report.AppendLine();
            report.AppendLine("═══════════════════════════════════════════════════════════════");

            // Write Markdown report to the output directory.
            WriteMarkdownReport(allFindings, totalCommands, staticLiteral, concatenated, indeterminate, score);

            Assert.True(
                concatenated == 0,
                $"SQL injection vulnerabilities detected! Score: {score}/10. " +
                $"{concatenated} concatenated, {indeterminate} indeterminate out of {totalCommands} total commands. " +
                "See test output for detailed report.");
        }

        private static void WriteMarkdownReport(
            List<SqlCommandFinding> allFindings,
            int totalCommands, int staticLiteral, int concatenated, int indeterminate, int score)
        {
            try
            {
                string reportDir = TestSettings.CreateTimestampedOutputDir("TestResults");
                string reportPath = Path.Combine(reportDir, "SqlInjectionReport.md");

                var md = new StringBuilder();
                md.AppendLine("# SQL Injection Vulnerability Analysis Report");
                md.AppendLine();
                md.AppendLine($"**Date:** {DateTime.Now:yyyy-MM-dd HH:mm:ss}  ");
                md.AppendLine($"**Security Score:** {score}/10  ");
                md.AppendLine($"**Total SQL commands:** {totalCommands} — " +
                    $"✓ {staticLiteral} safe, ✗ {concatenated} concatenated, ? {indeterminate} indeterminate");
                md.AppendLine();

                // Group findings by project, then by containing type.
                var byProject = allFindings
                    .Where(f => f.Classification != SqlTextClassification.StaticLiteral)
                    .GroupBy(f => f.ProjectName ?? "(unknown)")
                    .OrderBy(g => g.Key);

                foreach (var projectGroup in byProject)
                {
                    md.AppendLine($"## {projectGroup.Key}");
                    md.AppendLine();
                    md.AppendLine("| Class / Module | Method | Line | SQL Command Call |");
                    md.AppendLine("|---|---|---:|---|");

                    foreach (var finding in projectGroup
                        .OrderBy(f => f.ContainingType)
                        .ThenBy(f => f.ContainingMethod)
                        .ThenBy(f => f.Line))
                    {
                        string icon = finding.Classification == SqlTextClassification.Concatenation ? "✗" : "?";
                        string escapedSnippet = EscapeMarkdownPipe(finding.SqlSnippet);

                        md.AppendLine(
                            $"| {finding.ContainingType} " +
                            $"| {finding.ContainingMethod} " +
                            $"| {finding.Line} " +
                            $"| {icon} `{escapedSnippet}` |");
                    }

                    md.AppendLine();
                }

                File.WriteAllText(reportPath, md.ToString(), Encoding.UTF8);
                TestRunLogger.Info($"Markdown report written to: {reportPath}");
            }
            catch (Exception ex)
            {
                TestRunLogger.Trace($"Failed to write Markdown report: {ex.Message}");
            }
        }

        private static string EscapeMarkdownPipe(string text)
            => text?.Replace("|", "\\|") ?? "";

        private static string MakeRelativePath(string fullPath)
        {
            string slnDir = Path.GetDirectoryName(SolutionPath);

            if (fullPath.StartsWith(slnDir, StringComparison.OrdinalIgnoreCase))
                return fullPath.Substring(slnDir.Length).TrimStart(Path.DirectorySeparatorChar);

            return fullPath;
        }

        private static string Truncate(string value, int maxLength)
        {
            // Collapse whitespace for readability in the report.
            value = System.Text.RegularExpressions.Regex.Replace(value, @"\s+", " ").Trim();

            if (value.Length <= maxLength)
                return value;
            return value.Substring(0, maxLength - 3) + "...";
        }
    }
}
