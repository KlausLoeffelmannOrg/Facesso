using System.Windows.Forms;

namespace Facesso
{
    [System.CLSCompliant(false)]
    public partial class frmLogin : Form
    {
        private UserInfo myLoginInfo;

        public frmLogin()
        {
            InitializeComponent();
        }

        public UserInfo Login(SubsidiaryInfoCollection subsidiaries, int preselectSSID, LoginHistory locLoginHistory)
        {
            using (this)
            {
                int locCount = 0;
                int locPreselectIndex = 0;
                foreach (SubsidiaryInfo locSubsidiary in subsidiaries)
                {
                    if (preselectSSID > 0)
                    {
                        if (locSubsidiary.IDSubsidiary == preselectSSID)
                            locPreselectIndex = locCount;
                    }

                    cmbSubsidiary.Items.Add(locSubsidiary);
                    locCount++;
                }
                if (cmbSubsidiary.Items.Count > 0)
                    cmbSubsidiary.SelectedIndex = locPreselectIndex;

                foreach (string locString in locLoginHistory)
                    cmbUsernames.Items.Add(locString);

                cmbUsernames.Text = locLoginHistory.LastLoginName;
                ShowDialog();

                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                    return myLoginInfo;
                else
                    return null;
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            myLoginInfo = new UserInfo(
                ((SubsidiaryInfo)cmbSubsidiary.SelectedItem).IDSubsidiary,
                cmbUsernames.Text,
                txtPassword.Text,
                FacessoGeneric.SQLConnectionString);

            if (!myLoginInfo.Authenticated)
            {
                MessageBox.Show(myLoginInfo.LoggedInFailedReason, "Fehler bei Login:",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Hide();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Hide();
        }

        private void txtPassword_TextChanged(object sender, System.EventArgs e)
        {
            AcceptButton = txtPassword.Text != "" ? (IButtonControl)btnOK : null;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            Visible = true;
            Application.DoEvents();
            if (cmbUsernames.Text == "")
                cmbUsernames.Focus();
            else
                txtPassword.Focus();
        }

        private void frmLogin_Load(object sender, System.EventArgs e) { }
    }
}
