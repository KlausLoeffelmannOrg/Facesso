# Development history for `Tools\FacessoSetup`

This note captures the recent evolution of the `FacessoSetup` CLI while the database-maintenance and `--convert-to-demo` work was being implemented and hardened. It is organized by development sequence and by the prompts/issues that drove each change.

## Scope added during this work

- expanded admin/user maintenance commands
- `--add-admin <name>`
- interactive `--convert-to-demo`
- unattended demo conversion via `--silent` plus `--demo-*` overrides
- dated demo-backup history plus quick restore of the newest backup
- stronger legacy-database compatibility handling
- startup execution-context output and detailed diagnostic log files

## Chronology

| Phase | Prompt / observed issue | Change made |
| --- | --- | --- |
| 1. Admin maintenance expansion | Request to extend admin-password handling and add `--remove-existing-user-admins`, `--list-users`, `--delete-users`, and `--change-subsidiary-name` | Extended CLI parsing/help and added dedicated DB-maintenance operations. `--setup --admin-user <name>` now updates existing admin passwords and also inserts/promotes the named admin if it does not yet exist. |
| 2. Admin cleanup transaction bug | Error: `ExecuteScalar requires the command to have a transaction...` while deleting admin users | Updated `TableExists(...)` to accept and use the active `SqlTransaction`, avoiding metadata queries outside a pending transaction. |
| 3. Add-admin command | Request for `add-admin <adminUserName>` with a password prompt | Added support for both `--add-admin <name>` and `add-admin <name>`, including password prompting and the same add/promote logic used by setup. |
| 4. Demo conversion planning | Request to first plan and document a large `--convert-to-demo` feature | Researched the Facesso schema and stored procedures, then created `Demodata-conversion.md` with the intended flow, safety strategy, and affected DB objects. |
| 5. Demo conversion implementation | Request for an interactive destructive demo-data conversion workflow | Implemented `--convert-to-demo` with warnings, pre-run analysis, option prompts, backup creation, subsidiary rename, employee/user anonymization, workgroup/labour-value renaming, grouped time/production shifts, recalculation calls, and console progress output. |
| 6. Source refactor | Request to split the growing tool into dedicated code files | Refactored the app into `Program.cs`, `Program.Common.cs`, `Program.DatabaseOperations.cs`, `Program.DemoConversion.cs`, `Program.Restore.cs`, and `Program.Models.cs`. |
| 7. Missing stacktrace visibility | Request to show the stack trace when later conversion errors occurred | Added centralized `WriteException(...)` stacktrace reporting and stage-specific wrappers so failures identify the phase that broke. |
| 8. Legacy identifier type failure | Error: `Specified cast is not valid` and later `IDSubsidiary ... cannot be converted to Guid` | Removed brittle GUID-only assumptions in the demo conversion path. Relevant IDs now preserve their actual DB runtime type (`object`), which better fits older Facesso databases. |
| 9. Offline naming dictionary | Request for a basic German/English laundry-domain dictionary without runtime AI access | Expanded the built-in workgroup/labour-value translation logic with offline phrase and word dictionaries plus laundry-industry fallback names/descriptions. |
| 10. Shift-update SQL batch failure | Error: `The variable name '@OffsetSeconds' has already been declared` | Fixed the shift update SQL batch by removing the conflicting declaration and keeping the parameterized offset logic. |
| 11. Demo conversion safety hardening | Concern about leaving the DB in an inconsistent state during large updates | Wrapped metadata changes in a single transaction, kept shift/date bucket changes transactional, and ensured recalculation triggers are re-enabled in `finally` handling. |
| 12. Personnel-number collision | Error: duplicate key on `IX_Employees_PersonnelNumber` during anonymization | Reworked personnel-number assignment to load already-used values and allocate the next collision-free demo number instead of relying on ad-hoc randomness. |
| 13. Backup/restore convenience | Request for an easy way to restore the backup created before demo conversion | Added `--restore-last-demo-backup` / `--restore-latest-demo-backup`, and changed backup output into dated folders under `FacessoSetup-Backups\yyyy-MM-dd\...`. |
| 14. Restore blocked by active DB users | Error: `Exclusive access could not be obtained because the database is in use` | Updated restore SQL to switch the target DB to `SINGLE_USER WITH ROLLBACK IMMEDIATE` before restore and back to `MULTI_USER` afterward. |
| 15. Restore compatibility for very old DB/server modes | Error: `Incorrect syntax near 'THROW'` | Replaced `THROW` in the generated restore batch with `RAISERROR(...)` for better compatibility with legacy SQL compatibility behavior. |
| 16. Runtime/binary identification | Need to confirm which executable build actually produced the reported output | Added startup output for `Executable`, `Version`, and `Built` timestamp so captured logs clearly identify the running binary. |
| 17. Detailed diagnostics for field debugging | Request to print the SQL statement and/or write a local logfile for easier debugging | Added diagnostic logging under `Log files\yyyy-MM-dd\...`. On SQL command failures the tool now records runtime context, stack traces, and the failing SQL command text plus non-sensitive parameter values. |
| 18. Legacy recalculation NULL bug | Demo conversion later failed around 2.9% with `Cannot insert the value NULL into column 'DegreeOfTime'` inside `dbo.TimeLog_UpdateValuesForShiftDate` | Hardened recalculation to detect missing `TotalReferenceIWT`/legacy reference data and fall back to time-only metric refresh instead of aborting the whole conversion. Also updated the database-project stored procedure script to guard against null/zero reference cases more safely. |
| 19. Unattended demo conversion | Request to pass time offset/jitter from the command line and add a non-interactive `--silent` mode | Added `--demo-time-offset`, `--demo-jitter-seconds`, `--demo-target-date`, `--demo-subsidiary-name`, `--demo-regenerate-users`, and `--demo-regenerate-workgroups`. `--silent` now skips all runtime questions for `--convert-to-demo`, uses the supplied CLI values or built-in defaults, and logs the unattended execution settings. |
| 20. Docker container integration | Need to auto-restore the Facesso demo backup and run `--setup --add-default-admin` when the `wf-sandbox` Windows container starts | Added a `C:\FacessoSetup` directory to the container image (via `COPY backups/ C:/FacessoSetup/` in the Dockerfile) containing `FacessoSetup.exe`, its config/PDB, and the demo `.bak` file. The container entrypoint (`start.ps1`) now runs `FacessoSetup.exe --restore "C:\backups\Facesso-demo-backup.bak" --setup --conn-str "Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;" --add-default-admin` from `C:\FacessoSetup` after SQL Server is ready and the `sa` account is configured. Restore completes successfully; `--setup` writes the expected registry keys. The admin-account steps (`--setup` admin update and `--add-default-admin`) currently emit warnings ("Connected database does not appear to be a Facesso database") even though the earlier restore verification confirms the DB — this may need investigation in the FacessoSetup tool itself. |

