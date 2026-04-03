Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmEmployeeInfoAddEditView
    Inherits Functions.frmInfoItemAddEditViewBase

    Private myAddressDetails As AddressDetailsInfo
    Friend WithEvents btnHandicapManager As System.Windows.Forms.Button
    Private myDoNothing As Boolean
    Private myCurrentInfoItem As IInfoItem

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
    Friend WithEvents ncombCostCenter As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents ntbFirstName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nibPersonnelNumber As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ntbLastName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ncbWageGroup As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents ncbUseFixedWage As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ndbFixedWage As ActiveDev.Controls.ADNullableDoubleBox
    Friend WithEvents ncbIsIncentive As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncbIsActive As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ndbDateOfBirth As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbDateOfJoining As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ndbDateOfSeparation As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents ntbTimeCardNo As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents btnAddressDetails As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.ncombCostCenter = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.ntbFirstName = New ActiveDev.Controls.ADNullableTextBox
        Me.nibPersonnelNumber = New ActiveDev.Controls.ADNullableIntBox
        Me.ntbLastName = New ActiveDev.Controls.ADNullableTextBox
        Me.ncbWageGroup = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.ncbUseFixedWage = New ActiveDev.Controls.ADNullableCheckBox
        Me.ndbFixedWage = New ActiveDev.Controls.ADNullableDoubleBox
        Me.ncbIsIncentive = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncbIsActive = New ActiveDev.Controls.ADNullableCheckBox
        Me.ndbDateOfBirth = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbDateOfJoining = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ndbDateOfSeparation = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.ntbTimeCardNo = New ActiveDev.Controls.ADNullableTextBox
        Me.btnAddressDetails = New System.Windows.Forms.Button
        Me.btnHandicapManager = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(566, 13)
        Me.btnOK.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(566, 58)
        Me.btnCancel.TabIndex = 14
        '
        'ncombCostCenter
        '
        Me.ncombCostCenter.BackColor = System.Drawing.SystemColors.Window
        Me.ncombCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncombCostCenter.CaptionToValueRatio = 426.64
        Me.ncombCostCenter.ColorOnFocus = True
        Me.ncombCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncombCostCenter.DropDownHeight = 106
        Me.ncombCostCenter.DropDownWidth = 315
        Me.ncombCostCenter.FailedValidationErrorMessage = Nothing
        Me.ncombCostCenter.HasCaption = True
        Me.ncombCostCenter.IndependentDatafieldName = "IDCostCenter"
        Me.ncombCostCenter.Location = New System.Drawing.Point(12, 44)
        Me.ncombCostCenter.MaxDropDownItems = 8
        Me.ncombCostCenter.Name = "ncombCostCenter"
        Me.ncombCostCenter.NullString = Nothing
        Me.ncombCostCenter.NullValueMessage = Nothing
        Me.ncombCostCenter.Size = New System.Drawing.Size(518, 24)
        Me.ncombCostCenter.TabIndex = 1
        Me.ncombCostCenter.Text = "Kostenstellen-Nummer: "
        Me.ncombCostCenter.ValueAreaLength = 297
        '
        'ntbFirstName
        '
        Me.ntbFirstName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbFirstName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbFirstName.CaptionToValueRatio = 426.64
        Me.ntbFirstName.ColorOnFocus = True
        Me.ntbFirstName.FailedValidationErrorMessage = Nothing
        Me.ntbFirstName.HasCaption = True
        Me.ntbFirstName.IndependentDatafieldName = "FirstName"
        Me.ntbFirstName.Location = New System.Drawing.Point(12, 118)
        Me.ntbFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbFirstName.MaxLength = 100
        Me.ntbFirstName.Multiline = False
        Me.ntbFirstName.Name = "ntbFirstName"
        Me.ntbFirstName.NullString = "* --- *"
        Me.ntbFirstName.NullValueMessage = "Bitte geben Sie den Vornamen ein!"
        Me.ntbFirstName.Size = New System.Drawing.Size(518, 22)
        Me.ntbFirstName.TabIndex = 3
        Me.ntbFirstName.Text = "Vorname: "
        Me.ntbFirstName.ValueAreaLength = 297
        '
        'nibPersonnelNumber
        '
        Me.nibPersonnelNumber.BackColor = System.Drawing.SystemColors.Window
        Me.nibPersonnelNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibPersonnelNumber.CaptionToValueRatio = 426.64
        Me.nibPersonnelNumber.ColorOnFocus = True
        Me.nibPersonnelNumber.FailedValidationErrorMessage = Nothing
        Me.nibPersonnelNumber.FormularText = ""
        Me.nibPersonnelNumber.HasCaption = True
        Me.nibPersonnelNumber.IndependentDatafieldName = "PersonnelNumber"
        Me.nibPersonnelNumber.Location = New System.Drawing.Point(12, 13)
        Me.nibPersonnelNumber.MaxValue = 0
        Me.nibPersonnelNumber.MinValue = 0
        Me.nibPersonnelNumber.Name = "nibPersonnelNumber"
        Me.nibPersonnelNumber.NullString = "* --- *"
        Me.nibPersonnelNumber.NullValueMessage = "Bitte bestimmen Sie die Personal-Nummer!"
        Me.nibPersonnelNumber.Size = New System.Drawing.Size(518, 22)
        Me.nibPersonnelNumber.TabIndex = 0
        Me.nibPersonnelNumber.Text = "Personal-Nr.:"
        Me.nibPersonnelNumber.ValueAreaLength = 297
        '
        'ntbLastName
        '
        Me.ntbLastName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbLastName.CaptionToValueRatio = 426.64
        Me.ntbLastName.ColorOnFocus = True
        Me.ntbLastName.FailedValidationErrorMessage = Nothing
        Me.ntbLastName.HasCaption = True
        Me.ntbLastName.IndependentDatafieldName = "LastName"
        Me.ntbLastName.Location = New System.Drawing.Point(12, 87)
        Me.ntbLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbLastName.MaxLength = 100
        Me.ntbLastName.Multiline = False
        Me.ntbLastName.Name = "ntbLastName"
        Me.ntbLastName.NullString = "* --- *"
        Me.ntbLastName.NullValueMessage = "Bitte geben Sie den Nachnamen ein:"
        Me.ntbLastName.Size = New System.Drawing.Size(518, 22)
        Me.ntbLastName.TabIndex = 2
        Me.ntbLastName.Text = "Nachname: "
        Me.ntbLastName.ValueAreaLength = 297
        '
        'ncbWageGroup
        '
        Me.ncbWageGroup.BackColor = System.Drawing.SystemColors.Window
        Me.ncbWageGroup.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbWageGroup.CaptionToValueRatio = 426.64
        Me.ncbWageGroup.ColorOnFocus = True
        Me.ncbWageGroup.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncbWageGroup.DropDownHeight = 106
        Me.ncbWageGroup.DropDownWidth = 315
        Me.ncbWageGroup.FailedValidationErrorMessage = Nothing
        Me.ncbWageGroup.HasCaption = True
        Me.ncbWageGroup.IndependentDatafieldName = "IDWageGroup"
        Me.ncbWageGroup.Location = New System.Drawing.Point(11, 169)
        Me.ncbWageGroup.MaxDropDownItems = 8
        Me.ncbWageGroup.Name = "ncbWageGroup"
        Me.ncbWageGroup.NullString = Nothing
        Me.ncbWageGroup.NullValueMessage = Nothing
        Me.ncbWageGroup.Size = New System.Drawing.Size(518, 24)
        Me.ncbWageGroup.TabIndex = 4
        Me.ncbWageGroup.Text = "Lohngruppe: "
        Me.ncbWageGroup.ValueAreaLength = 297
        '
        'ncbUseFixedWage
        '
        Me.ncbUseFixedWage.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbUseFixedWage.CaptionToValueRatio = 741.61
        Me.ncbUseFixedWage.ColorOnFocus = True
        Me.ncbUseFixedWage.FailedValidationErrorMessage = Nothing
        Me.ncbUseFixedWage.HasCaption = True
        Me.ncbUseFixedWage.IndependentDatafieldName = "UseFixedWage"
        Me.ncbUseFixedWage.Location = New System.Drawing.Point(11, 204)
        Me.ncbUseFixedWage.Name = "ncbUseFixedWage"
        Me.ncbUseFixedWage.NullString = Nothing
        Me.ncbUseFixedWage.NullValueMessage = "Bitte bestimmen Sie, ob fixe Beträge verwendet werden sollen oder nicht!"
        Me.ncbUseFixedWage.Size = New System.Drawing.Size(298, 19)
        Me.ncbUseFixedWage.TabIndex = 6
        Me.ncbUseFixedWage.Text = "Fixen Betrag verwenden: "
        Me.ncbUseFixedWage.ValueAreaLength = 77
        '
        'ndbFixedWage
        '
        Me.ndbFixedWage.BackColor = System.Drawing.SystemColors.Window
        Me.ndbFixedWage.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.RightSide
        Me.ndbFixedWage.CaptionToValueRatio = 349.06
        Me.ndbFixedWage.ColorOnFocus = True
        Me.ndbFixedWage.CurrencyText = ""
        Me.ndbFixedWage.FailedValidationErrorMessage = Nothing
        Me.ndbFixedWage.FormularText = ""
        Me.ndbFixedWage.HasCaption = True
        Me.ndbFixedWage.IndependentDatafieldName = "FixedWage"
        Me.ndbFixedWage.Location = New System.Drawing.Point(316, 204)
        Me.ndbFixedWage.MaxValue = 0
        Me.ndbFixedWage.MinValue = 0
        Me.ndbFixedWage.Name = "ndbFixedWage"
        Me.ndbFixedWage.NullString = "* --- *"
        Me.ndbFixedWage.NullValueMessage = Nothing
        Me.ndbFixedWage.Size = New System.Drawing.Size(212, 22)
        Me.ndbFixedWage.TabIndex = 5
        Me.ndbFixedWage.Text = " Euro"
        Me.ndbFixedWage.ValueAreaLength = 138
        '
        'ncbIsIncentive
        '
        Me.ncbIsIncentive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsIncentive.CaptionToValueRatio = 741.61
        Me.ncbIsIncentive.ColorOnFocus = True
        Me.ncbIsIncentive.FailedValidationErrorMessage = Nothing
        Me.ncbIsIncentive.HasCaption = True
        Me.ncbIsIncentive.IndependentDatafieldName = "IsIncentive"
        Me.ncbIsIncentive.Location = New System.Drawing.Point(11, 245)
        Me.ncbIsIncentive.Name = "ncbIsIncentive"
        Me.ncbIsIncentive.NullString = Nothing
        Me.ncbIsIncentive.NullValueMessage = "Bitte bestimmen Sie, ob {%1} berücksichtigt werden soll!"
        Me.ncbIsIncentive.Size = New System.Drawing.Size(298, 19)
        Me.ncbIsIncentive.TabIndex = 7
        Me.ncbIsIncentive.Text = "Für {%1} verwenden:"
        Me.ncbIsIncentive.ValueAreaLength = 77
        '
        'ncbIsActive
        '
        Me.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsActive.CaptionToValueRatio = 741.61
        Me.ncbIsActive.ColorOnFocus = True
        Me.ncbIsActive.FailedValidationErrorMessage = Nothing
        Me.ncbIsActive.HasCaption = True
        Me.ncbIsActive.IndependentDatafieldName = "IsActive"
        Me.ncbIsActive.Location = New System.Drawing.Point(11, 281)
        Me.ncbIsActive.Name = "ncbIsActive"
        Me.ncbIsActive.NullString = Nothing
        Me.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!"
        Me.ncbIsActive.Size = New System.Drawing.Size(298, 19)
        Me.ncbIsActive.TabIndex = 8
        Me.ncbIsActive.Text = "Ist aktiviert:"
        Me.ncbIsActive.ValueAreaLength = 77
        '
        'ndbDateOfBirth
        '
        Me.ndbDateOfBirth.BackColor = System.Drawing.SystemColors.Window
        Me.ndbDateOfBirth.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbDateOfBirth.CaptionToValueRatio = 423.3
        Me.ndbDateOfBirth.ColorOnFocus = True
        Me.ndbDateOfBirth.FailedValidationErrorMessage = Nothing
        Me.ndbDateOfBirth.HasCaption = True
        Me.ndbDateOfBirth.IndependentDatafieldName = "DateOfBirth"
        Me.ndbDateOfBirth.Location = New System.Drawing.Point(11, 323)
        Me.ndbDateOfBirth.Name = "ndbDateOfBirth"
        Me.ndbDateOfBirth.NullString = "* --- *"
        Me.ndbDateOfBirth.NullValueMessage = Nothing
        Me.ndbDateOfBirth.Size = New System.Drawing.Size(515, 22)
        Me.ndbDateOfBirth.TabIndex = 9
        Me.ndbDateOfBirth.Text = "Geburtsdatum:"
        Me.ndbDateOfBirth.ValueAreaLength = 297
        '
        'ndbDateOfJoining
        '
        Me.ndbDateOfJoining.BackColor = System.Drawing.SystemColors.Window
        Me.ndbDateOfJoining.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbDateOfJoining.CaptionToValueRatio = 423.3
        Me.ndbDateOfJoining.ColorOnFocus = True
        Me.ndbDateOfJoining.FailedValidationErrorMessage = Nothing
        Me.ndbDateOfJoining.HasCaption = True
        Me.ndbDateOfJoining.IndependentDatafieldName = "DateOfJoining"
        Me.ndbDateOfJoining.Location = New System.Drawing.Point(11, 352)
        Me.ndbDateOfJoining.Name = "ndbDateOfJoining"
        Me.ndbDateOfJoining.NullString = "* --- *"
        Me.ndbDateOfJoining.NullValueMessage = Nothing
        Me.ndbDateOfJoining.Size = New System.Drawing.Size(515, 22)
        Me.ndbDateOfJoining.TabIndex = 10
        Me.ndbDateOfJoining.Text = "Eintrittsdatum: "
        Me.ndbDateOfJoining.ValueAreaLength = 297
        '
        'ndbDateOfSeparation
        '
        Me.ndbDateOfSeparation.BackColor = System.Drawing.SystemColors.Window
        Me.ndbDateOfSeparation.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbDateOfSeparation.CaptionToValueRatio = 423.3
        Me.ndbDateOfSeparation.ColorOnFocus = True
        Me.ndbDateOfSeparation.FailedValidationErrorMessage = Nothing
        Me.ndbDateOfSeparation.HasCaption = True
        Me.ndbDateOfSeparation.IndependentDatafieldName = "DateOfSeparation"
        Me.ndbDateOfSeparation.Location = New System.Drawing.Point(11, 381)
        Me.ndbDateOfSeparation.Name = "ndbDateOfSeparation"
        Me.ndbDateOfSeparation.NullString = "* --- *"
        Me.ndbDateOfSeparation.NullValueMessage = Nothing
        Me.ndbDateOfSeparation.Size = New System.Drawing.Size(515, 22)
        Me.ndbDateOfSeparation.TabIndex = 11
        Me.ndbDateOfSeparation.Text = "Datum Beschäftigungsende: "
        Me.ndbDateOfSeparation.ValueAreaLength = 297
        '
        'ntbTimeCardNo
        '
        Me.ntbTimeCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.ntbTimeCardNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbTimeCardNo.CaptionToValueRatio = 426.64
        Me.ntbTimeCardNo.ColorOnFocus = True
        Me.ntbTimeCardNo.FailedValidationErrorMessage = Nothing
        Me.ntbTimeCardNo.HasCaption = True
        Me.ntbTimeCardNo.IndependentDatafieldName = "TimeCardNo"
        Me.ntbTimeCardNo.Location = New System.Drawing.Point(11, 426)
        Me.ntbTimeCardNo.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbTimeCardNo.MaxLength = 100
        Me.ntbTimeCardNo.Multiline = False
        Me.ntbTimeCardNo.Name = "ntbTimeCardNo"
        Me.ntbTimeCardNo.NullString = "* --- *"
        Me.ntbTimeCardNo.NullValueMessage = ""
        Me.ntbTimeCardNo.Size = New System.Drawing.Size(518, 22)
        Me.ntbTimeCardNo.TabIndex = 12
        Me.ntbTimeCardNo.Text = "Kartennummer/externe Personalnr:"
        Me.ntbTimeCardNo.ValueAreaLength = 297
        '
        'btnAddressDetails
        '
        Me.btnAddressDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddressDetails.Location = New System.Drawing.Point(566, 133)
        Me.btnAddressDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddressDetails.Name = "btnAddressDetails"
        Me.btnAddressDetails.Size = New System.Drawing.Size(117, 35)
        Me.btnAddressDetails.TabIndex = 15
        Me.btnAddressDetails.Text = "Adressdetails..."
        '
        'btnHandicapManager
        '
        Me.btnHandicapManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHandicapManager.Location = New System.Drawing.Point(566, 176)
        Me.btnHandicapManager.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHandicapManager.Name = "btnHandicapManager"
        Me.btnHandicapManager.Size = New System.Drawing.Size(117, 47)
        Me.btnHandicapManager.TabIndex = 16
        Me.btnHandicapManager.Text = "Handicap- Manager..."
        '
        'frmEmployeeInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(696, 476)
        Me.Controls.Add(Me.btnHandicapManager)
        Me.Controls.Add(Me.btnAddressDetails)
        Me.Controls.Add(Me.ntbTimeCardNo)
        Me.Controls.Add(Me.ndbDateOfSeparation)
        Me.Controls.Add(Me.ndbDateOfJoining)
        Me.Controls.Add(Me.ndbDateOfBirth)
        Me.Controls.Add(Me.ncbIsActive)
        Me.Controls.Add(Me.ncbIsIncentive)
        Me.Controls.Add(Me.ndbFixedWage)
        Me.Controls.Add(Me.ncbUseFixedWage)
        Me.Controls.Add(Me.ncbWageGroup)
        Me.Controls.Add(Me.ncombCostCenter)
        Me.Controls.Add(Me.ntbFirstName)
        Me.Controls.Add(Me.nibPersonnelNumber)
        Me.Controls.Add(Me.ntbLastName)
        Me.Name = "frmEmployeeInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.ntbLastName, 0)
        Me.Controls.SetChildIndex(Me.nibPersonnelNumber, 0)
        Me.Controls.SetChildIndex(Me.ntbFirstName, 0)
        Me.Controls.SetChildIndex(Me.ncombCostCenter, 0)
        Me.Controls.SetChildIndex(Me.ncbWageGroup, 0)
        Me.Controls.SetChildIndex(Me.ncbUseFixedWage, 0)
        Me.Controls.SetChildIndex(Me.ndbFixedWage, 0)
        Me.Controls.SetChildIndex(Me.ncbIsIncentive, 0)
        Me.Controls.SetChildIndex(Me.ncbIsActive, 0)
        Me.Controls.SetChildIndex(Me.ndbDateOfBirth, 0)
        Me.Controls.SetChildIndex(Me.ndbDateOfJoining, 0)
        Me.Controls.SetChildIndex(Me.ndbDateOfSeparation, 0)
        Me.Controls.SetChildIndex(Me.ntbTimeCardNo, 0)
        Me.Controls.SetChildIndex(Me.btnAddressDetails, 0)
        Me.Controls.SetChildIndex(Me.btnHandicapManager, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
        myDoNothing = True
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter)
        Fac_FunctionsInternal.AddWageGroupsToADNullableIdOrIndexComboBox(ncbWageGroup)
        myDoNothing = False

        AlignIncentiveSynonym()
        ncbIsIncentive.TypeSafeValue = True
        ncbIsActive.TypeSafeValue = True
        ncbUseFixedWage.TypeSafeValue = False
        btnHandicapManager.Enabled = False
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        myCurrentInfoItem = InfoItem
        If myCurrentInfoItem IsNot Nothing Then
            btnHandicapManager.Enabled = True
        End If
        myDoNothing = True
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter)
        Fac_FunctionsInternal.AddWageGroupsToADNullableIdOrIndexComboBox(ncbWageGroup)
        myDoNothing = False
        MyBase.Fac_OnAssigningToControls(InfoItem)
        AlignIncentiveSynonym()

        Dim locIDAddressDetails As ADDBNullable(Of Integer) = DirectCast(InfoItem, EmployeeInfo).IDAddressDetails
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

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        If e.Cancel Then
            Return
        End If

        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Personalnummer schon existiert
        If locSPA.Employees_DoesPersonnelNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibPersonnelNumber.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Body
            locErr = String.Format(locErr, nibPersonnelNumber.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        If e.Cancel Then
            Return
        End If

        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.Employees_DoesPersonnelNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibPersonnelNumber.TypeSafeValue, _
                                                 DirectCast(e.InfoItem, EmployeeInfo).IDEmployee) Then
            Dim locErr As String = My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Body
            locErr = String.Format(locErr, nibPersonnelNumber.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        CType(InfoItem, EmployeeInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary

        'AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
        If myAddressDetails Is Nothing Then
            myAddressDetails = New AddressDetailsInfo()
            myAddressDetails.FirstName = ntbFirstName.TypeSafeValue
            myAddressDetails.LastName = ntbLastName.TypeSafeValue
        End If

        DirectCast(InfoItem, EmployeeInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.Employees_Add(DirectCast(InfoItem, EmployeeInfo), FacessoGeneric.LoginInfo.IDUser, myAddressDetails)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.Employees_Edit(DirectCast(InfoItem, EmployeeInfo), FacessoGeneric.LoginInfo.IDUser, myAddressDetails)
        End If
    End Sub

    Private Sub btnAddressDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddressDetails.Click
        Dim frmAdrDetails As New frmAddressDetailsInfoAddEditView()

        'AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
        If myAddressDetails Is Nothing Then
            myAddressDetails = New AddressDetailsInfo()
        End If

        'Die müssen im Haupt- und Adresseninfo-Dialog identisch sein!
        myAddressDetails.FirstName = ntbFirstName.TypeSafeValue
        myAddressDetails.LastName = ntbLastName.TypeSafeValue

        Dim locBack As InfoItemMaintenanceDialogResult
        'Für den Benutzereintrag dürfen Vor- und Nachname nicht DBNull sein!
        frmAdrDetails.ForceToHaveLastNameAndFirstname()
        locBack = frmAdrDetails.Fac_HandleDialogAsEdit(My.Resources.UserInfoAddOrEdit_AddressDetailsDialogTitle, _
                                                       myAddressDetails)
        If locBack.DialogResult = Windows.Forms.DialogResult.OK Then
            myAddressDetails = DirectCast(locBack.InfoItem, AddressDetailsInfo)
            ntbFirstName.Value = myAddressDetails.FirstName
            ntbLastName.Value = myAddressDetails.LastName
        End If

    End Sub

    Private Sub ncombCostCenter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ncombCostCenter.ValueChanged
        If myDoNothing Then Return
        AlignIncentiveSynonym()
    End Sub

    Private Sub AlignIncentiveSynonym()
        Dim locString As String = String.Format(My.Resources.EmployeeInfoAddEditView_Dialog_IncentiveSynonym, _
            SPAccess.GetInstance.GetCostCenter( _
                FacessoGeneric.LoginInfo.IDSubsidiary, _
                ncombCostCenter.TypeSafeValue).IncentiveIndicatorSynonym)
        ncbIsIncentive.Text = locString
    End Sub

    Private Sub btnHandicapManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHandicapManager.Click
        Dim frmInstance As New frmHandicapRangeManager

        'Hack: Speichern bei Neuanlegen berücksichtigen
        frmInstance.ShowDialog(DirectCast(myCurrentInfoItem, EmployeeInfo))

    End Sub
End Class
