Imports ActiveDev
Imports System.Collections.ObjectModel

Public Class CombinedParametersInfo

    Private myEmployeeInfo As EmployeeInfo
    Private myWorkGroupInfo As WorkGroupInfo
    Private myShift As Byte
    Private myProductionDate As Date

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal wg As WorkGroupInfo, ByVal ProdDate As Date, ByVal Shift As Byte)
        myWorkGroupInfo = wg
        myProductionDate = ProdDate
        myShift = Shift
    End Sub

    Public Property EmployeeInfo() As EmployeeInfo
        Get
            Return myEmployeeInfo
        End Get
        Set(ByVal value As EmployeeInfo)
            myEmployeeInfo = value
        End Set
    End Property

    Public Property WorkGroup() As WorkGroupInfo
        Get
            Return myWorkGroupInfo
        End Get
        Set(ByVal value As WorkGroupInfo)
            myWorkGroupInfo = value
        End Set
    End Property

    Public Property Shift() As Byte
        Get
            Return myShift
        End Get
        Set(ByVal value As Byte)
            myShift = value
        End Set
    End Property

    Public Property ProductionDate() As Date
        Get
            Return myProductionDate
        End Get
        Set(ByVal value As Date)
            myProductionDate = value
        End Set
    End Property

    Public ReadOnly Property ShiftText() As String
        Get
            Return ShiftText(Me.Shift)
        End Get
    End Property

    Public ReadOnly Property ShiftText(ByVal IncludeShiftNr As Boolean) As String
        Get
            Return CStr(IIf(IncludeShiftNr, Me.Shift.ToString & ": " & ShiftText(Me.Shift), ShiftText(Me.Shift)))
        End Get
    End Property


    Public ReadOnly Property ShiftText(ByVal ShiftNr As Byte) As String
        Get
            Dim locString As String = "("

            If Me.WorkGroup Is Nothing Then
                Return "(-- : --  -  -- : --)"
            End If
            Dim locTSD As TimeSettingDetail = Me.WorkGroup. _
                    TimeSettingDetails.GetTimeSettingDetail(Me.ProductionDate, _
                                                            ShiftNr)
            If locTSD.ShiftStart.HasValue Then
                locString &= locTSD.ShiftStart.TypedValue.ToShortTimeString & "  -  "
                locString &= locTSD.ShiftEnd.TypedValue.ToShortTimeString & ")"
            Else
                locString &= "-- : --  -  -- : --)"
            End If
            Return locString
        End Get
    End Property

End Class

Public Class ProductionPeriodItem
    Private _ProductionDate As Date
    Private _Shift As Byte

    Sub New(ByVal ProductionDate As Date, ByVal Shift As Byte)
        _ProductionDate = ProductionDate
        _Shift = Shift
    End Sub

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

End Class
