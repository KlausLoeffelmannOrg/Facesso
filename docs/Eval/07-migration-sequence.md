<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 07-migration-sequence
-->

# Facesso — Recommended Migration Sequence

## Strategy: Bottom-Up with Security-First Priority

The Facesso solution has a clean dependency DAG with no circular references. The optimal migration sequence follows the dependency graph from leaf nodes (infrastructure) up to the main application, with security fixes applied immediately as Phase 0.

---

## Migration Phases

### Phase 0 — Security Hotfix (Pre-Migration)

| Order | Project(s) | Action | Unblocks | Effort |
|-------|-----------|--------|----------|--------|
| 0.1 | FAC_Generic | Fix SQL injection in `LoginUserClasses.vb` — parameterize login query | All phases (removes critical risk) | 1 hour |
| 0.2 | FAC_Generic | Fix authentication logic bug (`myAuthenticated` always true) | All phases | 30 min |
| 0.3 | Fac_Functions | Parameterize ad-hoc queries in `Fac_FunctionsInternal.vb` | Phase 3+ | 2 hours |
| 0.4 | Facesso | Change ClickOnce URL from HTTP → HTTPS | Deployment security | 1 hour |

**Rationale:** These fixes are independent of the migration and should be applied to the current codebase immediately.

---

### Phase 1 — Test Infrastructure (Foundation)

| Order | Project(s) | Action | Unblocks | Effort |
|-------|-----------|--------|----------|--------|
| 1.1 | (New) Facesso.Tests | Create xUnit test project targeting .NET Framework 4.7.2 | All subsequent phases | 2 days |
| 1.2 | (New) Facesso.Tests | Write integration tests for KPI calculations (TimeLog→ProductionData trigger chain) | Phase 4 (DB migration) | 5 days |
| 1.3 | (New) Facesso.Tests | Write integration tests for SPAccess CRUD operations | Phase 4 (data layer migration) | 3 days |
| 1.4 | (New) Facesso.Tests | Write unit tests for ADCryptedPassword, FacessoLicenseManager | Phase 3 (security upgrade) | 1 day |

**Rationale:** Zero test coverage makes any refactoring dangerous. Integration tests for KPI calculations are the highest priority because trigger behavior must be preserved exactly during migration.

---

### Phase 2 — SDK-Style Project Conversion & Framework Retarget

Migrate infrastructure libraries first (fewest dependencies), then work upward.

| Order | Project(s) | Rationale | Unblocks | Effort |
|-------|-----------|-----------|----------|--------|
| 2.1 | ADDataTypes | Leaf node — no project dependencies; core types used everywhere | ADInfoItem, ADSundries, all upstream | 1 day |
| 2.2 | ADSundries | Leaf node — depends only on System.Management (add NuGet) | ADLicenceManager, FAC_Generic, ADSqlSupport, all upstream | 1 day |
| 2.3 | ADInfoItem | Depends on ADDataTypes (already migrated); verify/remove WPF flag | Fac_Data, FacGenericControls | 0.5 day |
| 2.4 | ADLicenceManager | Depends on ADSundries (already migrated) | FAC_Generic | 0.5 day |
| 2.5 | ADSimplePrintDocument | Already C# — easiest conversion; System.Drawing.Common NuGet | Fac_Functions | 0.5 day |
| 2.6 | ActiveDevelop.SqlTools | Depends on ADSundries; straightforward ADO.NET | Fac_Data, ADSqlSupportComponents | 0.5 day |
| 2.7 | ADSqlSupportComponents | Depends on ADSundries, ActiveDevelop.SqlTools; WinForms controls | FAC_Generic, Fac_Data | 1 day |
| 2.8 | ADNullableValueControls | Complex WinForms control library (58KB template); high-risk conversion | Fac_GenericControls, Fac_Functions | 3 days |
| 2.9 | FAC_Generic | Central hub — depends on multiple infrastructure libs | Everything upstream | 2 days |
| 2.10 | Fac_Data | Data access layer — depends on ADInfoItem, ADSqlSupport, FAC_Generic | Fac_Functions, Fac_GenericControls, FacInterfaces | 2 days |
| 2.11 | Fac_EntityModel | EF6 EDMX → evaluate: keep EF6 or drop in favor of EF Core later | Fac_Functions | 1 day |
| 2.12 | FacInterfaces | Import adapters — depends on Fac_Data, FAC_Generic | Facesso main | 2 days |
| 2.13 | Fac_GenericControls | Application UI controls — depends on Fac_Data, FAC_Generic | Fac_Functions | 1 day |
| 2.14 | Fac_Functions | Largest library (~82 files) — depends on most other projects | Facesso main | 3 days |
| 2.15 | Facesso (main) | Final: retarget main application exe | Complete framework migration | 2 days |
| 2.16 | FacessoConfig | Configuration utility | Independent deployment | 1 day |
| 2.17 | ADSerialGenerator | License tool | Independent deployment | 0.5 day |

**Total Phase 2 Effort: ~22 days**

