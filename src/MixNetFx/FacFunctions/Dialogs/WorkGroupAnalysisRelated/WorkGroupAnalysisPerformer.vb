Imports Facesso.Data
Imports System.Windows.Forms

Public Class WorkGroupAnalysisPerformer

    Private myAnalysisParameters As WorkGroupAnalysisParameters

    Sub New(ByVal AnalysisParameters As WorkGroupAnalysisParameters)
        myAnalysisParameters = AnalysisParameters

        'Überprüfen, ob die Workgroup-Infos neu abgerufen werden müssen, da
        'die bei einer Auswertung nicht mitserialisiert werden.
        If myAnalysisParameters.WorkGroups Is Nothing And myAnalysisParameters.SelectedWorkgroups IsNot Nothing Then
            Dim locWorkGroups As New WorkGroupInfoItems(True)
            Dim locSelectedWorkgroups As New WorkGroupInfoItems
            For Each locInt As Integer In myAnalysisParameters.SelectedWorkgroups
                locSelectedWorkgroups.Add(locWorkGroups(New ActiveDev.IntKey(locInt)))
            Next
            myAnalysisParameters.WorkGroups = locSelectedWorkgroups
        End If
    End Sub

    Public Sub PerformAnalysis()
        Select Case myAnalysisParameters.AnalysisType
            Case WorkgroupAnalysisType.Detailed
                PerformDetailed()
            Case WorkgroupAnalysisType.WorkGroupListShiftCondensed
                PerformWorkGroupListShiftCondensed()
            Case WorkgroupAnalysisType.WorkGroupListShiftwise
                PerformWorkGroupListShiftWise()
            Case WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed
                PerformWorkGroupListShiftWiseCompressed()
            Case WorkgroupAnalysisType.Batch
                PerformBatch()
            Case WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad
                'TODO: Richtige Auswertung einbauen
                PerformWorkGroupListShiftWiseWorkload()
        End Select
    End Sub

    Public Sub PerformWorkGroupListShiftCondensed()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locAnalysises As New WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, Nothing, False, False)
        locAnalysises.ExecuteQuery()
        Dim locPrintAnalysis As New FacPrintWorkGroupListShiftCondensed(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub

    Public Sub PerformWorkGroupListShiftWise()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locAnalysises As New WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, _
                            Nothing, True, False)
        locAnalysises.ExecuteQuery()
        Dim locPrintAnalysis As New FacPrintWorkGroupListShiftWise(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub

    Public Sub PerformWorkGroupListShiftWiseWorkLoad()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locAnalysises As New WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, _
                            Nothing, True, False)
        locAnalysises.ExecuteQuery()
        Dim locPrintAnalysis As New FacPrintWorkGroupListShiftWiseWorkLoad(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub

    Public Sub PerformWorkGroupListShiftWiseCompressed()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locAnalysises As New WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, _
                            Nothing, True, False)
        locAnalysises.ExecuteQuery()
        Dim locPrintAnalysis As New FacPrintWorkGroupListShiftWiseCompressed(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub

    Public Sub PerformBatch()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locAnalysises As New WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, _
                            Nothing, False, True)
        locAnalysises.ExecuteQuery()
        Dim locPrintAnalysis As New FacPrintWorkGroupAnalysisBatch(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub

    Public Sub PerformDetailed()
        Dim locProductionPeriod As New ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters)
        Dim locPrintAnalysis As New FacPrintWorkGroupShiftDateBatch(myAnalysisParameters.WorkGroups, locProductionPeriod, FacessoGeneric.LoginInfo.Username)
        locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget)
    End Sub
End Class
