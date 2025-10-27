Imports ActiveDev
Imports Facesso.Data
Imports System.ComponentModel

Public Class ucAnalysisDateRangePicker

    Private myDateRangeValue As DateRangeParameter
    Private myDoNothing As Boolean
    Private myLastWorkingday As LastWorkingdays

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        myDoNothing = True
        InitializeComponent()
        myDoNothing = False
        myLastWorkingday = LastWorkingdays.Friday

        ' Add any initialization after the InitializeComponent() call.
        cmbMonthsHistory.Items.Add("Laufender Monat (" & MonthText(0) & ")")
        cmbMonthsHistory.Items.Add("Letzter Monat (" & MonthText(1) & ")")
        For c As Integer = 2 To 24
            cmbMonthsHistory.Items.Add("Vor " & c & " Monaten (" & MonthText(c) & ")")
        Next
        DateRangeValue = New DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, 1)
        myDateRangeValue.LastWorkingday = LastWorkingdays.Friday

    End Sub

    Private Function MonthText(ByVal MonthsIntoPast As Integer) As String
        Dim locStartDate As Date
        locStartDate = Dates.LastDayOfMonth(Date.Now).AddMonths(-MonthsIntoPast)
        Return locStartDate.ToString("MMM, yyyy")
    End Function

    Public Property DateRangeValue() As DateRangeParameter
        Get
            Return myDateRangeValue
        End Get
        Set(ByVal value As DateRangeParameter)
            myDateRangeValue = value
            UpdateUI()
        End Set
    End Property

    Public Property LastWorkingday() As LastWorkingdays
        Get
            Return myLastWorkingday
        End Get
        Set(ByVal value As LastWorkingdays)
            myLastWorkingday = value
            myDateRangeValue.LastWorkingday = value
        End Set
    End Property

    Private Sub UpdateUI()
        myDoNothing = True
        Select Case myDateRangeValue.DateRangePreset
            Case DateRangePresets.CustomPeriod
                optCustomPeriod.Checked = True
                myDoNothing = False
                Return
            Case DateRangePresets.YesterdayOrLastWorkingDay
                optYesterday.Checked = True
            Case DateRangePresets.FromStartOfCurrentMonthToNow
                optFromStartOfCurrentMonthToNow.Checked = True
            Case DateRangePresets.FromStartOfCurrentWeekToNow
                optFromStartOfCurrentWeekToNow.Checked = True
            Case DateRangePresets.FromStartToEndOfSpecifiedMonth
                cmbMonthsHistory.SelectedIndex = DateRangeValue.MonthIntoPast
            Case DateRangePresets.LastWeek
                optLastWeek.Checked = True
            Case DateRangePresets.Today
                optToday.Checked = True
            Case DateRangePresets.SinceYearBeganToNow
                optSinceYearBegan.Checked = True
            Case Else
                optWeekBeforeLastWeek.Checked = True
        End Select
        dtpStart.Value = myDateRangeValue.StartDate
        dtpEnd.Value = myDateRangeValue.EndDate
        myDoNothing = False
    End Sub

    Private Sub dtpStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStart.ValueChanged
        If myDoNothing Then
            Return
        End If
        If dtpStart.Value > dtpEnd.Value Then
            dtpEnd.Value = dtpStart.Value
        End If
        DateRangeValue = New DateRangeParameter(dtpStart.Value, dtpEnd.Value)
    End Sub

    Private Sub dtpEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEnd.ValueChanged
        If myDoNothing Then
            Return
        End If
        If dtpStart.Value > dtpEnd.Value Then
            dtpStart.Value = dtpEnd.Value
        End If
        DateRangeValue = New DateRangeParameter(dtpStart.Value, dtpEnd.Value)
    End Sub

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
     EditorBrowsable(EditorBrowsableState.Always)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        gbTitle.Text = Me.Text
    End Sub

    Private Sub optDateRanges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles optYesterday.CheckedChanged, optFromStartOfCurrentMonthToNow.CheckedChanged, _
        optFromStartOfCurrentWeekToNow.CheckedChanged, optStartToEndOfSpecifiedMonth.CheckedChanged, _
         optLastWeek.CheckedChanged, _
        optToday.CheckedChanged, optSinceYearBegan.CheckedChanged, _
        optWeekBeforeLastWeek.CheckedChanged

        If myDoNothing Then Return

        If optYesterday.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.YesterdayOrLastWorkingDay, Me.LastWorkingday)
        ElseIf optFromStartOfCurrentMonthToNow.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.FromStartOfCurrentMonthToNow)
        ElseIf optFromStartOfCurrentWeekToNow.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.FromStartOfCurrentWeekToNow)
        ElseIf optStartToEndOfSpecifiedMonth.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, cmbMonthsHistory.SelectedIndex)
        ElseIf optLastWeek.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.LastWeek)
        ElseIf optToday.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.Today)
        ElseIf optSinceYearBegan.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.SinceYearBeganToNow)
        ElseIf optWeekBeforeLastWeek.Checked Then
            DateRangeValue = New DateRangeParameter(DateRangePresets.WeekBeforeLastWeek)
        ElseIf optCustomPeriod.Checked Then
            DateRangeValue = New DateRangeParameter(dtpStart.Value, dtpEnd.Value)
        End If
    End Sub

    Private Sub cmbMonthsHistory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonthsHistory.SelectedIndexChanged
        If Not optStartToEndOfSpecifiedMonth.Checked Then
            optStartToEndOfSpecifiedMonth.Checked = True
        Else
            DateRangeValue = New DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, cmbMonthsHistory.SelectedIndex)
        End If
    End Sub

    Private Sub gbTitle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbTitle.Enter

    End Sub
End Class
