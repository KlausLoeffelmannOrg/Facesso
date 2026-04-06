# Demo data conversion for `FacessoSetup --convert-to-demo`

## Goal

Add an interactive `--convert-to-demo` mode to `Tools\FacessoSetup\Program.cs` that turns an existing Facesso database into a safer demo dataset without breaking shift, production, and calculation integrity.

## Proposed user flow

1. Validate the target database and show a hard warning that the operation is destructive and not reversible.
2. Query and print a diagnostic snapshot before any changes:
   - configured or observed shift windows
   - earliest and latest booking timestamps
   - average booking spans per shift
   - average booking spans per shift and workgroup
   - weekend usage information
3. Prompt for:
   - global time offset (`+/-h:mm`)
   - per-booking jitter in seconds
   - target date for the latest time entry
   - new subsidiary name (default from a built-in list of funny industrial laundry service names)
   - whether to regenerate employee/user names
   - whether to rename workgroups and labour values
   - or accept the same values through dedicated `--demo-*` CLI arguments for unattended runs
4. Print a summary and require a second confirmation.
5. Create a SQL backup into the current working directory and report its path, size, and timestamp.
6. Apply the conversion in phases with console progress output:
   - subsidiary rename
   - employee/user anonymization
   - labour value and workgroup renaming
   - date/time shifting for `TimeLog` and `ProductionData`
   - recalculation of affected shift/workgroup results

## Implementation plan

### Phase 1 - CLI and prompt flow

- Add independent option `--convert-to-demo` to the parser and `--help`.
- Add an optional unattended mode via `--silent` plus `--demo-*` overrides so the conversion can run without user interaction.
- Introduce prompt helpers for:
  - yes/no confirmations
  - signed `TimeSpan` parsing
  - numeric input with defaults
  - date input with defaults
- Add a `DemoConversionOptions` model and a `RunConvertToDemo` entry point.

### Phase 2 - Database analysis snapshot

Use read-only SQL queries against:

- `dbo.TimeLog`
- `dbo.ProductionData`
- `dbo.WorkGroups`
- `dbo.LabourValues`
- `dbo.Employees`
- `dbo.Subsidiaries`

The snapshot should report:

- booking range (`MIN(ShiftStart)`, `MAX(ShiftEnd)`)
- average shift start/end per `Shift`
- average shift span per workgroup and shift
- whether Saturday/Sunday data exists

### Phase 3 - Backup and safety

- Determine the current database name with `SELECT DB_NAME()`.
- Create a copy-only backup into a dated history folder below the current working directory (for example `FacessoSetup-Backups\yyyy-mm-dd\...`):
  `BACKUP DATABASE [...] TO DISK = ... WITH COPY_ONLY, INIT, CHECKSUM`.
- Print the resulting path, file size, and backup timestamp.
- Support an operator-friendly restore shortcut for the newest demo backup in that history tree.

### Phase 4 - Demo conversion mechanics

#### 4.1 Subsidiary

- Update `dbo.Subsidiaries.SubsidiaryName`.
- Clear address-like fields only when the demo conversion is meant to anonymize them.

#### 4.2 Employees and users

- Randomize active employee names using built-in international first/last-name pools.
- Reassign display-oriented personnel numbers to unique demo values.
- Clear personal fields in `dbo.AddressDetails` such as street, phone, email, and URL.
- Preserve system accounts (`Facesso!...`) and built-in admin accounts.
- Optionally rename non-system, non-admin `dbo.Users` entries to demo-safe usernames.

#### 4.3 Workgroups and labour values

- Keep `TeHMin` and related numeric fields unchanged.
- Rename workgroups and labour values to English, slightly varied demo-friendly names.
- Use a built-in offline German/English laundry dictionary so the conversion does not depend on AI or network access at runtime.
- Seed the dictionary and fallback descriptions with common industrial-laundry domains such as:
  - soiled linen intake / sorting
  - washer-extractor loading and unloading
  - drying / gas drying / suction drying
  - flatwork ironing (`Mangel`) and large-piece ironing
  - tunnel finishing / garment pressing
  - hand folding / terry folding
  - sewing / repairs / rework
  - packing / dispatch / resident-laundry allocation
  - dry cleaning / curtain and specialty-textile care

#### 4.4 Time and production data

- Compute the day delta so the last booking ends on the requested target date.
- Apply:
  - the requested whole-dataset offset
  - a deterministic per-row jitter in seconds
- Update both `TimeLog` and `ProductionData`.
- Include Saturday/Sunday rows in the same grouped processing so weekend activity is preserved in the transformed dataset.

#### 4.5 Recalculation strategy

- Temporarily disable the existing triggers on:
  - `dbo.TimeLog`
  - `dbo.ProductionData`
  - `dbo.ProductionDataItems`
- Process one `(ProductionDate, Shift)` bucket at a time.
- For each affected workgroup, print the old values, update the bucket, then run:
  - `dbo.TimeLog_UpdateValuesForShiftDate`
  - `dbo.RecalculateTimeLogAndProductionData`
- If a legacy bucket has no valid quantity/reference data for recalculation, fall back to updating the time-based fields only and mark the degree-of-time fields with the usual sentinel values instead of aborting the full demo conversion.
- Re-enable the triggers at the end even on failure.

### Phase 5 - Console progress reporting

- Build a work queue from distinct `(ProductionDate, Shift)` values plus affected workgroups.
- Render an ASCII progress bar with percentage and current bucket info.
- For each workgroup print:
  - original shift window
  - recalculated shift window
  - `DegreeOfTime` and `DegreeOfTimeAdj`

## Key database references

- `Database\FacessoDB\FacessoDB\Tables\TimeLog.sql`
- `Database\FacessoDB\FacessoDB\Tables\ProductionData.sql`
- `Database\FacessoDB\FacessoDB\Tables\ProductionDataItems.sql`
- `Database\FacessoDB\FacessoDB\Tables\Employees.sql`
- `Database\FacessoDB\FacessoDB\Tables\AddressDetails.sql`
- `Database\FacessoDB\FacessoDB\Tables\WorkGroups.sql`
- `Database\FacessoDB\FacessoDB\Tables\LabourValues.sql`
- `Database\FacessoDB\FacessoDB\Stored Procedures\TimeLog_UpdateValuesForShiftDate.sql`
- `Database\FacessoDB\FacessoDB\Stored Procedures\RecalculateTimeLogAndProductionData.sql`

## Notes / assumptions

- The feature should be implemented in the CLI tool without adding external dependencies.
- Existing production and time quantities should remain plausible; only names, identifying data, and timestamps are altered.
- The backup is the recovery mechanism, so the tool must create it before any data mutation starts.
