<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADSqlDirectoryPickerDialog
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
        Me.components = New System.ComponentModel.Container
        Me.DirectoryPicker = New ActiveDev.Data.SqlClient.ADSQLDirectoryPicker
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DirectoryPicker
        '
        Me.DirectoryPicker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DirectoryPicker.ConnectionString = Nothing
        Me.DirectoryPicker.ExtensionFilter = ".mdf"
        Me.DirectoryPicker.ImageIndex = 0
        Me.DirectoryPicker.Location = New System.Drawing.Point(12, 12)
        Me.DirectoryPicker.Name = "DirectoryPicker"
        Me.DirectoryPicker.SelectedImageIndex = 0
        Me.DirectoryPicker.Size = New System.Drawing.Size(452, 310)
        Me.DirectoryPicker.TabIndex = 0
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.Location = New System.Drawing.Point(12, 328)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(452, 20)
        Me.txtPath.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(254, 354)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(102, 28)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(362, 354)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 28)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ADSqlDirectoryPickerDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(476, 390)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.DirectoryPicker)
        Me.Name = "ADSqlDirectoryPickerDialog"
        Me.Text = "Verzeichnis/Datei auf SQL-Server auswählen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DirectoryPicker As ActiveDev.Data.SqlClient.ADSQLDirectoryPicker
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
