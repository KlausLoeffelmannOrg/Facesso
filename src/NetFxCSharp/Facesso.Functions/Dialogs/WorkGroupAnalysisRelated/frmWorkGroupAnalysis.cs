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
    public partial class frmWorkGroupAnalysis
    {
        //Wizard-Handler
        private ADWizardController _myWizardController;
        private ADWizardController myWizardController
        {
            get
            {
                return _myWizardController;
            }

            set
            {
                if (_myWizardController != null)
                {
                    _myWizardController.Cancel -= myWizardController_Cancel;
                    _myWizardController.Finished -= myWizardController_Finished;
                    _myWizardController.StepChanged -= myWizardController_StepChanged;
                }

                _myWizardController = value;
                if (_myWizardController != null)
                {
                    _myWizardController.Cancel += myWizardController_Cancel;
                    _myWizardController.Finished += myWizardController_Finished;
                    _myWizardController.StepChanged += myWizardController_StepChanged;
                }
            }
        }

        private WorkGroupAnalysisParameters myAnalysisParameters;
        private bool myOnlyGetParameters;
        private FacessoGeneralOptions myFacessoGeneralOptions;
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
            {
                var __with0 = lstDestFields.Items;
                __with0.Clear();
                __with0.Add("Arbeitsgruppenname");
                __with0.Add("Gesamt-Referenzzeit");
                __with0.Add("Gesamt-Effektivzeit");
                __with0.Add("Gesamt-Effektivzeit (ang.)");
                __with0.Add("Gesamt-Ausfallzeit");
                __with0.Add("Gesamt-Pausenzeit");
                __with0.Add("Zeitgrad");
                __with0.Add("Zeitgrad (ang.)");
            }

            wglWorkGroups.WorkGroupInfoItems = new WorkGroupInfoItems(true);
            foreach (ListViewItem locItem in wglWorkGroups.Items)
            {
                locItem.Selected = true;
            }

            if (myAnalysisParameters != null)
            {
                FromAnalysisParameters();
            }

            if (myFacessoGeneralOptions.SaturdayIsWorkday)
            {
                this.drpMain.LastWorkingday = LastWorkingdays.Saturday;
            }
            else if (myFacessoGeneralOptions.SundayIsWorkday)
            {
                this.drpMain.LastWorkingday = LastWorkingdays.Sunday;
            }

            myWizardController = new ADWizardController(btnBack, btnNext, btnCancel, tcWizard);
            myWizardController.Initialize();
        }

        public WorkGroupAnalysisParameters GetAnalysisParameters()
        {
            myOnlyGetParameters = true;
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
            myOnlyGetParameters = true;
            myAnalysisParameters = wgap;
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

        private void myWizardController_Cancel(object sender, System.EventArgs e)
        {
            string locMessage = "Sind Sie sicher, dass Sie den Assistenten abbrechen m�chten?";
            DialogResult locdr = MessageBox.Show(locMessage, "Assistenten beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (locdr == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void myWizardController_Finished(object sender, System.EventArgs e)
        {
            if (myOnlyGetParameters)
            {
                ToAnalysisParameters();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }

            DialogResult locDR = MessageBox.Show("M�chten Sie die Auswertung durchf�hren (Abbrechen kehrt zur�ck zum Ausgangsdialog)?", "Auswertung durchf�hren?", MessageBoxButtons.YesNoCancel);
            if (locDR == System.Windows.Forms.DialogResult.Cancel)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (locDR == System.Windows.Forms.DialogResult.Yes)
            {
                ToAnalysisParameters();
                WorkGroupAnalysisPerformer locAnalysisPerformer = new WorkGroupAnalysisPerformer(myAnalysisParameters);
                locAnalysisPerformer.PerformAnalysis();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void myWizardController_StepChanged(object sender, ActiveDev.ADWizardStepChangeEventArgs e)
        {
            if (e.NewStepNo == 4 & e.WizardStepAction == ADWizardStepAction.NextStep & (!(optCSVExport.Checked)))
            {
                e.WizardStepAction = ADWizardStepAction.SkipAllRemainingSteps;
            }

            e.NextStepAllowed = true;
            ToAnalysisParameters();
            txtConclusion.Text = myAnalysisParameters.Description();
        }

        private void ToAnalysisParameters()
        {
            if (myAnalysisParameters == null)
            {
                myAnalysisParameters = new WorkGroupAnalysisParameters();
            }

            {
                var __with1 = myAnalysisParameters;
                __with1.DateRange = drpMain.DateRangeValue;
                __with1.ShiftParameters = new ShiftParameters(chkShift1.Checked, chkShift2.Checked, chkShift3.Checked, chkShift4.Checked, optUseAlternatingShifts.Checked, System.Convert.ToInt32(nudAltShiftDays.Value), System.Convert.ToInt32(nudAltShift1.Value), System.Convert.ToInt32(nudAltShift2.Value));
                __with1.WorkGroups = wglWorkGroups.SelectedWorkGroups;
                if (optDetailed.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.Detailed;
                }
                else if (optBatch.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.Batch;
                }
                else if (optWorkGroupListShiftCondensed.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftCondensed;
                }
                else if (optWorkGroupListShiftWise.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwise;
                }
                else if (optWorkGroupListShiftwiseCompressed.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed;
                }
                else if (optAnalysisLine.Checked)
                {
                    __with1.AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad;
                }

                __with1.IncludeSuspended = chkIncludeSuspended.Checked;
                //TODO: Hier im Bedarfsfall wieder ein Kontrollk�stchen einf�gen und abfragen.
                __with1.IncludeWorkLoad = false;
                //TODO: Fieldassignments speichern
                if (optTargetPrinter.Checked)
                {
                    __with1.AnalysisTarget = AnalysisTarget.DirectlyToPrinter;
                }
                else if (optPreviewBeforePrint.Checked)
                {
                    __with1.AnalysisTarget = AnalysisTarget.PreviewBeforePrint;
                }
                else if (optCSVExport.Checked)
                {
                    __with1.AnalysisTarget = AnalysisTarget.CSVExport;
                }
            }
        }

        private void FromAnalysisParameters()
        {
            {
                var __with2 = myAnalysisParameters;
                drpMain.DateRangeValue = __with2.DateRange;
                chkShift1.Checked = __with2.ShiftParameters.ConsiderShift1;
                chkShift2.Checked = __with2.ShiftParameters.ConsiderShift2;
                chkShift3.Checked = __with2.ShiftParameters.ConsiderShift3;
                chkShift4.Checked = __with2.ShiftParameters.ConsiderShift4;
                optUseAlternatingShifts.Checked = __with2.ShiftParameters.AlternateShifts;
                nudAltShiftDays.Value = __with2.ShiftParameters.DaysAfterToAlternate;
                nudAltShift1.Value = __with2.ShiftParameters.AlternatingFirstShift;
                nudAltShift2.Value = __with2.ShiftParameters.AlternatingSecondShift;
                //Vorselektieren
                foreach (ListViewItem locLvw in wglWorkGroups.Items)
                {
                    locLvw.Selected = false;
                }

                foreach (int locItem in myAnalysisParameters.SelectedWorkgroups)
                {
                    foreach (ListViewItem locLvw in wglWorkGroups.Items)
                    {
                        if (int.Parse(locLvw.Name) == locItem)
                        {
                            locLvw.Selected = true;
                        }
                    }
                }

                {
                    var __select3 = (int)(__with2.AnalysisType);
                    if (__select3 == (int)(WorkgroupAnalysisType.Batch))
                    {
                        optBatch.Checked = true;
                    }
                    else if (__select3 == (int)(WorkgroupAnalysisType.WorkGroupListShiftCondensed))
                    {
                        optWorkGroupListShiftCondensed.Checked = true;
                    }
                    else if (__select3 == (int)(WorkgroupAnalysisType.Detailed))
                    {
                        optDetailed.Checked = true;
                    }
                    else if (__select3 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad))
                    {
                        optAnalysisLine.Checked = true;
                    }
                    else if (__select3 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwise))
                    {
                        optWorkGroupListShiftWise.Checked = true;
                    }
                    else if (__select3 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed))
                    {
                        optWorkGroupListShiftwiseCompressed.Checked = true;
                    }
                }

                chkIncludeSuspended.Checked = __with2.IncludeSuspended;
                //Todo: Das im Bedarfsfall wieder reaktivieren, damit
                //chkIncludeWorkload.Checked = False
                //TODO: Fieldassignments zuordnen
                {
                    var __select4 = (int)(__with2.AnalysisTarget);
                    if (__select4 == (int)(AnalysisTarget.DirectlyToPrinter))
                    {
                        optTargetPrinter.Checked = true;
                    }
                    else if (__select4 == (int)(AnalysisTarget.PreviewBeforePrint))
                    {
                        optPreviewBeforePrint.Checked = true;
                    }
                    else if (__select4 == (int)(AnalysisTarget.CSVExport))
                    {
                        optCSVExport.Checked = true;
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

        public frmWorkGroupAnalysis()
        {
            InitializeComponent();
        }
    }
}