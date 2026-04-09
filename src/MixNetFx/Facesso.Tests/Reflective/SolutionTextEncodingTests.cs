using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Facesso.Tests.Infrastructure;
using Xunit;

namespace Facesso.Tests.Reflective
{
    /// <summary>
    /// Best-effort guard against code-page regressions that can turn German umlauts
    /// into characters older Western UI fonts no longer render reliably.
    /// </summary>
    public class SolutionTextEncodingTests
    {
        private const string GermanUmlautSample = "äöüÄÖÜß";
        private const string ReportTimestampFormat = "yy-MM-dd_HH-mm";

        private static readonly UTF8Encoding StrictUtf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        private static readonly Regex ProjectEntryRegex = new Regex(
            "^\\s*Project\\(\"[^\"]+\"\\)\\s*=\\s*\"[^\"]+\"\\s*,\\s*\"(?<path>[^\"]+\\.(?:csproj|vbproj))\"",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        private static readonly Regex XmlEncodingRegex = new Regex(
            "encoding\\s*=\\s*[\"'](?<encoding>[^\"']+)[\"']",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        private static readonly HashSet<string> ProjectItemNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Compile",
            "EmbeddedResource",
            "None",
            "Content",
            "AdditionalFiles",
            "Resource",
            "Page",
            "ApplicationDefinition"
        };

        private static readonly HashSet<string> IgnoredDirectoryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "bin",
            "obj",
            ".git",
            ".vs",
            "packages"
        };

        private static readonly HashSet<string> BinaryExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".bmp",
            ".cur",
            ".dll",
            ".exe",
            ".gif",
            ".ico",
            ".jpeg",
            ".jpg",
            ".nupkg",
            ".pdb",
            ".pdf",
            ".pfx",
            ".png",
            ".snk",
            ".zip"
        };

