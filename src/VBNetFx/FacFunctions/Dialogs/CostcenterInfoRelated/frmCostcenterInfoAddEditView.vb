Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmCostcenterInfoAddEditView
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
    Friend WithEvents nsbCostCenterDescription As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nsbCostCenterName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nibCostCenterNo As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ntbIncentiveSynonym As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbIncentiveDimension As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ncbUseFixValuedBonus As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ndbIncentiveIndicatorFactor As ActiveDev.Controls.ADNullableDoubleBox
    Friend WithEvents ntbIncentiveWageSynonym As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nibIncentiveIndicatorPrecision As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents ncbIDCurrency As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents ntbBaseValueSynonym As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents nibBaseValuePrecision As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.nsbCostCenterDescription = New ActiveDev.Controls.ADNullableTextBox
        Me.nsbCostCenterName = New ActiveDev.Controls.ADNullableTextBox
        Me.nibCostCenterNo = New ActiveDev.Controls.ADNullableIntBox
        Me.ntbIncentiveSynonym = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbIncentiveDimension = New ActiveDev.Controls.ADNullableTextBox
        Me.ncbUseFixValuedBonus = New ActiveDev.Controls.ADNullableCheckBox
        Me.ndbIncentiveIndicatorFactor = New ActiveDev.Controls.ADNullableDoubleBox
        Me.ntbIncentiveWageSynonym = New ActiveDev.Controls.ADNullableTextBox
        Me.nibIncentiveIndicatorPrecision = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.ncbIDCurrency = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.ntbBaseValueSynonym = New ActiveDev.Controls.ADNullableTextBox
        Me.nibBaseValuePrecision = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(454, 13)
        Me.btnOK.TabIndex = 15
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(454, 58)
        Me.btnCancel.TabIndex = 16
        '
        'nsbCostCenterDescription
        '
        Me.nsbCostCenterDescription.BackColor = System.Drawing.SystemColors.Window
        Me.nsbCostCenterDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nsbCostCenterDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above
        Me.nsbCostCenterDescription.CaptionToValueRatio = 1000
        Me.nsbCostCenterDescription.ColorOnFocus = True
        Me.nsbCostCenterDescription.FailedValidationErrorMessage = Nothing
        Me.nsbCostCenterDescription.HasCaption = True
        Me.nsbCostCenterDescription.IndependentDatafieldName = "CostCenterDescription"
        Me.nsbCostCenterDescription.Location = New System.Drawing.Point(13, 91)
        Me.nsbCostCenterDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.nsbCostCenterDescription.Multiline = True
        Me.nsbCostCenterDescription.Name = "nsbCostCenterDescription"
        Me.nsbCostCenterDescription.NullString = "* --- *"
        Me.nsbCostCenterDescription.NullValueMessage = Nothing
        Me.nsbCostCenterDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.nsbCostCenterDescription.Size = New System.Drawing.Size(423, 160)
        Me.nsbCostCenterDescription.TabIndex = 2
        Me.nsbCostCenterDescription.Text = "Kostenstellen-Beschreibung:"
        Me.nsbCostCenterDescription.ValueAreaLength = 423
        '
        'nsbCostCenterName
        '
        Me.nsbCostCenterName.BackColor = System.Drawing.SystemColors.Window
        Me.nsbCostCenterName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nsbCostCenterName.CaptionToValueRatio = 481.13
        Me.nsbCostCenterName.ColorOnFocus = True
        Me.nsbCostCenterName.FailedValidationErrorMessage = Nothing
        Me.nsbCostCenterName.HasCaption = True
        Me.nsbCostCenterName.IndependentDatafieldName = "CostCenterName"
        Me.nsbCostCenterName.Location = New System.Drawing.Point(12, 54)
        Me.nsbCostCenterName.Margin = New System.Windows.Forms.Padding(4)
        Me.nsbCostCenterName.MaxLength = 100
        Me.nsbCostCenterName.Multiline = False
        Me.nsbCostCenterName.Name = "nsbCostCenterName"
        Me.nsbCostCenterName.NullString = "* --- *"
        Me.nsbCostCenterName.NullValueMessage = "Bitte geben Sie einen gültigen Kostenstellennamen ein!"
        Me.nsbCostCenterName.Size = New System.Drawing.Size(424, 22)
        Me.nsbCostCenterName.TabIndex = 1
        Me.nsbCostCenterName.Text = "Kostenstellen-Name:"
        Me.nsbCostCenterName.ValueAreaLength = 220
        '
        'nibCostCenterNo
        '
        Me.nibCostCenterNo.BackColor = System.Drawing.SystemColors.Window
        Me.nibCostCenterNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibCostCenterNo.CaptionToValueRatio = 481.13
        Me.nibCostCenterNo.ColorOnFocus = True
        Me.nibCostCenterNo.FailedValidationErrorMessage = Nothing
        Me.nibCostCenterNo.FormularText = ""
        Me.nibCostCenterNo.HasCaption = True
        Me.nibCostCenterNo.IndependentDatafieldName = "CostCenterNo"
        Me.nibCostCenterNo.Location = New System.Drawing.Point(12, 17)
        Me.nibCostCenterNo.MaxValue = 0
        Me.nibCostCenterNo.MinValue = 0
        Me.nibCostCenterNo.Name = "nibCostCenterNo"
        Me.nibCostCenterNo.NullString = "* --- *"
        Me.nibCostCenterNo.NullValueMessage = "Bitte bestimmen Sie die Kostenstellen-Nummer!"
        Me.nibCostCenterNo.Size = New System.Drawing.Size(424, 22)
        Me.nibCostCenterNo.TabIndex = 0
        Me.nibCostCenterNo.Text = "Kostenstellen-Nr.:"
        Me.nibCostCenterNo.ValueAreaLength = 220
        '
        'ntbIncentiveSynonym
        '
        Me.ntbIncentiveSynonym.BackColor = System.Drawing.SystemColors.Window
        Me.ntbIncentiveSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbIncentiveSynonym.CaptionToValueRatio = 478.87
        Me.ntbIncentiveSynonym.ColorOnFocus = True
        Me.ntbIncentiveSynonym.FailedValidationErrorMessage = Nothing
        Me.ntbIncentiveSynonym.HasCaption = True
        Me.ntbIncentiveSynonym.IndependentDatafieldName = "IncentiveIndicatorSynonym"
        Me.ntbIncentiveSynonym.Location = New System.Drawing.Point(9, 487)
        Me.ntbIncentiveSynonym.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbIncentiveSynonym.MaxLength = 50
        Me.ntbIncentiveSynonym.Multiline = False
        Me.ntbIncentiveSynonym.Name = "ntbIncentiveSynonym"
        Me.ntbIncentiveSynonym.NullString = "* --- *"
        Me.ntbIncentiveSynonym.NullValueMessage = "Bitte bestimmen Sie die Leistungsbezeichnung!"
        Me.ntbIncentiveSynonym.Size = New System.Drawing.Size(426, 22)
        Me.ntbIncentiveSynonym.TabIndex = 10
        Me.ntbIncentiveSynonym.Text = "Leistungsbezeichnung: "
        Me.ntbIncentiveSynonym.ValueAreaLength = 222
        '
        'ntbIncentiveDimension
        '
        Me.ntbIncentiveDimension.BackColor = System.Drawing.SystemColors.Window
        Me.ntbIncentiveDimension.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbIncentiveDimension.CaptionToValueRatio = 478.87
        Me.ntbIncentiveDimension.ColorOnFocus = True
        Me.ntbIncentiveDimension.FailedValidationErrorMessage = Nothing
        Me.ntbIncentiveDimension.HasCaption = True
        Me.ntbIncentiveDimension.IndependentDatafieldName = "IncentiveIndicatorDimension"
        Me.ntbIncentiveDimension.Location = New System.Drawing.Point(9, 518)
        Me.ntbIncentiveDimension.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbIncentiveDimension.MaxLength = 10
        Me.ntbIncentiveDimension.Multiline = False
        Me.ntbIncentiveDimension.Name = "ntbIncentiveDimension"
        Me.ntbIncentiveDimension.NullString = "* --- *"
        Me.ntbIncentiveDimension.NullValueMessage = "Bitte bestimmen Sie die Leistungseinheit!"
        Me.ntbIncentiveDimension.ReturnNullOnEmptyString = False
        Me.ntbIncentiveDimension.Size = New System.Drawing.Size(426, 22)
        Me.ntbIncentiveDimension.TabIndex = 11
        Me.ntbIncentiveDimension.Text = "Leistungseinheit: "
        Me.ntbIncentiveDimension.ValueAreaLength = 222
        '
        'ncbUseFixValuedBonus
        '
        Me.ncbUseFixValuedBonus.CaptionToValueRatio = 801.89
        Me.ncbUseFixValuedBonus.ColorOnFocus = True
        Me.ncbUseFixValuedBonus.FailedValidationErrorMessage = Nothing
        Me.ncbUseFixValuedBonus.HasCaption = True
        Me.ncbUseFixValuedBonus.IndependentDatafieldName = "UseFixValuedBonus"
        Me.ncbUseFixValuedBonus.Location = New System.Drawing.Point(11, 344)
        Me.ncbUseFixValuedBonus.Name = "ncbUseFixValuedBonus"
        Me.ncbUseFixValuedBonus.NullString = Nothing
        Me.ncbUseFixValuedBonus.NullValueMessage = "Prämienberechnungsfeld darf keinen Zwischenstatus haben!"
        Me.ncbUseFixValuedBonus.Size = New System.Drawing.Size(424, 19)
        Me.ncbUseFixValuedBonus.TabIndex = 5
        Me.ncbUseFixValuedBonus.Text = "Vergütungsberechnung mit fixen Beträgen:"
        Me.ncbUseFixValuedBonus.ValueAreaLength = 84
        '
        'ndbIncentiveIndicatorFactor
        '
        Me.ndbIncentiveIndicatorFactor.BackColor = System.Drawing.SystemColors.Window
        Me.ndbIncentiveIndicatorFactor.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ndbIncentiveIndicatorFactor.CaptionToValueRatio = 478.87
        Me.ndbIncentiveIndicatorFactor.ColorOnFocus = True
        Me.ndbIncentiveIndicatorFactor.CurrencyText = ""
        Me.ndbIncentiveIndicatorFactor.FailedValidationErrorMessage = Nothing
        Me.ndbIncentiveIndicatorFactor.FormularText = ""
        Me.ndbIncentiveIndicatorFactor.HasCaption = True
        Me.ndbIncentiveIndicatorFactor.IndependentDatafieldName = "IncentiveIndicatorFactor"
        Me.ndbIncentiveIndicatorFactor.Location = New System.Drawing.Point(9, 548)
        Me.ndbIncentiveIndicatorFactor.MaxValue = 0
        Me.ndbIncentiveIndicatorFactor.MinValue = 0
        Me.ndbIncentiveIndicatorFactor.Name = "ndbIncentiveIndicatorFactor"
        Me.ndbIncentiveIndicatorFactor.NullString = "* --- *"
        Me.ndbIncentiveIndicatorFactor.NullValueMessage = "Bitte bestimmen Sie den Leistungsmultiplikator!"
        Me.ndbIncentiveIndicatorFactor.Size = New System.Drawing.Size(426, 22)
        Me.ndbIncentiveIndicatorFactor.TabIndex = 12
        Me.ndbIncentiveIndicatorFactor.Text = "Leistungsmultiplikator:"
        Me.ndbIncentiveIndicatorFactor.ValueAreaLength = 222
        '
        'ntbIncentiveWageSynonym
        '
        Me.ntbIncentiveWageSynonym.BackColor = System.Drawing.SystemColors.Window
        Me.ntbIncentiveWageSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbIncentiveWageSynonym.CaptionToValueRatio = 481.13
        Me.ntbIncentiveWageSynonym.ColorOnFocus = True
        Me.ntbIncentiveWageSynonym.FailedValidationErrorMessage = Nothing
        Me.ntbIncentiveWageSynonym.HasCaption = True
        Me.ntbIncentiveWageSynonym.IndependentDatafieldName = "IncentiveWageSynonym"
        Me.ntbIncentiveWageSynonym.Location = New System.Drawing.Point(11, 311)
        Me.ntbIncentiveWageSynonym.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbIncentiveWageSynonym.MaxLength = 50
        Me.ntbIncentiveWageSynonym.Multiline = False
        Me.ntbIncentiveWageSynonym.Name = "ntbIncentiveWageSynonym"
        Me.ntbIncentiveWageSynonym.NullString = "* --- *"
        Me.ntbIncentiveWageSynonym.NullValueMessage = "Bitte bestimmen Sie die Vergütungsbezeichnung!"
        Me.ntbIncentiveWageSynonym.Size = New System.Drawing.Size(424, 22)
        Me.ntbIncentiveWageSynonym.TabIndex = 4
        Me.ntbIncentiveWageSynonym.Text = "Vergütungsbezeichnung: "
        Me.ntbIncentiveWageSynonym.ValueAreaLength = 220
        '
        'nibIncentiveIndicatorPrecision
        '
        Me.nibIncentiveIndicatorPrecision.BackColor = System.Drawing.SystemColors.Window
        Me.nibIncentiveIndicatorPrecision.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibIncentiveIndicatorPrecision.CaptionToValueRatio = 689.19
        Me.nibIncentiveIndicatorPrecision.ColorOnFocus = True
        Me.nibIncentiveIndicatorPrecision.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.Index_As_Int32
        Me.nibIncentiveIndicatorPrecision.DropDownHeight = 106
        Me.nibIncentiveIndicatorPrecision.DropDownWidth = 264
        Me.nibIncentiveIndicatorPrecision.FailedValidationErrorMessage = Nothing
        Me.nibIncentiveIndicatorPrecision.HasCaption = True
        Me.nibIncentiveIndicatorPrecision.IndependentDatafieldName = "IncentiveIndicatorPrecision"
        Me.nibIncentiveIndicatorPrecision.Location = New System.Drawing.Point(9, 577)
        Me.nibIncentiveIndicatorPrecision.MaxDropDownItems = 8
        Me.nibIncentiveIndicatorPrecision.Name = "nibIncentiveIndicatorPrecision"
        Me.nibIncentiveIndicatorPrecision.NullString = Nothing
        Me.nibIncentiveIndicatorPrecision.NullValueMessage = Nothing
        Me.nibIncentiveIndicatorPrecision.Size = New System.Drawing.Size(296, 24)
        Me.nibIncentiveIndicatorPrecision.TabIndex = 13
        Me.nibIncentiveIndicatorPrecision.Text = "Leistungsindikatorgenauigkeit: "
        Me.nibIncentiveIndicatorPrecision.ValueAreaLength = 92
        '
        'ncbIDCurrency
        '
        Me.ncbIDCurrency.BackColor = System.Drawing.SystemColors.Window
        Me.ncbIDCurrency.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIDCurrency.CaptionToValueRatio = 481.13
        Me.ncbIDCurrency.ColorOnFocus = True
        Me.ncbIDCurrency.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncbIDCurrency.DropDownHeight = 106
        Me.ncbIDCurrency.DropDownWidth = 264
        Me.ncbIDCurrency.FailedValidationErrorMessage = Nothing
        Me.ncbIDCurrency.HasCaption = True
        Me.ncbIDCurrency.IndependentDatafieldName = "IDCurrency"
        Me.ncbIDCurrency.Location = New System.Drawing.Point(11, 280)
        Me.ncbIDCurrency.MaxDropDownItems = 8
        Me.ncbIDCurrency.Name = "ncbIDCurrency"
        Me.ncbIDCurrency.NullString = Nothing
        Me.ncbIDCurrency.NullValueMessage = Nothing
        Me.ncbIDCurrency.Size = New System.Drawing.Size(424, 24)
        Me.ncbIDCurrency.TabIndex = 3
        Me.ncbIDCurrency.Text = "Vergütungswährung: "
        Me.ncbIDCurrency.ValueAreaLength = 220
        '
        'ntbBaseValueSynonym
        '
        Me.ntbBaseValueSynonym.BackColor = System.Drawing.SystemColors.Window
        Me.ntbBaseValueSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbBaseValueSynonym.CaptionToValueRatio = 478.87
        Me.ntbBaseValueSynonym.ColorOnFocus = True
        Me.ntbBaseValueSynonym.FailedValidationErrorMessage = Nothing
        Me.ntbBaseValueSynonym.HasCaption = True
        Me.ntbBaseValueSynonym.IndependentDatafieldName = "BaseValueSynonym"
        Me.ntbBaseValueSynonym.Location = New System.Drawing.Point(10, 378)
        Me.ntbBaseValueSynonym.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbBaseValueSynonym.MaxLength = 50
        Me.ntbBaseValueSynonym.Multiline = False
        Me.ntbBaseValueSynonym.Name = "ntbBaseValueSynonym"
        Me.ntbBaseValueSynonym.NullString = "* --- *"
        Me.ntbBaseValueSynonym.NullValueMessage = "Bitte bestimmen Sie die Vergütungsbezeichnung!"
        Me.ntbBaseValueSynonym.Size = New System.Drawing.Size(426, 22)
        Me.ntbBaseValueSynonym.TabIndex = 6
        Me.ntbBaseValueSynonym.Text = "Basiswertbezeichnung: "
        Me.ntbBaseValueSynonym.ValueAreaLength = 222
        '
        'nibBaseValuePrecision
        '
        Me.nibBaseValuePrecision.BackColor = System.Drawing.SystemColors.Window
        Me.nibBaseValuePrecision.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibBaseValuePrecision.CaptionToValueRatio = 689.19
        Me.nibBaseValuePrecision.ColorOnFocus = True
        Me.nibBaseValuePrecision.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.Index_As_Int32
        Me.nibBaseValuePrecision.DropDownHeight = 106
        Me.nibBaseValuePrecision.DropDownWidth = 264
        Me.nibBaseValuePrecision.FailedValidationErrorMessage = Nothing
        Me.nibBaseValuePrecision.HasCaption = True
        Me.nibBaseValuePrecision.IndependentDatafieldName = "BaseValuePrecision"
        Me.nibBaseValuePrecision.Location = New System.Drawing.Point(10, 408)
        Me.nibBaseValuePrecision.MaxDropDownItems = 8
        Me.nibBaseValuePrecision.Name = "nibBaseValuePrecision"
        Me.nibBaseValuePrecision.NullString = Nothing
        Me.nibBaseValuePrecision.NullValueMessage = Nothing
        Me.nibBaseValuePrecision.Size = New System.Drawing.Size(296, 24)
        Me.nibBaseValuePrecision.TabIndex = 7
        Me.nibBaseValuePrecision.Text = "Basiswertgenauigkeit: "
        Me.nibBaseValuePrecision.ValueAreaLength = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 411)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Dezimalstellen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 580)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Dezimalstellen"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 436)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(424, 28)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Wichtig: Basiswerte, wie 'te', werden in Facesso immer auf der Grundlage von h/mi" & _
            "n (hundertstel Minuten) angegeben! Diese Berechnungsgrundlage ist nicht änderbar" & _
            "!"
        '
        'frmCostcenterInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(584, 612)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nibBaseValuePrecision)
        Me.Controls.Add(Me.ntbBaseValueSynonym)
        Me.Controls.Add(Me.ncbIDCurrency)
        Me.Controls.Add(Me.nibIncentiveIndicatorPrecision)
        Me.Controls.Add(Me.ntbIncentiveWageSynonym)
        Me.Controls.Add(Me.ndbIncentiveIndicatorFactor)
        Me.Controls.Add(Me.ncbUseFixValuedBonus)
        Me.Controls.Add(Me.ntbIncentiveDimension)
        Me.Controls.Add(Me.ntbIncentiveSynonym)
        Me.Controls.Add(Me.nibCostCenterNo)
        Me.Controls.Add(Me.nsbCostCenterDescription)
        Me.Controls.Add(Me.nsbCostCenterName)
        Me.Name = "frmCostcenterInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.nsbCostCenterName, 0)
        Me.Controls.SetChildIndex(Me.nsbCostCenterDescription, 0)
        Me.Controls.SetChildIndex(Me.nibCostCenterNo, 0)
        Me.Controls.SetChildIndex(Me.ntbIncentiveSynonym, 0)
        Me.Controls.SetChildIndex(Me.ntbIncentiveDimension, 0)
        Me.Controls.SetChildIndex(Me.ncbUseFixValuedBonus, 0)
        Me.Controls.SetChildIndex(Me.ndbIncentiveIndicatorFactor, 0)
        Me.Controls.SetChildIndex(Me.ntbIncentiveWageSynonym, 0)
        Me.Controls.SetChildIndex(Me.nibIncentiveIndicatorPrecision, 0)
        Me.Controls.SetChildIndex(Me.ncbIDCurrency, 0)
        Me.Controls.SetChildIndex(Me.ntbBaseValueSynonym, 0)
        Me.Controls.SetChildIndex(Me.nibBaseValuePrecision, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FillDecimalPlacesList()
        For z As Integer = 0 To 4
            Dim locCbi As New ADComboBoxItem(z, z)
            nibIncentiveIndicatorPrecision.Items.Add(locCbi)
            nibBaseValuePrecision.Items.Add(locCbi)
        Next
        nibIncentiveIndicatorPrecision.TypeSafeValue = 0
    End Sub

    Protected Overrides Sub Fac_OnInitializeFormControls()
        MyBase.Fac_OnInitializeFormControls()
        Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency)
        FillDecimalPlacesList()
        ntbIncentiveDimension.TypeSafeValue = My.Resources.Incentive_Dimension
        ntbIncentiveSynonym.TypeSafeValue = My.Resources.Incentive_Synonym
        ntbIncentiveWageSynonym.TypeSafeValue = My.Resources.Incentive_WageSynonym
        ncbUseFixValuedBonus.TypeSafeValue = False
        ndbIncentiveIndicatorFactor.TypeSafeValue = 1
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency)
        FillDecimalPlacesList()
        MyBase.Fac_OnAssigningToControls(InfoItem)
    End Sub

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.CostCenters_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 CInt(nibCostCenterNo.Value.Value), _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body
            locErr = String.Format(locErr, CInt(nibCostCenterNo.Value.Value), _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.CostCenters_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 CInt(nibCostCenterNo.Value.Value), _
                                                 CType(e.InfoItem, CostcenterInfo).IDCostCenter) Then
            Dim locErr As String = My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body
            locErr = String.Format(locErr, CInt(nibCostCenterNo.Value.Value), _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)
        ' Abspeichern der Kostenstelle

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        DirectCast(InfoItem, CostcenterInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.CostCenters_Add(DirectCast(InfoItem, CostcenterInfo), FacessoGeneric.LoginInfo.IDUser)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.CostCenters_Edit(DirectCast(InfoItem, CostcenterInfo), FacessoGeneric.LoginInfo.IDUser)
        End If
    End Sub
End Class
