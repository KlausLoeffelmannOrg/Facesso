Option Strict On

Imports Facesso.Data
Imports ActiveDev

Public Class LegatroTimeDataTransformation

    Private myProductionDate As Date
    Private myShift As Integer
    Private myLegatroTaskItem As LegatroTimeDataImport

    Private myResultTable As TimeDataTable
    Private myConnectionString As String

    Private myEarliestTime As Date
    Private myLatestTime As Date

    Private myLegatroTimeData As List(Of ViewTimeLogNativeVerbatim)

    Private myConversionItems As FacessoConversionItemsBase

    Sub New(ByVal ProductionDate As Date, ByVal Shift As Integer, ByVal LegatroTaskItem As LegatroTimeDataImport)
        myProductionDate = ProductionDate
        myShift = Shift
        myLegatroTaskItem = LegatroTaskItem
        myConversionItems = LegatroTaskItem.ConversionItems
    End Sub

    Public Sub Convert()
        'Neue Resulttabelle anlegen
        myResultTable = New TimeDataTable

        'ConnectionString setzen
        myConnectionString = myLegatroTaskItem.LegatroSQLConnectionString

        'Die Zeitrahmendaten ermitteln
        myLegatroTimeData = GetLegatroData()

        'Gab keine Zeitdaten für den Zeitbereich, dann und Tschüss.
        If myLegatroTimeData Is Nothing OrElse myLegatroTimeData.Count = 0 Then
            Return
        End If

        'Build Table
        myResultTable = New TimeDataTable
        BuildTableFromLegatroTimeData()

    End Sub

    Private Sub BuildTableFromLegatroTimeData()

        Dim tdb As New TimeDataBuilder
        tdb.CurrentEmployeeNo = -1

        For Each tItem In myLegatroTimeData

            'Employee-Wechsel erkennen
            If tdb.CurrentEmployeeNo <> tItem.PersonnelNumber Then
                'Ist der nunmehr vorherige Mitarbeiter immer noch da?
                If tdb.IsPresent Then
                    tdb.HasDiscrepancies = True
                    tdb.DiscrepanciesText = "Die 'Geht'-Buchung dieses Mitarbeiters für die entsprechende Periode scheint zu fehlen."
                End If

                'Wenn es nicht der erste Mitarbeiter der gesamtverarbeitung war (-1 als Kennzeichen) war, dann diesen speichern.
                If tdb.CurrentEmployeeNo <> -1 Then
                    If tdb.LastWorkgroup <> -1 Then
                        Dim resultRow = NewBookingEntry(tdb, tdb.LastWorksiteChange)
                        myResultTable.Rows.Add(resultRow)
                    End If
                End If

                'Das setzt alle inneren Daten auch zurück!
                tdb.CurrentEmployeeNo = tItem.PersonnelNumber
            End If

            'Und interessieren nur die Arbeitsgruppenwechsel - Startbuchungen sind wurscht.
            If tItem.IsWorksiteChange Then
                Dim tmpWorkgroup = GetWorkgroup(tItem.WorkEntityNumber.Value)
                If Not tdb.IsPresent Then
                    If tmpWorkgroup.HasValue Then
                        tdb.IsPresent = True
                        tdb.LastWorksiteChange = tItem.EventTime.Value
                        tdb.LastWorkgroup = tmpWorkgroup.Value
                    End If
                Else
                    'Arbeitsgruppenwechsel komplett - jetzt müssen wir den Buchungseintrag vornehmen
                    Dim resultRow = NewBookingEntry(tdb, tItem.EventTime.Value)
                    myResultTable.Rows.Add(resultRow)
                    tdb.ResetValues()
                    If tmpWorkgroup.HasValue Then
                        'Alter Endwert ist neuer Startwert!
                        tdb.LastWorksiteChange = tItem.EventTime.Value
                        tdb.LastWorkgroup = tmpWorkgroup.Value
                        tdb.IsPresent = True
                    End If
                End If
            End If

            'Mitarbeiter bucht sich von einer Arbeitsgruppe zurück an die Heimatkostenstelle (über Zwischenbuchung Pause oder Ausfallzeit), 
            'das wird wie ein "Geht" behandelt aus Facesso-Sicht.
            If tItem.BookingType = 1 And Not tItem.WorkEntityNumber.HasValue And tdb.IsPresent Then
                'Arbeitszeitabschnitt komplett - jetzt müssen wir den Buchungseintrag vornehmen
                Dim resultRow = NewBookingEntry(tdb, tItem.EventTime.Value)
                myResultTable.Rows.Add(resultRow)
                tdb.ResetValues()
            End If

            'Mitarbeiter bucht sich wech, durch "Dienstgang" oder "Geht".
            If tItem.BookingType = BookingTypes.Leave Or tItem.BookingType = BookingTypes.OffSiteWork Then
                If tdb.LastWorkgroup > -1 Then
                    If Not tdb.IsPresent Then
                        tdb.HasDiscrepancies = True
                        tdb.DiscrepanciesText = "Die 'Kommt'-Buchung dieses Mitarbeiters für die entsprechende Periode scheint zu fehlen."
                    End If

                    'Arbeitszeitabschnitt komplett - jetzt müssen wir den Buchungseintrag vornehmen
                    Dim resultRow = NewBookingEntry(tdb, tItem.EventTime.Value)
                    myResultTable.Rows.Add(resultRow)
                    tdb.ResetValues()
                End If
            End If

            'Ausfallzeitbuchung:
            If tItem.BookingType = BookingTypes.DownTime Then
                'Mitarbeiter ist nicht angemeldet, dann darf er keine Ausfallzeit buchen.
                If Not tdb.IsPresent Then
                    'Ausfallzeit ohne Anbuchung is nich.
                    GoTo SkipDownTimeProcessing
                End If

                'Ausfallzeit unterbricht eine vorhandene Pause.
                If tdb.IsWorkBreak Then
                    tdb.CurrentWorkBreakDuration += CInt(Math.Round((tItem.EventTime.Value - tdb.LastWorkbreakEvent.Value).TotalMinutes, 0))
                    tdb.LastWorkbreakEvent = Nothing
                End If

                'Nur merken, wenn nicht schon eine Ausfallzeit im Gang war,
                'sonst, also bei zwei AUsfallzeitbuchungen, bleibt die erste
                'Buchung bestehen - die zweite wird ignoriert.
                If Not tdb.IsDownTime Then
                    tdb.LastDowntimeEvent = tItem.EventTime
                End If
