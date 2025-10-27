Public Class TimePeriodComparer
    Implements IComparable, ICloneable

    Sub New(ByVal startTime As Date?, ByVal endtime As Date?)
        Me.StartTime = startTime
        Me.EndTime = endtime
    End Sub

    Public ReadOnly Property TimeSpan() As TimeSpan?
        Get
            If (Not EndTime.HasValue) Or (Not StartTime.HasValue) Then
                Return Nothing
            Else
                Return EndTime - StartTime
            End If
        End Get
    End Property

    Public ReadOnly Property IsEndtimePriorToStartTime() As Boolean?
        Get
            If (Not EndTime.HasValue Or Not StartTime.HasValue) Then
                Return Nothing
            End If
            Return EndTime < StartTime
        End Get
    End Property

    Public Function IsIn(ByVal pointOfTime As Date) As Boolean?
        If (Not EndTime.HasValue) Or (Not StartTime.HasValue) Then
            Return False
        End If
        Return (pointOfTime >= Me.StartTime And pointOfTime <= Me.EndTime)
    End Function

    Public Function InsertOrCloseSimpleEvent(ByVal pointOfTime As Date) As List(Of TimePeriodComparer)
        ''List<TimePeriodBase>
        Dim retTimeSpans As New List(Of TimePeriodComparer)

        If (Not StartTime.HasValue And Not EndTime.HasValue) Then Return Nothing

        'Closing: Endzeit wird ergänzt
        If (StartTime.HasValue And Not EndTime.HasValue And pointOfTime > StartTime.Value) Then
            retTimeSpans.Add(New TimePeriodComparer(StartTime, pointOfTime))
            Return retTimeSpans
        End If

        'Closing:Startzeit wird ergänzt
        If (Not StartTime.HasValue And EndTime.HasValue And pointOfTime < EndTime.Value) Then
            retTimeSpans.Add(New TimePeriodComparer(pointOfTime, EndTime))
            Return retTimeSpans
        End If

        'Ist nicht in der Zeitspanne -->ergibt nichts.
        If (Not Me.IsIn(pointOfTime)) Then Return Nothing

        'Zeitpunkt ist einer der Grenzwerte, dann gibt es nur ein Element zurpck
        If ((pointOfTime = Me.StartTime.Value) Or (pointOfTime = Me.EndTime.Value)) Then
            retTimeSpans.Add(Me)
            Return retTimeSpans
        End If

        'Sonst wird es in zwei Elemente aufgeteilt
        retTimeSpans.Add(New TimePeriodComparer(Me.StartTime, pointOfTime))
        retTimeSpans.Add(New TimePeriodComparer(pointOfTime, Me.EndTime))
        Return retTimeSpans

    End Function

    Public Function OverlappingTimeInfo(ByVal timePeriod As TimePeriodComparer) As OverlappingTimeInfo
        'die zu vergleichende Zeitspanne darf nicht null sein
        If timePeriod Is Nothing Then
            Throw New ArgumentException("Overlapping minutes can't be calculated if instance is null!")
        End If

        'die zu vergleichende Zeitspanne darf nicht null sien
        If (Not timePeriod.StartTime.HasValue) And (Not timePeriod.EndTime.HasValue) Then
            Throw New ArgumentException("Overlapping minutes can't be calculated if instance is null!")
        End If

        'Wenn diese Instanz einen offenen Wert hat, kann nicht verglichen werden
        If (Not Me.StartTime.HasValue) Or (Not Me.EndTime.HasValue) Then
            Return New OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.NotDefinable)
        End If

        If (Not timePeriod.StartTime.HasValue) Then
            Return New OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.OpenStart)
        End If

        If (Not timePeriod.EndTime.HasValue) Then
            Return New OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.OpenEnd)
        End If

        If (timePeriod.IsEndtimePriorToStartTime.Value Or Me.IsEndtimePriorToStartTime.Value) Then
            Throw New ArgumentOutOfRangeException("Endtime can't be prior to Starttime!")
        End If

        'Zu vergleichende Zeitspanne endet vor dieser Zeitspanne -->keine Überlappung
        If (timePeriod.EndTime.Value < Me.StartTime.Value) Then
            Return New OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.EndsBefore)
        End If

        'Zu vergleichende Zeitspanne beginnt nach dieser Zeitspanne -->keine Überlappung
        If (timePeriod.StartTime.Value >= EndTime.Value) Then
            Return New OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.StartsAfter)
        End If

        'Zu vergleichende Zeitspanne liegt genau in dieser Zeitspanne -->Überlappung ist zu vergleichende Zeitspanne
        If ((timePeriod.StartTime.Value >= Me.StartTime.Value) And (timePeriod.EndTime.Value <= Me.EndTime.Value)) Then
            Dim tmpTotalInnerMinutes As Double = (timePeriod.EndTime.Value - timePeriod.StartTime.Value).TotalMinutes
            Return New OverlappingTimeInfo(tmpTotalInnerMinutes, (Me.EndTime.Value - Me.StartTime.Value).TotalMinutes - tmpTotalInnerMinutes, TimeSpanOverlappingTypes.IsInside)
        End If

        'Zu vergleichende Zeitspanne beginnt in dieser Zeitspanne endet aber außerhalb -->Überlapppung!
        If (timePeriod.StartTime.Value >= Me.StartTime.Value) And (timePeriod.StartTime.Value <= EndTime.Value) Then
            Dim tmpOverlappingMinutes As Double = (Me.EndTime.Value - timePeriod.StartTime.Value).TotalMinutes
            Return New OverlappingTimeInfo(tmpOverlappingMinutes, (timePeriod.EndTime.Value - Me.EndTime.Value).TotalMinutes, TimeSpanOverlappingTypes.StartsInside)
        End If

        'Zu vergleichende Zeitspanne endet in dieser Zeitspanne, beginnt aber außerhalb -->Überlappung!
        If (timePeriod.EndTime.Value <= Me.EndTime.Value) And (timePeriod.EndTime.Value >= StartTime.Value) Then
            Dim tmpOverlappingMinutes As Double = (timePeriod.EndTime.Value - Me.StartTime.Value).TotalMinutes
            Return New OverlappingTimeInfo(tmpOverlappingMinutes, (Me.StartTime.Value - timePeriod.StartTime.Value).TotalMinutes, TimeSpanOverlappingTypes.EndsInside)
        End If

        'zu vergleichende Zeitspanne klammert diese Zeitspanne ein
        If (timePeriod.StartTime.Value < Me.StartTime.Value) And (timePeriod.EndTime.Value > Me.EndTime.Value) Then
            Dim tmpTotalInnerMinutes As Double = (Me.EndTime.Value - Me.StartTime.Value).TotalMinutes
            Return New OverlappingTimeInfo(tmpTotalInnerMinutes, (timePeriod.EndTime.Value - timePeriod.StartTime.Value).TotalMinutes - tmpTotalInnerMinutes, TimeSpanOverlappingTypes.IncludesCompletely)
        End If

        Throw New ArgumentException("This case schouldn't actually get reached! :-)")
    End Function

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If (obj.GetType() IsNot GetType(TimeSpan?)) And (obj.GetType() IsNot GetType(TimePeriodComparer)) Then
            Throw New ArgumentException("Argument must be of type Nullable<System.TimeSpan> or EventTimeSpan", "obj")
        End If


        Dim tmpTimeSpan As TimeSpan?

        If (obj.GetType() Is GetType(TimeSpan?)) Then
            tmpTimeSpan = DirectCast(obj, TimeSpan)
        Else
            tmpTimeSpan = (DirectCast(obj, TimePeriodComparer)).TimeSpan
        End If

        If tmpTimeSpan.HasValue And Me.TimeSpan.HasValue Then
            Return Me.TimeSpan.Value.CompareTo(tmpTimeSpan.Value)
        End If

        If Me.TimeSpan.HasValue And (Not tmpTimeSpan.HasValue) Then
            Return 1
        End If

        If (Not Me.TimeSpan.HasValue And tmpTimeSpan.HasValue) Then
            Return -1
        End If

        'Beide !HasValue
        Return 0
    End Function
