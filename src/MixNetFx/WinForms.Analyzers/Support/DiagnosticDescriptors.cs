using Microsoft.CodeAnalysis;

namespace WinForms.Analyzers;

/// <summary>
///  Centralized repository for all diagnostic descriptors used by WinForms analyzers.
/// </summary>
/// <remarks>
///  <para>
///   All diagnostic IDs follow the pattern: <c>WFOWARP####</c>
///  </para>
///  <para>
///   ID Ranges:
///  </para>
///  <para>
///   - 9900-9999: Code-behind file analyzers (Form/UserControl code quality)
///  </para>
/// </remarks>
internal static class DiagnosticDescriptors
{
    private const string Category = "CodeQuality";

    private const string WFOWARP9900 = nameof(WFOWARP9900);
    private const string WFOWARP9901 = nameof(WFOWARP9901);
    private const string WFOWARP9902 = nameof(WFOWARP9902);
    private const string WFOWARP9903 = nameof(WFOWARP9903);
    private const string WFOWARP9904 = nameof(WFOWARP9904);
    private const string WFOWARP9905 = nameof(WFOWARP9905);
    private const string WFOWARP9906 = nameof(WFOWARP9906);
    private const string WFOWARP9907 = nameof(WFOWARP9907);
    private const string WFOWARP9908 = nameof(WFOWARP9908);
    private const string WFOWARP9909 = nameof(WFOWARP9909);
    private const string WFOWARP9910 = nameof(WFOWARP9910);
    private const string WFOWARP9911 = nameof(WFOWARP9911);
    private const string WFOWARP9912 = nameof(WFOWARP9912);
    private const string WFOWARP9913 = nameof(WFOWARP9913);
    private const string WFOWARP9914 = nameof(WFOWARP9914);
    private const string WFOWARP9915 = nameof(WFOWARP9915);
    private const string WFOWARP9916 = nameof(WFOWARP9916);
    private const string WFOWARP9917 = nameof(WFOWARP9917);
    private const string WFOWARP9918 = nameof(WFOWARP9918);
    private const string WFOWARP9919 = nameof(WFOWARP9919);
    private const string WFOWARP9920 = nameof(WFOWARP9920);
    private const string WFOWARP9921 = nameof(WFOWARP9921);

    /// <summary>
    ///  WFOWARP9900: Fields should be defined at bottom of code-behind class.
    /// </summary>
    public static readonly DiagnosticDescriptor FieldsShouldBeAtBottom = new(
        id: WFOWARP9900,
        title: "Fields should be defined at bottom of code-behind class",
        messageFormat: "The Control backing field '{0}' should be defined at the bottom of the class file and in the code-behind, not in the main class file",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "In WinForms code-behind files, backing fields should be defined at the bottom of the class to maintain consistency with WinForms conventions.");

    /// <summary>
    ///  WFOWARP9901: Code-behind files should only contain InitializeComponent, Dispose, and constructors.
    /// </summary>
    public static readonly DiagnosticDescriptor CodeBehindShouldOnlyContainInfrastructure = new(
        id: WFOWARP9901,
        title: "Code-behind files should only contain InitializeComponent, Dispose, and constructors",
        messageFormat: "{0} '{1}' should not be defined in the code-behind file - move it to the main .cs file",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "WinForms code-behind files should only contain infrastructure code (InitializeComponent, Dispose, constructors, and fields). All other members should be in the main .cs file.");

