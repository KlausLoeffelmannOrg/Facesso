; Unshipped analyzer release
; https://github.com/dotnet/roslyn/blob/main/src/RoslynAnalyzers/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

### New Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
WFOWARP9900 | CodeQuality | Error | Control backing fields should be defined at the bottom of the code-behind class file
WFOWARP9901 | CodeQuality | Error | Code-behind files should only contain InitializeComponent, Dispose, constructors, and explicit interface implementations
WFOWARP9902 | CodeQuality | Error | For loops are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9903 | CodeQuality | Error | Foreach loops are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9904 | CodeQuality | Error | While loops are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9905 | CodeQuality | Error | If statements are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9906 | CodeQuality | Error | Switch statements are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9907 | CodeQuality | Error | Switch expressions are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9908 | CodeQuality | Error | Local functions are not allowed in InitializeComponent - Designer cannot parse them
WFOWARP9909 | CodeQuality | Error | Goto statements are not allowed in InitializeComponent - Designer cannot parse control flow
WFOWARP9910 | CodeQuality | Error | nameof operator is not allowed in InitializeComponent - use string literals instead
WFOWARP9911 | CodeQuality | Error | Ternary operator is not allowed in InitializeComponent - Designer cannot parse conditional expressions
WFOWARP9912 | CodeQuality | Error | Null-coalescing operator (??) is not allowed in InitializeComponent - use explicit values
WFOWARP9913 | CodeQuality | Error | Null-conditional operator (?., ?[]) is not allowed in InitializeComponent - use explicit checks
WFOWARP9914 | CodeQuality | Error | String interpolation is not allowed in InitializeComponent - use simple string literals
WFOWARP9915 | CodeQuality | Error | Lambda expressions are not allowed in InitializeComponent - use named event handlers instead
WFOWARP9916 | CodeQuality | Error | Try-catch statements are not allowed in InitializeComponent - Designer cannot parse exception handling
WFOWARP9917 | CodeQuality | Error | Lock statements are not allowed in InitializeComponent - Designer cannot parse thread synchronization
WFOWARP9918 | CodeQuality | Warning | Property creates new instance on every access which may cause memory leaks - consider caching
WFOWARP9919 | CodeQuality | Error | Events should not be defined in code-behind files - move to main .cs file
WFOWARP9920 | CodeQuality | Error | Delegates should not be defined in code-behind files - move to main .cs file
WFOWARP9921 | CodeQuality | Error | Collection expressions are not allowed in code-behind files - Designer cannot parse them
