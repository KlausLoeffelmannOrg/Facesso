Imports ActiveDev
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmUserInfoEdit
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.ChangeSystemData)
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
    Public Function ShowDialog(ByVal InfoItem As IInfoItem) As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmUserInfoEdit = FunctionHandler(Of GetFrmUserInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmUserInfoEdit As New frmUserInfoAddEditView
        Return locFrmUserInfoEdit.Fac_HandleDialogAsEdit(My.Resources.UserInfoEdit_FormCaption, InfoItem)
    End Function
End Class
