Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections

Friend Class ADCheckBoxedValueForNullableValueControl
    Inherits ADEditableValueForNullableValueControlTemplate(Of Boolean)

    Protected WithEvents myCheckBox As CheckBox

    Sub New()
        MyBase.New()
        myCheckBox = New CheckBox
        myControl = myCheckBox
        myControl.Name = "ADCheckBoxedValueForUVTControl" & myInstanceCounter
        myCheckBox.ThreeState = True
        myCheckBox.CheckState = CheckState.Indeterminate
        myCheckBox.Text = ""
        myCheckBox.BackColor = BackColor
        PaddingToCaption = 0
        CheckAlignment = ContentAlignment.MiddleCenter
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

    Public Property PaddingToCaption() As Integer
        Get
            Return myCheckBox.Padding.Left
        End Get
        Set(ByVal value As Integer)
            myCheckBox.Padding = New System.Windows.Forms.Padding(value, _
                                    myCheckBox.Padding.Top, _
                                    myCheckBox.Padding.Right, _
                                    myCheckBox.Padding.Bottom)
        End Set
    End Property

    Public Property CheckAlignment() As ContentAlignment
        Get
            Return myCheckBox.CheckAlign
        End Get
        Set(ByVal value As ContentAlignment)
            myCheckBox.CheckAlign = value
        End Set
    End Property

    Public Overrides Property Value() As Object
        Get
            If myCheckBox.CheckState = CheckState.Indeterminate Then
                Return Nothing
            End If
            Return myCheckBox.Checked
        End Get
        Set(ByVal Value As Object)
            Dim locTOB As ADDBNullable(Of Boolean) = CType(Value, ADDBNullable(Of Boolean))
            If Not locTOB.HasValue Then
                myCheckBox.CheckState = CheckState.Indeterminate
            Else
                If CBool(CType(Value, ADDBNullable(Of Boolean)).Value) Then
                    myCheckBox.CheckState = CheckState.Checked
                Else
                    myCheckBox.CheckState = CheckState.Unchecked
                End If
            End If
        End Set
    End Property

    Private Sub myComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myCheckBox.CheckedChanged
        OnValueChanged(e)
    End Sub
End Class
