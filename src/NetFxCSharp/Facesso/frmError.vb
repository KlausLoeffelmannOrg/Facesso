Public Class frmError

    Public Sub HandleDialog(ByVal ex As Exception)
        Dim locExMessage As String
        locExMessage = ex.Message

        Dim locDetailedMessage As String
        locDetailedMessage = "Exception-Message:" & vbNewLine &
                       "------------------" & vbNewLine &
                       locExMessage & vbNewLine & vbNewLine

        locDetailedMessage &= "Source:" & vbNewLine &
                       "-------" & vbNewLine &
                       ex.Source & vbNewLine & vbNewLine

        If ex.InnerException IsNot Nothing Then
            locDetailedMessage &= "Inner Exception Message:" & vbNewLine &
                            "------------------------" & vbNewLine &
                            ex.InnerException.Message _
                            & vbNewLine & vbNewLine
        End If

        locDetailedMessage &= "Stack-Trace:" & vbNewLine &
                       "-------" & vbNewLine &
                       ex.StackTrace & vbNewLine & vbNewLine

        If Not Environment.UserInteractive Then
            Console.Error.WriteLine(locDetailedMessage)
            Environment.ExitCode = 1
            Return
        End If

        lblExceptionText.Text = locExMessage
        txtExceptionMessage.Text = locDetailedMessage
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
