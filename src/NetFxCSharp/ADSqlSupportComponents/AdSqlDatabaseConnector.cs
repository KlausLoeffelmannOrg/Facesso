using System;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADSqlDatabaseConnector : UserControl
    {
        public event EventHandler ParametersChanged;

        public ADSqlDatabaseConnector()
        {
            InitializeComponent();
            AssignCheckedStates();
        }

        private void optUseDatabasesOfInstance_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckedStates();
            OnParametersChanged();
        }

        private void AssignCheckedStates()
        {
            lblDatabase.Enabled = optUseDatabasesOfInstance.Checked;
            SqlDatabases.Enabled = optUseDatabasesOfInstance.Checked;
            lblFileToAttach.Enabled = optAttachDatabase.Checked;
            txtFileToAttach.Enabled = optAttachDatabase.Checked;
            lblLogicalName.Enabled = optAttachDatabase.Checked;
            txtLogicalDatabaseName.Enabled = optAttachDatabase.Checked;
        }

        public SqlCredentialMethods CredentialMethod
        {
            get => SqlDatabases.CredentialMethod;
            set => SqlDatabases.CredentialMethod = value;
        }

        public SqlMixedModeCredentialParameters CredentialParameters
        {
            get => SqlDatabases.CredentialParameters;
            set => SqlDatabases.CredentialParameters = value;
        }

        public SqlInstanceItem SqlInstance
        {
            get => SqlDatabases.SqlInstance;
            set => SqlDatabases.SqlInstance = value;
        }

        private void btnFileSelector_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Filter = "SQL Server-Dateien (*.mdf)|*.mdf|Alle Dateien (*.*)|*.*";
                ofd.Title = "SQL-Server-Datenbank öffnen";
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtFileToAttach.Text = ofd.FileName;
            }
        }

        protected virtual void OnParametersChanged()
        {
            ParametersChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SqlParameters_TextChanged(object sender, EventArgs e)
        {
            OnParametersChanged();
        }

        public override string Text
        {
            get => SqlDatabases.Text;
            set => SqlDatabases.Text = value;
        }

        public SqlDatabaseSource DatabaseSource
        {
            get
            {
                if (optAttachDatabase.Checked)
                    return SqlDatabaseSource.FromFile;
                else
                    return SqlDatabaseSource.FromSqlServerInstance;
            }
            set
            {
                if (value == SqlDatabaseSource.FromFile)
                    optAttachDatabase.Checked = true;
                else
                    optUseDatabasesOfInstance.Checked = true;
            }
        }

        public string FileToAttach
        {
            get => txtFileToAttach.Text;
            set => txtFileToAttach.Text = value;
        }

        public string LogicalDatabasename
        {
            get => txtLogicalDatabaseName.Text;
            set => txtLogicalDatabaseName.Text = value;
        }
    }
}
