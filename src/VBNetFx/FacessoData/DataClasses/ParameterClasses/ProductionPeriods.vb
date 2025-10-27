Imports ActiveDev
Imports System.Collections.ObjectModel
Imports System.Globalization

Public Class ProductionPeriod
    Inherits Collection(Of ProductionPeriodItem)

    Private _StartDate As Date
    Private _EndDate As Date
    Private _ShiftParameters As ShiftParameters

    Public Sub New(ByVal CertainDate As Date, ByVal CertainShift As Byte)
        MyBase.New()
        CertainDate = CertainDate.Date
        _StartDate = CertainDate
        _EndDate = CertainDate
        Dim locProductionPeriodItem As New ProductionPeriodItem(CertainDate, CertainShift)
        Me.Add(locProductionPeriodItem)
    End Sub

    ''' <summary>
    ''' Erstellt einen neuen Produktionsdaten-Auswertungszeitraum über alle Schichten im entsprechenden Zeitraum
    ''' </summary>
    ''' <param name="Startdate">Das Anfangsdatum des Auswertungszeitraums</param>
    ''' <param name="EndDate">Das Enddatum des Auswertungszeitraums</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Startdate As Date, ByVal EndDate As Date)
        MyBase.new()
        Startdate = Startdate.Date
        EndDate = EndDate.Date
        _StartDate = Startdate
        _EndDate = EndDate
        For locDouble As Double = Startdate.ToOADate To EndDate.ToOADate
            For locShift As Byte = 1 To 4
                Dim locProductionPeriodItem As New ProductionPeriodItem(Date.FromOADate(locDouble), locShift)
                Me.Add(locProductionPeriodItem)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Erstellt einen neuen Produktionsdaten-Auswertungszeitraum über eine bestimmte Schicht im entsprechenden Zeitraum
    ''' </summary>
    ''' <param name="Startdate">Das Anfangsdatum des Auswertungszeitraums</param>
    ''' <param name="EndDate">Das Enddatum des Auswertungszeitraums</param>
    ''' <param name="Shift">Die zu berücksichtigende Schicht</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Startdate As Date, ByVal EndDate As Date, ByVal Shift As Byte)
        Me.New(Startdate, EndDate, Shift, Shift, 1)
    End Sub

    ''' <summary>
    ''' Erstellt einen neuen Produktionsdaten-Auswertungszeitraum über eine oder mehrere, im Bedarfsfall alle X Tage wechselnde Schicht im entsprechenden Zeitraum
    ''' </summary>
    ''' <param name="DateRange">Bestimmt den Zeitraum.</param>
    ''' <param name="Shifts">Bestimmt die Schichten und, falls gewünscht, nach wievielen Tagen diese wechseln sollen.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal DateRange As DateRangeParameter, ByVal Shifts As ShiftParameters)
        MyBase.New()
        _StartDate = DateRange.StartDate.Date
        _EndDate = DateRange.EndDate.Date
        _ShiftParameters = Shifts

        Dim locShiftDaysChangeCount As Integer = 0
        Dim locShiftChangeFlag As Boolean = False
        For locDouble As Double = _StartDate.ToOADate To _EndDate.ToOADate
            If Not Shifts.AlternateShifts Then
                If Shifts.ConsiderShift1 Then Me.Add(New ProductionPeriodItem(Date.FromOADate(locDouble), 1))
                If Shifts.ConsiderShift2 Then Me.Add(New ProductionPeriodItem(Date.FromOADate(locDouble), 2))
                If Shifts.ConsiderShift3 Then Me.Add(New ProductionPeriodItem(Date.FromOADate(locDouble), 3))
                If Shifts.ConsiderShift4 Then Me.Add(New ProductionPeriodItem(Date.FromOADate(locDouble), 4))
            Else
                Dim locProductionPeriodItem As New ProductionPeriodItem(Date.FromOADate(locDouble), CByte(IIf(locShiftChangeFlag, Shifts.AlternatingFirstShift, Shifts.AlternatingSecondShift)))
                locShiftDaysChangeCount += 1
                If locShiftDaysChangeCount > 0 Then
                    If locShiftDaysChangeCount = Shifts.DaysAfterToAlternate Then
                        locShiftChangeFlag = locShiftChangeFlag Xor True
                    End If
                Else
                    If Weekday(Date.FromOADate(locDouble), FirstDayOfWeek.Monday) = -locShiftDaysChangeCount Then
                        locShiftChangeFlag = locShiftChangeFlag Xor True
                    End If
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Erstellt einen neue Produktionsdaten-Auswertungszeitraum auf Basis der angegebenen Parameter.
    ''' </summary>
    ''' <param name="StartDate">Das Anfangsdatum des Auswertungszeitraums (inklusive).</param>
    ''' <param name="EndDate">Das Enddatum des Auswertungszeitraums (inklusive)</param>
    ''' <param name="AlternatingShift1">Die erste alterierende Schicht</param>
    ''' <param name="AlternatingShift2">Die zweite alternierende Schicht</param>
    ''' <param name="ShiftChangeAfterDays">Positiv: Die Anzahl der Tage, nachdem die Schichtnummern getauscht werden. Negativ: Die (negative) Wochentagsnummer, an der die Schichtnummern getauscht werden.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AlternatingShift1 As Byte, ByVal AlternatingShift2 As Byte, ByVal ShiftChangeAfterDays As Integer)
        MyBase.new()
        StartDate = StartDate.Date
        EndDate = EndDate.Date
        _StartDate = StartDate
        _EndDate = EndDate
        Dim locShiftDaysChangeCount As Integer = 0
        Dim locShiftChangeFlag As Boolean = False
        For locDouble As Double = StartDate.ToOADate To EndDate.ToOADate
            Dim locProductionPeriodItem As New ProductionPeriodItem(Date.FromOADate(locDouble), CByte(IIf(locShiftChangeFlag, AlternatingShift2, AlternatingShift1)))
            locShiftDaysChangeCount += 1
            If locShiftDaysChangeCount > 0 Then
                If locShiftDaysChangeCount = ShiftChangeAfterDays Then
                    locShiftChangeFlag = locShiftChangeFlag Xor True
                End If
            Else
                If Weekday(Date.FromOADate(locDouble), FirstDayOfWeek.Monday) = -locShiftDaysChangeCount Then
                    locShiftChangeFlag = locShiftChangeFlag Xor True
                End If
            End If
        Next
    End Sub

    Public Sub PrepareProductionDates(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, ByVal Ticket As Date)
        SPAccess.GetInstance.ProductionData_PrepareProductionDates(IDSubsidiary, IDUser, Ticket, Me)
    End Sub

    Public ReadOnly Property StartDate() As Date
        Get
            Return _StartDate
        End Get
    End Property

    Public ReadOnly Property EndDate() As Date
        Get
            Return _EndDate
        End Get
    End Property

    Public ReadOnly Property RangeDescription() As String
        Get
            If StartDate = EndDate Then
                If CultureInfo.CurrentUICulture.TwoLetterISOLanguageName = "de" Then
                    Return "Am " & StartDate.ToLongDateString
                Else
                    Return "On " & StartDate.ToLongDateString
                End If
            Else
                If CultureInfo.CurrentUICulture.TwoLetterISOLanguageName = "de" Then
                    Return "Von " & StartDate.ToLongDateString & " bis " & EndDate.ToLongDateString
                Else
                    Return "From " & StartDate.ToLongDateString & " to " & EndDate.ToLongDateString
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property StartDateMonthDescription() As String
        Get
            Return StartDate.ToString("MMMM yyyy")
        End Get
    End Property

    Public ReadOnly Property ShiftParameters() As ShiftParameters
        Get
            Return _ShiftParameters
        End Get
    End Property

