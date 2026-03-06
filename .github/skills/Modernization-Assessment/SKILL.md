---
name: migration-assessment
description: 'Perform a structured technical discovery and migration fitness assessment (Ist-Zustand-Analyse) of a software solution. Use when asked to evaluate a codebase for migration readiness, assess modernization candidates, analyze legacy software architecture, produce a technology fitness report, or run a migration risk assessment. Produces structured Markdown documents with scored evaluations and lookup tables for downstream migration skills.'
---

# Migration Assessment Skill

Perform a comprehensive **Technical Discovery & Migration Fitness Assessment** of a software solution. This skill produces both human-readable summaries for study and machine-consumable lookup tables that a downstream migration skill can reference.

## Step 0 — Workspace Setup

Before scanning any code, prepare the output location.

### 0.1 Solution Items Folder

Check whether the solution already has a solution-items folder (common names: `_solution items`, `Solution Items`, `_SolutionItems`). If one exists, use it. If not, create `_solution items` at the solution root.

### 0.2 Documentation Folder

Check whether the repository already has a documentation folder at the same level as or containing the source tree (common names: `docs`, `Docs`, `doc`, `documentation`). Also check for an adjacent `src`, `source`, or `Source` folder to determine repo layout.

- If a docs folder exists, use it.
- If not, create `docs` at the same level as the `src`-equivalent folder (or at the repo root if no src-equivalent exists).

Inside the docs folder, create a subfolder `Eval`. All output documents go into `docs/Eval/`.

### 0.3 Output Documents

Generate the following Markdown files. Each file is self-contained and independently useful.

| File | Purpose | Size Target |
|------|---------|-------------|
| `00-migration-assessment.md` | **Comprehensive assessment.** The full deep-dive document for intensive study. Contains all area summaries, all tables, all findings. This is the canonical reference. | 20–80 pages depending on solution size |
| `01-executive-summary.md` | **One-page executive overview.** T-shirt sizing, top risks, top advantages, recommended strategy, effort distribution. | 1–2 pages |
| `02-scorecard.md` | **Quick-lookup scorecard.** The evaluation table across all 13 areas with scores, risk levels, blocking flags, modern targets, and migration complexity. Glanceable. | 1 page |
| `03-dependency-register.md` | **Third-party dependency risk register.** Every external dependency: vendor status, .NET 8+ compatibility, modern replacement, migration effort, risk score. | Variable |
| `04-database-logic-map.md` | **Database logic migration map.** Every trigger, stored procedure, function, view — categorized, with target application-layer equivalent and effort estimate. Skip this file if the application has no significant database-side logic. | Variable |
| `05-architecture-diagram.md` | **Architecture & project topology.** Solution structure, project dependency graph (Mermaid), subsystem grouping, framework-per-project matrix. | 2–5 pages |
| `06-security-assessment.md` | **Security posture assessment.** Authentication, authorization, secrets management, network exposure, cryptography, compliance gaps. | 2–4 pages |
| `07-migration-sequence.md` | **Recommended migration order.** For multi-project solutions: which projects/subsystems to migrate first, dependency chains, effort per step. For single-project solutions, merge this into `00-migration-assessment.md` and skip the standalone file. | Variable |

Each document should start with a YAML-style metadata block (as a Markdown comment or heading block) containing:

```markdown
<!-- migration-assessment
  solution: {solution name}
  generated: {ISO 8601 timestamp}
  skill-version: 1.0
  document: {document ID, e.g., "02-scorecard"}
-->
```

### 0.4 Solution Items Integration

Add all generated `docs/Eval/*.md` files as solution items in the `_solution items` folder (or equivalent) so they are visible in the IDE's Solution Explorer. For `.sln` files, this means adding a Solution Folder entry. If the solution uses a non-standard build system, note this in the output and skip IDE integration.

---

## Step 1 — Inventory (No Judgment Yet)

Systematically scan the solution. Record facts only — do not evaluate.

### 1.1 Solution Topology

