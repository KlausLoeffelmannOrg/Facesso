Imports System.Data.SqlClient

Partial Class JensenProductionDataImportTaskElement

    Private Sub retrieveDataForDate(ByVal ProductionDate As Date)

        If JensenSQLConnectionString Is Nothing Then
            Return
        End If

        'Quelldaten für den Tag abrufen
        Dim locConnection As New SqlConnection(JensenSQLConnectionString)
        Dim locSourceData As New DataTable
        Using locConnection
            Dim locAdapter As New SqlDataAdapter("SELECT * FROM [LogData] WHERE " & _
                "(TargetId='" & Me.JensenDeviceID & "') AND" & _
                "([TimeStamp] >= CONVERT(DATETIME,'" & _
                ProductionDate.Date.ToString("MM\-dd\-yyyy") & _
                " 00:00:00', 102) AND [TimeStamp] <= CONVERT(DATETIME,'" & _
                ProductionDate.ToString("MM\-dd\-yyyy") & _
                " 23:59:59', 102)) AND " & _
                "(([Mode]=1 AND [ValueID]=1) OR [Mode]=6)" & _
                " ORDER BY [TargetID],[LineNo],[Mode]", locConnection)
            locAdapter.SelectCommand.CommandTimeout = 120
            Dim locIntBack As Integer = locAdapter.Fill(locSourceData)
        End Using

        'Zieldatentabellenstruktur einrichten
        myCurrFacData = New ProductionDataTable

        'Aktuelle Programmnr.
        Dim locCurrPrgNo As Integer

        'Daten umschaufeln und dabei neu berechnen
        Dim exCollection As String = ""
        Dim exCount As Integer

        For Each locDataRow As DataRow In locSourceData.Rows
            Dim locFacRow As ProductionDataRow = Nothing
            Try
                ''Ist es ein "Programm-Umstell-Datensatz"?
                If CInt(locDataRow("Mode")) = 1 And CInt(locDataRow("ValueID")) = 1 Then
                    'Ja, neue Programmnr. für die nächsten Datensätze
                    locCurrPrgNo = CInt(locDataRow("Value"))
                    'und nächster Datensatz
                    Continue For
                End If

                'Ist es ein Mengen-Datensatz?
                If CInt(locDataRow("Mode")) = 6 And CInt(locDataRow("ValueID")) <> 9 And locCurrPrgNo > 0 Then
                    locFacRow = myCurrFacData.NewProductionDataRow()
                    With locFacRow
                        .StartTime = CDate(locDataRow("TimeStamp"))
                        .EndTime = .StartTime.AddSeconds(1)
                        .ProgramNo = locCurrPrgNo
                        .TotalAmount = CDbl(locDataRow("Value"))
                        .Shift = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, .StartTime).ShiftNo
                    End With
                    myCurrFacData.AddProductionDataRow(locFacRow)
                End If
            Catch ex As Exception
                Try
                    exCollection += "Ausnahme Nr.:" & exCount & vbNewLine
                    exCollection += "Ausnahmetext:" & ex.Message & vbNewLine
                    If locFacRow Is Nothing Then
                        exCollection += "<FacRow> is nothing for TimeStap/Data: " & locDataRow("TimeStamp").ToString & "/" & locDataRow("Value").ToString & vbNewLine
                    Else
                        With locFacRow
                            exCollection += "StartTime/EndTime/ProgramNo/TotalAmount/Shift=" & .StartTime & "/" & .EndTime & "/" & .ProgramNo & "/" & .TotalAmount & "/" & .Shift & vbNewLine
                        End With
                        exCollection &= vbNewLine & vbNewLine
                    End If
                Catch exInner As Exception
                    exCollection += "!!! WARNUNG - In der Ausnahme ist eine weitere Ausnahme aufgetreten !!!"
                    exCollection &= vbNewLine & vbNewLine
                End Try
            End Try
        Next
        If exCollection <> "" Then
            Try
                My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments _
                        & "\" & DateTime.Now.ToString("yymmdd-hhMMss") & "FcExPrt.log", exCollection, False)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Beim Versuch, das Ausnahmebehandlungsprotokoll für den Jensen-Import zu schreiben, ist ein Fehler aufgetreten!" & vbNewLine & vbNewLine & _
                                                     ex.Message, "IO-Fehler!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
            Finally
                Try
                    My.Computer.Clipboard.SetText(exCollection)
                    System.Windows.Forms.MessageBox.Show("Ausnahmen traten beim Jensen-Import-Filter auf; die Texte wurden ins Protokoll und in die Zwischen ablagegeschrieben.", _
                     "Fehler beim Import!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show("Ausnahmen traten beim Jensen-Import-Filter auf; die Ausnahmetexte konnten nicht in die Zwischenablage kopiert werden!", _
                     "Fehler beim Import!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
                End Try
            End Try
        End If
    End Sub
End Class