**Key Actions Per Project:**
1. Convert `.vbproj` from legacy format to SDK-style
2. Replace `packages.config` with `<PackageReference>`
3. Set `<TargetFramework>net8.0-windows</TargetFramework>`
4. Add `<UseWindowsForms>true</UseWindowsForms>` where needed
5. Replace `System.Data.SqlClient` → `Microsoft.Data.SqlClient`
6. Add `System.Management` NuGet where WMI is used
7. Add `System.Drawing.Common` NuGet where needed
8. Build, fix compilation errors, run tests

---

### Phase 3 — Core Modernization

| Order | Project(s) | Action | Unblocks | Effort |
|-------|-----------|--------|----------|--------|
| 3.1 | ADSundries | Upgrade ADCryptedPassword: SHA1 → PBKDF2 with backward-compatible read | Security improvement | 2 days |
| 3.2 | FAC_Generic | Replace Registry-based configuration with `IConfiguration` / `appsettings.json` | Modern config pattern | 3 days |
| 3.3 | FAC_Generic | Introduce DI container (Microsoft.Extensions.DependencyInjection) — extract `FacessoGeneric` module into injectable services | Testability, modularity | 5 days |
| 3.4 | ADDataTypes | Replace `ADDBNullable(Of T)` with `Nullable(Of T)` where possible | Simplification | 3 days |
| 3.5 | All projects | Add structured logging (Serilog or Microsoft.Extensions.Logging) | Observability | 2 days |

---

### Phase 4 — Data Layer Modernization

| Order | Project(s) | Action | Unblocks | Effort |
|-------|-----------|--------|----------|--------|
| 4.1 | Fac_Data | Migrate simple CRUD SPs (28 master data SPs) to EF Core repositories | Reduced SP count | 5 days |
| 4.2 | Fac_Data | Migrate validation/lookup SPs (14 SPs) to LINQ queries | Reduced SP count | 2 days |
| 4.3 | Fac_Data | Migrate analytics SPs to application-layer query services | Reporting independence | 5 days |
| 4.4 | Fac_Data | Migrate TimeLog + ProductionData SPs (20 SPs) to services | Core business logic | 10 days |
| 4.5 | Database | Evaluate trigger migration: move KPI calculations to domain events | Full application-layer control | 10 days |
| 4.6 | FacInterfaces | Replace LINQ-to-SQL (.dbml) with EF Core or Dapper | .NET 8+ compatibility | 3 days |

---

### Phase 5 — UI & Deployment Modernization

| Order | Project(s) | Action | Unblocks | Effort |
|-------|-----------|--------|----------|--------|
| 5.1 | All | Convert remaining VB.NET to C# (optional — tooling-assisted) | Language standardization | 10–15 days |
| 5.2 | Facesso | Evaluate UI modernization: keep WinForms or migrate selected modules to Blazor/MAUI | Future UI roadmap | 2 days (evaluation) |
| 5.3 | Deployment | Replace .vdproj with MSIX or WiX | Modern installer | 3 days |
| 5.4 | CI/CD | Set up GitHub Actions: build → test → package → publish | Automated quality gates | 2 days |
| 5.5 | All | Internationalization: extract hardcoded German strings to resource files | Multi-language support | 5 days |

---

## Dependency-Driven Migration Order (Visual)

```
Phase 2 Migration Sequence (following dependency graph):

Layer 0 (Leaves):     ADDataTypes ─── ADSundries ─── ADSimplePrintDocument
                          │               │
Layer 1:              ADInfoItem    ADLicenceManager    ActiveDev.SqlTools
                          │               │                    │
Layer 2:                  └───────── ADSqlSupportComponents ───┘
                                         │
Layer 3:              ADNullableValueControls    FAC_Generic
                               │                     │
Layer 4:                  Fac_Data ──── Fac_EntityModel
                               │
Layer 5:          FacInterfaces ── Fac_GenericControls
                               │         │
Layer 6:                  Fac_Functions ──┘
                               │
Layer 7 (Root):    Facesso ── FacessoConfig ── ADSerialGenerator
```

---

## Effort Summary

| Phase | Description | Effort (days) | Effort (%) |
|-------|-------------|---------------|-----------|
| Phase 0 | Security Hotfix | 1 | 1% |
| Phase 1 | Test Infrastructure | 11 | 10% |
| Phase 2 | SDK + Framework Retarget | 22 | 20% |
| Phase 3 | Core Modernization | 15 | 14% |
| Phase 4 | Data Layer Modernization | 35 | 33% |
| Phase 5 | UI & Deployment | 22–27 | 22% |
| **Total** | | **106–111 days** | **100%** |

With 2 FTEs working in parallel (infrastructure + business logic tracks): **~11–14 months elapsed time** accounting for testing, review, and stabilization.

---

## Quick Wins

These projects can be migrated with minimal risk and provide early confidence:

1. **ADSimplePrintDocument** — Already C#, simple printing abstraction, no complex dependencies
2. **ADDataTypes** — Pure types and enums, leaf node, no WinForms dependency
3. **ActiveDevelop.SqlTools** — Small utility library, straightforward ADO.NET
4. **ADInfoItem** — Simple base class, minimal code
