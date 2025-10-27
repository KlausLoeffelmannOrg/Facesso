Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmOptions
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.ChangeSystemData)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            'TODO: Meldung anpassen
            Return My.Resources.UserInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As DialogResult

        Dim locFH As GetFrmOptions = FunctionHandler(Of GetFrmOptions).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmOptions As New frmOptions
        Return locFrmOptions.HandleDialog()
    End Function
End Class
