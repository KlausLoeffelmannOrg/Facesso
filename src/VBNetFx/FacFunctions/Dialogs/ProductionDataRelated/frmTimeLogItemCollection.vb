Imports Activedev
Imports System.Windows.Forms
Imports Facesso.Data

Public Class frmTimeLogItemCollection

    Private myTimeLogItems As EmployeeTimeLogInfo
    Private myTimeLogItem As EmployeeTimeLogInfoItem
    Private myEmployeeInfoCollection As EmployeeInfoItems
    Private myInitialized As Boolean
    Private myCPIs As CombinedParametersInfo

    Public Function GetTimeLogItems(ByVal cp As CombinedParametersInfo, ByVal eic As EmployeeInfoItems) As EmployeeTimeLogInfo
        Using Me
            If eic Is Nothing Then
                Return Nothing
            End If
            myCPIs = cp

            Dim locTsd As TimeSettingDetail = cp.WorkGroup.TimeSettingDetails.GetTimeSettingDetail(cp.ProductionDate, cp.Shift)

            ndbShiftStart.Value = locTsd.ShiftStart
            ndbShiftEnd.Value = locTsd.ShiftEnd
            nibWorkBreak.Value = locTsd.WorkBreak
            myTimeLogItem = New EmployeeTimeLogInfoItem()
            myEmployeeInfoCollection = eic
            myInitialized = True
            UpdateUI()
            Me.Text = "Zeiterfassung für: " & cp.WorkGroup.WorkGroupName & "; " & _
                "Schicht " & cp.Shift & ", " & cp.ProductionDate.ToLongDateString
            Dim locDR As DialogResult = Me.ShowDialog()
            If locDR = Windows.Forms.DialogResult.Cancel Then
                Return Nothing
            End If
            Return myTimeLogItems
        End Using
    End Function

    Public Function EditTimeLogItems(ByVal cp As CombinedParametersInfo, ByVal LogItems As EmployeeTimeLogInfo) As DialogResult
        Using Me
            If LogItems Is Nothing OrElse LogItems.Count = 0 Then
                Return Windows.Forms.DialogResult.Cancel
            End If
            myCPIs = cp

            ndbShiftStart.TypeSafeValue = LogItems(0).ShiftStart
            ndbShiftEnd.TypeSafeValue = LogItems(0).ShiftEnd
            nibWorkBreak.TypeSafeValue = LogItems(0).WorkBreak
            nibDownTime.TypeSafeValue = LogItems(0).DownTime
            ndbHandicap.TypeSafeValue = LogItems(0).Handicap
            myTimeLogItem = New EmployeeTimeLogInfoItem()
            myInitialized = True
            myTimeLogItems = LogItems
            UpdateUI()
            Me.Text = "Zeiterfassung für: " & cp.WorkGroup.WorkGroupName & "; " & _
                "Schicht " & cp.Shift & ", " & cp.ProductionDate.ToLongDateString
            Dim locDR As DialogResult = Me.ShowDialog()
            Return Me.DialogResult
        End Using
    End Function

    Private Function CheckForOverlaps() As Boolean
        Dim locMessage As String = ""
        For Each locEi As EmployeeTimeLogInfoItem In myTimeLogItems
            Dim locExcludeIDTimeLog As ADDBNullable(Of Long)
            If locEi.IDTimeLog > 0 Then
                locExcludeIDTimeLog = locEi.IDTimeLog
            End If
            Dim locOverlapsInfo As New OverlapsInfo(locEi.EmployeeInfo, locEi.ShiftStart, locEi.ShiftEnd, locExcludeIDTimeLog)
            locMessage &= locOverlapsInfo.ToString()
        Next
        If locMessage <> "" Then
            locMessage = "Facesso hat folgende Zeitüberschneidungen festgestellt" & vbNewLine & _
            "weswegen die angegebenen Werte nachgearbeitet werden müssen:" & _
            vbNewLine & vbNewLine & locMessage & vbNewLine & vbNewLine & _
            "Bitte korrigieren Sie die Werte entsprechend!"
            MessageBox.Show(locMessage, _
                             "Übernahme nicht möglich!", _
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Public Sub UpdateUI()

        If nibDownTime.Value.IsNull Then nibDownTime.TypeSafeValue = 0
        If ndbHandicap.Value.IsNull Then ndbHandicap.TypeSafeValue = 0
        If nibWorkBreak.Value.IsNull Then nibWorkBreak.TypeSafeValue = 0

        If ndbShiftStart.Value.IsNull Or ndbShiftEnd.Value.IsNull Then
            ndbShiftStart.Value = Nothing
            ndbShiftEnd.Value = Nothing
            lblShiftStartDate.Text = myCPIs.ProductionDate.ToShortDateString
            lblShiftEndDate.Text = btnShiftStart.Text
            lblMinutesAttendance.Text = "- - -"
            lblMinutesEffective.Text = "- - -"
            lblMinutesEffectiveAdj.Text = "- - -"
            btnShiftStart.Text = "Dieser &Tag"
            btnShiftEnd.Text = "Dieser Ta&g"
            Return
        End If

        myTimeLogItem.SetShiftTimes(ndbShiftStart.TypeSafeValue, ndbShiftEnd.TypeSafeValue, myCPIs.ProductionDate)
        myTimeLogItem.WorkBreak = nibWorkBreak.TypeSafeValue
        myTimeLogItem.DownTime = nibDownTime.TypeSafeValue
        myTimeLogItem.Handicap = ndbHandicap.TypeSafeValue

        ndbShiftStart.TypeSafeValue = myTimeLogItem.ShiftStart
        ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd

        lblShiftStartDate.Text = myTimeLogItem.ShiftStart.ToShortDateString
        lblShiftEndDate.Text = myTimeLogItem.ShiftEnd.ToShortDateString
        lblMinutesAttendance.Text = myTimeLogItem.AttendanceTime.ToString
        lblMinutesEffective.Text = myTimeLogItem.IncentiveWageTime.ToString
        lblMinutesEffectiveAdj.Text = myTimeLogItem.IncentiveWageTimeAdj.ToString
        lblMinutesWorkingTime.Text = myTimeLogItem.WorkingTime.ToString

        If myTimeLogItem.ProductionDate = myTimeLogItem.ShiftStart.Date Then
            btnShiftStart.Text = "Dieser &Tag"
        Else
            btnShiftStart.Text = "Folge&tag"
        End If

        If myTimeLogItem.ProductionDate = myTimeLogItem.ShiftEnd.Date Then
            btnShiftEnd.Text = "Dieser Ta&g"
        Else
            btnShiftEnd.Text = "Folgeta&g"
        End If
    End Sub

    'Falls die Events verschwinden!
    'Handles ndbShiftStart.Validated, ndbShiftEnd.Validated, nibDownTime.Validated, _
    '        nibHandicap.Validated, nibWorkBreak.Validated
    Private Sub GenericValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles ndbShiftStart.Validated, ndbShiftEnd.Validated, nibDownTime.Validated, _
                     nibWorkBreak.Validated, ndbHandicap.Validated

        If ndbShiftStart.Value.IsNull And ndbShiftEnd.Value.IsNull Then
            Return
        End If

        If ndbShiftStart.Value.HasValue And ndbShiftEnd.Value.IsNull Then
            ndbShiftEnd.Value = ndbShiftStart.Value
        End If

        If ndbShiftEnd.Value.HasValue And ndbShiftStart.Value.IsNull Then
            ndbShiftStart.Value = ndbShiftEnd.Value
        End If

        If ndbShiftEnd.TypeSafeValue < ndbShiftStart.TypeSafeValue Then
            If sender Is ndbShiftEnd Then
                If ndbShiftEnd.TypeSafeValue < ndbShiftStart.TypeSafeValue And _
                    ndbShiftStart.TypeSafeValue.TypedValue.Date = myCPIs.ProductionDate Then
                    ndbShiftEnd.TypeSafeValue = ndbShiftEnd.TypeSafeValue.TypedValue.AddDays(1)
                End If
            End If

            If sender Is ndbShiftStart Then
                If ndbShiftStart.TypeSafeValue > ndbShiftEnd.TypeSafeValue And _
                    ndbShiftEnd.TypeSafeValue.TypedValue.Date = myCPIs.ProductionDate.AddDays(1) Then
                    ndbShiftStart.TypeSafeValue = ndbShiftStart.TypeSafeValue.TypedValue.Subtract(New TimeSpan(1, 0, 0, 0))
                End If
            End If
        End If
        UpdateUI()
    End Sub

    Private Sub btnShiftStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftStart.Click
        If myTimeLogItem.ShiftStart.Date > myCPIs.ProductionDate.Date Then
            myTimeLogItem.ShiftStart = myCPIs.ProductionDate.Date + myTimeLogItem.ShiftStart.TimeOfDay
            myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.Date + myTimeLogItem.ShiftEnd.TimeOfDay
        Else
            myTimeLogItem.ShiftStart = myCPIs.ProductionDate.Date.AddDays(1) + myTimeLogItem.ShiftStart.TimeOfDay
            myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.Date.AddDays(1) + myTimeLogItem.ShiftEnd.TimeOfDay
        End If
        ndbShiftStart.TypeSafeValue = myTimeLogItem.ShiftStart
        ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd
        UpdateUI()
    End Sub

    Private Sub btnShiftEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftEnd.Click
        If myTimeLogItem.ShiftEnd.Date > myCPIs.ProductionDate.Date Then
            myTimeLogItem.ShiftEnd = myCPIs.ProductionDate + myTimeLogItem.ShiftEnd.TimeOfDay
        Else
            myTimeLogItem.ShiftEnd = myCPIs.ProductionDate.AddDays(1) + myTimeLogItem.ShiftEnd.TimeOfDay
        End If
        ndbShiftEnd.TypeSafeValue = myTimeLogItem.ShiftEnd
        UpdateUI()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If myEmployeeInfoCollection IsNot Nothing Then
            myTimeLogItems = New EmployeeTimeLogInfo()
            For Each locEi As EmployeeInfo In myEmployeeInfoCollection
                Dim locTimeLogItem As New EmployeeTimeLogInfoItem
                locTimeLogItem = myTimeLogItem.Clone()
                locTimeLogItem.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser
                locTimeLogItem.EmployeeInfo = locEi
                locTimeLogItem.IDWorkGroup = myCPIs.WorkGroup.IDWorkGroup
                locTimeLogItem.InsertedByInterface = False
                locTimeLogItem.ManuallyEdited = True
                locTimeLogItem.Shift = myCPIs.Shift
                myTimeLogItems.Add(locTimeLogItem)
            Next
        Else
            For Each locLogItem As EmployeeTimeLogInfoItem In myTimeLogItems
                locLogItem.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser
                locLogItem.ShiftStart = myTimeLogItem.ShiftStart
                locLogItem.ShiftEnd = myTimeLogItem.ShiftEnd
                locLogItem.WorkBreak = myTimeLogItem.WorkBreak
                locLogItem.DownTime = myTimeLogItem.DownTime
                locLogItem.Handicap = myTimeLogItem.Handicap
                locLogItem.ManuallyEdited = True
            Next
        End If
        If CheckForOverlaps() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class