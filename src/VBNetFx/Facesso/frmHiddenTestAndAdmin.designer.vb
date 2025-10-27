<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmHiddenTestAndAdmin
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToEndNullableDateValue = New ActiveDevelop.EntitiesFormsLib.NullableDateValue()
        Me.ToStartNullableDateValue = New ActiveDevelop.EntitiesFormsLib.NullableDateValue()
        Me.FromStartNullableDateValue = New ActiveDevelop.EntitiesFormsLib.NullableDateValue()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.IncludeTineDataCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CopyProgressBar = New System.Windows.Forms.ProgressBar()
        Me.CopyNowButton = New System.Windows.Forms.Button()
        Me.CopyInfoLabel = New System.Windows.Forms.Label()
        Me.PassCaptionLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.btnNamenAnonymisieren = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNamenAnonymisieren)
        Me.GroupBox1.Controls.Add(Me.ToEndNullableDateValue)
        Me.GroupBox1.Controls.Add(Me.ToStartNullableDateValue)
        Me.GroupBox1.Controls.Add(Me.FromStartNullableDateValue)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.IncludeTineDataCheckBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CopyProgressBar)
        Me.GroupBox1.Controls.Add(Me.CopyNowButton)
        Me.GroupBox1.Controls.Add(Me.CopyInfoLabel)
        Me.GroupBox1.Controls.Add(Me.PassCaptionLabel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 178)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mengen und Zeitdaten duplizieren"
        '
        'ToEndNullableDateValue
        '
        Me.ToEndNullableDateValue.AssignedManagerComponent = Nothing
        Me.ToEndNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToEndNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.ToEndNullableDateValue.DaysDistanceBetweenLinkedControl = Nothing
        Me.ToEndNullableDateValue.LinkedToNullableDateControl = Nothing
        Me.ToEndNullableDateValue.Location = New System.Drawing.Point(333, 78)
        Me.ToEndNullableDateValue.MaxLength = 32767
        Me.ToEndNullableDateValue.Name = "ToEndNullableDateValue"
        Me.ToEndNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!"
        Me.ToEndNullableDateValue.ObfuscationChar = Nothing
        Me.ToEndNullableDateValue.PermissionReason = Nothing
        Me.ToEndNullableDateValue.Size = New System.Drawing.Size(185, 20)
        Me.ToEndNullableDateValue.TabIndex = 17
        Me.ToEndNullableDateValue.UIGuid = New System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618")
        Me.ToEndNullableDateValue.Value = New Date(2010, 1, 2, 0, 0, 0, 0)
        '
        'ToStartNullableDateValue
        '
        Me.ToStartNullableDateValue.AssignedManagerComponent = Nothing
        Me.ToStartNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToStartNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.ToStartNullableDateValue.DaysDistanceBetweenLinkedControl = 1
        Me.ToStartNullableDateValue.LinkedToNullableDateControl = Nothing
        Me.ToStartNullableDateValue.Location = New System.Drawing.Point(64, 79)
        Me.ToStartNullableDateValue.MaxLength = 32767
        Me.ToStartNullableDateValue.Name = "ToStartNullableDateValue"
        Me.ToStartNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!"
        Me.ToStartNullableDateValue.ObfuscationChar = Nothing
        Me.ToStartNullableDateValue.PermissionReason = Nothing
        Me.ToStartNullableDateValue.Size = New System.Drawing.Size(185, 20)
        Me.ToStartNullableDateValue.TabIndex = 16
        Me.ToStartNullableDateValue.UIGuid = New System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618")
        Me.ToStartNullableDateValue.Value = New Date(2010, 1, 2, 0, 0, 0, 0)
        '
        'FromStartNullableDateValue
        '
        Me.FromStartNullableDateValue.AssignedManagerComponent = Nothing
        Me.FromStartNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FromStartNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.FromStartNullableDateValue.DaysDistanceBetweenLinkedControl = 1
        Me.FromStartNullableDateValue.LinkedToNullableDateControl = Nothing
        Me.FromStartNullableDateValue.Location = New System.Drawing.Point(64, 51)
        Me.FromStartNullableDateValue.MaxLength = 32767
        Me.FromStartNullableDateValue.Name = "FromStartNullableDateValue"
        Me.FromStartNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!"
        Me.FromStartNullableDateValue.ObfuscationChar = Nothing
        Me.FromStartNullableDateValue.PermissionReason = Nothing
        Me.FromStartNullableDateValue.Size = New System.Drawing.Size(185, 20)
        Me.FromStartNullableDateValue.TabIndex = 15
        Me.FromStartNullableDateValue.UIGuid = New System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618")
        Me.FromStartNullableDateValue.Value = New Date(2010, 1, 1, 0, 0, 0, 0)
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(309, 54)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(221, 17)
        Me.CheckBox2.TabIndex = 14
        Me.CheckBox2.Text = "Vorhandene Daten dabei vorher löschen."
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(306, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "ab diesem Datum kopieren."
        '
        'IncludeTineDataCheckBox
        '
        Me.IncludeTineDataCheckBox.AutoSize = True
        Me.IncludeTineDataCheckBox.Location = New System.Drawing.Point(178, 22)
        Me.IncludeTineDataCheckBox.Name = "IncludeTineDataCheckBox"
        Me.IncludeTineDataCheckBox.Size = New System.Drawing.Size(71, 17)
        Me.IncludeTineDataCheckBox.TabIndex = 12
        Me.IncludeTineDataCheckBox.Text = "Zeitdaten"
        Me.IncludeTineDataCheckBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Die Mengendaten und"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "bis:"
        '
        'CopyProgressBar
        '
        Me.CopyProgressBar.Location = New System.Drawing.Point(255, 139)
        Me.CopyProgressBar.Name = "CopyProgressBar"
        Me.CopyProgressBar.Size = New System.Drawing.Size(263, 22)
        Me.CopyProgressBar.TabIndex = 9
        Me.CopyProgressBar.Value = 10
        '
        'CopyNowButton
        '
        Me.CopyNowButton.Location = New System.Drawing.Point(546, 25)
        Me.CopyNowButton.Name = "CopyNowButton"
        Me.CopyNowButton.Size = New System.Drawing.Size(120, 46)
        Me.CopyNowButton.TabIndex = 8
        Me.CopyNowButton.Text = "Jetzt Kopieren"
        Me.CopyNowButton.UseVisualStyleBackColor = True
        '
        'CopyInfoLabel
        '
        Me.CopyInfoLabel.AutoEllipsis = True
        Me.CopyInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CopyInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyInfoLabel.Location = New System.Drawing.Point(64, 139)
        Me.CopyInfoLabel.Name = "CopyInfoLabel"
        Me.CopyInfoLabel.Size = New System.Drawing.Size(185, 23)
        Me.CopyInfoLabel.TabIndex = 7
        Me.CopyInfoLabel.Text = "- - -"
        '
        'PassCaptionLabel
        '
        Me.PassCaptionLabel.AutoSize = True
        Me.PassCaptionLabel.Location = New System.Drawing.Point(61, 117)
        Me.PassCaptionLabel.Name = "PassCaptionLabel"
        Me.PassCaptionLabel.Size = New System.Drawing.Size(105, 13)
        Me.PassCaptionLabel.TabIndex = 5
        Me.PassCaptionLabel.Text = "Kopieren Daten von:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(306, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "bis:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "von:"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(591, 212)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(110, 37)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'btnNamenAnonymisieren
        '
        Me.btnNamenAnonymisieren.Location = New System.Drawing.Point(546, 79)
        Me.btnNamenAnonymisieren.Name = "btnNamenAnonymisieren"
        Me.btnNamenAnonymisieren.Size = New System.Drawing.Size(120, 46)
        Me.btnNamenAnonymisieren.TabIndex = 18
        Me.btnNamenAnonymisieren.Text = "Namen anonymisieren"
        Me.btnNamenAnonymisieren.UseVisualStyleBackColor = True
        '
        'frmHiddenTestAndAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 269)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmHiddenTestAndAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hidden Test and Admin"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CopyProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CopyNowButton As System.Windows.Forms.Button
    Friend WithEvents CopyInfoLabel As System.Windows.Forms.Label
    Friend WithEvents PassCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents IncludeTineDataCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToEndNullableDateValue As ActiveDevelop.EntitiesFormsLib.NullableDateValue
    Friend WithEvents ToStartNullableDateValue As ActiveDevelop.EntitiesFormsLib.NullableDateValue
    Friend WithEvents FromStartNullableDateValue As ActiveDevelop.EntitiesFormsLib.NullableDateValue
    Friend WithEvents btnNamenAnonymisieren As System.Windows.Forms.Button
End Class
