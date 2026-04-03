Imports Activedev
Imports System.Data.SqlClient
Imports System.Collections.ObjectModel

Public Class EmployeeTimeLogInfoItem

    Private _IDTimeLog As Long
    Private _IDWorkGroup As Integer
    Private _Employee As EmployeeInfo
    Private _Shift As Byte
    Private _ProductionDate As Date
    Private _ShiftStart As Date
    Private _ShiftStartViaInterface As ADDBNullable(Of Date)
    Private _ShiftEnd As Date
    Private _ShiftEndViaInterface As ADDBNullable(Of Date)
    Private _WorkBreak As Integer
    Private _WorkBreakViaInterface As ADDBNullable(Of Integer)
    Private _DownTime As Integer
    Private _DownTimeViaInterface As ADDBNullable(Of Integer)
    Private _Handicap As Double
    Private _AttendanceTime As Integer
    Private _WorkingTime As Integer
    Private _IncentiveWageTime As Double
    Private _IncentiveWageTimeAdj As Double
    Private _IncentiveWageTimeAct As Double
    Private _DegreeOfTime As Double
    Private _DegreeOfTimeAdj As Double
    Private _DegreeOfTimeAct As Double
    Private _ReferenceWageTimeProRata As Double
    Private _InsertedByInterface As Boolean
    Private _ManuallyEdited As Boolean
    Private _LastEdited As Date
    Private _EditedByIDUser As Integer
    Private _Overlaps As OverlapsInfo
    Private _IsSuspended As Boolean

    Private _ParentEmployeeTimeLogItems As EmployeeTimeLogInfo
    Private _Deleted As Boolean

    Sub New()
        MyBase.new()
        _Overlaps = New OverlapsInfo()
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal Employee As EmployeeInfo)
        With Me
            AssignGenericProperties(dr)
            .EmployeeInfo = Employee
        End With
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal JoinedWithEmployeesAndCostcenters As Boolean)
        With Me
            AssignGenericProperties(dr)
            .EmployeeInfo = New EmployeeInfo(dr, True)
        End With
    End Sub

    Private Sub AssignGenericProperties(ByVal dr As SqlDataReader)
        With Me
            .IDTimeLog = dr.GetInt64(dr.GetOrdinal("IDTimeLog"))
            .IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"))
            .Shift = dr.GetByte(dr.GetOrdinal("Shift"))
            .SetShiftTimes(dr.GetDateTime(dr.GetOrdinal("ShiftStart")), _
                             dr.GetDateTime(dr.GetOrdinal("ShiftEnd")), _
                             dr.GetDateTime(dr.GetOrdinal("ProductionDate")))
            .ShiftStartViaInterface = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("ShiftStartViaInterface")))
            .ShiftEndViaInterface = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("ShiftEndViaInterface")))
            .WorkBreak = dr.GetInt32(dr.GetOrdinal("WorkBreak"))
            .DownTime = dr.GetInt32(dr.GetOrdinal("DownTime"))
            .WorkBreakViaInterface = ADDBNullable.FromObject(Of Integer)(dr.GetValue(dr.GetOrdinal("WorkBreakViaInterface")))
            .DownTimeViaInterface = ADDBNullable.FromObject(Of Integer)(dr.GetValue(dr.GetOrdinal("DownTimeViaInterface")))
            .Handicap = dr.GetDouble(dr.GetOrdinal("Handicap"))
            .ReferenceWageTimeProRata = dr.GetDouble(dr.GetOrdinal("ReferenceWageTimeProRata"))
            .InsertedByInterface = dr.GetBoolean(dr.GetOrdinal("InsertedByInterface"))
            .ManuallyEdited = dr.GetBoolean(dr.GetOrdinal("ManuallyEdited"))
            .IsSuspended = dr.GetBoolean(dr.GetOrdinal("IsSuspended"))
            .LastEdited = dr.GetDateTime(dr.GetOrdinal("LastEdited"))
            .EditedByIDUser = dr.GetInt32(dr.GetOrdinal("EditedByIDUser"))
        End With
    End Sub

    Friend WriteOnly Property ParentEmployeeTimeLogItems() As EmployeeTimeLogInfo
        Set(ByVal value As EmployeeTimeLogInfo)
            _ParentEmployeeTimeLogItems = value
        End Set
    End Property

    Public Property IDTimeLog() As Long
        Get
            Return _IDTimeLog
        End Get
        Set(ByVal value As Long)
            _IDTimeLog = value
        End Set
    End Property

    Public Property IDWorkGroup() As Integer
        Get
            Return _IDWorkGroup
        End Get
        Set(ByVal value As Integer)
            _IDWorkGroup = value
        End Set
    End Property

    Public Property EmployeeInfo() As EmployeeInfo
        Get
            Return _Employee
        End Get
        Set(ByVal value As EmployeeInfo)
            _Employee = value
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

    Public Property ProductionDate() As Date
        Get
            Return _ProductionDate
        End Get
        Set(ByVal value As Date)
            _ProductionDate = value.Date
        End Set
    End Property

    Public Property IsSuspended() As Boolean
        Get
            Return _IsSuspended
        End Get
        Set(ByVal value As Boolean)
            _IsSuspended = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt den Schichtbeginn. ACHTUNG: Löst keine Neuberechnung der Klasse aus!
    ''' </summary>
    ''' <value>Schichtbeginn als DateTime</value>
    ''' <remarks></remarks>
    Public Property ShiftStart() As Date
        Get
            Return _ShiftStart
        End Get
        Set(ByVal value As Date)
            _ShiftStart = value
        End Set
    End Property

    Private Property ShiftStartViaInterface() As ADDBNullable(Of Date)
        Get
            Return _ShiftStartViaInterface
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            _ShiftStartViaInterface = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt das Schichtende. ACHTUNG: Löst keine Neuberechnung der Klasse aus!
    ''' </summary>
    ''' <value>Schichtende als DateTime</value>
    ''' <remarks></remarks>
    Public Property ShiftEnd() As Date
        Get
            Return _ShiftEnd
        End Get
        Set(ByVal value As Date)
            _ShiftEnd = value
        End Set
    End Property

    Private Property ShiftEndViaInterface() As ADDBNullable(Of Date)
        Get
            Return _ShiftEndViaInterface
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            _ShiftEndViaInterface = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.EmployeeInfo.PersonnelNumber & ": " & Me.EmployeeInfo.LastName & ", " & Me.EmployeeInfo.FirstName & _
               " (" & Me.ShiftStart.ToShortTimeString & "  -  " & Me.ShiftEnd.ToShortTimeString & ")"
    End Function

    ''' <summary>
    ''' Setzt Produktionsdatum, Schichtstart- und Endzeiten, und stößt, anders als die entsprechenden Eigenschaften, die Berechnung an.
    ''' </summary>
    ''' <param name="ShiftStart">Startzeit der Schicht</param>
    ''' <param name="ShiftEnd">Endzeit der Schicht</param>
    ''' <param name="ProductionDate">Produktionstag</param>
    ''' <remarks></remarks>
    Public Sub SetShiftTimes(ByVal ShiftStart As Date, ByVal ShiftEnd As Date, ByVal ProductionDate As Date)
        Me.ProductionDate = ProductionDate.Date
        If ShiftStart > ShiftEnd Then
            ShiftEnd = ShiftStart
        End If
        Dim locStartDifference As TimeSpan
        Dim locEndDifference As TimeSpan

        If ShiftStart.Date = ProductionDate Or ShiftStart.Date = ProductionDate.AddDays(1) Then
            locStartDifference = ShiftStart.Subtract(ProductionDate)
            locEndDifference = ShiftEnd.Subtract(ProductionDate)
        Else
            locStartDifference = ShiftStart.Subtract(ShiftStart.Date)
            locEndDifference = ShiftEnd.Subtract(ShiftStart.Date)
        End If

        Me.ShiftStart = ProductionDate.Date.Add(locStartDifference)
        Me.ShiftEnd = ProductionDate.Date.Add(locEndDifference)
        Recalculate()
    End Sub

    Public Property WorkBreak() As Integer
        Get
            Return _WorkBreak
        End Get
        Set(ByVal value As Integer)
            _WorkBreak = value
            Recalculate()
        End Set
    End Property

    Private Property WorkBreakViaInterface() As ADDBNullable(Of Integer)
        Get
            Return _WorkBreakViaInterface
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            _WorkBreakViaInterface = value
        End Set
    End Property

    Public Property DownTime() As Integer
        Get
            Return _DownTime
        End Get
        Set(ByVal value As Integer)
            _DownTime = value
            Recalculate()
        End Set
    End Property

    Private Property DownTimeViaInterface() As ADDBNullable(Of Integer)
        Get
            Return _DownTimeViaInterface
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            _DownTimeViaInterface = value
        End Set
    End Property

    Public Property Handicap() As Double
        Get
            Return _Handicap
        End Get
        Set(ByVal value As Double)
            _Handicap = value
            Recalculate()
        End Set
    End Property

    Public ReadOnly Property AttendanceTime() As Integer
        Get
            Return _AttendanceTime
        End Get
    End Property

    Public ReadOnly Property WorkingTime() As Integer
        Get
            Return _WorkingTime
        End Get
    End Property

    Public ReadOnly Property IncentiveWageTime() As Double
        Get
            Return _IncentiveWageTime
        End Get
    End Property

    Public ReadOnly Property IncentiveWageTimeAdj() As Double
        Get
            Return _IncentiveWageTimeAdj
        End Get
    End Property

    Public ReadOnly Property IncentiveWageTimeAct() As Double
        Get
            Return _IncentiveWageTimeAct
        End Get
    End Property

    Public ReadOnly Property DegreeOfTime() As Double
        Get
            Return _DegreeOfTime
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAdj() As Double
        Get
            Return _DegreeOfTimeAdj
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAct() As Double
        Get
            Return _DegreeOfTimeAct
        End Get
    End Property

    Friend Sub SetDegreesOfTime(ByVal dot As Double, ByVal dotAdj As Double)
        _DegreeOfTime = dot
        _DegreeOfTimeAdj = dotAdj
        _ReferenceWageTimeProRata = _DegreeOfTime / 100 * _IncentiveWageTime
    End Sub

    Public Property ReferenceWageTimeProRata() As Double
        Get
            Return _ReferenceWageTimeProRata
        End Get
        Friend Set(ByVal value As Double)
            _ReferenceWageTimeProRata = value
            Recalculate()
        End Set
    End Property

    Public Property InsertedByInterface() As Boolean
        Get
            Return _InsertedByInterface
        End Get
        Set(ByVal value As Boolean)
            _InsertedByInterface = value
        End Set
    End Property

    Public Property ManuallyEdited() As Boolean
        Get
            Return _ManuallyEdited
        End Get
        Set(ByVal value As Boolean)
            _ManuallyEdited = value
        End Set
    End Property

    Public Property LastEdited() As Date
        Get
            Return _LastEdited
        End Get
        Set(ByVal value As Date)
            _LastEdited = value
        End Set
    End Property

    Public Property EditedByIDUser() As Integer
        Get
            Return _EditedByIDUser
        End Get
        Set(ByVal value As Integer)
            _EditedByIDUser = value
        End Set
    End Property

    Public Property Deleted() As Boolean
        Get
            Return _Deleted
        End Get
        Friend Set(ByVal value As Boolean)
            _Deleted = value
        End Set
    End Property

    Public Property Overlaps() As OverlapsInfo
        Get
            Return _Overlaps
        End Get
        Set(ByVal value As OverlapsInfo)
            _Overlaps = value
        End Set
    End Property

    Public ReadOnly Property TimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Gesamtpräsenz:  " + AttendanceTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Arbeitszeit:  " + WorkingTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Effektivzeit:  " + IncentiveWageTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public Function Clone() As EmployeeTimeLogInfoItem
        Dim locEtli As New EmployeeTimeLogInfoItem
        With locEtli
            ._AttendanceTime = Me._AttendanceTime
            ._DegreeOfTime = Me._DegreeOfTime
            ._DegreeOfTimeAdj = Me._DegreeOfTimeAdj
            ._DownTime = Me._DownTime
            ._EditedByIDUser = Me._EditedByIDUser
            ._Employee = Me._Employee
            ._ShiftEnd = Me._ShiftEnd
            ._IDTimeLog = Me._IDTimeLog
            ._IDWorkGroup = Me._IDWorkGroup
            ._IncentiveWageTime = Me._IncentiveWageTime
            ._IncentiveWageTimeAdj = Me._IncentiveWageTimeAdj
            ._InsertedByInterface = Me._InsertedByInterface
            ._LastEdited = Me._LastEdited
            ._ManuallyEdited = Me._ManuallyEdited
            ._ParentEmployeeTimeLogItems = Me._ParentEmployeeTimeLogItems
            ._Handicap = Me._Handicap
            ._ProductionDate = Me._ProductionDate
            ._ReferenceWageTimeProRata = Me._ReferenceWageTimeProRata
            ._Shift = Me._Shift
            ._ShiftStart = Me._ShiftStart
            ._WorkBreak = Me._WorkBreak
            ._WorkingTime = Me._WorkingTime
        End With
        Return locEtli
    End Function

    Private Sub Recalculate()
        Me._AttendanceTime = Convert.ToInt32((ShiftEnd - ShiftStart).TotalMinutes)
        Me._WorkingTime = _AttendanceTime - _WorkBreak
        Me._IncentiveWageTime = _WorkingTime - _DownTime
        Me._IncentiveWageTimeAct = Me._IncentiveWageTime + _IncentiveWageTime * Handicap / 100
        Me._IncentiveWageTimeAdj = Me._IncentiveWageTime - ((Me._IncentiveWageTime * Handicap) / 100)

        Me._DegreeOfTime = _ReferenceWageTimeProRata / _IncentiveWageTime * 100
        Me._DegreeOfTimeAdj = _ReferenceWageTimeProRata / _IncentiveWageTimeAdj * 100
        Me._DegreeOfTimeAct = _ReferenceWageTimeProRata / _IncentiveWageTimeAct * 100

        If Me._ParentEmployeeTimeLogItems IsNot Nothing Then
            Me._ParentEmployeeTimeLogItems.Recalculate()
        End If
    End Sub
End Class

Public Class EmployeeTimeLogInfo
    Inherits KeyedCollection(Of Long, EmployeeTimeLogInfoItem)

    Private _WorkGroup As WorkGroupInfo
    Private _ProductionDate As Date
    Private _Shift As Byte
    Private _NextAutoCountID As Integer
    Private _TotalReferenceIWT As Double
    Private _TotalAttendanceTime As Integer
    Private _TotalDownTime As Integer
    Private _TotalWorkingTime As Integer
    Private _TotalEffectiveIWT As Double
    Private _TotalEffectiveIWTAdj As Double
    Private _TotalEffectiveIWTAct As Double
    Private _TotalWorkBreakTime As Integer
    Private _DegreeOfTime As Double
    Private _DegreeOfTimeAdj As Double
    Private _DegreeOfTimeAct As Double
    Private _RecalculateTotalReferenceIWT As Boolean
    Private _Employee As EmployeeInfo
    Private _StartDate As Date
    Private _EndDate As Date

    Public Event EmployeeTimeLogItemsResultsChangedChanged(ByVal sender As Object, ByVal e As EmployeeTimeLogItemsResultsChangedEventArgs)

    Sub New()
    End Sub

    Sub New(ByVal CombinedParameters As CombinedParametersInfo)
        _WorkGroup = CombinedParameters.WorkGroup
        _ProductionDate = CombinedParameters.ProductionDate
        _Shift = CombinedParameters.Shift
        SPAccess.GetInstance.GetEmployeeTimeLog(Me)
    End Sub

    Sub New(ByVal CombinedParameters As CombinedParametersInfo, ByVal TimeLogItems As EmployeeTimeLogInfo)
        _WorkGroup = CombinedParameters.WorkGroup
        _ProductionDate = CombinedParameters.ProductionDate
        _Shift = CombinedParameters.Shift
        Me.AddRange(TimeLogItems)
    End Sub

    Sub New(ByVal Employee As EmployeeInfo, ByVal StartDate As Date, ByVal EndDate As Date)
        MyBase.New()
        _Employee = Employee
        _StartDate = StartDate
        _EndDate = EndDate
        SPAccess.GetInstance.GetEmployeeTimeLog(Employee, StartDate, EndDate, Me)
    End Sub

    Public Sub DeleteFromDatabase(ByVal EmpTimeLogItem As EmployeeTimeLogInfoItem)
        SPAccess.GetInstance.TimeLog_DeleteItemFromDatabase(Me.WorkGroup, EmpTimeLogItem)
    End Sub

    Public Sub AddRange(ByVal TimeLogItems As EmployeeTimeLogInfo)
        For Each locItem As EmployeeTimeLogInfoItem In TimeLogItems
            Me.Add(locItem)
        Next
    End Sub

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As EmployeeTimeLogInfoItem)
        item.ParentEmployeeTimeLogItems = Me
        If item.IDTimeLog <= 0 Then
            item.IDTimeLog = _NextAutoCountID
            _NextAutoCountID -= 1
        End If
        MyBase.InsertItem(index, item)
        Recalculate()
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
        Recalculate()
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        If Me(index).IDTimeLog > 0 Then
            Me(index).Deleted = True
        Else
            MyBase.RemoveItem(index)
        End If
        Recalculate()
    End Sub

    Public Sub RemoveAllItems()
        Do While Me.Count > 0
            RemoveItem(0)
        Loop
    End Sub

    Public Overloads Sub SetItem(ByVal Key As Long, ByVal item As EmployeeTimeLogInfoItem)
        SetItem(Me.IndexOf(item), item)
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As EmployeeTimeLogInfoItem)
        item.ParentEmployeeTimeLogItems = Me
        MyBase.SetItem(index, item)
        Recalculate()
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As EmployeeTimeLogInfoItem) As Long
        Return item.IDTimeLog
    End Function

    Public Property WorkGroup() As WorkGroupInfo
        Get
            Return _WorkGroup
        End Get
        Set(ByVal value As WorkGroupInfo)
            _WorkGroup = value
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

    Public ReadOnly Property NextAutoCountID() As Integer
        Get
            Return _NextAutoCountID
        End Get
    End Property

    Public Property TotalReferenceIWT() As Double
        Get
            Return _TotalReferenceIWT
        End Get
        Set(ByVal value As Double)
            _TotalReferenceIWT = value
            Recalculate()
        End Set
    End Property

    Public ReadOnly Property TotalEffectiveIWT() As Double
        Get
            Return _TotalEffectiveIWT
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWTAdj() As Double
        Get
            Return _TotalEffectiveIWTAdj
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWTAct() As Double
        Get
            Return _TotalEffectiveIWTAct
        End Get
    End Property

    Public ReadOnly Property DegreeOfTime() As Double
        Get
            Return _DegreeOfTime
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAdj() As Double
        Get
            Return _DegreeOfTimeAdj
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAct() As Double
        Get
            Return _DegreeOfTimeAct
        End Get
    End Property

    Public ReadOnly Property TotalWorkBreakTime() As Integer
        Get
            Return _TotalWorkBreakTime
        End Get
    End Property

    Public ReadOnly Property TotalDownTime() As Integer
        Get
            Return _TotalDownTime
        End Get
    End Property

    Public ReadOnly Property TotalWorkingTime() As Integer
        Get
            Return _TotalWorkingTime
        End Get
    End Property

    Public ReadOnly Property TotalAttendanceTime() As Integer
        Get
            Return _TotalAttendanceTime
        End Get
    End Property

    Public ReadOnly Property AttendanceTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Arbeit:  " + TotalWorkingTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public ReadOnly Property IncentiveTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Referenz:  " + TotalReferenceIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Effektiv:  " + TotalEffectiveIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "angepasst:  " + TotalEffectiveIWTAdj.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property


    Public Property RecalculateTotalReferenceIWT() As Boolean
        Get
            Return _RecalculateTotalReferenceIWT
        End Get
        Set(ByVal value As Boolean)
            _RecalculateTotalReferenceIWT = value
        End Set
    End Property

    Public Sub SaveToDatabase(ByVal IDUser As Integer, ByVal UpdateResultSet As Boolean)
        If UpdateResultSet Then
            Me.Clear()
            For Each locItem As EmployeeTimeLogInfoItem In SPAccess.GetInstance.TimeLog_AddEditEmployeeTimeLogItems(Me, IDUser, True)
                Me.Add(locItem)
            Next
        Else
            SPAccess.GetInstance.TimeLog_AddEditEmployeeTimeLogItems(Me, IDUser, True)
        End If
    End Sub

    Friend Sub Recalculate()
        _TotalAttendanceTime = 0
        _TotalWorkingTime = 0
        _TotalDownTime = 0
        _TotalEffectiveIWT = 0
        _TotalEffectiveIWTAdj = 0
        _TotalEffectiveIWTAct = 0
        _TotalWorkBreakTime = 0
        If RecalculateTotalReferenceIWT Then
            _TotalReferenceIWT = 0
        End If
        For Each locItem As EmployeeTimeLogInfoItem In Me
            If Not locItem.Deleted Then
                _TotalAttendanceTime += locItem.AttendanceTime
                _TotalWorkingTime += locItem.WorkingTime
                _TotalDownTime += locItem.DownTime
                _TotalEffectiveIWT += locItem.IncentiveWageTime
                _TotalEffectiveIWTAdj += locItem.IncentiveWageTimeAdj
                _TotalEffectiveIWTAct += locItem.IncentiveWageTimeAct
                _TotalWorkBreakTime += locItem.WorkBreak
                If RecalculateTotalReferenceIWT Then
                    _TotalReferenceIWT += locItem.ReferenceWageTimeProRata
                End If
            End If
        Next
        _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100
        _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100
        _DegreeOfTimeAct = _TotalReferenceIWT / _TotalEffectiveIWTAct * 100

        'Neuberechnung der Gesamtmenge änderte unter Umständen
        'den Gesamtzeitgrad, der schließlich an die einzelnen 
        'Items wieder weitergegeben werden muss.
        If Not RecalculateTotalReferenceIWT Then
            For Each locItem As EmployeeTimeLogInfoItem In Me
                If Not locItem.Deleted Then
                    locItem.SetDegreesOfTime(_DegreeOfTime, _DegreeOfTimeAdj)
                End If
            Next
        End If
        RaiseEvent EmployeeTimeLogItemsResultsChangedChanged(Me, New EmployeeTimeLogItemsResultsChangedEventArgs( _
            _TotalAttendanceTime, _TotalWorkingTime, _TotalDownTime, _TotalEffectiveIWT, _
            _TotalEffectiveIWTAdj, _TotalWorkBreakTime))
    End Sub

    Public ReadOnly Property Employee() As EmployeeInfo
        Get
            Return _Employee
        End Get
    End Property

    Public ReadOnly Property StartDate() As Date
        Get
            Return _StartDate
        End Get
    End Property

    Public ReadOnly Property EndDate() As Date
        Get
            Return _EndDate
        End Get
    End Property
End Class

Public Class EmployeeTimeLogItemsResultsChangedEventArgs
    Inherits EventArgs

    Private _NewTotalAttendanceTime As Integer
    Private _NewTotalWorkingTime As Integer
    Private _NewTotalDownTime As Integer
    Private _NewTotalEffectiveIWT As Double
    Private _NewTotalEffectiveIWTAdj As Double
    Private _NewTotalWorkBreakTime As Integer

    Sub New()
    End Sub

    Sub New(ByVal NewTotalAttendanceTime As Integer, ByVal NewTotalWorkingTime As Integer, _
            ByVal NewTotalDownTime As Integer, ByVal NewTotalEffectiveIWT As Double, _
            ByVal NewTotalEffectiveIWTAdj As Double, ByVal NewTotalWorkBreakTime As Integer)
        _NewTotalAttendanceTime = NewTotalAttendanceTime
        _NewTotalWorkBreakTime = NewTotalWorkBreakTime
        _NewTotalDownTime = NewTotalDownTime
        _NewTotalEffectiveIWT = NewTotalEffectiveIWT
        _NewTotalEffectiveIWTAdj = NewTotalEffectiveIWTAdj
        _NewTotalWorkingTime = NewTotalWorkingTime
    End Sub

    Public Property NewTotalAttendanceTime() As Integer
        Get
            Return _NewTotalAttendanceTime
        End Get
        Set(ByVal value As Integer)
            _NewTotalAttendanceTime = value
        End Set
    End Property

    Public Property NewTotalWorkingTime() As Integer
        Get
            Return _NewTotalWorkingTime
        End Get
        Set(ByVal value As Integer)
            _NewTotalWorkingTime = value
        End Set
    End Property

    Public Property NewTotalDownTime() As Integer
        Get
            Return _NewTotalDownTime
        End Get
        Set(ByVal value As Integer)
            _NewTotalDownTime = value
        End Set
    End Property

    Public Property NewTotalEffectiveIWT() As Double
        Get
            Return _NewTotalEffectiveIWT
        End Get
        Set(ByVal value As Double)
            _NewTotalEffectiveIWT = value
        End Set
    End Property

    Public Property NewTotalEffectiveIWTAdj() As Double
        Get
            Return _NewTotalEffectiveIWTAdj
        End Get
        Set(ByVal value As Double)
            _NewTotalEffectiveIWTAdj = value
        End Set
    End Property

    Public Property NewTotalWorkBreakTime() As Integer
        Get
            Return _NewTotalWorkBreakTime
        End Get
        Set(ByVal value As Integer)
            _NewTotalWorkBreakTime = value
        End Set
    End Property
End Class

Public Class EmployeeTimeLogInfoCollection
    Inherits Collection(Of EmployeeTimeLogInfo)

    Private _TotalReferenceIWT As Double
    Private _TotalAttendanceTime As Double
    Private _TotalDownTime As Double
    Private _TotalWorkingTime As Double
    Private _TotalEffectiveIWT As Double
    Private _TotalEffectiveIWTAdj As Double
    Private _TotalEffectiveIWTAct As Double
    Private _TotalWorkBreakTime As Double

    Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As EmployeeTimeLogInfo)
        MyBase.InsertItem(index, item)
        Recalculate()
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
        Recalculate()
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        MyBase.RemoveItem(index)
        Recalculate()
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As EmployeeTimeLogInfo)
        MyBase.SetItem(index, item)
        Recalculate()
    End Sub

    Public ReadOnly Property TotalReferenceIWT() As Double
        Get
            Return _TotalReferenceIWT
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWT() As Double
        Get
            Return _TotalEffectiveIWT
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWTAdj() As Double
        Get
            Return _TotalEffectiveIWTAdj
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWTAct() As Double
        Get
            Return _TotalEffectiveIWTAct
        End Get
    End Property

    Public ReadOnly Property DegreeOfTime() As Double
        Get
            Return _TotalReferenceIWT / _TotalEffectiveIWT * 100
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAdj() As Double
        Get
            Return _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAct() As Double
        Get
            Return _TotalReferenceIWT / _TotalEffectiveIWTAct * 100
        End Get
    End Property

    Public ReadOnly Property TotalWorkBreakTime() As Double
        Get
            Return _TotalWorkBreakTime
        End Get
    End Property

    Public ReadOnly Property TotalDownTime() As Double
        Get
            Return _TotalDownTime
        End Get
    End Property

    Public ReadOnly Property TotalWorkingTime() As Double
        Get
            Return _TotalWorkingTime
        End Get
    End Property

    Public ReadOnly Property TotalAttendanceTime() As Double
        Get
            Return _TotalAttendanceTime
        End Get
    End Property

    Friend Sub Recalculate()
        _TotalAttendanceTime = 0
        _TotalWorkingTime = 0
        _TotalDownTime = 0
        _TotalEffectiveIWT = 0
        _TotalEffectiveIWTAdj = 0
        _TotalEffectiveIWTAct = 0
        _TotalWorkBreakTime = 0
        _TotalReferenceIWT = 0
        For Each locItem As EmployeeTimeLogInfo In Me
            _TotalAttendanceTime += locItem.TotalAttendanceTime
            _TotalWorkingTime += locItem.TotalWorkingTime
            _TotalDownTime += locItem.TotalDownTime
            _TotalEffectiveIWT += locItem.TotalEffectiveIWT
            _TotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj
            _TotalEffectiveIWTAct += locItem.TotalEffectiveIWTAct
            _TotalWorkBreakTime += locItem.TotalWorkBreakTime
            _TotalReferenceIWT += locItem.TotalReferenceIWT
        Next
    End Sub
End Class