End Class

Public Structure DateRangeParameter
    Private myDateRangePreset As DateRangePresets
    Private myStartDate As Date
    Private myEndDate As Date
    Private myMonthIntoPast As Integer
    Private myLastWorkingDay As LastWorkingdays

    Public Sub New(ByVal DateRangePreset As DateRangePresets, ByVal LastWorkingDay As LastWorkingdays)
        myLastWorkingDay = LastWorkingDay
        Me.DateRangePreset = DateRangePreset
    End Sub

    Public Sub New(ByVal DateRangePreset As DateRangePresets)
        Me.DateRangePreset = DateRangePreset
    End Sub

    Public Sub New(ByVal DateRangePreset As DateRangePresets, ByVal MonthIntoPast As Integer)
        myMonthIntoPast = MonthIntoPast
        Me.DateRangePreset = DateRangePreset
    End Sub

    Public Sub New(ByVal Startdate As Date, ByVal Enddate As Date)
        myDateRangePreset = DateRangePresets.CustomPeriod
        myStartDate = Startdate
        myEndDate = Enddate
    End Sub

    Public Property LastWorkingday() As LastWorkingdays
        Get
            Return myLastWorkingday
        End Get
        Set(ByVal value As LastWorkingdays)
            myLastWorkingday = value
        End Set
    End Property

    Public Property DateRangePreset() As DateRangePresets
        Get
            Return myDateRangePreset
        End Get
        Set(ByVal value As DateRangePresets)
            Select Case value
                Case DateRangePresets.YesterdayOrLastWorkingDay
                    If Date.Now.Date.DayOfWeek = DayOfWeek.Monday Then
                        If LastWorkingday = LastWorkingdays.Sunday Then
                            myStartDate = Date.Now.Date.AddDays(-1)
                        ElseIf LastWorkingday = LastWorkingdays.Saturday Then
                            myStartDate = Date.Now.Date.AddDays(-2)
                        Else
                            myStartDate = Date.Now.Date.AddDays(-3)
                        End If
                    Else
                        myStartDate = Date.Now.Date.AddDays(-1)
                    End If
                    myEndDate = myStartDate
                Case DateRangePresets.FromStartOfCurrentMonthToNow
                    myStartDate = Dates.FirstDayOfMonth(Date.Now.Date)
                    myEndDate = Date.Now.Date
                Case DateRangePresets.FromStartOfCurrentWeekToNow
                    myStartDate = Dates.MondayOfWeek(Date.Now.Date)
                    myEndDate = Date.Now.Date
                Case DateRangePresets.FromStartToEndOfSpecifiedMonth
                    If myMonthIntoPast = -1 Then
                        myMonthIntoPast = 0
                    End If
                    myStartDate = Dates.FirstDayOfMonth(Date.Now.AddMonths(-MonthIntoPast))
                    myEndDate = Dates.LastDayOfMonth(Date.Now.AddMonths(-MonthIntoPast))
                Case DateRangePresets.LastWeek
                    myStartDate = Dates.MondayOfWeek(Date.Now.Date).AddDays(-7)
                    myEndDate = myStartDate.AddDays(7)
                Case DateRangePresets.Today
                    myStartDate = Date.Now.Date
                    myEndDate = myStartDate
                Case DateRangePresets.SinceYearBeganToNow
                    myStartDate = New Date(Date.Now.Year, 1, 1)
                    myEndDate = Date.Now.Date
                Case DateRangePresets.WeekBeforeLastWeek
                    myStartDate = Dates.MondayOfWeek(Date.Now.Date).AddDays(-14)
                    myEndDate = myStartDate.AddDays(7)
            End Select
            myDateRangePreset = value
        End Set
    End Property

    Public Property MonthIntoPast() As Integer
        Get
            Return myMonthIntoPast
        End Get
        Set(ByVal value As Integer)
            myMonthIntoPast = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return myStartDate
        End Get
        Set(ByVal value As Date)
            myStartDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return myEndDate
        End Get
        Set(ByVal value As Date)
            myEndDate = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim locString As String = ""
        Select Case myDateRangePreset
            Case DateRangePresets.CustomPeriod
                locString = "Freidefinierter Zeitraum."
            Case DateRangePresets.FromStartOfCurrentMonthToNow
                locString = "Vom Anfang des aktuellen Monats bis heute."
            Case DateRangePresets.FromStartOfCurrentWeekToNow
                locString = "Vom Anfang der aktuellen Woche bis heute."
            Case DateRangePresets.FromStartToEndOfSpecifiedMonth
                locString = "Vom Anfang bis zum Ende des Monats " & StartDate.ToString("MMMM yyyy") & "."
            Case DateRangePresets.LastWeek
                locString = "Die letzte Woche."
            Case DateRangePresets.SinceYearBeganToNow
                locString = "Von Anfang des laufenden Jahres bis heute."
            Case DateRangePresets.Today
                locString = "Heute."
            Case DateRangePresets.WeekBeforeLastWeek
                locString = "Die vorletzte Woche."
            Case DateRangePresets.YesterdayOrLastWorkingDay
                locString = "Gestern."
        End Select
        locString &= vbNewLine
        If StartDate = EndDate Then
            locString &= "Aus heutiger Sicht ist das am " & StartDate.ToLongDateString
        Else
            locString &= "Aus heutiger Sicht ist das vom " & StartDate.ToLongDateString & " bis " & EndDate.ToLongDateString
        End If
        Return locString
    End Function
End Structure

Public Enum LastWorkingdays
    Friday
    Saturday
    Sunday
End Enum

Public Enum DateRangePresets
    CustomPeriod = 0
    FromStartOfCurrentMonthToNow
    FromStartToEndOfSpecifiedMonth
    SinceYearBeganToNow
    FromStartOfCurrentWeekToNow
    LastWeek
    YesterdayOrLastWorkingDay
    Today
    WeekBeforeLastWeek
End Enum
