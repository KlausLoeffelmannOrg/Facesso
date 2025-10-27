<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADAttachDatabaseDialog
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGetConnectionString = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtConnectionString = New System.Windows.Forms.TextBox
        Me.DBDirectoryPicker = New ActiveDev.Data.SqlClient.ADSQLDirectoryPicker
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(219, 364)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(105, 31)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Verbindung zum SQL-Server:"
        '
        'btnGetConnectionString
        '
        Me.btnGetConnectionString.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetConnectionString.Location = New System.Drawing.Point(409, 25)
        Me.btnGetConnectionString.Name = "btnGetConnectionString"
        Me.btnGetConnectionString.Size = New System.Drawing.Size(26, 22)
        Me.btnGetConnectionString.TabIndex = 3
        Me.btnGetConnectionString.Text = "..."
        Me.btnGetConnectionString.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(330, 364)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 31)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionString.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ActiveDev.Data.SqlClient.My.MySettings.Default, "AttachDatabaseDialogConnectionString", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtConnectionString.Location = New System.Drawing.Point(12, 27)
        Me.txtConnectionString.Multiline = True
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(391, 43)
        Me.txtConnectionString.TabIndex = 1
        Me.txtConnectionString.Text = Global.ActiveDev.Data.SqlClient.My.MySettings.Default.AttachDatabaseDialogConnectionString
        '
        'DBDirectoryPicker
        '
        Me.DBDirectoryPicker.ConnectionString = Nothing
        Me.DBDirectoryPicker.ExtensionFilter = ".mdf"
        Me.DBDirectoryPicker.ImageIndex = 0
        Me.DBDirectoryPicker.Location = New System.Drawing.Point(12, 76)
        Me.DBDirectoryPicker.Name = "DBDirectoryPicker"
        Me.DBDirectoryPicker.SelectedImageIndex = 0
        Me.DBDirectoryPicker.Size = New System.Drawing.Size(423, 282)
        Me.DBDirectoryPicker.TabIndex = 5
        '
        'ADAttachDatabaseDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 407)
        Me.Controls.Add(Me.DBDirectoryPicker)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGetConnectionString)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "ADAttachDatabaseDialog"
        Me.Text = "Datenbankdatei an SQL-Server anhängen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetConnectionString As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents DBDirectoryPicker As ActiveDev.Data.SqlClient.ADSQLDirectoryPicker
End Class
