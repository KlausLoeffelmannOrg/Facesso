''' <summary>
''' Hält die Schichteinstellungen (Schichten, Alternierende Schritte, etc.) für Auswertungen
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class ShiftParameters

    Private myConsiderShift1 As Boolean
    Private myConsiderShift2 As Boolean
    Private myConsiderShift3 As Boolean
    Private myConsiderShift4 As Boolean
    Private myAlternateShifts As Boolean
    Private myDaysAfterToAlternate As Integer
    Private myAlternatingFirstShift As Integer
    Private myAlternatingSecondShift As Integer

    Sub New()
        MyBase.New()

        'Kritische Default-Werte füllen (können bei der UI-Befüllung in die Hose gehen)
        myAlternateShifts = False
        myAlternatingFirstShift = 1
        myAlternatingSecondShift = 2
        myDaysAfterToAlternate = 7
    End Sub

    Sub New(ByVal CShift1 As Boolean, ByVal CShift2 As Boolean, ByVal CShift3 As Boolean, ByVal CShift4 As Boolean, _
            ByVal AlternateShifts As Boolean, ByVal DaysAfterToAlternate As Integer, _
            ByVal AlternatingFirstShift As Integer, ByVal AlternatingSecondShift As Integer)
        myConsiderShift1 = CShift1
        myConsiderShift2 = CShift2
        myConsiderShift3 = CShift3
        myConsiderShift4 = CShift4
        myAlternateShifts = AlternateShifts
        myDaysAfterToAlternate = DaysAfterToAlternate
        myAlternatingFirstShift = AlternatingFirstShift
        myAlternatingSecondShift = AlternatingSecondShift
    End Sub

    Public Property ConsiderShift1() As Boolean
        Get
            Return myConsiderShift1
        End Get
        Set(ByVal value As Boolean)
            myConsiderShift1 = value
        End Set
    End Property

    Public Property ConsiderShift2() As Boolean
        Get
            Return myConsiderShift2
        End Get
        Set(ByVal value As Boolean)
            myConsiderShift2 = value
        End Set
    End Property

    Public Property ConsiderShift3() As Boolean
        Get
            Return myConsiderShift3
        End Get
        Set(ByVal value As Boolean)
            myConsiderShift3 = value
        End Set
    End Property

    Public Property ConsiderShift4() As Boolean
        Get
            Return myConsiderShift4
        End Get
        Set(ByVal value As Boolean)
            myConsiderShift4 = value
        End Set
    End Property

    Public Property AlternateShifts() As Boolean
        Get
            Return myAlternateShifts
        End Get
        Set(ByVal value As Boolean)
            myAlternateShifts = value
        End Set
    End Property

    Public Property DaysAfterToAlternate() As Integer
        Get
            Return myDaysAfterToAlternate
        End Get
        Set(ByVal value As Integer)
            myDaysAfterToAlternate = value
        End Set
    End Property

    Public Property AlternatingFirstShift() As Integer
        Get
            Return myAlternatingFirstShift
        End Get
        Set(ByVal value As Integer)
            myAlternatingFirstShift = value
        End Set
    End Property

    Public Property AlternatingSecondShift() As Integer
        Get
            Return myAlternatingSecondShift
        End Get
        Set(ByVal value As Integer)
            myAlternatingSecondShift = value
        End Set
    End Property

    Public Overrides Function ToString() As String

        If AlternateShifts Then
            Return "Wechselschicht zwischen Schicht " & AlternatingFirstShift & " und Schicht " & AlternatingSecondShift & " alle " & DaysAfterToAlternate & " Tage."
        End If

        Dim locShiftCol As New ArrayList
        If ConsiderShift1 Then
            locShiftCol.Add(1)
        End If
        If ConsiderShift2 Then
            locShiftCol.Add(2)
        End If
        If ConsiderShift3 Then
            locShiftCol.Add(3)
        End If

        Dim locRetString As String = "Schicht "
        For c As Integer = 0 To locShiftCol.Count - 1
            locRetString &= locShiftCol(c).ToString
            If c < (locShiftCol.Count - 2) Then
                locRetString &= ", "
            End If
            If c = (locShiftCol.Count - 2) And locShiftCol.Count > 1 Then
                locRetString &= " und "
            End If
        Next
        Return locRetString
    End Function
End Class
