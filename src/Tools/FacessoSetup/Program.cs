using System;
using System.Data.SqlClient;

namespace FacessoSetup
{
    internal partial class Program
    {
        // Universal serial bypasses all hardware and expiry checks (UNIVERSAL_INST_SERIAL_MIT_FOR_TESTING).
        const string UniversalSerial = "{face2407-6913-1068-1111-43002b30bfeb}";
        const string ProgramGuid = "{face2470-bae0-20cd-b579-08002b30bfeb}";
        const long AdminClearance = -1;

        const string RegClasses = @"SOFTWARE\ActiveDev\Facesso\Classes";
        const string RegBase = @"SOFTWARE\ActiveDev\Facesso";
        const string RegIntel = @"SOFTWARE\Intel_lAD\Classes\{face0100-bae0-20cd-b579-08002b30bfeb}";

        static int Main(string[] args)
        {
            string backupFile = null;
            bool doRestore = false;
            bool doSetup = false;
            string instance = @".\SQLEXPRESS";
            string dbName = "Facesso";
            string connStr = null;
            string adminUser = "Administrator";
            string adminPassword = null;
            bool listUsers = false;
            bool deleteUsers = false;
            bool removeExistingUserAdmins = false;
            bool doConvertToDemo = false;
            bool restoreLatestDemoBackup = false;
            string subsidiaryName = null;
            string addAdminUser = null;
            var demoCliOptions = new DemoConversionCliOptions();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--help":
                    case "-h":
                    case "/?":
                        PrintUsage();
                        return 0;

                    case "--restore":
                    case "-r":
                        doRestore = true;
                        if (i + 1 < args.Length && !args[i + 1].StartsWith("-"))
                            backupFile = args[++i];
                        break;

                    case "--restore-last-demo-backup":
                    case "--restore-latest-demo-backup":
                        doRestore = true;
                        restoreLatestDemoBackup = true;
                        break;

                    case "--setup":
                    case "-s":
                        doSetup = true;
                        break;

                    case "--instance":
                    case "-i":
                        if (!TryReadOptionValue(args, ref i, args[i], out instance)) return 1;
                        break;

                    case "--db-name":
                    case "-n":
                        if (!TryReadOptionValue(args, ref i, args[i], out dbName)) return 1;
                        break;

                    case "--conn-str":
                    case "-c":
                        if (!TryReadOptionValue(args, ref i, args[i], out connStr)) return 1;
                        break;

                    case "--admin-user":
                        if (!TryReadOptionValue(args, ref i, args[i], out adminUser)) return 1;
                        break;

                    case "--admin-password":
                        if (!TryReadOptionValue(args, ref i, args[i], out adminPassword)) return 1;
                        break;

                    case "--remove-existing-user-admins":
                        removeExistingUserAdmins = true;
                        break;

                    case "--list-users":
                        listUsers = true;
                        break;

                    case "--delete-users":
                        deleteUsers = true;
                        break;

                    case "--change-subsidiary-name":
                        if (!TryReadOptionValue(args, ref i, args[i], out subsidiaryName)) return 1;
                        break;

                    case "--convert-to-demo":
                        doConvertToDemo = true;
                        break;

                    case "--silent":
                        demoCliOptions.Silent = true;
                        break;

                    case "--demo-time-offset":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoTimeOffsetRaw, allowValueStartingWithDash: true)) return 1;
                        if (!TryParseSignedTimeSpan(demoTimeOffsetRaw, out TimeSpan demoTimeOffset))
                        {
                            WriteError("--demo-time-offset must be a value like -1:30, 0, or +0:45.");
                            return 1;
                        }
                        demoCliOptions.GeneralTimeOffset = demoTimeOffset;
                        break;

