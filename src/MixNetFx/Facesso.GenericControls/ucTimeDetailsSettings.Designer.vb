<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ucTimeDetailsSettings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnReset = New System.Windows.Forms.Button
        Me.lblShiftInformer = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblImportEndTimeDateDescription = New System.Windows.Forms.Label
        Me.ndbImportTimeStart = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbImportTimeEnd = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.lbTimes = New System.Windows.Forms.ListBox
        Me.btnEndDate = New System.Windows.Forms.Button
        Me.btnStartDate = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnWD_07_Sunday = New System.Windows.Forms.Button
        Me.btnWD_06_Saturday = New System.Windows.Forms.Button
        Me.btnWD_05_Friday = New System.Windows.Forms.Button
        Me.btnWD_04_Thursday = New System.Windows.Forms.Button
        Me.btnWD_03_Wednesday = New System.Windows.Forms.Button
        Me.btnWD_02_Tuesday = New System.Windows.Forms.Button
        Me.btnWD_01_Monday = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnGeneric = New System.Windows.Forms.Button
        Me.ncbForceToHavePause = New ActiveDev.Controls.ADNullableCheckBox
        Me.nibThreshold = New ActiveDev.Controls.ADNullableIntBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ndbRoundDownAfter = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ndbRoundUpBefore = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.nibPausetime = New ActiveDev.Controls.ADNullableIntBox
        Me.lblEndTimeDateDecription = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ndbCoreTimeStart = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbCoreTimeEnd = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.tcShifts = New System.Windows.Forms.TabControl
        Me.tpShift1 = New System.Windows.Forms.TabPage
        Me.tpShift2 = New System.Windows.Forms.TabPage
        Me.tpShift3 = New System.Windows.Forms.TabPage
        Me.tpShift4 = New System.Windows.Forms.TabPage
        Me.Panel2.SuspendLayout()
        Me.tcShifts.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.lblShiftInformer)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lblImportEndTimeDateDescription)
        Me.Panel2.Controls.Add(Me.ndbImportTimeStart)
        Me.Panel2.Controls.Add(Me.ndbImportTimeEnd)
        Me.Panel2.Controls.Add(Me.lbTimes)
        Me.Panel2.Controls.Add(Me.btnEndDate)
        Me.Panel2.Controls.Add(Me.btnStartDate)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.btnWD_07_Sunday)
        Me.Panel2.Controls.Add(Me.btnWD_06_Saturday)
        Me.Panel2.Controls.Add(Me.btnWD_05_Friday)
        Me.Panel2.Controls.Add(Me.btnWD_04_Thursday)
        Me.Panel2.Controls.Add(Me.btnWD_03_Wednesday)
        Me.Panel2.Controls.Add(Me.btnWD_02_Tuesday)
        Me.Panel2.Controls.Add(Me.btnWD_01_Monday)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnGeneric)
        Me.Panel2.Controls.Add(Me.ncbForceToHavePause)
        Me.Panel2.Controls.Add(Me.nibThreshold)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.ndbRoundDownAfter)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.ndbRoundUpBefore)
        Me.Panel2.Controls.Add(Me.nibPausetime)
        Me.Panel2.Controls.Add(Me.lblEndTimeDateDecription)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ndbCoreTimeStart)
        Me.Panel2.Controls.Add(Me.ndbCoreTimeEnd)
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(567, 445)
        Me.Panel2.TabIndex = 1
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(496, 25)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(61, 24)
        Me.btnReset.TabIndex = 35
        Me.btnReset.Text = "Reset..."
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblShiftInformer
        '
        Me.lblShiftInformer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblShiftInformer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftInformer.Location = New System.Drawing.Point(19, 55)
        Me.lblShiftInformer.Name = "lblShiftInformer"
        Me.lblShiftInformer.Size = New System.Drawing.Size(169, 22)
        Me.lblShiftInformer.TabIndex = 34
        Me.lblShiftInformer.Text = "für Schicht 1"
        Me.lblShiftInformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "(Abweichend für Datenimport:)"
        '
        'lblImportEndTimeDateDescription
        '
        Me.lblImportEndTimeDateDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportEndTimeDateDescription.Location = New System.Drawing.Point(445, 182)
        Me.lblImportEndTimeDateDescription.Name = "lblImportEndTimeDateDescription"
        Me.lblImportEndTimeDateDescription.Size = New System.Drawing.Size(94, 17)
        Me.lblImportEndTimeDateDescription.TabIndex = 6
        Me.lblImportEndTimeDateDescription.Text = "(Der Folgetag)"
        Me.lblImportEndTimeDateDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ndbImportTimeStart
        '
        Me.ndbImportTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbImportTimeStart.BackColor = System.Drawing.SystemColors.Window
        Me.ndbImportTimeStart.CaptionToValueRatio = 601.35
        Me.ndbImportTimeStart.ColorOnFocus = True
        Me.ndbImportTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbImportTimeStart.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbImportTimeStart.HasCaption = True
        Me.ndbImportTimeStart.IndependentDatafieldName = Nothing
        Me.ndbImportTimeStart.Location = New System.Drawing.Point(22, 177)
        Me.ndbImportTimeStart.Name = "ndbImportTimeStart"
        Me.ndbImportTimeStart.NullString = "* --- *"
        Me.ndbImportTimeStart.NullValueMessage = Nothing
        Me.ndbImportTimeStart.Size = New System.Drawing.Size(296, 22)
        Me.ndbImportTimeStart.TabIndex = 4
        Me.ndbImportTimeStart.Text = "Schicht Beginn/Ende:"
        Me.ndbImportTimeStart.ValueAreaLength = 118
        '
        'ndbImportTimeEnd
        '
        Me.ndbImportTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbImportTimeEnd.BackColor = System.Drawing.SystemColors.Window
        Me.ndbImportTimeEnd.CaptionToValueRatio = 0
        Me.ndbImportTimeEnd.ColorOnFocus = True
        Me.ndbImportTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbImportTimeEnd.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbImportTimeEnd.HasCaption = False
        Me.ndbImportTimeEnd.IndependentDatafieldName = Nothing
        Me.ndbImportTimeEnd.Location = New System.Drawing.Point(324, 177)
        Me.ndbImportTimeEnd.Name = "ndbImportTimeEnd"
        Me.ndbImportTimeEnd.NullString = "* --- *"
        Me.ndbImportTimeEnd.NullValueMessage = Nothing
        Me.ndbImportTimeEnd.Size = New System.Drawing.Size(118, 22)
        Me.ndbImportTimeEnd.TabIndex = 5
        Me.ndbImportTimeEnd.Text = "Schicht-1-Kernzeiten: Beginn/Ende:"
        Me.ndbImportTimeEnd.ValueAreaLength = 118
        '
        'lbTimes
        '
        Me.lbTimes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTimes.FormattingEnabled = True
        Me.lbTimes.HorizontalScrollbar = True
        Me.lbTimes.ItemHeight = 14
        Me.lbTimes.Location = New System.Drawing.Point(23, 347)
        Me.lbTimes.Name = "lbTimes"
        Me.lbTimes.Size = New System.Drawing.Size(534, 88)
        Me.lbTimes.TabIndex = 14
        '
        'btnEndDate
        '
        Me.btnEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEndDate.Location = New System.Drawing.Point(320, 108)
        Me.btnEndDate.Name = "btnEndDate"
        Me.btnEndDate.Size = New System.Drawing.Size(119, 23)
        Me.btnEndDate.TabIndex = 12
        Me.btnEndDate.Text = "(Datum)"
        '
        'btnStartDate
        '
        Me.btnStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartDate.Location = New System.Drawing.Point(196, 108)
        Me.btnStartDate.Name = "btnStartDate"
        Me.btnStartDate.Size = New System.Drawing.Size(119, 23)
        Me.btnStartDate.TabIndex = 11
        Me.btnStartDate.Text = "(Datum)"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(220, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(300, 33)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "HINWEIS: Tage ohne eigene Definition (nicht fett markiert), erben automatisch die" & _
            " Einstellungen von [für alle Wochentage]!"
        '
        'btnWD_07_Sunday
        '
        Me.btnWD_07_Sunday.Location = New System.Drawing.Point(443, 25)
        Me.btnWD_07_Sunday.Name = "btnWD_07_Sunday"
        Me.btnWD_07_Sunday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_07_Sunday.TabIndex = 23
        Me.btnWD_07_Sunday.Text = "So"
        '
        'btnWD_06_Saturday
        '
        Me.btnWD_06_Saturday.Location = New System.Drawing.Point(406, 25)
        Me.btnWD_06_Saturday.Name = "btnWD_06_Saturday"
        Me.btnWD_06_Saturday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_06_Saturday.TabIndex = 22
        Me.btnWD_06_Saturday.Text = "Sa"
        '
        'btnWD_05_Friday
        '
        Me.btnWD_05_Friday.Location = New System.Drawing.Point(369, 25)
        Me.btnWD_05_Friday.Name = "btnWD_05_Friday"
        Me.btnWD_05_Friday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_05_Friday.TabIndex = 21
        Me.btnWD_05_Friday.Text = "Fr"
        '
        'btnWD_04_Thursday
        '
        Me.btnWD_04_Thursday.Location = New System.Drawing.Point(332, 25)
        Me.btnWD_04_Thursday.Name = "btnWD_04_Thursday"
        Me.btnWD_04_Thursday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_04_Thursday.TabIndex = 20
        Me.btnWD_04_Thursday.Text = "Do"
        '
        'btnWD_03_Wednesday
        '
        Me.btnWD_03_Wednesday.Location = New System.Drawing.Point(295, 25)
        Me.btnWD_03_Wednesday.Name = "btnWD_03_Wednesday"
        Me.btnWD_03_Wednesday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_03_Wednesday.TabIndex = 19
        Me.btnWD_03_Wednesday.Text = "Mi"
        '
        'btnWD_02_Tuesday
        '
        Me.btnWD_02_Tuesday.Location = New System.Drawing.Point(258, 25)
        Me.btnWD_02_Tuesday.Name = "btnWD_02_Tuesday"
        Me.btnWD_02_Tuesday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_02_Tuesday.TabIndex = 18
        Me.btnWD_02_Tuesday.Text = "Di"
        '
        'btnWD_01_Monday
        '
        Me.btnWD_01_Monday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWD_01_Monday.Location = New System.Drawing.Point(221, 25)
        Me.btnWD_01_Monday.Name = "btnWD_01_Monday"
        Me.btnWD_01_Monday.Size = New System.Drawing.Size(38, 25)
        Me.btnWD_01_Monday.TabIndex = 17
        Me.btnWD_01_Monday.Text = "Mo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(201, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "für:"
        '
        'btnGeneric
        '
        Me.btnGeneric.BackColor = System.Drawing.Color.Yellow
        Me.btnGeneric.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneric.Location = New System.Drawing.Point(19, 25)
        Me.btnGeneric.Name = "btnGeneric"
        Me.btnGeneric.Size = New System.Drawing.Size(174, 25)
        Me.btnGeneric.TabIndex = 15
        Me.btnGeneric.Text = "Für alle Wochentage"
        Me.btnGeneric.UseVisualStyleBackColor = False
        '
        'ncbForceToHavePause
        '
        Me.ncbForceToHavePause.CaptionToValueRatio = 600
        Me.ncbForceToHavePause.ColorOnFocus = True
        Me.ncbForceToHavePause.FailedValidationErrorMessage = Nothing
        Me.ncbForceToHavePause.HasCaption = True
        Me.ncbForceToHavePause.IndependentDatafieldName = Nothing
        Me.ncbForceToHavePause.Location = New System.Drawing.Point(23, 320)
        Me.ncbForceToHavePause.Name = "ncbForceToHavePause"
        Me.ncbForceToHavePause.NullString = Nothing
        Me.ncbForceToHavePause.NullValueMessage = Nothing
        Me.ncbForceToHavePause.Size = New System.Drawing.Size(295, 19)
        Me.ncbForceToHavePause.TabIndex = 13
        Me.ncbForceToHavePause.Text = "Pause in Schicht erzwingen:"
        Me.ncbForceToHavePause.ValueAreaLength = 118
        '
        'nibThreshold
        '
        Me.nibThreshold.BackColor = System.Drawing.SystemColors.Window
        Me.nibThreshold.CaptionToValueRatio = 0
        Me.nibThreshold.ColorOnFocus = True
        Me.nibThreshold.FailedValidationErrorMessage = Nothing
        Me.nibThreshold.FormularText = ""
        Me.nibThreshold.HasCaption = False
        Me.nibThreshold.IndependentDatafieldName = Nothing
        Me.nibThreshold.Location = New System.Drawing.Point(324, 289)
        Me.nibThreshold.MaxValue = 0
        Me.nibThreshold.MinValue = 0
        Me.nibThreshold.Name = "nibThreshold"
        Me.nibThreshold.NullString = "* --- *"
        Me.nibThreshold.NullValueMessage = Nothing
        Me.nibThreshold.Size = New System.Drawing.Size(118, 22)
        Me.nibThreshold.TabIndex = 12
        Me.nibThreshold.Text = "AdNullableIntBox2"
        Me.nibThreshold.ValueAreaLength = 118
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(324, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "enden, abrunden."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ndbRoundDownAfter
        '
        Me.ndbRoundDownAfter.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbRoundDownAfter.BackColor = System.Drawing.SystemColors.Window
        Me.ndbRoundDownAfter.CaptionToValueRatio = 601.35
        Me.ndbRoundDownAfter.ColorOnFocus = True
        Me.ndbRoundDownAfter.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.CombinedShort
        Me.ndbRoundDownAfter.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbRoundDownAfter.HasCaption = True
        Me.ndbRoundDownAfter.IndependentDatafieldName = Nothing
        Me.ndbRoundDownAfter.Location = New System.Drawing.Point(22, 241)
        Me.ndbRoundDownAfter.Name = "ndbRoundDownAfter"
        Me.ndbRoundDownAfter.NullString = "* --- *"
        Me.ndbRoundDownAfter.NullValueMessage = Nothing
        Me.ndbRoundDownAfter.Size = New System.Drawing.Size(296, 22)
        Me.ndbRoundDownAfter.TabIndex = 9
        Me.ndbRoundDownAfter.Text = "Buchungen, die nach"
        Me.ndbRoundDownAfter.ValueAreaLength = 118
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(324, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "beginnen, aufrunden."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ndbRoundUpBefore
        '
        Me.ndbRoundUpBefore.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbRoundUpBefore.BackColor = System.Drawing.SystemColors.Window
        Me.ndbRoundUpBefore.CaptionToValueRatio = 601.35
        Me.ndbRoundUpBefore.ColorOnFocus = True
        Me.ndbRoundUpBefore.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.CombinedShort
        Me.ndbRoundUpBefore.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbRoundUpBefore.HasCaption = True
        Me.ndbRoundUpBefore.IndependentDatafieldName = Nothing
        Me.ndbRoundUpBefore.Location = New System.Drawing.Point(22, 212)
        Me.ndbRoundUpBefore.Name = "ndbRoundUpBefore"
        Me.ndbRoundUpBefore.NullString = "* --- *"
        Me.ndbRoundUpBefore.NullValueMessage = Nothing
        Me.ndbRoundUpBefore.Size = New System.Drawing.Size(296, 22)
        Me.ndbRoundUpBefore.TabIndex = 7
        Me.ndbRoundUpBefore.Text = "Buchungen, die vor"
        Me.ndbRoundUpBefore.ValueAreaLength = 118
        '
        'nibPausetime
        '
        Me.nibPausetime.BackColor = System.Drawing.SystemColors.Window
        Me.nibPausetime.CaptionToValueRatio = 601.35
        Me.nibPausetime.ColorOnFocus = True
        Me.nibPausetime.FailedValidationErrorMessage = Nothing
        Me.nibPausetime.FormularText = ""
        Me.nibPausetime.HasCaption = True
        Me.nibPausetime.IndependentDatafieldName = Nothing
        Me.nibPausetime.Location = New System.Drawing.Point(22, 289)
        Me.nibPausetime.MaxValue = 0
        Me.nibPausetime.MinValue = 0
        Me.nibPausetime.Name = "nibPausetime"
        Me.nibPausetime.NullString = "* --- *"
        Me.nibPausetime.NullValueMessage = Nothing
        Me.nibPausetime.Size = New System.Drawing.Size(296, 22)
        Me.nibPausetime.TabIndex = 11
        Me.nibPausetime.Text = "Pause/Schichtschwelle:"
        Me.nibPausetime.ValueAreaLength = 118
        '
        'lblEndTimeDateDecription
        '
        Me.lblEndTimeDateDecription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndTimeDateDecription.Location = New System.Drawing.Point(445, 135)
        Me.lblEndTimeDateDecription.Name = "lblEndTimeDateDecription"
        Me.lblEndTimeDateDecription.Size = New System.Drawing.Size(94, 20)
        Me.lblEndTimeDateDecription.TabIndex = 2
        Me.lblEndTimeDateDecription.Text = "(Der Folgetag)"
        Me.lblEndTimeDateDecription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Referenztag: Mo, 01.01.2003:"
        '
        'ndbCoreTimeStart
        '
        Me.ndbCoreTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbCoreTimeStart.BackColor = System.Drawing.SystemColors.Window
        Me.ndbCoreTimeStart.CaptionToValueRatio = 601.35
        Me.ndbCoreTimeStart.ColorOnFocus = True
        Me.ndbCoreTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbCoreTimeStart.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbCoreTimeStart.HasCaption = True
        Me.ndbCoreTimeStart.IndependentDatafieldName = Nothing
        Me.ndbCoreTimeStart.Location = New System.Drawing.Point(23, 133)
        Me.ndbCoreTimeStart.Name = "ndbCoreTimeStart"
        Me.ndbCoreTimeStart.NullString = "* --- *"
        Me.ndbCoreTimeStart.NullValueMessage = Nothing
        Me.ndbCoreTimeStart.Size = New System.Drawing.Size(296, 22)
        Me.ndbCoreTimeStart.TabIndex = 0
        Me.ndbCoreTimeStart.Text = "Schicht: Beginn/Ende:"
        Me.ndbCoreTimeStart.ValueAreaLength = 118
        '
        'ndbCoreTimeEnd
        '
        Me.ndbCoreTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbCoreTimeEnd.BackColor = System.Drawing.SystemColors.Window
        Me.ndbCoreTimeEnd.CaptionToValueRatio = 0
        Me.ndbCoreTimeEnd.ColorOnFocus = True
        Me.ndbCoreTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbCoreTimeEnd.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" & _
            "rigieren Sie Ihre Eingabe!"
        Me.ndbCoreTimeEnd.HasCaption = False
        Me.ndbCoreTimeEnd.IndependentDatafieldName = Nothing
        Me.ndbCoreTimeEnd.Location = New System.Drawing.Point(321, 133)
        Me.ndbCoreTimeEnd.Name = "ndbCoreTimeEnd"
        Me.ndbCoreTimeEnd.NullString = "* --- *"
        Me.ndbCoreTimeEnd.NullValueMessage = Nothing
        Me.ndbCoreTimeEnd.Size = New System.Drawing.Size(118, 22)
        Me.ndbCoreTimeEnd.TabIndex = 1
        Me.ndbCoreTimeEnd.Text = "Schicht-1-Kernzeiten: Beginn/Ende:"
        Me.ndbCoreTimeEnd.ValueAreaLength = 118
        '
        'tcShifts
        '
        Me.tcShifts.Controls.Add(Me.tpShift1)
        Me.tcShifts.Controls.Add(Me.tpShift2)
        Me.tcShifts.Controls.Add(Me.tpShift3)
        Me.tcShifts.Controls.Add(Me.tpShift4)
        Me.tcShifts.Location = New System.Drawing.Point(0, 2)
        Me.tcShifts.Name = "tcShifts"
        Me.tcShifts.SelectedIndex = 0
        Me.tcShifts.Size = New System.Drawing.Size(563, 26)
        Me.tcShifts.TabIndex = 0
        '
        'tpShift1
        '
        Me.tpShift1.Location = New System.Drawing.Point(4, 25)
        Me.tpShift1.Name = "tpShift1"
        Me.tpShift1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpShift1.Size = New System.Drawing.Size(555, 0)
        Me.tpShift1.TabIndex = 0
        Me.tpShift1.Text = "Schicht 1"
        '
        'tpShift2
        '
        Me.tpShift2.Location = New System.Drawing.Point(4, 25)
        Me.tpShift2.Name = "tpShift2"
        Me.tpShift2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpShift2.Size = New System.Drawing.Size(555, 0)
        Me.tpShift2.TabIndex = 1
        Me.tpShift2.Text = "Schicht 2"
        '
        'tpShift3
        '
        Me.tpShift3.Location = New System.Drawing.Point(4, 25)
        Me.tpShift3.Name = "tpShift3"
        Me.tpShift3.Size = New System.Drawing.Size(555, 0)
        Me.tpShift3.TabIndex = 2
        Me.tpShift3.Text = "Schicht 3"
        '
        'tpShift4
        '
        Me.tpShift4.Location = New System.Drawing.Point(4, 25)
        Me.tpShift4.Name = "tpShift4"
        Me.tpShift4.Size = New System.Drawing.Size(555, 0)
        Me.tpShift4.TabIndex = 3
        Me.tpShift4.Text = "Sonderschicht"
        '
        'ucTimeDetailsSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tcShifts)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucTimeDetailsSettings"
        Me.Size = New System.Drawing.Size(569, 474)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tcShifts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnEndDate As System.Windows.Forms.Button
    Friend WithEvents btnStartDate As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnWD_07_Sunday As System.Windows.Forms.Button
    Friend WithEvents btnWD_06_Saturday As System.Windows.Forms.Button
    Friend WithEvents btnWD_05_Friday As System.Windows.Forms.Button
    Friend WithEvents btnWD_04_Thursday As System.Windows.Forms.Button
    Friend WithEvents btnWD_03_Wednesday As System.Windows.Forms.Button
    Friend WithEvents btnWD_02_Tuesday As System.Windows.Forms.Button
    Friend WithEvents btnWD_01_Monday As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGeneric As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEndTimeDateDecription As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tcShifts As System.Windows.Forms.TabControl
    Friend WithEvents tpShift1 As System.Windows.Forms.TabPage
    Friend WithEvents tpShift2 As System.Windows.Forms.TabPage
    Friend WithEvents tpShift3 As System.Windows.Forms.TabPage
    Friend WithEvents tpShift4 As System.Windows.Forms.TabPage
    Friend WithEvents lbTimes As System.Windows.Forms.ListBox
    Friend WithEvents ncbForceToHavePause As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents nibThreshold As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ndbRoundDownAfter As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbRoundUpBefore As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents nibPausetime As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ndbCoreTimeStart As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbCoreTimeEnd As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblImportEndTimeDateDescription As System.Windows.Forms.Label
    Friend WithEvents ndbImportTimeStart As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbImportTimeEnd As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents lblShiftInformer As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button

End Class
