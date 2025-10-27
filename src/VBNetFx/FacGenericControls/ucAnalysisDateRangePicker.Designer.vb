<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ucAnalysisDateRangePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.gbTitle = New System.Windows.Forms.GroupBox()
        Me.cmbMonthsHistory = New System.Windows.Forms.ComboBox()
        Me.optWeekBeforeLastWeek = New System.Windows.Forms.RadioButton()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.optCustomPeriod = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optToday = New System.Windows.Forms.RadioButton()
        Me.optYesterday = New System.Windows.Forms.RadioButton()
        Me.optLastWeek = New System.Windows.Forms.RadioButton()
        Me.optFromStartOfCurrentWeekToNow = New System.Windows.Forms.RadioButton()
        Me.optSinceYearBegan = New System.Windows.Forms.RadioButton()
        Me.optStartToEndOfSpecifiedMonth = New System.Windows.Forms.RadioButton()
        Me.optFromStartOfCurrentMonthToNow = New System.Windows.Forms.RadioButton()
        Me.gbTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTitle
        '
        Me.gbTitle.Controls.Add(Me.cmbMonthsHistory)
        Me.gbTitle.Controls.Add(Me.optWeekBeforeLastWeek)
        Me.gbTitle.Controls.Add(Me.dtpEnd)
        Me.gbTitle.Controls.Add(Me.Label2)
        Me.gbTitle.Controls.Add(Me.dtpStart)
        Me.gbTitle.Controls.Add(Me.optCustomPeriod)
        Me.gbTitle.Controls.Add(Me.Label1)
        Me.gbTitle.Controls.Add(Me.optToday)
        Me.gbTitle.Controls.Add(Me.optYesterday)
        Me.gbTitle.Controls.Add(Me.optLastWeek)
        Me.gbTitle.Controls.Add(Me.optFromStartOfCurrentWeekToNow)
        Me.gbTitle.Controls.Add(Me.optSinceYearBegan)
        Me.gbTitle.Controls.Add(Me.optStartToEndOfSpecifiedMonth)
        Me.gbTitle.Controls.Add(Me.optFromStartOfCurrentMonthToNow)
        Me.gbTitle.Location = New System.Drawing.Point(0, 0)
        Me.gbTitle.Name = "gbTitle"
        Me.gbTitle.Size = New System.Drawing.Size(342, 307)
        Me.gbTitle.TabIndex = 0
        Me.gbTitle.TabStop = False
        '
        'cmbMonthsHistory
        '
        Me.cmbMonthsHistory.FormattingEnabled = True
        Me.cmbMonthsHistory.Location = New System.Drawing.Point(26, 180)
        Me.cmbMonthsHistory.Name = "cmbMonthsHistory"
        Me.cmbMonthsHistory.Size = New System.Drawing.Size(228, 21)
        Me.cmbMonthsHistory.TabIndex = 14
        '
        'optWeekBeforeLastWeek
        '
        Me.optWeekBeforeLastWeek.AutoSize = True
        Me.optWeekBeforeLastWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWeekBeforeLastWeek.Location = New System.Drawing.Point(6, 65)
        Me.optWeekBeforeLastWeek.Name = "optWeekBeforeLastWeek"
        Me.optWeekBeforeLastWeek.Size = New System.Drawing.Size(119, 17)
        Me.optWeekBeforeLastWeek.TabIndex = 13
        Me.optWeekBeforeLastWeek.Text = "Vorletzte Woche"
        Me.optWeekBeforeLastWeek.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(121, 279)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(209, 20)
        Me.dtpEnd.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Endzeitpunkt:"
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(121, 253)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(209, 20)
        Me.dtpStart.TabIndex = 10
        '
        'optCustomPeriod
        '
        Me.optCustomPeriod.AutoSize = True
        Me.optCustomPeriod.Location = New System.Drawing.Point(6, 230)
        Me.optCustomPeriod.Name = "optCustomPeriod"
        Me.optCustomPeriod.Size = New System.Drawing.Size(135, 17)
        Me.optCustomPeriod.TabIndex = 9
        Me.optCustomPeriod.Text = "Freigewählter Zeitraum:"
        Me.optCustomPeriod.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Startzeitpunkt:"
        '
        'optToday
        '
        Me.optToday.AutoSize = True
        Me.optToday.Location = New System.Drawing.Point(6, 42)
        Me.optToday.Name = "optToday"
        Me.optToday.Size = New System.Drawing.Size(54, 17)
        Me.optToday.TabIndex = 7
        Me.optToday.Text = "Heute"
        Me.optToday.UseVisualStyleBackColor = True
        '
        'optYesterday
        '
        Me.optYesterday.AutoSize = True
        Me.optYesterday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYesterday.Location = New System.Drawing.Point(6, 19)
        Me.optYesterday.Name = "optYesterday"
        Me.optYesterday.Size = New System.Drawing.Size(199, 17)
        Me.optYesterday.TabIndex = 6
        Me.optYesterday.Text = "Gestern bzw. letzter Arbeitstag"
        Me.optYesterday.UseVisualStyleBackColor = True
        '
        'optLastWeek
        '
        Me.optLastWeek.AutoSize = True
        Me.optLastWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optLastWeek.Location = New System.Drawing.Point(6, 88)
        Me.optLastWeek.Name = "optLastWeek"
        Me.optLastWeek.Size = New System.Drawing.Size(104, 17)
        Me.optLastWeek.TabIndex = 5
        Me.optLastWeek.Text = "Letzte Woche"
        Me.optLastWeek.UseVisualStyleBackColor = True
        '
        'optFromStartOfCurrentWeekToNow
        '
        Me.optFromStartOfCurrentWeekToNow.AutoSize = True
        Me.optFromStartOfCurrentWeekToNow.Location = New System.Drawing.Point(6, 111)
        Me.optFromStartOfCurrentWeekToNow.Name = "optFromStartOfCurrentWeekToNow"
        Me.optFromStartOfCurrentWeekToNow.Size = New System.Drawing.Size(161, 17)
        Me.optFromStartOfCurrentWeekToNow.TabIndex = 4
        Me.optFromStartOfCurrentWeekToNow.Text = "Anfang der Woche bis heute"
        Me.optFromStartOfCurrentWeekToNow.UseVisualStyleBackColor = True
        '
        'optSinceYearBegan
        '
        Me.optSinceYearBegan.AutoSize = True
        Me.optSinceYearBegan.Location = New System.Drawing.Point(6, 207)
        Me.optSinceYearBegan.Name = "optSinceYearBegan"
        Me.optSinceYearBegan.Size = New System.Drawing.Size(151, 17)
        Me.optSinceYearBegan.TabIndex = 3
        Me.optSinceYearBegan.Text = "Anfang des Jahres bis jetzt"
        Me.optSinceYearBegan.UseVisualStyleBackColor = True
        '
        'optStartToEndOfSpecifiedMonth
        '
        Me.optStartToEndOfSpecifiedMonth.AutoSize = True
        Me.optStartToEndOfSpecifiedMonth.Checked = True
        Me.optStartToEndOfSpecifiedMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStartToEndOfSpecifiedMonth.Location = New System.Drawing.Point(6, 157)
        Me.optStartToEndOfSpecifiedMonth.Name = "optStartToEndOfSpecifiedMonth"
        Me.optStartToEndOfSpecifiedMonth.Size = New System.Drawing.Size(227, 17)
        Me.optStartToEndOfSpecifiedMonth.TabIndex = 1
        Me.optStartToEndOfSpecifiedMonth.TabStop = True
        Me.optStartToEndOfSpecifiedMonth.Text = "Anfang bis Ende folgenden Monats:"
        Me.optStartToEndOfSpecifiedMonth.UseVisualStyleBackColor = True
        '
        'optFromStartOfCurrentMonthToNow
        '
        Me.optFromStartOfCurrentMonthToNow.AutoSize = True
        Me.optFromStartOfCurrentMonthToNow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFromStartOfCurrentMonthToNow.Location = New System.Drawing.Point(6, 134)
        Me.optFromStartOfCurrentMonthToNow.Name = "optFromStartOfCurrentMonthToNow"
        Me.optFromStartOfCurrentMonthToNow.Size = New System.Drawing.Size(213, 17)
        Me.optFromStartOfCurrentMonthToNow.TabIndex = 0
        Me.optFromStartOfCurrentMonthToNow.Text = "Anfang aktueller Monat bis heute"
        Me.optFromStartOfCurrentMonthToNow.UseVisualStyleBackColor = True
        '
        'ucAnalysisDateRangePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbTitle)
        Me.Name = "ucAnalysisDateRangePicker"
        Me.Size = New System.Drawing.Size(345, 310)
        Me.gbTitle.ResumeLayout(False)
        Me.gbTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTitle As System.Windows.Forms.GroupBox
    Friend WithEvents optFromStartOfCurrentMonthToNow As System.Windows.Forms.RadioButton
    Friend WithEvents optStartToEndOfSpecifiedMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optSinceYearBegan As System.Windows.Forms.RadioButton
    Friend WithEvents optFromStartOfCurrentWeekToNow As System.Windows.Forms.RadioButton
    Friend WithEvents optLastWeek As System.Windows.Forms.RadioButton
    Friend WithEvents optYesterday As System.Windows.Forms.RadioButton
    Friend WithEvents optToday As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optCustomPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optWeekBeforeLastWeek As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMonthsHistory As System.Windows.Forms.ComboBox

End Class
