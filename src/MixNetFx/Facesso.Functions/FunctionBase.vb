Imports ActiveDev
Imports System.Windows.Forms

Public Interface IFacessoFunction
    ReadOnly Property VersionPermission() As IVersionPermissionInfo
    ReadOnly Property RolePermission() As IRolePermissionInfo
    ReadOnly Property VersionPermissionViolationMessage() As String
    ReadOnly Property RolePermissionViolationMessage() As String
End Interface

Public NotInheritable Class FunctionHandler(Of FacessoFunction As {New, IFacessoFunction})

    Public Shared Function GetFunctionInstance() As FacessoFunction
        Dim locFacessoFunction As New FacessoFunction
        If Not FacessoGeneric.PermitFunctionForRole(locFacessoFunction.RolePermission) Then
            MessageBox.Show(locFacessoFunction.RolePermissionViolationMessage, _
                            "Fehlende Rechte:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
        End If

        If Not FacessoGeneric.PermitFunctionForVersion(locFacessoFunction.VersionPermission) Then
            MessageBox.Show(locFacessoFunction.VersionPermissionViolationMessage, _
                            "In dieser Programversion nicht verfügbar:", MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Return Nothing
        End If
        'Todo: Log in Database
        Return locFacessoFunction
    End Function
End Class

Public Class FacessoFunctionBase
    Implements IFacessoFunction

    Friend Sub New()
    End Sub

    Public Overridable ReadOnly Property RolePermission() As IRolePermissionInfo Implements IFacessoFunction.RolePermission
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.None)
        End Get
    End Property

    Public Overridable ReadOnly Property VersionPermission() As IVersionPermissionInfo Implements IFacessoFunction.VersionPermission
        Get
            Return New FacessoVersionPermissionInfo(FacessoVersion.FacessoStandard)
        End Get
    End Property

    Public Overridable ReadOnly Property RolePermissionViolationMessage() As String Implements IFacessoFunction.RolePermissionViolationMessage
        Get
            Return "Sie haben nicht die erforderlichen Rechte, diese Funktion verwenden zu können!"
        End Get
    End Property

    Public Overridable ReadOnly Property VersionPermissionViolationMessage() As String Implements IFacessoFunction.VersionPermissionViolationMessage
        Get
            Return "In dieser Ausbaustufe von Facesso dürfen Sie diese Funktion nicht verwenden"
        End Get
    End Property
End Class


