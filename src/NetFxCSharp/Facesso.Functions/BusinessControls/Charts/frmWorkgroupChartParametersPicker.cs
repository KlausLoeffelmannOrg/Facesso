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
    public partial class frmWorkgroupChartParametersPicker
    {
        private WorkGroupAnalysisParameters myAnalysisParameters;
        private FacessoGeneralOptions myFacessoGeneralOptions;
        private WorkGroupInfoItems myAllWorkgroups;
        private bool myIgnoreNextTextChange;
        private bool myHasChangedManually;
        private const int MINIMUM_CHART_DELTA = 30;
        private const int INITIAL_FROM_VALUE_FOR_CHART_DELTA = 80;
        private const int INITIAL_TO_VALUE_FOR_CHART_DELTA = 140;
        public frmWorkgroupChartParametersPicker()
        {
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
            myAllWorkgroups = new WorkGroupInfoItems(true);
            wglWorkgroups.WorkGroupInfoItems = myAllWorkgroups;
            foreach (ListViewItem locItem in wglWorkgroups.Items)
            {
                locItem.Selected = true;
            }

            if (myFacessoGeneralOptions.SaturdayIsWorkday)
            {
                this.drpMain.LastWorkingday = LastWorkingdays.Saturday;
            }
            else if (myFacessoGeneralOptions.SundayIsWorkday)
            {
                this.drpMain.LastWorkingday = LastWorkingdays.Sunday;
            }
        }

        public WorkGroupAnalysisParameters GetAnalysisParameters()
        {
            //Default-Einstellungen übertragen
            ToAnalysisParameters();
            this.ShowDialog();
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return myAnalysisParameters;
            }
            else
            {
                return null;
            }

            return default(WorkGroupAnalysisParameters);
        }

        public WorkGroupAnalysisParameters GetAnalysisParameters(WorkGroupAnalysisParameters wgap)
        {
            myAnalysisParameters = wgap;
            FromAnalysisParameters();
            this.ShowDialog();
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return myAnalysisParameters;
            }
            else
            {
                return null;
            }

            return default(WorkGroupAnalysisParameters);
        }

        private void myWizardController_Finished(object sender, System.EventArgs e)
        {
        }

        private void ToAnalysisParameters()
        {
            if (myAnalysisParameters == null)
            {
                myAnalysisParameters = new WorkGroupAnalysisParameters();
            }

            {
                var __with0 = myAnalysisParameters;
                __with0.DateRange = drpMain.DateRangeValue;
                __with0.ShiftParameters = new ShiftParameters(chkShift1.Checked, chkShift2.Checked, chkShift3.Checked, chkShift4.Checked, optUseAlternatingShifts.Checked, System.Convert.ToInt32(nudAltShiftDays.Value), System.Convert.ToInt32(nudAltShift1.Value), System.Convert.ToInt32(nudAltShift2.Value));
                __with0.WorkGroups = wglWorkgroups.SelectedWorkGroups;
                //TODO: Hier im Bedarfsfall wieder ein Kontrollkästchen einfügen und abfragen.
                __with0.IncludeWorkLoad = false;
                __with0.WorkgroupAnalysisCount = nivBestWorstCount.Value;
                if (optBest.Checked)
                {
                    __with0.WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best;
                }
                else if (optWorst.Checked)
                {
                    __with0.WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Worst;
                }
                else
                {
                    __with0.WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Selected;
                }

                __with0.ChartTitel = txtChartTitel.Text;
                __with0.ChartDeltaFromValue = tbDegreeOfTimeFrom.Value;
                __with0.ChartDeltaToValue = tbDegreeOfTimeTo.Value;
                __with0.ChartType = (opt2DChart.Checked ? ChartType.Chart2DLine : ChartType.Chart3DLine);
            }
        }

        private void FromAnalysisParameters()
        {
            {
                var __with1 = myAnalysisParameters;
                drpMain.DateRangeValue = __with1.DateRange;
                chkShift1.Checked = __with1.ShiftParameters.ConsiderShift1;
                chkShift2.Checked = __with1.ShiftParameters.ConsiderShift2;
                chkShift3.Checked = __with1.ShiftParameters.ConsiderShift3;
                chkShift4.Checked = __with1.ShiftParameters.ConsiderShift4;
                optUseAlternatingShifts.Checked = __with1.ShiftParameters.AlternateShifts;
                nudAltShiftDays.Value = __with1.ShiftParameters.DaysAfterToAlternate;
                nudAltShift1.Value = __with1.ShiftParameters.AlternatingFirstShift;
                nudAltShift2.Value = __with1.ShiftParameters.AlternatingSecondShift;
                nivBestWorstCount.Value = __with1.WorkgroupAnalysisCount;
                if (__with1.WorkgroupAnalysisBehaviour == WorkgroupAnalysisBehaviours.Best)
                {
                    optBest.Checked = true;
                    __with1.WorkGroups = myAllWorkgroups;
                }
                else if (__with1.WorkgroupAnalysisBehaviour == WorkgroupAnalysisBehaviours.Worst)
                {
                    optWorst.Checked = true;
                    __with1.WorkGroups = myAllWorkgroups;
                }
                else
                {
                    optPickedSites.Checked = true;
                }

                txtChartTitel.Text = __with1.ChartTitel;
                tbDegreeOfTimeFrom.Value = __with1.ChartDeltaFromValue;
                tbDegreeOfTimeTo.Value = __with1.ChartDeltaToValue;
                txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString();
                txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString();
                if (__with1.ChartType == ChartType.Chart2DLine)
                {
                    opt2DChart.Checked = true;
                }
                else
                {
                    opt3DChart.Checked = true;
                }
            }
        }

        private void SelectAllWorkgroupItems()
        {
            //Vorselektieren
            foreach (ListViewItem locLvw in wglWorkgroups.Items)
            {
                locLvw.Selected = false;
            }
        }

        private void SelectWorkgroupItems()
        {
            SelectAllWorkgroupItems();
            foreach (int locItem in myAnalysisParameters.SelectedWorkgroups)
            {
                foreach (ListViewItem locLvw in wglWorkgroups.Items)
                {
                    if (int.Parse(locLvw.Name) == locItem)
                    {
                        locLvw.Selected = true;
                    }
                }
            }
        }

        private void btnAllShifts_Click(System.Object sender, System.EventArgs e)
        {
            chkShift1.Checked = true;
            chkShift2.Checked = true;
            chkShift3.Checked = true;
            chkShift4.Checked = true;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            ToAnalysisParameters();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            myAnalysisParameters = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void rbBest_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            wglWorkgroups.Enabled = false;
        }

        private void rbWorst_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            wglWorkgroups.Enabled = false;
        }

        private void rbPickedSites_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            wglWorkgroups.Enabled = true;
        }

        private void tbDegreeOfTimeTo_Scroll(System.Object sender, System.EventArgs e)
        {
            if (tbDegreeOfTimeTo.Value < (tbDegreeOfTimeFrom.Value + MINIMUM_CHART_DELTA))
            {
                tbDegreeOfTimeFrom.Value = (tbDegreeOfTimeTo.Value - MINIMUM_CHART_DELTA);
                txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString();
            }

            txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString();
        }

        private void tbDegreeOfTimeFrom_Scroll(System.Object sender, System.EventArgs e)
        {
            if (tbDegreeOfTimeFrom.Value > (tbDegreeOfTimeTo.Value - MINIMUM_CHART_DELTA))
            {
                tbDegreeOfTimeTo.Value = tbDegreeOfTimeFrom.Value + MINIMUM_CHART_DELTA;
                txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString();
            }

            txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString();
        }

        private void btnResetDeltaValues_Click(System.Object sender, System.EventArgs e)
        {
            tbDegreeOfTimeFrom.Value = INITIAL_FROM_VALUE_FOR_CHART_DELTA;
            tbDegreeOfTimeTo.Value = INITIAL_TO_VALUE_FOR_CHART_DELTA;
            txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString();
            txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString();
        }

        private void chkAutomaticTimeOfDegreeRange_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkAutomaticTimeOfDegreeRange.Checked)
            {
                tbDegreeOfTimeFrom.Enabled = false;
                tbDegreeOfTimeTo.Enabled = false;
                txtTimeOfDegreeRangeFrom.Text = "Auto";
                txtTimeOfDegreeRangeTo.Text = "Auto";
            }
            else
            {
                tbDegreeOfTimeFrom.Enabled = true;
                tbDegreeOfTimeTo.Enabled = true;
                txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString();
                txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString();
            }
        }

        private void txtChartTitel_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (!(myIgnoreNextTextChange))
            {
                myHasChangedManually = true;
            }
        }
    }
}