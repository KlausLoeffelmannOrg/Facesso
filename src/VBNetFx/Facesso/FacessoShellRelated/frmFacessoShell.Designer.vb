<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmFacessoShell
    Inherits Facesso.FrontEnd.frmBaseFacesso

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacessoShell))
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.EmployeeInfoCollectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslAdminInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslActiveEmployees = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslActiveWorkgroups = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslCurrentDateAndTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitEmployeesWorkGroups = New System.Windows.Forms.SplitContainer()
        Me.splitWorkGroups = New System.Windows.Forms.SplitContainer()
        Me.gbWorkGroups = New System.Windows.Forms.GroupBox()
        Me.wglWorkGroups = New Facesso.FrontEnd.ucWorkGroupListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvWorkGroupResults = New Facesso.FrontEnd.ucWorkGroupItemDetailsView()
        Me.gbEmployees = New System.Windows.Forms.GroupBox()
        Me.elvEmployees = New Facesso.FrontEnd.ucEmployeeListView()
        Me.TopLineLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCurrentShift = New System.Windows.Forms.Label()
        Me.lblCurrentWorkgroup = New System.Windows.Forms.Label()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.mainChartOne = New Facesso.Functions.ucConfigurableWorkgroupChart()
        Me.mainChartTwo = New Facesso.Functions.ucConfigurableWorkgroupChart()
        Me.mainChartThree = New Facesso.Functions.ucConfigurableWorkgroupChart()
        Me.ToolStripDateShiftSelector = New System.Windows.Forms.ToolStrip()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportierenalsXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportierenalsXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDataImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MitarbeiterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProduktivSitesAnalyseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProgrammbeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEdit_ProductionDataCollection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmEdit_EmployeeTimeBookings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmEdit_SetMyReminder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmView_WorkGroupInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmView_Employees = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilternToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmView_OnlyActiveWorkgroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmView_OnlyActiveEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmView_DockDateSelector = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAnalyses_AnalysisWizard = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAnalyses_AnalysisManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmArticleAmountAnalysis = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.AusfallzeitenAnalyseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCostCalculation = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCostCalculation_IncentiveWageCalculation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmCostCalculation_CostOfEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCostCalculation_CostOfCostCenter = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCostCalculation_CostOfWorkgroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBaseData_Subsidiaries = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmBaseData_Employees = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBaseData_LabourValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBaseData_WorkGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmBaseData_CostCenters = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBaseData_WageGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBaseData_BonusProgressions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDataImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmTools_UserManagement = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmTools_LoginInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmTools_Options = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.tsbDataManager = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbWorkGroupAnalysis = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnalysisIncentiveWage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevWorkgroup = New System.Windows.Forms.ToolStripButton()
        Me.tsbNextWorkgroup = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrevWorkDay = New System.Windows.Forms.ToolStripButton()
        Me.tsbMyTodoList = New System.Windows.Forms.ToolStripButton()
        Me.tsbNextWorkDay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbBaseDataEmployee = New System.Windows.Forms.ToolStripButton()
        Me.tsbBaseDataWorkGroups = New System.Windows.Forms.ToolStripButton()
        Me.tsbBaseDataLabourValue = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbBaseDataUser = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton()
        CType(Me.EmployeeInfoCollectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.LeftToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitEmployeesWorkGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitEmployeesWorkGroups.Panel1.SuspendLayout()
        Me.SplitEmployeesWorkGroups.Panel2.SuspendLayout()
        Me.SplitEmployeesWorkGroups.SuspendLayout()
        CType(Me.splitWorkGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitWorkGroups.Panel1.SuspendLayout()
        Me.splitWorkGroups.Panel2.SuspendLayout()
        Me.splitWorkGroups.SuspendLayout()
        Me.gbWorkGroups.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvWorkGroupResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmployees.SuspendLayout()
        Me.TopLineLayoutPanel.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'TimerMain
        '
        Me.TimerMain.Interval = 1000
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.AutoScroll = True
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1126, 695)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'ToolStripContainer1.LeftToolStripPanel
        '
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStripDateShiftSelector)
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1152, 774)
        Me.ToolStripContainer1.TabIndex = 7
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStripMain)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStripMain)
        '
        'StatusStrip
        '
        Me.StatusStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.tslAdminInfo, Me.tslActiveEmployees, Me.tslActiveWorkgroups, Me.tslCurrentDateAndTime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 4, 19, 1)
        Me.StatusStrip.Size = New System.Drawing.Size(1152, 30)
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(0, 20)
        Me.ToolStripSplitButton1.Text = "Sie sind angemeldet als: Administrator"
        '
        'tslAdminInfo
        '
        Me.tslAdminInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslAdminInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslAdminInfo.Name = "tslAdminInfo"
        Me.tslAdminInfo.Size = New System.Drawing.Size(190, 20)
        Me.tslAdminInfo.Text = "Angemeldet als: Administrator "
        '
        'tslActiveEmployees
        '
        Me.tslActiveEmployees.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslActiveEmployees.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslActiveEmployees.Name = "tslActiveEmployees"
        Me.tslActiveEmployees.Size = New System.Drawing.Size(199, 20)
        Me.tslActiveEmployees.Text = "Aktive bzw. beteiligte Mitarbeiter"
        '
        'tslActiveWorkgroups
        '
        Me.tslActiveWorkgroups.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslActiveWorkgroups.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslActiveWorkgroups.Name = "tslActiveWorkgroups"
        Me.tslActiveWorkgroups.Size = New System.Drawing.Size(135, 20)
        Me.tslActiveWorkgroups.Text = "Aktive Produktiv-Sites"
        '
        'tslCurrentDateAndTime
        '
        Me.tslCurrentDateAndTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslCurrentDateAndTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslCurrentDateAndTime.Name = "tslCurrentDateAndTime"
        Me.tslCurrentDateAndTime.Size = New System.Drawing.Size(608, 20)
        Me.tslCurrentDateAndTime.Spring = True
        Me.tslCurrentDateAndTime.Text = "Current Date and Time"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1126, 695)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitEmployeesWorkGroups)
        Me.TabPage1.Controls.Add(Me.TopLineLayoutPanel)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1118, 666)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "SYSTEM"
        Me.TabPage1.Text = "Bearbeitung"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitEmployeesWorkGroups
        '
        Me.SplitEmployeesWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitEmployeesWorkGroups.Location = New System.Drawing.Point(3, 67)
        Me.SplitEmployeesWorkGroups.Name = "SplitEmployeesWorkGroups"
        Me.SplitEmployeesWorkGroups.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitEmployeesWorkGroups.Panel1
        '
        Me.SplitEmployeesWorkGroups.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.SplitEmployeesWorkGroups.Panel1.Controls.Add(Me.splitWorkGroups)
        '
        'SplitEmployeesWorkGroups.Panel2
        '
        Me.SplitEmployeesWorkGroups.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.SplitEmployeesWorkGroups.Panel2.Controls.Add(Me.gbEmployees)
        Me.SplitEmployeesWorkGroups.Size = New System.Drawing.Size(1112, 596)
        Me.SplitEmployeesWorkGroups.SplitterDistance = 262
        Me.SplitEmployeesWorkGroups.TabIndex = 1
        Me.SplitEmployeesWorkGroups.Text = "SplitContainer1"
        '
        'splitWorkGroups
        '
        Me.splitWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitWorkGroups.Location = New System.Drawing.Point(0, 0)
        Me.splitWorkGroups.Name = "splitWorkGroups"
        '
        'splitWorkGroups.Panel1
        '
        Me.splitWorkGroups.Panel1.Controls.Add(Me.gbWorkGroups)
        '
        'splitWorkGroups.Panel2
        '
        Me.splitWorkGroups.Panel2.Controls.Add(Me.GroupBox1)
        Me.splitWorkGroups.Size = New System.Drawing.Size(1112, 262)
        Me.splitWorkGroups.SplitterDistance = 688
        Me.splitWorkGroups.TabIndex = 0
        Me.splitWorkGroups.Text = "SplitContainer2"
        '
        'gbWorkGroups
        '
        Me.gbWorkGroups.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.gbWorkGroups.Controls.Add(Me.wglWorkGroups)
        Me.gbWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbWorkGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbWorkGroups.Location = New System.Drawing.Point(0, 0)
        Me.gbWorkGroups.Name = "gbWorkGroups"
        Me.gbWorkGroups.Size = New System.Drawing.Size(688, 262)
        Me.gbWorkGroups.TabIndex = 2
        Me.gbWorkGroups.TabStop = False
        Me.gbWorkGroups.Text = "Produktiv-Sites"
        '
        'wglWorkGroups
        '
        Me.wglWorkGroups.AutoGroup = True
        Me.wglWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wglWorkGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wglWorkGroups.FullRowSelect = True
        Me.wglWorkGroups.HideSelection = False
        Me.wglWorkGroups.Location = New System.Drawing.Point(3, 18)
        Me.wglWorkGroups.Name = "wglWorkGroups"
        Me.wglWorkGroups.OnlyActiveWorkgroups = True
        Me.wglWorkGroups.Size = New System.Drawing.Size(682, 241)
        Me.wglWorkGroups.TabIndex = 0
        Me.wglWorkGroups.UseCompatibleStateImageBehavior = False
        Me.wglWorkGroups.View = System.Windows.Forms.View.Details
        Me.wglWorkGroups.WorkGroupInfoItems = Nothing
        Me.wglWorkGroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvWorkGroupResults)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 262)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Produktiv-Site-Info:"
        '
        'dgvWorkGroupResults
        '
        Me.dgvWorkGroupResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWorkGroupResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWorkGroupResults.Location = New System.Drawing.Point(3, 18)
        Me.dgvWorkGroupResults.Name = "dgvWorkGroupResults"
        Me.dgvWorkGroupResults.Object = Nothing
        Me.dgvWorkGroupResults.Size = New System.Drawing.Size(414, 241)
        Me.dgvWorkGroupResults.TabIndex = 0
        '
        'gbEmployees
        '
        Me.gbEmployees.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.gbEmployees.Controls.Add(Me.elvEmployees)
        Me.gbEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEmployees.Location = New System.Drawing.Point(0, 0)
        Me.gbEmployees.Name = "gbEmployees"
        Me.gbEmployees.Size = New System.Drawing.Size(1112, 330)
        Me.gbEmployees.TabIndex = 2
        Me.gbEmployees.TabStop = False
        Me.gbEmployees.Text = "Mitarbeiter"
        '
        'elvEmployees
        '
        Me.elvEmployees.AutoGroup = True
        Me.elvEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.elvEmployees.EmployeeInfoCollection = Nothing
        Me.elvEmployees.EmployeeSortOrder = Facesso.FrontEnd.EmployeeSortOrder.PersonnelNumber
        Me.elvEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elvEmployees.FullRowSelect = True
        Me.elvEmployees.HideSelection = False
        Me.elvEmployees.Location = New System.Drawing.Point(3, 18)
        Me.elvEmployees.Name = "elvEmployees"
        Me.elvEmployees.OnlyActiveEmployees = True
        Me.elvEmployees.OnlyIncentiveEmployees = False
        Me.elvEmployees.Size = New System.Drawing.Size(1106, 309)
        Me.elvEmployees.TabIndex = 0
        Me.elvEmployees.UseCompatibleStateImageBehavior = False
        Me.elvEmployees.View = System.Windows.Forms.View.Details
        '
        'TopLineLayoutPanel
        '
        Me.TopLineLayoutPanel.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TopLineLayoutPanel.ColumnCount = 3
        Me.TopLineLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TopLineLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TopLineLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TopLineLayoutPanel.Controls.Add(Me.lblCurrentShift, 0, 0)
        Me.TopLineLayoutPanel.Controls.Add(Me.lblCurrentWorkgroup, 0, 0)
        Me.TopLineLayoutPanel.Controls.Add(Me.lblCurrentDate, 0, 0)
        Me.TopLineLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopLineLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.TopLineLayoutPanel.Name = "TopLineLayoutPanel"
        Me.TopLineLayoutPanel.RowCount = 1
        Me.TopLineLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TopLineLayoutPanel.Size = New System.Drawing.Size(1112, 64)
        Me.TopLineLayoutPanel.TabIndex = 2
        '
        'lblCurrentShift
        '
        Me.lblCurrentShift.AutoEllipsis = True
        Me.lblCurrentShift.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCurrentShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentShift.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrentShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentShift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentShift.Location = New System.Drawing.Point(559, 3)
        Me.lblCurrentShift.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCurrentShift.Name = "lblCurrentShift"
        Me.lblCurrentShift.Padding = New System.Windows.Forms.Padding(2)
        Me.lblCurrentShift.Size = New System.Drawing.Size(550, 58)
        Me.lblCurrentShift.TabIndex = 4
        Me.lblCurrentShift.Text = "Schicht 1 (06:15 - 12:15)"
        Me.lblCurrentShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentWorkgroup
        '
        Me.lblCurrentWorkgroup.AutoEllipsis = True
        Me.lblCurrentWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCurrentWorkgroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentWorkgroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrentWorkgroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentWorkgroup.Location = New System.Drawing.Point(281, 3)
        Me.lblCurrentWorkgroup.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCurrentWorkgroup.Name = "lblCurrentWorkgroup"
        Me.lblCurrentWorkgroup.Padding = New System.Windows.Forms.Padding(2)
        Me.lblCurrentWorkgroup.Size = New System.Drawing.Size(272, 58)
        Me.lblCurrentWorkgroup.TabIndex = 5
        Me.lblCurrentWorkgroup.Text = "Schicht 1 (06:15 - 12:15)"
        Me.lblCurrentWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.AutoEllipsis = True
        Me.lblCurrentDate.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCurrentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentDate.Location = New System.Drawing.Point(3, 3)
        Me.lblCurrentDate.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Padding = New System.Windows.Forms.Padding(2)
        Me.lblCurrentDate.Size = New System.Drawing.Size(272, 58)
        Me.lblCurrentDate.TabIndex = 0
        Me.lblCurrentDate.Text = "Montag, 23.2.2005"
        Me.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1118, 669)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "SYSTEM"
        Me.TabPage2.Text = "Überblick"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.mainChartThree)
        Me.SplitContainer1.Size = New System.Drawing.Size(1112, 663)
        Me.SplitContainer1.SplitterDistance = 295
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.mainChartOne)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.mainChartTwo)
        Me.SplitContainer2.Size = New System.Drawing.Size(1112, 295)
        Me.SplitContainer2.SplitterDistance = 543
        Me.SplitContainer2.TabIndex = 0
        '
        'mainChartOne
        '
        Me.mainChartOne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainChartOne.Location = New System.Drawing.Point(0, 0)
        Me.mainChartOne.Margin = New System.Windows.Forms.Padding(4)
        Me.mainChartOne.Name = "mainChartOne"
        Me.mainChartOne.Size = New System.Drawing.Size(543, 295)
        Me.mainChartOne.TabIndex = 1
        '
        'mainChartTwo
        '
        Me.mainChartTwo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainChartTwo.Location = New System.Drawing.Point(0, 0)
        Me.mainChartTwo.Margin = New System.Windows.Forms.Padding(4)
        Me.mainChartTwo.Name = "mainChartTwo"
        Me.mainChartTwo.Size = New System.Drawing.Size(565, 295)
        Me.mainChartTwo.TabIndex = 2
        '
        'mainChartThree
        '
        Me.mainChartThree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainChartThree.Location = New System.Drawing.Point(0, 0)
        Me.mainChartThree.Margin = New System.Windows.Forms.Padding(4)
        Me.mainChartThree.Name = "mainChartThree"
        Me.mainChartThree.Size = New System.Drawing.Size(1112, 364)
        Me.mainChartThree.TabIndex = 3
        '
        'ToolStripDateShiftSelector
        '
        Me.ToolStripDateShiftSelector.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripDateShiftSelector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripDateShiftSelector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStripDateShiftSelector.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripDateShiftSelector.Name = "ToolStripDateShiftSelector"
        Me.ToolStripDateShiftSelector.Size = New System.Drawing.Size(26, 695)
        Me.ToolStripDateShiftSelector.Stretch = True
        Me.ToolStripDateShiftSelector.TabIndex = 7
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStripMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.AnalysisToolStripMenuItem, Me.tsmCostCalculation, Me.BaseDataToolStripMenuItem, Me.ExtrasToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStripMain.Size = New System.Drawing.Size(1152, 24)
        Me.MenuStripMain.TabIndex = 0
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem7, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ExportierenalsXMLToolStripMenuItem, Me.ImportierenalsXMLToolStripMenuItem, Me.BaseDataImportToolStripMenuItem, Me.ToolStripSeparator1, Me.DruckenToolStripMenuItem, Me.ToolStripSeparator2, Me.ProgrammbeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem8.Text = "Neu anmelden..."
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(219, 6)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem5.Text = "Daten&sicherung..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(219, 6)
        '
        'ExportierenalsXMLToolStripMenuItem
        '
        Me.ExportierenalsXMLToolStripMenuItem.Name = "ExportierenalsXMLToolStripMenuItem"
        Me.ExportierenalsXMLToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ExportierenalsXMLToolStripMenuItem.Text = "&Exportieren als XML..."
        Me.ExportierenalsXMLToolStripMenuItem.Visible = False
        '
        'ImportierenalsXMLToolStripMenuItem
        '
        Me.ImportierenalsXMLToolStripMenuItem.Name = "ImportierenalsXMLToolStripMenuItem"
        Me.ImportierenalsXMLToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ImportierenalsXMLToolStripMenuItem.Text = "&Importieren als XML..."
        Me.ImportierenalsXMLToolStripMenuItem.Visible = False
        '
        'BaseDataImportToolStripMenuItem
        '
        Me.BaseDataImportToolStripMenuItem.Name = "BaseDataImportToolStripMenuItem"
        Me.BaseDataImportToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.BaseDataImportToolStripMenuItem.Text = "Stammdaten importieren..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(219, 6)
        '
        'DruckenToolStripMenuItem
        '
        Me.DruckenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MitarbeiterToolStripMenuItem1, Me.ProduktivSitesAnalyseToolStripMenuItem, Me.ToolStripSeparator7})
        Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
        Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.DruckenToolStripMenuItem.Text = "Drucken"
        Me.DruckenToolStripMenuItem.Visible = False
        '
        'MitarbeiterToolStripMenuItem1
        '
        Me.MitarbeiterToolStripMenuItem1.Name = "MitarbeiterToolStripMenuItem1"
        Me.MitarbeiterToolStripMenuItem1.Size = New System.Drawing.Size(212, 22)
        Me.MitarbeiterToolStripMenuItem1.Text = "&Mitarbeiteranalyse..."
        '
        'ProduktivSitesAnalyseToolStripMenuItem
        '
        Me.ProduktivSitesAnalyseToolStripMenuItem.Name = "ProduktivSitesAnalyseToolStripMenuItem"
        Me.ProduktivSitesAnalyseToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ProduktivSitesAnalyseToolStripMenuItem.Text = "&Produktiv-Sites-Analyse..."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(209, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(219, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'ProgrammbeendenToolStripMenuItem
        '
        Me.ProgrammbeendenToolStripMenuItem.Name = "ProgrammbeendenToolStripMenuItem"
        Me.ProgrammbeendenToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ProgrammbeendenToolStripMenuItem.Text = "Programm be&enden"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmEdit_ProductionDataCollection, Me.ToolStripSeparator3, Me.tsmEdit_EmployeeTimeBookings, Me.ToolStripMenuItem3, Me.tsmEdit_SetMyReminder})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.EditToolStripMenuItem.Text = "&Bearbeiten"
        '
        'tsmEdit_ProductionDataCollection
        '
        Me.tsmEdit_ProductionDataCollection.Name = "tsmEdit_ProductionDataCollection"
        Me.tsmEdit_ProductionDataCollection.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.tsmEdit_ProductionDataCollection.Size = New System.Drawing.Size(282, 22)
        Me.tsmEdit_ProductionDataCollection.Text = "Datenmanager..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(279, 6)
        '
        'tsmEdit_EmployeeTimeBookings
        '
        Me.tsmEdit_EmployeeTimeBookings.Enabled = False
        Me.tsmEdit_EmployeeTimeBookings.Name = "tsmEdit_EmployeeTimeBookings"
        Me.tsmEdit_EmployeeTimeBookings.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.tsmEdit_EmployeeTimeBookings.Size = New System.Drawing.Size(282, 22)
        Me.tsmEdit_EmployeeTimeBookings.Text = "Mitarbeiter-Einzelzeiten bearbeiten"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(279, 6)
        '
        'tsmEdit_SetMyReminder
        '
        Me.tsmEdit_SetMyReminder.Name = "tsmEdit_SetMyReminder"
        Me.tsmEdit_SetMyReminder.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.tsmEdit_SetMyReminder.Size = New System.Drawing.Size(282, 22)
        Me.tsmEdit_SetMyReminder.Text = "Mein Merkdatum setzen..."
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmView_WorkGroupInfo, Me.tsmView_Employees, Me.FilternToolStripMenuItem, Me.tsmView_OnlyActiveWorkgroups, Me.tsmView_OnlyActiveEmployees, Me.ToolStripSeparator8, Me.tsmView_DockDateSelector})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ViewToolStripMenuItem.Text = "&Ansicht"
        '
        'tsmView_WorkGroupInfo
        '
        Me.tsmView_WorkGroupInfo.Name = "tsmView_WorkGroupInfo"
        Me.tsmView_WorkGroupInfo.Size = New System.Drawing.Size(266, 22)
        Me.tsmView_WorkGroupInfo.Text = "&Produktiv-Site-Info"
        '
        'tsmView_Employees
        '
        Me.tsmView_Employees.Checked = True
        Me.tsmView_Employees.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmView_Employees.Name = "tsmView_Employees"
        Me.tsmView_Employees.Size = New System.Drawing.Size(266, 22)
        Me.tsmView_Employees.Text = "&Mitarbeiter"
        '
        'FilternToolStripMenuItem
        '
        Me.FilternToolStripMenuItem.Name = "FilternToolStripMenuItem"
        Me.FilternToolStripMenuItem.Size = New System.Drawing.Size(263, 6)
        '
        'tsmView_OnlyActiveWorkgroups
        '
        Me.tsmView_OnlyActiveWorkgroups.Checked = True
        Me.tsmView_OnlyActiveWorkgroups.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmView_OnlyActiveWorkgroups.Name = "tsmView_OnlyActiveWorkgroups"
        Me.tsmView_OnlyActiveWorkgroups.Size = New System.Drawing.Size(266, 22)
        Me.tsmView_OnlyActiveWorkgroups.Text = "Nur aktive Produktiv-Sites anzeigen"
        '
        'tsmView_OnlyActiveEmployees
        '
        Me.tsmView_OnlyActiveEmployees.Checked = True
        Me.tsmView_OnlyActiveEmployees.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmView_OnlyActiveEmployees.Name = "tsmView_OnlyActiveEmployees"
        Me.tsmView_OnlyActiveEmployees.Size = New System.Drawing.Size(266, 22)
        Me.tsmView_OnlyActiveEmployees.Text = "Nur aktive Mitarbeiter anzeigen"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(263, 6)
        '
        'tsmView_DockDateSelector
        '
        Me.tsmView_DockDateSelector.Checked = True
        Me.tsmView_DockDateSelector.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmView_DockDateSelector.Enabled = False
        Me.tsmView_DockDateSelector.Name = "tsmView_DockDateSelector"
        Me.tsmView_DockDateSelector.Size = New System.Drawing.Size(266, 22)
        Me.tsmView_DockDateSelector.Text = "Datums-Selektor gedockt"
        '
        'AnalysisToolStripMenuItem
        '
        Me.AnalysisToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAnalyses_AnalysisWizard, Me.tsmAnalyses_AnalysisManager, Me.ToolStripMenuItem9, Me.tsmArticleAmountAnalysis, Me.ToolStripMenuItem10, Me.AusfallzeitenAnalyseToolStripMenuItem})
        Me.AnalysisToolStripMenuItem.Name = "AnalysisToolStripMenuItem"
        Me.AnalysisToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AnalysisToolStripMenuItem.Text = "Anal&ysen"
        '
        'tsmAnalyses_AnalysisWizard
        '
        Me.tsmAnalyses_AnalysisWizard.Name = "tsmAnalyses_AnalysisWizard"
        Me.tsmAnalyses_AnalysisWizard.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.tsmAnalyses_AnalysisWizard.Size = New System.Drawing.Size(334, 22)
        Me.tsmAnalyses_AnalysisWizard.Text = "Assistent für &Produktiv-Site-Analysen..."
        '
        'tsmAnalyses_AnalysisManager
        '
        Me.tsmAnalyses_AnalysisManager.Name = "tsmAnalyses_AnalysisManager"
        Me.tsmAnalyses_AnalysisManager.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F8), System.Windows.Forms.Keys)
        Me.tsmAnalyses_AnalysisManager.Size = New System.Drawing.Size(334, 22)
        Me.tsmAnalyses_AnalysisManager.Text = "Analysen-Manager für Produktiv-Sites..."
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(331, 6)
        '
        'tsmArticleAmountAnalysis
        '
        Me.tsmArticleAmountAnalysis.Name = "tsmArticleAmountAnalysis"
        Me.tsmArticleAmountAnalysis.Size = New System.Drawing.Size(334, 22)
        Me.tsmArticleAmountAnalysis.Text = "&Produktionsergebnis-Analyse..."
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(331, 6)
        '
        'AusfallzeitenAnalyseToolStripMenuItem
        '
        Me.AusfallzeitenAnalyseToolStripMenuItem.Name = "AusfallzeitenAnalyseToolStripMenuItem"
        Me.AusfallzeitenAnalyseToolStripMenuItem.Size = New System.Drawing.Size(334, 22)
        Me.AusfallzeitenAnalyseToolStripMenuItem.Text = "&Quick-Info..."
        '
        'tsmCostCalculation
        '
        Me.tsmCostCalculation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCostCalculation_IncentiveWageCalculation, Me.ToolStripSeparator4, Me.tsmCostCalculation_CostOfEmployees, Me.tsmCostCalculation_CostOfCostCenter, Me.tsmCostCalculation_CostOfWorkgroups})
        Me.tsmCostCalculation.Name = "tsmCostCalculation"
        Me.tsmCostCalculation.Size = New System.Drawing.Size(143, 20)
        Me.tsmCostCalculation.Text = "&Kosten/Abrechnungen"
        '
        'tsmCostCalculation_IncentiveWageCalculation
        '
        Me.tsmCostCalculation_IncentiveWageCalculation.Name = "tsmCostCalculation_IncentiveWageCalculation"
        Me.tsmCostCalculation_IncentiveWageCalculation.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.tsmCostCalculation_IncentiveWageCalculation.Size = New System.Drawing.Size(237, 22)
        Me.tsmCostCalculation_IncentiveWageCalculation.Text = "&Prämienlohnabrechnung..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(234, 6)
        '
        'tsmCostCalculation_CostOfEmployees
        '
        Me.tsmCostCalculation_CostOfEmployees.Name = "tsmCostCalculation_CostOfEmployees"
        Me.tsmCostCalculation_CostOfEmployees.Size = New System.Drawing.Size(237, 22)
        Me.tsmCostCalculation_CostOfEmployees.Text = "&Mitarbeiterkosten..."
        '
        'tsmCostCalculation_CostOfCostCenter
        '
        Me.tsmCostCalculation_CostOfCostCenter.Name = "tsmCostCalculation_CostOfCostCenter"
        Me.tsmCostCalculation_CostOfCostCenter.Size = New System.Drawing.Size(237, 22)
        Me.tsmCostCalculation_CostOfCostCenter.Text = "&Kostenstellen-Kosten..."
        '
        'tsmCostCalculation_CostOfWorkgroups
        '
        Me.tsmCostCalculation_CostOfWorkgroups.Name = "tsmCostCalculation_CostOfWorkgroups"
        Me.tsmCostCalculation_CostOfWorkgroups.Size = New System.Drawing.Size(237, 22)
        Me.tsmCostCalculation_CostOfWorkgroups.Text = "&Arbeitsgruppen-Kosten..."
        '
        'BaseDataToolStripMenuItem
        '
        Me.BaseDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBaseData_Subsidiaries, Me.ToolStripMenuItem4, Me.tsmBaseData_Employees, Me.tsmBaseData_LabourValues, Me.tsmBaseData_WorkGroups, Me.ToolStripSeparator5, Me.tsmBaseData_CostCenters, Me.tsmBaseData_WageGroups, Me.tsmBaseData_BonusProgressions})
        Me.BaseDataToolStripMenuItem.Name = "BaseDataToolStripMenuItem"
        Me.BaseDataToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.BaseDataToolStripMenuItem.Text = "Basi&sdaten"
        '
        'tsmBaseData_Subsidiaries
        '
        Me.tsmBaseData_Subsidiaries.Enabled = False
        Me.tsmBaseData_Subsidiaries.Name = "tsmBaseData_Subsidiaries"
        Me.tsmBaseData_Subsidiaries.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_Subsidiaries.Text = "Niederlassungen..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(186, 6)
        '
        'tsmBaseData_Employees
        '
        Me.tsmBaseData_Employees.Name = "tsmBaseData_Employees"
        Me.tsmBaseData_Employees.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_Employees.Text = "Mitarbeiter..."
        '
        'tsmBaseData_LabourValues
        '
        Me.tsmBaseData_LabourValues.Name = "tsmBaseData_LabourValues"
        Me.tsmBaseData_LabourValues.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_LabourValues.Text = "REFA-Arbeitswerte..."
        '
        'tsmBaseData_WorkGroups
        '
        Me.tsmBaseData_WorkGroups.Name = "tsmBaseData_WorkGroups"
        Me.tsmBaseData_WorkGroups.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_WorkGroups.Text = "Produktiv-Sites..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(186, 6)
        '
        'tsmBaseData_CostCenters
        '
        Me.tsmBaseData_CostCenters.Name = "tsmBaseData_CostCenters"
        Me.tsmBaseData_CostCenters.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_CostCenters.Text = "&Kostenstellen..."
        '
        'tsmBaseData_WageGroups
        '
        Me.tsmBaseData_WageGroups.Name = "tsmBaseData_WageGroups"
        Me.tsmBaseData_WageGroups.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_WageGroups.Text = "&Lohngruppen..."
        '
        'tsmBaseData_BonusProgressions
        '
        Me.tsmBaseData_BonusProgressions.Name = "tsmBaseData_BonusProgressions"
        Me.tsmBaseData_BonusProgressions.Size = New System.Drawing.Size(189, 22)
        Me.tsmBaseData_BonusProgressions.Text = "&Bonusprogression..."
        '
        'ExtrasToolStripMenuItem
        '
        Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDataImport, Me.ToolStripSeparator9, Me.tsmTools_UserManagement, Me.tsmTools_LoginInfo, Me.ToolStripSeparator6, Me.SupportToolStripMenuItem, Me.ToolStripSeparator16, Me.tsmTools_Options})
        Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
        Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ExtrasToolStripMenuItem.Text = "&Extras"
        '
        'tsmDataImport
        '
        Me.tsmDataImport.Name = "tsmDataImport"
        Me.tsmDataImport.Size = New System.Drawing.Size(286, 22)
        Me.tsmDataImport.Text = "Datenimport..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(283, 6)
        '
        'tsmTools_UserManagement
        '
        Me.tsmTools_UserManagement.Name = "tsmTools_UserManagement"
        Me.tsmTools_UserManagement.Size = New System.Drawing.Size(286, 22)
        Me.tsmTools_UserManagement.Text = "Facesso Benutzermanagement..."
        '
        'tsmTools_LoginInfo
        '
        Me.tsmTools_LoginInfo.Enabled = False
        Me.tsmTools_LoginInfo.Name = "tsmTools_LoginInfo"
        Me.tsmTools_LoginInfo.Size = New System.Drawing.Size(286, 22)
        Me.tsmTools_LoginInfo.Text = "Anmeldeinformationen..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(283, 6)
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.SupportToolStripMenuItem.Text = "Support-Zugang (nur für AD-Support!)"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(283, 6)
        '
        'tsmTools_Options
        '
        Me.tsmTools_Options.Name = "tsmTools_Options"
        Me.tsmTools_Options.Size = New System.Drawing.Size(286, 22)
        Me.tsmTools_Options.Text = "&Optionen..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.tsmHelpAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.HelpToolStripMenuItem.Text = "&Hilfe"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(200, 22)
        Me.ToolStripMenuItem1.Text = "Neuer Freischaltcode..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(197, 6)
        '
        'tsmHelpAbout
        '
        Me.tsmHelpAbout.Name = "tsmHelpAbout"
        Me.tsmHelpAbout.Size = New System.Drawing.Size(200, 22)
        Me.tsmHelpAbout.Text = "&Info über Faceso..."
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDataManager, Me.ToolStripSeparator10, Me.tsbWorkGroupAnalysis, Me.tsbAnalysisIncentiveWage, Me.ToolStripSeparator11, Me.tsbPrevWorkgroup, Me.tsbNextWorkgroup, Me.ToolStripSeparator12, Me.tsbPrevWorkDay, Me.tsbMyTodoList, Me.tsbNextWorkDay, Me.ToolStripSeparator13, Me.tsbBaseDataEmployee, Me.tsbBaseDataWorkGroups, Me.tsbBaseDataLabourValue, Me.ToolStripSeparator14, Me.tsbBaseDataUser, Me.ToolStripSeparator15, Me.tsbOptions})
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 24)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(347, 25)
        Me.ToolStripMain.TabIndex = 1
        Me.ToolStripMain.Text = "tsmDataManager"
        '
        'tsbDataManager
        '
        Me.tsbDataManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDataManager.Image = CType(resources.GetObject("tsbDataManager.Image"), System.Drawing.Image)
        Me.tsbDataManager.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDataManager.Name = "tsbDataManager"
        Me.tsbDataManager.Size = New System.Drawing.Size(23, 22)
        Me.tsbDataManager.Text = "Datenmanager aufrufen"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'tsbWorkGroupAnalysis
        '
        Me.tsbWorkGroupAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbWorkGroupAnalysis.Image = CType(resources.GetObject("tsbWorkGroupAnalysis.Image"), System.Drawing.Image)
        Me.tsbWorkGroupAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbWorkGroupAnalysis.Name = "tsbWorkGroupAnalysis"
        Me.tsbWorkGroupAnalysis.Size = New System.Drawing.Size(23, 22)
        Me.tsbWorkGroupAnalysis.Text = "Produktiv-Site-Analysen"
        '
        'tsbAnalysisIncentiveWage
        '
        Me.tsbAnalysisIncentiveWage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAnalysisIncentiveWage.Image = CType(resources.GetObject("tsbAnalysisIncentiveWage.Image"), System.Drawing.Image)
        Me.tsbAnalysisIncentiveWage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnalysisIncentiveWage.Name = "tsbAnalysisIncentiveWage"
        Me.tsbAnalysisIncentiveWage.Size = New System.Drawing.Size(23, 22)
        Me.tsbAnalysisIncentiveWage.Text = "Monatslohnabrechnung Mitarbeiter"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrevWorkgroup
        '
        Me.tsbPrevWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrevWorkgroup.Image = CType(resources.GetObject("tsbPrevWorkgroup.Image"), System.Drawing.Image)
        Me.tsbPrevWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrevWorkgroup.Name = "tsbPrevWorkgroup"
        Me.tsbPrevWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrevWorkgroup.Text = "Vorherige Produktiv-Site"
        '
        'tsbNextWorkgroup
        '
        Me.tsbNextWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNextWorkgroup.Image = CType(resources.GetObject("tsbNextWorkgroup.Image"), System.Drawing.Image)
        Me.tsbNextWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNextWorkgroup.Name = "tsbNextWorkgroup"
        Me.tsbNextWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbNextWorkgroup.Text = "Nächste Produktiv-Site"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrevWorkDay
        '
        Me.tsbPrevWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrevWorkDay.Image = CType(resources.GetObject("tsbPrevWorkDay.Image"), System.Drawing.Image)
        Me.tsbPrevWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrevWorkDay.Name = "tsbPrevWorkDay"
        Me.tsbPrevWorkDay.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrevWorkDay.Text = "vorheriger Arbeitstag"
        '
        'tsbMyTodoList
        '
        Me.tsbMyTodoList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMyTodoList.Image = CType(resources.GetObject("tsbMyTodoList.Image"), System.Drawing.Image)
        Me.tsbMyTodoList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMyTodoList.Name = "tsbMyTodoList"
        Me.tsbMyTodoList.Size = New System.Drawing.Size(23, 22)
        Me.tsbMyTodoList.Text = "Meine To-do-Liste"
        '
        'tsbNextWorkDay
        '
        Me.tsbNextWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNextWorkDay.Image = CType(resources.GetObject("tsbNextWorkDay.Image"), System.Drawing.Image)
        Me.tsbNextWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNextWorkDay.Name = "tsbNextWorkDay"
        Me.tsbNextWorkDay.Size = New System.Drawing.Size(23, 22)
        Me.tsbNextWorkDay.Text = "nächster Arbeitstag"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'tsbBaseDataEmployee
        '
        Me.tsbBaseDataEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBaseDataEmployee.Image = CType(resources.GetObject("tsbBaseDataEmployee.Image"), System.Drawing.Image)
        Me.tsbBaseDataEmployee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBaseDataEmployee.Name = "tsbBaseDataEmployee"
        Me.tsbBaseDataEmployee.Size = New System.Drawing.Size(23, 22)
        Me.tsbBaseDataEmployee.Text = "Mitarbeiter-Stammdaten"
        '
        'tsbBaseDataWorkGroups
        '
        Me.tsbBaseDataWorkGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBaseDataWorkGroups.Image = CType(resources.GetObject("tsbBaseDataWorkGroups.Image"), System.Drawing.Image)
        Me.tsbBaseDataWorkGroups.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBaseDataWorkGroups.Name = "tsbBaseDataWorkGroups"
        Me.tsbBaseDataWorkGroups.Size = New System.Drawing.Size(23, 22)
        Me.tsbBaseDataWorkGroups.Text = "Produktiv-Site-Manager"
        Me.tsbBaseDataWorkGroups.ToolTipText = "Produktiv-Site-Manager"
        '
        'tsbBaseDataLabourValue
        '
        Me.tsbBaseDataLabourValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBaseDataLabourValue.Image = CType(resources.GetObject("tsbBaseDataLabourValue.Image"), System.Drawing.Image)
        Me.tsbBaseDataLabourValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBaseDataLabourValue.Name = "tsbBaseDataLabourValue"
        Me.tsbBaseDataLabourValue.Size = New System.Drawing.Size(23, 22)
        Me.tsbBaseDataLabourValue.Text = "REFA-Arbeitswert-Stammdaten"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'tsbBaseDataUser
        '
        Me.tsbBaseDataUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBaseDataUser.Image = CType(resources.GetObject("tsbBaseDataUser.Image"), System.Drawing.Image)
        Me.tsbBaseDataUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBaseDataUser.Name = "tsbBaseDataUser"
        Me.tsbBaseDataUser.Size = New System.Drawing.Size(23, 22)
        Me.tsbBaseDataUser.Text = "Benutzerverwaltung"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'tsbOptions
        '
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOptions.Image = CType(resources.GetObject("tsbOptions.Image"), System.Drawing.Image)
        Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptions.Name = "tsbOptions"
        Me.tsbOptions.Size = New System.Drawing.Size(23, 22)
        Me.tsbOptions.Text = "Optionen"
        '
        'frmFacessoShell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 774)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(40, 40)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(656, 550)
        Me.Name = "frmFacessoShell"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Facesso Shell"
        CType(Me.EmployeeInfoCollectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.LeftToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.LeftToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitEmployeesWorkGroups.Panel1.ResumeLayout(False)
        Me.SplitEmployeesWorkGroups.Panel2.ResumeLayout(False)
        CType(Me.SplitEmployeesWorkGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitEmployeesWorkGroups.ResumeLayout(False)
        Me.splitWorkGroups.Panel1.ResumeLayout(False)
        Me.splitWorkGroups.Panel2.ResumeLayout(False)
        CType(Me.splitWorkGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitWorkGroups.ResumeLayout(False)
        Me.gbWorkGroups.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvWorkGroupResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmployees.ResumeLayout(False)
        Me.TopLineLayoutPanel.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportierenalsXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportierenalsXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProgrammbeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCostCalculation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BaseDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmView_OnlyActiveWorkgroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilternToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmView_OnlyActiveEmployees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEdit_ProductionDataCollection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCostCalculation_IncentiveWageCalculation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCostCalculation_CostOfEmployees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCostCalculation_CostOfCostCenter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCostCalculation_CostOfWorkgroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_Employees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_LabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_WorkGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_CostCenters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_WageGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBaseData_BonusProgressions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTools_UserManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTools_LoginInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmTools_Options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmBaseData_Subsidiaries As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmAnalyses_AnalysisWizard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MitarbeiterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProduktivSitesAnalyseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDateShiftSelector As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmView_DockDateSelector As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslAdminInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BaseDataImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeInfoCollectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tsmView_WorkGroupInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmView_Employees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEdit_EmployeeTimeBookings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbDataManager As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbWorkGroupAnalysis As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnalysisIncentiveWage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNextWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrevWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrevWorkDay As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMyTodoList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNextWorkDay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbBaseDataEmployee As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbBaseDataWorkGroups As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbBaseDataLabourValue As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbBaseDataUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmEdit_SetMyReminder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslActiveEmployees As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslActiveWorkgroups As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslCurrentDateAndTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents tsmAnalyses_AnalysisManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDataImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmArticleAmountAnalysis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusfallzeitenAnalyseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TopLineLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCurrentShift As System.Windows.Forms.Label
    Friend WithEvents lblCurrentWorkgroup As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents SplitEmployeesWorkGroups As System.Windows.Forms.SplitContainer
    Friend WithEvents splitWorkGroups As System.Windows.Forms.SplitContainer
    Friend WithEvents gbWorkGroups As System.Windows.Forms.GroupBox
    Friend WithEvents wglWorkGroups As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvWorkGroupResults As Facesso.FrontEnd.ucWorkGroupItemDetailsView
    Friend WithEvents gbEmployees As System.Windows.Forms.GroupBox
    Friend WithEvents elvEmployees As Facesso.FrontEnd.ucEmployeeListView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents mainChartOne As Facesso.Functions.ucConfigurableWorkgroupChart
    Friend WithEvents mainChartTwo As Facesso.Functions.ucConfigurableWorkgroupChart
    Friend WithEvents mainChartThree As Facesso.Functions.ucConfigurableWorkgroupChart
    Friend WithEvents SupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator

End Class
