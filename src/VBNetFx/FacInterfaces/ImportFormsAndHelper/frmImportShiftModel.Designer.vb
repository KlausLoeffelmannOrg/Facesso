<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportShiftModel
    Inherits System.Windows.Forms.Form

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
        Me.UcTimeDetailsSettings1 = New Facesso.FrontEnd.ucTimeDetailsSettings
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'UcTimeDetailsSettings1
        '
        Me.UcTimeDetailsSettings1.CurrentlyDisplayedShift = 1
        Me.UcTimeDetailsSettings1.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll
        Me.UcTimeDetailsSettings1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcTimeDetailsSettings1.Location = New System.Drawing.Point(13, 13)
        Me.UcTimeDetailsSettings1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcTimeDetailsSettings1.Name = "UcTimeDetailsSettings1"
        Me.UcTimeDetailsSettings1.Size = New System.Drawing.Size(558, 458)
        Me.UcTimeDetailsSettings1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(348, 478)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 34)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(457, 478)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 34)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmImportShiftModel
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(577, 525)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UcTimeDetailsSettings1)
        Me.Name = "frmImportShiftModel"
        Me.Text = "Schichtmodell für den Datenimport bearbeiten"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcTimeDetailsSettings1 As Facesso.FrontEnd.ucTimeDetailsSettings
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
