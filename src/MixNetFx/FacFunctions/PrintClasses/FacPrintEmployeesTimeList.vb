Imports ActiveDev
Imports Facesso.Data

Public Class FacPrintEmployeesTimeList
    Inherits FacessoPrintBase

    Private myTimeList As EmployeeTimeLogInfo
    Private myWorkGroups As WorkGroupInfoItems

    Sub New(ByVal TimeList As EmployeeTimeLogInfo, ByVal Username As String)
        MyBase.New("Zeitenaufstellung für " & TimeList.Employee.DisplayName, _
                   "von " & TimeList.StartDate.ToShortDateString & " bis " & _
                   TimeList.EndDate.ToShortDateString, Username)
        myTimeList = TimeList
        If myWOrkGroups Is Nothing Then
            myWOrkGroups = New WorkGroupInfoItems(True)
        End If
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument()

        With PrintDocument
            .WriteLine().DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 60, 65, 180, 100, 100, 100, 85, 87)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Datum", "Schicht", "Produktiv-Site", "von", "bis", "Anwesen- heitszeit", "Pausen- zeit", "Ausfallzeit")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont
            For Each locItem As EmployeeTimeLogInfoItem In myTimeList
                'Leerzeiten nicht drucken!
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.ProductionDate.ToString("dd.MM."))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.Shift.ToString("0"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(myWorkGroups(New IntKey(locItem.IDWorkGroup)).ListItemText)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.ShiftStart.ToString("(dd:)  HH:mm"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.ShiftEnd.ToString("(dd:)  HH:mm"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.AttendanceTime.ToString("#,##0.00") & " min.")
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.WorkBreak.ToString("##0.00") & " min.")
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.DownTime.ToString("##0.00") & " min.")
            Next
            .EndTable()
        End With
    End Sub
End Class
