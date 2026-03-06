<!-- migration-assessment
  solution: Facesso
  generated: 2026-03-06T22:34:29Z
  skill-version: 1.0
  document: 06-security-assessment
-->

# Facesso — Security Posture Assessment

## Overall Security Score: 2 / 10 — Critical

The application has fundamental security vulnerabilities that must be addressed regardless of whether a migration is undertaken. The most severe issue — SQL injection in the authentication path — could allow complete authentication bypass.

---

## 1. Authentication

### Current State

| Aspect | Implementation | Rating |
|--------|---------------|--------|
| **Mechanism** | Custom username/password login via `UserInfo` class | ⚠️ |
| **Password Storage** | Salted SHA1 hash (ADCryptedPassword) stored as `VARBINARY` | ❌ Weak |
| **Password Comparison** | Byte-array comparison via operator overload | ✅ Acceptable |
| **Login Query** | Direct string concatenation — **SQL injection vulnerable** | 🔴 Critical |
| **Session Management** | Single-user singleton (My.Application) — no timeout | ⚠️ |
| **Multi-Factor Auth** | Not implemented | ❌ |
| **Account Lockout** | Not implemented | ❌ |
| **Login Auditing** | Not implemented | ❌ |

### Critical Vulnerability: SQL Injection in Login

**Location:** `FAC_Generic\LoginUserClasses.vb`, lines 53–54

```vb
Dim locCommand As New SqlCommand(
    "SELECT * FROM [Users] WHERE [IDSubsidiary]=" & IDSubsidiary.ToString &
    " AND [Username] = '" & Username & "'" &
    " AND [IsCurrent]=1", locConnection)
```

**Attack Vector:** A malicious username such as `' OR '1'='1' --` would bypass authentication entirely, returning the first active user's record (likely an administrator).

**Impact:** Complete authentication bypass. An attacker with network access to the application could gain administrator access without valid credentials.

**Severity:** 🔴 **CRITICAL** — CVSS 9.8 (Network, Low complexity, No privileges required)

### Critical Bug: Authentication Logic Error

**Location:** `FAC_Generic\LoginUserClasses.vb`, line 87

The code reportedly sets `myAuthenticated = True` on both the success and failure branches. This means authentication may never actually fail even with wrong passwords.

**Impact:** Password verification may be completely ineffective.

**Severity:** 🔴 **CRITICAL**

### Remediation

```vb
' BEFORE (vulnerable):
Dim locCommand As New SqlCommand(
    "SELECT * FROM [Users] WHERE [IDSubsidiary]=" & IDSubsidiary.ToString &
    " AND [Username] = '" & Username & "'", locConnection)

' AFTER (parameterized):
Dim locCommand As New SqlCommand(
    "SELECT * FROM [Users] WHERE [IDSubsidiary]=@IDSubsidiary " &
    "AND [Username]=@Username AND [IsCurrent]=1", locConnection)
locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.UniqueIdentifier).Value = IDSubsidiary
locCommand.Parameters.Add("@Username", SqlDbType.NVarChar, 256).Value = Username
```

---

## 2. Authorization

### Current State

| Aspect | Implementation | Rating |
|--------|---------------|--------|
| **Model** | Role-based (ClearanceLevel enum) + Version-based (license tier) | ✅ Good design |
| **Granularity** | Per-function via `IFacessoFunction` interface | ✅ Good |
| **Enforcement** | `FunctionHandler(Of T).GetFunctionInstance()` validates before instantiation | ✅ Consistent |
| **Role Hierarchy** | ClearanceLevel: None → Standard → Admin (BIGINT flags) | ✅ Adequate |
| **Data-Level Authorization** | Multi-tenant via IDSubsidiary — applied consistently | ✅ Good |

**Assessment:** Authorization design is sound. The role-based + version-based dual model provides reasonable access control for a desktop application. The multi-tenant IDSubsidiary partitioning is consistently applied across stored procedures.

---

## 3. Secrets Management

| Secret | Storage Location | Encrypted? | Risk |
|--------|-----------------|-----------|------|
| **SQL Connection String** | Windows Registry (HKLM + HKCU) | ❌ Plain text | 🟠 High |
| **License Serial Number** | Windows Registry (HKLM) | ❌ Plain text | 🟡 Medium |
| **License Dates** | Obfuscated registry path (`Intel_lAD\Classes\{GUID}`) | ❌ Security through obscurity | 🟡 Medium |
| **User Passwords** | SQL Server `Users` table as VARBINARY | ✅ Salted hash | ⚠️ Weak algorithm |
| **Assembly Signing Key** | `ActiveDev.pfx` in source repository | ❌ Should not be in source control | 🟠 High |

### Concerns

1. **Connection strings** in the registry are readable by any local process running under the same user or with elevated privileges. If the connection string contains SQL Server credentials (SQL Auth mode), these are exposed in plain text.

2. **Assembly signing key** (`ActiveDev.pfx`) is checked into the repository. While not a runtime secret, it could be used to create signed assemblies impersonating the legitimate application.

3. **License dates** stored under an obfuscated registry path (`Intel_lAD`) provide no real security — the path is discoverable in the source code.

### Recommendations

- Use **Windows Authentication (Integrated Security)** for SQL Server to eliminate credential storage
- Use **DPAPI** or **Azure Key Vault** for any secrets that must be stored locally
- Move `ActiveDev.pfx` out of source control; use CI/CD signing instead
- Replace registry-based configuration with encrypted `appsettings.json` (via `Microsoft.Extensions.Configuration`)

---

## 4. Network Exposure

