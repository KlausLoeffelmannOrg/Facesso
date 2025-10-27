Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmSubsidiaryManager
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.Admin)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.SubsidiaryInfoAddEditDelete_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowDialog()

        Dim locFH As GetFrmSubsidiaryManager = FunctionHandler(Of GetFrmSubsidiaryManager).GetFunctionInstance
        If locFH Is Nothing Then Return

        Dim locFrmSubidiaryManager As New frmSubsidiaryManager
        locFrmSubidiaryManager.HandleDialog()
    End Sub
End Class
