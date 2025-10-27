Imports Facesso
Imports Facesso.Data

Partial Class frmFacessoShell

    Private myCombinedParameters As CombinedParametersInfo
    Private myOldIDWorkGroup As Integer
    Private myCurrentEmpGroupname As String

    Private Sub UpdateCombinedParameters(ByVal DontUpdateWorkGroup As Boolean)

        If wglWorkGroups.WorkGroupInfoItems IsNot Nothing Then
            myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup
        Else
            myCombinedParameters.WorkGroup = Nothing
        End If

        If elvEmployees.EmployeeInfoCollection IsNot Nothing Then
            myCombinedParameters.EmployeeInfo = elvEmployees.FirstSelectedEmployee
        Else
            myCombinedParameters.EmployeeInfo = Nothing
        End If

        myCombinedParameters.ProductionDate = myTsmCalender.MonthCalendarControl.SelectionStart
        UpdateUI(DontUpdateWorkGroup)

    End Sub

    Private Sub UpdateUI(ByVal DontUpdateWorkgroup As Boolean)
        lblCurrentDate.Text = myCombinedParameters.ProductionDate.ToString("ddd, dd. MMM yyyy")
        If myCombinedParameters.Shift = 4 Then
            lblCurrentShift.Text = "Sonderschicht " & myCombinedParameters.ShiftText
        Else
            lblCurrentShift.Text = "S" & myCombinedParameters.Shift & ": " & myCombinedParameters.ShiftText
        End If
        If myCombinedParameters.WorkGroup Is Nothing Then
            lblCurrentWorkgroup.Text = "- keine Site ausgewählt -"
        Else
            lblCurrentWorkgroup.Text = myCombinedParameters.WorkGroup.ListItemText
        End If
        For z As Integer = 0 To 3
            myTsShiftButtons(z).Text = myCombinedParameters.ShiftText(CByte(z + 1))
            If myCombinedParameters.Shift = (z + 1) Then
                myTsShiftButtons(z).Emphasized = True
            Else
                myTsShiftButtons(z).Emphasized = False
            End If
        Next

        If Not DontUpdateWorkgroup Then
            RebuildWorkGroup()
            'ResetWorkedEmployees()
        End If
        If myCombinedParameters.WorkGroup IsNot Nothing Then
            Dim locwgr As New WorkGroupAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                        myCombinedParameters)
            dgvWorkGroupResults.Object = locwgr
        Else
            dgvWorkGroupResults.Object = Nothing
        End If
    End Sub

    Private Sub RebuildWorkGroup()
        myWorkGroups = New WorkGroupInfoItems(myCombinedParameters)
        wglWorkGroups.WorkGroupInfoItems = myWorkGroups
        If elvEmployees.EmployeeInfoCollection Is Nothing Then
            elvEmployees.EmployeeInfoCollection = myEmployees
        End If
        If myWorkGroups IsNot Nothing Then
            If myWorkGroups.Count > 0 Then
                wglWorkGroups.Items(0).Selected = True
            End If
        End If
    End Sub

    Private Sub wglWorkGroups_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As ListViewItemSelectionChangedEventArgs) Handles wglWorkGroups.ItemSelectionChanged
        If e.IsSelected = True Then
            myCombinedParameters.WorkGroup = wglWorkGroups.FirstSelectedWorkGroup
            UpdateCombinedParameters(True)
            ResetWorkedEmployees()
        End If
    End Sub

    Private Sub ResetWorkedEmployees()
        If myCombinedParameters.WorkGroup IsNot Nothing Then
            If myCombinedParameters.WorkGroup.HasProductionData Then
                elvEmployees.DeleteCustomGroup(myCurrentEmpGroupname, False)
                Dim locSiteEmployees As New EmployeeInfoItems(myCombinedParameters)
                If locSiteEmployees.Count > 0 Then
                    myCurrentEmpGroupname = "Beteiligte Mitarbeiter in Site: " _
                                & myCombinedParameters.WorkGroup.WorkGroupName
                    elvEmployees.SetCustomGroup(myCurrentEmpGroupname, _
                                locSiteEmployees)
                    Return
                End If
            Else
                elvEmployees.DeleteCustomGroup(myCurrentEmpGroupname, True)
            End If
        End If
    End Sub
End Class

