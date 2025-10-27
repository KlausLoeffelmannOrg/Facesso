Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmEmployeeInfoAdd
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.EmployeeInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmEmployeeInfoAdd = FunctionHandler(Of GetFrmEmployeeInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmEmployeeInfoAdd As New frmEmployeeInfoAddEditView
        Return locFrmEmployeeInfoAdd.Fac_HandleDialogAsAdd(My.Resources.EmployeeInfoAdd_FormCaption, GetType(EmployeeInfo))
    End Function
End Class
