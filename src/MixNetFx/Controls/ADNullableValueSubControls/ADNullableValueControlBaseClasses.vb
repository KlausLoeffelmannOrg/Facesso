Imports System.Windows.Forms
Imports System.Drawing

Public Interface IADCaptionForNullableValueControl

    Property Alignment() As ContentAlignment
    Property BorderStyle() As BorderStyle
    Property Font() As Font
    Property BackColor() As Color
    Property ForeColor() As Color
    Property Text() As String
    'Liefert ein Control-Array zurück, dass dem umgebenden
    'Steuerelement hinzugefügt wird. Damit kann das Beschriftungs-Control
    'durchaus auch aus mehreren Controls bestehen
    ReadOnly Property Controls() As Control()
    Property Location() As Point
    Property Size() As Size
    'Definiert die Größenreglementierung der Beschriftung
    'Positiver Wert: Mindesthöhe
    'Negativer Wert: Fixe Höhe
    Function MeasureHeight() As Integer
    Property Parent() As Control
    Sub Invalidate()

End Interface

Public Interface IADEditableValueForNullableValueControl

    Property Font() As Font
    Property BackColor() As Color
    Property ForeColor() As Color
    'Der aktuelle Wert als Object, damit
    'ihn jedes belibige Control darstellen kann
    Property Value() As Object
    'Liefert ein Control-Array zurück, dass dem umgebenden
    'Steuerelement hinzugefügt wird. Damit kann das Werte-Control
    'durchaus auch aus mehreren Controls bestehen
    ReadOnly Property Controls() As Control()
    Property Location() As Point
    Property Size() As Size
    Property Parent() As Control

    'Definiert die Größenreglementierung der Beschriftung
    'Positiver Wert: Mindesthöhe
    'Negativer Wert: Fixe Höhe
    Function MeasureHeight() As Integer


    'Wird durch Chance getriggert, während Modified und Modified Changed
    'durch den Entwickler ausschließlich über Modified getriggert wird!
    Property OnceModified() As Boolean
    Sub ResetOnceModified()

    Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Event Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    Event Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    Event OnceModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Sub OnValueChanged(ByVal e As System.EventArgs)
    Sub OnValidated(ByVal e As System.EventArgs)
    Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)
    Sub OnOnceModifiedChanged(ByVal e As System.EventArgs)
    Sub Invalidate()

End Interface

Public MustInherit Class ADCaptionForNullableValueControlTemplate
    Implements IADCaptionForNullableValueControl

    Protected WithEvents myControl As Control
    Protected Shared myInstanceCounter As Integer

    Sub New()
        'Wird in abgeleiteten Controls zur Namensbestimmung herangezoegen
        myInstanceCounter += 1
    End Sub

    Public Overridable Property BackColor() As System.Drawing.Color Implements IADCaptionForNullableValueControl.BackColor
        Get
            Return myControl.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            myControl.BackColor = Value
        End Set
    End Property

    Public Overridable Property Font() As System.Drawing.Font Implements IADCaptionForNullableValueControl.Font
        Get
            Return myControl.Font
        End Get
        Set(ByVal Value As System.Drawing.Font)
            myControl.Font = Value
        End Set
    End Property

    Public Overridable Property ForeColor() As System.Drawing.Color Implements IADCaptionForNullableValueControl.ForeColor
        Get
            Return myControl.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            myControl.ForeColor = Value
        End Set
    End Property

    Public Overridable Property Location() As System.Drawing.Point Implements IADCaptionForNullableValueControl.Location
        Get
            Return myControl.Location
        End Get
        Set(ByVal Value As System.Drawing.Point)
            myControl.Location = Value
        End Set
    End Property

    Public Overridable Property Size() As System.Drawing.Size Implements IADCaptionForNullableValueControl.Size
        Get
            Return myControl.Size
        End Get
        Set(ByVal Value As System.Drawing.Size)
            myControl.Size = Value
        End Set
    End Property

    Public Overridable Property Text() As String Implements IADCaptionForNullableValueControl.Text
        Get
            Return myControl.Text
        End Get
        Set(ByVal Value As String)
            myControl.Text = Value
        End Set
    End Property

    Public Overridable ReadOnly Property Controls() As System.Windows.Forms.Control() Implements IADCaptionForNullableValueControl.Controls
        Get
            Dim locControl(0) As Control
            locControl(0) = myControl
            Return locControl
        End Get
    End Property

    Public Overridable Function MeasureHeight() As Integer Implements IADCaptionForNullableValueControl.MeasureHeight
        Return 0
    End Function

    Public MustOverride Property Alignment() As System.Drawing.ContentAlignment Implements IADCaptionForNullableValueControl.Alignment
    Public MustOverride Property BorderStyle() As System.Windows.Forms.BorderStyle Implements IADCaptionForNullableValueControl.BorderStyle

    Public Property Parent() As System.Windows.Forms.Control Implements IADCaptionForNullableValueControl.Parent
        Get
            Return myControl.Parent
        End Get
        Set(ByVal value As System.Windows.Forms.Control)
            myControl.Parent = value
        End Set
    End Property

    Public Sub Invalidate() Implements IADCaptionForNullableValueControl.Invalidate
        myControl.Invalidate()
    End Sub
