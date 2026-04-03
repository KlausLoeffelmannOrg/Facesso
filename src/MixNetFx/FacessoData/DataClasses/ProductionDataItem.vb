Imports ActiveDev
Imports System.Data.SqlClient
Imports System.Xml.Serialization

<Serializable()> _
Public Class ProductionDataItem

    Private myIDProductionDataItem As Long
    Private myIDArticle As Integer
    Private myLabourValue As LabourValueInfo
    Private myAmount As Double
    Private myAmountViaInterface As Double
    Private myAmountOriginal As Double
    Private myOrdinalNo As Integer
    Private myManuallyEdited As Boolean
    Private myAccumulatedAmount As Double

    Private myParentProductionData As ProductionData

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader)
        With Me
            .IDProductionDataItem = dr.GetInt64(dr.GetOrdinal("IDProductionDataItem"))
            .IDArticle = dr.GetInt32(dr.GetOrdinal("IDArticle"))
            .LabourValue = New LabourValueInfo(dr, True)
            .OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNumber"))
            .ManuallyEdited = dr.GetBoolean(dr.GetOrdinal("ManuallyEdited"))
            .Amount = dr.GetDouble(dr.GetOrdinal("Amount"))
            .AmountViaInterface = dr.GetDouble(dr.GetOrdinal("AmountViaInterface"))
            myAmountOriginal = .Amount
        End With
    End Sub

    Friend WriteOnly Property ParentProductionData() As ProductionData
        Set(ByVal value As ProductionData)
            myParentProductionData = value
        End Set
    End Property

    Public Property IDProductionDataItem() As Long
        Get
            Return myIDProductionDataItem
        End Get
        Set(ByVal value As Long)
            myIDProductionDataItem = value
        End Set
    End Property

    Public Property IDProductionData() As Long
        Get
            Return myIDProductionDataItem
        End Get
        Set(ByVal value As Long)
            myIDProductionDataItem = value
        End Set
    End Property

    Public Property IDArticle() As Integer
        Get
            Return myIDArticle
        End Get
        Set(ByVal value As Integer)
            myIDArticle = value
        End Set
    End Property

    Public Property LabourValue() As LabourValueInfo
        Get
            Return myLabourValue
        End Get
        Set(ByVal value As LabourValueInfo)
            myLabourValue = value
        End Set
    End Property

    ''' <summary>
    ''' Wert, der als Berechnungsgrundlage für die Produktionsmenge in die Datenbank geschrieben wird.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Amount() As Double
        Get
            Return myAmount
        End Get
        Set(ByVal value As Double)
            myAmount = value
            If myParentProductionData IsNot Nothing Then
                myParentProductionData.Recalculate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Der Originalwert, der durch eine Schnittstelle in die Datenbank geschrieben wurde.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AmountViaInterface() As Double
        Get
            Return myAmountViaInterface
        End Get
        Set(ByVal value As Double)
            myAmountViaInterface = value
        End Set
    End Property

    ''' <summary>
    ''' Vergleichswert, um festzustellen, ob die Mengen dieser Klasse geändert wurden. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Datenbankunabhängig, kann deshalb auch nicht geschrieben werden.</remarks>
    Public Property AmountOriginal() As Double
        Get
            Return AmountOriginal
        End Get
        Friend Set(ByVal value As Double)
            myAmountOriginal = value
        End Set
    End Property

    ''' <summary>
    ''' Stellt fest, ob Menge in dieser Klasse seit der Instanzierung verändert wurde.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AmountChangedSinceInstatiation() As Boolean
        Get
            Return Amount <> myAmountOriginal
        End Get
    End Property

    Public Property OrdinalNo() As Integer
        Get
            Return myOrdinalNo
        End Get
        Set(ByVal value As Integer)
            myOrdinalNo = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt oder bestimmt, ob der Wert durch eine manuelle (true) Eingabe oder durch eine Schnittstelle (false) zustande kam.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManuallyEdited() As Boolean
        Get
            Return myManuallyEdited
        End Get
        Set(ByVal value As Boolean)
            myManuallyEdited = value
        End Set
    End Property

    ''' <summary>
    ''' Die Gesamtsumme, die sich durch Arbeitsbasiswert und Menge ergibt.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SubTotal() As Double
        Get
            Return Amount * LabourValue.TeHMin
        End Get
    End Property

    ''' <summary>
    ''' Hilfsregister, das es ermöglicht, dass ein Arbeitswert seine Daten kummuliert aus verschiedenen Artikeln bei der automatischen Datenübernahme bekommt.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Wird nicht in Datenbank gespeichert.</remarks>
    Public Property AccumulatedAmount() As Double
        Get
            Return myAccumulatedAmount
        End Get
        Set(ByVal value As Double)
            myAccumulatedAmount = value
        End Set
    End Property
