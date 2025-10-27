Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmLabourValueInfoAdd
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.LabourValueInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmLabourValueInfoAdd = FunctionHandler(Of GetFrmLabourValueInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmLabourValueInfoAdd As New frmLabourValueInfoAddEditView
        Return locFrmLabourValueInfoAdd.Fac_HandleDialogAsAdd(My.Resources.LabourValueInfoAdd_FormCaption, GetType(LabourValueInfo))
    End Function
End Class
