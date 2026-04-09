using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ActiveDev
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string cultureName = "de-DE";

            foreach (string arg in args)
            {
                if (arg.Equals("--English", StringComparison.OrdinalIgnoreCase) ||
                    arg.Equals("/English", StringComparison.OrdinalIgnoreCase))
                {
                    cultureName = "en-US";
                    break;
                }

                if (arg.Equals("--German", StringComparison.OrdinalIgnoreCase) ||
                    arg.Equals("/German", StringComparison.OrdinalIgnoreCase))
                {
                    cultureName = "de-DE";
                    break;
                }
            }

            CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
