<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKannegiesserProdDataConfigDialog
    Inherits Interfaces.frmProductionDataConfigureDialogBase

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
        Me.btnChoosePath = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPathToDeviceData = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTitel
        '
        Me.lblTitel.Size = New System.Drawing.Size(716, 46)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(528, 475)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(630, 475)
        '
        'btnChoosePath
        '
        Me.btnChoosePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChoosePath.Location = New System.Drawing.Point(454, 475)
        Me.btnChoosePath.Name = "btnChoosePath"
        Me.btnChoosePath.Size = New System.Drawing.Size(30, 20)
        Me.btnChoosePath.TabIndex = 16
        Me.btnChoosePath.Text = "..."
        Me.btnChoosePath.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 478)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Pfad zu Maschinendaten:"
        '
        'txtPathToDeviceData
        '
        Me.txtPathToDeviceData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPathToDeviceData.Location = New System.Drawing.Point(145, 475)
        Me.txtPathToDeviceData.Name = "txtPathToDeviceData"
        Me.txtPathToDeviceData.ReadOnly = True
        Me.txtPathToDeviceData.Size = New System.Drawing.Size(303, 20)
        Me.txtPathToDeviceData.TabIndex = 15
        '
        'frmKannegiesserProdDataConfigDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(726, 529)
        Me.Controls.Add(Me.btnChoosePath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPathToDeviceData)
        Me.Name = "frmKannegiesserProdDataConfigDialog"
        Me.Controls.SetChildIndex(Me.lblTitel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.txtPathToDeviceData, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnChoosePath, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChoosePath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPathToDeviceData As System.Windows.Forms.TextBox

End Class
