Imports System.ComponentModel
Imports ActiveDev
Imports ActiveDev.Controls
Imports System.Windows.Forms
Imports System.Text

<CLSCompliant(False)> _
Public Class ucClearanceLevelCheckListBox
    Inherits ADEnumFlagCheckListBox(Of ClearanceLevel)
    Implements IADNullableValueControl

    Private myValue As ADDBNullable(Of ClearanceLevel)
    Private myIndependentDatafieldName As String
    Private myOnceModified As Boolean

    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADNullableValueControl.ValueChanged
    Public Event OnceModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADNullableValueControl.OnceModifiedChanged

    Public Overrides Function GetLocalizedEnumElementNamesPipeSeparated() As String
        Return FacessoGeneric.RoleList
    End Function

    Protected Overrides Sub OnItemCheck(ByVal ice As System.Windows.Forms.ItemCheckEventArgs)
        MyBase.OnItemCheck(ice)
        Dim locValue As ADDBNullable(Of ClearanceLevel) = ADDBNullable.FromObject(Of ClearanceLevel)(DirectCast(MyBase.ValueInternal, ClearanceLevel))
        If Not MyBase.myEventSourceWasSelf Then
            HandleOnceModified(locValue)
        End If
    End Sub

    Public Property IndependentDatafieldName() As String Implements IADNullableValueControl.IndependentDatafieldName
        Get
            Return myIndependentDatafieldName
        End Get
        Set(ByVal value As String)
            myIndependentDatafieldName = value
        End Set
    End Property

    Public ReadOnly Property OnceModified() As Boolean Implements IADNullableValueControl.OnceModified
        Get
            Return myOnceModified
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
    Browsable(False)> _
    Public Property Value() As IADDBNullableValue Implements IADNullableValueControl.Value
        Get
            Return myValue
        End Get
        Set(ByVal value As IADDBNullableValue)
            Dim locChangedFlag As Boolean
            If CType(value, ADDBNullable(Of ClearanceLevel)) <> CType(myValue, ADDBNullable(Of ClearanceLevel)) Then
                locChangedFlag = True
            End If
            If MyBase.IsHandleCreated Then
                RenderValue(CLng(value.Value))
            Else
                MyBase.myValueInternal = CLng(value.Value)
                myValue = DirectCast(value, ADDBNullable(Of ClearanceLevel))
            End If
            If locChangedFlag Then
                RaiseEvent ValueChanged(Me, New EventArgs)
            End If
        End Set
    End Property

    Private Sub HandleOnceModified(ByVal newValue As IADDBNullableValue)
        Dim locTempValue As ADDBNullable(Of ClearanceLevel) = DirectCast(newValue, ADDBNullable(Of ClearanceLevel))
        If locTempValue <> myValue Then
            myValue = locTempValue
            RaiseEvent ValueChanged(Me, New EventArgs())
            If Not myOnceModified Then
                RaiseEvent OnceModifiedChanged(Me, New EventArgs())
                myOnceModified = True
            End If
        End If
    End Sub

    Public Property NullValueMessage() As String Implements IADNullableValueControl.NullValueMessage
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)
            'Bleibt immer Nothing; Eigenschaft wird nicht verwendet!
        End Set
    End Property

    Public Overrides Property Text() As String Implements IADNullableValueControl.Text
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

End Class

Public Enum CombinedFlagsSelectionBehaviour
    SelectSingelFlag
    IgnoreSingleFlag
End Enum

