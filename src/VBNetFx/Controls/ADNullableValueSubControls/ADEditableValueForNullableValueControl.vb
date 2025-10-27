Imports System.Windows.Forms

Friend Class ADEditableValueForNullableValueControl
    Inherits ADEditableValueForNullableValueControlTemplate(Of String)

    Protected WithEvents myTextBox As TextBox

    Sub New()
        MyBase.New()
        myTextBox = New TextBox
        myControl = myTextBox
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
        If DirectCast(myControl, TextBox).Multiline Then
            Return Me.Font.Height
        Else
            Return (myControl.Height) * -1
        End If
    End Function

    Public Overridable Property Multiline() As Boolean
        Get
            Return DirectCast(myControl, TextBox).Multiline
        End Get
        Set(ByVal Value As Boolean)
            DirectCast(myControl, TextBox).Multiline = Value
        End Set
    End Property

    Public Overrides Property Value() As Object
        Get
            Return DirectCast(myControl, TextBox).Text
        End Get
        Set(ByVal Value As Object)
            If Value Is Nothing Then
                DirectCast(myControl, TextBox).Text = ""
            Else
                DirectCast(myControl, TextBox).Text = Value.ToString()
            End If
        End Set
    End Property

    Public Overridable Property ScrollBars() As ScrollBars
        Get
            Return DirectCast(myControl, TextBox).ScrollBars
        End Get
        Set(ByVal Value As ScrollBars)
            DirectCast(myControl, TextBox).ScrollBars = Value
        End Set
    End Property

    Public Overridable Property MaxLength() As Integer
        Get
            Return DirectCast(myControl, TextBox).MaxLength
        End Get
        Set(ByVal Value As Integer)
            DirectCast(myControl, TextBox).MaxLength = Value
        End Set
    End Property

    Public Overridable Property [Readonly]() As Boolean
        Get
            Return DirectCast(myControl, TextBox).ReadOnly
        End Get
        Set(ByVal value As Boolean)
            DirectCast(myControl, TextBox).ReadOnly = value
        End Set
    End Property

    Private Sub myTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTextBox.TextChanged
        OnValueChanged(e)
    End Sub

    Private Sub myTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTextBox.Validated
        OnValidated(e)
    End Sub

    Private Sub myTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles myTextBox.Validating
        OnValidating(e)
    End Sub
End Class
