using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ActiveDev;

namespace Facesso
{
    public partial class frmSetupWizard : Form
    {
        private string myOleDBConnectionString;
        private string mySQLConnectionString;
        private int mySubsidiaryID = 1;
        private bool myStepAfterSQLConnectionChoice;
        private bool myDatabaseAlreadySetup;

        private ADWizardController myWizardController;

        public frmSetupWizard()
        {
            try
            {
                if (!RegistryHelper.IsRegistered())
                {
                    RegistryHelper.Register(false);
                    RegistryHelper.InstallationDate = DateTime.Now;
                    RegistryHelper.LastRegisteredDate = RegistryHelper.InstallationDate;
                    RegistryHelper.ProgramGUID = ADCryptography.GetRandomGUID().ToString();
                    RegistryHelper.ConnectionString = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Facesso konnte nicht konfiguriert werden - überprüfen Sie, ob Ihr Anmeldekonto ausreichende Rechte besetzt, um Installations- und Konfigurationsaufgaben einer Windows-Software wahrnehmen zu können!",
                    "Konfiguration nicht möglich:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RegistryHelper.LastRunDate = DateTime.Now;

            if (!RegistryHelper.IsRegistered())
            {
                RegistryHelper.Register(false);
                RegistryHelper.InstallationDate = DateTime.Now;
                RegistryHelper.LastRegisteredDate = RegistryHelper.InstallationDate;
                RegistryHelper.ProgramGUID = ADCryptography.GetRandomGUID().ToString();
                RegistryHelper.ConnectionString = "";
            }
            else
            {
                DialogResult locDR = MessageBox.Show(
                    "Sie haben diese Kopie von Facesso bereits freigeschaltet." + "\r\n" +
                    "Wenn Sie die Prozedur abermals durchführen, werden die alten Einstellungen" + "\r\n" +
                    "ungültig, und Sie benötigen obendrein eine neue Seriennummer." + "\r\n" +
                    "Möchten Sie die Freischaltung WIRKLICH neu durchführen?",
                    "Freischaltung neu durchführen?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (locDR == System.Windows.Forms.DialogResult.No)
                {
                    Close();
                    throw new FacessoEndOfSetupException("Abbruch des Setups führte zu Ausnahme (kein kritischer Fehler).", null);
                }
            }

            RegistryHelper.LastRegisteredDate = DateTime.Now;

            Guid locGuid = new Guid(RegistryHelper.ProgramGUID);
            DateTime locInstDate = RegistryHelper.InstallationDate;
            string locPreSerial = ADLicenseManager.GetPreSerialNo(locGuid, locInstDate);
            int locCount = 0;
            string locFormattedPreSerial = "";
            foreach (char locChar in locPreSerial)
            {
                if (locCount == 5)
                {
                    locCount = 0;
                    locFormattedPreSerial += " - ";
                }
                locFormattedPreSerial += locChar.ToString();
                locCount++;
            }
            lblPreSerialNo.Text = locFormattedPreSerial;
            try
            {
                System.Windows.Forms.Clipboard.SetText(locFormattedPreSerial);
            }
            catch { }

            myWizardController = new ADWizardController(btnBack, btnNext, btnCancel, tcWizard);
            myWizardController.Initialize();
            txtConnectionString.Text = @"Server=.\SQLEXPRESS;Database=Facesso;Integrated Security=True; AttachDBFileName=" +
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                @"\Facesso.mdf";

            FacessoPathSettings.InstallationFolder = FacessoGeneric.InstallationFolder;
            FacessoPathSettings.UpdateFolder = FacessoGeneric.UpdateFolder;
            FacessoPathSettings.UpdateUrl = FacessoGeneric.UpdateUrl;
            FacessoPathSettings.SharedFolder = FacessoGeneric.SharedFolder;
        }

        private void myWizardController_Cancel(object sender, EventArgs e)
        {
            string locMessage = "Sind Sie sicher, dass Sie den Assistenten abbrechen möchten?";
            DialogResult locdr = MessageBox.Show(locMessage, "Assistenten beenden?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (locdr == System.Windows.Forms.DialogResult.Yes)
                throw new FacessoEndOfSetupException("Abbruch des Setups führte zu Ausnahme (kein kritischer Fehler).", null);
        }

        private void myWizardController_StepChanged(object sender, ADWizardStepChangeEventArgs e)
        {
            if (e.WizardStepAction == ADWizardStepAction.NoChange)
            {
                e.NextStepAllowed = true;
                return;
            }

            if (e.WizardStepAction == ADWizardStepAction.NextStep)
            {
                if (e.NewStepNo == 0)
                {
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 1)
                {
                    e.Cancel = !Step2_ValidateSerialNo();
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 2)
                {
                    e.Cancel = !Step3_ValidateSQLConnection();
                    if (IsDatabaseSetup())
                    {
                        e.WizardStepAction = ADWizardStepAction.SkipAllRemainingSteps;
                        myDatabaseAlreadySetup = true;
                        DialogResult locDR = MessageBox.Show(
                            "Die Datenbank ist bereits eingerichtet! Möchten Sie alle Daten dennoch löschen und neu einrichten?",
                            "Datenbank bereits vorhanden!", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
                        if (locDR == System.Windows.Forms.DialogResult.Yes)
                        {
                            locDR = MessageBox.Show("Sind Sie sicher? (Alle Daten GEHEN VERLOREN!!!)",
                                "Bestätigung - Datenverlust droht!", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (locDR == System.Windows.Forms.DialogResult.Yes)
                            {
                                e.WizardStepAction = ADWizardStepAction.NextStep;
                                myDatabaseAlreadySetup = false;
                            }
                        }
                        e.NextStepAllowed = true;
                    }
                }
                else if (e.NewStepNo == 3)
                {
                    e.Cancel = !Step4_CompanyData();
                }
                else if (e.NewStepNo == 4)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 5)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 6)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
            }
        }

        private bool Step2_ValidateSerialNo()
        {
            string locSerialString = mtbSerialNo.Text;
            var locLicense = new FacessoLicenseManager(new Guid(RegistryHelper.ProgramGUID),
                RegistryHelper.InstallationDate, RegistryHelper.LastRunDate,
                RegistryHelper.LastRegisteredDate, locSerialString);

            if (locLicense.LicenseInfo().HasFallenBack && !locLicense.IsSerialNoValid)
            {
                DialogResult dr = MessageBox.Show(
                    "Die angegebene Freischaltnummer passt nicht zu Ihrem System oder Ihrer Facesso-Ausbaustufe." + "\r\n" +
                    "Sie können ohne Freischaltung zunächst 30 Tage weiterarbeiten, bevor Facesso seinen Dienst einstellt." + "\r\n" +
                    "Holen Sie die Freischaltung dann zu einem späteren Zeitpunkt nach." + "\r\n" +
                    "Wenn Sie die Freischaltung JETZT wiederholen möchten, wählen Sie [Wiederholen]," + "\r\n" +
                    "anderenfalls klicken Sie [Abbrechen], um ohne Freischaltung fortzufahren.",
                    "Ungültige Seriennummer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                return dr != System.Windows.Forms.DialogResult.Retry;
            }

            try
            {
                if (locLicense.IsLicensed())
                {
                    RegistryHelper.SerialNumber = locSerialString;
                    return true;
                }
            }
            catch (Exception)
            {
                DialogResult dr = MessageBox.Show(
                    "Die angegebene Freischaltnummer passt nicht zu Ihrem System oder Ihrer Facesso-Ausbaustufe." + "\r\n" +
                    "Eine Testfrist, mit der Sie 30 Tage zur Probe arbeiten konnten, ist bereits abgelaufen." + "\r\n" +
                    "Wenn Sie die Freischaltung JETZT wiederholen möchten, wählen Sie [Wiederholen], anderenfalls klicken" + "\r\n" +
                    "Sie [Abbrechen], um die Freischaltung abzubrechen, die Sie aber durch Neustart wiederholen können.",
                    "Ungültige Seriennummer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.Retry)
                    return false;
                else
                    throw;
            }
            return false;
        }

        private bool Step3_ValidateSQLConnection()
        {
            var locSQLConnection = new SqlConnection(txtConnectionString.Text);
            using (locSQLConnection)
            {
                try
                {
                    locSQLConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim Öffnen der Datenbankverbindung ist ein Fehler aufgetreten:" + "\r\n" +
                        ex.Message, "Fehler bei der Verbindungsherstellung",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                RegistryHelper.ConnectionString = txtConnectionString.Text;
                mySQLConnectionString = txtConnectionString.Text;
            }
            return true;
        }

        private bool Step4_CompanyData()
        {
            if (txtSubsidiaryName.Text == "" || txtStreet.Text == "" || txtZip.Text == "" ||
                txtCity.Text == "" || txtCountry.Text == "" || txtCountryCode.Text == "" || txtPrimaryPhone.Text == "")
            {
                MessageBox.Show("Bitte füllen Sie die Felder vollständig aus!", "Fehlende Eingabe(n)",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void myWizardController_Finished(object sender, EventArgs e)
        {
            string locString1 = "MSI!=Mainboard Creation Computer";
            string locString2 = "Cuslaka, Alfred";
            string locString3 = "2cp3b - Fargoroad";

            var locCryptedPassword = new ADCryptedPassword(txtPassword.Text);
            locString2 = locString1.Substring(0, 4) + locString2.Substring(0, 4);
            var locSystemPassword = new ADCryptedPassword(locString2 + locString3.Substring(0, 5) + "f");
            if (!myDatabaseAlreadySetup)
            {
                InitializeDatabase(locCryptedPassword.CryptedPassword, locSystemPassword.CryptedPassword,
                    txtSubsidiaryName.Text, txtStreet.Text, txtZip.Text, txtCity.Text,
                    txtCountryCode.Text, txtCountry.Text, txtPrimaryPhone.Text);
            }

            FacessoGeneric.InstallationFolder = FacessoPathSettings.InstallationFolder;
            FacessoGeneric.UpdateFolder = FacessoPathSettings.UpdateFolder;
            FacessoGeneric.UpdateUrl = FacessoPathSettings.UpdateUrl;
            FacessoGeneric.SharedFolder = FacessoPathSettings.SharedFolder;

            RegistryHelper.Register(true);

            MessageBox.Show(
                "Facesso ist nun für den Einsatz bereit." + "\r\n" +
                "Starten Sie das Programm 'Facesso' aus dem Startmenü und der Programmgruppe 'ActiveDevelop'." + "\r\n" + "\r\n" +
                "Danke, dass Sie sich für Facesso entschieden haben!",
                "Konfiguration abgeschlossen", MessageBoxButtons.OK, MessageBoxIcon.Information);

            throw new FacessoEndOfSetupException("Ende des Setups führte zu Ausnahme (kein kritischer Fehler).", null);
        }

        private void txtSS_Name_TextChanged(object sender, EventArgs e)
        {
            if (txtSubsidiaryName.Text != "" && txtStreet.Text != "" && txtZip.Text != "" &&
                txtCity.Text != "" && txtCountry.Text != "" && txtCountryCode.Text != "" && txtPrimaryPhone.Text != "")
            {
                myWizardController.AllowNextStep();
                return;
            }
            myWizardController.ForbidNextStep();
        }

        private void txtPasswordRepetition_TextChanged(object sender, EventArgs e)
        {
            if (txtPasswordRepetition.Text == txtPassword.Text && txtPassword.Text.Length > 5)
                myWizardController.AllowNextStep();
            else
                myWizardController.ForbidNextStep();
        }

        private void dcpSqlServer_DataBasesSelectedIndexChanged(object sender, EventArgs e)
        {
            myStepAfterSQLConnectionChoice = true;
            myWizardController.AllowNextStep();
        }

        private void dcpSqlServer_DataSourcesSelectedIndexChanged(object sender, EventArgs e)
        {
            myStepAfterSQLConnectionChoice = false;
            myWizardController.ForbidNextStep();
        }

        private bool InitializeDatabase(byte[] cryptedPassword, byte[] systemPassword, string subsidiaryName,
            string street, string zip, string city, string countryCode, string country, string primaryPhone)
        {
            var locSQLConnection = new SqlConnection(mySQLConnectionString);
            locSQLConnection.Open();
            using (locSQLConnection)
            {
                var locCmd = new SqlCommand("InitializeDatabase", locSQLConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@CryptedAdminPassword", SqlDbType.Binary).Value = cryptedPassword;
                locCmd.Parameters.Add("@CryptedSystemPassword", SqlDbType.Binary).Value = systemPassword;
                locCmd.Parameters.Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = subsidiaryName;
                locCmd.Parameters.Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = street;
                locCmd.Parameters.Add("@SubsidiaryZIP", SqlDbType.NVarChar, 10).Value = zip;
                locCmd.Parameters.Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = city;
                locCmd.Parameters.Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = countryCode;
                locCmd.Parameters.Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = country;
                locCmd.Parameters.Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = primaryPhone;
                locCmd.Parameters.Add("@CostCenterName", SqlDbType.NVarChar, 100).Value =
                    global::Facesso.My.Resources.Resources.CostCenter_Base_Name;
                locCmd.Parameters.Add("@CostCenterDescription", SqlDbType.Text).Value =
                    global::Facesso.My.Resources.Resources.CostCenter_Base_Description;
                locCmd.CommandTimeout = 10 * 60;
                locCmd.ExecuteNonQuery();
                return true;
            }
        }

        private bool IsDatabaseSetup()
        {
            var locConnection = new SqlConnection(mySQLConnectionString);
            locConnection.Open();
            using (locConnection)
            {
                var locCmd = new SqlCommand("IsDatabaseSetup", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                var locIsSetup = new SqlParameter("@IsSetup", SqlDbType.Bit);
                locIsSetup.Direction = ParameterDirection.Output;
                locCmd.Parameters.Add(locIsSetup);
                locCmd.ExecuteNonQuery();
                return Convert.ToBoolean(locCmd.Parameters["@IsSetup"].Value);
            }
        }

        private void btnTData_Click(object sender, EventArgs e)
        {
            txtCity.Text = "Musterstadt";
            txtStreet.Text = "Beispielstraße 23";
            txtCountry.Text = "Germany";
            txtCountryCode.Text = "D";
            txtSubsidiaryName.Text = "SampleCompany Ltd.";
            txtZip.Text = "59556";
            txtPrimaryPhone.Text = "+49 555 4554";
        }

        private void optNamedInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (optNamedInstance.Checked)
            {
                txtConnectionString.ReadOnly = false;
                btnPickConnection.Enabled = true;
            }
            else
            {
                txtConnectionString.ReadOnly = true;
                btnPickConnection.Enabled = false;
            }
        }

        private void btnPickConnection_Click(object sender, EventArgs e)
        {
            var locFrm = new ActiveDev.Data.SqlClient.ADDatabaseConnectionDialog();
            SqlConnectionStringBuilder locSqlConnBuilder = locFrm.GetConnectionBuilder();
            if (locSqlConnBuilder != null)
                txtConnectionString.Text = locSqlConnBuilder.ToString();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (Step3_ValidateSQLConnection())
                MessageBox.Show("Verbindung konnte erfolgreich aufgebaut und getestet werden!",
                    "Verbindungsinfo:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mtbSerialNo_TextChanged(object sender, EventArgs e)
        {
            var locLicense = new FacessoLicenseManager(new Guid(RegistryHelper.ProgramGUID),
                RegistryHelper.InstallationDate, RegistryHelper.LastRunDate,
                RegistryHelper.LastRegisteredDate, mtbSerialNo.Text);

            if (locLicense.IsSerialNoValid)
            {
                lblSerialNoValid.Text = "Die eingegebene Seriennummer ist gültig; eine Vollversion wird freigeschaltet.";
                SerialDialogTooltips.SetToolTip(lblSerialNoValid, locLicense.ToString());
                imgCheckSerialNo.Image = global::Facesso.My.Resources.Resources.Keyboard_Check;
            }
            else
            {
                lblSerialNoValid.Text = "Die eingegebene Seriennummer ist nicht gültig; eine Demo-Version wird - so noch möglich - freigeschaltet.";
                SerialDialogTooltips.SetToolTip(lblSerialNoValid, locLicense.ToString());
                imgCheckSerialNo.Image = global::Facesso.My.Resources.Resources.Keyboard_Error;
            }
        }
    }
}
