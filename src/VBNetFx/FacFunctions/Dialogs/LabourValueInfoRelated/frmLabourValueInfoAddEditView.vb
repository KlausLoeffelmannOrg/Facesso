Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Data
Imports System.Windows.Forms

Public Class frmLabourValueInfoAddEditView
    Inherits Functions.frmInfoItemAddEditViewBase

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents ntbLabourValueDescription As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbLabourValueName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ndbTe As ActiveDev.Controls.ADNullableDoubleBox
    Friend WithEvents nibLabourValueNumber As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ntbDimension As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ncbIsActive As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncbCostCenter As ActiveDev.Controls.ADNullableIdOrIndexComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.ntbLabourValueDescription = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbLabourValueName = New ActiveDev.Controls.ADNullableTextBox
        Me.ndbTe = New ActiveDev.Controls.ADNullableDoubleBox
        Me.nibLabourValueNumber = New ActiveDev.Controls.ADNullableIntBox
        Me.ntbDimension = New ActiveDev.Controls.ADNullableTextBox
        Me.ncbIsActive = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncbCostCenter = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(468, 13)
        Me.btnOK.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(468, 58)
        Me.btnCancel.TabIndex = 8
        '
        'ntbLabourValueDescription
        '
        Me.ntbLabourValueDescription.BackColor = System.Drawing.SystemColors.Window
        Me.ntbLabourValueDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ntbLabourValueDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above
        Me.ntbLabourValueDescription.CaptionToValueRatio = 1000
        Me.ntbLabourValueDescription.ColorOnFocus = True
        Me.ntbLabourValueDescription.FailedValidationErrorMessage = Nothing
        Me.ntbLabourValueDescription.HasCaption = True
        Me.ntbLabourValueDescription.IndependentDatafieldName = "LabourValueDescription"
        Me.ntbLabourValueDescription.Location = New System.Drawing.Point(11, 112)
        Me.ntbLabourValueDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbLabourValueDescription.Multiline = True
        Me.ntbLabourValueDescription.Name = "ntbLabourValueDescription"
        Me.ntbLabourValueDescription.NullString = "* --- *"
        Me.ntbLabourValueDescription.NullValueMessage = Nothing
        Me.ntbLabourValueDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.ntbLabourValueDescription.Size = New System.Drawing.Size(429, 184)
        Me.ntbLabourValueDescription.TabIndex = 3
        Me.ntbLabourValueDescription.Text = "REFA-Arbeitswertbeschreibung:"
        Me.ntbLabourValueDescription.ValueAreaLength = 429
        '
        'ntbLabourValueName
        '
        Me.ntbLabourValueName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbLabourValueName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbLabourValueName.CaptionToValueRatio = 399.53
        Me.ntbLabourValueName.ColorOnFocus = True
        Me.ntbLabourValueName.FailedValidationErrorMessage = Nothing
        Me.ntbLabourValueName.HasCaption = True
        Me.ntbLabourValueName.IndependentDatafieldName = "LabourValueName"
        Me.ntbLabourValueName.Location = New System.Drawing.Point(11, 42)
        Me.ntbLabourValueName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbLabourValueName.MaxLength = 100
        Me.ntbLabourValueName.Multiline = False
        Me.ntbLabourValueName.Name = "ntbLabourValueName"
        Me.ntbLabourValueName.NullString = "* --- *"
        Me.ntbLabourValueName.NullValueMessage = "Bitte bestimmen Sie einen Arbeitswertnamen !"
        Me.ntbLabourValueName.Size = New System.Drawing.Size(428, 23)
        Me.ntbLabourValueName.TabIndex = 1
        Me.ntbLabourValueName.Text = "REFA-Arbeitswertname:"
        Me.ntbLabourValueName.ValueAreaLength = 257
        '
        'ndbTe
        '
        Me.ndbTe.AssignFormatString = "#,##0.00"
        Me.ndbTe.BackColor = System.Drawing.SystemColors.Window
        Me.ndbTe.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbTe.CaptionToValueRatio = 400.93
        Me.ndbTe.ColorOnFocus = True
        Me.ndbTe.CurrencyText = ""
        Me.ndbTe.DisplayCustomFormatString = "#,##0.00"
        Me.ndbTe.DisplayFormat = ActiveDev.Controls.ADUVNumFormat.UseCustomString
        Me.ndbTe.FailedValidationErrorMessage = Nothing
        Me.ndbTe.FormularText = ""
        Me.ndbTe.HasCaption = True
        Me.ndbTe.IndependentDatafieldName = "TeHMin"
        Me.ndbTe.Location = New System.Drawing.Point(11, 318)
        Me.ndbTe.MaxValue = 0
        Me.ndbTe.MinValue = 0
        Me.ndbTe.Name = "ndbTe"
        Me.ndbTe.NullString = "* --- *"
        Me.ndbTe.NullValueMessage = "Bitte bestimmen Sie den nach REFA berechneten te-Wert für diesen Arbeitswert!"
        Me.ndbTe.Size = New System.Drawing.Size(429, 23)
        Me.ndbTe.TabIndex = 4
        Me.ndbTe.Text = "te: "
        Me.ndbTe.ValueAreaLength = 257
        '
        'nibLabourValueNumber
        '
        Me.nibLabourValueNumber.BackColor = System.Drawing.SystemColors.Window
        Me.nibLabourValueNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibLabourValueNumber.CaptionToValueRatio = 400
        Me.nibLabourValueNumber.ColorOnFocus = True
        Me.nibLabourValueNumber.FailedValidationErrorMessage = Nothing
        Me.nibLabourValueNumber.FormularText = ""
        Me.nibLabourValueNumber.HasCaption = True
        Me.nibLabourValueNumber.IndependentDatafieldName = "LabourValueNumber"
        Me.nibLabourValueNumber.Location = New System.Drawing.Point(10, 12)
        Me.nibLabourValueNumber.MaxValue = 0
        Me.nibLabourValueNumber.MinValue = 0
        Me.nibLabourValueNumber.Name = "nibLabourValueNumber"
        Me.nibLabourValueNumber.NullString = "* --- *"
        Me.nibLabourValueNumber.NullValueMessage = "Bitte bestimmen Sie die Arbeitswertnummer!"
        Me.nibLabourValueNumber.Size = New System.Drawing.Size(430, 23)
        Me.nibLabourValueNumber.TabIndex = 0
        Me.nibLabourValueNumber.Text = "REFA-Arbeitswertnr.:"
        Me.nibLabourValueNumber.ValueAreaLength = 258
        '
        'ntbDimension
        '
        Me.ntbDimension.BackColor = System.Drawing.SystemColors.Window
        Me.ntbDimension.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbDimension.CaptionToValueRatio = 400.93
        Me.ntbDimension.ColorOnFocus = True
        Me.ntbDimension.FailedValidationErrorMessage = Nothing
        Me.ntbDimension.HasCaption = True
        Me.ntbDimension.IndependentDatafieldName = "Dimension"
        Me.ntbDimension.Location = New System.Drawing.Point(10, 348)
        Me.ntbDimension.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbDimension.MaxLength = 100
        Me.ntbDimension.Multiline = False
        Me.ntbDimension.Name = "ntbDimension"
        Me.ntbDimension.NullString = "* --- *"
        Me.ntbDimension.NullValueMessage = "Bitte bestimmen Sie die Maßeinheit für diesen te-Wert!"
        Me.ntbDimension.Size = New System.Drawing.Size(429, 23)
        Me.ntbDimension.TabIndex = 5
        Me.ntbDimension.Text = "Maßeinheit: "
        Me.ntbDimension.ValueAreaLength = 257
        '
        'ncbIsActive
        '
        Me.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsActive.CaptionToValueRatio = 741.61
        Me.ncbIsActive.ColorOnFocus = True
        Me.ncbIsActive.FailedValidationErrorMessage = Nothing
        Me.ncbIsActive.HasCaption = True
        Me.ncbIsActive.IndependentDatafieldName = "IsActive"
        Me.ncbIsActive.Location = New System.Drawing.Point(10, 390)
        Me.ncbIsActive.Name = "ncbIsActive"
        Me.ncbIsActive.NullString = Nothing
        Me.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!"
        Me.ncbIsActive.Size = New System.Drawing.Size(298, 19)
        Me.ncbIsActive.TabIndex = 6
        Me.ncbIsActive.Text = "Ist aktiviert:"
        Me.ncbIsActive.ValueAreaLength = 77
        '
        'ncbCostCenter
        '
        Me.ncbCostCenter.BackColor = System.Drawing.SystemColors.Window
        Me.ncbCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbCostCenter.CaptionToValueRatio = 400.93
        Me.ncbCostCenter.ColorOnFocus = True
        Me.ncbCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncbCostCenter.DropDownHeight = 106
        Me.ncbCostCenter.DropDownWidth = 315
        Me.ncbCostCenter.FailedValidationErrorMessage = Nothing
        Me.ncbCostCenter.HasCaption = True
        Me.ncbCostCenter.IndependentDatafieldName = "IDCostCenter"
        Me.ncbCostCenter.Location = New System.Drawing.Point(11, 72)
        Me.ncbCostCenter.MaxDropDownItems = 8
        Me.ncbCostCenter.Name = "ncbCostCenter"
        Me.ncbCostCenter.NullString = Nothing
        Me.ncbCostCenter.NullValueMessage = "Bitte bestimmen Sie die Kostenstelle zu diesem Arbeitswert!"
        Me.ncbCostCenter.Size = New System.Drawing.Size(429, 24)
        Me.ncbCostCenter.TabIndex = 2
        Me.ncbCostCenter.Text = "Kostenstellen-Nummer: "
        Me.ncbCostCenter.ValueAreaLength = 257
        '
        'frmLabourValueInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(598, 430)
        Me.Controls.Add(Me.ncbCostCenter)
        Me.Controls.Add(Me.ncbIsActive)
        Me.Controls.Add(Me.ntbDimension)
        Me.Controls.Add(Me.nibLabourValueNumber)
        Me.Controls.Add(Me.ndbTe)
        Me.Controls.Add(Me.ntbLabourValueDescription)
        Me.Controls.Add(Me.ntbLabourValueName)
        Me.Name = "frmLabourValueInfoAddEditView"
        Me.Controls.SetChildIndex(Me.ntbLabourValueName, 0)
        Me.Controls.SetChildIndex(Me.ntbLabourValueDescription, 0)
        Me.Controls.SetChildIndex(Me.ndbTe, 0)
        Me.Controls.SetChildIndex(Me.nibLabourValueNumber, 0)
        Me.Controls.SetChildIndex(Me.ntbDimension, 0)
        Me.Controls.SetChildIndex(Me.ncbIsActive, 0)
        Me.Controls.SetChildIndex(Me.ncbCostCenter, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter)
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter)
        MyBase.Fac_OnAssigningToControls(InfoItem)
    End Sub

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Arbeitswertnummer schon existiert
        If locSPA.LabourValues_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibLabourValueNumber.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Body
            locErr = String.Format(locErr, CInt(nibLabourValueNumber.TypeSafeValue), _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Arbeitswertnummer schon existiert
        If locSPA.LabourValues_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibLabourValueNumber.TypeSafeValue, _
                                                 DirectCast(e.InfoItem, LabourValueInfo).IDLabourValue) Then
            Dim locErr As String = My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Body
            locErr = String.Format(locErr, nibLabourValueNumber.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        DirectCast(InfoItem, LabourValueInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.LabourValues_Add(DirectCast(InfoItem, LabourValueInfo), FacessoGeneric.LoginInfo.IDUser)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.LabourValues_Edit(DirectCast(InfoItem, LabourValueInfo), FacessoGeneric.LoginInfo.IDUser)
        End If
    End Sub
End Class
