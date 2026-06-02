using ActiveDev;
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
    public partial class frmProductionAmountAnalysis
    {
        private WorkgroupsProductionDataAmounts myCurrentProdAmounts;
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            lvwWorkgroups.WorkGroupInfoItems = new WorkGroupInfoItems(true);
            lvwCostCenter.AutoGroup = false;
            lvwCostCenter.CostCenterInfoCollection = CostcenterInfoItems.GetCostCenterInfoItems();
            lvwWorkgroups.HideSelection = false;
            lvwCostCenter.HideSelection = false;
            SelectDeselect(true);
        }

        private void PerformAnalysis()
        {
            if (lvwWorkgroups.SelectedWorkGroups.Count == 0)
            {
                MessageBox.Show("Bitte markieren Sie zun�chst die Produktiv-Sites" + ", die Sie in die Auswertung einbeziehen wollen", "Keine Produktiv-Sites ausgew�hlt!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = lvwWorkgroups.SelectedWorkGroups.Count - 1;
            ProgressBar1.Value = 0;
            lblPass.Text = "Pass 1: Berechnen der Leistung der einzelnen Arbeitsgruppen";
            WorkGroupInfoItems locWorkgroups = lvwWorkgroups.SelectedWorkGroups;
            ProductionPeriod locPeriod = new ProductionPeriod(DateRangePicker.DateRangeValue, new ShiftParameters(true, true, true, true, false, 0, 0, 0));
            //Zeitgrade der Arbeitsgruppen im Bereich errechnen
            WorkGroupAnalysisInfoItems locWorkgroupAnalysis = new WorkGroupAnalysisInfoItems(locPeriod, lvwWorkgroups.SelectedWorkGroups, UpdateProgressInfo, true, true);
            locWorkgroupAnalysis.ExecuteQuery();
            foreach (WorkGroupAnalysisInfo locItem in locWorkgroupAnalysis)
            {
                locWorkgroups[new IntKey(locItem.WorkGroupInfo.IDWorkGroup)].CurrentDegreeOfTime = locItem.DegreeOfTime;
            }

            lblPass.Text = "Pass 2: Durchf�hren der Mengenanalyse";
            lblPass.Update();
            ProgressBar1.Value = 0;
            ProgressBar1.Update();
            myCurrentProdAmounts = new WorkgroupsProductionDataAmounts(FacessoGeneric.LoginInfo.IDSubsidiary, locWorkgroups, DateRangePicker.DateRangeValue.StartDate, DateRangePicker.DateRangeValue.EndDate, UpdateProgressInfo);
            myCurrentProdAmounts.ExecuteQuery();
            lblPass.Text = "Berechnungen abgeschlossen.";
            lblPass.Update();
            myCurrentProdAmounts.CostCenters = lvwCostCenter.SelectedCostCenters;
        }

        private void UpdateProgressInfo(WorkGroupInfo Workgroup, int ProcessedWorkgroups)
        {
            ProgressBar1.Value = ProcessedWorkgroups;
        }

        private void btnPreview_Click(System.Object sender, System.EventArgs e)
        {
            PerformAnalysis();
            if (optGroupWorkvalues.Checked)
            {
                myCurrentProdAmounts.CategoriseByWorkvalues();
            }
            else if (optGroupCostcenters.Checked)
            {
                myCurrentProdAmounts.CategoriseByCostCenters();
            }

            FacPrintProductionAmountAnalysisBatch locPrintAnalysis = new FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(AnalysisTarget.PreviewBeforePrint);
        }

        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            PerformAnalysis();
            if (optGroupWorkvalues.Checked)
            {
                myCurrentProdAmounts.CategoriseByWorkvalues();
            }
            else if (optGroupCostcenters.Checked)
            {
                myCurrentProdAmounts.CategoriseByCostCenters();
            }

            FacPrintProductionAmountAnalysisBatch locPrintAnalysis = new FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(AnalysisTarget.DirectlyToPrinter);
        }

        private void btnExport_Click(System.Object sender, System.EventArgs e)
        {
            PerformAnalysis();
            FacPrintProductionAmountAnalysisBatch locPrintAnalysis = new FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(AnalysisTarget.CSVExport);
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnCostCenterLabourValueAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Not yet implemented!");
        }

        private void SelectDeselect(bool SelFlag)
        {
            foreach (ListViewItem locItem in lvwWorkgroups.Items)
            {
                locItem.Selected = SelFlag;
            }
        }

        private void TabControl1_Selected(System.Object sender, System.Windows.Forms.TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (!(optGroupCostcenters.Checked))
                {
                    optGroupCostcenters.Checked = true;
                }
            }
            else
            {
                if (!(optStandardAnalysis.Checked))
                {
                    optStandardAnalysis.Checked = true;
                }
            }
        }

        private void optGroupCostcenters_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (optGroupCostcenters.Checked == true)
            {
                if (TabControl1.SelectedIndex == 0)
                {
                    TabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    TabControl1.SelectedIndex = 0;
                }
            }
        }

        private void btnSelectAll_Click(System.Object sender, System.EventArgs e)
        {
            SelectDeselect(true);
        }

        private void btnDeselectAll_Click(System.Object sender, System.EventArgs e)
        {
            SelectDeselect(false);
        }

        public frmProductionAmountAnalysis()
        {
            InitializeComponent();
        }
    }
}