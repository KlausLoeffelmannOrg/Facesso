Public Class ADSqlDirectoryPickerDialog

    Private mySqlPathFilename As String

    Public Overloads Function ShowDialog(ByVal ServerConnection As String, ByVal ExtensionFilter As String) As DialogResult

        With DirectoryPicker
            .BeginUpdate()
            .ConnectionString = ServerConnection
            .ExtensionFilter = ExtensionFilter
            .EndUpdate()
        End With
        Return Me.ShowDialog()
    End Function

    Public Overloads Function ShowDialog(ByVal ServerConnection As String) As DialogResult

        With DirectoryPicker
            .BeginUpdate()
            .ConnectionString = ServerConnection
            .ExtensionFilter = Nothing
            .EndUpdate()
        End With
        Return Me.ShowDialog()
    End Function

    Private Sub DirectoryPicker_SelectedFileNodeChanged(ByVal sender As Object, ByVal e As ADFileTreeViewEventArgs) Handles DirectoryPicker.SelectedFileNodeChanged
        txtPath.Text = e.Node.FullPath
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        mySqlPathFilename = txtPath.Text
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        mySqlPathFilename = Nothing
    End Sub

    Public Property SqlPathFilename() As String
        Get
            Return mySqlPathFilename
        End Get
        Set(ByVal value As String)
            mySqlPathFilename = value
        End Set
    End Property
End Class