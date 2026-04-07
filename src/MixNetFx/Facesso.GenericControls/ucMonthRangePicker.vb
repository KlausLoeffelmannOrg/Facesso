Public Class ucMonthRangePicker

    Private myMonthRangeResult As MonthRangePickerResult
    Private myFromInner As Boolean

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myMonthRangeResult = New MonthRangePickerResult(MonthRangeBase.FirstToLastPrevious, RelatedMonth.PreviousMonth)
        Me.MonthRangeResult = myMonthRangeResult
        myFromInner = True
        Me.dtpFrom.Value = myMonthRangeResult.FromDate
        Me.dtpTo.Value = myMonthRangeResult.ToDate
        myFromInner = False
        optCurrentMonth.Text = optCurrentMonth.Text.Replace("###", Date.Now.ToString("MMMM"))
        optPreviousMonth.Text = optPreviousMonth.Text.Replace("###", Date.Now.AddMonths(-1).ToString("MMMM"))
        optSecondLastMonth.Text = optSecondLastMonth.Text.Replace("###", Date.Now.AddMonths(-2).ToString("MMMM"))
    End Sub

    Public Property MonthRangeResult() As MonthRangePickerResult
        Get
            myMonthRangeResult.FromDate = dtpFrom.Value
            myMonthRangeResult.ToDate = dtpTo.Value
            Return myMonthRangeResult
        End Get
        Set(ByVal value As MonthRangePickerResult)
            myMonthRangeResult = value
            SetControlsInternal()
        End Set
    End Property

    Private Sub SetControlsInternal()
        optRelatedMonth.Checked = True
        cmbMonthRange.SelectedIndex = myMonthRangeResult.MonthRangeBase
        Select Case myMonthRangeResult.RelatedMonth
            Case RelatedMonth.CurrentMonth
                optCurrentMonth.Checked = True
            Case RelatedMonth.PreviousMonth
                optPreviousMonth.Checked = True
            Case RelatedMonth.SecondLastMonth
                optSecondLastMonth.Checked = True
        End Select
        myFromInner = True
        dtpFrom.Value = myMonthRangeResult.FromDate
        dtpTo.Value = myMonthRangeResult.ToDate
        myFromInner = False
    End Sub

    Public ReadOnly Property DateRangeText() As String
        Get
            With myMonthRangeResult
                Return .FromDate.ToString("dd. MMMM yy") & " - " & .ToDate.ToString("dd. MMMM yy")
            End With
        End Get
    End Property

    Private Sub dtps_ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged, dtpTo.ValueChanged
        If myFromInner Then
            Return
        End If
        optFreeRange.Checked = True
    End Sub

    Private Sub cmbMonthRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonthRange.SelectedIndexChanged
        myMonthRangeResult.MonthRangeBase = CType(cmbMonthRange.SelectedIndex, MonthRangeBase)
        SetControlsInternal()
    End Sub

    Private Sub optRelatedMonth_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCurrentMonth.CheckedChanged, optPreviousMonth.CheckedChanged, optSecondLastMonth.CheckedChanged
        If optCurrentMonth.Checked Then
            myMonthRangeResult.RelatedMonth = RelatedMonth.CurrentMonth
        ElseIf optPreviousMonth.Checked Then
            myMonthRangeResult.RelatedMonth = RelatedMonth.PreviousMonth
        ElseIf optSecondLastMonth.Checked Then
            myMonthRangeResult.RelatedMonth = RelatedMonth.SecondLastMonth
        End If
        SetControlsInternal()
    End Sub
End Class
