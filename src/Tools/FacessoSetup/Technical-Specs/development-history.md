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

## Related files

- `Tools\FacessoSetup\Technical-Specs\Demodata-conversion.md`
- `Tools\FacessoSetup\Program.cs`
- `Tools\FacessoSetup\Program.Common.cs`
- `Tools\FacessoSetup\Program.DatabaseOperations.cs`
- `Tools\FacessoSetup\Program.DemoConversion.cs`
- `Tools\FacessoSetup\Program.Restore.cs`
- `Tools\FacessoSetup\Program.Models.cs`
