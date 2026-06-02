using Facesso.Data;
using Facesso.Functions;
using Facesso.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Facesso
{
    public partial class frmFacessoShell
    {
        private ToolStripLabel myTsDateLabel;
        private ToolStripLabel myTsShiftLabel;
        private ShiftToolStripButton[] myTsShiftButtons;
        private ToolStripSeparator myTsSeparator;
        private Font myStandardFont;
        private Font myBoldFont;
        private bool myDoNothing;

        // Where are those backing fields?
        // See frmFacessoShell_WithEventsBackingFields.cs for the WithEvents-style backing fields and
        // their wrapping properties (_myTsmCalender, _myTsNextWorkday, _myTsPreviousWorkday,
        // _myTsTodoList, _myWindowsControl). They were moved there to keep this file easier to read.

        private EmployeeInfoItems myEmployees;
        private WorkGroupInfoItems myWorkGroups;
        private System.DateTime myOldSelectedDate;
        private FacessoGeneralOptions myFacessoGeneralOptions;
        public frmFacessoShell()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            myCombinedParameters = new CombinedParametersInfo()
            {
                Shift = 1,
                ProductionDate = DateTime.Now
            };
            myStandardFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            myBoldFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            myTsDateLabel = new ToolStripLabel("Arbeitstagdatum")
            {
                Font = myBoldFont
            };
            myTsmCalender = new ToolStripMonthCalender();
            myTsShiftLabel = new ToolStripLabel("Schicht");
            myTsShiftLabel.Font = myBoldFont;
            myTsShiftButtons = new ShiftToolStripButton[]
            {
                new ShiftToolStripButton("1", null, "1:", "Shift1", ShiftButtons_Click),
                new ShiftToolStripButton("2", null, "2:", "Shift2", ShiftButtons_Click),
                new ShiftToolStripButton("3", null, "3:", "Shift3", ShiftButtons_Click),
                new ShiftToolStripButton("S", null, "S:", "Shift4", ShiftButtons_Click)
            };
            foreach (ToolStripButton locTsShiftButton in myTsShiftButtons)
            {
                locTsShiftButton.AutoSize = false;
                locTsShiftButton.Height = 30;
                locTsShiftButton.Width = 200;
                locTsShiftButton.Font = myStandardFont;
                locTsShiftButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
                locTsShiftButton.Text = "";
                locTsShiftButton.TextAlign = ContentAlignment.MiddleCenter;
            }

            myTsNextWorkday = new ToolStripButton("Nächster Arbeitstag >>");
            myTsNextWorkday.Font = myStandardFont;
            myTsPreviousWorkday = new ToolStripButton("<< Vorheriger Arbeitstag");
            myTsPreviousWorkday.Font = myStandardFont;
            myTsTodoList = new ToolStripButton("Meine To-do-Liste");
            myTsTodoList.Font = myStandardFont;
            {
                var __with0 = ToolStripDateShiftSelector.Items;
                __with0.Add(myTsDateLabel);
                __with0.Add(myTsmCalender);
                __with0.Add(new ToolStripSeparator());
                __with0.Add(myTsNextWorkday);
                __with0.Add(myTsPreviousWorkday);
                __with0.Add(myTsTodoList);
                __with0.Add(new ToolStripSeparator());
                __with0.Add(myTsShiftLabel);
                __with0.AddRange(myTsShiftButtons);
            }
        }

        private void ToolStripDateShiftSelector_MouseEnter(System.Object sender, System.EventArgs e)
        {
            ToolStripDateShiftSelector.Select();
        }

        private void myTsmCalender_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            if (myOldSelectedDate == e.Start)
            {
                return;
            }

            UpdateCombinedParameters(false);
            myOldSelectedDate = e.Start;
        }

        private void ShiftButtons_Click(object sender, EventArgs e)
        {
            if (sender.ToString() == "Shift1")
            {
                myCombinedParameters.Shift = 1;
            }

            if (sender.ToString() == "Shift2")
            {
                myCombinedParameters.Shift = 2;
            }

            if (sender.ToString() == "Shift3")
            {
                myCombinedParameters.Shift = 3;
            }

            if (sender.ToString() == "Shift4")
            {
                myCombinedParameters.Shift = 4;
            }

            UpdateCombinedParameters(false);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.Location = ((Point)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowLocation", this.Location));
            this.Size = ((Size)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowSize", this.Size));
            myWindowsControl = new FacessoShellWindowsControl(true, true, true, true, true);
            myWindowsControl.WorkgroupSplitterDistance = splitWorkGroups.SplitterDistance;
            myWindowsControl.EmpWorkgroupSplitterDistance = SplitEmployeesWorkGroups.SplitterDistance;
            myWindowsControl = ((FacessoShellWindowsControl)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowsControl", this.myWindowsControl));
            splitWorkGroups.SplitterDistance = myWindowsControl.WorkgroupSplitterDistance;
            SplitEmployeesWorkGroups.SplitterDistance = myWindowsControl.EmpWorkgroupSplitterDistance;
            myEmployees = new EmployeeInfoItems(0);
            UpdateCombinedParameters(false);
            tslAdminInfo.Text = "Angemeldet: " + FacessoGeneric.LoginInfo.Username + " an " + FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName;
            tslAdminInfo.ToolTipText = "Benutzer " + FacessoGeneric.LoginInfo.Username + " an " + FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName + "seit " + System.DateTime.Now.ToLongDateString() + " - " + System.DateTime.Now.ToLongTimeString() + " Uhr.";
            ApplyWindowsControlChanges();
            TimerMain.Enabled = true;
            wglWorkGroups.OnlyActiveWorkgroups = myWindowsControl.OnlyShowActiveWorkGroups;
            elvEmployees.OnlyActiveEmployees = myWindowsControl.OnlyShowActiveEmployees;
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
            //TODO: Wieder einblenden - nur ausgeblendet, weil der Start zu lange dauert.
            AssignChartAnalysises();
            ScheduleScreenshotCaptureIfRequested();
        }

        /// <summary>
        /// If the FACESSO_SCREENSHOT_PATH environment variable is set,
        /// maximizes the form and schedules a DrawToBitmap capture after a
        /// short delay. DrawToBitmap renders via a memory DC and works in
        /// headless / container environments where cross-process PrintWindow
        /// produces black images.
        /// </summary>
        private void ScheduleScreenshotCaptureIfRequested()
        {
            var screenshotPath = Environment.GetEnvironmentVariable("FACESSO_SCREENSHOT_PATH");
            if (string.IsNullOrEmpty(screenshotPath))
            {
                return;
            }

            this.WindowState = FormWindowState.Maximized;
            Timer captureTimer = new Timer()
            {
                Interval = 3000
            };
            captureTimer.Tick += (s, ev) =>
            {
                ((Timer)s).Stop();
                ((Timer)s).Dispose();
                try
                {
                    using (var bmp = new Bitmap(this.Width, this.Height))
                    {
                        this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                        var dir = System.IO.Path.GetDirectoryName(screenshotPath);
                        if (!(string.IsNullOrEmpty(dir)))
                        {
                            System.IO.Directory.CreateDirectory(dir);
                        }

                        bmp.Save(screenshotPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                catch
                {
                }
            };
            captureTimer.Start();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            SaveChartAnalysisChanges();
            myWindowsControl.WorkgroupSplitterDistance = splitWorkGroups.SplitterDistance;
            myWindowsControl.EmpWorkgroupSplitterDistance = SplitEmployeesWorkGroups.SplitterDistance;
            base.OnClosed(e);
            {
                var __with1 = FacessoGeneric.FacessoUserSettings;
                if (!(this.WindowState == FormWindowState.Minimized))
                {
                    __with1.Settings.SetItem("FacessoShellWindowLocation", this.Location);
                    __with1.Settings.SetItem("FacessoShellWindowSize", this.Size);
                }

                __with1.Settings.SetItem("FacessoShellWindowsControl", this.myWindowsControl);
            }

            FacessoGeneric.SaveAllSettings();
            TimerMain.Enabled = false;
        }

        private void BaseDataImportToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            frmTSImport locfrm = new frmTSImport();
            locfrm.ShowDialog();
        }

        private void tsmBaseData_CostCenters_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmCostcenterInfoCenter locFH = FunctionHandler<GetFrmCostcenterInfoCenter>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        private void tsmBaseData_BonusProgressions_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmBonusListMaintenance locFH = FunctionHandler<GetFrmBonusListMaintenance>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        private void tsmBaseData_WageGroups_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWageGroupInfoCenter locFh = FunctionHandler<GetFrmWageGroupInfoCenter>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsmBaseData_Employees_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmEmployeeInfoCenter locFh = FunctionHandler<GetFrmEmployeeInfoCenter>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsmBaseData_LabourValues_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmLabourValueInfoCenter locFh = FunctionHandler<GetFrmLabourValueInfoCenter>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
            UpdateCombinedParameters(false);
        }

        private void tsmBaseData_WorkGroups_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupManager locFh = FunctionHandler<GetFrmWorkGroupManager>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
            UpdateCombinedParameters(false);
        }

        private void tsmTools_UserManagement_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmUserInfoCenter locFH = FunctionHandler<GetFrmUserInfoCenter>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        private void tsmEdit_ProductionDataCollection_Click(System.Object sender, System.EventArgs e)
        {
            if ((myCombinedParameters != null) && (!(myCombinedParameters.WorkGroup.IsActive)))
            {
                MessageBox.Show("Sie können keine Datenerfassung für eine inaktive Produktiv-Site durchführen!", "Datenerfassung nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GetFrmProductionDataCollector locFh = FunctionHandler<GetFrmProductionDataCollector>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog(myCombinedParameters);
            UpdateCombinedParameters(false);
        }

        private void wglWorkGroups_DoubleClick(System.Object sender, System.EventArgs e)
        {
            if (wglWorkGroups.SelectedIndices.Count > 0)
            {
                myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup;
            }
            else
            {
                myCombinedParameters.WorkGroup = null;
            }

            if ((myCombinedParameters != null) && (!(myCombinedParameters.WorkGroup.IsActive)))
            {
                MessageBox.Show("Sie können keine Datenerfassung für eine inaktive Produktiv-Site durchführen!", "Datenerfassung nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GetFrmProductionDataCollector locFh = FunctionHandler<GetFrmProductionDataCollector>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog(myCombinedParameters);
            UpdateCombinedParameters(false);
        }

        private void tsmBaseData_Subsidiaries_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmSubsidiaryManager locFh = FunctionHandler<GetFrmSubsidiaryManager>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsmCostCalculation_IncentiveWageCalculation_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmIncentiveWageCalc locFh = FunctionHandler<GetFrmIncentiveWageCalc>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void ProduktivSitesAuswertungToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupAnalysis locFh = FunctionHandler<GetFrmWorkGroupAnalysis>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsmCostCalculation_CostOfEmployees_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!");
        }

        private void tsmCostCalculation_CostOfCostCenter_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!");
        }

        private void tsmCostCalculation_CostOfWorkgroups_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!");
        }

        private void myWindowsControl_WindowsControlSettingsChange(object sender, System.EventArgs e)
        {
            ApplyWindowsControlChanges();
        }

        private void ApplyWindowsControlChanges()
        {
            tsmView_OnlyActiveEmployees.Checked = myWindowsControl.OnlyShowActiveEmployees;
            tsmView_OnlyActiveWorkgroups.Checked = myWindowsControl.OnlyShowActiveWorkGroups;
            tsmView_WorkGroupInfo.Checked = myWindowsControl.ShowWorkGroupInfo;
            tsmView_Employees.Checked = myWindowsControl.ShowEmployees;
            splitWorkGroups.Panel2Collapsed = !(myWindowsControl.ShowWorkGroupInfo);
            SplitEmployeesWorkGroups.Panel2Collapsed = !(myWindowsControl.ShowEmployees);
            if (!(wglWorkGroups.OnlyActiveWorkgroups == myWindowsControl.OnlyShowActiveWorkGroups))
            {
                wglWorkGroups.OnlyActiveWorkgroups = myWindowsControl.OnlyShowActiveWorkGroups;
            }

            if (!(elvEmployees.OnlyActiveEmployees == myWindowsControl.OnlyShowActiveEmployees))
            {
                elvEmployees.OnlyActiveEmployees = myWindowsControl.OnlyShowActiveEmployees;
            }
        }

        private void UserChangedWindowsControlSettings()
        {
            myWindowsControl.OnlyShowActiveWorkGroups = tsmView_OnlyActiveWorkgroups.Checked;
            myWindowsControl.OnlyShowActiveEmployees = tsmView_OnlyActiveEmployees.Checked;
            myWindowsControl.ShowWorkGroupInfo = tsmView_WorkGroupInfo.Checked;
            myWindowsControl.ShowEmployees = tsmView_Employees.Checked;
            tslActiveWorkgroups.Text = myWindowsControl.WorkGroupStateDisplayString();
            tslActiveEmployees.Text = myWindowsControl.EmployeeStateDisplayString();
        }

        private void tsmView_WorkGroupInfo_Click(System.Object sender, System.EventArgs e)
        {
            tsmView_WorkGroupInfo.Checked = !(tsmView_WorkGroupInfo.Checked);
            UserChangedWindowsControlSettings();
        }

        private void tsmView_Employees_Click(System.Object sender, System.EventArgs e)
        {
            tsmView_Employees.Checked = !(tsmView_Employees.Checked);
            UserChangedWindowsControlSettings();
        }

        private void tsmView_OnlyActiveWorkgroups_Click(System.Object sender, System.EventArgs e)
        {
            tsmView_OnlyActiveWorkgroups.Checked = !(tsmView_OnlyActiveWorkgroups.Checked);
            UserChangedWindowsControlSettings();
        }

        private void tsmView_OnlyActiveEmployees_Click(System.Object sender, System.EventArgs e)
        {
            tsmView_OnlyActiveEmployees.Checked = !(tsmView_OnlyActiveEmployees.Checked);
            UserChangedWindowsControlSettings();
        }

        private void tsbWorkGroupAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupAnalysis locFh = FunctionHandler<GetFrmWorkGroupAnalysis>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsbAnalysisIncentiveWage_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmIncentiveWageCalc locFh = FunctionHandler<GetFrmIncentiveWageCalc>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsbBaseDataEmployee_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmEmployeeInfoCenter locFh = FunctionHandler<GetFrmEmployeeInfoCenter>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
        }

        private void tsbBaseDataWorkGroups_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmWorkGroupManager locFh = FunctionHandler<GetFrmWorkGroupManager>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
            UpdateCombinedParameters(false);
        }

        private void tsbBaseDataLabourValue_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmLabourValueInfoCenter locFh = FunctionHandler<GetFrmLabourValueInfoCenter>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
            UpdateCombinedParameters(false);
        }

        private void tsbBaseDataUser_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmUserInfoCenter locFH = FunctionHandler<GetFrmUserInfoCenter>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        private void tsbOptions_Click(System.Object sender, System.EventArgs e)
        {
            GetFrmOptions locFh = FunctionHandler<GetFrmOptions>.GetFunctionInstance();
            if (locFh == null)
            {
                return;
            }

            locFh.ShowDialog();
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
        }

        private void tsbPrevWorkDay_Click(System.Object sender, System.EventArgs e)
        {
            myTsmCalender.Value = ActiveDev.Dates.PreviousWorkday(myTsmCalender.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
        }

        private void tsbMyTodoList_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht nur in der Enterprise-Edition zur Verfügung", "Nicht implementiert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbNextWorkDay_Click(System.Object sender, System.EventArgs e)
        {
            myTsmCalender.Value = ActiveDev.Dates.NextWorkday(myTsmCalender.Value, myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday);
        }

        private void TimerMain_Tick(System.Object sender, System.EventArgs e)
        {
            tslCurrentDateAndTime.Text = System.DateTime.Now.ToLongDateString() + " - " + System.DateTime.Now.ToLongTimeString();
        }

        private void tsmAnalyses_AnalysisManager_Click(System.Object sender, System.EventArgs e)
        {
            frmWorkGroupAnalysisManager locFrm = new frmWorkGroupAnalysisManager();
            locFrm.ShowDialog();
        }

        private void ProgrammbeendenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tsmDataImport_Click(System.Object sender, System.EventArgs e)
        {
            frmImport locFrm = new frmImport();
            locFrm.ShowDialog();
        }

        private void elvEmployees_DoubleClick(System.Object sender, System.EventArgs e)
        {
            if (elvEmployees.SelectedIndices.Count > 0)
            {
                frmEmployeeTimeList locFrm = new frmEmployeeTimeList();
                locFrm.ShowDialog(elvEmployees.FirstSelectedEmployee, myCombinedParameters.ProductionDate);
            }
        }

        private void tsmHelpAbout_Click(System.Object sender, System.EventArgs e)
        {
            new frmInfo().ShowDialog();
        }

        private void tsmArticleAmountAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            //TODO: In Berechtigungsmechanismus einbinden
            frmProductionAmountAnalysis locfrm = new frmProductionAmountAnalysis();
            locfrm.ShowDialog();
        }

        private void AusfallzeitenAnalyseToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!");
        }

        private void SupportToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            frmHiddenTestAndAdmin frm = new frmHiddenTestAndAdmin();
            frm.ShowDialog();
        }
    }

    public class ShiftToolStripButton : ToolStripButton
    {
        private string myShiftText;
        private Font myShiftTextFont = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);
        private bool myEmphasized;
        public ShiftToolStripButton() : base()
        {
        }

        public ShiftToolStripButton(string text, Image image, string ShiftText, string Name, System.EventHandler onClick) : base(text, image, onClick)
        {
            myShiftText = ShiftText;
            this.Name = Name;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Font locUsedFont = default(Font);
            base.OnPaint(e);
            Graphics locGraphics = e.Graphics;
            SizeF locTextSize = locGraphics.MeasureString(myShiftText, myShiftTextFont, Size.Width);
            if (this.Emphasized)
            {
                locUsedFont = new Font(myShiftTextFont, FontStyle.Bold);
            }
            else
            {
                locUsedFont = myShiftTextFont;
            }

            locGraphics.DrawString(myShiftText, locUsedFont, Brushes.Black, 10, System.Convert.ToSingle(Size.Height / 2 - locTextSize.Height / 2));
        }

        public string ShiftText
        {
            get
            {
                return myShiftText;
            }

            set
            {
                myShiftText = value;
                this.Invalidate();
            }
        }

        public Font ShiftTextFont
        {
            get
            {
                return myShiftTextFont;
            }

            set
            {
                myShiftTextFont = value;
                this.Invalidate();
            }
        }

        public bool Emphasized
        {
            get
            {
                return myEmphasized;
            }

            set
            {
                myEmphasized = value;
                if (value)
                {
                    this.Font = new Font(this.Font, FontStyle.Bold);
                }
                else
                {
                    this.Font = new Font(this.Font, FontStyle.Regular);
                }

                this.Invalidate();
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}