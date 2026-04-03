Imports Facesso
Imports Facesso.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmProductionDataCollector

    Private WithEvents mySdwResult As ShiftDateWorkResultInfo
    Private myDoNothing As Boolean
    Private myFacessoGeneralOptions As FacessoGeneralOptions

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Location = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerWindowLocation", Me.Location), Point)
        Me.Size = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerWindowSize", Me.Size), Size)
        Me.splitProductionData_Employees.SplitterDistance = CInt(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerSplitterDistance", Me.splitProductionData_Employees.SplitterDistance))
        Me.tsmOnlyShowActiveLabourValues.Checked = CBool(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoDataManagerOnlyShowActiveLabourValues", Me.tsmOnlyShowActiveLabourValues.Checked))
        myFacessoGeneralOptions = DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)
        dgvProductionData.OnlyShowActivatedLabourValues = Me.tsmOnlyShowActiveLabourValues.Checked
    End Sub

    Sub HandleDialog(ByVal CombinedParameters As CombinedParametersInfo)
        Dim locError As String = ""
        If Not SPAccess.GetInstance.Basedata_DoEmployeesExist Then
            locError = "* Es sind keine Mitarbeiterstammdaten eingerichtet!" & vbNewLine & vbNewLine
        End If

        If Not SPAccess.GetInstance.Basedata_DoWorkgroupsExist Then
            locError &= "* Es sind keine Produktiv-Sites eingerichtet!" & vbNewLine & vbNewLine
        End If
        If locError <> "" Then
            MessageBox.Show("Datenerfassung ist noch nicht möglich:" & vbNewLine & vbNewLine & _
                            locError & vbNewLine & _
                            "Bitte führen Sie zunächst die Stammdaten erfassung durch!", _
            "Datenerfassung nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SwitchParameters(CombinedParameters.WorkGroup, CombinedParameters.ProductionDate, CombinedParameters.Shift, True)
        Me.ShowDialog()
    End Sub

    Private Sub tsbShift1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShift1.Click, tsmShift1.Click
        SaveChanges(False)
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         1, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub tsbShift2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShift2.Click, tsmShift2.Click
        SaveChanges(False)
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         2, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub tsbShift3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShift3.Click, tsmShift3.Click
        SaveChanges(False)
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         3, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub tsbShift4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShift4.Click, tsmShift4.Click
        SaveChanges(False)
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         4, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub tscWorkGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscWorkGroup.SelectedIndexChanged
        If myDoNothing Then Return
        SaveChanges(False)
        SwitchParameters(DirectCast(tscWorkGroup.Items(tscWorkGroup.SelectedIndex), WorkGroupInfo), _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         mySdwResult.CombinedParameters.Shift, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub dtpProductionDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpProductionDate.ValueChanged
        If myDoNothing Then Return
        SaveChanges(False)
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         dtpProductionDate.Value, _
                         mySdwResult.CombinedParameters.Shift, False)
        dgvProductionData.Focus()
    End Sub

    Private Sub tsmEmployeeTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEmployeeTime.Click, tsbNewEmployeeTimes.Click

        Try
            dgvProductionData.EndEdit()
        Catch ex As Exception
            MessageBox.Show("Bitte überprüfen Sie Ihre Eingabe, da die Formelauswertung einen Syntax-Fehler generierte!", _
                            "Eingabefehler:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        'Erst die Mitarbeiter auswählen
        Dim locEmployees As EmployeeInfoItems
        locEmployees = New frmEmployeePicker().GetEmployeeSelection
        If locEmployees IsNot Nothing Then
            'Jetzt Mitarbeiterzeiten erfassen
            Dim locFormTimeItems As New frmTimeLogItemCollection
            Dim locTimeLogItems As EmployeeTimeLogInfo = locFormTimeItems.GetTimeLogItems(mySdwResult.CombinedParameters, locEmployees)
            'Prüfen, ob Abbruch oder OK
            If locTimeLogItems IsNot Nothing Then
                'Und die neuen Zeiten der Mitarbeiter entweder einrichten,...
                If mySdwResult.EmployeeTimeLogItems Is Nothing Then
                    mySdwResult.EmployeeTimeLogItems = New EmployeeTimeLogInfo(mySdwResult.CombinedParameters, _
                                                        locTimeLogItems)
                Else
                    'oder zu den vorhandenen dazufügen
                    mySdwResult.EmployeeTimeLogItems.AddRange(locTimeLogItems)
                End If
                'Zeitentabelle aktualisieren
                SaveChanges(True, True)
            End If
        End If
    End Sub

    Private Sub UpdateUI()
        With mySdwResult.CombinedParameters.WorkGroup
            lblDegreeOfTime.Text = .IncentiveIndicatorSynonym & " (ang.): " & mySdwResult.DegreeOfTimeAdj.ToString(.IncentiveFormatString)
        End With
        lblMinutesEffective.Text = "Min. Effektiv: " & mySdwResult.TotalEffectiveIWT.ToString
        lblMinutesEffectiveAdj.Text = "Min. (ang.) Effektiv: " & mySdwResult.TotalEffectiveIWTAdj.ToString
        lblMinutesReference.Text = "Min. Referenz: " & mySdwResult.TotalReferenceIWT.ToString
        lblShift.Text = "Schicht " & mySdwResult.CombinedParameters.ShiftText(True)
        lblWorkgroup.Text = "Produktiv-Site: " & mySdwResult.CombinedParameters.WorkGroup.ListItemText
    End Sub

    Private Sub RebuildWorkgroupCombo()
        Dim locWorkGroups As New WorkGroupInfoItems(mySdwResult.CombinedParameters)
        Dim locCount As Integer = -1
        Dim locIndex As Integer = -1
        With tscWorkGroup
            .Items.Clear()
            For Each locItem As WorkGroupInfo In locWorkGroups
                If locItem.IsActive Then
                    locCount += 1
                    .Items.Add(locItem)
                    If locItem.IDWorkGroup = mySdwResult.CombinedParameters.WorkGroup.IDWorkGroup Then
                        locIndex = locCount
                    End If
                End If
            Next
        End With
        If locIndex > -1 Then
            tscWorkGroup.SelectedIndex = locIndex
        End If
    End Sub

    Private Sub EditTimeLogItems(ByVal tli As EmployeeTimeLogInfo)
        Dim locFormTimeItems As New frmTimeLogItemCollection
        Dim locDR As DialogResult = locFormTimeItems.EditTimeLogItems(mySdwResult.CombinedParameters, tli)
        If locDR = Windows.Forms.DialogResult.Abort Then Exit Sub
        For Each locItem As EmployeeTimeLogInfoItem In tli
            dgvTimeLogItems.EmployeeTimeLogItems.SetItem(locItem.IDTimeLog, locItem)
        Next
        SaveChanges(True, True)
    End Sub

    Private Sub mySdwResult_CombinedSavingStateChanged(ByVal sender As Object, ByVal e As Data.CombinedSavingStateChangedEventArgs) Handles mySdwResult.CombinedSavingStateChanged
        If e.ForProductionDataSavingState Then
            tslSaveState.Text = "Mengenänderungen wurden vorgenommen"
        Else
            tslSaveState.Text = "Es wurden keine Mengenänderungen vorgenommen."
        End If
    End Sub

    Private Sub mySdwResult_ResultsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mySdwResult.ResultsChanged
        UpdateUI()
    End Sub

    Private Sub mainTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainTimer.Tick
        tslCurrentDateInfo.Text = "Heute: " & DateTime.Now().ToLongDateString & "   -   " & DateTime.Now().ToLongTimeString
    End Sub

    Private Sub tsmSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSaveChanges.Click
        mySdwResult.SaveToDatabase()
    End Sub

    Private Sub dgvTimeLogItems_TimeLogItemDoubleClick(ByVal sender As System.Object, ByVal e As Facesso.FrontEnd.TimeLogItemClickEventArgs) Handles dgvTimeLogItems.TimeLogItemDoubleClick
        Dim locTlis As New EmployeeTimeLogInfo()
        locTlis.Add(e.EmployeeTimeLogItem)
        EditTimeLogItems(locTlis)
        dgvTimeLogItems.SelectEmployeeItems(locTlis)
    End Sub

    Private Sub SwitchParameters(ByVal wgi As WorkGroupInfo, ByVal ProductionDate As Date, ByVal Shift As Byte, ByVal DontSave As Boolean)
        If Not DontSave Then
            SaveChanges(False)
        End If
        Dim locCP As New CombinedParametersInfo(wgi, ProductionDate, Shift)
        mySdwResult = New ShiftDateWorkResultInfo(locCP)
        dgvTimeLogItems.EmployeeTimeLogItems = mySdwResult.EmployeeTimeLogItems
        dgvProductionData.ProductionData = mySdwResult.ProductionData
        myDoNothing = True
        RebuildWorkgroupCombo()
        dtpProductionDate.Value = ProductionDate
        myDoNothing = False
        UpdateUI()
    End Sub

    Private Sub SaveChanges(ByVal Rebuild As Boolean)
        SaveChanges(rebuild, False)
    End Sub

    Private Sub SaveChanges(ByVal Rebuild As Boolean, ByVal SaveInAnycase As Boolean)
        Try
            If SaveInAnycase Then
                mySdwResult.SaveToDatabase()
            Else
                If mySdwResult.CombinedSavingState.ForProductionDataSavingState Then
                    mySdwResult.SaveToDatabase()
                End If
            End If
        Catch ex As SqlClient.SqlException
            If ex.Message.Contains("IDBonusLists") Then
                MessageBox.Show("Die zuletzt eingegebenen Mitarbeiter konnten nicht hinzugefügt werden, da keine " & vbNewLine & _
                                "über die Kostenstelle zugewiesene individuelle Bonus-Tabelle existiert." & vbNewLine & vbNewLine & _
                                "Bitte legen Sie entweder eine Bonus-Tabelle für die dem Mitarbeiter zugewiesene" & vbNewLine & _
                                "Kostenstelle an, oder weisen Sie dem Mitarbeiter wieder die Systemkostenstelle zu!" & vbNewLine & vbNewLine & _
                                "Die zuletzt eingegebenen Mitarbeiter werden verworfen.", "Zeitenzuweisung konnte nicht ausgeführt werden!", _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End Try

        If Rebuild Then
            dgvTimeLogItems.EmployeeTimeLogItems = mySdwResult.EmployeeTimeLogItems
            dgvProductionData.ProductionData = mySdwResult.ProductionData
        End If
    End Sub

    Private Sub tsmDeleteTimeEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeleteTimeEntries.Click
        Dim locString As String = ""
        locString = "Sind Sie sicher, dass Sie die Zeiten der markierten Mitarbeiter" & vbNewLine & vbNewLine
        For Each locItem As EmployeeTimeLogInfoItem In dgvTimeLogItems.SelectedEmployeeTimeLogItems
            locString &= locItem.ToString + vbNewLine
        Next
        locString &= vbNewLine & vbNewLine & "entfernen wollen?"
        Dim locDR As DialogResult = MessageBox.Show(locString, "Markierte Mitarbeiterzeiten entfernen", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If locDR = Windows.Forms.DialogResult.Yes Then
            For Each locItem As EmployeeTimeLogInfoItem In dgvTimeLogItems.SelectedEmployeeTimeLogItems
                'mySdwResult.EmployeeTimeLogItems.DeleteFromDatabase(locItem)
                mySdwResult.EmployeeTimeLogItems.Remove(locItem.IDTimeLog)
            Next
            SaveChanges(True, True)
        End If
    End Sub

    Private Sub tssbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tssbPrint.Click
        Dim locPrint As New FacPrintWorkGroupShiftDate(mySdwResult, FacessoGeneric.LoginInfo.Username)
        locPrint.ProcessDocument(AnalysisTarget.PreviewBeforePrint)
    End Sub

    Private Sub frmProductionDataCollector_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        SaveChanges(False)
        FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerWindowLocation", Me.Location)
        FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerWindowSize", Me.Size)
        FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerSplitterDistance", Me.splitProductionData_Employees.SplitterDistance)
        FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoDataManagerOnlyShowActiveLabourValues", Me.tsmOnlyShowActiveLabourValues.Checked)
    End Sub

    Private Sub DialogbeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DialogbeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub tsbNextWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNextWorkgroup.Click, tsmNextWorkgroup.Click
        Try
            tscWorkGroup.SelectedIndex = tscWorkGroup.SelectedIndex + 1
        Catch ex As Exception
            tscWorkGroup.SelectedIndex = 0
            dtpProductionDate.Value = ActiveDev.Dates.NextWorkday(dtpProductionDate.Value, _
            myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday)
        End Try
    End Sub

    Private Sub tsbPreviousWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreviousWorkgroup.Click, tsmPrevWorkgroup.Click
        If tscWorkGroup.SelectedIndex > 0 Then
            tscWorkGroup.SelectedIndex = tscWorkGroup.SelectedIndex - 1
        Else
            tscWorkGroup.SelectedIndex = tscWorkGroup.Items.Count - 1
            dtpProductionDate.Value = ActiveDev.Dates.PreviousWorkday(dtpProductionDate.Value, _
            myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday)
        End If
    End Sub

    Private Sub tsbNextWorkDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNextWorkDay.Click, tsmNextWorkDay.Click
        dtpProductionDate.Value = ActiveDev.Dates.NextWorkday(dtpProductionDate.Value, _
            myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday)
    End Sub

    Private Sub tsbPreviousWorkday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreviousWorkday.Click, tsmPrevWorkday.Click
        dtpProductionDate.Value = ActiveDev.Dates.PreviousWorkday(dtpProductionDate.Value, _
        myFacessoGeneralOptions.SaturdayIsWorkday, myFacessoGeneralOptions.SundayIsWorkday)
    End Sub

    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBack.Click
        Me.Close()
    End Sub

    Private Sub tsbMyTodoList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMyTodoList.Click, tsmMyTodoList.Click
        MessageBox.Show("Diese Funktion steht nur in der Enterprise-Edition zur Verfügung", _
                "Funktion nicht verfügbar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub tsmOnlyShowActiveLabourValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOnlyShowActiveLabourValues.Click
        tsmOnlyShowActiveLabourValues.Checked = Not tsmOnlyShowActiveLabourValues.Checked
        dgvProductionData.OnlyShowActivatedLabourValues = tsmOnlyShowActiveLabourValues.Checked
    End Sub

    Private Sub tsmDeleteShiftData_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeleteShiftData.ButtonClick
        Dim locDr As DialogResult = MessageBox.Show("Sind Sie sicher, dass Sie die Produktionsdaten" & vbNewLine & _
                    "der aktuellen Schicht löschen wollen?", "Produktionsdaten löschen?", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If locDr = Windows.Forms.DialogResult.Yes Then
            mySdwResult.DeleteProductionDataItems()
        End If
        SwitchParameters(mySdwResult.CombinedParameters.WorkGroup, _
                         mySdwResult.CombinedParameters.ProductionDate, _
                         mySdwResult.CombinedParameters.Shift, True)
    End Sub
End Class
