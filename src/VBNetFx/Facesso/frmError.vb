Public Class frmError

    Public Sub HandleDialog(ByVal ex As Exception)
        Dim locExMessage As String
        locExMessage = ex.Message
        lblExceptionText.Text = locExMessage

        locExMessage = "Exception-Message:" & vbNewLine &
                       "------------------" & vbNewLine &
                       locExMessage & vbNewLine & vbNewLine

        locExMessage &= "Source:" & vbNewLine &
                       "-------" & vbNewLine &
                       ex.Source & vbNewLine & vbNewLine


        If ex.InnerException IsNot Nothing Then
            locExMessage &= "Inner Exception Message:" & vbNewLine &
                            "------------------------" & vbNewLine &
                            ex.InnerException.Message _
                            & vbNewLine & vbNewLine
        End If

        locExMessage &= "Stack-Trace:" & vbNewLine &
                       "-------" & vbNewLine &
                       ex.StackTrace & vbNewLine & vbNewLine
        txtExceptionMessage.Text = locExMessage
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
