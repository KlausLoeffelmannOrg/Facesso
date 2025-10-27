Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmWageGroupInfoCenter
    Inherits FacessoFunctionBase

    Private myFrmInfoItemsManagerGeneric As frmInfoItemsManagerGeneric(Of WageGroupInfo)

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WageGroupInfoCollectionGet_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars zurück,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>Rückgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locWageGroupInfoCollection As WageGroupInfoCollection = SPAccess.GetInstance.WageGroupInfoCollection

        myFrmInfoItemsManagerGeneric = New frmInfoItemsManagerGeneric(Of WageGroupInfo) _
                                       (My.Resources.WageGroupInfoCenter_LocalizedTypeName)

        myFrmInfoItemsManagerGeneric.InfoItems = locWageGroupInfoCollection

        myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = AddressOf WageGroupInfoAdd
        myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = AddressOf WageGroupInfoEdit
        myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = AddressOf RefreshItems
        myFrmInfoItemsManagerGeneric.ShowDialog()
    End Sub

    Friend Sub WageGroupInfoAdd()
        Dim locFH As GetFrmWageGroupInfoAdd = FunctionHandler(Of GetFrmWageGroupInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Friend Sub WageGroupInfoEdit()
        Dim locFH As GetFrmWageGroupInfoEdit = FunctionHandler(Of GetFrmWageGroupInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.WageGroupInfoCenter_NoSelectedWageGroup_MB_Body, _
                            My.Resources.WageGroupInfoCenter_NoSelectedWageGroup_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub RefreshItems()
        Dim locWageGroupInfoCollection As WageGroupInfoCollection = SPAccess.GetInstance.WageGroupInfoCollection
        myFrmInfoItemsManagerGeneric.InfoItems = locWageGroupInfoCollection
    End Sub
End Class
