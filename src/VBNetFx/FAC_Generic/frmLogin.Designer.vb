<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmLogin
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbUsernames = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblSubsidiary = New System.Windows.Forms.Label
        Me.cmbSubsidiary = New System.Windows.Forms.ComboBox
        Me.myErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.myErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Benutzername:"
        '
        'cmbUsernames
        '
        Me.cmbUsernames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUsernames.FormattingEnabled = True
        Me.cmbUsernames.Location = New System.Drawing.Point(175, 18)
        Me.cmbUsernames.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUsernames.Name = "cmbUsernames"
        Me.cmbUsernames.Size = New System.Drawing.Size(195, 24)
        Me.cmbUsernames.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(413, 13)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(102, 33)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Kennwort:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(175, 58)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(193, 22)
        Me.txtPassword.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(413, 56)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 33)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Abbrechen"
        '
        'lblSubsidiary
        '
        Me.lblSubsidiary.AutoSize = True
        Me.lblSubsidiary.Location = New System.Drawing.Point(97, 99)
        Me.lblSubsidiary.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubsidiary.Name = "lblSubsidiary"
        Me.lblSubsidiary.Size = New System.Drawing.Size(74, 16)
        Me.lblSubsidiary.TabIndex = 4
        Me.lblSubsidiary.Text = "&Subsidiarit:"
        '
        'cmbSubsidiary
        '
        Me.cmbSubsidiary.FormattingEnabled = True
        Me.cmbSubsidiary.Location = New System.Drawing.Point(175, 96)
        Me.cmbSubsidiary.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubsidiary.Name = "cmbSubsidiary"
        Me.cmbSubsidiary.Size = New System.Drawing.Size(194, 24)
        Me.cmbSubsidiary.TabIndex = 5
        '
        'myErrorProvider
        '
        Me.myErrorProvider.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(528, 151)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmbSubsidiary)
        Me.Controls.Add(Me.lblSubsidiary)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbUsernames)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facesso - Benutzeranmeldung"
        Me.TopMost = True
        CType(Me.myErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUsernames As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSubsidiary As System.Windows.Forms.Label
    Friend WithEvents cmbSubsidiary As System.Windows.Forms.ComboBox
    Friend WithEvents myErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
