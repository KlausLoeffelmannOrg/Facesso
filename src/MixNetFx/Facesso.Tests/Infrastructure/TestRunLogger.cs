using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;

namespace Facesso.Tests.Infrastructure
{
    /// <summary>
    /// Central test run logger that writes a timestamped log file to C:\output.
    /// Records test lifecycle events (start, pass/fail, duration) and supports
    /// custom Info/Trace messages from within tests.
    /// </summary>
    public static class TestRunLogger
    {
        private static string _logFilePath;
        private static readonly object SyncLock = new object();

        internal static readonly ConcurrentDictionary<string, Stopwatch> ActiveTests
            = new ConcurrentDictionary<string, Stopwatch>();

        internal static void TestStarted(string testName)
        {
            ActiveTests[testName] = Stopwatch.StartNew();
            Log("STARTED ", testName);
        }

        internal static void TestFinished(string testName, string outcome)
        {
            if (ActiveTests.TryRemove(testName, out var sw))
            {
                sw.Stop();
                Log($"{outcome,-8}", $"{testName} ({sw.Elapsed.TotalSeconds:F3}s)");
            }
            else
            {
                Log($"{outcome,-8}", testName);
            }
        }

        /// <summary>
        /// Writes an INFO-level message to the test run log.
        /// Call from any test method to add context to the run report.
        /// </summary>
        public static void Info(string message) => Log("INFO    ", message);

        /// <summary>
        /// Writes a TRACE-level message to the test run log.
        /// Use for detailed diagnostics during test execution.
        /// </summary>
        public static void Trace(string message) => Log("TRACE   ", message);

        private static void Log(string level, string message)
        {
            try
            {
                var line = $"[{DateTime.Now:HH:mm:ss.fff}] {level}: {message}{Environment.NewLine}";
                lock (SyncLock)
                {
                    if (_logFilePath == null)
                    {
                        Directory.CreateDirectory(TestSettings.OutputRoot);
                        _logFilePath = Path.Combine(TestSettings.OutputRoot,
                            $"testrun_{DateTime.Now.ToString(TestSettings.TimestampFormat)}.txt");
                        File.WriteAllText(_logFilePath,
                            $"=== Test Run Started: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===" +
                            Environment.NewLine + Environment.NewLine);
                    }
                    File.AppendAllText(_logFilePath, line);
                }
            }
            catch
            {
                // Never fail a test due to logging issues
            }
        }
    }
}
