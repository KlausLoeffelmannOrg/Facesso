using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Facesso.Tests.Infrastructure;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Xunit;

namespace Facesso.Tests.Visual
{
    /// <summary>
    /// Starts the Facesso application with /silentAdminLogon, captures a
    /// fullscreen screenshot via PrintWindow, performs OCR on each UI region
    /// using Tesseract (eng+deu), and writes both the PNG and a Markdown
    /// report to c:\output.
    /// If the main window does not appear in time, the test captures any
    /// modal dialogs, OCR's them, and fails with diagnostic output.
    /// </summary>
    public class FacessoScreenshotTests : IDisposable
    {
        private Process _facessoProcess;

        private const string OutputFolder = @"c:\output";
        private const string ScreenshotFileName = "FacessoScreenshot.png";
        private const string DialogScreenshotFileName = "FacessoDialog.png";
        private const string MarkdownFileName = "FacessoOcrReport.md";
        private const int StartupTimeoutMs = 30_000;
        private const int RenderDelayMs = 5_000;

        #region Win32 Interop

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(
            int dwThreadId, EnumThreadWndProc lpfn, IntPtr lParam);

        private const int SW_SHOWMAXIMIZED = 3;
        private const uint PW_RENDERFULLCONTENT = 0x00000002;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
            public int Width => Right - Left;
            public int Height => Bottom - Top;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X, Y;
        }

        #endregion

        [Fact]
        public void Facesso_CaptureScreenshotAndOcrReport()
        {
            var exePath = FindFacessoExe();
            Assert.True(File.Exists(exePath), $"Facesso.exe not found at: {exePath}");

            TestRunLogger.Trace($"Starting Facesso.exe from: {exePath}");

            var diagLogPath = Path.Combine(OutputFolder, "FacessoDiag.log");
            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = "/silentAdminLogon",
                UseShellExecute = false,
                RedirectStandardError = true
            };
            startInfo.EnvironmentVariables["FACESSO_DIAG_LOG"] = diagLogPath;

            _facessoProcess = Process.Start(startInfo);
            Assert.NotNull(_facessoProcess);

            TestRunLogger.Trace($"{_facessoProcess.ProcessName} is now running.");

            var mainWindowHandle = WaitForMainWindow(_facessoProcess, StartupTimeoutMs);
            TestRunLogger.Trace($"Got mainWindowHandle {mainWindowHandle}.");

            if (mainWindowHandle == IntPtr.Zero)
            {
                if (_facessoProcess.HasExited)
                {
                    string stderr = "";
                    try { stderr = _facessoProcess.StandardError.ReadToEnd(); }
                    catch { }

                    string diagLog = "";
                    try
                    {
                        if (File.Exists(diagLogPath))
                            diagLog = File.ReadAllText(diagLogPath);
                    }
                    catch { }

                    TestRunLogger.Info($"Facesso.exe exited with code {_facessoProcess.ExitCode}.");
                    if (!string.IsNullOrEmpty(stderr))
                        TestRunLogger.Info($"stderr: {stderr}");
                    if (!string.IsNullOrEmpty(diagLog))
                        TestRunLogger.Info($"Diagnostic log:\n{diagLog}");

                    var msg = $"Facesso.exe crashed on startup (exit code {_facessoProcess.ExitCode}).";
                    if (!string.IsNullOrEmpty(stderr))
                        msg += $"\n\nStandard Error:\n{stderr}";
                    if (!string.IsNullOrEmpty(diagLog))
                        msg += $"\n\nDiagnostic Log ({diagLogPath}):\n{diagLog}";
                    if (string.IsNullOrEmpty(stderr) && string.IsNullOrEmpty(diagLog))
                        msg += " No diagnostic output captured.";

                    Assert.Fail(msg);
                }

                TestRunLogger.Trace("mainWindowHandle was invalid — looking for dialogs.");
                HandleMissingMainWindow();
                return;
            }

            // Maximize and give the application time to render
            TestRunLogger.Trace("Setting application window as foreground window.");
            SetForegroundWindow(mainWindowHandle);
            ShowWindow(mainWindowHandle, SW_SHOWMAXIMIZED);

            TestRunLogger.Trace("Waiting for rendering to settle.");
            Thread.Sleep(RenderDelayMs);

            // Determine window geometry and client area offset
            GetWindowRect(mainWindowHandle, out var windowRect);
            GetClientRect(mainWindowHandle, out var clientRect);
            var clientOrigin = new POINT { X = 0, Y = 0 };
            ClientToScreen(mainWindowHandle, ref clientOrigin);

