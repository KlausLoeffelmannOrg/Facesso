<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMonthRangePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optSecondLastMonth = New System.Windows.Forms.RadioButton
        Me.optPreviousMonth = New System.Windows.Forms.RadioButton
        Me.optCurrentMonth = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMonthRange = New System.Windows.Forms.ComboBox
        Me.optFreeRange = New System.Windows.Forms.RadioButton
        Me.optRelatedMonth = New System.Windows.Forms.RadioButton
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "bis:"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(65, 215)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(212, 20)
        Me.dtpTo.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "von:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(65, 189)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(212, 20)
        Me.dtpFrom.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSecondLastMonth)
        Me.GroupBox2.Controls.Add(Me.optPreviousMonth)
        Me.GroupBox2.Controls.Add(Me.optCurrentMonth)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 83)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'optSecondLastMonth
        '
        Me.optSecondLastMonth.AutoSize = True
        Me.optSecondLastMonth.Location = New System.Drawing.Point(6, 59)
        Me.optSecondLastMonth.Name = "optSecondLastMonth"
        Me.optSecondLastMonth.Size = New System.Drawing.Size(140, 17)
        Me.optSecondLastMonth.TabIndex = 6
        Me.optSecondLastMonth.TabStop = True
        Me.optSecondLastMonth.Text = "Vor zwei Monaten (###)"
        Me.optSecondLastMonth.UseVisualStyleBackColor = True
        '
        'optPreviousMonth
        '
        Me.optPreviousMonth.AutoSize = True
        Me.optPreviousMonth.Location = New System.Drawing.Point(6, 36)
        Me.optPreviousMonth.Name = "optPreviousMonth"
        Me.optPreviousMonth.Size = New System.Drawing.Size(100, 17)
        Me.optPreviousMonth.TabIndex = 5
        Me.optPreviousMonth.TabStop = True
        Me.optPreviousMonth.Text = "Vormonat (###)"
        Me.optPreviousMonth.UseVisualStyleBackColor = True
        '
        'optCurrentMonth
        '
        Me.optCurrentMonth.AutoSize = True
        Me.optCurrentMonth.Location = New System.Drawing.Point(6, 13)
        Me.optCurrentMonth.Name = "optCurrentMonth"
        Me.optCurrentMonth.Size = New System.Drawing.Size(129, 17)
        Me.optCurrentMonth.TabIndex = 4
        Me.optCurrentMonth.TabStop = True
        Me.optCurrentMonth.Text = "Aktueller Monat (###)"
        Me.optCurrentMonth.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Monatlicher Abrechnungszeitraum:"
        '
        'cmbMonthRange
        '
        Me.cmbMonthRange.FormattingEnabled = True
        Me.cmbMonthRange.Items.AddRange(New Object() {"von 1. bis letzten des Vor-Bezugsmonats", "vom 1. bis letzten des Bezugsmonats", "vom 10. des Vor-Bezugsmonats bis  9. des Bezugmonats", "vom 15. des Vor-Bezugsmonats bis  14. des Bezugmonats", "vom 20. des Vor-Bezugsmonats bis 19. des Bezugsmonats"})
        Me.cmbMonthRange.Location = New System.Drawing.Point(6, 17)
        Me.cmbMonthRange.Name = "cmbMonthRange"
        Me.cmbMonthRange.Size = New System.Drawing.Size(271, 21)
        Me.cmbMonthRange.TabIndex = 14
        '
        'optFreeRange
        '
        Me.optFreeRange.AutoSize = True
        Me.optFreeRange.Location = New System.Drawing.Point(6, 166)
        Me.optFreeRange.Name = "optFreeRange"
        Me.optFreeRange.Size = New System.Drawing.Size(150, 17)
        Me.optFreeRange.TabIndex = 13
        Me.optFreeRange.TabStop = True
        Me.optFreeRange.Text = "Frei gewählter Zeitbereich:"
        Me.optFreeRange.UseVisualStyleBackColor = True
        '
        'optRelatedMonth
        '
        Me.optRelatedMonth.AutoSize = True
        Me.optRelatedMonth.Location = New System.Drawing.Point(6, 53)
        Me.optRelatedMonth.Name = "optRelatedMonth"
        Me.optRelatedMonth.Size = New System.Drawing.Size(92, 17)
        Me.optRelatedMonth.TabIndex = 12
        Me.optRelatedMonth.TabStop = True
        Me.optRelatedMonth.Text = "Bezugsmonat:"
        Me.optRelatedMonth.UseVisualStyleBackColor = True
        '
        'ucMonthRangePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMonthRange)
        Me.Controls.Add(Me.optFreeRange)
        Me.Controls.Add(Me.optRelatedMonth)
        Me.MaximumSize = New System.Drawing.Size(280, 290)
        Me.MinimumSize = New System.Drawing.Size(280, 250)
        Me.Name = "ucMonthRangePicker"
        Me.Size = New System.Drawing.Size(280, 250)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optSecondLastMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optPreviousMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optCurrentMonth As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMonthRange As System.Windows.Forms.ComboBox
    Friend WithEvents optFreeRange As System.Windows.Forms.RadioButton
    Friend WithEvents optRelatedMonth As System.Windows.Forms.RadioButton

End Class
