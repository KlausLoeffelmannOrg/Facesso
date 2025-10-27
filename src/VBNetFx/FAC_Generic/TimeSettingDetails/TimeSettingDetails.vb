Option Infer On
Option Strict On

Imports System.IO
Imports ActiveDev
Imports System.Xml.Serialization

<Serializable()> _
Public Class TimeSettingDetails
    Private myGenericTimeSettingDetails(4) As TimeSettingDetail
    Private myTimeSettingDetail(28) As TimeSettingDetail
    Private myFallBackStartTime As Date
    Private myFallBackEndTime As Date
    Private myNextShiftStart As Date

    Sub New()
        CreateObjects()
    End Sub

    Sub New(ByVal Shift1Start As Date, _
            ByVal Shift2Start As Date, _
            ByVal Shift3Start As Date, ByVal Shift3End As Date, _
            ByVal Shift4Start As ADDBNullable(Of Date), ByVal Shift4End As ADDBNullable(Of Date), _
            ByVal StandardPauseTime As ADDBNullable(Of Integer))
        myGenericTimeSettingDetails(0) = New TimeSettingDetail(Shift1Start, Shift2Start, StandardPauseTime, _
                                         2, TimeSettingDetailsWeekdays.ForAll, 1)

        myGenericTimeSettingDetails(1) = New TimeSettingDetail(Shift2Start, Shift3Start, StandardPauseTime, _
                                         3, TimeSettingDetailsWeekdays.ForAll, 2)


        myGenericTimeSettingDetails(2) = New TimeSettingDetail(Shift3Start, Shift3End, StandardPauseTime, _
                                         Nothing, TimeSettingDetailsWeekdays.ForAll, 3)

        myGenericTimeSettingDetails(3) = New TimeSettingDetail(Shift4Start, Shift4End, StandardPauseTime, _
                                         Nothing, TimeSettingDetailsWeekdays.ForAll, 4)
        CreateObjects(myGenericTimeSettingDetails)
    End Sub

    Private Sub CreateObjects()
        Dim locTSD As New TimeSettingDetail
        CreateObjects(locTSD)
    End Sub

    Private Sub CreateObjects(ByVal tsdTemplate As TimeSettingDetail)
        For z As Integer = 0 To 3
            myGenericTimeSettingDetails(z) = tsdTemplate.Clone(z + 1, TimeSettingDetailsWeekdays.ForAll)
        Next
        CreateObjects(myGenericTimeSettingDetails)
    End Sub

    Private Sub CreateObjects(ByVal tsdTemplates As TimeSettingDetail())
        For i As Integer = 0 To 3
            For j As Integer = 0 To 6
                myTimeSettingDetail(i * 7 + j) = tsdTemplates(i).Clone(i + 1, CType(j + 1, TimeSettingDetailsWeekdays))
                myTimeSettingDetail(i * 7 + j).IsDerived = True
            Next
        Next
    End Sub

    Public Function Clone() As TimeSettingDetails
        Dim locClone As New TimeSettingDetails
        For i As Integer = 0 To 3
            locClone.myGenericTimeSettingDetails(i) = Me.myGenericTimeSettingDetails(i).Clone
            For j As Integer = 0 To 6
                locClone.myTimeSettingDetail(i * 7 + j) = Me.myTimeSettingDetail(i * 7 + j).Clone
            Next
        Next
        Return locClone
    End Function

    Public Property GenericTimeSettingDetail() As TimeSettingDetail()
        Get
            Return myGenericTimeSettingDetails
        End Get
        Set(ByVal value As TimeSettingDetail())
            myGenericTimeSettingDetails = value
        End Set
    End Property

    Public Property TimeSettingDetail() As TimeSettingDetail()
        Get
            Return myTimeSettingDetail
        End Get
        Set(ByVal value As TimeSettingDetail())
            myTimeSettingDetail = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt die Schicht-Parameter aufgrund eines gegebenen Datums und der Schichtnummer (1-4).
    ''' </summary>
    ''' <param name="workdate">Arbeitsdatum, zu dem die Schichtparameter ermittelt werden sollen.</param>
    ''' <param name="Shift">Die Schicht-Nummer, zu der die Schichtparameter ermittelt werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks>Die Schicht-Start und End-Werte werden relativ zum 1.1.2003 angegeben.</remarks>
    Public Function GetTimeSettingDetail(ByVal WorkDate As Date, ByVal Shift As Integer) As TimeSettingDetail
        Dim locDay As Integer = Weekday(WorkDate, FirstDayOfWeek.Monday) - 1
        Return TimeSettingDetail((Shift - 1) * 7 + locDay)
    End Function

    ''' <summary>
    ''' Ermittelt die Schicht-Parameter aufgrund eines gegebenen Datums und der Schichtnummer (1-4) und gleicht sie optional 
    ''' an das workdate Datum an.
    ''' </summary>
    ''' <param name="workdate">Arbeitsdatum, zu dem die Schichtparameter ermittelt werden sollen.</param>
    ''' <param name="Shift">Die Schicht-Nummer, zu der die Schichtparameter ermittelt werden sollen.</param>
    ''' <param name="AlignedToCurrentDate">Bestimmt, ob die Schichtparameter (ShiftStart, End, ImportedShiftStart, End) an das 
    ''' workdate angepasst werden sollen (true) oder nicht.</param>
    ''' <returns></returns>
    ''' <remarks>Die Schicht-Start und End-Werte werden relativ zum 1.1.2003 angegeben, wenn für AlignToCurrentDaten false übergeben wird.</remarks>
    Public Function GetTimeSettingDetail(ByVal workdate As Date, ByVal Shift As Integer, ByVal AlignedToCurrentDate As Boolean) As TimeSettingDetail
        If Not AlignedToCurrentDate Then
            Return GetTimeSettingDetail(workdate, Shift)
        End If

        Dim retTimeSettingDetail As TimeSettingDetail
        retTimeSettingDetail = GetTimeSettingDetail(workdate, Shift).Clone
        Dim difToBaseDate = workdate.Date - #1/1/2003#
        If retTimeSettingDetail.ImportShiftStart.HasValue Then
            retTimeSettingDetail.ImportShiftStart = retTimeSettingDetail.ImportShiftStart.TypedValue.Add(difToBaseDate)
        End If

        If retTimeSettingDetail.ImportShiftEnd.HasValue Then
            retTimeSettingDetail.ImportShiftEnd = retTimeSettingDetail.ImportShiftEnd.TypedValue.Add(difToBaseDate)
        End If

        If retTimeSettingDetail.ShiftStart.HasValue Then
            retTimeSettingDetail.ShiftStart = retTimeSettingDetail.ShiftStart.TypedValue.Add(difToBaseDate)
        End If

        If retTimeSettingDetail.ShiftEnd.HasValue Then
            retTimeSettingDetail.ShiftEnd = retTimeSettingDetail.ShiftEnd.TypedValue.Add(difToBaseDate)
        End If

        Return retTimeSettingDetail
    End Function

    Public Shared Function FromXmlString(ByVal xmlString As String) As TimeSettingDetails
        Dim locXml As New XmlSerializer(GetType(TimeSettingDetails))
        Dim locSr As New StringReader(xmlString)
        Return DirectCast(locXml.Deserialize(locSr), TimeSettingDetails)
    End Function

    Public Function XMLString() As String
        Dim locXml As New XmlSerializer(GetType(TimeSettingDetails))
        Dim locSw As New StringWriter()
        locXml.Serialize(locSw, Me)
        Return locSw.ToString
    End Function

    Public Function DistributeTimes(ByVal StartTime As Date, ByVal EndTime As Date) As TimeSplitDataTable
        Dim locCurrStart As Date = StartTime
        'Dim locCurrEnd As Date
        Dim locTimes As New TimeSplitDataTable()
        Return locTimes
    End Function

    Public Function FindShiftForPeriod(ByVal Proddate As Date, ByVal StartTime As Date, ByVal EndTime As Date) As ShiftTimeSpan
        'Wir testen alle drei Schichtdefinitionen aus, und überprüfen, in welchem der Modelle
        'a) die meiste Überlappung vorliegt
        Dim currentTsd As TimeSettingDetail

        Dim bookingRange As New TimePeriodComparer(StartTime, EndTime)
        Dim longestTimeInShift As New ShiftTimeSpan

        'Erste und letzte Schicht dieses Tages finden
        'Erste und letzte Schicht ermitteln für diese Arbeitsgruppe ermitteln
        Dim firstShift = 0
        Dim lastShift = 0

        Dim tsdFirstShift = New TimeSettingDetail
        Dim tsdLastShift = New TimeSettingDetail

        For sCount = 1 To 4
            Dim currShift = GetTimeSettingDetail(Proddate, sCount, True)
            If currShift.ImportShiftStart.HasValue Then
                If firstShift = 0 Then
                    firstShift = sCount
                    tsdFirstShift = currShift
                End If
            End If
            currShift = GetTimeSettingDetail(Proddate, 5 - sCount, True)
            If currShift.ImportShiftEnd.HasValue Then
                If lastShift = 0 Then
                    lastShift = 5 - sCount
                    tsdLastShift = currShift
                End If
            End If
            If firstShift <> 0 AndAlso lastShift <> 0 Then Exit For
        Next

        For shiftCount As Byte = CByte(firstShift) To CByte(lastShift)
            currentTsd = GetTimeSettingDetail(Proddate, shiftCount, True)

            Dim shiftRange As New TimePeriodComparer(currentTsd.ImportShiftStart, currentTsd.ImportShiftEnd)
            Dim overlapInfo = shiftRange.OverlappingTimeInfo(bookingRange)

            If overlapInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.EndsBefore Or overlapInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.StartsAfter Then
                'Zeitspanne ist gar nicht drin: --> Ergebnis interessiert uns nicht.
                Continue For
            End If

            If overlapInfo.TimeSpanOverlappingType = TimeSpanOverlappingTypes.IncludesCompletely Then
                'Die Zeitspanne befindet sich komplett im Schichtmodell, wir sind fertig!
                longestTimeInShift.OverlappingTime = CInt(overlapInfo.OverlappingMinutes)
                longestTimeInShift.ShiftNo = shiftCount
                GoTo SkipToReturnValue
            End If

            'Den Schichtbereich finden, in der sich der Mitarbeiter überwiegend aufgehalten hat.
            If overlapInfo.OverlappingMinutes > longestTimeInShift.OverlappingTime Then
                longestTimeInShift.OverlappingTime = CInt(overlapInfo.OverlappingMinutes)
                longestTimeInShift.ShiftNo = shiftCount
            End If
        Next

        If longestTimeInShift.OverlappingTime = 0 Then
            Return Nothing
        End If

SkipToReturnValue:
        currentTsd = GetTimeSettingDetail(Proddate, longestTimeInShift.ShiftNo, True)
        Return New ShiftTimeSpan(Proddate, longestTimeInShift.ShiftNo, currentTsd.ShiftStart, currentTsd.ShiftEnd)

    End Function

    ''' <summary>
    ''' Ermittelt iterativ die Schicht für eine bestimmte Zeit und berücksichtigt dabei Fallbackzeiten und Schwellzeit der 1. Schicht.
    ''' </summary>
    ''' <param name="ProdDate">Datum, für das gesucht werden soll.</param>
    ''' <param name="StartTime">Die Startzeit, die der Schicht zugeordnet werden soll.</param>
    ''' <returns>ShiftTimeSpan-Objekt, das Info über die gefundene Schicht enthält.</returns>
    ''' <remarks></remarks>
    Public Function FindShiftForStartTime(ByVal ProdDate As Date, ByVal StartTime As Date) As ShiftTimeSpan
        Dim locProductionDate As Date = StartTime.Date
        Dim locTimeSettingDetail As TimeSettingDetail = GetTimeSettingDetail(locProductionDate, 1)
        Dim locShift1Date As Date = locTimeSettingDetail.ImportShiftStart.TypedValue.Date
        Dim locOffset As TimeSpan = locProductionDate.Subtract(locShift1Date)

        For locShift As Byte = 1 To 4
            locTimeSettingDetail = GetTimeSettingDetail(locProductionDate, locShift)
            Dim locThreshold As Integer

            'Für den Fall, dass bestimmte Schichtzeiten NICHT definiert sind,
            'muss es eine "nicht-nulle" Ausweichmöglichkeit geben, damit es bei
            'einer Datenübername, die einen nicht-null-Zeitpunkt zur Schichtermittelung
            'erwartet, nicht knallt. Das ist entweder die nicht-nulle erste Schicht
            'oder eine Fallback-Zeit, die dann in der lokalen Registry geändert 
            'werden kann!
            If locShift = 1 Then
                Try
                    myFallBackStartTime = locTimeSettingDetail.ImportShiftStart.TypedValue
                    myFallBackEndTime = locTimeSettingDetail.ImportShiftEnd.TypedValue
                Catch ex As Exception
                    myFallBackStartTime = FacessoGeneric.FallbackStartTime
                    myFallBackEndTime = FacessoGeneric.FallbackEndTime
                End Try
                'Für die erste Schicht: Schwellzeit nach unten, damit "frühe" Datenübernahmen
                'nicht zu Datenverlust führen.
                myNextShiftStart = myFallBackStartTime.AddMinutes(-FacessoGeneric.FirstShiftThresholdInMin)
            End If

            'Keine Angabe für Schwelle abfangen
            If locTimeSettingDetail.Threshold.IsNull Then
                locThreshold = 0
            Else
                locThreshold = locTimeSettingDetail.Threshold
            End If

            'Zu vergleichender Schichtstart: Untere Schwelle mit einbeziehen
            Dim locShiftStart, locShiftEndUnaligned, locShiftEnd As Date

            'Zeitenverkettung!
            locShiftStart = myNextShiftStart.AddMinutes(-CInt(locThreshold)).Add(locOffset)
            Try
                locShiftEnd = locTimeSettingDetail.ImportShiftEnd.TypedValue
                locShiftEndUnaligned = locShiftEnd
                locShiftEnd = locShiftEnd.Add(locOffset)
            Catch ex As Exception
                locShiftEnd = myFallBackEndTime
                locShiftEndUnaligned = locShiftEnd
                locShiftEnd = locShiftEnd.Add(locOffset)
            End Try
            If locShiftEnd < locShiftStart Then
                locShiftEnd.AddHours(7)
                locShiftEndUnaligned.AddHours(7)
            End If

            'Rückgabewert
            Dim retShiftTimeSpan As ShiftTimeSpan = Nothing

            'Haben wir die Schicht schon gefunden?
            If StartTime >= locShiftStart And StartTime <= locShiftEnd Then
                'Ja - das ist der Rückgabewert...
                retShiftTimeSpan = New ShiftTimeSpan(locProductionDate, locShift, locShiftStart, locShiftEnd)
            End If
            myNextShiftStart = locShiftEndUnaligned
            If retShiftTimeSpan IsNot Nothing Then
                '...und wir steigen aus der "Schichtfindungsschleife" aus,
                'wenn der Rückgabewert nicht Null ist.
                Return retShiftTimeSpan
            End If
            'Anderenfalls schauen wir, ob wir die Schicht nicht
            'doch noch ermitteln können.
        Next
        Return Nothing
    End Function
