Imports Facesso.Data

Public Class FacPrintWorkGroupListShiftWiseCompressed
    Inherits FacessoPrintBase

    Private myWorkGroupAnalysis As WorkGroupAnalysisInfoItems
    Private myProductionPeriod As ProductionPeriod

    Sub New(ByVal WorkGroupAnalysis As WorkGroupAnalysisInfoItems, ByVal Period As ProductionPeriod, ByVal Username As String)
        MyBase.New("Produktiv-Site-Auswertung", WorkGroupAnalysis.Period.RangeDescription, Username)
        myWorkGroupAnalysis = WorkGroupAnalysis
        myProductionPeriod = Period
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument()

        Dim locDoPrint As Boolean
        Dim locDownTimeTotal As Double
        Dim locBreakTimeTotal As Double
        Dim locTotalAttendanceTime As Double
        Dim locTotalEffectiveIWT As Double
        Dim locTotalEffectiveIWTAdj As Double
        Dim locTotalReferenceIWT As Double
        Dim locTotalWorkingTime As Double

        With PrintDocument
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .WriteLine(myProductionPeriod.ShiftParameters.ToString).DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 75, 75, 180, 140, 150, 125)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Schicht", "Site-Nr.:", "Site-Name", "Unterbr.-" + vbNewLine + "zeiten", "Netto-" + vbNewLine + "zeiten", "Kennzahlen")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont
            For Each locAnalysisInfo As WorkGroupAnalysisInfo In myWorkGroupAnalysis
                For locShift As Integer = 1 To 4
                    Dim locItem As WorkGroupAnalysisInfoItem = Nothing
                    For Each locItem In locAnalysisInfo
                        If locItem.Shift = locShift Then
                            If locItem.DegreeOfTime > -1 Then
                                locDoPrint = True
                                Exit For
                            End If
                        End If
                    Next
                    If locDoPrint And locItem IsNot Nothing Then
                        locDoPrint = Not locDoPrint
                        'Leerzeiten nicht drucken!
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        .WriteCell(locShift.ToString)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        .WriteCell(locAnalysisInfo.WorkGroupInfo.WorkGroupNumber.ToString())
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                        .WriteCell(locAnalysisInfo.WorkGroupInfo.WorkGroupName)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        .WriteCell("Ausfall: " & locItem.TotalDownTime.ToString("#,##0") & " Min.")
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                        .WriteCell("Effektiv (ang.): " & locItem.TotalEffectiveIWTAdj.ToString("#,##0") & " Min.")
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                        .WriteCell("Zeitgrad (angp.): " & locItem.DegreeOfTimeAdj.ToString("##0"))

                        locDownTimeTotal += locItem.TotalDownTime
                        locBreakTimeTotal += locItem.TotalWorkBreakTime
                        locTotalAttendanceTime += locItem.TotalAttendanceTime
                        locTotalEffectiveIWT += locItem.TotalEffectiveIWT
                        locTotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj
                        locTotalReferenceIWT += locItem.TotalReferenceIWT
                        locTotalWorkingTime += locItem.TotalWorkingTime
                    End If
                Next
            Next
            .EndTable()

            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left
            .WriteLine()
            .WriteLine("Zusammenfassung:")
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            .WriteLine("Gesamt-Ausfallzeit: " & locDownTimeTotal.ToString("#,##0"))
            .WriteLine("Gesamt-Pausenzeit: " & locBreakTimeTotal.ToString("#,##0"))
            .WriteLine("Gesamt-Anwesenheitszeit: " & locTotalAttendanceTime.ToString("#,##0"))
            .WriteLine("Effektive Prämienlohnzeit: " & locTotalEffectiveIWT.ToString("#,##0"))
            .WriteLine("Effektive angepasste Prämienlohnzeit: " & locTotalEffectiveIWTAdj.ToString("#,##0"))
            .WriteLine("Gesamt-Referenzzeit: " & locTotalReferenceIWT.ToString("#,##0"))
            .WriteLine("Gesamt-Arbeitszeit (ohne Pausen und Ausfälle): " & locTotalWorkingTime.ToString("#,##0"))

        End With
    End Sub
End Class
