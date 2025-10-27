Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmCostcenterInfoCenter
    Inherits FacessoFunctionBase

    Private myFrmInfoItemsManagerGeneric As frmInfoItemsManagerGeneric(Of CostcenterInfo)

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.CostCenterInfoCollectionGet_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars zurück,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>Rückgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locCostcenterInfoCollection As CostcenterInfoItems = SPAccess.GetInstance.CostCenterInfoItems

        myFrmInfoItemsManagerGeneric = New frmInfoItemsManagerGeneric(Of CostcenterInfo) _
                                       (My.Resources.CostCenterInfoCenter_LocalizedTypeName)

        myFrmInfoItemsManagerGeneric.InfoItems = locCostcenterInfoCollection

        myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = AddressOf CostcenterInfoAdd
        myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = AddressOf CostCenterInfoEdit
        myFrmInfoItemsManagerGeneric.InfoItemDeleteDelegate = AddressOf CostCenterInfoDelete
        myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = AddressOf RefreshItems
        myFrmInfoItemsManagerGeneric.ShowDialog()
    End Sub

    Friend Sub CostcenterInfoAdd()
        Dim locFH As GetFrmCostcenterInfoAdd = FunctionHandler(Of GetFrmCostcenterInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Friend Sub CostCenterInfoEdit()
        Dim locFH As GetFrmCostcenterInfoEdit = FunctionHandler(Of GetFrmCostcenterInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, _
                            My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub CostCenterInfoDelete()
        Dim locFH As GetFuncCostCenterDelete = FunctionHandler(Of GetFuncCostCenterDelete).GetFunctionInstance
        If locFH Is Nothing Then Return

        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, _
                            My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        For Each locItem As CostcenterInfo In myFrmInfoItemsManagerGeneric.SelectedInfoItems
            locFH.DeleteItem(locItem)
        Next
    End Sub

    Friend Sub RefreshItems()
        Dim locCostcenterInfoCollection As CostcenterInfoItems = SPAccess.GetInstance.CostCenterInfoItems
        myFrmInfoItemsManagerGeneric.InfoItems = locCostcenterInfoCollection
    End Sub
End Class
