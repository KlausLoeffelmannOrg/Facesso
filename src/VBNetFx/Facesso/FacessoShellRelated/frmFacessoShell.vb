Imports Facesso.Data
Imports Facesso.Functions
Imports Facesso.Interfaces

Public Class frmFacessoShell

    Private myTsDateLabel As ToolStripLabel
    Private WithEvents myTsmCalender As ToolStripMonthCalender
    Private myTsShiftLabel As ToolStripLabel
    Private myTsShiftButtons As ShiftToolStripButton()
    Private WithEvents myTsNextWorkday As ToolStripButton
    Private WithEvents myTsPreviousWorkday As ToolStripButton
    Private WithEvents myTsTodoList As ToolStripButton
    Private myTsSeparator As ToolStripSeparator
    Private myStandardFont As Font
    Private myBoldFont As Font
    Private myDoNothing As Boolean
    Private WithEvents myWindowsControl As FacessoShellWindowsControl

    Private myEmployees As EmployeeInfoItems
    Private myWorkGroups As WorkGroupInfoItems
    Private myOldSelectedDate As Date
    Private myFacessoGeneralOptions As FacessoGeneralOptions

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myCombinedParameters = New CombinedParametersInfo With {
            .Shift = 1,
            .ProductionDate = DateTime.Now
        }
        myStandardFont = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
        myBoldFont = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)

        myTsDateLabel = New ToolStripLabel("Arbeitstagdatum")
        myTsDateLabel.Font = myBoldFont
        myTsmCalender = New ToolStripMonthCalender
        myTsShiftLabel = New ToolStripLabel("Schicht")
        myTsShiftLabel.Font = myBoldFont
        myTsShiftButtons = New ShiftToolStripButton() {New ShiftToolStripButton("1", Nothing, "1:", "Shift1", AddressOf ShiftButtons_Click), _
                                                  New ShiftToolStripButton("2", Nothing, "2:", "Shift2", AddressOf ShiftButtons_Click), _
                                                  New ShiftToolStripButton("3", Nothing, "3:", "Shift3", AddressOf ShiftButtons_Click), _
                                                  New ShiftToolStripButton("S", Nothing, "S:", "Shift4", AddressOf ShiftButtons_Click)}
        For Each locTsShiftButton As ToolStripButton In myTsShiftButtons
            locTsShiftButton.AutoSize = False
            locTsShiftButton.Height = 30
            locTsShiftButton.Width = 200
            locTsShiftButton.Font = myStandardFont
            locTsShiftButton.DisplayStyle = ToolStripItemDisplayStyle.Text
            locTsShiftButton.Text = ""
            locTsShiftButton.TextAlign = ContentAlignment.MiddleCenter
        Next
        myTsNextWorkday = New ToolStripButton("Nächster Arbeitstag >>")
        myTsNextWorkday.Font = myStandardFont
        myTsPreviousWorkday = New ToolStripButton("<< Vorheriger Arbeitstag")
        myTsPreviousWorkday.Font = myStandardFont
        myTsTodoList = New ToolStripButton("Meine To-do-Liste")
        myTsTodoList.Font = myStandardFont
        With ToolStripDateShiftSelector.Items
            .Add(myTsDateLabel)
            .Add(myTsmCalender)
            .Add(New ToolStripSeparator())
            .Add(myTsNextWorkday)
            .Add(myTsPreviousWorkday)
            .Add(myTsTodoList)
            .Add(New ToolStripSeparator())
            .Add(myTsShiftLabel)
            .AddRange(myTsShiftButtons)
        End With
    End Sub

    Private Sub ToolStripDateShiftSelector_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDateShiftSelector.MouseEnter
        ToolStripDateShiftSelector.Select()
    End Sub

    Private Sub myTsmCalender_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles myTsmCalender.DateChanged
        If myOldSelectedDate = e.Start Then Exit Sub
        UpdateCombinedParameters(False)
        myOldSelectedDate = e.Start
    End Sub

    Private Sub ShiftButtons_Click(ByVal sender As Object, ByVal e As EventArgs)
        If sender.ToString = "Shift1" Then myCombinedParameters.Shift = 1
        If sender.ToString = "Shift2" Then myCombinedParameters.Shift = 2
        If sender.ToString = "Shift3" Then myCombinedParameters.Shift = 3
        If sender.ToString = "Shift4" Then myCombinedParameters.Shift = 4
        UpdateCombinedParameters(False)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.Location = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowLocation", Me.Location), Point)
        Me.Size = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowSize", Me.Size), Size)
        myWindowsControl = New FacessoShellWindowsControl(True, True, True, True, True)
        myWindowsControl.WorkgroupSplitterDistance = splitWorkGroups.SplitterDistance
        myWindowsControl.EmpWorkgroupSplitterDistance = SplitEmployeesWorkGroups.SplitterDistance
        myWindowsControl = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoShellWindowsControl", Me.myWindowsControl), FacessoShellWindowsControl)
        splitWorkGroups.SplitterDistance = myWindowsControl.WorkgroupSplitterDistance
        SplitEmployeesWorkGroups.SplitterDistance = myWindowsControl.EmpWorkgroupSplitterDistance
        myEmployees = New EmployeeInfoItems(0)
        UpdateCombinedParameters(False)
        tslAdminInfo.Text = "Angemeldet: " & FacessoGeneric.LoginInfo.Username & " an " & FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName
        tslAdminInfo.ToolTipText = "Benutzer " & FacessoGeneric.LoginInfo.Username & " an " & FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName & "seit " & Now.ToLongDateString & " - " & Now.ToLongTimeString & " Uhr."
        ApplyWindowsControlChanges()
        TimerMain.Enabled = True
        wglWorkGroups.OnlyActiveWorkgroups = myWindowsControl.OnlyShowActiveWorkGroups
        elvEmployees.OnlyActiveEmployees = myWindowsControl.OnlyShowActiveEmployees
        myFacessoGeneralOptions = DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)

        'TODO: Wieder einblenden - nur ausgeblendet, weil der Start zu lange dauert.
        AssignChartAnalysises()
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        SaveChartAnalysisChanges()
        myWindowsControl.WorkgroupSplitterDistance = splitWorkGroups.SplitterDistance
        myWindowsControl.EmpWorkgroupSplitterDistance = SplitEmployeesWorkGroups.SplitterDistance
        MyBase.OnClosed(e)
        With FacessoGeneric.FacessoUserSettings
            If Not Me.WindowState = FormWindowState.Minimized Then
                .Settings.SetItem("FacessoShellWindowLocation", Me.Location)
                .Settings.SetItem("FacessoShellWindowSize", Me.Size)
            End If
            .Settings.SetItem("FacessoShellWindowsControl", Me.myWindowsControl)
        End With
        FacessoGeneric.SaveAllSettings()
        TimerMain.Enabled = False
    End Sub


