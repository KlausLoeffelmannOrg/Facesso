# Facesso  
### Production Data Acquisition & REFA-Based KPI System  
*(Historical Reference Implementation)*

---

## About Facesso

**Facesso** was originally developed approximately 15 years ago as a production data acquisition and group-based time tracking system for manufacturing environments.

Its core capabilities include:

- REFA-based work value calculations  
- Group-based time tracking  
- KPI computation and bottleneck detection  
- Incentive wage calculation  
- A database-driven integrity model designed to maintain internal consistency  

One of the architecturally notable aspects of Facesso is its SQL integrity layer.  
Even when time or production data is modified directly at the table level, database triggers automatically recalculate KPIs and work-degree metrics to preserve consistency across work groups.

---

## Why This Repository Exists

Facesso is published today as:

- A historical software artifact  
- A realistic enterprise scenario for modernization experiments  
- A non-trivial database integrity case study  
- A practical object for AI-assisted refactoring and migration tooling  
- A learning resource for REFA-based production modeling  

It is intentionally preserved close to its original architectural form to provide a realistic legacy system structure.

---

## How to Make Facesso Startable

Facesso requires a running SQL Server instance and a set of Windows Registry entries before it can start. This section explains the minimal setup.

### Prerequisites

1. **SQL Server Express** (2017 or later) must be installed and the instance must be running.
2. If you are running inside a **container** or need **unattended / unit-test access**, the SQL Server instance must be configured in **mixed-mode authentication** (SQL + Windows auth) so that a SQL login (e.g. `sa`) can be used.
3. The Facesso demo database must be restored from the backup in `DemoData\Facesso-demo-backup.zip`.

### Quick Setup with FacessoSetup

The tool `FacessoSetup` in `src\Tools\FacessoSetup\` automates the most common database-administration tasks. Build it first:

```powershell
msbuild src\Tools\FacessoSetup\FacessoSetup.sln /restore /p:Configuration=Release /v:minimal
```

Then use it in the following order:

#### 1. Extract and restore the demo database

```powershell
# If your backup is a ZIP archive (e.g. the shipped DemoData\Facesso-demo-backup.zip):
.\FacessoSetup.exe --RestoreCompressedDb "DemoData\Facesso-demo-backup.zip" "C:\backups"

# If you already have a plain .bak file:
.\FacessoSetup.exe --restore "C:\backups\Facesso-demo-backup.bak"
```

When neither `--instance` nor `--conn-str` is given, the tool assumes a container-style SQL auth connection:

```
Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;
```

For a local SQL Express instance with Windows auth, add `--instance .\SQLEXPRESS`.

#### 2. Add the default administrator account

```powershell
.\FacessoSetup.exe --add-default-admin
```

This creates the Facesso application user **Admin** with password **P@$$w0rd**.

#### 3. Configure the Windows Registry

```powershell
.\FacessoSetup.exe --setup --admin-password "P@$$w0rd"
```

This writes the universal test serial number, the connection string, and the required date/GUID values to HKLM and HKCU (see the *Registry Keys* section below for details). Requires Administrator privileges.

#### All-in-one command (container / CI)

```powershell
.\FacessoSetup.exe `
    --RestoreCompressedDb "DemoData\Facesso-demo-backup.zip" "C:\backups" `
    --setup `
    --add-default-admin
```

### Resetting the Database for Fresh Testing

To save the current state, back up with a timestamped file name:

```powershell
.\FacessoSetup.exe --Backup "C:\output\DBBackup\Facesso-{yyyy-MM-dd-HHmmss}.bak"
```

To restore the original demo data (discarding all changes):

```powershell
.\FacessoSetup.exe --RestoreCompressedDb "DemoData\Facesso-demo-backup.zip" "C:\backups"
```

Or, if you kept an uncompressed `.bak`:

```powershell
.\FacessoSetup.exe --restore "C:\backups\Facesso-demo-backup.bak"
```

Both restore commands force-close all existing connections before restoring.

---

## Intended Use

You are welcome to:

- Study the architecture  
- Experiment with migration strategies  
- Use it as a test object for AI agents  
- Evaluate modernization approaches  
- Reuse generic UI or printing components  
- Explore REFA-based production modeling  

The goal is to provide something more realistic than a synthetic demo application.

---

## Licensing & Security Reference

### Registry Keys

All Facesso runtime settings are stored under two hive roots. Values are written to both so
that per-machine defaults and per-user overrides coexist.

