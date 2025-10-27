Imports System.Windows.Forms

<CLSCompliant(False)> _
Public Class frmLogin

    Dim myLoginInfo As UserInfo

    Public Function Login(ByVal Subsidiaries As SubsidiaryInfoCollection, ByVal PreselectSSID As Integer, ByVal locLoginHistory As LoginHistory) As UserInfo
        Using Me
            Dim locCount As Integer = 0
            Dim locPreselectIndex As Integer = 0
            For Each locSubsidiary As SubsidiaryInfo In Subsidiaries
                If PreselectSSID > 0 Then
                    If locSubsidiary.IDSubsidiary = PreselectSSID Then
                        locPreselectIndex = locCount
                    End If
                End If
                cmbSubsidiary.Items.Add(locSubsidiary)
            Next
            If cmbSubsidiary.Items.Count > 0 Then
                cmbSubsidiary.SelectedIndex = locPreselectIndex
            End If
            For Each locString As String In locLoginHistory
                cmbUsernames.Items.Add(locString)
            Next
            cmbUsernames.Text = locLoginHistory.LastLoginName
            Me.ShowDialog()
            If Me.DialogResult = Windows.Forms.DialogResult.OK Then
                Return myLoginInfo
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        myLoginInfo = New UserInfo(CType(cmbSubsidiary.SelectedItem, SubsidiaryInfo).IDSubsidiary, _
                                   cmbUsernames.Text, txtPassword.Text, _
                                   FacessoGeneric.SQLConnectionString)

        If Not myLoginInfo.Authenticated Then
            MessageBox.Show(myLoginInfo.LoggedInFailedReason, "Fehler bei Login:", _
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Me.Hide()
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" Then
            Me.AcceptButton = Me.btnOK
        Else
            Me.AcceptButton = Nothing
        End If
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.Visible = True
        Application.DoEvents()
        If cmbUsernames.Text = "" Then
            cmbUsernames.Focus()
        Else
            txtPassword.Focus()
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class