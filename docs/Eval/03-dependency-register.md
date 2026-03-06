<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 03-dependency-register
-->

# Facesso — Third-Party Dependency Risk Register

## External NuGet Packages

| Dependency | Version | Category | Maintained? | .NET 8+? | Replacement | Effort | Risk |
|------------|---------|----------|-------------|----------|-------------|--------|------|
| Newtonsoft.Json | 13.0.4 | Serialization | ✅ Active | ✅ Yes | System.Text.Json (built-in) or keep Newtonsoft | Low | Low |
| System.Reactive | 6.1.0 | Reactive / Async | ✅ Active | ✅ Yes | None needed (fully compatible) | None | Low |
| System.Reactive.Core | 6.1.0 | Reactive / Async | ✅ Active | ✅ Yes | Merged into System.Reactive on .NET 8+ | None | Low |
| System.Reactive.Interfaces | 6.1.0 | Reactive / Async | ✅ Active | ✅ Yes | Merged into System.Reactive on .NET 8+ | None | Low |
| System.Reactive.Linq | 6.1.0 | Reactive / Async | ✅ Active | ✅ Yes | Merged into System.Reactive on .NET 8+ | None | Low |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | Runtime | ✅ Active | ✅ Built-in | Built into .NET 8+ runtime | None | Low |
| System.Threading.Tasks.Extensions | 4.6.3 | Runtime | ✅ Active | ✅ Built-in | Built into .NET 8+ runtime | None | Low |
| System.Resources.Extensions | 4.6.0 | Resources | ✅ Active | ✅ Yes | Compatible on .NET 8+ | None | Low |
| MvvmForms | 2.1.7-Beta3 | UI / MVVM | ⚠️ Niche/Beta | ❓ Unknown | CommunityToolkit.Mvvm or manual MVVM | Medium | Medium |
| MvvmFormsBase | 2.1.6-Beta | UI / MVVM | ⚠️ Niche/Beta | ❓ Unknown | CommunityToolkit.Mvvm or manual MVVM | Medium | Medium |
| EntityFramework (EF6) | 6.x (EDMX) | ORM | ⚠️ Maintenance-only | ⚠️ EF6 on .NET 8 limited | EF Core 8+ | High | Medium |

## In-House Libraries (ActiveDevelop.*)

These are all part of the Facesso solution and will migrate together. Risk is based on their internal complexity and .NET 8+ readiness.

| Library | Category | LOC Estimate | .NET 8+ Readiness | Migration Notes | Effort | Risk |
|---------|----------|-------------|-------------------|-----------------|--------|------|
| ADDataTypes | Data Types | ~2K | Medium | ADDBNullable(Of T) can be replaced by .NET Nullable(Of T); ADFormularParser needs review | Medium | Low |
| ADInfoItem | Entity Base | ~1K | High | Simple base class; WPF flag in .vbproj needs removal if unused | Low | Low |
| ADLicenceManager | Licensing | ~2K | Medium | Registry-dependent; WMI queries (System.Management) need NuGet package on .NET 8+ | Medium | Medium |
| ADSimplePrintDocument | Printing | ~1K | High | C# project; System.Drawing.Common needs NuGet on .NET 8+; Windows-only | Low | Low |
| ADSqlSupportComponents | DB Tooling | ~3K | Medium | UI components for SQL Server connection; needs WinForms on .NET 8+ | Low | Low |
| ADSundries | Utilities | ~3K | Medium | ADCryptedPassword (SHA1), ADComputerInfo (WMI), ADWizardController | Medium | Medium |
| ADNullableValueControls | UI Controls | ~8K | Low | Largest control library (58KB template file); deep WinForms dependency; complex nullable binding | High | High |
| ActiveDevelop.SqlTools | DB Tools | ~1K | Medium | DatabaseSchemaUpdateManager base class; straightforward ADO.NET | Low | Low |

## Framework & Platform Dependencies

| Dependency | Category | .NET 8+ Status | Replacement / Action | Risk |
|------------|----------|---------------|---------------------|------|
| .NET Framework 4.7.2 | Runtime | ❌ Not supported | Retarget to .NET 8+ | High (blocking) |
| System.Windows.Forms | UI | ✅ Supported on .NET 8+ (Windows-only) | Keep; add `<UseWindowsForms>true</UseWindowsForms>` in SDK-style project | Low |
| System.Data.SqlClient | Data Access | ⚠️ Maintenance-only | Microsoft.Data.SqlClient (drop-in replacement) | Low |
| System.Data.Entity (EF6) | ORM | ⚠️ Limited support | EF Core 8+ | Medium |
| Microsoft.VisualBasic | VB Runtime | ✅ Supported on .NET 8+ | Keep; Microsoft.VisualBasic.* available on modern .NET | Low |
| System.Management (WMI) | System Info | ⚠️ Needs NuGet package | Add System.Management NuGet package; Windows-only | Low |
| System.Drawing.Common | Graphics | ⚠️ Windows-only on .NET 8+ | Keep for Windows desktop; add NuGet package | Low |
| RDLC / ReportViewer | Reporting | ⚠️ Community package | Microsoft.ReportingServices.ReportViewerControl.WinForms (NuGet) | Medium |
| LINQ to SQL (.dbml) | Data Access | ❌ Not on .NET 8+ | EF Core or Dapper for Kannegiesser SQL integration | High |
| ClickOnce | Deployment | ✅ Supported on .NET 8+ | Keep or migrate to MSIX | Low |

## COM / GAC / Local Assembly References

| Reference | Type | Status | Action |
|-----------|------|--------|--------|
| None detected | — | — | Clean solution — no COM/GAC dependencies found |

## Summary

- **Blocking dependencies:** .NET Framework 4.7.2 (must retarget), LINQ to SQL (must replace)
- **High-risk:** MvvmForms (beta, unknown .NET 8+ support), ADNullableValueControls (complex WinForms controls)
- **Low-risk majority:** 8 of 11 NuGet packages are fully .NET 8+ compatible or built-in
- **Key advantage:** No COM references, no GAC dependencies, no discontinued vendor control suites
