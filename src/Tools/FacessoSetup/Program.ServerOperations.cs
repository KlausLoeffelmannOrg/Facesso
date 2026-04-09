using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace FacessoSetup
{
    internal partial class Program
    {
        // Default connection string for container / MSBench scenarios where SQL Server
        // is pre-configured with SQL Authentication on the standard port.
        const string DefaultContainerConnStr =
            "Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;";

        const string DefaultDatabaseName = "Facesso";

        /// <summary>
        /// Resolves a master-level connection string from the supplied CLI values,
        /// falling back to <see cref="DefaultContainerConnStr"/> when nothing is given.
        /// </summary>
        static string ResolveMasterConnStr(string connStr, string instance)
        {
            if (connStr != null)
                return new SqlConnectionStringBuilder(connStr) { InitialCatalog = "master" }.ConnectionString;

            if (instance != null)
                return BuildConnStr(instance, "master");

            return new SqlConnectionStringBuilder(DefaultContainerConnStr) { InitialCatalog = "master" }.ConnectionString;
        }

        /// <summary>
        /// Resolves a database-level connection string from the supplied CLI values,
        /// falling back to <see cref="DefaultContainerConnStr"/> + <see cref="DefaultDatabaseName"/>.
        /// </summary>
        static string ResolveDatabaseConnStr(string connStr, string instance, string dbName)
        {
            if (connStr != null)
            {
                var builder = new SqlConnectionStringBuilder(connStr);
                if (string.IsNullOrEmpty(builder.InitialCatalog))
                    builder.InitialCatalog = dbName ?? DefaultDatabaseName;
                return builder.ConnectionString;
            }

            if (instance != null)
                return BuildConnStr(instance, dbName ?? DefaultDatabaseName);

            return new SqlConnectionStringBuilder(DefaultContainerConnStr)
            {
                InitialCatalog = dbName ?? DefaultDatabaseName
            }.ConnectionString;
        }

        // ──────────────────────────────────────────────────────────────────
        //  --ExtractDb
        // ──────────────────────────────────────────────────────────────────

        static int RunExtractDb(string compressedFile, string destinationPath)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Extract Compressed Database");
            Console.WriteLine("==========================================");

            try
            {
                string extractedBak = ExtractCompressedBackup(compressedFile, destinationPath);
                if (extractedBak == null) return 1;

                WriteSuccess($"Extracted to: {extractedBak}");
                return 0;
            }
            catch (Exception ex) { WriteException("Extraction error", ex); return 1; }
        }

        // ──────────────────────────────────────────────────────────────────
        //  --RestoreCompressedDb
        // ──────────────────────────────────────────────────────────────────

        static int RunRestoreCompressedDb(
            string compressedFile, string destinationPath,
            string instance, ref string dbName, string connStr)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Restore Compressed Database");
            Console.WriteLine("==========================================");

            try
            {
                string extractedBak = ExtractCompressedBackup(compressedFile, destinationPath);
                if (extractedBak == null) return 1;

                Console.WriteLine();
                Console.WriteLine("Proceeding to restore the extracted backup...");
                return RunRestore(extractedBak, instance ?? @".\SQLEXPRESS", ref dbName, connStr ?? DefaultContainerConnStr);
            }
            catch (Exception ex) { WriteException("RestoreCompressedDb error", ex); return 1; }
        }

        // ──────────────────────────────────────────────────────────────────
        //  --DetachDb
        // ──────────────────────────────────────────────────────────────────

        static int RunDetachDb(string databaseName, string copyToPath, string connStr, string instance)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Detach Database");
            Console.WriteLine("==============================");
            Console.WriteLine($"Database: {databaseName}");

            string masterConnStr = ResolveMasterConnStr(connStr, instance);

            try
            {
                List<(string PhysicalPath, string Type)> dbFiles;

                using (var conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();

                    // Collect the physical file paths before detaching.
                    dbFiles = GetDatabaseFiles(conn, databaseName);
                    if (dbFiles.Count == 0)
                    {
                        WriteError($"Database '{databaseName}' was not found or has no files.");
                        return 1;
                    }

                    Console.WriteLine($"  Database files ({dbFiles.Count}):");
                    foreach (var (path, type) in dbFiles)
                        Console.WriteLine($"    [{type}] {path}");
                    Console.WriteLine();

                    // Force-close all connections.
                    Console.WriteLine("Setting database to SINGLE_USER (closing all connections)...");
                    string safeName = databaseName.Replace("]", "]]");
                    ExecuteSqlNonQuery(conn,
                        $"IF DB_ID(N'{EscSql(databaseName)}') IS NOT NULL " +
                        $"ALTER DATABASE [{safeName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");

                    Console.WriteLine("Detaching database...");
                    using (var cmd = new SqlCommand("EXEC sp_detach_db @dbname = @db, @skipchecks = 'true'", conn))
                    {
                        cmd.Parameters.AddWithValue("@db", databaseName);
                        cmd.CommandTimeout = 120;
                        ExecuteNonQueryLogged(cmd);
                    }

                    WriteSuccess($"Database '{databaseName}' detached successfully.");
                }

                // Optional file copy after detach.
                if (!string.IsNullOrWhiteSpace(copyToPath))
                {
                    Console.WriteLine();
                    Console.WriteLine($"Copying database files to: {copyToPath}");
                    Directory.CreateDirectory(copyToPath);

                    foreach (var (sourcePath, type) in dbFiles)
                    {
                        if (!File.Exists(sourcePath))
                        {
                            WriteWarning($"  File not found (skipped): {sourcePath}");
                            continue;
                        }

                        string destFile = Path.Combine(copyToPath, Path.GetFileName(sourcePath));
                        Console.WriteLine($"  Copying [{type}] {Path.GetFileName(sourcePath)}...");
                        File.Copy(sourcePath, destFile, overwrite: true);
                    }

                    WriteSuccess("File copy complete.");
                }

                return 0;
            }
            catch (SqlException ex) { WriteException($"SQL Server error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Detach error", ex); return 1; }
        }

        // ──────────────────────────────────────────────────────────────────
        //  --Backup
        // ──────────────────────────────────────────────────────────────────

        static int RunBackupDb(string bakPath, string connStr, string instance, string dbName)
        {
            bakPath = ExpandDateTokens(bakPath);
            string resolvedDbName = dbName ?? DefaultDatabaseName;

            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Backup Database");
            Console.WriteLine("==============================");
            Console.WriteLine($"Database   : {resolvedDbName}");
            Console.WriteLine($"Backup path: {bakPath}");

            string masterConnStr = ResolveMasterConnStr(connStr, instance);

            try
            {
                // Ensure the target directory exists.
                string bakDir = Path.GetDirectoryName(Path.GetFullPath(bakPath));
                if (!string.IsNullOrWhiteSpace(bakDir))
                    Directory.CreateDirectory(bakDir);

                using (var conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();

                    // Verify the database exists.
                    string existsCheck = QueryScalar(conn,
                        $"SELECT DB_ID(N'{EscSql(resolvedDbName)}')");
                    if (existsCheck == null)
                    {
                        WriteError($"Database '{resolvedDbName}' does not exist on this server.");
                        return 1;
                    }

                    // Force-close all connections and rollback pending transactions.
                    string safeName = resolvedDbName.Replace("]", "]]");
                    Console.WriteLine("Setting database to SINGLE_USER (closing all connections)...");
                    ExecuteSqlNonQuery(conn,
                        $"ALTER DATABASE [{safeName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");

                    Console.WriteLine("Performing backup (this may take a while)...");
                    string backupSql =
                        $"BACKUP DATABASE [{safeName}] TO DISK = N'{EscSql(Path.GetFullPath(bakPath))}' " +
                        $"WITH FORMAT, INIT, STATS = 10;";

                    conn.FireInfoMessageEventOnUserErrors = false;
                    conn.InfoMessage += (s, e) =>
                    {
                        foreach (SqlError err in e.Errors)
                            Console.Write($"\r  {err.Message.Trim(),-70}");
                    };

                    using (var cmd = new SqlCommand(backupSql, conn))
                    {
                        cmd.CommandTimeout = 600;
                        ExecuteNonQueryLogged(cmd);
                    }

                    // Return to multi-user mode.
                    Console.WriteLine();
                    Console.WriteLine("Restoring MULTI_USER mode...");
                    ExecuteSqlNonQuery(conn,
                        $"ALTER DATABASE [{safeName}] SET MULTI_USER;");

                    WriteSuccess($"Backup complete: {Path.GetFullPath(bakPath)}");
                }

                return 0;
            }
            catch (SqlException ex) { WriteException($"SQL Server error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Backup error", ex); return 1; }
        }

        // ──────────────────────────────────────────────────────────────────
        //  Helpers
        // ──────────────────────────────────────────────────────────────────

        /// <summary>
        /// Extracts a ZIP-compressed file and locates the .bak inside it.
        /// Returns the full path to the extracted .bak, or null on failure.
        /// </summary>
        static string ExtractCompressedBackup(string compressedFile, string destinationPath)
        {
            compressedFile = Path.GetFullPath(compressedFile);
            destinationPath = Path.GetFullPath(destinationPath);

            Console.WriteLine($"Compressed file : {compressedFile}");
            Console.WriteLine($"Destination     : {destinationPath}");

            if (!File.Exists(compressedFile))
            {
                WriteError($"File not found: {compressedFile}");
                return null;
            }

            Console.WriteLine("Extracting...");
            Directory.CreateDirectory(destinationPath);
            ZipFile.ExtractToDirectory(compressedFile, destinationPath);

            // Find the .bak file(s) inside the extracted contents.
            var bakFiles = Directory.GetFiles(destinationPath, "*.bak", SearchOption.AllDirectories);
            if (bakFiles.Length == 0)
            {
                WriteWarning("No .bak file found inside the archive. Listing extracted files:");
                foreach (string f in Directory.GetFiles(destinationPath, "*", SearchOption.AllDirectories))
                    Console.WriteLine($"  {f}");
                return null;
            }

            if (bakFiles.Length > 1)
            {
                Console.WriteLine($"Multiple .bak files found ({bakFiles.Length}); using the first one.");
                foreach (string f in bakFiles)
                    Console.WriteLine($"  {f}");
            }

            string bakFile = bakFiles[0];
            WriteSuccess($"Extracted backup: {bakFile}");
            return bakFile;
        }

        /// <summary>
        /// Queries sys.master_files for the physical paths of a given database.
        /// </summary>
        static List<(string PhysicalPath, string Type)> GetDatabaseFiles(SqlConnection conn, string databaseName)
        {
            var result = new List<(string, string)>();
            string sql =
                "SELECT physical_name, " +
                "CASE type WHEN 0 THEN 'DATA' WHEN 1 THEN 'LOG' ELSE 'OTHER' END AS file_type " +
                $"FROM sys.master_files WHERE database_id = DB_ID(N'{EscSql(databaseName)}') " +
                "ORDER BY type, file_id";

            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                    result.Add((reader.GetString(0), reader.GetString(1)));
            }

            return result;
        }

        /// <summary>
        /// Expands date/time format tokens enclosed in braces within a path string.
        /// For example, <c>Facesso{yyyy-MM-dd-HHmmss}.bak</c> becomes
        /// <c>Facesso2026-04-09-213000.bak</c>.
        /// </summary>
        static string ExpandDateTokens(string path)
        {
            if (string.IsNullOrEmpty(path) || !path.Contains("{"))
                return path;

            var sb = new StringBuilder(path.Length + 20);
            DateTime now = DateTime.Now;
            int i = 0;

            while (i < path.Length)
            {
                if (path[i] == '{')
                {
                    int close = path.IndexOf('}', i + 1);
                    if (close > i)
                    {
                        string token = path.Substring(i + 1, close - i - 1);
                        try
                        {
                            sb.Append(now.ToString(token, System.Globalization.CultureInfo.InvariantCulture));
                        }
                        catch (FormatException)
                        {
                            // Not a valid date format — keep literal.
                            sb.Append(path, i, close - i + 1);
                        }
                        i = close + 1;
                        continue;
                    }
                }

                sb.Append(path[i]);
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Executes a non-query SQL statement with logging but without parameters.
        /// </summary>
        static void ExecuteSqlNonQuery(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 120;
                ExecuteNonQueryLogged(cmd);
            }
        }
    }
}
