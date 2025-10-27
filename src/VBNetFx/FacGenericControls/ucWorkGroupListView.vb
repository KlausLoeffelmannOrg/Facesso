Imports System.Windows.Forms
Imports Facesso.Data

Public Class ucWorkGroupListView
    Inherits System.Windows.Forms.ListView

    Private myAutoGroup As Boolean
    Private myWorkGroupInfoCollection As WorkGroupInfoItems
    Private myWorkGroupSortOrder As WorkGroupSortOrder
    Private myMaxDigitsWorkGroupNo As Byte
    Private myMaxDigitsCostCenterNo As Byte
    Private myDataTable As DataTable
    Private myLastSortColumn As String
    Private myOnlyActiveWorkgroups As Boolean
    Private myWorkGroupNoGroupingResolution As Integer

    Sub New()
        MyBase.New()
        Me.FullRowSelect = True
        Me.View = Windows.Forms.View.Details
        Me.HideSelection = False
        myWorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber
        Me.Columns.Add("Produktiv-Site-Nr.:", -2)
        Me.Columns.Add("Produktiv-Site-Name:", -2)
        Me.Columns.Add("Kostenstellenname:", -2)
        Me.Columns.Add("/nummer:", -2)
        myLastSortColumn = "WorkGroupNumber"
        myAutoGroup = True
        myOnlyActiveWorkgroups = True
        myWorkGroupNoGroupingResolution = 10
    End Sub

    Public ReadOnly Property FirstSelectedWorkGroup() As WorkGroupInfo
        Get
            If Me.SelectedIndices.Count = 0 Then
                Return Nothing
            End If
            Return Me.WorkGroupInfoItems(New ActiveDev.IntKey(Integer.Parse(Me.SelectedItems(0).Name)))
        End Get
    End Property

    Public ReadOnly Property SelectedWorkGroups() As WorkGroupInfoItems
        Get
            Dim locLvic As New WorkGroupInfoItems
            For Each locLvi As ListViewItem In Me.SelectedItems
                locLvic.Add(Me.WorkGroupInfoItems(New ActiveDev.IntKey(Integer.Parse(locLvi.Name))))
            Next
            Return locLvic
        End Get
    End Property

    Public ReadOnly Property CheckedWorkGroups() As WorkGroupInfoItems
        Get
            Dim locLvic As New WorkGroupInfoItems
            For Each locLvi As ListViewItem In Me.CheckedItems
                locLvic.Add(Me.WorkGroupInfoItems(New ActiveDev.IntKey(Integer.Parse(locLvi.Name))))
            Next
            Return locLvic
        End Get
    End Property

    Public Property WorkGroupInfoItems() As WorkGroupInfoItems
        Get
            Return myWorkGroupInfoCollection
        End Get
        Set(ByVal value As WorkGroupInfoItems)
            myWorkGroupInfoCollection = value
            If value IsNot Nothing Then
                SetMaxDigits()
                AssignToDataTable()
            End If
            rebuildList()
        End Set
    End Property

    Public Property WorkGroupSortOrder() As WorkGroupSortOrder
        Get
            Return myWorkGroupSortOrder
        End Get
        Set(ByVal value As WorkGroupSortOrder)
            myWorkGroupSortOrder = value
            rebuildList()
        End Set
    End Property

    Public Property OnlyActiveWorkgroups() As Boolean
        Get
            Return myOnlyActiveWorkgroups
        End Get
        Set(ByVal value As Boolean)
            myOnlyActiveWorkgroups = value
            rebuildList()
        End Set
    End Property

    Public Property AutoGroup() As Boolean
        Get
            Return myAutoGroup
        End Get
        Set(ByVal value As Boolean)
            myAutoGroup = value
        End Set
    End Property

    Private Sub rebuildList()
        Me.BeginUpdate()
        Me.Items.Clear()
        Me.Groups.Clear()
        If myDataTable Is Nothing Then
            Me.EndUpdate()
            Return
        End If

        myDataTable.DefaultView.Sort = WorkGroupSortOrder.ToString & ", " & myLastSortColumn

        Dim locLastItem As ListViewItem = Nothing
        Dim locCurrentGroup As ListViewGroup = Nothing
        Dim LastDelta As Integer = -1

        For Each locRow As DataRowView In myDataTable.DefaultView
            If OnlyActiveWorkgroups And (Not CBool(locRow("IsActive"))) Then
                Continue For
            End If
            Dim locItem As New ListViewItem(locRow("WorkGroupNumber").ToString)
            locItem.SubItems.Add(locRow("WorkGroupName").ToString)
            locItem.SubItems.Add(locRow("CostCenterName").ToString)
            locItem.SubItems.Add(locRow("CostCenterNo").ToString)
            locItem.Name = locRow("IDWorkGroup").ToString
            If Convert.ToBoolean(locRow("HasProductionData")) Then
                locItem.Font = New Font(locItem.Font, FontStyle.Bold)
            End If
            If Not Convert.ToBoolean(locRow("IsActive")) Then
                locItem.ForeColor = Color.DarkGray
            End If
            Me.Items.Add(locItem)

            'Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
            If AutoGroup Then
                If Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupName Or _
                    Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterName Or _
                    Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber Or _
                    Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterNo Then
                    If Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber Then
                        locItem.Tag = CInt(locRow("WorkGroupNumber")) \ myWorkGroupNoGroupingResolution
                    ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupName Then
                        locItem.Tag = AscW(locRow("WorkGroupName").ToString)
                    ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterNo Then
                        locItem.Tag = CInt(locRow("CostCenterNo"))
                    ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterName Then
                        locItem.Tag = CStr(locRow("CostCenterName"))
                    End If

                    If locCurrentGroup Is Nothing Then
                        If Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber Then
                            locCurrentGroup = New ListViewGroup("Produktiv-Sites ab Nummer:" & locRow("WorkGroupNumber").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupName Then
                            Dim locCharValue As Integer = AscW(locRow("WorkGroupName").ToString)
                            locCurrentGroup = New ListViewGroup("Produktiv-Sites alphabetisch:" & ChrW(locCharValue))
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterName Then
                            locCurrentGroup = New ListViewGroup("Produktiv-Sites mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterNo Then
                            locCurrentGroup = New ListViewGroup("Produktiv-Sites ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        End If
                    End If

                    If locLastItem IsNot Nothing Then
                        If Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber Then
                            If LastDelta > -1 Then
                                If LastDelta <> (CInt(locItem.Tag) * myWorkGroupNoGroupingResolution - CInt(locLastItem.Tag) * myWorkGroupNoGroupingResolution) Then
                                    locCurrentGroup = New ListViewGroup("Produktiv-Sites ab Nummer:" & locRow("WorkGroupNumber").ToString)
                                    Me.Groups.Add(locCurrentGroup)
                                    GoTo Label
                                End If
                            End If
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupName Then
                            Dim locCharValue As Integer = AscW(locRow("WorkGroupName").ToString)
                            If locCharValue <> CInt(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Produktiv-Sites alphabetisch:" & ChrW(locCharValue))
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterName Then
                            If locRow("CostCenterName").ToString <> CStr(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Produktiv-Sites mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        ElseIf Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterNo Then
                            If CInt(locItem.Tag) <> CInt(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Produktiv-Sites ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                                Me.Groups.Add(locCurrentGroup)
                                GoTo Label
                            End If
                        End If

                        If Me.WorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber Or _
                            Me.WorkGroupSortOrder = WorkGroupSortOrder.CostCenterNo Then
                            LastDelta = CInt(locItem.Tag) * myWorkGroupNoGroupingResolution - CInt(locLastItem.Tag) * myWorkGroupNoGroupingResolution
                        End If
                    End If
Label:
                    locItem.Group = locCurrentGroup
                    locLastItem = locItem
                End If
            End If
        Next

        Me.Columns(0).Width = -2
        Me.Columns(1).Width = -2
        Me.Columns(2).Width = -2
        Me.Columns(3).Width = -2
        Me.EndUpdate()
    End Sub

    Private Sub AssignToDataTable()
        myDataTable = New DataTable()
        With myDataTable.Columns
            .Add("IDWorkGroup", GetType(Integer))
            .Add("WorkGroupNumber", GetType(String))
            .Add("WorkGroupName", GetType(String))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterNo", GetType(String))
            .Add("HasProductionData", GetType(Boolean))
            .Add("IsActive", GetType(Boolean))
        End With

        For Each locWgi As WorkGroupInfo In myWorkGroupInfoCollection
            Dim locTc As DataRow = myDataTable.NewRow()
            locTc.Item("IDWorkGroup") = locWgi.IDWorkGroup
            locTc.Item("WorkGroupNumber") = locWgi.WorkGroupNumber.ToString(New String("0"c, myMaxDigitsWorkGroupNo))
            locTc.Item("WorkGroupName") = locWgi.WorkGroupName
            locTc.Item("CostCenterName") = locWgi.CostCenterName
            locTc.Item("CostCenterNo") = locWgi.CostCenterNo.ToString(New String("0"c, myMaxDigitsCostCenterNo))
            locTc.Item("HasProductionData") = locWgi.HasProductionData
            locTc.Item("IsActive") = locWgi.IsActive
            myDataTable.Rows.Add(locTc)
        Next
    End Sub

    'Ermittelt die höchste Anzahl der Ziffern in der Liste
    Private Sub SetMaxDigits()
        myMaxDigitsCostCenterNo = 0
        myMaxDigitsWorkGroupNo = 0
        For Each locWgi As WorkGroupInfo In myWorkGroupInfoCollection
            If locWgi.CostCenterNo.ToString.Length > myMaxDigitsCostCenterNo Then
                myMaxDigitsCostCenterNo = CByte(locWgi.CostCenterNo.ToString.Length)
            End If
            If locWgi.WorkGroupNumber.ToString.Length > myMaxDigitsWorkGroupNo Then
                myMaxDigitsWorkGroupNo = CByte(locWgi.WorkGroupNumber.ToString.Length)
            End If
        Next
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        MyBase.OnColumnClick(e)
        myLastSortColumn = Me.WorkGroupSortOrder.ToString
        Me.WorkGroupSortOrder = DirectCast([Enum].ToObject(GetType(WorkGroupSortOrder), e.Column), WorkGroupSortOrder)
    End Sub

End Class

Public Enum WorkGroupSortOrder
    WorkGroupNumber
    WorkGroupName
    CostCenterName
    CostCenterNo
End Enum

