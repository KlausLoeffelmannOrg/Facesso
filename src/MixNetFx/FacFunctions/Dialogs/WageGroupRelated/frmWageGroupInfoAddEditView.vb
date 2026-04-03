Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Data
Imports System.Windows.Forms

Public Class frmWageGroupInfoAddEditView
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
    Friend WithEvents ntbComment As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbWageGroupToken As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ndbHourlyRate As ActiveDev.Controls.ADNullableDoubleBox
    Friend WithEvents ncbIDCurrency As ActiveDev.Controls.ADNullableIdOrIndexComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.ntbComment = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbWageGroupToken = New ActiveDev.Controls.ADNullableTextBox
        Me.ndbHourlyRate = New ActiveDev.Controls.ADNullableDoubleBox
        Me.ncbIDCurrency = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(468, 13)
        Me.btnOK.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(468, 58)
        Me.btnCancel.TabIndex = 5
        '
        'ntbComment
        '
        Me.ntbComment.BackColor = System.Drawing.SystemColors.Window
        Me.ntbComment.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ntbComment.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above
        Me.ntbComment.CaptionToValueRatio = 1000
        Me.ntbComment.ColorOnFocus = True
        Me.ntbComment.FailedValidationErrorMessage = Nothing
        Me.ntbComment.HasCaption = True
        Me.ntbComment.IndependentDatafieldName = "Comment"
        Me.ntbComment.Location = New System.Drawing.Point(12, 113)
        Me.ntbComment.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbComment.Multiline = True
        Me.ntbComment.Name = "ntbComment"
        Me.ntbComment.NullString = "* --- *"
        Me.ntbComment.NullValueMessage = Nothing
        Me.ntbComment.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.ntbComment.Size = New System.Drawing.Size(426, 150)
        Me.ntbComment.TabIndex = 3
        Me.ntbComment.Text = "Anmerkungen:"
        Me.ntbComment.ValueAreaLength = 426
        '
        'ntbWageGroupToken
        '
        Me.ntbWageGroupToken.BackColor = System.Drawing.SystemColors.Window
        Me.ntbWageGroupToken.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbWageGroupToken.CaptionToValueRatio = 420.19
        Me.ntbWageGroupToken.ColorOnFocus = True
        Me.ntbWageGroupToken.FailedValidationErrorMessage = Nothing
        Me.ntbWageGroupToken.HasCaption = True
        Me.ntbWageGroupToken.IndependentDatafieldName = "WageGroupToken"
        Me.ntbWageGroupToken.Location = New System.Drawing.Point(11, 13)
        Me.ntbWageGroupToken.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbWageGroupToken.MaxLength = 100
        Me.ntbWageGroupToken.Multiline = False
        Me.ntbWageGroupToken.Name = "ntbWageGroupToken"
        Me.ntbWageGroupToken.NullString = "* --- *"
        Me.ntbWageGroupToken.NullValueMessage = "Bitte geben Sie einen gültigen Kostenstellennamen ein!"
        Me.ntbWageGroupToken.Size = New System.Drawing.Size(426, 23)
        Me.ntbWageGroupToken.TabIndex = 0
        Me.ntbWageGroupToken.Text = "Lohngruppennr./-kürzel:"
        Me.ntbWageGroupToken.ValueAreaLength = 247
        '
        'ndbHourlyRate
        '
        Me.ndbHourlyRate.AssignFormatString = "#,##0.00"
        Me.ndbHourlyRate.BackColor = System.Drawing.SystemColors.Window
        Me.ndbHourlyRate.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbHourlyRate.CaptionToValueRatio = 420.19
        Me.ndbHourlyRate.ColorOnFocus = True
        Me.ndbHourlyRate.CurrencyText = ""
        Me.ndbHourlyRate.DisplayCustomFormatString = "#,##0.00"
        Me.ndbHourlyRate.DisplayFormat = ActiveDev.Controls.ADUVNumFormat.UseCustomString
        Me.ndbHourlyRate.FailedValidationErrorMessage = Nothing
        Me.ndbHourlyRate.FormularText = ""
        Me.ndbHourlyRate.HasCaption = True
        Me.ndbHourlyRate.IndependentDatafieldName = "HourlyRate"
        Me.ndbHourlyRate.Location = New System.Drawing.Point(11, 43)
        Me.ndbHourlyRate.MaxValue = 0
        Me.ndbHourlyRate.MinValue = 0
        Me.ndbHourlyRate.Name = "ndbHourlyRate"
        Me.ndbHourlyRate.NullString = "* --- *"
        Me.ndbHourlyRate.NullValueMessage = "Bitte bestimmen Sie den Grundlohn pro Stunde!"
        Me.ndbHourlyRate.Size = New System.Drawing.Size(426, 23)
        Me.ndbHourlyRate.TabIndex = 1
        Me.ndbHourlyRate.Text = "Grundlohn (Stunde): "
        Me.ndbHourlyRate.ValueAreaLength = 247
        '
        'ncbIDCurrency
        '
        Me.ncbIDCurrency.BackColor = System.Drawing.SystemColors.Window
        Me.ncbIDCurrency.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIDCurrency.CaptionToValueRatio = 420.19
        Me.ncbIDCurrency.ColorOnFocus = True
        Me.ncbIDCurrency.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncbIDCurrency.DropDownHeight = 106
        Me.ncbIDCurrency.DropDownWidth = 264
        Me.ncbIDCurrency.FailedValidationErrorMessage = Nothing
        Me.ncbIDCurrency.HasCaption = True
        Me.ncbIDCurrency.IndependentDatafieldName = "IDCurrency"
        Me.ncbIDCurrency.Location = New System.Drawing.Point(12, 72)
        Me.ncbIDCurrency.MaxDropDownItems = 8
        Me.ncbIDCurrency.Name = "ncbIDCurrency"
        Me.ncbIDCurrency.NullString = Nothing
        Me.ncbIDCurrency.NullValueMessage = Nothing
        Me.ncbIDCurrency.Size = New System.Drawing.Size(426, 24)
        Me.ncbIDCurrency.TabIndex = 2
        Me.ncbIDCurrency.Text = "Währung:"
        Me.ncbIDCurrency.ValueAreaLength = 247
        '
        'frmWageGroupInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(598, 283)
        Me.Controls.Add(Me.ncbIDCurrency)
        Me.Controls.Add(Me.ndbHourlyRate)
        Me.Controls.Add(Me.ntbComment)
        Me.Controls.Add(Me.ntbWageGroupToken)
        Me.Name = "frmWageGroupInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.ntbWageGroupToken, 0)
        Me.Controls.SetChildIndex(Me.ntbComment, 0)
        Me.Controls.SetChildIndex(Me.ndbHourlyRate, 0)
        Me.Controls.SetChildIndex(Me.ncbIDCurrency, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
        Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency)
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency)
        MyBase.Fac_OnAssigningToControls(InfoItem)
    End Sub

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.WageGroups_DoesTokenExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 ntbWageGroupToken.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Body
            locErr = String.Format(locErr, CInt(ntbWageGroupToken.TypeSafeValue), _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.WageGroups_DoesTokenExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 ntbWageGroupToken.TypeSafeValue, _
                                                 CType(e.InfoItem, WageGroupInfo).IDWageGroup) Then
            Dim locErr As String = My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Body
            locErr = String.Format(locErr, ntbWageGroupToken.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)
        ' Abspeichern der Kostenstelle

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        DirectCast(InfoItem, WageGroupInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.WageGroups_Add(DirectCast(InfoItem, WageGroupInfo), FacessoGeneric.LoginInfo.IDUser)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.WageGroups_Edit(DirectCast(InfoItem, WageGroupInfo), FacessoGeneric.LoginInfo.IDUser)
        End If
    End Sub
End Class
