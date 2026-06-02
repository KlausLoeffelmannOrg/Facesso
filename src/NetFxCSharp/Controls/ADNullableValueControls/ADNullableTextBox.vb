Imports System.ComponentModel
Imports System.Windows.Forms

Public Class ADNullableTextBox
    Inherits ADNullableValueControlTemplate(Of String)

    Protected myReturnNullOnEmptyString As Boolean

    Protected Overrides Sub CreateControls()
        Me.EditableValueControl = New ADEditableValueForNullableValueControl
        Me.CaptionControl = New ADCaptionForNullableValueControl
    End Sub

    Sub New()
        MyBase.New()
        ConsiderFixedSize = True
        Me.NullString = "* --- *"
        Me.Value = New ADDBNullable(Of String)
        Me.ReturnNullOnEmptyString = True
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
    ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Steuert, ob der Text im Datenerfassungsbereich mehr als eine Zeile umfassen darf.", _
                   "Controls, if the text in the data input area can contain more than one line.")> _
    Public Property Multiline() As Boolean
        Get
            Return DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).Multiline
        End Get
        Set(ByVal Value As Boolean)
            DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).Multiline() = Value
            If Value Then
                ConsiderFixedSize = False
                myControlHeight = myRequestedlHeight
            Else
                ConsiderFixedSize = True
            End If
            UpdateLayout()
        End Set
    End Property

    <ADCategory("Darstellung", "Display"), _
    ADDescription("Bestimmt oder ermittelt, welche Scrollbalken der Datenerfassungsbereich aufweisen soll.", _
                   "Sets or gets, which scrollbars should be available for scrolling in the data input area.")> _
    Public Property Scrollbars() As Scrollbars
        Get
            Return DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).ScrollBars
        End Get
        Set(ByVal Value As Scrollbars)
            DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).ScrollBars = Value
            UpdateLayout()
        End Set
    End Property

    Public Function ShouldSerializeScrollbars() As Boolean
        Return Not (Scrollbars = Scrollbars.None)
    End Function

    <ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Bestimmt, wieviele Zeichen im Datenerfassungsbereich maximal eingegeben werden dürfen.", _
                   "Determines the amount of characters the user can enter in the data input area."), _
    DefaultValue(32767)> _
    Public Property MaxLength() As Integer
        Get
            Return DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).MaxLength
        End Get
        Set(ByVal Value As Integer)
            DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).MaxLength = Value
            UpdateLayout()
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Bestimmt, ob der dargestellte Wert/Text nicht verändert werden darf.", _
               "Determines, wether the displayed value can be changed or not."), _
    DefaultValue(False)> _
    Public Property [ReadOnly]() As Boolean
        Get
            Return DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).Readonly
        End Get
        Set(ByVal Value As Boolean)
            DirectCast(Me.EditableValueControl, ADEditableValueForNullableValueControl).Readonly = Value
            UpdateLayout()
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Bestimmt, ob NULL zurückgeliefert werden soll, wenn keine Eingabe im Datenerfassungsbereich vorgenommen wurde.", _
                   "Determines, if NULL is returned, when no data has been entered in the data input area."), _
    DefaultValue(True)> _
    Public Property ReturnNullOnEmptyString() As Boolean
        Get
            Return myReturnNullOnEmptyString
        End Get
        Set(ByVal Value As Boolean)
            myReturnNullOnEmptyString = Value
        End Set
    End Property

    Protected Overrides Function ToObjectForDisplaying(ByVal Value As IADDBNullableValue, ByVal ForSetValue As Boolean) As Object
        If Not Value.HasValue Then
            Return NullString
        Else
            Return Value.Value.ToString
        End If
    End Function

    Protected Overrides Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of String)
        If ReturnNullOnEmptyString Then
            If [Object].ToString = "" Or [Object] Is Nothing Then
                Return Nothing
            End If
        End If
        Return ADDBNullable.FromObject(Of String)([Object])
    End Function
End Class