#Region "Datei-Menü-Handler"
    Private Sub BaseDataImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseDataImportToolStripMenuItem.Click
        Dim locfrm As New frmTSImport
        locfrm.ShowDialog()
    End Sub
#End Region

#Region "Stammdaten-Menü-Handler"
    Private Sub tsmBaseData_CostCenters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_CostCenters.Click
        Dim locFH As GetFrmCostcenterInfoCenter = FunctionHandler(Of GetFrmCostcenterInfoCenter).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Private Sub tsmBaseData_BonusProgressions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_BonusProgressions.Click
        Dim locFH As GetFrmBonusListMaintenance = FunctionHandler(Of GetFrmBonusListMaintenance).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Private Sub tsmBaseData_WageGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_WageGroups.Click
        Dim locFh As GetFrmWageGroupInfoCenter = FunctionHandler(Of GetFrmWageGroupInfoCenter).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsmBaseData_Employees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_Employees.Click
        Dim locFh As GetFrmEmployeeInfoCenter = FunctionHandler(Of GetFrmEmployeeInfoCenter).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsmBaseData_LabourValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_LabourValues.Click
        Dim locFh As GetFrmLabourValueInfoCenter = FunctionHandler(Of GetFrmLabourValueInfoCenter).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
        UpdateCombinedParameters(False)
    End Sub

    Private Sub tsmBaseData_WorkGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_WorkGroups.Click
        Dim locFh As GetFrmWorkGroupManager = FunctionHandler(Of GetFrmWorkGroupManager).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
        UpdateCombinedParameters(False)
    End Sub
