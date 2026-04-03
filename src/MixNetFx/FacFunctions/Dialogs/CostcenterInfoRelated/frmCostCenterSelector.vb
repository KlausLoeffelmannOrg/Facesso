Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmCostCenterSelector

    Public Function HandleDialog(ByVal ccic As CostcenterInfoItems) As CostcenterInfo
        Using Me
            lstCostCenter.DataSource = ccic
            lstCostCenter.DisplayMember = "ListItemText"
            Me.ShowDialog()
            If DialogResult = Windows.Forms.DialogResult.OK Then
                Return DirectCast(lstCostCenter.SelectedItem, CostcenterInfo)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If lstCostCenter.SelectedIndex = -1 Then
            MessageBox.Show(My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, _
                            My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, _
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class