            int ncLeft = clientOrigin.X - windowRect.Left;
            int ncTop = clientOrigin.Y - windowRect.Top;
            int clientWidth = clientRect.Right;
            int clientHeight = clientRect.Bottom;

            Assert.True(windowRect.Width > 0 && windowRect.Height > 0,
                $"Window has invalid dimensions: {windowRect.Width}x{windowRect.Height}");

            // ── Capture the screenshot ──
            Directory.CreateDirectory(OutputFolder);
            var screenshotPath = Path.Combine(OutputFolder, ScreenshotFileName);

            TestRunLogger.Trace("Capturing window via PrintWindow.");
            using (var bitmap = new Bitmap(windowRect.Width, windowRect.Height, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    var hdc = g.GetHdc();
                    try
                    {
                        bool captured = PrintWindow(mainWindowHandle, hdc, PW_RENDERFULLCONTENT);
                        Assert.True(captured, "PrintWindow failed to capture the window content.");
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }

                bitmap.Save(screenshotPath, ImageFormat.Png);
            }

            Assert.True(File.Exists(screenshotPath), $"Screenshot was not saved to: {screenshotPath}");
            Assert.True(new FileInfo(screenshotPath).Length > 0, "Screenshot file is empty.");
            TestRunLogger.Info($"Screenshot saved: {screenshotPath}");

            // ── OCR each UI region and build the Markdown report ──
            var regions = ComputeRegions(ncLeft, ncTop, clientWidth, clientHeight);

            var tessdataDir = Path.Combine(
                Path.GetDirectoryName(typeof(FacessoScreenshotTests).Assembly.Location),
                "Visual", "tessdata");
            Assert.True(Directory.Exists(tessdataDir),
                $"tessdata directory not found at: {tessdataDir}");

            var md = new StringBuilder();
            md.AppendLine("# Facesso Shell — OCR Report");
            md.AppendLine();
            md.AppendLine($"*Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}*  ");
            md.AppendLine($"*Screenshot: {screenshotPath}*  ");
            md.AppendLine($"*Window: {windowRect.Width} × {windowRect.Height} px | " +
                          $"Client area: {clientWidth} × {clientHeight} px*");
            md.AppendLine();
            md.AppendLine("---");
            md.AppendLine();

            TestRunLogger.Trace("Starting OCR on UI regions.");

            using (var engine = new TesseractEngine(tessdataDir, "eng+deu", EngineMode.Default))
            using (var pix = Pix.LoadFromFile(screenshotPath))
            {
                foreach (var region in regions)
                {
                    var r = ClampRect(region.Rect, pix.Width, pix.Height);

                    md.AppendLine($"## {region.Name}");
                    md.AppendLine();
                    md.AppendLine($"> {region.Description}");
                    md.AppendLine();
                    md.AppendLine($"**Region:** `({r.X}, {r.Y})` — `{r.Width} × {r.Height}` px  ");

                    if (r.Width <= 10 || r.Height <= 10)
                    {
                        md.AppendLine();
                        md.AppendLine("*(Region too small or outside captured area)*");
                        md.AppendLine();
                        md.AppendLine("---");
                        md.AppendLine();
                        continue;
                    }

                    var tessRect = new Rect(r.X, r.Y, r.Width, r.Height);

                    using (var page = engine.Process(pix, tessRect, region.SegMode))
                    {
                        string text = page.GetText()?.Trim() ?? "";
                        float confidence = page.GetMeanConfidence();

                        md.AppendLine($"**Confidence:** {confidence:P1}");
                        md.AppendLine();

                        if (string.IsNullOrWhiteSpace(text))
                        {
                            md.AppendLine("*(no text detected)*");
                        }
                        else
                        {
                            md.AppendLine("```");
                            md.AppendLine(text);
                            md.AppendLine("```");
                        }

                        md.AppendLine();
                        md.AppendLine("---");
                        md.AppendLine();
                    }
                }
            }

            var mdPath = Path.Combine(OutputFolder, MarkdownFileName);
            File.WriteAllText(mdPath, md.ToString(), Encoding.UTF8);

            Assert.True(File.Exists(mdPath), $"Markdown report was not saved to: {mdPath}");
            Assert.True(new FileInfo(mdPath).Length > 0, "Markdown report is empty.");
            TestRunLogger.Info($"OCR report saved: {mdPath}");
        }

        #region Error Handling — Missing Main Window