End Class

<Serializable()> _
Public Class TimeSettingDetail
    Private myShiftStart As ADDBNullable(Of Date)
    Private myShiftEnd As ADDBNullable(Of Date)
    'Geändert am 30.11.2005
    Private myImportShiftStart As ADDBNullable(Of Date)
    Private myImportShiftEnd As ADDBNullable(Of Date)

    Private myRoundUpBefore As ADDBNullable(Of Date)
    Private myRoundDownAfter As ADDBNullable(Of Date)
    Private myPauseTime As ADDBNullable(Of Integer)
    Private myThreshold As ADDBNullable(Of Integer)
    Private myForceToHavePause As Boolean
    Private myChainEndTimeTo As ADDBNullable(Of Integer)
    Private mySpecialShiftIsShift4 As Boolean
    Private myIsDerived As Boolean
    Private myForWeekday As TimeSettingDetailsWeekdays
    Private myForShift As Integer

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal ShiftStart As ADDBNullable(Of Date), ByVal ShiftEnd As ADDBNullable(Of Date), ByVal PauseTime As ADDBNullable(Of Integer), _
            ByVal ChainEndTimeTo As ADDBNullable(Of Integer), ByVal ForWeekDay As TimeSettingDetailsWeekdays, _
            ByVal forShift As Integer)
        myShiftStart = ShiftStart
        myShiftEnd = ShiftEnd

        'Geändert am 30.11.2005
        myImportShiftStart = ShiftStart
        myImportShiftEnd = ShiftEnd

        myChainEndTimeTo = ChainEndTimeTo
        myForWeekday = ForWeekDay
        myForShift = forShift
        myPauseTime = PauseTime
    End Sub

    <XmlIgnore()> _
    Public Property ShiftStart() As ADDBNullable(Of Date)
        Get
            Return myShiftStart
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myShiftStart = value
        End Set
    End Property

    Public Property XMLShiftStart() As Date
        Get
            Return CDate(IIf(myShiftStart.IsNull, #12:00:00 AM#, myShiftStart.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myShiftStart = Nothing
            Else
                myShiftStart = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property ShiftEnd() As ADDBNullable(Of Date)
        Get
            Return myShiftEnd
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myShiftEnd = value
        End Set
    End Property

    Public Property XMLShiftEnd() As Date
        Get
            Return CDate(IIf(myShiftEnd.IsNull, #12:00:00 AM#, myShiftEnd.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myShiftEnd = Nothing
            Else
                myShiftEnd = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property ImportShiftStart() As ADDBNullable(Of Date)
        Get
            Return myImportShiftStart
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myImportShiftStart = value
        End Set
    End Property

    Public Property XMLImportShiftStart() As Date
        Get
            Return CDate(IIf(myImportShiftStart.IsNull, #12:00:00 AM#, myImportShiftStart.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myImportShiftStart = Nothing
            Else
                myImportShiftStart = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property ImportShiftEnd() As ADDBNullable(Of Date)
        Get
            Return myImportShiftEnd
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myImportShiftEnd = value
        End Set
    End Property

    Public Property XMLImportShiftEnd() As Date
        Get
            Return CDate(IIf(myImportShiftEnd.IsNull, #12:00:00 AM#, myImportShiftEnd.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myImportShiftEnd = Nothing
            Else
                myImportShiftEnd = value
            End If
        End Set
    End Property


    <XmlIgnore()> _
    Public Property RoundUpBefore() As ADDBNullable(Of Date)
        Get
            Return myRoundUpBefore
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myRoundUpBefore = value
        End Set
    End Property

    Public Property XMLShiftRoundUpBefore() As Date
        Get
            Return CDate(IIf(myRoundUpBefore.IsNull, #12:00:00 AM#, myRoundUpBefore.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myRoundUpBefore = Nothing
            Else
                myRoundUpBefore = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property RoundDownAfter() As ADDBNullable(Of Date)
        Get
            Return myRoundDownAfter
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            myRoundDownAfter = value
        End Set
    End Property

    Public Property XMLRoundDownAfter() As Date
        Get
            Return CDate(IIf(myRoundUpBefore.IsNull, #12:00:00 AM#, myRoundUpBefore.Value))
        End Get
        Set(ByVal value As Date)
            If value = #12:00:00 AM# Then
                myRoundDownAfter = Nothing
            Else
                myRoundDownAfter = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property WorkBreak() As ADDBNullable(Of Integer)
        Get
            Return myPauseTime
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            myPauseTime = value
        End Set
    End Property

    Public Property XMLPauseTime() As Integer
        Get
            Return CInt(IIf(myPauseTime.IsNull, -1, myPauseTime.Value))
        End Get
        Set(ByVal value As Integer)
            If value = -1 Then
                myPauseTime = Nothing
            Else
                myPauseTime = value
            End If
        End Set
    End Property

    <XmlIgnore()> _
    Public Property Threshold() As ADDBNullable(Of Integer)
        Get
            Return myThreshold
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            myThreshold = value
        End Set
    End Property

    Public Property XMLThreshold() As Integer
        Get
            Return CInt(IIf(myThreshold.IsNull, -1, myThreshold.Value))
        End Get
        Set(ByVal value As Integer)
            If value = -1 Then
                myThreshold = Nothing
            Else
                myThreshold = value
            End If
        End Set
    End Property

    Public Property ForceToHavePause() As Boolean
        Get
            Return myForceToHavePause
        End Get
        Set(ByVal value As Boolean)
            myForceToHavePause = value
        End Set
    End Property

    <XmlIgnore()> _
    Public Property ChainEndTimeTo() As ADDBNullable(Of Integer)
        Get
            Return myChainEndTimeTo
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            myChainEndTimeTo = value
        End Set
    End Property

    Public Property XMLChainEndTimeTo() As Integer
        Get
            Return CInt(IIf(myChainEndTimeTo.IsNull, -1, myChainEndTimeTo.Value))
        End Get
        Set(ByVal value As Integer)
            If value = -1 Then
                myChainEndTimeTo = Nothing
            Else
                myChainEndTimeTo = value
            End If
        End Set
    End Property

    Public Property IsDerived() As Boolean
        Get
            Return myIsDerived
        End Get
        Set(ByVal value As Boolean)
            myIsDerived = value
        End Set
    End Property

    Public Property ForWeekday() As TimeSettingDetailsWeekdays
        Get
            Return myForWeekday
        End Get
        Set(ByVal value As TimeSettingDetailsWeekdays)
            myForWeekday = value
        End Set
    End Property

    Public Property ForShift() As Integer
        Get
            Return myForShift
        End Get
        Set(ByVal value As Integer)
            myForShift = value
        End Set
    End Property

    Public Function Clone() As TimeSettingDetail
        Dim locTSD As New TimeSettingDetail
        With locTSD
            .ChainEndTimeTo = Me.ChainEndTimeTo
            .ForceToHavePause = Me.ForceToHavePause
            .ForShift = Me.ForShift
            .ForWeekday = Me.ForWeekday
            .IsDerived = True
            .WorkBreak = Me.WorkBreak
            .RoundDownAfter = Me.RoundDownAfter
            .RoundUpBefore = Me.RoundUpBefore
            .ShiftEnd = Me.ShiftEnd
            .ShiftStart = Me.ShiftStart
            .ImportShiftStart = Me.ImportShiftStart
            .ImportShiftEnd = Me.ImportShiftEnd
            .Threshold = Me.Threshold
        End With
        Return locTSD
    End Function

    Public Sub NullAll()
        With Me
            .ChainEndTimeTo = Nothing
            .ForceToHavePause = False
            .ForShift = 0
            .ForWeekday = Nothing
            .IsDerived = False
            .WorkBreak = Nothing
            .RoundDownAfter = Nothing
            .RoundUpBefore = Nothing
            .ShiftEnd = Nothing
            .ShiftStart = Nothing
            .ImportShiftEnd = Nothing
            .ImportShiftStart = Nothing
            .Threshold = Nothing
        End With
    End Sub

    Public Function Clone(ByVal ForShift As Integer, ByVal ForWeekday As TimeSettingDetailsWeekdays) As TimeSettingDetail
        Dim locTSD As TimeSettingDetail
        locTSD = Me.Clone
        locTSD.ForShift = ForShift
        locTSD.ForWeekday = ForWeekday
        Return locTSD
    End Function

    Public Function IsEqual(ByVal tsd As TimeSettingDetail) As Boolean
        With tsd
            If .ChainEndTimeTo <> Me.ChainEndTimeTo Then Return False
            If .ForceToHavePause <> Me.ForceToHavePause Then Return False
            If .ForShift <> Me.ForShift Then Return False
            'If .ForWeekday <> Me.ForWeekday Then Return False
            If .WorkBreak <> Me.WorkBreak Then Return False
            If .RoundDownAfter <> Me.RoundDownAfter Then Return False
            If .RoundUpBefore <> Me.RoundUpBefore Then Return False
            If .ShiftEnd <> Me.ShiftEnd Then Return False
            If .ShiftStart <> Me.ShiftStart Then Return False
            If .ImportShiftEnd <> Me.ImportShiftEnd Then Return False
            If .ImportShiftStart <> Me.ImportShiftStart Then Return False
            If .Threshold <> Me.Threshold Then Return False
            Return True
        End With
    End Function

    Public Overrides Function ToString() As String
        Dim locString As String
        locString = "S:" & Me.ForShift.ToString("0")
        If Me.ShiftStart.HasValue Then
            locString &= "    S: " & Me.ShiftStart.TypedValue.ToString("HH:mm (dd)") & _
                        "    E: " & Me.ShiftEnd.TypedValue.ToString("HH:mm (dd)")
        Else
            locString &= "    S: --:-- (--)    E: --:-- (--)"
        End If

        If Me.ImportShiftStart.HasValue Then
            locString &= "   IS:" & Me.ImportShiftStart.TypedValue.ToString("HH:mm (dd)")
        Else
            locString &= "   IS:" & "--:-- (--)"
        End If

        If Me.ImportShiftEnd.HasValue Then
            locString &= "   IE:" & Me.ImportShiftEnd.TypedValue.ToString("HH:mm (dd)") & "     "
        Else
            locString &= "   IE:" & "--:-- (--)" & "     "
        End If

        Dim locWeekday As String = Me.ForWeekday.ToString
        If My.Application.Culture.Name.StartsWith("de") Then
            Select Case Me.ForWeekday
                Case TimeSettingDetailsWeekdays.ForAll
                    locWeekday = "Für alle Wochentage"
                Case TimeSettingDetailsWeekdays.Friday
                    locWeekday = "Für freitags"
                Case TimeSettingDetailsWeekdays.Monday
                    locWeekday = "Für montags"
                Case TimeSettingDetailsWeekdays.Saturday
                    locWeekday = "Für samstags"
                Case TimeSettingDetailsWeekdays.Sunday
                    locWeekday = "Für sonntags"
                Case TimeSettingDetailsWeekdays.Thursday
                    locWeekday = "Für donnerstags"
                Case TimeSettingDetailsWeekdays.Tuesday
                    locWeekday = "Für dienstags"
                Case TimeSettingDetailsWeekdays.Wednesday
                    locWeekday = "Für mittwochs"
            End Select
        End If
        locString &= locWeekday
        Return locString
    End Function
End Class

<Serializable()> _
Public Enum TimeSettingDetailsWeekdays
    ForAll = 0
    Monday
    Tuesday
    Wednesday
    Thursday
    Friday
    Saturday
    Sunday
End Enum

Public Class ShiftTimeSpan
    Private myProductionDate As Date
    Private myShift As Byte
    Private myShiftStart As Date
    Private myShiftEnd As Date
    Private myOverlappingTime As Integer
    Private myDistanceToAStartTime As Integer

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal ProductionDate As Date, ByVal Shift As Byte, ByVal ShiftStart As Date, ByVal ShiftEnd As Date)
        myProductionDate = ProductionDate
        myShift = Shift
        myShiftStart = ShiftStart
        myShiftEnd = ShiftEnd
    End Sub

    Public Property ProductionDate() As Date
        Get
            Return myProductionDate
        End Get
        Set(ByVal value As Date)
            myProductionDate = value
        End Set
    End Property

    Public Property ShiftNo() As Byte
        Get
            Return myShift
        End Get
        Set(ByVal value As Byte)
            myShift = value
        End Set
    End Property

    Public Property ShiftStart() As Date
        Get
            Return myShiftStart
        End Get
        Set(ByVal value As Date)
            myShiftStart = value
        End Set
    End Property

    Public Property ShiftEnd() As Date
        Get
            Return myShiftEnd
        End Get
        Set(ByVal value As Date)
            myShiftEnd = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt oder bestimmt die Anzahl von Minuten, die eine andere Zeitspanne diesen Schichtbereich überlappt.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Dient nur zum Zurückliefern von Vergleichszeiträumen beim Ermitteln einer Schicht von 
    ''' einem beliebigen Zeitbereich und hat nur informativen und parameter-tragenden Wert.</remarks>
    Public Property OverlappingTime() As Integer
        Get
            Return myOverlappingTime
        End Get
        Set(ByVal value As Integer)
            myOverlappingTime = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt oder bestimmt die Anzahl von Minuten, deren Startzeitpunkt einer anderen Zeitspanne vom Schichtbeginn entfernt ist.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Dient nur zum Zurückliefern von Vergleichszeiträumen beim Ermitteln einer Schicht von 
    ''' einem beliebigen Zeitbereich und hat nur informativen und parameter-tragenden Wert.</remarks>
    Public Property DistanceToAStartTime() As Integer
        Get
            Return myDistanceToAStartTime
        End Get
        Set(ByVal value As Integer)
            myDistanceToAStartTime = value
        End Set
    End Property
End Class
