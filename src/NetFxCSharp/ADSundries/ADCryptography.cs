using System;
using System.Security.Cryptography;

namespace ActiveDev
{

    /// <summary>
/// Modul, das Hilfsfunktionen zur Verfügung stellt, die im Rahmen von Kryptografie-Erfordersinnen verwendet werden.
/// </summary>
/// <remarks></remarks>
    public static class ADCryptography
    {

        /// <summary>
    /// Erzeugt eine absolut zufällige GUID.
    /// </summary>
    /// <returns>GUID als native .NET-GUID-Struktur.</returns>
    /// <remarks></remarks>
        public static Guid GetRandomGUID()
        {
            var locRandomBytes = new byte[16];
            var locRandom = new RNGCryptoServiceProvider();
            locRandom.GetBytes(locRandomBytes);

            return new Guid(locRandomBytes);
        }

        /// <summary>
    /// Wandelt die einzelnen Wertigkeiten der Zeichen einer Zeichenkette in Byte-Werte um.
    /// </summary>
    /// <param name="text">Zeichenkette, deren einzelne Zeichenwertigkeiten (ASCII) 
    /// ein Byte-Array umgewandelt werden.</param>
    /// <returns>Byte-Array, das die Zeichenwertigkeiten enthält.</returns>
    /// <remarks></remarks>
        public static byte[] ToByteArray(string text)
        {
            var locByte = new byte[text.Length];
            int locCount = 0;
            foreach (char c in text.ToCharArray())
            {
                locByte[locCount] = Convert.ToByte(c);
                locCount += 1;
            }
            return locByte;
        }

    }
}