Imports Facesso.Data
Imports ActiveDev
Imports System.Data.SqlClient
Imports System.Windows.Forms

Partial Class frmImport

    Private myEmployees As EmployeeInfoItems

    Private Sub AlignTimeData(ByVal timeData As TimeDataTable, ByVal ProductionDate As Date)

        'Als erstes benötigen wir die Workgroup-Infos.

        Dim currentWorkgroup As WorkGroupInfo = Nothing
        Dim timeDataRowCount = 0

        Dim firstShift As Integer
        Dim lastShift As Integer

        'Keine Datenzeilen, dann raus.
        If timeData.Rows.Count = 0 Then Return

        myEmployees = New EmployeeInfoItems(0)

        Dim tsdFirstShift As New TimeSettingDetail
        Dim tsdLastShift As New TimeSettingDetail

        Do
            If timeDataRowCount > (timeData.Rows.Count - 1) Then
                Exit Do
            End If

            Dim timeRow = DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow)

            'Workgroupinfo ermitteln
            Try
                currentWorkgroup = myWorkgroups.GetByWorkGroupNumber(timeRow.WorkgroupNo)
            Catch ex As Exception
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).HasDiscrepancies = True
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).DiscrepanciesText = "Der Produktiv-Site mit dieser Nummer ist in Facesso nicht vorhanden und muss nachgepflegt werden."
                timeDataRowCount += 1
                Continue Do
            End Try

            'Die Textfelder in der Tabelle füllen, damit sie im Report richtig angezeigt werden können.
            DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).WorkgroupDescription = currentWorkgroup.DisplayName
            Try
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).EmployeeDescription = myEmployees.GetByPersonnelNumber(DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).EmployeeNo).DisplayName
            Catch ex As Exception
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).HasDiscrepancies = True
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).DiscrepanciesText = "Der Mitarbeiter mit dieser Personalnummer ist in Facesso nicht vorhanden und muss nachgepflegt werden."
                timeDataRowCount += 1
                Continue Do
            End Try

            'Erste und letzte Schicht ermitteln für diese Arbeitsgruppe ermitteln
            firstShift = 0
            lastShift = 0

            tsdFirstShift = New TimeSettingDetail
            tsdLastShift = New TimeSettingDetail

            For sCount = 1 To 4
                Dim currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, sCount, True)
                If currShift.ImportShiftStart.HasValue Then
                    If firstShift = 0 Then
                        firstShift = sCount
                        tsdFirstShift = currShift
                    End If
                End If
                currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, 5 - sCount, True)
                If currShift.ImportShiftEnd.HasValue Then
                    If lastShift = 0 Then
                        lastShift = 5 - sCount
                        tsdLastShift = currShift
                    End If
                End If
                If firstShift <> 0 AndAlso lastShift <> 0 Then Exit For
            Next

            'Wir haben GAR KEINE Schichtdefinitionen gefunden, so können wir nicht arbeiten...
            If firstShift = 0 AndAlso lastShift = 0 Then
                Throw New ArgumentException("Das Schichtmodell ist nicht korrekt definiert - es gibt für die Arbeitsgruppe " _
                                            & currentWorkgroup.DisplayName & " für " _
                                            & ProductionDate.ToString("dddd, dd.MM.yy") _
                                            & " keine Schichtdefinition.")
            End If

            Dim shiftTimes As New TimePeriodComparer(tsdFirstShift.ImportShiftStart, tsdLastShift.ImportShiftEnd)
            Dim currTimes As New TimePeriodComparer(timeRow.StartTime, timeRow.EndTime)
            Dim oltInfo As OverlappingTimeInfo
            Try
                oltInfo = shiftTimes.OverlappingTimeInfo(currTimes)
            Catch ex As Exception
                MessageBox.Show("Bei der Zeitverteilung auf das Schichtmodell ist ein Fehler aufgetreten." & vbNewLine & _
                                "Möglicherweise ist im Schichtmodell ein Zeitbereich fehlerhaft eingestellt." & vbNewLine & _
                                "Überprüfen Sie das Schichtmodell für den Wochentag " & ProductionDate.ToString("dddd") & " sowie " & _
                                "für die Produktiv-Site " & currentWorkgroup.DisplayName & vbNewLine & vbNewLine, "Fehler im Schichtmodell", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            'Wenn der aktuelle Zeitpunkt außerhalb des gesamten Schichtmodell ist, dann raus damit.
            If oltInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.EndsBefore Or oltInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.StartsAfter Then
                timeData.Rows.RemoveAt(timeDataRowCount)
                Continue Do
            End If

            'Schicht der Startzeit ermitteln
            Dim foundShift = currentWorkgroup.TimeSettingDetails.FindShiftForPeriod(ProductionDate, currTimes.StartTime.Value, currTimes.EndTime.Value)
            If foundShift Is Nothing Then
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).HasDiscrepancies = True
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).DiscrepanciesText = "Dieser Buchungszeitspanne konnte keine Schicht zugewiesen werden."
            Else
                DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).Shift = foundShift.ShiftNo
            End If
            timeDataRowCount += 1
        Loop


        Dim hasDistributedTimes = False
        Dim loopCount = 0

        Do
            timeDataRowCount = 0
            hasDistributedTimes = False
            Do
                If timeDataRowCount > (timeData.Rows.Count - 1) Then
                    Exit Do
                End If

                'Aktuelle typisierte Datenzeile
                Dim timeRow = DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow)

                'Nicht verarbeiten, wenn es bereits Ungereimtheiten gab
                If timeRow.HasDiscrepancies Then
                    timeDataRowCount += 1
                    Continue Do
                End If

                'Workgroupinfo ermitteln
                Try
                    currentWorkgroup = myWorkgroups.GetByWorkGroupNumber(timeRow.WorkgroupNo)
                Catch ex As Exception
                    'TODO: Fehler werfen?
                    Throw ex
                    Continue Do
                End Try

                'Handycap zuordnen
                Try
                    timeRow.Handicap = GetHandicapFromDate(myEmployees.GetByPersonnelNumber(timeRow.EmployeeNo), ProductionDate)
                Catch ex As Exception
                    timeRow.Handicap = 0
                End Try

                'Schichtrahmendaten holen
                Dim currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, timeRow.Shift, True)

                If currShift.ForShift = 0 Then
                    timeDataRowCount += 1
                    Continue Do
                End If

                'Schwellwert ermitteln
                Dim threshold = 0
                If currShift.Threshold.HasValue Then
                    threshold = currShift.Threshold.TypedValue
                End If

                Dim lastShiftTimes As New TimePeriodComparer(tsdLastShift.ImportShiftStart, tsdLastShift.ImportShiftEnd)
                Dim currTimes As New TimePeriodComparer(timeRow.StartTime, timeRow.EndTime)
                'Feststellen, ob der Datensatz nach vorne aufgespalten werden muss
                If timeRow.StartTime < currShift.ImportShiftStart.TypedValue.AddMinutes(-threshold) Then
                    'Zwei Buchungssätze daraus machen
                    Dim additionalRow = timeData.NewTimeDataRow()
                    additionalRow.StartTime = timeRow.StartTime
                    additionalRow.EndTime = currShift.ImportShiftStart
                    additionalRow.Shift = CByte(timeRow.Shift - 1)
                    additionalRow.WorkgroupNo = timeRow.WorkgroupNo

                    'TODO: Überprüfen, ob Pause+Ausfallzeit größer als die Restspanne werden, und falls ja, entsprechend kürzen und Fehler schreiben.
                    'TODO: Ausfallzeit und Pausenzeit zu gleichen Anteilen verteilen.
                    additionalRow.WorkBreak = 0
                    additionalRow.DownTime = 0
                    additionalRow.AlienEmployeeNo = timeRow.AlienEmployeeNo
                    additionalRow.AlienID = timeRow.AlienID
                    additionalRow.EmployeeNo = timeRow.EmployeeNo
                    additionalRow.ID = timeRow.ID
                    additionalRow.HasDiscrepancies = False
                    additionalRow.EmployeeDescription = timeRow.EmployeeDescription
                    additionalRow.WorkgroupDescription = timeRow.WorkgroupDescription

                    If loopCount > 0 Then
                        additionalRow.HasDiscrepancies = True
                        additionalRow.DiscrepanciesText = "Dieser Buchungssatz wurde über mehr als zwei Schichten verteilt. Fehlt evnt. eine Geht-Buchung?"
                    End If

                    If additionalRow.Shift = 0 Then
                        additionalRow.HasDiscrepancies = True
                        additionalRow.DiscrepanciesText &= "Beim Aufteilen eines Buchungssatzes der 1. Schicht, ist diese Buchungszeitanteil aus dem Buchungstag gefallen."
                    End If
                    timeData.Rows.InsertAt(additionalRow, timeDataRowCount)

                    'Bestehenden Datensatz angleichen
                    timeRow.StartTime = currShift.ImportShiftStart
                    hasDistributedTimes = True
                End If

                If (timeRow.EndTime - timeRow.StartTime).TotalHours > 16 Then
                    timeRow.HasDiscrepancies = True
                    timeRow.DiscrepanciesText = "Die ursprünglichen Anfangs- und die Endzeit lagen vor Splittung dieses Buchungssatzes mehr als 16 Stunden auseinander - fehlt eine Geht-Buchung?"
                End If

                'Feststellen, ob der Datensatz nach hinten aufgespalten werden muss

                If timeRow.EndTime > currShift.ImportShiftEnd.TypedValue.AddMinutes(threshold) Then
                    'Aber nur, wenn es nicht die letzte Schicht ist, und nur ein Anteil kleinergleich threashold in der aktuellen Schicht ist.
                    Dim oti = lastShiftTimes.OverlappingTimeInfo(currTimes)
                    If currShift.ForShift < lastShift Or (currShift.ForShift = lastShift And oti.NonOverlappingMinutes < threshold) Then
                        'Zwei Buchungssätze daraus machen
                        Dim additionalRow = timeData.NewTimeDataRow()
                        additionalRow.StartTime = currShift.ImportShiftEnd
                        additionalRow.EndTime = timeRow.EndTime
                        additionalRow.Shift = CByte(timeRow.Shift + 1)
                        additionalRow.WorkgroupNo = timeRow.WorkgroupNo

                        'TODO: Überprüfen, ob Pause+Ausfallzeit größer als die Restspanne werden, und falls ja, entsprechend kürzen und Fehler schreiben.
                        'TODO: Ausfallzeit und Pausenzeit zu gleichen Anteilen verteilen.
                        additionalRow.WorkBreak = 0
                        additionalRow.DownTime = 0
                        additionalRow.AlienEmployeeNo = timeRow.AlienEmployeeNo
                        additionalRow.AlienID = timeRow.AlienID
                        additionalRow.EmployeeNo = timeRow.EmployeeNo
                        additionalRow.ID = timeRow.ID
                        additionalRow.HasDiscrepancies = False
                        additionalRow.EmployeeDescription = timeRow.EmployeeDescription
                        additionalRow.WorkgroupDescription = timeRow.WorkgroupDescription

                        If loopCount > 0 Then
                            additionalRow.HasDiscrepancies = True
                            additionalRow.DiscrepanciesText = "Dieser Buchungssatz wurde über mehr als zwei Schichten verteilt. Fehlt evnt. eine Geht-Buchung?"
                        End If

                        If additionalRow.Shift > lastShift Then
                            additionalRow.Shift = 0
                            additionalRow.HasDiscrepancies = True
                            additionalRow.DiscrepanciesText &= "Beim Aufteilen eines Buchungssatzes der letzten Schicht des Buchungstages, ist diese Buchungszeitanteil aus dem Buchungstag gefallen."
                        End If

                        If timeDataRowCount < (timeData.Rows.Count - 1) Then
                            timeData.Rows.InsertAt(additionalRow, timeDataRowCount + 1)
                        Else
                            timeData.Rows.Add(additionalRow)
                        End If

                        'Bestehenden Datensatz angleichen
                        timeRow.EndTime = currShift.ImportShiftEnd
                        hasDistributedTimes = True
                    Else
                        'Datensatz fliegt raus
                        timeRow.HasDiscrepancies = True
                        timeRow.DiscrepanciesText = "Wird in der nächsten Version rausgeschmissen"
                    End If
                End If

                timeDataRowCount += 1
            Loop
            loopCount += 1
        Loop While hasDistributedTimes

        'Nochmal final alle (vielleicht geplitteten) Buchungen rausschmeißen, die nicht ins Buchungsmodell passen
        timeDataRowCount = 0
        Do
            If timeDataRowCount > (timeData.Rows.Count - 1) Then
                Exit Do
            End If

            Dim timeRow = DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow)

            Dim shiftTimes As New TimePeriodComparer(tsdFirstShift.ImportShiftStart, tsdLastShift.ImportShiftEnd)
            Dim currTimes As New TimePeriodComparer(timeRow.StartTime, timeRow.EndTime)
            Dim oltInfo = shiftTimes.OverlappingTimeInfo(currTimes)

            'Wenn der aktuelle Zeitpunkt außerhalb des gesamten Schichtmodell ist, dann raus damit.
            If oltInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.EndsBefore Or oltInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.StartsAfter Then
                timeData.Rows.RemoveAt(timeDataRowCount)
                Continue Do
            End If

            ''Schicht der Startzeit ermitteln
            'Dim foundShift = currentWorkgroup.TimeSettingDetails.FindShiftForPeriod(ProductionDate, currTimes.StartTime.Value, currTimes.EndTime.Value)
            'If foundShift Is Nothing Then
            '    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).HasDiscrepancies = True
            '    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).DiscrepanciesText = "Dieser Buchungszeitspanne konnte keine Schicht zugewiesen werden."
            'Else
            '    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).Shift = foundShift.ShiftNo
            'End If
            timeDataRowCount += 1
        Loop
    End Sub

    Private Sub ProcessTimeData(ByVal TimeData As TimeDataTable, ByVal ProductionDate As Date, ByVal shift As Integer)

        Dim fdc = New FacessoDataContext(FacessoGeneric.SQLConnectionString)

        Try
            Dim currentTicket As Date? = DateTime.Now

            'Die Daten löschen, die Importiert wurden für diese Schicht
            Dim timesToDelete = (From delItem In fdc.TimeLog _
                          Where delItem.InsertedByInterface And _
                          delItem.ProductionDate = ProductionDate.Date _
                          And delItem.Shift = shift).ToList
 _
            Dim timesToDeleteFiltered = (From delItem In timesToDelete _
                                        Join sourceItem In ucWorkGroups.CheckedWorkGroups On _
                                        delItem.IDWorkGroup Equals sourceItem.IDWorkGroup _
                                        Select delItem).ToList

            For Each logEntry In timesToDeleteFiltered
                fdc.ExecuteCommand("DELETE FROM [TimeLog] WHERE [IDTimeLog]=@p0", New Object() {logEntry.IDTimeLog})
            Next

            For Each timeLogItem As TimeDataRow In TimeData
                'Daten umschaufeln nur für die Schicht und nur wenn es keine Probleme mit diesem Datensatz gab!
                If timeLogItem.Shift = shift And Not timeLogItem.HasDiscrepancies Then
                    fdc.TimeLog_AddItemsForAddEdit(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary, _
                                                    0, FacessoGeneric.LoginInfo.IDUser, _
                                                    myWorkgroups.GetByWorkGroupNumber(timeLogItem.WorkgroupNo).IDWorkGroup, _
                                                    myEmployees.GetByPersonnelNumber(timeLogItem.EmployeeNo).IDEmployee, _
                                                    ProductionDate, CByte(shift), timeLogItem.StartTime, timeLogItem.EndTime, _
                                                    timeLogItem.WorkBreak, timeLogItem.DownTime, If(timeLogItem.Handicap.HasValue, timeLogItem.Handicap, 0), _
                                                    True, False, FacessoGeneric.LoginInfo.IDUser, currentTicket, False)
                End If
            Next

            'Bisherige Änderungen abspeichern
            fdc.TimeLog_HandleAddEdit(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary, _
                                      FacessoGeneric.LoginInfo.IDUser, _
                                      currentTicket)
        Catch ex As Exception
            Dim ret = (fdc.ChangeConflicts).ToList
            For Each item In ret
                Debug.Print(item.Object.ToString)
                Debug.Print(New String("="c, 40))
                For Each item2 In item.MemberConflicts
                    Debug.Print("Member:" & item2.Member.ToString & "OV:" & item2.OriginalValue.ToString & "; " & "CV:" & item2.CurrentValue.ToString)
                Next
            Next
            MessageBox.Show("Beim Übernehmen der Daten ist ein Fehler aufgetreten." & vbNewLine & _
                            ex.Message & vbNewLine & vbNewLine & _
                            ex.StackTrace, "Datenimport:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcessProductionData(ByVal ProdData As ProductionDataTable, ByVal CombinedParameters As CombinedParametersInfo)
        'Die Daten für den Tag und die Arbeitsgruppe ermitteln - falls vorhanden,
        'sonst neue Strukur erzeugen
        Dim locProdInfo As New ProductionData(CombinedParameters)
        Dim locDataChanged As Boolean

        'und nun die neuen Daten konvertiert dort hineinschreiben,
        'dabei darauf achten, dass Daten, deren Originalwerte noch dieselben sind,
        'NICHT überschrieben werden, und dass nur die entsprechende Schicht verarbeitet wird.

        'Default View erstellen, die die Schicht selektiert.
        ProdData.DefaultView.RowFilter = "Shift=" & CombinedParameters.Shift

        For Each locRow As DataRowView In ProdData.DefaultView
            Dim locProdDataItem As ProductionDataItem = Nothing
            Try
                locProdDataItem = locProdInfo.GetItemFromIDLabourValue(CInt(locRow("IDLabourValue")))
            Catch ex As Exception
                ResultMessage &= "Für Produktiv-Site " & CombinedParameters.WorkGroup.ListItemText & _
                                 " konnte am " & CombinedParameters.ProductionDate.ToShortDateString & _
                                 " in Schicht " & CombinedParameters.Shift & _
                                 " die Geräte-ID " & -CInt(locRow("IDLabourValue")) & _
                                 " nicht dem entsprechenden Arbeitswert zugewiesen werden." + vbNewLine
                Continue For
            End Try
            locProdDataItem.AccumulatedAmount += CDbl(locRow("TotalAmount"))
        Next

        For Each locItem As ProductionDataItem In locProdInfo
            'Daten nicht übernehmen, wenn manuell nachgearbeitet wurde,
            'und der ursprünglich gelesene Wert dem jetzigen Wert entspricht.
            If locItem.ManuallyEdited AndAlso _
                (locItem.AmountViaInterface = locItem.AccumulatedAmount) Then
                Continue For
            End If

            locItem.AmountViaInterface = locItem.AccumulatedAmount
            locItem.Amount = locItem.AmountViaInterface
            Debug.Print(locItem.LabourValue.DisplayName & ": " & locItem.Amount)
            locItem.ManuallyEdited = False
            locDataChanged = locDataChanged Or True
        Next

        'Nur speichern, wenn sich überhaupt was geändert hat!
        If locDataChanged Then
            locProdInfo.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
        End If
    End Sub

    Public Shared Function GetHandicapFromDate(ByVal empInfo As EmployeeInfo, ByVal workday As Date) As Double
        Dim selCmd = "select h1.Handicap" & _
                    " from EmployeeHandicaps h1" & _
                    " where h1.ValidFrom=(select MAX(s1.ValidFrom)" & _
                    " from EmployeeHandicaps s1" & _
                    " where s1.ValidFrom<=@Workday" & _
                    " and	h1.IDSubsidiary=s1.IDSubsidiary" & _
                    " and h1.IDEmployee=s1.IDEmployee" & _
                    " )" & _
                    " and h1.IDEmployee=@EMPID" & _
                    " and h1.IDSubsidiary=@SUBSID"

        Dim con As New SqlConnection(FacessoGeneric.SQLConnectionString)
        Using con
            con.Open()
            Dim cmd = con.CreateCommand

            cmd.CommandText = selCmd
            cmd.CommandType = CommandType.Text
            Dim p As New SqlParameter("@SUBSID", empInfo.IDSubsidiary)
            cmd.Parameters.Add(p)
            p = New SqlParameter("@EMPID", empInfo.IDEmployee)
            cmd.Parameters.Add(p)
            p = New SqlParameter("@Workday", workday.Date)
            cmd.Parameters.Add(p)

            Dim res = cmd.ExecuteScalar()
            If res Is Nothing Then
                ' Keine Daten für den MA gefunden
                ' also Handicap 0
                Return 0
            Else
                Return CDbl(res)
            End If
        End Using
    End Function
End Class
