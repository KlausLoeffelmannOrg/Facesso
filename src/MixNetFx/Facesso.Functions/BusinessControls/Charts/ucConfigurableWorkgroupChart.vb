Option Strict On

Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Facesso.Data
Imports ActiveDev

Public Class ucConfigurableWorkgroupChart

    Private myAnalysisParameters As WorkGroupAnalysisParameters
    Private myEnsureWorkgroups As Action
    Private myResultList As List(Of WorkGroupAnalysisInfo)

    Sub New()

        myAnalysisParameters = New WorkGroupAnalysisParameters With
                                {.AnalysisTarget = AnalysisTarget.DirectlyToPrinter,
                                 .AnalysisType = WorkgroupAnalysisType.Batch,
                                 .AutomaticChartDeltaRange = True,
                                 .ChartDeltaFromValue = 80,
                                 .ChartDeltaToValue = 140,
                                 .ChartTitel = "Arbeitsgruppenauswertung",
                                 .ChartType = ChartType.Chart2DLine,
                                 .DateRange = New DateRangeParameter(DateRangePresets.LastWeek),
                                 .IncludeSuspended = False,
                                 .IncludeWorkLoad = True,
                                 .ShiftParameters = New ShiftParameters() With {.ConsiderShift1 = True},
                                 .WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best,
                                 .WorkgroupAnalysisCount = 3}

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        myEnsureWorkgroups = Sub()
                                 If Me.AnalysisParameters.WorkGroups Is Nothing Then
                                     Me.AnalysisParameters.WorkGroups = New WorkGroupInfoItems(True)
                                     If Me.AnalysisParameters.SelectedWorkgroups Is Nothing Then
                                         Me.AnalysisParameters.SelectedWorkgroups = New System.Collections.ObjectModel.Collection(Of Integer)
                                         Me.AnalysisParameters.WorkGroups.ToList.ForEach(Sub(item)
                                                                                             Me.AnalysisParameters.SelectedWorkgroups.Add(item.WorkGroupNumber)
                                                                                         End Sub)
                                     End If
                                 End If
                             End Sub
    End Sub

    Public Sub RecalculateChartData()
        Dim prodPeriod As New ProductionPeriod(Me.AnalysisParameters.DateRange, Me.AnalysisParameters.ShiftParameters)
        Dim compressShifts As Boolean
        'Dafür sorgen, dass die Collections, die die Workgroups beschreiben, auch vorhanden sind.
        myEnsureWorkgroups()
        If Me.AnalysisParameters.SelectedWorkgroups IsNot Nothing AndAlso Me.AnalysisParameters.SelectedWorkgroups.Count > 1 Then
            compressShifts = True
        Else
            compressShifts = False
        End If
        Dim wgAnalysis As New WorkGroupAnalysisInfoItems(prodPeriod, Me.AnalysisParameters.WorkGroups, _
                            Nothing, False, compressShifts)
        wgAnalysis.ExecuteQuery()

        'Wir brauchen entweder die alle, die x besten oder die x schlechtesten in der Ergebnisliste
        If Me.AnalysisParameters.WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best Then
            'Nur die x besten verwenden,
            myResultList = (From item In wgAnalysis
                          Where item.HasData
                          Order By item.DegreeOfTime
                          Take Me.AnalysisParameters.WorkgroupAnalysisCount.Value).ToList
        ElseIf Me.AnalysisParameters.WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Worst Then
            'oder nur die X schlechtesten verwenden,
            myResultList = (From item In wgAnalysis
                          Where item.HasData
                          Order By item.DegreeOfTime Descending
                          Take Me.AnalysisParameters.WorkgroupAnalysisCount.Value).ToList
        Else
            'oder die selektierten nehmen, die aber aufsteigend sortieren.
            'Und auch die nehmen, die keine Daten haben.
            myResultList = (From item In wgAnalysis
                          Where AnalysisParameters.SelectedWorkgroups.Contains(item.WorkGroupInfo.WorkGroupNumber)
                          Order By item.DegreeOfTime).ToList
        End If

        'Die Produktiv-Sites - so vorhanden - aus der Drop-Downliste entfernen.
        For Each item As ToolStripItem In WorkgroupsDropDownItems.DropDownItems
            RemoveHandler item.Click, AddressOf WorkgroupDropDownItemClickHandler
        Next
        WorkgroupsDropDownItems.DropDownItems.Clear()

        'Die Produktiv-Sites wieder aufnahmen, und die Eventhandler für die Auswahl neu verdrahten.
        For Each item In myResultList
            Dim tb = New ToolStripMenuItem With {.Text = item.WorkGroupInfo.DisplayName,
                                                        .Checked = True,
                                                        .CheckOnClick = True,
                                                        .DisplayStyle = ToolStripItemDisplayStyle.Text,
                                                        .Tag = item}
            AddHandler tb.CheckedChanged, AddressOf WorkgroupDropDownItemClickHandler
            WorkgroupsDropDownItems.DropDownItems.Add(tb)
        Next

        RefreshChart()
    End Sub

    Private Sub WorkgroupDropDownItemClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        RefreshChart()
    End Sub

    Public Sub RefreshChart()

        Dim compressShifts As Boolean

        If Me.AnalysisParameters.SelectedWorkgroups IsNot Nothing AndAlso Me.AnalysisParameters.SelectedWorkgroups.Count > 1 Then
            compressShifts = True
        Else
            compressShifts = False
        End If

        Me.mainChart.Titles("MainTitle").Text = Me.AnalysisParameters.ChartTitel

        'Interaktives Chart auf beiden Achsen aktivieren
        mainChart.ChartAreas(0).CursorX.IsUserEnabled = True
        mainChart.ChartAreas(0).CursorY.IsUserEnabled = True

        'Selektionsfähigkeit aktivieren
        mainChart.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        mainChart.ChartAreas(0).CursorY.IsUserSelectionEnabled = True


        'Zoomen aktivieren
        mainChart.ChartAreas(0).AxisX.ScaleView.Zoomable = True
        mainChart.ChartAreas(0).AxisY.ScaleView.Zoomable = True

        'Scrollbar innendrin positionieren
        mainChart.ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
        mainChart.ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = True

        If myResultList.Count = 0 Then
            Me.mainChart.Titles("SubTitle").Text = "Die Abfrage brachte keine Ergebnisse!"
            'Die vorhandenen Serien löschen
            mainChart.Series.Clear()
            Return
        Else
            Me.mainChart.Titles("SubTitle").Text = Me.AnalysisParameters.DateRange.ToString
        End If

        Dim count = 1
        If compressShifts Then
            'Die vorhandenen Serien löschen
            mainChart.Series.Clear()
            For Each wgItem In myResultList
                'Neue Serie hinzufügen
                Dim tmpItem = wgItem
                Dim menueItem = (From dItem In WorkgroupsDropDownItems.DropDownItems
                                 Where DirectCast(dItem, ToolStripMenuItem).Tag Is tmpItem).Single

                If Not DirectCast(menueItem, ToolStripMenuItem).Checked Then Continue For
                Dim wgDescription = wgItem.WorkGroupInfo.WorkGroupNumber & ": " & wgItem.WorkGroupInfo.WorkGroupName
                Dim series As Series = mainChart.Series.Add(wgDescription)
                series.Legend = mainChart.Legends(0).Name
                series.LegendText = count.ToString & ". - " & wgDescription
                series.ToolTip = wgItem.AttendanceTimeDeltaStrings & vbNewLine & _
                                 wgItem.IncentiveTimeDeltaStrings & vbNewLine & _
                                 wgItem.GeneralBreakTimeStrings
                'Chart-Area festlegen, in das diese Serie gezeichnet werden soll
                series.ChartArea = mainChart.ChartAreas(0).Name
                'Legende formatieren

                'Chart-Type definieren
                series.ChartType = SeriesChartType.Spline

                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
                'MessageBox.Show("Es folgen Daten für" & wgItem.WorkGroupInfo.WorkGroupName)
                Debug.Print("-------- Daten " & wgItem.WorkGroupInfo.WorkGroupName & "--------------")
                'Daten aufjedenfall nach Datum sortieren, sonst knallt es!

                Dim valuesForChart = (From vItem In wgItem
                                     Order By vItem.ProductionDate Ascending).ToList

                For Each valueItem In valuesForChart
                    Debug.Print("Datum:" & valueItem.ProductionDate.ToString & "Wert:" & valueItem.DegreeOfTime)
                    series.Points.Add(New DataPoint(valueItem.ProductionDate.ToOADate, valueItem.DegreeOfTime) With
                                      {.ToolTip = wgDescription & vbNewLine & valueItem.ProductionDate.ToShortDateString & " - Schicht:" & vbNewLine &
                                          valueItem.Shift & "Zeitgrad: " & valueItem.DegreeOfTime.ToString("##0") &
                                        vbNewLine & vbNewLine & valueItem.IncentiveTimeDeltaStrings,
                                       .Label = If(ShowValuesInChartToolStripButton.Checked, valueItem.DegreeOfTime.ToString("##0"), ""),
                                       .IsValueShownAsLabel = ShowValuesInChartToolStripButton.Checked})
                Next
                Debug.Print("----------------------")
                count += 1
            Next
        End If
    End Sub

    Private Property WorkgroupsInner As WorkGroupInfoItems

    Private Sub EditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripButton.Click
        Dim frmGetChartParameters As New frmWorkgroupChartParametersPicker
        myEnsureWorkgroups()
        Dim anaparams = frmGetChartParameters.GetAnalysisParameters(myAnalysisParameters)

        If anaparams IsNot Nothing Then
            Me.AnalysisParameters = anaparams
            RecalculateChartData()
        End If
    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property AnalysisParameters As WorkGroupAnalysisParameters
        Set(ByVal value As WorkGroupAnalysisParameters)
            If value IsNot myAnalysisParameters Then
                myAnalysisParameters = value
                RecalculateChartData()
            End If
        End Set
        Get
            Return myAnalysisParameters
        End Get
    End Property

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        mainChart.Printing.PrintDocument.DefaultPageSettings.Margins = New Drawing.Printing.Margins(100, 100, 100, 100)
        mainChart.Printing.PrintDocument.DefaultPageSettings.Landscape = True
        mainChart.Printing.PrintPreview()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        mainChart.Printing.PrintDocument.DefaultPageSettings.Margins = New Drawing.Printing.Margins(100, 100, 100, 100)
        mainChart.Printing.PrintDocument.DefaultPageSettings.Landscape = True
        mainChart.Printing.Print(True)
    End Sub

    Private Sub Chart3DToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart3DToolStripButton.Click
        Chart3DToolStripButton.Checked = Not Chart3DToolStripButton.Checked
        mainChart.ChartAreas(0).Area3DStyle.Enable3D = Chart3DToolStripButton.Checked
    End Sub

    Private Sub ShowValuesInChartToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowValuesInChartToolStripButton.Click
        RefreshChart()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripButton.Click
        MessageBox.Show("Export-Fuznktionalität ist nur in der Enterprise-Version implementiert!")
    End Sub

    Private Sub CopyToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripButton.Click
        MessageBox.Show("Export-Funktionalität ist nur in der Enterprise-Version implementiert!")
    End Sub
End Class

Public Enum SeriesSourceType
    TopCount
    LastCount
    Given
End Enum