SkipDownTimeProcessing:
            End If

            'Pausenbuchung:
            If tItem.BookingType = BookingTypes.WorkBreak Then
                'Mitarbeiter ist nicht angemeldet, dann darf er keine Pause buchen.
                If Not tdb.IsPresent Then
                    'Pause ohne dasein iss nich.
                    GoTo SkipWorkBreakProcessing
                End If

                'Pause unterbricht eine fortlaufende Ausfallzeit.
                If tdb.IsDownTime Then
                    tdb.CurrentDownTimeDuration += CInt(Math.Round((tItem.EventTime.Value - tdb.LastDowntimeEvent.Value).TotalMinutes, 0))
                    tdb.LastDowntimeEvent = Nothing
                End If

                If Not tdb.IsWorkBreak Then
                    tdb.LastWorkbreakEvent = tItem.EventTime
                End If
            End If
SkipWorkBreakProcessing:
        Next
    End Sub

    Private Function NewBookingEntry(ByVal tdBuilder As TimeDataBuilder, ByVal LastEventTime As Date) As TimeDataRow

        'Etwaige Ausfallzeit abschließen
        If tdBuilder.IsDownTime Then
            tdBuilder.CurrentDownTimeDuration += CInt(Math.Round((LastEventTime - tdBuilder.LastDowntimeEvent.Value).TotalMinutes, 0))
            tdBuilder.LastDowntimeEvent = Nothing
        End If

        'Etwaige Pause abschließen
        If tdBuilder.IsWorkBreak Then
            tdBuilder.CurrentWorkBreakDuration += CInt(Math.Round((LastEventTime - tdBuilder.LastWorkbreakEvent.Value).TotalMinutes, 0))
            tdBuilder.LastWorkbreakEvent = Nothing
        End If

        'Ansonsten liefern wir die Ereignisfolge als Buchungssatz zurück.
        Dim tdr = myResultTable.NewTimeDataRow
        With tdr
            .WorkgroupNo = tdBuilder.LastWorkgroup
            .AlienID = tdBuilder.LastWorkgroup
            .AlienEmployeeNo = tdBuilder.CurrentEmployeeNo
            .EmployeeNo = tdBuilder.CurrentEmployeeNo
            .StartTime = tdBuilder.LastWorksiteChange
            .EndTime = LastEventTime
            .Shift = 0 ' Die wird später bestimmt
            .WorkBreak = tdBuilder.CurrentWorkBreakDuration
            .DownTime = tdBuilder.CurrentDownTimeDuration
            .HasDiscrepancies = tdBuilder.HasDiscrepancies
            .DiscrepanciesText = tdBuilder.DiscrepanciesText
        End With
        Return tdr
    End Function

    Private Function GetLegatroData() As List(Of ViewTimeLogNativeVerbatim)
        myEarliestTime = Date.MaxValue
        myLatestTime = Date.MinValue


        'Durch alle betroffenen Produktiv-Sites iterieren und die entsprechenden Schichtdefinitionen dafür finden.
        For Each item In myLegatroTaskItem.ConversionItems()
            If item.HomeElementID > -1 Then
                Dim currentFacWorkgroup = WorkGroupInfo.FromWorkGroupNumber(FacessoGeneric.LoginInfo.IDSubsidiary, item.HomeElementID)
                'Rausfinden, ob durch fehlerhafte Definitionen irgendwelche Zeiten später oder früher sind.
                For tmpShift = 1 To 4
                    Dim shiftStart = currentFacWorkgroup.TimeSettingDetails.GetTimeSettingDetail(myProductionDate, tmpShift, True).ImportShiftStart
                    If shiftStart.HasValue Then
                        If shiftStart.TypedValue < myEarliestTime Then
                            myEarliestTime = shiftStart.TypedValue
                        End If
                    End If

                    Dim shiftEnd = currentFacWorkgroup.TimeSettingDetails.GetTimeSettingDetail(myProductionDate, tmpShift, True).ImportShiftEnd
                    If shiftEnd.HasValue Then
                        If shiftEnd.TypedValue > myLatestTime Then
                            myLatestTime = shiftEnd.TypedValue
                        End If
                    End If
                Next
            End If
        Next

        'Jetzt 12 Stunden vorher und nachher draufpacken, dann haben wir den Zeitbereich, den wir betrachten müssen
        'und falls es in diesem Zeitraum unvollständige Buchungssätze gibt, die innerhalb des Schichtbereichs und
        'deren Schwellwerten fallen, dann handelt es sich wirklich um Buchungsfehler.
        myEarliestTime = myEarliestTime.AddHours(-12)
        myLatestTime = myLatestTime.AddHours(12)
        If myLatestTime > Now Then
            myLatestTime = Now
        End If

        'Jetzt holen wir alle Zeitdaten aus Legatro innerhalb dieses Zeitraums.
        Dim ldc As New LegatroDataContext(myConnectionString)
        Dim myLegatroTimeData = (From items In ldc.ViewTimeLogNativeVerbatim _
                                Where items.EventTime >= myEarliestTime And items.EventTime <= myLatestTime _
                                Order By items.PersonnelNumber Ascending, items.EventTime Ascending).ToList
        Return myLegatroTimeData
    End Function

    ''' <summary>
    ''' Konvertiert eine Workentity aus Legatro in eine Produktiv-Site in Facesso.
    ''' </summary>
    ''' <param name="lastWorkEntity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWorkgroup(ByVal lastWorkEntity As Integer) As Integer?
        For Each eItem In myConversionItems
            If eItem.HomeElementID > -1 Then
                If eItem.AlienElementID = lastWorkEntity Then
                    Return eItem.HomeElementID
                    Exit For
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function ResultTable() As IImportResultTable
        Return myResultTable
    End Function
