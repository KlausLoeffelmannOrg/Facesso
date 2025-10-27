Imports Activedev
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmLabourValueInfoEdit
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.LabourValueInfoEdit_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog(ByVal InfoItem As IInfoItem) As InfoItemMaintenanceDialogResult

        Dim locFH As GetFrmLabourValueInfoEdit = FunctionHandler(Of GetFrmLabourValueInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return Nothing

        Dim locFrmLabourValueInfoEdit As New frmLabourValueInfoAddEditView
        Return locFrmLabourValueInfoEdit.Fac_HandleDialogAsEdit(My.Resources.LabourValueInfoEdit_FormCaption, InfoItem)
    End Function
End Class
