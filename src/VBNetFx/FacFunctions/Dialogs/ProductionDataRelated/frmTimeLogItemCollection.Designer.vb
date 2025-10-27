<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTimeLogItemCollection
    Inherits frmBaseFacesso

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
        Me.btnShiftStart = New System.Windows.Forms.Button
        Me.lblMinutesAttendance = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblShiftStartDate = New System.Windows.Forms.Label
        Me.btnShiftEnd = New System.Windows.Forms.Button
        Me.lblShiftEndDate = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblMinutesEffective = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblMinutesEffectiveAdj = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMinutesWorkingTime = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.nibDownTime = New ActiveDev.Controls.ADNullableIntBox
        Me.nibWorkBreak = New ActiveDev.Controls.ADNullableIntBox
        Me.ndbShiftEnd = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbShiftStart = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbHandicap = New ActiveDev.Controls.ADNullableDoubleBox
        Me.SuspendLayout()
        '
        'btnShiftStart
        '
        Me.btnShiftStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftStart.Location = New System.Drawing.Point(11, 18)
        Me.btnShiftStart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShiftStart.Name = "btnShiftStart"
        Me.btnShiftStart.Size = New System.Drawing.Size(89, 21)
        Me.btnShiftStart.TabIndex = 6
        Me.btnShiftStart.Text = "Dieser &Tag"
        '
        'lblMinutesAttendance
        '
        Me.lblMinutesAttendance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesAttendance.Location = New System.Drawing.Point(400, 41)
        Me.lblMinutesAttendance.Name = "lblMinutesAttendance"
        Me.lblMinutesAttendance.Size = New System.Drawing.Size(59, 20)
        Me.lblMinutesAttendance.TabIndex = 17
        Me.lblMinutesAttendance.Text = "0"
        Me.lblMinutesAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(465, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Minuten"
        '
        'lblShiftStartDate
        '
        Me.lblShiftStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftStartDate.Location = New System.Drawing.Point(102, 18)
        Me.lblShiftStartDate.Name = "lblShiftStartDate"
        Me.lblShiftStartDate.Size = New System.Drawing.Size(81, 18)
        Me.lblShiftStartDate.TabIndex = 8
        Me.lblShiftStartDate.Text = "Do, 24.07.2005"
        Me.lblShiftStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShiftEnd
        '
        Me.btnShiftEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftEnd.Location = New System.Drawing.Point(204, 18)
        Me.btnShiftEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShiftEnd.Name = "btnShiftEnd"
        Me.btnShiftEnd.Size = New System.Drawing.Size(89, 21)
        Me.btnShiftEnd.TabIndex = 7
        Me.btnShiftEnd.Text = "Dieser Ta&g"
        '
        'lblShiftEndDate
        '
        Me.lblShiftEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftEndDate.Location = New System.Drawing.Point(293, 18)
        Me.lblShiftEndDate.Name = "lblShiftEndDate"
        Me.lblShiftEndDate.Size = New System.Drawing.Size(81, 18)
        Me.lblShiftEndDate.TabIndex = 9
        Me.lblShiftEndDate.Text = "Do, 24.07.2005"
        Me.lblShiftEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(398, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Gesamtpräsenz:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(202, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Effektivzeit:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(302, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Minuten"
        '
        'lblMinutesEffective
        '
        Me.lblMinutesEffective.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesEffective.Location = New System.Drawing.Point(204, 147)
        Me.lblMinutesEffective.Name = "lblMinutesEffective"
        Me.lblMinutesEffective.Size = New System.Drawing.Size(89, 20)
        Me.lblMinutesEffective.TabIndex = 14
        Me.lblMinutesEffective.Text = "0"
        Me.lblMinutesEffective.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "(Zuschlag in % zum Ausgleich)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(398, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "angepasst:"
        '
        'lblMinutesEffectiveAdj
        '
        Me.lblMinutesEffectiveAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesEffectiveAdj.Location = New System.Drawing.Point(400, 147)
        Me.lblMinutesEffectiveAdj.Name = "lblMinutesEffectiveAdj"
        Me.lblMinutesEffectiveAdj.Size = New System.Drawing.Size(59, 20)
        Me.lblMinutesEffectiveAdj.TabIndex = 23
        Me.lblMinutesEffectiveAdj.Text = "0"
        Me.lblMinutesEffectiveAdj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(307, 195)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 30)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(463, 149)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Minuten"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 195)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(226, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "&Kernzeiten des letzten Arbeitstages"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(413, 195)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Abbrechen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(398, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Arbeitszeit:"
        '
        'lblMinutesWorkingTime
        '
        Me.lblMinutesWorkingTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesWorkingTime.Location = New System.Drawing.Point(400, 92)
        Me.lblMinutesWorkingTime.Name = "lblMinutesWorkingTime"
        Me.lblMinutesWorkingTime.Size = New System.Drawing.Size(59, 20)
        Me.lblMinutesWorkingTime.TabIndex = 20
        Me.lblMinutesWorkingTime.Text = "0"
        Me.lblMinutesWorkingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(465, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Minuten"
        '
        'nibDownTime
        '
        Me.nibDownTime.BackColor = System.Drawing.SystemColors.Window
        Me.nibDownTime.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nibDownTime.CaptionToValueRatio = 500
        Me.nibDownTime.ColorOnFocus = True
        Me.nibDownTime.FailedValidationErrorMessage = Nothing
        Me.nibDownTime.FormularText = ""
        Me.nibDownTime.HasCaption = True
        Me.nibDownTime.IndependentDatafieldName = Nothing
        Me.nibDownTime.Location = New System.Drawing.Point(204, 91)
        Me.nibDownTime.MaxValue = 0
        Me.nibDownTime.MinValue = 0
        Me.nibDownTime.Name = "nibDownTime"
        Me.nibDownTime.NullString = "* --- *"
        Me.nibDownTime.NullValueMessage = Nothing
        Me.nibDownTime.Size = New System.Drawing.Size(178, 23)
        Me.nibDownTime.TabIndex = 3
        Me.nibDownTime.Text = "&Ausfall:"
        Me.nibDownTime.ValueAreaLength = 89
        '
        'nibWorkBreak
        '
        Me.nibWorkBreak.BackColor = System.Drawing.SystemColors.Window
        Me.nibWorkBreak.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nibWorkBreak.CaptionToValueRatio = 500
        Me.nibWorkBreak.ColorOnFocus = True
        Me.nibWorkBreak.FailedValidationErrorMessage = Nothing
        Me.nibWorkBreak.FormularText = ""
        Me.nibWorkBreak.HasCaption = True
        Me.nibWorkBreak.IndependentDatafieldName = Nothing
        Me.nibWorkBreak.Location = New System.Drawing.Point(12, 91)
        Me.nibWorkBreak.MaxValue = 0
        Me.nibWorkBreak.MinValue = 0
        Me.nibWorkBreak.Name = "nibWorkBreak"
        Me.nibWorkBreak.NullString = "* --- *"
        Me.nibWorkBreak.NullValueMessage = Nothing
        Me.nibWorkBreak.Size = New System.Drawing.Size(178, 23)
        Me.nibWorkBreak.TabIndex = 2
        Me.nibWorkBreak.Text = "&Pause:"
        Me.nibWorkBreak.ValueAreaLength = 89
        '
        'ndbShiftEnd
        '
        Me.ndbShiftEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbShiftEnd.BackColor = System.Drawing.SystemColors.Window
        Me.ndbShiftEnd.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ndbShiftEnd.CaptionToValueRatio = 500
        Me.ndbShiftEnd.ColorOnFocus = True
        Me.ndbShiftEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbShiftEnd.FailedValidationErrorMessage = Nothing
        Me.ndbShiftEnd.HasCaption = True
        Me.ndbShiftEnd.IndependentDatafieldName = Nothing
        Me.ndbShiftEnd.Location = New System.Drawing.Point(205, 39)
        Me.ndbShiftEnd.Name = "ndbShiftEnd"
        Me.ndbShiftEnd.NullString = "* --- *"
        Me.ndbShiftEnd.NullValueMessage = Nothing
        Me.ndbShiftEnd.Size = New System.Drawing.Size(178, 23)
        Me.ndbShiftEnd.TabIndex = 1
        Me.ndbShiftEnd.Text = "&Endzeit:"
        Me.ndbShiftEnd.ValueAreaLength = 89
        '
        'ndbShiftStart
        '
        Me.ndbShiftStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbShiftStart.BackColor = System.Drawing.SystemColors.Window
        Me.ndbShiftStart.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ndbShiftStart.CaptionToValueRatio = 500
        Me.ndbShiftStart.ColorOnFocus = True
        Me.ndbShiftStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.ndbShiftStart.FailedValidationErrorMessage = Nothing
        Me.ndbShiftStart.HasCaption = True
        Me.ndbShiftStart.IndependentDatafieldName = Nothing
        Me.ndbShiftStart.Location = New System.Drawing.Point(12, 39)
        Me.ndbShiftStart.Name = "ndbShiftStart"
        Me.ndbShiftStart.NullString = "* --- *"
        Me.ndbShiftStart.NullValueMessage = Nothing
        Me.ndbShiftStart.Size = New System.Drawing.Size(178, 23)
        Me.ndbShiftStart.TabIndex = 0
        Me.ndbShiftStart.Text = "&Startzeit:"
        Me.ndbShiftStart.ValueAreaLength = 89
        '
        'ndbHandicap
        '
        Me.ndbHandicap.BackColor = System.Drawing.SystemColors.Window
        Me.ndbHandicap.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ndbHandicap.CaptionToValueRatio = 500
        Me.ndbHandicap.ColorOnFocus = True
        Me.ndbHandicap.CurrencyText = ""
        Me.ndbHandicap.FailedValidationErrorMessage = Nothing
        Me.ndbHandicap.FormularText = ""
        Me.ndbHandicap.HasCaption = True
        Me.ndbHandicap.IndependentDatafieldName = Nothing
        Me.ndbHandicap.Location = New System.Drawing.Point(11, 150)
        Me.ndbHandicap.MaxValue = 99
        Me.ndbHandicap.MinValue = 0
        Me.ndbHandicap.Name = "ndbHandicap"
        Me.ndbHandicap.NullString = "* --- *"
        Me.ndbHandicap.NullValueMessage = Nothing
        Me.ndbHandicap.Size = New System.Drawing.Size(178, 23)
        Me.ndbHandicap.TabIndex = 4
        Me.ndbHandicap.Text = "Handicap:"
        Me.ndbHandicap.ValueAreaLength = 89
        '
        'frmTimeLogItemCollection
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(522, 238)
        Me.Controls.Add(Me.ndbHandicap)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMinutesWorkingTime)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblMinutesEffectiveAdj)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblMinutesEffective)
        Me.Controls.Add(Me.nibDownTime)
        Me.Controls.Add(Me.nibWorkBreak)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblShiftEndDate)
        Me.Controls.Add(Me.btnShiftEnd)
        Me.Controls.Add(Me.lblShiftStartDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMinutesAttendance)
        Me.Controls.Add(Me.ndbShiftEnd)
        Me.Controls.Add(Me.ndbShiftStart)
        Me.Controls.Add(Me.btnShiftStart)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmTimeLogItemCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnShiftStart As System.Windows.Forms.Button
    Friend WithEvents ndbShiftStart As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbShiftEnd As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents lblMinutesAttendance As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblShiftStartDate As System.Windows.Forms.Label
    Friend WithEvents btnShiftEnd As System.Windows.Forms.Button
    Friend WithEvents lblShiftEndDate As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nibWorkBreak As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents nibDownTime As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMinutesEffective As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMinutesEffectiveAdj As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMinutesWorkingTime As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ndbHandicap As ActiveDev.Controls.ADNullableDoubleBox
End Class
