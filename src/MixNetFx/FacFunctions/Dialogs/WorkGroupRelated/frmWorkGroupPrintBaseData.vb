Imports Facesso.Data

Public Class frmWorkGroupPrintBaseData

    Public Overloads Sub ShowDialog(ByVal PrintOnlyListOfLabourValue As Boolean)
        If PrintOnlyListOfLabourValue Then
            optOnlyPrintWorkgroups.Checked = True
            SetCheckBoxes(False)
        Else
            optPrintWorkgroups.Checked = True
            chkPrintAssignedLabourValues.Checked = True
            SetCheckBoxes(True)
        End If
        Me.ShowDialog()
    End Sub

    Private Sub SetCheckBoxes(ByVal state As Boolean)
        chkPrintAssignedLabourValues.Enabled = state
        chkPrintShiftTimes.Enabled = state
        chkVisualieProductivityHistory.Enabled = state
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim locParameters As New WorkgroupBaseDataPrintParameters
        With locParameters
            If optOnlyPrintWorkgroups.Checked Then
                .OnlyPrintListOfLabourValues = True
            Else
                .PrintWorkgroups = True
                .PrintAssignedLabourValues = chkPrintAssignedLabourValues.Checked
                .PrintShiftTimes = chkPrintShiftTimes.Checked
                If Not chkVisualieProductivityHistory.Checked Then
                    .VisualizeProductivityHistory = -1
                Else
                    .VisualizeProductivityHistory = CInt(nudMonths.Value)
                End If
            End If
        End With

        Dim locPrintEngine As New FacPrintWorkgroupBaseData(locParameters, _
                                FacessoGeneric.LoginInfo.Username)

        locPrintEngine.ProcessDocument(Data.AnalysisTarget.PreviewBeforePrint)
        Me.Close()
    End Sub
End Class