<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 02-scorecard
-->

# Facesso — Migration Scorecard

## Overall Rating: 4.8 / 10 — **High Risk**

| Area | Score | Risk | Blocking? | Modern Target | Complexity | Key Finding |
|------|-------|------|-----------|---------------|------------|-------------|
| **A — Separation of Concerns** | 6 | Medium | No | Clean Architecture / Vertical Slices | Moderate | Good 3-layer separation (UI→Functions→Data→SQL), but business logic leaks into UI forms and DB triggers |
| **B — Framework & Runtime** | 4 | High | **Yes** | .NET 8+ / .NET 9 | High | .NET Framework 4.7.2 across all 17 projects; non-SDK-style .vbproj; WPF interop flag complicates retargeting |
| **C — Language Modernization** | 4 | High | No | C# 12+ (or modernized VB.NET) | High | ~35K LOC VB.NET; Option Strict On (good); heavy use of `My` namespace, `Module`, VB-specific patterns; VB→C# conversion at scale is significant |
| **D — Third-Party Dependencies** | 7 | Medium | No | Modern NuGet equivalents | Low | Minimal third-party: Newtonsoft.Json ✅, System.Reactive ✅, MvvmForms (beta/niche ⚠️); most libs are in-house ActiveDevelop |
| **E — Data Access & ORM** | 5 | High | No | EF Core 8+ / Dapper | High | 80 stored procedures via raw SqlCommand; EF6 EDMX present but unused; SPAccess singleton pattern tightly coupled |
| **F — Database Schema & Design** | 6 | Medium | No | EF Core with Fluent API | Moderate | Well-designed multi-tenant schema (IDSubsidiary compound PKs); dual GUID+INT ID pattern; XML columns; sentinel values (-1, -2) need mapping |
| **G — UI Framework & Controls** | 4 | High | **Yes** | WinForms on .NET 8+ / Blazor / MAUI | Very High | WinForms MDI with ~50 custom forms; custom ADNullableValueControls (58KB template); MvvmForms beta dependency; no standard MVVM; all UI text hardcoded German |
| **H — Performance Architecture** | 5 | High | No | Async/await, background services | Moderate | No async anywhere; all DB calls synchronous on UI thread; DB trigger cascades are potential performance bottleneck; Reactive Extensions included but underused |
| **I — Extensibility & Modularity** | 6 | Medium | No | Plugin architecture / DI | Moderate | Good interface-based import system (IFacessoImportTaskItem); Factory pattern for functions; but tightly coupled to FacessoGeneric singleton; no DI container |
| **J — Security Posture** | 2 | Critical | **Yes** | ASP.NET Core Identity / OWASP | Critical | SQL injection in login (string concatenation); SHA1 password hashing; authentication logic bug (always sets authenticated=true); plain-text registry credentials |
| **K — Deployment & Operations** | 3 | Critical | No | MSIX / CI-CD / Containers | High | Deprecated .vdproj installers; ClickOnce to HTTP URL; no CI/CD pipeline; Registry-dependent configuration; no observability |
| **L — Testing & Confidence** | 1 | Critical | **Yes** | xUnit + Integration Tests | Very High | Zero test projects; zero unit tests; no integration tests; no mocking infrastructure; refactoring without tests is high-risk |
| **M — Documentation & Knowledge** | 3 | Critical | No | XML docs + Architecture Decision Records | High | README exists; no inline architecture docs; German domain terms throughout; REFA wage calculation logic is tribal knowledge; no API documentation |

## Summary

- **Blocking areas (4):** Framework & Runtime (B), UI Framework (G), Security (J), Testing (L)
- **Critical risk (4):** Security (J), Deployment (K), Testing (L), Documentation (M)
- **Strongest area:** Third-Party Dependencies (D) — minimal external risk
- **Weakest area:** Testing (L) — zero coverage makes any migration high-risk

## T-Shirt Sizing

| Dimension | Size |
|-----------|------|
| **Overall Migration Effort** | **XL** |
| **Timeline (with 2 FTE)** | 9–14 months |
| **Risk Profile** | High — security blockers + zero test safety net |
| **Recommended Strategy** | Phased strangler fig: security fixes first → test harness → framework retarget → UI modernization |
