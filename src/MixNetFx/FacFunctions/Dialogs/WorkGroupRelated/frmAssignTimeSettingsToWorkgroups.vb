Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmAssignTimeSettingsToWorkgroups

    Private myTimeSettings As TimeSettingDetails

    Public Sub AssignToSelected(ByVal timeSettings As TimeSettingDetails)
        myTimeSettings = timeSettings
        wglWorkGroups.WorkGroupInfoItems = New WorkGroupInfoItems(True)
        Me.ShowDialog()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        For Each locWorkGroup As WorkGroupInfo In wglWorkGroups.SelectedWorkGroups
            locWorkGroup.TimeSettingDetails = myTimeSettings
            SPAccess.GetInstance.WorkGroups_Edit(locWorkGroup, FacessoGeneric.LoginInfo.IDUser)
        Next
        MessageBox.Show("Die Produktiv-Site-Rahmenzeiten wurden geändert!", "Erfolgreich:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class