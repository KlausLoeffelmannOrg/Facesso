<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSplash
    Inherits Facesso.FrontEnd.frmBaseFacesso

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Copyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Copyright
        '
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(248, 277)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(364, 40)
        Me.Copyright.TabIndex = 2
        Me.Copyright.Text = "Copyright"
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.Location = New System.Drawing.Point(12, 277)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(241, 20)
        Me.Version.TabIndex = 3
        Me.Version.Text = "Version {0}.{1:00}.{2:0}.{3:00}"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(15, 31)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(600, 190)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(623, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facesso.NET 2011"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
