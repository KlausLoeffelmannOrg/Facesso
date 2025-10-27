Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic

Public Class ADNullableIdOrIndexComboBox
    Inherits ADNullableValueControlTemplate(Of Integer)

    Private myComboBox As ADComboBoxedValueForNullableValueControl

    Protected Overrides Sub CreateControls()
        myComboBox = New ADComboBoxedValueForNullableValueControl
        Me.EditableValueControl = myComboBox
        Me.CaptionControl = New ADCaptionForNullableValueControl
    End Sub

    Sub New()
        MyBase.New()
        myDontConditionForDisplay = True
        ConsiderFixedSize = True
        Me.Value = New ADDBNullable(Of IComparable)
    End Sub

    Public Property ComboBoxValueType() As ADNullableComboBoxValueType
        Get
            Return myComboBox.ComboBoxValueType
        End Get
        Set(ByVal value As ADNullableComboBoxValueType)
            If value = ADNullableComboBoxValueType.Content_As_String Then
                Dim up As New ADTypeMismatchException("ValueType nicht möglich. Setzen Sie stattdessen 'ADNullableContentComboBox' ein, um die Auswahl über den Steuerelemente-Inhalt zu setzen oder diesen direkt aufzufragen!", _
                                                      "This ValueType can't be set in this circumstance. Choose 'AdNullableContentComboBox' instead for setting or getting the selected item via the actual content.")
                Throw up
            End If
            myComboBox.ComboBoxValueType = value
        End Set
    End Property

    Public Property DropDownHeight() As Integer
        Get
            Return myComboBox.DropDownHeight
        End Get
        Set(ByVal value As Integer)
            myComboBox.DropDownHeight = value
        End Set
    End Property

    Public Property DropDownWidth() As Integer
        Get
            Return myComboBox.DropDownWidth
        End Get
        Set(ByVal value As Integer)
            myComboBox.DropDownWidth = value
        End Set
    End Property

    Public Property MaxDropDownItems() As Integer
        Get
            Return myComboBox.MaxDropDownItems
        End Get
        Set(ByVal value As Integer)
            myComboBox.MaxDropDownItems = value
        End Set
    End Property

    Public ReadOnly Property Items() As ADComboBoxItemCollection
        Get
            Return DirectCast(EditableValueControl, ADComboBoxedValueForNullableValueControl).Items
        End Get
    End Property

    Friend ReadOnly Property UnderlyingComboBoxControl() As ComboBox
        Get
            Return DirectCast(Me.EditableValueControl, ADComboBoxedValueForNullableValueControl).ComboBoxInstance
        End Get
    End Property

    'Nicht gebraucht für dieses Steuerelement, da die Anzeigedarstellung immer der Editierdarstellung entspricht
    Protected Overrides Function ToObjectForDisplaying(ByVal Value As IADDBNullableValue, ByVal ForSetValue As Boolean) As Object
        Return NullString
    End Function

    Protected Overrides Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of Integer)
            'Case ADNullableComboBoxValueType.Content_As_String
        '    Return New ADDBNullable(Of IComparable)(DirectCast([Object], ADDBNullable(Of String)))
        Return New ADDBNullable(Of Integer)(DirectCast([Object], ADDBNullable(Of Integer)))
    End Function

    Protected Overrides Function GetCurrentControlValue() As IADDBNullableValue
        Return New ADDBNullable(Of Integer)(DirectCast(myValueControl.Value, ADDBNullable(Of Integer)))
    End Function
End Class

Public Enum ADNullableComboBoxValueType
    Content_As_String
    ID_As_Int32
    Index_As_Int32
End Enum

Public Class ADComboBoxItemCollection

    Private myComboBoxObjectCollection As ComboBox.ObjectCollection

    Sub New(ByVal owner As ADNullableIdOrIndexComboBox)
        myComboBoxObjectCollection = New ComboBox.ObjectCollection(owner.UnderlyingComboBoxControl)
    End Sub

    Sub New(ByVal ObjCollection As ComboBox.ObjectCollection)
        myComboBoxObjectCollection = ObjCollection
    End Sub

    Function Add(ByVal Item As ADComboBoxItem) As Integer
        Return myComboBoxObjectCollection.Add(Item)
    End Function

    Sub RemoveByID(ByVal ID As Integer)
        Dim locIndex As Integer = IndexFromID(ID)
        If locIndex > -1 Then
            myComboBoxObjectCollection.RemoveAt(locIndex)
        Else
            'Todo: Translate
            Dim up As New ADArgumentException("Ein Wert mit der angegebenen ID konnte in der Objektliste der ComboBox nicht gefunden werden!", "A value with the ID could not be found in the object list of the ComboBox!", "ID")
            Throw up
        End If
    End Sub

    Sub RemoveAt(ByVal Index As Integer)
        myComboBoxObjectCollection.RemoveAt(Index)
    End Sub

    Default Property Item(ByVal Index As Integer) As Object
        Get
            Return myComboBoxObjectCollection(Index)
        End Get
        Set(ByVal value As Object)
            myComboBoxObjectCollection(Index) = value
        End Set
    End Property

    Function IndexFromID(ByVal ID As Integer) As Integer
        Dim locIndex As Integer = 0

        For Each myItem As ADComboBoxItem In myComboBoxObjectCollection
            If myItem.ID = ID Then
                Return locIndex
            End If
            locIndex += 1
        Next
        Return -1
    End Function

    Function IndexFromString(ByVal Item As String) As Integer
        Dim locIndex As Integer = 0
        For Each myItem As ADComboBoxItem In myComboBoxObjectCollection
            If myItem.Item.ToString = Item Then
                Return locIndex
            End If
            locIndex += 1
        Next
        Return -1
    End Function
End Class

Public Structure ADComboBoxItem
    Implements IComparable

    Private myID As Integer
    Private myItem As Object

    Sub New(ByVal ID As Integer, ByVal Item As Object)
        myID = ID
        myItem = Item
    End Sub

    Public Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal value As Integer)
            myID = value
        End Set
    End Property

    Public Property Item() As Object
        Get
            Return myItem
        End Get
        Set(ByVal value As Object)
            myItem = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Item.ToString
    End Function

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Dim locCTItem As ADComboBoxItem = CType(obj, ADComboBoxItem)
        Return Me.Item.ToString.CompareTo(locCTItem.Item.ToString)
    End Function
End Structure
