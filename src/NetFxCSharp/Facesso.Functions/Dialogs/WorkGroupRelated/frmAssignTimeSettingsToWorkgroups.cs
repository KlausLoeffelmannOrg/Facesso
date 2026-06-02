using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmAssignTimeSettingsToWorkgroups
    {
        private TimeSettingDetails myTimeSettings;
        public void AssignToSelected(TimeSettingDetails timeSettings)
        {
            myTimeSettings = timeSettings;
            wglWorkGroups.WorkGroupInfoItems = new WorkGroupInfoItems(true);
            this.ShowDialog();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            foreach (WorkGroupInfo locWorkGroup in wglWorkGroups.SelectedWorkGroups)
            {
                locWorkGroup.TimeSettingDetails = myTimeSettings;
                SPAccess.GetInstance().WorkGroups_Edit(locWorkGroup, FacessoGeneric.LoginInfo.IDUser);
            }

            MessageBox.Show("Die Produktiv-Site-Rahmenzeiten wurden ge�ndert!", "Erfolgreich:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public frmAssignTimeSettingsToWorkgroups()
        {
            InitializeComponent();
        }
    }
}