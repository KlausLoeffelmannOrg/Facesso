Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmLabourValueInfoCenter
    Inherits FacessoFunctionBase

    Private myFrmInfoItemsManagerGeneric As frmInfoItemsManagerGeneric(Of LabourValueInfo)
    Private myCurrentSortOrderString As String = "LabourValueNumber"

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.LabourValueInfoCollectionGet_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
    ''' das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locLabourValueInfoCollection As LabourValueInfoCollection = SPAccess.GetInstance.GetLabourValueInfoCollection

        myFrmInfoItemsManagerGeneric = New frmInfoItemsManagerGeneric(Of LabourValueInfo) _
                                       (My.Resources.LabourValueInfoCenter_LocalizedTypeName) With
        {
            .InfoItems = locLabourValueInfoCollection,
            .InfoItemAddDelegate = AddressOf LabourValueInfoAdd,
            .InfoItemEditDelegate = AddressOf LabourValueInfoEdit,
            .RefreshItemsDelegate = AddressOf RefreshItems,
            .InfoItemDeleteDelegate = AddressOf LabourValueInfoDelete,
            .InfoItemColumnClickDelegate = AddressOf ColumnClick,
            .Costcenters = SPAccess.GetInstance.CostCenterInfoItems,
            .AssignCostcenterDelegate = AddressOf AssignCostCenter
        }

        myFrmInfoItemsManagerGeneric.ShowDialog()
    End Sub

    Friend Sub AssignCostCenter(ByVal Costcenter As CostcenterInfo)

        If Costcenter Is Nothing Then
            MessageBox.Show("Bitte w�hlen Sie zun�chst eine Kostenstelle aus der Liste aus!",
                            "Kostenstelle ausw�hlen:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim locSelectedItems As List(Of LabourValueInfo)
        locSelectedItems = myFrmInfoItemsManagerGeneric.SelectedInfoItems
        If locSelectedItems IsNot Nothing Then
            Dim locDr As DialogResult = MessageBox.Show("Sind Sie sicher, dass Sie die Kostenstellen der markierten Arbeitswerte neu zuordnen wollen?",
                            "Kostenstellen neu zuordnen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If locDr = DialogResult.Yes Then
                For Each locLabourValue As LabourValueInfo In locSelectedItems
                    locLabourValue.IDCostCenter = Costcenter.IDCostCenter
                    SPAccess.GetInstance.LabourValues_Edit(locLabourValue,
                            FacessoGeneric.LoginInfo.IDUser)
                Next
            End If
        Else
            MessageBox.Show("Bitte w�hlen Sie die Arbeitswerte aus, denen Sie eine neue Kostenstelle zuordnen wollen!",
                            "Kostenstelle ausw�hlen:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        RefreshItems()
    End Sub

    Friend Sub LabourValueInfoAdd()
        Dim locFH As GetFrmLabourValueInfoAdd = FunctionHandler(Of GetFrmLabourValueInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Friend Sub LabourValueInfoEdit()
        Dim locFH As GetFrmLabourValueInfoEdit = FunctionHandler(Of GetFrmLabourValueInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Body,
                            My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Title,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub LabourValueInfoDelete()
        Dim locFH As GetFuncLabourValueDelete = FunctionHandler(Of GetFuncLabourValueDelete).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Body,
                            My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Title,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.DeleteItem(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub RefreshItems()
        Dim locLabourValueInfoCollection As LabourValueInfoCollection = SPAccess.GetInstance.GetLabourValueInfoCollection(myCurrentSortOrderString)
        myFrmInfoItemsManagerGeneric.InfoItems = locLabourValueInfoCollection
    End Sub

    Friend Sub ColumnClick()
        Select Case myFrmInfoItemsManagerGeneric.LastColumnClickEventArgs.Column

            Case 0
                myCurrentSortOrderString = "LabourValueNumber"
            Case 1
                myCurrentSortOrderString = "LabourValueName"
            Case Else
                myCurrentSortOrderString = "LabourValueNumber"
        End Select

    End Sub
End Class
