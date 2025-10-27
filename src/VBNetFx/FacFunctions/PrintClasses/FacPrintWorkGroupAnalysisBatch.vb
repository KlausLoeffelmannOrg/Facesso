Imports Facesso.Data
Imports System.Drawing

Public Class FacPrintWorkGroupAnalysisBatch
    Inherits FacessoPrintBase

    Private myWorkGroupAnalysis As WorkGroupAnalysisInfoItems
    Private myProductionPeriod As ProductionPeriod

    Sub New(ByVal WorkGroupAnalysis As WorkGroupAnalysisInfoItems, ByVal Period As ProductionPeriod, ByVal Username As String)
        MyBase.New("Produktiv-Site-Auswertung", WorkGroupAnalysis.Period.RangeDescription, Username)
        myWorkGroupAnalysis = WorkGroupAnalysis
        myProductionPeriod = Period
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument(True)

        With PrintDocument
            .WriteLine().DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            For Each locItem As WorkGroupAnalysisInfo In myWorkGroupAnalysis
                PrintWorkGroupStatement(locItem)
                .PageBreak()
            Next
        End With
    End Sub

    Protected Overridable Sub PrintWorkGroupStatement(ByVal AnalysisInfo As WorkGroupAnalysisInfo)

        Dim locFound As Boolean

        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            'TODO: Begriff durch Kostenstelle anpassen
            .WriteLine("Site-Analyse für " & AnalysisInfo.WorkGroupInfo.WorkGroupNumber & " " & AnalysisInfo.WorkGroupInfo.WorkGroupName)
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Zeitraum: " & myProductionPeriod.StartDate.ToString("ddd, dd.MM.yyyy") & " bis " & myProductionPeriod.EndDate.ToString("ddd, dd.MM.yyyy"))
            If myProductionPeriod.ShiftParameters IsNot Nothing Then
                .WriteLine(myProductionPeriod.ShiftParameters.ToString)
            End If
            .WriteLine().DistanceToNext = 5
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 70, 100, 100, 100, 115, 100, 115)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            'Todo: Zeitgrad durch Kostenstellendefinitiontext für Leistungsindikator ersetzen
            .WriteCells("Tag", "Pausen", "Ausfall", "(angepasste) Effektivzeit", "Referenzzeit", "Auslastung", "(angepasster) Zeitgrad")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont

            For locDaysCount As Integer = Convert.ToInt32(myProductionPeriod.StartDate.ToOADate) To Convert.ToInt32(myProductionPeriod.EndDate.ToOADate)
                'rausfinden, ob's Daten an diesem Tag gibt
                Dim locItem As WorkGroupAnalysisInfoItem = Nothing
                locFound = False
                For Each locItem In AnalysisInfo
                    If locItem.ProductionDate = Date.FromOADate(locDaysCount) Then
                        locFound = True
                        Exit For
                    End If
                Next

                If locFound = False Then
                    locItem = Nothing
                End If

                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                'Wochentagsabkürzung und Namen drucken
                .WriteCell(Date.FromOADate(locDaysCount).ToString("(ddd) dd"))

                If locItem Is Nothing Then
                    .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                    .WriteCells("- - -", "- - -", "- - -", "- - -", "- - -", "- - -")
                Else
                    .WriteCell(locItem.TotalWorkBreakTime.ToString)
                    .WriteCell(locItem.TotalDownTime.ToString)
                    .WriteCell("(" & locItem.TotalEffectiveIWTAdj.ToString & ") " & locItem.TotalEffectiveIWT.ToString)
                    .WriteCell(locItem.TotalReferenceIWT.ToString)
                    .WriteCell("- n.i.p. -")
                    .WriteCell("(" & locItem.DegreeOfTimeAdj.ToString("##0") & ") " & _
                               locItem.DegreeOfTime.ToString("##0"))
                End If
            Next
            'Zusammenfassung
            .CurrentFont = New Font(LayoutAndNumberFormats.SmallTableFont.ToFont, FontStyle.Bold)
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
            .WriteCell("Gesamt:")
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
            .WriteCell(AnalysisInfo.TotalWorkBreakTime.ToString)
            .WriteCell(AnalysisInfo.TotalDownTime.ToString)
            .WriteCell("(" & AnalysisInfo.TotalEffectiveIWTAdj.ToString & ") " & AnalysisInfo.TotalEffectiveIWTAdj.ToString)
            .WriteCell(AnalysisInfo.TotalReferenceIWT.ToString)
            .WriteCell(AnalysisInfo.PercentageWorkload.ToString("##0.00") & " %")
            .WriteCell("(" & AnalysisInfo.DegreeOfTimeAdj.ToString("##0") & ") " & _
                       AnalysisInfo.DegreeOfTime.ToString("##0"))
            .EndTable()
        End With
    End Sub
End Class
