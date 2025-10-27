<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMain
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
        Me.mtbPreSerial = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbProgramID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtbLimit1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mtbLimit2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtbBestBefore = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mtbLimit3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtbLimit4 = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.btnQuitProgram = New System.Windows.Forms.Button()
        Me.btnCalcSerial = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mtbPreSerial
        '
        Me.mtbPreSerial.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbPreSerial.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbPreSerial.HideSelection = False
        Me.mtbPreSerial.Location = New System.Drawing.Point(12, 45)
        Me.mtbPreSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbPreSerial.Mask = ">AAAAA - AAAAA - AAAAA"
        Me.mtbPreSerial.Name = "mtbPreSerial"
        Me.mtbPreSerial.Size = New System.Drawing.Size(263, 26)
        Me.mtbPreSerial.TabIndex = 1
        Me.mtbPreSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbPreSerial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vorseriennummer:"
        '
        'cmbProgramID
        '
        Me.cmbProgramID.FormattingEnabled = True
        Me.cmbProgramID.Location = New System.Drawing.Point(12, 109)
        Me.cmbProgramID.Name = "cmbProgramID"
        Me.cmbProgramID.Size = New System.Drawing.Size(220, 24)
        Me.cmbProgramID.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 90)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Programm-ID:"
        '
        'mtbLimit1
        '
        Me.mtbLimit1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbLimit1.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbLimit1.HideSelection = False
        Me.mtbLimit1.Location = New System.Drawing.Point(248, 110)
        Me.mtbLimit1.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbLimit1.Mask = "000"
        Me.mtbLimit1.Name = "mtbLimit1"
        Me.mtbLimit1.Size = New System.Drawing.Size(185, 26)
        Me.mtbLimit1.TabIndex = 5
        Me.mtbLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbLimit1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(246, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Limit1 (Users):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 149)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Limit2 (Internet-Users):"
        '
        'mtbLimit2
        '
        Me.mtbLimit2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbLimit2.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbLimit2.HideSelection = False
        Me.mtbLimit2.Location = New System.Drawing.Point(15, 169)
        Me.mtbLimit2.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbLimit2.Mask = "000"
        Me.mtbLimit2.Name = "mtbLimit2"
        Me.mtbLimit2.Size = New System.Drawing.Size(217, 26)
        Me.mtbLimit2.TabIndex = 7
        Me.mtbLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbLimit2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(246, 209)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Gültig für (Monate):"
        '
        'mtbBestBefore
        '
        Me.mtbBestBefore.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbBestBefore.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbBestBefore.HideSelection = False
        Me.mtbBestBefore.Location = New System.Drawing.Point(248, 229)
        Me.mtbBestBefore.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbBestBefore.Mask = "000"
        Me.mtbBestBefore.Name = "mtbBestBefore"
        Me.mtbBestBefore.Size = New System.Drawing.Size(185, 26)
        Me.mtbBestBefore.TabIndex = 13
        Me.mtbBestBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbBestBefore.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Limit3 (Mitarbeiter):"
        '
        'mtbLimit3
        '
        Me.mtbLimit3.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbLimit3.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbLimit3.HideSelection = False
        Me.mtbLimit3.Location = New System.Drawing.Point(248, 170)
        Me.mtbLimit3.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbLimit3.Mask = "00000"
        Me.mtbLimit3.Name = "mtbLimit3"
        Me.mtbLimit3.Size = New System.Drawing.Size(185, 26)
        Me.mtbLimit3.TabIndex = 9
        Me.mtbLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbLimit3.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 208)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Limit4 (Custom):"
        '
        'mtbLimit4
        '
        Me.mtbLimit4.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbLimit4.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbLimit4.HideSelection = False
        Me.mtbLimit4.Location = New System.Drawing.Point(15, 228)
        Me.mtbLimit4.Margin = New System.Windows.Forms.Padding(4)
        Me.mtbLimit4.Mask = "00000"
        Me.mtbLimit4.Name = "mtbLimit4"
        Me.mtbLimit4.Size = New System.Drawing.Size(217, 26)
        Me.mtbLimit4.TabIndex = 11
        Me.mtbLimit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbLimit4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 295)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Seriennummer:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(13, 314)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(572, 26)
        Me.txtSerialNumber.TabIndex = 15
        Me.txtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuitProgram.Location = New System.Drawing.Point(501, 39)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(140, 32)
        Me.btnQuitProgram.TabIndex = 17
        Me.btnQuitProgram.Text = "Programm beenden"
        '
        'btnCalcSerial
        '
        Me.btnCalcSerial.Location = New System.Drawing.Point(282, 42)
        Me.btnCalcSerial.Name = "btnCalcSerial"
        Me.btnCalcSerial.Size = New System.Drawing.Size(151, 29)
        Me.btnCalcSerial.TabIndex = 16
        Me.btnCalcSerial.Text = "Calc Serial"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnCalcSerial
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnQuitProgram
        Me.ClientSize = New System.Drawing.Size(653, 373)
        Me.Controls.Add(Me.btnCalcSerial)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.mtbLimit4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mtbLimit3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.mtbBestBefore)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.mtbLimit2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mtbLimit1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbProgramID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mtbPreSerial)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AD-Serial"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mtbPreSerial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbProgramID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mtbLimit1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents mtbLimit2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mtbBestBefore As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mtbLimit3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mtbLimit4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents btnCalcSerial As System.Windows.Forms.Button

End Class
