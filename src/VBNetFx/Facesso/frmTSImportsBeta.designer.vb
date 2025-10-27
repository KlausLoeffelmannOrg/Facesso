<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTSImport
    Inherits Facesso.FrontEnd.frmBaseFacesso

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
        Me.txtAccessPathAndFile = New System.Windows.Forms.TextBox
        Me.btnOpenFile = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnImportNow = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.chkTransformProductionData = New System.Windows.Forms.CheckBox
        Me.chkTransformEmployeeTimes = New System.Windows.Forms.CheckBox
        Me.chkAllowNewCostCenterAlignment = New System.Windows.Forms.CheckBox
        Me.chkTransformBaseData = New System.Windows.Forms.CheckBox
        Me.chkGenerateRandomData = New System.Windows.Forms.CheckBox
        Me.ndbTransformFrom = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.adinMonthToAdd = New ActiveDev.Controls.ADNullableIntBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Access-Datenbank:"
        '
        'txtAccessPathAndFile
        '
        Me.txtAccessPathAndFile.Location = New System.Drawing.Point(115, 17)
        Me.txtAccessPathAndFile.Name = "txtAccessPathAndFile"
        Me.txtAccessPathAndFile.Size = New System.Drawing.Size(290, 20)
        Me.txtAccessPathAndFile.TabIndex = 1
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(406, 17)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(23, 20)
        Me.btnOpenFile.TabIndex = 2
        Me.btnOpenFile.Text = "..."
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(474, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 38)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        '
        'btnImportNow
        '
        Me.btnImportNow.Location = New System.Drawing.Point(474, 83)
        Me.btnImportNow.Name = "btnImportNow"
        Me.btnImportNow.Size = New System.Drawing.Size(112, 39)
        Me.btnImportNow.TabIndex = 8
        Me.btnImportNow.Text = "Jetzt importieren"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Location = New System.Drawing.Point(12, 307)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(574, 54)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.Text = "Leerlauf"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkTransformProductionData
        '
        Me.chkTransformProductionData.AutoSize = True
        Me.chkTransformProductionData.Checked = True
        Me.chkTransformProductionData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransformProductionData.Location = New System.Drawing.Point(115, 203)
        Me.chkTransformProductionData.Name = "chkTransformProductionData"
        Me.chkTransformProductionData.Size = New System.Drawing.Size(182, 17)
        Me.chkTransformProductionData.TabIndex = 6
        Me.chkTransformProductionData.Text = "Produktionsmengen übernehmen"
        Me.chkTransformProductionData.UseVisualStyleBackColor = True
        '
        'chkTransformEmployeeTimes
        '
        Me.chkTransformEmployeeTimes.AutoSize = True
        Me.chkTransformEmployeeTimes.Checked = True
        Me.chkTransformEmployeeTimes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransformEmployeeTimes.Location = New System.Drawing.Point(115, 226)
        Me.chkTransformEmployeeTimes.Name = "chkTransformEmployeeTimes"
        Me.chkTransformEmployeeTimes.Size = New System.Drawing.Size(165, 17)
        Me.chkTransformEmployeeTimes.TabIndex = 7
        Me.chkTransformEmployeeTimes.Text = "Mitarbeiterzeiten übernehmen"
        Me.chkTransformEmployeeTimes.UseVisualStyleBackColor = True
        '
        'chkAllowNewCostCenterAlignment
        '
        Me.chkAllowNewCostCenterAlignment.AutoSize = True
        Me.chkAllowNewCostCenterAlignment.Location = New System.Drawing.Point(115, 157)
        Me.chkAllowNewCostCenterAlignment.Name = "chkAllowNewCostCenterAlignment"
        Me.chkAllowNewCostCenterAlignment.Size = New System.Drawing.Size(343, 17)
        Me.chkAllowNewCostCenterAlignment.TabIndex = 5
        Me.chkAllowNewCostCenterAlignment.Text = "Nach Stammdatenübernahme, Kostenstellen manuell neu zuordnen"
        Me.chkAllowNewCostCenterAlignment.UseVisualStyleBackColor = True
        '
        'chkTransformBaseData
        '
        Me.chkTransformBaseData.AutoSize = True
        Me.chkTransformBaseData.Checked = True
        Me.chkTransformBaseData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransformBaseData.Location = New System.Drawing.Point(115, 180)
        Me.chkTransformBaseData.Name = "chkTransformBaseData"
        Me.chkTransformBaseData.Size = New System.Drawing.Size(451, 17)
        Me.chkTransformBaseData.TabIndex = 11
        Me.chkTransformBaseData.Text = "Stammdaten neu übernehmen (alle Daten der Subsidiarität werden dabei zuvor gelösc" & _
            "ht!!!)"
        Me.chkTransformBaseData.UseVisualStyleBackColor = True
        '
        'chkGenerateRandomData
        '
        Me.chkGenerateRandomData.AutoSize = True
        Me.chkGenerateRandomData.Location = New System.Drawing.Point(115, 105)
        Me.chkGenerateRandomData.Name = "chkGenerateRandomData"
        Me.chkGenerateRandomData.Size = New System.Drawing.Size(209, 17)
        Me.chkGenerateRandomData.TabIndex = 12
        Me.chkGenerateRandomData.Text = "Zufallsdaten aus Realdaten generieren"
        Me.chkGenerateRandomData.UseVisualStyleBackColor = True
        '
        'ndbTransformFrom
        '
        Me.ndbTransformFrom.BackColor = System.Drawing.SystemColors.Window
        Me.ndbTransformFrom.CaptionToValueRatio = 500
        Me.ndbTransformFrom.ColorOnFocus = True
        Me.ndbTransformFrom.FailedValidationErrorMessage = Nothing
        Me.ndbTransformFrom.HasCaption = True
        Me.ndbTransformFrom.IndependentDatafieldName = Nothing
        Me.ndbTransformFrom.Location = New System.Drawing.Point(115, 69)
        Me.ndbTransformFrom.Name = "ndbTransformFrom"
        Me.ndbTransformFrom.NullString = "* --- *"
        Me.ndbTransformFrom.NullValueMessage = Nothing
        Me.ndbTransformFrom.Size = New System.Drawing.Size(290, 20)
        Me.ndbTransformFrom.TabIndex = 13
        Me.ndbTransformFrom.Text = "Datenübernahme ab:"
        Me.ndbTransformFrom.ValueAreaLength = 145
        '
        'adinMonthToAdd
        '
        Me.adinMonthToAdd.BackColor = System.Drawing.SystemColors.Window
        Me.adinMonthToAdd.CaptionToValueRatio = 500
        Me.adinMonthToAdd.ColorOnFocus = True
        Me.adinMonthToAdd.Enabled = False
        Me.adinMonthToAdd.FailedValidationErrorMessage = Nothing
        Me.adinMonthToAdd.FormularText = ""
        Me.adinMonthToAdd.HasCaption = True
        Me.adinMonthToAdd.IndependentDatafieldName = Nothing
        Me.adinMonthToAdd.Location = New System.Drawing.Point(115, 131)
        Me.adinMonthToAdd.MaxValue = 0
        Me.adinMonthToAdd.MinValue = 0
        Me.adinMonthToAdd.Name = "adinMonthToAdd"
        Me.adinMonthToAdd.NullString = "* --- *"
        Me.adinMonthToAdd.NullValueMessage = Nothing
        Me.adinMonthToAdd.Size = New System.Drawing.Size(290, 20)
        Me.adinMonthToAdd.TabIndex = 14
        Me.adinMonthToAdd.Text = "Hinzuzufügende Monate:"
        Me.adinMonthToAdd.ValueAreaLength = 145
        '
        'frmTSImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 370)
        Me.Controls.Add(Me.adinMonthToAdd)
        Me.Controls.Add(Me.ndbTransformFrom)
        Me.Controls.Add(Me.chkGenerateRandomData)
        Me.Controls.Add(Me.chkTransformBaseData)
        Me.Controls.Add(Me.chkAllowNewCostCenterAlignment)
        Me.Controls.Add(Me.chkTransformEmployeeTimes)
        Me.Controls.Add(Me.chkTransformProductionData)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnImportNow)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.txtAccessPathAndFile)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmTSImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stammdatenimport aus Access-Datenbank:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccessPathAndFile As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnImportNow As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkTransformProductionData As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransformEmployeeTimes As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowNewCostCenterAlignment As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransformBaseData As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerateRandomData As System.Windows.Forms.CheckBox
    Friend WithEvents ndbTransformFrom As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents adinMonthToAdd As ActiveDev.Controls.ADNullableIntBox
End Class
