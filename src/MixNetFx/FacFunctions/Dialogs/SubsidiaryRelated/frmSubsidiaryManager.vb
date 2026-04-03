Imports Facesso.Data
Imports System.Windows.Forms

Friend Class frmSubsidiaryManager

    Public Sub HandleDialog()
        arvSubsidiaries.List = FacessoGeneric.Subsidiaries
        Me.ShowDialog()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim locFh As GetFrmSubsidiaryInfoAdd = FunctionHandler(Of GetFrmSubsidiaryInfoAdd).GetFunctionInstance
        If locFh Is Nothing Then Return
        Dim locDR As InfoItemMaintenanceDialogResult = locFh.ShowDialog()
        If locDR.DialogResult = Windows.Forms.DialogResult.OK Then
            FacessoGeneric.RebuildSubsidiaries()
            arvSubsidiaries.List = FacessoGeneric.Subsidiaries
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim locFH As GetFrmSubsidiaryInfoEdit = FunctionHandler(Of GetFrmSubsidiaryInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If Me.arvSubsidiaries.SelectedItems Is Nothing OrElse arvSubsidiaries.SelectedItems.Count = 0 Then
            MessageBox.Show(My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Body, _
                            My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim locDR As InfoItemMaintenanceDialogResult = locFH.ShowDialog(DirectCast(Me.arvSubsidiaries.SelectedItems(0).Tag, SubsidiaryInfo))
        If locDR.DialogResult = Windows.Forms.DialogResult.OK Then
            FacessoGeneric.RebuildSubsidiaries()
            arvSubsidiaries.List = FacessoGeneric.Subsidiaries
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.arvSubsidiaries.SelectedItems Is Nothing OrElse arvSubsidiaries.SelectedItems.Count = 0 Then
            MessageBox.Show(My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Body, _
                            My.Resources.SubsidiaryInfoManager_NoSelectedSubsidiary_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If DirectCast(arvSubsidiaries.SelectedItems(0).Tag, SubsidiaryInfo).IDSubsidiary = 1 Then
            MessageBox.Show("Sie können die Haupt-Subsidiarität nicht löschen!", "Löschen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If DirectCast(arvSubsidiaries.SelectedItems(0).Tag, SubsidiaryInfo).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary Then
            MessageBox.Show("Sie können die Subsidiarität nicht löschen, wenn Sie sich unter dieser angemeldet haben!", "Löschen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim locDR As DialogResult = MessageBox.Show("Sind Sie sicher, die ausgewählte Subsidiarität mit ALLEN DATEN LÖSCHEN zu wollen?", _
            "SUBSIDIARITÄT LÖSCHEN?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If locDR = Windows.Forms.DialogResult.Yes Then
            SPAccess.GetInstance.Subsidiaries_Delete(DirectCast(arvSubsidiaries.SelectedItems(0).Tag, SubsidiaryInfo), FacessoGeneric.LoginInfo)
            FacessoGeneric.RebuildSubsidiaries()
            arvSubsidiaries.List = FacessoGeneric.Subsidiaries
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class