| Registry path | Value name | Type | Description |
|---|---|---|---|
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `SerialNumber` | `REG_SZ` | 30-char base-20 serial (no dashes). Default: `000000000000000000000000000000` |
| `HKCU\SOFTWARE\ActiveDev\Facesso\Classes` | `SerialNumber` | `REG_SZ` | Per-user copy of the serial number |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `{face2470-bae0-20cd-b579-08002b30bfeb}` | `REG_SZ` | Program GUID used as salt in hardware key derivation |
| `HKCU\SOFTWARE\ActiveDev\Facesso\Classes` | `{face2470-bae0-20cd-b579-08002b30bfeb}` | `REG_SZ` | Per-user copy of the program GUID |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `ConnectionString` | `REG_SZ` | ADO.NET SQL Server connection string |
| `HKCU\SOFTWARE\ActiveDev\Facesso\Classes` | `ConnectionString` | `REG_SZ` | Per-user copy of the connection string |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `RegObject` | `REG_DWORD` | `1` when the installation has been registered |
| `HKLM\SOFTWARE\ActiveDev\Facesso` | `ForceReapplication` | `REG_DWORD` | Set to `1` by the runtime when the serial must be re-entered (e.g. after date-tamper detection) |
| `HKCU\SOFTWARE\ActiveDev\Facesso` | `ForceReapplication` | `REG_DWORD` | Per-user copy |
| `HKLM\SOFTWARE\Intel_lAD\Classes\{face0100-bae0-20cd-b579-08002b30bfeb}` | `SUD_Intel_Private` | `REG_SZ` | Installation date stored as OADate (`double`) |
| `HKLM\SOFTWARE\ActiveDev\Facesso` | `InstallationDate` | `REG_SZ` | Human-readable copy of the installation date |
| `HKLM\SOFTWARE\Intel_lAD\Classes\{face0100-bae0-20cd-b579-08002b30bfeb}` | `DRL_Intel_Private` | `REG_SZ` | Last run date as OADate |
| `HKLM\SOFTWARE\ActiveDev\Facesso` | `LastRunDate` | `REG_SZ` | Human-readable copy of the last run date |
| `HKCU\SOFTWARE\ActiveDev\Facesso` | `LastRunDate` | `REG_SZ` | Per-user copy |
| `HKLM\SOFTWARE\Intel_lAD\Classes\{face0100-bae0-20cd-b579-08002b30bfeb}` | `DgeRL_Intel_Private` | `REG_SZ` | Last registration date as OADate (used when re-deriving the serial for validation) |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `FirstShiftThresholdInMin` | `REG_DWORD` | Minutes threshold for first-shift detection |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `FallbackStartTime` / `FallbackEndTime` | `REG_SZ` | Shift fallback time window |
| `HKLM\SOFTWARE\ActiveDev\Facesso` | `SubsidiarySubstitutionName` | `REG_SZ` | UI label substitution for "Filiale" (branch/subsidiary); default: `Filiale` |
| `HKLM\SOFTWARE\ActiveDev\Facesso` | `InstallationFolder` | `REG_SZ` | Path to the Facesso installation directory |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `SharedFolder` | `REG_SZ` | Path used for shared file exchange |
| `HKLM\SOFTWARE\ActiveDev\Facesso\Classes` | `UpdateFolder` / `UpdateUrl` | `REG_SZ` | Auto-update source folder / URL |

> **Universal test serial** — Set `SerialNumber` (in both hive locations) to
> `{face2407-6913-1068-1111-43002b30bfeb}` to skip all hardware-based and expiry
> checks. The constant is defined as `UNIVERSAL_INST_SERIAL_MIT_FOR_TESTING` in
> `FAC_Generic\Sundries\RegistryHelper.cs`.

---

### Hardware-Based Key Calculation — Pseudo-code

The licensing scheme is a two-step phone-in process. The client generates a **Pre-Key**
from local hardware; the vendor uses that Pre-Key plus licence parameters to calculate
the final **Serial Number**.

