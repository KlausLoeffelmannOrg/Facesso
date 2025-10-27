<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKannegiesserSQLProdDataConfigDialog
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
        Me.txtSqlConnectionString = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmbDevice = New System.Windows.Forms.ComboBox()
        Me.lblDevice = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitel
        '
        Me.lblTitel.Size = New System.Drawing.Size(723, 46)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(535, 517)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(637, 516)
        '
        'lvwDeviceItems
        '
        Me.lvwDeviceItems.Size = New System.Drawing.Size(299, 373)
        '
        'ucLabourValues
        '
        Me.ucLabourValues.Size = New System.Drawing.Size(299, 373)
        '
        'btnChoosePath
        '
        Me.btnChoosePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoosePath.Location = New System.Drawing.Point(438, 468)
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
        Me.Label1.Location = New System.Drawing.Point(9, 468)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Kannegiesser SQL-Instanz:"
        '
        'txtSqlConnectionString
        '
        Me.txtSqlConnectionString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSqlConnectionString.Location = New System.Drawing.Point(149, 468)
        Me.txtSqlConnectionString.Multiline = True
        Me.txtSqlConnectionString.Name = "txtSqlConnectionString"
        Me.txtSqlConnectionString.ReadOnly = True
        Me.txtSqlConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSqlConnectionString.Size = New System.Drawing.Size(283, 73)
        Me.txtSqlConnectionString.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(149, 503)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(358, 69)
        Me.TextBox1.TabIndex = 17
        '
        'cmbDevice
        '
        Me.cmbDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevice.Enabled = False
        Me.cmbDevice.FormattingEnabled = True
        Me.cmbDevice.Items.AddRange(New Object() {"- Nicht festgelegt -", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cmbDevice.Location = New System.Drawing.Point(149, 547)
        Me.cmbDevice.Name = "cmbDevice"
        Me.cmbDevice.Size = New System.Drawing.Size(282, 21)
        Me.cmbDevice.TabIndex = 19
        '
        'lblDevice
        '
        Me.lblDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDevice.AutoSize = True
        Me.lblDevice.Enabled = False
        Me.lblDevice.Location = New System.Drawing.Point(87, 555)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(56, 13)
        Me.lblDevice.TabIndex = 20
        Me.lblDevice.Text = "Maschine:"
        '
        'frmKannegiesserSQLProdDataConfigDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(747, 575)
        Me.Controls.Add(Me.lblDevice)
        Me.Controls.Add(Me.cmbDevice)
        Me.Controls.Add(Me.txtSqlConnectionString)
        Me.Controls.Add(Me.btnChoosePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmKannegiesserSQLProdDataConfigDialog"
        Me.Controls.SetChildIndex(Me.lblTitel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnChoosePath, 0)
        Me.Controls.SetChildIndex(Me.txtSqlConnectionString, 0)
        Me.Controls.SetChildIndex(Me.cmbDevice, 0)
        Me.Controls.SetChildIndex(Me.lblDevice, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChoosePath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSqlConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbDevice As System.Windows.Forms.ComboBox
    Friend WithEvents lblDevice As System.Windows.Forms.Label

End Class
