using System.Windows.Forms;

namespace Facesso
{
    public partial class ucFacessoPathSettings : UserControl
    {
        public string InstallationFolder
        {
            get { return txtInstallationDirectory.Text; }
            set { txtInstallationDirectory.Text = value; }
        }

        public string UpdateFolder
        {
            get { return txtUpdateDirectory.Text; }
            set { txtUpdateDirectory.Text = value; }
        }

        public string UpdateUrl
        {
            get { return txtUpdateUrl.Text; }
            set { txtUpdateUrl.Text = value; }
        }

        public string SharedFolder
        {
            get { return txtSharedFolder.Text; }
            set { txtSharedFolder.Text = value; }
        }

        public string GetPath(string dialogTitel)
        {
            var locFB = new FolderBrowserDialog();
            locFB.Description = dialogTitel;
            DialogResult locDR = locFB.ShowDialog();
            if (locDR == System.Windows.Forms.DialogResult.OK)
                return locFB.SelectedPath;
            else
            {
                DialogResult locDr2 = MessageBox.Show("Soll der Pfad zurückgesetzt werden?",
                    "Pfad zurücksetzen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (locDr2 == DialogResult.Yes)
                    return "";
                return null;
            }
        }

        private void btnChooseUpdateDirectory_Click(object sender, System.EventArgs e)
        {
            string locPath = GetPath("Wählen Sie das Verzeichnis, in dem Facesso-Updates zentral abgelegt werden sollen.");
            if (locPath == null)
                return;
            txtUpdateDirectory.Text = locPath;
        }

        private void btnChooseSharedFolder_Click(object sender, System.EventArgs e)
        {
            string locPath = GetPath("Wählen Sie das Verzeichnis, in dem verteilte Daten wie beispielsweise Schnittstellen-Definitionen abgelegt werden sollen.");
            if (locPath == null)
                return;
            txtSharedFolder.Text = locPath;
        }
    }
}