## Silent mode purpose and usage

`--silent` exists specifically to make **`--convert-to-demo` reproducible and unattended** on a physical machine where no AI/network help is available during the run itself.

### Scope

- `--silent` is currently intended **only for `--convert-to-demo`**
- it should not be treated as a global non-interactive flag for `--setup` or `--add-admin`, because those operations still require secure password entry

### Why it was added

- to rerun the same demo conversion repeatedly without answering prompts by hand
- to enable **batch-style debugging** on the target workstation
- to make it easier to reproduce failures and then paste the generated log file back into a later Copilot session

### Supported unattended arguments

- `--silent`
  - skips the destructive confirmation prompts and the option prompts during `--convert-to-demo`
- `--demo-time-offset <+/-h:mm>`
  - example: `+0:15`, `0`, `-1:30`
- `--demo-jitter-seconds <0..3600>`
- `--demo-target-date <yyyy-mm-dd>`
- `--demo-subsidiary-name "<name>"`
- `--demo-regenerate-users <yes|no>`
- `--demo-regenerate-workgroups <yes|no>`

### Defaults in silent mode when an override is omitted

- time offset: `0`
- jitter seconds: `0`
- target date: derived from the latest detected booking date
- subsidiary name: one default name chosen from the built-in funny laundry-name list
- regenerate users: `yes`
- regenerate workgroups/labour values: `yes`

