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
    public partial class frmFacessoShell : Facesso.GenericControls.frmBaseFacesso
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacessoShell));
            this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.EmployeeInfoCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.TimerMain.Tick += TimerMain_Tick;
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslAdminInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslActiveEmployees = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslActiveWorkgroups = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCurrentDateAndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SplitEmployeesWorkGroups = new System.Windows.Forms.SplitContainer();
            this.splitWorkGroups = new System.Windows.Forms.SplitContainer();
            this.gbWorkGroups = new System.Windows.Forms.GroupBox();
            this.wglWorkGroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.wglWorkGroups.DoubleClick += wglWorkGroups_DoubleClick;
            this.wglWorkGroups.ItemSelectionChanged += wglWorkGroups_ItemSelectionChanged;
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWorkGroupResults = new Facesso.GenericControls.ucWorkGroupItemDetailsView();
            this.gbEmployees = new System.Windows.Forms.GroupBox();
            this.elvEmployees = new Facesso.GenericControls.ucEmployeeListView();
            this.elvEmployees.DoubleClick += elvEmployees_DoubleClick;
            this.TopLineLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentShift = new System.Windows.Forms.Label();
            this.lblCurrentWorkgroup = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mainChartOne = new Facesso.Functions.ucConfigurableWorkgroupChart();
            this.mainChartTwo = new Facesso.Functions.ucConfigurableWorkgroupChart();
            this.mainChartThree = new Facesso.Functions.ucConfigurableWorkgroupChart();
            this.ToolStripDateShiftSelector = new System.Windows.Forms.ToolStrip();
            this.ToolStripDateShiftSelector.MouseEnter += ToolStripDateShiftSelector_MouseEnter;
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.DateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportierenalsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportierenalsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseDataImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseDataImportToolStripMenuItem.Click += BaseDataImportToolStripMenuItem_Click;
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DruckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MitarbeiterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ProduktivSitesAnalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ProgrammbeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgrammbeendenToolStripMenuItem.Click += ProgrammbeendenToolStripMenuItem_Click;
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit_ProductionDataCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit_ProductionDataCollection.Click += tsmEdit_ProductionDataCollection_Click;
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit_EmployeeTimeBookings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit_SetMyReminder = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView_WorkGroupInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView_WorkGroupInfo.Click += tsmView_WorkGroupInfo_Click;
            this.tsmView_Employees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView_Employees.Click += tsmView_Employees_Click;
            this.FilternToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.tsmView_OnlyActiveWorkgroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView_OnlyActiveWorkgroups.Click += tsmView_OnlyActiveWorkgroups_Click;
            this.tsmView_OnlyActiveEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView_OnlyActiveEmployees.Click += tsmView_OnlyActiveEmployees_Click;
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmView_DockDateSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalyses_AnalysisWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalyses_AnalysisWizard.Click += ProduktivSitesAuswertungToolStripMenuItem_Click;
            this.tsmAnalyses_AnalysisManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalyses_AnalysisManager.Click += tsmAnalyses_AnalysisManager_Click;
            this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmArticleAmountAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmArticleAmountAnalysis.Click += tsmArticleAmountAnalysis_Click;
            this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.AusfallzeitenAnalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AusfallzeitenAnalyseToolStripMenuItem.Click += AusfallzeitenAnalyseToolStripMenuItem_Click;
            this.tsmCostCalculation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCostCalculation_IncentiveWageCalculation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCostCalculation_IncentiveWageCalculation.Click += tsmCostCalculation_IncentiveWageCalculation_Click;
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCostCalculation_CostOfEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCostCalculation_CostOfEmployees.Click += tsmCostCalculation_CostOfEmployees_Click;
            this.tsmCostCalculation_CostOfCostCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCostCalculation_CostOfCostCenter.Click += tsmCostCalculation_CostOfCostCenter_Click;
            this.tsmCostCalculation_CostOfWorkgroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCostCalculation_CostOfWorkgroups.Click += tsmCostCalculation_CostOfWorkgroups_Click;
            this.BaseDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_Subsidiaries = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_Subsidiaries.Click += tsmBaseData_Subsidiaries_Click;
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBaseData_Employees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_Employees.Click += tsmBaseData_Employees_Click;
            this.tsmBaseData_LabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_LabourValues.Click += tsmBaseData_LabourValues_Click;
            this.tsmBaseData_WorkGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_WorkGroups.Click += tsmBaseData_WorkGroups_Click;
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBaseData_CostCenters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_CostCenters.Click += tsmBaseData_CostCenters_Click;
            this.tsmBaseData_WageGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_WageGroups.Click += tsmBaseData_WageGroups_Click;
            this.tsmBaseData_BonusProgressions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBaseData_BonusProgressions.Click += tsmBaseData_BonusProgressions_Click;
            this.ExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDataImport.Click += tsmDataImport_Click;
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTools_UserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools_UserManagement.Click += tsmTools_UserManagement_Click;
            this.tsmTools_LoginInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.SupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SupportToolStripMenuItem.Click += SupportToolStripMenuItem_Click;
            this.ToolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTools_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools_Options.Click += tsbOptions_Click;
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelpAbout.Click += tsmHelpAbout_Click;
            this.ToolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbDataManager = new System.Windows.Forms.ToolStripButton();
            this.tsbDataManager.Click += tsmEdit_ProductionDataCollection_Click;
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbWorkGroupAnalysis = new System.Windows.Forms.ToolStripButton();
            this.tsbWorkGroupAnalysis.Click += tsbWorkGroupAnalysis_Click;
            this.tsbAnalysisIncentiveWage = new System.Windows.Forms.ToolStripButton();
            this.tsbAnalysisIncentiveWage.Click += tsbAnalysisIncentiveWage_Click;
            this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrevWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.tsbNextWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrevWorkDay = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevWorkDay.Click += tsbPrevWorkDay_Click;
            this.tsbMyTodoList = new System.Windows.Forms.ToolStripButton();
            this.tsbMyTodoList.Click += tsbMyTodoList_Click;
            this.tsbNextWorkDay = new System.Windows.Forms.ToolStripButton();
            this.tsbNextWorkDay.Click += tsbNextWorkDay_Click;
            this.ToolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBaseDataEmployee = new System.Windows.Forms.ToolStripButton();
            this.tsbBaseDataEmployee.Click += tsbBaseDataEmployee_Click;
            this.tsbBaseDataWorkGroups = new System.Windows.Forms.ToolStripButton();
            this.tsbBaseDataWorkGroups.Click += tsbBaseDataWorkGroups_Click;
            this.tsbBaseDataLabourValue = new System.Windows.Forms.ToolStripButton();
            this.tsbBaseDataLabourValue.Click += tsbBaseDataLabourValue_Click;
            this.ToolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBaseDataUser = new System.Windows.Forms.ToolStripButton();
            this.tsbBaseDataUser.Click += tsbBaseDataUser_Click;
            this.ToolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions.Click += tsbOptions_Click;
            ((System.ComponentModel.ISupportInitialize)this.EmployeeInfoCollectionBindingSource).BeginInit();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.SplitEmployeesWorkGroups).BeginInit();
            this.SplitEmployeesWorkGroups.Panel1.SuspendLayout();
            this.SplitEmployeesWorkGroups.Panel2.SuspendLayout();
            this.SplitEmployeesWorkGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitWorkGroups).BeginInit();
            this.splitWorkGroups.Panel1.SuspendLayout();
            this.splitWorkGroups.Panel2.SuspendLayout();
            this.splitWorkGroups.SuspendLayout();
            this.gbWorkGroups.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvWorkGroupResults).BeginInit();
            this.gbEmployees.SuspendLayout();
            this.TopLineLayoutPanel.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.SplitContainer2).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.MenuStripMain.SuspendLayout();
            this.ToolStripMain.SuspendLayout();
            this.SuspendLayout();
            //
            //ToolStripButton2
            //
            this.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton2.Image = ((System.Drawing.Image)resources.GetObject("ToolStripButton2.Image"));
            this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton2.Name = "ToolStripButton2";
            this.ToolStripButton2.Size = new System.Drawing.Size(23, 23);
            this.ToolStripButton2.Text = "ToolStripButton2";
            //
            //TimerMain
            //
            this.TimerMain.Interval = 1000;
            //
            //ToolStripContainer1
            //
            //
            //ToolStripContainer1.BottomToolStripPanel
            //
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip);
            //
            //ToolStripContainer1.ContentPanel
            //
            this.ToolStripContainer1.ContentPanel.AutoScroll = true;
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.TabControl1);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1126, 695);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //ToolStripContainer1.LeftToolStripPanel
            //
            this.ToolStripContainer1.LeftToolStripPanel.Controls.Add(this.ToolStripDateShiftSelector);
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(1152, 774);
            this.ToolStripContainer1.TabIndex = 7;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            //
            //ToolStripContainer1.TopToolStripPanel
            //
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.MenuStripMain);
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.ToolStripMain);
            //
            //StatusStrip
            //
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusStrip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ToolStripSplitButton1, this.tslAdminInfo, this.tslActiveEmployees, this.tslActiveWorkgroups, this.tslCurrentDateAndTime });
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 4, 19, 1);
            this.StatusStrip.Size = new System.Drawing.Size(1152, 30);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "StatusStrip1";
            //
            //ToolStripSplitButton1
            //
            this.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            this.ToolStripSplitButton1.Size = new System.Drawing.Size(0, 20);
            this.ToolStripSplitButton1.Text = "Sie sind angemeldet als: Administrator";
            //
            //tslAdminInfo
            //
            this.tslAdminInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslAdminInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslAdminInfo.Name = "tslAdminInfo";
            this.tslAdminInfo.Size = new System.Drawing.Size(190, 20);
            this.tslAdminInfo.Text = "Angemeldet als: Administrator ";
            //
            //tslActiveEmployees
            //
            this.tslActiveEmployees.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslActiveEmployees.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslActiveEmployees.Name = "tslActiveEmployees";
            this.tslActiveEmployees.Size = new System.Drawing.Size(199, 20);
            this.tslActiveEmployees.Text = "Aktive bzw. beteiligte Mitarbeiter";
            //
            //tslActiveWorkgroups
            //
            this.tslActiveWorkgroups.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslActiveWorkgroups.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslActiveWorkgroups.Name = "tslActiveWorkgroups";
            this.tslActiveWorkgroups.Size = new System.Drawing.Size(135, 20);
            this.tslActiveWorkgroups.Text = "Aktive Produktiv-Sites";
            //
            //tslCurrentDateAndTime
            //
            this.tslCurrentDateAndTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslCurrentDateAndTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslCurrentDateAndTime.Name = "tslCurrentDateAndTime";
            this.tslCurrentDateAndTime.Size = new System.Drawing.Size(608, 20);
            this.tslCurrentDateAndTime.Spring = true;
            this.tslCurrentDateAndTime.Text = "Current Date and Time";
            //
            //TabControl1
            //
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1126, 695);
            this.TabControl1.TabIndex = 2;
            //
            //TabPage1
            //
            this.TabPage1.Controls.Add(this.SplitEmployeesWorkGroups);
            this.TabPage1.Controls.Add(this.TopLineLayoutPanel);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1118, 666);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Tag = "SYSTEM";
            this.TabPage1.Text = "Bearbeitung";
            this.TabPage1.UseVisualStyleBackColor = true;
            //
            //SplitEmployeesWorkGroups
            //
            this.SplitEmployeesWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEmployeesWorkGroups.Location = new System.Drawing.Point(3, 67);
            this.SplitEmployeesWorkGroups.Name = "SplitEmployeesWorkGroups";
            this.SplitEmployeesWorkGroups.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //SplitEmployeesWorkGroups.Panel1
            //
            this.SplitEmployeesWorkGroups.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SplitEmployeesWorkGroups.Panel1.Controls.Add(this.splitWorkGroups);
            //
            //SplitEmployeesWorkGroups.Panel2
            //
            this.SplitEmployeesWorkGroups.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SplitEmployeesWorkGroups.Panel2.Controls.Add(this.gbEmployees);
            this.SplitEmployeesWorkGroups.Size = new System.Drawing.Size(1112, 596);
            this.SplitEmployeesWorkGroups.SplitterDistance = 262;
            this.SplitEmployeesWorkGroups.TabIndex = 1;
            this.SplitEmployeesWorkGroups.Text = "SplitContainer1";
            //
            //splitWorkGroups
            //
            this.splitWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitWorkGroups.Location = new System.Drawing.Point(0, 0);
            this.splitWorkGroups.Name = "splitWorkGroups";
            //
            //splitWorkGroups.Panel1
            //
            this.splitWorkGroups.Panel1.Controls.Add(this.gbWorkGroups);
            //
            //splitWorkGroups.Panel2
            //
            this.splitWorkGroups.Panel2.Controls.Add(this.GroupBox1);
            this.splitWorkGroups.Size = new System.Drawing.Size(1112, 262);
            this.splitWorkGroups.SplitterDistance = 688;
            this.splitWorkGroups.TabIndex = 0;
            this.splitWorkGroups.Text = "SplitContainer2";
            //
            //gbWorkGroups
            //
            this.gbWorkGroups.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.gbWorkGroups.Controls.Add(this.wglWorkGroups);
            this.gbWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbWorkGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.gbWorkGroups.Location = new System.Drawing.Point(0, 0);
            this.gbWorkGroups.Name = "gbWorkGroups";
            this.gbWorkGroups.Size = new System.Drawing.Size(688, 262);
            this.gbWorkGroups.TabIndex = 2;
            this.gbWorkGroups.TabStop = false;
            this.gbWorkGroups.Text = "Produktiv-Sites";
            //
            //wglWorkGroups
            //
            this.wglWorkGroups.AutoGroup = true;
            this.wglWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wglWorkGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.wglWorkGroups.FullRowSelect = true;
            this.wglWorkGroups.HideSelection = false;
            this.wglWorkGroups.Location = new System.Drawing.Point(3, 18);
            this.wglWorkGroups.Name = "wglWorkGroups";
            this.wglWorkGroups.OnlyActiveWorkgroups = true;
            this.wglWorkGroups.Size = new System.Drawing.Size(682, 241);
            this.wglWorkGroups.TabIndex = 0;
            this.wglWorkGroups.UseCompatibleStateImageBehavior = false;
            this.wglWorkGroups.View = System.Windows.Forms.View.Details;
            this.wglWorkGroups.WorkGroupInfoItems = null;
            this.wglWorkGroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.dgvWorkGroupResults);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(420, 262);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Produktiv-Site-Info:";
            //
            //dgvWorkGroupResults
            //
            this.dgvWorkGroupResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkGroupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkGroupResults.Location = new System.Drawing.Point(3, 18);
            this.dgvWorkGroupResults.Name = "dgvWorkGroupResults";
            this.dgvWorkGroupResults.Object = null;
            this.dgvWorkGroupResults.Size = new System.Drawing.Size(414, 241);
            this.dgvWorkGroupResults.TabIndex = 0;
            //
            //gbEmployees
            //
            this.gbEmployees.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.gbEmployees.Controls.Add(this.elvEmployees);
            this.gbEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.gbEmployees.Location = new System.Drawing.Point(0, 0);
            this.gbEmployees.Name = "gbEmployees";
            this.gbEmployees.Size = new System.Drawing.Size(1112, 330);
            this.gbEmployees.TabIndex = 2;
            this.gbEmployees.TabStop = false;
            this.gbEmployees.Text = "Mitarbeiter";
            //
            //elvEmployees
            //
            this.elvEmployees.AutoGroup = true;
            this.elvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elvEmployees.EmployeeInfoCollection = null;
            this.elvEmployees.EmployeeSortOrder = Facesso.GenericControls.EmployeeSortOrder.PersonnelNumber;
            this.elvEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.elvEmployees.FullRowSelect = true;
            this.elvEmployees.HideSelection = false;
            this.elvEmployees.Location = new System.Drawing.Point(3, 18);
            this.elvEmployees.Name = "elvEmployees";
            this.elvEmployees.OnlyActiveEmployees = true;
            this.elvEmployees.OnlyIncentiveEmployees = false;
            this.elvEmployees.Size = new System.Drawing.Size(1106, 309);
            this.elvEmployees.TabIndex = 0;
            this.elvEmployees.UseCompatibleStateImageBehavior = false;
            this.elvEmployees.View = System.Windows.Forms.View.Details;
            //
            //TopLineLayoutPanel
            //
            this.TopLineLayoutPanel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TopLineLayoutPanel.ColumnCount = 3;
            this.TopLineLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
            this.TopLineLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
            this.TopLineLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TopLineLayoutPanel.Controls.Add(this.lblCurrentShift, 0, 0);
            this.TopLineLayoutPanel.Controls.Add(this.lblCurrentWorkgroup, 0, 0);
            this.TopLineLayoutPanel.Controls.Add(this.lblCurrentDate, 0, 0);
            this.TopLineLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopLineLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.TopLineLayoutPanel.Name = "TopLineLayoutPanel";
            this.TopLineLayoutPanel.RowCount = 1;
            this.TopLineLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TopLineLayoutPanel.Size = new System.Drawing.Size(1112, 64);
            this.TopLineLayoutPanel.TabIndex = 2;
            //
            //lblCurrentShift
            //
            this.lblCurrentShift.AutoEllipsis = true;
            this.lblCurrentShift.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCurrentShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblCurrentShift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentShift.Location = new System.Drawing.Point(559, 3);
            this.lblCurrentShift.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentShift.Name = "lblCurrentShift";
            this.lblCurrentShift.Padding = new System.Windows.Forms.Padding(2);
            this.lblCurrentShift.Size = new System.Drawing.Size(550, 58);
            this.lblCurrentShift.TabIndex = 4;
            this.lblCurrentShift.Text = "Schicht 1 (06:15 - 12:15)";
            this.lblCurrentShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblCurrentWorkgroup
            //
            this.lblCurrentWorkgroup.AutoEllipsis = true;
            this.lblCurrentWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCurrentWorkgroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentWorkgroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentWorkgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblCurrentWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentWorkgroup.Location = new System.Drawing.Point(281, 3);
            this.lblCurrentWorkgroup.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentWorkgroup.Name = "lblCurrentWorkgroup";
            this.lblCurrentWorkgroup.Padding = new System.Windows.Forms.Padding(2);
            this.lblCurrentWorkgroup.Size = new System.Drawing.Size(272, 58);
            this.lblCurrentWorkgroup.TabIndex = 5;
            this.lblCurrentWorkgroup.Text = "Schicht 1 (06:15 - 12:15)";
            this.lblCurrentWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblCurrentDate
            //
            this.lblCurrentDate.AutoEllipsis = true;
            this.lblCurrentDate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCurrentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblCurrentDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentDate.Location = new System.Drawing.Point(3, 3);
            this.lblCurrentDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Padding = new System.Windows.Forms.Padding(2);
            this.lblCurrentDate.Size = new System.Drawing.Size(272, 58);
            this.lblCurrentDate.TabIndex = 0;
            this.lblCurrentDate.Text = "Montag, 23.2.2005";
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //TabPage2
            //
            this.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TabPage2.Controls.Add(this.SplitContainer1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1118, 669);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Tag = "SYSTEM";
            this.TabPage2.Text = "Überblick";
            //
            //SplitContainer1
            //
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //SplitContainer1.Panel1
            //
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
            //
            //SplitContainer1.Panel2
            //
            this.SplitContainer1.Panel2.Controls.Add(this.mainChartThree);
            this.SplitContainer1.Size = new System.Drawing.Size(1112, 663);
            this.SplitContainer1.SplitterDistance = 295;
            this.SplitContainer1.TabIndex = 1;
            //
            //SplitContainer2
            //
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            //
            //SplitContainer2.Panel1
            //
            this.SplitContainer2.Panel1.Controls.Add(this.mainChartOne);
            //
            //SplitContainer2.Panel2
            //
            this.SplitContainer2.Panel2.Controls.Add(this.mainChartTwo);
            this.SplitContainer2.Size = new System.Drawing.Size(1112, 295);
            this.SplitContainer2.SplitterDistance = 543;
            this.SplitContainer2.TabIndex = 0;
            //
            //mainChartOne
            //
            this.mainChartOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChartOne.Location = new System.Drawing.Point(0, 0);
            this.mainChartOne.Margin = new System.Windows.Forms.Padding(4);
            this.mainChartOne.Name = "mainChartOne";
            this.mainChartOne.Size = new System.Drawing.Size(543, 295);
            this.mainChartOne.TabIndex = 1;
            //
            //mainChartTwo
            //
            this.mainChartTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChartTwo.Location = new System.Drawing.Point(0, 0);
            this.mainChartTwo.Margin = new System.Windows.Forms.Padding(4);
            this.mainChartTwo.Name = "mainChartTwo";
            this.mainChartTwo.Size = new System.Drawing.Size(565, 295);
            this.mainChartTwo.TabIndex = 2;
            //
            //mainChartThree
            //
            this.mainChartThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChartThree.Location = new System.Drawing.Point(0, 0);
            this.mainChartThree.Margin = new System.Windows.Forms.Padding(4);
            this.mainChartThree.Name = "mainChartThree";
            this.mainChartThree.Size = new System.Drawing.Size(1112, 364);
            this.mainChartThree.TabIndex = 3;
            //
            //ToolStripDateShiftSelector
            //
            this.ToolStripDateShiftSelector.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStripDateShiftSelector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripDateShiftSelector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ToolStripDateShiftSelector.Location = new System.Drawing.Point(0, 0);
            this.ToolStripDateShiftSelector.Name = "ToolStripDateShiftSelector";
            this.ToolStripDateShiftSelector.Size = new System.Drawing.Size(26, 695);
            this.ToolStripDateShiftSelector.Stretch = true;
            this.ToolStripDateShiftSelector.TabIndex = 7;
            //
            //MenuStripMain
            //
            this.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStripMain.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DateiToolStripMenuItem, this.EditToolStripMenuItem, this.ViewToolStripMenuItem, this.AnalysisToolStripMenuItem, this.tsmCostCalculation, this.BaseDataToolStripMenuItem, this.ExtrasToolStripMenuItem, this.HelpToolStripMenuItem });
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStripMain.Size = new System.Drawing.Size(1152, 24);
            this.MenuStripMain.TabIndex = 0;
            this.MenuStripMain.Text = "MenuStrip1";
            //
            //DateiToolStripMenuItem
            //
            this.DateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ToolStripMenuItem8, this.ToolStripMenuItem7, this.ToolStripMenuItem5, this.ToolStripMenuItem6, this.ExportierenalsXMLToolStripMenuItem, this.ImportierenalsXMLToolStripMenuItem, this.BaseDataImportToolStripMenuItem, this.ToolStripSeparator1, this.DruckenToolStripMenuItem, this.ToolStripSeparator2, this.ProgrammbeendenToolStripMenuItem });
            this.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem";
            this.DateiToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.DateiToolStripMenuItem.Text = "&Datei";
            //
            //ToolStripMenuItem8
            //
            this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            this.ToolStripMenuItem8.Size = new System.Drawing.Size(222, 22);
            this.ToolStripMenuItem8.Text = "Neu anmelden...";
            //
            //ToolStripMenuItem7
            //
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            this.ToolStripMenuItem7.Size = new System.Drawing.Size(219, 6);
            //
            //ToolStripMenuItem5
            //
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(222, 22);
            this.ToolStripMenuItem5.Text = "Daten&sicherung...";
            //
            //ToolStripMenuItem6
            //
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(219, 6);
            //
            //ExportierenalsXMLToolStripMenuItem
            //
            this.ExportierenalsXMLToolStripMenuItem.Name = "ExportierenalsXMLToolStripMenuItem";
            this.ExportierenalsXMLToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ExportierenalsXMLToolStripMenuItem.Text = "&Exportieren als XML...";
            this.ExportierenalsXMLToolStripMenuItem.Visible = false;
            //
            //ImportierenalsXMLToolStripMenuItem
            //
            this.ImportierenalsXMLToolStripMenuItem.Name = "ImportierenalsXMLToolStripMenuItem";
            this.ImportierenalsXMLToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ImportierenalsXMLToolStripMenuItem.Text = "&Importieren als XML...";
            this.ImportierenalsXMLToolStripMenuItem.Visible = false;
            //
            //BaseDataImportToolStripMenuItem
            //
            this.BaseDataImportToolStripMenuItem.Name = "BaseDataImportToolStripMenuItem";
            this.BaseDataImportToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.BaseDataImportToolStripMenuItem.Text = "Stammdaten importieren...";
            //
            //ToolStripSeparator1
            //
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            //
            //DruckenToolStripMenuItem
            //
            this.DruckenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MitarbeiterToolStripMenuItem1, this.ProduktivSitesAnalyseToolStripMenuItem, this.ToolStripSeparator7 });
            this.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem";
            this.DruckenToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.DruckenToolStripMenuItem.Text = "Drucken";
            this.DruckenToolStripMenuItem.Visible = false;
            //
            //MitarbeiterToolStripMenuItem1
            //
            this.MitarbeiterToolStripMenuItem1.Name = "MitarbeiterToolStripMenuItem1";
            this.MitarbeiterToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.MitarbeiterToolStripMenuItem1.Text = "&Mitarbeiteranalyse...";
            //
            //ProduktivSitesAnalyseToolStripMenuItem
            //
            this.ProduktivSitesAnalyseToolStripMenuItem.Name = "ProduktivSitesAnalyseToolStripMenuItem";
            this.ProduktivSitesAnalyseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ProduktivSitesAnalyseToolStripMenuItem.Text = "&Produktiv-Sites-Analyse...";
            //
            //ToolStripSeparator7
            //
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(209, 6);
            //
            //ToolStripSeparator2
            //
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(219, 6);
            this.ToolStripSeparator2.Visible = false;
            //
            //ProgrammbeendenToolStripMenuItem
            //
            this.ProgrammbeendenToolStripMenuItem.Name = "ProgrammbeendenToolStripMenuItem";
            this.ProgrammbeendenToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ProgrammbeendenToolStripMenuItem.Text = "Programm be&enden";
            //
            //EditToolStripMenuItem
            //
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmEdit_ProductionDataCollection, this.ToolStripSeparator3, this.tsmEdit_EmployeeTimeBookings, this.ToolStripMenuItem3, this.tsmEdit_SetMyReminder });
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.EditToolStripMenuItem.Text = "&Bearbeiten";
            //
            //tsmEdit_ProductionDataCollection
            //
            this.tsmEdit_ProductionDataCollection.Name = "tsmEdit_ProductionDataCollection";
            this.tsmEdit_ProductionDataCollection.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmEdit_ProductionDataCollection.Size = new System.Drawing.Size(282, 22);
            this.tsmEdit_ProductionDataCollection.Text = "Datenmanager...";
            //
            //ToolStripSeparator3
            //
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(279, 6);
            //
            //tsmEdit_EmployeeTimeBookings
            //
            this.tsmEdit_EmployeeTimeBookings.Enabled = false;
            this.tsmEdit_EmployeeTimeBookings.Name = "tsmEdit_EmployeeTimeBookings";
            this.tsmEdit_EmployeeTimeBookings.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tsmEdit_EmployeeTimeBookings.Size = new System.Drawing.Size(282, 22);
            this.tsmEdit_EmployeeTimeBookings.Text = "Mitarbeiter-Einzelzeiten bearbeiten";
            //
            //ToolStripMenuItem3
            //
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(279, 6);
            //
            //tsmEdit_SetMyReminder
            //
            this.tsmEdit_SetMyReminder.Name = "tsmEdit_SetMyReminder";
            this.tsmEdit_SetMyReminder.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmEdit_SetMyReminder.Size = new System.Drawing.Size(282, 22);
            this.tsmEdit_SetMyReminder.Text = "Mein Merkdatum setzen...";
            //
            //ViewToolStripMenuItem
            //
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmView_WorkGroupInfo, this.tsmView_Employees, this.FilternToolStripMenuItem, this.tsmView_OnlyActiveWorkgroups, this.tsmView_OnlyActiveEmployees, this.ToolStripSeparator8, this.tsmView_DockDateSelector });
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ViewToolStripMenuItem.Text = "&Ansicht";
            //
            //tsmView_WorkGroupInfo
            //
            this.tsmView_WorkGroupInfo.Name = "tsmView_WorkGroupInfo";
            this.tsmView_WorkGroupInfo.Size = new System.Drawing.Size(266, 22);
            this.tsmView_WorkGroupInfo.Text = "&Produktiv-Site-Info";
            //
            //tsmView_Employees
            //
            this.tsmView_Employees.Checked = true;
            this.tsmView_Employees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmView_Employees.Name = "tsmView_Employees";
            this.tsmView_Employees.Size = new System.Drawing.Size(266, 22);
            this.tsmView_Employees.Text = "&Mitarbeiter";
            //
            //FilternToolStripMenuItem
            //
            this.FilternToolStripMenuItem.Name = "FilternToolStripMenuItem";
            this.FilternToolStripMenuItem.Size = new System.Drawing.Size(263, 6);
            //
            //tsmView_OnlyActiveWorkgroups
            //
            this.tsmView_OnlyActiveWorkgroups.Checked = true;
            this.tsmView_OnlyActiveWorkgroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmView_OnlyActiveWorkgroups.Name = "tsmView_OnlyActiveWorkgroups";
            this.tsmView_OnlyActiveWorkgroups.Size = new System.Drawing.Size(266, 22);
            this.tsmView_OnlyActiveWorkgroups.Text = "Nur aktive Produktiv-Sites anzeigen";
            //
            //tsmView_OnlyActiveEmployees
            //
            this.tsmView_OnlyActiveEmployees.Checked = true;
            this.tsmView_OnlyActiveEmployees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmView_OnlyActiveEmployees.Name = "tsmView_OnlyActiveEmployees";
            this.tsmView_OnlyActiveEmployees.Size = new System.Drawing.Size(266, 22);
            this.tsmView_OnlyActiveEmployees.Text = "Nur aktive Mitarbeiter anzeigen";
            //
            //ToolStripSeparator8
            //
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(263, 6);
            //
            //tsmView_DockDateSelector
            //
            this.tsmView_DockDateSelector.Checked = true;
            this.tsmView_DockDateSelector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmView_DockDateSelector.Enabled = false;
            this.tsmView_DockDateSelector.Name = "tsmView_DockDateSelector";
            this.tsmView_DockDateSelector.Size = new System.Drawing.Size(266, 22);
            this.tsmView_DockDateSelector.Text = "Datums-Selektor gedockt";
            //
            //AnalysisToolStripMenuItem
            //
            this.AnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmAnalyses_AnalysisWizard, this.tsmAnalyses_AnalysisManager, this.ToolStripMenuItem9, this.tsmArticleAmountAnalysis, this.ToolStripMenuItem10, this.AusfallzeitenAnalyseToolStripMenuItem });
            this.AnalysisToolStripMenuItem.Name = "AnalysisToolStripMenuItem";
            this.AnalysisToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.AnalysisToolStripMenuItem.Text = "Anal&ysen";
            //
            //tsmAnalyses_AnalysisWizard
            //
            this.tsmAnalyses_AnalysisWizard.Name = "tsmAnalyses_AnalysisWizard";
            this.tsmAnalyses_AnalysisWizard.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmAnalyses_AnalysisWizard.Size = new System.Drawing.Size(334, 22);
            this.tsmAnalyses_AnalysisWizard.Text = "Assistent für &Produktiv-Site-Analysen...";
            //
            //tsmAnalyses_AnalysisManager
            //
            this.tsmAnalyses_AnalysisManager.Name = "tsmAnalyses_AnalysisManager";
            this.tsmAnalyses_AnalysisManager.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F8));
            this.tsmAnalyses_AnalysisManager.Size = new System.Drawing.Size(334, 22);
            this.tsmAnalyses_AnalysisManager.Text = "Analysen-Manager für Produktiv-Sites...";
            //
            //ToolStripMenuItem9
            //
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            this.ToolStripMenuItem9.Size = new System.Drawing.Size(331, 6);
            //
            //tsmArticleAmountAnalysis
            //
            this.tsmArticleAmountAnalysis.Name = "tsmArticleAmountAnalysis";
            this.tsmArticleAmountAnalysis.Size = new System.Drawing.Size(334, 22);
            this.tsmArticleAmountAnalysis.Text = "&Produktionsergebnis-Analyse...";
            //
            //ToolStripMenuItem10
            //
            this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            this.ToolStripMenuItem10.Size = new System.Drawing.Size(331, 6);
            //
            //AusfallzeitenAnalyseToolStripMenuItem
            //
            this.AusfallzeitenAnalyseToolStripMenuItem.Name = "AusfallzeitenAnalyseToolStripMenuItem";
            this.AusfallzeitenAnalyseToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.AusfallzeitenAnalyseToolStripMenuItem.Text = "&Quick-Info...";
            //
            //tsmCostCalculation
            //
            this.tsmCostCalculation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmCostCalculation_IncentiveWageCalculation, this.ToolStripSeparator4, this.tsmCostCalculation_CostOfEmployees, this.tsmCostCalculation_CostOfCostCenter, this.tsmCostCalculation_CostOfWorkgroups });
            this.tsmCostCalculation.Name = "tsmCostCalculation";
            this.tsmCostCalculation.Size = new System.Drawing.Size(143, 20);
            this.tsmCostCalculation.Text = "&Kosten/Abrechnungen";
            //
            //tsmCostCalculation_IncentiveWageCalculation
            //
            this.tsmCostCalculation_IncentiveWageCalculation.Name = "tsmCostCalculation_IncentiveWageCalculation";
            this.tsmCostCalculation_IncentiveWageCalculation.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.tsmCostCalculation_IncentiveWageCalculation.Size = new System.Drawing.Size(237, 22);
            this.tsmCostCalculation_IncentiveWageCalculation.Text = "&Prämienlohnabrechnung...";
            //
            //ToolStripSeparator4
            //
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            //
            //tsmCostCalculation_CostOfEmployees
            //
            this.tsmCostCalculation_CostOfEmployees.Name = "tsmCostCalculation_CostOfEmployees";
            this.tsmCostCalculation_CostOfEmployees.Size = new System.Drawing.Size(237, 22);
            this.tsmCostCalculation_CostOfEmployees.Text = "&Mitarbeiterkosten...";
            //
            //tsmCostCalculation_CostOfCostCenter
            //
            this.tsmCostCalculation_CostOfCostCenter.Name = "tsmCostCalculation_CostOfCostCenter";
            this.tsmCostCalculation_CostOfCostCenter.Size = new System.Drawing.Size(237, 22);
            this.tsmCostCalculation_CostOfCostCenter.Text = "&Kostenstellen-Kosten...";
            //
            //tsmCostCalculation_CostOfWorkgroups
            //
            this.tsmCostCalculation_CostOfWorkgroups.Name = "tsmCostCalculation_CostOfWorkgroups";
            this.tsmCostCalculation_CostOfWorkgroups.Size = new System.Drawing.Size(237, 22);
            this.tsmCostCalculation_CostOfWorkgroups.Text = "&Arbeitsgruppen-Kosten...";
            //
            //BaseDataToolStripMenuItem
            //
            this.BaseDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmBaseData_Subsidiaries, this.ToolStripMenuItem4, this.tsmBaseData_Employees, this.tsmBaseData_LabourValues, this.tsmBaseData_WorkGroups, this.ToolStripSeparator5, this.tsmBaseData_CostCenters, this.tsmBaseData_WageGroups, this.tsmBaseData_BonusProgressions });
            this.BaseDataToolStripMenuItem.Name = "BaseDataToolStripMenuItem";
            this.BaseDataToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.BaseDataToolStripMenuItem.Text = "Basi&sdaten";
            //
            //tsmBaseData_Subsidiaries
            //
            this.tsmBaseData_Subsidiaries.Enabled = false;
            this.tsmBaseData_Subsidiaries.Name = "tsmBaseData_Subsidiaries";
            this.tsmBaseData_Subsidiaries.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_Subsidiaries.Text = "Niederlassungen...";
            //
            //ToolStripMenuItem4
            //
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(186, 6);
            //
            //tsmBaseData_Employees
            //
            this.tsmBaseData_Employees.Name = "tsmBaseData_Employees";
            this.tsmBaseData_Employees.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_Employees.Text = "Mitarbeiter...";
            //
            //tsmBaseData_LabourValues
            //
            this.tsmBaseData_LabourValues.Name = "tsmBaseData_LabourValues";
            this.tsmBaseData_LabourValues.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_LabourValues.Text = "REFA-Arbeitswerte...";
            //
            //tsmBaseData_WorkGroups
            //
            this.tsmBaseData_WorkGroups.Name = "tsmBaseData_WorkGroups";
            this.tsmBaseData_WorkGroups.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_WorkGroups.Text = "Produktiv-Sites...";
            //
            //ToolStripSeparator5
            //
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            //
            //tsmBaseData_CostCenters
            //
            this.tsmBaseData_CostCenters.Name = "tsmBaseData_CostCenters";
            this.tsmBaseData_CostCenters.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_CostCenters.Text = "&Kostenstellen...";
            //
            //tsmBaseData_WageGroups
            //
            this.tsmBaseData_WageGroups.Name = "tsmBaseData_WageGroups";
            this.tsmBaseData_WageGroups.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_WageGroups.Text = "&Lohngruppen...";
            //
            //tsmBaseData_BonusProgressions
            //
            this.tsmBaseData_BonusProgressions.Name = "tsmBaseData_BonusProgressions";
            this.tsmBaseData_BonusProgressions.Size = new System.Drawing.Size(189, 22);
            this.tsmBaseData_BonusProgressions.Text = "&Bonusprogression...";
            //
            //ExtrasToolStripMenuItem
            //
            this.ExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmDataImport, this.ToolStripSeparator9, this.tsmTools_UserManagement, this.tsmTools_LoginInfo, this.ToolStripSeparator6, this.SupportToolStripMenuItem, this.ToolStripSeparator16, this.tsmTools_Options });
            this.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem";
            this.ExtrasToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ExtrasToolStripMenuItem.Text = "&Extras";
            //
            //tsmDataImport
            //
            this.tsmDataImport.Name = "tsmDataImport";
            this.tsmDataImport.Size = new System.Drawing.Size(286, 22);
            this.tsmDataImport.Text = "Datenimport...";
            //
            //ToolStripSeparator9
            //
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(283, 6);
            //
            //tsmTools_UserManagement
            //
            this.tsmTools_UserManagement.Name = "tsmTools_UserManagement";
            this.tsmTools_UserManagement.Size = new System.Drawing.Size(286, 22);
            this.tsmTools_UserManagement.Text = "Facesso Benutzermanagement...";
            //
            //tsmTools_LoginInfo
            //
            this.tsmTools_LoginInfo.Enabled = false;
            this.tsmTools_LoginInfo.Name = "tsmTools_LoginInfo";
            this.tsmTools_LoginInfo.Size = new System.Drawing.Size(286, 22);
            this.tsmTools_LoginInfo.Text = "Anmeldeinformationen...";
            //
            //ToolStripSeparator6
            //
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(283, 6);
            //
            //SupportToolStripMenuItem
            //
            this.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem";
            this.SupportToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.SupportToolStripMenuItem.Text = "Support-Zugang (nur für AD-Support!)";
            //
            //ToolStripSeparator16
            //
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";
            this.ToolStripSeparator16.Size = new System.Drawing.Size(283, 6);
            //
            //tsmTools_Options
            //
            this.tsmTools_Options.Name = "tsmTools_Options";
            this.tsmTools_Options.Size = new System.Drawing.Size(286, 22);
            this.tsmTools_Options.Text = "&Optionen...";
            //
            //HelpToolStripMenuItem
            //
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ToolStripMenuItem1, this.ToolStripMenuItem2, this.tsmHelpAbout });
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.HelpToolStripMenuItem.Text = "&Hilfe";
            //
            //ToolStripMenuItem1
            //
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.ToolStripMenuItem1.Text = "Neuer Freischaltcode...";
            //
            //ToolStripMenuItem2
            //
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(197, 6);
            //
            //tsmHelpAbout
            //
            this.tsmHelpAbout.Name = "tsmHelpAbout";
            this.tsmHelpAbout.Size = new System.Drawing.Size(200, 22);
            this.tsmHelpAbout.Text = "&Info über Faceso...";
            //
            //ToolStripMain
            //
            this.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbDataManager, this.ToolStripSeparator10, this.tsbWorkGroupAnalysis, this.tsbAnalysisIncentiveWage, this.ToolStripSeparator11, this.tsbPrevWorkgroup, this.tsbNextWorkgroup, this.ToolStripSeparator12, this.tsbPrevWorkDay, this.tsbMyTodoList, this.tsbNextWorkDay, this.ToolStripSeparator13, this.tsbBaseDataEmployee, this.tsbBaseDataWorkGroups, this.tsbBaseDataLabourValue, this.ToolStripSeparator14, this.tsbBaseDataUser, this.ToolStripSeparator15, this.tsbOptions });
            this.ToolStripMain.Location = new System.Drawing.Point(3, 24);
            this.ToolStripMain.Name = "ToolStripMain";
            this.ToolStripMain.Size = new System.Drawing.Size(347, 25);
            this.ToolStripMain.TabIndex = 1;
            this.ToolStripMain.Text = "tsmDataManager";
            //
            //tsbDataManager
            //
            this.tsbDataManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDataManager.Image = ((System.Drawing.Image)resources.GetObject("tsbDataManager.Image"));
            this.tsbDataManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDataManager.Name = "tsbDataManager";
            this.tsbDataManager.Size = new System.Drawing.Size(23, 22);
            this.tsbDataManager.Text = "Datenmanager aufrufen";
            //
            //ToolStripSeparator10
            //
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            //
            //tsbWorkGroupAnalysis
            //
            this.tsbWorkGroupAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWorkGroupAnalysis.Image = ((System.Drawing.Image)resources.GetObject("tsbWorkGroupAnalysis.Image"));
            this.tsbWorkGroupAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWorkGroupAnalysis.Name = "tsbWorkGroupAnalysis";
            this.tsbWorkGroupAnalysis.Size = new System.Drawing.Size(23, 22);
            this.tsbWorkGroupAnalysis.Text = "Produktiv-Site-Analysen";
            //
            //tsbAnalysisIncentiveWage
            //
            this.tsbAnalysisIncentiveWage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnalysisIncentiveWage.Image = ((System.Drawing.Image)resources.GetObject("tsbAnalysisIncentiveWage.Image"));
            this.tsbAnalysisIncentiveWage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnalysisIncentiveWage.Name = "tsbAnalysisIncentiveWage";
            this.tsbAnalysisIncentiveWage.Size = new System.Drawing.Size(23, 22);
            this.tsbAnalysisIncentiveWage.Text = "Monatslohnabrechnung Mitarbeiter";
            //
            //ToolStripSeparator11
            //
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            this.ToolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            //
            //tsbPrevWorkgroup
            //
            this.tsbPrevWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbPrevWorkgroup.Image"));
            this.tsbPrevWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevWorkgroup.Name = "tsbPrevWorkgroup";
            this.tsbPrevWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbPrevWorkgroup.Text = "Vorherige Produktiv-Site";
            //
            //tsbNextWorkgroup
            //
            this.tsbNextWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbNextWorkgroup.Image"));
            this.tsbNextWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextWorkgroup.Name = "tsbNextWorkgroup";
            this.tsbNextWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbNextWorkgroup.Text = "Nächste Produktiv-Site";
            //
            //ToolStripSeparator12
            //
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            this.ToolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            //
            //tsbPrevWorkDay
            //
            this.tsbPrevWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevWorkDay.Image = ((System.Drawing.Image)resources.GetObject("tsbPrevWorkDay.Image"));
            this.tsbPrevWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevWorkDay.Name = "tsbPrevWorkDay";
            this.tsbPrevWorkDay.Size = new System.Drawing.Size(23, 22);
            this.tsbPrevWorkDay.Text = "vorheriger Arbeitstag";
            //
            //tsbMyTodoList
            //
            this.tsbMyTodoList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMyTodoList.Image = ((System.Drawing.Image)resources.GetObject("tsbMyTodoList.Image"));
            this.tsbMyTodoList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMyTodoList.Name = "tsbMyTodoList";
            this.tsbMyTodoList.Size = new System.Drawing.Size(23, 22);
            this.tsbMyTodoList.Text = "Meine To-do-Liste";
            //
            //tsbNextWorkDay
            //
            this.tsbNextWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextWorkDay.Image = ((System.Drawing.Image)resources.GetObject("tsbNextWorkDay.Image"));
            this.tsbNextWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextWorkDay.Name = "tsbNextWorkDay";
            this.tsbNextWorkDay.Size = new System.Drawing.Size(23, 22);
            this.tsbNextWorkDay.Text = "nächster Arbeitstag";
            //
            //ToolStripSeparator13
            //
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";
            this.ToolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            //
            //tsbBaseDataEmployee
            //
            this.tsbBaseDataEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBaseDataEmployee.Image = ((System.Drawing.Image)resources.GetObject("tsbBaseDataEmployee.Image"));
            this.tsbBaseDataEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBaseDataEmployee.Name = "tsbBaseDataEmployee";
            this.tsbBaseDataEmployee.Size = new System.Drawing.Size(23, 22);
            this.tsbBaseDataEmployee.Text = "Mitarbeiter-Stammdaten";
            //
            //tsbBaseDataWorkGroups
            //
            this.tsbBaseDataWorkGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBaseDataWorkGroups.Image = ((System.Drawing.Image)resources.GetObject("tsbBaseDataWorkGroups.Image"));
            this.tsbBaseDataWorkGroups.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBaseDataWorkGroups.Name = "tsbBaseDataWorkGroups";
            this.tsbBaseDataWorkGroups.Size = new System.Drawing.Size(23, 22);
            this.tsbBaseDataWorkGroups.Text = "Produktiv-Site-Manager";
            this.tsbBaseDataWorkGroups.ToolTipText = "Produktiv-Site-Manager";
            //
            //tsbBaseDataLabourValue
            //
            this.tsbBaseDataLabourValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBaseDataLabourValue.Image = ((System.Drawing.Image)resources.GetObject("tsbBaseDataLabourValue.Image"));
            this.tsbBaseDataLabourValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBaseDataLabourValue.Name = "tsbBaseDataLabourValue";
            this.tsbBaseDataLabourValue.Size = new System.Drawing.Size(23, 22);
            this.tsbBaseDataLabourValue.Text = "REFA-Arbeitswert-Stammdaten";
            //
            //ToolStripSeparator14
            //
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";
            this.ToolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            //
            //tsbBaseDataUser
            //
            this.tsbBaseDataUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBaseDataUser.Image = ((System.Drawing.Image)resources.GetObject("tsbBaseDataUser.Image"));
            this.tsbBaseDataUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBaseDataUser.Name = "tsbBaseDataUser";
            this.tsbBaseDataUser.Size = new System.Drawing.Size(23, 22);
            this.tsbBaseDataUser.Text = "Benutzerverwaltung";
            //
            //ToolStripSeparator15
            //
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";
            this.ToolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            //
            //tsbOptions
            //
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.Image = ((System.Drawing.Image)resources.GetObject("tsbOptions.Image"));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(23, 22);
            this.tsbOptions.Text = "Optionen";
            //
            //frmFacessoShell
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 774);
            this.Controls.Add(this.ToolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Location = new System.Drawing.Point(40, 40);
            this.MainMenuStrip = this.MenuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(656, 550);
            this.Name = "frmFacessoShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Facesso Shell";
            ((System.ComponentModel.ISupportInitialize)this.EmployeeInfoCollectionBindingSource).EndInit();
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.SplitEmployeesWorkGroups.Panel1.ResumeLayout(false);
            this.SplitEmployeesWorkGroups.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.SplitEmployeesWorkGroups).EndInit();
            this.SplitEmployeesWorkGroups.ResumeLayout(false);
            this.splitWorkGroups.Panel1.ResumeLayout(false);
            this.splitWorkGroups.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitWorkGroups).EndInit();
            this.splitWorkGroups.ResumeLayout(false);
            this.gbWorkGroups.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvWorkGroupResults).EndInit();
            this.gbEmployees.ResumeLayout(false);
            this.TopLineLayoutPanel.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.SplitContainer2).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.ToolStripMain.ResumeLayout(false);
            this.ToolStripMain.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.MenuStrip MenuStripMain;
        internal System.Windows.Forms.ToolStrip ToolStripMain;
        internal System.Windows.Forms.StatusStrip StatusStrip;
        internal System.Windows.Forms.ToolStripMenuItem DateiToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExportierenalsXMLToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ImportierenalsXMLToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem DruckenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem ProgrammbeendenToolStripMenuItem;

        internal System.Windows.Forms.ToolStripMenuItem AnalysisToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmCostCalculation;
        internal System.Windows.Forms.ToolStripMenuItem BaseDataToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmHelpAbout;

        internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmView_OnlyActiveWorkgroups;

        internal System.Windows.Forms.ToolStripSeparator FilternToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmView_OnlyActiveEmployees;

        internal System.Windows.Forms.ToolStripMenuItem tsmEdit_ProductionDataCollection;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem tsmCostCalculation_IncentiveWageCalculation;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem tsmCostCalculation_CostOfEmployees;

        internal System.Windows.Forms.ToolStripMenuItem tsmCostCalculation_CostOfCostCenter;

        internal System.Windows.Forms.ToolStripMenuItem tsmCostCalculation_CostOfWorkgroups;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_Employees;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_LabourValues;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_WorkGroups;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_CostCenters;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_WageGroups;

        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_BonusProgressions;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem ExtrasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmTools_UserManagement;

        internal System.Windows.Forms.ToolStripMenuItem tsmTools_LoginInfo;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripMenuItem tsmTools_Options;

        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem6;
        internal System.Windows.Forms.ToolStripMenuItem tsmBaseData_Subsidiaries;

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem tsmAnalyses_AnalysisWizard;

        internal System.Windows.Forms.ToolStripMenuItem MitarbeiterToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ProduktivSitesAnalyseToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton2;
        internal System.Windows.Forms.ToolStrip ToolStripDateShiftSelector;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        internal System.Windows.Forms.ToolStripMenuItem tsmView_DockDateSelector;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripSplitButton1;
        internal System.Windows.Forms.ToolStripStatusLabel tslAdminInfo;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem8;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem7;
        internal System.Windows.Forms.ToolStripMenuItem BaseDataImportToolStripMenuItem;

        internal System.Windows.Forms.BindingSource EmployeeInfoCollectionBindingSource;
        internal System.Windows.Forms.ToolStripMenuItem tsmView_WorkGroupInfo;

        internal System.Windows.Forms.ToolStripMenuItem tsmView_Employees;

        internal System.Windows.Forms.ToolStripMenuItem tsmEdit_EmployeeTimeBookings;
        internal System.Windows.Forms.ToolStripButton tsbDataManager;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
        internal System.Windows.Forms.ToolStripButton tsbWorkGroupAnalysis;

        internal System.Windows.Forms.ToolStripButton tsbAnalysisIncentiveWage;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator11;
        internal System.Windows.Forms.ToolStripButton tsbNextWorkgroup;
        internal System.Windows.Forms.ToolStripButton tsbPrevWorkgroup;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator12;
        internal System.Windows.Forms.ToolStripButton tsbPrevWorkDay;

        internal System.Windows.Forms.ToolStripButton tsbMyTodoList;

        internal System.Windows.Forms.ToolStripButton tsbNextWorkDay;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator13;
        internal System.Windows.Forms.ToolStripButton tsbBaseDataEmployee;

        internal System.Windows.Forms.ToolStripButton tsbBaseDataWorkGroups;

        internal System.Windows.Forms.ToolStripButton tsbBaseDataLabourValue;

        internal System.Windows.Forms.ToolStripButton tsbBaseDataUser;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator14;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator15;
        internal System.Windows.Forms.ToolStripButton tsbOptions;

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem tsmEdit_SetMyReminder;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem9;
        internal System.Windows.Forms.ToolStripStatusLabel tslActiveEmployees;
        internal System.Windows.Forms.ToolStripStatusLabel tslActiveWorkgroups;
        internal System.Windows.Forms.ToolStripStatusLabel tslCurrentDateAndTime;
        internal System.Windows.Forms.Timer TimerMain;

        internal System.Windows.Forms.ToolStripMenuItem tsmAnalyses_AnalysisManager;

        internal System.Windows.Forms.ToolStripMenuItem tsmDataImport;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
        internal System.Windows.Forms.ToolStripMenuItem tsmArticleAmountAnalysis;

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem10;
        internal System.Windows.Forms.ToolStripMenuItem AusfallzeitenAnalyseToolStripMenuItem;

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TableLayoutPanel TopLineLayoutPanel;
        internal System.Windows.Forms.Label lblCurrentShift;
        internal System.Windows.Forms.Label lblCurrentWorkgroup;
        internal System.Windows.Forms.Label lblCurrentDate;
        internal System.Windows.Forms.SplitContainer SplitEmployeesWorkGroups;
        internal System.Windows.Forms.SplitContainer splitWorkGroups;
        internal System.Windows.Forms.GroupBox gbWorkGroups;
        internal Facesso.GenericControls.ucWorkGroupListView wglWorkGroups;

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal Facesso.GenericControls.ucWorkGroupItemDetailsView dgvWorkGroupResults;
        internal System.Windows.Forms.GroupBox gbEmployees;
        internal Facesso.GenericControls.ucEmployeeListView elvEmployees;

        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal Facesso.Functions.ucConfigurableWorkgroupChart mainChartOne;
        internal Facesso.Functions.ucConfigurableWorkgroupChart mainChartTwo;
        internal Facesso.Functions.ucConfigurableWorkgroupChart mainChartThree;
        internal System.Windows.Forms.ToolStripMenuItem SupportToolStripMenuItem;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator16;
    }
}