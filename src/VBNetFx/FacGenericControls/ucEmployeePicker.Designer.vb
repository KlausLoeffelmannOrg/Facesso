<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ucEmployeePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtSearchText = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkOnlyIncentiveEmployees = New System.Windows.Forms.CheckBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.elvMain = New Facesso.FrontEnd.ucEmployeeListView
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.txtSearchText)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkOnlyIncentiveEmployees)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 62)
        Me.Panel1.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(73, 36)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(71, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(17, 36)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(50, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'txtSearchText
        '
        Me.txtSearchText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchText.Location = New System.Drawing.Point(150, 2)
        Me.txtSearchText.Multiline = True
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(335, 60)
        Me.txtSearchText.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Beliebige &Suchbegriffe:"
        '
        'chkOnlyIncentiveEmployees
        '
        Me.chkOnlyIncentiveEmployees.AutoSize = True
        Me.chkOnlyIncentiveEmployees.Checked = True
        Me.chkOnlyIncentiveEmployees.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOnlyIncentiveEmployees.Location = New System.Drawing.Point(17, 18)
        Me.chkOnlyIncentiveEmployees.Name = "chkOnlyIncentiveEmployees"
        Me.chkOnlyIncentiveEmployees.Size = New System.Drawing.Size(130, 17)
        Me.chkOnlyIncentiveEmployees.TabIndex = 4
        Me.chkOnlyIncentiveEmployees.Text = "nur Prämienmitarbeiter"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1MinSize = 50
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.elvMain)
        Me.SplitContainer1.Size = New System.Drawing.Size(487, 315)
        Me.SplitContainer1.SplitterDistance = 62
        Me.SplitContainer1.TabIndex = 2
        Me.SplitContainer1.Text = "SplitContainer1"
        '
        'elvMain
        '
        Me.elvMain.AutoGroup = True
        Me.elvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.elvMain.EmployeeInfoCollection = Nothing
        Me.elvMain.EmployeeSortOrder = Facesso.FrontEnd.EmployeeSortOrder.PersonnelNumber
        Me.elvMain.FullRowSelect = True
        Me.elvMain.HideSelection = False
        Me.elvMain.Location = New System.Drawing.Point(0, 0)
        Me.elvMain.Name = "elvMain"
        Me.elvMain.OnlyActiveEmployees = False
        Me.elvMain.Size = New System.Drawing.Size(487, 249)
        Me.elvMain.TabIndex = 0
        Me.elvMain.View = System.Windows.Forms.View.Details
        '
        'ucEmployeePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucEmployeePicker"
        Me.Size = New System.Drawing.Size(487, 315)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkOnlyIncentiveEmployees As System.Windows.Forms.CheckBox
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents elvMain As Facesso.FrontEnd.ucEmployeeListView

End Class
