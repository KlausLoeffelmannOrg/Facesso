<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLegatroTimeDataConfigDialog
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.tvwAssignments = New System.Windows.Forms.TreeView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSqlConnectionString = New System.Windows.Forms.TextBox
        Me.btnSelectSqlConnection = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lvwLegatroWorksitesOrProjects = New System.Windows.Forms.ListView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(296, 229)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(76, 36)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = ">> dazu"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(296, 271)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(76, 36)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "<< entfernen"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'tvwAssignments
        '
        Me.tvwAssignments.Location = New System.Drawing.Point(382, 112)
        Me.tvwAssignments.Name = "tvwAssignments"
        Me.tvwAssignments.Size = New System.Drawing.Size(270, 396)
        Me.tvwAssignments.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Verbindung zur Legatro-Datenbank:"
        '
        'txtSqlConnectionString
        '
        Me.txtSqlConnectionString.Location = New System.Drawing.Point(12, 25)
        Me.txtSqlConnectionString.Multiline = True
        Me.txtSqlConnectionString.Name = "txtSqlConnectionString"
        Me.txtSqlConnectionString.ReadOnly = True
        Me.txtSqlConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSqlConnectionString.Size = New System.Drawing.Size(592, 52)
        Me.txtSqlConnectionString.TabIndex = 5
        '
        'btnSelectSqlConnection
        '
        Me.btnSelectSqlConnection.Location = New System.Drawing.Point(610, 45)
        Me.btnSelectSqlConnection.Name = "btnSelectSqlConnection"
        Me.btnSelectSqlConnection.Size = New System.Drawing.Size(42, 32)
        Me.btnSelectSqlConnection.TabIndex = 6
        Me.btnSelectSqlConnection.Text = "..."
        Me.btnSelectSqlConnection.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(488, 518)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(79, 32)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(573, 518)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(79, 32)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lvwLegatroWorksitesOrProjects
        '
        Me.lvwLegatroWorksitesOrProjects.FullRowSelect = True
        Me.lvwLegatroWorksitesOrProjects.HideSelection = False
        Me.lvwLegatroWorksitesOrProjects.Location = New System.Drawing.Point(12, 110)
        Me.lvwLegatroWorksitesOrProjects.Name = "lvwLegatroWorksitesOrProjects"
        Me.lvwLegatroWorksitesOrProjects.Size = New System.Drawing.Size(278, 398)
        Me.lvwLegatroWorksitesOrProjects.TabIndex = 9
        Me.lvwLegatroWorksitesOrProjects.UseCompatibleStateImageBehavior = False
        Me.lvwLegatroWorksitesOrProjects.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Arbeitsplätze in Legatro:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "zugewiesen an"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(379, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Produktiv-Sites in Facesso:"
        '
        'frmLegatroTimeDataConfigDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(664, 562)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvwLegatroWorksitesOrProjects)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSelectSqlConnection)
        Me.Controls.Add(Me.txtSqlConnectionString)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tvwAssignments)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmLegatroTimeDataConfigDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Legatro Datenübernahmeeinstellungen:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents tvwAssignments As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSqlConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectSqlConnection As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lvwLegatroWorksitesOrProjects As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
