<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFacessoPathSettings
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.btnChooseSharedFolder = New System.Windows.Forms.Button
        Me.txtSharedFolder = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtUpdateUrl = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnChooseUpdateDirectory = New System.Windows.Forms.Button
        Me.txtUpdateDirectory = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInstallationDirectory = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnChooseSharedFolder
        '
        Me.btnChooseSharedFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChooseSharedFolder.Location = New System.Drawing.Point(440, 97)
        Me.btnChooseSharedFolder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChooseSharedFolder.Name = "btnChooseSharedFolder"
        Me.btnChooseSharedFolder.Size = New System.Drawing.Size(25, 22)
        Me.btnChooseSharedFolder.TabIndex = 19
        Me.btnChooseSharedFolder.Text = "..."
        Me.btnChooseSharedFolder.UseVisualStyleBackColor = True
        '
        'txtSharedFolder
        '
        Me.txtSharedFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSharedFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSharedFolder.Location = New System.Drawing.Point(158, 97)
        Me.txtSharedFolder.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSharedFolder.Name = "txtSharedFolder"
        Me.txtSharedFolder.ReadOnly = True
        Me.txtSharedFolder.Size = New System.Drawing.Size(274, 22)
        Me.txtSharedFolder.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(42, 100)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 16)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Verteilter Ordner:"
        '
        'txtUpdateUrl
        '
        Me.txtUpdateUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUpdateUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateUrl.Location = New System.Drawing.Point(158, 67)
        Me.txtUpdateUrl.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUpdateUrl.Name = "txtUpdateUrl"
        Me.txtUpdateUrl.Size = New System.Drawing.Size(274, 22)
        Me.txtUpdateUrl.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(63, 70)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 16)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Update-URL:"
        '
        'btnChooseUpdateDirectory
        '
        Me.btnChooseUpdateDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChooseUpdateDirectory.Location = New System.Drawing.Point(440, 37)
        Me.btnChooseUpdateDirectory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChooseUpdateDirectory.Name = "btnChooseUpdateDirectory"
        Me.btnChooseUpdateDirectory.Size = New System.Drawing.Size(25, 25)
        Me.btnChooseUpdateDirectory.TabIndex = 14
        Me.btnChooseUpdateDirectory.Text = "..."
        Me.btnChooseUpdateDirectory.UseVisualStyleBackColor = True
        '
        'txtUpdateDirectory
        '
        Me.txtUpdateDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUpdateDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateDirectory.Location = New System.Drawing.Point(158, 37)
        Me.txtUpdateDirectory.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUpdateDirectory.Name = "txtUpdateDirectory"
        Me.txtUpdateDirectory.ReadOnly = True
        Me.txtUpdateDirectory.Size = New System.Drawing.Size(274, 22)
        Me.txtUpdateDirectory.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 40)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Update-Verzeichnis:"
        '
        'txtInstallationDirectory
        '
        Me.txtInstallationDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstallationDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstallationDirectory.Location = New System.Drawing.Point(158, 7)
        Me.txtInstallationDirectory.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInstallationDirectory.Name = "txtInstallationDirectory"
        Me.txtInstallationDirectory.ReadOnly = True
        Me.txtInstallationDirectory.Size = New System.Drawing.Size(274, 22)
        Me.txtInstallationDirectory.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Installationsverzeichnis:"
        '
        'ucFacessoPathSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnChooseSharedFolder)
        Me.Controls.Add(Me.txtSharedFolder)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtUpdateUrl)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnChooseUpdateDirectory)
        Me.Controls.Add(Me.txtUpdateDirectory)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtInstallationDirectory)
        Me.Controls.Add(Me.Label4)
        Me.Name = "ucFacessoPathSettings"
        Me.Size = New System.Drawing.Size(469, 130)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChooseSharedFolder As System.Windows.Forms.Button
    Friend WithEvents txtSharedFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnChooseUpdateDirectory As System.Windows.Forms.Button
    Friend WithEvents txtUpdateDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInstallationDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