End Class

Public MustInherit Class ADEditableValueForNullableValueControlTemplate(Of ValType As IComparable)
    Implements IADEditableValueForNullableValueControl

    Protected myControl As Control
    Protected myValue As ADDBNullable(Of ValType)
    Protected myAssignedValue As ADDBNullable(Of ValType)
    Protected Shared myInstanceCounter As Integer
    Protected myOnceModified As Boolean

    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.ValueChanged
    Public Event Validated(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.Validated
    Public Event Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Implements IADEditableValueForNullableValueControl.Validating
    Public Event OnceModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.OnceModifiedChanged

    Sub New()
        'Alte Überlegung
        myInstanceCounter += 1
    End Sub

    Public Overridable Property BackColor() As System.Drawing.Color Implements IADEditableValueForNullableValueControl.BackColor
        Get
            Return myControl.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            myControl.BackColor = Value
        End Set
    End Property

    Public Overridable Property Font() As System.Drawing.Font Implements IADEditableValueForNullableValueControl.Font
        Get
            Return myControl.Font
        End Get
        Set(ByVal Value As System.Drawing.Font)
            myControl.Font = Value
        End Set
    End Property

    Public Overridable Property ForeColor() As System.Drawing.Color Implements IADEditableValueForNullableValueControl.ForeColor
        Get
            Return myControl.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            myControl.ForeColor = Value
        End Set
    End Property

    Public Overridable Property Location() As System.Drawing.Point Implements IADEditableValueForNullableValueControl.Location
        Get
            Return myControl.Location
        End Get
        Set(ByVal Value As System.Drawing.Point)
            myControl.Location = Value
        End Set
    End Property

    Public Overridable Property Size() As System.Drawing.Size Implements IADEditableValueForNullableValueControl.Size
        Get
            Return myControl.Size
        End Get
        Set(ByVal Value As System.Drawing.Size)
            myControl.Size = Value
        End Set
    End Property

    Public Overridable Property OnceModified() As Boolean Implements IADEditableValueForNullableValueControl.OnceModified
        Get
            Return myOnceModified
        End Get
        Set(ByVal Value As Boolean)
            If Value <> myOnceModified And Value = True Then
                OnOnceModifiedChanged(EventArgs.Empty)
            End If
            myOnceModified = Value
        End Set
    End Property

    Public MustOverride Property Value() As Object Implements IADEditableValueForNullableValueControl.Value

    Public Overridable ReadOnly Property Controls() As System.Windows.Forms.Control() Implements IADEditableValueForNullableValueControl.Controls
        Get
            Dim locControl(0) As Control
            locControl(0) = myControl
            Return locControl
        End Get
    End Property

    'Bestimmt die Höhe eines Controls
    'negativer Wert: Fixe Höhe
    'positivert Wert: Mindesthöhe
    '0: keine Festlegung
    Public Overridable Function MeasureHeight() As Integer Implements IADEditableValueForNullableValueControl.MeasureHeight
        Return 0
    End Function

    Public Overridable Sub OnValueChanged(ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.OnValueChanged
        RaiseEvent ValueChanged(Me, e)
        OnceModified = OnceModified Or True
    End Sub

    Public Overridable Sub OnValidated(ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.OnValidated
        RaiseEvent Validated(Me, e)
    End Sub

    Public Overridable Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs) Implements IADEditableValueForNullableValueControl.OnValidating
        RaiseEvent Validating(Me, e)
    End Sub

    Public Overridable Sub OnOnceModifiedChanged(ByVal e As System.EventArgs) Implements IADEditableValueForNullableValueControl.OnOnceModifiedChanged
        RaiseEvent OnceModifiedChanged(Me, e)
    End Sub

    Public Overridable Sub ResetOnceModified() Implements IADEditableValueForNullableValueControl.ResetOnceModified
        'Löst kein Ereignis aus! Sie können aber OnceModified überschreiben,
        'falls Sie dieses Ereignis dennoch in einen Event umwandeln möchten
        OnceModified = False
    End Sub

    Public Property Parent() As System.Windows.Forms.Control Implements IADEditableValueForNullableValueControl.Parent
        Get
            Return myControl.Parent
        End Get
        Set(ByVal value As System.Windows.Forms.Control)
            myControl.Parent = value
        End Set
    End Property

    Public Sub Invalidate() Implements IADEditableValueForNullableValueControl.Invalidate
        myControl.Invalidate()
    End Sub
End Class
