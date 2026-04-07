Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class frmTimeLogResultTable

    Private myTimeLogData As TimeDataTable
    Private myProductionDate As Date

    Private Sub frmTimeLogResultTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmpParams As New List(Of ReportParameter)
        tmpParams.Add(New ReportParameter("ReportDate", myProductionDate.ToString))
        Me.rvEmployeeTimeLogResult.LocalReport.SetParameters(tmpParams)
        Me.rvWorksiteTimeLogResult.LocalReport.SetParameters(tmpParams)
        Me.TimeDataRowBindingSource.DataSource = myTimeLogData
        Me.rvEmployeeTimeLogResult.RefreshReport()
        Me.rvWorksiteTimeLogResult.RefreshReport()
    End Sub

    Overloads Function ShowDialog(ByVal timeLogData As TimeDataTable, ByVal ProductionDate As Date) As DialogResult
        myProductionDate = ProductionDate
        myTimeLogData = timeLogData
        Return MyBase.ShowDialog
    End Function
End Class