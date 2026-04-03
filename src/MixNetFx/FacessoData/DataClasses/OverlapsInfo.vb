Imports ActiveDev
Imports System.Data.SQLClient
Imports System.Collections.ObjectModel

Public Class OverlapsInfoItem
    Private _IDOverlapInfo As Integer
    Private _EmployeeInfo As EmployeeInfo
    Private _WorkgroupInfo As WorkGroupInfo
    Private _ProductionDate As Date
    Private _Shift As Byte
    Private _ShiftStart As Date
    Private _ShiftEnd As Date
    Private _OverlapsExternal As Boolean

    Sub New(ByVal EmployeeInfo As EmployeeInfo, ByVal WorkgroupInfo As WorkGroupInfo, _
            ByVal ProductionDate As Date, ByVal Shift As Byte, _
            ByVal ShiftStart As Date, ByVal ShiftEnd As Date)
        _EmployeeInfo = EmployeeInfo
        _WorkgroupInfo = WorkgroupInfo
        _ProductionDate = ProductionDate
        _Shift = Shift
        _ShiftStart = ShiftStart
        _ShiftEnd = ShiftEnd
    End Sub

    Sub New(ByVal EmployeeInfo As EmployeeInfo, ByVal dr As SqlDataReader)
        _EmployeeInfo = EmployeeInfo
        _OverlapsExternal = True
        With Me
            .WorkgroupInfo = New WorkGroupInfo(dr, WorkGroupInfoItemsGetType.JoinedWithCostCenter)
            .ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"))
            .Shift = dr.GetByte(dr.GetOrdinal("Shift"))
            .ShiftStart = dr.GetDateTime(dr.GetOrdinal("ShiftStart"))
            .ShiftEnd = dr.GetDateTime(dr.GetOrdinal("ShiftEnd"))
        End With
    End Sub

    Public Property IDOverlapInfo() As Integer
        Get
            Return _IDOverlapInfo
        End Get
        Set(ByVal value As Integer)
            _IDOverlapInfo = value
        End Set
    End Property

    Public Property EmployeeInfo() As EmployeeInfo
        Get
            Return _EmployeeInfo
        End Get
        Set(ByVal value As EmployeeInfo)
            _EmployeeInfo = value
        End Set
    End Property

    Public Property WorkgroupInfo() As WorkGroupInfo
        Get
            Return _WorkgroupInfo
        End Get
        Set(ByVal value As WorkGroupInfo)
            _WorkgroupInfo = value
        End Set
    End Property

    Public Property ProductionDate() As Date
        Get
            Return _ProductionDate
        End Get
        Set(ByVal value As Date)
            _ProductionDate = value
        End Set
    End Property

    Public Property Shift() As Byte
        Get
            Return _Shift
        End Get
        Set(ByVal value As Byte)
            _Shift = value
        End Set
    End Property

    Public Property ShiftStart() As Date
        Get
            Return _ShiftStart
        End Get
        Set(ByVal value As Date)
            _ShiftStart = value
        End Set
    End Property

    Public Property ShiftEnd() As Date
        Get
            Return _ShiftEnd
        End Get
        Set(ByVal value As Date)
            _ShiftEnd = value
        End Set
    End Property

    Public ReadOnly Property OverlapsExternal() As Boolean
        Get
            Return _OverlapsExternal
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim locString As String
        locString = EmployeeInfo.DisplayName & ": "
        locString &= "hat schon gearbeitet in Site " & Me.WorkgroupInfo.WorkGroupNumber & " "
        locString &= Me.WorkgroupInfo.WorkGroupName & ". "
        locString &= "(" & ShiftStart.ToShortTimeString & "  -  " & ShiftEnd.ToShortTimeString & ")"
        Return locString
    End Function
End Class

Public Class OverlapsInfo
    Inherits KeyedCollection(Of Integer, OverlapsInfoItem)

    Private _myNextID As Integer

    Sub New()
        _myNextID = 1
    End Sub

    Sub New(ByVal EmployeeInfo As EmployeeInfo, ByVal ShiftStart As Date, ByVal ShiftEnd As Date, ByVal ExcludeIDTimeLog As ADDBNullable(Of Long))
        _myNextID = 1
        SPAccess.GetInstance.TimeLog_GetOverlappingLogItems(EmployeeInfo, ShiftStart, ShiftEnd, Me, ExcludeIDTimeLog)
    End Sub

    Public Overloads Sub Add(ByVal LogItem As EmployeeTimeLogInfoItem, ByVal WorkGroup As WorkGroupInfo)
        Dim locItem As New OverlapsInfoItem(LogItem.EmployeeInfo, WorkGroup, _
                    LogItem.ProductionDate, LogItem.Shift, LogItem.ShiftStart, LogItem.ShiftEnd)
        Me.Add(locItem)
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
        _myNextID = 1
    End Sub

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As OverlapsInfoItem)
        If item.IDOverlapInfo = 0 Then
            item.IDOverlapInfo = _myNextID
        End If
        MyBase.InsertItem(index, item)
        _myNextID += 1
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        MyBase.RemoveItem(index)
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As OverlapsInfoItem)
        MyBase.SetItem(index, item)
    End Sub

    Public ReadOnly Property DoesOverlap() As Boolean
        Get
            Return Me.Count > 0
        End Get
    End Property

    Protected Overrides Function GetKeyForItem(ByVal item As OverlapsInfoItem) As Integer
        Return item.IDOverlapInfo
    End Function

    Public Overrides Function ToString() As String
        Return ToString(False)
    End Function

    Public Overloads Function ToString(ByVal SupressLastFillLine As Boolean) As String
        If Me.Count = 0 Then Return ""
        Dim locString As String = ""
        For Each locItem As OverlapsInfoItem In Me
            locString &= locItem.ToString + vbNewLine
        Next

        If SupressLastFillLine Then
            'Letzten Wagenrücklauf entfernen
            locString = locString.Substring(0, locString.Length - 2)
        End If
        Return locString
    End Function
End Class

