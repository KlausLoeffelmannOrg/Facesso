using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace FacessoSetup
{
    internal partial class Program
    {
        static readonly KeyValuePair<string, string>[] LaundryPhraseTranslations = BuildLaundryPhraseTranslations();
        static readonly Dictionary<string, string> LaundryWordTranslations = BuildLaundryWordTranslations();

        static int RunConvertToDemo(string connStr, DemoConversionCliOptions cliOptions)
        {
            cliOptions = cliOptions ?? new DemoConversionCliOptions();

            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Convert Database To Demo");
            Console.WriteLine("=======================================");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        WriteWarning("Demo conversion was not started.");
                        return 0;
                    }

                    string warningText =
                        "Warning: This operation is not reversible and will change every data in the existing database. " +
                        "Make sure you know what you're doing!";

                    if (cliOptions.Silent)
                    {
                        Console.WriteLine(warningText);
                        Console.WriteLine("Silent mode enabled: continuing without interactive confirmation.");
                    }
                    else if (!PromptYesNo($"{warningText} Do you want to proceed?", false))
                    {
                        WriteWarning("Demo conversion cancelled.");
                        return 0;
                    }

                    DemoAnalysisInfo analysis = RunDemoStage(
                        "collecting the current shift and booking analysis",
                        () => CollectDemoAnalysis(conn));
                    PrintDemoAnalysis(analysis);

                    DemoConversionOptions options = PromptDemoOptions(analysis, cliOptions);
                    PrintDemoSummary(analysis, options);
                    LogDemoConversionSettings(analysis, options);

                    if (!cliOptions.Silent &&
                        !PromptYesNo("Proceed with the demo conversion using these settings?", false))
                    {
                        WriteWarning("Demo conversion cancelled.");
                        return 0;
                    }

                    DatabaseBackupInfo backup = RunDemoStage(
                        "creating the database backup",
                        () => CreateDatabaseBackup(conn, analysis.DatabaseName));
                    Console.WriteLine($"  Backup path : {backup.Path}");
                    Console.WriteLine($"  Backup size : {FormatBytes(backup.SizeBytes)}");
                    Console.WriteLine($"  Backup time : {backup.CreatedAt:yyyy-MM-dd HH:mm:ss}");

                    RunDemoStage("applying the demo-data conversion", () => ApplyDemoConversion(conn, analysis, options));
                    WriteSuccess("The database was converted to demo data.");
                }
            }
            catch (SqlException ex) { WriteException($"Database error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Database error", ex); return 1; }

            return 0;
        }

        static DemoAnalysisInfo CollectDemoAnalysis(SqlConnection conn)
        {
            var analysis = new DemoAnalysisInfo
            {
                DatabaseName = QueryScalar(conn, "SELECT DB_NAME()") ?? "Facesso",
                CurrentSubsidiaryName = QueryScalar(conn,
                    "SELECT TOP (1) [SubsidiaryName] FROM [dbo].[Subsidiaries] ORDER BY [LastEdited] DESC, [SubsidiaryName]")
            };

            analysis.ShiftDefinitions = RunDemoStage(
                "loading configured shift definitions",
                () => LoadConfiguredShiftDefinitions(conn));
            analysis.AverageByShift = RunDemoStage(
                "loading average booking windows per shift",
                () => LoadAverageShiftWindows(conn));
            if (analysis.ShiftDefinitions.Count == 0)
                analysis.ShiftDefinitions.AddRange(analysis.AverageByShift);

            analysis.AverageByWorkgroup = RunDemoStage(
                "loading average booking windows per workgroup",
                () => LoadAverageShiftWindowsByWorkgroup(conn));
            analysis.ShiftProgressItems = RunDemoStage(
                "loading shift progress buckets",
                () => LoadShiftProgressItems(conn));

            var starts = analysis.ShiftProgressItems.Where(x => x.OriginalStart.HasValue).Select(x => x.OriginalStart.Value).ToList();
            var ends = analysis.ShiftProgressItems.Where(x => x.OriginalEnd.HasValue).Select(x => x.OriginalEnd.Value).ToList();

            if (starts.Count > 0) analysis.MinBookingStart = starts.Min();
            if (ends.Count > 0) analysis.MaxBookingEnd = ends.Max();

            if (!analysis.MaxBookingEnd.HasValue && analysis.ShiftProgressItems.Count > 0)
                analysis.MaxBookingEnd = analysis.ShiftProgressItems.Max(x => x.ProductionDate);

            analysis.WeekendShiftBucketCount = analysis.ShiftProgressItems
                .Select(x => x.ProductionDate.Date)
                .Distinct()
                .Count(x => x.DayOfWeek == DayOfWeek.Saturday || x.DayOfWeek == DayOfWeek.Sunday);

            return analysis;
        }

        static T RunDemoStage<T>(string description, Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed while {description}.", ex);
            }
        }

        static void RunDemoStage(string description, Action action)
        {
            RunDemoStage(description, () =>
            {
                action();
                return true;
            });
        }

        static List<DemoShiftWindowInfo> LoadConfiguredShiftDefinitions(SqlConnection conn)
        {
            var result = new List<DemoShiftWindowInfo>();
            using (var cmd = new SqlCommand(
                @"SELECT TOP (1) CONVERT(nvarchar(max), [TimeSettingDetails])
                  FROM [dbo].[WorkGroups]
                  WHERE ISNULL([IsCurrent], 1) = 1 AND [TimeSettingDetails] IS NOT NULL
                  ORDER BY [OrdinalNo], [WorkGroupNumber], [WorkgroupName]", conn))
            {
                object xmlValue = ExecuteScalarLogged(cmd);
                string xml = xmlValue == null || xmlValue == DBNull.Value
                    ? null
                    : Convert.ToString(xmlValue, CultureInfo.InvariantCulture);
                if (string.IsNullOrWhiteSpace(xml))
                    return result;

                try
                {
                    XDocument doc = XDocument.Parse(xml);
                    foreach (var item in doc.Descendants().Where(x => x.Name.LocalName == "TimeSettingDetail"))
                    {
                        string weekday = item.Elements().FirstOrDefault(x => x.Name.LocalName == "ForWeekday")?.Value;
                        if (!string.Equals(weekday, "ForAll", StringComparison.OrdinalIgnoreCase) &&
                            !string.Equals(weekday, "0", StringComparison.OrdinalIgnoreCase))
                            continue;

                        if (!int.TryParse(
                                item.Elements().FirstOrDefault(x => x.Name.LocalName == "ForShift")?.Value,
                                NumberStyles.Integer,
                                CultureInfo.InvariantCulture,
                                out int shiftNo))
                            continue;

                        if (shiftNo < 1 || shiftNo > 4 || result.Any(x => x.Shift == shiftNo))
                            continue;

                        if (!TryParseXmlTime(item, "XMLImportShiftStart", "XMLShiftStart", out TimeSpan start))
                            continue;

                        if (!TryParseXmlTime(item, "XMLImportShiftEnd", "XMLShiftEnd", out TimeSpan end))
                            continue;

                        result.Add(new DemoShiftWindowInfo
                        {
                            Shift = (byte)shiftNo,
                            Start = start,
                            End = end
                        });
                    }
                }
                catch
                {
                    return new List<DemoShiftWindowInfo>();
                }
            }

            return result.OrderBy(x => x.Shift).ToList();
        }

        static bool TryParseXmlTime(XElement parent, string primaryElementName, string fallbackElementName, out TimeSpan value)
        {
            value = TimeSpan.Zero;
            string rawValue = parent.Elements().FirstOrDefault(x => x.Name.LocalName == primaryElementName)?.Value;
            if (string.IsNullOrWhiteSpace(rawValue))
                rawValue = parent.Elements().FirstOrDefault(x => x.Name.LocalName == fallbackElementName)?.Value;

            if (string.IsNullOrWhiteSpace(rawValue))
                return false;

            if (!DateTime.TryParse(rawValue, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed) &&
                !DateTime.TryParse(rawValue, out parsed))
                return false;

            value = parsed.TimeOfDay;
            return true;
        }

        static List<DemoShiftWindowInfo> LoadAverageShiftWindows(SqlConnection conn)
        {
            var result = new List<DemoShiftWindowInfo>();
            using (var cmd = new SqlCommand(
                @"SELECT [Shift],
                         AVG(CAST(DATEDIFF(SECOND, CAST([ShiftStart] AS date), [ShiftStart]) AS float)) AS [AvgStartSeconds],
                         AVG(CAST(DATEDIFF(SECOND, CAST([ShiftEnd] AS date), [ShiftEnd]) AS float)) AS [AvgEndSeconds],
                         COUNT(*) AS [EntryCount]
                   FROM [dbo].[TimeLog]
                   GROUP BY [Shift]
                   ORDER BY [Shift]", conn))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    result.Add(new DemoShiftWindowInfo
                    {
                        Shift = Convert.ToByte(reader["Shift"]),
                        Start = TimeSpan.FromSeconds(Convert.ToDouble(reader["AvgStartSeconds"], CultureInfo.InvariantCulture)),
                        End = TimeSpan.FromSeconds(Convert.ToDouble(reader["AvgEndSeconds"], CultureInfo.InvariantCulture)),
                        EntryCount = Convert.ToInt32(reader["EntryCount"], CultureInfo.InvariantCulture)
                    });
                }
            }

            return result;
        }

        static List<DemoWorkgroupShiftSummary> LoadAverageShiftWindowsByWorkgroup(SqlConnection conn)
        {
            var map = new Dictionary<string, DemoWorkgroupShiftSummary>(StringComparer.OrdinalIgnoreCase);

            using (var cmd = new SqlCommand(
                @"SELECT COALESCE(wg.[WorkgroupName], N'(unknown)') AS [WorkgroupName],
                         tl.[Shift],
                         AVG(CAST(DATEDIFF(SECOND, CAST(tl.[ShiftStart] AS date), tl.[ShiftStart]) AS float)) AS [AvgStartSeconds],
                         AVG(CAST(DATEDIFF(SECOND, CAST(tl.[ShiftEnd] AS date), tl.[ShiftEnd]) AS float)) AS [AvgEndSeconds],
                         COUNT(*) AS [EntryCount]
                  FROM [dbo].[TimeLog] tl
                   LEFT JOIN [dbo].[WorkGroups] wg
                          ON wg.[IDSubsidiary] = tl.[IDSubsidiary]
                         AND wg.[IDWorkGroup] = tl.[IDWorkGroup]
                   GROUP BY COALESCE(wg.[WorkgroupName], N'(unknown)'), tl.[Shift]
                   ORDER BY [WorkgroupName], tl.[Shift]", conn))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    string workgroupName = reader["WorkgroupName"].ToString();
                    if (!map.TryGetValue(workgroupName, out DemoWorkgroupShiftSummary summary))
                    {
                        summary = new DemoWorkgroupShiftSummary { WorkgroupName = workgroupName };
                        map.Add(workgroupName, summary);
                    }

                    summary.Shifts.Add(new DemoShiftWindowInfo
                    {
                        Shift = Convert.ToByte(reader["Shift"]),
                        Start = TimeSpan.FromSeconds(Convert.ToDouble(reader["AvgStartSeconds"], CultureInfo.InvariantCulture)),
                        End = TimeSpan.FromSeconds(Convert.ToDouble(reader["AvgEndSeconds"], CultureInfo.InvariantCulture)),
                        EntryCount = Convert.ToInt32(reader["EntryCount"], CultureInfo.InvariantCulture)
                    });
                }
            }

            return map.Values.OrderBy(x => x.WorkgroupName, StringComparer.OrdinalIgnoreCase).ToList();
        }

        static List<ShiftProgressItem> LoadShiftProgressItems(SqlConnection conn)
        {
            var result = new List<ShiftProgressItem>();

            using (var cmd = new SqlCommand(
                @"SELECT g.[IDSubsidiary],
                         g.[ProductionDate],
                         g.[Shift],
                         g.[IDWorkGroup],
                         COALESCE(wg.[WorkgroupName], N'(unknown)') AS [WorkgroupName],
                         tl.[MinStart],
                         tl.[MaxEnd],
                         pd.[DegreeOfTime],
                         pd.[DegreeOfTimeAdj],
                         ISNULL(tl.[EntryCount], 0) AS [EntryCount]
                  FROM (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup]
                        FROM [dbo].[ProductionData]
                        UNION
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup]
                        FROM [dbo].[TimeLog]
                  ) g
                  LEFT JOIN (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup],
                               MIN([ShiftStart]) AS [MinStart],
                               MAX([ShiftEnd]) AS [MaxEnd],
                               COUNT(*) AS [EntryCount]
                        FROM [dbo].[TimeLog]
                        GROUP BY [IDSubsidiary], CONVERT(date, [ProductionDate]), [Shift], [IDWorkGroup]
                  ) tl
                    ON tl.[IDSubsidiary] = g.[IDSubsidiary]
                   AND tl.[ProductionDate] = g.[ProductionDate]
                   AND tl.[Shift] = g.[Shift]
                   AND tl.[IDWorkGroup] = g.[IDWorkGroup]
                  LEFT JOIN (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup],
                               MAX([DegreeOfTime]) AS [DegreeOfTime],
                               MAX([DegreeOfTimeAdj]) AS [DegreeOfTimeAdj]
                        FROM [dbo].[ProductionData]
                        GROUP BY [IDSubsidiary], CONVERT(date, [ProductionDate]), [Shift], [IDWorkGroup]
                  ) pd
                    ON pd.[IDSubsidiary] = g.[IDSubsidiary]
                   AND pd.[ProductionDate] = g.[ProductionDate]
                   AND pd.[Shift] = g.[Shift]
                   AND pd.[IDWorkGroup] = g.[IDWorkGroup]
                   LEFT JOIN [dbo].[WorkGroups] wg
                     ON wg.[IDSubsidiary] = g.[IDSubsidiary]
                    AND wg.[IDWorkGroup] = g.[IDWorkGroup]
                   ORDER BY g.[ProductionDate], g.[Shift], [WorkgroupName]", conn))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    result.Add(new ShiftProgressItem
                    {
                        IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                        ProductionDate = GetDateTimeValue(reader, "ProductionDate").Date,
                        Shift = GetByteValue(reader, "Shift"),
                        IDWorkGroup = GetIdentifierValue(reader, "IDWorkGroup"),
                        WorkgroupName = GetStringValue(reader, "WorkgroupName", "(unknown)"),
                        OriginalStart = GetNullableDateTimeValue(reader, "MinStart"),
                        OriginalEnd = GetNullableDateTimeValue(reader, "MaxEnd"),
                        DegreeOfTime = GetNullableDoubleValue(reader, "DegreeOfTime"),
                        DegreeOfTimeAdj = GetNullableDoubleValue(reader, "DegreeOfTimeAdj"),
                        EntryCount = GetInt32Value(reader, "EntryCount")
                    });
                }
            }

            return result;
        }

        static DemoConversionOptions PromptDemoOptions(DemoAnalysisInfo analysis, DemoConversionCliOptions cliOptions)
        {
            cliOptions = cliOptions ?? new DemoConversionCliOptions();
            var options = new DemoConversionOptions();
            Random rng = NewRandom();
            List<string> funnyNames = BuildFunnyLaundryServiceNames();
            string defaultSubsidiary = funnyNames[rng.Next(funnyNames.Count)];

            if (!string.Equals(defaultSubsidiary, analysis.CurrentSubsidiaryName, StringComparison.OrdinalIgnoreCase))
                defaultSubsidiary = $"{defaultSubsidiary}";

            DateTime defaultLastDate = analysis.MaxBookingEnd?.Date ?? DateTime.Today;
            if (defaultLastDate < DateTime.Today.AddYears(-2) || defaultLastDate > DateTime.Today.AddYears(2))
                defaultLastDate = DateTime.Today;

            if (cliOptions.Silent)
            {
                Console.WriteLine();
                Console.WriteLine("Silent mode: using command-line values or defaults for demo conversion.");
            }
            else
            {
                Console.WriteLine();
            }

            options.GeneralTimeOffset = cliOptions.GeneralTimeOffset ?? (cliOptions.Silent
                ? TimeSpan.Zero
                : PromptSignedTimeOffset(
                    "What general time offset do you want for all the time items: +/- h:mm (0 - nothing changes)",
                    TimeSpan.Zero));

            options.RandomJitterSeconds = cliOptions.RandomJitterSeconds ?? (cliOptions.Silent
                ? 0
                : PromptInteger(
                    "What random jitter-span per time entry booking do you want to define in seconds (0 - nothing changes)",
                    0, 0, 3600));

            options.TargetLastDate = cliOptions.TargetLastDate ?? (cliOptions.Silent
                ? defaultLastDate
                : PromptDate(
                    "Adjust the booking dates both for production data and time data, so the last time entry will be (yyyy-mm-dd)",
                    defaultLastDate));

            options.NewSubsidiaryName = cliOptions.NewSubsidiaryName ?? (cliOptions.Silent
                ? defaultSubsidiary
                : PromptString(
                    "New name of the Subsidiary",
                    defaultSubsidiary,
                    allowEmpty: false));

            options.RegenerateUserNames = cliOptions.RegenerateUserNames ?? (cliOptions.Silent
                ? true
                : PromptYesNo("Regenerate User Names (y/n)", true));

            options.RegenerateWorkgroupNames = cliOptions.RegenerateWorkgroupNames ?? (cliOptions.Silent
                ? true
                : PromptYesNo("Regenerate Workgroup and Labourvalue names (yes/no)", true));
            options.IsSilent = cliOptions.Silent;

            return options;
        }

        static void PrintDemoAnalysis(DemoAnalysisInfo analysis)
        {
            Console.WriteLine();
            Console.WriteLine("The current shift-times are defined like this:");
            if (analysis.ShiftDefinitions.Count == 0)
            {
                Console.WriteLine("  No shift definitions or historic bookings were found.");
            }
            else
            {
                foreach (var shift in analysis.ShiftDefinitions.OrderBy(x => x.Shift))
                    Console.WriteLine($"  Shift {shift.Shift}: {FormatTimeOfDay(shift.Start)} - {FormatTimeOfDay(shift.End)}");
            }

            Console.WriteLine();
            Console.WriteLine("Existing booking times span:");
            Console.WriteLine($"  {FormatDateTime(analysis.MinBookingStart)} - {FormatDateTime(analysis.MaxBookingEnd)}");

            Console.WriteLine();
            Console.WriteLine("Employees have booked in average per shift the following time spans:");
            if (analysis.AverageByShift.Count == 0)
            {
                Console.WriteLine("  No booking averages are available.");
            }
            else
            {
                foreach (var shift in analysis.AverageByShift.OrderBy(x => x.Shift))
                    Console.WriteLine($"  Shift {shift.Shift}: {FormatTimeOfDay(shift.Start)} - {FormatTimeOfDay(shift.End)}");
            }

            Console.WriteLine();
            Console.WriteLine("Employees have booked in average per shift per workgroup the following time spans:");
            if (analysis.AverageByWorkgroup.Count == 0)
            {
                Console.WriteLine("  No workgroup-based booking averages are available.");
            }
            else
            {
                foreach (var workgroup in analysis.AverageByWorkgroup)
                {
                    string shiftText = string.Join("  ",
                        workgroup.Shifts
                            .OrderBy(x => x.Shift)
                            .Select(x => $"Shift {x.Shift} [{FormatTimeOfDay(x.Start)} - {FormatTimeOfDay(x.End)}]"));
                    Console.WriteLine($"  {workgroup.WorkgroupName}: {shiftText}");
                }
            }

            Console.WriteLine();
            if (analysis.WeekendShiftBucketCount > 0)
                Console.WriteLine($"Weekend activity detected on {analysis.WeekendShiftBucketCount} production date bucket(s).");
            else
                Console.WriteLine("No Saturday/Sunday activity was found in the operational data.");
        }

        static void PrintDemoSummary(DemoAnalysisInfo analysis, DemoConversionOptions options)
        {
            Console.WriteLine();
            Console.WriteLine("Summary of the selected demo conversion settings:");
            Console.WriteLine($"  Execution mode          : {(options.IsSilent ? "silent" : "interactive")}");
            Console.WriteLine($"  Database                : {analysis.DatabaseName}");
            Console.WriteLine($"  Current subsidiary      : {analysis.CurrentSubsidiaryName ?? "(unknown)"}");
            Console.WriteLine($"  New subsidiary          : {options.NewSubsidiaryName}");
            Console.WriteLine($"  Time offset             : {FormatSignedTimeSpan(options.GeneralTimeOffset)}");
            Console.WriteLine($"  Random jitter           : {options.RandomJitterSeconds} seconds");
            Console.WriteLine($"  Target last booking day : {options.TargetLastDate:yyyy-MM-dd}");
            Console.WriteLine($"  Regenerate user names   : {(options.RegenerateUserNames ? "yes" : "no")}");
            Console.WriteLine($"  Rename workgroups/LV    : {(options.RegenerateWorkgroupNames ? "yes" : "no")}");
            Console.WriteLine($"  Shift buckets to update : {analysis.ShiftProgressItems.Select(x => $"{x.IDSubsidiary}:{x.ProductionDate:yyyy-MM-dd}:{x.Shift}").Distinct().Count()}");
        }

        static void LogDemoConversionSettings(DemoAnalysisInfo analysis, DemoConversionOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Execution mode          : {(options.IsSilent ? "silent" : "interactive")}");
            sb.AppendLine($"Database                : {analysis.DatabaseName}");
            sb.AppendLine($"Current subsidiary      : {analysis.CurrentSubsidiaryName ?? "(unknown)"}");
            sb.AppendLine($"New subsidiary          : {options.NewSubsidiaryName}");
            sb.AppendLine($"Time offset             : {FormatSignedTimeSpan(options.GeneralTimeOffset)}");
            sb.AppendLine($"Random jitter           : {options.RandomJitterSeconds} seconds");
            sb.AppendLine($"Target last booking day : {options.TargetLastDate:yyyy-MM-dd}");
            sb.AppendLine($"Regenerate user names   : {(options.RegenerateUserNames ? "yes" : "no")}");
            sb.AppendLine($"Rename workgroups/LV    : {(options.RegenerateWorkgroupNames ? "yes" : "no")}");
            sb.AppendLine($"Shift buckets to update : {analysis.ShiftProgressItems.Select(x => $"{x.IDSubsidiary}:{x.ProductionDate:yyyy-MM-dd}:{x.Shift}").Distinct().Count()}");
            AppendLogBlock("DEMO CONVERSION SETTINGS", sb.ToString());
        }

        static DatabaseBackupInfo CreateDatabaseBackup(SqlConnection conn, string databaseName)
        {
            string safeDbName = MakeFileNameSafe(databaseName);
            string backupDirectory = Path.Combine(
                Environment.CurrentDirectory,
                "FacessoSetup-Backups",
                DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            Directory.CreateDirectory(backupDirectory);

            string backupPath = Path.Combine(
                backupDirectory,
                $"{safeDbName}-demo-backup-{DateTime.Now:yyyyMMdd-HHmmss}.bak");

            Console.WriteLine();
            Console.WriteLine($"Creating DB backup into {backupPath}...");

            using (var cmd = new SqlCommand(
                $"BACKUP DATABASE [{databaseName.Replace("]", "]]")}] TO DISK = @backupPath WITH COPY_ONLY, INIT, CHECKSUM, STATS = 10",
                conn))
            {
                cmd.Parameters.Add("@backupPath", SqlDbType.NVarChar, 4000).Value = backupPath;
                cmd.CommandTimeout = 0;
                ExecuteNonQueryLogged(cmd);
            }

            var backupFile = new FileInfo(backupPath);
            return new DatabaseBackupInfo
            {
                Path = backupPath,
                SizeBytes = backupFile.Exists ? backupFile.Length : 0,
                CreatedAt = backupFile.Exists ? backupFile.LastWriteTime : DateTime.Now
            };
        }

        static void ApplyDemoConversion(SqlConnection conn, DemoAnalysisInfo analysis, DemoConversionOptions options)
        {
            Random rng = NewRandom();
            int totalShiftBuckets = analysis.ShiftProgressItems
                .Select(x => $"{x.IDSubsidiary}:{x.ProductionDate:yyyy-MM-dd}:{x.Shift}")
                .Distinct()
                .Count();

            int totalSteps = Math.Max(totalShiftBuckets, 0)
                             + 1
                             + (options.RegenerateUserNames ? 1 : 0)
                             + (options.RegenerateWorkgroupNames ? 1 : 0);

            int completedSteps = 0;

            Console.WriteLine();
            Console.WriteLine("Applying demo data changes...");

            using (var metadataTx = conn.BeginTransaction())
            {
                try
                {
                    int updatedSubsidiaries = ChangeSubsidiaryName(conn, options.NewSubsidiaryName, metadataTx);
                    Console.WriteLine($"  Subsidiary renamed on {updatedSubsidiaries} row(s).");
                    DrawProgressBar(++completedSteps, totalSteps, "Subsidiary rename");
                    Console.WriteLine();

                    if (options.RegenerateUserNames)
                    {
                        RandomizePeopleForDemo(conn, rng, metadataTx);
                        DrawProgressBar(++completedSteps, totalSteps, "Users and employees anonymized");
                        Console.WriteLine();
                    }

                    if (options.RegenerateWorkgroupNames)
                    {
                        RandomizeDescriptorsForDemo(conn, metadataTx);
                        DrawProgressBar(++completedSteps, totalSteps, "Workgroups and labour values renamed");
                        Console.WriteLine();
                    }

                    metadataTx.Commit();
                }
                catch
                {
                    try { metadataTx.Rollback(); } catch { }
                    throw;
                }
            }

            if (totalShiftBuckets == 0)
            {
                WriteWarning("No TimeLog or ProductionData rows were found for date shifting.");
                return;
            }

            int dayShift = 0;
            if (analysis.MaxBookingEnd.HasValue)
                dayShift = (options.TargetLastDate.Date - analysis.MaxBookingEnd.Value.Date).Days;

            var groupedBuckets = analysis.ShiftProgressItems
                .GroupBy(x => new ShiftBucketKey(x.IDSubsidiary, x.ProductionDate.Date, x.Shift))
                .OrderBy(x => x.Key.ProductionDate)
                .ThenBy(x => x.Key.Shift)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Suspending recalculation triggers for grouped shift updates...");
            SetOperationalTriggersEnabled(conn, false);

            try
            {
                int jitterSeed = rng.Next(1, int.MaxValue);
                for (int i = 0; i < groupedBuckets.Count; i++)
                {
                    var bucket = groupedBuckets[i];
                    DateTime newProductionDate = bucket.Key.ProductionDate.AddDays(dayShift);
                    string bucketLabel = $"{bucket.Key.ProductionDate:yyyy-MM-dd} / Shift {bucket.Key.Shift}";

                    DrawProgressBar(completedSteps + i + 1, totalSteps, bucketLabel);
                    Console.WriteLine();

                    foreach (var item in bucket.OrderBy(x => x.WorkgroupName, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            $"  {item.WorkgroupName} - Org: Shift {item.Shift} - TS {FormatDateTime(item.OriginalStart)} - " +
                            $"TE {FormatDateTime(item.OriginalEnd)} TE: {FormatMetric(item.DegreeOfTime)} " +
                            $"TEAdj: {FormatMetric(item.DegreeOfTimeAdj)}");
                    }

                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            UpdateShiftBucket(
                                conn,
                                tx,
                                bucket.Key.IDSubsidiary,
                                bucket.Key.ProductionDate,
                                bucket.Key.Shift,
                                dayShift,
                                options.GeneralTimeOffset,
                                options.RandomJitterSeconds,
                                jitterSeed);

                            foreach (var item in bucket)
                                RecalculateShiftBucket(conn, tx, item.IDSubsidiary, item.IDWorkGroup, newProductionDate, item.Shift);

                            tx.Commit();
                        }
                        catch
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }

                    List<ShiftProgressItem> refreshed = LoadShiftBucketDetails(
                        conn,
                        bucket.Key.IDSubsidiary,
                        newProductionDate,
                        bucket.Key.Shift);

                    foreach (var item in refreshed.OrderBy(x => x.WorkgroupName, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            $"  {item.WorkgroupName} - New: Shift {item.Shift} - TS {FormatDateTime(item.OriginalStart)} - " +
                            $"TE {FormatDateTime(item.OriginalEnd)} TE: {FormatMetric(item.DegreeOfTime)} " +
                            $"TEAdj: {FormatMetric(item.DegreeOfTimeAdj)}");
                    }
                }

                completedSteps += groupedBuckets.Count;
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Reactivating recalculation triggers...");
                SetOperationalTriggersEnabled(conn, true);
            }
        }

        static void RandomizePeopleForDemo(SqlConnection conn, Random rng, SqlTransaction tx)
        {
            Console.WriteLine();
            Console.WriteLine("Randomizing employees and user names...");

            List<PersonIdentity> namePool = BuildInternationalNamePool();
            var usedUserNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            int poolIndex = 0;

            var employees = new List<EmployeeRecord>();
            using (var cmd = new SqlCommand(
                @"SELECT [IDSubsidiary], [IDEmployee], [IDAddressDetails], [PersonnelNumber]
                  FROM [dbo].[Employees]
                  WHERE ISNULL([IsCurrent], 1) = 1
                  ORDER BY [PersonnelNumber], [LastName], [FirstName]", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    employees.Add(new EmployeeRecord
                    {
                        IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                        IDEmployee = GetIdentifierValue(reader, "IDEmployee"),
                        IDAddressDetails = GetNullableIdentifierValue(reader, "IDAddressDetails"),
                        PersonnelNumber = GetInt32Value(reader, "PersonnelNumber")
                    });
                }
            }

            HashSet<int> usedPersonnelNumbers = LoadUsedPersonnelNumbers(conn, tx);
            int nextPersonnelNumber = usedPersonnelNumbers.Count == 0
                ? 1000 + rng.Next(1000, 5000)
                : Math.Max(usedPersonnelNumbers.Max() + 1, 1000 + rng.Next(1000, 5000));

            using (var cmd = new SqlCommand(
                @"SELECT [Username]
                  FROM [dbo].[Users]
                  WHERE [Username] IS NOT NULL", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    string existingUserName = GetStringValue(reader, "Username").Trim();
                    if (!string.IsNullOrWhiteSpace(existingUserName))
                        usedUserNames.Add(existingUserName);
                }
            }

            foreach (var employee in employees)
            {
                PersonIdentity identity = namePool[poolIndex % namePool.Count];
                poolIndex++;
                int newPersonnelNumber = GetNextAvailablePersonnelNumber(usedPersonnelNumbers, ref nextPersonnelNumber);
                string matchCode = $"{identity.LastName.ToUpperInvariant()}-{newPersonnelNumber}";
                string timeCardNo = $"DEMO-{newPersonnelNumber:0000}";

                using (var cmd = new SqlCommand(
                    @"UPDATE [dbo].[Employees]
                      SET [FirstName] = @firstName,
                          [LastName] = @lastName,
                          [Matchcode] = @matchCode,
                          [PersonnelNumber] = @personnelNumber,
                          [TimeCardNo] = @timeCardNo,
                          [DateOfBirth] = NULL,
                          [DateOfJoining] = NULL,
                          [DateOfSeparation] = NULL,
                          [Comment] = NULL,
                          [LastEdited] = GETDATE()
                      WHERE [IDSubsidiary] = @subsidiaryId
                        AND [IDEmployee] = @employeeId", conn, tx))
                {
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = identity.FirstName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = identity.LastName;
                    cmd.Parameters.Add("@matchCode", SqlDbType.NVarChar, 50).Value = matchCode;
                    cmd.Parameters.Add("@personnelNumber", SqlDbType.Int).Value = newPersonnelNumber;
                    cmd.Parameters.Add("@timeCardNo", SqlDbType.NVarChar, 50).Value = timeCardNo;
                    AddParameterValue(cmd.Parameters, "@subsidiaryId", employee.IDSubsidiary);
                    AddParameterValue(cmd.Parameters, "@employeeId", employee.IDEmployee);
                    ExecuteNonQueryLogged(cmd);
                }

                if (employee.IDAddressDetails != null)
                {
                    using (var cmd = new SqlCommand(
                        @"UPDATE [dbo].[AddressDetails]
                          SET [PersonnelNo] = @personnelNumber,
                              [LastName] = @lastName,
                              [MiddleName] = NULL,
                              [FirstName] = @firstName,
                              [Title] = NULL,
                              [Street] = NULL,
                              [Zip] = NULL,
                              [City] = NULL,
                              [CountryCode] = NULL,
                              [Country] = NULL,
                              [CompanyPhone] = NULL,
                              [PrivatePhone] = NULL,
                              [CompanyEmail] = NULL,
                              [PrivateEmail] = NULL,
                              [CompanyMobile] = NULL,
                              [PrivateMobile] = NULL,
                              [URL] = NULL,
                              [LastEdited] = GETDATE()
                          WHERE [IDSubsidiary] = @subsidiaryId
                            AND [IDAddressDetail] = @addressId", conn, tx))
                    {
                        cmd.Parameters.Add("@personnelNumber", SqlDbType.Int).Value = newPersonnelNumber;
                        cmd.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = identity.FirstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = identity.LastName;
                        AddParameterValue(cmd.Parameters, "@subsidiaryId", employee.IDSubsidiary);
                        AddParameterValue(cmd.Parameters, "@addressId", employee.IDAddressDetails);
                        ExecuteNonQueryLogged(cmd);
                    }
                }

                Console.WriteLine($"  Personnel {newPersonnelNumber:0000}: {identity.FirstName} {identity.LastName}");
            }

            var users = new List<UserRecord>();
            using (var cmd = new SqlCommand(
                @"SELECT [IDSubsidiary], [IDUser], [IDAddressDetails], [Username]
                  FROM [dbo].[Users]
                  WHERE ISNULL([IsCurrent], 1) = 1
                    AND [IsSystemAccount] = 0
                    AND [Username] NOT IN (N'Admin', N'Administrator')
                    AND [Username] NOT LIKE N'Facesso!%'
                  ORDER BY [Username]", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    users.Add(new UserRecord
                    {
                        IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                        IDUser = GetIdentifierValue(reader, "IDUser"),
                        IDAddressDetails = GetNullableIdentifierValue(reader, "IDAddressDetails"),
                        UserName = GetStringValue(reader, "Username")
                    });
                }
            }

            foreach (var user in users)
            {
                PersonIdentity identity = namePool[poolIndex % namePool.Count];
                poolIndex++;
                string demoUserName = CreateUniqueUserName(identity, usedUserNames, poolIndex);

                using (var cmd = new SqlCommand(
                    @"UPDATE [dbo].[Users]
                      SET [FirstName] = @firstName,
                          [LastName] = @lastName,
                          [Username] = @userName,
                          [Comment] = NULL,
                          [LastEdited] = GETDATE()
                      WHERE [IDSubsidiary] = @subsidiaryId
                        AND [IDUser] = @userId", conn, tx))
                {
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = identity.FirstName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = identity.LastName;
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 100).Value = demoUserName;
                    AddParameterValue(cmd.Parameters, "@subsidiaryId", user.IDSubsidiary);
                    AddParameterValue(cmd.Parameters, "@userId", user.IDUser);
                    ExecuteNonQueryLogged(cmd);
                }

                if (user.IDAddressDetails != null)
                {
                    using (var cmd = new SqlCommand(
                        @"UPDATE [dbo].[AddressDetails]
                          SET [LastName] = @lastName,
                              [MiddleName] = NULL,
                              [FirstName] = @firstName,
                              [Title] = NULL,
                              [Street] = NULL,
                              [Zip] = NULL,
                              [City] = NULL,
                              [CountryCode] = NULL,
                              [Country] = NULL,
                              [CompanyPhone] = NULL,
                              [PrivatePhone] = NULL,
                              [CompanyEmail] = NULL,
                              [PrivateEmail] = NULL,
                              [CompanyMobile] = NULL,
                              [PrivateMobile] = NULL,
                              [URL] = NULL,
                              [LastEdited] = GETDATE()
                          WHERE [IDSubsidiary] = @subsidiaryId
                            AND [IDAddressDetail] = @addressId", conn, tx))
                    {
                        cmd.Parameters.Add("@firstName", SqlDbType.NVarChar, 100).Value = identity.FirstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar, 100).Value = identity.LastName;
                        AddParameterValue(cmd.Parameters, "@subsidiaryId", user.IDSubsidiary);
                        AddParameterValue(cmd.Parameters, "@addressId", user.IDAddressDetails);
                        ExecuteNonQueryLogged(cmd);
                    }
                }

                Console.WriteLine($"  User '{user.UserName}' -> '{demoUserName}'");
            }
        }

        static HashSet<int> LoadUsedPersonnelNumbers(SqlConnection conn, SqlTransaction tx)
        {
            var values = new HashSet<int>();
            using (var cmd = new SqlCommand(
                @"SELECT [PersonnelNumber]
                  FROM [dbo].[Employees]
                  WHERE [PersonnelNumber] IS NOT NULL", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                    values.Add(GetInt32Value(reader, "PersonnelNumber"));
            }

            return values;
        }

        static int GetNextAvailablePersonnelNumber(HashSet<int> usedPersonnelNumbers, ref int candidate)
        {
            while (usedPersonnelNumbers.Contains(candidate))
                candidate++;

            usedPersonnelNumbers.Add(candidate);
            return candidate++;
        }

        static void RandomizeDescriptorsForDemo(SqlConnection conn, SqlTransaction tx)
        {
            Console.WriteLine();
            Console.WriteLine("Randomizing workgroup and labour value names...");

            var workgroups = new List<DescriptorRecord>();
            using (var cmd = new SqlCommand(
                @"SELECT [IDSubsidiary], [IDWorkGroup], [WorkGroupNumber], [WorkgroupName]
                  FROM [dbo].[WorkGroups]
                  WHERE ISNULL([IsCurrent], 1) = 1
                  ORDER BY [WorkGroupNumber], [WorkgroupName]", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    workgroups.Add(new DescriptorRecord
                    {
                        IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                        ItemId = GetIdentifierValue(reader, "IDWorkGroup"),
                        Number = GetInt32Value(reader, "WorkGroupNumber"),
                        CurrentName = GetStringValue(reader, "WorkgroupName")
                    });
                }
            }

            for (int i = 0; i < workgroups.Count; i++)
            {
                DescriptorRecord workgroup = workgroups[i];
                string newName = BuildEnglishWorkgroupName(workgroup.CurrentName, i + 1);
                string newDescription = BuildWorkgroupDescription(workgroup.CurrentName, i + 1);

                using (var cmd = new SqlCommand(
                    @"UPDATE [dbo].[WorkGroups]
                      SET [WorkgroupName] = @name,
                          [WorkGroupDescription] = @description,
                          [LastEdited] = GETDATE()
                      WHERE [IDSubsidiary] = @subsidiaryId
                        AND [IDWorkGroup] = @itemId", conn, tx))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = Truncate(newName, 100);
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar, 4000).Value = Truncate(newDescription, 4000);
                    AddParameterValue(cmd.Parameters, "@subsidiaryId", workgroup.IDSubsidiary);
                    AddParameterValue(cmd.Parameters, "@itemId", workgroup.ItemId);
                    ExecuteNonQueryLogged(cmd);
                }

                Console.WriteLine($"  Workgroup {workgroup.Number}: {workgroup.CurrentName} -> {newName}");
            }

            var labourValues = new List<LabourValueRecord>();
            using (var cmd = new SqlCommand(
                @"SELECT [IDSubsidiary], [IDLabourValue], [LabourValueNumber], [LabourValueName], [Dimension]
                  FROM [dbo].[LabourValues]
                  WHERE ISNULL([IsCurrent], 1) = 1
                  ORDER BY [LabourValueNumber], [LabourValueName]", conn, tx))
            using (var reader = ExecuteReaderLogged(cmd))
            {
                while (reader.Read())
                {
                    labourValues.Add(new LabourValueRecord
                    {
                        IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                        ItemId = GetIdentifierValue(reader, "IDLabourValue"),
                        Number = GetInt32Value(reader, "LabourValueNumber"),
                        CurrentName = GetStringValue(reader, "LabourValueName"),
                        Dimension = GetStringValue(reader, "Dimension")
                    });
                }
            }

            for (int i = 0; i < labourValues.Count; i++)
            {
                LabourValueRecord labourValue = labourValues[i];
                string newName = BuildEnglishLabourValueName(labourValue.CurrentName, i + 1);
                string newDescription = BuildLabourValueDescription(labourValue.CurrentName, i + 1);

                using (var cmd = new SqlCommand(
                    @"UPDATE [dbo].[LabourValues]
                      SET [LabourValueName] = @name,
                          [LabourValueDescription] = @description,
                          [Dimension] = @dimension,
                          [LastEdited] = GETDATE()
                      WHERE [IDSubsidiary] = @subsidiaryId
                        AND [IDLabourValue] = @itemId", conn, tx))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = Truncate(newName, 100);
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = newDescription;
                    cmd.Parameters.Add("@dimension", SqlDbType.NVarChar, 100).Value = TranslateDimension(labourValue.Dimension);
                    AddParameterValue(cmd.Parameters, "@subsidiaryId", labourValue.IDSubsidiary);
                    AddParameterValue(cmd.Parameters, "@itemId", labourValue.ItemId);
                    ExecuteNonQueryLogged(cmd);
                }

                Console.WriteLine($"  Labour value {labourValue.Number}: {labourValue.CurrentName} -> {newName}");
            }
        }

        static void UpdateShiftBucket(
            SqlConnection conn,
            SqlTransaction tx,
            object idSubsidiary,
            DateTime oldProductionDate,
            byte shift,
            int dayShift,
            TimeSpan generalOffset,
            int jitterSeconds,
            int jitterSeed)
        {
            using (var cmd = new SqlCommand(
                @"DECLARE @jitterRangeLocal INT = CASE WHEN @jitterSeconds <= 0 THEN 1 ELSE @jitterSeconds * 2 + 1 END;

                  UPDATE pd
                  SET [ProductionDate] = DATEADD(DAY, @dayShift, pd.[ProductionDate]),
                      [LastEdited] = GETDATE()
                  FROM [dbo].[ProductionData] pd
                  WHERE pd.[IDSubsidiary] = @subsidiaryId
                    AND CONVERT(date, pd.[ProductionDate]) = @oldProductionDate
                    AND pd.[Shift] = @shift;

                  UPDATE tl
                  SET [ProductionDate] = DATEADD(DAY, @dayShift, tl.[ProductionDate]),
                      [ShiftStart] = DATEADD(SECOND, @offsetSeconds + j.[Jitter], DATEADD(DAY, @dayShift, tl.[ShiftStart])),
                      [ShiftEnd] = DATEADD(SECOND, @offsetSeconds + j.[Jitter], DATEADD(DAY, @dayShift, tl.[ShiftEnd])),
                      [ShiftStartViaInterface] = CASE
                            WHEN tl.[ShiftStartViaInterface] IS NULL THEN NULL
                            ELSE DATEADD(SECOND, @offsetSeconds + j.[Jitter], DATEADD(DAY, @dayShift, tl.[ShiftStartViaInterface]))
                      END,
                      [ShiftEndViaInterface] = CASE
                            WHEN tl.[ShiftEndViaInterface] IS NULL THEN NULL
                            ELSE DATEADD(SECOND, @offsetSeconds + j.[Jitter], DATEADD(DAY, @dayShift, tl.[ShiftEndViaInterface]))
                      END,
                      [LastEdited] = GETDATE()
                  FROM [dbo].[TimeLog] tl
                  CROSS APPLY (
                        SELECT CASE
                                WHEN @jitterSeconds <= 0 THEN 0
                                ELSE ABS(CHECKSUM(tl.[IDTimeLog], @jitterSeed)) % @jitterRangeLocal - @jitterSeconds
                              END AS [Jitter]
                  ) j
                  WHERE tl.[IDSubsidiary] = @subsidiaryId
                    AND CONVERT(date, tl.[ProductionDate]) = @oldProductionDate
                    AND tl.[Shift] = @shift;", conn, tx))
            {
                cmd.Parameters.Add("@offsetSeconds", SqlDbType.Int).Value = Convert.ToInt32(generalOffset.TotalSeconds, CultureInfo.InvariantCulture);
                cmd.Parameters.Add("@jitterSeconds", SqlDbType.Int).Value = jitterSeconds;
                cmd.Parameters.Add("@jitterSeed", SqlDbType.Int).Value = jitterSeed;
                cmd.Parameters.Add("@dayShift", SqlDbType.Int).Value = dayShift;
                AddParameterValue(cmd.Parameters, "@subsidiaryId", idSubsidiary);
                cmd.Parameters.Add("@oldProductionDate", SqlDbType.Date).Value = oldProductionDate.Date;
                cmd.Parameters.Add("@shift", SqlDbType.TinyInt).Value = shift;
                cmd.CommandTimeout = 0;
                ExecuteNonQueryLogged(cmd);
            }
        }

        static void RecalculateShiftBucket(SqlConnection conn, SqlTransaction tx, object idSubsidiary, object idWorkGroup, DateTime productionDate, byte shift)
        {
            double? totalReferenceIwt = LoadReferenceIwtForShiftBucket(conn, tx, idSubsidiary, idWorkGroup, productionDate, shift);
            if (!totalReferenceIwt.HasValue)
            {
                RefreshShiftBucketWithoutReferenceData(conn, tx, idSubsidiary, idWorkGroup, productionDate, shift);
                return;
            }

            try
            {
                using (var cmd = new SqlCommand("dbo.TimeLog_UpdateValuesForShiftDate", conn, tx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameterValue(cmd.Parameters, "@IDSubsidiary", idSubsidiary);
                    AddParameterValue(cmd.Parameters, "@IDWorkGroup", idWorkGroup);
                    cmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = productionDate.Date;
                    cmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = shift;
                    cmd.Parameters.Add("@TotalReferenceIWT", SqlDbType.Float).Value = totalReferenceIwt.Value;
                    cmd.CommandTimeout = 0;
                    ExecuteNonQueryLogged(cmd);
                }

                using (var cmd = new SqlCommand("dbo.RecalculateTimeLogAndProductionData", conn, tx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameterValue(cmd.Parameters, "@IDSubsidiary", idSubsidiary);
                    AddParameterValue(cmd.Parameters, "@IDWorkGroup", idWorkGroup);
                    cmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = productionDate.Date;
                    cmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = shift;
                    cmd.CommandTimeout = 0;
                    ExecuteNonQueryLogged(cmd);
                }
            }
            catch (SqlException ex) when (ShouldUseLegacyRecalculationFallback(ex))
            {
                WriteWarning(
                    $"Legacy recalculation fallback used for workgroup {idWorkGroup} on {productionDate:yyyy-MM-dd} / shift {shift}: {ex.Message}");
                RefreshShiftBucketWithoutReferenceData(conn, tx, idSubsidiary, idWorkGroup, productionDate, shift);
            }
        }

        static double? LoadReferenceIwtForShiftBucket(
            SqlConnection conn,
            SqlTransaction tx,
            object idSubsidiary,
            object idWorkGroup,
            DateTime productionDate,
            byte shift)
        {
            using (var cmd = new SqlCommand(
                @"SELECT TOP (1) [TotalReferenceIWT]
                  FROM [dbo].[ProductionData]
                  WHERE [IDSubsidiary] = @subsidiaryId
                    AND [IDWorkGroup] = @workGroupId
                    AND CONVERT(date, [ProductionDate]) = @productionDate
                    AND [Shift] = @shift
                    AND [TotalReferenceIWT] > -1
                  ORDER BY [TotalReferenceIWT] DESC", conn, tx))
            {
                AddParameterValue(cmd.Parameters, "@subsidiaryId", idSubsidiary);
                AddParameterValue(cmd.Parameters, "@workGroupId", idWorkGroup);
                cmd.Parameters.Add("@productionDate", SqlDbType.Date).Value = productionDate.Date;
                cmd.Parameters.Add("@shift", SqlDbType.TinyInt).Value = shift;

                object value = ExecuteScalarLogged(cmd);
                if (value == null || value == DBNull.Value)
                    return null;

                return Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
        }

        static void RefreshShiftBucketWithoutReferenceData(
            SqlConnection conn,
            SqlTransaction tx,
            object idSubsidiary,
            object idWorkGroup,
            DateTime productionDate,
            byte shift)
        {
            using (var cmd = new SqlCommand(
                @"UPDATE tl
                  SET [AttendanceTime] = calc.[AttendanceTime],
                      [WorkingTime] = calc.[AttendanceTime] - tl.[WorkBreak],
                      [IncentiveWageTime] = calc.[AttendanceTime] - tl.[WorkBreak] - tl.[DownTime],
                      [IncentiveWageTimeAdj] = (calc.[AttendanceTime] - tl.[WorkBreak] - tl.[DownTime])
                                               - ((calc.[AttendanceTime] - tl.[WorkBreak] - tl.[DownTime]) * tl.[Handicap] / 100.0),
                      [DegreeOfTime] = -2,
                      [DegreeOfTimeAdj] = -2,
                      [ReferenceWageTimeProRata] = -2,
                      [LastEdited] = GETDATE()
                  FROM [dbo].[TimeLog] tl
                  CROSS APPLY (
                        SELECT DATEDIFF(MINUTE, tl.[ShiftStart], tl.[ShiftEnd]) AS [AttendanceTime]
                  ) calc
                  WHERE tl.[IDSubsidiary] = @subsidiaryId
                    AND tl.[IDWorkGroup] = @workGroupId
                    AND CONVERT(date, tl.[ProductionDate]) = @productionDate
                    AND tl.[Shift] = @shift;

                  UPDATE pd
                  SET [DegreeOfTime] = CASE WHEN pd.[DegreeOfTime] IS NULL OR pd.[DegreeOfTime] < -1 THEN -2 ELSE pd.[DegreeOfTime] END,
                      [DegreeOfTimeAdj] = CASE WHEN pd.[DegreeOfTimeAdj] IS NULL OR pd.[DegreeOfTimeAdj] < -1 THEN -2 ELSE pd.[DegreeOfTimeAdj] END,
                      [LastEdited] = GETDATE()
                  FROM [dbo].[ProductionData] pd
                  WHERE pd.[IDSubsidiary] = @subsidiaryId
                    AND pd.[IDWorkGroup] = @workGroupId
                    AND CONVERT(date, pd.[ProductionDate]) = @productionDate
                    AND pd.[Shift] = @shift;", conn, tx))
            {
                AddParameterValue(cmd.Parameters, "@subsidiaryId", idSubsidiary);
                AddParameterValue(cmd.Parameters, "@workGroupId", idWorkGroup);
                cmd.Parameters.Add("@productionDate", SqlDbType.Date).Value = productionDate.Date;
                cmd.Parameters.Add("@shift", SqlDbType.TinyInt).Value = shift;
                cmd.CommandTimeout = 0;
                ExecuteNonQueryLogged(cmd);
            }
        }

        static bool ShouldUseLegacyRecalculationFallback(SqlException ex) =>
            ex != null &&
            ((ex.Number == 515 &&
              (ex.Message.IndexOf("DegreeOfTime", StringComparison.OrdinalIgnoreCase) >= 0 ||
               ex.Message.IndexOf("ReferenceWageTimeProRata", StringComparison.OrdinalIgnoreCase) >= 0)) ||
             ex.Number == 8134 ||
             ex.Message.IndexOf("divide by zero", StringComparison.OrdinalIgnoreCase) >= 0);

        static List<ShiftProgressItem> LoadShiftBucketDetails(SqlConnection conn, object idSubsidiary, DateTime productionDate, byte shift)
        {
            var result = new List<ShiftProgressItem>();

            using (var cmd = new SqlCommand(
                @"SELECT g.[IDSubsidiary],
                         g.[ProductionDate],
                         g.[Shift],
                         g.[IDWorkGroup],
                         COALESCE(wg.[WorkgroupName], N'(unknown)') AS [WorkgroupName],
                         tl.[MinStart],
                         tl.[MaxEnd],
                         pd.[DegreeOfTime],
                         pd.[DegreeOfTimeAdj],
                         ISNULL(tl.[EntryCount], 0) AS [EntryCount]
                  FROM (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup]
                        FROM [dbo].[ProductionData]
                        WHERE [IDSubsidiary] = @subsidiaryId AND CONVERT(date, [ProductionDate]) = @productionDate AND [Shift] = @shift
                        UNION
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup]
                        FROM [dbo].[TimeLog]
                        WHERE [IDSubsidiary] = @subsidiaryId AND CONVERT(date, [ProductionDate]) = @productionDate AND [Shift] = @shift
                  ) g
                  LEFT JOIN (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup],
                               MIN([ShiftStart]) AS [MinStart],
                               MAX([ShiftEnd]) AS [MaxEnd],
                               COUNT(*) AS [EntryCount]
                        FROM [dbo].[TimeLog]
                        WHERE [IDSubsidiary] = @subsidiaryId AND CONVERT(date, [ProductionDate]) = @productionDate AND [Shift] = @shift
                        GROUP BY [IDSubsidiary], CONVERT(date, [ProductionDate]), [Shift], [IDWorkGroup]
                  ) tl
                    ON tl.[IDSubsidiary] = g.[IDSubsidiary]
                   AND tl.[ProductionDate] = g.[ProductionDate]
                   AND tl.[Shift] = g.[Shift]
                   AND tl.[IDWorkGroup] = g.[IDWorkGroup]
                  LEFT JOIN (
                        SELECT [IDSubsidiary], CONVERT(date, [ProductionDate]) AS [ProductionDate], [Shift], [IDWorkGroup],
                               MAX([DegreeOfTime]) AS [DegreeOfTime],
                               MAX([DegreeOfTimeAdj]) AS [DegreeOfTimeAdj]
                        FROM [dbo].[ProductionData]
                        WHERE [IDSubsidiary] = @subsidiaryId AND CONVERT(date, [ProductionDate]) = @productionDate AND [Shift] = @shift
                        GROUP BY [IDSubsidiary], CONVERT(date, [ProductionDate]), [Shift], [IDWorkGroup]
                  ) pd
                    ON pd.[IDSubsidiary] = g.[IDSubsidiary]
                   AND pd.[ProductionDate] = g.[ProductionDate]
                   AND pd.[Shift] = g.[Shift]
                   AND pd.[IDWorkGroup] = g.[IDWorkGroup]
                  LEFT JOIN [dbo].[WorkGroups] wg
                    ON wg.[IDSubsidiary] = g.[IDSubsidiary]
                   AND wg.[IDWorkGroup] = g.[IDWorkGroup]
                  ORDER BY [WorkgroupName]", conn))
            {
                AddParameterValue(cmd.Parameters, "@subsidiaryId", idSubsidiary);
                cmd.Parameters.Add("@productionDate", SqlDbType.Date).Value = productionDate.Date;
                cmd.Parameters.Add("@shift", SqlDbType.TinyInt).Value = shift;

                using (var reader = ExecuteReaderLogged(cmd))
                {
                    while (reader.Read())
                    {
                        result.Add(new ShiftProgressItem
                        {
                            IDSubsidiary = GetIdentifierValue(reader, "IDSubsidiary"),
                            ProductionDate = GetDateTimeValue(reader, "ProductionDate").Date,
                            Shift = GetByteValue(reader, "Shift"),
                            IDWorkGroup = GetIdentifierValue(reader, "IDWorkGroup"),
                            WorkgroupName = GetStringValue(reader, "WorkgroupName", "(unknown)"),
                            OriginalStart = GetNullableDateTimeValue(reader, "MinStart"),
                            OriginalEnd = GetNullableDateTimeValue(reader, "MaxEnd"),
                            DegreeOfTime = GetNullableDoubleValue(reader, "DegreeOfTime"),
                            DegreeOfTimeAdj = GetNullableDoubleValue(reader, "DegreeOfTimeAdj"),
                            EntryCount = GetInt32Value(reader, "EntryCount")
                        });
                    }
                }
            }

            return result;
        }

        static void SetOperationalTriggersEnabled(SqlConnection conn, bool enabled)
        {
            string[] commands =
            {
                $"{(enabled ? "ENABLE" : "DISABLE")} TRIGGER dbo.OnTimeLog_Delete ON dbo.TimeLog",
                $"{(enabled ? "ENABLE" : "DISABLE")} TRIGGER dbo.OnTimeLog_InsertUpdate ON dbo.TimeLog",
                $"{(enabled ? "ENABLE" : "DISABLE")} TRIGGER dbo.OnProductionData_InsertUpdate ON dbo.ProductionData",
                $"{(enabled ? "ENABLE" : "DISABLE")} TRIGGER dbo.OnProductionDataItems_InsertUpdateDelete ON dbo.ProductionDataItems"
            };

            foreach (string commandText in commands)
            {
                using (var cmd = new SqlCommand(commandText, conn))
                    ExecuteNonQueryLogged(cmd);
            }
        }

        static bool PromptYesNo(string prompt, bool defaultValue)
        {
            while (true)
            {
                Console.Write($"{prompt} {(defaultValue ? "[Y/n]" : "[y/N]")}: ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    return defaultValue;

                if (input.Equals("y", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("j", StringComparison.OrdinalIgnoreCase))
                    return true;

                if (input.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("no", StringComparison.OrdinalIgnoreCase))
                    return false;

                Console.WriteLine("Please answer with 'y' or 'n'.");
            }
        }

        static TimeSpan PromptSignedTimeOffset(string prompt, TimeSpan defaultValue)
        {
            while (true)
            {
                Console.Write($"{prompt} [{FormatSignedTimeSpan(defaultValue)}]: ");
                string input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                    return defaultValue;

                if (TryParseSignedTimeSpan(input, out TimeSpan value))
                    return value;

                Console.WriteLine("Please enter a value like -1:30, 0, or +0:45.");
            }
        }

        static bool TryParseSignedTimeSpan(string input, out TimeSpan result)
        {
            result = TimeSpan.Zero;
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input == "0")
            {
                result = TimeSpan.Zero;
                return true;
            }

            bool isNegative = input.StartsWith("-", StringComparison.Ordinal);
            if (input.StartsWith("+", StringComparison.Ordinal) || isNegative)
                input = input.Substring(1);

            string[] formats = { @"h\:mm", @"hh\:mm", @"h\:mm\:ss", @"hh\:mm\:ss" };
            if (!TimeSpan.TryParseExact(input, formats, CultureInfo.InvariantCulture, out result) &&
                !TimeSpan.TryParse(input, CultureInfo.InvariantCulture, out result))
                return false;

            if (isNegative)
                result = -result;

            return true;
        }

        static int PromptInteger(string prompt, int defaultValue, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write($"{prompt} [{defaultValue}]: ");
                string input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                    return defaultValue;

                if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value) &&
                    value >= minValue && value <= maxValue)
                    return value;

                Console.WriteLine($"Please enter a whole number between {minValue} and {maxValue}.");
            }
        }

        static DateTime PromptDate(string prompt, DateTime defaultValue)
        {
            while (true)
            {
                Console.Write($"{prompt} [{defaultValue:yyyy-MM-dd}]: ");
                string input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                    return defaultValue.Date;

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime value))
                    return value.Date;

                Console.WriteLine("Please enter the date in yyyy-mm-dd format.");
            }
        }

        static string PromptString(string prompt, string defaultValue, bool allowEmpty)
        {
            while (true)
            {
                Console.Write($"{prompt} [{defaultValue}]: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    input = defaultValue;

                input = input?.Trim();
                if (allowEmpty || !string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Please enter a non-empty value.");
            }
        }

        static Random NewRandom() =>
            new Random(unchecked(Environment.TickCount * 397) ^ DateTime.Now.Millisecond);

        static string CreateUniqueUserName(PersonIdentity identity, HashSet<string> usedUserNames, int index)
        {
            string baseName = NormalizeUserName($"{identity.FirstName}.{identity.LastName}");
            if (string.IsNullOrWhiteSpace(baseName))
                baseName = "demo.user";

            string candidate = baseName;
            int suffix = index;
            while (!usedUserNames.Add(candidate))
                candidate = $"{baseName}{suffix++:00}";

            return Truncate(candidate, 100);
        }

        static string NormalizeUserName(string value)
        {
            string normalized = RemoveDiacritics(value ?? string.Empty).ToLowerInvariant();
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                    sb.Append(c);
                else if ((c == '.' || c == '_' || c == '-') && sb.Length > 0)
                    sb.Append(c);
            }

            return sb.ToString().Trim('.', '_', '-');
        }

        static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(normalized.Length);
            foreach (char c in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        static List<PersonIdentity> BuildInternationalNamePool() =>
            new List<PersonIdentity>
            {
                new PersonIdentity("Luca", "Bennett"),
                new PersonIdentity("Sofia", "Meyer"),
                new PersonIdentity("Kenji", "Tanaka"),
                new PersonIdentity("Mei", "Lin"),
                new PersonIdentity("Oliver", "Hughes"),
                new PersonIdentity("Emma", "Garcia"),
                new PersonIdentity("Mateo", "Santos"),
                new PersonIdentity("Ava", "Walker"),
                new PersonIdentity("Hana", "Novak"),
                new PersonIdentity("Anika", "Schulz"),
                new PersonIdentity("Diego", "Navarro"),
                new PersonIdentity("Grace", "Turner"),
                new PersonIdentity("Noah", "Fischer"),
                new PersonIdentity("Yuna", "Park"),
                new PersonIdentity("Mila", "Rossi"),
                new PersonIdentity("Ethan", "Brooks"),
                new PersonIdentity("Clara", "Weber"),
                new PersonIdentity("Leo", "Moreau"),
                new PersonIdentity("Aiko", "Sato"),
                new PersonIdentity("Samuel", "Carter"),
                new PersonIdentity("Elena", "Vega"),
                new PersonIdentity("Jonas", "Lindberg"),
                new PersonIdentity("Priya", "Shaw"),
                new PersonIdentity("Iris", "Collins"),
                new PersonIdentity("Tomas", "Silva"),
                new PersonIdentity("Nina", "Keller"),
                new PersonIdentity("Haruto", "Watanabe"),
                new PersonIdentity("Isla", "Reed"),
                new PersonIdentity("Carlos", "Morales"),
                new PersonIdentity("Maya", "Bauer"),
                new PersonIdentity("Felix", "Arnold"),
                new PersonIdentity("Lina", "Petrov"),
                new PersonIdentity("Julian", "Scott"),
                new PersonIdentity("Naomi", "Yamamoto"),
                new PersonIdentity("Adrian", "Lopez"),
                new PersonIdentity("Ella", "Murphy"),
                new PersonIdentity("Kai", "Nguyen"),
                new PersonIdentity("Ruby", "Bishop"),
                new PersonIdentity("Mason", "Diaz"),
                new PersonIdentity("Chloe", "Evans")
            };

        static List<string> BuildFunnyLaundryServiceNames() =>
            new List<string>
            {
                "Spin Doctors Industrial Laundry",
                "Soap Opera Linen Works",
                "Steam Dream Services",
                "Wrinkle Wranglers Plant",
                "Suds and Steel Laundry Co.",
                "The Tumble Titans",
                "Fresh Press Express",
                "Boiler Room Bubbles",
                "Lint Legends Washhouse",
                "Foam Rangers Textile Care",
                "Cloud Nine Laundry Lines",
                "Blue Apron Pressworks",
                "Starch Command Central",
                "Whirlwind Workwear Wash",
                "Bright Basket Industries",
                "Happy Hanger Fabric Flow",
                "Sparkle Shift Laundry",
                "Fold Patrol Services",
                "Rinse Cycle Heroes",
                "The Gentle Spin Factory",
                "White Glove Wash Systems",
                "Clean Machine Collective",
                "Velvet Steam Linen Lab",
                "Fresh Load Logistics",
                "Mop and Marvel Laundry",
                "Iron Smile Textile Works",
                "Shiny Sheet Syndicate",
                "Bubble Batch Industries",
                "Soft Spin Solutions",
                "Press and Impress Laundry",
                "Neat Nest Linen Care",
                "Whistle Clean Works",
                "Fizzy Fabric Foundry",
                "Rinse and Roll Services",
                "Crystal Collar Laundry",
                "Fluff Factor Wash Co.",
                "Polished Pocket Textile Care",
                "Steam Team Industrial Wash",
                "Laundry Lantern Logistics",
                "Fresh Thread Factory",
                "Bright Barrel Linen Ops",
                "Silver Suds Plant",
                "Tidy Tunnel Textile Flow",
                "Laughing Linen Services",
                "Crisp Collar Collective",
                "Clean Sweep Workwear",
                "Foam Forge Laundry",
                "Sunny Spin Textile Care",
                "Ready Rinse Industries",
                "Jolly Press Laundry House"
            };

        static string BuildEnglishWorkgroupName(string currentName, int index)
        {
            string translated = TranslateNameTokens(currentName);
            if (string.IsNullOrWhiteSpace(translated))
                translated = "Laundry Process";

            return $"{translated} {index:00}";
        }

        static string BuildEnglishLabourValueName(string currentName, int index)
        {
            string translated = TranslateNameTokens(currentName);
            if (string.IsNullOrWhiteSpace(translated))
                translated = "Process Step";

            return $"{translated} {index:00}";
        }

        static string TranslateNameTokens(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string working = NormalizeTranslationInput(value);
            foreach (var pair in LaundryPhraseTranslations)
                working = ReplaceWholePhrase(working, pair.Key, pair.Value);

            working = Regex.Replace(
                working,
                @"[A-Za-z]+(?:\.[A-Za-z]+)?|\d+(?:\.\d+)?",
                match => TranslateSingleToken(match.Value),
                RegexOptions.CultureInvariant);

            return CleanupTranslatedText(working);
        }

        static string TranslateDimension(string dimension)
        {
            if (string.IsNullOrWhiteSpace(dimension))
                return "units";

            string normalized = NormalizeTranslationInput(dimension);
            switch (normalized)
            {
                case "stueck":
                case "stuck":
                case "stk":
                case "st":
                case "teil":
                case "teile":
                case "piece":
                case "pieces":
                    return "pieces";
                case "kg":
                case "kilogram":
                case "kilograms":
                    return "kg";
                case "std":
                case "stunde":
                case "stunden":
                case "hour":
                case "hours":
                    return "hours";
                case "min":
                case "minute":
                case "minutes":
                    return "minutes";
                case "sekunde":
                case "sekunden":
                case "sek":
                case "sec":
                case "second":
                case "seconds":
                    return "seconds";
                default:
                    return dimension;
            }
        }

        static string BuildWorkgroupDescription(string currentName, int index)
        {
            string normalized = NormalizeTranslationInput(currentName);

            if (ContainsAny(normalized, "schmutzwaesche", "sortier", "absortier", "zeichnen", "scan", "eingang"))
                return $"Demo workgroup {index:00} for soiled-linen intake, article identification, and sorting.";

            if (ContainsAny(normalized, "wasch", "trockner", "twe", "wsm", "fas", "fex"))
                return $"Demo workgroup {index:00} for washing, extraction, and drying operations.";

            if (ContainsAny(normalized, "mangel", "finisher", "press", "buegel", "dampf"))
                return $"Demo workgroup {index:00} for flatwork and garment finishing.";

            if (ContainsAny(normalized, "legen", "falt", "frottee"))
                return $"Demo workgroup {index:00} for folding, terry processing, and clean-linen presentation.";

            if (ContainsAny(normalized, "naehen", "naeh", "reparatur", "ausbessern"))
                return $"Demo workgroup {index:00} for sewing, alteration, and textile repair.";

            if (ContainsAny(normalized, "versand", "expedition", "pack", "ausgang"))
                return $"Demo workgroup {index:00} for packing and dispatch of clean linen and garments.";

            if (ContainsAny(normalized, "chemisch", "vorhang", "gardin"))
                return $"Demo workgroup {index:00} for specialty care such as dry cleaning and curtain processing.";

            return $"Demo workgroup {index:00} for industrial laundry operations.";
        }

        static string BuildLabourValueDescription(string currentName, int index)
        {
            string normalized = NormalizeTranslationInput(currentName);

            if (ContainsAny(normalized, "schmutzwaesche", "sortier", "absortier", "scan", "eingang"))
                return $"Demo labour value {index:00} for intake, scanning, and sorting of soiled linen.";

            if (ContainsAny(normalized, "waschschleudermaschine", "wasch", "trockner", "beschicken", "beladen", "entladen"))
                return $"Demo labour value {index:00} for washer, extractor, or dryer loading and unloading.";

            if (ContainsAny(normalized, "mangel", "laken", "formlaken", "tischdecken", "bezug", "stecklaken"))
                return $"Demo labour value {index:00} for flatwork ironing and finishing of sheets, covers, and table linen.";

            if (ContainsAny(normalized, "frottee", "legen", "falten", "handtuch", "badetuch"))
                return $"Demo labour value {index:00} for folding terry goods, towels, or other clean textiles.";

            if (ContainsAny(normalized, "finisher", "press", "buegel", "dampf", "oberhemd", "kittel", "kasak"))
                return $"Demo labour value {index:00} for garment finishing, steaming, or press operations.";

            if (ContainsAny(normalized, "naehen", "naeh", "reparatur", "flicken"))
                return $"Demo labour value {index:00} for sewing, repair, and alteration work.";

            if (ContainsAny(normalized, "versand", "expedition", "pack", "ausgang"))
                return $"Demo labour value {index:00} for packing, allocation, and dispatch of finished items.";

            if (ContainsAny(normalized, "vorhang", "gardin"))
                return $"Demo labour value {index:00} for curtain and specialty-textile care.";

            return $"Demo labour value {index:00} for a typical industrial laundry process step.";
        }

        static bool ContainsAny(string text, params string[] values) =>
            values.Any(value => text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0);

        static string NormalizeTranslationInput(string value)
        {
            string working = (value ?? string.Empty).Trim();
            if (working.Length == 0)
                return string.Empty;

            working = working
                .Replace("Ä", "Ae").Replace("Ö", "Oe").Replace("Ü", "Ue")
                .Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue")
                .Replace("ß", "ss")
                .Replace("&", " und ");

            working = RemoveDiacritics(working);
            working = Regex.Replace(working, @"(?<=\d),(?=\d)", ".", RegexOptions.CultureInvariant);
            working = Regex.Replace(working, @"[_/\\\-]+", " ", RegexOptions.CultureInvariant);
            working = Regex.Replace(working, @"\s+", " ", RegexOptions.CultureInvariant).Trim().ToLowerInvariant();

            while (Regex.IsMatch(working, @"\s\d{2,3}$", RegexOptions.CultureInvariant))
                working = Regex.Replace(working, @"\s\d{2,3}$", string.Empty, RegexOptions.CultureInvariant).Trim();

            return working;
        }

        static string ReplaceWholePhrase(string input, string search, string replacement)
        {
            string pattern = Regex.Escape(search).Replace(@"\ ", @"\s+");
            return Regex.Replace(
                input,
                $@"(?<![a-z0-9]){pattern}(?![a-z0-9])",
                _ => replacement,
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }

        static string TranslateSingleToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return string.Empty;

            if (Regex.IsMatch(token, @"^\d+(?:\.\d+)?$", RegexOptions.CultureInvariant))
                return token;

            if (token.Any(char.IsUpper))
                return token;

            if (LaundryWordTranslations.TryGetValue(token, out string translated))
                return translated;

            if (token.Any(char.IsDigit))
                return token.ToUpperInvariant();

            return CapitalizeWord(token);
        }

        static string CleanupTranslatedText(string value)
        {
            string cleaned = Regex.Replace(value ?? string.Empty, @"\s+", " ", RegexOptions.CultureInvariant).Trim();
            cleaned = Regex.Replace(cleaned, @"\s+([,.;:)])", "$1", RegexOptions.CultureInvariant);
            cleaned = Regex.Replace(cleaned, @"([(<])\s+", "$1", RegexOptions.CultureInvariant);
            cleaned = Regex.Replace(cleaned, @"\s*(<=|>=|=|<|>)\s*", " $1 ", RegexOptions.CultureInvariant);
            cleaned = Regex.Replace(cleaned, @"\b(Program|Category|incl)\.", "$1", RegexOptions.CultureInvariant);
            cleaned = Regex.Replace(cleaned, @"\s+", " ", RegexOptions.CultureInvariant).Trim();
            cleaned = cleaned.Replace("Kg", "kg");
            return cleaned;
        }

        static KeyValuePair<string, string>[] BuildLaundryPhraseTranslations()
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("schmutzwaesche eingang", "Soiled Linen Intake"),
                new KeyValuePair<string, string>("schmutzwaesche eingang nach reorg", "Soiled Linen Intake After Reorg"),
                new KeyValuePair<string, string>("schmutzwaesche", "Soiled Linen"),
                new KeyValuePair<string, string>("zeichnen sw", "Soiled Linen Marking"),
                new KeyValuePair<string, string>("saubere waesche", "Clean Linen"),
                new KeyValuePair<string, string>("bewohnerwaesche", "Resident Laundry"),
                new KeyValuePair<string, string>("objektwaesche", "Facility Linen"),
                new KeyValuePair<string, string>("privatwaesche", "Personal Laundry"),
                new KeyValuePair<string, string>("weisswaesche", "White Linen"),
                new KeyValuePair<string, string>("mietberufskleidung", "Rental Workwear"),
                new KeyValuePair<string, string>("mietkleidung", "Rental Garments"),
                new KeyValuePair<string, string>("berufsbekleidung", "Workwear"),
                new KeyValuePair<string, string>("berufskleidung", "Workwear"),
                new KeyValuePair<string, string>("chemische reinigung", "Dry Cleaning"),
                new KeyValuePair<string, string>("chemische reiningung", "Dry Cleaning"),
                new KeyValuePair<string, string>("frottee legemaschine", "Terry Folding Machine"),
                new KeyValuePair<string, string>("legen von hand", "Hand Folding"),
                new KeyValuePair<string, string>("legen v. hand", "Hand Folding"),
                new KeyValuePair<string, string>("legen v hand", "Hand Folding"),
                new KeyValuePair<string, string>("pressen kombination", "Press Combination"),
                new KeyValuePair<string, string>("trocknen und legen", "Drying and Folding"),
                new KeyValuePair<string, string>("waschen und legen", "Washing and Folding"),
                new KeyValuePair<string, string>("grossteilemangel", "Large-Piece Ironer"),
                new KeyValuePair<string, string>("tunnel finisher", "Tunnel Finisher"),
                new KeyValuePair<string, string>("tunnelfinisher", "Tunnel Finisher"),
                new KeyValuePair<string, string>("absortierband", "Sorting Conveyor"),
                new KeyValuePair<string, string>("container schleuse", "Container Airlock"),
                new KeyValuePair<string, string>("reine seite", "Clean Side"),
                new KeyValuePair<string, string>("unreine seite", "Soiled Side"),
                new KeyValuePair<string, string>("naehen ausbessern", "Sewing and Repair"),
                new KeyValuePair<string, string>("kurzzeitpflege", "Short-Stay Care"),
                new KeyValuePair<string, string>("tagespflege", "Day Care"),
                new KeyValuePair<string, string>("altenheim", "Care Home"),
                new KeyValuePair<string, string>("krankenhaus", "Hospital"),
                new KeyValuePair<string, string>("op stecklaken", "OR Draw Sheets"),
                new KeyValuePair<string, string>("op kleinteile", "OR Small Pieces"),
                new KeyValuePair<string, string>("op laken", "OR Sheets"),
                new KeyValuePair<string, string>("op kasak", "OR Scrub Top"),
                new KeyValuePair<string, string>("op hosen", "OR Trousers"),
                new KeyValuePair<string, string>("op maentel", "OR Coats"),
                new KeyValuePair<string, string>("oberhemden", "Shirts"),
                new KeyValuePair<string, string>("nachthemden", "Nightgowns"),
                new KeyValuePair<string, string>("fluegelhemden", "Patient Gowns"),
                new KeyValuePair<string, string>("kissenbezuege", "Pillowcases"),
                new KeyValuePair<string, string>("kopfkissen", "Pillows"),
                new KeyValuePair<string, string>("formlaken", "Fitted Sheets"),
                new KeyValuePair<string, string>("stecklaken", "Draw Sheets"),
                new KeyValuePair<string, string>("deckservietten", "Table Napkins"),
                new KeyValuePair<string, string>("mundservietten", "Napkins"),
                new KeyValuePair<string, string>("tischdecken", "Tablecloths"),
                new KeyValuePair<string, string>("steppdecke", "Quilt"),
                new KeyValuePair<string, string>("wolldecken", "Wool Blankets"),
                new KeyValuePair<string, string>("vorhaenge", "Curtains"),
                new KeyValuePair<string, string>("waeschesaecke", "Linen Bags"),
                new KeyValuePair<string, string>("waeschesacke", "Linen Bags"),
                new KeyValuePair<string, string>("waesche sortieren", "Linen Sorting"),
                new KeyValuePair<string, string>("inkl. waesche sortieren", "incl. Linen Sorting"),
                new KeyValuePair<string, string>("inkl waesche sortieren", "incl. Linen Sorting"),
                new KeyValuePair<string, string>("be und entladen", "Load and Unload"),
                new KeyValuePair<string, string>("beschicken und entnehmen", "Feed and Remove"),
                new KeyValuePair<string, string>("eingabe abnahme", "Feed/Take-Off"),
                new KeyValuePair<string, string>("inkontinenzunterlagen", "Incontinence Pads"),
                new KeyValuePair<string, string>("badetuecher", "Bath Towels"),
                new KeyValuePair<string, string>("handtuecher", "Towels"),
                new KeyValuePair<string, string>("unterwaesche", "Underwear"),
                new KeyValuePair<string, string>("grossteile", "Large Pieces"),
                new KeyValuePair<string, string>("kleinteile", "Small Pieces"),
                new KeyValuePair<string, string>("gastrockner", "Gas Dryer"),
                new KeyValuePair<string, string>("saugtrockner", "Suction Dryer"),
                new KeyValuePair<string, string>("waschschleudermaschine", "Washer-Extractor"),
                new KeyValuePair<string, string>("shock finisher", "Shock Finisher")
            };

            return values.OrderByDescending(x => x.Key.Length).ToArray();
        }

        static Dictionary<string, string> BuildLaundryWordTranslations() =>
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["mbk"] = "Rental Workwear",
                ["bk"] = "Workwear",
                ["sw"] = "Soiled Linen",
                ["wsm"] = "WSM",
                ["twe"] = "TWE",
                ["fas"] = "FAS",
                ["fex"] = "FEX",
                ["p50"] = "P50",
                ["lva"] = "LVA",
                ["op"] = "OR",
                ["prg"] = "Program",
                ["prog"] = "Program",
                ["programm"] = "Program",
                ["cat"] = "Category",
                ["kg"] = "kg",
                ["u"] = "and",
                ["und"] = "and",
                ["inkl"] = "incl",
                ["incl"] = "incl",
                ["bzw"] = "resp.",
                ["privat"] = "Private",
                ["ausbildungs"] = "Training",
                ["waesche"] = "Linen",
                ["kissen"] = "Pillows",
                ["spanntuecher"] = "Stretch Sheets",
                ["waschstrasse"] = "Wash Line",
                ["einrichtung"] = "Setup",
                ["komplettierung"] = "Completion",
                ["eingang"] = "Intake",
                ["neueingang"] = "New Intake",
                ["ausgang"] = "Dispatch",
                ["sortieren"] = "Sorting",
                ["sortiert"] = "Sorted",
                ["absortieren"] = "Sorting",
                ["zeichnen"] = "Marking",
                ["zeichnene"] = "Marked",
                ["gezeichnete"] = "Marked",
                ["beladen"] = "Loading",
                ["entladen"] = "Unloading",
                ["beschicken"] = "Feeding",
                ["abnehmen"] = "Removing",
                ["entleeren"] = "Emptying",
                ["kontrollieren"] = "Inspecting",
                ["kontrolle"] = "Inspection",
                ["kontroll"] = "Inspection",
                ["auslesen"] = "Scan Out",
                ["einlesen"] = "Scan In",
                ["einscannen"] = "Scanning",
                ["scannen"] = "Scanning",
                ["zuordnen"] = "Allocation",
                ["verpacken"] = "Packing",
                ["packen"] = "Packing",
                ["ablegen"] = "Stacking",
                ["abstellen"] = "Staging",
                ["reinigung"] = "Cleaning",
                ["waescherei"] = "Laundry Service",
                ["wascherei"] = "Laundry Service",
                ["mangel"] = "Flatwork Ironer",
                ["finisher"] = "Finisher",
                ["pressen"] = "Pressing",
                ["presse"] = "Press",
                ["hosenpresse"] = "Trouser Press",
                ["hosentopper"] = "Trouser Topper",
                ["frottee"] = "Terry",
                ["legen"] = "Folding",
                ["falten"] = "Folding",
                ["naehen"] = "Sewing",
                ["naeherei"] = "Sewing Room",
                ["naehklasse"] = "Sewing Class",
                ["ausbessern"] = "Repair",
                ["reparatur"] = "Repair",
                ["reparaturkontrolle"] = "Repair Inspection",
                ["flicken"] = "Patch Repair",
                ["aufbuegeln"] = "Press Finish",
                ["abbuegeln"] = "Finish Press",
                ["nachbuegeln"] = "Touch-Up Ironing",
                ["handbuegeln"] = "Hand Ironing",
                ["daempfen"] = "Steam Finish",
                ["dampfen"] = "Steam Finish",
                ["reine"] = "Clean",
                ["unreine"] = "Soiled",
                ["seite"] = "Side",
                ["bewohner"] = "Resident",
                ["kurzzeitpflege"] = "Short-Stay Care",
                ["tagespflege"] = "Day Care",
                ["verwalt"] = "Administration",
                ["cafe"] = "Cafe",
                ["hosen"] = "Trousers",
                ["jacken"] = "Jackets",
                ["jacke"] = "Jacket",
                ["mantel"] = "Coat",
                ["bluse"] = "Blouse",
                ["weste"] = "Waistcoat",
                ["krawatte"] = "Tie",
                ["pullover"] = "Sweater",
                ["hemd"] = "Shirt",
                ["hemden"] = "Shirts",
                ["kittel"] = "Coats",
                ["kochjacken"] = "Chef Jackets",
                ["schuerzen"] = "Aprons",
                ["schuerze"] = "Apron",
                ["kasak"] = "Scrub Top",
                ["maentel"] = "Coats",
                ["oberbekleidung"] = "Outerwear",
                ["mischgewebe"] = "Blended Fabric",
                ["wolle"] = "Wool",
                ["kleid"] = "Dress",
                ["rock"] = "Skirt",
                ["decken"] = "Blankets",
                ["sacke"] = "Bags",
                ["saecke"] = "Bags",
                ["windeln"] = "Diapers",
                ["matten"] = "Mats",
                ["molton"] = "Molton",
                ["spanner"] = "Stretch Sheets",
                ["laken"] = "Sheets",
                ["bezuege"] = "Covers",
                ["bezug"] = "Cover",
                ["quer"] = "Crosswise",
                ["laengs"] = "Lengthwise",
                ["leicht"] = "Light",
                ["schwer"] = "Heavy",
                ["gross"] = "Large",
                ["klein"] = "Small",
                ["grosse"] = "Large",
                ["kleine"] = "Small",
                ["hospital"] = "Hospital",
                ["altenheim"] = "Care Home",
                ["expedition"] = "Dispatch",
                ["versand"] = "Shipping",
                ["reorg"] = "Reorg",
                ["trocknen"] = "Drying",
                ["waschen"] = "Washing",
                ["trockner"] = "Dryer",
                ["linie"] = "Line",
                ["station"] = "Station",
                ["gruppe"] = "Group",
                ["schicht"] = "Shift",
                ["dienst"] = "Service",
                ["reinraum"] = "Cleanroom"
            };

        static string CapitalizeWord(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        static void DrawProgressBar(int current, int total, string status)
        {
            const int width = 32;
            int safeTotal = Math.Max(total, 1);
            int safeCurrent = Math.Max(0, Math.Min(current, safeTotal));
            int filled = (int)Math.Round((safeCurrent / (double)safeTotal) * width);
            string bar = new string('#', Math.Max(0, Math.Min(width, filled)))
                       + new string('-', Math.Max(0, width - filled));

            Console.Write($"\r[{bar}] {safeCurrent,3}/{safeTotal,-3} {safeCurrent * 100.0 / safeTotal,6:0.0}%  {Truncate(status, 50),-50}");
            if (safeCurrent == safeTotal)
                Console.WriteLine();
        }

        static string FormatMetric(double? value) =>
            value.HasValue ? value.Value.ToString("0.##", CultureInfo.InvariantCulture) : "-";

        static string FormatDateTime(DateTime? value) =>
            value.HasValue ? value.Value.ToString("yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) : "-";

        static string FormatTimeOfDay(TimeSpan? value) =>
            value.HasValue ? value.Value.ToString(@"hh\:mm", CultureInfo.InvariantCulture) : "--:--";

        static string FormatSignedTimeSpan(TimeSpan value)
        {
            if (value == TimeSpan.Zero)
                return "0:00";

            string sign = value < TimeSpan.Zero ? "-" : "+";
            value = value.Duration();
            return $"{sign}{(int)value.TotalHours}:{value.Minutes:00}";
        }

        static string MakeFileNameSafe(string value)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                value = value.Replace(c, '_');

            return value;
        }

        static string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            double size = bytes;
            int suffix = 0;
            while (size >= 1024 && suffix < suffixes.Length - 1)
            {
                size /= 1024;
                suffix++;
            }

            return $"{size:0.##} {suffixes[suffix]}";
        }
    }
}
