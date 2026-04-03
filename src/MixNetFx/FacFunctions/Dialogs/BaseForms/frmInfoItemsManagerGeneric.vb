Imports System.Windows.Forms
Imports ActiveDev
Imports Facesso
Imports Facesso.data

Friend Class frmInfoItemsManagerGeneric(Of ItemType As IInfoItem)
    Inherits frmInfoItemsManagerBase

    Friend Delegate Sub HandleInfoItemAddDelegate()
    Friend Delegate Sub HandleInfoItemEditDelegate()
    Friend Delegate Sub HandleRefreshItemsDelegate()
    Friend Delegate Sub HandleInfoItemColumnClickDelegate()
    Friend Delegate Sub HandleInfoItemDeleteDelegate()
    Friend Delegate Sub HandleAssignCostcenterDelegate(ByVal Costcenter As CostcenterInfo)
    Friend Delegate Sub HandlePrintListDelegate()

    Private myInfoItems As InfoItems(Of ItemType)
    Private myLastColumnClickEventArgs As ColumnClickEventArgs
    Private myInfoItemAddDelegate As HandleInfoItemAddDelegate
    Private myInfoItemEditDelegate As HandleInfoItemEditDelegate
    Private myRefreshItemsDelegate As HandleRefreshItemsDelegate
    Private myInfoItemColumnClickDelegate As HandleInfoItemColumnClickDelegate
    Private myInfoItemDeleteDelegate As HandleInfoItemDeleteDelegate
    Private myAssignCostcenterDelegate As HandleAssignCostcenterDelegate
    Private myHandlePrintListDelegate As HandlePrintListDelegate

    Private myCostCenters As CostcenterInfoItems

    Sub New(ByVal InfoItemLocalizedTypeName As String)
        MyBase.new()
        Me.Text = InfoItemLocalizedTypeName + " - Stammdaten verwalten"
        For Each tsi As ToolStripItem In MyBase.EditToolStripMenuItem.DropDownItems
            If tsi.Text.Contains("%1") Then
                tsi.Text = tsi.Text.Replace("%1", InfoItemLocalizedTypeName)
            End If
        Next
        Me.Costcenters = Nothing
    End Sub

    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
    End Sub

    Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
        MyBase.OnFormClosed(e)
    End Sub

    Friend Overrides Sub OnInfoItemDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        myInfoItemEditDelegate.Invoke()
        RefreshItemsManager()
    End Sub

    Friend ReadOnly Property LastColumnClickEventArgs() As ColumnClickEventArgs
        Get
            Return myLastColumnClickEventArgs
        End Get
    End Property

    Friend Property InfoItems() As InfoItems(Of ItemType)
        Get
            Return myInfoItems
        End Get
        Set(ByVal value As InfoItems(Of ItemType))
            myInfoItems = value
            If myInfoItems IsNot Nothing Then
                If myInfoItems.Count > 0 Then
                    arvInfoItems.List = value
                End If
            End If
        End Set
    End Property

    Friend Property Costcenters() As CostcenterInfoItems
        Get
            Return myCostCenters
        End Get
        Set(ByVal value As CostcenterInfoItems)
            myCostCenters = value
            If value IsNot Nothing Then
                tslCostcenters.Enabled = True
                tscCostCenters.Enabled = True
                tsbAssignCostcenter.Enabled = True
                tscCostCenters.Items.Clear()
                For Each locCcItem As CostcenterInfo In value
                    tscCostCenters.Items.Add(locCcItem)
                Next
            Else
                tscCostCenters.Items.Clear()
                tslCostcenters.Enabled = False
                tscCostCenters.Enabled = False
                tsbAssignCostcenter.Enabled = False
            End If
        End Set
    End Property

    Public ReadOnly Property SelectedInfoItem() As ItemType
        Get
            If arvInfoItems.SelectedItems.Count = 0 Then
                Return Nothing
            Else
                Return CType(arvInfoItems.SelectedItems(0).Tag, ItemType)
            End If
        End Get
    End Property

    Public ReadOnly Property SelectedInfoItems() As List(Of ItemType)
        Get
            If arvInfoItems.SelectedItems.Count = 0 Then
                Return Nothing
            Else
                Dim locSelectedItems As New List(Of ItemType)
                For Each locItem As ListViewItem In arvInfoItems.SelectedItems
                    locSelectedItems.Add(DirectCast(locItem.Tag, ItemType))
                Next
                Return locSelectedItems
            End If
        End Get
    End Property

    Friend WriteOnly Property InfoItemAddDelegate() As HandleInfoItemAddDelegate
        Set(ByVal value As HandleInfoItemAddDelegate)
            myInfoItemAddDelegate = value
            If value IsNot Nothing Then
                AddHandler ItemAddToolStripMenuItem.Click, AddressOf UICaused_ItemAdd
                AddHandler ItemAddToolStripButton.Click, AddressOf UICaused_ItemAdd
            End If
        End Set
    End Property

    Friend WriteOnly Property InfoItemDeleteDelegate() As HandleInfoItemDeleteDelegate
        Set(ByVal value As HandleInfoItemDeleteDelegate)
            myInfoItemDeleteDelegate = value
            If value IsNot Nothing Then
                AddHandler ItemDeleteToolStripMenuItem.Click, AddressOf UICaused_ItemDelete
                AddHandler ItemDeleteToolStripButton.Click, AddressOf UICaused_ItemDelete
            End If
        End Set
    End Property

    Friend WriteOnly Property InfoItemEditDelegate() As HandleInfoItemEditDelegate
        Set(ByVal value As HandleInfoItemEditDelegate)
            myInfoItemEditDelegate = value
            If value IsNot Nothing Then
                AddHandler ItemEditToolStripMenuItem.Click, AddressOf UICaused_ItemEdit
                AddHandler ItemEditToolStripButton.Click, AddressOf UICaused_ItemEdit
            End If
        End Set
    End Property

    Friend WriteOnly Property PrintListDelegate() As HandlePrintListDelegate
        Set(ByVal value As HandlePrintListDelegate)
            myHandlePrintListDelegate = value
            If value IsNot Nothing Then
                AddHandler ItemPrintToolStripButton.Click, AddressOf UICaused_PrintList
                AddHandler PrintToolStripMenuItem.Click, AddressOf UICaused_PrintList
            End If
        End Set
    End Property



    Friend WriteOnly Property RefreshItemsDelegate() As HandleRefreshItemsDelegate
        Set(ByVal value As HandleRefreshItemsDelegate)
            myRefreshItemsDelegate = value
        End Set
    End Property

    Friend WriteOnly Property InfoItemColumnClickDelegate() As HandleInfoItemColumnClickDelegate
        Set(ByVal value As HandleInfoItemColumnClickDelegate)
            myInfoItemColumnClickDelegate = value
            If value IsNot Nothing Then
                AddHandler MyBase.InfoItemsColumnClick, AddressOf UICaused_InfoItemClicked
            End If
        End Set
    End Property

    Friend WriteOnly Property AssignCostcenterDelegate() As HandleAssignCostcenterDelegate
        Set(ByVal value As HandleAssignCostcenterDelegate)
            myAssignCostcenterDelegate = value
            If value IsNot Nothing Then
                AddHandler tsbAssignCostcenter.Click, AddressOf UICaused_AssignCostcenterClicked
            End If
        End Set
    End Property

    Private Sub UICaused_ItemAdd(ByVal sender As Object, ByVal e As EventArgs)
        myInfoItemAddDelegate.Invoke()
        RefreshItemsManager()
    End Sub

    Private Sub UICaused_ItemEdit(ByVal sender As Object, ByVal e As EventArgs)
        myInfoItemEditDelegate.Invoke()
        RefreshItemsManager()
    End Sub

    Private Sub UICaused_PrintList(ByVal sender As Object, ByVal e As EventArgs)
        myHandlePrintListDelegate.Invoke()
    End Sub

    Private Sub UICaused_InfoItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        myLastColumnClickEventArgs = e
        myInfoItemColumnClickDelegate.Invoke()
        RefreshItemsManager()
    End Sub

    Private Sub UICaused_ItemDelete(ByVal sender As Object, ByVal e As EventArgs)
        myInfoItemDeleteDelegate.Invoke()
        RefreshItemsManager()
    End Sub

    Private Sub UICaused_AssignCostcenterClicked(ByVal sender As Object, ByVal e As EventArgs)
        myAssignCostcenterDelegate.Invoke(DirectCast(tscCostCenters.SelectedItem, CostcenterInfo))
    End Sub

    Private Sub RefreshItemsManager()

        Dim locIItem As IInfoItem = Nothing
        If arvInfoItems.SelectedItems.Count > 0 Then
            locIItem = DirectCast(arvInfoItems.SelectedItems(0).Tag, IInfoItem)
        End If

        myRefreshItemsDelegate.Invoke()

        'Durch die Liste galoppieren, und schauen, ob wir es wiederfinden.
        'Wenn ja, dann selektieren!
        If locIItem IsNot Nothing Then
            For Each locLvi As ListViewItem In arvInfoItems.Items
                If DirectCast(locLvi.Tag, IInfoItem).DataID = locIItem.DataID Then
                    locLvi.Selected = True
                    locLvi.EnsureVisible()
                    Return
                End If
            Next
        End If
    End Sub
End Class
