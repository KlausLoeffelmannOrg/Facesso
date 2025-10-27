Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmWageGroupInfoAdd
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WageGroupInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmWageGroupInfoAdd = FunctionHandler(Of GetFrmWageGroupInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmWageGroupInfoAdd As New frmWageGroupInfoAddEditView
        Return locFrmWageGroupInfoAdd.Fac_HandleDialogAsAdd(My.Resources.WageGroupInfoAdd_FormCaption, GetType(WageGroupInfo))
    End Function
End Class
