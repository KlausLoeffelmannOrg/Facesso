Imports System.Data.OleDb

Partial Class KannegiesserProductionDataImportTaskElement

    Private Sub retrieveDataForDate(ByVal ProductionDate As Date)

        If PathToDeviceData Is Nothing Then
            Return
        End If

        'Quelldaten f¸r den Tag abrufen
        Dim locConnection As New OleDbConnection(ConnectionString)

        Dim locSourceData As new DataTable
        Using locConnection
            Dim locAdapter As New OleDbDataAdapter("SELECT * FROM PROTOKOL WHERE DATUM=" & _
                    ProductionDate.ToString("\#MM\/dd\/yyyy\#") & _
                    " AND TYP=0 AND ARTNR>0", locConnection)
            'Falls das eine Exception wirft, dann den BDE (Paradox-Treiber) installieren.
            'Der ist nicht mehr erh‰ltlich, heiﬂt bde.exe ist im Install-Verzeichnis auf
            'dem Server, ca. 5 MByte groﬂ.
            Dim locIntBack As Integer = locAdapter.Fill(locSourceData)
        End Using

        'Zieldatentabellenstruktur einrichten
        myCurrFacData = New ProductionDataTable

        'Daten umschaufeln und dabei neu berechnen
        For Each locDataRow As DataRow In locSourceData.Rows
            Dim locFacRow As ProductionDataRow
            locFacRow = myCurrFacData.NewProductionDataRow()
            With locFacRow
                Dim locStartTime As DateTime = ProductionDate.AddSeconds(CInt(locDataRow("STARTZEIT")))
                .StartTime = locStartTime
                .EndTime = .StartTime.AddSeconds(CInt(locDataRow("DAUER")))
                .ProgramNo = CInt(locDataRow("ARTNR"))
                .TotalAmount = CDbl(locDataRow("ZAEHLER"))
                Dim locShiftSpan As ShiftTimeSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
                If locShiftSpan IsNot Nothing Then
                    .Shift = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime).ShiftNo
                Else
                    locShiftSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
                End If
            End With
            myCurrFacData.AddProductionDataRow(locFacRow)
        Next
    End Sub
End Class