Public MustInherit Class ADEnumFlagCheckListBox(Of EType)
    Inherits CheckedListBox

    Private myDeselectCombinedFlagsItemBehaviour As CombinedFlagsSelectionBehaviour
    Private mySelectCombinedFlagsItemBehaviour As CombinedFlagsSelectionBehaviour
    Protected myEventSourceWasSelf As Boolean
    Protected myValueInternal As Long

    Sub New()
        MyBase.New()
        myDeselectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.IgnoreSingleFlag
        mySelectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.SelectSingelFlag
        Me.CheckOnClick = True
        myValueInternal = 0
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        If Not Me.DesignMode Then
            Dim locLocalizedText As String = GetLocalizedEnumElementNamesPipeSeparated()
            Dim locEnumItems As New EnumCheckListBoxItems(Of EType)(locLocalizedText)
            For Each locItem As EnumCheckListBoxItem(Of EType) In locEnumItems
                Me.Items.Add(locItem, False)
            Next
            RenderValue(myValueInternal)
        End If
    End Sub

    Protected Overrides Sub OnItemCheck(ByVal ice As System.Windows.Forms.ItemCheckEventArgs)

        If Me.Items.Count = 0 Then Exit Sub
        If myEventSourceWasSelf Then Exit Sub

        Try
            Dim locEnumItem As EnumCheckListBoxItem(Of EType)
            Dim locSelectedItem As EnumCheckListBoxItem(Of EType) = DirectCast(Me.Items(ice.Index), EnumCheckListBoxItem(Of EType))
            Dim locStartIndex As Integer = 0

            'Wenn das erste Enum-Element Null-Wertigkeit hat,
            'dann ist StartIndex für alle weiteren Operationen 1
            If DirectCast(Me.Items(0), EnumCheckListBoxItem(Of EType)).EnumItemValue = 0 Then
                locStartIndex = 1

                'Wenn selektiertes Element mit Enum-Wertigkeit 0 ist, dann 
                'alle anderen zurücksetzen, wenn dieses Element gechecked wurde.
                If locSelectedItem.EnumItemValue = 0 Then
                    If ice.NewValue = CheckState.Checked Then
                        ' Alle löschen
                        myEventSourceWasSelf = True
                        For locCount As Integer = 1 To Me.Items.Count - 1
                            Me.SetItemChecked(locCount, False)
                        Next
                        myEventSourceWasSelf = False
                        'Falls dieses Element ge-unchecked wurde, dann das mit der niedrigsten
                        'nicht-0-Wertigkeit selektieren.
                    Else
                        myEventSourceWasSelf = True
                        If Me.Items.Count > 1 Then
                            Me.SetItemChecked(1, True)
                        End If
                        myEventSourceWasSelf = False
                    End If
                    Exit Sub
                End If
            End If

            If ice.NewValue = CheckState.Checked Then
                If SelectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.SelectSingelFlag Then
                    myEventSourceWasSelf = True
                    For locCount As Integer = 1 To Me.Items.Count - 1
                        locEnumItem = DirectCast(Me.Items(locCount), EnumCheckListBoxItem(Of EType))
                        If (locSelectedItem.EnumItemValue And locEnumItem.EnumItemValue) = locEnumItem.EnumItemValue Then
                            Me.SetItemChecked(locCount, True)
                        End If
                    Next
                    myEventSourceWasSelf = False
                End If
            Else
                If DeselectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.SelectSingelFlag Then
                    myEventSourceWasSelf = True
                    For locCount As Integer = 1 To Me.Items.Count - 1
                        locEnumItem = DirectCast(Me.Items(locCount), EnumCheckListBoxItem(Of EType))
                        If (locSelectedItem.EnumItemValue And locEnumItem.EnumItemValue) = locEnumItem.EnumItemValue Then
                            Me.SetItemChecked(locCount, False)
                        End If
                    Next
                    myEventSourceWasSelf = False
                End If

                'Die Übergeordneten zurücksetzen
                myEventSourceWasSelf = True
                For locCount As Integer = 1 To Me.Items.Count - 1
                    locEnumItem = DirectCast(Me.Items(locCount), EnumCheckListBoxItem(Of EType))
                    If (locEnumItem.EnumItemValue And locSelectedItem.EnumItemValue) = locSelectedItem.EnumItemValue Then
                        Me.SetItemChecked(locCount, False)
                    End If
                Next
                myEventSourceWasSelf = False
            End If
        Finally

            'Keine mehr angeklickt, dann "0"-Wert voreinstellen
            If Me.CheckedItems.Count = 0 Then
                myEventSourceWasSelf = True
                Me.SetItemChecked(0, True)
                myEventSourceWasSelf = False
            End If

            'Dafür sorgen, dass "0"-Wert nicht voreingestellt ist,
            'wenn andere Elemente ausgewählt werden.
            If ice.Index > 0 And ice.NewValue = CheckState.Checked Then
                myEventSourceWasSelf = True
                Me.SetItemChecked(0, False)
                myEventSourceWasSelf = False
            End If

            MyBase.OnItemCheck(ice)
            Dim locLong As Long
            For Each li As EnumCheckListBoxItem(Of EType) In Me.CheckedItems
                locLong = locLong Or li.EnumItemValue
            Next
            myValueInternal = locLong
            Debug.Print(myValueInternal.ToString)

        End Try
    End Sub

    Protected Property ValueInternal() As Long
        Get
            Return myValueInternal
        End Get
        Set(ByVal value As Long)
            RenderValue(value)
        End Set
    End Property

    Protected Sub RenderValue(ByVal Value As Long)
        Try
            myEventSourceWasSelf = True
            If Value = 0 Then
                SetItemChecked(0, True)
                Exit Sub
            End If
            For locCount As Integer = 1 To Me.Items.Count - 1
                Dim locCurrentItem As EnumCheckListBoxItem(Of EType) = DirectCast(Me.Items(locCount), EnumCheckListBoxItem(Of EType))
                If (Value And locCurrentItem.EnumItemValue) = locCurrentItem.EnumItemValue Then
                    SetItemChecked(locCount, True)
                Else
                    SetItemChecked(locCount, False)
                End If
            Next
        Finally
            myEventSourceWasSelf = False
        End Try
    End Sub

    Public Property DeselectCombinedFlagsItemBehaviour() As CombinedFlagsSelectionBehaviour
        Get
            Return myDeselectCombinedFlagsItemBehaviour
        End Get
        Set(ByVal value As CombinedFlagsSelectionBehaviour)
            myDeselectCombinedFlagsItemBehaviour = value
        End Set
    End Property

    Public Property SelectCombinedFlagsItemBehaviour() As CombinedFlagsSelectionBehaviour
        Get
            Return mySelectCombinedFlagsItemBehaviour
        End Get
        Set(ByVal value As CombinedFlagsSelectionBehaviour)
            mySelectCombinedFlagsItemBehaviour = value
        End Set
    End Property

    Public MustOverride Function GetLocalizedEnumElementNamesPipeSeparated() As String

    Public Overrides Function ToString() As String
        Dim locString As New StringBuilder()
        For Each li As EnumCheckListBoxItem(Of EType) In Me.CheckedItems
            locString.Append(li.LocalizedText & "; ")
        Next
        Return locString.ToString
    End Function

