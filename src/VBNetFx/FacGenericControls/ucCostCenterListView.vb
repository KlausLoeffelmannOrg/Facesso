Imports System.Windows.Forms
Imports Facesso.Data

Public Class ucCostCenterListView
    Inherits System.Windows.Forms.ListView

    Private myAutoGroup As Boolean
    Private myCostCenterInfoCollection As CostcenterInfoItems
    Private myCostCenterSortOrder As CostCenterSortOrder
    Private myMaxDigitsCostCenterNo As Byte
    Private myDataTable As DataTable
    Private myLastSortColumn As String
    Private myCostCenterNoGroupingResolution As Integer

    Sub New()
        MyBase.New()
        Me.FullRowSelect = True
        Me.View = Windows.Forms.View.Details
        Me.HideSelection = False
        myCostCenterSortOrder = FrontEnd.CostCenterSortOrder.CostCenterNumber
        Me.Columns.Add("Nr.:", -2)
        Me.Columns.Add("Kostenstellenname:", -2)
        Me.Columns.Add("Beschreibung:", -2)
        myLastSortColumn = "CostCenterNumber"
        myAutoGroup = True
        myCostCenterNoGroupingResolution = 10
    End Sub

    Public ReadOnly Property FirstSelectedCostCenter() As CostcenterInfo
        Get
            If Me.SelectedIndices.Count = 0 Then
                Return Nothing
            End If
            Return Me.CostCenterInfoCollection(New ActiveDev.IntKey(Integer.Parse(Me.SelectedItems(0).Name)))
        End Get
    End Property

    Public ReadOnly Property SelectedCostCenters() As CostcenterInfoItems
        Get
            Dim locLvic As New CostcenterInfoItems
            For Each locLvi As ListViewItem In Me.SelectedItems
                locLvic.Add(Me.CostCenterInfoCollection(New ActiveDev.IntKey(Integer.Parse(locLvi.Name))))
            Next
            Return locLvic
        End Get
    End Property

    Public Property CostCenterInfoCollection() As CostcenterInfoItems
        Get
            Return myCostCenterInfoCollection
        End Get
        Set(ByVal value As CostcenterInfoItems)
            myCostCenterInfoCollection = value
            If value IsNot Nothing Then
                SetMaxDigits()
                AssignToDataTable()
            End If
            rebuildList()
        End Set
    End Property

    Public Property CostCenterSortOrder() As CostCenterSortOrder
        Get
            Return myCostCenterSortOrder
        End Get
        Set(ByVal value As CostCenterSortOrder)
            myCostCenterSortOrder = value
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

        myDataTable.DefaultView.Sort = CostCenterSortOrder.ToString & ", " & myLastSortColumn

        Dim locLastItem As ListViewItem = Nothing
        Dim locCurrentGroup As ListViewGroup = Nothing
        Dim LastDelta As Integer = -1

        For Each locRow As DataRowView In myDataTable.DefaultView
            Dim locItem As New ListViewItem(locRow("CostCenterNumber").ToString)
            locItem.SubItems.Add(locRow("CostCenterName").ToString)
            locItem.SubItems.Add(locRow("CostCenterDescription").ToString)
            locItem.Name = locRow("IDCostCenter").ToString
            Me.Items.Add(locItem)

            'Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
            If AutoGroup Then
                If Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterName Or _
                    Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterNumber Or _
                    Me.CostCenterSortOrder = FrontEnd.CostCenterSortOrder.CostCenterDescription Then
                    If Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterNumber Then
                        locItem.Tag = CInt(locRow("CostCenterNumber")) \ myCostCenterNoGroupingResolution
                    ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterName Then
                        locItem.Tag = AscW(locRow("CostCenterName").ToString)
                    ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterDescription Then
                        locItem.Tag = CStr(locRow("CostCenterDescription"))
                    End If

                    If locCurrentGroup Is Nothing Then
                        If Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterNumber Then
                            locCurrentGroup = New ListViewGroup("Kostenstellen ab Nummer:" & locRow("CostCenterNumber").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterName Then
                            Dim locCharValue As Integer = AscW(locRow("CostCenterName").ToString)
                            locCurrentGroup = New ListViewGroup("Kostenstellennamen alphabetisch:" & ChrW(locCharValue))
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterDescription Then
                            locCurrentGroup = New ListViewGroup("Kostenstellenbeschreibungen alphabetisch:" & locRow("CostCenterDescription").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        End If
                    End If

                    If locLastItem IsNot Nothing Then
                        If Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterNumber Then
                            If LastDelta > -1 Then
                                If LastDelta <> (CInt(locItem.Tag) * myCostCenterNoGroupingResolution - CInt(locLastItem.Tag) * myCostCenterNoGroupingResolution) Then
                                    locCurrentGroup = New ListViewGroup("Kostenstellen ab Nummer:" & locRow("CostCenterNumber").ToString)
                                    Me.Groups.Add(locCurrentGroup)
                                    GoTo Label
                                End If
                            End If
                        ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterName Then
                            Dim locCharValue As Integer = AscW(locRow("CostCenterName").ToString)
                            If locCharValue <> CInt(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("ProduktivKostenstellennamen alphabetisch:" & ChrW(locCharValue))
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        ElseIf Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterDescription Then
                            If locRow("CostCenterDescription").ToString <> CStr(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Kostenstellenbeschreibungen alphabetisch:" & locRow("CostCenterDescription").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        End If

                        If Me.CostCenterSortOrder = CostCenterSortOrder.CostCenterNumber Then
                            LastDelta = CInt(locItem.Tag) * myCostCenterNoGroupingResolution - CInt(locLastItem.Tag) * myCostCenterNoGroupingResolution
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
        Me.EndUpdate()
    End Sub

    Private Sub AssignToDataTable()
        myDataTable = New DataTable()
        With myDataTable.Columns
            .Add("IDCostCenter", GetType(Integer))
            .Add("CostCenterNumber", GetType(String))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterDescription", GetType(String))
        End With

        For Each locWgi As CostcenterInfo In myCostCenterInfoCollection
            Dim locTc As DataRow = myDataTable.NewRow()
            locTc.Item("IDCostCenter") = locWgi.IDCostCenter
            locTc.Item("CostCenterNumber") = locWgi.CostCenterNo
            locTc.Item("CostCenterName") = locWgi.CostCenterName
            locTc.Item("CostCenterDescription") = locWgi.CostCenterDescription
            myDataTable.Rows.Add(locTc)
        Next
    End Sub

    'Ermittelt die höchste Anzahl der Ziffern in der Liste
    Private Sub SetMaxDigits()
        myMaxDigitsCostCenterNo = 0
        For Each locWgi As CostcenterInfo In myCostCenterInfoCollection
            If locWgi.CostCenterNo.ToString.Length > myMaxDigitsCostCenterNo Then
                myMaxDigitsCostCenterNo = CByte(locWgi.CostCenterNo.ToString.Length)
            End If
        Next
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        MyBase.OnColumnClick(e)
        myLastSortColumn = Me.CostCenterSortOrder.ToString
        Me.CostCenterSortOrder = DirectCast([Enum].ToObject(GetType(CostCenterSortOrder), e.Column), CostCenterSortOrder)
    End Sub

End Class

Public Enum CostCenterSortOrder
    CostCenterNumber
    CostCenterName
    CostCenterDescription
End Enum
