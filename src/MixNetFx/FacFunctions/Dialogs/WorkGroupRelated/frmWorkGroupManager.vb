Imports Facesso
Imports Facesso.Data
Imports Facesso.Functions
Imports System.Windows.Forms

Public Class frmWorkGroupManager

    Private myCurrentWorkGroup As WorkGroupInfo
    Private myLabourValueList As LabourValueInfoCollection

    Public Sub HandleDialog()
        Dim locError As String = ""
        If Not SPAccess.GetInstance.Basedata_DoLabourValuesExist Then
            locError = "* Es sind keine REFA-Arbeitswertstammdaten eingerichtet!" & vbNewLine & vbNewLine
        End If

        If locError <> "" Then
            MessageBox.Show("Datenerfassung ist noch nicht möglich:" & vbNewLine & vbNewLine & _
                            locError & vbNewLine & _
                            "Bitte führen Sie zunächst die Stammdaten erfassung durch!", _
            "Datenerfassung nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.ShowDialog()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myLabourValueList = SPAccess.GetInstance.LabourValueInfoCollection()
        BuildLabourValuesForAssignment()
        Me.wglSetup.WorkGroupInfoItems = New WorkGroupInfoItems(True)
        Me.wglSetup.MultiSelect = False
        HandleControlsEnabling()
    End Sub

    Private Sub btnNewWorkGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewWorkGroup.Click, tsmNewWorkgroup.Click, tsbNewWorkgroup.Click
        Dim locFH As GetFrmWorkGroupInfoAdd = FunctionHandler(Of GetFrmWorkGroupInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
        BuildLabourValuesForAssignment()
        Me.wglSetup.WorkGroupInfoItems = New WorkGroupInfoItems(True)
    End Sub

    Private Sub wglSetup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wglSetup.SelectedIndexChanged
        myCurrentWorkGroup = wglSetup.FirstSelectedWorkGroup
        If myCurrentWorkGroup IsNot Nothing Then
            lblSelectedWorkgroup.Text = myCurrentWorkGroup.WorkGroupNumber.ToString & ": " & myCurrentWorkGroup.WorkGroupName
            lvlAssigned.LabourValues = LabourValueInfoCollection.GetWorkGroupAssignedLabourValues( _
                            FacessoGeneric.LoginInfo.IDSubsidiary, _
                            myCurrentWorkGroup)
            BuildLabourValuesForAssignment()
            HandleControlsEnabling()
        Else
            lvlAssigned.LabourValues = Nothing
        End If
    End Sub

    Private Sub lvlToAssign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlToAssign.SelectedIndexChanged
        HandleControlsEnabling()
    End Sub

    Private Sub HandleControlsEnabling()
        If lvlAssigned.SelectedIndices.Count > 0 Then
            btnDeleteFromAssignment.Enabled = True
            tsbUnassignLabourValues.Enabled = True
            tsmUnAssignLabourValues.Enabled = True
        Else
            btnDeleteFromAssignment.Enabled = False
            tsbUnassignLabourValues.Enabled = False
            tsmUnAssignLabourValues.Enabled = False
        End If

        If lvlToAssign.SelectedIndices.Count > 0 Then
            If wglSetup.SelectedIndices.Count > 0 Then
                btnAssignToWorkGroup.Enabled = True
                tsbAssignLabourValues.Enabled = True
                tsmAssignLabourValues.Enabled = True
                Return
            End If
        End If
        btnAssignToWorkGroup.Enabled = False
        tsbAssignLabourValues.Enabled = False
        tsmAssignLabourValues.Enabled = False
    End Sub

    Private Sub btnAssignToWorkGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignToWorkGroup.Click, tsmAssignLabourValues.Click, tsbAssignLabourValues.Click

        If lvlAssigned.LabourValues Is Nothing Then
            lvlAssigned.LabourValues = New LabourValueInfoCollection
        End If

        For Each locSourceItem As LabourValueInfo In lvlToAssign.SelectedLabourValues
            lvlAssigned.LabourValues.Add(locSourceItem)
        Next
        lvlAssigned.LabourValues = lvlAssigned.LabourValues
        BuildLabourValuesForAssignment()
        SPAccess.GetInstance.AssignLabourValuesToWorkGroup(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                           myCurrentWorkGroup.IDWorkGroup, _
                                                           Me.lvlAssigned.LabourValues)
    End Sub

    Sub BuildLabourValuesForAssignment()
        Dim locToAssignList As New LabourValueInfoCollection
        For Each locItem As LabourValueInfo In myLabourValueList
            locToAssignList.Add(locItem)
        Next
        If lvlAssigned.LabourValues IsNot Nothing Then
            For Each locDestItem As LabourValueInfo In lvlAssigned.LabourValues
                locToAssignList.Remove(New ActiveDev.IntKey(locDestItem.IDLabourValue))
            Next
        End If
        lvlToAssign.LabourValues = locToAssignList
        HandleControlsEnabling()
    End Sub

    Private Sub btnDeleteFromAssignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFromAssignment.Click, tsmUnAssignLabourValues.Click, tsbUnassignLabourValues.Click
        For Each locItem As LabourValueInfo In lvlAssigned.SelectedLabourValues
            lvlAssigned.LabourValues.Remove(New ActiveDev.IntKey(locItem.IDLabourValue))
        Next
        lvlAssigned.LabourValues = lvlAssigned.LabourValues
        BuildLabourValuesForAssignment()
        SPAccess.GetInstance.AssignLabourValuesToWorkGroup(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                   myCurrentWorkGroup.IDWorkGroup, _
                                                   Me.lvlAssigned.LabourValues)

    End Sub

    Private Sub lvlAssigned_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlAssigned.SelectedIndexChanged
        HandleControlsEnabling()
    End Sub

    Private Sub OKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOK.Click
        Me.Dispose()
    End Sub

    Private Sub tsmEditWorkgroupData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditWorkgroupData.Click, tsbEditWorkgroup.Click
        Dim locFH As GetFrmWorkGroupInfoEdit = FunctionHandler(Of GetFrmWorkGroupInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog(myCurrentWorkGroup)
        BuildLabourValuesForAssignment()
        Me.wglSetup.WorkGroupInfoItems = New WorkGroupInfoItems(True)
    End Sub

    Private Sub tsmGroupLabourValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmGroupLabourValues.Click
        If tsmGroupLabourValues.Checked Then
            tsmGroupLabourValues.Checked = False
            lvlToAssign.AutoGroup = False
        Else
            tsmGroupLabourValues.Checked = True
            lvlToAssign.AutoGroup = True
        End If
    End Sub

    Private Sub tsmShowQuickStartButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShowQuickStartButtons.Click
        If tsmShowQuickStartButtons.Checked Then
            tsmShowQuickStartButtons.Checked = False
            splitLabourValuesQuickButtons.Panel2Collapsed = True
        Else
            tsmShowQuickStartButtons.Checked = True
            splitLabourValuesQuickButtons.Panel2Collapsed = False
        End If
    End Sub

    Private Sub tsbDeleteWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteWorkgroup.Click
        DeleteWorkGroup()
    End Sub

    Private Sub tsmDeleteWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeleteWorkgroup.Click
        DeleteWorkGroup()
    End Sub

    Private Sub DeleteWorkGroup()
        Dim locWorkGroup As WorkGroupInfo = wglSetup.FirstSelectedWorkGroup
        If locWorkGroup Is Nothing Then
            MessageBox.Show("Bitte wählen Sie zunächst eine Produktiv-Site aus der unteren, linken Liste aus", "Fehlende Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim locFH As GetFuncWorkGroupDelete = FunctionHandler(Of GetFuncWorkGroupDelete).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.DeleteItem(locWorkGroup)
        BuildLabourValuesForAssignment()
        Me.wglSetup.WorkGroupInfoItems = New WorkGroupInfoItems(True)
    End Sub

    Private Sub tsmPrintWorkGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrintWorkGroup.Click, tsbPrintWorkGroupList.Click
        Dim locFrm As New frmWorkGroupPrintBaseData
        locFrm.ShowDialog(False)
    End Sub
End Class