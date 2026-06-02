using Facesso.Data;
using Facesso.GenericControls;
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
    public partial class frmIncentiveWageCalc
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            //Employeeliste f�llen
            EmployeeInfoItems locEmployees = new EmployeeInfoItems(0);
            if (locEmployees == null || locEmployees.Count == 0)
            {
                MessageBox.Show("Es sind keine Stammdaten vorhanden. Bitte legen Sie zun�chst die erforderlichen Stammdaten an und f�hren Sie eine Datenerfassung durch", "Fehlende Stammdaten:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }

            elvEmployees.EmployeeInfoCollection = locEmployees;
            SelectAll();
            //Monatsbereich aus den globalen Einstellungen laden
            MonthRangePicker.MonthRangeResult = ((MonthRangePickerResult)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("WageCalcMonthlyRange", MonthRangePicker.MonthRangeResult));
        }

        private void SelectAll()
        {
            foreach (ListViewItem locItem in elvEmployees.Items)
            {
                locItem.Selected = true;
            }
        }

        private void UnselectAll()
        {
            foreach (ListViewItem locItem in elvEmployees.Items)
            {
                locItem.Selected = false;
            }
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSelectAll_Click(System.Object sender, System.EventArgs e)
        {
            SelectAll();
        }

        private void btnUnselectAll_Click(System.Object sender, System.EventArgs e)
        {
            UnselectAll();
        }

        private void btnPerformCalculation_Click(System.Object sender, System.EventArgs e)
        {
            //Einstellungen speichern
            FacessoGeneric.FacessoGlobalSettings.Settings.SetItem("WageCalcMonthlyRange", MonthRangePicker.MonthRangeResult);
            //Wieviele Mitarbeiter m�ssen berechnet werden?
            int locCount = elvEmployees.SelectedEmployees.Count;
            if (locCount == 0)
            {
                MessageBox.Show("Bitte w�hlen Sie die auszuwertenden Mitarbeiter aus.", "Keine Mitarbeiter ausgew�hlt:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EmployeeAnalysisInfoItems locEmployeesAnalysed = new EmployeeAnalysisInfoItems(MonthRangePicker.DateRangeText);
            EmployeeAnalysisInfoItem locEmployeeAnalysed = null;
            bool blnFirst = default(bool);
            DateTime locTicket = default(DateTime);
            pbEmployeesToAnalyse.Maximum = locCount;
            //Employee-Daten holen
            foreach (EmployeeInfo locEmployee in elvEmployees.SelectedEmployees)
            {
                //Progress-Bar setzen:
                pbEmployeesToAnalyse.Value = locCount;
                locCount -= 1;
                //Mitarbeiternamen anzeigen
                lblCurrentEmployee.Text = locEmployee.DisplayName;
                Application.DoEvents();
                //Den Zeitraum bestimmen (immer �ber alle Schichten)
                ProductionPeriod locPeriod = new ProductionPeriod(MonthRangePicker.MonthRangeResult.FromDate, MonthRangePicker.MonthRangeResult.ToDate);
                //Zeitdaten einholen und Lohndaten berechnen
                if (!(blnFirst))
                {
                    locEmployeeAnalysed = new EmployeeAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, FacessoGeneric.LoginInfo.IDUser, locEmployee, locPeriod, true);
                    locTicket = locEmployeeAnalysed.UsedTicket;
                    blnFirst = true;
                }
                else
                {
                    locEmployeeAnalysed = new EmployeeAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, FacessoGeneric.LoginInfo.IDUser, locEmployee, locPeriod, locTicket, false);
                }

                locEmployeesAnalysed.Add(locEmployeeAnalysed);
            }

            locEmployeeAnalysed.CleanUp();
            pbEmployeesToAnalyse.Value = 0;
            frmIncentiveWageGroupResult locFrm = new frmIncentiveWageGroupResult();
            locFrm.ShowDialog(locEmployeesAnalysed);
        }

        public frmIncentiveWageCalc()
        {
            InitializeComponent();
        }
    }
}