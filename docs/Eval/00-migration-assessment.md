<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 00-migration-assessment
-->

# Facesso — Comprehensive Migration Assessment

## Table of Contents

1. [Solution Overview](#1-solution-overview)
2. [Inventory](#2-inventory)
3. [Area Evaluations](#3-area-evaluations)
4. [Scorecard Summary](#4-scorecard-summary)
5. [Recommended Strategy](#5-recommended-strategy)
6. [Risk Register](#6-risk-register)

---

## 1. Solution Overview

**Facesso** is a REFA-based production data acquisition and incentive wage calculation system built approximately 15 years ago for manufacturing environments. It provides employee time tracking, production KPI computation (Zeitgrad/Degree of Time), work group analytics, and incentive wage calculations.

| Dimension | Value |
|-----------|-------|
| **Codebase Size** | ~35,000 LOC across 240 VB.NET source files |
| **Projects in Solution** | 17 (3 WinExe + 14 Libraries) |
| **Primary Language** | VB.NET (16 projects); C# (1 project: ADSimplePrintDocument) |
| **Target Framework** | .NET Framework 4.7.2 (uniform across all projects) |
| **UI Framework** | Windows Forms (MDI pattern) |
| **Database** | SQL Server — 28 tables, 80 stored procedures, 9 scalar functions, 4 triggers |
| **Test Coverage** | 0% — no test projects exist |
| **NuGet Packages** | 11 (mostly .NET 8+ compatible) |
| **COM/GAC Dependencies** | None |
| **Deployment** | ClickOnce (HTTP) + legacy .vdproj MSI installers |
| **CI/CD** | None |

---

## 2. Inventory

### 2.1 Solution Topology

The solution contains 17 projects organized in a clean layered architecture:

**Entry Points (3 WinExe):**
- `Facesso.exe` — Main MDI shell application with calendar/shift navigation, employee and work group management
- `FacessoConfig.exe` — Standalone database and license configuration utility
- `ADSerialGenerator.exe` — Internal license serial number generator

**Core Business Libraries (5 DLL):**
- `Fac_Data` (FacessoData) — Data access layer: 11 partial SPAccess classes wrapping 80 stored procedures
- `Fac_Functions` (FacFunctions) — Business logic, ~50 dialog forms, reports, print classes (~82 VB files)
- `FAC_Generic` — Application singleton hub: configuration, licensing, login, settings, subsidiary management
- `FacInterfaces` — External system import adapters (Kannegiesser, Jensen, Legatro, ZI Interflex)
- `Fac_EntityModel` — Entity Framework 6 EDMX model (parallel to SPAccess, minimally used)

**UI Control Libraries (2 DLL):**
- `Fac_GenericControls` — Domain-specific controls (ListViews, DateRange pickers, DataGridViews)
- `ADNullableValueControls` (Controls) — Generic nullable-aware input controls (largest library: 58KB template file)

**Infrastructure Libraries (7 DLL, all prefixed "ActiveDevelop." or "AD"):**
- `ADDataTypes` — Core types: ADDBNullable(Of T), enums, expression parser
- `ADInfoItem` — InfoItemsBase entity base class
- `ADLicenceManager` — License validation framework with anti-tampering
- `ADSimplePrintDocument` — Print document abstraction (**C#** — only non-VB project)
- `ADSqlSupportComponents` — SQL Server connection dialog components
- `ADSundries` — Utilities: ADCryptedPassword (SHA1), ADComputerInfo (WMI), wizard framework
- `ActiveDevelop.SqlTools` — DatabaseSchemaUpdateManager base class

**Separate Solutions (not in main Facesso.sln):**
- `Database/FacessoDB` — SQL Server Database Project (SQLPROJ)
- `HoloLens/Facesso.HoloLens.Mock` — Experimental UWP HoloLens client (isolated, not migration-relevant)

**Dependency Graph:** Clean DAG with no circular dependencies. `FAC_Generic` is the central hub referenced by 10+ projects. `ADDataTypes` and `ADSundries` are leaf-level foundations.

### 2.2 Language & Compiler

| Aspect | Detail |
|--------|--------|
| **Primary Language** | VB.NET (16 of 17 projects) |
| **Secondary Language** | C# (1 project: ADSimplePrintDocument) |
| **Language Version** | VB 15.x (inferred from .NET 4.7.2 target) |
| **Option Strict** | **On** across all VB.NET projects (enforced strict typing) |
| **My Namespace** | Used extensively — `My.Application`, `My.Resources`, `My.Computer` |
| **Microsoft.VisualBasic** | Implicit dependency (VB runtime); `Module` declarations throughout |
| **VB-Specific Patterns** | Module (static class), WithEvents, Handles keyword, partial classes for forms |
| **P/Invoke** | None detected |
| **COM Interop** | System.Management (WMI) for hardware info — not COM reference |
| **T4 Templates** | None |
| **Source Generators** | None |
| **Unsafe Code** | None |
| **Code Analysis** | FxCop AllRules.ruleset configured in legacy projects |
| **Assembly Signing** | ActiveDev.pfx strong-name key used across most projects |
| **Warnings As Errors** | Configured: 42016, 42017, 42018, 42019, 42020, 42021, 42022, 42032, 42036, 41999 |

### 2.3 Third-Party & Platform Dependencies

**NuGet Packages (11):**

| Package | Version | Category | .NET 8+? |
|---------|---------|----------|----------|
| Newtonsoft.Json | 13.0.4 | Serialization | ✅ |
| System.Reactive (4 packages) | 6.1.0 | Reactive Extensions | ✅ |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | Runtime | ✅ Built-in |
| System.Threading.Tasks.Extensions | 4.6.3 | Runtime | ✅ Built-in |
| System.Resources.Extensions | 4.6.0 | Resources | ✅ |
| MvvmForms | 2.1.7-Beta3 | UI MVVM | ❓ Unknown |
| MvvmFormsBase | 2.1.6-Beta | UI MVVM | ❓ Unknown |
| EntityFramework (EF6) | 6.x | ORM | ⚠️ Limited |

**Platform Dependencies Requiring Action:**

| Dependency | Action for .NET 8+ |
|------------|-------------------|
| System.Data.SqlClient | Replace with Microsoft.Data.SqlClient |
| System.Management (WMI) | Add NuGet package |
| System.Drawing.Common | Add NuGet package (Windows-only) |
| RDLC ReportViewer | Use community NuGet package |
| LINQ to SQL (.dbml) | Replace with EF Core or Dapper |

**No COM references, no GAC dependencies, no discontinued vendor control suites.**

### 2.4 Data Layer

**Database Engine:** SQL Server (2008 R2+, inferred from features used)

**Connection Strategy:** Singleton `FacessoGeneric.SQLConnectionString` property reads from Windows Registry. Replicated between HKEY_LOCAL_MACHINE and HKEY_CURRENT_USER.

**Data Access Patterns:**
- **Primary:** Raw ADO.NET `SqlCommand` calling stored procedures via `SPAccess` singleton class
- **Secondary:** Entity Framework 6 EDMX model (`Fac_EntityModel`) — present but minimally/not used for primary operations
- **Import layer:** LINQ to SQL (`.dbml`) for Kannegiesser SQL integration
- **Ad-hoc queries:** String-concatenated SQL in `Fac_FunctionsInternal.vb` and `LoginUserClasses.vb` (anti-pattern)

**Database-Side Logic:**
- **80 stored procedures** — organized by domain: Employees (7), WorkGroups (10), TimeLog (8), ProductionData (12), LabourValues (5), CostCenters (6), BonusList (5), Users (3), WageGroups (3), Settings (2), Utilities (8), Others (11)
- **9 scalar functions** — ID mapping (GUID→INT), KPI calculations (DegreeOfTime, ReferenceWageTimeProRata), lookups
- **4 triggers** — Cascading KPI recalculation chain: TimeLog ↔ ProductionData ↔ ProductionDataItems
- **0 views**

**Schema Patterns:**
- **Multi-tenant:** Compound PKs with `IDSubsidiary` (UNIQUEIDENTIFIER) throughout
- **Dual-ID:** GUID PKs for referential integrity + INT internal IDs (`IDWorkGroupInternal`, `IDEmployeeInternal`) denormalized for join performance
- **History tracking:** `IsCurrent`, `WasCurrentFrom`, `WasCurrentTo` columns (soft-delete pattern)
- **Sentinel values:** `-1` (no valid data), `-2` (recalculation needed) replace NULLs in calculated fields
- **XML columns:** `WorkGroups.TimeSettingDetails` (shift configuration), `ApplicationSettings.Settings` (user preferences)
- **Staging tables:** `TimeLogForInsert`, `ProductionDataItemsForInsert` for bulk import

### 2.5 Architecture & Patterns

**Layer Separation:**
- **UI Layer:** Facesso.exe (MDI shell) + FacessoConfig.exe (config tool)
- **Business Logic:** Fac_Functions (forms + logic), FacInterfaces (imports)
- **Data Access:** Fac_Data (SPAccess), Fac_EntityModel (EF6)
- **Database:** SQL Server with triggers and stored procedures
- **Quality:** Genuine separation exists, but business logic bleeds into UI forms (form classes contain data binding + validation logic) and database (triggers implement core calculations)

**Dependency Injection:** None. Uses singleton modules (`FacessoGeneric`, `RegistryHelper`) and manual wiring. `FunctionHandler(Of T)` provides factory-based instantiation with permission checking.

**Configuration:** Windows Registry (connection string, license data) + Database (XML-serialized user/global settings via `ApplicationSettings` table)

**Logging:** None. No logging framework. Error information displayed in `frmError` dialog. `FunctionLog` table exists in database but usage is minimal.

**Error Handling:** Custom exception hierarchy rooted at `FacessoApplicationExceptionBase`. Global unhandled exception handler in `ApplicationEvents.vb`. Try/Catch used inconsistently.

**Threading:** Minimal. No async/await, no BackgroundWorker, no TPL. All operations synchronous on UI thread. System.Reactive NuGet included but underused.

**Deployment:** ClickOnce (HTTP URL: `http://facesso.de/updates/`) + legacy `.vdproj` MSI installers (deprecated in VS 2022).

### 2.6 Security

**Authentication:** Custom username/password login. SQL injection vulnerability in login query. SHA1 password hashing with 4-byte salt. Authentication logic bug (always sets authenticated=true).

**Authorization:** Role-based (`ClearanceLevel` enum) + version-based (license tier). Per-function enforcement via `IFacessoFunction` interface.

**Secrets:** Connection string and license data stored in plain-text Windows Registry.

**Network Exposure:** Desktop application — no web surface. SQL Server connection over LAN. ClickOnce updates over HTTP (MITM risk).

### 2.7 Testing & Quality

**Test Projects:** None. Zero unit tests, integration tests, or any automated testing.

**Static Analysis:** FxCop AllRules.ruleset configured in project files.

**CI/CD:** None. No build pipelines, no automated quality gates.

---

## 3. Area Evaluations

### Area A — Separation of Concerns (Score: 6/10, Risk: Medium)

Facesso demonstrates genuine architectural layering that was thoughtful for its era. The solution cleanly separates UI (Facesso main + FacessoConfig), business logic (Fac_Functions with 82 files of dialog and service code), data access (Fac_Data with the SPAccess partial-class pattern), and database (SQL Server with stored procedures).

However, concerns leak across boundaries in three significant ways. First, dialog forms in Fac_Functions contain data-binding logic tightly coupled to specific data access methods — forms know about `SPAccess.GetInstance()` and call database methods directly. Second, the core KPI calculation logic lives in database triggers, making it invisible to the application layer and untestable without a live database. Third, the `FacessoGeneric` module acts as a god object providing configuration, login state, licensing, and settings to every layer.

The interface-based import system (`IFacessoImportTaskItem` with implementations for Kannegiesser, Jensen, Legatro) shows good extensibility design. The factory pattern via `FunctionHandler(Of T)` with permission checking is well-structured. These patterns demonstrate the developer understood separation principles even if enforcement wasn't always consistent.

**Migration implication:** Layers can be retargeted to .NET 8+ independently, bottom-up. The trigger-to-application migration is the biggest separation challenge.

### Area B — Framework & Runtime (Score: 4/10, Risk: High, BLOCKING)

All 17 projects target .NET Framework 4.7.2 uniformly. None use SDK-style project files — all are legacy `.vbproj` format requiring conversion. The `Facesso.vbproj` has both `<UseWindowsForms>true</UseWindowsForms>` and `<UseWPF>true</UseWPF>` flags, which needs investigation (likely WPF interop rather than actual WPF usage).

The .NET 4.7.2 target is two major generations behind modern .NET (8/9). While .NET 4.7.2 has high API compatibility with .NET 8+, the project file format conversion is mechanical but tedious across 17 projects. Assembly binding redirects in `app.config` files (Newtonsoft.Json, System.Reactive, System.Runtime.CompilerServices.Unsafe) will need to be removed or updated.

Blocking APIs are limited: `System.Data.SqlClient` → `Microsoft.Data.SqlClient` is a near-drop-in replacement. LINQ to SQL (`.dbml` in Kannegiesser integration) is not available on .NET 8+ and must be replaced. The ClickOnce deployment model is supported on .NET 8+ but requires project file reconfiguration.

**Migration implication:** Retargeting is feasible but requires converting all 17 project files to SDK-style format. Estimated 2–3 weeks for the full conversion with testing.

### Area C — Language Modernization (Score: 4/10, Risk: High)

The codebase is ~99% VB.NET with one C# project. VB.NET is fully supported on .NET 8+ and WinForms on modern .NET works with VB.NET. However, VB.NET has a reduced feature set compared to C# on modern .NET (no `init` accessors, no record types, limited pattern matching, no default interface members, etc.).

Positive: `Option Strict On` is enforced across all projects, meaning the code already has strict typing — this makes both VB→C# conversion and migration safer. There are no late-binding patterns to untangle.

Negative: Heavy use of VB-specific constructs complicates potential C# conversion:
- `Module` declarations (VB static classes with implicit import)
- `WithEvents` / `Handles` (event subscription pattern not available in C#)
- `My` namespace (`My.Application`, `My.Resources`, `My.Computer`)
- VB-specific `Using` patterns and `DirectCast` / `CType` operators
- `ADDBNullable(Of T)` custom nullable type (predates .NET Nullable)

The VB→C# conversion question is strategic: staying on VB.NET is viable but limits access to modern language features and shrinks the available developer pool. Conversion tools exist (e.g., CodeConverter by icsharpcode) but require manual review, especially for event handling patterns.

**Migration implication:** VB→C# conversion is optional but recommended for long-term maintainability. Effort is ~10–15 days for tooling-assisted conversion with manual cleanup.

### Area D — Third-Party Dependencies (Score: 7/10, Risk: Medium)

This is Facesso's strongest area. The dependency profile is remarkably clean:
- 8 of 11 NuGet packages are fully .NET 8+ compatible or built into the runtime
- No COM references or GAC dependencies
- No discontinued vendor control suites (a common migration killer)
- All infrastructure libraries are in-house (ActiveDevelop.*) and migrate with the solution

The two risk areas are:
1. **MvvmForms/MvvmFormsBase** (2.1.x-Beta) — Niche MVVM framework with unknown .NET 8+ status. May need replacement with CommunityToolkit.Mvvm. Usage extent needs assessment.
2. **Entity Framework 6** — In maintenance mode. The EDMX model is minimally used, so replacing/dropping it is low risk.

**Migration implication:** No dependency blockers. MvvmForms is the only unknown — assess usage and availability on .NET 8+.

### Area E — Data Access & ORM (Score: 5/10, Risk: High)

Data access is heavily concentrated in the `SPAccess` singleton class, split across 11 partial class files. Every database operation goes through stored procedures via `SqlCommand` with `CommandType.StoredProcedure`. This is a consistent, if dated, pattern.

Positive: Parameterized queries are used consistently in the SPAccess layer — no SQL injection risk in the primary data access path. Connection lifecycle management uses `Using` statements properly. The singleton pattern provides a single point for connection string management.

Negative: 80 stored procedures represent a large migration surface. The `SPAccess` singleton is untestable without a live database. The parallel EF6 EDMX model adds confusion — it's unclear if it's used for any runtime operations or is purely legacy. The LINQ to SQL usage in FacInterfaces adds a second deprecated data access pattern.

The critical concern is coupling between application code and stored procedure contracts. Each `SPAccess_*` method directly maps to a specific stored procedure with specific parameter signatures. Migrating to EF Core requires rewriting these methods as repository/service classes.

**Migration implication:** The 28 simple CRUD stored procedures can be replaced with EF Core straightforwardly. The 20+ KPI-related SPs and 4 triggers require careful analysis and comprehensive testing before migration.

### Area F — Database Schema & Design (Score: 6/10, Risk: Medium)

The schema is well-designed for its requirements:
- Clean multi-tenant partitioning via `IDSubsidiary` compound primary keys
- Thoughtful dual-ID pattern (GUID PKs + INT internal IDs for performance)
- Soft-delete with `IsCurrent` / `WasCurrentFrom` / `WasCurrentTo` columns
- Proper foreign key relationships with descriptive constraints

EF Core mapping challenges:
- Compound primary keys (`IDSubsidiary` + entity-specific GUID) require explicit configuration
- The dual GUID/INT ID pattern needs custom value generation or computed column mapping
- XML columns (`TimeSettingDetails`, `Settings`) need custom value converters
- Sentinel values (-1, -2) replacing nulls are anti-patterns for EF Core — need migration to proper NULLs or custom value converters
- History tracking columns should map to EF Core's temporal table support or shadow properties

**Migration implication:** Schema migration to EF Core is feasible but requires significant Fluent API configuration. The sentinel value pattern is the most tedious to address.

### Area G — UI Framework & Controls (Score: 4/10, Risk: High, BLOCKING)

WinForms is fully supported on .NET 8+, which is the saving grace. The application can be retargeted without rewriting UI.

However, the UI complexity is substantial:
- ~50 WinForms forms/dialogs across the solution
- MDI parent-child pattern (`frmFacessoShell` as MDI host)
- Custom `ADNullableValueControls` library (58KB template file, 8 control classes) with complex nullable data binding
- Custom toolbar controls (`ToolStripMonthCalender`)
- MvvmForms/MvvmFormsBase beta MVVM integration
- RDLC reports (ReportViewer control)
- All UI text hardcoded in German (no resource files for i18n)
- `frmBaseFacesso` base form used across all dialogs

The `ADNullableValueControls` library is the highest-risk UI component. Its 58KB template file suggests code generation or heavy designer reliance. These controls may have subtle WinForms designer compatibility issues on .NET 8+.

**Migration implication:** WinForms retargeting is feasible. Full UI modernization (to Blazor/MAUI) would be a separate, very large effort. Recommend retarget-first, modernize-later.

### Area H — Performance Architecture (Score: 5/10, Risk: High)

The absence of asynchronous programming is the primary performance concern. All database calls are synchronous on the UI thread — heavy queries or slow network connections will freeze the application. The `System.Reactive` NuGet packages are included but appear underused.

The database trigger cascade is a double-edged sword: it ensures consistency but can cause unexpected performance degradation when modifying large batches of TimeLog or ProductionData records. Each insert/update triggers cascading recalculations across related tables.

The dual-ID pattern (GUID PKs + INT internal IDs) was a smart optimization for join performance, though modern SQL Server handles GUID joins well with proper indexing.

**Migration implication:** Adding async/await to the data layer is recommended but not blocking. Trigger performance should be profiled before deciding on migration strategy.

### Area I — Extensibility & Modularity (Score: 6/10, Risk: Medium)

The solution demonstrates good modular design in several areas:
- Interface-based import system (`IFacessoImportTaskItem`) with 4+ concrete implementations
- Factory pattern (`FunctionHandler(Of T)`) for permission-checked function instantiation
- Clean project boundaries with logical responsibility separation

The primary extensibility blocker is the `FacessoGeneric` module acting as a service locator. Every project depends on this singleton for configuration, login state, and settings. This creates a tight coupling that prevents independent testing or deployment of subsystems.

**Migration implication:** Introducing dependency injection to replace `FacessoGeneric` is the key enabler for testability and modularity.

### Area J — Security Posture (Score: 2/10, Risk: Critical, BLOCKING)

**Critical findings:**
1. SQL injection in authentication query (`LoginUserClasses.vb`) — allows complete login bypass
2. Authentication logic bug — `myAuthenticated` always set to `true` regardless of password validation
3. SHA1 password hashing with 4-byte salt — cryptographically weak
4. ClickOnce updates over HTTP — man-in-the-middle attack vector
5. Plain-text connection string in Windows Registry
6. Assembly signing key (`ActiveDev.pfx`) committed to source control

**Positive findings:**
- Role-based authorization model is well-designed
- Multi-tenant IDSubsidiary filtering is consistent
- Primary data access layer uses parameterized queries
- No hardcoded credentials in source

See `06-security-assessment.md` for full analysis and remediation priorities.

**Migration implication:** Security fixes are mandatory before any migration. The SQL injection and auth bug are P0 fixes that should be applied to the current codebase immediately.

### Area K — Deployment & Operations (Score: 3/10, Risk: Critical)

The deployment story is outdated:
- `.vdproj` MSI installers are deprecated and unsupported in VS 2022
- ClickOnce deployment configured for HTTP (not HTTPS)
- No CI/CD pipeline exists
- Configuration stored in Windows Registry (not portable, not containerizable)
- No health checks, metrics, or observability

The application is tightly coupled to the Windows desktop deployment model: Registry for configuration, ClickOnce for updates, WMI for hardware identification (licensing). This makes any move toward containerization or cloud deployment very difficult without refactoring.

**Migration implication:** Deployment modernization is a separate workstream. Replace .vdproj with MSIX or WiX. Move configuration from Registry to `appsettings.json`. Set up CI/CD with automated build/test/package.

### Area L — Testing & Confidence (Score: 1/10, Risk: Critical, BLOCKING)

Zero test coverage. No test projects, no test frameworks referenced, no evidence of any automated testing. The only test infrastructure is a hidden admin form (`frmHiddenTestAndAdmin.vb`) for manual testing and a `DemoData.vb` class for generating sample data.

This is the single biggest risk for any migration effort. Without tests:
- KPI calculation correctness cannot be verified after changes
- Trigger behavior cannot be validated after migration to application layer
- Stored procedure contracts cannot be verified after EF Core migration
- VB→C# conversion correctness cannot be validated

**Migration implication:** Building a test harness is the mandatory first investment before any migration work begins. Integration tests for KPI calculations (the trigger chain) are the highest priority.

### Area M — Documentation & Knowledge (Score: 3/10, Risk: Critical)

Documentation is sparse:
- `README.md` provides a high-level overview of Facesso's purpose and architecture
- No inline architecture documentation
- No API documentation
- No database schema documentation beyond column names
- REFA-based wage calculation logic is undocumented — this is complex domain knowledge
- All UI labels, messages, and comments are in German
- Sentinel values (-1, -2) are undocumented except through code inspection

The REFA domain knowledge represents tribal knowledge risk. The DegreeOfTime calculation (Zeitgrad), reference wage time pro-rata allocation, handicap adjustments, and incentive wage formulas are domain-specific and non-obvious. Losing this knowledge would make the trigger migration extremely risky.

**Migration implication:** Document the KPI calculation formulas and business rules before migrating trigger logic. Create a domain glossary mapping German terms to English equivalents.

---

## 4. Scorecard Summary

| Area | Score | Risk | Blocking? | Key Finding |
|------|-------|------|-----------|-------------|
| A — Separation of Concerns | 6 | Medium | No | Good layering; logic leaks into UI and DB triggers |
| B — Framework & Runtime | 4 | High | **Yes** | .NET Fx 4.7.2; non-SDK projects; WPF interop flag |
| C — Language Modernization | 4 | High | No | VB.NET throughout; Option Strict On; heavy VB idioms |
| D — Third-Party Dependencies | 7 | Medium | No | Clean profile; MvvmForms beta is only unknown |
| E — Data Access & ORM | 5 | High | No | 80 SPs via SqlCommand; EF6 present but unused |
| F — Database Schema & Design | 6 | Medium | No | Multi-tenant design; sentinel values need migration |
| G — UI Framework & Controls | 4 | High | **Yes** | WinForms MDI; complex custom controls; all German |
| H — Performance Architecture | 5 | High | No | Zero async; trigger cascades; Rx underused |
| I — Extensibility & Modularity | 6 | Medium | No | Good import interfaces; FacessoGeneric is bottleneck |
| J — Security Posture | 2 | Critical | **Yes** | SQL injection in login; auth bug; SHA1 passwords |
| K — Deployment & Operations | 3 | Critical | No | Deprecated .vdproj; no CI/CD; Registry config |
| L — Testing & Confidence | 1 | Critical | **Yes** | Zero test coverage; zero automated testing |
| M — Documentation & Knowledge | 3 | Critical | No | REFA domain knowledge undocumented; all German |
| **Weighted Average** | **4.3** | **High** | **4 blocking** | |

---

## 5. Recommended Strategy

### Approach: Phased Strangler Fig with Security-First Priority

**Rationale:** The clean layered architecture and absence of circular dependencies make an incremental bottom-up migration feasible. Security fixes are mandatory regardless of migration. A test harness must precede any structural changes.

### Phase Summary

| Phase | Focus | Effort % | Elapsed (2 FTE) |
|-------|-------|----------|-----------------|
| 0 — Security Hotfix | Fix SQL injection, auth bug, HTTPS | 1% | 1 week |
| 1 — Test Infrastructure | Integration + unit tests for core logic | 10% | 2 weeks |
| 2 — SDK + Framework Retarget | Convert projects, retarget to .NET 8+ | 20% | 5 weeks |
| 3 — Core Modernization | DI, config, logging, password hashing | 14% | 3 weeks |
| 4 — Data Layer Modernization | SP→EF Core migration, trigger evaluation | 33% | 8 weeks |
| 5 — UI & Deployment | Optional VB→C#, CI/CD, MSIX, i18n | 22% | 5 weeks |
| **Total** | | **100%** | **~24 weeks (6 months)** |

See `07-migration-sequence.md` for detailed project-by-project migration order.

---

## 6. Risk Register

| Risk | Probability | Impact | Mitigation |
|------|------------|--------|------------|
| KPI calculation regression after trigger migration | High | Critical | Integration tests before migration; parallel run period |
| MvvmForms incompatible with .NET 8+ | Medium | Medium | Assess usage extent; prepare CommunityToolkit.Mvvm fallback |
| ADNullableValueControls designer issues on .NET 8+ | Medium | High | Test early in Phase 2; prepare simplified replacement controls |
| REFA domain knowledge loss | Medium | Critical | Document formulas and rules in Phase 1; involve domain expert |
| VB→C# conversion introduces subtle bugs | Medium | High | Only convert with comprehensive test coverage in place |
| Sentinel values (-1, -2) cause EF Core mapping issues | High | Medium | Create custom value converters; consider schema migration to NULLs |
| LINQ to SQL replacement breaks Kannegiesser import | Medium | Medium | Test import end-to-end; may need temporary dual data access |
| Registry removal breaks existing installations | High | Medium | Provide migration tool for Registry→appsettings.json |
