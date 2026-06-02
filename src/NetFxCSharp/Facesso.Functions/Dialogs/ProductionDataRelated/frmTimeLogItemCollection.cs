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
    public partial class frmTimeLogItemCollection
    {
        private EmployeeTimeLogInfo myTimeLogItems;
        private EmployeeTimeLogInfoItem myTimeLogItem;
        private EmployeeInfoItems myEmployeeInfoCollection;
        private bool myInitialized;
        private CombinedParametersInfo myCPIs;
        public EmployeeTimeLogInfo GetTimeLogItems(CombinedParametersInfo cp, EmployeeInfoItems eic)
        {
            using (this)
            {
                if (eic == null)
                {
                    return null;
                }

                myCPIs = cp;
                TimeSettingDetail locTsd = cp.WorkGroup.TimeSettingDetails.GetTimeSettingDetail(cp.ProductionDate, cp.Shift);
                ndbShiftStart.Value = locTsd.ShiftStart;
                ndbShiftEnd.Value = locTsd.ShiftEnd;
                nibWorkBreak.Value = locTsd.WorkBreak;
                myTimeLogItem = new EmployeeTimeLogInfoItem();
                myEmployeeInfoCollection = eic;
                myInitialized = true;
                UpdateUI();
                this.Text = "Zeiterfassung f�r: " + cp.WorkGroup.WorkGroupName + "; " + "Schicht " + cp.Shift + ", " + cp.ProductionDate.ToLongDateString();
                DialogResult locDR = this.ShowDialog();
                if (locDR == System.Windows.Forms.DialogResult.Cancel)
                {
                    return null;
                }

                return myTimeLogItems;
            }

            return default(EmployeeTimeLogInfo);
        }

        public DialogResult EditTimeLogItems(CombinedParametersInfo cp, EmployeeTimeLogInfo LogItems)
        {
            using (this)
            {
                if (LogItems == null || LogItems.Count == 0)
                {
                    return System.Windows.Forms.DialogResult.Cancel;
                }

                myCPIs = cp;
                ndbShiftStart.TypeSafeValue = LogItems[0].ShiftStart;
                ndbShiftEnd.TypeSafeValue = LogItems[0].ShiftEnd;
                nibWorkBreak.TypeSafeValue = LogItems[0].WorkBreak;
                nibDownTime.TypeSafeValue = LogItems[0].DownTime;
                ndbHandicap.TypeSafeValue = LogItems[0].Handicap;
                myTimeLogItem = new EmployeeTimeLogInfoItem();
                myInitialized = true;
                myTimeLogItems = LogItems;
                UpdateUI();
                this.Text = "Zeiterfassung f�r: " + cp.WorkGroup.WorkGroupName + "; " + "Schicht " + cp.Shift + ", " + cp.ProductionDate.ToLongDateString();
                DialogResult locDR = this.ShowDialog();
                return this.DialogResult;
            }

            return default(DialogResult);
        }

        private bool CheckForOverlaps()
        {
            string locMessage = "";
            foreach (EmployeeTimeLogInfoItem locEi in myTimeLogItems)
            {
                ADDBNullable<long> locExcludeIDTimeLog = default(ADDBNullable<long>);
                if (locEi.IDTimeLog > 0)
                {
                    locExcludeIDTimeLog = locEi.IDTimeLog;
                }

                OverlapsInfo locOverlapsInfo = new OverlapsInfo(locEi.EmployeeInfo, locEi.ShiftStart, locEi.ShiftEnd, locExcludeIDTimeLog);
                locMessage += locOverlapsInfo.ToString();
            }

            if (locMessage != "")
            {
                locMessage = "Facesso hat folgende Zeit�berschneidungen festgestellt" + System.Environment.NewLine + "weswegen die angegebenen Werte nachgearbeitet werden m�ssen:" + System.Environment.NewLine + System.Environment.NewLine + locMessage + System.Environment.NewLine + System.Environment.NewLine + "Bitte korrigieren Sie die Werte entsprechend!";
                MessageBox.Show(locMessage, "�bernahme nicht m�glich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public void UpdateUI()
        {
            if (nibDownTime.Value.IsNull)
            {
                nibDownTime.TypeSafeValue = 0;
            }

            if (ndbHandicap.Value.IsNull)
            {
                ndbHandicap.TypeSafeValue = 0;
            }

            if (nibWorkBreak.Value.IsNull)
            {
                nibWorkBreak.TypeSafeValue = 0;
            }

            if (ndbShiftStart.Value.IsNull | ndbShiftEnd.Value.IsNull)
            {
                ndbShiftStart.Value = null;
                ndbShiftEnd.Value = null;
                lblShiftStartDate.Text = myCPIs.ProductionDate.ToShortDateString();
                lblShiftEndDate.Text = btnShiftStart.Text;
                lblMinutesAttendance.Text = "- - -";
                lblMinutesEffective.Text = "- - -";
                lblMinutesEffectiveAdj.Text = "- - -";
                btnShiftStart.Text = "Dieser &Tag";
                btnShiftEnd.Text = "Dieser Ta&g";
                return;
            }

            myTimeLogItem.SetShiftTimes(ndbShiftStart.TypeSafeValue, ndbShiftEnd.TypeSafeValue, myCPIs.ProductionDate);
            myTimeLogItem.WorkBreak = nibWorkBreak.TypeSafeValue;
            myTimeLogItem.DownTime = nibDownTime.TypeSafeValue;
            myTimeLogItem.Handicap = ndbHandicap.TypeSafeValue;
            ndbShiftStart.TypeSafeValue = myTimeLogItem.ShiftStart;
            ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd;
            lblShiftStartDate.Text = myTimeLogItem.ShiftStart.ToShortDateString();
            lblShiftEndDate.Text = myTimeLogItem.ShiftEnd.ToShortDateString();
            lblMinutesAttendance.Text = myTimeLogItem.AttendanceTime.ToString();
            lblMinutesEffective.Text = myTimeLogItem.IncentiveWageTime.ToString();
            lblMinutesEffectiveAdj.Text = myTimeLogItem.IncentiveWageTimeAdj.ToString();
            lblMinutesWorkingTime.Text = myTimeLogItem.WorkingTime.ToString();
            if (myTimeLogItem.ProductionDate == myTimeLogItem.ShiftStart.Date)
            {
                btnShiftStart.Text = "Dieser &Tag";
            }
            else
            {
                btnShiftStart.Text = "Folge&tag";
            }

            if (myTimeLogItem.ProductionDate == myTimeLogItem.ShiftEnd.Date)
            {
                btnShiftEnd.Text = "Dieser Ta&g";
            }
            else
            {
                btnShiftEnd.Text = "Folgeta&g";
            }
        }

        //Falls die Events verschwinden!
        //Handles ndbShiftStart.Validated, ndbShiftEnd.Validated, nibDownTime.Validated, _
        //        nibHandicap.Validated, nibWorkBreak.Validated
        private void GenericValidated(System.Object sender, System.EventArgs e)
        {
            if (ndbShiftStart.Value.IsNull & ndbShiftEnd.Value.IsNull)
            {
                return;
            }

            if (ndbShiftStart.Value.HasValue & ndbShiftEnd.Value.IsNull)
            {
                ndbShiftEnd.Value = ndbShiftStart.Value;
            }

            if (ndbShiftEnd.Value.HasValue & ndbShiftStart.Value.IsNull)
            {
                ndbShiftStart.Value = ndbShiftEnd.Value;
            }

            if (ndbShiftEnd.TypeSafeValue < ndbShiftStart.TypeSafeValue)
            {
                if (sender == ndbShiftEnd)
                {
                    if (ndbShiftEnd.TypeSafeValue < ndbShiftStart.TypeSafeValue & ndbShiftStart.TypeSafeValue.TypedValue.Date == myCPIs.ProductionDate)
                    {
                        ndbShiftEnd.TypeSafeValue = ndbShiftEnd.TypeSafeValue.TypedValue.AddDays(1);
                    }
                }

                if (sender == ndbShiftStart)
                {
                    if (ndbShiftStart.TypeSafeValue > ndbShiftEnd.TypeSafeValue & ndbShiftEnd.TypeSafeValue.TypedValue.Date == myCPIs.ProductionDate.AddDays(1))
                    {
                        ndbShiftStart.TypeSafeValue = ndbShiftStart.TypeSafeValue.TypedValue.Subtract(new TimeSpan(1, 0, 0, 0));
                    }
                }
            }

            UpdateUI();
        }

        private void btnShiftStart_Click(System.Object sender, System.EventArgs e)
        {
            if (myTimeLogItem.ShiftStart.Date > myCPIs.ProductionDate.Date)
            {
                myTimeLogItem.ShiftStart = myCPIs.ProductionDate.Date + myTimeLogItem.ShiftStart.TimeOfDay;
                myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.Date + myTimeLogItem.ShiftEnd.TimeOfDay;
            }
            else
            {
                myTimeLogItem.ShiftStart = myCPIs.ProductionDate.Date.AddDays(1) + myTimeLogItem.ShiftStart.TimeOfDay;
                myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.Date.AddDays(1) + myTimeLogItem.ShiftEnd.TimeOfDay;
            }

            ndbShiftStart.TypeSafeValue = myTimeLogItem.ShiftStart;
            ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd;
            UpdateUI();
        }

        private void btnShiftEnd_Click(System.Object sender, System.EventArgs e)
        {
            if (myTimeLogItem.ShiftEnd.Date > myCPIs.ProductionDate.Date)
            {
                myTimeLogItem.ShiftEnd = myCPIs.ProductionDate + myTimeLogItem.ShiftEnd.TimeOfDay;
            }
            else
            {
                myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.AddDays(1) + myTimeLogItem.ShiftEnd.TimeOfDay;
            }

            ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd;
            UpdateUI();
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            if (myEmployeeInfoCollection != null)
            {
                myTimeLogItems = new EmployeeTimeLogInfo();
                foreach (EmployeeInfo locEi in myEmployeeInfoCollection)
                {
                    EmployeeTimeLogInfoItem locTimeLogItem = new EmployeeTimeLogInfoItem();
                    locTimeLogItem = myTimeLogItem.Clone();
                    locTimeLogItem.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser;
                    locTimeLogItem.EmployeeInfo = locEi;
                    locTimeLogItem.IDWorkGroup = myCPIs.WorkGroup.IDWorkGroup;
                    locTimeLogItem.InsertedByInterface = false;
                    locTimeLogItem.ManuallyEdited = true;
                    locTimeLogItem.Shift = myCPIs.Shift;
                    myTimeLogItems.Add(locTimeLogItem);
                }
            }
            else
            {
                foreach (EmployeeTimeLogInfoItem locLogItem in myTimeLogItems)
                {
                    locLogItem.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser;
                    locLogItem.ShiftStart = myTimeLogItem.ShiftStart;
                    locLogItem.ShiftEnd = myTimeLogItem.ShiftEnd;
                    locLogItem.WorkBreak = myTimeLogItem.WorkBreak;
                    locLogItem.DownTime = myTimeLogItem.DownTime;
                    locLogItem.Handicap = myTimeLogItem.Handicap;
                    locLogItem.ManuallyEdited = true;
                }
            }

            if (CheckForOverlaps())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public frmTimeLogItemCollection()
        {
            InitializeComponent();
        }
    }
}