| Aspect | Current State | Risk |
|--------|--------------|------|
| **Application Type** | Desktop (WinForms) — no web surface | ✅ Low network exposure |
| **Database Connection** | SQL Server (local or LAN) — no TLS enforcement | 🟡 Medium on shared networks |
| **ClickOnce Updates** | HTTP (not HTTPS): `http://facesso.de/updates/` | 🔴 Man-in-the-middle risk |
| **External Integrations** | Import adapters (Kannegiesser, Jensen, Legatro) — SQL/OleDB connections | 🟡 Depends on network |
| **WMI Queries** | Local system info for licensing — no network exposure | ✅ Low |

### Key Concern: ClickOnce over HTTP

The ClickOnce update URL uses plain HTTP (`http://facesso.de/updates/`). This allows man-in-the-middle attacks where an attacker on the same network could serve malicious updates to users.

**Remediation:** Change to HTTPS and verify certificate pinning.

---

## 5. Cryptography

| Usage | Algorithm | Rating | Modern Alternative |
|-------|-----------|--------|-------------------|
| **Password Hashing** | SHA1 with 4-byte salt | ❌ Deprecated | PBKDF2 (100K+ iterations), bcrypt, or Argon2id |
| **Random GUID Generation** | RNGCryptoServiceProvider | ✅ Cryptographically secure | RandomNumberGenerator (static API on .NET 8+) |
| **Password Salt** | 4 bytes (32 bits) | ⚠️ Short | Minimum 16 bytes (128 bits) recommended |
| **Data-at-Rest Encryption** | None — no field-level encryption | 🟡 Risk depends on data sensitivity | SQL Server TDE or column-level encryption |
| **Transport Encryption** | Not enforced on SQL connection | 🟡 Medium | Add `Encrypt=True;TrustServerCertificate=False` to connection string |

### SHA1 Password Hashing Detail

```
ADCryptedPassword implementation:
  1. Generate 4-byte random salt
  2. Concatenate: salt + password bytes (ASCII)
  3. Compute SHA1 hash of concatenated input
  4. Store: salt (4 bytes) + hash (20 bytes) = 24 bytes in VARBINARY column
```

**Weakness:** SHA1 has known collision attacks and is computationally cheap to brute-force with modern hardware. The 4-byte salt space (2³² = 4 billion possibilities) is adequate but the hash function is not.

**Migration path:** On next password change per user, re-hash with PBKDF2/bcrypt. Store algorithm identifier alongside hash for backward compatibility during transition.

---

## 6. Input Validation & SQL Injection

### SQL Injection Audit

| Location | Pattern | Severity | Status |
|----------|---------|----------|--------|
| `FAC_Generic\LoginUserClasses.vb:53` | Username concatenated into WHERE clause | 🔴 Critical | Unpatched |
| `FacFunctions\Fac_FunctionsInternal.vb:17` | IDSubsidiary concatenated (integer) | 🟠 High | Anti-pattern (integer mitigates direct injection but still dangerous) |
| `FacFunctions\Fac_FunctionsInternal.vb:64` | Same pattern in currency/wage combo loaders | 🟠 High | Anti-pattern |
| `FacessoData\SPAccess_*.vb` (all files) | ✅ Parameterized stored procedure calls | ✅ Safe | Good practice |
| `FacessoData\DatenModelUpdater.vb` | DDL strings for schema migration (no user input) | ✅ Acceptable | Schema-only |

### Assessment

The **primary data access layer** (SPAccess) consistently uses parameterized queries — this is good. However, the **business logic layer** (FacFunctions) and **core services** (FAC_Generic) contain ad-hoc queries with string concatenation. The critical vulnerability is in the authentication path.

---

## 7. Compliance Considerations

| Standard | Relevance | Current Gaps |
|----------|-----------|-------------|
| **GDPR** | Employee personal data (names, DOB, addresses, personnel numbers) | No data export/deletion mechanism; no consent tracking; no data retention policy |
| **BDSG** (German Federal Data Protection) | German manufacturing context — employee data | Same gaps as GDPR; additionally, handicap data (health info) requires special protection |
| **ISO 27001** | If customer requires certification | No access logging, no vulnerability management, no incident response |
| **SOC 2** | If SaaS deployment considered | Would require fundamental security overhaul |

---

## 8. Security Remediation Priority

| Priority | Action | Effort | Impact |
|----------|--------|--------|--------|
| **P0 — Immediate** | Fix SQL injection in `LoginUserClasses.vb` (parameterize query) | 1 hour | Eliminates authentication bypass |
| **P0 — Immediate** | Fix authentication logic bug (`myAuthenticated` always true) | 30 min | Restores password verification |
| **P1 — Urgent** | Parameterize all queries in `Fac_FunctionsInternal.vb` | 2 hours | Eliminates remaining injection vectors |
| **P1 — Urgent** | Change ClickOnce URL from HTTP to HTTPS | 1 hour | Eliminates MITM update attack |
| **P2 — Short-term** | Upgrade password hashing from SHA1 to PBKDF2/bcrypt | 1–2 days | Protects passwords if database compromised |
| **P2 — Short-term** | Remove `ActiveDev.pfx` from source control | 1 hour | Prevents assembly impersonation |
| **P3 — Medium-term** | Add login audit trail (failed attempts, successful logins) | 2–3 days | Enables security monitoring |
| **P3 — Medium-term** | Add account lockout after N failed attempts | 1 day | Prevents brute-force attacks |
| **P4 — Long-term** | Implement DPAPI or vault-based secrets management | 3–5 days | Eliminates plain-text secret storage |
| **P4 — Long-term** | Add SQL Server TLS enforcement | 1 day | Protects data in transit |
