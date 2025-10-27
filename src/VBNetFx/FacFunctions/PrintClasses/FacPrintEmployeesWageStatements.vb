Imports Facesso.Data
Imports System.Drawing

Public Class FacPrintEmployeesWageStatements
    Inherits FacessoPrintBase

    Private myEmployeeWages As EmployeeAnalysisInfoItems

    Sub New(ByVal EmployeeWages As EmployeeAnalysisInfoItems, ByVal Username As String)
        MyBase.New("Prämienlohnaufstellung", EmployeeWages.PeriodText, Username)
        myEmployeeWages = EmployeeWages
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument(True)
        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            For Each locItem As EmployeeAnalysisInfoItem In myEmployeeWages
                If Not locItem.Selected Then Continue For
                PrintEmployeeStatement(locItem)
                .PageBreak()
            Next
        End With
    End Sub

    Private Sub PrintEmployeeStatement(ByVal WageItem As EmployeeAnalysisInfoItem)
        With PrintDocument
            Dim locTimeLogInfoCollection As New EmployeeTimeLogInfoCollection()
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            'TODO: Begriff durch Kostenstelle anpassen
            .WriteLine("Prämienberechnung  für " & WageItem.EmployeeWage.FirstName & " " & WageItem.EmployeeWage.LastName)
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Abrechnungszeitraum:  " & WageItem.Period.StartDateMonthDescription)
            .WriteLine().DistanceToNext = 5
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 80, 100, 100, 100, 115, 100, 115)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Tag-Nr.:", "Gesamt-" & vbNewLine & "präsenz", "Pausen", "Ausfall", "(eigentliche) Effektivzeit", "Referenzzeit", "(eigentlicher) ang. Zeitgrad")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont

            For locDaysCount As Integer = WageItem.Period.StartDate.Day To WageItem.Period.EndDate.Day()
                'Alle TimeLogItems dieser Tage zusammensuchen
                Dim locTimeLogItems As New EmployeeTimeLogInfo
                locTimeLogItems.RecalculateTotalReferenceIWT = True
                For Each locItem As EmployeeTimeLogInfoItem In WageItem.TimeLogItems
                    If locItem.ProductionDate = New Date(WageItem.Period.StartDate.Year, _
                                                       WageItem.Period.StartDate.Month, locDaysCount) Then
                        locTimeLogItems.Add(locItem)
                    End If
                Next
                locTimeLogInfoCollection.Add(locTimeLogItems)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight

                'Wochentagsabkürzung und Namen drucken
                .WriteCell(New DateTime(WageItem.Period.StartDate.Year, _
                           WageItem.Period.StartDate.Month, locDaysCount).ToString("(ddd) ") & _
                           locDaysCount.ToString("00"))

                If locTimeLogItems.Count > 0 Then
                    'Daten am Tag vorhanden --> drucken
                    .WriteCell(locTimeLogItems.TotalAttendanceTime.ToString("#,##0.00"))
                    .WriteCell(locTimeLogItems.TotalWorkBreakTime.ToString("#,##0.00"))
                    .WriteCell(locTimeLogItems.TotalDownTime.ToString("#,##0.00"))
                    .WriteCell("(" & locTimeLogItems.TotalEffectiveIWTAct.ToString("#,##0.00") & ")  " & _
                            locTimeLogItems.TotalEffectiveIWT.ToString("#,##0.00"))
                    .WriteCell(locTimeLogItems.TotalReferenceIWT.ToString("#,##0.00"))
                    .WriteCell("(" & locTimeLogItems.DegreeOfTimeAct.ToString("#,##0") & ")  " & locTimeLogItems.DegreeOfTime.ToString("#,##0"))
                Else
                    .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                    .WriteCells("- - -", "- - -", "- - -", "- - -", "- - -", "- - -")
                End If
            Next
            'Zusammenfassung
            .CurrentFont = New Font(LayoutAndNumberFormats.SmallTableFont.ToFont, FontStyle.Bold)
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
            .WriteCell("Gesamt:")
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
            .WriteCell(locTimeLogInfoCollection.TotalAttendanceTime.ToString("#,##0.00"))
            .WriteCell(locTimeLogInfoCollection.TotalWorkBreakTime.ToString("#,##0.00"))
            .WriteCell(locTimeLogInfoCollection.TotalDownTime.ToString("#,##0.00"))
            .WriteCell(" (" & locTimeLogInfoCollection.TotalEffectiveIWTAct.ToString("#,##0.00") & ") " & _
                locTimeLogInfoCollection.TotalEffectiveIWT.ToString("#,##0.00"))
            .WriteCell(locTimeLogInfoCollection.TotalReferenceIWT.ToString("#,##0.00"))
            .WriteCell("(" & locTimeLogInfoCollection.DegreeOfTimeAct.ToString("#,##0") & ") " & _
                locTimeLogInfoCollection.DegreeOfTime.ToString("#,##0"))
            .EndTable()
            .WriteLine.DistanceToNext = 8
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Berechnung der Prämie").DistanceToNext = 10
            .BeginTable(ActiveDev.Printing.ADFrameCellBorderStyle.None, 170, 170, 170, 170)
            .BuildTableHeader()
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("angepasster Zeitgrad", "Grundlohn", "Effektivstunden", "Prämie")
            .BuildTableBody()
            .CurrentFont = New Font(LayoutAndNumberFormats.TextAndTableBodyFont.ToFont, FontStyle.Bold)
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont
            .WriteCell(locTimeLogInfoCollection.DegreeOfTime.ToString("#,##0") & " " & WageItem.EmployeeWage.PercentageDescription)
            .WriteCell(WageItem.EmployeeWage.BaseWage.ToString("#,##0.00 €"))
            .WriteCell((WageItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \h"))
            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .WriteCell(WageItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 €"))
            .EndTable()
        End With
    End Sub
End Class
