using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmWorkGroupPrintBaseData
    {
        public void ShowDialog(bool PrintOnlyListOfLabourValue)
        {
            if (PrintOnlyListOfLabourValue)
            {
                optOnlyPrintWorkgroups.Checked = true;
                SetCheckBoxes(false);
            }
            else
            {
                optPrintWorkgroups.Checked = true;
                chkPrintAssignedLabourValues.Checked = true;
                SetCheckBoxes(true);
            }

            this.ShowDialog();
        }

        private void SetCheckBoxes(bool state)
        {
            chkPrintAssignedLabourValues.Enabled = state;
            chkPrintShiftTimes.Enabled = state;
            chkVisualieProductivityHistory.Enabled = state;
        }

        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            WorkgroupBaseDataPrintParameters locParameters = new WorkgroupBaseDataPrintParameters();
            {
                var __with0 = locParameters;
                if (optOnlyPrintWorkgroups.Checked)
                {
                    __with0.OnlyPrintListOfLabourValues = true;
                }
                else
                {
                    __with0.PrintWorkgroups = true;
                    __with0.PrintAssignedLabourValues = chkPrintAssignedLabourValues.Checked;
                    __with0.PrintShiftTimes = chkPrintShiftTimes.Checked;
                    if (!(chkVisualieProductivityHistory.Checked))
                    {
                        __with0.VisualizeProductivityHistory = -1;
                    }
                    else
                    {
                        __with0.VisualizeProductivityHistory = System.Convert.ToInt32(nudMonths.Value);
                    }
                }
            }

            FacPrintWorkgroupBaseData locPrintEngine = new FacPrintWorkgroupBaseData(locParameters, FacessoGeneric.LoginInfo.Username);
            locPrintEngine.ProcessDocument(Facesso.Data.AnalysisTarget.PreviewBeforePrint);
            this.Close();
        }

        public frmWorkGroupPrintBaseData()
        {
            InitializeComponent();
        }
    }
}