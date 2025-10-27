Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmIncentiveWageCalc
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.IncentiveWageCalculation_DeniedDueToRole
        End Get
    End Property

    Public Function ShowDialog() As DialogResult

        Dim locFH As GetFrmIncentiveWageCalc = FunctionHandler(Of GetFrmIncentiveWageCalc).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmIncentiveWageCalc As New frmIncentiveWageCalc
        Return locFrmIncentiveWageCalc.ShowDialog
    End Function
End Class