- Count and list all projects, grouped by output type (EXE, DLL, Test, Shared).
- Map the project reference graph. Flag circular dependencies.
- Identify UI framework(s) per project: WinForms, WPF, UWP, Xamarin, WebForms, ASP.NET Framework, ASP.NET Core, Blazor, MAUI, Console, Service, None.
- Identify target framework(s) per project: .NET Framework (version), .NET Core, .NET 5+, .NET Standard, multi-targeting.
- Detect solution-level patterns: shared projects, Directory.Build.props, central package management.
- For solutions with >20 projects, group into logical subsystems based on naming, folder structure, and dependency clusters. Present subsystem summaries first.

### 1.2 Language & Compiler

- Primary language(s): C#, VB.NET, F#, C++/CLI, mixed.
- Language version (explicit or inferred).
- Noteworthy compiler features: `Unsafe`, P/Invoke, COM interop, `dynamic`, T4 templates, source generators, Roslyn analyzers.
- VB-specific: `Option Strict Off`, `My` namespace, `Microsoft.VisualBasic` runtime dependency, XML literals.

### 1.3 Third-Party & Platform Dependencies

For each dependency, record: name, version, category (UI controls, ORM, logging, IoC, reporting, communication, serialization, testing, build tooling, other), and binding type (NuGet, GAC, local assembly, COM reference).

### 1.4 Data Layer

- Database engine(s) and version if detectable.
- Connection strategy (config-based, hardcoded, encrypted, per-environment).
- Data access patterns: raw ADO.NET, typed DataSets, EF (version), EF Core, Dapper, NHibernate, LINQ to SQL, stored procedures, inline SQL, triggers, functions.
- Database-side logic: count and categorize triggers, stored procedures, functions, views.
- Schema patterns: composite keys, GUID PKs, identity columns, temporal versioning, soft deletes, sentinel values.

### 1.5 Architecture & Patterns

- Layer separation quality (UI / business logic / data access).
- Dependency injection approach (or lack thereof).
- Configuration mechanism.
- Logging framework.
- Error handling patterns.
- Inter-process communication (WCF, Remoting, REST, gRPC, etc.).
- Threading model (`BackgroundWorker`, `Thread`, TPL, `async/await`, `Control.Invoke`).
- Deployment model (ClickOnce, MSI, XCOPY, Azure, IIS, Windows Service, container).

### 1.6 Security

- Authentication mechanism.
- Authorization model.
- Secrets management.
- Network exposure (local desktop, LAN, internet-facing).
- Cryptography (hashing, TLS usage, plaintext storage).

### 1.7 Testing & Quality

- Test projects, framework, approximate coverage.
- Static analysis configuration.
- CI/CD setup.

---

## Step 2 — Evaluation & Scoring

Evaluate each area against current best practices (2025 zeitgeist). For each area, produce a written summary (2–5 paragraphs) and a scored table row.

### Evaluation Areas

| ID | Area | Key Questions |
|----|------|---------------|
| A | **Separation of Concerns** | Can layers be migrated independently? Is logic trapped in UI or DB? |
| B | **Framework & Runtime** | Distance from modern .NET? Blocking APIs? SDK-style projects? |
| C | **Language Modernization** | Refactoring needed for current idioms? VB→C# complexity? |
| D | **Third-Party Dependencies** | Vendor alive? .NET 8+ version? Modern replacement? Licensing? |
| E | **Data Access & ORM** | Coupling to data access pattern? DB-side logic volume? EF Core path? |
| F | **Database Schema & Design** | Normalization quality? EF Core mapping suitability? Anti-patterns? |
| G | **UI Framework & Controls** | Modern .NET support? Third-party control availability? UI pattern? |
| H | **Performance Architecture** | Obsolete optimizations? Patterns that are anti-patterns today? |
| I | **Extensibility & Modularity** | Plugin architecture? API surface? Monolith vs. modular? |
| J | **Security Posture** | Auth modernity? Compliance gaps? Network assumptions? |
| K | **Deployment & Operations** | Containerization feasibility? Config maturity? Observability? |
| L | **Testing & Confidence** | Coverage? Can you refactor safely? Integration tests for business rules? |
| M | **Documentation & Knowledge** | Inline docs quality? Is domain knowledge tribal? |

