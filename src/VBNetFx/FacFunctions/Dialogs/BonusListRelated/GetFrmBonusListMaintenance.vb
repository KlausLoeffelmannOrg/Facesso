Imports Activedev
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmBonusListMaintenance
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.UserInfoEdit_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowDialog()

        Dim locFH As GetFrmBonusListMaintenance = FunctionHandler(Of GetFrmBonusListMaintenance).GetFunctionInstance
        If locFH Is Nothing Then Return

        Dim locfrm As New frmBonuslistMaintenance
        locfrm.HandleDialog()
    End Sub
End Class
