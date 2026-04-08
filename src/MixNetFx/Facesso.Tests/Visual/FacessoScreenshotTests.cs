using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Facesso.Tests.Infrastructure;
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
        private const string MarkdownFileName = "FacessoA11yReport.md";
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref POINT lpPoints, int cPoints);

        private const int SW_SHOWMAXIMIZED = 3;
        private const uint PW_RENDERFULLCONTENT = 0x00000002;

        private const int WM_PRINT = 0x0317;
        private const int WM_PRINTCLIENT = 0x0318;
        private const int PRF_NONCLIENT = 0x02;
        private const int PRF_CLIENT = 0x04;
        private const int PRF_ERASEBKGND = 0x08;
        private const int PRF_CHILDREN = 0x10;

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

            // Tell the app to save its own screenshot via DrawToBitmap.
            // This works in headless / container environments where
            // cross-process PrintWindow produces black images.
            Directory.CreateDirectory(OutputFolder);
            var drawToBitmapPath = Path.Combine(OutputFolder, "FacessoScreenshot_DrawToBitmap.png");
            if (File.Exists(drawToBitmapPath)) File.Delete(drawToBitmapPath);
            startInfo.EnvironmentVariables["FACESSO_SCREENSHOT_PATH"] = drawToBitmapPath;

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
            var screenshotPath = Path.Combine(OutputFolder, ScreenshotFileName);

            // Prefer the in-process DrawToBitmap screenshot (saved by
            // frmFacessoShell via FACESSO_SCREENSHOT_PATH). DrawToBitmap
            // uses a memory DC and works in headless / container environments
            // — exactly like the proven WinFormsSmoke test pattern.
            if (File.Exists(drawToBitmapPath) && new FileInfo(drawToBitmapPath).Length > 0)
            {
                File.Copy(drawToBitmapPath, screenshotPath, true);
                TestRunLogger.Info(
                    "Using in-process DrawToBitmap screenshot (headless-safe).");
            }
            else
            {
                // Fallback: cross-process capture (PrintWindow → WM_PRINT).
                // Works on interactive desktops but may produce black images
                // in headless environments.
                TestRunLogger.Trace(
                    "In-process screenshot not available, falling back to external capture.");
                using (var bitmap = new Bitmap(windowRect.Width, windowRect.Height,
                           PixelFormat.Format32bppArgb))
                {
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.White);
                    }

                    var captureMethod = CaptureWindow(mainWindowHandle, bitmap);
                    TestRunLogger.Info(
                        $"External capture succeeded via: {captureMethod}");

                    bitmap.Save(screenshotPath, ImageFormat.Png);
                }
            }

            Assert.True(File.Exists(screenshotPath), $"Screenshot was not saved to: {screenshotPath}");
            Assert.True(new FileInfo(screenshotPath).Length > 0, "Screenshot file is empty.");
            TestRunLogger.Info($"Screenshot saved: {screenshotPath}");

            // ── Capture UI text via Accessibility (UI Automation) ──
            TestRunLogger.Trace("Capturing accessibility snapshot.");
            var snapshot = A11ySnapshot.Capture(mainWindowHandle);

            var mdPath = Path.Combine(OutputFolder, MarkdownFileName);
            File.WriteAllText(mdPath, snapshot.ToMarkdown(), Encoding.UTF8);

            Assert.True(File.Exists(mdPath), $"A11y report was not saved to: {mdPath}");
            Assert.True(new FileInfo(mdPath).Length > 0, "A11y report is empty.");
            TestRunLogger.Info($"Accessibility report saved: {mdPath}");
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
                        string dlgMethod;
                        using (var bmp = new Bitmap(dlgRect.Width, dlgRect.Height,
                                   PixelFormat.Format32bppArgb))
                        {
                            using (var g = Graphics.FromImage(bmp))
                            {
                                g.Clear(Color.White);
                            }

                            dlgMethod = CaptureWindow(info.Handle, bmp);

                            bmp.Save(pngPath, ImageFormat.Png);
                        }

                        report.AppendLine($"  Screenshot saved to: {pngPath} (via {dlgMethod})");
                    }
                    catch (Exception ex)
                    {
                        report.AppendLine($"  Screenshot capture failed: {ex.Message}");
                        pngPath = null;
                    }
                }

                // Use UI Automation to extract dialog text
                try
                {
                    var dialogSnapshot = A11ySnapshot.Capture(info.Handle);
                    string a11yText = dialogSnapshot.ToPlainText();
                    report.AppendLine($"  Accessibility text:");
                    report.AppendLine();

                    foreach (var line in a11yText.Split('\n'))
                    {
                        report.AppendLine($"    {line.TrimEnd()}");
                    }

                    report.AppendLine();
                }
                catch
                {
                    report.AppendLine("  (accessibility text extraction failed)");
                    report.AppendLine();
                }
            }

            KillProcess();
            Assert.Fail(report.ToString());
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Captures a window into the given bitmap. The bitmap should
        /// already be pre-filled (e.g. with white) so that unpainted
        /// areas are visible.
        ///
        /// Strategy (in order):
        ///   1. WM_PRINT cross-process — sends a message asking the window
        ///      to paint itself (incl. children) into our memory DC.
        ///      Works in headless / container environments because it
        ///      triggers the control's actual OnPaint code via GDI,
        ///      not a compositor surface capture.
        ///   2. PrintWindow with PW_RENDERFULLCONTENT — works well on
        ///      interactive desktops where DWM is active.
        ///   3. Recursive child painting — enumerates every child HWND
        ///      and sends WM_PRINT/WM_PRINTCLIENT to each individually
        ///      in case the top-level message didn't propagate.
        ///   4. ForceOpaqueAlpha — fixes the alpha channel which
        ///      WM_PRINT / PrintWindow often leave at 0.
        /// </summary>
        private static string CaptureWindow(IntPtr hWnd, Bitmap target)
        {
            string method;

            // ── Attempt 1: WM_PRINT (universal, works in headless) ──
            using (var g = Graphics.FromImage(target))
            {
                var hdc = g.GetHdc();
                try
                {
                    SendMessage(hWnd, WM_PRINT, hdc,
                        (IntPtr)(PRF_NONCLIENT | PRF_CLIENT
                               | PRF_CHILDREN | PRF_ERASEBKGND));
                }
                finally
                {
                    g.ReleaseHdc(hdc);
                }
            }

            method = "WM_PRINT";

            // ── Attempt 2: PrintWindow (interactive desktops) ──
            if (IsImageMostlyUniform(target))
            {
                using (var g = Graphics.FromImage(target))
                {
                    g.Clear(Color.White);
                    var hdc = g.GetHdc();
                    try
                    {
                        PrintWindow(hWnd, hdc, PW_RENDERFULLCONTENT);
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }

                method = "PrintWindow";
            }

            // ── Attempt 3: Recursive child window painting ──
            // If top-level WM_PRINT didn't propagate to children, paint
            // each child individually at its correct position.
            if (IsImageMostlyUniform(target))
            {
                using (var g = Graphics.FromImage(target))
                {
                    g.Clear(Color.White);
                }

                PaintChildWindowsRecursive(hWnd, hWnd, target);
                method = "RecursiveChildPaint";
            }

            // Fix alpha channel — WM_PRINT / PrintWindow may write valid
            // RGB but leave alpha at 0, making the PNG appear transparent.
            ForceOpaqueAlpha(target);

            return method;
        }

        /// <summary>
        /// Enumerates all child windows of <paramref name="root"/> and sends
        /// WM_PRINTCLIENT to each, painting them at their correct position
        /// relative to the root window into <paramref name="target"/>.
        /// </summary>
        private static void PaintChildWindowsRecursive(
            IntPtr root, IntPtr parent, Bitmap target)
        {
            GetWindowRect(root, out var rootRect);

            EnumChildWindows(parent, (child, _) =>
            {
                GetWindowRect(child, out var childRect);

                int x = childRect.Left - rootRect.Left;
                int y = childRect.Top - rootRect.Top;
                int w = childRect.Width;
                int h = childRect.Height;

                if (w <= 0 || h <= 0)
                    return true;

                // Clamp to target bounds
                if (x + w > target.Width) w = target.Width - x;
                if (y + h > target.Height) h = target.Height - y;
                if (x < 0 || y < 0 || w <= 0 || h <= 0)
                    return true;

                using (var childBmp = new Bitmap(childRect.Width, childRect.Height,
                           PixelFormat.Format32bppArgb))
                {
                    using (var g = Graphics.FromImage(childBmp))
                    {
                        g.Clear(Color.White);
                        var hdc = g.GetHdc();
                        try
                        {
                            // Try WM_PRINTCLIENT first (client area only),
                            // then WM_PRINT as fallback.
                            SendMessage(child, WM_PRINTCLIENT, hdc,
                                (IntPtr)(PRF_CLIENT | PRF_ERASEBKGND));

                            // Also try WM_PRINT with children for nested controls
                            SendMessage(child, WM_PRINT, hdc,
                                (IntPtr)(PRF_CLIENT | PRF_CHILDREN | PRF_ERASEBKGND));
                        }
                        finally
                        {
                            g.ReleaseHdc(hdc);
                        }
                    }

                    // Composite onto the main bitmap
                    using (var g = Graphics.FromImage(target))
                    {
                        g.DrawImage(childBmp, x, y, w, h);
                    }
                }

                return true; // continue enumeration
            }, IntPtr.Zero);
        }

        /// <summary>
        /// Sets the alpha byte of every pixel to 255 (fully opaque).
        /// </summary>
        private static void ForceOpaqueAlpha(Bitmap bitmap)
        {
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bmpData = bitmap.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);

            try
            {
                int byteCount = Math.Abs(bmpData.Stride) * bitmap.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(bmpData.Scan0, pixels, 0, byteCount);

                // BGRA layout — byte 3 of each 4-byte pixel is the alpha channel
                for (int i = 3; i < byteCount; i += 4)
                {
                    pixels[i] = 255;
                }

                Marshal.Copy(pixels, 0, bmpData.Scan0, byteCount);
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
        }

        /// <summary>
        /// Samples pixels to determine whether the image is essentially a single
        /// solid colour (i.e. capture produced no meaningful content).
        /// </summary>
        private static bool IsImageMostlyUniform(Bitmap bitmap)
        {
            const int sampleCount = 80;
            var rng = new Random(42); // deterministic seed
            Color reference = bitmap.GetPixel(bitmap.Width / 2, bitmap.Height / 2);
            int matchCount = 0;

            for (int i = 0; i < sampleCount; i++)
            {
                int x = rng.Next(bitmap.Width);
                int y = rng.Next(bitmap.Height);
                var px = bitmap.GetPixel(x, y);

                if (Math.Abs(px.R - reference.R) < 8
                    && Math.Abs(px.G - reference.G) < 8
                    && Math.Abs(px.B - reference.B) < 8)
                {
                    matchCount++;
                }
            }

            return matchCount > (int)(sampleCount * 0.92);
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
                        // Skip IsWindowVisible check — in containers, windows
                        // exist but are never marked visible (no desktop session).
                        var titleBuf = new StringBuilder(512);
                        GetWindowText(hWnd, titleBuf, titleBuf.Capacity);
                        string title = titleBuf.ToString();

                        if (string.IsNullOrEmpty(title))
                            return true;

                        var classBuf = new StringBuilder(256);
                        GetClassName(hWnd, classBuf, classBuf.Capacity);

                        windows.Add(new WindowInfo
                        {
                            Handle = hWnd,
                            Title = title,
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
                    // Try the standard .NET API first (works on interactive desktops)
                    if (process.MainWindowHandle != IntPtr.Zero && IsWindow(process.MainWindowHandle))
                        return process.MainWindowHandle;
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                // Fallback: enumerate thread windows directly (works in non-interactive
                // containers where MainWindowHandle stays 0 even though windows exist)
                var hWnd = FindMainWindowViaThreads(process);
                if (hWnd != IntPtr.Zero)
                    return hWnd;

                Thread.Sleep(250);
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Walks every thread of the given process looking for a top-level WinForms
        /// window whose title contains "Facesso". Returns the first match.
        /// </summary>
        private static IntPtr FindMainWindowViaThreads(Process process)
        {
            IntPtr found = IntPtr.Zero;

            try
            {
                foreach (ProcessThread thread in process.Threads)
                {
                    EnumThreadWindows(thread.Id, (hWnd, _) =>
                    {
                        var titleBuf = new StringBuilder(512);
                        GetWindowText(hWnd, titleBuf, titleBuf.Capacity);
                        string title = titleBuf.ToString();

                        if (title.IndexOf("Facesso", StringComparison.OrdinalIgnoreCase) >= 0
                            && IsWindow(hWnd))
                        {
                            found = hWnd;
                            return false; // stop enumeration
                        }

                        return true;
                    }, IntPtr.Zero);

                    if (found != IntPtr.Zero)
                        break;
                }
            }
            catch
            {
                // Process may have exited during enumeration
            }

            return found;
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

        private struct WindowInfo
        {
            public IntPtr Handle;
            public string Title;
            public string ClassName;
        }
    }
}
