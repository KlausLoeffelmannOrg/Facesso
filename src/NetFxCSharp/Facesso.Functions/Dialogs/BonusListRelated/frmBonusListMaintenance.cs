using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmBonuslistMaintenance
    {
        private CostcenterInfo myBaseCostcenter;
        private bool myIsBeingBuild;
        internal void HandleDialog()
        {
            using (this)
            {
                myBaseCostcenter = SPAccess.GetInstance().GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary);
                this.ShowDialog();
            }
        }

        private void frmBonuslistMaintenance_Load(System.Object sender, System.EventArgs e)
        {
            RebuildCostcenterList();
        }

        private void lstCostCenter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            RebuildTable(((CostcenterInfo)lstCostCenter.SelectedItem));
        }

        private void RebuildTable(CostcenterInfo cci)
        {
            BonusListItems locBlis = SPAccess.GetInstance().BonusList_GetBonusListItems(cci.IDSubsidiary, cci.IDCostCenter);
            myIsBeingBuild = true;
            dgvWageTable.AutoGenerateColumns = true;
            dgvWageTable.SuspendLayout();
            dgvWageTable.DataSource = locBlis;
            {
                var __with0 = dgvWageTable.Columns;
                __with0.Remove(__with0["IDBonusLists"]);
                __with0.Remove(__with0["IDBonusList"]);
                __with0.Remove(__with0["IDSubsidiary"]);
                __with0.Remove(__with0["DegreeOfTime"]);
                __with0.Remove(__with0["DegreeOfTimeAligned"]);
                __with0.Remove(__with0["CostCenterInfo"]);
                {
                    var __with1 = __with0["DegreeOfTimeAlignedText"];
                    __with1.DisplayIndex = 0;
                    __with1.DefaultCellStyle.Format = cci.IncentiveFormatString;
                    __with1.HeaderText = cci.IncentiveIndicatorSynonym;
                    __with1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    __with1.ReadOnly = true;
                }

                {
                    var __with2 = __with0["Percentage"];
                    __with2.DisplayIndex = 1;
                    __with2.DefaultCellStyle.Format = "#,##0.##";
                    __with2.HeaderText = cci.IncentiveWageSynonym + " (% Aufschlag)";
                    __with2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    __with2.ReadOnly = false;
                }

                {
                    var __with3 = __with0["AbsoluteValue"];
                    __with3.DisplayIndex = 2;
                    __with3.DefaultCellStyle.Format = "#,##0.00";
                    __with3.HeaderText = cci.IncentiveWageSynonym + " (" + cci.CurrencyToken + " Fixbetrag)";
                    __with3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    __with3.ReadOnly = false;
                }
            }

            dgvWageTable.ResumeLayout();
            myIsBeingBuild = false;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void NewCostcenterTable_Click(System.Object sender, System.EventArgs e)
        {
            frmCostCenterSelector locCsel = new frmCostCenterSelector();
            //TODO: Position correctly!
            //locCsel.Location = New Point(NewCostcenterTable.Location.X, NewCostcenterTable.Location.Y + _
            //                             NewCostcenterTable.Size.Height)
            //locCsel.Size = New Size(NewCostcenterTable.Size.Width, locCsel.Size.Height)
            CostcenterInfoItems locCcic = SPAccess.GetInstance().BonusList_GetCostCenterInfoCollection(FacessoGeneric.LoginInfo.IDSubsidiary, true);
            CostcenterInfo locCci = locCsel.HandleDialog(locCcic);
            if (locCci == null)
            {
                return;
            }

            SPAccess.GetInstance().BonusList_FromBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary, SPAccess.GetInstance().GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter, locCci.IDCostCenter, FacessoGeneric.LoginInfo.IDUser);
            RebuildCostcenterList();
        }

        private void RebuildCostcenterList()
        {
            //Kostenstellenliste f�llen
            CostcenterInfoItems locCCs = SPAccess.GetInstance().BonusList_GetCostCenterInfoCollection(FacessoGeneric.LoginInfo.IDSubsidiary, false);
            if (locCCs == null || locCCs.Count == 0)
            {
                this.Visible = true;
                Application.DoEvents();
                DialogResult dr = MessageBox.Show("Die Lohnliste der Systemkostenstelle wurde gel�scht." + System.Environment.NewLine + "Soll eine Standardtabelle wiederhergestellt werden, die Sie anschlie�end nachbearbeiten k�nnen?", "Lohnliste nicht vorhanden!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    SPAccess.GetInstance().BonusList_CreateBaseList(FacessoGeneric.LoginInfo.IDSubsidiary, SPAccess.GetInstance().GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter, FacessoGeneric.LoginInfo.IDUser);
                }

                locCCs = SPAccess.GetInstance().BonusList_GetCostCenterInfoCollection(FacessoGeneric.LoginInfo.IDSubsidiary, false);
            }

            lstCostCenter.DataSource = locCCs;
            lstCostCenter.DisplayMember = "ListItemText";
        }

        private void btnDeleteCostCenterTable_Click(System.Object sender, System.EventArgs e)
        {
            if (lstCostCenter.SelectedIndex == -1)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CostcenterInfo locCci = ((CostcenterInfo)lstCostCenter.SelectedItem);
            SPAccess.GetInstance().BonusList_DeleteList(FacessoGeneric.LoginInfo.IDSubsidiary, locCci.IDCostCenter, FacessoGeneric.LoginInfo.IDUser);
            RebuildCostcenterList();
        }

        private void dgvWageTable_DataError(System.Object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show(Facesso.Functions.My.Resources.BonusListMaintenance_InputValueFormatError_MB_Body, Facesso.Functions.My.Resources.BonusListMaintenance_InputValueFormatError_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvWageTable_CellValueChanged(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (myIsBeingBuild)
            {
                return;
            }

            //Neue Zeile direkt abspeichern
            int locCurrentRow = e.RowIndex;
            SPAccess.GetInstance().BonusList_ReplaceEntry(((BonusListItem)dgvWageTable.Rows[locCurrentRow].DataBoundItem), FacessoGeneric.LoginInfo.IDUser);
        }

        public frmBonuslistMaintenance()
        {
            this.Load += frmBonuslistMaintenance_Load;
            InitializeComponent();
        }
    }
}