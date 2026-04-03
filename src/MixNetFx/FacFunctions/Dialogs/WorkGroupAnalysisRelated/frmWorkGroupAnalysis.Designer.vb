<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmWorkGroupAnalysis
    Inherits frmBaseFacesso

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkGroupAnalysis))
        Me.tcWizard = New System.Windows.Forms.TabControl
        Me.TabBase = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tab2Period = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.nudAltShiftDays = New System.Windows.Forms.NumericUpDown
        Me.btnAllShifts = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.nudAltShift2 = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudAltShift1 = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.optUseAlternatingShifts = New System.Windows.Forms.RadioButton
        Me.optUseShifts = New System.Windows.Forms.RadioButton
        Me.chkShift4 = New System.Windows.Forms.CheckBox
        Me.chkShift3 = New System.Windows.Forms.CheckBox
        Me.chkShift2 = New System.Windows.Forms.CheckBox
        Me.chkShift1 = New System.Windows.Forms.CheckBox
        Me.drpMain = New Facesso.FrontEnd.ucAnalysisDateRangePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.Tab3SelectWorkgroups = New System.Windows.Forms.TabPage
        Me.btnAllWorkGroupsInCostCenter = New System.Windows.Forms.Button
        Me.btnUnSelectWorkGroups = New System.Windows.Forms.Button
        Me.btnSelectAllWorkGroups = New System.Windows.Forms.Button
        Me.wglWorkGroups = New Facesso.FrontEnd.ucWorkGroupListView
        Me.Label25 = New System.Windows.Forms.Label
        Me.Tab4TypeOfAnalysis = New System.Windows.Forms.TabPage
        Me.optWorkGroupListShiftwiseCompressed = New System.Windows.Forms.RadioButton
        Me.lblDescription = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.optWorkGroupListShiftWise = New System.Windows.Forms.RadioButton
        Me.optAnalysisLine = New System.Windows.Forms.RadioButton
        Me.optWorkGroupListShiftCondensed = New System.Windows.Forms.RadioButton
        Me.optBatch = New System.Windows.Forms.RadioButton
        Me.optDetailed = New System.Windows.Forms.RadioButton
        Me.chkIncludeSuspended = New System.Windows.Forms.CheckBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Tab5AnalysisDestination = New System.Windows.Forms.TabPage
        Me.btnSelectExportFile = New System.Windows.Forms.Button
        Me.lblExportFilename = New System.Windows.Forms.Label
        Me.optCSVExport = New System.Windows.Forms.RadioButton
        Me.optPreviewBeforePrint = New System.Windows.Forms.RadioButton
        Me.optTargetPrinter = New System.Windows.Forms.RadioButton
        Me.Label27 = New System.Windows.Forms.Label
        Me.Tab6ExcelExport = New System.Windows.Forms.TabPage
        Me.lstDestFields = New System.Windows.Forms.ListBox
        Me.btnRemoveAllFields = New System.Windows.Forms.Button
        Me.btnRemoveField = New System.Windows.Forms.Button
        Me.btnAddField = New System.Windows.Forms.Button
        Me.btnAddAllFields = New System.Windows.Forms.Button
        Me.lstSourceFields = New System.Windows.Forms.ListBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Tab8Finalize = New System.Windows.Forms.TabPage
        Me.txtConclusion = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tcWizard.SuspendLayout()
        Me.TabBase.SuspendLayout()
        Me.Tab2Period.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAltShiftDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAltShift2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAltShift1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3SelectWorkgroups.SuspendLayout()
        Me.Tab4TypeOfAnalysis.SuspendLayout()
        Me.Tab5AnalysisDestination.SuspendLayout()
        Me.Tab6ExcelExport.SuspendLayout()
        Me.Tab8Finalize.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcWizard
        '
        Me.tcWizard.Controls.Add(Me.TabBase)
        Me.tcWizard.Controls.Add(Me.Tab2Period)
        Me.tcWizard.Controls.Add(Me.Tab3SelectWorkgroups)
        Me.tcWizard.Controls.Add(Me.Tab4TypeOfAnalysis)
        Me.tcWizard.Controls.Add(Me.Tab5AnalysisDestination)
        Me.tcWizard.Controls.Add(Me.Tab6ExcelExport)
        Me.tcWizard.Controls.Add(Me.Tab8Finalize)
        Me.tcWizard.Location = New System.Drawing.Point(154, -22)
        Me.tcWizard.Name = "tcWizard"
        Me.tcWizard.SelectedIndex = 0
        Me.tcWizard.Size = New System.Drawing.Size(658, 417)
        Me.tcWizard.TabIndex = 1
        '
        'TabBase
        '
        Me.TabBase.Controls.Add(Me.Label6)
        Me.TabBase.Controls.Add(Me.Label12)
        Me.TabBase.Controls.Add(Me.Label4)
        Me.TabBase.Controls.Add(Me.Label3)
        Me.TabBase.Controls.Add(Me.Label2)
        Me.TabBase.Location = New System.Drawing.Point(4, 22)
        Me.TabBase.Name = "TabBase"
        Me.TabBase.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBase.Size = New System.Drawing.Size(650, 391)
        Me.TabBase.TabIndex = 0
        Me.TabBase.Text = "Basis"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(464, 51)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(50, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(438, 32)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Klicken Sie jeweils auf die Schaltfläche [Weiter >], wenn Sie einen Schritt des A" & _
            "ssistenten abgeschlossen haben."
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(441, 69)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(438, 39)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Dieser Assistent hilft Ihnen, die erforderlichen Parameter zusammenzustellen, um " & _
            "auf möglichst flexible Art und Weise Auswertungen von Produktiv-Sites durchführe" & _
            "n zu können."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(498, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Willkommen zum Produktiv-Site-Auswertungs-Assistenten von Facesso!"
        '
        'Tab2Period
        '
        Me.Tab2Period.Controls.Add(Me.GroupBox1)
        Me.Tab2Period.Controls.Add(Me.drpMain)
        Me.Tab2Period.Controls.Add(Me.Label16)
        Me.Tab2Period.Location = New System.Drawing.Point(4, 22)
        Me.Tab2Period.Name = "Tab2Period"
        Me.Tab2Period.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2Period.Size = New System.Drawing.Size(650, 391)
        Me.Tab2Period.TabIndex = 1
        Me.Tab2Period.Text = "PeriodAndShifts"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.nudAltShiftDays)
        Me.GroupBox1.Controls.Add(Me.btnAllShifts)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.nudAltShift2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.nudAltShift1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.optUseAlternatingShifts)
        Me.GroupBox1.Controls.Add(Me.optUseShifts)
        Me.GroupBox1.Controls.Add(Me.chkShift4)
        Me.GroupBox1.Controls.Add(Me.chkShift3)
        Me.GroupBox1.Controls.Add(Me.chkShift2)
        Me.GroupBox1.Controls.Add(Me.chkShift1)
        Me.GroupBox1.Location = New System.Drawing.Point(392, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 336)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Schichten:"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(181, 69)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Wählen Sie diesen Schichttyp, wenn Mitarbeiter beispielsweise in der ersten Woche" & _
            " in Schicht 1, in der zweiten in Schicht 2, in der dritten wieder in Schicht 1 u" & _
            "sw. arbeiten."
        '
        'nudAltShiftDays
        '
        Me.nudAltShiftDays.Location = New System.Drawing.Point(54, 171)
        Me.nudAltShiftDays.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.nudAltShiftDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAltShiftDays.Name = "nudAltShiftDays"
        Me.nudAltShiftDays.Size = New System.Drawing.Size(34, 20)
        Me.nudAltShiftDays.TabIndex = 7
        Me.nudAltShiftDays.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'btnAllShifts
        '
        Me.btnAllShifts.Location = New System.Drawing.Point(116, 45)
        Me.btnAllShifts.Name = "btnAllShifts"
        Me.btnAllShifts.Size = New System.Drawing.Size(68, 23)
        Me.btnAllShifts.TabIndex = 15
        Me.btnAllShifts.Text = "Alle"
        Me.btnAllShifts.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(107, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "wechseln."
        '
        'nudAltShift2
        '
        Me.nudAltShift2.Location = New System.Drawing.Point(67, 225)
        Me.nudAltShift2.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudAltShift2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAltShift2.Name = "nudAltShift2"
        Me.nudAltShift2.Size = New System.Drawing.Size(34, 20)
        Me.nudAltShift2.TabIndex = 13
        Me.nudAltShift2.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Schicht"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(106, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "und"
        '
        'nudAltShift1
        '
        Me.nudAltShift1.Location = New System.Drawing.Point(66, 199)
        Me.nudAltShift1.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudAltShift1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAltShift1.Name = "nudAltShift1"
        Me.nudAltShift1.Size = New System.Drawing.Size(34, 20)
        Me.nudAltShift1.TabIndex = 10
        Me.nudAltShift1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Schicht"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(94, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tage zwischen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Alle"
        '
        'optUseAlternatingShifts
        '
        Me.optUseAlternatingShifts.AutoSize = True
        Me.optUseAlternatingShifts.Location = New System.Drawing.Point(7, 149)
        Me.optUseAlternatingShifts.Name = "optUseAlternatingShifts"
        Me.optUseAlternatingShifts.Size = New System.Drawing.Size(116, 17)
        Me.optUseAlternatingShifts.TabIndex = 5
        Me.optUseAlternatingShifts.Text = "Wechselschichten:"
        Me.optUseAlternatingShifts.UseVisualStyleBackColor = True
        '
        'optUseShifts
        '
        Me.optUseShifts.AutoSize = True
        Me.optUseShifts.Checked = True
        Me.optUseShifts.Location = New System.Drawing.Point(9, 21)
        Me.optUseShifts.Name = "optUseShifts"
        Me.optUseShifts.Size = New System.Drawing.Size(183, 17)
        Me.optUseShifts.TabIndex = 0
        Me.optUseShifts.TabStop = True
        Me.optUseShifts.Text = "Folgende Schichten einbeziehen:"
        Me.optUseShifts.UseVisualStyleBackColor = True
        '
        'chkShift4
        '
        Me.chkShift4.AutoSize = True
        Me.chkShift4.Location = New System.Drawing.Point(21, 115)
        Me.chkShift4.Name = "chkShift4"
        Me.chkShift4.Size = New System.Drawing.Size(94, 17)
        Me.chkShift4.TabIndex = 4
        Me.chkShift4.Text = "Sonderschicht"
        Me.chkShift4.UseVisualStyleBackColor = True
        '
        'chkShift3
        '
        Me.chkShift3.AutoSize = True
        Me.chkShift3.Location = New System.Drawing.Point(21, 92)
        Me.chkShift3.Name = "chkShift3"
        Me.chkShift3.Size = New System.Drawing.Size(71, 17)
        Me.chkShift3.TabIndex = 3
        Me.chkShift3.Text = "Schicht 3"
        Me.chkShift3.UseVisualStyleBackColor = True
        '
        'chkShift2
        '
        Me.chkShift2.AutoSize = True
        Me.chkShift2.Location = New System.Drawing.Point(21, 69)
        Me.chkShift2.Name = "chkShift2"
        Me.chkShift2.Size = New System.Drawing.Size(71, 17)
        Me.chkShift2.TabIndex = 2
        Me.chkShift2.Text = "Schicht 2"
        Me.chkShift2.UseVisualStyleBackColor = True
        '
        'chkShift1
        '
        Me.chkShift1.AutoSize = True
        Me.chkShift1.Checked = True
        Me.chkShift1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShift1.Location = New System.Drawing.Point(21, 46)
        Me.chkShift1.Name = "chkShift1"
        Me.chkShift1.Size = New System.Drawing.Size(71, 17)
        Me.chkShift1.TabIndex = 1
        Me.chkShift1.Text = "Schicht 1"
        Me.chkShift1.UseVisualStyleBackColor = True
        '
        'drpMain
        '
        Me.drpMain.LastWorkingday = Facesso.Data.LastWorkingdays.Friday
        Me.drpMain.Location = New System.Drawing.Point(9, 34)
        Me.drpMain.Name = "drpMain"
        Me.drpMain.Size = New System.Drawing.Size(378, 338)
        Me.drpMain.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(362, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Schritt 1: Eingabe des Zeitraums und der Schichten:"
        '
        'Tab3SelectWorkgroups
        '
        Me.Tab3SelectWorkgroups.Controls.Add(Me.btnAllWorkGroupsInCostCenter)
        Me.Tab3SelectWorkgroups.Controls.Add(Me.btnUnSelectWorkGroups)
        Me.Tab3SelectWorkgroups.Controls.Add(Me.btnSelectAllWorkGroups)
        Me.Tab3SelectWorkgroups.Controls.Add(Me.wglWorkGroups)
        Me.Tab3SelectWorkgroups.Controls.Add(Me.Label25)
        Me.Tab3SelectWorkgroups.Location = New System.Drawing.Point(4, 22)
        Me.Tab3SelectWorkgroups.Name = "Tab3SelectWorkgroups"
        Me.Tab3SelectWorkgroups.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3SelectWorkgroups.Size = New System.Drawing.Size(650, 391)
        Me.Tab3SelectWorkgroups.TabIndex = 2
        Me.Tab3SelectWorkgroups.Text = "ChooseWorkgroups"
        '
        'btnAllWorkGroupsInCostCenter
        '
        Me.btnAllWorkGroupsInCostCenter.Location = New System.Drawing.Point(200, 337)
        Me.btnAllWorkGroupsInCostCenter.Name = "btnAllWorkGroupsInCostCenter"
        Me.btnAllWorkGroupsInCostCenter.Size = New System.Drawing.Size(197, 25)
        Me.btnAllWorkGroupsInCostCenter.TabIndex = 3
        Me.btnAllWorkGroupsInCostCenter.Text = "Alle in dieser Kostenstelle markieren"
        Me.btnAllWorkGroupsInCostCenter.UseVisualStyleBackColor = True
        '
        'btnUnSelectWorkGroups
        '
        Me.btnUnSelectWorkGroups.Location = New System.Drawing.Point(495, 337)
        Me.btnUnSelectWorkGroups.Name = "btnUnSelectWorkGroups"
        Me.btnUnSelectWorkGroups.Size = New System.Drawing.Size(133, 25)
        Me.btnUnSelectWorkGroups.TabIndex = 2
        Me.btnUnSelectWorkGroups.Text = "Selektierung aufheben"
        Me.btnUnSelectWorkGroups.UseVisualStyleBackColor = True
        '
        'btnSelectAllWorkGroups
        '
        Me.btnSelectAllWorkGroups.Location = New System.Drawing.Point(403, 337)
        Me.btnSelectAllWorkGroups.Name = "btnSelectAllWorkGroups"
        Me.btnSelectAllWorkGroups.Size = New System.Drawing.Size(86, 25)
        Me.btnSelectAllWorkGroups.TabIndex = 4
        Me.btnSelectAllWorkGroups.Text = "Alle markieren"
        Me.btnSelectAllWorkGroups.UseVisualStyleBackColor = True
        '
        'wglWorkGroups
        '
        Me.wglWorkGroups.AutoGroup = True
        Me.wglWorkGroups.FullRowSelect = True
        Me.wglWorkGroups.HideSelection = False
        Me.wglWorkGroups.Location = New System.Drawing.Point(9, 50)
        Me.wglWorkGroups.Name = "wglWorkGroups"
        Me.wglWorkGroups.OnlyActiveWorkgroups = True
        Me.wglWorkGroups.Size = New System.Drawing.Size(619, 281)
        Me.wglWorkGroups.TabIndex = 1
        Me.wglWorkGroups.UseCompatibleStateImageBehavior = False
        Me.wglWorkGroups.View = System.Windows.Forms.View.Details
        Me.wglWorkGroups.WorkGroupInfoItems = Nothing
        Me.wglWorkGroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(6, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(422, 16)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Schritt 2: Auswahl der mit einzubeziehenden Arbeitsgruppen:"
        '
        'Tab4TypeOfAnalysis
        '
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optWorkGroupListShiftwiseCompressed)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.lblDescription)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.Label14)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optWorkGroupListShiftWise)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optAnalysisLine)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optWorkGroupListShiftCondensed)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optBatch)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.optDetailed)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.chkIncludeSuspended)
        Me.Tab4TypeOfAnalysis.Controls.Add(Me.Label37)
        Me.Tab4TypeOfAnalysis.Location = New System.Drawing.Point(4, 22)
        Me.Tab4TypeOfAnalysis.Name = "Tab4TypeOfAnalysis"
        Me.Tab4TypeOfAnalysis.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab4TypeOfAnalysis.Size = New System.Drawing.Size(650, 391)
        Me.Tab4TypeOfAnalysis.TabIndex = 7
        Me.Tab4TypeOfAnalysis.Text = "TypeOfAnalysis"
        '
        'optWorkGroupListShiftwiseCompressed
        '
        Me.optWorkGroupListShiftwiseCompressed.AutoSize = True
        Me.optWorkGroupListShiftwiseCompressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWorkGroupListShiftwiseCompressed.Location = New System.Drawing.Point(14, 143)
        Me.optWorkGroupListShiftwiseCompressed.Name = "optWorkGroupListShiftwiseCompressed"
        Me.optWorkGroupListShiftwiseCompressed.Size = New System.Drawing.Size(610, 19)
        Me.optWorkGroupListShiftwiseCompressed.TabIndex = 11
        Me.optWorkGroupListShiftwiseCompressed.Text = "Produktiv-Site-Liste, schichtweise, kompakt: Wie vorheriger, kompakte Version. Al" & _
            "s einfache Tagesübersicht."
        Me.optWorkGroupListShiftwiseCompressed.UseVisualStyleBackColor = True
        '
        'lblDescription
        '
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescription.Location = New System.Drawing.Point(34, 218)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(599, 129)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 202)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(214, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Beschreibung für das ausgewählte Element:"
        Me.Label14.Visible = False
        '
        'optWorkGroupListShiftWise
        '
        Me.optWorkGroupListShiftWise.AutoSize = True
        Me.optWorkGroupListShiftWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWorkGroupListShiftWise.Location = New System.Drawing.Point(14, 121)
        Me.optWorkGroupListShiftWise.Name = "optWorkGroupListShiftWise"
        Me.optWorkGroupListShiftWise.Size = New System.Drawing.Size(588, 19)
        Me.optWorkGroupListShiftWise.TabIndex = 8
        Me.optWorkGroupListShiftWise.Text = "Produktiv-Site-Liste, schichtweise: Pro Produktiv-Site und Schicht eine Zeile als" & _
            " Liste, eine Liste pro Tag."
        Me.optWorkGroupListShiftWise.UseVisualStyleBackColor = True
        '
        'optAnalysisLine
        '
        Me.optAnalysisLine.AutoSize = True
        Me.optAnalysisLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optAnalysisLine.Location = New System.Drawing.Point(14, 168)
        Me.optAnalysisLine.Name = "optAnalysisLine"
        Me.optAnalysisLine.Size = New System.Drawing.Size(599, 19)
        Me.optAnalysisLine.TabIndex = 4
        Me.optAnalysisLine.Text = "Produktiv-Site-Auslastung schichtweise: Wie Produktiv-Site-Liste schichtweise, mi" & _
            "t Auslastungsinformation"
        Me.optAnalysisLine.UseVisualStyleBackColor = True
        '
        'optWorkGroupListShiftCondensed
        '
        Me.optWorkGroupListShiftCondensed.AutoSize = True
        Me.optWorkGroupListShiftCondensed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWorkGroupListShiftCondensed.Location = New System.Drawing.Point(14, 96)
        Me.optWorkGroupListShiftCondensed.Name = "optWorkGroupListShiftCondensed"
        Me.optWorkGroupListShiftCondensed.Size = New System.Drawing.Size(616, 19)
        Me.optWorkGroupListShiftCondensed.TabIndex = 3
        Me.optWorkGroupListShiftCondensed.Text = "Stapel, Schichten verdichtet: Pro Produktiv-Site eine Zeile mit Tagesergebnissen " & _
            "aller Schichten im Zeitraum."
        Me.optWorkGroupListShiftCondensed.UseVisualStyleBackColor = True
        '
        'optBatch
        '
        Me.optBatch.AutoSize = True
        Me.optBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBatch.Location = New System.Drawing.Point(14, 71)
        Me.optBatch.Name = "optBatch"
        Me.optBatch.Size = New System.Drawing.Size(565, 19)
        Me.optBatch.TabIndex = 2
        Me.optBatch.Text = "Stapelausdruck: Pro Produktiv-Site eine Liste, mit einem Element pro Tag; alle Sc" & _
            "hichten verdichtet."
        Me.optBatch.UseVisualStyleBackColor = True
        '
        'optDetailed
        '
        Me.optDetailed.AutoSize = True
        Me.optDetailed.Checked = True
        Me.optDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDetailed.Location = New System.Drawing.Point(14, 48)
        Me.optDetailed.Name = "optDetailed"
        Me.optDetailed.Size = New System.Drawing.Size(603, 19)
        Me.optDetailed.TabIndex = 1
        Me.optDetailed.TabStop = True
        Me.optDetailed.Text = "Detailliert: Pro Schicht, Datum und Produktiv-Site eine Seite mit Produktionserge" & _
            "bnis und Mitarbeiterzeiten"
        Me.optDetailed.UseVisualStyleBackColor = True
        '
        'chkIncludeSuspended
        '
        Me.chkIncludeSuspended.AutoSize = True
        Me.chkIncludeSuspended.Checked = True
        Me.chkIncludeSuspended.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeSuspended.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncludeSuspended.Location = New System.Drawing.Point(14, 366)
        Me.chkIncludeSuspended.Name = "chkIncludeSuspended"
        Me.chkIncludeSuspended.Size = New System.Drawing.Size(294, 19)
        Me.chkIncludeSuspended.TabIndex = 6
        Me.chkIncludeSuspended.Text = "Ausgesetzte Tage in die Auswertung einbeziehen"
        Me.chkIncludeSuspended.UseVisualStyleBackColor = True
        Me.chkIncludeSuspended.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(6, 9)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(503, 16)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Schritt 3: Bestimmen Sie, wie die Auswertung vorgenommen werden soll:"
        '
        'Tab5AnalysisDestination
        '
        Me.Tab5AnalysisDestination.Controls.Add(Me.btnSelectExportFile)
        Me.Tab5AnalysisDestination.Controls.Add(Me.lblExportFilename)
        Me.Tab5AnalysisDestination.Controls.Add(Me.optCSVExport)
        Me.Tab5AnalysisDestination.Controls.Add(Me.optPreviewBeforePrint)
        Me.Tab5AnalysisDestination.Controls.Add(Me.optTargetPrinter)
        Me.Tab5AnalysisDestination.Controls.Add(Me.Label27)
        Me.Tab5AnalysisDestination.Location = New System.Drawing.Point(4, 22)
        Me.Tab5AnalysisDestination.Name = "Tab5AnalysisDestination"
        Me.Tab5AnalysisDestination.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab5AnalysisDestination.Size = New System.Drawing.Size(650, 391)
        Me.Tab5AnalysisDestination.TabIndex = 3
        Me.Tab5AnalysisDestination.Text = "SelectFields"
        '
        'btnSelectExportFile
        '
        Me.btnSelectExportFile.Enabled = False
        Me.btnSelectExportFile.Location = New System.Drawing.Point(461, 188)
        Me.btnSelectExportFile.Name = "btnSelectExportFile"
        Me.btnSelectExportFile.Size = New System.Drawing.Size(139, 24)
        Me.btnSelectExportFile.TabIndex = 12
        Me.btnSelectExportFile.Text = "Speicherort..."
        Me.btnSelectExportFile.UseVisualStyleBackColor = True
        '
        'lblExportFilename
        '
        Me.lblExportFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExportFilename.Location = New System.Drawing.Point(108, 190)
        Me.lblExportFilename.Name = "lblExportFilename"
        Me.lblExportFilename.Size = New System.Drawing.Size(336, 23)
        Me.lblExportFilename.TabIndex = 13
        Me.lblExportFilename.Text = "unbenannt.csv"
        Me.lblExportFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optCSVExport
        '
        Me.optCSVExport.AutoSize = True
        Me.optCSVExport.Enabled = False
        Me.optCSVExport.Location = New System.Drawing.Point(89, 170)
        Me.optCSVExport.Name = "optCSVExport"
        Me.optCSVExport.Size = New System.Drawing.Size(345, 17)
        Me.optCSVExport.TabIndex = 11
        Me.optCSVExport.Text = "CSV-Export für die Excel-Weiterverarbeitung (nur Enterprise-Edition!)"
        Me.optCSVExport.UseVisualStyleBackColor = True
        '
        'optPreviewBeforePrint
        '
        Me.optPreviewBeforePrint.AutoSize = True
        Me.optPreviewBeforePrint.Checked = True
        Me.optPreviewBeforePrint.Location = New System.Drawing.Point(89, 126)
        Me.optPreviewBeforePrint.Name = "optPreviewBeforePrint"
        Me.optPreviewBeforePrint.Size = New System.Drawing.Size(151, 17)
        Me.optPreviewBeforePrint.TabIndex = 10
        Me.optPreviewBeforePrint.TabStop = True
        Me.optPreviewBeforePrint.Text = "Vorschau, dann drucken..."
        Me.optPreviewBeforePrint.UseVisualStyleBackColor = True
        '
        'optTargetPrinter
        '
        Me.optTargetPrinter.AutoSize = True
        Me.optTargetPrinter.Location = New System.Drawing.Point(89, 83)
        Me.optTargetPrinter.Name = "optTargetPrinter"
        Me.optTargetPrinter.Size = New System.Drawing.Size(190, 17)
        Me.optTargetPrinter.TabIndex = 9
        Me.optTargetPrinter.Text = "Direkt auf Drucker, ohne Vorschau"
        Me.optTargetPrinter.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(22, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(348, 16)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "Schritt 4: Bestimmen Sie das Ziel der Auswertung:"
        '
        'Tab6ExcelExport
        '
        Me.Tab6ExcelExport.Controls.Add(Me.lstDestFields)
        Me.Tab6ExcelExport.Controls.Add(Me.btnRemoveAllFields)
        Me.Tab6ExcelExport.Controls.Add(Me.btnRemoveField)
        Me.Tab6ExcelExport.Controls.Add(Me.btnAddField)
        Me.Tab6ExcelExport.Controls.Add(Me.btnAddAllFields)
        Me.Tab6ExcelExport.Controls.Add(Me.lstSourceFields)
        Me.Tab6ExcelExport.Controls.Add(Me.Label11)
        Me.Tab6ExcelExport.Controls.Add(Me.Label20)
        Me.Tab6ExcelExport.Location = New System.Drawing.Point(4, 22)
        Me.Tab6ExcelExport.Name = "Tab6ExcelExport"
        Me.Tab6ExcelExport.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab6ExcelExport.Size = New System.Drawing.Size(650, 391)
        Me.Tab6ExcelExport.TabIndex = 4
        Me.Tab6ExcelExport.Text = "AnalysisTarget"
        '
        'lstDestFields
        '
        Me.lstDestFields.FormattingEnabled = True
        Me.lstDestFields.Location = New System.Drawing.Point(357, 75)
        Me.lstDestFields.Name = "lstDestFields"
        Me.lstDestFields.Size = New System.Drawing.Size(166, 238)
        Me.lstDestFields.TabIndex = 15
        '
        'btnRemoveAllFields
        '
        Me.btnRemoveAllFields.Location = New System.Drawing.Point(256, 208)
        Me.btnRemoveAllFields.Name = "btnRemoveAllFields"
        Me.btnRemoveAllFields.Size = New System.Drawing.Size(86, 26)
        Me.btnRemoveAllFields.TabIndex = 14
        Me.btnRemoveAllFields.Text = "<< Alle"
        Me.btnRemoveAllFields.UseVisualStyleBackColor = True
        '
        'btnRemoveField
        '
        Me.btnRemoveField.Location = New System.Drawing.Point(256, 176)
        Me.btnRemoveField.Name = "btnRemoveField"
        Me.btnRemoveField.Size = New System.Drawing.Size(86, 26)
        Me.btnRemoveField.TabIndex = 13
        Me.btnRemoveField.Text = "<"
        Me.btnRemoveField.UseVisualStyleBackColor = True
        '
        'btnAddField
        '
        Me.btnAddField.Location = New System.Drawing.Point(256, 144)
        Me.btnAddField.Name = "btnAddField"
        Me.btnAddField.Size = New System.Drawing.Size(86, 26)
        Me.btnAddField.TabIndex = 12
        Me.btnAddField.Text = ">"
        Me.btnAddField.UseVisualStyleBackColor = True
        '
        'btnAddAllFields
        '
        Me.btnAddAllFields.Location = New System.Drawing.Point(256, 112)
        Me.btnAddAllFields.Name = "btnAddAllFields"
        Me.btnAddAllFields.Size = New System.Drawing.Size(86, 26)
        Me.btnAddAllFields.TabIndex = 11
        Me.btnAddAllFields.Text = "Alle >>"
        Me.btnAddAllFields.UseVisualStyleBackColor = True
        '
        'lstSourceFields
        '
        Me.lstSourceFields.FormattingEnabled = True
        Me.lstSourceFields.Location = New System.Drawing.Point(73, 75)
        Me.lstSourceFields.Name = "lstSourceFields"
        Me.lstSourceFields.Size = New System.Drawing.Size(166, 238)
        Me.lstSourceFields.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(70, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(438, 38)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Hinweis: Diese Einstellung findet nur in der Enterprise-Edition Berücksichtigung " & _
            "und gilt ausschließlich für den Excel-Datenexport!"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(548, 16)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Schritt 5: Bestimmen Sie die miteinzubeziehenden Datenfelder der Auswertung:"
        '
        'Tab8Finalize
        '
        Me.Tab8Finalize.Controls.Add(Me.txtConclusion)
        Me.Tab8Finalize.Controls.Add(Me.Label15)
        Me.Tab8Finalize.Controls.Add(Me.Label35)
        Me.Tab8Finalize.Controls.Add(Me.Label34)
        Me.Tab8Finalize.Controls.Add(Me.Label33)
        Me.Tab8Finalize.Location = New System.Drawing.Point(4, 22)
        Me.Tab8Finalize.Name = "Tab8Finalize"
        Me.Tab8Finalize.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab8Finalize.Size = New System.Drawing.Size(650, 391)
        Me.Tab8Finalize.TabIndex = 6
        Me.Tab8Finalize.Text = "Fertig"
        '
        'txtConclusion
        '
        Me.txtConclusion.Location = New System.Drawing.Point(56, 110)
        Me.txtConclusion.Multiline = True
        Me.txtConclusion.Name = "txtConclusion"
        Me.txtConclusion.ReadOnly = True
        Me.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConclusion.Size = New System.Drawing.Size(435, 220)
        Me.txtConclusion.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(50, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(441, 19)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Überprüfen Sie die Einstellungen in der folgenden Zusammenfassung:"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(50, 346)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(441, 20)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Klicken Sie schließlich auf [Fertig], um die Auswertung zu erstellen."
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(50, 41)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(441, 37)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Der Assistent hat alle erforderlichen Daten gesammelt, um eine Auswertung nach Ih" & _
            "ren Wünschen zu erstellen."
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(156, 16)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Assistent fertigstellen"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(717, 401)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 27)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(603, 401)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(97, 27)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Weiter >"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(500, 401)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(97, 27)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "< Zurück"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Blue
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 394)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'frmWorkGroupAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 437)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tcWizard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmWorkGroupAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistent zur Durchführung von Produktiv-Sites-Analysen"
        Me.tcWizard.ResumeLayout(False)
        Me.TabBase.ResumeLayout(False)
        Me.TabBase.PerformLayout()
        Me.Tab2Period.ResumeLayout(False)
        Me.Tab2Period.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAltShiftDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAltShift2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAltShift1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3SelectWorkgroups.ResumeLayout(False)
        Me.Tab3SelectWorkgroups.PerformLayout()
        Me.Tab4TypeOfAnalysis.ResumeLayout(False)
        Me.Tab4TypeOfAnalysis.PerformLayout()
        Me.Tab5AnalysisDestination.ResumeLayout(False)
        Me.Tab5AnalysisDestination.PerformLayout()
        Me.Tab6ExcelExport.ResumeLayout(False)
        Me.Tab6ExcelExport.PerformLayout()
        Me.Tab8Finalize.ResumeLayout(False)
        Me.Tab8Finalize.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcWizard As System.Windows.Forms.TabControl
    Friend WithEvents TabBase As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tab2Period As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Tab3SelectWorkgroups As System.Windows.Forms.TabPage
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Tab4TypeOfAnalysis As System.Windows.Forms.TabPage
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Tab5AnalysisDestination As System.Windows.Forms.TabPage
    Friend WithEvents Tab6ExcelExport As System.Windows.Forms.TabPage
    Friend WithEvents Tab8Finalize As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents drpMain As Facesso.FrontEnd.ucAnalysisDateRangePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optUseAlternatingShifts As System.Windows.Forms.RadioButton
    Friend WithEvents optUseShifts As System.Windows.Forms.RadioButton
    Friend WithEvents chkShift4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnAllShifts As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudAltShift2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudAltShift1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnUnSelectWorkGroups As System.Windows.Forms.Button
    Friend WithEvents btnSelectAllWorkGroups As System.Windows.Forms.Button
    Friend WithEvents wglWorkGroups As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeSuspended As System.Windows.Forms.CheckBox
    Friend WithEvents btnAllWorkGroupsInCostCenter As System.Windows.Forms.Button
    Friend WithEvents nudAltShiftDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtConclusion As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents optDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents optAnalysisLine As System.Windows.Forms.RadioButton
    Friend WithEvents optWorkGroupListShiftCondensed As System.Windows.Forms.RadioButton
    Friend WithEvents optBatch As System.Windows.Forms.RadioButton
    Friend WithEvents btnSelectExportFile As System.Windows.Forms.Button
    Friend WithEvents lblExportFilename As System.Windows.Forms.Label
    Friend WithEvents optCSVExport As System.Windows.Forms.RadioButton
    Friend WithEvents optPreviewBeforePrint As System.Windows.Forms.RadioButton
    Friend WithEvents optTargetPrinter As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lstDestFields As System.Windows.Forms.ListBox
    Friend WithEvents btnRemoveAllFields As System.Windows.Forms.Button
    Friend WithEvents btnRemoveField As System.Windows.Forms.Button
    Friend WithEvents btnAddField As System.Windows.Forms.Button
    Friend WithEvents btnAddAllFields As System.Windows.Forms.Button
    Friend WithEvents lstSourceFields As System.Windows.Forms.ListBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents optWorkGroupListShiftWise As System.Windows.Forms.RadioButton
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents optWorkGroupListShiftwiseCompressed As System.Windows.Forms.RadioButton
End Class
