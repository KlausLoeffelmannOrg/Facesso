Imports System.Security.Cryptography

Public Class ADCryptedPassword

    Private Const SaltLength As Integer = 4
    Private myCryptedPassword As Byte()

    Sub New(ByVal UncryptedPassword As String)

        Dim UnsaltedPassword() As Byte = CreatePasswordHash(UncryptedPassword)

        ' Zufälligen Salzwert generieren.
        Dim SaltValue(SaltLength - 1) As Byte
        Dim Rng As New RNGCryptoServiceProvider
        Rng.GetBytes(SaltValue)

        ' Salzwert-Hash generieren
        myCryptedPassword = CreateSaltedPassword(SaltValue, UnsaltedPassword)

    End Sub

    Sub New(ByVal CryptedPassword As Byte())
        myCryptedPassword = CryptedPassword
    End Sub

    ' Diese Funktion liefert einen Passwort-Hash zurück, 
    ' der nicht salzwertbasierend ist.
    Private Function CreatePasswordHash(ByVal password As String) As Byte()
        Dim Sha1 As New SHA1Managed
        Return Sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
    End Function

    ' Diese Funktion übernimmt einnen Passwort-Hash, und
    ' "salzt" ihn mit einem angegebenen Salzwert.
    Private Function CreateSaltedPassword(ByVal saltValue As Byte(), ByVal unsaltedPassword() As Byte) As Byte()
        ' Salzwert zum Hash addieren.
        Dim RawSalted(unsaltedPassword.Length + saltValue.Length - 1) As Byte
        unsaltedPassword.CopyTo(RawSalted, 0)
        saltValue.CopyTo(RawSalted, unsaltedPassword.Length)

        'Saltzwert-Hash erstellen.
        Dim Sha1 As New SHA1Managed
        Dim SaltedPassword() As Byte = Sha1.ComputeHash(RawSalted)

        ' Salzwert zum Saltwert-Hash addieren.
        Dim DbPassword(SaltedPassword.Length + saltValue.Length - 1) As Byte
        SaltedPassword.CopyTo(DbPassword, 0)
        saltValue.CopyTo(DbPassword, SaltedPassword.Length)

        Return DbPassword
    End Function

    ' Diese Funktion vergleicht ein gehashtes Passwort mit
    ' einem salzwertbasierendem Passwort aus der Datenbank.
    ' Falls der Vergleich zutraf, wird True zurückgeliefert.
    Private Function CompareToUncryptedPassword(ByVal UncryptedPassword As String) As Boolean
        ' Salzwert vom salzwertbasierten Hash abziehen.
        Dim SaltValue(SaltLength - 1) As Byte
        Dim SaltOffset As Integer = myCryptedPassword.Length - SaltLength
        Dim i As Integer
        For i = 0 To SaltLength - 1
            SaltValue(i) = myCryptedPassword(SaltOffset + i)
        Next

        ' Das vom Benutzer eingegebene Passwort zum salzbasierten Passwort
        ' konvertieren. Dazu wird der Salzwert aus dem Datenbanksatz verwendet.
        Dim HashedPassword As Byte() = CreatePasswordHash(UncryptedPassword)
        Dim SaltedPassword As Byte() = CreateSaltedPassword(SaltValue, HashedPassword)

        ' Zwei salzwertbasierte Hashes miteinander vergleichen.
        ' Falls der Vergleich zutraf, war die Authentifizierung erfolgreich.
        Return CompareByteArray(myCryptedPassword, SaltedPassword)
    End Function

    ' Diese Hilfsfunktion vergleicht zwei Byte-Arrays, und sie liefert
    ' True zurück, wenn die Byteserien übereinstimmten.
    Private Function CompareByteArray(ByVal arrayA() As Byte, ByVal arrayB() As Byte) As Boolean
        ' Sicherstellen, dass beide Arrays gleich groß sind.
        If arrayA.Length <> arrayB.Length Then Return False

        ' Jedes Byte der beiden Arrays miteinander vergleichen.
        Dim i As Integer
        For i = 0 To arrayA.Length - 1
            If Not arrayA(i).Equals(arrayB(i)) Then Return False
        Next

        ' Beide Tests waren erfolgreich, die Arrays stimmen überein.
        Return True
    End Function

    Public Shared Operator =(ByVal cryptedPassword As ADCryptedPassword, ByVal uncryptedPassword As String) As Boolean
        Return cryptedPassword.CompareToUncryptedPassword(uncryptedPassword)
    End Operator

    Public Shared Operator <>(ByVal cryptedPassword As ADCryptedPassword, ByVal uncryptedPassword As String) As Boolean
        Return Not cryptedPassword.CompareToUncryptedPassword(uncryptedPassword)
    End Operator

    Public ReadOnly Property CryptedPassword() As Byte()
        Get
            Return myCryptedPassword
        End Get
    End Property

End Class
