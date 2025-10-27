Imports System.Data.SqlClient

Partial Class KannegiesserSQLProductionDataImportTaskElement

    Private Sub retrieveDataForDate(ByVal ProductionDate As Date)

        If KannegiesserSQLConnectionString Is Nothing Then
            Return
        End If

        'Zieldatentabellenstruktur einrichten
        myCurrFacData = New ProductionDataTable


        ' *** Alte auskommentierte Version (dBase) durch neue SQL ersetzt.
        ''Quelldaten für den Tag abrufen
        'Dim locConnection As New SQLConnection(ConnectionString)

        'Dim locSourceData As New DataTable
        'Using locConnection
        '    Dim locAdapter As New SqlDataAdapter("SELECT * FROM PROTOKOL WHERE DATUM=" & _
        '            ProductionDate.ToString("\#MM\/dd\/yyyy\#") & _
        '            " AND TYP=0 AND ARTNR>0", locConnection)
        '    Dim locIntBack As Integer = locAdapter.Fill(locSourceData)
        'End Using


        ''Daten umschaufeln und dabei neu berechnen
        'For Each locDataRow As DataRow In locSourceData.Rows
        '    Dim locFacRow As ProductionDataRow
        '    locFacRow = myCurrFacData.NewProductionDataRow()
        '    With locFacRow
        '        Dim locStartTime As DateTime = ProductionDate.AddSeconds(CInt(locDataRow("STARTZEIT")))
        '        .StartTime = locStartTime
        '        .EndTime = .StartTime.AddSeconds(CInt(locDataRow("DAUER")))
        '        .ProgramNo = CInt(locDataRow("ARTNR"))
        '        .TotalAmount = CDbl(locDataRow("ZAEHLER"))
        '        Dim locShiftSpan As ShiftTimeSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
        '        If locShiftSpan IsNot Nothing Then
        '            .Shift = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime).ShiftNo
        '        Else
        '            locShiftSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
        '        End If
        '    End With
        '    myCurrFacData.AddProductionDataRow(locFacRow)
        'Next

        Dim oc As New KannegiesserDataContext(ConnectionString)
        Dim sourceDataArticleList = (From artItem In oc.GetArtHist(
                                        CInt(KannegiesserDeviceID),
                                        ProductionDate.Date,
                                        ProductionDate.Date.AddDays(1).AddSeconds(-1))
                                    Where artItem.ArticleID > 0
                                    Order By artItem.StartTime).ToList

        For Each artItem In sourceDataArticleList
            Dim locFacRow As ProductionDataRow
            locFacRow = myCurrFacData.NewProductionDataRow()
            With locFacRow
                .StartTime = artItem.StartTime.Value
                .EndTime = artItem.EndTime.Value
                .ProgramNo = artItem.ArticleID
                .TotalAmount = artItem.Counter.Value
                Dim locShiftSpan As ShiftTimeSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, .StartTime)
                If locShiftSpan IsNot Nothing Then
                    .Shift = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, .StartTime).ShiftNo
                Else
                    locShiftSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, .StartTime)
                End If
            End With
            myCurrFacData.AddProductionDataRow(locFacRow)
        Next
    End Sub
End Class
