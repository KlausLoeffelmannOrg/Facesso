Imports ActiveDev
Imports System.Collections.ObjectModel

Public Class CustomListViewGroup(Of InfoItemType As IInfoItem)
    Private _InfoItems As InfoItems(of InfoItemType)
    Private _GroupName As String

    Sub New(ByVal Groupname As String, ByVal InfoItems As InfoItems(Of InfoItemType))
        _InfoItems = InfoItems
        _GroupName = Groupname
    End Sub

    Public Property InfoItems() As InfoItems(Of InfoItemType)
        Get
            Return _InfoItems
        End Get
        Set(ByVal value As InfoItems(Of InfoItemType))
            _InfoItems = value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return _GroupName
        End Get
        Set(ByVal value As String)
            _GroupName = value
        End Set
    End Property

End Class

Public Class CustomListViewGroups(Of InfoItemType As IInfoItem)
    Inherits KeyedCollection(Of String, CustomListViewGroup(Of InfoItemType))

    Private myKeyProvidedThroughAdd As String = Nothing

    Protected Overrides Function GetKeyForItem(ByVal item As CustomListViewGroup(Of InfoItemType)) As String
        Return item.GroupName
    End Function

    Public Function GroupSortIndexOfID(ByVal ID As Integer) As Integer
        Dim locCount As Integer = Me.Count
        For Each item As CustomListViewGroup(Of InfoItemType) In Me
            If item.InfoItems.Contains(New IntKey(ID)) Then
                Return Me.Count - locCount + 1
            End If
            locCount -= 1
        Next
        Return 0
    End Function

End Class
