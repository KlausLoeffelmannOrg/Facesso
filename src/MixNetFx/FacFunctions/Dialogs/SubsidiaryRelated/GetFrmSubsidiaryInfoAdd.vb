Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmSubsidiaryInfoAdd
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
    Public Function ShowDialog() As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmSubsidiaryInfoAdd = FunctionHandler(Of GetFrmSubsidiaryInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmSubsidiaryInfoAdd As New frmSubsidiaryInfoAddEditView
        Return locFrmSubsidiaryInfoAdd.Fac_HandleDialogAsAdd(My.Resources.SubsidiaryInfoAdd_FormCaption, GetType(SubsidiaryInfo))
    End Function
End Class
