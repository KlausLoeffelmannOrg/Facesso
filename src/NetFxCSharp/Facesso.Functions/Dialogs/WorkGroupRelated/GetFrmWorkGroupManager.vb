Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmWorkGroupManager
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WorkGroupManager_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars zurück,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>Rückgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locWorkGroupManager As New frmWorkGroupManager
        locWorkGroupManager.HandleDialog()
    End Sub
End Class
