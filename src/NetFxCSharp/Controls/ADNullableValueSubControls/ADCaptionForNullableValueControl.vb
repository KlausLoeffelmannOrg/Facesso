Imports System.Collections.Specialized
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text

Friend Class ADCaptionForNullableValueControl
    Inherits ADCaptionForNullableValueControlTemplate

    'Um die Mindesthöhe einer Zeile zu lesen, benötigen wir die Größe
    'des verwendeten Fonts, so wie ihn das Control intern selbst misst.
    'Da "FontHeight" protected ist, kommen wir da so nicht dran -
    'bevor wir es selber programmieren, legen wir die Eigenschaft einfach frei;
    'dazu definieren wir eine neue Labelklasse basierend auf dem alten Label-Control
    Sub New()
        myControl = New ADLabelExInternal
        myControl.Name = "ADLabelExInternal" & myInstanceCounter
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
        'Nur eine Zeile für die Fontgröße!
        'Mit ein bisschen Abstand oben und unten (+3 Pixel)
        Return DirectCast(myControl, ADLabelExInternal).FontHeightInternal + 6
    End Function

    Public Overrides Property Alignment() As System.Drawing.ContentAlignment
        Get
            Return DirectCast(myControl, ADLabelExInternal).TextAlign
        End Get
        Set(ByVal Value As System.Drawing.ContentAlignment)
            DirectCast(myControl, ADLabelExInternal).TextAlign = Value
        End Set
    End Property

    Public Overrides Property BorderStyle() As BorderStyle
        Get
            Return DirectCast(myControl, ADLabelExInternal).BorderStyle
        End Get
        Set(ByVal Value As BorderStyle)
            DirectCast(myControl, ADLabelExInternal).BorderStyle = Value
        End Set
    End Property
End Class
