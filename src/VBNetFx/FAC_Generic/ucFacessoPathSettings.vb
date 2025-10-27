Imports System.Windows.Forms

Public Class ucFacessoPathSettings

    Public Property InstallationFolder() As String
        Get
            Return txtInstallationDirectory.Text
        End Get
        Set(ByVal value As String)
            txtInstallationDirectory.Text = value
        End Set
    End Property

    Public Property UpdateFolder() As String
        Get
            Return txtUpdateDirectory.Text
        End Get
        Set(ByVal value As String)
            txtUpdateDirectory.Text = value
        End Set
    End Property

    Public Property UpdateUrl() As String
        Get
            Return txtUpdateUrl.Text
        End Get
        Set(ByVal value As String)
            txtUpdateUrl.Text = value
        End Set
    End Property

    Public Property SharedFolder() As String
        Get
            Return txtSharedFolder.Text
        End Get
        Set(ByVal value As String)
            txtSharedFolder.Text = value
        End Set
    End Property

    Public Function GetPath(ByVal DialogTitel As String) As String
        Dim locFB As New FolderBrowserDialog
        locFB.Description = DialogTitel
        Dim locDR As DialogResult = locFB.ShowDialog
        If locDR = Windows.Forms.DialogResult.OK Then
            Return locFB.SelectedPath
        Else
            Dim locDr2 As DialogResult = MessageBox.Show("Soll der Pfad zurückgesetzt werden?", _
                 "Pfad zurücksetzen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If locDr2 = DialogResult.Yes Then
                Return ""
            End If
            Return Nothing
        End If
    End Function

    Private Sub btnChooseUpdateDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseUpdateDirectory.Click
        Dim locPath As String = GetPath("Wählen Sie das Verzeichnis, in dem Facesso-Updates zentral abgelegt werden sollen.")
        If locPath Is Nothing Then
            Return
        End If
        txtUpdateDirectory.Text = locPath
    End Sub

    Private Sub btnChooseSharedFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseSharedFolder.Click
        Dim locPath As String = GetPath("Wählen Sie das Verzeichnis, in dem verteilte Daten wie beispielsweise Schnittstellen-Definitionen abgelegt werden sollen.")
        If locPath Is Nothing Then
            Return
        End If
        txtSharedFolder.Text = locPath
    End Sub
End Class

