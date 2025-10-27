Imports System.Security.Cryptography

''' <summary>
''' Modul, das Hilfsfunktionen zur Verfügung stellt, die im Rahmen von Kryptografie-Erfordersinnen verwendet werden.
''' </summary>
''' <remarks></remarks>
Public Module ADCryptography

    ''' <summary>
    ''' Erzeugt eine absolut zufällige GUID.
    ''' </summary>
    ''' <returns>GUID als native .NET-GUID-Struktur.</returns>
    ''' <remarks></remarks>
    Public Function GetRandomGUID() As Guid
        Dim locRandomBytes(15) As Byte
        Dim locRandom As New RNGCryptoServiceProvider()
        locRandom.GetBytes(locRandomBytes)

        Return New Guid(locRandomBytes)
    End Function

    ''' <summary>
    ''' Wandelt die einzelnen Wertigkeiten der Zeichen einer Zeichenkette in Byte-Werte um.
    ''' </summary>
    ''' <param name="text">Zeichenkette, deren einzelne Zeichenwertigkeiten (ASCII) 
    ''' ein Byte-Array umgewandelt werden.</param>
    ''' <returns>Byte-Array, das die Zeichenwertigkeiten enthält.</returns>
    ''' <remarks></remarks>
    Public Function ToByteArray(ByVal text As String) As Byte()
        Dim locByte(text.Length - 1) As Byte
        Dim locCount As Integer = 0
        For Each c As Char In text.ToCharArray
            locByte(locCount) = Convert.ToByte(c)
            locCount += 1
        Next
        Return locByte
    End Function

End Module
