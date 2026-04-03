Imports Facesso.Data
Imports System.IO

Partial Public Class frmFacessoShell

    Private Const CHART_ANALYSIS_PATH = "\ChartAnalysisInfo"
    Private Const CHART_ANALYSIS_FILENAME = "\FacessoAnalyses.Xml"

    Private Sub AssignChartAnalysises()
        Dim analysisFile As New FileInfo(FacessoGeneric.SharedFolder & CHART_ANALYSIS_PATH & CHART_ANALYSIS_FILENAME)
        If Not analysisFile.Exists Then
            'Neue Collection mit den Default-Einstellungen anlegen
            'Gestern, letzte Woche, Seit Anfang des Monats
            With mainChartOne.AnalysisParameters
                .ChartTitel = "Beste Arbeitsgruppen gestern"
                .DateRange = New DateRangeParameter(DateRangePresets.YesterdayOrLastWorkingDay, LastFacessoWorkingDay)
                .ShiftParameters = New ShiftParameters() With {.ConsiderShift1 = True,
                                                             .ConsiderShift2 = True,
                                                             .ConsiderShift3 = True,
                                                             .ConsiderShift4 = True}
                .Name = "mainChartOne"
            End With
            mainChartOne.RecalculateChartData()

            With mainChartTwo.AnalysisParameters
                .ChartTitel = "Beste Arbeitsgruppen diese Woche"
                .DateRange = New DateRangeParameter(DateRangePresets.FromStartOfCurrentWeekToNow, LastFacessoWorkingDay)
                .ShiftParameters = New ShiftParameters() With {.ConsiderShift1 = True,
                                                             .ConsiderShift2 = True,
                                                             .ConsiderShift3 = True,
                                                             .ConsiderShift4 = True}
                .Name = "mainChartTwo"
            End With
            mainChartTwo.RecalculateChartData()

            With mainChartThree.AnalysisParameters
                .ChartTitel = "Beste Arbeitsgruppen letzter Monat"
                .DateRange = New DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, 1)
                .ShiftParameters = New ShiftParameters() With {.ConsiderShift1 = True,
                                                             .ConsiderShift2 = True,
                                                             .ConsiderShift3 = True,
                                                             .ConsiderShift4 = True}
                .Name = "mainChartThree"
            End With
            mainChartThree.RecalculateChartData()
            SaveChartAnalysisChanges()
        Else
            Dim myAnalysises = WorkGroupAnalysisParametersCollection.FromFile(New FileInfo(FacessoGeneric.SharedFolder & CHART_ANALYSIS_PATH & CHART_ANALYSIS_FILENAME))
            mainChartOne.AnalysisParameters = myAnalysises(0)
            mainChartTwo.AnalysisParameters = myAnalysises(1)
            mainChartThree.AnalysisParameters = myAnalysises(2)
        End If
    End Sub

    Private Sub SaveChartAnalysisChanges()
        Dim locFi As New FileInfo(FacessoGeneric.SharedFolder & CHART_ANALYSIS_PATH & CHART_ANALYSIS_FILENAME)
        Dim myAnalysises As New WorkGroupAnalysisParametersCollection()
        myAnalysises.Add(mainChartOne.AnalysisParameters)
        myAnalysises.Add(mainChartTwo.AnalysisParameters)
        myAnalysises.Add(mainChartThree.AnalysisParameters)
        myAnalysises.ToFile(locFi)
    End Sub

    Private Function LastFacessoWorkingDay() As LastWorkingdays
        If Not (myFacessoGeneralOptions.SaturdayIsWorkday And myFacessoGeneralOptions.SundayIsWorkday) Then
            Return LastWorkingdays.Friday
        ElseIf myFacessoGeneralOptions.SundayIsWorkday Then
            Return LastWorkingdays.Sunday
        Else
            Return LastWorkingdays.Saturday
        End If
    End Function

End Class
