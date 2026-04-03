Imports Facesso.Data
Imports System.io

Public Class FacPrintEmployeesWageList
    Inherits FacessoPrintBase

    Private myEmployeeWages As EmployeeAnalysisInfoItems

    Sub New(ByVal EmployeeWages As EmployeeAnalysisInfoItems, ByVal Username As String)
        MyBase.New("Prämienlohnliste", EmployeeWages.PeriodText, Username)
        myEmployeeWages = EmployeeWages
    End Sub

    Public Overrides ReadOnly Property HasExcelExport() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Sub ExcelExport(ByVal Filename As String)
        Dim locSW As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Filename, False, System.Text.Encoding.Default)
        locSW.Write("Pers-Nr.;")
        locSW.Write("Name;")
        locSW.Write("Vorname;")
        locSW.Write("Arbeitszeit;")
        locSW.Write("Pausenzeit;")
        locSW.Write("Referenzzeit;")
        locSW.Write("Effektivzeit;")
        locSW.Write("angep. Effektivzeit;")
        locSW.Write("Zeitgrad;")
        locSW.Write("angep. Zeitgrad;")
        locSW.Write("Grundlohn;")
        locSW.Write("Effektivstunden;")
        locSW.WriteLine("Prämie")
        For Each locItem As EmployeeAnalysisInfoItem In myEmployeeWages
            'Leerzeiten nicht drucken!
            If Not locItem.Selected Then Continue For
            locSW.Write(locItem.EmployeeWage.PersonnelNumber.ToString() & ";")
            locSW.Write(locItem.EmployeeWage.LastName & "; " & locItem.EmployeeWage.FirstName & ";")
            locSW.Write(locItem.TimeLogItems.TotalAttendanceTime.ToString & ";")
            locSW.Write(locItem.TimeLogItems.TotalWorkBreakTime.ToString & ";")
            locSW.Write(locItem.TimeLogItems.TotalReferenceIWT.ToString & ";")
            locSW.Write(locItem.TimeLogItems.TotalEffectiveIWT.ToString & ";")
            locSW.Write(locItem.TimeLogItems.TotalEffectiveIWTAdj.ToString & ";")
            locSW.Write(locItem.TimeLogItems.DegreeOfTime.ToString & ";")
            locSW.Write(locItem.TimeLogItems.DegreeOfTimeAdj.ToString & ";")
            locSW.Write(locItem.EmployeeWage.BaseWage.ToString() & ";")
            locSW.Write((locItem.EmployeeWage.IncentiveWageTime / 60).ToString() & ";")
            locSW.WriteLine(locItem.EmployeeWage.TotalIncentiveWage.ToString())
        Next
        locSW.Flush()
        locSW.Close()
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument()

        With PrintDocument
            .WriteLine().DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 55, 135, 135, 135, 90, 60, 80, 80)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("P.-Nr.:", "Name, Vorname", "Anwesenheits-" + vbNewLine + "zeiten", "Bonus-" + vbNewLine + "zeiten", "Zeitgrad", "Grund- lohn", "Effektiv- stunden", "Prämie")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont
            For Each locItem As EmployeeAnalysisInfoItem In myEmployeeWages
                'Leerzeiten nicht drucken!
                If Not locItem.Selected Then Continue For
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.EmployeeWage.PersonnelNumber.ToString())
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.EmployeeWage.LastName & ", " & locItem.EmployeeWage.FirstName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.TimeLogItems.AttendanceTimeDeltaStrings)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell(locItem.TimeLogItems.IncentiveTimeDeltaStrings)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                .WriteCell("Zeitgrad: " & locItem.EmployeeWage.DegreeOfTime.ToString("##0") & vbNewLine & locItem.EmployeeWage.PercentageDescription)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.EmployeeWage.BaseWage.ToString("#,##0.00 €"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell((locItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \h"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 €"))
            Next
            .EndTable()
        End With

    End Sub
End Class
