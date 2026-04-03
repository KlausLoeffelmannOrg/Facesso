<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnActivateFacesso = New System.Windows.Forms.Button()
        Me.btnSetupDatabase = New System.Windows.Forms.Button()
        Me.btnSetDatabaseInstance = New System.Windows.Forms.Button()
        Me.btnUpdateSchema = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnActivateFacesso
        '
        Me.btnActivateFacesso.Location = New System.Drawing.Point(75, 12)
        Me.btnActivateFacesso.Name = "btnActivateFacesso"
        Me.btnActivateFacesso.Size = New System.Drawing.Size(335, 67)
        Me.btnActivateFacesso.TabIndex = 0
        Me.btnActivateFacesso.Text = "Facesso neu aktivieren."
        Me.btnActivateFacesso.UseVisualStyleBackColor = True
        '
        'btnSetupDatabase
        '
        Me.btnSetupDatabase.Location = New System.Drawing.Point(75, 85)
        Me.btnSetupDatabase.Name = "btnSetupDatabase"
        Me.btnSetupDatabase.Size = New System.Drawing.Size(335, 67)
        Me.btnSetupDatabase.TabIndex = 1
        Me.btnSetupDatabase.Text = "Datenbank neu einrichten."
        Me.btnSetupDatabase.UseVisualStyleBackColor = True
        '
        'btnSetDatabaseInstance
        '
        Me.btnSetDatabaseInstance.Location = New System.Drawing.Point(75, 158)
        Me.btnSetDatabaseInstance.Name = "btnSetDatabaseInstance"
        Me.btnSetDatabaseInstance.Size = New System.Drawing.Size(335, 67)
        Me.btnSetDatabaseInstance.TabIndex = 2
        Me.btnSetDatabaseInstance.Text = "Datenbank-Instanz neu festlegen."
        Me.btnSetDatabaseInstance.UseVisualStyleBackColor = True
        '
        'btnUpdateSchema
        '
        Me.btnUpdateSchema.Location = New System.Drawing.Point(75, 231)
        Me.btnUpdateSchema.Name = "btnUpdateSchema"
        Me.btnUpdateSchema.Size = New System.Drawing.Size(335, 67)
        Me.btnUpdateSchema.TabIndex = 3
        Me.btnUpdateSchema.Text = "Schema-Update durchführen."
        Me.btnUpdateSchema.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 312)
        Me.Controls.Add(Me.btnUpdateSchema)
        Me.Controls.Add(Me.btnSetDatabaseInstance)
        Me.Controls.Add(Me.btnSetupDatabase)
        Me.Controls.Add(Me.btnActivateFacesso)
        Me.Name = "frmMain"
        Me.Text = "Facesso Konfigurationswerkzeug"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnActivateFacesso As System.Windows.Forms.Button
    Friend WithEvents btnSetupDatabase As System.Windows.Forms.Button
    Friend WithEvents btnSetDatabaseInstance As System.Windows.Forms.Button
    Friend WithEvents btnUpdateSchema As System.Windows.Forms.Button
End Class