        /// <summary>
        /// Called when the main shell window did not appear in time.
        /// Enumerates all visible windows belonging to the Facesso process,
        /// captures and OCR's each one, then kills the process and fails
        /// the test with the dialog text as diagnostic output.
        /// </summary>
        private void HandleMissingMainWindow()
        {
            Directory.CreateDirectory(OutputFolder);

            var dialogWindows = FindProcessWindows(_facessoProcess);

            if (dialogWindows.Count == 0)
            {
                string stderr = "";
                try
                {
                    if (_facessoProcess.HasExited)
                        stderr = _facessoProcess.StandardError.ReadToEnd();
                }
                catch { }

                KillProcess();
                Assert.Fail(
                    "Facesso main window did not appear within the timeout period " +
                    "and no modal dialog was found on screen." +
                    (string.IsNullOrEmpty(stderr) ? "" : "\n\nStandard Error:\n" + stderr));
            }

            var report = new StringBuilder();
            report.AppendLine("Facesso main window did not appear. " +
                              "The following dialog(s) were found:");
            report.AppendLine();

            for (int i = 0; i < dialogWindows.Count; i++)
            {
                var info = dialogWindows[i];
                report.AppendLine($"── Dialog {i + 1}: \"{info.Title}\" " +
                                  $"(class: {info.ClassName}) ──");

                string pngPath = null;
                GetWindowRect(info.Handle, out var dlgRect);

                if (dlgRect.Width > 0 && dlgRect.Height > 0)
                {
                    pngPath = Path.Combine(OutputFolder,
                        dialogWindows.Count == 1
                            ? DialogScreenshotFileName
                            : $"FacessoDialog_{i + 1}.png");

                    try
                    {
                        using (var bmp = new Bitmap(dlgRect.Width, dlgRect.Height,
                                   PixelFormat.Format32bppArgb))
                        using (var g = Graphics.FromImage(bmp))
                        {
                            var hdc = g.GetHdc();
                            try
                            {
                                PrintWindow(info.Handle, hdc, PW_RENDERFULLCONTENT);
                            }
                            finally
                            {
                                g.ReleaseHdc(hdc);
                            }

                            bmp.Save(pngPath, ImageFormat.Png);
                        }

                        report.AppendLine($"  Screenshot saved to: {pngPath}");
                    }
                    catch (Exception ex)
                    {
                        report.AppendLine($"  Screenshot capture failed: {ex.Message}");
                        pngPath = null;
                    }
                }

                if (pngPath != null && File.Exists(pngPath))
                {
                    string ocrText = OcrImage(pngPath);
                    report.AppendLine($"  OCR text:");
                    report.AppendLine();

                    foreach (var line in ocrText.Split('\n'))
                    {
                        report.AppendLine($"    {line.TrimEnd()}");
                    }

                    report.AppendLine();
                }
                else
                {
                    report.AppendLine("  (no image available for OCR)");
                    report.AppendLine();
                }
            }

            KillProcess();
            Assert.Fail(report.ToString());
        }

        #endregion

        #region OCR Regions

