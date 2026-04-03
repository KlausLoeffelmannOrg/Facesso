using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace FacAttachSqlBackup
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string backupFile = null;
            string instance   = @".\SQLEXPRESS";
            string dbName     = null;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--help": case "-h": case "/?":
                        PrintUsage();
                        return 0;
                    case "--instance": case "-i":
                        if (i + 1 < args.Length) instance = args[++i];
                        break;
                    case "--db-name": case "-n":
                        if (i + 1 < args.Length) dbName = args[++i];
                        break;
                    default:
                        if (!args[i].StartsWith("-") && backupFile == null)
                            backupFile = args[i];
                        break;
                }
            }

            if (backupFile == null)
            {
                PrintUsage();
                return 1;
            }

            if (!File.Exists(backupFile))
            {
                WriteError($"Backup file not found: {backupFile}");
                return 1;
            }

            backupFile = Path.GetFullPath(backupFile);

            Console.WriteLine("FacAttachSqlBackup - Facesso Database Restore Tool");
            Console.WriteLine("===================================================");
            Console.WriteLine($"Backup file : {backupFile}");
            Console.WriteLine($"SQL instance: {instance}");

            string masterConnStr =
                $"Data Source={instance};Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            try
            {
                using (var conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();

                    string productVersion = QueryScalar(conn, "SELECT SERVERPROPERTY('ProductVersion')");
                    string productLevel   = QueryScalar(conn, "SELECT SERVERPROPERTY('ProductLevel')");
                    string edition        = QueryScalar(conn, "SELECT SERVERPROPERTY('Edition')");
                    Console.WriteLine($"Server      : SQL Server {productVersion} {productLevel}  ({edition})");
                    Console.WriteLine();

                    Console.WriteLine("Reading backup metadata...");
                    string backupDbName = GetBackupDatabaseName(conn, backupFile);
                    var    fileList     = GetBackupFileList(conn, backupFile);

                    if (fileList == null || fileList.Count == 0)
                    {
                        WriteError("Could not read backup file metadata. Is this a valid SQL Server backup?");
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

                    // Forward SQL Server progress messages (STATS output) to the console.
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

                    // Verify it is a Facesso database and check schema version.
                    Console.WriteLine();
                    Console.WriteLine("Verifying database...");
                    string dbConnStr =
                        $"Data Source={instance};Initial Catalog={dbName};Integrated Security=True;Connect Timeout=30;";

                    using (var dbConn = new SqlConnection(dbConnStr))
                    {
                        dbConn.Open();
                        bool isFacesso = IsFacessoDatabase(dbConn);

                        if (!isFacesso)
                        {
                            WriteWarning(
                                "The restored database does not appear to be a Facesso database.");
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
            catch (SqlException ex)
            {
                WriteError($"SQL Server error ({ex.Number}): {ex.Message}");
                return 1;
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
                return 1;
            }
        }

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
                {
                    while (r.Read())
                        result.Add(new BackupFile
                        {
                            LogicalName  = r["LogicalName"].ToString(),
                            PhysicalName = r["PhysicalName"].ToString(),
                            Type         = r["Type"].ToString()          // "D" = data, "L" = log
                        });
                }
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
                    // Log file: dbName_log.ldf, dbName_log1.ldf, ...
                    string suffix = logIdx == 0 ? "_log.ldf" : $"_log{logIdx}.ldf";
                    destPath = Path.Combine(dataDir, dbName + suffix);
                    logIdx++;
                }
                else
                {
                    // Data file: dbName.mdf, dbName_1.ndf, dbName_2.ndf, ...
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
            // Must find at least 4 of these 5 key tables.
            string[] tables = { "TimeLog", "Employees", "WorkGroups", "ProductionData", "Subsidiaries" };
            int found = 0;
            foreach (var t in tables)
                if (TableExists(conn, t)) found++;
            return found >= 4;
        }

        // The DatenModelUpdater (FacessoData project) adds [EmployeeHandicaps].
        // If missing, the database has not been updated to the latest schema.
        static bool NeedsSchemaUpdate(SqlConnection conn) =>
            !TableExists(conn, "EmployeeHandicaps");

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
            Console.WriteLine("FacAttachSqlBackup - Restores a SQL Server backup and verifies it is a Facesso database.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  FacAttachSqlBackup <backup_file.bak> [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --instance, -i <name>    SQL Server instance  (default: .\\SQLEXPRESS)");
            Console.WriteLine("  --db-name, -n <name>     Target database name (default: taken from backup)");
            Console.WriteLine("  --help, -h               Show this help");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  FacAttachSqlBackup C:\\Backups\\Facesso.bak");
            Console.WriteLine("  FacAttachSqlBackup Facesso.bak --instance .\\SQLEXPRESS");
            Console.WriteLine("  FacAttachSqlBackup Facesso.bak --instance (localdb)\\MSSQLLocalDB --db-name FacessoProd");
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
