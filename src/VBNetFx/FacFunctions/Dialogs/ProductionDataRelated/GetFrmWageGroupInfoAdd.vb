Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFrmProductionDataCollector
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.CorrectProductionData)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            'Todo!
            Return My.Resources.WageGroupInfoAdd_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowDialog(ByVal CombinedParameters As CombinedParametersInfo)

        Dim locFH As GetFrmProductionDataCollector = FunctionHandler(Of GetFrmProductionDataCollector).GetFunctionInstance
        If locFH Is Nothing Then Return

        Dim locFrmProductionDataCollector As New frmProductionDataCollector
        locFrmProductionDataCollector.HandleDialog(CombinedParameters)
    End Sub
End Class
