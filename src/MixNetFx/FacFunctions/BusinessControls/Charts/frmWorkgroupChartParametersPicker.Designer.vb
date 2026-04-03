<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkgroupChartParametersPicker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkgroupChartParametersPicker))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudAltShiftDays = New System.Windows.Forms.NumericUpDown()
        Me.btnAllShifts = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudAltShift2 = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudAltShift1 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optUseAlternatingShifts = New System.Windows.Forms.RadioButton()
        Me.optUseShifts = New System.Windows.Forms.RadioButton()
        Me.chkShift4 = New System.Windows.Forms.CheckBox()
        Me.chkShift3 = New System.Windows.Forms.CheckBox()
        Me.chkShift2 = New System.Windows.Forms.CheckBox()
        Me.chkShift1 = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optPickedSites = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optWorst = New System.Windows.Forms.RadioButton()
        Me.optBest = New System.Windows.Forms.RadioButton()
        Me.nivBestWorstCount = New ActiveDevelop.EntitiesFormsLib.NullableIntValue()
        Me.wglWorkgroups = New Facesso.FrontEnd.ucWorkGroupListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnResetDeltaValues = New System.Windows.Forms.Button()
        Me.chkAutomaticTimeOfDegreeRange = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbDegreeOfTimeFrom = New System.Windows.Forms.TrackBar()
        Me.txtTimeOfDegreeRangeTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbDegreeOfTimeTo = New System.Windows.Forms.TrackBar()
        Me.txtTimeOfDegreeRangeFrom = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.opt3DChart = New System.Windows.Forms.RadioButton()
        Me.opt2DChart = New System.Windows.Forms.RadioButton()
        Me.txtChartTitel = New System.Windows.Forms.TextBox()
        Me.drpMain = New Facesso.FrontEnd.ucAnalysisDateRangePicker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAltShiftDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAltShift2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAltShift1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.tbDegreeOfTimeFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDegreeOfTimeTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(360, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 305)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Schichten:"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(255, 53)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Wählen Sie diesen Schichttyp, wenn Mitarbeiter beispielsweise in der ersten Woche" & _
    " in Schicht 1, in der zweiten in Schicht 2, in der dritten wieder in Schicht 1 u" & _
    "sw. arbeiten."
        '
        'nudAltShiftDays
        '
        Me.nudAltShiftDays.Location = New System.Drawing.Point(54, 157)
        Me.nudAltShiftDays.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.nudAltShiftDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAltShiftDays.Name = "nudAltShiftDays"
        Me.nudAltShiftDays.Size = New System.Drawing.Size(34, 20)
        Me.nudAltShiftDays.TabIndex = 7
        Me.nudAltShiftDays.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'btnAllShifts
        '
        Me.btnAllShifts.Location = New System.Drawing.Point(163, 44)
        Me.btnAllShifts.Name = "btnAllShifts"
        Me.btnAllShifts.Size = New System.Drawing.Size(68, 23)
        Me.btnAllShifts.TabIndex = 15
        Me.btnAllShifts.Text = "Alle"
        Me.btnAllShifts.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(107, 214)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "wechseln."
        '
        'nudAltShift2
        '
        Me.nudAltShift2.Location = New System.Drawing.Point(67, 211)
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
        Me.Label10.Location = New System.Drawing.Point(19, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Schicht"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(106, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "und"
        '
        'nudAltShift1
        '
        Me.nudAltShift1.Location = New System.Drawing.Point(66, 185)
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
        Me.Label7.Location = New System.Drawing.Point(18, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Schicht"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(94, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tage zwischen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Alle"
        '
        'optUseAlternatingShifts
        '
        Me.optUseAlternatingShifts.AutoSize = True
        Me.optUseAlternatingShifts.Location = New System.Drawing.Point(7, 139)
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
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(638, 28)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(101, 28)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(638, 58)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 30)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.optPickedSites)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.optWorst)
        Me.GroupBox2.Controls.Add(Me.optBest)
        Me.GroupBox2.Controls.Add(Me.nivBestWorstCount)
        Me.GroupBox2.Controls.Add(Me.wglWorkgroups)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 327)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(345, 343)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Produktiv-Sites:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(322, 43)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "HINWEIS: Wählen Sie MEHRERE Schichten, aber nur EINE Produktiv-Site aus, erstellt" & _
    " Facesso ein Schichtvergleich-Diagramm über die entsprechende Arbeitsgruppe."
        '
        'optPickedSites
        '
        Me.optPickedSites.AutoSize = True
        Me.optPickedSites.Location = New System.Drawing.Point(9, 62)
        Me.optPickedSites.Name = "optPickedSites"
        Me.optPickedSites.Size = New System.Drawing.Size(237, 17)
        Me.optPickedSites.TabIndex = 13
        Me.optPickedSites.Text = "Die folgenden ausgewählten Produktiv-Sites:"
        Me.optPickedSites.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Die"
        '
        'optWorst
        '
        Me.optWorst.AutoSize = True
        Me.optWorst.Location = New System.Drawing.Point(175, 34)
        Me.optWorst.Name = "optWorst"
        Me.optWorst.Size = New System.Drawing.Size(91, 17)
        Me.optWorst.TabIndex = 11
        Me.optWorst.Text = "schlechtesten"
        Me.optWorst.UseVisualStyleBackColor = True
        '
        'optBest
        '
        Me.optBest.AutoSize = True
        Me.optBest.Checked = True
        Me.optBest.Location = New System.Drawing.Point(111, 34)
        Me.optBest.Name = "optBest"
        Me.optBest.Size = New System.Drawing.Size(57, 17)
        Me.optBest.TabIndex = 10
        Me.optBest.TabStop = True
        Me.optBest.Text = "besten"
        Me.optBest.UseVisualStyleBackColor = True
        '
        'nivBestWorstCount
        '
        Me.nivBestWorstCount.AssignedManagerComponent = Nothing
        Me.nivBestWorstCount.Borderstyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.nivBestWorstCount.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.nivBestWorstCount.Location = New System.Drawing.Point(56, 33)
        Me.nivBestWorstCount.MaxLength = 32767
        Me.nivBestWorstCount.Name = "nivBestWorstCount"
        Me.nivBestWorstCount.ObfuscationChar = Nothing
        Me.nivBestWorstCount.PermissionReason = Nothing
        Me.nivBestWorstCount.Size = New System.Drawing.Size(41, 20)
        Me.nivBestWorstCount.TabIndex = 9
        Me.nivBestWorstCount.UIGuid = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.nivBestWorstCount.Value = 5
        '
        'wglWorkgroups
        '
        Me.wglWorkgroups.AutoGroup = True
        Me.wglWorkgroups.Enabled = False
        Me.wglWorkgroups.FullRowSelect = True
        Me.wglWorkgroups.HideSelection = False
        Me.wglWorkgroups.Location = New System.Drawing.Point(9, 88)
        Me.wglWorkgroups.Name = "wglWorkgroups"
        Me.wglWorkgroups.OnlyActiveWorkgroups = True
        Me.wglWorkgroups.Size = New System.Drawing.Size(319, 192)
        Me.wglWorkgroups.TabIndex = 8
        Me.wglWorkgroups.UseCompatibleStateImageBehavior = False
        Me.wglWorkgroups.View = System.Windows.Forms.View.Details
        Me.wglWorkgroups.WorkGroupInfoItems = Nothing
        Me.wglWorkgroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Chart-Titel:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.txtChartTitel)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(360, 327)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 343)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chart-Parameter:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnResetDeltaValues)
        Me.GroupBox5.Controls.Add(Me.chkAutomaticTimeOfDegreeRange)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.tbDegreeOfTimeFrom)
        Me.GroupBox5.Controls.Add(Me.txtTimeOfDegreeRangeTo)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.tbDegreeOfTimeTo)
        Me.GroupBox5.Controls.Add(Me.txtTimeOfDegreeRangeFrom)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 180)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(254, 156)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Zeitgrad-Bereich im Chart:"
        Me.GroupBox5.Visible = False
        '
        'btnResetDeltaValues
        '
        Me.btnResetDeltaValues.Location = New System.Drawing.Point(167, 130)
        Me.btnResetDeltaValues.Name = "btnResetDeltaValues"
        Me.btnResetDeltaValues.Size = New System.Drawing.Size(81, 20)
        Me.btnResetDeltaValues.TabIndex = 7
        Me.btnResetDeltaValues.Text = "&Zurücksetzen"
        Me.btnResetDeltaValues.UseVisualStyleBackColor = True
        '
        'chkAutomaticTimeOfDegreeRange
        '
        Me.chkAutomaticTimeOfDegreeRange.AutoSize = True
        Me.chkAutomaticTimeOfDegreeRange.Location = New System.Drawing.Point(34, 22)
        Me.chkAutomaticTimeOfDegreeRange.Name = "chkAutomaticTimeOfDegreeRange"
        Me.chkAutomaticTimeOfDegreeRange.Size = New System.Drawing.Size(83, 17)
        Me.chkAutomaticTimeOfDegreeRange.TabIndex = 6
        Me.chkAutomaticTimeOfDegreeRange.Text = "automatisch"
        Me.chkAutomaticTimeOfDegreeRange.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "bis:"
        '
        'tbDegreeOfTimeFrom
        '
        Me.tbDegreeOfTimeFrom.Location = New System.Drawing.Point(48, 49)
        Me.tbDegreeOfTimeFrom.Maximum = 100
        Me.tbDegreeOfTimeFrom.Minimum = 20
        Me.tbDegreeOfTimeFrom.Name = "tbDegreeOfTimeFrom"
        Me.tbDegreeOfTimeFrom.Size = New System.Drawing.Size(200, 45)
        Me.tbDegreeOfTimeFrom.TabIndex = 4
        Me.tbDegreeOfTimeFrom.Value = 80
        '
        'txtTimeOfDegreeRangeTo
        '
        Me.txtTimeOfDegreeRangeTo.Location = New System.Drawing.Point(10, 103)
        Me.txtTimeOfDegreeRangeTo.Name = "txtTimeOfDegreeRangeTo"
        Me.txtTimeOfDegreeRangeTo.ReadOnly = True
        Me.txtTimeOfDegreeRangeTo.Size = New System.Drawing.Size(32, 20)
        Me.txtTimeOfDegreeRangeTo.TabIndex = 3
        Me.txtTimeOfDegreeRangeTo.Text = "140"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "von:"
        '
        'tbDegreeOfTimeTo
        '
        Me.tbDegreeOfTimeTo.LargeChange = 10
        Me.tbDegreeOfTimeTo.Location = New System.Drawing.Point(48, 94)
        Me.tbDegreeOfTimeTo.Maximum = 200
        Me.tbDegreeOfTimeTo.Minimum = 80
        Me.tbDegreeOfTimeTo.Name = "tbDegreeOfTimeTo"
        Me.tbDegreeOfTimeTo.Size = New System.Drawing.Size(200, 45)
        Me.tbDegreeOfTimeTo.SmallChange = 5
        Me.tbDegreeOfTimeTo.TabIndex = 1
        Me.tbDegreeOfTimeTo.Value = 140
        '
        'txtTimeOfDegreeRangeFrom
        '
        Me.txtTimeOfDegreeRangeFrom.Location = New System.Drawing.Point(10, 60)
        Me.txtTimeOfDegreeRangeFrom.Name = "txtTimeOfDegreeRangeFrom"
        Me.txtTimeOfDegreeRangeFrom.ReadOnly = True
        Me.txtTimeOfDegreeRangeFrom.Size = New System.Drawing.Size(32, 20)
        Me.txtTimeOfDegreeRangeFrom.TabIndex = 0
        Me.txtTimeOfDegreeRangeFrom.Text = "80"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.opt3DChart)
        Me.GroupBox4.Controls.Add(Me.opt2DChart)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(254, 70)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Chart-Typ:"
        Me.GroupBox4.Visible = False
        '
        'opt3DChart
        '
        Me.opt3DChart.AutoSize = True
        Me.opt3DChart.Location = New System.Drawing.Point(9, 42)
        Me.opt3DChart.Name = "opt3DChart"
        Me.opt3DChart.Size = New System.Drawing.Size(98, 17)
        Me.opt3DChart.TabIndex = 13
        Me.opt3DChart.Text = "3D-Linien-Chart"
        Me.opt3DChart.UseVisualStyleBackColor = True
        '
        'opt2DChart
        '
        Me.opt2DChart.AutoSize = True
        Me.opt2DChart.Checked = True
        Me.opt2DChart.Location = New System.Drawing.Point(9, 19)
        Me.opt2DChart.Name = "opt2DChart"
        Me.opt2DChart.Size = New System.Drawing.Size(98, 17)
        Me.opt2DChart.TabIndex = 12
        Me.opt2DChart.TabStop = True
        Me.opt2DChart.Text = "2D-Linien-Chart"
        Me.opt2DChart.UseVisualStyleBackColor = True
        '
        'txtChartTitel
        '
        Me.txtChartTitel.Location = New System.Drawing.Point(6, 49)
        Me.txtChartTitel.Name = "txtChartTitel"
        Me.txtChartTitel.Size = New System.Drawing.Size(260, 20)
        Me.txtChartTitel.TabIndex = 9
        Me.txtChartTitel.Text = "Arbeitsgruppen-Charting"
        '
        'drpMain
        '
        Me.drpMain.LastWorkingday = Facesso.Data.LastWorkingdays.Friday
        Me.drpMain.Location = New System.Drawing.Point(12, 12)
        Me.drpMain.Name = "drpMain"
        Me.drpMain.Size = New System.Drawing.Size(346, 318)
        Me.drpMain.TabIndex = 3
        Me.drpMain.Text = "Zeitbereich der Produktiv-Site-Analyse:"
        '
        'frmWorkgroupChartParametersPicker
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(748, 675)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.drpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWorkgroupChartParametersPicker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bearbeiten der Chart-Auswertungsparameter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAltShiftDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAltShift2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAltShift1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.tbDegreeOfTimeFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDegreeOfTimeTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nudAltShiftDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAllShifts As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudAltShift2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudAltShift1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optUseAlternatingShifts As System.Windows.Forms.RadioButton
    Friend WithEvents optUseShifts As System.Windows.Forms.RadioButton
    Friend WithEvents chkShift4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift1 As System.Windows.Forms.CheckBox
    Friend WithEvents drpMain As Facesso.FrontEnd.ucAnalysisDateRangePicker
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optWorst As System.Windows.Forms.RadioButton
    Friend WithEvents optBest As System.Windows.Forms.RadioButton
    Friend WithEvents nivBestWorstCount As ActiveDevelop.EntitiesFormsLib.NullableIntValue
    Friend WithEvents wglWorkgroups As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents optPickedSites As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAutomaticTimeOfDegreeRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbDegreeOfTimeFrom As System.Windows.Forms.TrackBar
    Friend WithEvents txtTimeOfDegreeRangeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbDegreeOfTimeTo As System.Windows.Forms.TrackBar
    Friend WithEvents txtTimeOfDegreeRangeFrom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents opt3DChart As System.Windows.Forms.RadioButton
    Friend WithEvents opt2DChart As System.Windows.Forms.RadioButton
    Friend WithEvents txtChartTitel As System.Windows.Forms.TextBox
    Friend WithEvents btnResetDeltaValues As System.Windows.Forms.Button
End Class
