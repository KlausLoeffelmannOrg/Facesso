Public Class MonthRangePickerResult

    Private myRangeBase As MonthRangeBase
    Private myMonthBase As RelatedMonth
    Private myFromDate As Date
    Private myToDate As Date

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal RangeBase As MonthRangeBase, ByVal MonthBase As RelatedMonth)
        myRangeBase = RangeBase
        myMonthBase = MonthBase
        SetDateInternal()
    End Sub

    Private Sub SetDateInternal()
        Dim currentDate As Date = Date.Now.AddMonths(-1)
        If RelatedMonth = RelatedMonth.PreviousMonth Then
            currentDate = currentDate.AddMonths(-1)
        ElseIf RelatedMonth = RelatedMonth.SecondLastMonth Then
            currentDate = currentDate.AddMonths(-2)
        End If

        myFromDate = New Date(currentDate.Year, currentDate.Month, 1)
        If MonthRangeBase = MonthRangeBase.FirstToLastPrevious Then
            myToDate = myFromDate.AddMonths(1).AddDays(-1)
        ElseIf MonthRangeBase = MonthRangeBase.FirstToLastCurrent Then
            myFromDate = myFromDate.AddMonths(1)
            myToDate = myFromDate.AddMonths(1).AddDays(-1)
        ElseIf MonthRangeBase = MonthRangeBase.FifteenthToFourteenth Then
            myFromDate = myFromDate.AddDays(14)
            myToDate = myFromDate.AddMonths(1).AddDays(-1)
        ElseIf MonthRangeBase = MonthRangeBase.TenthToNinth Then
            myFromDate = myFromDate.AddDays(9)
            myToDate = myFromDate.AddMonths(1).AddDays(-1)
        ElseIf MonthRangeBase = MonthRangeBase.TwentiethToNineteenth Then
            myFromDate = myFromDate.AddDays(19)
            myToDate = myFromDate.AddMonths(1).AddDays(-1)
        End If
    End Sub

    Public Property MonthRangeBase() As MonthRangeBase
        Get
            Return myRangeBase
        End Get
        Set(ByVal value As MonthRangeBase)
            myRangeBase = value
            SetDateInternal()
        End Set
    End Property

    Public Property RelatedMonth() As RelatedMonth
        Get
            Return myMonthBase
        End Get
        Set(ByVal value As RelatedMonth)
            myMonthBase = value
            SetDateInternal()
        End Set
    End Property

    Public Property ToDate() As Date
        Get
            Return myToDate
        End Get
        Set(ByVal value As Date)
            myToDate = value
        End Set
    End Property

    Public Property FromDate() As Date
        Get
            Return myFromDate
        End Get
        Set(ByVal value As Date)
            myFromDate = value
        End Set
    End Property
End Class

Public Enum MonthRangeBase
    FirstToLastPrevious
    FirstToLastCurrent
    TenthToNinth
    FifteenthToFourteenth
    TwentiethToNineteenth
End Enum

Public Enum RelatedMonth
    CurrentMonth
    PreviousMonth
    SecondLastMonth
End Enum
