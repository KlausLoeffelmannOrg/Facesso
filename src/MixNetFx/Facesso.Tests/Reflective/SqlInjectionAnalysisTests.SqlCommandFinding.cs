namespace Facesso.Tests.Reflective
{
    public partial class SqlInjectionAnalysisTests
    {
        private class SqlCommandFinding
        {
            public string FilePath { get; set; }
            public int Line { get; set; }
            public string ContainingType { get; set; }
            public string ContainingMethod { get; set; }
            public string ProjectName { get; set; }
            public string TypeName { get; set; }
            public string Context { get; set; }
            public string SqlSnippet { get; set; }
            public SqlTextClassification Classification { get; set; }
        }
    }
}
