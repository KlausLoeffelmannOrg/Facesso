# SDK-Style Conversion Plan

## Table of Contents

- [Executive Summary](#executive-summary)
- [Upgrade Strategy](#upgrade-strategy)
- [Detailed Dependency Analysis](#detailed-dependency-analysis)
- [Pre-Conversion Prerequisites](#pre-conversion-prerequisites)
- [Project Conversion Status](#project-conversion-status)
- [Project-by-Project Upgrade Plans](#project-by-project-upgrade-plans)
- [Risk Management](#risk-management)
- [Complexity & Effort Assessment](#complexity--effort-assessment)
- [Source Control Strategy](#source-control-strategy)
- [Success Criteria](#success-criteria)

---

## Executive Summary

### Scenario
**SDK-Style Project Conversion** — Convert all 17 legacy (non-SDK-style) project files in the Facesso solution to modern SDK-style format while preserving the existing .NET Framework 4.7.2 target, all dependencies, and build behavior. This is a **structural-only** conversion with no framework upgrade.

### Scope

| Metric | Value |
|--------|-------|
| **Total Projects** | 17 (16 VB.NET + 1 C#) |
| **Projects to Convert** | 17 (all legacy format) |
| **Target Framework** | .NET Framework 4.7.2 (unchanged) |
| **Packages.config Files** | 4 (will migrate to PackageReference) |
| **Test Projects** | 0 |
| **ASP.NET Web Apps** | 0 |
| **Dependency Depth** | 6 levels |
| **Circular Dependencies** | None |

### Selected Strategy
**All-At-Once Strategy** — All 17 projects are converted in a single coordinated operation following strict topological dependency order. Each project is converted, built, and verified individually, but the entire conversion is treated as one atomic effort.

**Rationale**:
- Small-medium solution (17 projects, well under 30-project threshold)
- All projects on same framework (.NET Framework 4.7.2)
- Homogeneous codebase (all class libraries, consistent patterns)
- No external dependency complexity beyond the ReportViewer GAC reference
- Structural-only conversion (no framework/API changes)

### Critical Blockers
**⚠️ 3 pre-existing build errors must be resolved before conversion begins**:
1. `ADSerialGenerator` — BC30469: Non-shared member access in static context (`Settings.Designer.vb:34`)
2. `FacInterfaces` — BC30002: Missing `Microsoft.Reporting.WinForms.ReportViewer` assembly (2 errors)
3. `Facesso` — BC2017: Cascading failure from FacInterfaces (auto-resolves)

### Complexity Classification
**Medium** — 17 projects with depth 6, 1 high-risk item (missing GAC assembly), 4 packages.config migrations. Manageable as a single coordinated conversion.

### Automation Mode
**Automatic** — Conversion will proceed through all 17 projects without stopping between each one. Execution will only pause if a blocker is encountered that cannot be resolved within constraints.

---

## Upgrade Strategy

### Approach: All-At-Once with Dependency-Ordered Execution

All 17 projects are converted in a **single coordinated operation** following strict topological dependency order. There are no intermediate states or multi-targeting phases — the conversion is atomic.

**Why All-At-Once?**
- All projects share the same target framework (.NET Framework 4.7.2)
- The conversion is purely structural (project file format change only)
- No framework upgrade means no API breaking changes from the conversion itself
- Clean dependency graph with no cycles
- Solution is small enough (17 projects) for single-pass execution

### Execution Approach

**Phase 0: Fix Pre-existing Build Errors**
- Resolve the 3 pre-existing build errors that block baseline build
- Verify full solution builds with 0 errors
- Document baseline warning count
- Commit fixes as a separate checkpoint

**Phase 1: Atomic SDK-Style Conversion**
- Convert all 17 projects using the SDK-style conversion tool in strict topological order
- Build each project individually after conversion (not the full solution)
- Fix any conversion-caused build errors immediately
- Check for globbing conflicts (ItemGroups with removed items)
- Verify `packages.config` removed for applicable projects (ADInfoItem, Fac_GenericControls, Fac_Functions, Facesso)
- Commit after each successful project conversion

**Phase 2: Full Solution Verification**
- Build the entire solution to confirm integration
- Compare warning count to baseline
- Verify all project outputs are correct

### Hard Constraints (SDK-Style Conversion)

| Constraint | Description |
|------------|-------------|
| **No TargetFramework changes** | All projects remain on `net472` — do not change, add, or remove framework targets |
| **No package version changes** | All NuGet packages remain at their current versions |
| **Use conversion tool** | Do not manually rewrite project XML — use `convert_project_to_sdk_style` tool |
| **Use topological order** | Do not compute order manually — use `get_projects_in_topological_order` tool output |
| **Build per-project** | After each conversion, build the individual project (not the full solution) |
| **Stop on failure** | If a project cannot be fixed within constraints, mark as Blocked and stop |

### Automation Mode

The user has requested **automatic conversion** — proceed through all 17 projects without stopping between each one. Only pause execution if:
- A project fails to build after reasonable fixes
- A blocking dependency error prevents further progress
- File removal confirmation is needed for globbing conflicts

---

## Detailed Dependency Analysis

### Dependency Graph

```
Layer 0 (Leaf nodes — no dependencies):
  ├── ADDataTypes
  ├── ActiveDevelop.SqlTools
  ├── ADSundries
  └── ADNullableValueControls

Layer 1 (depends on Layer 0 only):
  ├── ADSqlSupportComponents  → ADDataTypes, ActiveDevelop.SqlTools
  ├── ADLicenceManager        → ADDataTypes
  ├── ADInfoItem              → ADDataTypes, ADNullableValueControls, ADSundries
  └── FacGeneric              → ADDataTypes

Layer 2 (depends on Layer 0–1):
  ├── Fac_Data                → FacGeneric
  ├── Fac_GenericControls     → ADDataTypes, ADSqlSupportComponents, FacGeneric
  └── Fac_EntityModel         → FacGeneric

Layer 3 (depends on Layer 0–2):
  └── ADSimplePrintDocument   → ADInfoItem, Fac_EntityModel

Layer 4 (depends on Layer 0–3):
  └── FacInterfaces           → ADDataTypes, ADInfoItem, ADLicenceManager,
                                 ADSimplePrintDocument, Fac_Data, Fac_GenericControls

Layer 5 (depends on Layer 0–4):
  ├── Fac_Functions           → FacInterfaces
  └── FacessoConfig           → FacInterfaces

Layer 6 (depends on Layer 0–5):
  └── ADSerialGenerator       → FacessoConfig

Layer 7 (depends on Layer 0–6):
  └── Facesso                 → ADSerialGenerator, Fac_EntityModel, Fac_Functions
```

### Conversion Order (Strict Topological)

The topological order below is the **mandatory** conversion sequence. Each project must build successfully before proceeding to the next.

| Order | Project | Project File | Layer | Dependencies |
|------:|---------|-------------|:-----:|--------------|
| 1 | ADDataTypes | `ADDataTypes\ADDataTypes.vbproj` | 0 | (none) |
| 2 | ActiveDevelop.SqlTools | `ActiveDevelop.SqlTools\ActiveDevelop.SqlTools.vbproj` | 0 | (none) |
| 3 | ADSundries | `ADSundries\ADSundries.vbproj` | 0 | (none) |
| 4 | ADNullableValueControls | `Controls\ADNullableValueControls.vbproj` | 0 | (none) |
| 5 | ADSqlSupportComponents | `ADSqlSupportComponents\ADSqlSupportComponents.vbproj` | 1 | ADDataTypes, ActiveDevelop.SqlTools |
| 6 | ADLicenceManager | `ADLicenceManager\ADLicenceManager.vbproj` | 1 | ADDataTypes |
| 7 | ADInfoItem | `ADInfoItem\ADInfoItem.vbproj` | 1 | ADDataTypes, ADNullableValueControls, ADSundries |
| 8 | FacGeneric | `FAC_Generic\FacGeneric.vbproj` | 1 | ADDataTypes |
| 9 | Fac_Data | `FacessoData\Fac_Data.vbproj` | 2 | FacGeneric |
| 10 | Fac_GenericControls | `FacGenericControls\Fac_GenericControls.vbproj` | 2 | ADDataTypes, ADSqlSupportComponents, FacGeneric |
| 11 | Fac_EntityModel | `Fac_EntityModel\Fac_EntityModel.vbproj` | 2 | FacGeneric |
| 12 | ADSimplePrintDocument | `ADSimplePrintDocument\ADSimplePrintDocument.csproj` | 3 | ADInfoItem, Fac_EntityModel |
| 13 | FacInterfaces | `FacInterfaces\FacInterfaces.vbproj` | 4 | ADDataTypes, ADInfoItem, ADLicenceManager, ADSimplePrintDocument, Fac_Data, Fac_GenericControls |
| 14 | Fac_Functions | `FacFunctions\Fac_Functions.vbproj` | 5 | FacInterfaces |
| 15 | FacessoConfig | `FacessoConfig\FacessoConfig.vbproj` | 5 | FacInterfaces |
| 16 | ADSerialGenerator | `FacessoSerialGenerator\ADSerialGenerator.vbproj` | 6 | FacessoConfig |
| 17 | Facesso | `Facesso\Facesso.vbproj` | 7 | ADSerialGenerator, Fac_EntityModel, Fac_Functions |

### Critical Path

The longest dependency chain is:
```
ADDataTypes → FacGeneric → Fac_EntityModel → ADSimplePrintDocument → FacInterfaces → FacessoConfig → ADSerialGenerator → Facesso
```
This 8-project chain defines the minimum sequential path. Any blocker in this chain halts all downstream conversions.

### Circular Dependencies
**None detected.** All projects form a clean directed acyclic graph (DAG).

---

## Pre-Conversion Prerequisites

### Step 0.1: Fix ADSerialGenerator Build Error (BC30469)

**File**: `src\VBNetFx\FacessoSerialGenerator\My Project\Settings.Designer.vb`  
**Line**: 34  
**Error**: `BC30469` — Reference to a non-shared member requires an object reference

**Current Code**:
```vb
Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
    If My.Application.SaveMySettingsOnExit Then
        My.Settings.Save()  ' ERROR: My.Settings is instance, called in Shared context
    End If
End Sub
```

**Required Fix**: Replace `My.Settings.Save()` with `My.MySettings.Default.Save()` or equivalent shared-safe accessor.

**Verification**: Build ADSerialGenerator project — expect 0 errors.

### Step 0.2: Fix FacInterfaces Build Error (BC30002 — Missing ReportViewer)

**File**: `src\VBNetFx\FacInterfaces\ImportFormsAndHelper\frmTimeLogResultTable.Designer.vb`  
**Lines**: 146, 152  
**Error**: `BC30002` — Type `Microsoft.Reporting.WinForms.ReportViewer` is not defined

**Root Cause**: The project references `Microsoft.ReportViewer.WinForms, Version=12.0.0.0` without a HintPath. The assembly is expected from the GAC but is not installed on the build machine.

**Required Fix**: Add the `Microsoft.ReportingServices.ReportViewerControl.WinForms` NuGet package to the FacInterfaces project, or add an explicit HintPath to a locally available copy of the assembly.

**Verification**: Build FacInterfaces project — expect 0 errors.

### Step 0.3: Verify Full Baseline Build

After fixing the above errors:
1. Run full solution build: `msbuild Facesso.sln`
2. Confirm **0 errors** across all 17 projects
3. Record baseline **warning count** for post-conversion comparison
4. Commit all pre-conversion fixes

### Step 0.4: Verify Clean Working Tree

Confirm `git status` shows no uncommitted changes after the prerequisite commits.

---

## Project Conversion Status

| Order | Project | Path | Status | Has packages.config | Notes |
|------:|---------|------|--------|:-------------------:|-------|
| 1 | ADDataTypes | `ADDataTypes\ADDataTypes.vbproj` | Pending | ❌ | Leaf node, no dependencies |
| 2 | ActiveDevelop.SqlTools | `ActiveDevelop.SqlTools\ActiveDevelop.SqlTools.vbproj` | Pending | ❌ | Leaf node, no dependencies |
| 3 | ADSundries | `ADSundries\ADSundries.vbproj` | Pending | ❌ | Leaf node, no dependencies |
| 4 | ADNullableValueControls | `Controls\ADNullableValueControls.vbproj` | Pending | ❌ | Leaf node, no dependencies |
| 5 | ADSqlSupportComponents | `ADSqlSupportComponents\ADSqlSupportComponents.vbproj` | Pending | ❌ | Depends on #1, #2 |
| 6 | ADLicenceManager | `ADLicenceManager\ADLicenceManager.vbproj` | Pending | ❌ | Depends on #1 |
| 7 | ADInfoItem | `ADInfoItem\ADInfoItem.vbproj` | Pending | ✅ | Depends on #1, #3, #4. Has NuGet packages |
| 8 | FacGeneric | `FAC_Generic\FacGeneric.vbproj` | Pending | ❌ | Depends on #1 |
| 9 | Fac_Data | `FacessoData\Fac_Data.vbproj` | Pending | ❌ | Depends on #8 |
| 10 | Fac_GenericControls | `FacGenericControls\Fac_GenericControls.vbproj` | Pending | ✅ | Depends on #1, #5, #8. Has NuGet packages |
| 11 | Fac_EntityModel | `Fac_EntityModel\Fac_EntityModel.vbproj` | Pending | ❌ | Depends on #8. Contains EF EDMX |
| 12 | ADSimplePrintDocument | `ADSimplePrintDocument\ADSimplePrintDocument.csproj` | Pending | ❌ | Only C# project. Depends on #7, #11 |
| 13 | FacInterfaces | `FacInterfaces\FacInterfaces.vbproj` | Pending | ❌ | High-risk: ReportViewer + DBML files. Depends on #1, #7, #6, #12, #9, #10 |
| 14 | Fac_Functions | `FacFunctions\Fac_Functions.vbproj` | Pending | ✅ | Depends on #13. Has NuGet packages |
| 15 | FacessoConfig | `FacessoConfig\FacessoConfig.vbproj` | Pending | ❌ | Depends on #13 |
| 16 | ADSerialGenerator | `FacessoSerialGenerator\ADSerialGenerator.vbproj` | Pending | ❌ | Depends on #15. Had pre-existing error |
| 17 | Facesso | `Facesso\Facesso.vbproj` | Pending | ✅ | Final project. Depends on #16, #11, #14. Has NuGet packages |

**Status Values**: Pending → In-Progress → Done | Blocked

---

## Project-by-Project Upgrade Plans

Each project follows the same conversion workflow:
1. Invoke `convert_project_to_sdk_style` tool
2. Build the individual project (not the full solution)
3. Fix any conversion-caused build errors
4. Check for ItemGroups with removed items (globbing conflicts)
5. Verify `packages.config` is removed (if applicable)
6. Commit changes

---

### Project 1: ADDataTypes
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADDataTypes\ADDataTypes.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: (none — leaf node)
- Dependants: ADSqlSupportComponents, ADLicenceManager, ADInfoItem, FacGeneric, Fac_GenericControls, FacInterfaces
- Source files: ADDBNullable.vb, ADFormularParser.vb, ADNumberSystems.vb, TimePeriodComparer.vb
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ADDataTypes to SDK-style"`

**Expected Issues**: None — simple leaf library with no NuGet dependencies.

---

### Project 2: ActiveDevelop.SqlTools
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ActiveDevelop.SqlTools\ActiveDevelop.SqlTools.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: (none — leaf node)
- Dependants: ADSqlSupportComponents
- Source files: DatabaseSchemaUpdateManager.vb
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ActiveDevelop.SqlTools to SDK-style"`

**Expected Issues**: None — single-file leaf library.

---

### Project 3: ADSundries
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADSundries\ADSundries.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: (none — leaf node)
- Dependants: ADInfoItem
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ADSundries to SDK-style"`

**Expected Issues**: None — simple leaf library.

---

### Project 4: ADNullableValueControls
**Full Path**: `Q:\git\Facesso\src\VBNetFx\Controls\ADNullableValueControls.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: (none — leaf node)
- Dependants: ADInfoItem
- Contains Windows Forms controls
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ADNullableValueControls to SDK-style"`

**Expected Issues**: Windows Forms references should be handled automatically by SDK-style format for net472.

---

### Project 5: ADSqlSupportComponents
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADSqlSupportComponents\ADSqlSupportComponents.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: ADDataTypes (#1), ActiveDevelop.SqlTools (#2)
- Dependants: Fac_GenericControls
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors (dependencies already converted)
3. No packages.config to remove
4. Commit: `"Convert ADSqlSupportComponents to SDK-style"`

**Expected Issues**: None — straightforward library with 2 project references.

---

### Project 6: ADLicenceManager
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADLicenceManager\ADLicenceManager.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: ADDataTypes (#1)
- Dependants: FacInterfaces
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ADLicenceManager to SDK-style"`

**Expected Issues**: None.

---

### Project 7: ADInfoItem
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADInfoItem\ADInfoItem.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, **has packages.config**
- Dependencies: ADDataTypes (#1), ADNullableValueControls (#4), ADSundries (#3)
- Dependants: ADSimplePrintDocument, FacInterfaces
- Has `app.config` with assembly binding redirects
- Complexity: **Medium**

**NuGet Packages (from packages.config)**:
| Package | Version | Notes |
|---------|---------|-------|
| Newtonsoft.Json | 13.0.4 | |
| System.Reactive | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Core | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Interfaces | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Linq | 6.1.0 | `requireReinstallation="true"` |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | |
| System.Threading.Tasks.Extensions | 4.6.3 | |

**Upgrade Steps**:
1. Run conversion tool (will migrate packages.config → PackageReference)
2. Build project — verify all package references resolve correctly
3. If missing packages, add them back at same versions
4. Verify `packages.config` is removed
5. Commit: `"Convert ADInfoItem to SDK-style"`

**Expected Issues**:
- ⚠️ Packages marked `requireReinstallation="true"` may need attention during package restore
- Monitor that all System.Reactive package references are correctly migrated

---

### Project 8: FacGeneric
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FAC_Generic\FacGeneric.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: ADDataTypes (#1)
- Dependants: Fac_Data, Fac_GenericControls, Fac_EntityModel
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert FacGeneric to SDK-style"`

**Expected Issues**: None.

---

### Project 9: Fac_Data
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacessoData\Fac_Data.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: FacGeneric (#8)
- Dependants: FacInterfaces
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert Fac_Data to SDK-style"`

**Expected Issues**: None.

---

### Project 10: Fac_GenericControls
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacGenericControls\Fac_GenericControls.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, **has packages.config**
- Dependencies: ADDataTypes (#1), ADSqlSupportComponents (#5), FacGeneric (#8)
- Dependants: FacInterfaces
- Contains Windows Forms controls
- Complexity: **Medium**

**NuGet Packages (from packages.config)**:
| Package | Version |
|---------|---------|
| MvvmForms | 2.1.7-Beta3 |
| MvvmFormsBase | 2.1.6-Beta |
| Newtonsoft.Json | 13.0.4 |
| System.Reactive | 6.1.0 |
| System.Reactive.Core | 6.1.0 |
| System.Reactive.Interfaces | 6.1.0 |
| System.Reactive.Linq | 6.1.0 |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 |
| System.Threading.Tasks.Extensions | 4.6.3 |

**Upgrade Steps**:
1. Run conversion tool (will migrate packages.config → PackageReference)
2. Build project — verify NuGet packages restore and resolve
3. If missing packages, add them back at same versions
4. Verify `packages.config` is removed
5. Commit: `"Convert Fac_GenericControls to SDK-style"`

**Expected Issues**:
- ⚠️ Beta packages (MvvmForms, MvvmFormsBase) — monitor package restore
- Windows Forms controls should be handled automatically

---

### Project 11: Fac_EntityModel
**Full Path**: `Q:\git\Facesso\src\VBNetFx\Fac_EntityModel\Fac_EntityModel.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: FacGeneric (#8)
- Dependants: ADSimplePrintDocument, Facesso
- Contains Entity Framework EDMX model (`FacessoModel`)
- Has `App.Config` with EF connection string
- Complexity: **Medium**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — verify EDMX code generation still works
3. No packages.config to remove
4. Commit: `"Convert Fac_EntityModel to SDK-style"`

**Expected Issues**:
- ⚠️ EDMX files require specific MSBuild targets — verify Entity Framework code generation is preserved after conversion
- App.Config with Entity Framework connection string should be preserved

---

### Project 12: ADSimplePrintDocument
**Full Path**: `Q:\git\Facesso\src\VBNetFx\ADSimplePrintDocument\ADSimplePrintDocument.csproj`  
**Language**: **C#** (only C# project in solution) | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: ADInfoItem (#7), Fac_EntityModel (#11)
- Dependants: FacInterfaces
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert ADSimplePrintDocument to SDK-style"`

**Expected Issues**: None — straightforward C# library.

---

### Project 13: FacInterfaces ⚠️ HIGH RISK
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacInterfaces\FacInterfaces.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages (but has GAC assembly reference)
- Dependencies: ADDataTypes (#1), ADInfoItem (#7), ADLicenceManager (#6), ADSimplePrintDocument (#12), Fac_Data (#9), Fac_GenericControls (#10)
- Dependants: Fac_Functions, FacessoConfig
- **⚠️ GAC Reference**: `Microsoft.ReportViewer.WinForms, Version=12.0.0.0` (no HintPath)
- Contains LINQ to SQL `.dbml` files (Kannegiesser, Facesso/Legatro)
- Has `app.config` with connection strings and logging config
- Contains Windows Forms controls (including ReportViewer)
- Multi-platform configurations (AnyCPU, x86, x64)
- Source control (SCC) properties embedded
- Complexity: **High**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect potential issues with:
   - ReportViewer assembly reference (must have been resolved in prerequisites)
   - LINQ to SQL DBML code generation
3. Verify DBML files still generate code correctly
4. No packages.config to remove
5. Commit: `"Convert FacInterfaces to SDK-style"`

**Expected Issues**:
- ⚠️ **ReportViewer reference**: Must be resolved in pre-requisites (Step 0.2). After SDK-style conversion, verify the reference is still correctly resolved
- ⚠️ **DBML files**: LINQ to SQL code generation may need MSBuild target verification
- ⚠️ **Multi-platform configs**: Debug/Release × AnyCPU/x86/x64 — verify all configurations are preserved or simplified correctly
- ⚠️ **SCC properties**: Source control markers will be removed (expected/desired)

---

### Project 14: Fac_Functions
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacFunctions\Fac_Functions.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, **has packages.config**
- Dependencies: FacInterfaces (#13)
- Dependants: Facesso
- Complexity: **Medium**

**NuGet Packages (from packages.config)**:
| Package | Version | Notes |
|---------|---------|-------|
| MvvmForms | 2.1.7-Beta3 | |
| MvvmFormsBase | 2.1.6-Beta | |
| Newtonsoft.Json | 13.0.4 | |
| System.Reactive | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Core | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Interfaces | 6.1.0 | `requireReinstallation="true"` |
| System.Reactive.Linq | 6.1.0 | `requireReinstallation="true"` |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | `requireReinstallation="true"` |
| System.Threading.Tasks.Extensions | 4.6.3 | `requireReinstallation="true"` |

**Upgrade Steps**:
1. Run conversion tool (will migrate packages.config → PackageReference)
2. Build project — verify NuGet packages resolve correctly
3. If missing packages, add them back at same versions
4. Verify `packages.config` is removed
5. Commit: `"Convert Fac_Functions to SDK-style"`

**Expected Issues**:
- ⚠️ All packages marked `requireReinstallation="true"` — monitor package restore carefully
- ⚠️ Beta packages (MvvmForms, MvvmFormsBase) — may have pre-release compatibility concerns

---

### Project 15: FacessoConfig
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacessoConfig\FacessoConfig.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: FacInterfaces (#13)
- Dependants: ADSerialGenerator
- Complexity: **Low**

**Upgrade Steps**:
1. Run conversion tool
2. Build project — expect 0 errors
3. No packages.config to remove
4. Commit: `"Convert FacessoConfig to SDK-style"`

**Expected Issues**: None.

---

### Project 16: ADSerialGenerator
**Full Path**: `Q:\git\Facesso\src\VBNetFx\FacessoSerialGenerator\ADSerialGenerator.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, no NuGet packages
- Dependencies: FacessoConfig (#15)
- Dependants: Facesso
- **⚠️ Had pre-existing build error** (BC30469 in Settings.Designer.vb — must be fixed in prerequisites)
- Complexity: **Medium** (due to pre-existing error requiring fix)

**Upgrade Steps**:
1. Run conversion tool
2. Build project — the Settings.Designer.vb error must have been resolved in prerequisites
3. No packages.config to remove
4. Commit: `"Convert ADSerialGenerator to SDK-style"`

**Expected Issues**:
- ⚠️ Verify the pre-existing Settings.Designer.vb fix (from Step 0.1) is still intact after conversion
- The conversion tool may regenerate or modify Settings files

---

### Project 17: Facesso
**Full Path**: `Q:\git\Facesso\src\VBNetFx\Facesso\Facesso.vbproj`  
**Language**: VB.NET | **Output**: Library | **Framework**: net472

**Current State**:
- Legacy format, **has packages.config**
- Dependencies: ADSerialGenerator (#16), Fac_EntityModel (#11), Fac_Functions (#14)
- Dependants: (none — top-level project)
- Final project in dependency chain
- Complexity: **Medium**

**NuGet Packages (from packages.config)**:
| Package | Version |
|---------|---------|
| MvvmForms | 2.1.7-Beta3 |
| MvvmFormsBase | 2.1.6-Beta |
| Newtonsoft.Json | 13.0.4 |
| System.Reactive | 6.1.0 |
| System.Reactive.Core | 6.1.0 |
| System.Reactive.Interfaces | 6.1.0 |
| System.Reactive.Linq | 6.1.0 |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 |
| System.Threading.Tasks.Extensions | 4.6.3 |

**Upgrade Steps**:
1. Run conversion tool (will migrate packages.config → PackageReference)
2. Build project — verify all packages resolve and all project references work
3. If missing packages, add them back at same versions
4. Verify `packages.config` is removed
5. Commit: `"Convert Facesso to SDK-style"`

**Expected Issues**:
- ⚠️ Beta packages (MvvmForms, MvvmFormsBase)
- As the top-level project, it aggregates all dependencies — good integration test point

---

## Risk Management

### High-Risk Changes

| Project | Risk Level | Description | Mitigation |
|---------|:----------:|-------------|------------|
| FacInterfaces (#13) | 🔴 High | GAC-based ReportViewer reference with no HintPath; LINQ to SQL DBML files; multi-platform configs | Resolve ReportViewer in prerequisites; verify DBML code gen post-conversion; test all platform configurations |
| ADSerialGenerator (#16) | 🟡 Medium | Pre-existing build error in Settings.Designer.vb | Fix in prerequisites; verify fix survives conversion |
| ADInfoItem (#7) | 🟡 Medium | `requireReinstallation` flag on System.Reactive packages | Monitor package restore; manually add packages back if needed |
| Fac_Functions (#14) | 🟡 Medium | All packages marked `requireReinstallation`; beta packages | Monitor package restore carefully |
| Fac_EntityModel (#11) | 🟡 Medium | Entity Framework EDMX model code generation | Verify EDMX targets preserved; test code gen |
| Fac_GenericControls (#10) | 🟡 Medium | Beta NuGet packages (MvvmForms) | Monitor restore; verify package compatibility |
| Facesso (#17) | 🟡 Medium | Top-level project aggregating all deps; beta packages | Build last; serves as integration verification |
| All others | 🟢 Low | Simple leaf libraries or single-dependency projects | Standard conversion workflow |

### Package Compatibility Risks

| Package | Version | Risk | Details |
|---------|---------|:----:|--------|
| MvvmForms | 2.1.7-Beta3 | 🟡 | Pre-release package — may have PackageReference compatibility issues |
| MvvmFormsBase | 2.1.6-Beta | 🟡 | Pre-release package — dependency of MvvmForms |
| System.Reactive.* | 6.1.0 | 🟡 | Marked `requireReinstallation` in some projects — targeted at net461 originally |
| Newtonsoft.Json | 13.0.4 | 🟢 | Well-supported, no known issues |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | 🟢 | Transitive dependency, widely compatible |
| System.Threading.Tasks.Extensions | 4.6.3 | 🟢 | Transitive dependency, widely compatible |

### Contingency Plans

| Scenario | Response |
|----------|----------|
| **Project fails to build after conversion** | Attempt minimal fixes within constraints. If unresolvable, mark as Blocked, stop further conversions, seek user guidance |
| **Package restore fails** | Manually add missing PackageReference entries at exact same versions. Do not upgrade versions |
| **EDMX/DBML code generation breaks** | Verify MSBuild targets are preserved. May need to manually add EF/LINQ targets to SDK-style project |
| **ReportViewer reference lost after conversion** | Re-add the assembly reference or NuGet package reference to the converted project file |
| **Globbing includes unwanted files** | Check for ItemGroups with removal labels. Ask user before deleting files |
| **Settings.Designer.vb regenerated** | Re-apply the prerequisite fix if the conversion tool overwrites the file |

---

## Complexity & Effort Assessment

### Per-Project Complexity

| Order | Project | Complexity | Dependencies | NuGet Packages | Special Concerns |
|------:|---------|:----------:|:------------:|:--------------:|------------------|
| 1 | ADDataTypes | Low | 0 | 0 | — |
| 2 | ActiveDevelop.SqlTools | Low | 0 | 0 | — |
| 3 | ADSundries | Low | 0 | 0 | — |
| 4 | ADNullableValueControls | Low | 0 | 0 | WinForms controls |
| 5 | ADSqlSupportComponents | Low | 2 | 0 | — |
| 6 | ADLicenceManager | Low | 1 | 0 | — |
| 7 | ADInfoItem | Medium | 3 | 7 | `requireReinstallation` packages |
| 8 | FacGeneric | Low | 1 | 0 | — |
| 9 | Fac_Data | Low | 1 | 0 | — |
| 10 | Fac_GenericControls | Medium | 3 | 9 | Beta NuGet packages, WinForms |
| 11 | Fac_EntityModel | Medium | 1 | 0 | EDMX model, EF connection string |
| 12 | ADSimplePrintDocument | Low | 2 | 0 | Only C# project |
| 13 | FacInterfaces | **High** | 6 | 0 | ReportViewer GAC ref, DBML files, multi-platform |
| 14 | Fac_Functions | Medium | 1 | 9 | All packages `requireReinstallation`, beta pkgs |
| 15 | FacessoConfig | Low | 1 | 0 | — |
| 16 | ADSerialGenerator | Medium | 1 | 0 | Pre-existing build error |
| 17 | Facesso | Medium | 3 | 9 | Top-level, beta packages, integration point |

### Phase Complexity Summary

| Phase | Description | Projects | Complexity |
|:-----:|-------------|:--------:|:----------:|
| 0 | Fix pre-existing build errors | 2 fixes | Medium |
| 1 | Convert all 17 projects (atomic) | 17 | Medium overall (1 High, 6 Medium, 10 Low) |
| 2 | Full solution verification | — | Low |

---

## Source Control Strategy

### Branching Strategy

- **Starting Branch**: `main`
- **Working Branch**: Create a new branch `upgrade/sdk-style-conversion` from `main` before starting work
- All conversion work happens on the working branch
- Merge back to `main` via pull request after all conversions complete

### Commit Strategy

**Atomic commits per project** — each successfully converted project gets its own commit for clean rollback capability.

| Commit # | Scope | Message Template |
|---------:|-------|------------------|
| 0 | Prerequisites | `"Fix pre-existing build errors before SDK-style conversion"` |
| 1–17 | Per-project | `"Convert <ProjectName> to SDK-style"` |
| 18 | Final | `"Verify full solution build after SDK-style conversion"` (if needed) |

### Review & Merge Process

1. Create pull request from `upgrade/sdk-style-conversion` → `main`
2. Review checklist:
   - [ ] All 17 projects show as Done in status table
   - [ ] Full solution builds with 0 errors
   - [ ] Warning count ≤ baseline
   - [ ] No TargetFramework changes
   - [ ] All `packages.config` files removed
   - [ ] No unintended file changes
3. Squash-merge or merge as-is (preserving per-project history)

---

## Success Criteria

### Technical Criteria

- [ ] All 17 projects converted from legacy to SDK-style format
- [ ] All 17 projects build successfully (individually)
- [ ] Full solution builds with 0 errors
- [ ] No `TargetFramework` values changed (all remain `net472`)
- [ ] All 4 `packages.config` files removed (migrated to `PackageReference`)
- [ ] No NuGet package versions changed
- [ ] Warning count ≤ baseline count
- [ ] All project outputs (DLLs) are correct

### Quality Criteria

- [ ] Minimal diff — only structural format changes, no functional code changes
- [ ] Redundant legacy metadata removed (SCC properties, old ToolsVersion, etc.)
- [ ] File globbing correctly includes all source files
- [ ] No orphaned files left behind

### Process Criteria

- [ ] Conversion followed strict topological dependency order
- [ ] Each project committed atomically after successful conversion
- [ ] Pre-existing build errors fixed and committed separately
- [ ] Status tracking table updated for each project
- [ ] Blockers documented with error details (if any)
- [ ] Plan followed All-At-Once strategy principles

### Completion Definition

The SDK-style conversion is **complete** when:
1. All projects in the status table show `Done` (or documented `Blocked` with justification)
2. The full solution builds with 0 errors
3. All changes are committed on the working branch
4. No `packages.config` files remain in converted projects
