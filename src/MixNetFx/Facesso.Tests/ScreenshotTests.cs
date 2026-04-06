using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Xunit;

namespace Facesso.Tests
{
    /// <summary>
    /// Starts the Facesso application with /silentAdminLogon,
    /// brings it to fullscreen, captures a screenshot via PrintWindow,
    /// and saves the result as a PNG file to c:\out.
    /// </summary>
    public class ScreenshotTests : IDisposable
    {
        private Process _facessoProcess;

        private const string OutputFolder = @"c:\out";
        private const string ScreenshotFileName = "FacessoScreenshot.png";
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

            // Start Facesso with silent admin logon
            _facessoProcess = Process.Start(new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = "/silentAdminLogon",
                UseShellExecute = false
            });

            Assert.NotNull(_facessoProcess);

            // Wait for the main window to appear
            var mainWindowHandle = WaitForMainWindow(_facessoProcess, StartupTimeoutMs);
            Assert.True(mainWindowHandle != IntPtr.Zero,
                "Facesso main window did not appear within the timeout period.");

            // Maximize the window (fullscreen)
            SetForegroundWindow(mainWindowHandle);
            ShowWindow(mainWindowHandle, SW_SHOWMAXIMIZED);

            // Give the application time to render fully
            Thread.Sleep(RenderDelayMs);

            // Capture the window via PrintWindow
            GetWindowRect(mainWindowHandle, out var rect);
            Assert.True(rect.Width > 0 && rect.Height > 0,
                $"Window has invalid dimensions: {rect.Width}x{rect.Height}");

            using (var bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var hdc = graphics.GetHdc();
                try
                {
                    bool success = PrintWindow(mainWindowHandle, hdc, PW_RENDERFULLCONTENT);
                    Assert.True(success, "PrintWindow failed to capture the window content.");
                }
                finally
                {
                    graphics.ReleaseHdc(hdc);
                }

                // Save the screenshot
                Directory.CreateDirectory(OutputFolder);
                var outputPath = Path.Combine(OutputFolder, ScreenshotFileName);
                bitmap.Save(outputPath, ImageFormat.Png);

                Assert.True(File.Exists(outputPath), $"Screenshot was not saved to: {outputPath}");
                Assert.True(new FileInfo(outputPath).Length > 0, "Screenshot file is empty.");
            }
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
    }
}
