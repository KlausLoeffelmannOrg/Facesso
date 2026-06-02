using Facesso;
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
    public partial class frmProductionDataCollector
    {
        private ShiftDateWorkResultInfo _mySdwResult;
        // TODO(vb-convert): WithEvents member is reassigned outside InitializeComponent; re-wiring retained.
        private ShiftDateWorkResultInfo mySdwResult
        {
            get
            {
                return _mySdwResult;
            }

            set
            {
                if (_mySdwResult != null)
                {
                    _mySdwResult.CombinedSavingStateChanged -= mySdwResult_CombinedSavingStateChanged;
                    _mySdwResult.ResultsChanged -= mySdwResult_ResultsChanged;
                }

                _mySdwResult = value;
                if (_mySdwResult != null)
                {
                    _mySdwResult.CombinedSavingStateChanged += mySdwResult_CombinedSavingStateChanged;
                    _mySdwResult.ResultsChanged += mySdwResult_ResultsChanged;
                }
            }
        }

        private bool myDoNothing;
        private FacessoGeneralOptions myFacessoGeneralOptions;
        public frmProductionDataCollector()
        {
            this.FormClosed += frmProductionDataCollector_FormClosed;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            this.Location = ((Point)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerWindowLocation", this.Location));
            this.Size = ((Size)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerWindowSize", this.Size));
            this.splitProductionData_Employees.SplitterDistance = System.Convert.ToInt32(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerSplitterDistance", this.splitProductionData_Employees.SplitterDistance));
            this.tsmOnlyShowActiveLabourValues.Checked = System.Convert.ToBoolean(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerOnlyShowActiveLabourValues", this.tsmOnlyShowActiveLabourValues.Checked));
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
            dgvProductionData.OnlyShowActivatedLabourValues = this.tsmOnlyShowActiveLabourValues.Checked;
        }

        public void HandleDialog(CombinedParametersInfo CombinedParameters)
        {
            string locError = "";
            if (!(SPAccess.GetInstance().Basedata_DoEmployeesExist()))
            {
                locError = "* Es sind keine Mitarbeiterstammdaten eingerichtet!" + System.Environment.NewLine + System.Environment.NewLine;
            }

            if (!(SPAccess.GetInstance().Basedata_DoWorkGroupsExist()))
            {
                locError += "* Es sind keine Produktiv-Sites eingerichtet!" + System.Environment.NewLine + System.Environment.NewLine;
            }

            if (locError != "")
            {
                MessageBox.Show("Datenerfassung ist noch nicht m�glich:" + System.Environment.NewLine + System.Environment.NewLine + locError + System.Environment.NewLine + "Bitte f�hren Sie zun�chst die Stammdaten erfassung durch!", "Datenerfassung nicht m�glich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SwitchParameters(CombinedParameters.WorkGroup, CombinedParameters.ProductionDate, CombinedParameters.Shift, true);
            this.ShowDialog();
        }

        private void tsbShift1_Click(System.Object sender, System.EventArgs e)
        {
            SaveChanges(false);
            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, mySdwResult.CombinedParameters.ProductionDate, 1, false);
            dgvProductionData.Focus();
        }

        private void tsbShift2_Click(System.Object sender, System.EventArgs e)
        {
            SaveChanges(false);
            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, mySdwResult.CombinedParameters.ProductionDate, 2, false);
            dgvProductionData.Focus();
        }

        private void tsbShift3_Click(System.Object sender, System.EventArgs e)
        {
            SaveChanges(false);
            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, mySdwResult.CombinedParameters.ProductionDate, 3, false);
            dgvProductionData.Focus();
        }

        private void tsbShift4_Click(System.Object sender, System.EventArgs e)
        {
            SaveChanges(false);
            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, mySdwResult.CombinedParameters.ProductionDate, 4, false);
            dgvProductionData.Focus();
        }

        private void tscWorkGroup_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            SaveChanges(false);
            SwitchParameters(((WorkGroupInfo)tscWorkGroup.Items[tscWorkGroup.SelectedIndex]), mySdwResult.CombinedParameters.ProductionDate, mySdwResult.CombinedParameters.Shift, false);
            dgvProductionData.Focus();
        }

        private void dtpProductionDate_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            SaveChanges(false);
            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, dtpProductionDate.Value, mySdwResult.CombinedParameters.Shift, false);
            dgvProductionData.Focus();
        }

        private void tsmEmployeeTime_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                dgvProductionData.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitte �berpr�fen Sie Ihre Eingabe, da die Formelauswertung einen Syntax-Fehler generierte!", "Eingabefehler:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Erst die Mitarbeiter ausw�hlen
            EmployeeInfoItems locEmployees = default(EmployeeInfoItems);
            locEmployees = new frmEmployeePicker().GetEmployeeSelection();
            if (locEmployees != null)
            {
                //Jetzt Mitarbeiterzeiten erfassen
                frmTimeLogItemCollection locFormTimeItems = new frmTimeLogItemCollection();
                EmployeeTimeLogInfo locTimeLogItems = locFormTimeItems.GetTimeLogItems(mySdwResult.CombinedParameters, locEmployees);
                //Pr�fen, ob Abbruch oder OK
                if (locTimeLogItems != null)
                {
                    //Und die neuen Zeiten der Mitarbeiter entweder einrichten,...
                    if (mySdwResult.EmployeeTimeLogItems == null)
                    {
                        mySdwResult.EmployeeTimeLogItems = new EmployeeTimeLogInfo(mySdwResult.CombinedParameters, locTimeLogItems);
                    }
                    else
                    {
                        //oder zu den vorhandenen dazuf�gen
                        mySdwResult.EmployeeTimeLogItems.AddRange(locTimeLogItems);
                    }

                    //Zeitentabelle aktualisieren
                    SaveChanges(true, true);
                }
            }
        }

        private void UpdateUI()
        {
            {
                var __with0 = mySdwResult.CombinedParameters.WorkGroup;
                lblDegreeOfTime.Text = __with0.IncentiveIndicatorSynonym + " (ang.): " + mySdwResult.DegreeOfTimeAdj.ToString(__with0.IncentiveFormatString);
            }

            lblMinutesEffective.Text = "Min. Effektiv: " + mySdwResult.TotalEffectiveIWT.ToString();
            lblMinutesEffectiveAdj.Text = "Min. (ang.) Effektiv: " + mySdwResult.TotalEffectiveIWTAdj.ToString();
            lblMinutesReference.Text = "Min. Referenz: " + mySdwResult.TotalReferenceIWT.ToString();
            lblShift.Text = "Schicht " + mySdwResult.CombinedParameters.ShiftText(true);
            lblWorkgroup.Text = "Produktiv-Site: " + mySdwResult.CombinedParameters.WorkGroup.ListItemText;
        }

        private void RebuildWorkgroupCombo()
        {
            WorkGroupInfoItems locWorkGroups = new WorkGroupInfoItems(mySdwResult.CombinedParameters);
            int locCount = -1;
            int locIndex = -1;
            {
                var __with1 = tscWorkGroup;
                __with1.Items.Clear();
                foreach (WorkGroupInfo locItem in locWorkGroups)
                {
                    if (locItem.IsActive)
                    {
                        locCount += 1;
                        __with1.Items.Add(locItem);
                        if (locItem.IDWorkGroup == mySdwResult.CombinedParameters.WorkGroup.IDWorkGroup)
                        {
                            locIndex = locCount;
                        }
                    }
                }
            }

            if (locIndex > -1)
            {
                tscWorkGroup.SelectedIndex = locIndex;
            }
        }

        private void EditTimeLogItems(EmployeeTimeLogInfo tli)
        {
            frmTimeLogItemCollection locFormTimeItems = new frmTimeLogItemCollection();
            DialogResult locDR = locFormTimeItems.EditTimeLogItems(mySdwResult.CombinedParameters, tli);
            if (locDR == System.Windows.Forms.DialogResult.Abort)
            {
                return;
            }

            foreach (EmployeeTimeLogInfoItem locItem in tli)
            {
                dgvTimeLogItems.EmployeeTimeLogItems.SetItem(locItem.IDTimeLog, locItem);
            }

            SaveChanges(true, true);
        }

        private void mySdwResult_CombinedSavingStateChanged(object sender, Facesso.Data.CombinedSavingStateChangedEventArgs e)
        {
            if (e.ForProductionDataSavingState)
            {
                tslSaveState.Text = "Mengen�nderungen wurden vorgenommen";
            }
            else
            {
                tslSaveState.Text = "Es wurden keine Mengen�nderungen vorgenommen.";
            }
        }

        private void mySdwResult_ResultsChanged(object sender, System.EventArgs e)
        {
            UpdateUI();
        }

        private void mainTimer_Tick(object sender, System.EventArgs e)
        {
            tslCurrentDateInfo.Text = "Heute: " + DateTime.Now.ToLongDateString() + "   -   " + DateTime.Now.ToLongTimeString();
        }

        private void tsmSaveChanges_Click(System.Object sender, System.EventArgs e)
        {
            mySdwResult.SaveToDatabase();
        }

        private void dgvTimeLogItems_TimeLogItemDoubleClick(System.Object sender, Facesso.GenericControls.TimeLogItemClickEventArgs e)
        {
            EmployeeTimeLogInfo locTlis = new EmployeeTimeLogInfo();
            locTlis.Add(e.EmployeeTimeLogItem);
            EditTimeLogItems(locTlis);
            dgvTimeLogItems.SelectEmployeeItems(locTlis);
        }

        private void SwitchParameters(WorkGroupInfo wgi, System.DateTime ProductionDate, byte Shift, bool DontSave)
        {
            if (!(DontSave))
            {
                SaveChanges(false);
            }

            CombinedParametersInfo locCP = new CombinedParametersInfo(wgi, ProductionDate, Shift);
            mySdwResult = new ShiftDateWorkResultInfo(locCP);
            dgvTimeLogItems.EmployeeTimeLogItems = mySdwResult.EmployeeTimeLogItems;
            dgvProductionData.ProductionData = mySdwResult.ProductionData;
            myDoNothing = true;
            RebuildWorkgroupCombo();
            dtpProductionDate.Value = ProductionDate;
            myDoNothing = false;
            UpdateUI();
        }

        private void SaveChanges(bool Rebuild)
        {
            SaveChanges(Rebuild, false);
        }

        private void SaveChanges(bool Rebuild, bool SaveInAnycase)
        {
            try
            {
                if (SaveInAnycase)
                {
                    mySdwResult.SaveToDatabase();
                }
                else
                {
                    if (mySdwResult.CombinedSavingState.ForProductionDataSavingState)
                    {
                        mySdwResult.SaveToDatabase();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("IDBonusLists"))
                {
                    MessageBox.Show("Die zuletzt eingegebenen Mitarbeiter konnten nicht hinzugef�gt werden, da keine " + System.Environment.NewLine + "�ber die Kostenstelle zugewiesene individuelle Bonus-Tabelle existiert." + System.Environment.NewLine + System.Environment.NewLine + "Bitte legen Sie entweder eine Bonus-Tabelle f�r die dem Mitarbeiter zugewiesene" + System.Environment.NewLine + "Kostenstelle an, oder weisen Sie dem Mitarbeiter wieder die Systemkostenstelle zu!" + System.Environment.NewLine + System.Environment.NewLine + "Die zuletzt eingegebenen Mitarbeiter werden verworfen.", "Zeitenzuweisung konnte nicht ausgef�hrt werden!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (Rebuild)
            {
                dgvTimeLogItems.EmployeeTimeLogItems = mySdwResult.EmployeeTimeLogItems;
                dgvProductionData.ProductionData = mySdwResult.ProductionData;
            }
        }

        private void tsmDeleteTimeEntries_Click(System.Object sender, System.EventArgs e)
        {
            string locString = "";
            locString = "Sind Sie sicher, dass Sie die Zeiten der markierten Mitarbeiter" + System.Environment.NewLine + System.Environment.NewLine;
            foreach (EmployeeTimeLogInfoItem locItem in dgvTimeLogItems.SelectedEmployeeTimeLogItems)
            {
                locString += locItem.ToString() + System.Environment.NewLine;
            }

            locString += System.Environment.NewLine + System.Environment.NewLine + "entfernen wollen?";
            DialogResult locDR = MessageBox.Show(locString, "Markierte Mitarbeiterzeiten entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDR == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (EmployeeTimeLogInfoItem locItem in dgvTimeLogItems.SelectedEmployeeTimeLogItems)
                {
                    //mySdwResult.EmployeeTimeLogItems.DeleteFromDatabase(locItem)
                    mySdwResult.EmployeeTimeLogItems.Remove(locItem.IDTimeLog);
                }

                SaveChanges(true, true);
            }
        }

        private void tssbPrint_Click(System.Object sender, System.EventArgs e)
        {
            FacPrintWorkGroupShiftDate locPrint = new FacPrintWorkGroupShiftDate(mySdwResult, FacessoGeneric.LoginInfo.Username);
            locPrint.ProcessDocument(AnalysisTarget.PreviewBeforePrint);
        }

        private void frmProductionDataCollector_FormClosed(System.Object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            SaveChanges(false);
            FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerWindowLocation", this.Location);
            FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerWindowSize", this.Size);
            FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerSplitterDistance", this.splitProductionData_Employees.SplitterDistance);
            FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerOnlyShowActiveLabourValues", this.tsmOnlyShowActiveLabourValues.Checked);
        }

        private void DialogbeendenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tsbNextWorkgroup_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                tscWorkGroup.SelectedIndex = tscWorkGroup.SelectedIndex + 1;
            }
            catch (Exception ex)
            {
                tscWorkGroup.SelectedIndex = 0;
                dtpProductionDate.Value = ActiveDev.Dates.NextWorkday(dtpProductionDate.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
            }
        }

        private void tsbPreviousWorkgroup_Click(System.Object sender, System.EventArgs e)
        {
            if (tscWorkGroup.SelectedIndex > 0)
            {
                tscWorkGroup.SelectedIndex = tscWorkGroup.SelectedIndex - 1;
            }
            else
            {
                tscWorkGroup.SelectedIndex = tscWorkGroup.Items.Count - 1;
                dtpProductionDate.Value = ActiveDev.Dates.PreviousWorkday(dtpProductionDate.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
            }
        }

        private void tsbNextWorkDay_Click(System.Object sender, System.EventArgs e)
        {
            dtpProductionDate.Value = ActiveDev.Dates.NextWorkday(dtpProductionDate.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
        }

        private void tsbPreviousWorkday_Click(System.Object sender, System.EventArgs e)
        {
            dtpProductionDate.Value = ActiveDev.Dates.PreviousWorkday(dtpProductionDate.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
        }

        private void tsbBack_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tsbMyTodoList_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht nur in der Enterprise-Edition zur Verf�gung", "Funktion nicht verf�gbar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsmOnlyShowActiveLabourValues_Click(System.Object sender, System.EventArgs e)
        {
            tsmOnlyShowActiveLabourValues.Checked = !(tsmOnlyShowActiveLabourValues.Checked);
            dgvProductionData.OnlyShowActivatedLabourValues = tsmOnlyShowActiveLabourValues.Checked;
        }

        private void tsmDeleteShiftData_ButtonClick(System.Object sender, System.EventArgs e)
        {
            DialogResult locDr = MessageBox.Show("Sind Sie sicher, dass Sie die Produktionsdaten" + System.Environment.NewLine + "der aktuellen Schicht l�schen wollen?", "Produktionsdaten l�schen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDr == System.Windows.Forms.DialogResult.Yes)
            {
                mySdwResult.DeleteProductionDataItems();
            }

            SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, mySdwResult.CombinedParameters.ProductionDate, mySdwResult.CombinedParameters.Shift, true);
        }
    }
}