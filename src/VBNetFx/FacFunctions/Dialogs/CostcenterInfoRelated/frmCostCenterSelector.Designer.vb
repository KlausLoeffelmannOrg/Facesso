<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCostCenterSelector
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
        Me.lstCostCenter = New System.Windows.Forms.ListBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCostCenter
        '
        Me.lstCostCenter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCostCenter.FormattingEnabled = True
        Me.lstCostCenter.IntegralHeight = False
        Me.lstCostCenter.Location = New System.Drawing.Point(0, 1)
        Me.lstCostCenter.Name = "lstCostCenter"
        Me.lstCostCenter.Size = New System.Drawing.Size(259, 177)
        Me.lstCostCenter.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 178)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(247, 37)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Location = New System.Drawing.Point(126, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 31)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(117, 31)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'frmCostCenterSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 217)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lstCostCenter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmCostCenterSelector"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kostenstelle auswählen"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstCostCenter As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
