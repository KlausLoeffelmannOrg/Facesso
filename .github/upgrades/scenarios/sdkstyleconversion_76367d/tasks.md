# Facesso SDK-Style Conversion Tasks

## Overview

This document tracks the conversion of 17 projects in the Facesso solution from legacy project format to SDK-style format. All projects will be converted in a single automated operation following strict topological dependency order, with no framework version changes.

**Progress**: 1/3 tasks complete (33%) ![0%](https://progress-bar.xyz/33)

---

## Tasks

### [✓] TASK-001: Fix pre-existing build errors *(Completed: 2026-02-21 04:33)*
**References**: #plan:Pre-Conversion-Prerequisites

- [✓] (1) Fix ADSerialGenerator BC30469 error per #plan:Step-0.1 (Settings.Designer.vb line 34)
- [✓] (2) Fix FacInterfaces BC30002 error per #plan:Step-0.2 (add ReportViewer reference)
- [✓] (3) Build full solution to verify fixes
- [✓] (4) Solution builds with 0 errors (Verify)
- [✓] (5) Record baseline warning count for post-conversion comparison
- [✓] (6) Commit fixes with message: "Fix pre-existing build errors before SDK-style conversion"

---

### [▶] TASK-002: Convert all 17 projects to SDK-style format
**References**: #plan:Conversion-Order, #plan:Project-by-Project-Upgrade-Plans, #plan:Source-Control-Strategy

- [ ] (1) Convert all 17 projects to SDK-style following topological order per #plan:Conversion-Order
- [ ] (2) Build each project individually after conversion and fix any errors per #plan:Project-by-Project-Upgrade-Plans
- [ ] (3) Commit after each successful project conversion with message "Convert [ProjectName] to SDK-style"
- [ ] (4) All 17 projects converted to SDK-style format (Verify)
- [ ] (5) All packages.config files removed (projects #7, #10, #14, #17) (Verify)

---

### [ ] TASK-003: Verify full solution build
**References**: #plan:Phase-2, #plan:Success-Criteria

- [ ] (1) Build entire Facesso solution
- [ ] (2) Solution builds with 0 errors (Verify)
- [ ] (3) Warning count ≤ baseline warning count (Verify)

---