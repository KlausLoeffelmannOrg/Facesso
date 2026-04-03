Imports Facesso.Data
Imports System.Data.SqlClient

Public Class ReportEmployeeMasterData

    Private Sub ReportEmployeeMasterData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "MasterDataSet.EmployeesWithCostCenters". 
        'Sie können sie bei Bedarf verschieben oder entfernen.
        Me.EmployeesWithCostCentersTableAdapter.Connection = New SqlConnection(FacessoGeneric.SQLConnectionString)
        Me.EmployeesWithCostCentersTableAdapter.Fill(Me.MasterDataSet.EmployeesWithCostCenters)
        Me.rvEmployees.RefreshReport()
    End Sub
End Class