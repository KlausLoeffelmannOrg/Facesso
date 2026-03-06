<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 04-database-logic-map
-->

# Facesso — Database Logic Migration Map

## Overview

Facesso's SQL Server database contains **80 stored procedures**, **9 scalar functions**, and **4 triggers** implementing core business logic. The trigger cascade system is architecturally significant — it automatically recalculates KPIs (Zeitgrad/Degree of Time, wage allocation) whenever time or production data changes.

**Estimated migration effort for database logic: 35–45% of total migration.**

---

## Triggers (4 total)

| DB Object | Type | Table | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|-------|------------|-----------------|----------|--------|
| `OnTimeLog_InsertUpdate` | AFTER INSERT, UPDATE | TimeLog | **Critical** | Domain service: `TimeLogCalculationService.RecalculateOnChange()` | Move to application layer; fire on SaveChanges; must preserve atomicity | Very High |
| `OnTimeLog_Delete` | AFTER DELETE | TimeLog | **High** | Domain service: `TimeLogCalculationService.RecalculateOnDelete()` | Move to application layer; update ProductionData sums on deletion | High |
| `OnProductionData_InsertUpdate` | AFTER INSERT, UPDATE | ProductionData | **Critical** | Domain service: `ProductionDataCalculationService.SyncWithTimeLog()` | Move to application layer; synchronize SOLL↔IST; recalculate DegreeOfTime | Very High |
| `OnProductionDataItems_*` | AFTER INSERT, UPDATE | ProductionDataItems | **High** | Domain service: `ProductionDataCalculationService.RecalculateItems()` | Aggregate item-level data into ProductionData totals | High |

### Trigger Cascade Chain

```
ProductionDataItems INSERT/UPDATE
    └─► ProductionData recalculation (TotalReferenceIWT)
         └─► TimeLog recalculation (DegreeOfTime, ReferenceWageTimeProRata)

TimeLog INSERT/UPDATE/DELETE
    └─► ProductionData recalculation (TotalEffectiveIWT, TotalEffectiveIWTAdj)
         └─► DegreeOfTime = TotalReferenceIWT / TotalEffectiveIWT × 100%
         └─► DegreeOfTimeAdj = TotalReferenceIWT / TotalEffectiveIWTAdj × 100%
```

### Migration Strategy for Triggers

**Recommended: Domain Event Pattern**

1. Replace triggers with domain events fired from EF Core `SaveChanges` override or Dapper post-commit hooks
2. Implement calculation logic in dedicated service classes
3. Ensure atomicity — calculations must complete within the same transaction
4. Sentinel values (-1 = no data, -2 = invalid) must be preserved or replaced with proper nullability
5. **Integration test coverage is mandatory** before removing any trigger

---

## Scalar Functions (9 total)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `WorkGroupInternal` | Scalar Function | ID Mapping | Low | Inline lookup / navigation property | Replace with EF Core relationship or dictionary cache | Low |
| `EmployeeInternal` | Scalar Function | ID Mapping | Low | Inline lookup / navigation property | Replace with EF Core relationship or dictionary cache | Low |
| `GetLabourValueInternal` | Scalar Function | ID Mapping | Low | Inline lookup / navigation property | Replace with EF Core relationship or dictionary cache | Low |
| `CalculateReferenceWageTimeProRata` | Scalar Function | KPI Calculation | Medium | `KpiCalculator.ReferenceWageTimeProRata()` | Pure function; move to C# static method | Low |
| `DegreeOfTimeAbsolute` | Scalar Function | KPI Calculation | Medium | `KpiCalculator.DegreeOfTimeAbsolute()` | Pure function; move to C# static method | Low |
| `GetIDWageGroup` | Scalar Function | Lookup | Low | Repository method / navigation property | Replace with EF Core query | Low |
| `GetIDBonusLists` | Scalar Function | Lookup | Low | Repository method | Replace with LINQ query | Low |
| `HasProductionData` | Scalar Function | Existence Check | Low | Repository method: `Exists()` | Replace with `AnyAsync()` in EF Core | Low |
| `AnalysisShiftAtDay` | Scalar Function | Analysis | High | `AnalysisService.GetShiftMetrics()` | Complex multi-column result; refactor to view model + service | Medium |

---

## Stored Procedures (80 total)

### Initialization & Schema (3)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `InitializeDatabase` | SP | Setup | Medium | EF Core Migrations + Seed method | Replace with code-first migration | Medium |
| `IsDatabaseSetup` | SP | Setup | Low | `DbContext.Database.CanConnect()` + seed check | Replace with EF Core health check | Low |
| `RecalculateTimeLogAndProductionData` | SP | Maintenance | High | `RecalculationService.FullRecalculate()` | Batch operation; keep as SP initially, migrate later | Medium |

