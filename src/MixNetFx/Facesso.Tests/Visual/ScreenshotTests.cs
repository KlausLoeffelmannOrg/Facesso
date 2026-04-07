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
using Facesso.Tests.Infrastructure;

namespace Facesso.Tests.Visual
{
    /// <summary>
    /// Starts the Facesso application with /silentAdminLogon,
    /// brings it to fullscreen, captures a screenshot via PrintWindow,
    /// and saves the result as a PNG file to c:\out.
    /// If the main window does not appear in time, the test looks for a
    /// modal dialog, captures and OCR's it, then tears the process down.
    /// </summary>
    public class ScreenshotTests : IDisposable
    {
        private Process _facessoProcess;

        private const string OutputFolder = @"c:\output";
        private const string ScreenshotFileName = "FacessoScreenshot.png";
        private const string DialogScreenshotFileName = "FacessoDialog.png";
        private const int StartupTimeoutMs = 30_000;
        private const int RenderDelayMs = 3_000;

        #region Win32 Interop

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

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
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Width => Right - Left;
            public int Height => Bottom - Top;
        }

        #endregion

        [Fact]
        public void Facesso_CaptureScreenshot()
        {
            var exePath = FindFacessoExe();
            Assert.True(File.Exists(exePath), $"Facesso.exe not found at: {exePath}");

            TestRunLogger.Trace($"Starting Facesso.exe from: {exePath}");

            // Start Facesso with silent admin logon
            _facessoProcess = Process.Start(new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = "/silentAdminLogon",
                RedirectStandardError = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal
            });

            Assert.NotNull(_facessoProcess);

            TestRunLogger.Trace($"{_facessoProcess.ProcessName} is now running.");

            // Wait for the main window to appear
            var mainWindowHandle = WaitForMainWindow(_facessoProcess, StartupTimeoutMs);
            TestRunLogger.Trace($"Got mainWindowHandle {mainWindowHandle}.");

            if (mainWindowHandle == IntPtr.Zero)
            {
                // Main window never appeared — look for a modal dialog instead
                TestRunLogger.Trace($"mainWindowHandle was unvalid, though.");
                HandleMissingMainWindow();
                return; // HandleMissingMainWindow always calls Assert.Fail
            }

            // Maximize the window (fullscreen)
            TestRunLogger.Trace($"Setting Application window as foreground window.");
            SetForegroundWindow(mainWindowHandle);

            TestRunLogger.Trace($"Show the window.");
            ShowWindow(mainWindowHandle, SW_SHOWMAXIMIZED);

            // Give the application time to render fully
            TestRunLogger.Trace($"Giving time for the messages to process.");
            Thread.Sleep(RenderDelayMs);
            TestRunLogger.Trace($"Continuing.");

            // Capture the window via PrintWindow
            TestRunLogger.Trace($"Retrieving the Window Rectangle of the main window.");
            GetWindowRect(mainWindowHandle, out var rect);
            Assert.True(rect.Width > 0 && rect.Height > 0,
                $"Window has invalid dimensions: {rect.Width}x{rect.Height}");

            TestRunLogger.Trace($"Creating a bitmap in that size.");
            using (var bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                TestRunLogger.Trace($"Retrieving the Bitmap's HDC.");
                var hdc = graphics.GetHdc();

                TestRunLogger.Trace($"Try capturing the main window into the bitmap.");
                try
                {
                    bool success = PrintWindow(mainWindowHandle, hdc, PW_RENDERFULLCONTENT);
                    Assert.True(success, "PrintWindow failed to capture the window content.");
                }
                finally
                {
                    graphics.ReleaseHdc(hdc);
                }

                TestRunLogger.Trace($"Cleaning up resources and saving screenshot.");

                // Save the screenshot
                Directory.CreateDirectory(OutputFolder);
                var outputPath = Path.Combine(OutputFolder, ScreenshotFileName);
                bitmap.Save(outputPath, ImageFormat.Png);

                Assert.True(File.Exists(outputPath), $"Screenshot was not saved to: {outputPath}");
                Assert.True(new FileInfo(outputPath).Length > 0, "Screenshot file is empty.");
            }
        }

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

                // Capture the dialog window
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

                // OCR the captured dialog image
                if (pngPath != null && File.Exists(pngPath))
                {
                    string ocrText = OcrDialogImage(pngPath);
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

        /// <summary>
        /// OCR's a dialog screenshot using Tesseract (eng+deu).
        /// Returns the recognised text, or an error description on failure.
        /// </summary>
        private static string OcrDialogImage(string imagePath)
        {
            try
            {
                var tessdataDir = Path.Combine(
                    Path.GetDirectoryName(typeof(ScreenshotTests).Assembly.Location),
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

        /// <summary>
        /// Enumerates all visible top-level windows belonging to the given process
        /// by walking each of the process's threads with EnumThreadWindows.
        /// </summary>
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
                            return true; // continue

                        var titleBuf = new StringBuilder(512);
                        GetWindowText(hWnd, titleBuf, titleBuf.Capacity);

                        var classBuf = new StringBuilder(256);
                        GetClassName(hWnd, classBuf, classBuf.Capacity);

                        GetWindowRect(hWnd, out var r);
                        if (r.Width <= 0 || r.Height <= 0)
                            return true; // skip zero-size windows

                        windows.Add(new WindowInfo
                        {
                            Handle = hWnd,
                            Title = titleBuf.ToString(),
                            ClassName = classBuf.ToString()
                        });

                        return true; // continue
                    }, IntPtr.Zero);
                }
            }
            catch
            {
                // Process may have exited during enumeration
            }

            return windows;
        }

        /// <summary>
        /// Waits for the process to create its main window handle.
        /// </summary>
        private static IntPtr WaitForMainWindow(Process process, int timeoutMs)
        {
            var sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                process.Refresh();

                if (process.MainWindowHandle != IntPtr.Zero && IsWindow(process.MainWindowHandle))
                    return process.MainWindowHandle;

                if (process.HasExited)
                    break;

                Thread.Sleep(250);
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Locates the Facesso.exe build output relative to the test assembly.
        /// </summary>
        private static string FindFacessoExe()
        {
            var testAssemblyDir = Path.GetDirectoryName(typeof(ScreenshotTests).Assembly.Location);

            // Try common build output paths relative to test output (Facesso.Tests/bin/{Config}/net472)
            string[] configurations = { "Debug", "Release" };

            foreach (var config in configurations)
            {
                var candidate = Path.GetFullPath(
                    Path.Combine(testAssemblyDir, "..", "..", "..", "..", "Facesso", "bin", config, "net472", "Facesso.exe"));

                if (File.Exists(candidate))
                    return candidate;
            }

            // Fallback: look in the same directory as the test assembly
            var sameDir = Path.Combine(testAssemblyDir, "Facesso.exe");
            if (File.Exists(sameDir))
                return sameDir;

            return Path.GetFullPath(
                Path.Combine(testAssemblyDir, "..", "..", "..", "..", "Facesso", "bin", "Debug", "net472", "Facesso.exe"));
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
