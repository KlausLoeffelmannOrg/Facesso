<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignTimeSettingsToWorkgroups
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.wglWorkGroups = New Facesso.FrontEnd.ucWorkGroupListView
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(576, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(125, 39)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(576, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(125, 39)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'wglWorkGroups
        '
        Me.wglWorkGroups.AutoGroup = True
        Me.wglWorkGroups.FullRowSelect = True
        Me.wglWorkGroups.HideSelection = False
        Me.wglWorkGroups.Location = New System.Drawing.Point(7, 12)
        Me.wglWorkGroups.Name = "wglWorkGroups"
        Me.wglWorkGroups.OnlyActiveWorkgroups = True
        Me.wglWorkGroups.Size = New System.Drawing.Size(554, 304)
        Me.wglWorkGroups.TabIndex = 3
        Me.wglWorkGroups.View = System.Windows.Forms.View.Details
        Me.wglWorkGroups.WorkGroupInfoItems = Nothing
        Me.wglWorkGroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'frmAssignTimeSettingsToWorkgroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 328)
        Me.Controls.Add(Me.wglWorkGroups)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAssignTimeSettingsToWorkgroups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Globale Arbeitszeiteinstellungen Produktiv-Sites zuweisen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents wglWorkGroups As Facesso.FrontEnd.ucWorkGroupListView
End Class
