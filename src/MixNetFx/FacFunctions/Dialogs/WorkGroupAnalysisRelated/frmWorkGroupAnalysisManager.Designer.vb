<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkGroupAnalysisManager
    Inherits frmBaseFacesso

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstAnalysis = New System.Windows.Forms.ListBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnNewAnalysis = New System.Windows.Forms.Button
        Me.btnUseAnalysis = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAnalysisName = New System.Windows.Forms.TextBox
        Me.txtAnalysisMenuName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMenuIndex = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnEditAnalysis = New System.Windows.Forms.Button
        Me.btnDeleteAnalysis = New System.Windows.Forms.Button
        Me.btnApply = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstAnalysis)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 194)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Analysen:"
        '
        'lstAnalysis
        '
        Me.lstAnalysis.FormattingEnabled = True
        Me.lstAnalysis.Location = New System.Drawing.Point(6, 21)
        Me.lstAnalysis.Name = "lstAnalysis"
        Me.lstAnalysis.Size = New System.Drawing.Size(385, 160)
        Me.lstAnalysis.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(447, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(127, 35)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnNewAnalysis
        '
        Me.btnNewAnalysis.Location = New System.Drawing.Point(447, 94)
        Me.btnNewAnalysis.Name = "btnNewAnalysis"
        Me.btnNewAnalysis.Size = New System.Drawing.Size(127, 35)
        Me.btnNewAnalysis.TabIndex = 9
        Me.btnNewAnalysis.Text = "Neue Analyse..."
        Me.btnNewAnalysis.UseVisualStyleBackColor = True
        '
        'btnUseAnalysis
        '
        Me.btnUseAnalysis.Location = New System.Drawing.Point(447, 217)
        Me.btnUseAnalysis.Name = "btnUseAnalysis"
        Me.btnUseAnalysis.Size = New System.Drawing.Size(127, 35)
        Me.btnUseAnalysis.TabIndex = 12
        Me.btnUseAnalysis.Text = "Analyse anwenden..."
        Me.btnUseAnalysis.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Analyse-Name:"
        '
        'txtAnalysisName
        '
        Me.txtAnalysisName.Location = New System.Drawing.Point(104, 216)
        Me.txtAnalysisName.Name = "txtAnalysisName"
        Me.txtAnalysisName.Size = New System.Drawing.Size(305, 20)
        Me.txtAnalysisName.TabIndex = 2
        '
        'txtAnalysisMenuName
        '
        Me.txtAnalysisMenuName.Location = New System.Drawing.Point(104, 242)
        Me.txtAnalysisMenuName.Name = "txtAnalysisMenuName"
        Me.txtAnalysisMenuName.Size = New System.Drawing.Size(305, 20)
        Me.txtAnalysisMenuName.TabIndex = 4
        Me.txtAnalysisMenuName.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Menu-Name:"
        Me.Label2.Visible = False
        '
        'cmbMenuIndex
        '
        Me.cmbMenuIndex.FormattingEnabled = True
        Me.cmbMenuIndex.Location = New System.Drawing.Point(104, 269)
        Me.cmbMenuIndex.Name = "cmbMenuIndex"
        Me.cmbMenuIndex.Size = New System.Drawing.Size(305, 21)
        Me.cmbMenuIndex.TabIndex = 6
        Me.cmbMenuIndex.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Menu-Index:"
        Me.Label3.Visible = False
        '
        'btnEditAnalysis
        '
        Me.btnEditAnalysis.Location = New System.Drawing.Point(447, 135)
        Me.btnEditAnalysis.Name = "btnEditAnalysis"
        Me.btnEditAnalysis.Size = New System.Drawing.Size(127, 35)
        Me.btnEditAnalysis.TabIndex = 10
        Me.btnEditAnalysis.Text = "Analyse bearbeiten..."
        Me.btnEditAnalysis.UseVisualStyleBackColor = True
        '
        'btnDeleteAnalysis
        '
        Me.btnDeleteAnalysis.Location = New System.Drawing.Point(447, 176)
        Me.btnDeleteAnalysis.Name = "btnDeleteAnalysis"
        Me.btnDeleteAnalysis.Size = New System.Drawing.Size(127, 35)
        Me.btnDeleteAnalysis.TabIndex = 11
        Me.btnDeleteAnalysis.Text = "Analyse löschen..."
        Me.btnDeleteAnalysis.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(447, 53)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(127, 35)
        Me.btnApply.TabIndex = 8
        Me.btnApply.Text = "Übernehmen"
        Me.btnApply.UseVisualStyleBackColor = True
        Me.btnApply.Visible = False
        '
        'frmWorkGroupAnalysisManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 302)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnDeleteAnalysis)
        Me.Controls.Add(Me.btnEditAnalysis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMenuIndex)
        Me.Controls.Add(Me.txtAnalysisMenuName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAnalysisName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUseAnalysis)
        Me.Controls.Add(Me.btnNewAnalysis)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmWorkGroupAnalysisManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manager für Produktiv-Site-Analysen"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnNewAnalysis As System.Windows.Forms.Button
    Friend WithEvents btnUseAnalysis As System.Windows.Forms.Button
    Friend WithEvents lstAnalysis As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAnalysisName As System.Windows.Forms.TextBox
    Friend WithEvents txtAnalysisMenuName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMenuIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEditAnalysis As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAnalysis As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
End Class
