# Facesso VB.NET -> C# Conversion Skill Notes

Use this note when translating the remaining Facesso Visual Basic code to C#. The priority is **behavioral equivalence first** and only then stylistic cleanup. If a translation would silently change runtime behavior, prefer a slightly more explicit C# form.

## 1. Mandatory semantic rules

### 1.1 Arrays: VB declares the highest index, C# declares the element count

This is one of the most common off-by-one traps.

- **VB:** `Dim numbers(4) As Integer` creates **5** elements (`0..4`).
- **C#:** `new int[4]` creates **4** elements (`0..3`).

Typical mappings:

- `Dim a(n) As T` -> `new T[n + 1]`
- `UBound(a)` -> `a.Length - 1`
- `ReDim Preserve a(n)` -> usually `Array.Resize(ref a, n + 1)`

Do not translate VB array declarations mechanically without checking whether the VB number is an upper bound or an actual count.

### 1.2 `Nothing` is not blindly `null`; it is usually the **default value of the target type**

In VB, `Nothing` means the default value of whatever type the expression is targeting.

- For **reference types**, that is a null reference.
- For **non-nullable value types**, it is the type default.

Examples:

```vb
Dim a As Integer = Nothing   ' valid, assigns 0
Dim d As Date = Nothing      ' valid, assigns default(Date)
```

Equivalent C# intent:

```csharp
int a = default;             // 0
DateTime d = default;        // 0001-01-01 00:00:00
```

When VB lets a maybe-null expression flow into a value type, C# usually needs the defaulting to be made explicit:

```vb
Dim count As Integer = maybeNothing
```

```csharp
int count = maybeNothing ?? default;
// or, if boxing/conversion is involved:
int count = maybeNothing is null ? default : (int)maybeNothing;
```

Do **not** translate every `= Nothing` to `== null`.

- In Visual Basic, `"" = Nothing` is `True`.
- If the intent is "null or empty", use `string.IsNullOrEmpty(...)` in C#.
- If the original logic looks suspicious, preserve it carefully and add a `// TODO: verify VB empty-string/Nothing semantics` comment instead of silently changing the behavior.

Also keep `Nothing` separate from `DBNull.Value`; database code still needs explicit `DBNull` handling.

### 1.3 Parentheses do **not** prove you have a method call

In VB, parentheses can represent:

- a method call,
- array indexing,
- a parameterized property,
- a default property.

So `Foo(bar)` is **not** enough evidence that `Foo` is a method. Resolve the symbol first.

### 1.4 VB properties can have parameters

Visual Basic allows parameterized properties and default properties. C# does not support that pattern directly except via indexers, and in this codebase the safer default is to convert such cases into explicit `Get...(...)` / `Set...(...)` methods unless the member is clearly intended to behave like a collection indexer.

Repo examples that prove this is not hypothetical:

- `FAC_Generic\TimeSettingDetails\TimeSplitDataTable.vb`  
  `Default Public ReadOnly Property Item(ByVal index As Integer) As TimeSplitDataRow`
- `FacessoData\DataClasses\ParameterClasses\CombinedParametersInfo.vb`  
  overloaded properties with parameters

Because of this VB feature, **parentheses are no indicator at all** whether a symbol is a property or a method.

### 1.5 `Date` / `DateTime`

`Date` is Visual Basic's built-in name for `System.DateTime`. Treat it as a language primitive/built-in type when converting.

- `Dim x As Date` -> `DateTime x`
- VB date literals use `#...#` and must be rewritten explicitly in C#.

Examples:

```vb
Dim baseDate As Date = #1/1/2003#
Dim timestamp As Date = #8/13/2002 12:14 PM#
```

```csharp
var baseDate = new DateTime(2003, 1, 1);
var timestamp = new DateTime(2002, 8, 13, 12, 14, 0);
```

Repo examples:

- `FAC_Generic\TimeSettingDetails\TimeSettingDetails.vb`
- `FAC_Generic\Sundries\RegistryHelper.vb`
- `Facesso\frmTSImportsBeta.vb`

### 1.6 Numeric conversions and integer division

VB and C# are not equally permissive about implicit numeric conversions. Even when the end result looks obvious, C# often needs an explicit cast or `Convert` call where VB does not.

Pay special attention to:

- `Integer` -> `Double`
- `Object` -> numeric
- `String` -> numeric
- nullable / maybe-null expressions flowing into value types

Also remember:

