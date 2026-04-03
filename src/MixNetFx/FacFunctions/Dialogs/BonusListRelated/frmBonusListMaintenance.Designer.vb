<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmBonuslistMaintenance
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.lstCostCenter = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NewCostcenterTable = New System.Windows.Forms.Button
        Me.btnDeleteCostCenterTable = New System.Windows.Forms.Button
        Me.dgvWageTable = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgvWageTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(405, 34)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(207, 35)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'lstCostCenter
        '
        Me.lstCostCenter.FormattingEnabled = True
        Me.lstCostCenter.ItemHeight = 16
        Me.lstCostCenter.Location = New System.Drawing.Point(14, 34)
        Me.lstCostCenter.Margin = New System.Windows.Forms.Padding(4)
        Me.lstCostCenter.Name = "lstCostCenter"
        Me.lstCostCenter.Size = New System.Drawing.Size(383, 148)
        Me.lstCostCenter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Kostenstellen, für die Lohntabellen existieren:"
        '
        'NewCostcenterTable
        '
        Me.NewCostcenterTable.Location = New System.Drawing.Point(406, 117)
        Me.NewCostcenterTable.Margin = New System.Windows.Forms.Padding(4)
        Me.NewCostcenterTable.Name = "NewCostcenterTable"
        Me.NewCostcenterTable.Size = New System.Drawing.Size(207, 28)
        Me.NewCostcenterTable.TabIndex = 3
        Me.NewCostcenterTable.Text = "Neue Kostenstellentabelle"
        '
        'btnDeleteCostCenterTable
        '
        Me.btnDeleteCostCenterTable.Location = New System.Drawing.Point(406, 153)
        Me.btnDeleteCostCenterTable.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteCostCenterTable.Name = "btnDeleteCostCenterTable"
        Me.btnDeleteCostCenterTable.Size = New System.Drawing.Size(207, 28)
        Me.btnDeleteCostCenterTable.TabIndex = 4
        Me.btnDeleteCostCenterTable.Text = "Kostenstellentabelle löschen"
        '
        'dgvWageTable
        '
        Me.dgvWageTable.Location = New System.Drawing.Point(13, 219)
        Me.dgvWageTable.Name = "dgvWageTable"
        Me.dgvWageTable.Size = New System.Drawing.Size(599, 271)
        Me.dgvWageTable.TabIndex = 5
        Me.dgvWageTable.Text = "DataGridView1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 200)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Lohntabelle für ausgewählte Kostenstelle:"
        '
        'frmBonuslistMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 508)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvWageTable)
        Me.Controls.Add(Me.btnDeleteCostCenterTable)
        Me.Controls.Add(Me.NewCostcenterTable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstCostCenter)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBonuslistMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lohntabellenverwaltung"
        CType(Me.dgvWageTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lstCostCenter As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NewCostcenterTable As System.Windows.Forms.Button
    Friend WithEvents btnDeleteCostCenterTable As System.Windows.Forms.Button
    Friend WithEvents dgvWageTable As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
