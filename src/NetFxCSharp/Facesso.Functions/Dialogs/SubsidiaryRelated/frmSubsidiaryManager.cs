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
    internal partial class frmSubsidiaryManager
    {
        public void HandleDialog()
        {
            arvSubsidiaries.List = FacessoGeneric.Subsidiaries;
            this.ShowDialog();
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmSubsidiaryInfoAdd locFh = FunctionHandler<GetFrmSubsidiaryInfoAdd>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            InfoItemMaintenanceDialogResult locDR = locFh.ShowDialog();
            if (locDR.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FacessoGeneric.RebuildSubsidiaries();
                arvSubsidiaries.List = FacessoGeneric.Subsidiaries;
            }
        }

        private void btnEdit_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmSubsidiaryInfoEdit locFH = FunctionHandler<GetFrmSubsidiaryInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (this.arvSubsidiaries.SelectedItems == null || arvSubsidiaries.SelectedItems.Count == 0)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Body, Facesso.Functions.My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InfoItemMaintenanceDialogResult locDR = locFH.ShowDialog(((SubsidiaryInfo)this.arvSubsidiaries.SelectedItems[0].Tag));
            if (locDR.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FacessoGeneric.RebuildSubsidiaries();
                arvSubsidiaries.List = FacessoGeneric.Subsidiaries;
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (this.arvSubsidiaries.SelectedItems == null || arvSubsidiaries.SelectedItems.Count == 0)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Body, Facesso.Functions.My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (((SubsidiaryInfo)arvSubsidiaries.SelectedItems[0].Tag).IDSubsidiary == 1)
            {
                MessageBox.Show("Sie k�nnen die Haupt-Subsidiarit�t nicht l�schen!", "L�schen nicht m�glich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (((SubsidiaryInfo)arvSubsidiaries.SelectedItems[0].Tag).IDSubsidiary == FacessoGeneric.LoginInfo.IDSubsidiary)
            {
                MessageBox.Show("Sie k�nnen die Subsidiarit�t nicht l�schen, wenn Sie sich unter dieser angemeldet haben!", "L�schen nicht m�glich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult locDR = MessageBox.Show("Sind Sie sicher, die ausgew�hlte Subsidiarit�t mit ALLEN DATEN L�SCHEN zu wollen?", "SUBSIDIARIT�T L�SCHEN?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (locDR == System.Windows.Forms.DialogResult.Yes)
            {
                SPAccess.GetInstance().Subsidiaries_Delete(((SubsidiaryInfo)arvSubsidiaries.SelectedItems[0].Tag), FacessoGeneric.LoginInfo);
                FacessoGeneric.RebuildSubsidiaries();
                arvSubsidiaries.List = FacessoGeneric.Subsidiaries;
            }
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public frmSubsidiaryManager()
        {
            InitializeComponent();
        }
    }
}