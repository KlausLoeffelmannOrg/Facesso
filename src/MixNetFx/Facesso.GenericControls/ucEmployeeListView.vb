Imports System.Windows.Forms
Imports Facesso.Data

Public Class ucEmployeeListView
    Inherits System.Windows.Forms.ListView

    Private myAutoGroup As Boolean
    Private myEmployeeInfoItems As EmployeeInfoItems
    Private myEmployeeSortOrder As EmployeeSortOrder
    Private myMaxDigitsPersonnelNumber As Byte
    Private myMaxDigitsCostCenterNo As Byte
    Private myDataTable As DataTable
    Private myLastSortColumn As String
    Private myCustomGroups As CustomListViewGroups(Of EmployeeInfo)
    Private myPersonnelNoGroupingResulution As Integer
    Private myOnlyActiveEmployees As Boolean
    Private myOnlyIncentiveEmployees As Boolean

    Sub New()
        MyBase.New()
        Me.FullRowSelect = True
        Me.View = Windows.Forms.View.Details
        Me.HideSelection = False
        myEmployeeSortOrder = EmployeeSortOrder.PersonnelNumber
        Me.Columns.Add("Personal-Nr.:", -2)
        Me.Columns.Add("Nachname/Vorname:", -2)
        Me.Columns.Add("Kostenstellenname:", -2)
        Me.Columns.Add("/-nummer:", -2)
        myLastSortColumn = "PersonnelNumber"
        myAutoGroup = True
        myPersonnelNoGroupingResulution = 100
        myOnlyActiveEmployees = True
        myOnlyIncentiveEmployees = False
        myCustomGroups = New CustomListViewGroups(Of EmployeeInfo)
    End Sub

    Public Sub AddCustomGroup(ByVal GroupName As String, ByVal eic As EmployeeInfoItems)
        myCustomGroups.Insert(0, New CustomListViewGroup(Of EmployeeInfo)(GroupName, eic))
        rebuildList()
    End Sub

    Public Sub SetCustomGroup(ByVal GroupName As String, ByVal eic As EmployeeInfoItems)
        If myCustomGroups.Contains(GroupName) Then
            myCustomGroups.Item(GroupName).InfoItems = eic
        Else
            myCustomGroups.Add(New CustomListViewGroup(Of EmployeeInfo)(GroupName, eic))
        End If
        rebuildList()
    End Sub

    Public Sub DeleteCustomGroup(ByVal GroupName As String, ByVal Refresh As Boolean)
        If GroupName Is Nothing Then Return
        If myCustomGroups.Contains(GroupName) Then
            Me.myCustomGroups.Remove(GroupName)
            If Refresh Then
                rebuildList()
            End If
        End If
    End Sub

    Public Sub AddSelectedEmployee(ByVal Employee As EmployeeInfo)
        For Each locELvi As EmployeeListViewItem In Me.SelectedItems
            If locELvi.IDEmployee = Employee.IDEmployee Then
                locELvi.Selected = True
            End If
        Next
    End Sub

    Public ReadOnly Property FirstSelectedEmployee() As EmployeeInfo
        Get
            If Me.SelectedIndices.Count = 0 Then
                Return Nothing
            End If
            Return Me.EmployeeInfoCollection.Item(New ActiveDev.IntKey(DirectCast(Me.SelectedItems(0), EmployeeListViewItem).IDEmployee))
        End Get
    End Property

    Public ReadOnly Property SelectedEmployees() As EmployeeInfoItems
        Get
            Dim locLvic As New EmployeeInfoItems
            For Each locLvi As EmployeeListViewItem In Me.SelectedItems
                locLvic.Add(Me.EmployeeInfoCollection(New ActiveDev.IntKey(DirectCast(locLvi, EmployeeListViewItem).IDEmployee)))
            Next
            Return locLvic
        End Get
    End Property

    Public Property EmployeeInfoCollection() As EmployeeInfoItems
        Get
            Return myEmployeeInfoItems
        End Get
        Set(ByVal value As EmployeeInfoItems)
            myEmployeeInfoItems = value
            If value IsNot Nothing Then
                SetMaxDigits()
                AssignToDataTable()
            End If
            rebuildList()
        End Set
    End Property

    Public Property EmployeeSortOrder() As EmployeeSortOrder
        Get
            Return myEmployeeSortOrder
        End Get
        Set(ByVal value As EmployeeSortOrder)
            myEmployeeSortOrder = value
            rebuildList()
        End Set
    End Property

    Public Property OnlyActiveEmployees() As Boolean
        Get
            Return myOnlyActiveEmployees
        End Get
        Set(ByVal value As Boolean)
            myOnlyActiveEmployees = value
            rebuildList()
        End Set
    End Property

    Public Property OnlyIncentiveEmployees() As Boolean
        Get
            Return myOnlyIncentiveEmployees
        End Get
        Set(ByVal value As Boolean)
            myOnlyIncentiveEmployees = value
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

        For Each locRow As DataRow In myDataTable.Rows
            If myCustomGroups Is Nothing Then
                locRow.Item("GroupNameIndex") = 0
            Else
                locRow.Item("GroupNameIndex") = myCustomGroups.GroupSortIndexOfID(Convert.ToInt32(locRow.Item("IDEmployee")))
            End If
        Next

        myDataTable.DefaultView.Sort = "GroupNameIndex DESC, " & EmployeeSortOrder.ToString & ", " & myLastSortColumn

        Dim locLastItem As ListViewItem = Nothing
        Dim locCurrentGroup As ListViewGroup = Nothing
        Dim LastDelta As Integer = -1
        Dim locCustomGroupIndex As Integer
        Dim locOldCustomGroupIndex As Integer = -1

        For Each locRow As DataRowView In myDataTable.DefaultView

            'TODO: ! Nicht, wenn diese in der Gruppe vorhanden sind!
            If (Not CBool(locRow("IsActive"))) And OnlyActiveEmployees Then
                Continue For
            End If

            'TODO: ! Nicht, wenn diese in der Gruppe vorhanden sind!
            If (Not CBool(locRow("IsIncentive"))) And OnlyIncentiveEmployees Then
                Continue For
            End If

            Dim locItem As New EmployeeListViewItem(CInt(locRow("IDEmployee")), _
                                                    CInt(locRow("PersonnelNumber")), _
                                                    locRow("LastName").ToString, _
                                                    locRow("CostCenterName").ToString, _
                                                    CInt(locRow("CostCenterNo")))
            If Not Convert.ToBoolean(locRow("IsIncentive")) Then
                locItem.ForeColor = Color.Blue
            End If

            If Not Convert.ToBoolean(locRow("IsActive")) Then
                locItem.ForeColor = Color.DarkGray
            End If

            Me.Items.Add(locItem)

            'Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
            If AutoGroup Then
                locCustomGroupIndex = CInt(locRow("GroupNameIndex"))
                If locCustomGroupIndex <> locOldCustomGroupIndex Then
                    If locCustomGroupIndex > 0 Then
                        locCurrentGroup = New ListViewGroup(myCustomGroups(locCustomGroupIndex - 1).GroupName)
                        Me.Groups.Add(locCurrentGroup)
                    Else
                        locCurrentGroup = Nothing
                    End If
                End If
                locOldCustomGroupIndex = locCustomGroupIndex

                If locCustomGroupIndex > 0 Then
                    locItem.Group = locCurrentGroup
                    Me.SelectedIndices.Add(locItem.Index)
                Else
                    If Me.EmployeeSortOrder = EmployeeSortOrder.LastName Or _
                        Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterName Or _
                        Me.EmployeeSortOrder = EmployeeSortOrder.PersonnelNumber Or _
                        Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterNo Then
                        If Me.EmployeeSortOrder = EmployeeSortOrder.PersonnelNumber Then
                            locItem.Tag = CInt(locRow("PersonnelNumber")) \ myPersonnelNoGroupingResulution
                        ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.LastName Then
                            locItem.Tag = AscW(locRow("LastName").ToString)
                        ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterNo Then
                            locItem.Tag = CInt(locRow("CostCenterNo"))
                        ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterName Then
                            locItem.Tag = CStr(locRow("CostCenterName"))
                        End If

                        If locCurrentGroup Is Nothing Then
                            If Me.EmployeeSortOrder = EmployeeSortOrder.PersonnelNumber Then
                                locCurrentGroup = New ListViewGroup("Mitarbeiter ab Nummer:" & locRow("PersonnelNumber").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.LastName Then
                                Dim locCharValue As Integer = AscW(locRow("LastName").ToString)
                                locCurrentGroup = New ListViewGroup("Mitarbeiter alphabetisch:" & ChrW(locCharValue))
                                Me.Groups.Add(locCurrentGroup)
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterName Then
                                locCurrentGroup = New ListViewGroup("Mitarbeiter mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterNo Then
                                locCurrentGroup = New ListViewGroup("Mitarbeiter ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        End If

                        If locLastItem IsNot Nothing Then
                            If Me.EmployeeSortOrder = EmployeeSortOrder.PersonnelNumber Then
                                If LastDelta > -1 Then
                                    If LastDelta <> (CInt(locItem.Tag) * myPersonnelNoGroupingResulution - CInt(locLastItem.Tag) * myPersonnelNoGroupingResulution) Then
                                        locCurrentGroup = New ListViewGroup("Mitarbeiter ab Nummer:" & locRow("PersonnelNumber").ToString)
                                        Me.Groups.Add(locCurrentGroup)
                                        GoTo Label
                                    End If
                                End If
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.LastName Then
                                Dim locCharValue As Integer = AscW(locRow("LastName").ToString)
                                If locCharValue <> CInt(locLastItem.Tag) Then
                                    locCurrentGroup = New ListViewGroup("Mitarbeiter alphabetisch:" & ChrW(locCharValue))
                                    Me.Groups.Add(locCurrentGroup)
                                End If
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterName Then
                                If locRow("CostCenterName").ToString <> CStr(locLastItem.Tag) Then
                                    locCurrentGroup = New ListViewGroup("Mitarbeiter mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                                    Me.Groups.Add(locCurrentGroup)
                                End If
                            ElseIf Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterNo Then
                                If CInt(locItem.Tag) <> CInt(locLastItem.Tag) Then
                                    locCurrentGroup = New ListViewGroup("Mitarbeiter ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                                    Me.Groups.Add(locCurrentGroup)
                                    GoTo Label
                                End If
                            End If

                            If Me.EmployeeSortOrder = EmployeeSortOrder.PersonnelNumber Or _
                                Me.EmployeeSortOrder = EmployeeSortOrder.CostCenterNo Then
                                LastDelta = CInt(locItem.Tag) * myPersonnelNoGroupingResulution - CInt(locLastItem.Tag) * myPersonnelNoGroupingResulution
                            End If
                        End If
Label:
                        locItem.Group = locCurrentGroup
                        locLastItem = locItem
                    End If
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
            .Add("IDEmployee", GetType(Integer))
            .Add("PersonnelNumber", GetType(String))
            .Add("LastName", GetType(String))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterNo", GetType(String))
            .Add("GroupNameIndex", GetType(Integer))
            .Add("IsActive", GetType(Boolean))
            .Add("IsIncentive", GetType(Boolean))
        End With

        For Each locEi As EmployeeInfo In myEmployeeInfoItems
            Dim locTc As DataRow = myDataTable.NewRow()
            locTc.Item("IDEmployee") = locEi.IDEmployee
            locTc.Item("PersonnelNumber") = locEi.PersonnelNumber.ToString(New String("0"c, myMaxDigitsPersonnelNumber))
            locTc.Item("LastName") = locEi.LastName & ", " & locEi.FirstName
            locTc.Item("CostCenterName") = locEi.CostCenterName
            locTc.Item("CostCenterNo") = locEi.CostCenterNo.ToString(New String("0"c, myMaxDigitsCostCenterNo))
            locTc.Item("IsActive") = locEi.IsActive
            locTc.Item("IsIncentive") = locEi.IsIncentive
            myDataTable.Rows.Add(locTc)
        Next
    End Sub

    'Ermittelt die höchste Anzahl der Ziffern in der Liste
    Private Sub SetMaxDigits()
        myMaxDigitsCostCenterNo = 0
        myMaxDigitsPersonnelNumber = 0
        For Each locWgi As EmployeeInfo In myEmployeeInfoItems
            If locWgi.CostCenterNo.ToString.Length > myMaxDigitsCostCenterNo Then
                myMaxDigitsCostCenterNo = CByte(locWgi.CostCenterNo.ToString.Length)
            End If
            If locWgi.PersonnelNumber.ToString.Length > myMaxDigitsPersonnelNumber Then
                myMaxDigitsPersonnelNumber = CByte(locWgi.PersonnelNumber.ToString.Length)
            End If
        Next
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        MyBase.OnColumnClick(e)
        myLastSortColumn = Me.EmployeeSortOrder.ToString
        Me.EmployeeSortOrder = DirectCast([Enum].ToObject(GetType(EmployeeSortOrder), e.Column), EmployeeSortOrder)
    End Sub
End Class

Public Class EmployeeListViewItem
    Inherits ListViewItem

    Private _IDEmployee As Integer

    Sub New(ByVal IDEmployee As Integer, ByVal PersonnelNumber As Integer, ByVal LastName As String, ByVal CostCenterName As String, ByVal CostCenterNo As Integer)
        MyBase.New(PersonnelNumber.ToString)
        _IDEmployee = IDEmployee
        Me.SubItems.Add(LastName)
        Me.SubItems.Add(CostCenterName)
        Me.SubItems.Add(CostCenterNo.ToString)
    End Sub

    Public Property IDEmployee() As Integer
        Get
            Return _IDEmployee
        End Get
        Set(ByVal value As Integer)
            _IDEmployee = value
        End Set
    End Property
End Class

Public Enum EmployeeSortOrder
    PersonnelNumber
    LastName
    CostCenterName
    CostCenterNo
End Enum

