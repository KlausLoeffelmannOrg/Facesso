# Business Logic inside of the Facesso Database

Facesso pushes a significant amount of its business logic into the SQL Server database layer. This was a deliberate architectural decision — by computing KPIs via **triggers**, **scalar functions**, and **table-valued functions** directly in the database, the system guarantees that key metrics remain consistent regardless of whether data is modified through the application, through a data import interface, or through direct SQL manipulation.

This document describes the database schema, the relationships between tables, the trigger-driven recalculation engine, and the stored procedure catalogue.

---

## Table of Contents

1. [Schema Overview](#1-schema-overview)
2. [Table Reference](#2-table-reference)
3. [Relationships and Foreign Keys](#3-relationships-and-foreign-keys)
4. [The Trigger-Driven Recalculation Engine](#4-the-trigger-driven-recalculation-engine)
5. [Scalar and Table-Valued Functions](#5-scalar-and-table-valued-functions)
6. [Sentinel Values Convention](#6-sentinel-values-convention)
7. [The Staging-Table Pattern](#7-the-staging-table-pattern)
8. [Stored Procedure Reference](#8-stored-procedure-reference)

---

## 1. Schema Overview

The database is organized into five logical areas:

### Organizational Master Data

| Table | Purpose |
|-------|---------|
| `Subsidiaries` | Companies or plants — the top-level tenant scope. Every row in the database is scoped to a subsidiary via `IDSubsidiary`. |
| `CostCenters` | Departments within a subsidiary. Controls incentive measurement settings (dimension, precision, synonyms) and whether fixed-value or percentage-based bonus applies. |
| `Currencies` | Currency definitions with Euro exchange factors. |

### Personnel Master Data

| Table | Purpose |
|-------|---------|
| `Employees` | Workers eligible for incentive wage tracking. Linked to a cost center and wage group. |
| `WageGroups` | Pay classifications with an hourly base rate and currency. |
| `AddressDetails` | Contact information for employees and users. |
| `Users` | Application and system users with authentication and authorization data. |

### Work Measurement Master Data

| Table | Purpose |
|-------|---------|
| `LabourValues` | REFA work elements with a standard time (`TeHMin` — target time per unit in h/min). The foundation of all reference-time calculations. |
| `Articles` | Produced items, linked to labour values for costing. |
| `WorkGroups` | Production teams/assembly lines, linked to a cost center. Contains time-setting templates (XML) and a default workload IWT. |
| `WorkGroupAssignments` | Many-to-many link between work groups and labour values — defines which labour values are available at a given work group. |

### Operational / Transactional Data

| Table | Purpose |
|-------|---------|
| `TimeLog` | **Core table.** Per-employee, per-shift time records: shift start/end, breaks, downtimes, handicap, and all calculated time metrics plus the degree of time. |
| `ProductionData` | **Core table.** Per-work-group, per-shift production header: aggregated reference/effective IWT, degree of time, total downtime and break time. |
| `ProductionDataItems` | Line items within a production data record: which labour value was produced in what amount. |
| `BonusLists` | Header table — links a cost center to its bonus schedule (with validity period). |
| `BonusList` | Detail table — individual entries mapping a degree-of-time value to a bonus percentage and/or absolute value. |

### Support & Infrastructure

| Table | Purpose |
|-------|---------|
| `ApplicationSettings` | Per-user or global settings stored as XML. |
| `FunctionLog` | Audit trail for significant operations. |
| `NotificationRecipients` | Email recipients for system notifications. |
| `Skills` / `SkillNeeded` / `SkillProvided` | Skill-matching model: skills that work groups need vs. skills that employees provide. |
| `TimeLogForInsert` | Staging table for batch time-log operations. |
| `ProductionDataItemsForInsert` | Staging table for batch production-data operations. |
| `ParamsEmployees` / `ParamsWorkGroups` / `ParamsProductionDates` | Parameterization tables for analysis queries (user-scoped, ticket-based). |

---

## 2. Table Reference

### Subsidiaries

The root tenant entity. Every other table references a subsidiary either directly or transitively.

| Column | Type | Notes |
|--------|------|-------|
| `IDSubsidiary` | `UNIQUEIDENTIFIER` PK | `NEWSEQUENTIALID()` |
| `SubsidiaryName` | `NVARCHAR(100)` | |
| `Street`, `Zip`, `City` | `NVARCHAR(100)` | |
| `CountryCode` | `NVARCHAR(10)` | |
| `Country` | `NVARCHAR(100)` | |
| `PrimaryPhone` | `NVARCHAR(100)` | |
| `LastEdited` | `DATETIME` | Default `GETDATE()` |

---

### CostCenters

Organizational units that control how incentive indicators are measured and displayed.

| Column | Type | Notes |
|--------|------|-------|
| `IDCostCenter` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDSubsidiary` | `UNIQUEIDENTIFIER` | FK → Subsidiaries (via Currencies FK) |
| `IDCostCenterInternal` | `INT` | Internal sequential ID for faster joins |
| `CostCenterNo` | `INT` | User-facing number (`0` = base cost center) |
| `CostCenterName` | `NVARCHAR(100)` | |
| `IDCurrency` | `UNIQUEIDENTIFIER` | FK → Currencies |
| `IncentiveIndicatorSynonym` | `NVARCHAR(50)` | Display name for the KPI (e.g. "Zeitgrad") |
| `IncentiveWageSynonym` | `NVARCHAR(50)` | Display name for bonus wage (e.g. "Prämienlohn") |
| `IncentiveIndicatorDimension` | `NVARCHAR(10)` | Unit (e.g. "%") |
| `IncentiveIndicatorPrecision` | `TINYINT` | Decimal places for the KPI |
| `UseFixValuedBonus` | `BIT` | If true, bonus is a fixed absolute value; if false, percentage-based |
| `IncentiveIndicatorFactor` | `FLOAT` | Scaling factor |
| `BaseValuePrecision` | `TINYINT` | Decimal places for Te (default 2) |
| `BaseValueSynonym` | `NVARCHAR(50)` | Display name (default "te in h/min") |
| `IsCurrent` | `BIT` | Soft-delete / history flag |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity period |

---

### Employees

| Column | Type | Notes |
|--------|------|-------|
| `IDEmployee` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDEmployeeInternal` | `INT` | Internal sequential ID for fast TimeLog joins |
| `IDCostCenter` | `UNIQUEIDENTIFIER` | FK → CostCenters |
| `IDWageGroup` | `UNIQUEIDENTIFIER` | FK → WageGroups (nullable) |
| `UseFixedWage` | `BIT` | If true, `FixedWage` overrides the wage group rate |
| `FixedWage` | `MONEY` | Individual override |
| `IDAddressDetails` | `UNIQUEIDENTIFIER` | FK → AddressDetails |
| `LastName`, `FirstName` | `NVARCHAR(100)` | |
| `Matchcode` | `NVARCHAR(50)` | Short search code |
| `PersonnelNumber` | `INT` | Unique employee number (unique index) |
| `IsIncentive` | `BIT` | Whether the employee participates in incentive wage |
| `IsActive`, `IsCurrent` | `BIT` | Active/history flags |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity period |
| `DateOfBirth`, `DateOfJoining`, `DateOfSeparation` | `DATETIME` | HR dates |
| `TimeCardNo` | `NVARCHAR(50)` | Badge/card number |

**Indexes:** `IX_Employees_LastName` (LastName), `IX_Employees_PersonnelNumber` (PersonnelNumber, unique).

---

### WageGroups

| Column | Type | Notes |
|--------|------|-------|
| `IDWageGroup` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDWageGroupInternal` | `INT` | Internal sequential ID |
| `IDCurrency` | `UNIQUEIDENTIFIER` | FK → Currencies |
| `WageGroupToken` | `NVARCHAR(20)` | Short identifier (unique index) |
| `HourlyRate` | `MONEY` | The base hourly wage for this group |
| `IsTemplate` | `BIT` | Template wage groups for cloning |
| `IsCurrent` | `BIT` | History flag |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity period |

---

### LabourValues

The REFA work elements with their standard times.

| Column | Type | Notes |
|--------|------|-------|
| `IDLabourValue` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDLabourValueInternal` | `INT` | Internal sequential ID for fast joins |
| `IDCostCenter` | `UNIQUEIDENTIFIER` | FK (logical) → CostCenters |
| `LabourValueNumber` | `INT` | User-facing number |
| `LabourValueName` | `NVARCHAR(100)` | |
| `TeHMin` | `FLOAT` | **Target time per unit** — the core REFA measurement |
| `Dimension` | `NVARCHAR(100)` | Unit of measure (e.g. "Stück", "Meter") |
| `IsActive`, `IsCurrent` | `BIT` | Active/history flags |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity period |

---

### WorkGroups

| Column | Type | Notes |
|--------|------|-------|
| `IDWorkGroup` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDWorkGroupInternal` | `INT` | Internal sequential ID for fast operational joins |
| `IDCostCenter` | `UNIQUEIDENTIFIER` | FK → CostCenters |
| `WorkGroupNumber` | `INT` | User-facing number |
| `WorkgroupName` | `NVARCHAR(100)` | |
| `WorkloadIWT` | `FLOAT` | Default incentive-wage-time capacity in minutes (default 480 = 8 hours) |
| `IsPeaceWork` | `BIT` | Piece-work flag |
| `IsConceptional` | `BIT` | Planning/conceptional group (default false) |
| `TimeSettingDetails` | `XML` | Shift time templates (start, end, breaks per shift) |
| `OrdinalNo` | `INT` | Display order |
| `IsActive`, `IsCurrent` | `BIT` | Active/history flags |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity period |

---

### WorkGroupAssignments

Links labour values to work groups (many-to-many). Defines which labour values a group can produce.

| Column | Type | Notes |
|--------|------|-------|
| `IDWorkGroupAssignment` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDLabourValueInternal` | `INT` | References LabourValues (via internal ID) |
| `IDWorkGroupInternal` | `INT` | References WorkGroups (via internal ID) |
| `OrdinalNumber` | `INT` | Display order |

---

### TimeLog

The per-employee, per-shift time record. Contains both input data (shift times, breaks, downtime, handicap) and computed results (attendance time, working time, IWT, degree of time, pro-rata reference wage time).

| Column | Type | Notes |
|--------|------|-------|
| `IDTimeLog` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDWorkGroup` | `UNIQUEIDENTIFIER` | FK → WorkGroups |
| `IDWorkGroupInternal` | `INT` | Denormalized for fast queries |
| `IDEmployee` | `UNIQUEIDENTIFIER` | FK → Employees |
| `IDEmployeeInternal` | `INT` | Denormalized for fast queries |
| `IDBonusLists` | `UNIQUEIDENTIFIER` | Snapshot of bonus list at time of entry |
| `IDWageGroup` | `UNIQUEIDENTIFIER` | Snapshot of wage group at time of entry |
| `Shift` | `TINYINT` | 1, 2, 3, or Special |
| `ProductionDate` | `DATETIME` | Date-only (time component stripped) |
| **Input fields** | | |
| `ShiftStart` | `DATETIME` | When the shift started |
| `ShiftEnd` | `DATETIME` | When the shift ended |
| `WorkBreak` | `INT` | Break time in minutes |
| `DownTime` | `INT` | Downtime in minutes |
| `Handicap` | `FLOAT` | Efficiency adjustment 0–100 % |
| **Calculated fields** (set by triggers) | | |
| `AttendanceTime` | `INT` | `= DATEDIFF(mi, ShiftStart, ShiftEnd)` |
| `WorkingTime` | `INT` | `= AttendanceTime - WorkBreak` |
| `IncentiveWageTime` | `FLOAT` | `= WorkingTime - DownTime` |
| `IncentiveWageTimeAdj` | `FLOAT` | `= IWT - (IWT × Handicap / 100)` |
| `DegreeOfTime` | `FLOAT` | Group-level KPI, written back from ProductionData |
| `DegreeOfTimeAdj` | `FLOAT` | Handicap-adjusted group-level KPI |
| `ReferenceWageTimeProRata` | `FLOAT` | Individual pro-rata share of reference time |
| **Interface tracking** | | |
| `ShiftStartViaInterface` / `ShiftEndViaInterface` / `WorkBreakViaInterface` / `DownTimeViaInterface` | various | Original values from automated interfaces |
| `InsertedByInterface` | `BIT` | Data origin flag |
| `ManuallyEdited` | `BIT` | Manual override flag |
| `IsSuspended` | `BIT` | Excluded from calculations |
| `EditedByIDUser` | `UNIQUEIDENTIFIER` | Audit: who last changed this |

**Indexes:** `IX_AccessData` on `(IDSubsidiary, ProductionDate, Shift, IDWorkGroup)` — the primary query path.

**Triggers:** `OnTimeLog_InsertUpdate`, `OnTimeLog_Delete` — see [Section 4](#4-the-trigger-driven-recalculation-engine).

---

### ProductionData

The per-work-group, per-shift production summary. Contains both the reference IWT (from production items) and all aggregated effective IWT metrics (from TimeLog).

| Column | Type | Notes |
|--------|------|-------|
| `IDProductionData` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDWorkGroup` | `UNIQUEIDENTIFIER` | FK → WorkGroups |
| `IDWorkGroupInternal` | `INT` | Denormalized for fast queries |
| `IDEmployee` | `UNIQUEIDENTIFIER` | The employee who entered this data |
| `ProductionDate` | `DATETIME` | Date-only |
| `Shift` | `TINYINT` | |
| `TotalReferenceIWT` | `FLOAT` | **Σ(Amount × TeHMin)** — target time. Set by `ProductionDataItems` trigger. |
| `TotalEffectiveIWT` | `FLOAT` | **Σ(IncentiveWageTime)** across all employees. Set by `ProductionData` trigger. |
| `TotalEffectiveIWTAdj` | `FLOAT` | Handicap-adjusted effective IWT |
| `TotalDownTime` | `FLOAT` | Aggregated downtime |
| `TotalWorkBreakTime` | `FLOAT` | Aggregated break time |
| `DegreeOfTime` | `FLOAT` | `= (TotalReferenceIWT / TotalEffectiveIWT) × 100` |
| `DegreeOfTimeAdj` | `FLOAT` | Handicap-adjusted degree of time |
| `InsertedByInterface` | `BIT` | |
| `IsSuspended` | `BIT` | |
| `LastEditedByIDUser` | `UNIQUEIDENTIFIER` | Audit |

**Indexes:** `IX_AccessData` on `(IDSubsidiary, ProductionDate, Shift, IDWorkGroup)`.

**Trigger:** `OnProductionData_InsertUpdate` — see [Section 4](#4-the-trigger-driven-recalculation-engine).

---

### ProductionDataItems

Line items of a production record. Each row says: "We produced X units of labour value Y."

| Column | Type | Notes |
|--------|------|-------|
| `IDProductionDataItem` | `UNIQUEIDENTIFIER` | PK together with `IDSubsidiary` |
| `IDProductionData` | `UNIQUEIDENTIFIER` | FK → ProductionData |
| `IDLabourValue` | `UNIQUEIDENTIFIER` | Which labour value was produced |
| `IDArticle` | `UNIQUEIDENTIFIER` | Which article |
| `Amount` | `FLOAT` | Quantity produced |
| `AmountViaInterface` | `FLOAT` | Original amount from interface (default -1) |
| `OrdinalNumber` | `INT` | Display order |
| `ManuallyEdited` | `BIT` | |

**Trigger:** `OnProductionDataItems_InsertUpdateDelete` — see [Section 4](#4-the-trigger-driven-recalculation-engine).

---

### BonusLists / BonusList

A two-level structure: `BonusLists` is the header (one per cost center with validity), `BonusList` contains the individual entries mapping degree-of-time ranges to bonus percentages or absolute values.

**BonusLists (header):**

| Column | Type | Notes |
|--------|------|-------|
| `IDBonusLists` | `UNIQUEIDENTIFIER` | PK |
| `IDCostCenter` | `UNIQUEIDENTIFIER` | FK → CostCenters |
| `IsCurrent` | `BIT` | |
| `WasCurrentFrom` / `WasCurrentTo` | `DATETIME` | Validity |

**BonusList (detail):**

| Column | Type | Notes |
|--------|------|-------|
| `IDBonusList` | `UNIQUEIDENTIFIER` | PK |
| `IDBonusLists` | `UNIQUEIDENTIFIER` | FK → BonusLists |
| `DegreeOfTime` | `MONEY` | The degree-of-time value this entry applies to |
| `Percentage` | `MONEY` | Bonus percentage at this degree |
| `AbsoluteValue` | `MONEY` | Fixed bonus amount at this degree |

The base list (created by `BonusList_CreateBaseList`) has 75 entries covering degrees 75–149 %:

| Degree Range | Percentage | Increment |
|-------------|------------|-----------|
| 75–99 % | 100 % (flat) | — |
| 100–114 % | 100 %–114 % | +1 % per degree step |
| 115–134 % | 115 %–124.5 % | +0.5 % per degree step |
| 135–149 % | 124.5 % (flat) | — |

---

### EmployeeHandicaps

Historical handicap values for employees, with a validity start date.

| Column | Type | Notes |
|--------|------|-------|
| `IDEmployee` | `UNIQUEIDENTIFIER` | FK → Employees |
| `IDSubsidiary` | `UNIQUEIDENTIFIER` | |
| `Handicap` | `FLOAT` | 0–100 % |
| `ValidFrom` | `DATETIME` | When this handicap takes effect |

---

## 3. Relationships and Foreign Keys

### Composite Primary Keys

Nearly every table uses **composite primary keys** of `(IDSubsidiary, IDSomething)`. This ensures data isolation between subsidiaries at the physical key level.

### The Internal-ID Pattern

Several entities have both a `UNIQUEIDENTIFIER` primary key and an `INT` internal ID:

- `Employees` → `IDEmployeeInternal`
- `WorkGroups` → `IDWorkGroupInternal`
- `LabourValues` → `IDLabourValueInternal`
- `Users` → `IDUserInternal`
- `WageGroups` → `IDWageGroupInternal`
- `CostCenters` → `IDCostCenterInternal`

The GUID is the true primary key used for referential integrity. The internal INT is denormalized into operational tables (`TimeLog`, `ProductionData`, `WorkGroupAssignments`) for **join performance** — a critical optimization for a 2004-era SQL Server where integer comparisons in hot-path queries were significantly faster than GUID comparisons.

Scalar functions translate between the two:

- `dbo.WorkGroupInternal(@IDSubsidiary, @IDWorkGroup)` → INT
- `dbo.EmployeeInternal(@IDSubsidiary, @IDEmployee)` → INT
- `dbo.GetLabourValueInternal(@IDSubsidiary, @IDLabourValue)` → INT

### Key Relationship Chains

```text
Subsidiaries
 ├── CostCenters ──→ Currencies
 │    ├── WorkGroups
 │    │    ├── WorkGroupAssignments ──→ LabourValues
 │    │    ├── ProductionData
 │    │    │    └── ProductionDataItems ──→ LabourValues
 │    │    ├── TimeLog ──→ Employees, WageGroups
 │    │    └── SkillNeeded ──→ Skills
 │    ├── Employees ──→ WageGroups, AddressDetails
 │    │    └── SkillProvided ──→ Skills
 │    ├── Users ──→ AddressDetails
 │    └── BonusLists
 │         └── BonusList
 ├── LabourValues
 ├── Articles ──→ LabourValues
 └── NotificationRecipients
```

### The WasCurrentFrom / WasCurrentTo Pattern

Many master-data tables use `WasCurrentFrom` / `WasCurrentTo` / `IsCurrent` columns to implement temporal versioning. Rather than deleting or overwriting records, the system keeps history by marking records as no longer current and creating new versions. This is important for incentive wage auditing — you need to know what the wage group rate *was* when a specific shift was calculated.

---

## 4. The Trigger-Driven Recalculation Engine

This is the architectural centerpiece of Facesso's database layer. Four triggers form a **cascading recalculation chain** that keeps all KPIs consistent whenever any input data changes.

### Trigger Overview

| Trigger | Table | Fires on | Purpose |
|---------|-------|----------|---------|
| `OnProductionDataItems_InsertUpdateDelete` | `ProductionDataItems` | INSERT, UPDATE, DELETE | Recalculates `TotalReferenceIWT` in `ProductionData` |
| `OnProductionData_InsertUpdate` | `ProductionData` | INSERT, UPDATE | When `TotalReferenceIWT` changes: recalculates effective IWT, degrees of time, and pushes results to both `ProductionData` and `TimeLog` |
| `OnTimeLog_InsertUpdate` | `TimeLog` | INSERT, UPDATE | When shift times, breaks, downtime, or handicap change: recalculates per-employee metrics and cascades to group-level KPIs |
| `OnTimeLog_Delete` | `TimeLog` | DELETE | Same as above, but for deletion — recalculates remaining group metrics |

### The Cascade Flow

```text
ProductionDataItems changed (amounts)
         │
         ▼
  ┌──────────────────────────────────────────────┐
  │ OnProductionDataItems_nsertUpdateDelete      │
  │                                              │
  │ TotalReferenceIWT = Σ(Amount × TeHMin)       │
  │ → UPDATE ProductionData.TotalReferenceIWT    │
  └──────────────┬───────────────────────────────┘
                 │ (triggers next)
                 ▼
  ┌──────────────────────────────────────────────┐
  │ OnProductionData_InsertUpdate                │
  │ (fires when TotalReferenceIWT is updated)    │
  │                                              │
  │ 1. Sum all TimeLog entries for this shift:   │
  │    TotalEffectiveIWT = Σ(IncentiveWageTime)  │
  │    TotalEffectiveAdjIWT = Σ(IWT-IWT*H/100)   │
  │                                              │
  │ 2. Calculate degrees:                        │
  │    DegreeOfTime = Ref / Eff × 100            │
  │    DegreeOfTimeAdj = Ref / EffAdj × 100      │
  │                                              │
  │ 3. UPDATE ProductionData with all aggregates │
  │                                              │
  │ 4. UPDATE all TimeLog rows for this shift:   │
  │    - Recalculate AttendanceTime, WorkingTime │
  │    - Recalculate IWT and IWT adjusted        │
  │    - Set DegreeOfTime / DegreeOfTimeAdj      │
  │    - Set ReferenceWageTimeProRata            │
  └──────────────────────────────────────────────┘
```

```text
TimeLog changed (shift times, breaks, downtime, handicap)
         │
         ▼
  ┌──────────────────────────────────────────────┐
  │ OnTimeLog_InsertUpdate                       │
  │ (fires when ShiftStart, ShiftEnd, WorkBreak, │
  │  DownTime, or Handicap is updated)           │
  │                                              │
  │ 1. Look up TotalReferenceIWT from            │
  │    ProductionData for this shift             │
  │                                              │
  │ IF no production data exists:                │
  │    → Only update per-employee time metrics   │
  │    → Set DegreeOfTime = -2 (no data)         │
  │                                              │
  │ IF production data exists:                   │
  │    → Update per-employee time metrics        │
  │    → Re-sum across all employees             │
  │    → Recalculate degrees                     │
  │    → UPDATE ProductionData with new totals   │
  │    → UPDATE all TimeLog rows with degrees    │
  │      and pro-rata reference wage time        │
  └──────────────────────────────────────────────┘
```

### Key Formulas in the Triggers

**Per-employee calculations** (in TimeLog):
```text

AttendanceTime     = DATEDIFF(minute, ShiftStart, ShiftEnd)
WorkingTime        = AttendanceTime - WorkBreak
IncentiveWageTime  = WorkingTime - DownTime
IncentiveWageTimeAdj = IWT - (IWT × Handicap / 100)
```

**Group-level aggregation** (across all TimeLog rows for a shift):
```text

TotalEffectiveIWT    = Σ(IncentiveWageTime)
TotalEffectiveAdjIWT = Σ(IWT - IWT × Handicap / 100)
```

**Degree of Time**:
```text

DegreeOfTime    = (TotalReferenceIWT / TotalEffectiveIWT) × 100
DegreeOfTimeAdj = (TotalReferenceIWT / TotalEffectiveAdjIWT) × 100
```

**Pro-rata Reference Wage Time** (per employee):
```text

ReferenceWageTimeProRata = TotalReferenceIWT / TotalEffectiveIWT × IncentiveWageTime
```

### Performance Considerations (2004 Design)

The trigger architecture was optimized for SQL Server 2000/2005 with these specific techniques:

1. **Internal INT IDs**: All hot-path joins (TimeLog ↔ ProductionData ↔ WorkGroups) use `IDWorkGroupInternal` (INT) rather than the GUID primary key. Integer comparisons are significantly faster in index scans.

2. **Selective trigger execution**: The `OnProductionData_InsertUpdate` trigger checks `IF UPDATE(TotalReferenceIWT)` before doing any work. The `OnTimeLog_InsertUpdate` trigger checks `IF UPDATE(ShiftStart) OR UPDATE(ShiftEnd) OR UPDATE(WorkBreak) OR UPDATE(DownTime) OR UPDATE(Handicap)` — it does nothing if only metadata columns change.

3. **Single-pass UPDATE with variable assignment**: The triggers use SQL Server's proprietary `UPDATE ... SET @variable=expression, column=@variable` syntax to calculate and assign values in a single table scan rather than requiring a separate SELECT + UPDATE.

4. **Scoped recalculation**: All recalculations are scoped to `(IDSubsidiary, IDWorkGroupInternal, ProductionDate, Shift)` — only the affected shift's data is touched, never the entire table.

5. **Composite index on access path**: `IX_AccessData` on `(IDSubsidiary, ProductionDate, Shift, IDWorkGroup)` directly supports the primary query pattern.

6. **Nested triggers enabled**: The database is configured with `IsNestedTriggersOn = True` to allow the ProductionDataItems trigger to cascade through ProductionData's trigger. However, `RecursiveTriggersEnabled = False` prevents infinite loops.

---

## 5. Scalar and Table-Valued Functions

### Scalar Functions

| Function | Parameters | Returns | Purpose |
|----------|-----------|---------|---------|
| `WorkGroupInternal` | `@IDSubsidiary, @IDWorkGroup` | `INT` | Translates a work group GUID to its internal INT ID |
| `EmployeeInternal` | `@IDSubsidiary, @IDEmployee` | `INT` | Translates an employee GUID to its internal INT ID |
| `GetLabourValueInternal` | `@IDSubsidiary, @IDLabourValue` | `INT` | Translates a labour value GUID to its internal INT ID |
| `GetIDWageGroup` | `@IDSubsidiary, @IDEmployee` | `UNIQUEIDENTIFIER` | Looks up an employee's wage group |
| `GetIDBonusLists` | `@IDSubsidiary, @IDEmployee` | `UNIQUEIDENTIFIER` | Looks up the bonus list ID for an employee's cost center |
| `CalculateReferenceWageTimeProRata` | `@TotalReferenceIWT, @TotalEffectiveIWT, @IncentiveWageTime` | `FLOAT` | `= TotalReferenceIWT / TotalEffectiveIWT × IncentiveWageTime` (returns -1 if effective is 0) |
| `HasProductionData` | `@IDSubsidiary, @IDWorkGroup, @ProductionDate, @Shift` | `BIT` | Checks if production data exists for a given shift |
| `DegreeOfTimeAbsolute` | `@IDSubsidiary, @IDWorkGroup, @ProductionDate, @Shift` | `FLOAT` | Calculates degree of time on demand (standalone, outside triggers) |

### Table-Valued Functions

| Function | Parameters | Returns | Purpose |
|----------|-----------|---------|---------|
| `AnalysisShiftAtDay` | `@IDSubsidiary, @IDWorkGroupInternal, @ProductionDate, @Shift` | Table with 9 columns | Complete shift analysis: all totals + both degrees of time. Used by `RecalculateTimeLogAndProductionData`. |

**`AnalysisShiftAtDay` return columns:**

| Column | Description |
|--------|-------------|
| `TotalAttendanceTime` | Sum of all employee attendance times |
| `TotalDownTime` | Sum of all downtimes |
| `TotalWorkBreak` | Sum of all work breaks |
| `TotalWorkingTime` | Sum of all working times |
| `TotalReferenceIWT` | From ProductionData (target time) |
| `TotalEffectiveIWT` | Sum of IncentiveWageTime |
| `TotalEffectiveAdjIWT` | Sum of handicap-adjusted IWT |
| `DegreeOfTime` | (Reference / Effective) × 100 |
| `DegreeOfTimeAdj` | (Reference / EffectiveAdj) × 100 |

---

## 6. Sentinel Values Convention

Facesso uses specific negative values as sentinels rather than `NULL` for calculated fields:

| Value | Meaning |
|-------|---------|
| **-1** | No data available / not yet calculated / division by zero would occur |
| **-2** | No production data exists for this shift (TimeLog exists but no ProductionData yet) |

This is visible in:

- Default constraints on `TimeLog` and `ProductionData` columns (all default to `-1`)
- Trigger logic that sets degrees to `-2` when no TimeLog entries exist, and `-1` when effective IWT is zero

The convention avoids `NULL` arithmetic issues in downstream calculations and makes it easy to filter "not yet calculated" records with `WHERE DegreeOfTime > -1`.

---

## 7. The Staging-Table Pattern

Facesso uses a **staging-table pattern** for batch inserts and updates to both `TimeLog` and `ProductionDataItems`. This was a deliberate design to support multi-row editing in the UI without requiring multiple round-trips or complex transaction management.

### How it works

1. **Client collects changes** — the application accumulates new, modified, and deleted rows.

2. **Client writes to staging table** — all changes go into `TimeLogForInsert` or `ProductionDataItemsForInsert`, tagged with `IDUser` and a `Ticket` (timestamp) to scope the batch.

3. **Client calls HandleAddEdit** — the stored procedure (`TimeLog_HandleAddEdit` or `ProductionData_HandleAddEdit`) processes the staging table:
   - Deletes rows flagged with `Deleted = true` (TimeLog only)
   - Inserts new rows (where `IDTimeLog = NULL`)
   - Updates existing rows (matched by ID)
   - Cleans up the staging table

4. **Triggers fire** — the inserts/updates to the real tables trigger cascading recalculations.

This pattern ensures:

- **Atomicity**: All changes for a shift are applied together
- **Conflict isolation**: Each user's pending changes are tagged with their `IDUser` and `Ticket`
- **Trigger efficiency**: Batch inserts fire triggers once, not per-row from the client

---

## 8. Stored Procedure Reference

### Database Initialization & Maintenance

| Procedure | Purpose |
|-----------|---------|
| `InitializeDatabase` | Full database bootstrap: creates a subsidiary, currencies (EUR, CHF, DKK, GBP, PLN, CZK, USD), a base cost center, system users (`Facesso!GenericSystem`, `Facesso!TimeDataInterface`, `Facesso!ProdDataInterface`, `Administrator`), and a base bonus list. |
| `IsDatabaseSetup` | Returns whether the database has been initialized (checks for user records). |
| `SafelyTruncateAllTables` | Deletes all data from all tables in FK-safe order within a transaction, then reseeds all identity columns. Temporarily disables the `FK_Users_CostCenters` constraint. |
| `DeleteDataForOleDbImport` | Clears operational data for reimporting from external sources. |

### Time Log Operations

| Procedure | Purpose |
|-----------|---------|
| `TimeLog_HandleAddEdit` | Main entry point for time-log changes. Processes the `TimeLogForInsert` staging table: deletes flagged rows, inserts new rows (resolving internal IDs, bonus lists, and wage groups via scalar functions), updates existing rows, and cleans up staging data. |
| `TimeLog_AddItemsForAddEdit` | Adds a single row to the `TimeLogForInsert` staging table. |
| `TimeLog_UpdateValuesForShiftDate` | Recalculates all time metrics and degrees for a specific shift date. Called as a manual recalculation entry point. Sums all employee IWT values, calculates degrees, and updates both `TimeLog` and `ProductionData`. |
| `TimeLog_DeleteItem` | Deletes a single time-log entry by ID. |
| `TimeLog_GetLogItemsForShiftDate` | Retrieves all time-log entries for a shift with joined employee and cost-center details. |
| `TimeLog_GetLogItemsForRange` | Retrieves time-log records for an employee across a date range. |
| `TimeLog_GetOverlappingLogItems` | Finds time-log entries with overlapping shift times — used for validation. |
| `RecalculateTimeLogAndProductionData` | On-demand recalculation: uses `AnalysisShiftAtDay()` to recompute all metrics for a shift, then updates both `ProductionData` and `TimeLog`. |

### Production Data Operations

| Procedure | Purpose |
|-----------|---------|
| `ProductionData_AddEdit` | Creates or updates a `ProductionData` header record. Strips time from `ProductionDate`, resolves `IDWorkGroupInternal`. |
| `ProductionData_HandleAddEdit` | Main entry point for production-data-item changes. Processes `ProductionDataItemsForInsert`: inserts new items, updates existing items, cleans up staging data. Optionally returns the final result set. |
| `ProductionData_AddItemsForAddEdit` | Adds a single row to the `ProductionDataItemsForInsert` staging table. |
| `ProductionDataItems_Add` | Directly adds a production-data item (bypasses staging). |
| `ProductionData_GetProductionData` | Retrieves a production-data header with financial/timestamp details. |
| `ProductionData_GetProductionOrTemplateItems` | Returns production items if they exist; otherwise falls back to the work group's assigned labour values as a template (with amounts set to 0). |
| `ProductionData_DoProductionDataExist` | Checks if production data exists for a specific shift date. |

### Production Data Analysis

| Procedure | Purpose |
|-----------|---------|
| `ProductionData_Analysis_AddProductionDateItem` | Adds a date/shift entry to the `ParamsProductionDates` parameter table for analysis queries. |
| `ProductionData_Analysis_DeleteProductionDateItems` | Removes a date entry from analysis parameters. |
| `ProductionData_Analysis_GetPeriodResultSet` | Retrieves production data for a work group across multiple dates (joined via `ParamsProductionDates`). |
| `ProductionData_Analysis_GetResultSet` | Retrieves all production data for analysis. |
| `ProductionData_Analysis_GetShiftDateResultSet` | Retrieves production data for a specific shift/date. |
| `TimeLog_Analysis_GetEmployeeResult` | Retrieves time-log entries for employee-level analysis. |

### Bonus List / Incentive Wage Operations

| Procedure | Purpose |
|-----------|---------|
| `BonusList_CreateBaseList` | Creates the default bonus schedule for a cost center (75 entries from 75 %–149 % degree of time with tiered percentage increases). |
| `BonusList_AddEntry` | Adds a single entry to a bonus list. |
| `BonusList_ReplaceEntry` | Updates the percentage and absolute value for an existing bonus-list entry. |
| `BonusList_DeleteList` | Deletes an entire bonus list and its header. |
| `BonusList_FromBaseCostCenter` | Clones a bonus list from a base cost center to another cost center. |
| `Employees_LookUpWageData` | **Key wage-calculation procedure.** For a given employee and degree of time: (1) looks up the base wage (from wage group or employee fixed wage), (2) checks whether the cost center uses percentage or fixed-value bonuses, (3) finds the bonus-list entry closest to the given degree, (4) returns all four values as OUTPUT parameters (`@UseFixValuedBonus`, `@BaseWage`, `@Percentage`, `@AbsoluteValue`). |

### Employee CRUD

| Procedure | Purpose |
|-----------|---------|
| `Employees_Add` | Creates an employee with a linked address-detail record. |
| `Employees_Edit` | Updates employee data. |
| `Employees_Delete` | Deletes an employee. |
| `Employees_DoesMatchcodeExist` | Validates matchcode uniqueness. |
| `Employees_DoesPersonnelNumberExist` | Validates personnel number uniqueness. |
| `Employees_IsInUse` | Checks if an employee is referenced in `TimeLog` or `SkillProvided`. |
| `Employees_GetInWorkGroupOnShiftDate` | Retrieves all employees who have time-log entries for a given work group on a given shift date — joined with employee and cost-center details. |

### Labour Values CRUD

| Procedure | Purpose |
|-----------|---------|
| `LabourValues_Add` | Creates a labour value with auto-assigned internal ID. |
| `LabourValues_Edit` | Updates a labour value. |
| `LabourValues_Delete` | Deletes a labour value. |
| `LabourValues_DoesNumberExist` | Validates labour value number uniqueness. |
| `LabourValues_IsInUse` | Checks if a labour value is referenced in `WorkGroupAssignments`. |

### Work Groups CRUD

| Procedure | Purpose |
|-----------|---------|
| `WorkGroups_Add` | Creates a work group. Time-setting details are stored as XML. |
| `WorkGroups_Edit` | Updates a work group. |
| `WorkGroups_Delete` | Deletes a work group. |
| `WorkGroups_DoesWorkGroupNameExist` | Validates name uniqueness. |
| `WorkGroups_DoesWorkGroupNumberExist` | Validates number uniqueness. |
| `WorkGroups_IsInUse` | Checks if a work group is referenced in `ProductionData`, `TimeLog`, or `SkillNeeded`. |
| `WorkGroups_GetItems` | Lists work groups with optional cost-center join and production-data counts. |
| `WorkGroups_AddAssignmentRecord` | Assigns a labour value to a work group. |
| `WorkGroups_DeleteAssignment` | Removes a labour value assignment. |
| `WorkGroups_GetAssignedLabourValues` | Lists assigned labour values with cost-center details. |

### Cost Centers CRUD

| Procedure | Purpose |
|-----------|---------|
| `CostCenters_Add` | Creates a cost center within a transaction. |
| `CostCenters_Edit` | Updates a cost center. |
| `CostCenters_Delete` | Deletes a cost center. |
| `CostCenters_DoesNumberExist` | Validates cost-center number uniqueness. |
| `CostCenters_IsInUse` | Checks usage across `LabourValues`, `Employees`, `Users`, and `WorkGroups`. |
| `CostCenters_GetBaseCostCenterID` | Returns the ID of the base cost center (number = 0). |

### Subsidiaries CRUD

| Procedure | Purpose |
|-----------|---------|
| `Subsidiaries_Add` | Creates a subsidiary with a cloned base cost center, admin user, and bonus list — all within a transaction. |
| `Subsidiaries_Edit` | Updates subsidiary info. |
| `Subsidiaries_Delete` | Deletes a subsidiary and all related data. |
| `Subsidiaries_DoesNameExist` | Validates name uniqueness. |

### Wage Groups CRUD

| Procedure | Purpose |
|-----------|---------|
| `WageGroups_Add` | Creates a wage group. |
| `WageGroups_Edit` | Updates a wage group. |
| `WageGroups_DoesTokenExist` | Validates token uniqueness. |

### Users CRUD

| Procedure | Purpose |
|-----------|---------|
| `Users_Add` | Creates a user with linked address details. |
| `Users_Edit` | Updates user data. |
| `Users_DoesUsernameExist` | Validates username uniqueness. |

### Address Details & Miscellaneous

| Procedure | Purpose |
|-----------|---------|
| `AddressDetails_Add` | Creates an address-detail record. |
| `AddressDetails_Edit` | Updates an address-detail record. |
| `NotificationRecipients_AddEdit` | Adds or updates a notification recipient. |
| `NotificationRecipients_DoesEmailExist` | Validates email uniqueness. |
| `Currencies_Add` | Creates a currency record. |
| `ApplicationSettings_Get` | Retrieves settings (XML) for a user or global scope. |
| `ApplicationSettings_Set` | Stores or updates settings. |
| `AddToFunctionLog` | Writes an audit-log entry. |
| `BaseData_DoEmployeesExist` | Checks if a subsidiary has employees. |
| `BaseData_DoLabourValuesExist` | Checks if a subsidiary has labour values. |
| `BaseData_DoWorkGroupsExist` | Checks if a subsidiary has work groups. |
