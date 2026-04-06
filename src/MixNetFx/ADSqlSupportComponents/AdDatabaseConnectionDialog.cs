using System.Data.SqlClient;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADDatabaseConnectionDialog : ADSqlInstanceConnectionDialog
    {
        private bool _thisControlChangedParameters;

        public string Title
        {
            get => this.Text;
            set => this.Text = value;
        }

        protected override void OnParametersChanged()
        {
            base.OnParametersChanged();
            if (!_thisControlChangedParameters)
            {
                SqlDatabaseConnector.CredentialMethod = SqlServerConnector.CredentialMethod;
                SqlDatabaseConnector.CredentialParameters = SqlServerConnector.CredentialParameters;
                SqlDatabaseConnector.SqlInstance = SqlServerConnector.SqlInstance;
            }
            _thisControlChangedParameters = false;
        }

        private void SqlDatabaseConnector_ParametersChanged(object sender, System.EventArgs e)
        {
            _thisControlChangedParameters = true;
            OnParametersChanged();
        }

        protected override SqlConnectionStringBuilder BuildConnectionBuilder()
        {
            SqlConnectionStringBuilder builder = base.BuildConnectionBuilder();
            if (SqlDatabaseConnector.DatabaseSource == SqlDatabaseSource.FromFile)
            {
                builder.AttachDBFilename = SqlDatabaseConnector.FileToAttach;
                if (SqlDatabaseConnector.LogicalDatabasename != "")
                    builder.InitialCatalog = SqlDatabaseConnector.LogicalDatabasename;
            }
            else
            {
                if (SqlDatabaseConnector.Text != "")
                    builder.InitialCatalog = SqlDatabaseConnector.Text;
            }
            return builder;
        }
    }
}
