Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmSubsidiaryInfoAddEditView
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
    Friend WithEvents ntbSubsidiary As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCountry As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCountryCode As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCity As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbZip As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbStreet As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbPrimaryPhone As ActiveDev.Controls.ADNullableTextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.ntbSubsidiary = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCountry = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCountryCode = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCity = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbZip = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbStreet = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbPrimaryPhone = New ActiveDev.Controls.ADNullableTextBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(454, 13)
        Me.btnOK.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(454, 58)
        Me.btnCancel.TabIndex = 14
        '
        'ntbSubsidiary
        '
        Me.ntbSubsidiary.BackColor = System.Drawing.SystemColors.Window
        Me.ntbSubsidiary.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbSubsidiary.CaptionToValueRatio = 400.94
        Me.ntbSubsidiary.ColorOnFocus = True
        Me.ntbSubsidiary.FailedValidationErrorMessage = Nothing
        Me.ntbSubsidiary.HasCaption = True
        Me.ntbSubsidiary.IndependentDatafieldName = "SubsidiaryName"
        Me.ntbSubsidiary.Location = New System.Drawing.Point(13, 13)
        Me.ntbSubsidiary.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbSubsidiary.MaxLength = 100
        Me.ntbSubsidiary.Multiline = False
        Me.ntbSubsidiary.Name = "ntbSubsidiary"
        Me.ntbSubsidiary.NullString = "* --- *"
        Me.ntbSubsidiary.NullValueMessage = "Bitte geben Sie einen gültigen Kostenstellennamen ein!"
        Me.ntbSubsidiary.Size = New System.Drawing.Size(424, 23)
        Me.ntbSubsidiary.TabIndex = 0
        Me.ntbSubsidiary.Text = "Name der Subsidiarität:"
        Me.ntbSubsidiary.ValueAreaLength = 254
        '
        'ntbCountry
        '
        Me.ntbCountry.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCountry.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCountry.CaptionToValueRatio = 0
        Me.ntbCountry.ColorOnFocus = True
        Me.ntbCountry.FailedValidationErrorMessage = Nothing
        Me.ntbCountry.HasCaption = False
        Me.ntbCountry.IndependentDatafieldName = "Country"
        Me.ntbCountry.Location = New System.Drawing.Point(254, 124)
        Me.ntbCountry.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCountry.MaxLength = 100
        Me.ntbCountry.Multiline = False
        Me.ntbCountry.Name = "ntbCountry"
        Me.ntbCountry.NullString = "* --- *"
        Me.ntbCountry.NullValueMessage = Nothing
        Me.ntbCountry.Size = New System.Drawing.Size(183, 23)
        Me.ntbCountry.TabIndex = 5
        Me.ntbCountry.Text = "PLZ/Ort:"
        Me.ntbCountry.ValueAreaLength = 183
        '
        'ntbCountryCode
        '
        Me.ntbCountryCode.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCountryCode.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCountryCode.CaptionToValueRatio = 729.61
        Me.ntbCountryCode.ColorOnFocus = True
        Me.ntbCountryCode.FailedValidationErrorMessage = Nothing
        Me.ntbCountryCode.HasCaption = True
        Me.ntbCountryCode.IndependentDatafieldName = "CountryCode"
        Me.ntbCountryCode.Location = New System.Drawing.Point(13, 124)
        Me.ntbCountryCode.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCountryCode.MaxLength = 10
        Me.ntbCountryCode.Multiline = False
        Me.ntbCountryCode.Name = "ntbCountryCode"
        Me.ntbCountryCode.NullString = "* --- *"
        Me.ntbCountryCode.NullValueMessage = Nothing
        Me.ntbCountryCode.Size = New System.Drawing.Size(233, 23)
        Me.ntbCountryCode.TabIndex = 4
        Me.ntbCountryCode.Text = "Länderkennung/Land: "
        Me.ntbCountryCode.ValueAreaLength = 63
        '
        'ntbCity
        '
        Me.ntbCity.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCity.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCity.CaptionToValueRatio = 0
        Me.ntbCity.ColorOnFocus = True
        Me.ntbCity.FailedValidationErrorMessage = Nothing
        Me.ntbCity.HasCaption = False
        Me.ntbCity.IndependentDatafieldName = "City"
        Me.ntbCity.Location = New System.Drawing.Point(254, 93)
        Me.ntbCity.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCity.MaxLength = 100
        Me.ntbCity.Multiline = False
        Me.ntbCity.Name = "ntbCity"
        Me.ntbCity.NullString = "* --- *"
        Me.ntbCity.NullValueMessage = Nothing
        Me.ntbCity.Size = New System.Drawing.Size(183, 23)
        Me.ntbCity.TabIndex = 3
        Me.ntbCity.Text = "PLZ/Ort:"
        Me.ntbCity.ValueAreaLength = 183
        '
        'ntbZip
        '
        Me.ntbZip.BackColor = System.Drawing.SystemColors.Window
        Me.ntbZip.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbZip.CaptionToValueRatio = 729.61
        Me.ntbZip.ColorOnFocus = True
        Me.ntbZip.FailedValidationErrorMessage = Nothing
        Me.ntbZip.HasCaption = True
        Me.ntbZip.IndependentDatafieldName = "Zip"
        Me.ntbZip.Location = New System.Drawing.Point(13, 93)
        Me.ntbZip.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbZip.MaxLength = 10
        Me.ntbZip.Multiline = False
        Me.ntbZip.Name = "ntbZip"
        Me.ntbZip.NullString = "* --- *"
        Me.ntbZip.NullValueMessage = Nothing
        Me.ntbZip.Size = New System.Drawing.Size(233, 23)
        Me.ntbZip.TabIndex = 2
        Me.ntbZip.Text = "PLZ/Ort:"
        Me.ntbZip.ValueAreaLength = 63
        '
        'ntbStreet
        '
        Me.ntbStreet.BackColor = System.Drawing.SystemColors.Window
        Me.ntbStreet.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbStreet.CaptionToValueRatio = 400.94
        Me.ntbStreet.ColorOnFocus = True
        Me.ntbStreet.FailedValidationErrorMessage = Nothing
        Me.ntbStreet.HasCaption = True
        Me.ntbStreet.IndependentDatafieldName = "Street"
        Me.ntbStreet.Location = New System.Drawing.Point(13, 62)
        Me.ntbStreet.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbStreet.MaxLength = 100
        Me.ntbStreet.Multiline = False
        Me.ntbStreet.Name = "ntbStreet"
        Me.ntbStreet.NullString = "* --- *"
        Me.ntbStreet.NullValueMessage = Nothing
        Me.ntbStreet.Size = New System.Drawing.Size(424, 23)
        Me.ntbStreet.TabIndex = 1
        Me.ntbStreet.Text = "Straße: "
        Me.ntbStreet.ValueAreaLength = 254
        '
        'ntbPrimaryPhone
        '
        Me.ntbPrimaryPhone.BackColor = System.Drawing.SystemColors.Window
        Me.ntbPrimaryPhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbPrimaryPhone.CaptionToValueRatio = 400.94
        Me.ntbPrimaryPhone.ColorOnFocus = True
        Me.ntbPrimaryPhone.FailedValidationErrorMessage = Nothing
        Me.ntbPrimaryPhone.HasCaption = True
        Me.ntbPrimaryPhone.IndependentDatafieldName = "PrimaryPhone"
        Me.ntbPrimaryPhone.Location = New System.Drawing.Point(13, 170)
        Me.ntbPrimaryPhone.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbPrimaryPhone.MaxLength = 100
        Me.ntbPrimaryPhone.Multiline = False
        Me.ntbPrimaryPhone.Name = "ntbPrimaryPhone"
        Me.ntbPrimaryPhone.NullString = "* --- *"
        Me.ntbPrimaryPhone.NullValueMessage = Nothing
        Me.ntbPrimaryPhone.Size = New System.Drawing.Size(424, 23)
        Me.ntbPrimaryPhone.TabIndex = 15
        Me.ntbPrimaryPhone.Text = "Primäres Telefon:"
        Me.ntbPrimaryPhone.ValueAreaLength = 254
        '
        'frmSubsidiaryInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(584, 213)
        Me.Controls.Add(Me.ntbPrimaryPhone)
        Me.Controls.Add(Me.ntbCountry)
        Me.Controls.Add(Me.ntbCountryCode)
        Me.Controls.Add(Me.ntbCity)
        Me.Controls.Add(Me.ntbZip)
        Me.Controls.Add(Me.ntbStreet)
        Me.Controls.Add(Me.ntbSubsidiary)
        Me.Name = "frmSubsidiaryInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.ntbSubsidiary, 0)
        Me.Controls.SetChildIndex(Me.ntbStreet, 0)
        Me.Controls.SetChildIndex(Me.ntbZip, 0)
        Me.Controls.SetChildIndex(Me.ntbCity, 0)
        Me.Controls.SetChildIndex(Me.ntbCountryCode, 0)
        Me.Controls.SetChildIndex(Me.ntbCountry, 0)
        Me.Controls.SetChildIndex(Me.ntbPrimaryPhone, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        MyBase.Fac_OnAssigningToControls(InfoItem)
    End Sub

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'TODO: Feststellen, ob der Subsidiaritätsname schon existiert
        If locSPA.Subsidiaries_DoesNameExist(ntbSubsidiary.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body
            locErr = String.Format(locErr, CInt(ntbSubsidiary.TypeSafeValue), _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'TODO: Feststellen, ob der Subsidiaritätsname schon existiert
        If locSPA.Subsidiaries_DoesNameExist(ntbSubsidiary.TypeSafeValue, _
                                                 CType(e.InfoItem, SubsidiaryInfo).IDSubsidiary) Then
            Dim locErr As String = My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Body
            locErr = String.Format(locErr, ntbSubsidiary.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)
        ' Abspeichern der Kostenstelle

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        DirectCast(InfoItem, SubsidiaryInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.Subsidiaries_Add(DirectCast(InfoItem, SubsidiaryInfo), FacessoGeneric.LoginInfo.IDUser)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.Subsidiaries_Edit(DirectCast(InfoItem, SubsidiaryInfo), FacessoGeneric.LoginInfo.IDUser)
        End If
    End Sub

    Private Sub ntbStreet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbStreet.Click

    End Sub
End Class
