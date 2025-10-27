Imports System.Windows.Forms
Imports System.Collections

Friend Class ADComboBoxedValueForNullableValueControl
    Inherits ADEditableValueForNullableValueControlTemplate(Of IComparable)

    Protected WithEvents myComboBox As ComboBox
    Protected myComboBoxItemCollection As ADComboBoxItemCollection
    Protected myComboBoxValueType As ADNullableComboBoxValueType

    Sub New()
        MyBase.New()
        myComboBoxValueType = ADNullableComboBoxValueType.ID_As_Int32
        myComboBox = New ComboBox
        myControl = myComboBox
        myControl.Name = "ADComboBoxedValueForUVTControl" & myInstanceCounter
        myComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        myComboBoxItemCollection = New ADComboBoxItemCollection(myComboBox.Items)
    End Sub

    Public Overrides Property Size() As System.Drawing.Size
        Get
            Return myControl.Size
        End Get
        Set(ByVal Value As System.Drawing.Size)
            myControl.Size = Value
        End Set
    End Property

    Public Overrides Function MeasureHeight() As Integer
        Return (myControl.Height) * -1
    End Function

    Public Overrides Property Value() As Object
        Get
            If myComboBox.SelectedIndex = -1 Then
                Select Case ComboBoxValueType
                    Case ADNullableComboBoxValueType.Content_As_String
                        Return New ADDBNullable(Of String)
                    Case Else
                        Dim locNullableInt As New ADDBNullable(Of Integer)
                        Return locNullableInt
                End Select
            End If

            Select Case ComboBoxValueType
                Case ADNullableComboBoxValueType.Content_As_String
                    Return New ADDBNullable(Of String)(DirectCast(myComboBox.Items(myComboBox.SelectedIndex), ADComboBoxItem).ToString)
                Case ADNullableComboBoxValueType.Index_As_Int32
                    Return New ADDBNullable(Of Integer)(myComboBox.SelectedIndex)
                Case Else
                    Return New ADDBNullable(Of Integer)(DirectCast(myComboBox.Items(myComboBox.SelectedIndex), ADComboBoxItem).ID)
            End Select
        End Get
        Set(ByVal Value As Object)
            If (Value Is Nothing) Then
                myComboBox.SelectedIndex = -1
            ElseIf TypeOf Value Is ADDBNullable(Of Integer) Then
                If Not DirectCast(Value, ADDBNullable(Of Integer)).HasValue Then
                    myComboBox.SelectedIndex = -1
                Else
                    Dim locInt As Integer = CInt(DirectCast(Value, ADDBNullable(Of Integer)).Value)
                    Select Case ComboBoxValueType
                        Case ADNullableComboBoxValueType.Index_As_Int32
                            myComboBox.SelectedIndex = locInt
                        Case ADNullableComboBoxValueType.ID_As_Int32
                            myComboBox.SelectedIndex = myComboBoxItemCollection.IndexFromID(locInt)
                        Case Else
                            Dim Up As New InvalidCastException("ADDBNullable(Of Integer) expected as Value")
                            Throw Up
                    End Select
                End If
            ElseIf TypeOf Value Is ADDBNullable(Of String) Then
                If Not DirectCast(Value, ADDBNullable(Of String)).HasValue Then
                    myComboBox.SelectedIndex = -1
                Else
                    If ComboBoxValueType = ADNullableComboBoxValueType.Content_As_String Then
                        myComboBox.SelectedIndex = myComboBoxItemCollection.IndexFromString(DirectCast(Value, ADDBNullable(Of String)).Value.ToString)
                    Else
                        Dim Up As New InvalidCastException("ADDBNullable(Of String) expected as Value")
                        Throw Up
                    End If
                End If
            End If
        End Set
    End Property

    Public Property ComboBoxValueType() As ADNullableComboBoxValueType
        Get
            Return myComboBoxValueType
        End Get
        Set(ByVal value As ADNullableComboBoxValueType)
            myComboBoxValueType = value
        End Set
    End Property

    Public Property SelectedIndex() As Integer
        Get
            Return myComboBox.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            myComboBox.SelectedIndex = value
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

    Public Overridable ReadOnly Property Items() As ADComboBoxItemCollection
        Get
            Return myComboBoxItemCollection
        End Get
    End Property

    Friend ReadOnly Property ComboBoxInstance() As ComboBox
        Get
            Return myComboBox
        End Get
    End Property

    Private Sub myComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myComboBox.SelectedIndexChanged
        OnValueChanged(e)
    End Sub
End Class

