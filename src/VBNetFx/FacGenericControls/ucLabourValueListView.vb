Imports Facesso.Data

Public Class ucLabourValueListView
    Inherits System.Windows.Forms.ListView

    Private myAutoGroup As Boolean
    Private myLabourValueInfoCollection As LabourValueInfoCollection
    Private myLabourValueSortOrder As LabourValuesSortOrder
    Private myMaxDigitsLabourValueNo As Byte
    Private myMaxDigitsCostCenterNo As Byte
    Private myDataTable As DataTable
    Private myLastSortColumn As String

    Sub New()
        MyBase.New()
        Me.FullRowSelect = True
        Me.HideSelection = False
        Me.View = Windows.Forms.View.Details
        myLabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber
        Me.Columns.Add("Arbeitswert-Nr.:", -2)
        Me.Columns.Add("Arbeitswert-Name/Tätigkeits-Beschreibung:", -2)
        Me.Columns.Add("Kostenstellenname:", -2)
        Me.Columns.Add("/nummer:", -2)
        Me.Columns.Add("Basiswertname", -2)
        Me.Columns.Add("Basiswert", -2)
        Me.Columns.Add("Einheit", -2)
        myLastSortColumn = "LabourValueNumber"
        myAutoGroup = True
    End Sub

    Public Property LabourValueSortOrder() As LabourValuesSortOrder
        Get
            Return myLabourValueSortOrder
        End Get
        Set(ByVal value As LabourValuesSortOrder)
            myLabourValueSortOrder = value
            rebuildList()
        End Set
    End Property

    Public Property LabourValues() As LabourValueInfoCollection
        Get
            Return myLabourValueInfoCollection
        End Get
        Set(ByVal value As LabourValueInfoCollection)
            myLabourValueInfoCollection = value
            If value IsNot Nothing Then
                SetMaxDigits()
            End If
            AssignToDataTable()
            rebuildList()
        End Set
    End Property

    Public ReadOnly Property FirstSelectedLabourValue() As LabourValueInfo
        Get
            If Me.SelectedIndices.Count = 0 Then
                Return Nothing
            End If
            Return Me.LabourValues(New ActiveDev.IntKey(Integer.Parse(Me.SelectedItems(0).Name)))
        End Get
    End Property

    Public ReadOnly Property SelectedLabourValues() As LabourValueInfoCollection
        Get
            Dim locLvic As New LabourValueInfoCollection
            For Each locLvi As ListViewItem In Me.SelectedItems
                locLvic.Add(Me.LabourValues(New ActiveDev.IntKey(Integer.Parse(locLvi.Name))))
            Next
            Return locLvic
        End Get
    End Property

    Public Sub SelectLabourValue(ByVal labourValue As LabourValueInfo, ByVal EnsureVisible As Boolean)
        For Each locLvi As ListViewItem In Me.SelectedItems
            If Integer.Parse(locLvi.Name) = labourValue.IDLabourValue Then
                locLvi.Selected = True
                If EnsureVisible Then
                    locLvi.EnsureVisible()
                End If
            End If
        Next
    End Sub

    Public Property AutoGroup() As Boolean
        Get
            Return myAutoGroup
        End Get
        Set(ByVal value As Boolean)
            myAutoGroup = value
            rebuildList()
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

        myDataTable.DefaultView.Sort = LabourValueSortOrder.ToString & ", " & myLastSortColumn

        Dim locLastItem As ListViewItem = Nothing
        Dim locCurrentGroup As ListViewGroup = Nothing
        Dim LastDelta As Integer = -1

        For Each locRow As DataRowView In myDataTable.DefaultView
            Dim locItem As New ListViewItem(locRow("LabourValueNumber").ToString)
            locItem.SubItems.Add(locRow("LabourValueName").ToString)
            locItem.SubItems.Add(locRow("CostCenterName").ToString)
            locItem.SubItems.Add(locRow("CostCenterNo").ToString)
            locItem.SubItems.Add(locRow("BaseValueSynonym").ToString)
            locItem.SubItems.Add(locRow("TeHMin").ToString)
            locItem.SubItems.Add(locRow("Dimension").ToString)
            locItem.Name = locRow("IDLabourValue").ToString
            Me.Items.Add(locItem)

            'Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
            If AutoGroup Then
                If Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueName Or _
                    Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterName Or _
                    Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber Or _
                    Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterNo Then
                    If Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber Then
                        locItem.Tag = CInt(locRow("LabourValueNumber"))
                    ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueName Then
                        locItem.Tag = AscW(locRow("LabourValueName").ToString)
                    ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterNo Then
                        locItem.Tag = CInt(locRow("CostCenterNo"))
                    ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterName Then
                        locItem.Tag = CStr(locRow("CostCenterName"))
                    End If

                    If locCurrentGroup Is Nothing Then
                        If Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber Then
                            locCurrentGroup = New ListViewGroup("Arbeitswerte ab Nummer:" & locRow("LabourValueNumber").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueName Then
                            Dim locCharValue As Integer = AscW(locRow("LabourValueName").ToString)
                            locCurrentGroup = New ListViewGroup("Arbeitswerte alphabetisch:" & ChrW(locCharValue))
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterName Then
                            locCurrentGroup = New ListViewGroup("Arbeitswerte mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterNo Then
                            locCurrentGroup = New ListViewGroup("Arbeitswerte ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                            Me.Groups.Add(locCurrentGroup)
                        End If
                    End If

                    If locLastItem IsNot Nothing Then
                        If Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber Then
                            If LastDelta > -1 Then
                                If LastDelta <> (CInt(locItem.Tag) - CInt(locLastItem.Tag)) Then
                                    locCurrentGroup = New ListViewGroup("Arbeitswerte ab Nummer:" & locRow("LabourValueNumber").ToString)
                                    Me.Groups.Add(locCurrentGroup)
                                    GoTo Label
                                End If
                            End If
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueName Then
                            Dim locCharValue As Integer = AscW(locRow("LabourValueName").ToString)
                            If locCharValue <> CInt(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Arbeitswerte alphabetisch:" & ChrW(locCharValue))
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterName Then
                            If locRow("CostCenterName").ToString <> CStr(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Arbeitswerte mit Kostenstellen namens:" & locRow("CostCenterName").ToString)
                                Me.Groups.Add(locCurrentGroup)
                            End If
                        ElseIf Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterNo Then
                            If CInt(locItem.Tag) <> CInt(locLastItem.Tag) Then
                                locCurrentGroup = New ListViewGroup("Arbeitswerte ab Kostenstellennr:" & locRow("CostCenterNo").ToString)
                                Me.Groups.Add(locCurrentGroup)
                                GoTo Label
                            End If
                        End If

                        If Me.LabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber Or _
                            Me.LabourValueSortOrder = LabourValuesSortOrder.CostCenterNo Then
                            LastDelta = CInt(locItem.Tag) - CInt(locLastItem.Tag)
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
        Me.Columns(4).Width = -1
        Me.Columns(5).Width = -1
        Me.EndUpdate()
    End Sub

    Private Sub AssignToDataTable()
        If myLabourValueInfoCollection Is Nothing Then
            myDataTable = Nothing
            Return
        End If
        myDataTable = New DataTable()
        With myDataTable.Columns
            .Add("IDLabourValue", GetType(Integer))
            .Add("LabourValueNumber", GetType(String))
            .Add("LabourValueName", GetType(String))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterNo", GetType(String))
            .Add("BaseValueSynonym", GetType(String))
            .Add("TeHMin", GetType(String))
            .Add("Dimension", GetType(String))
        End With

        For Each locLbi As LabourValueInfo In myLabourValueInfoCollection
            Dim locTc As DataRow = myDataTable.NewRow()
            locTc.Item("IDLabourValue") = locLbi.IDLabourValue
            locTc.Item("LabourValueNumber") = locLbi.LabourValueNumber.ToString(New String("0"c, myMaxDigitsLabourValueNo))
            locTc.Item("LabourValueName") = locLbi.LabourValueName
            locTc.Item("CostCenterName") = locLbi.CostCenterName
            locTc.Item("CostCenterNo") = locLbi.CostCenterNo.ToString(New String("0"c, myMaxDigitsCostCenterNo))
            locTc.Item("BaseValueSynonym") = locLbi.BaseValueSynonym
            locTc.Item("TeHMin") = locLbi.TeHMin.ToString("#,##0" & IIf(locLbi.BaseValuePrecision = 0, "", "." & New String("0"c, locLbi.BaseValuePrecision)).ToString)
            locTc.Item("Dimension") = locLbi.TeHMin
            myDataTable.Rows.Add(locTc)
        Next
    End Sub

    'TODO: Ausformulieren - Ermittelt die höchste Anzahl der Ziffern in der Liste
    Private Sub SetMaxDigits()
        myMaxDigitsCostCenterNo = 0
        myMaxDigitsLabourValueNo = 0
        For Each locLbi As LabourValueInfo In myLabourValueInfoCollection
            If locLbi.CostCenterNo.ToString.Length > myMaxDigitsCostCenterNo Then
                myMaxDigitsCostCenterNo = CByte(locLbi.CostCenterNo.ToString.Length)
            End If
            If locLbi.LabourValueNumber.ToString.Length > myMaxDigitsLabourValueNo Then
                myMaxDigitsLabourValueNo = CByte(locLbi.LabourValueNumber.ToString.Length)
            End If
        Next
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        MyBase.OnColumnClick(e)
        myLastSortColumn = Me.LabourValueSortOrder.ToString
        Me.LabourValueSortOrder = DirectCast([Enum].ToObject(GetType(LabourValuesSortOrder), e.Column), LabourValuesSortOrder)
    End Sub
End Class

Public Enum LabourValuesSortOrder
    LabourValueNumber
    LabourValueName
    CostCenterName
    CostCenterNo
    BaseValueSynonym
    TeHMin
    Dimension
End Enum
