namespace Facesso.Tests.Reflective
{
public partial class SqlInjectionAnalysisTests
    {
        private enum SqlTextClassification
        {
            /// <summary>The SQL text is a compile-time constant string (safe).</summary>
            StaticLiteral,

            /// <summary>The SQL text involves string concatenation or interpolation with non-constant values.</summary>
            Concatenation,

            /// <summary>Could not determine the classification (treat as suspicious).</summary>
            Indeterminate
        }
    }
}
