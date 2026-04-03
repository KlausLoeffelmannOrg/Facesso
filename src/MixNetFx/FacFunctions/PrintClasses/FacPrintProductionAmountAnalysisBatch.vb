Imports Facesso.Data
Imports System.Drawing
Imports System.IO

Public Class FacPrintProductionAmountAnalysisBatch
    Inherits FacessoPrintBase

    Private myWorkgroupsAmounts As WorkgroupsProductionDataAmounts

    Sub New(ByVal WorkgroupsAmounts As WorkgroupsProductionDataAmounts, ByVal Username As String)
        MyBase.New("Mengenanalyse", "", Username)
        myWorkgroupsAmounts = WorkgroupsAmounts
    End Sub

    Protected Overrides Sub PrepareDocument()

        If myWorkgroupsAmounts.CategorisedBy = ProductionDataAmountsCategory.None Then
            MyBase.PrepareDocument(True)
            With PrintDocument
                .WriteLine().DistanceToNext = 10
                'Mengentabelle der Produktiv-Site
                For Each locItem As WorkgroupProductionDataAmounts In myWorkgroupsAmounts
                    PrintWorkGroupStatement(locItem)
                    .PageBreak()
                Next
            End With
        ElseIf myWorkgroupsAmounts.CategorisedBy = ProductionDataAmountsCategory.LabourValues Then
            PrintWorkgroupStatementCategorisedByLabourValues()
        Else
            PrintWorkgroupStatementCategorisedByCostCenters()
        End If


    End Sub

    Protected Overridable Sub PrintWorkgroupStatementCategorisedByCostCenters()

        Dim locSum As Double

        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .WriteLine("Kostenstellenanalyse  auf Produktionsmengen und Vorgabezeitbasis")
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Zeitraum: " & myWorkgroupsAmounts.Startdate.ToString("ddd, dd.MM.yyyy") & " bis " & myWorkgroupsAmounts.EndDate.ToString("ddd, dd.MM.yyyy"))
            .WriteLine().DistanceToNext = 5
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 70, 300, 150, 150)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Nr.", "Kostenstellenname", "Produktionszeit (Soll) in HMin", "... in Stunden")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont

            Dim locDataView As New DataView(myWorkgroupsAmounts.CategorisationTable)
            locDataView.Sort = "CostCenterNo"
            For Each locDataRow As DataRowView In locDataView
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locDataRow("CostCenterNo").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locDataRow("CostCenterName").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(CDbl(locDataRow("AmountIncentiveWageProductionTime")).ToString("#,##0.00"))
                locSum += CDbl(locDataRow("AmountIncentiveWageProductionTime"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell((CDbl(locDataRow("AmountIncentiveWageProductionTime")) / 60).ToString("#,##0.00"))
            Next
            .EndTable()

            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left
            .WriteLine()
            .WriteLine("Zusammenfassung:")
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            .WriteLine("Gesamtaufwand  im Zeitraum in Hmin/Stunden: " & locSum.ToString("#,##0.00") & " / " & (locSum / 60).ToString("#,##0.00"))
            .WriteLine("Ausfallzeiten  im Zeitraum in HMin/Stunden: ")
        End With

    End Sub

    Protected Overridable Sub PrintWorkgroupStatementCategorisedByLabourValues()

        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .WriteLine("Mengenanalyse für ausgewählte Produktiv-Sites, kategorisiert nach Arbeitswert-Nummern")
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Zeitraum: " & myWorkgroupsAmounts.Startdate.ToString("ddd, dd.MM.yyyy") & " bis " & myWorkgroupsAmounts.EndDate.ToString("ddd, dd.MM.yyyy"))
            .WriteLine().DistanceToNext = 5
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 70, 350, 70, 80, 80, 80)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Nr.", "Beschreibung", "Kst.-Nr.", "Summe", "Einheit", "te in HMin")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont

            Dim locDataView As New DataView(myWorkgroupsAmounts.CategorisationTable)
            locDataView.Sort = "LabourValueNumber"
            For Each locDataRow As DataRowView In locDataView
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locDataRow("LabourValueNumber").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locDataRow("LabourValueDescription").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locDataRow("CostCenterNo").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(CDbl(locDataRow("TotalAmount")).ToString("#,##0.00"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locDataRow("LabourValueDimension").ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(CDbl(locDataRow("LabourValueTeHMin")).ToString("#,##0.000"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
            Next
            .EndTable()
        End With
    End Sub

    Protected Overridable Sub PrintWorkGroupStatement(ByVal WorkgroupAmounts As WorkgroupProductionDataAmounts)

        Dim locDegreeOfTimeFaktor As Double = WorkgroupAmounts.Workgroup.CurrentDegreeOfTime / 100
        Dim locTotalHours As Double
        Dim locHours As Double
        Dim locUnitPerHour As Double

        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
            .WriteLine("Mengenanalyse  für " & WorkgroupAmounts.Workgroup.WorkGroupNumber & " " & WorkgroupAmounts.Workgroup.WorkGroupName)
            .CurrentFont = LayoutAndNumberFormats.U2Font.ToFont
            .WriteLine("Zeitraum: " & WorkgroupAmounts.Startdate.ToString("ddd, dd.MM.yyyy") & " bis " & WorkgroupAmounts.EndDate.ToString("ddd, dd.MM.yyyy"))
            .WriteLine().DistanceToNext = 5
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 70, 220, 70, 80, 80, 80, 80, 80)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("Nr.", "Beschreibung", "Kst.-Nr.", "Summe", "Einheit", "te in HMin", "Aufwand in Std.", "Stück pro Std.")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont

            'TODO: Nachkommastellen und Texte in Abhängigkeit vom Arbeitswert anpassen
            For Each locItem As WorkgroupProductionDataAmount In WorkgroupAmounts
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValue.LabourValueNumber.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.LabourValue.LabourValueName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValue.CostCenterNo.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.TotalAmount.ToString("#,##0.00"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.LabourValue.Dimension)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValue.TeHMin.ToString("#,##0.000"))
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                locHours = locItem.LabourValue.TeHMin * locItem.TotalAmount / locDegreeOfTimeFaktor / 60
                .WriteCell((locHours).ToString("#,##0.00"))
                locUnitPerHour = locItem.TotalAmount / locHours
                .WriteCell((locUnitPerHour).ToString("#,##0.00"))
                locTotalHours += locHours
            Next
            .EndTable()

            .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
            .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left
            .WriteLine()
            .WriteLine("Zusammenfassung:")
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            .WriteLine("Zeitgrad dieser Gruppe: " & WorkgroupAmounts.Workgroup.CurrentDegreeOfTime.ToString("#,##0"))
            .WriteLine("Gesamtstundenaufwand: " & locTotalHours.ToString("#,##0.00") & "  Stunden")
        End With
    End Sub

    Public Overrides ReadOnly Property HasExcelExport() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Sub ExcelExport(ByVal Filename As String)

        Dim locSW As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Filename, False, System.Text.Encoding.Default)
        locSW.Write("PS-Nr.;")
        locSW.Write("Produktiv-Site;")
        locSW.Write("Zeitgrad;")
        locSW.Write("AW-Nr.;")
        locSW.Write("Beschreibung;")
        locSW.Write("te-hMin;")
        locSW.Write("Kst.-Nr.;")
        locSW.Write("Kostenstellenname;")
        locSW.Write("Summe;")
        locSW.WriteLine("Einheit;")
        For Each locWorkgroupAmounts As WorkgroupProductionDataAmounts In myWorkgroupsAmounts

            Dim locDegreeOfTime As Double = locWorkgroupAmounts.Workgroup.CurrentDegreeOfTime

            For Each locItem As WorkgroupProductionDataAmount In locWorkgroupAmounts
                locSW.Write(locWorkgroupAmounts.Workgroup.WorkGroupNumber.ToString & ";")
                locSW.Write(locWorkgroupAmounts.Workgroup.WorkGroupName & ";")
                locSW.Write(locDegreeOfTime & ";")
                locSW.Write(locItem.LabourValue.LabourValueNumber.ToString & ";")
                locSW.Write(locItem.LabourValue.LabourValueName & ";")
                locSW.Write(locItem.LabourValue.TeHMin & ";")
                locSW.Write(locItem.LabourValue.CostCenterNo.ToString & ";")
                locSW.Write(locItem.LabourValue.CostCenterName & ";")
                locSW.Write(locItem.TotalAmount.ToString("#,##0.00") & ";")
                locSW.WriteLine(locItem.LabourValue.Dimension & ";")
            Next
        Next
        locSW.Flush()
        locSW.Close()
    End Sub
End Class
