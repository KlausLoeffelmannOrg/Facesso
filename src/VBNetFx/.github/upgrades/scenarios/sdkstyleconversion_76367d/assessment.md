# SDK-Style Conversion Assessment
**Facesso Solution - VBNetFx**

---

## Executive Summary

This assessment evaluates the **Facesso** solution for conversion from legacy (non-SDK-style) project format to modern SDK-style project format. The solution contains **17 class library projects** (16 VB.NET + 1 C#) all targeting **.NET Framework 4.7.2**. All projects use the legacy project format and require conversion.

### Key Findings

| Category | Status | Impact |
|----------|--------|--------|
| **Baseline Build** | ⚠️ **3 Pre-existing Errors** | **BLOCKER** - Must be resolved before conversion |
| **Project Format** | 🔴 All 17 projects are legacy format | Conversion required for all |
| **Package Management** | ✅ 4 projects use packages.config | Will migrate to PackageReference |
| **ASP.NET Web Apps** | ✅ None detected | No special handling required |
| **Test Projects** | ✅ None detected | No test-specific concerns |
| **Git Status** | ✅ Clean working tree | Ready for conversion |

### Pre-Conversion Blockers

**❌ CRITICAL**: The solution currently has **3 build errors** that must be fixed before SDK-style conversion can proceed:

1. **ADSerialGenerator** (BC30469): Reference to non-shared member requires object reference in `Settings.Designer.vb:34`
2. **FacInterfaces** (BC30002): Missing `Microsoft.Reporting.WinForms.ReportViewer` type definition (2 errors)
3. **Facesso** (BC2017): Cascading failure due to missing `FacInterfaces.dll`

**Per SDK conversion guidelines**: A successful baseline build is mandatory before conversion begins.

---

## Solution Overview

### Repository Structure

```
Q:\git\Facesso\
├── src/
│   ├── VBNetFx/          # Target solution
│   │   ├── Facesso.sln   # 17 projects
│   │   ├── ADDataTypes/
│   │   ├── ADInfoItem/
│   │   ├── ... (15 more projects)
│   ├── Database/FacessoDB/
│   └── HoloLens/Facesso.HoloLens.Mock/
└── .github/upgrades/scenarios/sdkstyleconversion_76367d/
```

**Solution Path**: `Q:\git\Facesso\src\VBNetFx\Facesso.sln`  
**Git Branch**: (detached HEAD or branch name not detected)  
**Last Commit**: `16172973` - "Update license statement in README.md"

### Project Inventory

| # | Project Name | Type | Output | Target Framework | SDK-Style | Packages.config |
|--:|--------------|------|--------|------------------|-----------|----------------|
| 1 | ADDataTypes | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 2 | ActiveDevelop.SqlTools | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 3 | ADSundries | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 4 | ADNullableValueControls | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 5 | ADSqlSupportComponents | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 6 | ADLicenceManager | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 7 | ADInfoItem | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ✅ |
| 8 | FacGeneric | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 9 | Fac_Data | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 10 | Fac_GenericControls | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ✅ |
| 11 | Fac_EntityModel | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 12 | ADSimplePrintDocument | C# | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 13 | FacInterfaces | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 14 | Fac_Functions | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ✅ |
| 15 | FacessoConfig | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 16 | ADSerialGenerator | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ❌ |
| 17 | Facesso | VB.NET | Library | .NET Framework 4.7.2 | ❌ | ✅ |

**Summary**: All 17 projects require SDK-style conversion. 4 projects have `packages.config` that will be migrated to `PackageReference` during conversion.

---

## Detailed Assessment

### 1. Project Dependencies (Topological Order)

The conversion **must** follow this dependency order to ensure each project builds successfully before its dependents are converted:

| Order | Project Path | Dependencies |
|------:|--------------|--------------|
| 1 | ADDataTypes | (none) |
| 2 | ActiveDevelop.SqlTools | (none) |
| 3 | ADSundries | (none) |
| 4 | ADNullableValueControls | (none) |
| 5 | ADSqlSupportComponents | ADDataTypes, ActiveDevelop.SqlTools |
| 6 | ADLicenceManager | ADDataTypes |
| 7 | ADInfoItem | ADDataTypes, ADNullableValueControls, ADSundries |
| 8 | FacGeneric | ADDataTypes |
| 9 | Fac_Data | FacGeneric |
| 10 | Fac_GenericControls | ADDataTypes, ADSqlSupportComponents, FacGeneric |
| 11 | Fac_EntityModel | FacGeneric |
| 12 | ADSimplePrintDocument | ADInfoItem, Fac_EntityModel |
| 13 | FacInterfaces | ADDataTypes, ADInfoItem, ADLicenceManager, ADSimplePrintDocument, Fac_Data, Fac_GenericControls |
| 14 | Fac_Functions | FacInterfaces |
| 15 | FacessoConfig | FacInterfaces |
| 16 | ADSerialGenerator | FacessoConfig |
| 17 | Facesso | ADSerialGenerator, Fac_EntityModel, Fac_Functions |

**⚠️ Note**: Projects **#13 (FacInterfaces)** and **#16 (ADSerialGenerator)** currently fail to build. They block downstream projects and must be fixed first.

### 2. NuGet Packages Analysis

**4 projects** use `packages.config` with the following packages:

#### ADInfoItem
- Newtonsoft.Json 13.0.4
- System.Reactive.* 6.1.0 (Core, Interfaces, Linq)
- System.Runtime.CompilerServices.Unsafe 6.1.2
- System.Threading.Tasks.Extensions 4.6.3

#### Facesso
- MvvmForms 2.1.7-Beta3
- MvvmFormsBase 2.1.6-Beta
- Newtonsoft.Json 13.0.4
- System.Reactive.* 6.1.0
- System.Runtime.CompilerServices.Unsafe 6.1.2
- System.Threading.Tasks.Extensions 4.6.3

#### Fac_Functions
- MvvmForms 2.1.7-Beta3
- MvvmFormsBase 2.1.6-Beta
- Newtonsoft.Json 13.0.4
- System.Reactive.* 6.1.0 (with `requireReinstallation="true"`)
- System.Runtime.CompilerServices.Unsafe 6.1.2
- System.Threading.Tasks.Extensions 4.6.3

#### Fac_GenericControls
- MvvmForms 2.1.7-Beta3
- MvvmFormsBase 2.1.6-Beta
- Newtonsoft.Json 13.0.4
- System.Reactive.* 6.1.0
- System.Runtime.CompilerServices.Unsafe 6.1.2
- System.Threading.Tasks.Extensions 4.6.3

**Conversion Impact**: The SDK-style conversion tool will automatically migrate these to `PackageReference` format. All version numbers will be preserved.

**⚠️ Some packages have `requireReinstallation="true"`** - This indicates the packages were targeting a different framework version and may need attention during conversion.

### 3. Pre-existing Build Errors (BLOCKER)

#### Error 1: ADSerialGenerator - BC30469
**File**: `FacessoSerialGenerator\My Project\Settings.Designer.vb:34`  
**Error**: Reference to a non-shared member requires an object reference

```vb
32: Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
33:     If My.Application.SaveMySettingsOnExit Then
34:         My.Settings.Save()  ' ❌ ERROR: My.Settings is not shared
35:     End If
36: End Sub
```

**Root Cause**: Attempting to call instance method `Save()` on `My.Settings` in a static context.

**Suggested Fix**: Use `Settings.Default.Save()` instead, or access via proper instance.

#### Error 2 & 3: FacInterfaces - BC30002 (Missing ReportViewer)
**File**: `FacInterfaces\ImportFormsAndHelper\frmTimeLogResultTable.Designer.vb:146,152`  
**Error**: Type `Microsoft.Reporting.WinForms.ReportViewer` is not defined

```vb
146: Friend WithEvents rvEmployeeTimeLogResult As Microsoft.Reporting.WinForms.ReportViewer  ' ❌ ERROR
152: Friend WithEvents rvWorksiteTimeLogResult As Microsoft.Reporting.WinForms.ReportViewer   ' ❌ ERROR
```

**Project Reference** (line 153 in `FacInterfaces.vbproj`):
```xml
<Reference Include="Microsoft.ReportViewer.WinForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91, processorArchitecture=MSIL" />
```

**Root Cause**: The ReportViewer assembly reference has no `HintPath`, suggesting it's expected from GAC (Global Assembly Cache) or a local installation. The assembly is not found at build time.

**Suggested Fixes**:
1. **Install via NuGet**: Add `Microsoft.ReportingServices.ReportViewerControl.WinForms` NuGet package (modern replacement)
2. **Install RDLC Runtime**: Install Microsoft Report Viewer 2012 Runtime (legacy approach)
3. **Add HintPath**: Locate the assembly and add explicit HintPath to the reference

**Recommendation**: Use NuGet package for better dependency management during SDK-style conversion.

#### Error 4: Facesso - BC2017 (Cascading)
**Error**: Could not find library `FacInterfaces.dll`

**Root Cause**: This is a cascading error because FacInterfaces failed to build (Error 2/3). Will auto-resolve once FacInterfaces builds successfully.

### 4. Legacy Project Format Characteristics

All 17 projects exhibit typical legacy format markers:

- ❌ No `Sdk` attribute on `<Project>` element
- ❌ Verbose, boilerplate-heavy XML structure
- ❌ Explicit `<Compile>`, `<Reference>`, and `<Import>` declarations
- ❌ Configuration-specific PropertyGroups (Debug/Release for AnyCPU, x86, x64)
- ❌ Redundant metadata (e.g., `RequiredTargetFramework`, old `ToolsVersion`)
- ❌ Source control properties (SCC) embedded in project files
- ❌ Legacy ClickOnce deployment properties (some projects)

**Example from FacInterfaces.vbproj**:
```xml
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ToolsVersion="12.0">
  <PropertyGroup>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <SccProjectName>SAK</SccProjectName>
    <FileUpgradeFlags></FileUpgradeFlags>
    <OldToolsVersion>3.5</OldToolsVersion>
    ...
```

**Post-Conversion**: SDK-style projects will dramatically reduce this boilerplate. File inclusions will use globbing patterns, and framework references will be implicit.

### 5. App.config Files

**2 projects** have `app.config` files with runtime settings:

#### ADInfoItem/app.config
- Standard assembly binding redirects for System.Reactive dependencies

#### FacInterfaces/app.config
- Connection strings for SQL Server databases (Legatro, Facesso, MISDB)
- Logging configuration (FileLogTraceListener)
- Startup runtime configuration

#### Fac_EntityModel/App.Config
- Entity Framework connection string (`FacessoEntities`)
- Logging configuration
- Startup runtime configuration

**Conversion Impact**: App.config files will be preserved as-is. SDK-style projects fully support app.config for .NET Framework targets.

### 6. Special Considerations

#### Windows Forms Controls
Several projects reference Windows Forms types:
- ADNullableValueControls
- Fac_GenericControls
- FacInterfaces (with ReportViewer controls)
- Facesso
- ADSerialGenerator

**SDK-Style Support**: .NET Framework 4.7.2 SDK-style projects fully support Windows Forms via implicit framework references.

#### Entity Framework & LINQ to SQL
- **Fac_EntityModel**: Uses Entity Framework (connection string in app.config)
- **FacInterfaces**: Contains LINQ to SQL `.dbml` files (Kannegiesser, Legatro/Facesso)

**Conversion Impact**: EDMX and DBML files are supported in SDK-style projects. Custom MSBuild targets may need verification.

#### Multi-Platform Configurations
Many projects define Debug/Release configurations for:
- AnyCPU
- x86
- x64

**SDK-Style Support**: SDK-style projects handle multi-platform builds more elegantly. Platform-specific properties can be simplified.

#### Beta/Pre-release NuGet Packages
- MvvmForms 2.1.7-Beta3
- MvvmFormsBase 2.1.6-Beta

**Risk**: Beta packages may have compatibility issues. Monitor package restore during conversion.

---

## Conversion Scope & Constraints

### In-Scope for SDK-Style Conversion

✅ Convert all 17 projects from legacy to SDK-style format  
✅ Migrate 4 `packages.config` to `PackageReference`  
✅ Remove redundant boilerplate XML  
✅ Simplify project file structure  
✅ Preserve all existing dependencies and versions  
✅ Maintain .NET Framework 4.7.2 target (no framework upgrade)  
✅ Verify each project builds after conversion  
✅ Remove `packages.config` files after successful migration  

### Out-of-Scope (Hard Constraints)

❌ **DO NOT** change, add, remove, or upgrade `TargetFramework` / `TargetFrameworks`  
❌ **DO NOT** introduce new package versions unrelated to conversion  
❌ **DO NOT** refactor code or fix unrelated bugs  
❌ **DO NOT** convert to .NET Core/.NET 6+/.NET 9  
❌ **DO NOT** manually rewrite project XML (use conversion tool)  

### Prerequisite Actions (REQUIRED)

Before starting conversion:

1. ✅ **Fix pre-existing build errors** (ADSerialGenerator, FacInterfaces)
2. ✅ **Verify clean baseline build** (all 17 projects build successfully)
3. ✅ **Ensure working tree is clean** (already confirmed)
4. ✅ **Document baseline warning count** (for comparison post-conversion)

---

## Risk Assessment

### High Risk ⚠️

| Risk | Impact | Mitigation |
|------|--------|------------|
| **Pre-existing build errors** | Conversion cannot start | **MUST FIX FIRST**: Resolve ADSerialGenerator and FacInterfaces errors |
| **Missing ReportViewer dependency** | FacInterfaces fails to build | Install NuGet package or RDLC Runtime before conversion |
| **Packages with `requireReinstallation`** | Package restore may fail | Monitor first conversion; may need manual package update |

### Medium Risk ⚙️

| Risk | Impact | Mitigation |
|------|--------|------------|
| **Beta NuGet packages** | MvvmForms packages may have issues | Test package restore; prepare to manually adjust if needed |
| **LINQ to SQL / EF dependencies** | Custom MSBuild targets may break | Verify EDMX/DBML code generation after conversion |
| **Multi-platform configurations** | Platform-specific logic may need adjustment | Test builds for x86/x64 after conversion |
| **Deeply nested dependencies** | Conversion order critical | Strictly follow topological order (#1-17) |

### Low Risk ✅

| Risk | Impact | Mitigation |
|------|--------|------------|
| **Windows Forms controls** | SDK-style handles this well | No special action required |
| **App.config files** | Fully supported in SDK-style | No changes needed |
| **Mixed VB.NET + C# projects** | Both supported equally | No special handling |

---

## Conversion Strategy

### Phase 1: Pre-Conversion (CRITICAL)

**Status**: ❌ BLOCKED - Must complete before proceeding

1. **Fix ADSerialGenerator.Settings issue** (BC30469)
   - Update `Settings.Designer.vb:34` to use proper Settings instance
   - Verify project builds

2. **Fix FacInterfaces.ReportViewer issue** (BC30002)
   - Option A: Install `Microsoft.ReportingServices.ReportViewerControl.WinForms` NuGet package
   - Option B: Install Microsoft Report Viewer 2012 Runtime
   - Option C: Add explicit HintPath to existing reference
   - Verify project builds

3. **Verify full solution build**
   - Run `dotnet build` or MSBuild on entire solution
   - Confirm 0 errors, document warning count
   - Create git checkpoint

### Phase 2: Conversion Execution

**Approach**: Incremental, dependency-ordered, atomic commits

For each project (in order 1-17):

1. **Convert**: Use SDK-style conversion tool (not manual XML edit)
2. **Build**: Build the converted project (NOT the full solution)
3. **Fix**: Address conversion-specific build errors
   - Check for ItemGroups with removed items (globbing conflicts)
   - Restore any missing packages
   - Adjust HintPaths if needed
4. **Verify**: Confirm `packages.config` removed (if applicable)
5. **Commit**: Atomic git commit per project (e.g., "Convert ADDataTypes to SDK-style")
6. **Repeat**: Move to next project in dependency order

**Stop Conditions**:
- If a project fails to build after reasonable fixes → Mark as BLOCKED → Stop further conversions → Seek user guidance
- If cascading failures occur → Revert last conversion → Investigate root cause

### Phase 3: Post-Conversion Verification

1. **Full solution build**: Verify all 17 projects build together
2. **Warning comparison**: Compare warning count vs. baseline
3. **Smoke test**: Run any available integration tests
4. **Git review**: Review all commits for unintended changes
5. **Documentation**: Update plan.md with final status

---

## Environment Information

### Development Environment

- **Solution Path**: `Q:\git\Facesso\src\VBNetFx\Facesso.sln`
- **Git Status**: Clean working tree (no uncommitted changes)
- **Current Commit**: `16172973` - "Update license statement in README.md"
- **.NET SDK Installed**: 
  - 9.0.203, 9.0.309, 9.0.311 (.NET 9)
  - 10.0.100-preview.7, 10.0.103, 10.0.200-preview.0 (.NET 10 preview)

**Note**: .NET 9+ SDKs are available but will NOT be used. Projects will remain on .NET Framework 4.7.2 throughout the conversion.

### Build Baseline (Pre-Conversion)

**Current Build Status**: ❌ **FAILED** (3 errors, 0 warnings)

| Metric | Value |
|--------|-------|
| **Total Projects** | 17 |
| **Succeeded** | 3 |
| **Failed** | 3 (ADSerialGenerator, FacInterfaces, Facesso) |
| **Up-to-date** | 11 |
| **Errors** | 3 |
| **Warnings** | 0 (in successful projects) |

**⚠️ Conversion cannot proceed until errors are resolved.**

---

## Success Criteria

The SDK-style conversion will be considered successful when:

✅ All 17 projects converted from legacy to SDK-style format  
✅ All projects build successfully (individually and as solution)  
✅ No `TargetFramework` values changed (remain .NET Framework 4.7.2)  
✅ All 4 `packages.config` files removed (migrated to PackageReference)  
✅ No package versions changed (except conversion-required adjustments)  
✅ Warning count remains same or lower than baseline  
✅ All changes committed atomically with clear commit messages  
✅ No blocking issues remain in plan.md tracking table  

---

## Recommendations

### Immediate Actions (Before Conversion)

1. **PRIORITY 1**: Fix `ADSerialGenerator` Settings error
   - File: `FacessoSerialGenerator\My Project\Settings.Designer.vb:34`
   - Change: `My.Settings.Save()` → `Settings.Default.Save()`

2. **PRIORITY 1**: Resolve `FacInterfaces` ReportViewer dependency
   - Recommended: Add NuGet package `Microsoft.ReportingServices.ReportViewerControl.WinForms`
   - Alternative: Install Report Viewer 2012 Runtime on build machine

3. **PRIORITY 2**: Verify full solution builds with 0 errors
   - Run full build
   - Document baseline warning count
   - Create git tag/checkpoint (e.g., `pre-sdk-conversion`)

### During Conversion

1. **Follow strict topological order** (projects 1-17 as listed)
2. **Build each project individually** after conversion (not full solution)
3. **Commit atomically** after each successful project conversion
4. **Stop immediately** if a project cannot be fixed within constraints
5. **Monitor for ItemGroup removals** and confirm with user before deleting files

### Post-Conversion

1. **Run full solution build** to verify integration
2. **Review all commits** for unintended changes
3. **Test application functionality** (smoke tests)
4. **Document any deviations** from expected outcomes
5. **Celebrate** 🎉 - SDK-style projects are a significant modernization step!

---

## Questions for User (To Be Answered Before Execution)

1. **Build Error Fixes**: Would you like me to attempt fixing the 3 pre-existing build errors, or would you prefer to fix them manually?

2. **ReportViewer Dependency**: For the missing `Microsoft.Reporting.WinForms` reference in FacInterfaces:
   - Option A: Install NuGet package `Microsoft.ReportingServices.ReportViewerControl.WinForms` (recommended)
   - Option B: Install Report Viewer 2012 Runtime locally
   - Option C: Provide HintPath to existing assembly
   - **Which option do you prefer?**

3. **Automated Conversion**: Would you like the SDK conversion to proceed automatically for all 17 projects without stopping between each one (only stopping if a blocker is encountered)?

4. **File Removals**: If the conversion tool identifies files that shouldn't be included due to globbing (ItemGroups with special labels), should I ask for confirmation before removing them, or proceed automatically?

5. **Baseline Documentation**: Do you want me to generate a detailed baseline build report (warnings, output sizes, etc.) before starting conversion?

---

## Appendix

### A. Project Dependency Graph

```
ADDataTypes (1) ──┐
                  ├──> ADSqlSupportComponents (5) ──┐
ActiveDevelop.SqlTools (2) ──┘                      │
                                                     ├──> Fac_GenericControls (10) ──┐
ADSundries (3) ──┐                                   │                                │
                 ├──> ADInfoItem (7) ──┐             │                                │
ADNullableValueControls (4) ──┘        ├─────────────┼────────────────────────────────┼──> FacInterfaces (13) ──┬──> Fac_Functions (14) ──┐
                                       │             │                                │                          │                          ├──> Facesso (17)
ADDataTypes (1) ──> ADLicenceManager (6) ──────────┼─────────────────────────────────┘                          └──> FacessoConfig (15) ──> ADSerialGenerator (16) ──┘
                                                     │
ADDataTypes (1) ──> FacGeneric (8) ──┬──> Fac_Data (9) ──────────────────────────────┘
                                     │
                                     └──> Fac_EntityModel (11) ──┬──> ADSimplePrintDocument (12) ──┘
                                                                   │
                                                                   └────────────────────────────────────────────────────────────────────────────────────────────────┘
```

### B. Tool Commands Reference

**Get topological order**:
```bash
get_projects_in_topological_order
```

**Convert single project**:
```bash
convert_project_to_sdk_style -solutionPath "Q:\git\Facesso\src\VBNetFx\Facesso.sln" -projectPath "<full-project-path>"
```

**Build single project**:
```bash
dotnet build "<full-project-path>"
```

**Build solution**:
```bash
dotnet build "Q:\git\Facesso\src\VBNetFx\Facesso.sln"
```

---

## Assessment Metadata

**Generated**: 2025-01-XX  
**Tool**: GitHub Copilot App Modernization Agent  
**Scenario**: SDK-Style Conversion  
**Version**: 1.0  
**Status**: ⚠️ **PENDING PRE-CONVERSION FIXES**

---

*End of Assessment*
