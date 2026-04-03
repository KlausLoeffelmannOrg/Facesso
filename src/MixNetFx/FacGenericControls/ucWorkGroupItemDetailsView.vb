Imports ActiveDev
Imports Facesso.Data
Imports System.Windows.Forms

Public Class ucWorkGroupItemDetailsView
    Inherits ucObjectContentDataGridView(Of WorkGroupAnalysisInfoItem)

    Protected Overrides Sub AssignValues()
        If [Object].HasData Then
            Me.Rows.Add(New Object() {"Referenzzeit", [Object].TotalReferenceIWT})
            Me.Rows.Add(New Object() {"Effektivzeit", [Object].TotalEffectiveIWT})
            Me.Rows.Add(New Object() {"Ang. Effektivzeit", [Object].TotalEffectiveIWTAdj})
            Me.Rows.Add(New Object() {"Gesamt-Pausenzeit", [Object].TotalWorkBreakTime})
            Me.Rows.Add(New Object() {"Gesamt-Ausfallzeit", [Object].TotalDownTime})
            Me.Rows.Add(New Object() {[Object].WorkGroup.IncentiveIndicatorSynonym, [Object].DegreeOfTime.ToString([Object].WorkGroup.IncentiveFormatString)})
            Me.Rows.Add(New Object() {"Ang. " & [Object].WorkGroup.IncentiveIndicatorSynonym, [Object].DegreeOfTimeAdj.ToString([Object].WorkGroup.IncentiveFormatString)})
            Me.Rows.Add(New Object() {"Ist ausgesetzt", IIf([Object].IsSuspended, "Ja", "Nein").ToString})
        Else
            Me.Rows.Add(New Object() {"Referenzzeit", "- - -"})
            Me.Rows.Add(New Object() {"Effektivzeit", "- - -"})
            Me.Rows.Add(New Object() {"Ang. Effektivzeit", "- - -"})
            Me.Rows.Add(New Object() {"Gesamt-Pausenzeit", "- - -"})
            Me.Rows.Add(New Object() {"Gesamt-Ausfallzeit", "- - -"})
            Me.Rows.Add(New Object() {[Object].WorkGroup.IncentiveIndicatorSynonym, "- - -"})
            Me.Rows.Add(New Object() {"Ang. " & [Object].WorkGroup.IncentiveIndicatorSynonym, "- - -"})
            Me.Rows.Add(New Object() {"Ist ausgesetzt", "- - -"})
        End If
    End Sub
End Class