### Example unattended command

```powershell
.\FacessoSetup.exe --convert-to-demo --silent `
  --demo-time-offset +0:15 `
  --demo-jitter-seconds 30 `
  --demo-target-date 2026-04-01 `
  --demo-subsidiary-name "Demo Laundry Services Ltd." `
  --demo-regenerate-users yes `
  --demo-regenerate-workgroups yes `
  --conn-str "Data Source=.\SQLEXPRESS;Initial Catalog=Facesso;Integrated Security=True"
```

### Logging behavior for silent runs

- every run writes a logfile under:
  - `.\Log files\yyyy-MM-dd\`
- startup output records:
  - executable path
  - version
  - build timestamp
  - logfile path
- silent demo runs also write a **`DEMO CONVERSION SETTINGS`** block into the logfile so the exact unattended inputs/defaults are preserved for later debugging

## Continuation notes for the next Copilot session

If work resumes in a fresh session, these are the most important current facts to carry forward:

1. **Current focus**
   - The main remaining work is practical end-to-end validation of `--convert-to-demo` on the legacy Facesso DB copy.
   - The feature set itself is already in place; recent work has mostly been hardening around real-world failures.

2. **Most recent runtime issue**
   - A conversion run progressed to about **2.9%** before failing in:
     - `dbo.TimeLog_UpdateValuesForShiftDate`
   - The reported error was:
     - `Cannot insert the value NULL into column 'DegreeOfTime'`
   - The fix added:
     - an application-side fallback for legacy buckets without valid reference data
     - safer null/zero guards in the DB-project stored procedure script

3. **Recommended next validation loop**
   - if needed, first restore the newest backup with:
     - `.\FacessoSetup.exe --restore-last-demo-backup --instance .\SQLEXPRESS`
   - then rerun the conversion, preferably with a fully specified unattended command using `--silent` and `--demo-*`
   - if another failure appears, capture the printed `DETAIL LOG:` path and inspect/paste the corresponding logfile

4. **Files most worth reading first in a future session**
   - `Tools\FacessoSetup\Program.cs`
   - `Tools\FacessoSetup\Program.Common.cs`
   - `Tools\FacessoSetup\Program.DemoConversion.cs`
   - `Tools\FacessoSetup\Program.Restore.cs`
   - `Database\FacessoDB\FacessoDB\Stored Procedures\TimeLog_UpdateValuesForShiftDate.sql`

5. **Assumption to keep in mind**
   - This environment should still be treated as a **legacy database / compatibility-mode target**, even when the SQL Server engine itself is newer.

## Practical lessons from this work

1. The Facesso database must be treated as a **legacy/compatibility target**; code should avoid assuming modern-only data types or SQL behavior.
2. Safety matters more than speed for demo conversion; **backups, transactions, and reversible operator workflows** are essential.
3. Runtime AI/web access is not available during the actual conversion, so any naming/translation support must be **fully offline**.
4. For field debugging, it is valuable to print both the **exact executable path/build** and a **persistent logfile path** on every run.

## Current operator notes

- Demo backups are stored below:
  - `.\FacessoSetup-Backups\yyyy-MM-dd\`
- Detailed run/error logs are stored below:
  - `.\Log files\yyyy-MM-dd\`
- When running the local build from PowerShell, prefer:
  - `.\FacessoSetup.exe ...`

## VB-to-C# conversion audit (MixNetFx)

This section documents the VB-to-C# conversion issues found and fixed in `src\MixNetFx` during a systematic audit of WinForms constructors and parameterized property conversions.

### Missing `InitializeComponent()` constructors

In VB, the compiler implicitly generates a default constructor that calls `InitializeComponent()` for every `Form` and `UserControl` that has a designer file. The C# compiler does **not** do this — an explicit constructor is required.

The following three classes were missing their default constructors after the VB-to-C# conversion and were fixed:

| Class | File | Base class |
| --- | --- | --- |
| `ADDatabaseConnectionDialog` | `ADSqlSupportComponents\AdDatabaseConnectionDialog.cs` | `ADSqlInstanceConnectionDialog` (Form) |
| `ADAttachDatabaseDialog` | `ADSqlSupportComponents\AdAttachDatabaseDialog.cs` | `Form` |
| `ADTsqlScriptProcessorDialog` | `ADSqlSupportComponents\AdTSqlScriptProcessorDialog.cs` | `Form` |

Each received a parameterless constructor calling `InitializeComponent()`.

### frmPreview designer file overwritten by ResXFileCodeGenerator

`ADSimplePrintDocument\UserInterface\frmPreview.Designer.cs` had been completely replaced by a strongly-typed resource accessor class (auto-generated by `ResXFileCodeGenerator` from `frmPreview.resx`). This destroyed the entire WinForms designer — all control declarations and the `InitializeComponent()` method were gone.

**Root cause:** The `.csproj` marked the designer file as `<AutoGen>True</AutoGen>` with `<DependentUpon>frmPreview.resx</DependentUpon>` and configured the `.resx` with `<Generator>ResXFileCodeGenerator</Generator><LastGenOutput>frmPreview.Designer.cs</LastGenOutput>`. This caused the build to regenerate the designer file as a resource accessor instead of preserving the WinForms layout.

**Fix applied:**
1. Restored the WinForms designer content (control declarations + `InitializeComponent()`) from the VBNetFx reference copy.
2. Updated `ADSimplePrintDocument.csproj`:
   - Removed `ResXFileCodeGenerator` from the `.resx`.
   - Changed `frmPreview.Designer.cs` to depend on `frmPreview.cs` (not `frmPreview.resx`).
   - Added `<SubType>Form</SubType>` for `frmPreview.cs`.
   - Made `frmPreview.resx` depend on `frmPreview.cs`.

### Parameterized VB property conversions — audit results

The VB-to-C# conversion skill document (`.github\skills\vb-to-csharp-conversion\SKILL.md`) warns that VB properties can have parameters and that parentheses alone do not indicate a method call. A systematic check of all converted C# files in `MixNetFx` found:

| VB construct | C# conversion | Status |
| --- | --- | --- |
| `Default Public ReadOnly Property Item(index)` in `TimeSplitDataTable.vb` | C# indexer `this[int index]` | ✅ correct |
| `ReadOnly Property ShiftText()` (3 overloads, 2 with parameters) in `CombinedParametersInfo.vb` | C# methods `ShiftText()` / `ShiftText(bool)` / `ShiftText(byte)` | ✅ correct |
| `ReadOnly Property LabourValueInfoCollection()` and `LabourValueInfoCollection(OrderByString)` in `SPAccess_LabourValue.vb` | C# methods `GetLabourValueInfoCollection()` / `GetLabourValueInfoCollection(string)` | ✅ correct — VB call sites in `frmTSImportsBeta.vb`, `frmWorkGroupManager.vb`, and `GetFrmLabourValueInfoCenter.vb` already updated |
| Parameterless properties with empty VB parens (`CostCenterInfoItems()`, `UserInfoCollection()`, `WageGroupInfoCollection()`, `SQLConnectionString()`) | Kept as C# properties (no `Get` prefix) | ✅ correct |

**Key takeaway:** The parameterized properties were handled correctly in this conversion. Properties that truly had parameters were converted to `Get...()` methods; parameterless properties (which in VB can have trailing empty parentheses) remained properties in C#. No broken cross-language call sites remain.

### Build status after fixes

All **10 C# projects** in `MixNetFx` compile cleanly:
`ADDataTypes`, `ADInfoItem`, `ADLicenceManager`, `ADSimplePrintDocument`, `ADSqlSupportComponents`, `ADSundries`, `ActiveDevelop.SqlTools`, `FacGeneric`, `Fac_Data`, `ADSerialGenerator`.

The only remaining build errors are **3 instances of MSB3823** (`Non-string resources require GenerateResourceUsePreserializedResources`) in the VB project `Facesso.vbproj`. These are unrelated to the VB-to-C# conversion — they are a pre-existing VB resource serialization compatibility issue with the current SDK version.

## Related files

- `Tools\FacessoSetup\Technical-Specs\Demodata-conversion.md`
- `Tools\FacessoSetup\Program.cs`
- `Tools\FacessoSetup\Program.Common.cs`
- `Tools\FacessoSetup\Program.DatabaseOperations.cs`
- `Tools\FacessoSetup\Program.DemoConversion.cs`
- `Tools\FacessoSetup\Program.Restore.cs`
- `Tools\FacessoSetup\Program.Models.cs`
- `.github\skills\vb-to-csharp-conversion\SKILL.md`

## Container screenshot testing and silent login (2026-04-07)

This section documents a substantial session that added container-based screenshot testing to the Facesso application, culminating in an instructive debugging episode about human vs. AI problem-solving.

### Goals

1. Make the Facesso WinForms application run inside a Windows Server Core container for automated visual testing.
2. Capture a fullscreen screenshot of frmFacessoShell via PrintWindow, OCR every UI region with Tesseract (eng+deu), and produce a Markdown report.
3. Fix any startup issues that prevent the app from launching in a non-interactive environment.

### Work performed

| Phase | Change | Files |
| --- | --- | --- |
| Non-interactive mode | Guarded all `ShowDialog()` and `MessageBox.Show()` with `Environment.UserInteractive` checks. When non-interactive, errors go to `Console.Error` instead. | `Facesso\frmError.vb`, `Facesso\ApplicationEvents.vb` |
| VB App Framework retry prevention | Added `e.ExitApplication = True` in the non-interactive unhandled exception handler so the framework doesn't loop after a crash. | `Facesso\ApplicationEvents.vb` |
| xUnit v3 alignment | Updated `WinForms.Analyzers.Tests` from xUnit v2 to v3 (`xunit.v3` 3.2.2, `xunit.runner.visualstudio` 3.1.5, `OutputType=Exe`, removed `Microsoft.NET.Test.Sdk`). | `WinForms.Analyzers.Tests.csproj` |
| vstest adapter | Added `xunit.runner.visualstudio` 3.1.5 to `Facesso.Tests` for optional VSTest/TRX support. | `Facesso.Tests.csproj` |
| Test runner simplification | Replaced `msbuild /t:Test` with direct xUnit v3 exe execution (`-trx` flag) in `run-tests.ps1`. Removed post-test log scraping. | `run-tests.ps1` |
| Central test run logger | Created `TestRunLogger` (writes `C:\output\testrun_{timestamp}.txt`), `TestRunLogAttribute` (xUnit v3 `BeforeAfterTestAttribute`), applied globally via `[assembly: TestRunLog]`. Pass/fail detection via `TestContext.Current.TestState.Result`. | `Infrastructure\TestRunLogger.cs`, `Infrastructure\TestRunLogAttribute.cs`, `AssemblyAttributes.cs` |
| Unified screenshot test | Merged `ScreenshotTests.cs` and `OcrScreenshotTests.cs` into one `FacessoScreenshotTests.cs` with a single `[Fact]`. Avoids `SingleInstance=true` conflicts. | `Visual\FacessoScreenshotTests.cs` |
| Diagnostic logger for Facesso.exe | Environment variable `FACESSO_DIAG_LOG` enables `System.Diagnostics.Trace` file logging. Added trace calls at every startup step. | `Facesso\ApplicationEvents.vb` |
| WaitForMainWindow race fix | Moved `HasExited` check before `MainWindowHandle` access; added try/catch for the remaining race window. | `Visual\FacessoScreenshotTests.cs` |
| Crash diagnostics in test | Test captures stderr, exit code, and diag log from spawned Facesso.exe. `run-tests.ps1` shows `FacessoDiag.log` and Application Event Log on failure. | `Visual\FacessoScreenshotTests.cs`, `run-tests.ps1` |
| Silent login NullRef fix | Moved `LoginHistory` initialization above the `/silentAdminLogon` check in `Login()`. | `Facesso.Generic\FacessoGeneric.cs` |

### The silent login bug — a case study in human vs. AI debugging

**The symptom:** `Facesso.exe` crashed on first-ever startup with `/silentAdminLogon` in the container. `NullReferenceException` at `PerformSilentLogin` line 297. On the second startup (VB framework retry), it succeeded.

**The AI approach (Copilot):** Exhaustive bottom-up analysis — checked every variable that could be null at line 297 (`SQLConnectionString`, `Subsidiaries`, `myLoginInfo`, `Authenticated` property internals, `UserInfo` constructor, `ADCryptedPassword`, resource strings). Reflected on xUnit package assemblies for API signatures. Examined release-build PDB line-number drift. Over multiple rounds, added tracing, fixed a race condition in `WaitForMainWindow`, added the `LoginHistory` null-check inside `PerformSilentLogin` — all valid improvements, but none addressed the root cause.

**The human approach (Klaus):** Looked at the `Login()` method once and immediately saw it:

```csharp
// The /silentAdminLogon check was HERE — line 240
// It called PerformSilentLogin() and returned BEFORE this ran:

