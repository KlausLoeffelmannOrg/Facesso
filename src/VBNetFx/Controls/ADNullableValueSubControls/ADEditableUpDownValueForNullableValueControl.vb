Imports System.Windows.Forms

Friend Class ADEditableUpDownValueForNullableValueControl
    Inherits ADEditableValueForNullableValueControlTemplate(Of Integer)

    Protected WithEvents myNumericUpDown As NumericUpDown

    Sub New()
        MyBase.New()
        myNumericUpDown = New NumericUpDown
        myControl = myNumericUpDown
        myControl.Name = "ADVariantTextControl" & myInstanceCounter
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
            Return DirectCast(myControl, NumericUpDown).Text
        End Get
        Set(ByVal Value As Object)
            If Value Is Nothing Then
                DirectCast(myControl, NumericUpDown).Text = ""
            Else
                DirectCast(myControl, NumericUpDown).Text = Value.ToString()
            End If
        End Set
    End Property

    Private Sub myNumericUpDown_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myNumericUpDown.TextChanged
        OnValueChanged(e)
    End Sub

    Private Sub myNumericUpDown_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles myNumericUpDown.Validated
        OnValidated(e)
    End Sub

    Private Sub myNumericUpDown_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles myNumericUpDown.Validating
        OnValidating(e)
    End Sub
End Class