End Class

Public Structure TimeDataBuilder

    Private myCurrentEmployeeNo As Integer
    Public Property CurrentEmployeeNo() As Integer
        Get
            Return myCurrentEmployeeNo
        End Get
        Set(ByVal value As Integer)
            ResetValues()
            myCurrentEmployeeNo = value
        End Set
    End Property

    Private myLastWorkEntity As Integer
    Public Property LastWorkgroup() As Integer
        Get
            Return myLastWorkEntity
        End Get
        Set(ByVal value As Integer)
            myLastWorkEntity = value
        End Set
    End Property


    Private myIsPresent As Boolean
    Public Property IsPresent() As Boolean
        Get
            Return myIsPresent
        End Get
        Set(ByVal value As Boolean)
            myIsPresent = value
        End Set
    End Property

    Public ReadOnly Property IsDownTime() As Boolean
        Get
            Return LastDowntimeEvent.HasValue
        End Get
    End Property

    Public ReadOnly Property IsWorkBreak() As Boolean
        Get
            Return LastWorkbreakEvent.HasValue
        End Get
    End Property

    Private myLastWorksiteChange As Date
    Public Property LastWorksiteChange() As Date
        Get
            Return myLastWorksiteChange
        End Get
        Set(ByVal value As Date)
            myLastWorksiteChange = value
        End Set
    End Property

    Private myLastWorkbreakEvent As Date?
    Public Property LastWorkbreakEvent() As Date?
        Get
            Return myLastWorkbreakEvent
        End Get
        Set(ByVal value As Date?)
            myLastWorkbreakEvent = value
        End Set
    End Property

    Private myLastDownTimeEvent As Date?
    Public Property LastDowntimeEvent() As Date?
        Get
            Return myLastDownTimeEvent
        End Get
        Set(ByVal value As Date?)
            myLastDownTimeEvent = value
        End Set
    End Property

    Private myCurrentWorkBreakDuration As Integer
    Public Property CurrentWorkBreakDuration() As Integer
        Get
            Return myCurrentWorkBreakDuration
        End Get
        Set(ByVal value As Integer)
            myCurrentWorkBreakDuration = value
        End Set
    End Property

    Private myCurrentDownTimeDuration As Integer
    Public Property CurrentDownTimeDuration() As Integer
        Get
            Return myCurrentDownTimeDuration
        End Get
        Set(ByVal value As Integer)
            myCurrentDownTimeDuration = value
        End Set
    End Property

    Dim myHasDiscrepancies As Boolean
    Public Property HasDiscrepancies() As Boolean
        Get
            Return myHasDiscrepancies
        End Get
        Set(ByVal value As Boolean)
            myHasDiscrepancies = value
        End Set
    End Property

    Private myDiscrepanciesText As String
    Public Property DiscrepanciesText() As String
        Get
            Return myDiscrepanciesText
        End Get
        Set(ByVal value As String)
            myDiscrepanciesText = value
        End Set
    End Property

    Public Sub ResetValues()
        IsPresent = False
        LastDowntimeEvent = Nothing
        LastWorkbreakEvent = Nothing
        LastWorkgroup = -1
        LastWorksiteChange = Date.MinValue
        DiscrepanciesText = Nothing
        HasDiscrepancies = False
    End Sub
End Structure