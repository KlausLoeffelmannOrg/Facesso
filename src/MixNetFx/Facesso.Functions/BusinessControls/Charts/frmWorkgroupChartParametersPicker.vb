Imports ActiveDev
Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmWorkgroupChartParametersPicker

    Private myAnalysisParameters As WorkGroupAnalysisParameters
    Private myFacessoGeneralOptions As FacessoGeneralOptions
    Private myAllWorkgroups As WorkGroupInfoItems
    Private myIgnoreNextTextChange As Boolean
    Private myHasChangedManually As Boolean

    Private Const MINIMUM_CHART_DELTA As Integer = 30
    Private Const INITIAL_FROM_VALUE_FOR_CHART_DELTA As Integer = 80
    Private Const INITIAL_TO_VALUE_FOR_CHART_DELTA As Integer = 140

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myFacessoGeneralOptions = DirectCast( _
                FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
                New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)

        myAllWorkgroups = New WorkGroupInfoItems(True)
        wglWorkgroups.WorkGroupInfoItems = myAllWorkgroups
        For Each locItem As ListViewItem In wglWorkgroups.Items
            locItem.Selected = True
        Next

        If myFacessoGeneralOptions.SaturdayIsWorkday Then
            Me.drpMain.LastWorkingday = LastWorkingdays.Saturday
        ElseIf myFacessoGeneralOptions.SundayIsWorkday Then
            Me.drpMain.LastWorkingday = LastWorkingdays.Sunday
        End If
    End Sub

    Public Function GetAnalysisParameters() As WorkGroupAnalysisParameters
        'Default-Einstellungen übertragen
        ToAnalysisParameters()
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myAnalysisParameters
        Else
            Return Nothing
        End If
    End Function

    Public Function GetAnalysisParameters(ByVal wgap As WorkGroupAnalysisParameters) As WorkGroupAnalysisParameters
        myAnalysisParameters = wgap
        FromAnalysisParameters()
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myAnalysisParameters
        Else
            Return Nothing
        End If
    End Function

    Private Sub myWizardController_Finished(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim locDR As DialogResult = MessageBox.Show("Möchten Sie die Auswertung durchführen (Abbrechen kehrt zurück zum Ausgangsdialog)?", _
        '            "Auswertung durchführen?", MessageBoxButtons.YesNoCancel)
        'If locDR = Windows.Forms.DialogResult.Cancel Then
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'ElseIf locDR = Windows.Forms.DialogResult.Yes Then
        '    ToAnalysisParameters()
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'End If
    End Sub

    Private Sub ToAnalysisParameters()
        If myAnalysisParameters Is Nothing Then
            myAnalysisParameters = New WorkGroupAnalysisParameters()
        End If

        With myAnalysisParameters
            .DateRange = drpMain.DateRangeValue
            .ShiftParameters = New ShiftParameters(chkShift1.Checked, chkShift2.Checked, chkShift3.Checked, _
                                chkShift4.Checked, optUseAlternatingShifts.Checked, CInt(nudAltShiftDays.Value), _
                                CInt(nudAltShift1.Value), CInt(nudAltShift2.Value))
            .WorkGroups = wglWorkgroups.SelectedWorkGroups

            'TODO: Hier im Bedarfsfall wieder ein Kontrollkästchen einfügen und abfragen.
            .IncludeWorkLoad = False
            .WorkgroupAnalysisCount = nivBestWorstCount.Value
            If optBest.Checked Then
                .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best
            ElseIf optWorst.Checked Then
                .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Worst
            Else
                .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Selected
            End If
            .ChartTitel = txtChartTitel.Text
            .ChartDeltaFromValue = tbDegreeOfTimeFrom.Value
            .ChartDeltaToValue = tbDegreeOfTimeTo.Value
            .ChartType = If(opt2DChart.Checked, ChartType.Chart2DLine, ChartType.Chart3DLine)
        End With
    End Sub

    Private Sub FromAnalysisParameters()
        With myAnalysisParameters
            drpMain.DateRangeValue = .DateRange
            chkShift1.Checked = .ShiftParameters.ConsiderShift1
            chkShift2.Checked = .ShiftParameters.ConsiderShift2
            chkShift3.Checked = .ShiftParameters.ConsiderShift3
            chkShift4.Checked = .ShiftParameters.ConsiderShift4
            optUseAlternatingShifts.Checked = .ShiftParameters.AlternateShifts
            nudAltShiftDays.Value = .ShiftParameters.DaysAfterToAlternate
            nudAltShift1.Value = .ShiftParameters.AlternatingFirstShift
            nudAltShift2.Value = .ShiftParameters.AlternatingSecondShift

            nivBestWorstCount.Value = .WorkgroupAnalysisCount
            If .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best Then
                optBest.Checked = True
                .WorkGroups = myAllWorkgroups
            ElseIf .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Worst Then
                optWorst.Checked = True
                .WorkGroups = myAllWorkgroups
            Else
                optPickedSites.Checked = True
            End If

            txtChartTitel.Text = .ChartTitel
            tbDegreeOfTimeFrom.Value = .ChartDeltaFromValue
            tbDegreeOfTimeTo.Value = .ChartDeltaToValue
            txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString
            txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString
            If .ChartType = ChartType.Chart2DLine Then
                opt2DChart.Checked = True
            Else
                opt3DChart.Checked = True
            End If
        End With
    End Sub

    Private Sub SelectAllWorkgroupItems()
        'Vorselektieren
        For Each locLvw As ListViewItem In wglWorkgroups.Items
            locLvw.Selected = False
        Next
    End Sub

    Private Sub SelectWorkgroupItems()
        SelectAllWorkgroupItems()
        For Each locItem As Integer In myAnalysisParameters.SelectedWorkgroups
            For Each locLvw As ListViewItem In wglWorkgroups.Items
                If Integer.Parse(locLvw.Name) = locItem Then
                    locLvw.Selected = True
                End If
            Next
        Next
    End Sub

    Private Sub btnAllShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllShifts.Click
        chkShift1.Checked = True
        chkShift2.Checked = True
        chkShift3.Checked = True
        chkShift4.Checked = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ToAnalysisParameters()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myAnalysisParameters = Nothing
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub rbBest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBest.CheckedChanged
        wglWorkgroups.Enabled = False
    End Sub

    Private Sub rbWorst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWorst.CheckedChanged
        wglWorkgroups.Enabled = False
    End Sub

    Private Sub rbPickedSites_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPickedSites.CheckedChanged
        wglWorkgroups.Enabled = True
    End Sub

    Private Sub tbDegreeOfTimeTo_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDegreeOfTimeTo.Scroll
        If tbDegreeOfTimeTo.Value < (tbDegreeOfTimeFrom.Value + MINIMUM_CHART_DELTA) Then
            tbDegreeOfTimeFrom.Value = (tbDegreeOfTimeTo.Value - MINIMUM_CHART_DELTA)
            txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString
        End If
        txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString
    End Sub

    Private Sub tbDegreeOfTimeFrom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDegreeOfTimeFrom.Scroll
        If tbDegreeOfTimeFrom.Value > (tbDegreeOfTimeTo.Value - MINIMUM_CHART_DELTA) Then
            tbDegreeOfTimeTo.Value = tbDegreeOfTimeFrom.Value + MINIMUM_CHART_DELTA
            txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString
        End If
        txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString
    End Sub

    Private Sub btnResetDeltaValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetDeltaValues.Click
        tbDegreeOfTimeFrom.Value = INITIAL_FROM_VALUE_FOR_CHART_DELTA
        tbDegreeOfTimeTo.Value = INITIAL_TO_VALUE_FOR_CHART_DELTA
        txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString
        txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString
    End Sub

    Private Sub chkAutomaticTimeOfDegreeRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutomaticTimeOfDegreeRange.CheckedChanged
        If chkAutomaticTimeOfDegreeRange.Checked Then
            tbDegreeOfTimeFrom.Enabled = False
            tbDegreeOfTimeTo.Enabled = False
            txtTimeOfDegreeRangeFrom.Text = "Auto"
            txtTimeOfDegreeRangeTo.Text = "Auto"
        Else
            tbDegreeOfTimeFrom.Enabled = True
            tbDegreeOfTimeTo.Enabled = True
            txtTimeOfDegreeRangeTo.Text = tbDegreeOfTimeTo.Value.ToString
            txtTimeOfDegreeRangeFrom.Text = tbDegreeOfTimeFrom.Value.ToString
        End If
    End Sub

    Private Sub txtChartTitel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChartTitel.TextChanged
        If Not myIgnoreNextTextChange Then
            myHasChangedManually = True
        End If
    End Sub
End Class
