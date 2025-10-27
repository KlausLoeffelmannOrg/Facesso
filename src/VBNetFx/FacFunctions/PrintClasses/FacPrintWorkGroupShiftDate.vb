Imports Facesso.Data

Public Class FacPrintWorkGroupShiftDate
    Inherits FacessoPrintBase

    Private mySdwResult As ShiftDateWorkResultInfo

    Sub New(ByVal sdwResult As ShiftDateWorkResultInfo, ByVal Username As String)
        MyBase.New("Schichtanalyse Produktiv-Site", _
        sdwResult.CombinedParameters.WorkGroup.ListItemText & ", Schicht " & _
        sdwResult.CombinedParameters.Shift & "  -  " & _
        sdwResult.CombinedParameters.ProductionDate.ToLongDateString, Username)
        mySdwResult = sdwResult
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument()

        With PrintDocument
            .WriteLine("Produktionsergebnis:").DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 100, 300, 80, 100, 80, 80)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Menge", "Einheit", mySdwResult.ProductionData.WorkGroup.BaseValueSynonym, "Summe")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            For Each locItem As ProductionDataItem In mySdwResult.ProductionData
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
            .WriteCells("Pers.-Nr.:", "Name, Vorname", "Start", "Ende", "Pause", "Ausfall", "Handic.", "Zeitendelta")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            For Each locItem As EmployeeTimeLogInfoItem In mySdwResult.EmployeeTimeLogItems
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
            .WriteCell("Produktiv-Site:") : .WriteCell(mySdwResult.CombinedParameters.WorkGroup.ListItemText)
            .WriteCell("Datum:") : .WriteCell(mySdwResult.CombinedParameters.ProductionDate.ToLongDateString)
            .WriteCell("Schicht:") : .WriteCell(mySdwResult.CombinedParameters.Shift.ToString)
            .WriteCell("Minuten Referenz:") : .WriteCell(mySdwResult.TotalReferenceIWT.ToString("#,##0.00"))
            .WriteCell("Minuten effektiv:") : .WriteCell(mySdwResult.TotalEffectiveIWT.ToString("#,##0.00"))
            .WriteCell("Minuten effektiv (angepasst):") : .WriteCell(mySdwResult.TotalEffectiveIWTAdj.ToString("#,##0.00"))
            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .WriteCell(mySdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym)
            .WriteCell(mySdwResult.DegreeOfTime.ToString(mySdwResult.CombinedParameters.WorkGroup.IncentiveFormatString))
            .WriteCell(mySdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym & " (angp.)")
            .WriteCell(mySdwResult.DegreeOfTimeAdj.ToString(mySdwResult.CombinedParameters.WorkGroup.IncentiveFormatString))
            .EndTable()
        End With

    End Sub
End Class
