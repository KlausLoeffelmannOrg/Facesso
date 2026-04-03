Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmWorkGroupInfoAdd
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WorkGroupInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmWorkGroupInfoAdd = FunctionHandler(Of GetFrmWorkGroupInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmWorkGroupInfoAdd As New frmWorkGroupInfoAddEditView
        Return locFrmWorkGroupInfoAdd.Fac_HandleDialogAsAdd(My.Resources.WorkGroupInfoAdd_FormCaption, GetType(WorkGroupInfo))
    End Function
End Class