                    case "--demo-jitter-seconds":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoJitterRaw)) return 1;
                        if (!int.TryParse(demoJitterRaw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int demoJitter) ||
                            demoJitter < 0 || demoJitter > 3600)
                        {
                            WriteError("--demo-jitter-seconds must be a whole number between 0 and 3600.");
                            return 1;
                        }
                        demoCliOptions.RandomJitterSeconds = demoJitter;
                        break;

                    case "--demo-target-date":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoDateRaw)) return 1;
                        if (!DateTime.TryParseExact(demoDateRaw, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime demoTargetDate))
                        {
                            WriteError("--demo-target-date must use yyyy-mm-dd format.");
                            return 1;
                        }
                        demoCliOptions.TargetLastDate = demoTargetDate.Date;
                        break;

                    case "--demo-subsidiary-name":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoSubsidiaryName)) return 1;
                        demoCliOptions.NewSubsidiaryName = demoSubsidiaryName;
                        break;

                    case "--demo-regenerate-users":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoRegenerateUsersRaw)) return 1;
                        if (!TryParseYesNoValue(demoRegenerateUsersRaw, out bool regenerateUsers))
                        {
                            WriteError("--demo-regenerate-users must be yes or no.");
                            return 1;
                        }
                        demoCliOptions.RegenerateUserNames = regenerateUsers;
                        break;

                    case "--demo-regenerate-workgroups":
                        if (!TryReadOptionValue(args, ref i, args[i], out string demoRegenerateWorkgroupsRaw)) return 1;
                        if (!TryParseYesNoValue(demoRegenerateWorkgroupsRaw, out bool regenerateWorkgroups))
                        {
                            WriteError("--demo-regenerate-workgroups must be yes or no.");
                            return 1;
                        }
                        demoCliOptions.RegenerateWorkgroupNames = regenerateWorkgroups;
                        break;

                    case "--add-admin":
                    case "add-admin":
                        if (!TryReadOptionValue(args, ref i, args[i], out addAdminUser)) return 1;
                        break;

                    case "--add-default-admin":
                        addAdminUser = "Admin";
                        adminPassword = "P@$$w0rd";
                        break;

                    default:
                        // Positional argument: treat as backup file for backward compatibility.
                        if (!args[i].StartsWith("-") && backupFile == null)
                        {
                            backupFile = args[i];
                            doRestore = true;
                        }
                        break;
                }
            }

            InitializeLogging();

            adminUser = adminUser?.Trim();
            subsidiaryName = subsidiaryName?.Trim();
            addAdminUser = addAdminUser?.Trim();
            demoCliOptions.NewSubsidiaryName = demoCliOptions.NewSubsidiaryName?.Trim();

            if (string.IsNullOrWhiteSpace(adminUser))
            {
                WriteError("--admin-user requires a non-empty value.");
                return 1;
            }

            if (adminPassword != null && adminPassword.Length < 6)
            {
                WriteError("--admin-password must be at least 6 characters.");
                return 1;
            }

            if (subsidiaryName != null && subsidiaryName.Length == 0)
            {
                WriteError("--change-subsidiary-name requires a non-empty value.");
                return 1;
            }

            if (addAdminUser != null && addAdminUser.Length == 0)
            {
                WriteError("--add-admin requires a non-empty username.");
                return 1;
            }

            if (demoCliOptions.NewSubsidiaryName != null && demoCliOptions.NewSubsidiaryName.Length == 0)
            {
                WriteError("--demo-subsidiary-name requires a non-empty value.");
                return 1;
            }

            bool hasDbOperation = doSetup || listUsers || deleteUsers || removeExistingUserAdmins ||
                                  subsidiaryName != null || addAdminUser != null || doConvertToDemo;
            bool hasDemoAutomationOption = demoCliOptions.Silent ||
                                           demoCliOptions.GeneralTimeOffset.HasValue ||
                                           demoCliOptions.RandomJitterSeconds.HasValue ||
                                           demoCliOptions.TargetLastDate.HasValue ||
                                           demoCliOptions.NewSubsidiaryName != null ||
                                           demoCliOptions.RegenerateUserNames.HasValue ||
                                           demoCliOptions.RegenerateWorkgroupNames.HasValue;

            if (hasDemoAutomationOption && !doConvertToDemo)
            {
                WriteError("--silent and --demo-* options are only supported together with --convert-to-demo.");
                return 1;
            }

            if (!doRestore && !hasDbOperation)
            {
                PrintUsage();
                return 1;
            }

            if (doRestore && backupFile == null && !restoreLatestDemoBackup)
            {
                WriteError("--restore requires a backup file path.");
                return 1;
            }

            if (doRestore || hasDbOperation)
                PrintExecutionContext();

            if (doRestore)
            {
                if (backupFile == null && restoreLatestDemoBackup)
                {
                    backupFile = FindLatestDemoBackup(Environment.CurrentDirectory);
                    if (backupFile == null)
                    {
                        WriteError(
                            $"No demo backup matching '*-demo-backup-*.bak' was found in '{Environment.CurrentDirectory}'.");
                        return 1;
                    }
                }

                int rc = RunRestore(backupFile, instance, ref dbName, connStr);
                if (rc != 0) return rc;
            }

            string databaseConnStr = null;
            if (hasDbOperation)
            {
                if (connStr != null)
                {
                    var builder = new SqlConnectionStringBuilder(connStr);
                    if (string.IsNullOrEmpty(builder.InitialCatalog))
                        builder.InitialCatalog = dbName;
                    databaseConnStr = builder.ConnectionString;
                }
                else
                {
                    if (dbName == null)
                    {
                        WriteError("Database operations require --conn-str or --db-name (and optionally --instance).");
                        return 1;
                    }

                    databaseConnStr = BuildConnStr(instance, dbName);
                }
            }

            if (removeExistingUserAdmins || deleteUsers || subsidiaryName != null)
            {
                int rc = RunDatabaseMaintenance(databaseConnStr, removeExistingUserAdmins, deleteUsers, subsidiaryName);
                if (rc != 0) return rc;
            }

            if (doSetup)
            {
                string password = adminPassword;
                if (password == null)
                {
                    if (!TryPromptNewPassword($"Enter new password for '{adminUser}'", "Setup", out password))
                        return 1;
                }

                int rc = RunSetup(databaseConnStr, adminUser, password);
                if (rc != 0) return rc;
            }

            if (addAdminUser != null)
            {
                int rc = RunAddAdmin(databaseConnStr, addAdminUser, adminPassword);
                if (rc != 0) return rc;
            }

            if (doConvertToDemo)
            {
                int rc = RunConvertToDemo(databaseConnStr, demoCliOptions);
                if (rc != 0) return rc;
            }

            if (listUsers)
            {
                int rc = ListUsers(databaseConnStr);
                if (rc != 0) return rc;
            }

            return 0;
        }
    }
}
