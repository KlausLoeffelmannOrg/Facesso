using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public class ADSqlDatabasesInfoComboBox : ADSqlInfoComboBase
    {
        private SqlDatabaseItems _sqlDatabases;
        private SqlInstanceItem _sqlInstance;
        private SqlCredentialMethods _sqlCredentialMethod;
        private SqlMixedModeCredentialParameters _sqlCredentialParameters;

        protected override void PopulateItemsInternal()
        {
            DataTable sqlDatabasesDataTable = null;

            base.PopulateItemsInternal();

            if (Connection == null)
                return;

            if (_sqlDatabases == null)
            {
                try
                {
                    using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
                    {
                        sqlConnection.ConnectionString = Connection.ToString();
                        sqlConnection.Open();
                        sqlDatabasesDataTable = sqlConnection.GetSchema("Databases");
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bei der Verbindungsherstellung zur ausgewählten" + "\r\n" +
                                    "SQL-Server-Instanz trat ein Fehler auf:" + "\r\n\r\n" +
                                    ex.Message, "Fehler bei Verbindungsherstellung:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (sqlDatabasesDataTable != null
                    && sqlDatabasesDataTable.Rows.Count > 0
                    && this.Items.Count == 0)
            {
                _sqlDatabases = new SqlDatabaseItems();
                foreach (DataRow row in sqlDatabasesDataTable.Rows)
                {
                    var db = new SqlDatabaseItem(
                        (string)row["database_name"],
                        (int)row["dbid"],
                        Convert.ToDateTime(row["create_date"]));
                    this.Items.Add(db);
                    _sqlDatabases.Add(db);
                }
            }
        }

        public SqlConnectionStringBuilder Connection
        {
            get
            {
                if (SqlInstance == null)
                    throw new ADSqlConnectionBuilderException("Connection-String kann ohne Sql-Server-Instanz nicht erstellt werden. Setzen Sie zunächst die SqlInstance-Eigenschaft. Verwenden Sie im Bedarfsfall die statische Funktion 'SqlInstanceFromString' dieser Klasse.");

                if (CredentialMethod == SqlCredentialMethods.MixedMode && CredentialParameters == null)
                    throw new ADSqlConnectionBuilderException("Connection-String benötigt bei MixedMode-Authentifizierung ein instanziertes SqlMixedModeCredentialParameters-Objekt.");

                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = SqlInstance.ToString();
                if (CredentialMethod == SqlCredentialMethods.WindowsIntegratedSecurity)
                {
                    builder.IntegratedSecurity = true;
                }
                else
                {
                    builder.IntegratedSecurity = false;
                    builder.UserID = CredentialParameters.UserID;
                    builder.Password = CredentialParameters.Password;
                }
                return builder;
            }
        }

        public SqlCredentialMethods CredentialMethod
        {
            get => _sqlCredentialMethod;
            set
            {
                _sqlCredentialMethod = value;
                ResetDatabases();
            }
        }

        public SqlMixedModeCredentialParameters CredentialParameters
        {
            get => _sqlCredentialParameters;
            set
            {
                _sqlCredentialParameters = value;
                ResetDatabases();
            }
        }

        public SqlInstanceItem SqlInstance
        {
            get => _sqlInstance;
            set
            {
                _sqlInstance = value;
                ResetDatabases();
            }
        }

        public static SqlInstanceItem SqlInstanceFromString(string instancePath)
        {
            if (instancePath == null)
                return null;

            string s = instancePath.Replace("\\\\", "").Replace("//", "").Replace("/", "\\");
            if (s.IndexOf('\\') > -1)
            {
                string[] arr = s.Split('\\');
                return new SqlInstanceItem(arr[0], arr[1], false, "Unknown");
            }
            else
            {
                return new SqlInstanceItem(s, null, false, "Unknown");
            }
        }

        public void ResetDatabases()
        {
            this.Items.Clear();
            this.Text = "";
            _sqlDatabases = null;
        }
    }

    public class SqlDatabaseItems : Collection<SqlDatabaseItem>
    {
        public SqlDatabaseItems() : base()
        {
        }

        public SqlDatabaseItems(string connString)
        {
            DataTable dataTable;
            using (var connection = new System.Data.SqlClient.SqlConnection())
            {
                connection.ConnectionString = connString;
                connection.Open();
                dataTable = connection.GetSchema("Databases");
                connection.Close();
            }

            if (dataTable != null && dataTable.Rows.Count > 0 && this.Items.Count == 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.Items.Add(new SqlDatabaseItem(
                        (string)row["database_name"],
                        (int)row["dbid"],
                        Convert.ToDateTime(row["create_date"])));
                }
            }
        }
    }

    public class SqlDatabaseItem
    {
        private string _database;
        private int _dbId;
        private DateTime _createDate;

        internal SqlDatabaseItem(string databaseName, int dbId, DateTime createDate)
        {
            _database = databaseName;
            _dbId = dbId;
            _createDate = createDate;
        }

        public string DatabaseName => _database;
        public int DbId => _dbId;
        public DateTime CreateDate => _createDate;

        public override string ToString() => DatabaseName;
    }
}
