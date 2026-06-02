---
name: vb-to-csharp-conversion
description: Convert a Visual Basic (.NET) project to an equivalent C# project. Use this skill whenever the user indicates to "convert VB to C#", "port a VB.NET project to C#", "migrate a Visual Basic WinForms app to C#" or mentions abstractly "to go" from a VB source to C#. This skill decides the safe maximum C# language version from the project's TFM, enforces gate checks on Option Strict / Option Explicit, and handles the subtle VB↔C# semantic differences that mechanical transpilers get wrong.
---

# VB.NET → C# Project Conversion

Convert a Visual Basic (.NET) project into an equivalent, idiomatic, **behavior-preserving** C# project. The hard part of this job is not syntax — it is the handful of places where VB and C# look the same but *do* different things. Get those wrong and the code compiles but misbehaves at runtime. Most of this skill is about not getting those wrong.

## Tenet - We convert whole .NET Projects - never only files

Remember, that we cannot convert only on file level. A while .NET Project is either C# or VB. So, we're convert either *all* files inside of a project or none.

## Conversion is not transpilation

A line-by-line transpile produces compiling C# that is subtly broken. The goal is semantic equivalence first, idiomatic C# second. When in doubt, preserve behavior and leave a `// TODO(vb-convert):` marker rather than guessing.

## Utilize Roslyn, when it's a low- (or mid-level-high) hanging fruit

When converting code from Visual Basic to C# - there can be a lot of cases, where converting the code algorithmically is difficult. In such cases, you should generate the code equivalent yourself.

However: When the conversion is straightforward and mechanical, you should utilize Roslyn to do the heavy lifting. For example, for syntax changes that are mechanical (e.g., `Dim` to type declaration, `Sub` to `void`, etc.) you can write respective Roslyn support-code library code, which you overtime, while you tackle the project-port, develop and add to in a dedicated Library in "Q:\git\WARP\src\WarpToolkit.Desktop.Roslyn\WarpToolkit.Desktop.Roslyn.csproj".

Rather than doing the huge port yourself, and while it is more code generation work to write the Roslyn-based converter, it will save you time in the long run, and give you a more robust and maintainable conversion process. You can
use Roslyn to parse the VB code and generate the equivalent C# syntax tree, and then emit that as C# code.

Note, that this library already exist in a different GitHub repo, so, but you need to make sure to use a dedicated branch "RoslynLanguageConverter" for that work, so the user can later decide to keep it by merging it into "main".

To actually create a compatible command line tool, which then utilizes the library you just wrote, create all the respective Command Line Tool code in Q:\git\Facesso\src\Tools\RoslynTooling. You have the permission, to create new command line projects in that repo, but those tools are targeted to load the respected project in a Roslyn workspace and then utilize the library you just created to do the conversion and write the converted code back to disk in a newly created CSharp project which resambles the original VB project in all aspects, except for the language and the necessary syntax changes.

You need to decide for youself, which part of the conversation to tackle with which approach, although the more you can automate with Roslyn, the better. You should also consider that some of the semantic differences between VB and C# might be difficult to handle with Roslyn, and in those cases, you should fall back to manual conversion and leave `// TODO(vb-convert):` markers for review.

---

## Step 0 — Gate checks (do these BEFORE converting anything)

Read the project's VB settings — both project-level (`.vbproj`: `<OptionStrict>`, `<OptionExplicit>`, `<OptionInfer>`, `<OptionCompare>`) and any per-file `Option` statements at the top of each `.vb` file.

**Per-file statements override project defaults.** Resolve the *effective* setting per file.

### Option Explicit

- **`Option Explicit Off` (effective, anywhere it matters) → REFUSE to convert that file/project for now.**

With implicit declaration on, you cannot reliably distinguish a variable from a typo, infer its type, or even enumerate the locals. A correct conversion is not possible. Report which files are affected and stop. Do not attempt a best-effort conversion — silently inventing declarations is worse than refusing.

### Option Strict

- **`Option Strict On` → straightforward path.** Types are explicit and conversions are checked; the work is mostly syntax plus the semantic-difference list below.

- **`Option Strict Off` → high-attention path.**
VB silently performs late binding and narrowing conversions that C# will not.
For every such site:

  - Insert the **explicit cast that is obvious from context** — when the surrounding code makes the intended type unambiguous (a known control type, a typed property, a literal, an immediately-prior assignment).

  - Use **`dynamic`** *only* when context provides no clue at all about the runtime type (genuine late binding against an unknown object). Do not reach for `dynamic` as a convenience to avoid thinking about an obvious cast — it is the last resort, not the default.

  - Flag every `dynamic` you introduce with `// TODO(vb-convert): late-bound, verify runtime type` so the user can review.

State the effective `Option Strict`/`Option Explicit` per file before you start, so the user can see which path each file took.

---

## Step 1 — Determine the safe C# language version from the TFM