End Class

Friend Structure EnumCheckListBoxItem(Of EType)
    Public EnumItemValue As Long
    Public EnumText As String
    Public LocalizedText As String

    Sub New(ByVal value As Long, ByVal et As String, ByVal lt As String)
        If GetType(EType).BaseType IsNot GetType([Enum]) Then
            Dim up As New TypeLoadException("Only Enum derivatives are allowed in this context!")
            Throw up
        End If

        EnumItemValue = value
        EnumText = et
        LocalizedText = lt
    End Sub

    Public Overrides Function ToString() As String
        Return LocalizedText
    End Function
End Structure

Friend Class EnumCheckListBoxItems(Of EType)
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Long, EnumCheckListBoxItem(Of EType))

    Sub New(ByVal plainTextElements As String)
        MyBase.New()
        If GetType(EType).BaseType IsNot GetType([Enum]) Then
            Dim up As New TypeLoadException("Only Enum derivatives are allowed in this context!")
            Throw up
        End If

        Dim locLocalizedElements As String() = plainTextElements.Split(New Char() {"|"c})
        Dim locOriginalElements As String() = [Enum].GetNames(GetType(EType))
        Dim locCount As Integer = 0
        For Each i As Long In [Enum].GetValues(GetType(EType))
            Me.Add(New EnumCheckListBoxItem(Of EType)(i, _
                                                     locOriginalElements(locCount), _
                                                     locLocalizedElements(locCount)))
            locCount += 1
        Next
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As EnumCheckListBoxItem(Of EType)) As Long
        Return CLng(item.EnumItemValue)
    End Function

End Class

