using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace FacessoSetup
{
    internal partial class Program
    {
        static int RunRestore(string backupFile, string instance, ref string dbName, string connStr)
        {
            // Don't validate the file locally — the path is from SQL Server's perspective,
            // which may be inside a Docker container or on a remote machine.
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
                    var fileList = GetBackupFileList(conn, backupFile);

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

                    var moveList = BuildMoveClauses(fileList, dbName, dataDir);
                    string restoreSql = BuildRestoreSql(backupFile, dbName, moveList);

                    Console.WriteLine("Switching target database to exclusive access...");
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
                        ExecuteNonQueryLogged(cmd);
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
            catch (SqlException ex) { WriteException($"SQL Server error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Restore error", ex); return 1; }
        }

        static string GetBackupDatabaseName(SqlConnection conn, string backupFile)
        {
            using (var cmd = new SqlCommand(
                $"RESTORE HEADERONLY FROM DISK = N'{EscSql(backupFile)}'", conn))
            {
                cmd.CommandTimeout = 60;
                using (var reader = ExecuteReaderLogged(cmd))
                {
                    if (reader.Read())
                    {
                        int index = reader.GetOrdinal("DatabaseName");
                        return reader.IsDBNull(index) ? null : reader.GetString(index);
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
                using (var reader = ExecuteReaderLogged(cmd))
                {
                    while (reader.Read())
                    {
                        result.Add(new BackupFile
                        {
                            LogicalName = reader["LogicalName"].ToString(),
                            PhysicalName = reader["PhysicalName"].ToString(),
                            Type = reader["Type"].ToString()
                        });
                    }
                }
            }

            return result;
        }

        static string GetDefaultDataPath(SqlConnection conn)
        {
            string path = QueryScalar(conn, "SELECT SERVERPROPERTY('InstanceDefaultDataPath')");
            if (!string.IsNullOrWhiteSpace(path))
                return path.TrimEnd('\\', '/');

            path = QueryScalar(conn,
                "SELECT physical_name FROM sys.master_files WHERE database_id = 1 AND file_id = 1");
            return string.IsNullOrEmpty(path) ? null : Path.GetDirectoryName(path);
        }

        static string FindLatestDemoBackup(string searchRoot)
        {
            if (string.IsNullOrWhiteSpace(searchRoot) || !Directory.Exists(searchRoot))
                return null;

            try
            {
                return new DirectoryInfo(searchRoot)
                    .EnumerateFiles("*-demo-backup-*.bak", SearchOption.AllDirectories)
                    .OrderByDescending(file => file.LastWriteTimeUtc)
                    .ThenByDescending(file => file.FullName, StringComparer.OrdinalIgnoreCase)
                    .Select(file => file.FullName)
                    .FirstOrDefault();
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
            catch (IOException)
            {
                return null;
            }
        }

        static List<(string Logical, string Physical)> BuildMoveClauses(
            List<BackupFile> files, string dbName, string dataDir)
        {
            var result = new List<(string, string)>();
            int dataIdx = 0;
            int logIdx = 0;

            foreach (var file in files)
            {
                string destPath;
                if (file.Type == "L")
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

                result.Add((file.LogicalName, destPath));
            }

            return result;
        }

        static string BuildRestoreSql(
            string backupFile, string dbName,
            List<(string Logical, string Physical)> moves)
        {
            string safeDbName = dbName.Replace("]", "]]");
            var sb = new StringBuilder();
            sb.AppendLine("SET NOCOUNT ON;");
            sb.AppendLine("BEGIN TRY");
            sb.AppendLine($"    IF DB_ID(N'{EscSql(dbName)}') IS NOT NULL");
            sb.AppendLine($"        ALTER DATABASE [{safeDbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");
            sb.Append($"    RESTORE DATABASE [{safeDbName}]");
            sb.Append($" FROM DISK = N'{EscSql(backupFile)}'");
            sb.Append(" WITH ");
            foreach (var (logical, physical) in moves)
                sb.Append($"MOVE N'{EscSql(logical)}' TO N'{EscSql(physical)}', ");
            sb.AppendLine("REPLACE, STATS = 10;");
            sb.AppendLine($"    ALTER DATABASE [{safeDbName}] SET MULTI_USER;");
            sb.AppendLine("END TRY");
            sb.AppendLine("BEGIN CATCH");
            sb.AppendLine($"    IF DB_ID(N'{EscSql(dbName)}') IS NOT NULL");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("        BEGIN TRY");
            sb.AppendLine($"            ALTER DATABASE [{safeDbName}] SET MULTI_USER;");
            sb.AppendLine("        END TRY");
            sb.AppendLine("        BEGIN CATCH");
            sb.AppendLine("        END CATCH");
            sb.AppendLine("    END");
            sb.AppendLine("    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();");
            sb.AppendLine("    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();");
            sb.AppendLine("    DECLARE @ErrorState INT = ERROR_STATE();");
            sb.AppendLine("    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);");
            sb.Append("END CATCH");
            return sb.ToString();
        }
    }
}
