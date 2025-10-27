Imports Facesso.Data

Public Class FacPrintWorkgroupBaseData
    Inherits FacessoPrintBase

    Private myParameters As WorkgroupBaseDataPrintParameters

    Sub New(ByVal PrintParameters As WorkgroupBaseDataPrintParameters, ByVal Username As String)
        MyBase.New("Stammdatenliste", _
        "Stand:" & Now.ToLongDateString & " - " & Now.ToShortTimeString, _
        Username)
        myParameters = PrintParameters
    End Sub

    Protected Overrides Sub PrepareDocument()
        MyBase.PrepareDocument(True)

        If myParameters.OnlyPrintListOfLabourValues Then
            PrintListOfLabourValues()
        Else
            PrintWorkGroups()
        End If
    End Sub

    Sub PrintListOfLabourValues()
        'Daten ermitteln
        Dim locLabourValues As dsLabourValues.dtLabourValuesDataTable
        Dim locTALabourValues As New dsLabourValuesTableAdapters.dtLabourValuesTableAdapter
        locTALabourValues.Connection = New SqlClient.SqlConnection(FacessoGeneric.SQLConnectionString)
        locLabourValues = locTALabourValues.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary)

        With PrintDocument
            .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
            .WriteLine("Liste der REFA-Arbeitswerte:").DistanceToNext = 10
            'Mengentabelle der Produktiv-Site
            .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
            .BeginTable(BorderStyle, 70, 250, 75, 100, 70, 70, 150)
            .BuildTableHeader()
            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
            .WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Einheit", "Perf.-Ind.", "Wert", "Kstnr.:", "Kostenstellenname:")
            .BuildTableBody()
            .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
            For Each locItem As dsLabourValues.dtLabourValuesRow In locLabourValues
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.LabourValueNumber.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.LabourValueName)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                .WriteCell(locItem.Dimension.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.BaseValueSynonym)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                'TODO: Richtiges Format einbauen!
                .WriteCell(locItem.TeHMin.ToString("#,##0.000"))
                .WriteCell(locItem.CostCenterNo.ToString)
                .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                .WriteCell(locItem.CostCenterName)
            Next
            .EndTable()
        End With
    End Sub

    Sub PrintWorkGroups()
        'Daten ermitteln
        Dim locAssignments As dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable
        Dim locWorkGroups As dsWorkgroupAssignments.dtWorkGroupsDataTable

        Dim locTaAssignments As New dsWorkgroupAssignmentsTableAdapters.dtLabourValuesToWorkGroupAssignmentsTableAdapter
        Dim locTaWorkgroups As New dsWorkgroupAssignmentsTableAdapters.dtWorkGroupsTableAdapter

        locTaAssignments.Connection = New SqlClient.SqlConnection(FacessoGeneric.SQLConnectionString)
        locTaWorkgroups.Connection = locTaAssignments.Connection

        locAssignments = locTaAssignments.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary)
        locWorkGroups = locTaWorkgroups.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary)

        Dim locAssignmentView As New DataView(locAssignments)

        For Each locWorkgroupItem As dsWorkgroupAssignments.dtWorkGroupsRow In locWorkGroups
            With PrintDocument
                .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center
                .CurrentFont = LayoutAndNumberFormats.U1Font.ToFont
                .WriteLine("Produktiv-Site-Info für")
                .WriteLine(locWorkgroupItem.WorkGroupNumber.ToString & ": " & locWorkgroupItem.WorkgroupName).DistanceToNext = 5
                .WriteLine()
                .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
                .CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left

                .WriteLine("Zugeordnete Kostenstelle:  " & locWorkgroupItem.CostCenterNo & ": " & locWorkgroupItem.CostCenterName)
                .WriteLine("Aktiviert:  " & IIf(locWorkgroupItem.IsActive, "Ja", "Nein").ToString)
                If (locWorkgroupItem.IsWorkGroupDescriptionNull) Then
                    .WriteLine("Beschreibung:  - Es wurde keine Beschreibung hinterlegt -")
                Else
                    .WriteLine("Beschreibung:  " & locWorkgroupItem.WorkGroupDescription).DistanceToNext = 20
                End If
                .WriteLine()
                .WriteLine()

                If myParameters.PrintShiftTimes Then
                    .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
                    .WriteLine("Schichtzeit-Definitionen für manuelle Eingabe:").DistanceToNext = 10
                    .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
                    .BeginTable(BorderStyle, 120, 100, 100, 100, 100)
                    .BuildTableHeader()
                    .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                    .WriteCells("Tag", "Schicht", "Startzeit", "Endzeit", "Pausen")
                    .BuildTableBody()

                    Dim locTimeDetails As TimeSettingDetails = TimeSettingDetails.FromXmlString(locWorkgroupItem.TimeSettingDetails)

                    Dim locDate As Date = #1/1/2001#
                    For locDay As Integer = 0 To 6
                        For locShift As Integer = 1 To 4
                            Dim locTD As TimeSettingDetail = locTimeDetails.GetTimeSettingDetail(locDate, locShift)
                            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                            .WriteCell(locDate.ToString("dddd"))
                            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                            .WriteCell(locShift.ToString)
                            .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                            If locTD.ShiftStart.IsNull Then
                                .WriteCell("n.d.")
                            Else
                                .WriteCell(locTD.ShiftStart.TypedValue.ToString("ddd, HH:mm"))
                            End If

                            If locTD.ShiftEnd.IsNull Then
                                .WriteCell("n.d.")
                            Else
                                .WriteCell(locTD.ShiftEnd.TypedValue.ToString("ddd, HH:mm"))
                            End If

                            If locTD.WorkBreak.IsNull Then
                                .WriteCell("n.d.")
                            Else
                                .WriteCell(locTD.WorkBreak.TypedValue.ToString)
                            End If
                        Next
                        locDate = locDate.AddDays(1)
                    Next
                    .EndTable()
                    If myParameters.PrintAssignedLabourValues Then
                        PrintDocument.PageBreak()
                    End If
                End If

                locAssignmentView.RowFilter = "IDWorkGroupInternal=" & locWorkgroupItem.IDWorkGroupInternal

                If myParameters.PrintAssignedLabourValues Then
                    .CurrentFont = LayoutAndNumberFormats.U3Font.ToFont
                    .WriteLine("Liste der zugeordneten REFA-Arbeitswerte für " & locWorkgroupItem.WorkGroupNumber & ": " & locWorkgroupItem.WorkgroupName).DistanceToNext = 10
                    .CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont
                    .BeginTable(BorderStyle, 70, 250, 75, 70, 70, 150)
                    .BuildTableHeader()
                    .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter
                    .WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Einheit", "Wert", "Kstnr.:", "Kostenstellenname:")
                    .BuildTableBody()
                    .CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont
                    For Each locLabourValueViewItem As DataRowView In locAssignmentView
                        Dim locLabourValueItem As dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsRow
                        locLabourValueItem = CType(locLabourValueViewItem.Row, dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsRow)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        .WriteCell(locLabourValueItem.LabourValueNumber.ToString)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                        .WriteCell(locLabourValueItem.LabourValueName)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        .WriteCell(locLabourValueItem.Dimension.ToString)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight
                        'TODO: Richtiges Format einbauen!
                        .WriteCell(locLabourValueItem.TeHMin.ToString("#,##0.000"))
                        .WriteCell(locLabourValueItem.CostCenterNo.ToString)
                        .CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft
                        .WriteCell(locLabourValueItem.CostCenterName)
                    Next
                    .EndTable()
                End If
            End With
            PrintDocument.PageBreak()
        Next
        Exit Sub
    End Sub


End Class