### Employee Management (7)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `Employees_Add` | SP | CRUD | Medium | `EmployeeRepository.AddAsync()` | Map to EF Core entity insert | Low |
| `Employees_Edit` | SP | CRUD | Medium | `EmployeeRepository.UpdateAsync()` | Map to EF Core entity update | Low |
| `Employees_Delete` | SP | CRUD | Low | `EmployeeRepository.DeleteAsync()` | Soft-delete (IsCurrent=false) | Low |
| `Employees_IsInUse` | SP | Validation | Low | `EmployeeRepository.IsInUseAsync()` | LINQ Any() query across related tables | Low |
| `Employees_DoesPersonnelNumberExist` | SP | Validation | Low | `EmployeeRepository.PersonnelNumberExistsAsync()` | LINQ Any() query | Low |
| `Employees_DoesMatchcodeExist` | SP | Validation | Low | `EmployeeRepository.MatchcodeExistsAsync()` | LINQ Any() query | Low |
| `Employees_GetInWorkGroupOnShiftDate` | SP | Query | Medium | `EmployeeRepository.GetByWorkGroupAndShift()` | LINQ join query | Medium |
| `Employees_LookUpWageData` | SP | Query | Medium | `WageService.LookupForEmployee()` | Service method with LINQ | Medium |

### Work Group Management (8)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `WorkGroups_Add` | SP | CRUD | Medium | `WorkGroupRepository.AddAsync()` | EF Core insert | Low |
| `WorkGroups_Edit` | SP | CRUD | Medium | `WorkGroupRepository.UpdateAsync()` | EF Core update | Low |
| `WorkGroups_Delete` | SP | CRUD | Low | `WorkGroupRepository.DeleteAsync()` | Soft-delete | Low |
| `WorkGroups_IsInUse` | SP | Validation | Low | `WorkGroupRepository.IsInUseAsync()` | LINQ Any() | Low |
| `WorkGroups_DoesWorkGroupNumberExist` | SP | Validation | Low | Repository validation | LINQ Any() | Low |
| `WorkGroups_DoesWorkGroupNameExist` | SP | Validation | Low | Repository validation | LINQ Any() | Low |
| `WorkGroups_GetItems` | SP | Query | Medium | `WorkGroupRepository.GetItemsAsync()` | LINQ query | Low |
| `WorkGroups_AddAssignmentRecord` | SP | CRUD | Medium | `WorkGroupAssignmentRepository.AddAsync()` | EF Core insert | Low |
| `WorkGroups_DeleteAssignment` | SP | CRUD | Low | `WorkGroupAssignmentRepository.DeleteAsync()` | EF Core delete | Low |
| `WorkGroups_GetAssignedLabourValues` | SP | Query | Medium | `WorkGroupRepository.GetAssignedLabourValuesAsync()` | LINQ join | Medium |

### Time Log — Core KPI Logic (8)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `TimeLog_HandleAddEdit` | SP | CRUD + Calc | **High** | `TimeLogService.HandleAddEditAsync()` | Complex: validates, inserts/updates, triggers KPI cascade | High |
| `TimeLog_AddItemsForAddEdit` | SP | CRUD | Medium | `TimeLogService.AddItemsAsync()` | Batch insert with validation | Medium |
| `TimeLog_GetLogItemsForShiftDate` | SP | Query | Medium | `TimeLogRepository.GetByShiftDateAsync()` | LINQ query with filtering | Low |
| `TimeLog_GetLogItemsForRange` | SP | Query | Medium | `TimeLogRepository.GetByRangeAsync()` | LINQ query with date range | Low |
| `TimeLog_GetOverlappingLogItems` | SP | Validation | **High** | `TimeLogService.GetOverlapsAsync()` | Complex temporal overlap detection | High |
| `TimeLog_DeleteItem` | SP | CRUD + Calc | Medium | `TimeLogService.DeleteAsync()` | Delete + trigger KPI recalculation | Medium |
| `TimeLog_UpdateValuesForShiftDate` | SP | Calculation | **High** | `TimeLogCalculationService.UpdateForShiftDate()` | Core KPI update logic; must match trigger behavior | Very High |
| `TimeLog_Analysis_GetEmployeeResult` | SP | Analytics | **High** | `AnalyticsService.GetEmployeeResultAsync()` | Complex aggregation query | High |

