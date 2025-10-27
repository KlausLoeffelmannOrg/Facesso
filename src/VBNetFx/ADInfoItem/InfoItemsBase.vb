Imports ActiveDev
Imports System.Reflection
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports ActiveDev.Controls

<CLSCompliant(True)> _
Public Interface IInfoItem
    ReadOnly Property DataID() As Integer
    ReadOnly Property DisplayName() As String
    Sub AssignFieldsFromNullableControls(ByVal controls As ADNullableValueControls)
    Sub AssignFieldsToNullableControls(ByVal controls As ADNullableValueControls)
    Sub AssignFieldsFromDataReader(ByVal dr As SqlDataReader)
End Interface

<CLSCompliant(True)> _
Public MustInherit Class InfoItemBase
    Implements IInfoItem

    Public MustOverride ReadOnly Property DataID() As Integer Implements IInfoItem.DataID
    Public MustOverride ReadOnly Property DisplayName() As String Implements IInfoItem.DisplayName

    Public Overridable Sub AssignFieldsToNullableControls(ByVal controls As ADNullableValueControls) _
        Implements IInfoItem.AssignFieldsToNullableControls

        Dim locADDBNullableType As Type = GetType(ADDBNullable)

        For Each c As IADNullableValueControl In controls
            'Namen der Eigenschaft ermitteln
            Dim locDatafieldName As String = c.IndependentDatafieldName
            If locDatafieldName <> "" And locDatafieldName IsNot Nothing Then
                Dim locCurrentProperty As PropertyInfo = Me.GetType.GetProperty(c.IndependentDatafieldName)
                'Ist bereits generischer Typ, dann muss nichts gemacht werden.
                If locCurrentProperty.PropertyType.IsGenericType Then
                    c.Value = CType(locCurrentProperty.GetValue(Me, Nothing), IADDBNullableValue)
                Else
                    'komplizierter ist's bei primitiven Typen:
                    'Hier muss FromObject aus ADDBNullable per Reflection eingebunden werden,
                    'um aus dem primitiven Typen sein generisches Äquivalent zu machen.
                    Dim locGenericBasedType As Type = CObj(c.Value).GetType.GetGenericArguments(0)
                    Dim locToObjectMethod As MethodInfo = locADDBNullableType.GetMethod("FromObject")
                    'Eine generische Methode daraus machen (den TypParameter festlegen)
                    locToObjectMethod = locToObjectMethod.MakeGenericMethod(New Type() {locGenericBasedType})
                    'Wert erstmal als Objekt ermitteln, und dann in IADDBNullableValue casten.
                    Dim locObject As Object = locToObjectMethod.Invoke(Me, New Object() {locCurrentProperty.GetValue(Me, Nothing)})
                    c.Value = CType(locObject, IADDBNullableValue)
                End If
            End If
        Next
    End Sub

    Public Overridable Sub AssignFieldsFromNullableControls(ByVal controls As ADNullableValueControls) _
            Implements IInfoItem.AssignFieldsFromNullableControls

        Dim locADDBNullableType As Type = GetType(ADDBNullable)

        For Each c As IADNullableValueControl In controls
            'Namen der korrelierenden Eigenschaft ermitteln
            Dim locDatafieldName As String = c.IndependentDatafieldName
            If locDatafieldName <> "" And locDatafieldName IsNot Nothing Then
                Dim locCurrentProperty As PropertyInfo = Me.GetType.GetProperty(c.IndependentDatafieldName)
                If locCurrentProperty.PropertyType.IsGenericType Then
                    locCurrentProperty.SetValue(Me, c.Value, Nothing)
                Else
                    'komplizierter ist's bei primitiven Typen:
                    'Hier muss ToObject aus ADDBNullable per Reflection eingebunden werden,
                    'um aus dem Generic ADNullable-Typen sein primitives Äquivalent zu machen.
                    Dim locGenericBasedType As Type = CObj(c.Value).GetType.GetGenericArguments(0)
                    Dim locToObjectMethod As MethodInfo = locADDBNullableType.GetMethod("ToObject")
                    'Eine generische Methode daraus machen
                    locToObjectMethod = locToObjectMethod.MakeGenericMethod(New Type() {locGenericBasedType})
                    'Und SetValue verwenden, indem der Wert über FromObjectMethodInfo.Invoke ermittelt und der
                    'ADDBNullable-generischen Eigenschaft zugewiesen wird
                    Dim locObjTemp As Object = locToObjectMethod.Invoke(Me, New Object() {c.Value})
                    'Convert-Klasse verwenden, damit der Umgang mit numerischen Typen ein wenig "lockerer" wird!
                    locCurrentProperty.SetValue(Me, Convert.ChangeType(locObjTemp, locCurrentProperty.PropertyType), Nothing)
                End If
            End If
        Next
    End Sub

    Public Overridable Sub AssignFieldsFromDataReader(ByVal dr As SqlDataReader) _
            Implements IInfoItem.AssignFieldsFromDataReader

        Dim locProperties As ADPropertyInfoCollection = ADClassReflector.GetProperties(Me)
        Dim locADDBNullableType As Type = GetType(ADDBNullable)
        Dim locCurrentProperty As PropertyInfo = Nothing

        For locCount As Integer = 0 To dr.FieldCount - 1
            Dim locColumnType As Type = dr.GetFieldType(locCount)
            Dim locFieldname As String = dr.GetName(locCount)

            If locProperties.Contains(locFieldname) Then
                locCurrentProperty = locProperties(locFieldname)
                If locCurrentProperty.PropertyType.IsGenericType Then
                    'Fallunterscheidung zwischen ADDBNullable und primitiven Typen
                    Dim locGType As Type = locCurrentProperty.PropertyType.GetGenericTypeDefinition
                    If locCurrentProperty.PropertyType.GetGenericTypeDefinition Is GetType(ADDBNullable(Of )) Then
                        'Typen finden, auf dem ADDBNullable basiert
                        Dim locGenericBasedType As Type = locCurrentProperty.PropertyType.GetGenericArguments(0)

                        'FromObject von ADDBNullable invoken
                        'Dazu zunächst erstmal die Methode "ungenerisch" als MethodInfo ermitteln
                        Dim locFromObjectMethod As MethodInfo = locADDBNullableType.GetMethod("FromObject")
                        'Eine generische Methode daraus machen
                        locFromObjectMethod = locFromObjectMethod.MakeGenericMethod(New Type() {locGenericBasedType})
                        'Und SetValue verwenden, indem der Wert über FromObjectMethodInfo.Invoke ermittelt und der
                        'ADDBNullable-generischen Eigenschaft zugewiesen wird
                        locCurrentProperty.SetValue(Me, locFromObjectMethod.Invoke(Me, New Object() {dr.GetValue(locCount)}), Nothing)
                    End If
                Else
                    'einfacher ist's bei primitiven Typen:
                    locCurrentProperty.SetValue(Me, dr.GetValue(locCount), Nothing)
                End If
            End If
        Next
    End Sub

    Public Function NumFormatString(ByVal Precision As Byte) As String
        Dim locret As String = "#,##0"
        If Precision > 0 Then
            locret &= "." & New String("0"c, Precision)
        End If
        Return locret
    End Function

    ''' <summary>
    ''' Bestimmt oder ermittelt, wann das entsprechende Info-Item in einer UI-Auswahl durch den Anwender selektiert worden ist, 
    ''' um beispielsweise eine Selektierungsreihenfolge ermitteln zu können.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectionDate As Date?

End Class

Public Class InfoItems(Of InfoItemType As IInfoItem)
    Inherits KeyedCollection(Of IntKey, InfoItemType)

    Protected Overrides Function GetKeyForItem(ByVal item As InfoItemType) As IntKey
        Return New IntKey(item.DataID)
    End Function
End Class

Public Class InfoItemInfo
    Inherits Attribute

    Private myTitel As String
    Private mySortable As Boolean
    Private myOrderID As Integer
End Class

Public Structure IntKey
    Private myValue As Integer

    Sub New(ByVal Value As Integer)
        myValue = Value
    End Sub

    Public Property Value() As Integer
        Get
            Return myValue
        End Get
        Set(ByVal value As Integer)
            myValue = value
        End Set
    End Property

    'Public Shared Widening Operator CType(ByVal intValue As Integer) As IntKey
    '    Return New IntKey(intValue)
    'End Operator
End Structure


