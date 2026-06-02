using Facesso;
using Facesso.Data;
using Facesso.Functions;
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
    public partial class frmWorkGroupManager
    {
        private WorkGroupInfo myCurrentWorkGroup;
        private LabourValueInfoCollection myLabourValueList;
        public void HandleDialog()
        {
            string locError = "";
            if (!(SPAccess.GetInstance().Basedata_DoLabourValuesExist()))
            {
                locError = "* Es sind keine REFA-Arbeitswertstammdaten eingerichtet!" + System.Environment.NewLine + System.Environment.NewLine;
            }

            if (locError != "")
            {
                MessageBox.Show("Datenerfassung ist noch nicht m�glich:" + System.Environment.NewLine + System.Environment.NewLine + locError + System.Environment.NewLine + "Bitte f�hren Sie zun�chst die Stammdaten erfassung durch!", "Datenerfassung nicht m�glich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.ShowDialog();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            myLabourValueList = SPAccess.GetInstance().GetLabourValueInfoCollection();
            BuildLabourValuesForAssignment();
            this.wglSetup.WorkGroupInfoItems = new WorkGroupInfoItems(true);
            this.wglSetup.MultiSelect = false;
            HandleControlsEnabling();
        }

        private void btnNewWorkGroup_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupInfoAdd locFH = FunctionHandler<GetFrmWorkGroupInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
            BuildLabourValuesForAssignment();
            this.wglSetup.WorkGroupInfoItems = new WorkGroupInfoItems(true);
        }

        private void wglSetup_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            myCurrentWorkGroup = wglSetup.FirstSelectedWorkGroup;
            if (myCurrentWorkGroup != null)
            {
                lblSelectedWorkgroup.Text = myCurrentWorkGroup.WorkGroupNumber.ToString() + ": " + myCurrentWorkGroup.WorkGroupName;
                lvlAssigned.LabourValues = LabourValueInfoCollection.GetWorkGroupAssignedLabourValues(FacessoGeneric.LoginInfo.IDSubsidiary, myCurrentWorkGroup);
                BuildLabourValuesForAssignment();
                HandleControlsEnabling();
            }
            else
            {
                lvlAssigned.LabourValues = null;
            }
        }

        private void lvlToAssign_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            HandleControlsEnabling();
        }

        private void HandleControlsEnabling()
        {
            if (lvlAssigned.SelectedIndices.Count > 0)
            {
                btnDeleteFromAssignment.Enabled = true;
                tsbUnassignLabourValues.Enabled = true;
                tsmUnAssignLabourValues.Enabled = true;
            }
            else
            {
                btnDeleteFromAssignment.Enabled = false;
                tsbUnassignLabourValues.Enabled = false;
                tsmUnAssignLabourValues.Enabled = false;
            }

            if (lvlToAssign.SelectedIndices.Count > 0)
            {
                if (wglSetup.SelectedIndices.Count > 0)
                {
                    btnAssignToWorkGroup.Enabled = true;
                    tsbAssignLabourValues.Enabled = true;
                    tsmAssignLabourValues.Enabled = true;
                    return;
                }
            }

            btnAssignToWorkGroup.Enabled = false;
            tsbAssignLabourValues.Enabled = false;
            tsmAssignLabourValues.Enabled = false;
        }

        private void btnAssignToWorkGroup_Click(System.Object sender, System.EventArgs e)
        {
            if (lvlAssigned.LabourValues == null)
            {
                lvlAssigned.LabourValues = new LabourValueInfoCollection();
            }

            foreach (LabourValueInfo locSourceItem in lvlToAssign.SelectedLabourValues)
            {
                lvlAssigned.LabourValues.Add(locSourceItem);
            }

            lvlAssigned.LabourValues = lvlAssigned.LabourValues;
            BuildLabourValuesForAssignment();
            SPAccess.GetInstance().AssignLabourValuesToWorkGroup(FacessoGeneric.LoginInfo.IDSubsidiary, myCurrentWorkGroup.IDWorkGroup, this.lvlAssigned.LabourValues);
        }

        public void BuildLabourValuesForAssignment()
        {
            LabourValueInfoCollection locToAssignList = new LabourValueInfoCollection();
            foreach (LabourValueInfo locItem in myLabourValueList)
            {
                locToAssignList.Add(locItem);
            }

            if (lvlAssigned.LabourValues != null)
            {
                foreach (LabourValueInfo locDestItem in lvlAssigned.LabourValues)
                {
                    locToAssignList.Remove(new ActiveDev.IntKey(locDestItem.IDLabourValue));
                }
            }

            lvlToAssign.LabourValues = locToAssignList;
            HandleControlsEnabling();
        }

        private void btnDeleteFromAssignment_Click(System.Object sender, System.EventArgs e)
        {
            foreach (LabourValueInfo locItem in lvlAssigned.SelectedLabourValues)
            {
                lvlAssigned.LabourValues.Remove(new ActiveDev.IntKey(locItem.IDLabourValue));
            }

            lvlAssigned.LabourValues = lvlAssigned.LabourValues;
            BuildLabourValuesForAssignment();
            SPAccess.GetInstance().AssignLabourValuesToWorkGroup(FacessoGeneric.LoginInfo.IDSubsidiary, myCurrentWorkGroup.IDWorkGroup, this.lvlAssigned.LabourValues);
        }

        private void lvlAssigned_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            HandleControlsEnabling();
        }

        private void OKToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void tsmEditWorkgroupData_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupInfoEdit locFH = FunctionHandler<GetFrmWorkGroupInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog(myCurrentWorkGroup);
            BuildLabourValuesForAssignment();
            this.wglSetup.WorkGroupInfoItems = new WorkGroupInfoItems(true);
        }

        private void tsmGroupLabourValues_Click(System.Object sender, System.EventArgs e)
        {
            if (tsmGroupLabourValues.Checked)
            {
                tsmGroupLabourValues.Checked = false;
                lvlToAssign.AutoGroup = false;
            }
            else
            {
                tsmGroupLabourValues.Checked = true;
                lvlToAssign.AutoGroup = true;
            }
        }

        private void tsmShowQuickStartButtons_Click(System.Object sender, System.EventArgs e)
        {
            if (tsmShowQuickStartButtons.Checked)
            {
                tsmShowQuickStartButtons.Checked = false;
                splitLabourValuesQuickButtons.Panel2Collapsed = true;
            }
            else
            {
                tsmShowQuickStartButtons.Checked = true;
                splitLabourValuesQuickButtons.Panel2Collapsed = false;
            }
        }

        private void tsbDeleteWorkgroup_Click(System.Object sender, System.EventArgs e)
        {
            DeleteWorkGroup();
        }

        private void tsmDeleteWorkgroup_Click(System.Object sender, System.EventArgs e)
        {
            DeleteWorkGroup();
        }

        private void DeleteWorkGroup()
        {
            WorkGroupInfo locWorkGroup = wglSetup.FirstSelectedWorkGroup;
            if (locWorkGroup == null)
            {
                MessageBox.Show("Bitte w�hlen Sie zun�chst eine Produktiv-Site aus der unteren, linken Liste aus", "Fehlende Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GetFuncWorkGroupDelete locFH = FunctionHandler<GetFuncWorkGroupDelete>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.DeleteItem(locWorkGroup);
            BuildLabourValuesForAssignment();
            this.wglSetup.WorkGroupInfoItems = new WorkGroupInfoItems(true);
        }

        private void tsmPrintWorkGroup_Click(System.Object sender, System.EventArgs e)
        {
            frmWorkGroupPrintBaseData locFrm = new frmWorkGroupPrintBaseData();
            locFrm.ShowDialog(false);
        }

        public frmWorkGroupManager()
        {
            InitializeComponent();
        }
    }
}