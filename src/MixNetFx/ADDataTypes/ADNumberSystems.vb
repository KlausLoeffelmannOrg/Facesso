''' <summary>
''' Struktur dient zur Umrechnung von dezimalen Zahlen auf Basis von ULong (64-Bit unsigned) in
''' andere Zahlensysteme (zum Beispiel Hexadezimalsystem). Werte können zunächst die die verschiedenen 
''' Konstruktoren in dieser Struktur gespeichert, und dann durch ToString in eine entsprechende 
''' Darstellung des anderen Zahlensystems umgewandelt werden. Die Eigenschaft NumberSystem erlaubt 
''' das Ändern des Zahlensystems (also die durch ToString repräsentierten Werte) auch noch nach der 
''' Instanzierung. Mit der statischen Mehtode Parse können auch Darstellungen anderer Zahlensysteme 
''' wieder in das Dezimalsystem zurückübertragen werden; die dezimale Darstellung lässt sich mit der 
''' Value-Eigenschaft ermitteln.
''' </summary>
''' <remarks>WICHTIG: Durch die Basierung dieser Klasse auf ULong gilt diese Klasse nicht als CLS-Compliant, 
''' und daher sollten Funktionen, die auf dieser Klasse basieren, nicht nach außen sichtbar gemacht werden.</remarks>
<CLSCompliant(False)> _
Public Structure ADNumberSystems

    Private myUnderlyingValue As ULong
    Private myNumberSystem As Integer
    Private Shared myDigits As Char()

    Shared Sub New()
        myDigits = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, _
                               "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, _
                               "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, _
                               "X"c, "Y"c, "Z"c}
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Struktur und übergibt einen Integer-Datentyp (signed) als Initialwert. 
    ''' Als Zahlensystem wird durch diese Konstruktorüberladung das Hexadezimal-System verwendet.
    ''' </summary>
    ''' <param name="Value">Interger-Wert, der den Initialwert zur Verfügung stellt.</param>
    ''' <remarks></remarks>
    Sub New(ByVal Value As Integer)
        Me.New(CULng(Value), 16)
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Struktur und übergibt einen Long-Datentyp (signed) als Initialwert. 
    ''' Als Zahlensystem wird durch diese Konstruktorüberladung das Hexadezimal-System verwendet.
    ''' </summary>
    ''' <param name="Value">Interger-Wert, der den Initialwert zur Verfügung stellt.</param>
    ''' <remarks></remarks>
    Sub New(ByVal Value As ULong)
        Me.New(Value, 16)
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Struktur, und erlaubt die Bestimmung eines Initalwertes sowie 
    ''' das zuverwendende Zahlensystem (1-33).
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="NumberSystem"></param>
    ''' <remarks></remarks>
    Sub New(ByVal Value As ULong, ByVal NumberSystem As Integer)

        myUnderlyingValue = Value
        If NumberSystem < 2 OrElse NumberSystem > 33 Then
            Dim Up As Exception = New OverflowException _
                ("Kennziffer des Zahlensystems außerhalb des gültigen Bereichs!")
            'Kleiner Scherz für die Englisch sprechenden:
            Throw Up
        End If
        myNumberSystem = NumberSystem

    End Sub

    ''' <summary>
    ''' Ermittelt oder bestimmt die dezimale Darstellung des in dieser Struktur gespeicherten Werts.
    ''' </summary>
    ''' <value>Wert vom Typ ULong.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As ULong

        Get
            Return myUnderlyingValue
        End Get
        Set(ByVal Value As ULong)
            myUnderlyingValue = Value
        End Set

    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt das Zahlensystem (zum Beispiel 16 für Hexadezimal), das bei der Umwandlung 
    ''' des Wertes, den diese Struktur speichert, in eine Zeichenfolge maßgeblich ist.
    ''' </summary>
    ''' <value>Wert (größer 1 und kleiner 34), der das Zahlensystem bestimmt.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumberSystem() As Integer
        Get
            Return myNumberSystem
        End Get
        Set(ByVal Value As Integer)
            If Value < 2 OrElse Value > 33 Then
                Dim Up As Exception = New OverflowException _
                    ("Kennziffer des Zahlensystems außerhalb des gültigen Bereichs!")
                Throw Up
            End If
            myNumberSystem = Value
        End Set
    End Property

    ''' <summary>
    ''' Wandelt den Wert, den diese Struktur repräsentiert, in die entsprechende Darstellungsweise  
    ''' des Zahlensystems um, und liefert das Ergebnis als Zeichenfolge zurück.
    ''' </summary>
    ''' <returns>Zeichenfolge, die den Wert dieser Strukturinstanz auf Basis des durch die 
    ''' NumberSystem-Eigenschaft eingestellten Zahlensystems repräsentiert.</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String

        Dim locResult As String = ""
        Dim locValue As ULong = myUnderlyingValue

        Do
            Dim digit As Byte = CByte(locValue Mod NumberSystem)
            locResult = CStr(myDigits(digit)) & locResult
            locValue \= CULng(NumberSystem)
        Loop Until locValue = 0

        Return locResult

    End Function

    ''' <summary>
    ''' Wandelt den Wert, den diese Struktur repräsentiert, in die entsprechende Darstellungsweise  
    ''' des Zahlensystems um, und liefert das Ergebnis als Zeichenfolge zurück. 
    ''' Erlaubt zusätzlich das Auffüllen von Füllzeichen ('0') für Formatierungszwecke.
    ''' </summary>
    ''' <param name="MinChars">Bestimmt, wieviele Zeichen die Ergebniszeichenfolge umfassen soll. 
    ''' Fehlende Zeichen werden mit führenden '0'-Zeichen aufgefüllt.</param>
    ''' <returns>Zeichenfolge, die den Wert dieser Strukturinstanz auf Basis des durch die 
    ''' NumberSystem-Eigenschaft eingestellten Zahlensystems repräsentiert.</returns>
    ''' <remarks></remarks>
    Public Overloads Function ToString(ByVal MinChars As Integer) As String
        Dim locRetString As String = ToString()
        If locRetString.Length < MinChars Then
            locRetString = New String("0"c, MinChars - locRetString.Length) + locRetString
        End If
        Return locRetString
    End Function

    ''' <summary>
    ''' Wandelt eine Zeichenkette mit der Darstellung eines anderen Zahlensystems in einen 
    ''' Interwert (max. 64-Bit unsigned Integer) zurück.
    ''' </summary>
    ''' <param name="Value">Wert in der Darstellung des anderen Zahlensystems, 
    ''' der als Zeichenkette vorliegt.</param>
    ''' <param name="NumberSystem">Das Zahlensystem auf dem die Wertedarstellung basiert.</param>
    ''' <returns>Eine Instanz dieser Struktur mit dem ins Dezimalsystem zurückgerechneten Wert.</returns>
    ''' <remarks></remarks>
    Public Shared Function Parse(ByVal Value As String, ByVal NumberSystem As Integer) As ADNumberSystems

        'Hier wird der Value zusammengebaut
        Dim locValue As ULong

        For count As Integer = 0 To Value.Length - 1
            'Try
            'Aktuellen Zeichen im String, das verarbeitet wird
            Dim locTmpChar As String = Value.Substring(count, 1)

            'Binäresuche anwenden, um das Zeichen im Array zu finden und damit die Ziffernummer
            Dim locDigitValue As Integer = CInt(Array.BinarySearch(myDigits, CChar(locTmpChar)))

            'Prüfen, ob sich das Zeichen im Gültigkeitsbereich befindet
            If locDigitValue >= NumberSystem OrElse locDigitValue < 0 Then
                Dim Up As Exception = New FormatException _
                    ("Ziffer '" & locTmpChar & "' ist nicht Bestandteil des Zahlensystems!")
                Throw Up
            End If

            'Aus der gefundenen Ziffernummer die Potenzbilden, und zum Gesamtwert addieren
            locValue += CULng(Math.Pow(NumberSystem, Value.Length - count - 1) * locDigitValue)

            'Catch ex As Exception
            '    'Für den Fall, dass zwischendurch 'was schiefgeht
            '    Dim Up As Exception = New InvalidCastException _
            '        ("Ziffer des Zahlensystems außerhalb des gültigen Bereichs!")
            '    Throw Up
            'End Try

            'nächstes Zeichen verarbeiten
        Next

        Return New ADNumberSystems(locValue, NumberSystem)

    End Function
End Structure
