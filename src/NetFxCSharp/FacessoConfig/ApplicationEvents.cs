using ActiveDev;
using Facesso;
using Facesso.Data;
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

namespace FacessoConfig.My
{
    // The following events are available for MyApplication:
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
            //Splash-Dialog
            //Ist Setup ordnungsgemäß durchgeführt?
            if (!(FacessoGeneric.IsSetup()))
            {
                frmSetupWizard locSetupWizard = new frmSetupWizard();
                locSetupWizard.ShowDialog();
                e.Cancel = true;
            }
            else
            {
                //Ist Datenbank-Setup ordnungsgemäß durchgeführt?
                FacessoGeneric.InitializeComponent();
                if (!(FacessoGeneric.IsDatabaseSetup()))
                {
                    frmDbSetupWizard locDbSetupWizard = new frmDbSetupWizard();
                    locDbSetupWizard.ShowDialog();
                    e.Cancel = true;
                }
                else
                {
                    //Schema-Update im Bedarfsfall.
                    DatenModelUpdater dmUpdater = new DatenModelUpdater(FacessoGeneric.SQLConnectionString, true);
                    if (dmUpdater.CheckIfUpdateRequired())
                    {
                        //TODO: An Facesso-Meldungen anpassen
                        MessageBox.Show("Es müssen Änderungen an der Datenbank vorgenommen werden. Alle Facesso-Programme müssen - mit Ausnahme Ihres Programms - beendet werden. Klicken sie auf OK, wenn dieses erfolgt ist.", "WICHTIGER HINWEIS");
                        try
                        {
                            dmUpdater.PerformSchemaUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Das Datenmodell konnte nicht angepasst werden. Grund:" + ex.Message, "Hinweis");
                            e.Cancel = true;
                        }
                    }

                    //Wenn wir hier landen, ist alles gut!
                    if (!(e.Cancel))
                    {
                        //Checken, ob die Lizenz gültig ist und nur dann das Login durchführen.
                        //Facesso-Generic ist eine Singleton-Klasse, die die Lizenzinformation ermittelt,
                        //überprüft, speichert, die Info hält, welche Benutzer was machen darf,
                        //das Login-durchführt und den angemeldeten Benutzer gegen die Lizenzinfo abgleicht.
                        FacessoGeneric.SetupLicenseInfoAndLogin();
                    }
                }
            }
        }

        private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
        {
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
                MessageBox.Show("Der Abschluss bzw. Abbruch der Installation macht das Beenden des Konfigurations-Werkzeuges erforderlich.", "Facesso-Config-Setup beendet.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmError locError = new frmError();
                locError.HandleDialog(e.Exception);
            }
        }
    }
}