using System.Data.SqlClient;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADSqlInstanceConnectionDialog : Form
    {
        protected SqlConnectionStringBuilder myConnectionBuilder;

        public System.Data.SqlClient.SqlConnectionStringBuilder GetConnectionBuilder()
        {
            myConnectionBuilder = null;
            this.ShowDialog();
            if (this.DialogResult == DialogResult.OK)
                return myConnectionBuilder;
            else
                return null;
        }

        public System.Data.SqlClient.SqlConnectionStringBuilder GetConnectionBuilder(string dialogTitel)
        {
            this.Text = dialogTitel;
            return GetConnectionBuilder();
        }

        protected virtual System.Data.SqlClient.SqlConnectionStringBuilder BuildConnectionBuilder()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = SqlServerConnector.Text;
            if (SqlServerConnector.CredentialMethod == SqlCredentialMethods.WindowsIntegratedSecurity)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = SqlServerConnector.CredentialParameters.UserID;
                builder.Password = SqlServerConnector.CredentialParameters.Password;
            }
            return builder;
        }

        protected virtual void OnParametersChanged()
        {
            if (SqlServerConnector.Text == "")
            {
                myConnectionBuilder = null;
                return;
            }
            myConnectionBuilder = BuildConnectionBuilder();
            txtLoginString.Text = myConnectionBuilder.ToString();
        }

        private void SqlServerConnector_ParametersChanges(object sender, System.EventArgs e)
        {
            OnParametersChanged();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTestConnection_Click(object sender, System.EventArgs e)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(myConnectionBuilder.ToString()))
            {
                string msg = "Die Verbindung konnte erfolgreich hergestellt werden!";
                var icon = MessageBoxIcon.Exclamation;
                try
                {
                    connection.Open();
                }
                catch (System.Exception ex)
                {
                    msg = "Verbindungsherstellung war nicht möglich!" +
                        "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace;
                    icon = MessageBoxIcon.Error;
                }
                MessageBox.Show(msg, "Verbindungstest:", MessageBoxButtons.OK, icon);
            }
        }
    }
}
