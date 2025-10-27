Imports System.ComponentModel
Imports System.Globalization

Public Class ADNullableDateTimeBox
    Inherits ADNullableValueControlTemplate(Of DateTime)

    Protected myReturnNullOnEmptyString As Boolean
    Protected myAssignFormat As ADUVDateTimeFormat
    Protected myPreferredAssignFormat As ADUVDateTimeFormat
    Protected myAssignCustomFormatString As String
    Protected myDisplayFormat As ADUVDateTimeFormat
    Protected myPreferredDisplayFormat As ADUVDateTimeFormat
    Protected myDisplayCustomFormatString As String
    Protected myParseFormatStrings As String()
    Protected myPreferredParseFormatStrings As String()
    Protected myReferenceDate As Date

    Private Shared mySharedTimeParseFormatStrings As String()
    Private Shared mySharedDateParseFormatStrings As String()
    Private Shared mySharedCombinedParseFormatStrings As String()
    Private Shared mySharedAssignFormatStrings As String()
    Private Shared mySharedDisplayFormatStrings As String()

    Shared Sub New()
        Dim locCi As CultureInfo
        locCi = CultureInfo.CurrentCulture
        If locCi.Name.StartsWith("de") Then
            'Deutsches Format
            mySharedCombinedParseFormatStrings = New String() {"ddM", "ddMM", "ddMMyy", "ddMMyyyy", _
                                 "d.M.y", "dd.M.y", "d.MM.y", "d.M.yy", "dd.M.yy", "dd.MM.yy", "d.M.yyyy", _
                                 "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yyyy", "d,M,y", "dd,M,y", "d,MM,y", "d,M,yy", _
                                 "dd,M,yy", "dd,MM,yy", "d,M,yyyy", "dd,M,yyyy", "d,MM,yyyy", "dd,MM,yyyy", _
                                 "dddd, dd.MM.yyyy", _
                                 "dd.MM.yy HH:mm", "dd.MM.yyyy HH:mm", _
                                 "ddMMyy HHmm", "ddMMyyyy HHmm", _
                                 "dd.MM.yy HH:mm:ss", "dd.MM.yyyy HH:mm:ss", _
                                 "HH", "HHmm", "HHmmss", "H.m", "H.mm", "HH.m", "HH.mm", _
                                 "HH.mm.ss", "H:m", "H:mm", "HH:m", "HH:mm", "HH:mm:ss", _
                                 "H,m", "H,mm", "HH,m", "HH,mm", "HH,mm,ss"}

            mySharedDateParseFormatStrings = New String() {"ddM", "ddMM", "ddMMyy", "ddMMyyyy", _
                     "dddd, dd.MM.yyyy", _
                     "d.M.y", "dd.M.y", "d.MM.y", "d.M.yy", "dd.M.yy", "dd.MM.yy", "d.M.yyyy", _
                     "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yyyy", "d,M,y", "dd,M,y", "d,MM,y", "d,M,yy", _
                     "dd,M,yy", "dd,MM,yy", "d,M,yyyy", "dd,M,yyyy", "d,MM,yyyy", "dd,MM,yyyy"}

            mySharedTimeParseFormatStrings = New String() {"HH", "HHmm", "HHmmss", "H.m", "H.mm", "HH.m", "HH.mm", _
                    "HH.mm.ss", "H:m", "H:mm", "HH:m", "HH:mm", "HH:mm:ss", _
                    "H,m", "H,mm", "HH,m", "HH,mm", "HH,mm,ss"}

            mySharedDisplayFormatStrings = New String() {"HH:mm", _
                                                        "HH:mm:ss", _
                                                        "dd.MM.yy", _
                                                        "dddd, dd.MM.yyyy", _
                                                        "dd.MM.yy - HH:mm", _
                                                        "dddd, dd.MM.yyyy HH:mm:ss", _
                                                        "dddd, \der dd. MMM yyyy"}

            mySharedAssignFormatStrings = New String() {"HH:mm", _
                                                        "HH:mm:ss", _
                                                        "dd.MM.yy", _
                                                        "dd.MM.yyyy", _
                                                        "dd.MM.yy HH:mm", _
                                                        "dd.MM.yyyy HH:mm:ss", _
                                                        "dd.MM.yy HH:mm:ss"}
        End If
    End Sub

    Sub New()
        MyBase.New()

        Dim locNullable As New ADDBNullable(Of DateTime)

        ConsiderFixedSize = True
        NullString = "* --- *"
        Value = locNullable
        myAssignFormat = ADUVDateTimeFormat.ShortDate
        myDisplayFormat = ADUVDateTimeFormat.LongDate
        myPreferredAssignFormat = myAssignFormat
        myPreferredDisplayFormat = myDisplayFormat
        myAssignCustomFormatString = ""
        myDisplayCustomFormatString = ""
        myParseFormatStrings = Nothing
        myReferenceDate = DateTime.Now.Date
    End Sub

    Protected Overrides Sub CreateControls()
        Me.EditableValueControl = New ADEditableValueForNullableValueControl
        Me.CaptionControl = New ADCaptionForNullableValueControl
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das Format des Datumswertes bei der Zuweisung durch die Value-Eigenschaft.", _
                   "Sets or gets the format of the date value which results out of the value property assignment.")> _
    Public Property AssignFormat() As ADUVDateTimeFormat
        Get
            Return myAssignFormat
        End Get
        Set(ByVal Value As ADUVDateTimeFormat)
            myAssignFormat = Value
        End Set
    End Property

    Public Function ShouldSerializeAssignFormat() As Boolean
        Return Not (AssignFormat = ADUVDateTimeFormat.ShortDate)
    End Function

    Public Sub ResetAssignFormat()
        AssignFormat = ADUVDateTimeFormat.ShortDate
    End Sub

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Ermittelt den AssignFormatString.", _
                   "Gets the AssignFormatString.")> _
    Public ReadOnly Property AssignFormatString() As String
        Get
            If AssignFormat = ADUVDateTimeFormat.Custom Then
                Return AssignCustomFormatString
            Else
                Return mySharedAssignFormatStrings(AssignFormat)
            End If
        End Get
    End Property

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt den benutzerdefinierten AssignFormatString, der verwendet wird, wenn für AssignFormat 'Custom' eingestellt wurde.", _
                   "Gets or sets the custom AssignFormatString, which is used, when AssignFormat has been set to 'Custom'.")> _
    Public Property AssignCustomFormatString() As String
        Get
            Return myAssignCustomFormatString
        End Get
        Set(ByVal Value As String)
            If (Value = "") Or (Value Is Nothing) Then
                AssignFormat = myPreferredAssignFormat
                Value = ""
            Else
                myPreferredAssignFormat = AssignFormat
                AssignFormat = ADUVDateTimeFormat.Custom
            End If
            myAssignCustomFormatString = Value
        End Set
    End Property

    Public Function ShouldSerializeAssignCustomFormatString() As Boolean
        Return Not (AssignCustomFormatString = "")
    End Function

    Public Sub ResetAssignCustomFormatString()
        AssignCustomFormatString = ""
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt das Format, in dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", _
                   "Gets or sets the format, with which the value is formatted, when the control looses its focus.")> _
    Public Property DisplayFormat() As ADUVDateTimeFormat
        Get
            Return myDisplayFormat
        End Get
        Set(ByVal Value As ADUVDateTimeFormat)
            myDisplayFormat = Value
        End Set
    End Property

    Public Function ShouldSerializeDisplayFormat() As Boolean
        Return Not (DisplayFormat = ADUVDateTimeFormat.LongDate)
    End Function

    Public Sub ResetDisplayFormat()
        DisplayFormat = ADUVDateTimeFormat.LongDate
    End Sub

    <RefreshProperties(RefreshProperties.Repaint), _
    ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Ermittelt den DisplayFormatString.", _
                   "Gets the DisplayFormatString.")> _
    Public ReadOnly Property DisplayFormatString() As String
        Get
            If DisplayFormat = ADUVDateTimeFormat.Custom Then
                Return DisplayCustomFormatString
            Else
                Return mySharedDisplayFormatStrings(DisplayFormat)
            End If
        End Get
    End Property

    <RefreshProperties(RefreshProperties.Repaint), Category("Verhalten")> _
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
                DisplayFormat = ADUVDateTimeFormat.Custom
            End If
            myDisplayCustomFormatString = Value
        End Set
    End Property

    <RefreshProperties(RefreshProperties.Repaint), Category("Sonstiges"), Bindable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property DateTimeValue() As Object
        Get
            Return Me.Value.Value
        End Get
        Set(ByVal Value As Object)
            Me.Value = ADDBNullable.FromObject(Of DateTime)(Value)
        End Set
    End Property

    Public Function ShouldSerializeDisplayCustomFormatString() As Boolean
        Return Not (DisplayCustomFormatString = "")
    End Function

    Public Sub ResetDisplayCustomFormatString()
        DisplayCustomFormatString = ""
    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ReferenceDate() As Date
        Get
            Return myReferenceDate
        End Get
        Set(ByVal value As Date)
            myReferenceDate = value.Date
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Bestimmt oder ermittelt ein Array aus Strings, das die Formate festlegt, die beim Parsen und Konvertieren des eingegebenen Texts in den gewünschten Datums-/Zeittyp berücksichtigt werden.", _
                   "Sets or gets an array of strings, which determines the formats that are being used for parsing and converting the input string into the desired date/time type.")> _
    Public Property ParseFormatStrings() As String()
        Get
            If myParseFormatStrings Is Nothing Then
                If DateTimeType = ADDateTimeType.DateOnly Then
                    Return mySharedDateParseFormatStrings
                ElseIf DateTimeType = ADDateTimeType.TimeOnly Then
                    Return mySharedTimeParseFormatStrings
                Else
                    Return mySharedCombinedParseFormatStrings
                End If
            Else
                Return myParseFormatStrings
            End If
        End Get
        Set(ByVal Value As String())
            myParseFormatStrings = Value
        End Set
    End Property

    Public Function ShouldSerializeParseFormatStrings() As Boolean
        Return Not (myParseFormatStrings Is Nothing)
    End Function

    Public Sub ResetParseFormatStrings()
        myParseFormatStrings = Nothing
    End Sub

    <ADCategory("Verhalten", "Behaviour"), _
    ADDescription("Spiegelt den DateTimeType wieder, der sich durch AssignFormat ergibt. Nur lesen.", _
                   "Reflects the DateTimeType, which is determined through AssignFormat. Read only.")> _
    Public ReadOnly Property DateTimeType() As ADDateTimeType
        Get
            Select Case AssignFormat
                Case ADUVDateTimeFormat.CombinedLong, ADUVDateTimeFormat.CombinedShort, ADUVDateTimeFormat.Custom
                    Return ADDateTimeType.BothTimeAndDate
                Case ADUVDateTimeFormat.LongDate, ADUVDateTimeFormat.ShortDate
                    Return ADDateTimeType.DateOnly
                Case ADUVDateTimeFormat.LongTime, ADUVDateTimeFormat.ShortTime
                    Return ADDateTimeType.TimeOnly
            End Select
        End Get
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

    Protected Overrides Function ToObjectForEditing(ByVal Value As IADDBNullableValue) As Object
        If Not Value.HasValue Then
            myReferenceDate = Date.Now.Date
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

    Protected Overrides Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of DateTime)
        If [Object].ToString = "" Then
            Return Nothing
        End If
        Dim locDate As ADDBNullable(Of DateTime)
        locDate = New ADDBNullable(Of DateTime)(DateTime.ParseExact([Object].ToString, _
                                                    ParseFormatStrings, _
                                                    New DateTimeFormatInfo, _
                                                    DateTimeStyles.AllowWhiteSpaces))
        If DisplayFormat = ADUVDateTimeFormat.LongTime Or DisplayFormat = ADUVDateTimeFormat.ShortTime Then
            If locDate.HasValue Then
                locDate = ReferenceDate.Add(locDate.TypedValue.TimeOfDay)
            End If
        End If

        Return locDate
    End Function

    Protected Overrides Sub UpdateValue(ByVal Value As IADDBNullableValue)
        MyBase.UpdateValue(Value)
        If DisplayFormat = ADUVDateTimeFormat.LongTime Or DisplayFormat = ADUVDateTimeFormat.ShortTime Then
            If Value.HasValue Then
                myReferenceDate = DirectCast(Value, ADDBNullable(Of Date)).TypedValue.Date
            End If
        End If
    End Sub
End Class

Public Enum ADDateTimeType
    DateOnly
    TimeOnly
    BothTimeAndDate
End Enum

Public Enum ADUVDateTimeFormat
    ShortTime = 0
    LongTime = 1
    ShortDate = 2
    LongDate = 3
    CombinedShort = 4
    CombinedLong = 5
    Custom = 6
End Enum
