using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Xunit;

namespace Facesso.Tests.Visual
{
    /// <summary>
    /// Captures a screenshot of the Facesso main window (frmFacessoShell),
    /// performs OCR on each UI region using Tesseract with eng+deu traineddata,
    /// and writes a Markdown report to c:\out\FacessoOcrReport.md.
    /// </summary>
    public class OcrScreenshotTests : IDisposable
    {
        private Process _facessoProcess;

        private const string OutputFolder = @"c:\out";
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
        public void Facesso_OcrScreenshot()
        {
            var exePath = FindFacessoExe();
            Assert.True(File.Exists(exePath), $"Facesso.exe not found at: {exePath}");

            _facessoProcess = Process.Start(new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = "/silentAdminLogon",
                UseShellExecute = false
            });
            Assert.NotNull(_facessoProcess);

            var mainWindow = WaitForMainWindow(_facessoProcess, StartupTimeoutMs);
            Assert.True(mainWindow != IntPtr.Zero,
                "Facesso main window did not appear within the timeout period.");

            SetForegroundWindow(mainWindow);
            ShowWindow(mainWindow, SW_SHOWMAXIMIZED);
            Thread.Sleep(RenderDelayMs);

            // Determine window geometry and client area offset
            GetWindowRect(mainWindow, out var windowRect);
            GetClientRect(mainWindow, out var clientRect);
            var clientOrigin = new POINT { X = 0, Y = 0 };
            ClientToScreen(mainWindow, ref clientOrigin);

            int ncLeft = clientOrigin.X - windowRect.Left;
            int ncTop = clientOrigin.Y - windowRect.Top;
            int clientWidth = clientRect.Right;
            int clientHeight = clientRect.Bottom;

            Assert.True(windowRect.Width > 0 && windowRect.Height > 0,
                $"Window has invalid dimensions: {windowRect.Width}x{windowRect.Height}");

            // Capture the window via PrintWindow
            Directory.CreateDirectory(OutputFolder);
            var screenshotPath = Path.Combine(OutputFolder, "FacessoScreenshot.png");

            using (var bitmap = new Bitmap(windowRect.Width, windowRect.Height, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    var hdc = g.GetHdc();
                    try
                    {
                        bool captured = PrintWindow(mainWindow, hdc, PW_RENDERFULLCONTENT);
                        Assert.True(captured, "PrintWindow failed to capture the window content.");
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }

                bitmap.Save(screenshotPath, ImageFormat.Png);
            }

            // Compute OCR regions based on the frmFacessoShell layout
            var regions = ComputeRegions(ncLeft, ncTop, clientWidth, clientHeight);

            // Locate tessdata (copied to output by MSBuild)
            var tessdataDir = Path.Combine(
                Path.GetDirectoryName(typeof(OcrScreenshotTests).Assembly.Location),
                "Visual", "tessdata");
            Assert.True(Directory.Exists(tessdataDir),
                $"tessdata directory not found at: {tessdataDir}");

            // Perform OCR on each region and build the Markdown report
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

            // Use standard tessdata with Default engine mode (LSTM + legacy fallback).
            // Language "eng+deu" handles both English and German UI text.
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
        }

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
            // Fixed layout sizes from frmFacessoShell.Designer.vb
            const int menuHeight = 24;       // MenuStripMain.Size.Height
            const int toolbarHeight = 25;    // ToolStripMain.Size.Height
            const int statusBarHeight = 30;  // StatusStrip.Size.Height
            const int tabHeaderHeight = 25;  // TabControl header row
            const int topInfoHeight = 64;    // TopLineLayoutPanel.Size.Height
            const int tabPad = 3;            // TabPage1.Padding
            const int splitterThick = 4;     // SplitContainer splitter bar

            // ToolStripDateShiftSelector is populated at runtime with shift buttons
            // (Width=200) and a month calendar, so the LeftToolStripPanel auto-sizes
            // to approximately 210px.
            const int dateShiftWidth = 210;

            // Client-area origin in bitmap coordinates
            int cx = ncLeft;
            int cy = ncTop;

            var regions = new List<OcrRegion>();

            // ── 1. Menu Bar ──
            regions.Add(new OcrRegion(
                "Menu Bar",
                "MenuStripMain — Datei | Bearbeiten | Ansicht | Analysen | " +
                "Kosten/Abrechnungen | Basisdaten | Extras | Hilfe",
                new Rectangle(cx, cy, clientWidth, menuHeight),
                PageSegMode.SingleLine));

            // ── 2. Toolbar ──
            regions.Add(new OcrRegion(
                "Toolbar",
                "ToolStripMain — Datenmanager, Produktiv-Site-Analysen, " +
                "Prämienlohn, Prev/Next Site, Prev/Next Arbeitstag, " +
                "To-do, Stammdaten, Benutzerverwaltung, Optionen",
                new Rectangle(cx, cy + menuHeight, clientWidth, toolbarHeight),
                PageSegMode.SingleLine));

            // ── Content area ──
            int contentX = cx + dateShiftWidth;
            int contentY = cy + menuHeight + toolbarHeight;
            int contentW = clientWidth - dateShiftWidth;
            int contentH = clientHeight - menuHeight - toolbarHeight - statusBarHeight;