#Region "Eigenschaften"

    Private myStartTime As Date?
    Public Property StartTime() As Date?
        Get
            Return myStartTime
        End Get
        Set(ByVal value As Date?)
            myStartTime = value
        End Set
    End Property

    Private myEndTime As Date?
    Public Property EndTime() As Date?
        Get
            Return myEndTime
        End Get
        Set(ByVal value As Date?)
            myEndTime = value
        End Set
    End Property

    Private myTag As Object
    Public Property Tag() As Object
        Get
            Return myTag
        End Get
        Set(ByVal value As Object)
            myTag = value
        End Set
    End Property

#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

Public Structure OverlappingTimeInfo

    Private myOverlappingMinutes As Double
    Private myNonOverlappingMinutes As Double
    Private myTimeSpanOverlappingType As TimeSpanOverlappingTypes

    Sub New(ByVal overlappingMinutes As Double, ByVal nonOverlappingMinutes As Double, ByVal timeSpanOverlappingType As TimeSpanOverlappingTypes)
        myOverlappingMinutes = overlappingMinutes
        myNonOverlappingMinutes = nonOverlappingMinutes
        myTimeSpanOverlappingType = timeSpanOverlappingType
        myTag = Nothing
    End Sub

    Public Property OverlappingMinutes() As Double
        Get
            Return myOverlappingMinutes
        End Get
        Set(ByVal value As Double)
            myOverlappingMinutes = value
        End Set
    End Property

    Public Property NonOverlappingMinutes() As Double
        Get
            Return myNonOverlappingMinutes
        End Get
        Set(ByVal value As Double)
            myNonOverlappingMinutes = value
        End Set
    End Property

    Public Property TimeSpanOverlappingType() As TimeSpanOverlappingTypes
        Get
            Return myTimeSpanOverlappingType
        End Get
        Set(ByVal value As TimeSpanOverlappingTypes)
            myTimeSpanOverlappingType = value
        End Set
    End Property

    Private myTag As Object
    Public Property Tag() As Object
        Get
            Return myTag
        End Get
        Set(ByVal value As Object)
            myTag = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("Overlapping:{0:#,##0}min;Nonoverlapping:{1:#,##0}min,Type:{2]", OverlappingMinutes, NonOverlappingMinutes, TimeSpanOverlappingType)
    End Function
End Structure

Public Enum TimeSpanOverlappingTypes
    NotDefinable
    EndsBefore
    StartsAfter
    IncludesCompletely
    IsInside
    EndsInside
    StartsInside
    OpenStart
    OpenEnd
End Enum
