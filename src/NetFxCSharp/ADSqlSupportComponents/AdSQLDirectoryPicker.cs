using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public class ADSQLDirectoryPicker : TreeView
    {
        private string _connectionString;
        private Collection<DBDriveItem> _drives;
        private readonly ImageList _imageList;
        private string _extensionFilter;
        private bool _updateBlocked;
        private bool _updateOnUpdateUnblocked;

        public event System.EventHandler<ADFileTreeViewEventArgs> SelectedFileNodeChanged;

        public ADSQLDirectoryPicker() : base()
        {
            _imageList = new ImageList();
            _imageList.Images.Add(global::ActiveDev.Data.SqlClient.My.Resources.drive, Color.Magenta);
            _imageList.Images.Add(global::ActiveDev.Data.SqlClient.My.Resources.VSFolder_closed, Color.Magenta);
            _imageList.Images.Add(global::ActiveDev.Data.SqlClient.My.Resources.document, Color.Magenta);
            this.ImageList = _imageList;
            _extensionFilter = null;
        }

        public new void BeginUpdate()
        {
            base.BeginUpdate();
            _updateBlocked = true;
        }

        public new void EndUpdate()
        {
            base.EndUpdate();
            _updateBlocked = false;
            if (_updateOnUpdateUnblocked)
                RebuildRootList();
        }

        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                _connectionString = value;
                if (!_updateBlocked)
                    RebuildRootList();
                else
                    _updateOnUpdateUnblocked = true;
            }
        }

        public string ExtensionFilter
        {
            get => _extensionFilter;
            set
            {
                _extensionFilter = value;
                if (!_updateBlocked)
                    RebuildRootList();
                else
                    _updateOnUpdateUnblocked = true;
            }
        }

        private bool TestConnection()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var icon = MessageBoxIcon.Exclamation;
                try
                {
                    connection.Open();
                }
                catch (System.Exception ex)
                {
                    string msg = "Verbindungsherstellung war nicht möglich!" +
                        "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace;
                    icon = MessageBoxIcon.Error;
                    MessageBox.Show(msg, "Verbindungstest:", MessageBoxButtons.OK, icon);
                    return false;
                }
            }
            return true;
        }

        private void RebuildRootList()
        {
            this.Nodes.Clear();
            if (string.IsNullOrEmpty(_connectionString))
                return;

            if (TestConnection())
            {
                _drives = ADSqlDriveFoldersAndFilesListing.GetDrivenames(_connectionString);
                foreach (DBDriveItem item in _drives)
                {
                    TreeNode node = this.Nodes.Add(item.DriveLetter, item.DriveLetter + ":", 0, 0);
                    var dirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(_connectionString, item.DriveLetter + ":\\");
                    BuildSubnode(node, dirItems);
                }
            }
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            base.OnBeforeExpand(e);
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Nodes.Clear();
                var dirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(_connectionString, node.FullPath);
                BuildSubnode(node, dirItems);
            }
        }

        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);
            TreeNode node = e.Node;
            node.Nodes.Clear();
            var dirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(_connectionString, node.FullPath);
            BuildSubnode(node, dirItems);
        }

        private void BuildSubnode(TreeNode node, Collection<DBDirOrFileItem> dirItems)
        {
            if (dirItems != null)
            {
                foreach (DBDirOrFileItem item in dirItems)
                {
                    if (item.IsFile && !string.IsNullOrEmpty(ExtensionFilter))
                    {
                        var fileInfo = new FileInfo(item.Name);
                        if (fileInfo.Extension == ExtensionFilter || ExtensionFilter == ".*")
                            node.Nodes.Add(item.Name, item.Name, 2, 2);
                    }
                    else if (!item.IsFile)
                    {
                        node.Nodes.Add(item.Name, item.Name, 1, 1);
                    }
                }
            }
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            ADFileTreeViewEventArgs args;
            if (e.Node != null)
                args = new ADFileTreeViewEventArgs(e.Node, e.Action, (ADFileItemType)e.Node.ImageIndex);
            else
                args = new ADFileTreeViewEventArgs(e.Node, e.Action, ADFileItemType.None);
            OnSelectedFileNodeChanged(args);
        }

        protected virtual void OnSelectedFileNodeChanged(ADFileTreeViewEventArgs e)
        {
            SelectedFileNodeChanged?.Invoke(this, e);
        }
    }

    public class ADFileTreeViewEventArgs : TreeViewEventArgs
    {
        private ADFileItemType _fileItemType;

        public ADFileTreeViewEventArgs(TreeNode node, TreeViewAction action, ADFileItemType itemType)
            : base(node, action)
        {
            _fileItemType = itemType;
        }

        public ADFileItemType FileItemType
        {
            get => _fileItemType;
            set => _fileItemType = value;
        }
    }

    public enum ADFileItemType
    {
        Drive,
        Folder,
        File,
        None
    }
}
