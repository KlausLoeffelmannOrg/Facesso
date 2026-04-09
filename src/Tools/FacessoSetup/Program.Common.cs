using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace FacessoSetup
{
    internal partial class Program
    {
        static readonly object LogSync = new object();
        static string currentLogFilePath;
        static bool unhandledExceptionLoggingRegistered;

        static void InitializeLogging()
        {
            if (!string.IsNullOrWhiteSpace(currentLogFilePath))
                return;

            try
            {
                string executablePath = Assembly.GetExecutingAssembly().Location;
                string baseDirectory = Path.GetDirectoryName(executablePath);
                string logDirectory = Path.Combine(
                    baseDirectory ?? Environment.CurrentDirectory,
                    "Log files",
                    DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

                Directory.CreateDirectory(logDirectory);

                currentLogFilePath = Path.Combine(
                    logDirectory,
                    $"FacessoSetup-{DateTime.Now:yyyyMMdd-HHmmss}.log");

                var details = new StringBuilder();
                details.AppendLine("FacessoSetup diagnostic log");
                details.AppendLine($"Started           : {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
                details.AppendLine($"Executable        : {executablePath}");
                details.AppendLine($"Current directory : {Environment.CurrentDirectory}");
                details.AppendLine($"Machine           : {Environment.MachineName}");
                details.AppendLine($"User              : {Environment.UserDomainName}\\{Environment.UserName}");
                details.AppendLine($"OS                : {Environment.OSVersion}");
                details.AppendLine($".NET runtime      : {Environment.Version}");
                details.AppendLine($"Command line      : {Environment.CommandLine}");

                AppendLogBlock("SESSION START", details.ToString());

                if (!unhandledExceptionLoggingRegistered)
                {
                    AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                    {
                        string text = args.ExceptionObject is Exception ex
                            ? ex.ToString()
                            : Convert.ToString(args.ExceptionObject, CultureInfo.InvariantCulture) ?? "(null)";

                        AppendLogBlock(
                            args.IsTerminating ? "UNHANDLED EXCEPTION (terminating)" : "UNHANDLED EXCEPTION",
                            text);
                    };
                    unhandledExceptionLoggingRegistered = true;
                }
            }
            catch
            {
                // Logging must never block the main operation.
                currentLogFilePath = null;
            }
        }

        static void AppendLogBlock(string title, string details)
        {
            if (string.IsNullOrWhiteSpace(currentLogFilePath))
                return;

            try
            {
                lock (LogSync)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(new string('=', 80));
                    sb.AppendLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {title}");
                    if (!string.IsNullOrWhiteSpace(details))
                        sb.AppendLine(details.TrimEnd());
                    sb.AppendLine();

                    File.AppendAllText(currentLogFilePath, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                // Best-effort diagnostic logging only.
            }
        }

        static void AttachSqlContext(Exception ex, SqlCommand cmd)
        {
            if (ex == null || cmd == null)
                return;

            try
            {
                if (!ex.Data.Contains("SqlCommandDetails"))
                    ex.Data["SqlCommandDetails"] = FormatSqlCommandDetails(cmd);
            }
            catch
            {
                // Ignore diagnostic enrichment issues.
            }
        }

        static string FormatSqlCommandDetails(SqlCommand cmd)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Data source : {cmd.Connection?.DataSource ?? "(unknown)"}");
            sb.AppendLine($"Database    : {cmd.Connection?.Database ?? "(unknown)"}");
            sb.AppendLine($"CommandType : {cmd.CommandType}");
            sb.AppendLine($"Timeout     : {cmd.CommandTimeout}");
            sb.AppendLine($"Transaction : {(cmd.Transaction == null ? "none" : "present")}");
            sb.AppendLine("CommandText :");
            sb.AppendLine(cmd.CommandText ?? string.Empty);

            if (cmd.Parameters.Count > 0)
            {
                sb.AppendLine("Parameters  :");
                foreach (SqlParameter parameter in cmd.Parameters)
                {
                    string valueText = FormatSqlParameterValue(parameter.ParameterName, parameter.Value);
                    sb.AppendLine($"  {parameter.ParameterName} = {valueText}");
                }
            }

            return sb.ToString();
        }

        static string FormatSqlParameterValue(string parameterName, object value)
        {
            if (value == null || value == DBNull.Value)
                return "NULL";

            if (IsSensitiveParameterName(parameterName))
                return "<redacted>";

            if (value is byte[] bytes)
                return $"<byte[{bytes.Length}]>";

            if (value is DateTime dateTime)
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            if (value is DateTimeOffset dateTimeOffset)
                return dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss.fff zzz", CultureInfo.InvariantCulture);

            string text = Convert.ToString(value, CultureInfo.InvariantCulture) ?? value.ToString();
            return "\"" + Truncate(text?.Replace("\r", "\\r").Replace("\n", "\\n"), 400) + "\"";
        }

        static bool IsSensitiveParameterName(string parameterName)
        {
            string normalized = (parameterName ?? string.Empty)
                .Replace("@", string.Empty)
                .Replace("_", string.Empty)
                .ToLowerInvariant();

            return normalized.Contains("password") ||
                   normalized.Contains("pwd") ||
                   normalized == "pw" ||
                   normalized.EndsWith("pw", StringComparison.Ordinal) ||
                   normalized.Contains("secret") ||
                   normalized.Contains("hash");
        }

        static bool TryGetSqlDetails(Exception ex, out string details)
        {
            details = null;
            var collected = new StringBuilder();
            var seen = new HashSet<string>(StringComparer.Ordinal);

            for (Exception current = ex; current != null; current = current.InnerException)
            {
                if (current.Data == null || !current.Data.Contains("SqlCommandDetails"))
                    continue;

                string sqlDetails = current.Data["SqlCommandDetails"] as string;
                if (string.IsNullOrWhiteSpace(sqlDetails) || !seen.Add(sqlDetails))
                    continue;

                if (collected.Length > 0)
                    collected.AppendLine().AppendLine(new string('-', 80));

                collected.Append(sqlDetails.TrimEnd());
            }

            if (collected.Length == 0)
                return false;

            details = collected.ToString();
            return true;
        }

        static int ExecuteNonQueryLogged(SqlCommand cmd)
        {
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AttachSqlContext(ex, cmd);
                throw;
            }
        }

        static object ExecuteScalarLogged(SqlCommand cmd)
        {
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                AttachSqlContext(ex, cmd);
                throw;
            }
        }

        static SqlDataReader ExecuteReaderLogged(SqlCommand cmd)
        {
            try
            {
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                AttachSqlContext(ex, cmd);
                throw;
            }
        }

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

        static string BuildConnStr(string instance, string dbName) =>
            $"Data Source={instance};Initial Catalog={dbName};Integrated Security=True;Connect Timeout=30;";

        static bool TryPromptNewPassword(string prompt, string operationName, out string password)
        {
            password = PromptPassword($"{prompt} (min. 6 chars): ");
            if (password == null)
            {
                WriteError($"{operationName} cancelled.");
                return false;
            }

            string confirm = PromptPassword("Confirm password: ");
            if (confirm == null)
            {
                WriteError($"{operationName} cancelled.");
                return false;
            }

            if (password != confirm)
            {
                WriteError("Passwords do not match. Operation aborted.");
                return false;
            }

            if (password.Length < 6)
            {
                WriteError("Password must be at least 6 characters.");
                return false;
            }

            return true;
        }

        static bool TryReadOptionValue(string[] args, ref int i, string optionName, out string value, bool allowValueStartingWithDash = false)
        {
            value = null;
            if (i + 1 >= args.Length ||
                (!allowValueStartingWithDash && args[i + 1].StartsWith("-", StringComparison.Ordinal)))
            {
                WriteError($"{optionName} requires a value.");
                return false;
            }

            value = args[++i];
            return true;
        }

        static bool TryParseYesNoValue(string input, out bool value)
        {
            switch ((input ?? string.Empty).Trim().ToLowerInvariant())
            {
                case "y":
                case "yes":
                case "j":
                case "true":
                case "1":
                case "on":
                    value = true;
                    return true;

                case "n":
                case "no":
                case "false":
                case "0":
                case "off":
                    value = false;
                    return true;

                default:
                    value = false;
                    return false;
            }
        }

        static bool IsFacessoDatabase(SqlConnection conn)
        {
            string[] tables = { "TimeLog", "Employees", "WorkGroups", "ProductionData", "Subsidiaries" };
            int found = 0;
            foreach (string table in tables)
                if (TableExists(conn, table)) found++;

            return found >= 4;
        }

        static bool NeedsSchemaUpdate(SqlConnection conn) => !TableExists(conn, "EmployeeHandicaps");

        static bool TableExists(SqlConnection conn, string tableName, SqlTransaction tx = null)
        {
            using (var cmd = new SqlCommand(
                $"SELECT COUNT(1) FROM sys.objects " +
                $"WHERE object_id = OBJECT_ID(N'[dbo].[{tableName}]') AND type = N'U'", conn, tx))
                return Convert.ToInt32(ExecuteScalarLogged(cmd), CultureInfo.InvariantCulture) > 0;
        }

        static string QueryScalar(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                var value = ExecuteScalarLogged(cmd);
                return (value == null || value == DBNull.Value) ? null : Convert.ToString(value, CultureInfo.InvariantCulture);
            }
        }

        static object GetRecordValue(IDataRecord record, string columnName)
        {
            int ordinal = record.GetOrdinal(columnName);
            return record.IsDBNull(ordinal) ? null : record.GetValue(ordinal);
        }

        static string GetStringValue(IDataRecord record, string columnName, string defaultValue = "")
        {
            object value = GetRecordValue(record, columnName);
            return value == null ? defaultValue : (Convert.ToString(value, CultureInfo.InvariantCulture) ?? defaultValue);
        }

        static Guid GetGuidValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            if (value is Guid guid)
                return guid;

            if (value is byte[] bytes && bytes.Length == 16)
                return new Guid(bytes);

            string text = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (Guid.TryParse(text, out guid))
                return guid;

            throw new InvalidCastException($"Column '{columnName}' with value '{text}' cannot be converted to Guid.");
        }

        static object GetIdentifierValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            if (value is byte[] bytes && bytes.Length == 16)
                return new Guid(bytes);

            return value;
        }

        static object GetNullableIdentifierValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                return null;

            if (value is byte[] bytes && bytes.Length == 16)
                return new Guid(bytes);

            return value;
        }

        static Guid? GetNullableGuidValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                return null;

            if (value is Guid guid)
                return guid;

            if (value is byte[] bytes && bytes.Length == 16)
                return new Guid(bytes);

            string text = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (Guid.TryParse(text, out guid))
                return guid;

            throw new InvalidCastException($"Column '{columnName}' with value '{text}' cannot be converted to Guid.");
        }

        static DateTime GetDateTimeValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            if (value is DateTime dateTime)
                return dateTime;

            if (value is DateTimeOffset dateTimeOffset)
                return dateTimeOffset.DateTime;

            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        static DateTime? GetNullableDateTimeValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                return null;

            if (value is DateTime dateTime)
                return dateTime;

            if (value is DateTimeOffset dateTimeOffset)
                return dateTimeOffset.DateTime;

            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        static byte GetByteValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }

        static int GetInt32Value(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        static double GetDoubleValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            if (value == null)
                throw new InvalidOperationException($"Column '{columnName}' was null.");

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        static double? GetNullableDoubleValue(IDataRecord record, string columnName)
        {
            object value = GetRecordValue(record, columnName);
            return value == null ? (double?)null : Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        static SqlParameter AddParameterValue(SqlParameterCollection parameters, string name, object value)
        {
            var parameter = parameters.AddWithValue(name, value ?? DBNull.Value);
            if (value == null)
                parameter.Value = DBNull.Value;

            return parameter;
        }

        static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
                return value ?? string.Empty;

            return value.Substring(0, Math.Max(0, maxLength - 3)) + "...";
        }

        static string EscSql(string s) => s?.Replace("'", "''");

        static void PrintUsage()
        {
            Console.WriteLine("FacessoSetup — Facesso Database Restore, Backup & Registry Setup Tool");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  FacessoSetup [operations] [options]");
            Console.WriteLine();
            Console.WriteLine("Operations / actions (at least one required; when combined, restore runs first):");
            Console.WriteLine("  --restore <backup.bak>, -r   Restore a SQL Server backup file");
            Console.WriteLine("  --restore-last-demo-backup   Restore the newest '*-demo-backup-*.bak'");
            Console.WriteLine("                               found below the current directory");
            Console.WriteLine("  --RestoreCompressedDb <file> <destPath>");
            Console.WriteLine("                               Extract a ZIP-compressed .bak and restore it");
            Console.WriteLine("  --ExtractDb <file> <destPath>");
            Console.WriteLine("                               Extract a ZIP-compressed .bak (no restore)");
            Console.WriteLine("  --Backup <bakPath>           Close all connections, rollback pending");
            Console.WriteLine("                               transactions, and back up the database.");
            Console.WriteLine("                               Supports {datetime-format} tokens in the path,");
            Console.WriteLine("                               e.g. Facesso-{yyyy-MM-dd-HHmmss}.bak");
            Console.WriteLine("  --DetachDb <dbName>          Close all connections and detach the database");
            Console.WriteLine("    --CopyTo <destPath>        (with --DetachDb) Copy MDF/LDF files after detach");
            Console.WriteLine("  --setup, -s                  Configure registry (universal licence +");
            Console.WriteLine("                               connection string) and set admin password");
            Console.WriteLine("  --list-users                 List current users in the Facesso database");
            Console.WriteLine("  --delete-users               Delete all non-admin, non-system users");
            Console.WriteLine("  --remove-existing-user-admins");
            Console.WriteLine("                               Delete non-system administrator users except");
            Console.WriteLine("                               'Admin' and 'Administrator'");
            Console.WriteLine("  --change-subsidiary-name <name>");
            Console.WriteLine("                               Set a new name for the subsidiary record(s)");
            Console.WriteLine("  --convert-to-demo           Interactively create a backup and convert");
            Console.WriteLine("                               the current Facesso DB into demo data");
            Console.WriteLine("  --add-admin <name>           Prompt for a password and add/promote");
            Console.WriteLine("                               a database administrator user");
            Console.WriteLine("  --add-default-admin          Add 'Admin' user with default password");
            Console.WriteLine("  --silent                     Do not prompt during --convert-to-demo;");
            Console.WriteLine("                               use CLI values or built-in defaults");
            Console.WriteLine();
            Console.WriteLine("Connection / setup options:");
            Console.WriteLine("  --instance, -i <name>        SQL Server instance  (default: .\\SQLEXPRESS)");
            Console.WriteLine("  --db-name, -n <name>         Target / existing database name (default: Facesso)");
            Console.WriteLine("  --conn-str, -c <cs>          Full ADO.NET connection string");
            Console.WriteLine("                               (overrides --instance + --db-name)");
            Console.WriteLine("  --admin-user <name>          Admin username for --setup  (default: Administrator)");
            Console.WriteLine("  --admin-password <pwd>       Admin password for --setup / --add-admin");
            Console.WriteLine("                               (skips interactive prompt)");
            Console.WriteLine("  --demo-time-offset <+/-h:mm> Override the demo conversion time offset");
            Console.WriteLine("  --demo-jitter-seconds <n>    Override the demo conversion jitter in seconds");
            Console.WriteLine("  --demo-target-date <date>    Override the target last booking day (yyyy-mm-dd)");
            Console.WriteLine("  --demo-subsidiary-name <name>");
            Console.WriteLine("                               Override the demo conversion subsidiary name");
            Console.WriteLine("  --demo-regenerate-users <yes|no>");
            Console.WriteLine("                               Control employee/user anonymization");
            Console.WriteLine("  --demo-regenerate-workgroups <yes|no>");
            Console.WriteLine("                               Control workgroup/labour-value renaming");
            Console.WriteLine("  --help, -h                   Show this help");
            Console.WriteLine();
            Console.WriteLine("Default connection string (when neither --instance nor --conn-str is given):");
            Console.WriteLine("  Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;");
            Console.WriteLine("  Database: Facesso");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(@"  FacessoSetup --restore C:\Backups\Facesso.bak");
            Console.WriteLine(@"  FacessoSetup --setup --conn-str ""Data Source=.\SQLEXPRESS;Initial Catalog=Facesso;Integrated Security=True""");
            Console.WriteLine(@"  FacessoSetup --restore Facesso.bak --setup --instance .\SQLEXPRESS --db-name Facesso");
            Console.WriteLine(@"  FacessoSetup --restore Facesso.bak --setup --conn-str ""..."" --admin-user MyAdmin");
            Console.WriteLine(@"  FacessoSetup --remove-existing-user-admins --delete-users --db-name Facesso");
            Console.WriteLine(@"  FacessoSetup --change-subsidiary-name ""SampleCompany Ltd."" --list-users");
            Console.WriteLine(@"  FacessoSetup --add-admin MyAdmin --db-name Facesso");
            Console.WriteLine(@"  FacessoSetup --convert-to-demo --conn-str ""Data Source=.\SQLEXPRESS;Initial Catalog=Facesso;Integrated Security=True""");
            Console.WriteLine(@"  FacessoSetup --convert-to-demo --silent --demo-time-offset +0:15 --demo-jitter-seconds 30 --demo-target-date 2026-04-01");
            Console.WriteLine(@"  FacessoSetup --restore-last-demo-backup --instance .\SQLEXPRESS");
            Console.WriteLine();
            Console.WriteLine("  Container / MSBench scenarios (use default SQL auth connection):");
            Console.WriteLine(@"  FacessoSetup --RestoreCompressedDb C:\backups\Facesso-demo.zip C:\backups");
            Console.WriteLine(@"  FacessoSetup --ExtractDb C:\backups\Facesso-demo.zip C:\temp\extracted");
            Console.WriteLine(@"  FacessoSetup --Backup ""C:\output\DBBackup\Facesso-{yyyy-MM-dd-HHmmss}.bak""");
            Console.WriteLine(@"  FacessoSetup --DetachDb Facesso --CopyTo C:\output\detached");
            Console.WriteLine(@"  FacessoSetup --Backup ""C:\output\Facesso-{yyyy-MM-dd-HHmmss}.bak"" --restore C:\backups\Facesso-demo.bak --setup --add-default-admin");
            Console.WriteLine();
            Console.WriteLine("Note: --setup writes to HKLM and requires Administrator privileges.");
            Console.WriteLine(@"PowerShell note: when running the local build from the current directory, use .\FacessoSetup.exe ...");
            Console.WriteLine(@"Diagnostics: detailed run/error logs are written below .\Log files\yyyy-MM-dd\");
        }

        static void PrintExecutionContext()
        {
            InitializeLogging();

            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "(unknown)";
            string executablePath = Assembly.GetExecutingAssembly().Location;
            string buildTime = File.Exists(executablePath)
                ? File.GetLastWriteTime(executablePath).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                : "(unknown)";

            Console.WriteLine($"Executable : {executablePath}");
            Console.WriteLine($"Version    : {version}");
            Console.WriteLine($"Built      : {buildTime}");
            if (!string.IsNullOrWhiteSpace(currentLogFilePath))
                Console.WriteLine($"Log file   : {currentLogFilePath}");
            Console.WriteLine();
        }

        static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"ERROR: {msg}");
            Console.ResetColor();
            AppendLogBlock("ERROR", msg);
        }

        static void WriteException(string message, Exception ex)
        {
            WriteError($"{message}: {ex.Message}");
            if (TryGetSqlDetails(ex, out string sqlDetails))
            {
                Console.Error.WriteLine("SQL COMMAND:");
                Console.Error.WriteLine(sqlDetails);
            }
            Console.Error.WriteLine("STACKTRACE:");
            Console.Error.WriteLine(ex.ToString());
            if (!string.IsNullOrWhiteSpace(currentLogFilePath))
                Console.Error.WriteLine($"DETAIL LOG: {currentLogFilePath}");

            var details = new StringBuilder();
            if (TryGetSqlDetails(ex, out sqlDetails))
            {
                details.AppendLine("SQL COMMAND:");
                details.AppendLine(sqlDetails);
                details.AppendLine();
            }
            details.AppendLine("STACKTRACE:");
            details.AppendLine(ex.ToString());

            AppendLogBlock($"EXCEPTION: {message}", details.ToString());
        }

        static void WriteWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  WARNING: {msg}");
            Console.ResetColor();
            AppendLogBlock("WARNING", msg);
        }

        static void WriteSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  OK: {msg}");
            Console.ResetColor();
            AppendLogBlock("SUCCESS", msg);
        }
    }
}
