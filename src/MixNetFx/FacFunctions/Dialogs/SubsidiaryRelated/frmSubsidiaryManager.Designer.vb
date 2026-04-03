<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class frmSubsidiaryManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubsidiaryManager))
        Me.tcSubsidiaries = New System.Windows.Forms.TabControl
        Me.tpSubsidiaries = New System.Windows.Forms.TabPage
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.arvSubsidiaries = New ActiveDev.ADAutoReportView
        Me.tpTerminology = New System.Windows.Forms.TabPage
        Me.btnApplyNewTerm = New System.Windows.Forms.Button
        Me.txtSubsidiarySynonym = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.tcSubsidiaries.SuspendLayout()
        Me.tpSubsidiaries.SuspendLayout()
        Me.tpTerminology.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSubsidiaries
        '
        Me.tcSubsidiaries.Controls.Add(Me.tpSubsidiaries)
        Me.tcSubsidiaries.Controls.Add(Me.tpTerminology)
        Me.tcSubsidiaries.Location = New System.Drawing.Point(14, 14)
        Me.tcSubsidiaries.Margin = New System.Windows.Forms.Padding(4)
        Me.tcSubsidiaries.Name = "tcSubsidiaries"
        Me.tcSubsidiaries.SelectedIndex = 0
        Me.tcSubsidiaries.Size = New System.Drawing.Size(594, 364)
        Me.tcSubsidiaries.TabIndex = 0
        '
        'tpSubsidiaries
        '
        Me.tpSubsidiaries.Controls.Add(Me.btnDelete)
        Me.tpSubsidiaries.Controls.Add(Me.btnEdit)
        Me.tpSubsidiaries.Controls.Add(Me.btnNew)
        Me.tpSubsidiaries.Controls.Add(Me.arvSubsidiaries)
        Me.tpSubsidiaries.Location = New System.Drawing.Point(4, 25)
        Me.tpSubsidiaries.Margin = New System.Windows.Forms.Padding(4)
        Me.tpSubsidiaries.Name = "tpSubsidiaries"
        Me.tpSubsidiaries.Padding = New System.Windows.Forms.Padding(4)
        Me.tpSubsidiaries.Size = New System.Drawing.Size(586, 335)
        Me.tpSubsidiaries.TabIndex = 0
        Me.tpSubsidiaries.Text = "Subsidiaritäten"
        Me.tpSubsidiaries.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(456, 93)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(117, 35)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Löschen..."
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(456, 52)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(117, 35)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Bearbeiten..."
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(456, 11)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(117, 35)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Neu..."
        '
        'arvSubsidiaries
        '
        Me.arvSubsidiaries.FullRowSelect = True
        Me.arvSubsidiaries.GridLines = True
        Me.arvSubsidiaries.HideSelection = False
        Me.arvSubsidiaries.List = Nothing
        Me.arvSubsidiaries.ListViewMode = ActiveDev.AutoReportMode.Details
        Me.arvSubsidiaries.Location = New System.Drawing.Point(13, 12)
        Me.arvSubsidiaries.Name = "arvSubsidiaries"
        Me.arvSubsidiaries.Size = New System.Drawing.Size(432, 308)
        Me.arvSubsidiaries.TabIndex = 0
        Me.arvSubsidiaries.View = System.Windows.Forms.View.Details
        '
        'tpTerminology
        '
        Me.tpTerminology.Controls.Add(Me.btnApplyNewTerm)
        Me.tpTerminology.Controls.Add(Me.txtSubsidiarySynonym)
        Me.tpTerminology.Controls.Add(Me.Label3)
        Me.tpTerminology.Controls.Add(Me.Label2)
        Me.tpTerminology.Controls.Add(Me.Label1)
        Me.tpTerminology.Location = New System.Drawing.Point(4, 25)
        Me.tpTerminology.Margin = New System.Windows.Forms.Padding(4)
        Me.tpTerminology.Name = "tpTerminology"
        Me.tpTerminology.Padding = New System.Windows.Forms.Padding(4)
        Me.tpTerminology.Size = New System.Drawing.Size(586, 335)
        Me.tpTerminology.TabIndex = 1
        Me.tpTerminology.Text = "Terminologie"
        Me.tpTerminology.UseVisualStyleBackColor = False
        '
        'btnApplyNewTerm
        '
        Me.btnApplyNewTerm.Location = New System.Drawing.Point(333, 225)
        Me.btnApplyNewTerm.Name = "btnApplyNewTerm"
        Me.btnApplyNewTerm.Size = New System.Drawing.Size(180, 28)
        Me.btnApplyNewTerm.TabIndex = 4
        Me.btnApplyNewTerm.Text = "Neuen Begriff übernehmen"
        '
        'txtSubsidiarySynonym
        '
        Me.txtSubsidiarySynonym.Location = New System.Drawing.Point(214, 179)
        Me.txtSubsidiarySynonym.Name = "txtSubsidiarySynonym"
        Me.txtSubsidiarySynonym.Size = New System.Drawing.Size(299, 22)
        Me.txtSubsidiarySynonym.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bezeichnung für Subsidiarität:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(503, 52)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(503, 66)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(463, 385)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(141, 34)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'frmSubsidiaryManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 428)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tcSubsidiaries)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSubsidiaryManager"
        Me.Text = "Subsidiaritäten-Manager:"
        Me.tcSubsidiaries.ResumeLayout(False)
        Me.tpSubsidiaries.ResumeLayout(False)
        Me.tpTerminology.ResumeLayout(False)
        Me.tpTerminology.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSubsidiaries As System.Windows.Forms.TabControl
    Friend WithEvents tpSubsidiaries As System.Windows.Forms.TabPage
    Friend WithEvents tpTerminology As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnApplyNewTerm As System.Windows.Forms.Button
    Friend WithEvents txtSubsidiarySynonym As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents arvSubsidiaries As ActiveDev.ADAutoReportView
End Class
