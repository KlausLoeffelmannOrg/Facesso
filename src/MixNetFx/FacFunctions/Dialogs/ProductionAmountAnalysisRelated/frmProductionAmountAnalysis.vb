Imports ActiveDev
Imports System.Windows.Forms
Imports Facesso.Data

Public Class frmProductionAmountAnalysis

    Private myCurrentProdAmounts As WorkGroupsProductionDataAmounts

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        lvwWorkgroups.WorkGroupInfoItems = New WorkGroupInfoItems(True)
        lvwCostCenter.AutoGroup = False
        lvwCostCenter.CostCenterInfoCollection = CostcenterInfoItems.GetCostCenterInfoItems
        lvwWorkgroups.HideSelection = False
        lvwCostCenter.HideSelection = False

        SelectDeselect(True)
    End Sub

    Private Sub PerformAnalysis()

        If lvwWorkgroups.SelectedWorkGroups.Count = 0 Then
            MessageBox.Show("Bitte markieren Sie zunächst die Produktiv-Sites" & _
                            ", die Sie in die Auswertung einbeziehen wollen", "Keine Produktiv-Sites ausgewählt!", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = lvwWorkgroups.SelectedWorkGroups.Count - 1
        ProgressBar1.Value = 0
        lblPass.Text = "Pass 1: Berechnen der Leistung der einzelnen Arbeitsgruppen"

        Dim locWorkgroups As WorkGroupInfoItems = lvwWorkgroups.SelectedWorkGroups

        Dim locPeriod As New ProductionPeriod(DateRangePicker.DateRangeValue, _
                        New ShiftParameters(True, True, True, True, False, 0, 0, 0))

        'Zeitgrade der Arbeitsgruppen im Bereich errechnen
        Dim locWorkgroupAnalysis As New WorkGroupAnalysisInfoItems(locPeriod, lvwWorkgroups.SelectedWorkGroups, _
            AddressOf UpdateProgressInfo, True, True)
        locWorkgroupAnalysis.ExecuteQuery()

        For Each locItem As WorkGroupAnalysisInfo In locWorkgroupAnalysis
            locWorkgroups(New IntKey(locItem.WorkGroupInfo.IDWorkGroup)).CurrentDegreeOfTime = locItem.DegreeOfTime
        Next

        lblPass.Text = "Pass 2: Durchführen der Mengenanalyse"
        lblPass.Update()

        ProgressBar1.Value = 0
        ProgressBar1.Update()

        myCurrentProdAmounts = New WorkgroupsProductionDataAmounts(FacessoGeneric.LoginInfo.IDSubsidiary, _
                    locWorkgroups, _
                    DateRangePicker.DateRangeValue.StartDate, _
                    DateRangePicker.DateRangeValue.EndDate, _
                    AddressOf UpdateProgressInfo)
        myCurrentProdAmounts.ExecuteQuery()

        lblPass.Text = "Berechnungen abgeschlossen."
        lblPass.Update()
        myCurrentProdAmounts.CostCenters = lvwCostCenter.SelectedCostCenters
    End Sub

    Private Sub UpdateProgressInfo(ByVal Workgroup As WorkGroupInfo, ByVal ProcessedWorkgroups As Integer)
        ProgressBar1.Value = ProcessedWorkgroups
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        PerformAnalysis()
        If optGroupWorkvalues.Checked Then
            myCurrentProdAmounts.CategoriseByWorkvalues()
        ElseIf optGroupCostcenters.Checked Then
            myCurrentProdAmounts.CategoriseByCostCenters()
        End If

        Dim locPrintAnalysis As New FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, _
                            FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(AnalysisTarget.PreviewBeforePrint)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PerformAnalysis()
        If optGroupWorkvalues.Checked Then
            myCurrentProdAmounts.CategoriseByWorkvalues()
        ElseIf optGroupCostcenters.Checked Then
            myCurrentProdAmounts.CategoriseByCostCenters()
        End If
        Dim locPrintAnalysis As New FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, _
                                    FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(AnalysisTarget.DirectlyToPrinter)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        PerformAnalysis()
        Dim locPrintAnalysis As New FacPrintProductionAmountAnalysisBatch(myCurrentProdAmounts, _
                                    FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(AnalysisTarget.CSVExport)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCostCenterLabourValueAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("Not yet implemented!")
    End Sub

    Private Sub SelectDeselect(ByVal SelFlag As Boolean)
        For Each locItem As ListViewItem In lvwWorkgroups.Items
            locItem.Selected = SelFlag
        Next
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 1 Then
            If Not optGroupCostcenters.Checked Then
                optGroupCostcenters.Checked = True
            End If
        Else
            If Not optStandardAnalysis.Checked Then
                optStandardAnalysis.Checked = True
            End If
        End If
    End Sub

    Private Sub optGroupCostcenters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGroupCostcenters.CheckedChanged
        If optGroupCostcenters.Checked = True Then
            If TabControl1.SelectedIndex = 0 Then
                TabControl1.SelectedIndex = 1
            End If
        Else
            If TabControl1.SelectedIndex = 1 Then
                TabControl1.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        SelectDeselect(True)
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        SelectDeselect(False)
    End Sub
End Class