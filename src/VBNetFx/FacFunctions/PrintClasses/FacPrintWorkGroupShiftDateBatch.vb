Imports Facesso.Data
Imports System.Drawing
Imports System.Collections.ObjectModel

Public Class FacPrintWorkGroupShiftDateBatch
    Inherits FacessoPrintBase

    Private myProductionPeriod As ProductionPeriod
    Private myWorkGroupList As Collection(Of WorkGroupInfo)

    Sub New(ByVal WorkGroupList As Collection(Of WorkGroupInfo), ByVal Period As ProductionPeriod, ByVal Username As String)
        MyBase.New("Schichtanalyse Produktiv-Site", "Detailaufstellung", Username)
        myProductionPeriod = Period
        myWorkGroupList = WorkGroupList
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument(True)

        With PrintDocument
            'Mengentabelle der Produktiv-Site
            For Each locWorkGroup As WorkGroupInfo In myWorkGroupList
                For Each locItem As ProductionPeriodItem In myProductionPeriod
                    Dim locSdwr As New ShiftDateWorkResultInfo(New CombinedParametersInfo(locWorkGroup, locItem.ProductionDate, locItem.Shift))
                    PrintWorkGroupStatement(locSdwr)
                    .PageBreak()
                Next
            Next
        End With
    End Sub

    Protected Overridable Sub PrintWorkGroupStatement(ByVal sdwResult As ShiftDateWorkResultInfo)

        With PrintDocument
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Schichtanalyse Produktiv-Site")
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine(sdwResult.CombinedParameters.WorkGroup.ListItemText)
            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .WriteLine("Schicht: " & sdwResult.CombinedParameters.Shift & "  -  " & sdwResult.CombinedParameters.ProductionDate.ToLongDateString).DistanceToNext = 20
            .WriteLine("Produktionsergebnis:").DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 100, 300, 80, 100, 80, 80)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Menge", "Einheit", sdwResult.ProductionData.WorkGroup.BaseValueSynonym, "Summe")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            For Each locItem As ProductionDataItem In sdwResult.ProductionData
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValue.LabourValueNumber.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.LabourValue.LabourValueName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.Amount.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.LabourValue.Dimension.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValue.TeHMin.ToString)
                .WriteCell(locItem.SubTotal.ToString)
            Next
            .EndTable()
            .WriteLine().DistanceToNext = 20
            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .WriteLine("Beteiligte Mitarbeiter:").DistanceToNext = 10
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 80, 150, 85, 85, 70, 75, 75, 160)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Pers.-Nr.:", "Name, Vorname", "Start", "Ende", "Pause", "Ausfall", "Handicap", "Zeitendelta")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            For Each locItem As EmployeeTimeLogInfoItem In sdwResult.EmployeeTimeLogItems
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.EmployeeInfo.PersonnelNumber.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.EmployeeInfo.LastName & ", " & locItem.EmployeeInfo.FirstName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.ShiftStart.ToString("(ddd) HH:mm"))
                .WriteCell(locItem.ShiftEnd.ToString("(ddd) HH:mm"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.WorkBreak.ToString)
                .WriteCell(locItem.DownTime.ToString)
                .WriteCell(locItem.Handicap.ToString & " %")
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.TimeDeltaStrings)
            Next
            .EndTable()
            .WriteLine()
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Zusammenfassung").DistanceToNext = 10
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(ActiveDev.Printing.ADFrameCellBorderStyle.None, 200, 400)
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.MiddleLeft
            .WriteCell("Produktiv-Site:") : .WriteCell(sdwResult.CombinedParameters.WorkGroup.ListItemText)
            .WriteCell("Datum:") : .WriteCell(sdwResult.CombinedParameters.ProductionDate.ToLongDateString)
            .WriteCell("Schicht:") : .WriteCell(sdwResult.CombinedParameters.Shift.ToString)
            .WriteCell("Minuten Referenz:") : .WriteCell(sdwResult.TotalReferenceIWT.ToString("#,##0.00"))
            .WriteCell("Minuten effektiv:") : .WriteCell(sdwResult.TotalEffectiveIWT.ToString("#,##0.00"))
            .WriteCell("Minuten effektiv (angepasst):") : .WriteCell(sdwResult.TotalEffectiveIWTAdj.ToString("#,##0.00"))
            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .WriteCell(sdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym)
            .WriteCell(sdwResult.DegreeOfTime.ToString(sdwResult.CombinedParameters.WorkGroup.IncentiveFormatString))
            .EndTable()
        End With
    End Sub
End Class