LoginHistory locLoginHistory = AppSettings.LoginHistory;
if (locLoginHistory == null)
{
    locLoginHistory = new LoginHistory();
    // ... initialization ...
    AppSettings.LoginHistory = locLoginHistory;
}
```

The silent login bailed out at line 248 (`return`) before `LoginHistory` was ever created. The fix: move the `LoginHistory` initialization above the `/silentAdminLogon` check.

**Why the human saw it instantly:**

- **Domain context** — knowing that "first manual login makes it work" means the manual path initializes something the silent path skips.
- **Flow-level pattern matching** — seeing *"this setup code runs after the early return"* rather than analyzing individual null values.
- **Abstraction zoom** — jumping straight to the structural/sequencing issue instead of examining every variable at the same depth.

**Why the AI struggled:**

- Approached the problem as *"what value is null?"* rather than *"what initialization hasn't run yet?"*
- Performed thorough but flat analysis — checking every possible null at the crash site instead of tracing the code flow that leads TO the crash site.
- Each round of investigation was technically correct but operated at the wrong abstraction level for this class of bug.

**The lesson for AI-assisted development:** Sequencing/initialization-order bugs are best diagnosed by reframing from *"what's null?"* to *"what hasn't run yet, and why?"*. When a human collaborator can point the AI at the **flow** rather than the **symptom**, the fix becomes obvious. The most valuable human input in this session was a single sentence: *"Why aren't we calling the auto login AFTER we did this?"*

### Commits (session 2026-04-07)

- `bb622f6` — Non-interactive mode guards (frmError, ApplicationEvents)
- `568cd0b` — xunit.runner.visualstudio adapter for Facesso.Tests
- `59d4eab` — Central test run logger infrastructure
- `8e7b8fe` — Align WinForms.Analyzers.Tests with xUnit v3
- `7d8c1dd` — Unified screenshot + OCR test
- `e6e14e4` — Diagnostic logging, WaitForMainWindow race fix, stderr capture
- `e8a85aa` — LoginHistory null-check in PerformSilentLogin
- `2c15974` — ExitApplication=True for non-interactive unhandled exceptions
- `d47cd29` — **Root fix**: Move LoginHistory init above /silentAdminLogon check

### Session 2026-04-07 (evening) — Screenshot capture in headless containers

After the silent-login bug was fixed and the application started successfully inside a Windows Server Core container, the focus shifted to **capturing a visible screenshot** of the running `frmFacessoShell` for automated visual verification and OCR-based content analysis.

#### Problem: black screenshots in headless environments

`PrintWindow` (the Win32 API used for cross-process window capture) relies on the DWM compositor to render the window surface into a bitmap. In headless containers (no desktop session, no DWM), every pixel comes back black — `PrintWindow` returns success but writes nothing.

Separately, `Process.MainWindowHandle` stays `IntPtr.Zero` in containers because the .NET API uses visibility-based heuristics that fail without an interactive desktop.

#### Approach: layered capture strategy

The investigation identified that **`WM_PRINT` is fundamentally different** from `PrintWindow`:

| API | Mechanism | Headless? |
| --- | --- | --- |
| `PrintWindow` | Compositor surface capture (DWM) | ❌ Black output |
| `WM_PRINT` (SendMessage) | Window message → `OnPaint` into caller's DC | ✅ GDI memory DC |
| `DrawToBitmap` (in-process) | Same as WM_PRINT, but called on the control directly | ✅ Always works |

`WM_PRINT` sends a message to the target window's WndProc, which triggers `OnPaint` code against whatever DC the caller provides. Since GDI handles live in a **session-wide kernel handle table**, a memory DC created in the test process is valid when the Facesso process paints into it. This is the same mechanism `Control.DrawToBitmap()` uses internally.

#### Implementation

**`CaptureWindow` method** in `FacessoScreenshotTests.cs` now tries three strategies in order:

1. **`WM_PRINT`** cross-process (primary) — sends `WM_PRINT` with `PRF_NONCLIENT | PRF_CLIENT | PRF_CHILDREN | PRF_ERASEBKGND` to the window, asking it to paint itself and all children into the test's memory DC.
2. **`PrintWindow`** with `PW_RENDERFULLCONTENT` (fallback) — works well on interactive desktops where DWM is active.
3. **Recursive child painting** (fallback) — `EnumChildWindows` iterates every child HWND, sends `WM_PRINTCLIENT` / `WM_PRINT` to each, and composites them at their screen-relative positions in the bitmap.

After every attempt, `ForceOpaqueAlpha` sets all alpha bytes to 255 (WM_PRINT often writes valid RGB but leaves alpha at 0, making PNGs appear transparent/black in viewers). `IsImageMostlyUniform` determines whether a strategy produced content or needs to fall through.

**`frmFacessoShell.vb`** gained `ScheduleScreenshotCaptureIfRequested()` — when the `FACESSO_SCREENSHOT_PATH` environment variable is set, the form maximizes itself and fires a 3-second one-shot timer that calls `Me.DrawToBitmap()` and saves the PNG. This is the belt-and-suspenders fallback for environments where even cross-process `WM_PRINT` fails.

**Window detection** was also improved: `WaitForMainWindow` now falls back to `EnumThreadWindows` (walking every thread of the process) when `Process.MainWindowHandle` stays zero. `FindMainWindowViaThreads` matches any window whose title contains "Facesso".

#### Tesseract OCR integration

Tesseract 5.2.0 was added to `Facesso.Tests` with **eng + deu** traineddata files (standard tessdata, supporting both LSTM and legacy engines). The test computes 10 OCR regions from the `frmFacessoShell.Designer.vb` layout:

1. Menu Bar (MenuStripMain)
2. Toolbar (ToolStripMain)
3. Date/Shift Selector (ToolStripDateShiftSelector, left panel)
4. Info Bar — Current Date, Current Work Group, Current Shift
5. Work Groups ListView (wglWorkGroups)
6. Work Group Details DataGridView (dgvWorkGroupResults)
7. Employees ListView (elvEmployees)
8. Status Bar (StatusStrip)

Each region is OCR'd with `TesseractEngine("eng+deu", EngineMode.Default)` and the results are written to a Markdown report at `c:\output\FacessoOcrReport.md`.

#### Also explored (then reverted)

UI Automation (UIA) with `TreeWalker.RawViewWalker` was explored as an alternative to OCR for extracting control text. While it could enumerate the control tree, WinForms accessibility support in containers proved unreliable — controls returned empty `Name` / `Value` properties. The approach was reverted in favour of Tesseract OCR which works directly against the captured bitmap.

### Commits (session 2026-04-07 evening / 2026-04-08)

- `db079dc` — Document container screenshot testing session and silent login bug analysis
- `2c1ca51` — Fix window detection in containers: use EnumThreadWindows fallback
- `82dae13` — Update screen capture strategy for text recognition base
- `524c833` — Replace Tesseract OCR with UI Automation accessibility snapshots
- `b8be068` — Fix FindMainWindowViaThreads: match WinForms class, not GDI+ hook window
- `ca43375` — Use RawViewWalker for deeper WinForms A11y tree traversal
- `7650b21` — Enable WinForms accessibility features for UIA support
- `1112420` — Revert A11y text extraction, keep screenshot-only test
- `081ffea` — Remove leftover ControlTreeDumper.cs
- `4701211` — Fix Screenshot and assembly inventory test

## Server-level DB administration operations (session 2026-04-09)

### Context

The MSBench test team identified a gap: in containerized testing scenarios, no script runs before the AI agent starts working. The agent itself must be able to set up the Facesso database from scratch. To support this, FacessoSetup needed new CLI operations that cover the full lifecycle of a SQL Server database — extract, restore, backup, and detach — without requiring any external orchestration.

### New operations added

| Option | Purpose |
| --- | --- |
| `--RestoreCompressedDb <file> <destPath>` | Extracts a ZIP-compressed `.bak` archive to `destPath`, then restores the contained backup to SQL Server. |
| `--ExtractDb <file> <destPath>` | Extracts a ZIP-compressed `.bak` archive without restoring (useful for inspection or manual restore). |
| `--Backup <bakPath>` | Closes all connections (SINGLE_USER WITH ROLLBACK IMMEDIATE), performs a full database backup. Supports `{datetime-format}` tokens in the path, e.g. `Facesso-{yyyy-MM-dd-HHmmss}.bak`. |
| `--DetachDb <dbName>` | Closes all connections and detaches the named database from the SQL Server instance. |
| `--CopyTo <destPath>` | Used with `--DetachDb` to copy the MDF/LDF files to a destination folder after detach. |

### Default connection string

When neither `--instance` nor `--conn-str` is supplied, the tool now assumes:

```
Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;
```

with `Facesso` as the default database name. This matches the standard container/MSBench configuration. The old behavior (Integrated Security via `.\SQLEXPRESS`) is preserved when `--instance` is explicitly passed.

### Implementation notes

- New file: `Program.ServerOperations.cs` — contains all server-level operation methods, the default connection string constants, and the `ResolveMasterConnStr` / `ResolveDatabaseConnStr` helpers.
- `Program.cs` — extended CLI parser with both PascalCase (`--RestoreCompressedDb`) and kebab-case (`--restore-compressed-db`) variants for all new options.
- `Program.Common.cs` — updated `PrintUsage()` with new operations, default connection string documentation, and container/MSBench example commands.
- `FacessoSetup.csproj` — added framework references for `System.IO.Compression` and `System.IO.Compression.FileSystem`.
- `README.md` — added "How to Make Facesso Startable" section with step-by-step setup guide and database reset instructions.

### Container infrastructure

The `sql.ini` unattended installation config was updated to include `SECURITYMODE="SQL"` and `SAPWD` so that mixed-mode authentication and the `sa` account are configured during SQL Server installation itself, rather than requiring a post-install runtime step. The redundant registry-based LoginMode override was removed from the Dockerfile.