        /// <summary>
        /// Computes OCR regions from the frmFacessoShell layout as defined in
        /// frmFacessoShell.Designer.vb. All coordinates are relative to the
        /// captured bitmap (0,0 = window top-left including non-client area).
        ///
        /// Layout (from Designer):
        ///   ToolStripContainer1 (Dock=Fill)
        ///     TopToolStripPanel:  MenuStripMain (h≈24) + ToolStripMain (h≈25)
        ///     LeftToolStripPanel: ToolStripDateShiftSelector (w≈210 at runtime)
        ///     ContentPanel:       TabControl1 (Dock=Fill)
        ///       TabPage1 "Bearbeitung":
        ///         TopLineLayoutPanel (Dock=Top, h=64): lblCurrentDate, lblCurrentWorkgroup, lblCurrentShift
        ///         SplitEmployeesWorkGroups (Dock=Fill, Horizontal, SplitterDistance≈262):
        ///           Panel1 → splitWorkGroups (Vertical, SplitterDistance≈688):
        ///             Panel1 → gbWorkGroups "Produktiv-Sites" → wglWorkGroups (ucWorkGroupListView)
        ///             Panel2 → GroupBox1 "Produktiv-Site-Info:" → dgvWorkGroupResults (ucWorkGroupItemDetailsView)
        ///           Panel2 → gbEmployees "Mitarbeiter" → elvEmployees (ucEmployeeListView)
        ///     BottomToolStripPanel: StatusStrip (h≈30)
        /// </summary>
        private static List<OcrRegion> ComputeRegions(
            int ncLeft, int ncTop, int clientWidth, int clientHeight)
        {
            const int menuHeight = 24;
            const int toolbarHeight = 25;
            const int statusBarHeight = 30;
            const int tabHeaderHeight = 25;
            const int topInfoHeight = 64;
            const int tabPad = 3;
            const int splitterThick = 4;
            const int dateShiftWidth = 210;

            int cx = ncLeft;
            int cy = ncTop;

            var regions = new List<OcrRegion>();

            regions.Add(new OcrRegion(
                "Menu Bar",
                "MenuStripMain — Datei | Bearbeiten | Ansicht | Analysen | " +
                "Kosten/Abrechnungen | Basisdaten | Extras | Hilfe",
                new Rectangle(cx, cy, clientWidth, menuHeight),
                PageSegMode.SingleLine));

            regions.Add(new OcrRegion(
                "Toolbar",
                "ToolStripMain — Datenmanager, Produktiv-Site-Analysen, " +
                "Prämienlohn, Prev/Next Site, Prev/Next Arbeitstag, " +
                "To-do, Stammdaten, Benutzerverwaltung, Optionen",
                new Rectangle(cx, cy + menuHeight, clientWidth, toolbarHeight),
                PageSegMode.SingleLine));

            int contentX = cx + dateShiftWidth;
            int contentY = cy + menuHeight + toolbarHeight;
            int contentW = clientWidth - dateShiftWidth;
            int contentH = clientHeight - menuHeight - toolbarHeight - statusBarHeight;

            regions.Add(new OcrRegion(
                "Date / Shift Selector",
                "ToolStripDateShiftSelector (LeftToolStripPanel) — " +
                "'Arbeitstagdatum' label, MonthCalendar, " +
                "'Nächster/Vorheriger Arbeitstag', 'Meine To-do-Liste', " +
                "'Schicht' label, Shift buttons 1 / 2 / 3 / S",
                new Rectangle(cx, contentY, dateShiftWidth, contentH),
                PageSegMode.SingleBlock));

            int tpX = contentX + tabPad;
            int tpY = contentY + tabHeaderHeight + tabPad;
            int tpW = contentW - 2 * tabPad;
            int tpH = contentH - tabHeaderHeight - 2 * tabPad;

            int col1W = tpW / 4;
            int col2W = tpW / 4;
            int col3W = tpW - col1W - col2W;

            regions.Add(new OcrRegion(
                "Info Bar — Current Date",
                "lblCurrentDate — selected production date (e.g. 'Montag, 23.2.2005')",
                new Rectangle(tpX, tpY, col1W, topInfoHeight),
                PageSegMode.SingleBlock));

            regions.Add(new OcrRegion(
                "Info Bar — Current Work Group",
                "lblCurrentWorkgroup — selected Produktiv-Site name",
                new Rectangle(tpX + col1W, tpY, col2W, topInfoHeight),
                PageSegMode.SingleBlock));

            regions.Add(new OcrRegion(
                "Info Bar — Current Shift",
                "lblCurrentShift — selected shift and time range " +
                "(e.g. 'Schicht 1 (06:15 - 12:15)')",
                new Rectangle(tpX + col1W + col2W, tpY, col3W, topInfoHeight),
                PageSegMode.SingleBlock));

            int splitY = tpY + topInfoHeight;
            int splitH = tpH - topInfoHeight;

            int wgPanelH = Math.Min(262, splitH / 2);
            int empPanelH = splitH - wgPanelH - splitterThick;

            int wgListW = Math.Min(688, (int)(tpW * 0.62));
            int wgDetailW = tpW - wgListW - splitterThick;

            regions.Add(new OcrRegion(
                "Work Groups (Produktiv-Sites)",
                "gbWorkGroups → wglWorkGroups (ucWorkGroupListView) — " +
                "grouped Details view listing production sites",
                new Rectangle(tpX, splitY, wgListW, wgPanelH),
                PageSegMode.SingleBlock));

            regions.Add(new OcrRegion(
                "Work Group Details (Produktiv-Site-Info)",
                "GroupBox1 → dgvWorkGroupResults (ucWorkGroupItemDetailsView) — " +
                "DataGridView showing selected site KPIs",
                new Rectangle(tpX + wgListW + splitterThick, splitY,
                              wgDetailW, wgPanelH),
                PageSegMode.SingleBlock));

            regions.Add(new OcrRegion(
                "Employees (Mitarbeiter)",
                "gbEmployees → elvEmployees (ucEmployeeListView) — " +
                "grouped Details view of employee personnel data",
                new Rectangle(tpX, splitY + wgPanelH + splitterThick,
                              tpW, empPanelH),
                PageSegMode.SingleBlock));

            regions.Add(new OcrRegion(
                "Status Bar",
                "StatusStrip — tslAdminInfo (login user + subsidiary), " +
                "tslActiveEmployees, tslActiveWorkgroups, tslCurrentDateAndTime",
                new Rectangle(cx, cy + clientHeight - statusBarHeight,
                              clientWidth, statusBarHeight),
                PageSegMode.SingleLine));

            return regions;
        }

