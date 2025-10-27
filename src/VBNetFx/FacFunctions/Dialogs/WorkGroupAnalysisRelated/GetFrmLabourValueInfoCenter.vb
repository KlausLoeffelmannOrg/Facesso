Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmWorkGroupAnalysis
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PrintReportsOnProductionData)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WorkGroupAnalysis_DeniedDueToRole
        End Get
    End Property

    Public Function ShowDialog() As DialogResult
        Dim locFH As GetFrmWorkGroupAnalysis = FunctionHandler(Of GetFrmWorkGroupAnalysis).GetFunctionInstance
        If locFH Is Nothing Then Return DialogResult.None

        Dim locFrmWorkGroupAnalysis As New frmWorkGroupAnalysis
        Return locFrmWorkGroupAnalysis.ShowDialog()
    End Function
End Class
