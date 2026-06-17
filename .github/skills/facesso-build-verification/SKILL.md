---
name: build-verification
description: Rules for final verification of code changes. Use this when completing a task that modified code, to ensure a clean build and rebuild passes before considering the work done.
---

# Build Verification Rules

When performing a **final check** of changes (before committing or marking a task complete), always do the following:

## Required Steps

1. **Clean** the solution first to remove all cached build artifacts:
   ```
   msbuild .\Facesso.sln /t:Clean /p:Configuration=Debug /nologo /clp:"ErrorsOnly;Summary"
   ```

2. **Rebuild** the entire solution from scratch:
   ```
   msbuild .\Facesso.sln /t:Rebuild /p:Configuration=Debug /m:1 /nologo /clp:"ErrorsOnly;Summary"
   ```

## Why

- A regular incremental build may succeed even when the full dependency graph is broken (e.g., stale artifacts from renamed projects, cached outputs).
- A clean + rebuild ensures that every project compiles from source with the current references and namespaces.

## When to Apply

- At the **end of every task** that modifies code, project files, solution files, or namespaces.
- This applies to both the `MixNetFx` and `VBNetFx` solutions — rebuild whichever solution was affected.