End Class

<CLSCompliant(True), Serializable()> _
Public Class ProductionData
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Long, ProductionDataItem)

    Private myIDProductionData As Long
    Private myWorkGroup As WorkGroupInfo
    Private myProductionDate As Date
    Private myShift As Byte
    Private myTotalReferenceIWT As Double
    Private myDegreeOfTime As Double
    Private myDegreeOfTimeAdj As Double
    Private myInsertedByInterface As Boolean
    Private myIsSuspended As Boolean
    Private myDoDataExist As Boolean
    Private myLastEdited As Date
    Private myLastEditedByIDUser As Integer

    Private myOldTotalReferenceIWT As Double = Double.NaN
    Private WithEvents mySavingState As ProductionDataSavingStateChangedEventArgs
    Private myCurrentIndex As Long

    Public Event TotalReferenceIWTChanged(ByVal sender As Object, ByVal e As ProductionDataTotalReferenceIWTChangedEventArgs)
    Public Event SavingStateChanged(ByVal sender As Object, ByVal e As ProductionDataSavingStateChangedEventArgs)

    Sub New()
        MyBase.New()
        myCurrentIndex = -1
        mySavingState = New ProductionDataSavingStateChangedEventArgs(False)
    End Sub

    Sub New(ByVal CombinedParameters As CombinedParametersInfo)
        Me.new()
        myWorkGroup = CombinedParameters.WorkGroup
        myProductionDate = CombinedParameters.ProductionDate
        myShift = CombinedParameters.Shift
        SPAccess.GetInstance.ProductionData_GetProductionData(Me, 1)
    End Sub

    Private Sub mySavingState_SavingStateChanged() Handles mySavingState.SavingStateChanged
        RaiseEvent SavingStateChanged(Me, mySavingState)
    End Sub

    Public Function GetItemFromIDLabourValue(ByVal IDLabourValue As Integer) As ProductionDataItem
        For Each locItem As ProductionDataItem In Me
            If locItem.LabourValue.IDLabourValue = IDLabourValue Then
                Return locItem
            End If
        Next
        Dim locEx As New IndexOutOfRangeException("The Item with the specified LabourValueID could not be found!")
        Throw locEx
        Return Nothing
    End Function

    Protected Overloads Overrides Function GetKeyForItem(ByVal item As ProductionDataItem) As Long
        Return Item.IDProductionData
    End Function

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As ProductionDataItem)
        If item.IDProductionDataItem = 0 Then
            item.IDProductionDataItem = myCurrentIndex
            myCurrentIndex -= 1
        End If
        MyBase.InsertItem(index, item)
        item.ParentProductionData = Me
        Recalculate()
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        MyBase.RemoveItem(index)
        Recalculate()
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
        Recalculate()
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As ProductionDataItem)
        item.ParentProductionData = Me
        MyBase.SetItem(index, item)
        Recalculate()
    End Sub

    Friend Sub Recalculate()
        Recalculate(False)
    End Sub

    Friend Sub Recalculate(ByVal RaiseEventInAnyCase As Boolean)
        Dim locFlag As Boolean

        myTotalReferenceIWT = 0
        For Each locItem As ProductionDataItem In Me
            myTotalReferenceIWT += locItem.SubTotal
            locFlag = locFlag Or locItem.AmountChangedSinceInstatiation
        Next
        If (myOldTotalReferenceIWT <> myTotalReferenceIWT) Or RaiseEventInAnyCase Then
            RaiseEvent TotalReferenceIWTChanged(Me, New ProductionDataTotalReferenceIWTChangedEventArgs(myTotalReferenceIWT))
        End If
        myOldTotalReferenceIWT = myTotalReferenceIWT
        mySavingState.SavingState = locFlag

    End Sub

    Public Sub ResetSavingState()
        mySavingState.SavingState = False
    End Sub

    Public Sub SaveToDatabase(ByVal IDUser As Integer, ByVal UpdateResultSet As Boolean)
        If UpdateResultSet Then
            Me.Clear()
            For Each locItem As ProductionDataItem In SPAccess.GetInstance.ProductionData_AddEditProductionData(Me, IDUser, True)
                Me.Add(locItem)
            Next
        Else
            SPAccess.GetInstance.ProductionData_AddEditProductionData(Me, IDUser, False)
        End If
    End Sub

    Public Property IDProductionData() As Long
        Get
            Return myIDProductionData
        End Get
        Set(ByVal value As Long)
            myIDProductionData = value
        End Set
    End Property

    Public Property WorkGroup() As WorkGroupInfo
        Get
            Return myWorkGroup
        End Get
        Set(ByVal value As WorkGroupInfo)
            myWorkGroup = value
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

    Public Property Shift() As Byte
        Get
            Return myShift
        End Get
        Set(ByVal value As Byte)
            myShift = value
        End Set
    End Property

    Public Property DoDataExist() As Boolean
        Get
            Return myDoDataExist
        End Get
        Set(ByVal value As Boolean)
            myDoDataExist = value
        End Set
    End Property

    Public ReadOnly Property TotalReferenceIWT() As Double
        Get
            Return myTotalReferenceIWT
        End Get
    End Property

    Public Property DegreeOfTime() As Double
        Get
            Return myDegreeOfTime
        End Get
        Set(ByVal value As Double)
            myDegreeOfTime = value
        End Set
    End Property

    Public Property DegreeOfTimeAdj() As Double
        Get
            Return myDegreeOfTimeAdj
        End Get
        Set(ByVal value As Double)
            myDegreeOfTimeAdj = value
        End Set
    End Property

    Public Property InsertedByInterface() As Boolean
        Get
            Return myInsertedByInterface
        End Get
        Set(ByVal value As Boolean)
            myInsertedByInterface = value
        End Set
    End Property

    Public Property IsSuspended() As Boolean
        Get
            Return myIsSuspended
        End Get
        Set(ByVal value As Boolean)
            myIsSuspended = value
        End Set
    End Property

    Public Property LastEdited() As Date
        Get
            Return myLastEdited
        End Get
        Set(ByVal value As Date)
            myLastEdited = value
        End Set
    End Property

    Public Property LastEditedByIDUser() As Integer
        Get
            Return myLastEditedByIDUser
        End Get
        Set(ByVal value As Integer)
            myLastEditedByIDUser = value
        End Set
    End Property