The original VB project's `<TargetFramework>` (or `<TargetFrameworkVersion>` for legacy `packages.config`-style projects) caps which C# language features the *converted* code may use.

**Pick the language version, do not just inherit `latest`** — a feature that needs a newer runtime/BCL type will compile but fail, and a feature gated behind a runtime feature won't exist on the target.

If the TFM is multi-targeted, use the **lowest** TFM as the ceiling unless the user says otherwise.

---

## Step 2 — WinForms tenets differences and the C# coding standard

After the conversion is semantically correct, make it idiomatic.
Apply the project's C# style rules **to the extent the chosen `<LangVersion>` allows** — don't emit `record` or collection expressions if the language version from Step 1 forbids them.

If the **`winforms-development`** skill is available, follow its modern-C# and code-organization guidance. For any Form/UserControl/Designer files, the **`winforms-designer-code`** skill is authoritative — in particular for how event wiring must be expressed (see the `Handles` rule below). Read and apply those skills where present.

### Forms/UserControls without CTor in VB *generate* the `InitializeComponent()` method call

If a WinForms `Form` or `UserControl` in VB is partial, has a designer/code-behind file, and has no explicit constructor, the VB compiler still generates a constructor that calls `InitializeComponent()` implicitly.

In C#, you must add that call explicitly:

```csharp
public frmSomething()
{
    InitializeComponent();
}
```

### Always inspect `Application.myapp` and `ApplicationEvents.vb`

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

When a WinForms App (.exe) project is converted, `Program.cs` (or a custom `ApplicationContext`) needs to emulate that VB Application Framework behavior as closely as possible, not merely call `Application.Run(new frmMain)`.

---

## Step 3 — Handle the semantic language differences

This is the core of the skill. Read **`references/semantic-differences.md`** and apply it.
Summary of what it covers (full detail + examples in the reference):

- **`Handles` clauses** → event subscriptions move into `InitializeComponent` (`this.myButton.MouseClick += MyButton_MouseClick;`). The handler *method bodies* stay where they are. This is mandatory for Designer round-tripping — defer to `winforms-designer-code`.

- **Overload resolution differs** — VB and C# rank candidates differently (esp. with optional args, `ParamArray`/`params`, and widening). Verify the *same* overload is selected; add explicit casts to pin it where needed.

