Imports System.Windows.Forms
Imports Facesso
Imports Facesso.Data

<Serializable()> _
Public Class FacessoConversionItemsBase
    Inherits System.Collections.ObjectModel.KeyedCollection(Of ActiveDev.IntKey, FacessoConversionItemBase)

    Protected Overrides Function GetKeyForItem(ByVal item As FacessoConversionItemBase) As ActiveDev.IntKey
        Return New ActiveDev.IntKey(item.AlienElementID)
    End Function
End Class

<Serializable()> _
Public Class FacessoConversionItemBase
    Implements IFacessoConversionItem

    Private myAlienElementID As Integer
    Private myHomeElementID As Integer
    Private myHomeElementName As String
    Private myItemname As String

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal ID As Integer, ByVal Itemname As String)
        myAlienElementID = ID
        myHomeElementID = -1
        myItemname = Itemname
    End Sub

    Public Property AlienElementID() As Integer Implements IFacessoConversionItem.AlienElementID
        Get
            Return myAlienElementID
        End Get
        Set(ByVal value As Integer)
            myAlienElementID = value
        End Set
    End Property

    Public Property Itemname() As String Implements IFacessoConversionItem.Itemname
        Get
            Return myItemname
        End Get
        Set(ByVal value As String)
            myItemname = value
        End Set
    End Property

    Public Property HomeElementID() As Integer Implements IFacessoConversionItem.HomeElementID
        Get
            Return myHomeElementID
        End Get
        Set(ByVal value As Integer)
            myHomeElementID = value
        End Set
    End Property

    Public Overrides Function ToString() As String Implements IFacessoConversionItem.ToString
        Return myItemname
    End Function

    Public Property HomeElementName() As String Implements IFacessoConversionItem.HomeElementName
        Get
            Return myHomeElementName
        End Get
        Set(ByVal value As String)
            myHomeElementName = value
        End Set
    End Property
End Class