        #endregion

        #region Helpers

        private static string OcrImage(string imagePath)
        {
            try
            {
                var tessdataDir = Path.Combine(
                    Path.GetDirectoryName(typeof(FacessoScreenshotTests).Assembly.Location),
                    "Visual", "tessdata");

                if (!Directory.Exists(tessdataDir))
                    return $"(tessdata not found at {tessdataDir})";

                using (var engine = new TesseractEngine(
                           tessdataDir, "eng+deu", EngineMode.Default))
                using (var pix = Pix.LoadFromFile(imagePath))
                using (var page = engine.Process(pix, PageSegMode.Auto))
                {
                    return page.GetText()?.Trim() ?? "(empty)";
                }
            }
            catch (Exception ex)
            {
                return $"(OCR failed: {ex.Message})";
            }
        }

        private static Rectangle ClampRect(Rectangle rect, int imgWidth, int imgHeight)
        {
            int x = Math.Max(0, rect.X);
            int y = Math.Max(0, rect.Y);
            int right = Math.Min(imgWidth, rect.Right);
            int bottom = Math.Min(imgHeight, rect.Bottom);
            return new Rectangle(x, y, Math.Max(0, right - x), Math.Max(0, bottom - y));
        }

        private static List<WindowInfo> FindProcessWindows(Process process)
        {
            var windows = new List<WindowInfo>();

            try
            {
                process.Refresh();

                foreach (ProcessThread thread in process.Threads)
                {
                    EnumThreadWindows(thread.Id, (hWnd, _) =>
                    {
                        if (!IsWindowVisible(hWnd))
                            return true;

                        var titleBuf = new StringBuilder(512);
                        GetWindowText(hWnd, titleBuf, titleBuf.Capacity);

                        var classBuf = new StringBuilder(256);
                        GetClassName(hWnd, classBuf, classBuf.Capacity);

                        GetWindowRect(hWnd, out var r);
                        if (r.Width <= 0 || r.Height <= 0)
                            return true;

                        windows.Add(new WindowInfo
                        {
                            Handle = hWnd,
                            Title = titleBuf.ToString(),
                            ClassName = classBuf.ToString()
                        });

                        return true;
                    }, IntPtr.Zero);
                }
            }
            catch
            {
                // Process may have exited during enumeration
            }

            return windows;
        }

        private static IntPtr WaitForMainWindow(Process process, int timeoutMs)
        {
            var sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                process.Refresh();

                if (process.HasExited)
                    break;

                try
                {
                    if (process.MainWindowHandle != IntPtr.Zero && IsWindow(process.MainWindowHandle))
                        return process.MainWindowHandle;
                }
                catch (InvalidOperationException)
                {
                    break; // Process exited between HasExited check and MainWindowHandle access
                }

                Thread.Sleep(250);
            }

            return IntPtr.Zero;
        }

        private static string FindFacessoExe()
        {
            var testDir = Path.GetDirectoryName(
                typeof(FacessoScreenshotTests).Assembly.Location);

            foreach (var config in new[] { "Debug", "Release" })
            {
                var candidate = Path.GetFullPath(Path.Combine(
                    testDir, "..", "..", "..", "..",
                    "Facesso", "bin", config, "net472", "Facesso.exe"));

                if (File.Exists(candidate))
                    return candidate;
            }

            var sameDir = Path.Combine(testDir, "Facesso.exe");
            if (File.Exists(sameDir))
                return sameDir;

            return Path.GetFullPath(Path.Combine(
                testDir, "..", "..", "..", "..",
                "Facesso", "bin", "Debug", "net472", "Facesso.exe"));
        }

        private void KillProcess()
        {
            if (_facessoProcess != null && !_facessoProcess.HasExited)
            {
                try
                {
                    _facessoProcess.Kill();
                    _facessoProcess.WaitForExit(5000);
                }
                catch
                {
                    // Best-effort
                }
            }
        }

        #endregion

        public void Dispose()
        {
            KillProcess();
            _facessoProcess?.Dispose();
        }

        private readonly struct OcrRegion
        {
            public string Name { get; }
            public string Description { get; }
            public Rectangle Rect { get; }
            public PageSegMode SegMode { get; }

            public OcrRegion(string name, string description,
                             Rectangle rect, PageSegMode segMode)
            {
                Name = name;
                Description = description;
                Rect = rect;
                SegMode = segMode;
            }
        }

        private struct WindowInfo
        {
            public IntPtr Handle;
            public string Title;
            public string ClassName;
        }
    }
}