- **Default member access scope differs** — VB class members default to `Friend` (`internal` in C#); C# defaults to `private`. VB module members differ again. Emit explicit accessibility to match the VB-effective visibility — never rely on the C# default.

- **Array bounds: VB declares the UPPER BOUND, C# declares the COUNT.**
`Dim a(5)` is **6** elements (0..5).
C# `new T[5]` is 5 elements.
Off-by-one here is the single most common silent bug — every array creation must be re-checked.

- **Parameterized properties → methods.**
C# has no parameterized properties (except indexers).
Convert `Property Item(i As Integer)` to `GetItem`/`SetItem` methods (or an indexer only if it's genuinely the default/`Item` member).

- **`=` operator** — VB uses `=` for both value and reference equality; C# uses `==` for value, `ReferenceEquals()` for reference. Verify which is needed per context.

- **`And`/`Or` are non-short-circuit** — VB evaluates both sides even if the first makes the result obvious. C# `&&`/`||` short-circuit. Replace with `AndAlso`/`OrElse` equivalent (`&&`/`||` in C#) unless both sides must always execute.

- **Integer division `\` vs `/`** — VB `\` truncates to integer; C# `/` with `int` operands also truncates, but `/` with `double` gives a float result. Ensure operand types match intent.

- **`On Error`/`Resume`** — VB exception handling with implicit error resumption. Convert to `try/catch/finally` blocks with explicit control flow; there is no direct `Resume` equivalent.

- **`With` blocks** — VB's implicit object context for member access. Expand to explicit `obj.member` in C# or use a local variable assignment.

- **`Select Case` ranges** — VB allows `Case 1 To 5, 10, 20 To 30`. C# `switch` (pre-pattern) requires individual cases or uses pattern matching (`case >= 1 and <= 5:`).

- **String comparison under `Option Compare Text`** — VB compares strings case-insensitively by default if set. C# defaults to case-sensitive; use `StringComparison.OrdinalIgnoreCase` or culture-aware overloads explicitly.

- **`Mid`/1-based string indexing** — VB strings are 1-indexed (`Mid(s, 1, 3)` gets chars 1–3); C# is 0-indexed (`s.Substring(0, 3)`). Adjust all indices by -1 and use modern C# slicing where applicable.

- **Late-bound `CallByName`** — VB's runtime method invocation by name string. Replace with reflection (`MethodInfo.Invoke`) or refactor to typed delegates/interfaces.

- **`Static` locals** — VB allows `Static localVar` inside a method to persist across calls. C# has no direct equivalent; convert to class-level field or use a closure pattern.

- **`WithEvents` fields and `Handles` clauses** — VB automatically wires event handlers at field declaration. C# requires explicit `+=` subscription; move handler attachment into constructors or `InitializeComponent()`.

- **Structure default-ctor semantics** — VB allows parameterless `New()` on structs and zero-initializes all fields. C# 11+ allows parameterless constructors; older versions require all fields initialized. Verify and add explicit zero-assignments if needed.

- **`Optional` and `ByRef` params** — VB allows `Optional ByRef` and implicit conversions in ref params. C# is stricter: no `ref` on optional params, and ref arguments must be assignable to the exact type. Add explicit variables or temporary holders to match.

- **`My` namespace** — VB's compiler-injected global namespace providing access to app state, settings, registry, files, etc. C# has no equivalent; use standard BCL (e.g., `Environment`, `System.IO`, `System.Configuration`).

### Namespace composition — VB is additive, C# is not

VB **prepends** `<RootNamespace>` to every `Namespace` block in source: `<RootNamespace>Contoso.App</RootNamespace>` + `Namespace Data` ⇒ effective namespace `Contoso.App.Data`, and a file with *no* `Namespace` block lands directly in `Contoso.App`.

C# does **not** do this — `<RootNamespace>` only seeds the default for newly generated/Designer files; `namespace Data` in C# source means exactly `Data`. So copying VB `Namespace` blocks verbatim while keeping `<RootNamespace>` in the `.csproj` silently **drops the root prefix off every type** — it compiles, then breaks at reflection/`Type.FullName`, Designer/type resolution, `.resx` manifest resource names, serialization, and any config or `using` expecting the rooted name.

Fix: compute each type's **effective VB namespace** (`RootNamespace` + source `Namespace`, honoring `Global.` escapes), emit that as the **fully-qualified `namespace` in the C# source**, and add an explicit `namespace <RootNamespace>` to files that had no `Namespace` block. Do not rely on the C# `<RootNamespace>` to re-add anything.

### `Nothing` in VB is not blindly `null` in C #

Rather, it is usually the **default value of the target type**

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

### `Date` / `DateTime`

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

### Parentheses do **not** prove you have a method call

In VB, parentheses can represent:

- a method call,
- array indexing,
- a parameterized property,
- a default property.

So `Foo(bar)` is **not** enough evidence that `Foo` is a method. Resolve the symbol first.

## Step 4 — Structural / naming transforms

- **`#Region` inside a Class or Structure → split into a `partial`.**
Convert the type to `partial` and move each region's contents into a separate code file named `{TypeName}_{RegionName}.cs` (sanitize the region name to a valid identifier-ish suffix). The original file keeps the primary declaration. (Regions that are just folding within a single logical unit and don't warrant a file split can stay as `#region`/`#endregion` — use judgment; the user's intent is to break up large multi-concern types, not to mechanically explode every fold.)

- **PascalCase type names AND file names.** `frmMain.vb` → `FrmMain.cs` (class *and* file). Apply to all lowercase/camelCase type names. Keep references consistent across the whole project (update every usage, Designer files, and `*.resx` base names).

- **PascalCase method names.** `Sub myButton_MouseClick(...)` → `void MyButton_MouseClick(...)`.
Update all call sites and any `Handles`-derived event wiring to match.

- When renaming, update `.csproj` `<Compile>` items, partial-file siblings, and resource file pairings so nothing dangles.

### Keep project and designer noise under control

Several converted SDK-style project files and designer outputs were cleaned up by removing redundant inclusions and normalizing generated code. When the conversion introduces noise but not behavior, strip the noise and keep only the functional parts.

## Practical conversion checklist

Before considering a VB file "done" in C#, verify all of the following:

1. Array upper bounds were converted to element counts correctly.
2. Every `Nothing` usage was checked for `default(T)` vs `null` vs `string.IsNullOrEmpty(...)`.
3. Every parenthesized access was resolved as method vs property vs default property vs array access.
4. Every `#date literal#` became an explicit `DateTime` construction.
5. Every `\`, `AndAlso`, and `OrElse` was translated intentionally.
6. Every partial WinForms `Form` / `UserControl` has an explicit constructor calling `InitializeComponent()`.
7. `Application.myapp` and `ApplicationEvents.vb` were consulted before translating app startup.
8. If the VB behavior looks odd, keep it correct first and annotate with a `// TODO` rather than "fixing" it silently.

---

## Output

Produce a buildable C# project:

- Convert to SDK-Style project type first, and *only* keep those settings inside which are really necessary.*only*

- Use inside the `.csproj` the explicit `<LangVersion>` (from Step 1), `<Nullable>enable</Nullable>` and `<ImplicitUsings>enable</ImplicitUsings>` where appropriate, all converted `.cs` files (PascalCased), partial split-outs, and renamed/repaired resource files. Surface a short report of: effective Option settings per file, chosen LangVersion + why, any files refused (Explicit Off), and every `// TODO(vb-convert):` marker left for human review.

- Convert the `Imports` defined in the original VB Project definition into global usings, when the language versions allows it.
