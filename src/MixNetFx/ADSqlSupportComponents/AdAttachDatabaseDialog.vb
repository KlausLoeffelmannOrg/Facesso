Imports System.Data.SqlClient

Public Class ADAttachDatabaseDialog

    Dim myConnectionString As String
    Dim myCurrentlySelectedFile As String

    Public Function GetSqlDatabaseFile() As String
        Me.ShowDialog()
        Return myCurrentlySelectedFile
    End Function

    Public Function GetSqlDatabaseFile(ByVal ConnectionString As String) As String
        DBDirectoryPicker.Location = New Point(DBDirectoryPicker.Location.X, txtConnectionString.Location.Y)
        txtConnectionString.Text = ConnectionString
        DBDirectoryPicker.ConnectionString = ConnectionString
        Me.ShowDialog()
        Return myCurrentlySelectedFile
    End Function

    Private Sub btnGetConnectionString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetConnectionString.Click
        Dim locfrm As New ADSqlInstanceConnectionDialog
        Dim locConnBuilder As SqlConnectionStringBuilder
        locConnBuilder = locfrm.GetConnectionBuilder()
        If locConnBuilder IsNot Nothing Then
            myConnectionString = locConnBuilder.ToString
            txtConnectionString.Text = myConnectionString
            DBDirectoryPicker.ConnectionString = txtConnectionString.Text
        End If
    End Sub

    Private Sub ADAttachDatabaseDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(txtConnectionString.Text) Then
            'Versuchen, eine Verbindung zur Datenbank herzustellen,
            'und das Rootverzeichnis darzustellen.
            DBDirectoryPicker.ConnectionString = txtConnectionString.Text
        End If
    End Sub

    Private Sub DBDirectoryPicker_SelectedFileNodeChanged(ByVal sender As Object, ByVal e As ADFileTreeViewEventArgs) Handles DBDirectoryPicker.SelectedFileNodeChanged
        If e.FileItemType = ADFileItemType.File Then
            btnOK.Enabled = True
            myCurrentlySelectedFile = e.Node.FullPath
        Else
            btnOK.Enabled = False
            myCurrentlySelectedFile = Nothing
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myCurrentlySelectedFile = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class