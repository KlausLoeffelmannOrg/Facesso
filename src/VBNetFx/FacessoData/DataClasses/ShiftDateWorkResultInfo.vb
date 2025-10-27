Imports System.Xml.Serialization
Imports System.IO

<Serializable(), XmlInclude(GetType(ProductionData)), XmlInclude(GetType(EmployeeTimeLogInfo))> _
Public Class ShiftDateWorkResultInfo

    Private _CombinedParameters As CombinedParametersInfo
    Private WithEvents _ProductionData As ProductionData
    Private WithEvents _EmployeeTimeLogItems As EmployeeTimeLogInfo
    Private _TotalReferenceIWT As Double
    Private _TotalEffectiveIWT As Double
    Private _TotalEffectiveIWTAdj As Double
    Private _DegreeOfTime As Double
    Private _DegreeOfTimeAdj As Double

    Private _CombinedSavingState As CombinedSavingStateChangedEventArgs

    Public Event CombinedSavingStateChanged(ByVal sender As Object, ByVal e As CombinedSavingStateChangedEventArgs)
    Public Event ResultsChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()
        CombinedSavingState = New CombinedSavingStateChangedEventArgs
    End Sub

    Public Sub New(ByVal CombinedParameters As CombinedParametersInfo)
        Me.New()
        _CombinedParameters = CombinedParameters
        _ProductionData = New ProductionData(CombinedParameters)
        _EmployeeTimeLogItems = New EmployeeTimeLogInfo(CombinedParameters)
        _ProductionData.Recalculate(True)
        _EmployeeTimeLogItems.Recalculate()
    End Sub

    Public Property CombinedParameters() As CombinedParametersInfo
        Get
            Return _CombinedParameters
        End Get
        Set(ByVal value As CombinedParametersInfo)
            _CombinedParameters = value
        End Set
    End Property

    Public Property ProductionData() As ProductionData
        Get
            Return _ProductionData
        End Get
        Set(ByVal value As ProductionData)
            _ProductionData = value
        End Set
    End Property

    Public Property EmployeeTimeLogItems() As EmployeeTimeLogInfo
        Get
            Return _EmployeeTimeLogItems
        End Get
        Set(ByVal value As EmployeeTimeLogInfo)
            _EmployeeTimeLogItems = value
        End Set
    End Property

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

    Public Property CombinedSavingState() As CombinedSavingStateChangedEventArgs
        Get
            Return _CombinedSavingState
        End Get
        Set(ByVal value As CombinedSavingStateChangedEventArgs)
            _CombinedSavingState = value
        End Set
    End Property

    Private Sub _ProductionData_SavingStateChanged(ByVal sender As Object, ByVal e As ProductionDataSavingStateChangedEventArgs) Handles _ProductionData.SavingStateChanged
        CombinedSavingState.ForProductionDataSavingState = e.SavingState
        RaiseEvent CombinedSavingStateChanged(Me, CombinedSavingState)
    End Sub

    Private Sub _ProductionData_TotalReferenceIWTChanged(ByVal sender As Object, ByVal e As ProductionDataTotalReferenceIWTChangedEventArgs) Handles _ProductionData.TotalReferenceIWTChanged
        Me._TotalReferenceIWT = e.NewTotalReferenceIWT
        Me.EmployeeTimeLogItems.TotalReferenceIWT = e.NewTotalReferenceIWT
    End Sub

    Private Sub _EmployeeTimeLogItems_EmployeeTimeLogItemsResultsChangedChanged(ByVal sender As Object, ByVal e As EmployeeTimeLogItemsResultsChangedEventArgs) Handles _EmployeeTimeLogItems.EmployeeTimeLogItemsResultsChangedChanged
        Recalculate()
    End Sub

    Private Sub Recalculate()
        Me._DegreeOfTime = Me.EmployeeTimeLogItems.DegreeOfTime
        Me._DegreeOfTimeAdj = Me.EmployeeTimeLogItems.DegreeOfTimeAdj
        Me._TotalEffectiveIWT = Me.EmployeeTimeLogItems.TotalEffectiveIWT
        Me._TotalEffectiveIWTAdj = Me.EmployeeTimeLogItems.TotalEffectiveIWTAdj
        RaiseEvent ResultsChanged(Me, EventArgs.Empty)
    End Sub

    Public Sub SaveToDatabase()
        SPAccess.GetInstance.ProductionData_AddEditShiftDateWorkResults(Me)
    End Sub

    Public Function DeleteProductionDataItems() As Boolean

        Return SPAccess.GetInstance.ProductionData_DeleteItems(FacessoGeneric.LoginInfo.IDSubsidiary, _
            Me.CombinedParameters.WorkGroup, Me.CombinedParameters.ProductionDate, _
            Me.CombinedParameters.Shift)
    End Function
End Class

Public Class CombinedSavingStateChangedEventArgs

    Private myForProductionDataSavingState As Boolean = False
    Private myForTimeDataSavingState As Boolean = False

    Public ReadOnly Property ForBothSavingState() As Boolean
        Get
            Return myForProductionDataSavingState And myForTimeDataSavingState
        End Get
    End Property

    Public ReadOnly Property ForOneSavingState() As Boolean
        Get
            Return myForProductionDataSavingState Or myForTimeDataSavingState
        End Get
    End Property

    Public Property ForProductionDataSavingState() As Boolean
        Get
            Return myForProductionDataSavingState
        End Get
        Set(ByVal value As Boolean)
            myForProductionDataSavingState = value
        End Set
    End Property

    Public Property ForTimeDataSavingState() As Boolean
        Get
            Return myForTimeDataSavingState
        End Get
        Set(ByVal value As Boolean)
            myForTimeDataSavingState = value
        End Set
    End Property
End Class