### Scoring: 1–10

| Score | Meaning | Migration Implication |
|-------|---------|----------------------|
| 10 | Excellent — already modern or trivially updatable | No work needed |
| 8–9 | Good — minor adjustments, well-structured | Low effort, predictable |
| 6–7 | Acceptable — some refactoring, no blockers | Moderate effort, manageable |
| 4–5 | Concerning — significant rework, structural issues | High effort, needs planning |
| 2–3 | Poor — fundamental problems, potential blockers | Very high effort, may require redesign |
| 1 | Critical — actively blocking or causing risk | Showstopper, address first |

**Risk Level derivation:** 8–10 → Low, 6–7 → Medium, 4–5 → High, 1–3 → Critical.

**Blocking** = migration cannot proceed without addressing this area first.

### Output Tables

**Scorecard** (goes into `02-scorecard.md`):

```
| Area | Score | Risk | Blocking? | Modern Target | Complexity | Key Finding |
|------|-------|------|-----------|---------------|------------|-------------|
```

**Dependency Register** (goes into `03-dependency-register.md`):

```
| Dependency | Version | Category | Maintained? | .NET 8+? | Replacement | Effort | Risk |
|------------|---------|----------|-------------|----------|-------------|--------|------|
```

**Database Logic Map** (goes into `04-database-logic-map.md`):

```
| DB Object | Type | Category | Complexity | App-Layer Target | Strategy | Effort |
|-----------|------|----------|------------|-----------------|----------|--------|
```

**Migration Sequence** (goes into `07-migration-sequence.md`):

```
| Order | Project(s) | Rationale | Unblocks | Effort |
|-------|-----------|-----------|----------|--------|
```

**UI Framework Matrix** (for mixed-framework solutions, goes into `05-architecture-diagram.md`):

```
| UI Framework | Project Count | Modern Target | Migration Path | Complexity |
|-------------|--------------|---------------|----------------|------------|
```

---

## Step 3 — Adaptive Scaling

- **Small (1–5 projects, <10K LOC):** Skip `04-database-logic-map.md` and `07-migration-sequence.md` if not applicable. Collapse dependency register into the main document if <10 dependencies.
- **Medium (5–30 projects, 10K–200K LOC):** Full document set. Group related projects in migration sequence.
- **Large (30+ projects, 200K+ LOC):** Add subsystem-level summaries. Sequence subsystems first, then projects within. Add a "Quick Wins" section identifying trivially migratable projects.
- **Mixed-framework (WinForms + WPF + Web + etc.):** Evaluate each UI framework separately in Area G. Include the framework matrix.

---

## Critical Assessment Guidelines

1. **Don't romanticize old decisions.** A pattern smart in 2004 may be debt today. Acknowledge original reasoning, then assess current fitness.
2. **Don't catastrophize.** A VB.NET WinForms app on .NET Framework 2.0 is not a disaster — WinForms runs on modern .NET, VB→C# tooling exists. Score honestly.
3. **Distinguish "old" from "broken."** A well-structured .NET Framework 4.8 app might score 7–8. A poorly structured .NET 6 app might score 3–4.
4. **Flag hidden complexity.** Trigger cascades, implicit transactions, COM interop with unmanaged resources, P/Invoke to native DLLs missing x64 builds — these blow up timelines.
5. **Be specific about blockers.** "Uses True DBGrid Pro 8.0, discontinued 2012, no .NET 8+ version" is actionable. "Uses old controls" is not.
6. **Give database logic proportional weight.** Trigger/SP migration is often 40–60% of total effort. Don't bury it.
7. **Identify load-bearing projects.** In multi-project solutions, find the ones everything depends on. They determine migration order.
