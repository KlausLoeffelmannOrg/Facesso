Imports Facesso.Data

Public Class FacPrintWorkGroupListShiftCondensed
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

        With PrintDocument
            .WriteLine(myProductionPeriod.ShiftParameters.ToString).DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 65, 175, 135, 110, 135, 125)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Nr.:", "Site-Name", "Brutto-" + vbNewLine + "zeiten", "Unterbr.-" + vbNewLine + "zeiten", "Netto-" + vbNewLine + "zeiten", "Kennzahlen")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont
            For Each locItem As WorkGroupAnalysisInfo In myWorkGroupAnalysis
                'Leerzeiten nicht drucken!
                If locItem.DegreeOfTime = -1 Then Continue For
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.WorkGroupInfo.WorkGroupNumber.ToString())
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.WorkGroupInfo.WorkGroupName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.AttendanceTimeDeltaStrings)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.GeneralBreakTimeStrings)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.IncentiveTimeDeltaStrings)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell("Zeitgrad: " & locItem.DegreeOfTime.ToString("##0") & vbNewLine & _
                           "Zeitgrad (angp.): " & locItem.DegreeOfTimeAdj.ToString("##0") & _
                           vbNewLine & "Auslastung:" & locItem.PercentageWorkload.ToString("#,##0.00") & " %")
            Next
            .EndTable()
        End With
    End Sub
End Class
