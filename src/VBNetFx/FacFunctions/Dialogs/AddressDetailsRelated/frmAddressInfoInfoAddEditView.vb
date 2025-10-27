Imports Activedev
Imports Facesso.Data
Imports System.Windows.Forms

Friend Class frmAddressDetailsInfoAddEditView
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
    Friend WithEvents ntbMiddleName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbURL As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbPrivateEmail As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbPrivateMobile As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbPrivatePhone As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCompanyEmail As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCompanyMobile As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCompanyPhone As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCountry As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCountryCode As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbCity As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbZip As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbStreet As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbTitel As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbFirstName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbLastName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nibPersonnelNo As ActiveDev.Controls.ADNullableIntBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.ntbMiddleName = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbURL = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbPrivateEmail = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbPrivateMobile = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbPrivatePhone = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCompanyEmail = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCompanyMobile = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCompanyPhone = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCountry = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCountryCode = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbCity = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbZip = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbStreet = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbTitel = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbFirstName = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbLastName = New ActiveDev.Controls.ADNullableTextBox
        Me.nibPersonnelNo = New ActiveDev.Controls.ADNullableIntBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(569, 13)
        Me.btnOK.TabIndex = 17
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(569, 58)
        Me.btnCancel.TabIndex = 18
        '
        'ntbMiddleName
        '
        Me.ntbMiddleName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbMiddleName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbMiddleName.CaptionToValueRatio = 343.75
        Me.ntbMiddleName.ColorOnFocus = True
        Me.ntbMiddleName.FailedValidationErrorMessage = Nothing
        Me.ntbMiddleName.HasCaption = True
        Me.ntbMiddleName.IndependentDatafieldName = "MiddleName"
        Me.ntbMiddleName.Location = New System.Drawing.Point(13, 137)
        Me.ntbMiddleName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbMiddleName.MaxLength = 100
        Me.ntbMiddleName.Multiline = False
        Me.ntbMiddleName.Name = "ntbMiddleName"
        Me.ntbMiddleName.NullString = "* --- *"
        Me.ntbMiddleName.NullValueMessage = Nothing
        Me.ntbMiddleName.Size = New System.Drawing.Size(544, 23)
        Me.ntbMiddleName.TabIndex = 4
        Me.ntbMiddleName.Text = "Zweiter Vor-/Zusatzname:"
        Me.ntbMiddleName.ValueAreaLength = 357
        '
        'ntbURL
        '
        Me.ntbURL.BackColor = System.Drawing.SystemColors.Window
        Me.ntbURL.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbURL.CaptionToValueRatio = 343.75
        Me.ntbURL.ColorOnFocus = True
        Me.ntbURL.FailedValidationErrorMessage = Nothing
        Me.ntbURL.HasCaption = True
        Me.ntbURL.IndependentDatafieldName = "URL"
        Me.ntbURL.Location = New System.Drawing.Point(13, 489)
        Me.ntbURL.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbURL.MaxLength = 255
        Me.ntbURL.Multiline = False
        Me.ntbURL.Name = "ntbURL"
        Me.ntbURL.NullString = "* --- *"
        Me.ntbURL.NullValueMessage = Nothing
        Me.ntbURL.Size = New System.Drawing.Size(544, 23)
        Me.ntbURL.TabIndex = 16
        Me.ntbURL.Text = "URL: "
        Me.ntbURL.ValueAreaLength = 357
        '
        'ntbPrivateEmail
        '
        Me.ntbPrivateEmail.BackColor = System.Drawing.SystemColors.Window
        Me.ntbPrivateEmail.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbPrivateEmail.CaptionToValueRatio = 343.75
        Me.ntbPrivateEmail.ColorOnFocus = True
        Me.ntbPrivateEmail.FailedValidationErrorMessage = Nothing
        Me.ntbPrivateEmail.HasCaption = True
        Me.ntbPrivateEmail.IndependentDatafieldName = "PrivateEmail"
        Me.ntbPrivateEmail.Location = New System.Drawing.Point(13, 458)
        Me.ntbPrivateEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbPrivateEmail.MaxLength = 255
        Me.ntbPrivateEmail.Multiline = False
        Me.ntbPrivateEmail.Name = "ntbPrivateEmail"
        Me.ntbPrivateEmail.NullString = "* --- *"
        Me.ntbPrivateEmail.NullValueMessage = Nothing
        Me.ntbPrivateEmail.Size = New System.Drawing.Size(544, 23)
        Me.ntbPrivateEmail.TabIndex = 15
        Me.ntbPrivateEmail.Text = "Private E-Mail: "
        Me.ntbPrivateEmail.ValueAreaLength = 357
        '
        'ntbPrivateMobile
        '
        Me.ntbPrivateMobile.BackColor = System.Drawing.SystemColors.Window
        Me.ntbPrivateMobile.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbPrivateMobile.CaptionToValueRatio = 343.75
        Me.ntbPrivateMobile.ColorOnFocus = True
        Me.ntbPrivateMobile.FailedValidationErrorMessage = Nothing
        Me.ntbPrivateMobile.HasCaption = True
        Me.ntbPrivateMobile.IndependentDatafieldName = "PrivateMobile"
        Me.ntbPrivateMobile.Location = New System.Drawing.Point(13, 427)
        Me.ntbPrivateMobile.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbPrivateMobile.MaxLength = 100
        Me.ntbPrivateMobile.Multiline = False
        Me.ntbPrivateMobile.Name = "ntbPrivateMobile"
        Me.ntbPrivateMobile.NullString = "* --- *"
        Me.ntbPrivateMobile.NullValueMessage = Nothing
        Me.ntbPrivateMobile.Size = New System.Drawing.Size(544, 23)
        Me.ntbPrivateMobile.TabIndex = 14
        Me.ntbPrivateMobile.Text = "Privat-Mobiltelefon: "
        Me.ntbPrivateMobile.ValueAreaLength = 357
        '
        'ntbPrivatePhone
        '
        Me.ntbPrivatePhone.BackColor = System.Drawing.SystemColors.Window
        Me.ntbPrivatePhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbPrivatePhone.CaptionToValueRatio = 343.75
        Me.ntbPrivatePhone.ColorOnFocus = True
        Me.ntbPrivatePhone.FailedValidationErrorMessage = Nothing
        Me.ntbPrivatePhone.HasCaption = True
        Me.ntbPrivatePhone.IndependentDatafieldName = "PrivatePhone"
        Me.ntbPrivatePhone.Location = New System.Drawing.Point(13, 396)
        Me.ntbPrivatePhone.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbPrivatePhone.MaxLength = 100
        Me.ntbPrivatePhone.Multiline = False
        Me.ntbPrivatePhone.Name = "ntbPrivatePhone"
        Me.ntbPrivatePhone.NullString = "* --- *"
        Me.ntbPrivatePhone.NullValueMessage = Nothing
        Me.ntbPrivatePhone.Size = New System.Drawing.Size(544, 23)
        Me.ntbPrivatePhone.TabIndex = 13
        Me.ntbPrivatePhone.Text = "Privattelefon: "
        Me.ntbPrivatePhone.ValueAreaLength = 357
        '
        'ntbCompanyEmail
        '
        Me.ntbCompanyEmail.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCompanyEmail.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCompanyEmail.CaptionToValueRatio = 343.75
        Me.ntbCompanyEmail.ColorOnFocus = True
        Me.ntbCompanyEmail.FailedValidationErrorMessage = Nothing
        Me.ntbCompanyEmail.HasCaption = True
        Me.ntbCompanyEmail.IndependentDatafieldName = "CompanyEmail"
        Me.ntbCompanyEmail.Location = New System.Drawing.Point(13, 350)
        Me.ntbCompanyEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCompanyEmail.MaxLength = 255
        Me.ntbCompanyEmail.Multiline = False
        Me.ntbCompanyEmail.Name = "ntbCompanyEmail"
        Me.ntbCompanyEmail.NullString = "* --- *"
        Me.ntbCompanyEmail.NullValueMessage = Nothing
        Me.ntbCompanyEmail.Size = New System.Drawing.Size(544, 23)
        Me.ntbCompanyEmail.TabIndex = 12
        Me.ntbCompanyEmail.Text = "Firmen-E-Mail: "
        Me.ntbCompanyEmail.ValueAreaLength = 357
        '
        'ntbCompanyMobile
        '
        Me.ntbCompanyMobile.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCompanyMobile.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCompanyMobile.CaptionToValueRatio = 343.75
        Me.ntbCompanyMobile.ColorOnFocus = True
        Me.ntbCompanyMobile.FailedValidationErrorMessage = Nothing
        Me.ntbCompanyMobile.HasCaption = True
        Me.ntbCompanyMobile.IndependentDatafieldName = "CompanyMobile"
        Me.ntbCompanyMobile.Location = New System.Drawing.Point(13, 319)
        Me.ntbCompanyMobile.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCompanyMobile.MaxLength = 100
        Me.ntbCompanyMobile.Multiline = False
        Me.ntbCompanyMobile.Name = "ntbCompanyMobile"
        Me.ntbCompanyMobile.NullString = "* --- *"
        Me.ntbCompanyMobile.NullValueMessage = Nothing
        Me.ntbCompanyMobile.Size = New System.Drawing.Size(544, 23)
        Me.ntbCompanyMobile.TabIndex = 11
        Me.ntbCompanyMobile.Text = "Firmen-Mobiltelefon: "
        Me.ntbCompanyMobile.ValueAreaLength = 357
        '
        'ntbCompanyPhone
        '
        Me.ntbCompanyPhone.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCompanyPhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCompanyPhone.CaptionToValueRatio = 343.75
        Me.ntbCompanyPhone.ColorOnFocus = True
        Me.ntbCompanyPhone.FailedValidationErrorMessage = Nothing
        Me.ntbCompanyPhone.HasCaption = True
        Me.ntbCompanyPhone.IndependentDatafieldName = "CompanyPhone"
        Me.ntbCompanyPhone.Location = New System.Drawing.Point(13, 288)
        Me.ntbCompanyPhone.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCompanyPhone.MaxLength = 100
        Me.ntbCompanyPhone.Multiline = False
        Me.ntbCompanyPhone.Name = "ntbCompanyPhone"
        Me.ntbCompanyPhone.NullString = "* --- *"
        Me.ntbCompanyPhone.NullValueMessage = Nothing
        Me.ntbCompanyPhone.Size = New System.Drawing.Size(544, 23)
        Me.ntbCompanyPhone.TabIndex = 10
        Me.ntbCompanyPhone.Text = "Firmen-Telefon: "
        Me.ntbCompanyPhone.ValueAreaLength = 357
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
        Me.ntbCountry.Location = New System.Drawing.Point(292, 243)
        Me.ntbCountry.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCountry.MaxLength = 100
        Me.ntbCountry.Multiline = False
        Me.ntbCountry.Name = "ntbCountry"
        Me.ntbCountry.NullString = "* --- *"
        Me.ntbCountry.NullValueMessage = Nothing
        Me.ntbCountry.Size = New System.Drawing.Size(265, 23)
        Me.ntbCountry.TabIndex = 9
        Me.ntbCountry.Text = "PLZ/Ort:"
        Me.ntbCountry.ValueAreaLength = 265
        '
        'ntbCountryCode
        '
        Me.ntbCountryCode.BackColor = System.Drawing.SystemColors.Window
        Me.ntbCountryCode.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbCountryCode.CaptionToValueRatio = 703.01
        Me.ntbCountryCode.ColorOnFocus = True
        Me.ntbCountryCode.FailedValidationErrorMessage = Nothing
        Me.ntbCountryCode.HasCaption = True
        Me.ntbCountryCode.IndependentDatafieldName = "CountryCode"
        Me.ntbCountryCode.Location = New System.Drawing.Point(13, 243)
        Me.ntbCountryCode.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCountryCode.MaxLength = 10
        Me.ntbCountryCode.Multiline = False
        Me.ntbCountryCode.Name = "ntbCountryCode"
        Me.ntbCountryCode.NullString = "* --- *"
        Me.ntbCountryCode.NullValueMessage = Nothing
        Me.ntbCountryCode.Size = New System.Drawing.Size(266, 23)
        Me.ntbCountryCode.TabIndex = 8
        Me.ntbCountryCode.Text = "L‰nderkennung/Land: "
        Me.ntbCountryCode.ValueAreaLength = 79
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
        Me.ntbCity.Location = New System.Drawing.Point(292, 212)
        Me.ntbCity.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbCity.MaxLength = 100
        Me.ntbCity.Multiline = False
        Me.ntbCity.Name = "ntbCity"
        Me.ntbCity.NullString = "* --- *"
        Me.ntbCity.NullValueMessage = Nothing
        Me.ntbCity.Size = New System.Drawing.Size(265, 23)
        Me.ntbCity.TabIndex = 7
        Me.ntbCity.Text = "PLZ/Ort:"
        Me.ntbCity.ValueAreaLength = 265
        '
        'ntbZip
        '
        Me.ntbZip.BackColor = System.Drawing.SystemColors.Window
        Me.ntbZip.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbZip.CaptionToValueRatio = 703.01
        Me.ntbZip.ColorOnFocus = True
        Me.ntbZip.FailedValidationErrorMessage = Nothing
        Me.ntbZip.HasCaption = True
        Me.ntbZip.IndependentDatafieldName = "Zip"
        Me.ntbZip.Location = New System.Drawing.Point(13, 212)
        Me.ntbZip.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbZip.MaxLength = 10
        Me.ntbZip.Multiline = False
        Me.ntbZip.Name = "ntbZip"
        Me.ntbZip.NullString = "* --- *"
        Me.ntbZip.NullValueMessage = Nothing
        Me.ntbZip.Size = New System.Drawing.Size(266, 23)
        Me.ntbZip.TabIndex = 6
        Me.ntbZip.Text = "PLZ/Ort:"
        Me.ntbZip.ValueAreaLength = 79
        '
        'ntbStreet
        '
        Me.ntbStreet.BackColor = System.Drawing.SystemColors.Window
        Me.ntbStreet.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbStreet.CaptionToValueRatio = 343.75
        Me.ntbStreet.ColorOnFocus = True
        Me.ntbStreet.FailedValidationErrorMessage = Nothing
        Me.ntbStreet.HasCaption = True
        Me.ntbStreet.IndependentDatafieldName = "Street"
        Me.ntbStreet.Location = New System.Drawing.Point(13, 181)
        Me.ntbStreet.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbStreet.MaxLength = 100
        Me.ntbStreet.Multiline = False
        Me.ntbStreet.Name = "ntbStreet"
        Me.ntbStreet.NullString = "* --- *"
        Me.ntbStreet.NullValueMessage = Nothing
        Me.ntbStreet.Size = New System.Drawing.Size(544, 23)
        Me.ntbStreet.TabIndex = 5
        Me.ntbStreet.Text = "Straﬂe: "
        Me.ntbStreet.ValueAreaLength = 357
        '
        'ntbTitel
        '
        Me.ntbTitel.BackColor = System.Drawing.SystemColors.Window
        Me.ntbTitel.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbTitel.CaptionToValueRatio = 343.75
        Me.ntbTitel.ColorOnFocus = True
        Me.ntbTitel.FailedValidationErrorMessage = Nothing
        Me.ntbTitel.HasCaption = True
        Me.ntbTitel.IndependentDatafieldName = "Titel"
        Me.ntbTitel.Location = New System.Drawing.Point(13, 44)
        Me.ntbTitel.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbTitel.MaxLength = 100
        Me.ntbTitel.Multiline = False
        Me.ntbTitel.Name = "ntbTitel"
        Me.ntbTitel.NullString = "* --- *"
        Me.ntbTitel.NullValueMessage = Nothing
        Me.ntbTitel.Size = New System.Drawing.Size(544, 23)
        Me.ntbTitel.TabIndex = 1
        Me.ntbTitel.Text = "Titel: "
        Me.ntbTitel.ValueAreaLength = 357
        '
        'ntbFirstName
        '
        Me.ntbFirstName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbFirstName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbFirstName.CaptionToValueRatio = 343.75
        Me.ntbFirstName.ColorOnFocus = True
        Me.ntbFirstName.FailedValidationErrorMessage = Nothing
        Me.ntbFirstName.HasCaption = True
        Me.ntbFirstName.IndependentDatafieldName = "FirstName"
        Me.ntbFirstName.Location = New System.Drawing.Point(13, 106)
        Me.ntbFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbFirstName.MaxLength = 100
        Me.ntbFirstName.Multiline = False
        Me.ntbFirstName.Name = "ntbFirstName"
        Me.ntbFirstName.NullString = "* --- *"
        Me.ntbFirstName.NullValueMessage = Nothing
        Me.ntbFirstName.Size = New System.Drawing.Size(544, 23)
        Me.ntbFirstName.TabIndex = 3
        Me.ntbFirstName.Text = "Vorname:"
        Me.ntbFirstName.ValueAreaLength = 357
        '
        'ntbLastName
        '
        Me.ntbLastName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbLastName.CaptionToValueRatio = 343.75
        Me.ntbLastName.ColorOnFocus = True
        Me.ntbLastName.FailedValidationErrorMessage = Nothing
        Me.ntbLastName.HasCaption = True
        Me.ntbLastName.IndependentDatafieldName = "LastName"
        Me.ntbLastName.Location = New System.Drawing.Point(13, 75)
        Me.ntbLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbLastName.MaxLength = 100
        Me.ntbLastName.Multiline = False
        Me.ntbLastName.Name = "ntbLastName"
        Me.ntbLastName.NullString = "* --- *"
        Me.ntbLastName.NullValueMessage = Nothing
        Me.ntbLastName.Size = New System.Drawing.Size(544, 23)
        Me.ntbLastName.TabIndex = 2
        Me.ntbLastName.Text = "Nachname: "
        Me.ntbLastName.ValueAreaLength = 357
        '
        'nibPersonnelNo
        '
        Me.nibPersonnelNo.BackColor = System.Drawing.SystemColors.Window
        Me.nibPersonnelNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibPersonnelNo.CaptionToValueRatio = 343.75
        Me.nibPersonnelNo.ColorOnFocus = True
        Me.nibPersonnelNo.FailedValidationErrorMessage = Nothing
        Me.nibPersonnelNo.FormularText = ""
        Me.nibPersonnelNo.HasCaption = True
        Me.nibPersonnelNo.IndependentDatafieldName = "PersonnelNo"
        Me.nibPersonnelNo.Location = New System.Drawing.Point(13, 14)
        Me.nibPersonnelNo.MaxValue = 0
        Me.nibPersonnelNo.MinValue = 0
        Me.nibPersonnelNo.Name = "nibPersonnelNo"
        Me.nibPersonnelNo.NullString = "* --- *"
        Me.nibPersonnelNo.NullValueMessage = Nothing
        Me.nibPersonnelNo.Size = New System.Drawing.Size(544, 23)
        Me.nibPersonnelNo.TabIndex = 0
        Me.nibPersonnelNo.Text = "Personal-Nummer:"
        Me.nibPersonnelNo.ValueAreaLength = 357
        '
        'frmAddressDetailsInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(699, 530)
        Me.Controls.Add(Me.nibPersonnelNo)
        Me.Controls.Add(Me.ntbMiddleName)
        Me.Controls.Add(Me.ntbURL)
        Me.Controls.Add(Me.ntbPrivateEmail)
        Me.Controls.Add(Me.ntbPrivateMobile)
        Me.Controls.Add(Me.ntbPrivatePhone)
        Me.Controls.Add(Me.ntbCompanyEmail)
        Me.Controls.Add(Me.ntbCompanyMobile)
        Me.Controls.Add(Me.ntbCompanyPhone)
        Me.Controls.Add(Me.ntbCountry)
        Me.Controls.Add(Me.ntbCountryCode)
        Me.Controls.Add(Me.ntbCity)
        Me.Controls.Add(Me.ntbZip)
        Me.Controls.Add(Me.ntbStreet)
        Me.Controls.Add(Me.ntbTitel)
        Me.Controls.Add(Me.ntbFirstName)
        Me.Controls.Add(Me.ntbLastName)
        Me.Name = "frmAddressDetailsInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.ntbLastName, 0)
        Me.Controls.SetChildIndex(Me.ntbFirstName, 0)
        Me.Controls.SetChildIndex(Me.ntbTitel, 0)
        Me.Controls.SetChildIndex(Me.ntbStreet, 0)
        Me.Controls.SetChildIndex(Me.ntbZip, 0)
        Me.Controls.SetChildIndex(Me.ntbCity, 0)
        Me.Controls.SetChildIndex(Me.ntbCountryCode, 0)
        Me.Controls.SetChildIndex(Me.ntbCountry, 0)
        Me.Controls.SetChildIndex(Me.ntbCompanyPhone, 0)
        Me.Controls.SetChildIndex(Me.ntbCompanyMobile, 0)
        Me.Controls.SetChildIndex(Me.ntbCompanyEmail, 0)
        Me.Controls.SetChildIndex(Me.ntbPrivatePhone, 0)
        Me.Controls.SetChildIndex(Me.ntbPrivateMobile, 0)
        Me.Controls.SetChildIndex(Me.ntbPrivateEmail, 0)
        Me.Controls.SetChildIndex(Me.ntbURL, 0)
        Me.Controls.SetChildIndex(Me.ntbMiddleName, 0)
        Me.Controls.SetChildIndex(Me.nibPersonnelNo, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub ForceToHaveLastNameAndFirstname()
        ntbFirstName.NullValueMessage = My.Resources.AddressDetails_FirstNameNullMessage
        ntbLastName.NullValueMessage = My.Resources.AddressDetails_LastNameNullMessage
    End Sub

End Class
