Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class ADNullableCheckBox
    Inherits ADNullableValueControlTemplate(Of Boolean)

    Protected Overrides Sub CreateControls()
        Me.EditableValueControl = New ADCheckBoxedValueForNullableValueControl
        Me.CaptionControl = New ADCaptionForNullableValueControl
    End Sub

    Sub New()
        MyBase.New()

        Dim locNullable As New ADDBNullable(Of Boolean)
        locNullable = Nothing

        ConsiderFixedSize = True
        myDontConditionForDisplay = True

        Me.Value = locNullable
    End Sub

    Protected Overrides Function GetInitialValueControlColor() As System.Drawing.Color
        Return SystemColors.Control
    End Function

    'Vorgegebene Breite der Controls
    'Aus ihnen ergibt sich das anfängliche Verhältnis für
    'Captionlänge und Wertebereichlänge
    Protected Overrides ReadOnly Property InitialCaptionControlLength() As Integer
        Get
            Return 400
        End Get
    End Property

    Protected Overrides ReadOnly Property InitialValueControlLength() As Integer
        Get
            Return 100
        End Get
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
    DefaultValue(True), _
    ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Steuert, ob der Text im Datenerfassungsbereich mehr als eine Zeile umfassen darf.", _
               "Controls, if the text in the data input area can contain more than one line.")> _
    Public Property AutoHeight() As Boolean
        Get
            Return ConsiderFixedSize
        End Get
        Set(ByVal Value As Boolean)
            ConsiderFixedSize = Value
            UpdateLayout()
        End Set
    End Property

    Protected Overrides Function ToObjectForDisplaying(ByVal Value As IADDBNullableValue, ByVal ForSetValue As Boolean) As Object
        If Not Value.HasValue Then
            Return NullString
        Else
            Return Value.Value.ToString
        End If
    End Function

    Protected Overrides Function ToObjectForEditing(ByVal Value As IADDBNullableValue) As Object
        Return Value
    End Function

    Protected Overrides Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of Boolean)
        If [Object] Is Nothing Then
            Return Nothing
        End If

        Return CBool([Object])

    End Function
End Class