```
══════════════════════════════════════════════════════════════
 STEP 1 — PRE-KEY (generated on the client machine)
══════════════════════════════════════════════════════════════
 hwString  = WMI(Win32_DiskDrive).Model
           + WMI(Win32_DiskDrive).Signature    // disk model + signature
           + WMI(Win32_BaseBoard).Product
           + WMI(Win32_BaseBoard).Version      // motherboard product + version
           + ProgramGUID                        // from registry key {face2470-…}
           + InstallationDate                   // from registry SUD_Intel_Private

 preKeyBytes = MAC-TripleDES(
                 key  = UTF8("Nicht genügend Speicher!"),
                 data = UTF8(hwString))          // 8-byte digest

 PreKey = ToBase20String(ToUInt64(preKeyBytes), width=15)
          // 15 alphanumeric base-20 characters

 → User reads PreKey from the registration dialog and communicates it to the vendor.

══════════════════════════════════════════════════════════════
 STEP 2 — SERIAL NUMBER (calculated by the vendor)
══════════════════════════════════════════════════════════════
 licenseInfo  (packed as UInt64 via explicit struct layout):
   byte  0    SoftwareID      (1=Standard … 6=Enterprise V2)
   byte  1    MonthsLimited   (0 = unlimited)
   byte  2    Limit1          (max simultaneous users)
   byte  3    Limit2          (max internet users)
   ushort 4-5 Limit3          (max employees)
   ushort 6-7 Limit4          (reserved / interface extension)

 keyString = ToBase20String(licenseInfo, width=16)
           + Today.ToString("ddMMyyyy")          // ties the key to registration date

 serialBytes = MAC-TripleDES(
                 key  = UTF8(keyString),
                 data = UTF8(PreKey))             // 8-byte digest

 part1 = ToBase20String(ToUInt64(serialBytes), width=15)     // hardware-bound part
 part2 = ToBase20String(licenseInfo XOR 0xFFEEDDCCBBAA9988,  // obfuscated licence info
                         width=15)

 SerialNumber = part1 + part2          // 30 characters
 Formatted    = every 5 chars separated by " - "
                e.g.  XXXXX - XXXXX - XXXXX - XXXXX - XXXXX - XXXXX

 → Vendor reads SerialNumber to the customer over the phone.

══════════════════════════════════════════════════════════════
 STEP 3 — VALIDATION (on the client machine at each startup)
══════════════════════════════════════════════════════════════
 storedSerial = registry SerialNumber (dashes stripped, padded to 30 chars)

 givenLicenseInfoRaw = Parse(storedSerial[15..29], base=20)
 licenseInfo         = givenLicenseInfoRaw XOR 0xFFEEDDCCBBAA9988

 keyString   = ToBase20String(licenseInfo, width=16)
             + LastRegisteredDate.ToString("ddMMyyyy")

 PreKey      = recompute from current hardware (same as STEP 1)

 calcBytes   = MAC-TripleDES(key=UTF8(keyString), data=UTF8(PreKey))
 calcPart1   = ToBase20String(ToUInt64(calcBytes), width=15)

 valid = (calcPart1 == storedSerial[0..14])

 Additional checks (in FacessoLicenseManager.IsLicensed):
   • SystemClock >= InstallationDate      (tamper-detection)
   • SystemClock >= LastRunDate           (tamper-detection)
   • If MonthsLimited > 0: SystemClock <= InstallationDate + MonthsLimited months
   • SoftwareID <= 10
```

---

### Default System-Account Password

During first-time database initialisation (`frmDbSetupWizard`) three internal service
accounts are created automatically.  Their password is assembled at runtime from three
obfuscated string literals so it does not appear literally in the source:

```
locString1 = "MSI!=Mainboard Creation Computer"
locString2 = "Cuslaka, Alfred"
locString3 = "2cp3b - Fargoroad"

systemPassword = locString1[0..3]   // "MSI!"
               + locString2[0..3]   // "Cusl"
               + locString3[0..4]   // "2cp3b"
               + "f"

→  systemPassword = "MSI!Cusl2cp3bf"
```

| Account name | IDUserInternal | Password |
|---|---|---|
| `Facesso!GenericSystem` | −1 | `MSI!Cusl2cp3bf` |
| `Facesso!TimeDataInterface` | −2 | `MSI!Cusl2cp3bf` |
| `Facesso!ProdDataInterface` | −3 | `MSI!Cusl2cp3bf` |
| `Administrator` | 0 | chosen by the installer (min. 6 characters) |

---

### Password Hashing

Passwords are stored in the `Users` table, `Password` column (`varbinary(128)`) using a
salted SHA-1 scheme implemented in `ADSundries\ADSaltedPasswordHash.cs`:

```
STORE:
  hash1        = SHA1( UTF8(plainPassword) )              // 20 bytes
  salt         = CSPRNG(4 bytes)                          // random per password
  saltedInput  = hash1 ++ salt                            // 24 bytes
  hash2        = SHA1( saltedInput )                      // 20 bytes
  storedValue  = hash2 ++ salt                            // 24 bytes  ← written to DB

VERIFY:
  salt         = storedValue[20..23]                      // extract last 4 bytes
  hash1        = SHA1( UTF8(candidatePassword) )
  saltedInput  = hash1 ++ salt
  hash2        = SHA1( saltedInput )
  valid        = (hash2 == storedValue[0..19])
```

> **Note:** SHA-1 is used here because this is a legacy codebase (~15 years old).
> Modern applications should use bcrypt, scrypt, or Argon2 instead.

---

## License

Facesso is planned to be released under the MIT License.  
See the `LICENSE` file for details.