### Production Data — SOLL/IST Sync (12)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `ProductionData_AddEdit` | SP | CRUD | Medium | `ProductionDataRepository.AddEditAsync()` | EF Core upsert | Medium |
| `ProductionData_HandleAddEdit` | SP | CRUD + Calc | **High** | `ProductionDataService.HandleAddEditAsync()` | Complex: validates, upserts, triggers recalculation | High |
| `ProductionData_AddItemsForAddEdit` | SP | CRUD | Medium | `ProductionDataService.AddItemsAsync()` | Batch insert | Medium |
| `ProductionData_GetProductionData` | SP | Query | Medium | `ProductionDataRepository.GetAsync()` | LINQ query | Low |
| `ProductionData_GetProductionOrTemplateItems` | SP | Query | Medium | `ProductionDataRepository.GetItemsOrTemplateAsync()` | Conditional query (existing or template) | Medium |
| `ProductionData_DoProductionDataExist` | SP | Validation | Low | `ProductionDataRepository.ExistsAsync()` | LINQ Any() | Low |
| `ProductionDataItems_Add` | SP | CRUD | Low | `ProductionDataItemRepository.AddAsync()` | EF Core insert | Low |
| `ProductionData_Analysis_GetShiftDateResultSet` | SP | Analytics | **High** | `AnalyticsService.GetShiftDateResultsAsync()` | Complex aggregation with joins | High |
| `ProductionData_Analysis_GetResultSet` | SP | Analytics | **High** | `AnalyticsService.GetResultSetAsync()` | Complex aggregation | High |
| `ProductionData_Analysis_GetPeriodResultSet` | SP | Analytics | **High** | `AnalyticsService.GetPeriodResultsAsync()` | Period aggregation with multiple joins | High |
| `ProductionData_Analysis_AddProductionDateItem` | SP | CRUD | Low | `AnalyticsService.AddDateItemAsync()` | Simple insert | Low |
| `ProductionData_Analysis_DeleteProductionDateItems` | SP | CRUD | Low | `AnalyticsService.DeleteDateItemsAsync()` | Simple delete | Low |

### Master Data CRUD (28)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `LabourValues_Add/Edit/Delete/IsInUse/DoesNumberExist` | SP ×5 | CRUD + Validation | Low | `LabourValueRepository.*` | Standard EF Core CRUD | Low |
| `CostCenters_Add/Edit/Delete/IsInUse/DoesNumberExist/GetBaseCostCenterID` | SP ×6 | CRUD + Validation | Low | `CostCenterRepository.*` | Standard EF Core CRUD | Low |
| `BonusList_AddEntry/CreateBaseList/DeleteList/FromBaseCostCenter/ReplaceEntry` | SP ×5 | CRUD | Medium | `BonusListRepository.*` | EF Core CRUD + service logic | Medium |
| `Users_Add/Edit/DoesUsernameExist` | SP ×3 | CRUD + Validation | Low | `UserRepository.*` | EF Core CRUD | Low |
| `WageGroups_Add/Edit/DoesTokenExist` | SP ×3 | CRUD + Validation | Low | `WageGroupRepository.*` | EF Core CRUD | Low |
| `AddressDetails_Add/Edit` | SP ×2 | CRUD | Low | `AddressRepository.*` | EF Core CRUD | Low |
| `Subsidiaries_Add/Edit/Delete/DoesNameExist` | SP ×4 | CRUD + Validation | Low | `SubsidiaryRepository.*` | EF Core CRUD | Low |

### Settings & Utilities (8)

| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
| `ApplicationSettings_Get` | SP | Settings | Low | `IOptions<T>` / `IConfiguration` | Replace with modern .NET configuration | Low |
| `ApplicationSettings_Set` | SP | Settings | Low | `IOptions<T>` / `IConfiguration` | Replace with modern .NET configuration | Low |
| `BaseData_DoEmployeesExist` | SP | Validation | Low | Repository.AnyAsync() | LINQ Any() | Low |
| `BaseData_DoWorkGroupsExist` | SP | Validation | Low | Repository.AnyAsync() | LINQ Any() | Low |
| `BaseData_DoLabourValuesExist` | SP | Validation | Low | Repository.AnyAsync() | LINQ Any() | Low |
| `AddToFunctionLog` | SP | Audit | Low | `ILogger` + audit middleware | Replace with structured logging | Low |
| `DeleteDataForOleDbImport` | SP | Import | Medium | `ImportService.ClearImportData()` | Batch delete with transaction | Low |
| `SafelyTruncateAllTables` | SP | Maintenance | Medium | `MaintenanceService.TruncateAll()` | Admin tool; keep as raw SQL or migration | Low |
| `NotificationRecipients_AddEdit/DoesEmailExist` | SP ×2 | CRUD | Low | `NotificationRepository.*` | EF Core CRUD | Low |

---

## Migration Effort Summary

| Category | SP Count | Function Count | Trigger Count | Overall Effort |
|----------|----------|---------------|---------------|----------------|
| **KPI Calculations (Triggers + TimeLog + ProductionData)** | 20 | 3 | 4 | **Very High** — core business logic |
| **Master Data CRUD** | 28 | 0 | 0 | **Low** — straightforward EF Core mapping |
| **Analytics / Reporting** | 8 | 1 | 0 | **High** — complex aggregation queries |
| **Settings / Utilities** | 10 | 0 | 0 | **Low** — replace with .NET patterns |
| **Validation / Lookups** | 14 | 5 | 0 | **Low** — simple LINQ replacements |
| **Total** | **80** | **9** | **4** | |

## Recommended Migration Order for Database Logic

1. **Keep initially:** All triggers and KPI-related SPs — migrate last, after comprehensive integration tests exist
2. **Migrate first:** Simple CRUD SPs → EF Core repositories
3. **Migrate second:** Validation/lookup SPs → LINQ queries
4. **Migrate third:** Analytics SPs → application-layer query services
5. **Migrate last:** Trigger logic → domain event handlers (requires highest test confidence)
