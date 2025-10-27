Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class frmError
    Inherits Form

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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtExceptionMessage = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblExceptionText = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bei der Programmausführung gab es Unregelmäßigkeiten und Facesso meldet die folge" & _
            "nde Ausnahme:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(451, 448)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Programm beenden"
        '
        'txtExceptionMessage
        '
        Me.txtExceptionMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExceptionMessage.Location = New System.Drawing.Point(12, 139)
        Me.txtExceptionMessage.Multiline = True
        Me.txtExceptionMessage.Name = "txtExceptionMessage"
        Me.txtExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExceptionMessage.Size = New System.Drawing.Size(600, 283)
        Me.txtExceptionMessage.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 445)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(402, 34)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Bitte kopieren Sie die Texte in die Zwischenablage, drucken Sie ihn aus, und faxe" & _
            "n Sie sie an: +49 2941 910908"
        '
        'lblExceptionText
        '
        Me.lblExceptionText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExceptionText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExceptionText.Location = New System.Drawing.Point(12, 51)
        Me.lblExceptionText.Name = "lblExceptionText"
        Me.lblExceptionText.Size = New System.Drawing.Size(600, 61)
        Me.lblExceptionText.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Details:"
        '
        'frmError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 488)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblExceptionText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtExceptionMessage)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "!!!Während der Programmausführung trat ein Fehler auf:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtExceptionMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblExceptionText As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
