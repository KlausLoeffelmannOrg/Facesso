Imports ActiveDev
Imports ActiveDev.Controls
Imports Facesso.Data
Imports System.Data
Imports System.Windows.Forms

Public Class frmWorkGroupInfoAddEditView
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tcTimeSettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ncbIsPeaceWork As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncbIsActive As ActiveDev.Controls.ADNullableCheckBox
    Friend WithEvents ncbCostCenter As ActiveDev.Controls.ADNullableIdOrIndexComboBox
    Friend WithEvents nibWorkGroupNumber As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents ntbWorkGroupDescription As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents ntbWorkGroupName As ActiveDev.Controls.ADNullableTextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UcTimeDetailsSettings As Facesso.FrontEnd.ucTimeDetailsSettings
    Friend WithEvents ndbWorkloadIWT As ActiveDev.Controls.ADNullableDoubleBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkGroupInfoAddEditView))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tcTimeSettings = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ndbWorkloadIWT = New ActiveDev.Controls.ADNullableDoubleBox
        Me.ncbIsPeaceWork = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncbIsActive = New ActiveDev.Controls.ADNullableCheckBox
        Me.ncbCostCenter = New ActiveDev.Controls.ADNullableIdOrIndexComboBox
        Me.nibWorkGroupNumber = New ActiveDev.Controls.ADNullableIntBox
        Me.ntbWorkGroupDescription = New ActiveDev.Controls.ADNullableTextBox
        Me.ntbWorkGroupName = New ActiveDev.Controls.ADNullableTextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.UcTimeDetailsSettings = New Facesso.FrontEnd.ucTimeDetailsSettings
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tcTimeSettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(660, 13)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(660, 58)
        Me.btnCancel.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(200, 100)
        Me.TabControl1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 0
        '
        'tcTimeSettings
        '
        Me.tcTimeSettings.Controls.Add(Me.TabPage1)
        Me.tcTimeSettings.Controls.Add(Me.TabPage2)
        Me.tcTimeSettings.Location = New System.Drawing.Point(12, 13)
        Me.tcTimeSettings.Name = "tcTimeSettings"
        Me.tcTimeSettings.SelectedIndex = 0
        Me.tcTimeSettings.Size = New System.Drawing.Size(616, 593)
        Me.tcTimeSettings.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ndbWorkloadIWT)
        Me.TabPage1.Controls.Add(Me.ncbIsPeaceWork)
        Me.TabPage1.Controls.Add(Me.ncbIsActive)
        Me.TabPage1.Controls.Add(Me.ncbCostCenter)
        Me.TabPage1.Controls.Add(Me.nibWorkGroupNumber)
        Me.TabPage1.Controls.Add(Me.ntbWorkGroupDescription)
        Me.TabPage1.Controls.Add(Me.ntbWorkGroupName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(608, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Produktiv-Site Stammdaten"
        '
        'ndbWorkloadIWT
        '
        Me.ndbWorkloadIWT.BackColor = System.Drawing.SystemColors.Window
        Me.ndbWorkloadIWT.CaptionToValueRatio = 373.52
        Me.ndbWorkloadIWT.ColorOnFocus = True
        Me.ndbWorkloadIWT.CurrencyText = ""
        Me.ndbWorkloadIWT.FailedValidationErrorMessage = Nothing
        Me.ndbWorkloadIWT.FormularText = ""
        Me.ndbWorkloadIWT.HasCaption = True
        Me.ndbWorkloadIWT.IndependentDatafieldName = "WorkloadIWT"
        Me.ndbWorkloadIWT.Location = New System.Drawing.Point(17, 436)
        Me.ndbWorkloadIWT.MaxValue = 0
        Me.ndbWorkloadIWT.MinValue = 0
        Me.ndbWorkloadIWT.Name = "ndbWorkloadIWT"
        Me.ndbWorkloadIWT.NullString = "* --- *"
        Me.ndbWorkloadIWT.NullValueMessage = "Bitte erfassen Sie unter 'Vollauslastung', wie vielen gearbeiteten Arbeitsminuten" & _
            " eine Vollauslastung in dieser Produktiv-Site entspricht."
        Me.ndbWorkloadIWT.Size = New System.Drawing.Size(506, 22)
        Me.ndbWorkloadIWT.TabIndex = 4
        Me.ndbWorkloadIWT.Text = "Vollauslastung bei (min.):"
        Me.ndbWorkloadIWT.ValueAreaLength = 317
        '
        'ncbIsPeaceWork
        '
        Me.ncbIsPeaceWork.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsPeaceWork.CaptionToValueRatio = 735.18
        Me.ncbIsPeaceWork.ColorOnFocus = True
        Me.ncbIsPeaceWork.FailedValidationErrorMessage = Nothing
        Me.ncbIsPeaceWork.HasCaption = True
        Me.ncbIsPeaceWork.IndependentDatafieldName = "IsPeaceWork"
        Me.ncbIsPeaceWork.Location = New System.Drawing.Point(17, 496)
        Me.ncbIsPeaceWork.Name = "ncbIsPeaceWork"
        Me.ncbIsPeaceWork.NullString = Nothing
        Me.ncbIsPeaceWork.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!"
        Me.ncbIsPeaceWork.Size = New System.Drawing.Size(506, 19)
        Me.ncbIsPeaceWork.TabIndex = 6
        Me.ncbIsPeaceWork.Text = "Ist Einzelarbeitsplatz: "
        Me.ncbIsPeaceWork.ValueAreaLength = 134
        '
        'ncbIsActive
        '
        Me.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbIsActive.CaptionToValueRatio = 735.18
        Me.ncbIsActive.ColorOnFocus = True
        Me.ncbIsActive.FailedValidationErrorMessage = Nothing
        Me.ncbIsActive.HasCaption = True
        Me.ncbIsActive.IndependentDatafieldName = "IsActive"
        Me.ncbIsActive.Location = New System.Drawing.Point(17, 471)
        Me.ncbIsActive.Name = "ncbIsActive"
        Me.ncbIsActive.NullString = Nothing
        Me.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!"
        Me.ncbIsActive.Size = New System.Drawing.Size(506, 19)
        Me.ncbIsActive.TabIndex = 5
        Me.ncbIsActive.Text = "Ist aktiviert:"
        Me.ncbIsActive.ValueAreaLength = 134
        '
        'ncbCostCenter
        '
        Me.ncbCostCenter.BackColor = System.Drawing.SystemColors.Window
        Me.ncbCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ncbCostCenter.CaptionToValueRatio = 373.52
        Me.ncbCostCenter.ColorOnFocus = True
        Me.ncbCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32
        Me.ncbCostCenter.DropDownHeight = 106
        Me.ncbCostCenter.DropDownWidth = 315
        Me.ncbCostCenter.FailedValidationErrorMessage = Nothing
        Me.ncbCostCenter.HasCaption = True
        Me.ncbCostCenter.IndependentDatafieldName = "IDCostCenter"
        Me.ncbCostCenter.Location = New System.Drawing.Point(17, 80)
        Me.ncbCostCenter.MaxDropDownItems = 8
        Me.ncbCostCenter.Name = "ncbCostCenter"
        Me.ncbCostCenter.NullString = Nothing
        Me.ncbCostCenter.NullValueMessage = "Bitte bestimmen Sie die Kostenstelle zu diesem Arbeitswert!"
        Me.ncbCostCenter.Size = New System.Drawing.Size(506, 24)
        Me.ncbCostCenter.TabIndex = 2
        Me.ncbCostCenter.Text = "Kostenstellen-Nummer: "
        Me.ncbCostCenter.ValueAreaLength = 317
        '
        'nibWorkGroupNumber
        '
        Me.nibWorkGroupNumber.BackColor = System.Drawing.SystemColors.Window
        Me.nibWorkGroupNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.nibWorkGroupNumber.CaptionToValueRatio = 372.78
        Me.nibWorkGroupNumber.ColorOnFocus = True
        Me.nibWorkGroupNumber.FailedValidationErrorMessage = Nothing
        Me.nibWorkGroupNumber.FormularText = ""
        Me.nibWorkGroupNumber.HasCaption = True
        Me.nibWorkGroupNumber.IndependentDatafieldName = "WorkGroupNumber"
        Me.nibWorkGroupNumber.Location = New System.Drawing.Point(16, 20)
        Me.nibWorkGroupNumber.MaxValue = 0
        Me.nibWorkGroupNumber.MinValue = 0
        Me.nibWorkGroupNumber.Name = "nibWorkGroupNumber"
        Me.nibWorkGroupNumber.NullString = "* --- *"
        Me.nibWorkGroupNumber.NullValueMessage = "Bitte bestimmen Sie die Arbeitswertnummer!"
        Me.nibWorkGroupNumber.Size = New System.Drawing.Size(507, 22)
        Me.nibWorkGroupNumber.TabIndex = 0
        Me.nibWorkGroupNumber.Text = "Produktiv-Site-Nr.: "
        Me.nibWorkGroupNumber.ValueAreaLength = 318
        '
        'ntbWorkGroupDescription
        '
        Me.ntbWorkGroupDescription.BackColor = System.Drawing.SystemColors.Window
        Me.ntbWorkGroupDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ntbWorkGroupDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above
        Me.ntbWorkGroupDescription.CaptionToValueRatio = 1000
        Me.ntbWorkGroupDescription.ColorOnFocus = True
        Me.ntbWorkGroupDescription.FailedValidationErrorMessage = Nothing
        Me.ntbWorkGroupDescription.HasCaption = True
        Me.ntbWorkGroupDescription.IndependentDatafieldName = "WorkGroupDescription"
        Me.ntbWorkGroupDescription.Location = New System.Drawing.Point(17, 120)
        Me.ntbWorkGroupDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbWorkGroupDescription.Multiline = True
        Me.ntbWorkGroupDescription.Name = "ntbWorkGroupDescription"
        Me.ntbWorkGroupDescription.NullString = "* --- *"
        Me.ntbWorkGroupDescription.NullValueMessage = Nothing
        Me.ntbWorkGroupDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.ntbWorkGroupDescription.Size = New System.Drawing.Size(506, 296)
        Me.ntbWorkGroupDescription.TabIndex = 3
        Me.ntbWorkGroupDescription.Text = "Produktiv-Site-Beschreibung:"
        Me.ntbWorkGroupDescription.ValueAreaLength = 506
        '
        'ntbWorkGroupName
        '
        Me.ntbWorkGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.ntbWorkGroupName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.ntbWorkGroupName.CaptionToValueRatio = 373.52
        Me.ntbWorkGroupName.ColorOnFocus = True
        Me.ntbWorkGroupName.FailedValidationErrorMessage = Nothing
        Me.ntbWorkGroupName.HasCaption = True
        Me.ntbWorkGroupName.IndependentDatafieldName = "WorkGroupName"
        Me.ntbWorkGroupName.Location = New System.Drawing.Point(17, 50)
        Me.ntbWorkGroupName.Margin = New System.Windows.Forms.Padding(4)
        Me.ntbWorkGroupName.MaxLength = 100
        Me.ntbWorkGroupName.Multiline = False
        Me.ntbWorkGroupName.Name = "ntbWorkGroupName"
        Me.ntbWorkGroupName.NullString = "* --- *"
        Me.ntbWorkGroupName.NullValueMessage = "Bitte bestimmen Sie einen Arbeitswertnamen !"
        Me.ntbWorkGroupName.Size = New System.Drawing.Size(506, 22)
        Me.ntbWorkGroupName.TabIndex = 1
        Me.ntbWorkGroupName.Text = "Produktiv-Site-Name: "
        Me.ntbWorkGroupName.ValueAreaLength = 317
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.UcTimeDetailsSettings)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(608, 564)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Einstellungen Zeiterfassung"
        '
        'UcTimeDetailsSettings
        '
        Me.UcTimeDetailsSettings.CurrentlyDisplayedShift = 1
        Me.UcTimeDetailsSettings.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll
        Me.UcTimeDetailsSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcTimeDetailsSettings.Location = New System.Drawing.Point(20, 72)
        Me.UcTimeDetailsSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.UcTimeDetailsSettings.Name = "UcTimeDetailsSettings"
        Me.UcTimeDetailsSettings.Size = New System.Drawing.Size(574, 477)
        Me.UcTimeDetailsSettings.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(508, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'frmWorkGroupInfoAddEditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(790, 618)
        Me.Controls.Add(Me.tcTimeSettings)
        Me.Name = "frmWorkGroupInfoAddEditView"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.tcTimeSettings, 0)
        Me.tcTimeSettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Fac_OnInitializeFormControls()
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter)
        Fac_InfoItem = New WorkGroupInfo(True)
        Fac_OnAssigningToControls(Fac_InfoItem)
        UcTimeDetailsSettings.TSDetails = DirectCast(Fac_InfoItem, WorkGroupInfo).TimeSettingDetails
    End Sub

    Protected Overrides Sub Fac_OnAssigningToControls(ByVal InfoItem As ActiveDev.IInfoItem)
        Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter)
        MyBase.Fac_OnAssigningToControls(InfoItem)
        UcTimeDetailsSettings.TSDetails = DirectCast(InfoItem, WorkGroupInfo).TimeSettingDetails
    End Sub

    Protected Overrides Sub Fac_OnValidatingNew(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.Fac_OnValidatingNew(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.WorkGroups_DoesWorkGroupNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibWorkGroupNumber.TypeSafeValue, _
                                                 Nothing) Then
            Dim locErr As String = My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Body
            locErr = String.Format(locErr, nibWorkGroupNumber.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If
    End Sub

    Protected Overrides Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        MyBase.Fac_OnValidatingEdit(e)
        Dim locSPA As SPAccess = SPAccess.GetInstance()

        'Feststellen, ob die Kostenstellennr. schon existiert
        If locSPA.WorkGroups_DoesWorkGroupNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                 nibWorkGroupNumber.TypeSafeValue, _
                                                 CType(e.InfoItem, WorkGroupInfo).IDWorkGroup) Then
            Dim locErr As String = My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Body
            locErr = String.Format(locErr, nibWorkGroupNumber.TypeSafeValue, _
                                 FacessoGeneric.SubsidiarySynonym, _
                                 FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName)
            MessageBox.Show(locErr, My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

    End Sub

    Protected Overrides Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        MyBase.Fac_OnAssigningToInfoItem(InfoItem)
        ' Abspeichern der Kostenstelle

        Dim locSPA As SPAccess = SPAccess.GetInstance()
        DirectCast(InfoItem, WorkGroupInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locSPA.WorkGroups_Add(DirectCast(InfoItem, WorkGroupInfo), FacessoGeneric.LoginInfo.IDUser)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locSPA.WorkGroups_Edit(DirectCast(InfoItem, WorkGroupInfo), FacessoGeneric.LoginInfo.IDUser)
        End If
    End Sub

    Private Sub AdNullableDateTimeBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
