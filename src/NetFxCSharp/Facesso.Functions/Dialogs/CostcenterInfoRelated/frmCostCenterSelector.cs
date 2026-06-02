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
    public partial class frmCostCenterSelector
    {
        public CostcenterInfo HandleDialog(CostcenterInfoItems ccic)
        {
            using (this)
            {
                lstCostCenter.DataSource = ccic;
                lstCostCenter.DisplayMember = "ListItemText";
                this.ShowDialog();
                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    return ((CostcenterInfo)lstCostCenter.SelectedItem);
                }
                else
                {
                    return null;
                }
            }

            return default(CostcenterInfo);
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            if (lstCostCenter.SelectedIndex == -1)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public frmCostCenterSelector()
        {
            InitializeComponent();
        }
    }
}