        private static readonly HashSet<string> RelevantTextExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".config",
            ".cs",
            ".csproj",
            ".myapp",
            ".resx",
            ".settings",
            ".vb",
            ".vbproj",
            ".xml"
        };

        [Fact]
        public void SolutionOwnedTextFiles_UseUmlautSafeEncodings()
        {
            var solutionPath = GetOwningSolutionPath();
            var projectPaths = GetSolutionProjectPaths(solutionPath).ToList();
            var candidateFiles = GetCandidateFiles(solutionPath, projectPaths).ToList();

            Assert.NotEmpty(projectPaths);
            Assert.NotEmpty(candidateFiles);

            var violations = new List<ProblematicFileReportItem>();

            foreach (var filePath in candidateFiles)
            {
                var analysis = AnalyzeFile(filePath);
                if (!analysis.ShouldInspect || analysis.IsSafe)
                {
                    continue;
                }

                violations.Add(new ProblematicFileReportItem(
                    MakeRelativeToSolution(solutionPath, filePath),
                    analysis.EncodingLabel,
                    analysis.Reason));
            }

            var reportPath = WriteMarkdownReport(solutionPath, candidateFiles.Count, violations);
            TestRunLogger.Info($"Code page scan report: {reportPath}");

            Assert.True(
                violations.Count == 0,
                "Found solution-owned text files with an encoding or character set that is not safe for German umlauts / older Western fonts like Microsoft Sans Serif."
                + Environment.NewLine
                + $"Markdown report: {reportPath}"
                + Environment.NewLine
                + string.Join(Environment.NewLine, violations.Select(FormatViolation)));
        }

        private static string GetOwningSolutionPath([CallerFilePath] string callerFilePath = "")
        {
            var directory = new DirectoryInfo(Path.GetDirectoryName(callerFilePath) ?? throw new InvalidOperationException("CallerFilePath was not set."));

            while (directory != null)
            {
                foreach (var solutionFile in directory.GetFiles("*.sln", SearchOption.TopDirectoryOnly))
                {
                    var solutionText = File.ReadAllText(solutionFile.FullName, Encoding.UTF8);
                    if (solutionText.IndexOf("Facesso.Tests\\Facesso.Tests.csproj", StringComparison.OrdinalIgnoreCase) >= 0
                        || solutionText.IndexOf("Facesso.Tests/Facesso.Tests.csproj", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return solutionFile.FullName;
                    }
                }

                directory = directory.Parent;
            }

            throw new FileNotFoundException("Could not locate the owning solution for Facesso.Tests.", callerFilePath);
        }

        private static IEnumerable<string> GetSolutionProjectPaths(string solutionPath)
        {
            var solutionDirectory = Path.GetDirectoryName(solutionPath) ?? throw new InvalidOperationException("The solution directory could not be determined.");
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in File.ReadLines(solutionPath, Encoding.UTF8))
            {
                var match = ProjectEntryRegex.Match(line);
                if (!match.Success)
                {
                    continue;
                }

                var relativePath = match.Groups["path"].Value.Replace('/', Path.DirectorySeparatorChar);
                var fullPath = Path.GetFullPath(Path.Combine(solutionDirectory, relativePath));
                if (File.Exists(fullPath) && seen.Add(fullPath))
                {
                    yield return fullPath;
                }
            }
        }

        private static IEnumerable<string> GetCandidateFiles(string solutionPath, IEnumerable<string> projectPaths)
        {
            var solutionDirectory = Path.GetDirectoryName(solutionPath) ?? throw new InvalidOperationException("The solution directory could not be determined.");
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var projectPath in projectPaths)
            {
                foreach (var filePath in EnumerateProjectFiles(projectPath))
                {
                    if (IsWithinDirectory(solutionDirectory, filePath)
                        && IsRelevantTextFile(filePath)
                        && seen.Add(filePath))
                    {
                        yield return filePath;
                    }
                }
            }
        }

        private static IEnumerable<string> EnumerateProjectFiles(string projectPath)
        {
            yield return projectPath;

            var projectDirectory = Path.GetDirectoryName(projectPath) ?? throw new InvalidOperationException("The project directory could not be determined.");
            var projectXml = XDocument.Load(projectPath);
            var root = projectXml.Root ?? throw new InvalidOperationException($"Project file '{projectPath}' has no root element.");

            foreach (var item in root.Descendants().Where(element => ProjectItemNames.Contains(element.Name.LocalName)))
            {
                var include = (string)item.Attribute("Include");
                if (string.IsNullOrWhiteSpace(include))
                {
                    continue;
                }

                foreach (var resolvedPath in ExpandItemSpec(projectDirectory, include))
                {
                    if (File.Exists(resolvedPath) && !IsIgnoredPath(resolvedPath) && IsRelevantTextFile(resolvedPath))
                    {
                        yield return resolvedPath;
                    }
                }
            }

            if (IsSdkStyleProject(root))
            {
                foreach (var filePath in Directory.EnumerateFiles(projectDirectory, "*", SearchOption.AllDirectories))
                {
                    if (!IsIgnoredPath(filePath) && IsRelevantTextFile(filePath))
                    {
                        yield return filePath;
                    }
                }
            }
        }

        private static bool IsSdkStyleProject(XElement projectRoot)
        {
            return projectRoot.Attributes().Any(attribute => string.Equals(attribute.Name.LocalName, "Sdk", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> ExpandItemSpec(string projectDirectory, string include)
        {
            foreach (var rawPart in include.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var itemSpec = rawPart.Trim();
                if (string.IsNullOrWhiteSpace(itemSpec)
                    || itemSpec.StartsWith("$(", StringComparison.Ordinal)
                    || itemSpec.StartsWith("@(", StringComparison.Ordinal))
                {
                    continue;
                }

                var normalizedItemSpec = itemSpec.Replace('/', Path.DirectorySeparatorChar);
                if (normalizedItemSpec.IndexOf('*') >= 0 || normalizedItemSpec.IndexOf('?') >= 0)
                {
                    foreach (var wildcardMatch in ExpandWildcard(projectDirectory, normalizedItemSpec))
                    {
                        yield return wildcardMatch;
                    }

                    continue;
                }

                yield return Path.GetFullPath(Path.Combine(projectDirectory, normalizedItemSpec));
            }
        }

        private static IEnumerable<string> ExpandWildcard(string projectDirectory, string pattern)
        {
            var searchRoot = GetWildcardSearchRoot(projectDirectory, pattern, out var relativePattern);
            if (!Directory.Exists(searchRoot))
            {
                yield break;
            }

            var rootedPattern = Path.Combine(searchRoot, relativePattern);
            var regexPattern = "^" + Regex.Escape(rootedPattern)
                .Replace(@"\*\*", ".*")
                .Replace(@"\*", @"[^\\]*")
                .Replace(@"\?", @"[^\\]") + "$";
            var regex = new Regex(regexPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            foreach (var filePath in Directory.EnumerateFiles(searchRoot, "*", SearchOption.AllDirectories))
            {
                if (!IsIgnoredPath(filePath) && regex.IsMatch(filePath))
                {
                    yield return filePath;
                }
            }
        }

        private static string GetWildcardSearchRoot(string projectDirectory, string pattern, out string relativePattern)
        {
            var normalizedPattern = pattern.Replace('/', Path.DirectorySeparatorChar);
            var wildcardIndex = normalizedPattern.IndexOfAny(new[] { '*', '?' });
            if (wildcardIndex < 0)
            {
                relativePattern = Path.GetFileName(normalizedPattern);
                var searchRoot = Path.GetDirectoryName(normalizedPattern);
                return Path.GetFullPath(string.IsNullOrEmpty(searchRoot)
                    ? projectDirectory
                    : Path.Combine(projectDirectory, searchRoot));
            }

            var separatorIndex = normalizedPattern.LastIndexOf(Path.DirectorySeparatorChar, wildcardIndex);
            if (separatorIndex < 0)
            {
                relativePattern = normalizedPattern;
                return Path.GetFullPath(projectDirectory);
            }

            relativePattern = normalizedPattern.Substring(separatorIndex + 1);
            var rootPart = normalizedPattern.Substring(0, separatorIndex);
            return Path.GetFullPath(Path.Combine(projectDirectory, rootPart));
        }

        private static bool IsIgnoredPath(string filePath)
        {
            var directory = new FileInfo(filePath).Directory;
            while (directory != null)
            {
                if (IgnoredDirectoryNames.Contains(directory.Name))
                {
                    return true;
                }

                directory = directory.Parent;
            }

            return false;
        }

        private static bool IsRelevantTextFile(string filePath)
        {
            return RelevantTextExtensions.Contains(Path.GetExtension(filePath));
        }

        private static bool IsWithinDirectory(string directoryPath, string filePath)
        {
            var normalizedDirectory = Path.GetFullPath(AppendDirectorySeparator(directoryPath));
            var normalizedFilePath = Path.GetFullPath(filePath);
            return normalizedFilePath.StartsWith(normalizedDirectory, StringComparison.OrdinalIgnoreCase);
        }

        private static FileEncodingAnalysis AnalyzeFile(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);
            if (bytes.Length == 0)
            {
                return FileEncodingAnalysis.Skip("empty", "The file is empty.");
            }

            if (LooksBinary(filePath, bytes))
            {
                return FileEncodingAnalysis.Skip("binary", "The file is not text-based.");
            }

            if (TryGetEncodingFromBom(bytes, out var bomEncoding, out var bomLabel))
            {
                return EvaluateText(bytes, bomEncoding, bomLabel);
            }

            if (TryGetXmlDeclaredEncoding(filePath, bytes, out var declaredEncoding, out var declaredLabel))
            {
                return EvaluateText(bytes, declaredEncoding, declaredLabel);
            }

            if (IsAsciiOnly(bytes))
            {
                return FileEncodingAnalysis.Safe("ASCII / unspecified", "ASCII-only content does not provide enough evidence for a code-page regression.");
            }

            if (TryDecodeUtf8(bytes, out var utf8Text))
            {
                return EvaluateDecodedText(utf8Text, Encoding.UTF8, "UTF-8 (no BOM)");
            }

            return EvaluateDecodedText(Encoding.GetEncoding(1252).GetString(bytes), Encoding.GetEncoding(1252), "Windows-1252 heuristic");
        }

        private static FileEncodingAnalysis EvaluateText(byte[] bytes, Encoding encoding, string encodingLabel)
        {
            try
            {
                var strictEncoding = CloneEncoding(encoding);
                return EvaluateDecodedText(strictEncoding.GetString(bytes), strictEncoding, encodingLabel);
            }
            catch (DecoderFallbackException ex)
            {
                return FileEncodingAnalysis.Fail(encodingLabel, $"The file could not be decoded cleanly: {ex.Message}");
            }
        }

        private static FileEncodingAnalysis EvaluateDecodedText(string text, Encoding encoding, string encodingLabel)
        {
            if (!SupportsGermanUmlauts(encoding))
            {
                return FileEncodingAnalysis.Fail(
                    encodingLabel,
                    $"{encoding.WebName} cannot round-trip '{GermanUmlautSample}' without loss.");
            }

            if (text.IndexOf('\uFFFD') >= 0)
            {
                return FileEncodingAnalysis.Fail(
                    encodingLabel,
                    "Contains the Unicode replacement character U+FFFD ('�'), which indicates a broken or mismatched encoding/code page.");
            }

            return FileEncodingAnalysis.Safe(encodingLabel, $"{encoding.WebName} is safe for German umlauts.");
        }

        private static bool SupportsGermanUmlauts(Encoding encoding)
        {
            try
            {
                var strictEncoding = CloneEncoding(encoding);
                var encodedBytes = strictEncoding.GetBytes(GermanUmlautSample);
                return string.Equals(strictEncoding.GetString(encodedBytes), GermanUmlautSample, StringComparison.Ordinal);
            }
            catch (EncoderFallbackException)
            {
                return false;
            }
            catch (DecoderFallbackException)
            {
                return false;
            }
        }

        private static Encoding CloneEncoding(Encoding encoding)
        {
            var strictEncoding = (Encoding)encoding.Clone();
            strictEncoding.EncoderFallback = EncoderFallback.ExceptionFallback;
            strictEncoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            return strictEncoding;
        }

        private static bool TryGetEncodingFromBom(byte[] bytes, out Encoding encoding, out string encodingLabel)
        {
            if (bytes.Length >= 4)
            {
                if (bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0x00 && bytes[3] == 0x00)
                {
                    encoding = new UTF32Encoding(bigEndian: false, byteOrderMark: true, throwOnInvalidCharacters: true);
                    encodingLabel = "UTF-32 LE BOM";
                    return true;
                }

                if (bytes[0] == 0x00 && bytes[1] == 0x00 && bytes[2] == 0xFE && bytes[3] == 0xFF)
                {
                    encoding = new UTF32Encoding(bigEndian: true, byteOrderMark: true, throwOnInvalidCharacters: true);
                    encodingLabel = "UTF-32 BE BOM";
                    return true;
                }
            }

            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true, throwOnInvalidBytes: true);
                encodingLabel = "UTF-8 BOM";
                return true;
            }

            if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
            {
                encoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true);
                encodingLabel = "UTF-16 LE BOM";
                return true;
            }

            if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
            {
                encoding = new UnicodeEncoding(bigEndian: true, byteOrderMark: true, throwOnInvalidBytes: true);
                encodingLabel = "UTF-16 BE BOM";
                return true;
            }

            encoding = Encoding.UTF8;
            encodingLabel = string.Empty;
            return false;
        }

        private static bool TryGetXmlDeclaredEncoding(string filePath, byte[] bytes, out Encoding encoding, out string encodingLabel)
        {
            var extension = Path.GetExtension(filePath);
            var looksXmlLike = extension.Equals(".config", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".csproj", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".myapp", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".resx", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".settings", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".vbproj", StringComparison.OrdinalIgnoreCase)
                               || extension.Equals(".xml", StringComparison.OrdinalIgnoreCase);

            if (!looksXmlLike)
            {
                encoding = Encoding.UTF8;
                encodingLabel = string.Empty;
                return false;
            }

            var head = Encoding.ASCII.GetString(bytes, 0, Math.Min(bytes.Length, 256));
            var match = XmlEncodingRegex.Match(head);
            if (!match.Success)
            {
                encoding = Encoding.UTF8;
                encodingLabel = string.Empty;
                return false;
            }

            try
            {
                var declaredEncoding = match.Groups["encoding"].Value;
                encoding = Encoding.GetEncoding(declaredEncoding);
                encodingLabel = $"XML declaration ({declaredEncoding})";
                return true;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException($"The file '{filePath}' declares an unknown encoding.", ex);
            }
        }

        private static bool TryDecodeUtf8(byte[] bytes, out string text)
        {
            try
            {
                text = StrictUtf8.GetString(bytes);
                return true;
            }
            catch (DecoderFallbackException)
            {
                text = string.Empty;
                return false;
            }
        }

        private static bool IsAsciiOnly(byte[] bytes)
        {
            return bytes.All(b => b <= 0x7F);
        }

        private static bool LooksBinary(string filePath, byte[] bytes)
        {
            if (BinaryExtensions.Contains(Path.GetExtension(filePath)))
            {
                return true;
            }

            var lengthToInspect = Math.Min(bytes.Length, 4096);
            var suspiciousControlCount = 0;

            for (var index = 0; index < lengthToInspect; index++)
            {
                var value = bytes[index];
                if (value == 0)
                {
                    return true;
                }

                if (value < 0x20 && value != '\r' && value != '\n' && value != '\t' && value != '\f')
                {
                    suspiciousControlCount++;
                }
            }

            return suspiciousControlCount > Math.Max(4, lengthToInspect / 20);
        }

        private static string MakeRelativeToSolution(string solutionPath, string filePath)
        {
            var solutionDirectory = Path.GetDirectoryName(solutionPath) ?? throw new InvalidOperationException("The solution directory could not be determined.");
            var baseUri = new Uri(AppendDirectorySeparator(solutionDirectory));
            var fileUri = new Uri(filePath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fileUri).ToString()).Replace('/', '\\');
        }

        private static string WriteMarkdownReport(string solutionPath, int scannedFileCount, IReadOnlyCollection<ProblematicFileReportItem> violations)
        {
            var outputRoot = TestSettings.EnsureOutputRoot();
            var reportPath = Path.Combine(outputRoot, $"codepage{DateTime.Now.ToString(ReportTimestampFormat)}.md");

            var markdown = new StringBuilder();
            markdown.AppendLine("# Code page scan report");
            markdown.AppendLine();
            markdown.AppendLine($"- Generated: `{DateTime.Now:yyyy-MM-dd HH:mm:ss}`");
            markdown.AppendLine($"- Solution: `{solutionPath}`");
            markdown.AppendLine($"- Scanned files: `{scannedFileCount}`");
            markdown.AppendLine($"- Problematic files: `{violations.Count}`");
            markdown.AppendLine();

            if (violations.Count == 0)
            {
                markdown.AppendLine("No problematic file encodings or character sets were detected.");
            }
            else
            {
                markdown.AppendLine("| File | Encoding | Reason |");
                markdown.AppendLine("| --- | --- | --- |");

                foreach (var violation in violations.OrderBy(v => v.RelativePath, StringComparer.OrdinalIgnoreCase))
                {
                    markdown.AppendLine(
                        $"| `{EscapeMarkdownInlineCode(violation.RelativePath)}` | `{EscapeMarkdownInlineCode(violation.EncodingLabel)}` | {EscapeMarkdownTableText(violation.Reason)} |");
                }
            }

            File.WriteAllText(reportPath, markdown.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
            return reportPath;
        }

        private static string FormatViolation(ProblematicFileReportItem violation)
        {
            return $"{violation.RelativePath} [{violation.EncodingLabel}] {violation.Reason}";
        }

        private static string EscapeMarkdownInlineCode(string value)
        {
            return value.Replace("`", "\\`");
        }

        private static string EscapeMarkdownTableText(string value)
        {
            return value.Replace("\r", string.Empty)
                .Replace("\n", "<br/>")
                .Replace("|", "\\|");
        }

        private static string AppendDirectorySeparator(string path)
        {
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                return path;
            }

            return path + Path.DirectorySeparatorChar;
        }

        private sealed class FileEncodingAnalysis
        {
            private FileEncodingAnalysis(bool shouldInspect, bool isSafe, string encodingLabel, string reason)
            {
                ShouldInspect = shouldInspect;
                IsSafe = isSafe;
                EncodingLabel = encodingLabel;
                Reason = reason;
            }

            public string EncodingLabel { get; }

            public bool IsSafe { get; }

            public string Reason { get; }

            public bool ShouldInspect { get; }

            public static FileEncodingAnalysis Fail(string encodingLabel, string reason)
            {
                return new FileEncodingAnalysis(shouldInspect: true, isSafe: false, encodingLabel: encodingLabel, reason: reason);
            }

            public static FileEncodingAnalysis Safe(string encodingLabel, string reason)
            {
                return new FileEncodingAnalysis(shouldInspect: true, isSafe: true, encodingLabel: encodingLabel, reason: reason);
            }

            public static FileEncodingAnalysis Skip(string encodingLabel, string reason)
            {
                return new FileEncodingAnalysis(shouldInspect: false, isSafe: true, encodingLabel: encodingLabel, reason: reason);
            }
        }

        private sealed class ProblematicFileReportItem
        {
            public ProblematicFileReportItem(string relativePath, string encodingLabel, string reason)
            {
                RelativePath = relativePath;
                EncodingLabel = encodingLabel;
                Reason = reason;
            }

            public string EncodingLabel { get; }

            public string Reason { get; }

            public string RelativePath { get; }
        }
    }
}