End Class

Public Class ProductionDataTotalReferenceIWTChangedEventArgs
    Inherits EventArgs

    Private myNewTotalReferenceIWT As Double

    Sub New()
    End Sub

    Sub New(ByVal NewTotalReferenceIWT As Double)
        myNewTotalReferenceIWT = NewTotalReferenceIWT
    End Sub

    Public Property NewTotalReferenceIWT() As Double
        Get
            Return myNewTotalReferenceIWT
        End Get
        Set(ByVal value As Double)
            myNewTotalReferenceIWT = value
        End Set
    End Property

End Class

Public Class ProductionDataSavingStateChangedEventArgs

    Private mySavingState As Boolean
    Friend Event SavingStateChanged()

    Sub New()
    End Sub

    Sub New(ByVal SavingState As Boolean)
        mySavingState = SavingState
    End Sub

    ''' <summary>
    ''' Zeigt an, ob die Daten gespeichert werden müssen (true) oder nicht (false).
    ''' </summary>
    ''' <value>Boolesche Variable, die anzeigt, ob Daten gespeichert werden müssen.</value>
    ''' <remarks></remarks>
    Public Property SavingState() As Boolean
        Get
            Return mySavingState
        End Get
        Set(ByVal value As Boolean)
            If value <> SavingState Then
                mySavingState = value
                RaiseEvent SavingStateChanged()
            End If
        End Set
    End Property
End Class
