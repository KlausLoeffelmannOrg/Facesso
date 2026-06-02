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
    internal partial class frmIncentiveWageGroupResult
    {
        private EmployeeAnalysisInfoItems myAnalysisItems;
        public frmIncentiveWageGroupResult()
        {
            this.Load += frmIncentiveWageGroupResult_Load;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public DialogResult ShowDialog(EmployeeAnalysisInfoItems AnalysisItems)
        {
            myAnalysisItems = AnalysisItems;
            InitializeTable();
            UpdateContent();
            this.Location = ((Point)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoIncWageListWindowLocation", this.Location));
            this.Size = ((Size)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoIncWageListWindowSize", this.Size));
            return this.ShowDialog();
        }

        private void UpdateContent()
        {
            double locSumIncentiveWage = default(double);
            dgvEmployeeWages.Rows.Clear();
            foreach (EmployeeAnalysisInfoItem locItem in myAnalysisItems)
            {
                if (locItem.EmployeeWage.DegreeOfTime == -1)
                {
                    dgvEmployeeWages.Rows.Add(new object[] { locItem.EmployeeWage.IDEmployee, locItem.EmployeeWage.PersonnelNumber, locItem.EmployeeWage.LastName + ", " + locItem.EmployeeWage.FirstName, "- - -", "- - -", "Zeitgrad:" + "- - -" + System.Environment.NewLine + "(Faktor: " + "- - -" + ")", locItem.EmployeeWage.BaseWage.ToString("#,##0.00"), "- - -", "- - -", false });
                }
                else
                {
                    dgvEmployeeWages.Rows.Add(new object[] { locItem.EmployeeWage.IDEmployee, locItem.EmployeeWage.PersonnelNumber, locItem.EmployeeWage.LastName + ", " + locItem.EmployeeWage.FirstName, locItem.TimeLogItems.AttendanceTimeDeltaStrings, locItem.TimeLogItems.IncentiveTimeDeltaStrings, "Zeitgrad: " + locItem.EmployeeWage.DegreeOfTime.ToString("##0") + System.Environment.NewLine + locItem.EmployeeWage.PercentageDescription, locItem.EmployeeWage.BaseWage.ToString("#,##0.00 �"), (locItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \\h"), locItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 �"), true });
                    dgvEmployeeWages.Rows[dgvEmployeeWages.Rows.Count - 1].Tag = locItem.EmployeeWage.TotalIncentiveWage;
                    locSumIncentiveWage += locItem.EmployeeWage.TotalIncentiveWage;
                }
            }

            lblIncentiveWageForMonth.Text = "Pr�mienl�hne " + myAnalysisItems.PeriodText;
            lblIncentiveWageSum.Text = locSumIncentiveWage.ToString("#,##0.00 �");
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            {
                var __with0 = FacessoGeneric.FacessoUserSettings;
                if (!(this.WindowState == FormWindowState.Minimized))
                {
                    __with0.Settings.SetItem("FacessoIncWageListWindowLocation", this.Location);
                    __with0.Settings.SetItem("FacessoIncWageListWindowSize", this.Size);
                }
            }
        }

        private void InitializeTable()
        {
            DataGridViewColumn locColumn = default(DataGridViewColumn);
            DataGridViewTextBoxCell locTextCell = new DataGridViewTextBoxCell();
            Font locHeaderFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            Font locCellFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            Font locSpecialFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            dgvEmployeeWages.ColumnHeadersDefaultCellStyle.Font = locHeaderFont;
            dgvEmployeeWages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployeeWages.AllowUserToAddRows = false;
            dgvEmployeeWages.AllowUserToDeleteRows = false;
            dgvEmployeeWages.AllowUserToOrderColumns = false;
            {
                var __with1 = dgvEmployeeWages.Columns;
                __with1.Clear();
                //ID (nicht sichtbar)
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Visible = false;
                locColumn.Name = "IDEmployee";
                __with1.Add(locColumn);
                //Personalnummer
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 100;
                locColumn.DisplayIndex = 0;
                locColumn.HeaderText = "Pers.-Nr.:";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locHeaderFont;
                locColumn.Name = "PersonnelNr";
                locColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                __with1.Add(locColumn);
                //Name, Vorname
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 300;
                locColumn.DisplayIndex = 1;
                locColumn.HeaderText = "Name, Vorname:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "LastnameFirstname";
                locColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                __with1.Add(locColumn);
                //Anwesenheitszeiten
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 150;
                locColumn.DisplayIndex = 2;
                locColumn.HeaderText = "Anwesenheitszeiten";
                locColumn.MinimumWidth = 150;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.False;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "DeltaTimes";
                __with1.Add(locColumn);
                //Bonuszeiten
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 150;
                locColumn.DisplayIndex = 3;
                locColumn.HeaderText = "Bonuszeiten";
                locColumn.MinimumWidth = 150;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.False;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "BonusTimes";
                __with1.Add(locColumn);
                //Zeitgrad/Faktor
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 100;
                locColumn.DisplayIndex = 4;
                locColumn.HeaderText = "Zeitgrad";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "DegreeOfTime";
                locColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                __with1.Add(locColumn);
                //Grundlohn
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 60;
                locColumn.DisplayIndex = 5;
                locColumn.HeaderText = "Grundlohn";
                locColumn.MinimumWidth = 60;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "BaseWage";
                __with1.Add(locColumn);
                //Pr�mienlohnstunden
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 60;
                locColumn.DisplayIndex = 6;
                locColumn.HeaderText = "Effektivstunden:";
                locColumn.MinimumWidth = 60;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "AttendanceTime";
                __with1.Add(locColumn);
                //Pr�mie
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 85;
                locColumn.DisplayIndex = 7;
                locColumn.HeaderText = "Pr�mie:";
                locColumn.MinimumWidth = 85;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locSpecialFont;
                locColumn.Name = "IncentiveWage";
                __with1.Add(locColumn);
                //Datentag (nicht sichtbar)
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Visible = false;
                locColumn.Name = "HasData";
                __with1.Add(locColumn);
            }

            dgvEmployeeWages.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEmployeeWages.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void tsmQuit_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AssignSelectionFromTable()
        {
            //Zun�chst alle deselektieren
            foreach (EmployeeAnalysisInfoItem locItem in myAnalysisItems)
            {
                locItem.Selected = false;
            }

            foreach (DataGridViewRow locRow in dgvEmployeeWages.Rows)
            {
                if (locRow.Selected)
                {
                    //Das selektierte Item finden
                    foreach (EmployeeAnalysisInfoItem locItem in myAnalysisItems)
                    {
                        if (System.Convert.ToInt32(locRow.Cells["IDEmployee"].Value) == locItem.EmployeeWage.IDEmployee)
                        {
                            locItem.Selected = true;
                        }
                    }
                }
            }
        }

        private void PreselectData(IncentiveWagePreSelectionMode SelectionMode)
        {
            foreach (DataGridViewRow locRow in dgvEmployeeWages.Rows)
            {
                if (SelectionMode == IncentiveWagePreSelectionMode.All)
                {
                    locRow.Selected = true;
                }
                else if (SelectionMode == IncentiveWagePreSelectionMode.None)
                {
                    locRow.Selected = false;
                }
                else if (SelectionMode == IncentiveWagePreSelectionMode.DataPresent)
                {
                    if (System.Convert.ToBoolean(locRow.Cells["HasData"].Value))
                    {
                        locRow.Selected = true;
                    }
                    else
                    {
                        locRow.Selected = false;
                    }
                }
                else
                {
                    double locIncentiveWage = default(double);
                    if (locRow.Tag != null)
                    {
                        locIncentiveWage = System.Convert.ToDouble(locRow.Tag);
                        if (Math.Round(locIncentiveWage, 2) > 0)
                        {
                            locRow.Selected = true;
                        }
                        else
                        {
                            locRow.Selected = false;
                        }
                    }
                    else
                    {
                        locRow.Selected = false;
                    }
                }
            }
        }

        private void tsmPrintWageList_Click(System.Object sender, System.EventArgs e)
        {
            AssignSelectionFromTable();
            FacPrintEmployeesWageList locPrintWageList = new FacPrintEmployeesWageList(myAnalysisItems, FacessoGeneric.LoginInfo.Username);
            locPrintWageList.ProcessDocument(AnalysisTarget.PreviewBeforePrint);
        }

        private void tsmPrintEmployeeWagesDetailed_Click(System.Object sender, System.EventArgs e)
        {
            AssignSelectionFromTable();
            FacPrintEmployeesWageStatements locPrintWageStatements = new FacPrintEmployeesWageStatements(myAnalysisItems, FacessoGeneric.LoginInfo.Username);
            locPrintWageStatements.ProcessDocument(AnalysisTarget.PreviewBeforePrint);
        }

        private void tsmSelectWithData_Click(System.Object sender, System.EventArgs e)
        {
            PreselectData(IncentiveWagePreSelectionMode.DataPresent);
        }

        private void TsmSelectWithIncentiveWage_Click(System.Object sender, System.EventArgs e)
        {
            PreselectData(IncentiveWagePreSelectionMode.IncentiveWagePresent);
        }

        private void tsmSelectAll_Click(System.Object sender, System.EventArgs e)
        {
            PreselectData(IncentiveWagePreSelectionMode.All);
        }

        private void tsmDeselectAll_Click(System.Object sender, System.EventArgs e)
        {
            PreselectData(IncentiveWagePreSelectionMode.None);
        }

        private void frmIncentiveWageGroupResult_Load(System.Object sender, System.EventArgs e)
        {
            PreselectData(IncentiveWagePreSelectionMode.DataPresent);
        }

        private void dgvEmployeeWages_ColumnHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvEmployeeWages.Columns["PersonnelNr"].Index)
            {
                myAnalysisItems.SortByPersonnelNumber();
            }
            else if (e.ColumnIndex == dgvEmployeeWages.Columns["LastnameFirstname"].Index)
            {
                myAnalysisItems.SortByLastname();
            }
            else if (e.ColumnIndex == dgvEmployeeWages.Columns["DegreeOfTime"].Index)
            {
                myAnalysisItems.SortByDegreeOfTime();
            }

            UpdateContent();
        }

        private void TsmCsvExport_Click(System.Object sender, System.EventArgs e)
        {
            AssignSelectionFromTable();
            FacPrintEmployeesWageList locPrintWageList = new FacPrintEmployeesWageList(myAnalysisItems, FacessoGeneric.LoginInfo.Username);
            locPrintWageList.ProcessDocument(AnalysisTarget.CSVExport);
        }
    }

    public enum IncentiveWagePreSelectionMode
    {
        All,
        IncentiveWagePresent,
        DataPresent,
        None,
    }
}