using System;
using System.IO;

namespace Facesso.Tests.Infrastructure
{
    /// <summary>
    /// Central configuration constants for the Facesso test suite.
    /// All output paths, report directories, and shared settings live here
    /// so they can be managed in one place.
    /// </summary>
    public static class TestSettings
    {
        /// <summary>
        /// Root output directory for all test artifacts (logs, reports, screenshots).
        /// </summary>
        public const string OutputRoot = @"C:\output";

        /// <summary>
        /// Timestamp format used for timestamped subdirectories and file names.
        /// Produces strings like "26-04-08_05-29-36".
        /// </summary>
        public const string TimestampFormat = "yy-MM-dd_HH-mm-ss";

        /// <summary>
        /// Creates a timestamped subdirectory under <see cref="OutputRoot"/> and returns its path.
        /// The directory is created on disk immediately.
        /// </summary>
        public static string CreateTimestampedOutputDir(string prefix)
        {
            string dirName = $"{prefix}_{DateTime.Now.ToString(TimestampFormat)}";
            string fullPath = Path.Combine(OutputRoot, dirName);
            Directory.CreateDirectory(fullPath);
            return fullPath;
        }

        /// <summary>
        /// Ensures <see cref="OutputRoot"/> exists and returns its path.
        /// </summary>
        public static string EnsureOutputRoot()
        {
            Directory.CreateDirectory(OutputRoot);
            return OutputRoot;
        }
    }
}
