using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;

namespace ActiveDev.Data.SqlClient
{
    public class ADSqlInstanceInfoComboBox : ADSqlInfoComboBase
    {
        private SqlInstanceItems _sqlInstances;
        private readonly SqlInstanceItem _sqlInstance;

        public ADSqlInstanceInfoComboBox() : base()
        {
            QueryInfoOnDropDown = true;
        }

        protected override void PopulateItemsInternal()
        {
            DataTable sqlInstancesDataTable = null;

            base.PopulateItemsInternal();

            if (_sqlInstances == null)
                sqlInstancesDataTable = GetSqlServerInstances();

            if (sqlInstancesDataTable != null && sqlInstancesDataTable.Rows.Count > 0)
            {
                _sqlInstances = new SqlInstanceItems();
                foreach (DataRow row in sqlInstancesDataTable.Rows)
                {
                    var instance = new SqlInstanceItem(
                        row["ServerName"] is DBNull ? null : (string)row["ServerName"],
                        row["InstanceName"] is DBNull ? null : (string)row["InstanceName"],
                        row["IsClustered"].ToString() != "No",
                        row["Version"] is DBNull ? null : (string)row["Version"]);
                    this.Items.Add(instance);
                    _sqlInstances.Add(instance);
                }
            }
        }

        private DataTable GetSqlServerInstances()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbDataSourceEnumerator enumerator = factory.CreateDataSourceEnumerator();
            return enumerator.GetDataSources();
        }

        public SqlInstanceItem SqlInstance => ADSqlDatabasesInfoComboBox.SqlInstanceFromString(this.Text);

        public SqlInstanceItem SelectedSqlInstance
        {
            get
            {
                if (this.SelectedIndex == -1)
                    return null;
                return (SqlInstanceItem)this.SelectedItem;
            }
        }
    }

    public class SqlInstanceItems : Collection<SqlInstanceItem>
    {
    }

    public class SqlInstanceItem
    {
        private readonly string _serverName;
        private readonly string _instanceName;
        private readonly bool _isClustered;
        private readonly string _version;

        internal SqlInstanceItem(string serverName, string instanceName, bool isClustered, string version)
        {
            _serverName = serverName;
            _instanceName = instanceName;
            _isClustered = isClustered;
            _version = version;
        }

        public string ServerName => _serverName;
        public string InstanceName => _instanceName;
        public bool IsClustered => _isClustered;
        public string Version => _version;

        public override string ToString()
        {
            string result = "";
            if (_serverName != null)
                result += _serverName;
            if (_instanceName != null)
                result += "\\" + _instanceName;
            return result;
        }
    }
}
