using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;

namespace FacSqlInfo
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0 && (args[0] == "--help" || args[0] == "-h" || args[0] == "/?"))
            {
                PrintUsage();
                return 0;
            }

            Console.WriteLine("FacSqlInfo - Facesso SQL Server Information Tool");
            Console.WriteLine("================================================");
            Console.WriteLine();

            Console.WriteLine("Discovering SQL Server instances...");
            var instances = DiscoverInstances();
            Console.WriteLine($"Found {instances.Count} candidate instance(s). Probing...");
            Console.WriteLine();

            bool anyConnected = false;
            foreach (var inst in instances)
            {
                if (ProbeInstance(inst))
                    anyConnected = true;
            }

            if (!anyConnected)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Could not connect to any SQL Server instance.");
                Console.ResetColor();
                return 1;
            }

            return 0;
        }

        // -------------------------------------------------------------------------
        //  Instance discovery
        // -------------------------------------------------------------------------

        static List<string> DiscoverInstances()
        {
            var seen   = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var result = new List<string>();

            void Add(string s)
            {
                if (!string.IsNullOrWhiteSpace(s) && seen.Add(s.Trim()))
                    result.Add(s.Trim());
            }

            // 1. Registry: instances registered by SQL Server setup (both 64-bit and WOW64 views).
            foreach (var keyPath in new[]
            {
                @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL",
                @"SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server\Instance Names\SQL"
            })
            {
                try
                {
                    using (var key = Registry.LocalMachine.OpenSubKey(keyPath))
                    {
                        if (key == null) continue;
                        foreach (var name in key.GetValueNames())
                        {
                            // The default instance is named "MSSQLSERVER"; connect to it via "."
                            if (name.Equals("MSSQLSERVER", StringComparison.OrdinalIgnoreCase))
                                Add(".");
                            else
                                Add($@".\{name}");
                        }
                    }
                }
                catch { /* registry access denied or key missing */ }
            }

            // 2. LocalDB instances via sqllocaldb.exe (suppressed if tool absent).
            try
            {
                var psi = new ProcessStartInfo("sqllocaldb", "info")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute        = false,
                    CreateNoWindow         = true
                };
                using (var p = Process.Start(psi))
                {
                    p.WaitForExit(3000);
                    foreach (var line in p.StandardOutput
                        .ReadToEnd()
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            Add($@"(localdb)\{line.Trim()}");
                    }
                }
            }
            catch { /* sqllocaldb not installed or not on PATH */ }

            // 3. Common well-known defaults - ensures these are tried even if registry is empty.
            foreach (var inst in new[] { @".\SQLEXPRESS", @"(localdb)\MSSQLLocalDB", @"(localdb)\v11.0", "." })
                Add(inst);

            return result;
        }

        // -------------------------------------------------------------------------
        //  Instance inspection
        // -------------------------------------------------------------------------

        static bool ProbeInstance(string instance)
        {
            string connStr =
                $"Data Source={instance};Initial Catalog=master;Integrated Security=True;Connect Timeout=5;";

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string productVersion = QueryScalar(conn, "SELECT SERVERPROPERTY('ProductVersion')");
                    string productLevel   = QueryScalar(conn, "SELECT SERVERPROPERTY('ProductLevel')");
                    string edition        = QueryScalar(conn, "SELECT SERVERPROPERTY('Edition')");
                    string serverName     = QueryScalar(conn, "SELECT SERVERPROPERTY('ServerName')");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Instance : {instance}  ({serverName})");
                    Console.ResetColor();
                    Console.WriteLine($"  Version: {productVersion} {productLevel}");
                    Console.WriteLine($"  Edition: {edition}");

                    var databases = ListUserDatabases(conn);
                    Console.WriteLine($"  Databases ({databases.Count} user database(s)):");

                    if (databases.Count == 0)
                    {
                        Console.WriteLine("    (none)");
                    }
                    else
                    {
                        foreach (var db in databases)
                            InspectDatabase(instance, db);
                    }

                    Console.WriteLine();
                    return true;
                }
            }
            catch
            {
                // Instance not reachable - silently skip.
                return false;
            }
        }

        static List<string> ListUserDatabases(SqlConnection conn)
        {
            var list = new List<string>();
            using (var cmd = new SqlCommand(
                "SELECT name FROM sys.databases " +
                "WHERE state_desc = 'ONLINE' " +
                "  AND name NOT IN ('master', 'tempdb', 'model', 'msdb') " +
                "ORDER BY name", conn))
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    list.Add(r.GetString(0));
            return list;
        }

        // -------------------------------------------------------------------------
        //  Database inspection
        // -------------------------------------------------------------------------

        static void InspectDatabase(string instance, string dbName)
        {
            string connStr =
                $"Data Source={instance};Initial Catalog={dbName};Integrated Security=True;Connect Timeout=5;";
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (IsFacessoDatabase(conn))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    [{dbName}]  ** Facesso Database **");
                        Console.ResetColor();
                        PrintFacessoStats(conn, dbName);
                    }
                    else
                    {
                        Console.WriteLine($"    [{dbName}]");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    [{dbName}]  (error: {ex.Message})");
            }
        }

        static bool IsFacessoDatabase(SqlConnection conn)
        {
            // Recognise a Facesso database by the presence of its key tables.
            string[] required = { "TimeLog", "Employees", "WorkGroups", "ProductionData", "Subsidiaries" };
            return required.Count(t => TableExists(conn, t)) >= 4;
        }

        static void PrintFacessoStats(SqlConnection conn, string dbName)
        {
            // --- Database creation date ---
            string created = QueryScalar(conn,
                $"SELECT create_date FROM sys.databases WHERE name = N'{EscSql(dbName)}'");
            if (created != null && DateTime.TryParse(created, out var createdDt))
                Console.WriteLine($"      Created              : {createdDt:yyyy-MM-dd HH:mm}");

            // --- TimeLog ---
            if (TableExists(conn, "TimeLog"))
            {
                try
                {
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*), MIN([ProductionDate]), MAX([ProductionDate]) " +
                        "FROM [dbo].[TimeLog]", conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            long count = r.IsDBNull(0) ? 0L : r.GetInt32(0);
                            Console.WriteLine($"      Time items           : {count:N0}");
                            if (count > 0 && !r.IsDBNull(1))
                            {
                                Console.WriteLine($"        First production   : {r.GetDateTime(1):yyyy-MM-dd}");
                                Console.WriteLine($"        Last production    : {r.GetDateTime(2):yyyy-MM-dd}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"      Time items           : (query error: {ex.Message})");
                }
            }

            // --- ProductionData ---
            if (TableExists(conn, "ProductionData"))
            {
                try
                {
                    string count = QueryScalar(conn, "SELECT COUNT(*) FROM [dbo].[ProductionData]");
                    Console.WriteLine($"      Production data items: {long.Parse(count):N0}");
                }
                catch { }
            }

            // --- WorkGroups with LabourValue counts ---
            if (TableExists(conn, "WorkGroups"))
            {
                try
                {
                    string totalWg = QueryScalar(conn, "SELECT COUNT(*) FROM [dbo].[WorkGroups]");
                    Console.WriteLine($"      Work groups          : {long.Parse(totalWg):N0}");

                    // Show each workgroup with the count of distinct LabourValues it has used
                    // in ProductionDataItems (WorkGroups → ProductionData → ProductionDataItems → LabourValues).
                    if (TableExists(conn, "ProductionData") && TableExists(conn, "ProductionDataItems"))
                    {
                        const string wgSql =
                            "SELECT wg.[WorkgroupName], " +
                            "       COUNT(DISTINCT pdi.[IDLabourValue]) AS LabourValueCount " +
                            "FROM [dbo].[WorkGroups] wg " +
                            "LEFT JOIN [dbo].[ProductionData] pd " +
                            "  ON pd.[IDSubsidiary] = wg.[IDSubsidiary] " +
                            " AND pd.[IDWorkGroup]  = wg.[IDWorkGroup] " +
                            "LEFT JOIN [dbo].[ProductionDataItems] pdi " +
                            "  ON pdi.[IDSubsidiary]    = pd.[IDSubsidiary] " +
                            " AND pdi.[IDProductionData] = pd.[IDProductionData] " +
                            "GROUP BY wg.[IDWorkGroup], wg.[WorkgroupName] " +
                            "ORDER BY wg.[WorkgroupName]";

                        using (var cmd = new SqlCommand(wgSql, conn))
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string wgName = r.GetString(0);
                                int    lvCnt  = r.GetInt32(1);
                                Console.WriteLine($"        - {wgName}: {lvCnt} work value(s)");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"      Work groups          : (query error: {ex.Message})");
                }
            }

            // --- Schema update check (DatenModelUpdater) ---
            // The Facesso DatenModelUpdater adds [dbo].[EmployeeHandicaps].
            // If the table is absent the database needs updating.
            if (!TableExists(conn, "EmployeeHandicaps"))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("      !! Schema update required: [dbo].[EmployeeHandicaps] table is missing.");
                Console.WriteLine("         Run the Facesso DatenModelUpdater to apply the latest schema changes.");
                Console.ResetColor();
            }
        }

        // -------------------------------------------------------------------------
        //  Generic SQL helpers
        // -------------------------------------------------------------------------

        static bool TableExists(SqlConnection conn, string tableName)
        {
            using (var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM sys.objects " +
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
        //  Help
        // -------------------------------------------------------------------------

        static void PrintUsage()
        {
            Console.WriteLine("FacSqlInfo - Checks local SQL Server instances for Facesso databases.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  FacSqlInfo [--help]");
            Console.WriteLine();
            Console.WriteLine("The tool auto-discovers SQL Server instances via:");
            Console.WriteLine("  - Windows registry (all installed named/default instances)");
            Console.WriteLine("  - sqllocaldb.exe  (all LocalDB instances)");
            Console.WriteLine("  - Common defaults (SQLEXPRESS, MSSQLLocalDB, ...)");
            Console.WriteLine();
            Console.WriteLine("For every reachable instance it reports:");
            Console.WriteLine("  - SQL Server version and edition");
            Console.WriteLine("  - All user databases");
            Console.WriteLine("  - For Facesso databases:");
            Console.WriteLine("      * Database creation date");
            Console.WriteLine("      * Time items: count, first/last production date");
            Console.WriteLine("      * Production data items: count");
            Console.WriteLine("      * Work groups: count and work values (LabourValues) used per group");
            Console.WriteLine("      * Schema update status (DatenModelUpdater / EmployeeHandicaps table)");
        }
    }
}
