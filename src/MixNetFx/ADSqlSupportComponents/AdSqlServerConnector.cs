using System;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class AdSqlServerConnector : UserControl
    {
        private string _oldInstance;
        private bool _skipEvent;

        public event EventHandler ParametersChanged;

        public AdSqlServerConnector()
        {
            InitializeComponent();
            AssignCheckedStates();
        }

        private void chkUseSXDefaultInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (_skipEvent)
            {
                _skipEvent = false;
                return;
            }

            _skipEvent = true;
            if (chkUseSXDefaultInstance.Checked)
            {
                _oldInstance = InstanceCombo.Text;
                if (InstanceCombo.Text == "")
                {
                    InstanceCombo.Text = ".\\SQLEXPRESS";
                }
                else
                {
                    if (InstanceCombo.Text.IndexOfAny(new char[] { '\\', '/' }) == -1)
                    {
                        InstanceCombo.Text += "\\SQLEXPRESS";
                    }
                    else
                    {
                        string[] arr = InstanceCombo.Text.Split(new char[] { '\\', '/' });
                        InstanceCombo.Text = arr[0] + "\\SQLEXPRESS";
                    }
                }
            }
            else
            {
                if (InstanceCombo.Text != _oldInstance)
                    InstanceCombo.Text = _oldInstance;
                else
                    _skipEvent = false;
            }
            OnParametersChanged();
        }

        private void optUseMixedMode_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckedStates();
            OnParametersChanged();
        }

        protected void OnParametersChanged()
        {
            ParametersChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AssignCheckedStates()
        {
            lblPassword.Enabled = optUseMixedMode.Checked;
            lblUserID.Enabled = optUseMixedMode.Checked;
            txtPassword.Enabled = optUseMixedMode.Checked;
            txtUserID.Enabled = optUseMixedMode.Checked;
        }

        private void InstanceCombo_TextChanged(object sender, EventArgs e)
        {
            if (_skipEvent)
            {
                _skipEvent = false;
                return;
            }

            _oldInstance = InstanceCombo.Text;
            chkUseSXDefaultInstance.Checked = false;
            OnParametersChanged();
        }

        public SqlInstanceItem SqlInstance => InstanceCombo.SqlInstance;

        public override string Text
        {
            get => InstanceCombo.Text;
            set => InstanceCombo.Text = base.Text;
        }

        public SqlCredentialMethods CredentialMethod
        {
            get
            {
                if (optUseIntegratedSecurity.Checked)
                    return SqlCredentialMethods.WindowsIntegratedSecurity;
                else
                    return SqlCredentialMethods.MixedMode;
            }
            set
            {
                if (value == SqlCredentialMethods.WindowsIntegratedSecurity)
                    optUseIntegratedSecurity.Checked = true;
                else
                    optUseMixedMode.Checked = true;
            }
        }

        public SqlMixedModeCredentialParameters CredentialParameters
        {
            get => new SqlMixedModeCredentialParameters(txtUserID.Text, txtPassword.Text);
            set
            {
                if (value == null)
                {
                    txtPassword.Text = "";
                    txtUserID.Text = "";
                }
                else
                {
                    txtPassword.Text = value.Password;
                    txtUserID.Text = value.UserID;
                }
            }
        }

        private void txtCredential_TextChanged(object sender, EventArgs e)
        {
            OnParametersChanged();
        }
    }
}
