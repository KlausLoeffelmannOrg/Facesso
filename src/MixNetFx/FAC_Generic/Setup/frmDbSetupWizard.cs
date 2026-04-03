using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ActiveDev;

namespace Facesso
{
    public partial class frmDbSetupWizard : Form
    {
        private string myOleDBConnectionString;
        private string mySQLConnectionString;
        private int mySubsidiaryID = 1;
        private bool myStepAfterSQLConnectionChoice;
        private bool myDatabaseAlreadySetup;

        private ADWizardController myWizardController;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            myWizardController = new ADWizardController(btnBack, btnNext, btnCancel, tcWizard);
            myWizardController.Initialize();
            myWizardController.Cancel += myWizardController_Cancel;
            myWizardController.StepChanged += myWizardController_StepChanged;
            myWizardController.Finished += myWizardController_Finished;
            mySQLConnectionString = RegistryHelper.ConnectionString;
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
                    e.Cancel = !Step4_CompanyData();
                }
                else if (e.NewStepNo == 2)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 3)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
                else if (e.NewStepNo == 4)
                {
                    e.Cancel = false;
                    e.NextStepAllowed = true;
                }
            }
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

            MessageBox.Show(
                "Die neue Facesso-Datenbank ist nun für den Einsatz bereit." + "\r\n" +
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

        private bool InitializeDatabase(byte[] CryptedPassword, byte[] SystemPassword, string SubsidiaryName,
            string Street, string Zip, string City, string CountryCode, string Country, string PrimaryPhone)
        {
            var locSQLConnection = new SqlConnection(mySQLConnectionString);
            locSQLConnection.Open();
            using (locSQLConnection)
            {
                var locCmd = new SqlCommand("InitializeDatabase", locSQLConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@CryptedAdminPassword", SqlDbType.Binary).Value = CryptedPassword;
                locCmd.Parameters.Add("@CryptedSystemPassword", SqlDbType.Binary).Value = SystemPassword;
                locCmd.Parameters.Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = SubsidiaryName;
                locCmd.Parameters.Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = Street;
                locCmd.Parameters.Add("@SubsidiaryZIP", SqlDbType.NVarChar, 10).Value = Zip;
                locCmd.Parameters.Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = City;
                locCmd.Parameters.Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = CountryCode;
                locCmd.Parameters.Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = Country;
                locCmd.Parameters.Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = PrimaryPhone;
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
    }
}
