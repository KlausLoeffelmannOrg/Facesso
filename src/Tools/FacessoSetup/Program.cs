using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace FacessoSetup
{
    internal class Program
    {
        // Universal serial bypasses all hardware and expiry checks (UNIVERSAL_INST_SERIAL_MIT_FOR_TESTING).
        const string UniversalSerial = "{face2407-6913-1068-1111-43002b30bfeb}";
        const string ProgramGuid     = "{face2470-bae0-20cd-b579-08002b30bfeb}";

        const string RegClasses = @"SOFTWARE\ActiveDev\Facesso\Classes";
        const string RegBase    = @"SOFTWARE\ActiveDev\Facesso";
        const string RegIntel   = @"SOFTWARE\Intel_lAD\Classes\{face0100-bae0-20cd-b579-08002b30bfeb}";

        static int Main(string[] args)
        {
            string backupFile = null;
            bool   doRestore  = false;
            bool   doSetup    = false;
            string instance   = @".\SQLEXPRESS";
            string dbName     = "Facesso";
            string connStr    = null;
            string adminUser  = "Administrator";

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--help": case "-h": case "/?":
                        PrintUsage();
                        return 0;

                    case "--restore": case "-r":
                        doRestore = true;
                        if (i + 1 < args.Length && !args[i + 1].StartsWith("-"))
                            backupFile = args[++i];
                        break;

                    case "--setup": case "-s":
                        doSetup = true;
                        break;

                    case "--instance": case "-i":
                        if (i + 1 < args.Length) instance = args[++i];
                        break;

                    case "--db-name": case "-n":
                        if (i + 1 < args.Length) dbName = args[++i];
                        break;

                    case "--conn-str": case "-c":
                        if (i + 1 < args.Length) connStr = args[++i];
                        break;

                    case "--admin-user":
                        if (i + 1 < args.Length) adminUser = args[++i];
                        break;

                    default:
                        // Positional argument: treat as backup file for backward compatibility.
                        if (!args[i].StartsWith("-") && backupFile == null)
                        {
                            backupFile = args[i];
                            doRestore  = true;
                        }
                        break;
                }
            }

            if (!doRestore && !doSetup)
            {
                PrintUsage();
                return 1;
            }

            if (doRestore && backupFile == null)
            {
                WriteError("--restore requires a backup file path.");
                return 1;
            }

            // Step 1: restore (may fill in dbName from the backup header)
            if (doRestore)
            {
                int rc = RunRestore(backupFile, instance, ref dbName, connStr);
                if (rc != 0) return rc;
            }

            // Step 2: setup (depends on connStr / instance+dbName being known)
            if (doSetup)
            {
                string setupConnStr = connStr;
                if (setupConnStr == null)
                {
                    if (dbName == null)
                    {
                        WriteError("--setup requires --conn-str or --db-name (and optionally --instance).");
                        return 1;
                    }
                    setupConnStr = BuildConnStr(instance, dbName);
                }

                string password = PromptPassword($"Enter new password for '{adminUser}' (min. 6 chars): ");
                if (password == null) { WriteError("Setup cancelled."); return 1; }

                string confirm = PromptPassword("Confirm password: ");
                if (confirm == null) { WriteError("Setup cancelled."); return 1; }

                if (password != confirm)
                {
                    WriteError("Passwords do not match. Setup aborted.");
                    return 1;
                }

                if (password.Length < 6)
                {
                    WriteError("Password must be at least 6 characters.");
                    return 1;
                }

                int rc = RunSetup(setupConnStr, adminUser, password);
                if (rc != 0) return rc;
            }

            return 0;
        }

        // -------------------------------------------------------------------------
        //  Restore
        // -------------------------------------------------------------------------

        static int RunRestore(string backupFile, string instance, ref string dbName, string connStr)
        {
            if (!File.Exists(backupFile))
            {
                WriteError($"Backup file not found: {backupFile}");
                return 1;
            }

            backupFile = Path.GetFullPath(backupFile);

            Console.WriteLine("FacessoSetup - Restore");
            Console.WriteLine("======================");
            Console.WriteLine($"Backup file : {backupFile}");
            Console.WriteLine($"SQL instance: {instance}");

            string masterConnStr = connStr != null
                ? new SqlConnectionStringBuilder(connStr) { InitialCatalog = "master" }.ConnectionString
                : BuildConnStr(instance, "master");

            try
            {
                using (var conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();
                    Console.WriteLine(
                        $"Server      : SQL Server {QueryScalar(conn, "SELECT SERVERPROPERTY('ProductVersion')")} " +
                        $"{QueryScalar(conn, "SELECT SERVERPROPERTY('ProductLevel')")}  " +
                        $"({QueryScalar(conn, "SELECT SERVERPROPERTY('Edition')")})");
                    Console.WriteLine();

                    Console.WriteLine("Reading backup metadata...");
                    string backupDbName = GetBackupDatabaseName(conn, backupFile);
                    var    fileList     = GetBackupFileList(conn, backupFile);

                    if (fileList == null || fileList.Count == 0)
                    {
                        WriteError("Could not read backup metadata. Is this a valid SQL Server backup?");
                        return 1;
                    }

                    Console.WriteLine($"  Backup database name : {backupDbName ?? "(unknown)"}");
                    Console.WriteLine($"  Backup file count    : {fileList.Count}");

                    if (dbName == null)
                        dbName = backupDbName ?? Path.GetFileNameWithoutExtension(backupFile);

                    Console.WriteLine($"  Target database name : {dbName}");

                    string dataDir = GetDefaultDataPath(conn);
                    if (dataDir == null)
                    {
                        WriteError("Could not determine the SQL Server default data directory.");
                        return 1;
                    }
                    Console.WriteLine($"  SQL data directory   : {dataDir}");
                    Console.WriteLine();

                    var    moveList   = BuildMoveClauses(fileList, dbName, dataDir);
                    string restoreSql = BuildRestoreSql(backupFile, dbName, moveList);

                    Console.WriteLine("Restoring database (this may take a while)...");

                    conn.FireInfoMessageEventOnUserErrors = false;
                    conn.InfoMessage += (s, e) =>
                    {
                        foreach (SqlError err in e.Errors)
                            Console.Write($"\r  {err.Message.Trim(),-70}");
                    };

                    using (var cmd = new SqlCommand(restoreSql, conn))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine();
                    WriteSuccess($"Database '{dbName}' restored successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Verifying database...");

                    string dbConnStr = connStr != null
                        ? new SqlConnectionStringBuilder(connStr) { InitialCatalog = dbName }.ConnectionString
                        : BuildConnStr(instance, dbName);

                    using (var dbConn = new SqlConnection(dbConnStr))
                    {
                        dbConn.Open();
                        bool isFacesso = IsFacessoDatabase(dbConn);

                        if (!isFacesso)
                        {
                            WriteWarning("The restored database does not appear to be a Facesso database.");
                            WriteWarning(
                                "Expected tables (TimeLog, Employees, WorkGroups, ProductionData, " +
                                "Subsidiaries) were not found.");
                        }
                        else
                        {
                            WriteSuccess("Confirmed: This is a Facesso database.");

                            if (NeedsSchemaUpdate(dbConn))
                            {
                                Console.WriteLine();
                                WriteWarning(
                                    "Schema update required: the [dbo].[EmployeeHandicaps] table is missing.");
                                WriteWarning(
                                    "Run the Facesso DatenModelUpdater to apply the latest schema changes.");
                            }
                            else
                            {
                                WriteSuccess("Schema is up to date (EmployeeHandicaps table is present).");
                            }
                        }
                    }

                    return 0;
                }
            }
            catch (SqlException ex) { WriteError($"SQL Server error ({ex.Number}): {ex.Message}"); return 1; }
            catch (Exception ex)    { WriteError(ex.Message); return 1; }
        }

        // -------------------------------------------------------------------------
        //  Setup — registry + admin password
        // -------------------------------------------------------------------------

        static int RunSetup(string connStr, string adminUser, string adminPassword)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Registry & Database Setup");
            Console.WriteLine("========================================");

            // --- Registry ---
            Console.WriteLine();
            Console.WriteLine("Writing registry values...");

            try
            {
                DateTime today        = DateTime.Today;
                string   oaDateStr    = today.ToOADate().ToString();
                string   readableDate = today.ToString("dd.MM.yyyy");

                // Write to both 32-bit and 64-bit registry views so the values are visible
                // regardless of whether Facesso runs as a 32-bit or 64-bit process.
                foreach (var view in new[] { RegistryView.Registry32, RegistryView.Registry64 })
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                    {
                        WriteReg(hklm, RegClasses, "SerialNumber",       UniversalSerial,  RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, ProgramGuid,          ProgramGuid,      RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, "ConnectionString",   connStr,          RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, "RegObject",          1,                RegistryValueKind.DWord);
                        WriteReg(hklm, RegBase,    "ForceReapplication", 0,                RegistryValueKind.DWord);
                        WriteReg(hklm, RegBase,    "InstallationDate",   readableDate,     RegistryValueKind.String);
                        WriteReg(hklm, RegBase,    "LastRunDate",        readableDate,     RegistryValueKind.String);
                        WriteReg(hklm, RegIntel,   "SUD_Intel_Private",   oaDateStr,       RegistryValueKind.String);
                        WriteReg(hklm, RegIntel,   "DRL_Intel_Private",   oaDateStr,       RegistryValueKind.String);
                        WriteReg(hklm, RegIntel,   "DgeRL_Intel_Private", oaDateStr,       RegistryValueKind.String);
                    }
                }

                // HKCU has no WOW64 redirection for user-hive keys — write once.
                using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    WriteReg(hkcu, RegClasses, "SerialNumber",       UniversalSerial, RegistryValueKind.String);
                    WriteReg(hkcu, RegClasses, ProgramGuid,          ProgramGuid,     RegistryValueKind.String);
                    WriteReg(hkcu, RegClasses, "ConnectionString",   connStr,         RegistryValueKind.String);
                    WriteReg(hkcu, RegBase,    "ForceReapplication", 0,               RegistryValueKind.DWord);
                    WriteReg(hkcu, RegBase,    "LastRunDate",        readableDate,    RegistryValueKind.String);
                }

                WriteSuccess("Registry configured.");
            }
            catch (UnauthorizedAccessException)
            {
                WriteError("Access denied writing to HKLM. Please run FacessoSetup as Administrator.");
                return 1;
            }
            catch (Exception ex)
            {
                WriteError($"Registry error: {ex.Message}");
                return 1;
            }

            // --- Admin user password ---
            Console.WriteLine();
            Console.WriteLine("Updating admin user password in database...");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        WriteWarning("Admin user password was not changed.");
                        return 0;
                    }

                    byte[] hash    = HashPassword(adminPassword);
                    int    updated = UpdateAdminPassword(conn, hash);

                    if (updated > 0)
                        WriteSuccess($"Password for '{adminUser}' (IDUserInternal=0) updated successfully.");
                    else
                    {
                        WriteWarning("No user with IDUserInternal=0 found in [dbo].[Users].");
                        WriteWarning("The database may not be fully initialised yet.");
                    }
                }
            }
            catch (SqlException ex) { WriteError($"Database error ({ex.Number}): {ex.Message}"); return 1; }
            catch (Exception ex)    { WriteError($"Database error: {ex.Message}"); return 1; }

            return 0;
        }

        // -------------------------------------------------------------------------
        //  Password hashing — ADSaltedPasswordHash (SHA-1 + 4-byte CSPRNG salt)
        // -------------------------------------------------------------------------

        static byte[] HashPassword(string plainPassword)
        {
            using (var sha1 = SHA1.Create())
            {
                // hash1 = SHA1(UTF8(plainPassword))                                        20 bytes
                byte[] hash1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

                // salt = CSPRNG(4 bytes)
                byte[] salt = new byte[4];
                using (var rng = new RNGCryptoServiceProvider())
                    rng.GetBytes(salt);

                // saltedInput = hash1 ++ salt                                               24 bytes
                byte[] saltedInput = new byte[24];
                Buffer.BlockCopy(hash1, 0, saltedInput,  0, 20);
                Buffer.BlockCopy(salt,  0, saltedInput, 20,  4);

                // storedValue = SHA1(saltedInput) ++ salt                                   24 bytes
                byte[] hash2   = sha1.ComputeHash(saltedInput);
                byte[] stored  = new byte[24];
                Buffer.BlockCopy(hash2, 0, stored,  0, 20);
                Buffer.BlockCopy(salt,  0, stored, 20,  4);
                return stored;
            }
        }

        static int UpdateAdminPassword(SqlConnection conn, byte[] passwordHash)
        {
            // IDUserInternal = 0 is the Administrator account (created during frmDbSetupWizard).
            using (var cmd = new SqlCommand(
                "UPDATE [dbo].[Users] SET [Password] = @pwd WHERE [IDUserInternal] = 0", conn))
            {
                cmd.Parameters.Add("@pwd", System.Data.SqlDbType.VarBinary, 128).Value = passwordHash;
                return cmd.ExecuteNonQuery();
            }
        }

        // -------------------------------------------------------------------------
        //  Registry helper
        // -------------------------------------------------------------------------

        static void WriteReg(RegistryKey hive, string subKeyPath, string valueName,
                             object value, RegistryValueKind kind)
        {
            using (var key = hive.CreateSubKey(subKeyPath, writable: true))
                key.SetValue(valueName, value, kind);
            Console.WriteLine($"  SET {hive.Name}\\{subKeyPath} => {valueName}");
        }

        // -------------------------------------------------------------------------
        //  Interactive password prompt (characters not echoed)
        // -------------------------------------------------------------------------

        static string PromptPassword(string prompt)
        {
            Console.Write(prompt);
            var sb = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    return null;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0) sb.Length--;
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    sb.Append(key.KeyChar);
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return sb.ToString();
        }

        // -------------------------------------------------------------------------
        //  Connection string builder
        // -------------------------------------------------------------------------

        static string BuildConnStr(string instance, string dbName) =>
            $"Data Source={instance};Initial Catalog={dbName};Integrated Security=True;Connect Timeout=30;";

        // -------------------------------------------------------------------------
        //  Backup metadata helpers
        // -------------------------------------------------------------------------

        static string GetBackupDatabaseName(SqlConnection conn, string backupFile)
        {
            using (var cmd = new SqlCommand(
                $"RESTORE HEADERONLY FROM DISK = N'{EscSql(backupFile)}'", conn))
            {
                cmd.CommandTimeout = 60;
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        int idx = r.GetOrdinal("DatabaseName");
                        return r.IsDBNull(idx) ? null : r.GetString(idx);
                    }
                }
            }
            return null;
        }

        static List<BackupFile> GetBackupFileList(SqlConnection conn, string backupFile)
        {
            var result = new List<BackupFile>();
            using (var cmd = new SqlCommand(
                $"RESTORE FILELISTONLY FROM DISK = N'{EscSql(backupFile)}'", conn))
            {
                cmd.CommandTimeout = 60;
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        result.Add(new BackupFile
                        {
                            LogicalName  = r["LogicalName"].ToString(),
                            PhysicalName = r["PhysicalName"].ToString(),
                            Type         = r["Type"].ToString()     // "D" = data, "L" = log
                        });
            }
            return result;
        }

        static string GetDefaultDataPath(SqlConnection conn)
        {
            // Preferred: InstanceDefaultDataPath property (SQL Server 2012+).
            string path = QueryScalar(conn, "SELECT SERVERPROPERTY('InstanceDefaultDataPath')");
            if (!string.IsNullOrWhiteSpace(path))
                return path.TrimEnd('\\', '/');

            // Fallback: derive from the location of the master database file.
            path = QueryScalar(conn,
                "SELECT physical_name FROM sys.master_files WHERE database_id = 1 AND file_id = 1");
            return string.IsNullOrEmpty(path) ? null : Path.GetDirectoryName(path);
        }

        // -------------------------------------------------------------------------
        //  RESTORE command builder
        // -------------------------------------------------------------------------

        static List<(string Logical, string Physical)> BuildMoveClauses(
            List<BackupFile> files, string dbName, string dataDir)
        {
            var result  = new List<(string, string)>();
            int dataIdx = 0;
            int logIdx  = 0;

            foreach (var f in files)
            {
                string destPath;
                if (f.Type == "L")
                {
                    string suffix = logIdx == 0 ? "_log.ldf" : $"_log{logIdx}.ldf";
                    destPath = Path.Combine(dataDir, dbName + suffix);
                    logIdx++;
                }
                else
                {
                    string suffix = dataIdx == 0 ? ".mdf" : $"_{dataIdx}.ndf";
                    destPath = Path.Combine(dataDir, dbName + suffix);
                    dataIdx++;
                }
                result.Add((f.LogicalName, destPath));
            }

            return result;
        }

        static string BuildRestoreSql(
            string backupFile, string dbName,
            List<(string Logical, string Physical)> moves)
        {
            var sb = new StringBuilder();
            sb.Append($"RESTORE DATABASE [{dbName}]");
            sb.Append($" FROM DISK = N'{EscSql(backupFile)}'");
            sb.Append(" WITH ");
            foreach (var (logical, physical) in moves)
                sb.Append($"MOVE N'{EscSql(logical)}' TO N'{EscSql(physical)}', ");
            sb.Append("REPLACE, STATS = 10");
            return sb.ToString();
        }

        // -------------------------------------------------------------------------
        //  Facesso verification
        // -------------------------------------------------------------------------

        static bool IsFacessoDatabase(SqlConnection conn)
        {
            string[] tables = { "TimeLog", "Employees", "WorkGroups", "ProductionData", "Subsidiaries" };
            int found = 0;
            foreach (var t in tables)
                if (TableExists(conn, t)) found++;
            return found >= 4;
        }

        // The DatenModelUpdater adds [EmployeeHandicaps]; its absence signals an outdated schema.
        static bool NeedsSchemaUpdate(SqlConnection conn) => !TableExists(conn, "EmployeeHandicaps");

        // -------------------------------------------------------------------------
        //  Generic SQL helpers
        // -------------------------------------------------------------------------

        static bool TableExists(SqlConnection conn, string tableName)
        {
            using (var cmd = new SqlCommand(
                $"SELECT COUNT(1) FROM sys.objects " +
                $"WHERE object_id = OBJECT_ID(N'[dbo].[{tableName}]') AND type = N'U'", conn))
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        static string QueryScalar(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                var r = cmd.ExecuteScalar();
                return (r == null || r == DBNull.Value) ? null : r.ToString();
            }
        }

        static string EscSql(string s) => s?.Replace("'", "''");

        // -------------------------------------------------------------------------
        //  Output helpers
        // -------------------------------------------------------------------------

        static void PrintUsage()
        {
            Console.WriteLine("FacessoSetup — Facesso Database Restore & Registry Setup Tool");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  FacessoSetup [operations] [options]");
            Console.WriteLine();
            Console.WriteLine("Operations (at least one required; when combined, restore runs first):");
            Console.WriteLine("  --restore <backup.bak>, -r   Restore a SQL Server backup file");
            Console.WriteLine("  --setup, -s                  Configure registry (universal licence +");
            Console.WriteLine("                               connection string) and set admin password");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --instance, -i <name>        SQL Server instance  (default: .\\SQLEXPRESS)");
            Console.WriteLine("  --db-name, -n <name>         Target / existing database name");
            Console.WriteLine("  --conn-str, -c <cs>          Full ADO.NET connection string");
            Console.WriteLine("                               (overrides --instance + --db-name for --setup)");
            Console.WriteLine("  --admin-user <name>          Admin username for --setup  (default: Administrator)");
            Console.WriteLine("  --help, -h                   Show this help");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(@"  FacessoSetup --restore C:\Backups\Facesso.bak");
            Console.WriteLine(@"  FacessoSetup --setup --conn-str ""Data Source=.\SQLEXPRESS;Initial Catalog=Facesso;Integrated Security=True""");
            Console.WriteLine(@"  FacessoSetup --restore Facesso.bak --setup --instance .\SQLEXPRESS --db-name Facesso");
            Console.WriteLine(@"  FacessoSetup --restore Facesso.bak --setup --conn-str ""..."" --admin-user MyAdmin");
            Console.WriteLine();
            Console.WriteLine("Note: --setup writes to HKLM and requires Administrator privileges.");
        }

        static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"ERROR: {msg}");
            Console.ResetColor();
        }

        static void WriteWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  WARNING: {msg}");
            Console.ResetColor();
        }

        static void WriteSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  OK: {msg}");
            Console.ResetColor();
        }
    }

    internal class BackupFile
    {
        public string LogicalName  { get; set; }
        public string PhysicalName { get; set; }
        public string Type         { get; set; }    // "D" = data file, "L" = log file
    }
}
