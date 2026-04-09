---
name: winforms-localization-xliff
description: >
  Set up XLIFF-based localization for a WinForms LOB application using
  Microsoft.DotNet.XliffTasks. Use this skill when asked to introduce
  localization infrastructure into a WinForms project, wire up MSBuild
  satellite-assembly generation from .xlf files, or prepare a project
  for AI-driven string extraction and translation.
---

# WinForms Localization via XliffTasks — Skill

This skill wires up `Microsoft.DotNet.XliffTasks` into a WinForms project
so that:

1. Every `.resx` file has a corresponding `.xlf` sibling per target language.
2. MSBuild automatically generates satellite assemblies from those `.xlf` files
   on every build — no VSIX, no MAT editor required.
3. The neutral (source) language is **German (`de-DE`)**.
4. The first target language is **English (`en-US`)**.

---

## Step 1 — NuGet Feed

`Microsoft.DotNet.XliffTasks` is **not published to nuget.org**.
Add the dnceng public feed to the solution-level `NuGet.config`.
Create one if it does not already exist at the solution root.
Key/value is as follows:

```
    <add key="dotnet-eng"
         value="https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng/nuget/v3/index.json"
         protocolVersion="3" />
```

---

## Step 2 — PackageReference

Add to every `.csproj` (or `.vbproj`) that owns localizable `.resx` files:

```xml
<PackageReference Include="Microsoft.DotNet.XliffTasks"
                  Version="1.0.0-beta.*"
                  PrivateAssets="all" />
```

Use the **latest available beta** from the feed — check
`https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng/nuget/v3/index.json`
for the current version. The `PrivateAssets="all"` prevents the task
package from leaking into downstream consumers.

---

## Step 3 — Project File Properties

Add to the `<PropertyGroup>` in each participating project:

```xml
<!-- Neutral (source) language already on disk as plain .resx -->
<NeutralLanguage>de-DE</NeutralLanguage>

<!-- Target languages for which .xlf files are maintained -->
<XlfLanguages>en-US</XlfLanguages>

<!-- Auto-sync .xlf files with .resx on every local build.
     Set to false in CI to enforce that .xlf files are committed. -->
<UpdateXlfOnBuild>true</UpdateXlfOnBuild>

<!-- Fail CI build if .xlf files are out of date with .resx -->
<!-- Override per environment: /p:ErrorOnOutOfDateXlf=false for local -->
<ErrorOnOutOfDateXlf Condition="'$(CI)' == 'true'">true</ErrorOnOutOfDateXlf>
<ErrorOnOutOfDateXlf Condition="'$(CI)' != 'true'">false</ErrorOnOutOfDateXlf>
```

### Resulting MSBuild behavior

| Trigger | What happens |
|---------|-------------|
| Normal `dotnet build` | Satellite assemblies built from existing `.xlf` files; `.xlf` updated if `UpdateXlfOnBuild=true` |
| `dotnet build /t:UpdateXlf` | Force-update all `.xlf` files from their source `.resx` without a full build |
| CI build (`CI=true`) | Fails if any `.xlf` is out of date; satellite assemblies are always generated |

---

## Step 4 — .xlf File Layout

XliffTasks expects `.xlf` files to live **alongside** the source `.resx`,
named with the target locale inserted before the extension:

```
Forms/
  MainForm.resx              ← neutral German source
  MainForm.en-US.xlf         ← auto-created by UpdateXlf target
Resources/
  Strings.resx
  Strings.en-US.xlf
```

The first time `UpdateXlf` runs, it creates these files automatically.
Important: These files  are the translation source of truth, not generated artifacts!

---

## Step 5 — Assembly Neutral Language Attribute

Ensure the assembly declares its neutral language so the resource fallback
chain works correctly. In `AssemblyInfo.cs` (or the project file for
SDK-style projects):

```csharp
[assembly: NeutralResourcesLanguage("de-DE")]
```

Or in the `.csproj`:

```xml
<NeutralLanguage>de-DE</NeutralLanguage>
```

Both are equivalent for SDK-style projects; the `<NeutralLanguage>` MSBuild
property emits the attribute automatically.

---

## Step 6 — WinForms Designer `.resx` Files

WinForms forms with `Localizable = true` generate a `.resx` per form.
These are treated identically to hand-authored resource files by XliffTasks.
No special handling is required — XliffTasks picks them up automatically
via the standard `EmbeddedResource` item group.

> **Important for Designer files:** The Designer serializes control
> properties (Text, Size, Location, etc.) into the form's `.resx`.
> XliffTasks will include **all** string-typed entries in the `.xlf`,
> including non-visible ones (e.g. `$this.AutoScaleMode`). Translation
> agents should be instructed to translate only entries whose keys
> correspond to user-visible text (see the Copilot prompt companion).

---

## Step 7 — Satellite Assembly Output

After a successful build, satellite assemblies appear in:

```
bin\Debug\net<tfm>\en-US\<AssemblyName>.resources.dll
```

The runtime loads these automatically via `ResourceManager` when
`Thread.CurrentThread.CurrentUICulture` matches `en-US`.

---

## Step 8 — Runtime Culture Switching (for `--English` / `--German`)

To support command-line culture switching without modifying application
logic, apply the culture **before** any WinForms initialization. The
recommended pattern for SDK-style WinForms is in `Program.cs`:

```csharp
[STAThread]
static void Main(string[] args)
{
    string culture = args.Contains("--English", StringComparer.OrdinalIgnoreCase)
        ? "en-US"
        : "de-DE"; // default neutral

    CultureInfo ci = new(culture);
    Thread.CurrentThread.CurrentCulture   = ci;
    Thread.CurrentThread.CurrentUICulture = ci;

    ApplicationConfiguration.Initialize();
    Application.Run(new MainForm());
}
```

> **Note:** Culture must be set before `Application.Run` and before any
> resource string is first accessed. Setting it after form construction
> has no effect on already-loaded resources.

Important: For Visual Basic, those equivalent settings are made in the ApplicationEvents.vb.


---

## Verification Checklist

- [ ] `NuGet.config` contains the `dotnet-eng` feed
- [ ] Each localizable project references `Microsoft.DotNet.XliffTasks`
- [ ] `<XlfLanguages>en-US</XlfLanguages>` is set
- [ ] `<NeutralLanguage>de-DE</NeutralLanguage>` is set
- [ ] First `dotnet build /t:UpdateXlf` succeeded and `.xlf` files were created
- [ ] `.xlf` files are committed to source control
- [ ] `bin\...\en-US\*.resources.dll` is present after build
- [ ] Running with `--English` displays English strings (even if untranslated
      placeholders at this stage — confirms the satellite assembly is loaded)

---

## Known Constraints

- `Microsoft.DotNet.XliffTasks` repo is **archived** (Oct 2023) but the
  package continues to be published and is used by `dotnet/winforms` itself.
  It is stable for this use case.
- The package is **pre-release only** (version scheme `1.0.0-beta.*`).
  Pin to a specific version in production; use wildcard only during setup.
- Non-string resource entries (images, icons, binary blobs) in `.resx` files
  are **ignored** by XliffTasks — only string-typed entries go into `.xlf`.
