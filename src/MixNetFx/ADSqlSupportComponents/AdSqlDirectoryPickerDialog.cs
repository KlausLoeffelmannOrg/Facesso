using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADSqlDirectoryPickerDialog : Form
    {
        private string _sqlPathFilename;

        public DialogResult ShowDialog(string serverConnection, string extensionFilter)
        {
            DirectoryPicker.BeginUpdate();
            DirectoryPicker.ConnectionString = serverConnection;
            DirectoryPicker.ExtensionFilter = extensionFilter;
            DirectoryPicker.EndUpdate();
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(string serverConnection)
        {
            DirectoryPicker.BeginUpdate();
            DirectoryPicker.ConnectionString = serverConnection;
            DirectoryPicker.ExtensionFilter = null;
            DirectoryPicker.EndUpdate();
            return this.ShowDialog();
        }

        private void DirectoryPicker_SelectedFileNodeChanged(object sender, ADFileTreeViewEventArgs e)
        {
            txtPath.Text = e.Node.FullPath;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            _sqlPathFilename = txtPath.Text;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _sqlPathFilename = null;
        }

        public string SqlPathFilename
        {
            get => _sqlPathFilename;
            set => _sqlPathFilename = value;
        }
    }
}
