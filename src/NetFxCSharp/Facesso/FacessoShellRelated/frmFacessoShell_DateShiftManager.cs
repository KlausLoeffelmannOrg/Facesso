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

namespace Facesso
{
    public partial class frmFacessoShell
    {
        private CombinedParametersInfo myCombinedParameters;
        private int myOldIDWorkGroup;
        private string myCurrentEmpGroupname;
        private void UpdateCombinedParameters(bool DontUpdateWorkGroup)
        {
            if (wglWorkGroups.WorkGroupInfoItems != null)
            {
                myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup;
            }
            else
            {
                myCombinedParameters.WorkGroup = null;
            }

            if (elvEmployees.EmployeeInfoCollection != null)
            {
                myCombinedParameters.EmployeeInfo = elvEmployees.FirstSelectedEmployee;
            }
            else
            {
                myCombinedParameters.EmployeeInfo = null;
            }

            myCombinedParameters.ProductionDate = myTsmCalender.MonthCalendarControl.SelectionStart;
            UpdateUI(DontUpdateWorkGroup);
        }

        private void UpdateUI(bool DontUpdateWorkgroup)
        {
            lblCurrentDate.Text = myCombinedParameters.ProductionDate.ToString("ddd, dd. MMM yyyy");
            if (myCombinedParameters.Shift == 4)
            {
                lblCurrentShift.Text = "Sonderschicht " + myCombinedParameters.ShiftText();
            }
            else
            {
                lblCurrentShift.Text = "S" + myCombinedParameters.Shift + ": " + myCombinedParameters.ShiftText();
            }

            if (myCombinedParameters.WorkGroup == null)
            {
                lblCurrentWorkgroup.Text = "- keine Site ausgewählt -";
            }
            else
            {
                lblCurrentWorkgroup.Text = myCombinedParameters.WorkGroup.ListItemText;
            }

            for (int z = 0; z <= 3; z++)
            {
                myTsShiftButtons[z].Text = myCombinedParameters.ShiftText(System.Convert.ToByte(z + 1));
                if (myCombinedParameters.Shift == (z + 1))
                {
                    myTsShiftButtons[z].Emphasized = true;
                }
                else
                {
                    myTsShiftButtons[z].Emphasized = false;
                }
            }

            if (!(DontUpdateWorkgroup))
            {
                RebuildWorkGroup();
            }

            if (myCombinedParameters.WorkGroup != null)
            {
                WorkGroupAnalysisInfoItem locwgr = new WorkGroupAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, myCombinedParameters);
                dgvWorkGroupResults.Object = locwgr;
            }
            else
            {
                dgvWorkGroupResults.Object = null;
            }
        }

        private void RebuildWorkGroup()
        {
            myWorkGroups = new WorkGroupInfoItems(myCombinedParameters);
            wglWorkGroups.WorkGroupInfoItems = myWorkGroups;
            if (elvEmployees.EmployeeInfoCollection == null)
            {
                elvEmployees.EmployeeInfoCollection = myEmployees;
            }

            if (myWorkGroups != null)
            {
                if (myWorkGroups.Count > 0)
                {
                    wglWorkGroups.Items[0].Selected = true;
                }
            }
        }

        private void wglWorkGroups_ItemSelectionChanged(System.Object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup;
                UpdateCombinedParameters(true);
                ResetWorkedEmployees();
            }
        }

        private void ResetWorkedEmployees()
        {
            if (myCombinedParameters.WorkGroup != null)
            {
                if (myCombinedParameters.WorkGroup.HasProductionData)
                {
                    elvEmployees.DeleteCustomGroup(myCurrentEmpGroupname, false);
                    EmployeeInfoItems locSiteEmployees = new EmployeeInfoItems(myCombinedParameters);
                    if (locSiteEmployees.Count > 0)
                    {
                        myCurrentEmpGroupname = "Beteiligte Mitarbeiter in Site: " + myCombinedParameters.WorkGroup.WorkGroupName;
                        elvEmployees.SetCustomGroup(myCurrentEmpGroupname, locSiteEmployees);
                        return;
                    }
                }
                else
                {
                    elvEmployees.DeleteCustomGroup(myCurrentEmpGroupname, true);
                }
            }
        }
    }
}