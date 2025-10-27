<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkGroupPrintBaseData
    Inherits frmBaseFacesso

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.optOnlyPrintWorkgroups = New System.Windows.Forms.RadioButton
        Me.optPrintWorkgroups = New System.Windows.Forms.RadioButton
        Me.chkPrintAssignedLabourValues = New System.Windows.Forms.CheckBox
        Me.chkPrintShiftTimes = New System.Windows.Forms.CheckBox
        Me.chkVisualieProductivityHistory = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudMonths = New System.Windows.Forms.NumericUpDown
        CType(Me.nudMonths, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(393, 47)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(97, 29)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Drucken..."
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(393, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(97, 29)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'optOnlyPrintWorkgroups
        '
        Me.optOnlyPrintWorkgroups.AutoSize = True
        Me.optOnlyPrintWorkgroups.Location = New System.Drawing.Point(12, 106)
        Me.optOnlyPrintWorkgroups.Name = "optOnlyPrintWorkgroups"
        Me.optOnlyPrintWorkgroups.Size = New System.Drawing.Size(188, 17)
        Me.optOnlyPrintWorkgroups.TabIndex = 2
        Me.optOnlyPrintWorkgroups.TabStop = True
        Me.optOnlyPrintWorkgroups.Text = "Nur Liste der Arbeitswerte drucken"
        Me.optOnlyPrintWorkgroups.UseVisualStyleBackColor = True
        '
        'optPrintWorkgroups
        '
        Me.optPrintWorkgroups.AutoSize = True
        Me.optPrintWorkgroups.Location = New System.Drawing.Point(12, 12)
        Me.optPrintWorkgroups.Name = "optPrintWorkgroups"
        Me.optPrintWorkgroups.Size = New System.Drawing.Size(138, 17)
        Me.optPrintWorkgroups.TabIndex = 5
        Me.optPrintWorkgroups.TabStop = True
        Me.optPrintWorkgroups.Text = "Produktiv-Sites drucken"
        Me.optPrintWorkgroups.UseVisualStyleBackColor = True
        '
        'chkPrintAssignedLabourValues
        '
        Me.chkPrintAssignedLabourValues.AutoSize = True
        Me.chkPrintAssignedLabourValues.Location = New System.Drawing.Point(29, 35)
        Me.chkPrintAssignedLabourValues.Name = "chkPrintAssignedLabourValues"
        Me.chkPrintAssignedLabourValues.Size = New System.Drawing.Size(252, 17)
        Me.chkPrintAssignedLabourValues.TabIndex = 6
        Me.chkPrintAssignedLabourValues.Text = "zugeordnete REFA-Arbeitswerte mit ausdrucken"
        Me.chkPrintAssignedLabourValues.UseVisualStyleBackColor = True
        '
        'chkPrintShiftTimes
        '
        Me.chkPrintShiftTimes.AutoSize = True
        Me.chkPrintShiftTimes.Location = New System.Drawing.Point(29, 58)
        Me.chkPrintShiftTimes.Name = "chkPrintShiftTimes"
        Me.chkPrintShiftTimes.Size = New System.Drawing.Size(280, 17)
        Me.chkPrintShiftTimes.TabIndex = 7
        Me.chkPrintShiftTimes.Text = "Schichtzeitrahmen der Arbeitsgruppen mit ausdrucken"
        Me.chkPrintShiftTimes.UseVisualStyleBackColor = True
        '
        'chkVisualieProductivityHistory
        '
        Me.chkVisualieProductivityHistory.AutoSize = True
        Me.chkVisualieProductivityHistory.Location = New System.Drawing.Point(29, 81)
        Me.chkVisualieProductivityHistory.Name = "chkVisualieProductivityHistory"
        Me.chkVisualieProductivityHistory.Size = New System.Drawing.Size(174, 17)
        Me.chkVisualieProductivityHistory.TabIndex = 8
        Me.chkVisualieProductivityHistory.Text = "Produktivitätsverlauf der letzten"
        Me.chkVisualieProductivityHistory.UseVisualStyleBackColor = True
        Me.chkVisualieProductivityHistory.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Monate visualisieren"
        Me.Label1.Visible = False
        '
        'nudMonths
        '
        Me.nudMonths.Location = New System.Drawing.Point(202, 80)
        Me.nudMonths.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudMonths.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudMonths.Name = "nudMonths"
        Me.nudMonths.Size = New System.Drawing.Size(56, 20)
        Me.nudMonths.TabIndex = 11
        Me.nudMonths.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudMonths.Visible = False
        '
        'frmWorkGroupPrintBaseData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 134)
        Me.Controls.Add(Me.nudMonths)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkVisualieProductivityHistory)
        Me.Controls.Add(Me.chkPrintShiftTimes)
        Me.Controls.Add(Me.chkPrintAssignedLabourValues)
        Me.Controls.Add(Me.optPrintWorkgroups)
        Me.Controls.Add(Me.optOnlyPrintWorkgroups)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmWorkGroupPrintBaseData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Produktiv-Sites/REFA-Arbeitswert-Basisdaten drucken"
        CType(Me.nudMonths, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents optOnlyPrintWorkgroups As System.Windows.Forms.RadioButton
    Friend WithEvents optPrintWorkgroups As System.Windows.Forms.RadioButton
    Friend WithEvents chkPrintAssignedLabourValues As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintShiftTimes As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisualieProductivityHistory As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudMonths As System.Windows.Forms.NumericUpDown
End Class
