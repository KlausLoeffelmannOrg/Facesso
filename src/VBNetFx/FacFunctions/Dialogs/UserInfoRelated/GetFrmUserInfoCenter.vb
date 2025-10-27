Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmUserInfoCenter
    Inherits FacessoFunctionBase

    Private myFrmInfoItemsManagerGeneric As frmInfoItemsManagerGeneric(Of UserInfo)

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.ViewSystemData)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.UserInfoCollectionGet_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars zurück,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>Rückgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locUserInfoCollection As UserInfoCollection = SPAccess.GetInstance.UserInfoCollection

        myFrmInfoItemsManagerGeneric = New frmInfoItemsManagerGeneric(Of UserInfo) _
                                       (My.Resources.UserInfoCenter_LocalizedTypeName)
        myFrmInfoItemsManagerGeneric.InfoItems = locUserInfoCollection

        myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = AddressOf UserInfoAdd
        myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = AddressOf UserInfoEdit
        myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = AddressOf RefreshItems
        myFrmInfoItemsManagerGeneric.ShowDialog()
    End Sub

    Friend Sub UserInfoAdd()
        Dim locFH As GetFrmUserInfoAdd = FunctionHandler(Of GetFrmUserInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Friend Sub UserInfoEdit()
        Dim locFH As GetFrmUserInfoEdit = FunctionHandler(Of GetFrmUserInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.UserInfoCenter_NoSelectedUser_MB_Body, _
                            My.Resources.UserInfoCenter_NoSelectedUser_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub RefreshItems()
        Dim locUserInfoCollection As UserInfoCollection = SPAccess.GetInstance.UserInfoCollection
        myFrmInfoItemsManagerGeneric.InfoItems = locUserInfoCollection
    End Sub
End Class
