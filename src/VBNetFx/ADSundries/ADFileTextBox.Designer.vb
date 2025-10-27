Partial Public Class ADFileTextBox
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()
        Ctor2()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.btnFileSelect = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtFilename
        '
        Me.txtFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilename.Location = New System.Drawing.Point(0, 0)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(208, 20)
        Me.txtFilename.TabIndex = 0
        '
        'btnFileSelect
        '
        Me.btnFileSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileSelect.Location = New System.Drawing.Point(209, 0)
        Me.btnFileSelect.Name = "btnFileSelect"
        Me.btnFileSelect.Size = New System.Drawing.Size(24, 20)
        Me.btnFileSelect.TabIndex = 1
        Me.btnFileSelect.Text = "..."
        '
        'ADFileTextBox
        '
        Me.AutoSize = True
        Me.Controls.Add(Me.btnFileSelect)
        Me.Controls.Add(Me.txtFilename)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ADFileTextBox"
        Me.Size = New System.Drawing.Size(232, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents btnFileSelect As System.Windows.Forms.Button

End Class
