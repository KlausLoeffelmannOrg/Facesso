Imports System.Data.SqlClient

Public Class BonusListItem

    Private myIDBonusList As Integer
    Private myIDSubsidiary As Integer
    Private myIDBonusLists As Integer
    Private myDegreeOfTime As Double
    Private myDegreeOfTimeInternal As DegreeOfTime
    Private myPercentage As Double
    Private myAbsoluteValue As Decimal
    Private myCostCenterInfo As CostcenterInfo

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal cci As CostcenterInfo)
        With Me
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDBonusList = dr.GetInt32(dr.GetOrdinal("IDBonusList"))
            .IDBonusLists = dr.GetInt32(dr.GetOrdinal("IDBonusLists"))
            .CostCenterInfo = cci
            .DegreeOfTime = dr.GetDecimal(dr.GetOrdinal("DegreeOfTime"))
            .Percentage = dr.GetDecimal(dr.GetOrdinal("Percentage"))
            .AbsoluteValue = dr.GetDecimal(dr.GetOrdinal("AbsoluteValue"))
        End With
    End Sub

    Public Property IDBonusList() As Integer
        Get
            Return myIDBonusList
        End Get
        Set(ByVal value As Integer)
            myIDBonusList = value
        End Set
    End Property

    Public Property IDSubsidiary() As Integer
        Get
            Return myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            myIDSubsidiary = value
        End Set
    End Property

    Public Property IDBonusLists() As Integer
        Get
            Return myIDBonusLists
        End Get
        Set(ByVal value As Integer)
            myIDBonusLists = value
        End Set
    End Property

    Public Property DegreeOfTime() As Double
        Get
            Return myDegreeOfTime
        End Get
        Set(ByVal value As Double)
            myDegreeOfTime = value
            If CostCenterInfo IsNot Nothing Then
                myDegreeOfTimeInternal = New DegreeOfTime(value, _
                                                          CostCenterInfo.IncentiveIndicatorFactor, _
                                                          CostCenterInfo.IncentiveIndicatorPrecision, _
                                                          CostCenterInfo.IncentiveIndicatorDimension)
            Else
                myDegreeOfTimeInternal = value
            End If
        End Set
    End Property

    Public Property DegreeOfTimeAligned() As Double
        Get
            Return myDegreeOfTimeInternal.Value
        End Get
        Set(ByVal value As Double)
            myDegreeOfTimeInternal.Value = value
        End Set
    End Property

    Public Property Percentage() As Double
        Get
            Return myPercentage
        End Get
        Set(ByVal value As Double)
            myPercentage = value
        End Set
    End Property

    Public Property AbsoluteValue() As Decimal
        Get
            Return myAbsoluteValue
        End Get
        Set(ByVal value As Decimal)
            myAbsoluteValue = value
        End Set
    End Property

    Public ReadOnly Property DegreeOfTimeAlignedText() As String
        Get
            Return DegreeOfTimeAligned.ToString & " " & CostCenterInfo.IncentiveIndicatorDimension
        End Get
    End Property

    Public Property CostCenterInfo() As CostcenterInfo
        Get
            Return myCostCenterInfo
        End Get
        Set(ByVal value As CostcenterInfo)
            myCostCenterInfo = value
            myDegreeOfTimeInternal = New DegreeOfTime(myDegreeOfTime, _
                                          myCostCenterInfo.IncentiveIndicatorFactor, _
                                          myCostCenterInfo.IncentiveIndicatorPrecision, _
                                          myCostCenterInfo.IncentiveIndicatorDimension)
        End Set
    End Property
End Class

Public Class BonusListItems
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Integer, BonusListItem)

    Protected Overrides Function GetKeyForItem(ByVal item As BonusListItem) As Integer
        Return item.IDBonusList
    End Function
End Class
