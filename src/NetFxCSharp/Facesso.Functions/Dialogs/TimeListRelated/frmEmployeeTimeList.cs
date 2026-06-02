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
    public partial class frmEmployeeTimeList
    {
        private EmployeeInfo myEmployee;
        private System.DateTime myReferenceDate;
        private EmployeeTimeLogInfo myTimeLogItems;
        public void ShowDialog(EmployeeInfo Employee, System.DateTime ReferenceDate)
        {
            myReferenceDate = ReferenceDate;
            myEmployee = Employee;
            this.Text = "Zeitenliste f�r " + Employee.DisplayName;
            InitializeDates();
            dgvTimeList.SingleEmployeeList = true;
            BuildList();
            this.ShowDialog();
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void InitializeDates()
        {
            dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate);
            dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate);
        }

        public void BuildList()
        {
            myTimeLogItems = new EmployeeTimeLogInfo(myEmployee, dtpFrom.Value, dtpTo.Value);
            dgvTimeList.EmployeeTimeLogItems = myTimeLogItems;
        }

        public void DeleteItem()
        {
            string locString = "";
            locString = "Sind Sie sicher, dass Sie die Zeiten der markierten Mitarbeiter" + System.Environment.NewLine + System.Environment.NewLine;
            foreach (EmployeeTimeLogInfoItem locItem in dgvTimeList.SelectedEmployeeTimeLogItems)
            {
                locString += locItem.ToString() + System.Environment.NewLine;
            }

            locString += System.Environment.NewLine + System.Environment.NewLine + "entfernen wollen?";
            DialogResult locDR = MessageBox.Show(locString, "Markierte Mitarbeiterzeiten entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDR == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (EmployeeTimeLogInfoItem locItem in dgvTimeList.SelectedEmployeeTimeLogItems)
                {
                    dgvTimeList.EmployeeTimeLogItems.DeleteFromDatabase(locItem);
                }
            }
        }

        private void dgvTimeList_TimeLogItemDoubleClick(System.Object sender, Facesso.GenericControls.TimeLogItemClickEventArgs e)
        {
            EmployeeTimeLogInfo locTlis = new EmployeeTimeLogInfo();
            locTlis.Add(e.EmployeeTimeLogItem);
            EditTimeLogItems(locTlis);
            dgvTimeList.SelectEmployeeItems(locTlis);
        }

        private void EditTimeLogItems(EmployeeTimeLogInfo tli)
        {
            frmTimeLogItemCollection locFormTimeItems = new frmTimeLogItemCollection();
            tli.WorkGroup = WorkGroupInfo.FromID(tli[0].EmployeeInfo.IDSubsidiary, tli[0].IDWorkGroup);
            tli.Shift = tli[0].Shift;
            tli.ProductionDate = tli[0].ProductionDate;
            CombinedParametersInfo locCP = new CombinedParametersInfo(tli.WorkGroup, tli[0].ProductionDate, tli[0].Shift);
            DialogResult locDR = locFormTimeItems.EditTimeLogItems(locCP, tli);
            if (locDR == System.Windows.Forms.DialogResult.Abort)
            {
                return;
            }

            foreach (EmployeeTimeLogInfoItem locItem in tli)
            {
                dgvTimeList.EmployeeTimeLogItems.SetItem(locItem.IDTimeLog, locItem);
            }

            tli.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
            BuildList();
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            BuildList();
        }

        private void btnCurrentMonth_Click(System.Object sender, System.EventArgs e)
        {
            dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate);
            dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate);
        }

        private void btnLastMonth_Click(System.Object sender, System.EventArgs e)
        {
            dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate.AddMonths(-1));
            dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate.AddMonths(-1));
        }

        private void btnSecondLastMonth_Click(System.Object sender, System.EventArgs e)
        {
            dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate.AddMonths(-2));
            dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate.AddMonths(-2));
        }

        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            FacPrintEmployeesTimeList locPrt = new FacPrintEmployeesTimeList(myTimeLogItems, FacessoGeneric.LoginInfo.Username);
            locPrt.ProcessDocument(AnalysisTarget.PreviewBeforePrint);
        }

        public frmEmployeeTimeList()
        {
            InitializeComponent();
        }
    }
}