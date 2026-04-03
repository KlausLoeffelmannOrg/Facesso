Imports Activedev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmUserInfoAddEditView
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordRepetition As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRoles As System.Windows.Forms.Label
    Friend WithEvents clbClearanceLevel As Facesso.FrontEnd.ucClearanceLevelCheckListBox
    Friend WithEvents btnAddressDetails As System.Windows.Forms.Button
    Friend WithEvents ntbComment As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ndbExpireDate As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ncbIsActivated As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ntbFirstname As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbLastName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbUsername As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ncbHasInternetAccess As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncbHasWorkstationAccess As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncombCostCenter As ActiveDev.Controls.ADNullableIdOrIndexComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPasswordRepetition = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRoles = New System.Windows.Forms.Label
        Me.clbClearanceLevel = New Facesso.FrontEnd.ucClearanceLevelCheckListBox
        Me.btnAddressDetails = New System.Windows.Forms.Button
        Me.ntbComment = New ActiveDev.Controls.ADNullableTextBox
        Me.ndbExpireDate = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ncbIsActivated = New ActiveDev.Controls.ADNullableCheckBox
        Me.ntbFirstname = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbLastName = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbUsername = New ActiveDev.Controls.ADNullableTextBox
        Me.ncbHasInternetAccess = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncbHasWorkstationAccess = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncombCostCenter = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(527, 13)
        Me.btnOK.TabIndex = 14
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(527, 58)
        Me.btnCancel.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Passwort/Passwortwiederholung:"
        '
        'txtPasswordRepetition
        '
        Me.txtPasswordRepetition.Location = New System.Drawing.Point(245, 209)
        Me.txtPasswordRepetition.MaxLength = 64
        Me.txtPasswordRepetition.Name = "txtPasswordRepetition"
        Me.txtPasswordRepetition.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordRepetition.Size = New System.Drawing.Size(253, 22)
        Me.txtPasswordRepetition.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(245, 180)
        Me.txtPassword.MaxLength = 64
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(253, 22)
        Me.txtPassword.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 287)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Kontorechte:"
        '
        'lblRoles
        '
        Me.lblRoles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRoles.Location = New System.Drawing.Point(15, 307)
        Me.lblRoles.Name = "lblRoles"
        Me.lblRoles.Size = New System.Drawing.Size(212, 98)
        Me.lblRoles.TabIndex = 17
        '
        'clbClearanceLevel
        '
        Me.clbClearanceLevel.CheckOnClick = True
        Me.clbClearanceLevel.DeselectCombinedFlagsItemBehaviour = Facesso.FrontEnd.CombinedFlagsSelectionBehaviour.IgnoreSingleFlag
        Me.clbClearanceLevel.FormattingEnabled = True
        Me.clbClearanceLevel.IndependentDatafieldName = "ClearanceLevel"
        Me.clbClearanceLevel.Location = New System.Drawing.Point(245, 287)
        Me.clbClearanceLevel.Margin = New System.Windows.Forms.Padding(6)
        Me.clbClearanceLevel.Name = "clbClearanceLevel"
        Me.clbClearanceLevel.NullValueMessage = Nothing
        Me.clbClearanceLevel.SelectCombinedFlagsItemBehaviour = Facesso.FrontEnd.CombinedFlagsSelectionBehaviour.SelectSingelFlag
        Me.clbClearanceLevel.Size = New System.Drawing.Size(254, 118)
        Me.clbClearanceLevel.TabIndex = 11
        '
        'btnAddressDetails
        '
        Me.btnAddressDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddressDetails.Location = New System.Drawing.Point(527, 152)
        Me.btnAddressDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddressDetails.Name = "btnAddressDetails"
        Me.btnAddressDetails.Size = New System.Drawing.Size(117, 35)
        Me.btnAddressDetails.TabIndex = 13
        Me.btnAddressDetails.Text = "Adressdetails..."
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
        Me.ntbComment.Location = New System.Drawing.Point(14, 417)
        Me.ntbComment.Margin = New System.Windows.Forms.Padding(6)
        Me.ntbComment.Multiline = True
        Me.ntbComment.Name = "ntbComment"
        Me.ntbComment.NullString = ""
        Me.ntbComment.NullValueMessage = Nothing
        Me.ntbComment.Size = New System.Drawing.Size(484, 122)
        Me.ntbComment.TabIndex = 12
        Me.ntbComment.Text = "Kommentar:"
        Me.ntbComment.ValueAreaLength = 484
        '
        'ndbExpireDate
        '
        Me.ndbExpireDate.BackColor = System.Drawing.SystemColors.Window
        Me.ndbExpireDate.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbExpireDate.CaptionToValueRatio = 349.17
        Me.ndbExpireDate.ColorOnFocus = True
        Me.ndbExpireDate.FailedValidationErrorMessage = "Falsches Datumsformat|Bitte geben Sie in dieses Feld entweder gar nichts oder ein" & _
            "en gültigen Datumswert ein!"
        Me.ndbExpireDate.HasCaption = True
        Me.ndbExpireDate.IndependentDatafieldName = ""
        Me.ndbExpireDate.Location = New System.Drawing.Point(15, 249)
        Me.ndbExpireDate.Margin = New System.Windows.Forms.Padding(6)
        Me.ndbExpireDate.Name = "ndbExpireDate"
        Me.ndbExpireDate.NullString = "* Konto läuft nie ab *"
        Me.ndbExpireDate.NullValueMessage = Nothing
        Me.ndbExpireDate.Size = New System.Drawing.Size(484, 23)
        Me.ndbExpireDate.TabIndex = 9
        Me.ndbExpireDate.Text = "Kontoablaufdatum:"
        Me.ndbExpireDate.ValueAreaLength = 315
        '
        'ncbIsActivated
        '
        Me.ncbIsActivated.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsActivated.CaptionToValueRatio = 801.89
        Me.ncbIsActivated.ColorOnFocus = True
        Me.ncbIsActivated.FailedValidationErrorMessage = Nothing
        Me.ncbIsActivated.HasCaption = True
        Me.ncbIsActivated.IndependentDatafieldName = "IsActivated"
        Me.ncbIsActivated.Location = New System.Drawing.Point(15, 218)
        Me.ncbIsActivated.Margin = New System.Windows.Forms.Padding(6)
        Me.ncbIsActivated.Name = "ncbIsActivated"
        Me.ncbIsActivated.NullString = Nothing
        Me.ncbIsActivated.NullValueMessage = "Bitte bestimmen Sie, ob das Konto aktiviert sein soll!"
        Me.ncbIsActivated.Size = New System.Drawing.Size(212, 19)
        Me.ncbIsActivated.TabIndex = 8
        Me.ncbIsActivated.Text = "Konto aktiviert:"
        Me.ncbIsActivated.ValueAreaLength = 42
        '
        'ntbFirstname
        '
        Me.ntbFirstname.BackColor = System.Drawing.SystemColors.Window
        Me.ntbFirstname.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbFirstname.CaptionToValueRatio = 349.17
        Me.ntbFirstname.ColorOnFocus = True
        Me.ntbFirstname.FailedValidationErrorMessage = Nothing
        Me.ntbFirstname.HasCaption = True
        Me.ntbFirstname.IndependentDatafieldName = "FirstName"
        Me.ntbFirstname.Location = New System.Drawing.Point(15, 51)
        Me.ntbFirstname.Margin = New System.Windows.Forms.Padding(6)
        Me.ntbFirstname.Multiline = False
        Me.ntbFirstname.Name = "ntbFirstname"
        Me.ntbFirstname.NullString = "* --- *"
        Me.ntbFirstname.NullValueMessage = "Bitte bestimmen Sie den Vornamen"
        Me.ntbFirstname.Size = New System.Drawing.Size(484, 23)
        Me.ntbFirstname.TabIndex = 0
        Me.ntbFirstname.Text = "Vorname:"
        Me.ntbFirstname.ValueAreaLength = 315
        '
        'ntbLastName
        '
        Me.ntbLastName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbLastName.CaptionToValueRatio = 349.17
        Me.ntbLastName.ColorOnFocus = True
        Me.ntbLastName.FailedValidationErrorMessage = Nothing
        Me.ntbLastName.HasCaption = True
        Me.ntbLastName.IndependentDatafieldName = "LastName"
        Me.ntbLastName.Location = New System.Drawing.Point(15, 86)
        Me.ntbLastName.Margin = New System.Windows.Forms.Padding(6)
        Me.ntbLastName.Multiline = False
        Me.ntbLastName.Name = "ntbLastName"
        Me.ntbLastName.NullString = "* --- *"
        Me.ntbLastName.NullValueMessage = "Bitte bestimmen Sie den Nachnamen des Benutzers!"
        Me.ntbLastName.Size = New System.Drawing.Size(484, 23)
        Me.ntbLastName.TabIndex = 1
        Me.ntbLastName.Text = "Nachname:"
        Me.ntbLastName.ValueAreaLength = 315
        '
        'ntbUsername
        '
        Me.ntbUsername.BackColor = System.Drawing.SystemColors.Window
        Me.ntbUsername.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbUsername.CaptionToValueRatio = 349.17
        Me.ntbUsername.ColorOnFocus = True
        Me.ntbUsername.FailedValidationErrorMessage = Nothing
        Me.ntbUsername.HasCaption = True
        Me.ntbUsername.IndependentDatafieldName = "Username"
        Me.ntbUsername.Location = New System.Drawing.Point(15, 121)
        Me.ntbUsername.Margin = New System.Windows.Forms.Padding(6)
        Me.ntbUsername.Multiline = False
        Me.ntbUsername.Name = "ntbUsername"
        Me.ntbUsername.NullString = "* --- *"
        Me.ntbUsername.NullValueMessage = "Bitte geben Sie den Benutzernamen ein, mit dem sich der Benutzer später anmeldet!" & _
            ""
        Me.ntbUsername.Size = New System.Drawing.Size(484, 23)
        Me.ntbUsername.TabIndex = 2
        Me.ntbUsername.Text = "Benutzername:"
        Me.ntbUsername.ValueAreaLength = 315
        '
        'ncbHasInternetAccess
        '
        Me.ncbHasInternetAccess.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbHasInternetAccess.CaptionToValueRatio = 801.89
        Me.ncbHasInternetAccess.ColorOnFocus = True
        Me.ncbHasInternetAccess.FailedValidationErrorMessage = Nothing
        Me.ncbHasInternetAccess.HasCaption = True
        Me.ncbHasInternetAccess.IndependentDatafieldName = "HasInternetAccess"
        Me.ncbHasInternetAccess.Location = New System.Drawing.Point(15, 187)
        Me.ncbHasInternetAccess.Margin = New System.Windows.Forms.Padding(6)
        Me.ncbHasInternetAccess.Name = "ncbHasInternetAccess"
        Me.ncbHasInternetAccess.NullString = Nothing
        Me.ncbHasInternetAccess.NullValueMessage = "Bitte bestimmen Sie, ob der Benutzer Internet-Zugriff erhalten soll."
        Me.ncbHasInternetAccess.Size = New System.Drawing.Size(212, 19)
        Me.ncbHasInternetAccess.TabIndex = 7
        Me.ncbHasInternetAccess.Text = "Inter-/Intranet-Zugriff:"
        Me.ncbHasInternetAccess.ValueAreaLength = 42
        '
        'ncbHasWorkstationAccess
        '
        Me.ncbHasWorkstationAccess.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbHasWorkstationAccess.CaptionToValueRatio = 801.89
        Me.ncbHasWorkstationAccess.ColorOnFocus = True
        Me.ncbHasWorkstationAccess.FailedValidationErrorMessage = Nothing
        Me.ncbHasWorkstationAccess.HasCaption = True
        Me.ncbHasWorkstationAccess.IndependentDatafieldName = "HasWorkstationAccess"
        Me.ncbHasWorkstationAccess.Location = New System.Drawing.Point(15, 156)
        Me.ncbHasWorkstationAccess.Margin = New System.Windows.Forms.Padding(6)
        Me.ncbHasWorkstationAccess.Name = "ncbHasWorkstationAccess"
        Me.ncbHasWorkstationAccess.NullString = Nothing
        Me.ncbHasWorkstationAccess.NullValueMessage = "Bitte bestimmen Sie, ob der Benutzer Workstation-Zugriff erhalten soll!"
        Me.ncbHasWorkstationAccess.Size = New System.Drawing.Size(212, 19)
        Me.ncbHasWorkstationAccess.TabIndex = 6
        Me.ncbHasWorkstationAccess.Text = "Workstation-Zugriff:"
        Me.ncbHasWorkstationAccess.ValueAreaLength = 42
        '
        'ncombCostCenter
        '
        Me.ncombCostCenter.BackColor = System.Drawing.SystemColors.Window
        Me.ncombCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncombCostCenter.CaptionToValueRatio = 349.17
        Me.ncombCostCenter.ColorOnFocus = True
        Me.ncombCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncombCostCenter.DropDownHeight = 106
        Me.ncombCostCenter.DropDownWidth = 315
        Me.ncombCostCenter.FailedValidationErrorMessage = Nothing
        Me.ncombCostCenter.HasCaption = True
        Me.ncombCostCenter.IndependentDatafieldName = "IDCostCenter"
        Me.ncombCostCenter.Location = New System.Drawing.Point(15, 16)
        Me.ncombCostCenter.MaxDropDownItems = 8
        Me.ncombCostCenter.Name = "ncombCostCenter"
        Me.ncombCostCenter.NullString = Nothing
        Me.ncombCostCenter.NullValueMessage = Nothing
        Me.ncombCostCenter.Size = New System.Drawing.Size(484, 24)
        Me.ncombCostCenter.TabIndex = 16
        Me.ncombCostCenter.Text = "Kostenstellen-Nummer: "
        Me.ncombCostCenter.ValueAreaLength = 315
        '
        'frmUserInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(657, 558)
        Me.Controls.Add(Me.ncombCostCenter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPasswordRepetition)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRoles)
        Me.Controls.Add(Me.clbClearanceLevel)
        Me.Controls.Add(Me.btnAddressDetails)
        Me.Controls.Add(Me.ntbComment)
        Me.Controls.Add(Me.ndbExpireDate)
        Me.Controls.Add(Me.ncbIsActivated)
        Me.Controls.Add(Me.ntbFirstname)
        Me.Controls.Add(Me.ntbLastName)
        Me.Controls.Add(Me.ntbUsername)
        Me.Controls.Add(Me.ncbHasInternetAccess)
        Me.Controls.Add(Me.ncbHasWorkstationAccess)
        Me.Name = "frmUserInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.ncbHasWorkstationAccess, 0)
        Me.Controls.SetChildIndex(Me.ncbHasInternetAccess, 0)
        Me.Controls.SetChildIndex(Me.ntbUsername, 0)
        Me.Controls.SetChildIndex(Me.ntbLastName, 0)
        Me.Controls.SetChildIndex(Me.ntbFirstname, 0)
        Me.Controls.SetChildIndex(Me.ncbIsActivated, 0)
        Me.Controls.SetChildIndex(Me.ndbExpireDate, 0)
        Me.Controls.SetChildIndex(Me.ntbComment, 0)
        Me.Controls.SetChildIndex(Me.btnAddressDetails, 0)
        Me.Controls.SetChildIndex(Me.clbClearanceLevel, 0)
        Me.Controls.SetChildIndex(Me.lblRoles, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtPassword, 0)
        Me.Controls.SetChildIndex(Me.txtPasswordRepetition, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ncombCostCenter, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private myAddressDetails As AddressDetailsInfo
    Private myPasswordChanged As Boolean

    'Wird aufgerufen bei "Neuer Datensatz"
    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter)
        Me.ncbIsActivated.TypeSafeValue = True
        Me.ncbHasWorkstationAccess.TypeSafeValue = True
        Me.ncbHasInternetAccess.TypeSafeValue = False
    End Sub

    'Wird aufgerufen bei "Datensatz editieren"
    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As IInfoItem)
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter)
        MyBase.Fac_OnAssigningToControls(InfoItem)
        If DirectCast(InfoItem, UserInfo).DoesExpire = True Then
            ndbExpireDate.TypeSafeValue = DirectCast(InfoItem, UserInfo).ExpireDate
        Else
            ndbExpireDate.TypeSafeValue = Nothing
        End If
        Dim locIDAddressDetails As ADDBNullable(Of Integer) = DirectCast(InfoItem, UserInfo).IDAddressDetails
        If Not locIDAddressDetails.IsNull Then
            If Fac_EditMode = InfoItemFormEditMode.Edit Then
                myAddressDetails = New AddressDetailsInfo
                Dim locConn As SqlConnection = SPAccess.GetInstance.GetOpenedConnectionSafely
                Using locConn
                    Dim locCommand As New SqlCommand("SELECT * FROM AddressDetails WHERE IDSubsidiary=" & _
                    FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary.ToString & _
                    " AND [IDAddressDetail]=" & locIDAddressDetails.ToString, locConn)
                    Dim locDR As SqlDataReader = locCommand.ExecuteReader
                End Using
            End If
        End If
    End Sub

    Public Property AddressDetails() As AddressDetailsInfo
        Get
            Return myAddressDetails
        End Get
        Set(ByVal value As AddressDetailsInfo)
            myAddressDetails = value
        End Set
    End Property

    'Wird aufgerufen zum Überprüfen eines Datensatzes bei der Neueingabe
    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        If e.Cancel Then
            Return
        End If
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob der Benutzername schon existiert
        If locSPA.Users_DoesUsernameExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 ntbUsername.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Body
            locErr = String.Format(locErr, ntbUsername.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

        'Passwort überprüfen
        If Not CheckPasswordConcurrency() Then
            e.Cancel = True
        End If

    End Sub

    'Wird aufgerufen zum Überprüfen eines Datensatzes beim Editieren
    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        If e.Cancel Then
            Return
        End If
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob der Benutzername schon existiert
        If locSPA.Users_DoesUsernameExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 ntbUsername.TypeSafeValue, _
                                                 CType(e.InfoItem, UserInfo).IDUser) Then
            Dim locErr As String = My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Body
            locErr = String.Format(locErr, ntbUsername.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

        'Passwort überprüfen
        If Not CheckPasswordConcurrency() Then
            e.Cancel = True
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        CType(InfoItem, UserInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary

        'AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
        If myAddressDetails Is Nothing Then
            myAddressDetails = New AddressDetailsInfo()
            myAddressDetails.FirstName = ntbFirstname.TypeSafeValue
            myAddressDetails.LastName = ntbLastName.TypeSafeValue
        End If

        'Passwort-Hash erzeugen, wenn das Passwort geändert wurde
        If myPasswordChanged Then
            CType(InfoItem, UserInfo).Password = New ADCryptedPassword(txtPassword.Text).CryptedPassword
        End If

        'Datums-Regelung
        If ndbExpireDate.Value.IsNull Then
            CType(InfoItem, UserInfo).ExpireDate = FacessoGeneric.OpenCurrentToDate
            CType(InfoItem, UserInfo).DoesExpire = False
        Else
            CType(InfoItem, UserInfo).ExpireDate = ndbExpireDate.TypeSafeValue
            CType(InfoItem, UserInfo).DoesExpire = True
        End If

        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.Users_Add(CType(InfoItem, UserInfo), FacessoGeneric.LoginInfo.IDUser, myAddressDetails)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.Users_Edit(CType(InfoItem, UserInfo), FacessoGeneric.LoginInfo.IDUser, myAddressDetails)
        End If
    End Sub

    Private Sub btnAddressDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddressDetails.Click
        Dim frmAdrDetails As New frmAddressDetailsInfoAddEditView()

        'AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
        If myAddressDetails Is Nothing Then
            myAddressDetails = New AddressDetailsInfo()
        End If

        'Die müssen im Haupt- und Adresseninfo-Dialog identisch sein!
        myAddressDetails.FirstName = ntbFirstname.TypeSafeValue
        myAddressDetails.LastName = ntbLastName.TypeSafeValue

        Dim locBack As InfoItemMaintenanceDialogResult
        'Für den Benutzereintrag dürfen Vor- und Nachname nicht DBNull sein!
        frmAdrDetails.ForceToHaveLastNameAndFirstname()
        locBack = frmAdrDetails.Fac_HandleDialogAsEdit(My.Resources.UserInfoAddOrEdit_AddressDetailsDialogTitle, _
                                                       myAddressDetails)
        If locBack.DialogResult = Windows.Forms.DialogResult.OK Then
            myAddressDetails = DirectCast(locBack.InfoItem, AddressDetailsInfo)
            ntbFirstname.Value = myAddressDetails.FirstName
            ntbLastName.Value = myAddressDetails.LastName
        End If
    End Sub

    Private Function CheckPasswordConcurrency() As Boolean
        If Fac_EditMode = InfoItemFormEditMode.AddNew And txtPassword.Text = "" Then
            MessageBox.Show(My.Resources.UserInfoAddOrEdit_NoPassword_MB_Body, _
                            My.Resources.UserInfoAddOrEdit_NoPassword_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If myPasswordChanged Then
            If Not (txtPassword.Text = txtPasswordRepetition.Text) Then
                MessageBox.Show(My.Resources.UserInfoAddOrEdit_PasswordRepetitionFailed_MB_Body, _
                                My.Resources.UserInfoAddOrEdit_PasswordRepetitionFailed_MB_Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        myPasswordChanged = True
    End Sub

    Private Sub clbClearanceLevel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbClearanceLevel.ValueChanged
        Debug.Print(clbClearanceLevel.Value.Value.ToString)
        lblRoles.Text = clbClearanceLevel.ToString
    End Sub
End Class