- `\` is **integer division** in VB.
- `AndAlso` and `OrElse` are VB's **short-circuit** boolean operators.

Mappings:

- `a \ b` -> truncating integer division in C# (do not replace this with normal floating-point division by accident)
- `AndAlso` -> `&&`
- `OrElse` -> `||`

Repo examples for `\`:

- `FacGenericControls\ucCostCenterListView.vb`
- `FacGenericControls\ucEmployeeListView.vb`
- `FacGenericControls\ucWorkGroupListView.vb`

One extra nuance from the VB language rules: if `\` is used with floating-point operands, VB first converts to integral values before performing the division. Be explicit when preserving that behavior in C#.

## 2. WinForms and the VB Application Framework

### 2.1 A missing constructor in VB can still call `InitializeComponent()`

If a WinForms `Form` or `UserControl` in VB is partial, has a designer/code-behind file, and has no explicit constructor, the VB compiler still generates a constructor that calls `InitializeComponent()` implicitly.

In C#, you must add that call explicitly:

```csharp
public frmSomething()
{
    InitializeComponent();
}
```

This was one of the issues fixed again in the latest cleanup work on this branch.

### 2.2 Always inspect `Application.myapp` and `ApplicationEvents.vb`

For a VB WinForms app, do **not** infer startup behavior from forms alone. To understand how the application is really wired, inspect:

- `My Project\Application.myapp`
- `ApplicationEvents.vb`

Those files capture VB Application Framework behavior such as:

- startup form / startup object,
- single-instance behavior,
- visual styles,
- settings persistence,
- splash screen usage,
- startup / shutdown hooks,
- unhandled exception wiring,
- startup-next-instance behavior.

For `VBNetFx\Facesso`, the current app settings show:

- `MySubMain = true`
- `MainForm = frmFacessoShell`
- `SingleInstance = true`
- `EnableVisualStyles = true`
- `SaveMySettingsOnExit = true`

`VBNetFx\Facesso\ApplicationEvents.vb` additionally performs:

- app settings save on shutdown,
- setup and database setup checks during startup,
- schema update checks,
- license/login bootstrapping,
- central unhandled-exception handling.

When this application is converted, `Program.cs` (or a custom `ApplicationContext`) needs to emulate that VB Application Framework behavior as closely as possible, not merely call `Application.Run(new frmFacessoShell())`.

## 3. Lessons from the latest cleanup PR on this branch

The latest cleanup work on `VB-To-CS-Conversion` (`c7b7478`: _"Fix a series of issues of bugs or coding standard violations, which happened from VB -> C# conversation."_) is a useful reality check for what automatic conversion still misses.

### 3.1 Missing designer bootstrapping had to be restored

Explicit constructors calling `InitializeComponent()` had to be re-added in converted WinForms classes such as:

- `src\MixNetFx\FAC_Generic\frmLogin.cs`
- `src\MixNetFx\FAC_Generic\Setup\frmDbSetupWizard.cs`

### 3.2 Lost or flattened members had to be restored

Converted classes were missing members and overrides that existed in the VB originals. For example:

- `src\MixNetFx\FacessoData\DataClasses\WageGroupInfo.cs` regained `DisplayName` and `WasCurrentTo`

Always compare the public surface of the C# result back to the VB source instead of assuming the conversion captured every property, override, and field.

### 3.3 Null/default behavior required human cleanup

`src\MixNetFx\ADSundries\ADComputerInfo.cs` was cleaned up to use deliberate null/default handling instead of exception-driven behavior. This is exactly the sort of area where `Nothing`, optional/default values, and loose VB semantics can create subtle bugs in a naïve C# translation.

### 3.4 Keep project and designer noise under control

Several converted SDK-style project files and designer outputs were cleaned up by removing redundant inclusions and normalizing generated code. When the conversion introduces noise but not behavior, strip the noise and keep only the functional parts.

## 4. Practical conversion checklist

Before considering a VB file "done" in C#, verify all of the following:

1. Array upper bounds were converted to element counts correctly.
2. Every `Nothing` usage was checked for `default(T)` vs `null` vs `string.IsNullOrEmpty(...)`.
3. Every parenthesized access was resolved as method vs property vs default property vs array access.
4. Every `#date literal#` became an explicit `DateTime` construction.
5. Every `\`, `AndAlso`, and `OrElse` was translated intentionally.
6. Every partial WinForms `Form` / `UserControl` has an explicit constructor calling `InitializeComponent()`.
7. `Application.myapp` and `ApplicationEvents.vb` were consulted before translating app startup.
8. If the VB behavior looks odd, keep it correct first and annotate with a `// TODO` rather than "fixing" it silently.

## 5. Sources reviewed

The following external references were used to cross-check this guide and were kept under the requested 10-source limit:

1. Microsoft Learn — `Nothing` keyword  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/nothing>
2. Microsoft Learn — Arrays in Visual Basic  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/arrays/>
3. Microsoft Learn — `Property` statement  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/statements/property-statement>
4. Microsoft Learn — Overview of the Visual Basic application model  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/developing-apps/development-with-my/overview-of-the-visual-basic-application-model>
5. Microsoft Learn — `Date` data type  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/data-types/date-data-type>
6. Microsoft Learn — Widening and narrowing conversions  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions>
7. Microsoft Learn — Integer division operator (`\`)  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/operators/integer-division-operator>
8. Microsoft Learn — `AndAlso` operator  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/operators/andalso-operator>
9. Microsoft Learn — `OrElse` operator  
   <https://learn.microsoft.com/en-us/dotnet/visual-basic/language-reference/operators/orelse-operator>
