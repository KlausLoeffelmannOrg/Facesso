
Public Class frmError

    Sub HandleDialog(ByVal ex As Exception)
        Dim locExMessage As String
        locExMessage = ex.Message
        lblExceptionText.Text = locExMessage

        locExMessage = "Exception-Message:" & vbNewLine & _
                       "------------------" & vbNewLine & _
                       locExMessage & vbNewLine & vbNewLine

        locExMessage &= "Source:" & vbNewLine & _
                       "-------" & vbNewLine & _
                       ex.Source & vbNewLine & vbNewLine


        If ex.InnerException IsNot Nothing Then
            locExMessage &= "Inner Exception Message:" & vbNewLine & _
                            "------------------------" & vbNewLine & _
                            ex.InnerException.Message _
                            & vbNewLine & vbNewLine
        End If

        locExMessage &= "Stack-Trace:" & vbNewLine & _
                       "-------" & vbNewLine & _
                       ex.StackTrace & vbNewLine & vbNewLine
        txtExceptionMessage.Text = locExMessage
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class