#End Region

#Region "Extras-Menü-Handler"
    Private Sub tsmTools_UserManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTools_UserManagement.Click
        Dim locFH As GetFrmUserInfoCenter = FunctionHandler(Of GetFrmUserInfoCenter).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub
#End Region

    Private Sub tsmEdit_ProductionDataCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEdit_ProductionDataCollection.Click, tsbDataManager.Click
        If (myCombinedParameters IsNot Nothing) AndAlso (Not myCombinedParameters.WorkGroup.IsActive) Then
            MessageBox.Show("Sie können keine Datenerfassung für eine inaktive Produktiv-Site durchführen!", "Datenerfassung nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim locFh As GetFrmProductionDataCollector = FunctionHandler(Of GetFrmProductionDataCollector).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog(myCombinedParameters)
        UpdateCombinedParameters(False)
    End Sub

    Private Sub wglWorkGroups_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wglWorkGroups.DoubleClick
        If wglWorkGroups.SelectedIndices.Count > 0 Then
            myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup
        Else
            myCombinedParameters.WorkGroup = Nothing
        End If
        If (myCombinedParameters IsNot Nothing) AndAlso (Not myCombinedParameters.WorkGroup.IsActive) Then
            MessageBox.Show("Sie können keine Datenerfassung für eine inaktive Produktiv-Site durchführen!", "Datenerfassung nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim locFh As GetFrmProductionDataCollector = FunctionHandler(Of GetFrmProductionDataCollector).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog(myCombinedParameters)
        UpdateCombinedParameters(False)
    End Sub

    Private Sub tsmBaseData_Subsidiaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBaseData_Subsidiaries.Click
        Dim locFh As GetFrmSubsidiaryManager = FunctionHandler(Of GetFrmSubsidiaryManager).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsmCostCalculation_IncentiveWageCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCostCalculation_IncentiveWageCalculation.Click
        Dim locFh As GetFrmIncentiveWageCalc = FunctionHandler(Of GetFrmIncentiveWageCalc).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub ProduktivSitesAuswertungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAnalyses_AnalysisWizard.Click
        Dim locFh As GetFrmWorkGroupAnalysis = FunctionHandler(Of GetFrmWorkGroupAnalysis).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsmCostCalculation_CostOfEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCostCalculation_CostOfEmployees.Click
        MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!")
    End Sub

    Private Sub tsmCostCalculation_CostOfCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCostCalculation_CostOfCostCenter.Click
        MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!")
    End Sub

    Private Sub tsmCostCalculation_CostOfWorkgroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCostCalculation_CostOfWorkgroups.Click
        MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!")
    End Sub

    Private Sub myWindowsControl_WindowsControlSettingsChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles myWindowsControl.WindowsControlSettingsChange
        ApplyWindowsControlChanges()
    End Sub

    Private Sub ApplyWindowsControlChanges()
        tsmView_OnlyActiveEmployees.Checked = myWindowsControl.OnlyShowActiveEmployees
        tsmView_OnlyActiveWorkgroups.Checked = myWindowsControl.OnlyShowActiveWorkGroups
        tsmView_WorkGroupInfo.Checked = myWindowsControl.ShowWorkGroupInfo
        tsmView_Employees.Checked = myWindowsControl.ShowEmployees
        splitWorkGroups.Panel2Collapsed = Not myWindowsControl.ShowWorkGroupInfo
        SplitEmployeesWorkGroups.Panel2Collapsed = Not myWindowsControl.ShowEmployees
        If Not wglWorkGroups.OnlyActiveWorkgroups = myWindowsControl.OnlyShowActiveWorkGroups Then
            wglWorkGroups.OnlyActiveWorkgroups = myWindowsControl.OnlyShowActiveWorkGroups
        End If
        If Not elvEmployees.OnlyActiveEmployees = myWindowsControl.OnlyShowActiveEmployees Then
            elvEmployees.OnlyActiveEmployees = myWindowsControl.OnlyShowActiveEmployees
        End If
    End Sub

    Private Sub UserChangedWindowsControlSettings()
        myWindowsControl.OnlyShowActiveWorkGroups = tsmView_OnlyActiveWorkgroups.Checked
        myWindowsControl.OnlyShowActiveEmployees = tsmView_OnlyActiveEmployees.Checked
        myWindowsControl.ShowWorkGroupInfo = tsmView_WorkGroupInfo.Checked
        myWindowsControl.ShowEmployees = tsmView_Employees.Checked
        tslActiveWorkgroups.Text = myWindowsControl.WorkGroupStateDisplayString
        tslActiveEmployees.Text = myWindowsControl.EmployeeStateDisplayString
    End Sub

    Private Sub tsmView_WorkGroupInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmView_WorkGroupInfo.Click
        tsmView_WorkGroupInfo.Checked = Not tsmView_WorkGroupInfo.Checked
        UserChangedWindowsControlSettings()
    End Sub

    Private Sub tsmView_Employees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmView_Employees.Click
        tsmView_Employees.Checked = Not tsmView_Employees.Checked
        UserChangedWindowsControlSettings()
    End Sub

    Private Sub tsmView_OnlyActiveWorkgroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmView_OnlyActiveWorkgroups.Click
        tsmView_OnlyActiveWorkgroups.Checked = Not tsmView_OnlyActiveWorkgroups.Checked
        UserChangedWindowsControlSettings()
    End Sub

    Private Sub tsmView_OnlyActiveEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmView_OnlyActiveEmployees.Click
        tsmView_OnlyActiveEmployees.Checked = Not tsmView_OnlyActiveEmployees.Checked
        UserChangedWindowsControlSettings()
    End Sub

    Private Sub tsbWorkGroupAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbWorkGroupAnalysis.Click
        Dim locFh As GetFrmWorkGroupAnalysis = FunctionHandler(Of GetFrmWorkGroupAnalysis).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsbAnalysisIncentiveWage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnalysisIncentiveWage.Click
        Dim locFh As GetFrmIncentiveWageCalc = FunctionHandler(Of GetFrmIncentiveWageCalc).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsbBaseDataEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBaseDataEmployee.Click
        Dim locFh As GetFrmEmployeeInfoCenter = FunctionHandler(Of GetFrmEmployeeInfoCenter).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
    End Sub

    Private Sub tsbBaseDataWorkGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBaseDataWorkGroups.Click
        Dim locFh As GetFrmWorkGroupManager = FunctionHandler(Of GetFrmWorkGroupManager).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
        UpdateCombinedParameters(False)
    End Sub

    Private Sub tsbBaseDataLabourValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBaseDataLabourValue.Click
        Dim locFh As GetFrmLabourValueInfoCenter = FunctionHandler(Of GetFrmLabourValueInfoCenter).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
        UpdateCombinedParameters(False)
    End Sub

    Private Sub tsbBaseDataUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBaseDataUser.Click
        Dim locFH As GetFrmUserInfoCenter = FunctionHandler(Of GetFrmUserInfoCenter).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Private Sub tsbOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOptions.Click, tsmTools_Options.Click
        Dim locFh As GetFrmOptions = FunctionHandler(Of GetFrmOptions).GetFunctionInstance
        If locFh Is Nothing Then Return
        locFh.ShowDialog()
        myFacessoGeneralOptions = DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)
    End Sub

    Private Sub tsbPrevWorkDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrevWorkDay.Click, myTsPreviousWorkday.Click
        myTsmCalender.Value = ActiveDev.Dates.PreviousWorkday(myTsmCalender.Value, _
                            myFacessoGeneralOptions.SaturdayIsWorkday, _
                            myFacessoGeneralOptions.SundayIsWorkday)
    End Sub

    Private Sub tsbMyTodoList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMyTodoList.Click, myTsTodoList.Click
        MessageBox.Show("Diese Funktion steht nur in der Enterprise-Edition zur Verfügung", _
                        "Nicht implementiert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub tsbNextWorkDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNextWorkDay.Click, myTsNextWorkday.Click
        myTsmCalender.Value = ActiveDev.Dates.NextWorkday(myTsmCalender.Value, _
                            myFacessoGeneralOptions.SaturdayIsWorkday, _
                            myFacessoGeneralOptions.SundayIsWorkday)
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        tslCurrentDateAndTime.Text = Now.ToLongDateString & " - " & Now.ToLongTimeString
    End Sub

    Private Sub tsmAnalyses_AnalysisManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAnalyses_AnalysisManager.Click
        Dim locFrm As New frmWorkGroupAnalysisManager
        locFrm.ShowDialog()
    End Sub

    Private Sub ProgrammbeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgrammbeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub tsmDataImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDataImport.Click
        Dim locFrm As New frmImport
        locFrm.ShowDialog()
    End Sub

    Private Sub elvEmployees_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles elvEmployees.DoubleClick
        If elvEmployees.SelectedIndices.Count > 0 Then
            Dim locFrm As New frmEmployeeTimeList
            locFrm.ShowDialog(elvEmployees.FirstSelectedEmployee, myCombinedParameters.ProductionDate)
        End If
    End Sub

    Private Sub tsmHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelpAbout.Click
        frmInfo.ShowDialog()
    End Sub

    Private Sub tsmArticleAmountAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmArticleAmountAnalysis.Click
        'TODO: In Berechtigungsmechanismus einbinden
        Dim locfrm As New frmProductionAmountAnalysis
        locfrm.ShowDialog()
    End Sub

    Private Sub AusfallzeitenAnalyseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusfallzeitenAnalyseToolStripMenuItem.Click
        MessageBox.Show("Diese Funktion steht Ihnen nur in der Enterprise Version zur Verfügung!", "Nicht implementiert!")
    End Sub

    Private Sub SupportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupportToolStripMenuItem.Click
        Dim frm As New frmHiddenTestAndAdmin
        frm.ShowDialog()
    End Sub
End Class

Public Class ShiftToolStripButton
    Inherits ToolStripButton

    Private myShiftText As String
    Private myShiftTextFont As Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular)
    Private myEmphasized As Boolean

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal text As String, ByVal image As Image, ByVal ShiftText As String, ByVal Name As String, ByVal onClick As System.EventHandler)
        MyBase.New(text, image, onClick)
        myShiftText = ShiftText
        Me.Name = Name
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim locUsedFont As Font

        MyBase.OnPaint(e)
        Dim locGraphics As Graphics = e.Graphics
        Dim locTextSize As SizeF = locGraphics.MeasureString(myShiftText, myShiftTextFont, Size.Width)
        If Me.Emphasized Then
            locUsedFont = New Font(myShiftTextFont, FontStyle.Bold)
        Else
            locUsedFont = myShiftTextFont
        End If
        locGraphics.DrawString(myShiftText, locUsedFont, Brushes.Black, 10, CSng(Size.Height / 2 - locTextSize.Height / 2))
    End Sub

    Public Property ShiftText() As String
        Get
            Return myShiftText
        End Get
        Set(ByVal value As String)
            myShiftText = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShiftTextFont() As Font
        Get
            Return myShiftTextFont
        End Get
        Set(ByVal value As Font)
            myShiftTextFont = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Emphasized() As Boolean
        Get
            Return myEmphasized
        End Get
        Set(ByVal value As Boolean)
            myEmphasized = value
            If value Then
                Me.Font = New Font(Me.Font, FontStyle.Bold)
            Else
                Me.Font = New Font(Me.Font, FontStyle.Regular)
            End If
            Me.Invalidate()
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class
