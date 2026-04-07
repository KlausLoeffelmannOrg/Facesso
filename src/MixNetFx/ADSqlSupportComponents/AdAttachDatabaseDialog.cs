using System.Data.SqlClient;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADAttachDatabaseDialog : Form
    {
        private string _connectionString;
        private string _currentlySelectedFile;

        public ADAttachDatabaseDialog()
        {
            InitializeComponent();
        }

        public string GetSqlDatabaseFile()
        {
            this.ShowDialog();
            return _currentlySelectedFile;
        }

        public string GetSqlDatabaseFile(string connectionString)
        {
            DBDirectoryPicker.Location = new System.Drawing.Point(DBDirectoryPicker.Location.X, txtConnectionString.Location.Y);
            txtConnectionString.Text = connectionString;
            DBDirectoryPicker.ConnectionString = connectionString;
            this.ShowDialog();
            return _currentlySelectedFile;
        }

        private void btnGetConnectionString_Click(object sender, System.EventArgs e)
        {
            var frm = new ADSqlInstanceConnectionDialog();
            SqlConnectionStringBuilder builder = frm.GetConnectionBuilder();
            if (builder != null)
            {
                _connectionString = builder.ToString();
                txtConnectionString.Text = _connectionString;
                DBDirectoryPicker.ConnectionString = txtConnectionString.Text;
            }
        }

        private void ADAttachDatabaseDialog_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConnectionString.Text))
                DBDirectoryPicker.ConnectionString = txtConnectionString.Text;
        }

        private void DBDirectoryPicker_SelectedFileNodeChanged(object sender, ADFileTreeViewEventArgs e)
        {
            if (e.FileItemType == ADFileItemType.File)
            {
                btnOK.Enabled = true;
                _currentlySelectedFile = e.Node.FullPath;
            }
            else
            {
                btnOK.Enabled = false;
                _currentlySelectedFile = null;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _currentlySelectedFile = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
