Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization

Public Class ADNullableDoubleBox
    Inherits ADNullableValueControlTemplate(Of Double)

    Protected myReturnNullOnEmptyString As Boolean
    Protected myAssignFormatString As String
    Protected myDisplayCustomFormatString As String
    Protected myDisplayFormat As ADUVNumFormat
    Protected myPreferredDisplayFormat As ADUVNumFormat
    Protected myCurrencyText As String
    Protected myDecimalPlaces As Integer
    Protected myHasGroupSeperator As Boolean
    Protected myFormularText As String
    Protected myMaxValue As Double
    Protected myMinValue As Double
    Protected myExpressionError As String
    Protected myValueTooHighError As String
    Protected myValueTooLowError As String
    Protected Shared mySharedDefaultExpressionError As String
    Protected Shared mySharedDefaultTooHighError As String
    Protected Shared mySharedDefaultTooLowError As String

    Shared Sub New()
        Dim locCi As CultureInfo
        locCi = CultureInfo.CurrentCulture
        If locCi.Name.StartsWith("de") Then
            mySharedDefaultExpressionError = "Formelfehler|Der eingegebene Ausdruck konnte auf Grund eines Syntaxfehlers nicht ausgewertet werden." + vbNewLine + "Vielleicht fehlt eine Klammer oder sind doppelte Rechenzeichen in der Formel vorhanden."
            mySharedDefaultTooHighError = "Eingabefehler|Der eingegebe Wert ist zu hoch. Bitte überprüfen Sie den Wert."
            mySharedDefaultTooLowError = "Eingabefehler|Der eingegebene Wert ist zu niedrig. Bitte überprüfen Sie den Wert."
        Else
            mySharedDefaultExpressionError = "Error in formular|The expression you have entered caused a syntax error. Maybe a parenthesis is missing or the formular contains mistyped operators."
            mySharedDefaultTooHighError = "Input error|The value you have entered is too high. Please check the value."
            mySharedDefaultTooLowError = "Input error|The value you have entered is too low. Please check the value."
        End If
    End Sub

    Sub New()
        MyBase.New()

        Dim locNullable As New ADDBNullable(Of Double)

        ConsiderFixedSize = True
        NullString = "* --- *"
        Value = locNullable
        myAssignFormatString = "#,##0.###############"
        myDisplayFormat = ADUVNumFormat.UseProperties
        myPreferredDisplayFormat = ADUVNumFormat.UseProperties
        myDisplayCustomFormatString = "#,##0.00 €"
        myCurrencyText = ""
        myDecimalPlaces = -5
        myHasGroupSeperator = True
        myFormularText = ""
        myMaxValue = 0
        myMinValue = 0
        myExpressionError = mySharedDefaultExpressionError
        myValueTooHighError = mySharedDefaultTooHighError
        myValueTooLowError = mySharedDefaultTooLowError
    End Sub

    Protected Overrides Sub CreateControls()
        Me.EditableValueControl = New ADEditableValueForNullableValueControl
        Me.CaptionControl = New ADCaptionForNullableValueControl
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das Format des Zahlenwertes bei der Zuweisung durch die Value-Eigenschaft.", _
                   "Sets or gets the format of the number value which results out of the value property assignment.")> _
    Public Property AssignFormatString() As String
        Get
            Return myAssignFormatString
        End Get
        Set(ByVal Value As String)
            myAssignFormatString = Value
        End Set
    End Property

    Public Function ShouldSerializeAssignFormatString() As Boolean
        Return Not (AssignFormatString = "#,##0.###############")
    End Function

    Public Sub ResetAssignFormatString()
        AssignFormatString = "#,##0.###############"
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", _
                   "Gets or sets the format, with which the value is formatted, when the control looses its focus.")> _
    Public Property DisplayFormat() As ADUVNumFormat
        Get
            Return myDisplayFormat
        End Get
        Set(ByVal Value As ADUVNumFormat)
            myDisplayFormat = Value
        End Set
    End Property

    Public Function ShouldSerializeDisplayFormat() As Boolean
        Return Not (DisplayFormat = ADUVNumFormat.UseProperties)
    End Function

    Public Sub ResetDisplayFormat()
        DisplayFormat = ADUVNumFormat.UseProperties
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
    ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Ermittelt den DisplayFormatString.", _
                   "Gets the DisplayFormatString.")> _
    Public ReadOnly Property DisplayFormatString() As String
        Get
            If DisplayFormat = ADUVNumFormat.UseCustomString Then
                Return DisplayCustomFormatString
            Else

                Dim locDFS As String

                If myHasGroupSeperator Then
                    locDFS = "#,##0"
                Else
                    locDFS = "###0"
                End If

                If myDecimalPlaces > 0 Then
                    locDFS &= "." & New String("0"c, myDecimalPlaces)
                ElseIf myDecimalPlaces < 0 Then
                    locDFS &= "." & New String("#"c, myDecimalPlaces * -1)
                End If
                Return locDFS & CurrencyText
            End If
        End Get
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", _
                   "Gets or sets the custom format, with which the value is formatted, when the control looses its focus.")> _
    Public Property DisplayCustomFormatString() As String
        Get
            Return myDisplayCustomFormatString
        End Get
        Set(ByVal Value As String)
            If (Value = "") Or (Value Is Nothing) Then
                DisplayFormat = myPreferredDisplayFormat
                Value = ""
            Else
                myPreferredDisplayFormat = DisplayFormat
                DisplayFormat = ADUVNumFormat.UseCustomString
            End If
            myDisplayCustomFormatString = Value
        End Set
    End Property

    Public Function ShouldSerializeDisplayCustomFormatString() As Boolean
        Return Not (DisplayCustomFormatString = "#,##0.00 €")
    End Function

    Public Sub ResetDisplayCustomFormatString()
        DisplayCustomFormatString = "#,##0.00 €"
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt das/den Währungssymbol/-text.", _
                   "Gets or sets the the currency symbol/text.")> _
    Public Property CurrencyText() As String
        Get
            Return myCurrencyText
        End Get
        Set(ByVal Value As String)
            myCurrencyText = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt die Anzahl der dargestellten Dezimalstellen. Ein negativer Wert bestimmt die Anzahl möglicher Nachkommastellen. Ein positiver Wert erzwingt das Auffüllen mit endenden Nullen.", _
                   "Gets or sets the number of decimal places to be shown. A negative Value sets the number of maximal possible digits to be shown. A positive value forces the filling up with zeros."), _
     DefaultValue(-5)> _
    Public Property DecimalPlaces() As Integer
        Get
            Return myDecimalPlaces
        End Get
        Set(ByVal Value As Integer)
            If Value > 50 Or Value < -50 Then
                Dim up As New ArgumentOutOfRangeException("Value", "Der Wert, der die Anzahl der Dezimalstellen beschreibt, darf sich zwischen 0 und 30 befinden!")
                Throw up
            End If
            myDecimalPlaces = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", _
                   "Gets or sets, wether digits before the decimal seperator should be grouped."), _
     DefaultValue(True)> _
    Public Property HasGroupSeperator() As Boolean
        Get
            Return myHasGroupSeperator
        End Get
        Set(ByVal Value As Boolean)
            myHasGroupSeperator = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", _
                   "Gets or sets, wether digits before the decimal seperator should be grouped.")> _
    Public Property FormularText() As String
        Get
            Return myFormularText
        End Get
        Set(ByVal Value As String)
            myFormularText = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", _
                   "Gets or sets the custom format, with which the value is formatted, when the control looses its focus."), _
     DefaultValue(0D)> _
    Public Property MaxValue() As Double
        Get
            Return myMaxValue
        End Get
        Set(ByVal Value As Double)
            myMaxValue = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", _
                   "Gets or sets the custom format, with which the value is formatted, when the control looses its focus."), _
     DefaultValue(0D)> _
    Public Property MinValue() As Double
        Get
            Return myMinValue
        End Get
        Set(ByVal Value As Double)
            myMinValue = Value
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

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", _
                   "Gets or sets, wether digits before the decimal seperator should be grouped.")> _
    Public Property ExpressionErrorText() As String
        Get
            Return myExpressionError
        End Get
        Set(ByVal Value As String)
            myExpressionError = Value
        End Set
    End Property

    Public Function ShouldSerializeExpressionErrorText() As Boolean
        Return Not (ExpressionErrorText = mySharedDefaultExpressionError)
    End Function

    Public Sub ResetExpressionErrorText()
        ExpressionErrorText = mySharedDefaultExpressionError
    End Sub


    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", _
               "Gets or sets, wether digits before the decimal seperator should be grouped.")> _
     Public Property ValueTooHighErrorText() As String
        Get
            Return myValueTooHighError
        End Get
        Set(ByVal Value As String)
            myValueTooHighError = Value
        End Set
    End Property

    Public Function ShouldSerializeValueTooHighErrorText() As Boolean
        Return Not (ValueTooHighErrorText = mySharedDefaultTooHighError)
    End Function

    Public Sub ResetValueTooHighErrorText()
        ValueTooHighErrorText = mySharedDefaultTooHighError
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", _
                   "Gets or sets, wether digits before the decimal seperator should be grouped.")> _
    Public Property ValueTooLowErrorText() As String
        Get
            Return myValueTooLowError
        End Get
        Set(ByVal Value As String)
            myValueTooLowError = Value
        End Set
    End Property

    Public Function ShouldSerializeValueTooLowErrorText() As Boolean
        Return Not (ValueTooLowErrorText = mySharedDefaultTooLowError)
    End Function

    Public Sub ResetValueTooLowErrorText()
        ValueTooLowErrorText = mySharedDefaultTooLowError
    End Sub

    Protected Overrides Function ToObjectForEditing(ByVal Value As IADDBNullableValue) As Object
        If Not Value.HasValue Then
            Return ""
        End If
        Return String.Format("{0:" + AssignFormatString + "}", Value.Value)
    End Function

    Protected Overrides Function ToObjectForDisplaying(ByVal Value As IADDBNullableValue, ByVal ForSetValue As Boolean) As Object
        If Not Value.HasValue Then
            Return NullString
        Else
            Return String.Format("{0:" + DisplayFormatString + "}", Value.Value)
        End If
    End Function

    Protected Overrides Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of Double)
        If [Object].ToString = "" Or [Object] Is Nothing Then
            Return Nothing
        End If
        Dim locFormParse As New ADFormularParser([Object].ToString)
        Return locFormParse.Result
    End Function

    Protected Overrides Sub OnValidating(ByVal e As CancelEventArgs)

        Dim locMessageString As String = Nothing

        Try
            myObjectForEditing = myValueControl.Value
            myValue = ToNullableValue(myObjectForEditing)
            'Nur auf Umwandlungsmöglichkeit testen:
        Catch synEx As SyntaxErrorException
            locMessageString = mySharedDefaultExpressionError

        Catch ex As Exception

            If FireExceptionOnFailedValidation Then
                Dim up As New InvalidCastException("Die Eingabe konnte nicht in den Zieltyp umgewandelt werden.")
                Throw up
            Else
                If FailedValidationErrorMessage Is Nothing Or FailedValidationErrorMessage = "" Then
                    locMessageString = mySharedFailedValidationErrorDefaultMessage
                Else
                    locMessageString = FailedValidationErrorMessage
                End If
            End If
        End Try

        If locMessageString <> "" Then
            'Auseinanderdröseln und als Messagebox ausgeben
            Dim locStringArray As String() = locMessageString.Split(New Char() {"|"c})
            Try
                MessageBox.Show(locStringArray(1), locStringArray(0), MessageBoxButtons.OK, _
                                 MessageBoxIcon.Error)
            Catch ex As Exception
                Dim locCi As CultureInfo
                Dim locError As String
                locCi = CultureInfo.CurrentCulture
                If locCi.Name.StartsWith("de") Then
                    locError = "Eine vordefinierte Fehlermeldung sollte ausgegeben werden, allerdings entsprach der Fehlermeldungstext nicht dem korrekten Format. Möglicherweise fehlt das Pipe-Zeichen (|)."
                Else
                    locError = "A predefined error message was supposed to be shown, but the message format didn't match the correct format. Probebly the pipe sign (|) is missing."
                End If
                locError += vbNewLine + vbNewLine
                locError += "Error causing control: " + Me.Name + vbNewLine
                locError += "Error caused while validating."
                Dim up As New SyntaxErrorException(locError)
                Throw up
            End Try
            e.Cancel = True
        End If
    End Sub

End Class

Public Enum ADUVNumFormat
    UseProperties
    UseCustomString
End Enum