    /// <summary>
    ///  WFOWARP9902: For loops are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoForLoopInInitializeComponent = new(
        id: WFOWARP9902,
        title: "For loops are not allowed in InitializeComponent",
        messageFormat: "For loop is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9903: Foreach loops are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoForEachLoopInInitializeComponent = new(
        id: WFOWARP9903,
        title: "Foreach loops are not allowed in InitializeComponent",
        messageFormat: "Foreach loop is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9904: While loops are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoWhileLoopInInitializeComponent = new(
        id: WFOWARP9904,
        title: "While loops are not allowed in InitializeComponent",
        messageFormat: "While loop is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9905: If statements are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoIfStatementInInitializeComponent = new(
        id: WFOWARP9905,
        title: "If statements are not allowed in InitializeComponent",
        messageFormat: "If statement is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9906: Switch statements are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoSwitchStatementInInitializeComponent = new(
        id: WFOWARP9906,
        title: "Switch statements are not allowed in InitializeComponent",
        messageFormat: "Switch statement is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9907: Switch expressions are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoSwitchExpressionInInitializeComponent = new(
        id: WFOWARP9907,
        title: "Switch expressions are not allowed in InitializeComponent",
        messageFormat: "Switch expression is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9908: Local functions are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoLocalFunctionInInitializeComponent = new(
        id: WFOWARP9908,
        title: "Local functions are not allowed in InitializeComponent",
        messageFormat: "Local function is not allowed in InitializeComponent - the Designer cannot parse local functions",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9909: Goto statements are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoGotoStatementInInitializeComponent = new(
        id: WFOWARP9909,
        title: "Goto statements are not allowed in InitializeComponent",
        messageFormat: "Goto statement is not allowed in InitializeComponent - the Designer cannot parse control flow statements",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9910: nameof operator is not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoNameOfInInitializeComponent = new(
        id: WFOWARP9910,
        title: "nameof operator is not allowed in InitializeComponent",
        messageFormat: "nameof operator is not allowed in InitializeComponent - use string literals instead",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must use string literals instead of nameof() for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9911: Ternary operator is not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoTernaryOperatorInInitializeComponent = new(
        id: WFOWARP9911,
        title: "Ternary operator is not allowed in InitializeComponent",
        messageFormat: "Ternary operator is not allowed in InitializeComponent - the Designer cannot parse conditional expressions",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9912: Null-coalescing operator is not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoNullCoalescingOperatorInInitializeComponent = new(
        id: WFOWARP9912,
        title: "Null-coalescing operator is not allowed in InitializeComponent",
        messageFormat: "Null-coalescing operator (??) is not allowed in InitializeComponent - use explicit values instead",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9913: Null-conditional operator is not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoNullConditionalOperatorInInitializeComponent = new(
        id: WFOWARP9913,
        title: "Null-conditional operator is not allowed in InitializeComponent",
        messageFormat: "Null-conditional operator is not allowed in InitializeComponent - use explicit null checks in main file",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9914: String interpolation is not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoStringInterpolationInInitializeComponent = new(
        id: WFOWARP9914,
        title: "String interpolation is not allowed in InitializeComponent",
        messageFormat: "String interpolation is not allowed in InitializeComponent - use simple string literals instead",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must use simple string literals for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9915: Lambda expressions are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoLambdaExpressionInInitializeComponent = new(
        id: WFOWARP9915,
        title: "Lambda expressions are not allowed in InitializeComponent",
        messageFormat: "Lambda expression is not allowed in InitializeComponent - use named event handlers in main file instead",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must use named event handlers for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9916: Try-catch statements are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoTryCatchInInitializeComponent = new(
        id: WFOWARP9916,
        title: "Try-catch statements are not allowed in InitializeComponent",
        messageFormat: "Try-catch statement is not allowed in InitializeComponent - the Designer cannot parse exception handling",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9917: Lock statements are not allowed in InitializeComponent.
    /// </summary>
    public static readonly DiagnosticDescriptor NoLockStatementInInitializeComponent = new(
        id: WFOWARP9917,
        title: "Lock statements are not allowed in InitializeComponent",
        messageFormat: "Lock statement is not allowed in InitializeComponent - the Designer cannot parse thread synchronization",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "InitializeComponent must contain only simple assignment statements for the Visual Studio Designer to parse correctly.");

    /// <summary>
    ///  WFOWARP9918: Property creates new instance per access causing potential memory leak.
    /// </summary>
    public static readonly DiagnosticDescriptor PropertyCreatesNewInstancePerAccess = new(
        id: WFOWARP9918,
        title: "Property creates new instance per access",
        messageFormat: "Property '{0}' creates a new instance on every access which may cause memory leaks - consider caching the instance",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Expression-bodied properties that create new objects on every access can cause memory leaks. Consider using a cached instance or lazy initialization with a backing field.");

    /// <summary>
    ///  WFOWARP9919: Events should not be defined in code-behind files.
    /// </summary>
    public static readonly DiagnosticDescriptor NoEventsInCodeBehind = new(
        id: WFOWARP9919,
        title: "Events should not be defined in code-behind files",
        messageFormat: "Event '{0}' should not be defined in the code-behind file - move it to the main .cs file",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "In WinForms code-behind files, new events should be defined in the main .cs file, not the .designer.cs file.");

    /// <summary>
    ///  WFOWARP9920: Delegates should not be defined in code-behind files.
    /// </summary>
    public static readonly DiagnosticDescriptor NoDelegatesInCodeBehind = new(
        id: WFOWARP9920,
        title: "Delegates should not be defined in code-behind files",
        messageFormat: "Delegate '{0}' should not be defined in the code-behind file - move it to the main .cs file",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "In WinForms code-behind files, new delegates should be defined in the main .cs file, not the .designer.cs file.");

    /// <summary>
    ///  WFOWARP9921: Collection expressions are not allowed in code-behind files.
    /// </summary>
    public static readonly DiagnosticDescriptor NoCollectionExpressionsInCodeBehind = new(
        id: WFOWARP9921,
        title: "Collection expressions are not allowed in code-behind files",
        messageFormat: "Collection expression is not allowed in code-behind files - use explicit initialization instead",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "Collection expressions (e.g., [1, 2, 3]) are not allowed in WinForms code-behind files (.designer.cs). The Visual Studio Designer cannot parse modern C# collection expressions. Use explicit initialization methods like new[] { } or collection initializers instead.");
}