            // ── 3. Date/Shift Selector (left panel) ──
            regions.Add(new OcrRegion(
                "Date / Shift Selector",
                "ToolStripDateShiftSelector (LeftToolStripPanel) — " +
                "'Arbeitstagdatum' label, MonthCalendar, " +
                "'Nächster/Vorheriger Arbeitstag', 'Meine To-do-Liste', " +
                "'Schicht' label, Shift buttons 1 / 2 / 3 / S",
                new Rectangle(cx, contentY, dateShiftWidth, contentH),
                PageSegMode.SingleBlock));

            // ── Tab page content (TabPage1 = "Bearbeitung") ──
            int tpX = contentX + tabPad;
            int tpY = contentY + tabHeaderHeight + tabPad;
            int tpW = contentW - 2 * tabPad;
            int tpH = contentH - tabHeaderHeight - 2 * tabPad;

            // TopLineLayoutPanel: 3 columns (25%, 25%, 50%)
            int col1W = tpW / 4;
            int col2W = tpW / 4;
            int col3W = tpW - col1W - col2W;

            // ── 4. Info Bar — Current Date ──
            regions.Add(new OcrRegion(
                "Info Bar — Current Date",
                "lblCurrentDate — selected production date (e.g. 'Montag, 23.2.2005')",
                new Rectangle(tpX, tpY, col1W, topInfoHeight),
                PageSegMode.SingleBlock));

            // ── 5. Info Bar — Current Work Group ──
            regions.Add(new OcrRegion(
                "Info Bar — Current Work Group",
                "lblCurrentWorkgroup — selected Produktiv-Site name",
                new Rectangle(tpX + col1W, tpY, col2W, topInfoHeight),
                PageSegMode.SingleBlock));

            // ── 6. Info Bar — Current Shift ──
            regions.Add(new OcrRegion(
                "Info Bar — Current Shift",
                "lblCurrentShift — selected shift and time range " +
                "(e.g. 'Schicht 1 (06:15 - 12:15)')",
                new Rectangle(tpX + col1W + col2W, tpY, col3W, topInfoHeight),
                PageSegMode.SingleBlock));

            // ── Split areas below the info bar ──
            int splitY = tpY + topInfoHeight;
            int splitH = tpH - topInfoHeight;

            // SplitEmployeesWorkGroups: Horizontal, SplitterDistance=262 (designer default).
            // The absolute pixel value is preserved when the window is maximized.
            int wgPanelH = Math.Min(262, splitH / 2);
            int empPanelH = splitH - wgPanelH - splitterThick;

            // splitWorkGroups: Vertical, SplitterDistance=688 (designer default).
            int wgListW = Math.Min(688, (int)(tpW * 0.62));
            int wgDetailW = tpW - wgListW - splitterThick;

            // ── 7. Work Groups ListView ──
            regions.Add(new OcrRegion(
                "Work Groups (Produktiv-Sites)",
                "gbWorkGroups → wglWorkGroups (ucWorkGroupListView) — " +
                "grouped Details view listing production sites",
                new Rectangle(tpX, splitY, wgListW, wgPanelH),
                PageSegMode.SingleBlock));

            // ── 8. Work Group Details ──
            regions.Add(new OcrRegion(
                "Work Group Details (Produktiv-Site-Info)",
                "GroupBox1 → dgvWorkGroupResults (ucWorkGroupItemDetailsView) — " +
                "DataGridView showing selected site KPIs",
                new Rectangle(tpX + wgListW + splitterThick, splitY,
                              wgDetailW, wgPanelH),
                PageSegMode.SingleBlock));

            // ── 9. Employees ListView ──
            regions.Add(new OcrRegion(
                "Employees (Mitarbeiter)",
                "gbEmployees → elvEmployees (ucEmployeeListView) — " +
                "grouped Details view of employee personnel data",
                new Rectangle(tpX, splitY + wgPanelH + splitterThick,
                              tpW, empPanelH),
                PageSegMode.SingleBlock));

            // ── 10. Status Bar ──
            regions.Add(new OcrRegion(
                "Status Bar",
                "StatusStrip — tslAdminInfo (login user + subsidiary), " +
                "tslActiveEmployees, tslActiveWorkgroups, tslCurrentDateAndTime",
                new Rectangle(cx, cy + clientHeight - statusBarHeight,
                              clientWidth, statusBarHeight),
                PageSegMode.SingleLine));

            return regions;
        }

        private static Rectangle ClampRect(Rectangle rect, int imgWidth, int imgHeight)
        {
            int x = Math.Max(0, rect.X);
            int y = Math.Max(0, rect.Y);
            int right = Math.Min(imgWidth, rect.Right);
            int bottom = Math.Min(imgHeight, rect.Bottom);
            return new Rectangle(x, y, Math.Max(0, right - x), Math.Max(0, bottom - y));
        }

        private static IntPtr WaitForMainWindow(Process process, int timeoutMs)
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                process.Refresh();
                if (process.MainWindowHandle != IntPtr.Zero
                    && IsWindow(process.MainWindowHandle))
                    return process.MainWindowHandle;

                if (process.HasExited)
                    break;

                Thread.Sleep(250);
            }
            return IntPtr.Zero;
        }

        private static string FindFacessoExe()
        {
            var testDir = Path.GetDirectoryName(
                typeof(OcrScreenshotTests).Assembly.Location);

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

        public void Dispose()
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
                    // Best-effort cleanup
                }
                finally
                {
                    _facessoProcess.Dispose();
                }
            }
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
    }
}
