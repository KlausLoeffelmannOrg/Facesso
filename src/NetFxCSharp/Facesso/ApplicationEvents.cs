using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.My
{
    // The following events are availble for MyApplication:
    //
    // Startup: Raised when the application starts, before the startup form is created.
    // Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    // UnhandledException: Raised if the application encounters an unhandled exception.
    // StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    // NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    internal partial class MyApplication
    {
        private void MyApplication_Shutdown(object sender, System.EventArgs e)
        {
            FacessoGeneric.AppSettings.Save();
        }

        private void MyApplication_Startup(object sender, Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            //Enable diagnostic file logging when FACESSO_DIAG_LOG is set (e.g. in containers)
            var diagLogPath = Environment.GetEnvironmentVariable("FACESSO_DIAG_LOG");
            if (!(string.IsNullOrEmpty(diagLogPath)))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(diagLogPath));
                    System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(diagLogPath));
                    System.Diagnostics.Trace.AutoFlush = true;
                }
                catch
                {
                }
            }

            System.Diagnostics.Trace.TraceInformation("Facesso startup beginning.");
            System.Diagnostics.Trace.TraceInformation("UserInteractive={0}, CommandLine={1}", Environment.UserInteractive, Environment.CommandLine);
            //Deutsche Kultur erzwingen im Bedarfsfall
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("de-DE");
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            //Splash-Dialog (skip in non-interactive environments such as containers)
            frmSplash locSplash = null;
            if (Environment.UserInteractive)
            {
                locSplash = new frmSplash();
                locSplash.Show();
                this.DoEvents();
            }

            //Ist Setup ordnungsgemäß durchgeführt?
            System.Diagnostics.Trace.TraceInformation("Checking FacessoGeneric.IsSetup...");
            if (!(FacessoGeneric.IsSetup()))
            {
                System.Diagnostics.Trace.TraceWarning("Facesso is not configured.");
                if (Environment.UserInteractive)
                {
                    MessageBox.Show("Facesso kann keinen Hinweis darauf finden, dass die Software bereits mit FacessoConfig konfiguriert wurde." + System.Environment.NewLine + "Bitte starten Sie FacessoConfig aus dem Start-Menü (ActiveDevelop/Facesso). Sie benötigen für die Konfiguration lokale Administratorrechte.", "Facesso-Konfigurations:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Console.Error.WriteLine("Facesso is not configured. Please run FacessoConfig first.");
                }

                e.Cancel = true;
            }
            else
            {
                //Ist Datenbank-Setup ordnungsgemäß durchgeführt?
                System.Diagnostics.Trace.TraceInformation("Initializing FacessoGeneric...");
                FacessoGeneric.InitializeComponent();
                System.Diagnostics.Trace.TraceInformation("Checking IsDatabaseSetup...");
                if (!(FacessoGeneric.IsDatabaseSetup()))
                {
                    System.Diagnostics.Trace.TraceWarning("Database is not configured.");
                    if (Environment.UserInteractive)
                    {
                        frmDbSetupWizard locDbSetupWizard = new frmDbSetupWizard();
                        locDbSetupWizard.ShowDialog();
                    }
                    else
                    {
                        Console.Error.WriteLine("Database is not configured. Please run database setup first.");
                    }

                    e.Cancel = true;
                }
                else
                {
                    //Schema-Update im Bedarfsfall.
                    System.Diagnostics.Trace.TraceInformation("Checking schema update...");
                    Facesso.Data.DatenModelUpdater dmUpdater = new Facesso.Data.DatenModelUpdater(FacessoGeneric.SQLConnectionString, true);
                    if (dmUpdater.CheckIfUpdateRequired())
                    {
                        System.Diagnostics.Trace.TraceInformation("Schema update required, performing...");
                        if (Environment.UserInteractive)
                        {
                            //TODO: An Facesso-Meldungen anpassen
                            MessageBox.Show("Es müssen Änderungen an der Datenbank vorgenommen werden. Alle Facesso-Programme müssen - mit Ausnahme Ihres Programms - beendet werden. Klicken sie auf OK, wenn dieses erfolgt ist.", "WICHTIGER HINWEIS");
                        }

                        try
                        {
                            dmUpdater.PerformSchemaUpdate();
                            System.Diagnostics.Trace.TraceInformation("Schema update completed.");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.TraceError("Schema update failed: " + ex.ToString());
                            if (Environment.UserInteractive)
                            {
                                MessageBox.Show("Das Datenmodell konnte nicht angepasst werden.Grund:" + ex.Message, "Hinweis");
                            }
                            else
                            {
                                Console.Error.WriteLine("Schema update failed: " + ex.Message);
                            }

                            e.Cancel = true;
                        }
                    }

                    //Wenn wir hier landen, ist alles gut!
                    if (!(e.Cancel))
                    {
                        System.Diagnostics.Trace.TraceInformation("Setup OK. Performing login...");
                        FacessoGeneric.SetupLicenseInfoAndLogin();
                        System.Diagnostics.Trace.TraceInformation("Login completed successfully.");
                    }
                }
            }

            //Entsorgen ohne Wenn und Aber!
            if (locSplash != null)
            {
                locSplash.Dispose();
            }

            System.Diagnostics.Trace.TraceInformation("Facesso startup finished. Cancel={0}", e.Cancel);
        }

        private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
        {
            if (!(Environment.UserInteractive))
            {
                System.Diagnostics.Trace.TraceError("Unhandled exception (non-interactive): " + e.Exception.ToString());
                Console.Error.WriteLine("Unhandled exception: " + e.Exception.ToString());
                Environment.ExitCode = 1;
                e.ExitApplication = true;
                return;
            }

            if (e.Exception.GetType() == typeof(ActiveDev.ADLicenseUnvalidException))
            {
                MessageBox.Show("Facesso hat ein Problem mit den Lizensierungsinformationen festgestellt." + System.Environment.NewLine + "Der genaue Problemtext lautet:" + System.Environment.NewLine + System.Environment.NewLine + e.Exception.Message, "Lizenzunstimmigkeiten", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.Exception.GetType() == typeof(FacessoLoginException))
            {
                MessageBox.Show("Sie haben den Login-Vorgang abgebrochen, und Faccesso.NET wird daher nun beendet!", "Abbruch des Login-Vorgangs!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (e.Exception.GetType() == typeof(FacessoEndOfSetupException))
            {
                MessageBox.Show("Der Abschluss bzw. Abbruch der Installation macht einen Neustart der Anwendung erforderlich.", "Facesso-Setup beendet.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmError locError = new frmError();
                locError.HandleDialog(e.Exception);
            }
        }
    }
}