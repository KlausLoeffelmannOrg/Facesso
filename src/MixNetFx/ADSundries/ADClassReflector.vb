Imports System.Collections.ObjectModel
Imports System.Reflection

Public Module ADClassReflector

    Function GetProperties(ByVal classInstance As Object) As ADPropertyInfoCollection
        Dim locPropertyInfos() As PropertyInfo = classInstance.GetType.GetProperties
        If locPropertyInfos.Length = 0 Then Return Nothing
        Dim retPropertyInfoCollection As New ADPropertyInfoCollection()
        For Each locPropertyInfo As PropertyInfo In locPropertyInfos
            retPropertyInfoCollection.Add(locPropertyInfo)
        Next
        Return retPropertyInfoCollection
    End Function

End Module

Public Class ADPropertyInfoCollection
    Inherits KeyedCollection(Of String, PropertyInfo)

    Protected Overrides Function GetKeyForItem(ByVal item As System.Reflection.PropertyInfo) As String
        Return item.Name
    End Function
End Class
