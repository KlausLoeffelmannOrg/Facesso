using System.Security.Cryptography;

namespace ActiveDev
{

    public class ADCryptedPassword
    {

        private const int SaltLength = 4;
        private byte[] myCryptedPassword;

        public ADCryptedPassword(string UncryptedPassword)
        {

            byte[] UnsaltedPassword = CreatePasswordHash(UncryptedPassword);

            // Zufälligen Salzwert generieren.
            var SaltValue = new byte[4];
            var Rng = new RNGCryptoServiceProvider();
            Rng.GetBytes(SaltValue);

            // Salzwert-Hash generieren
            myCryptedPassword = CreateSaltedPassword(SaltValue, UnsaltedPassword);

        }

        public ADCryptedPassword(byte[] CryptedPassword)
        {
            myCryptedPassword = CryptedPassword;
        }

        // Diese Funktion liefert einen Passwort-Hash zurück, 
        // der nicht salzwertbasierend ist.
        private byte[] CreatePasswordHash(string password)
        {
            var Sha1 = new SHA1Managed();
            return Sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        // Diese Funktion übernimmt einnen Passwort-Hash, und
        // "salzt" ihn mit einem angegebenen Salzwert.
        private byte[] CreateSaltedPassword(byte[] saltValue, byte[] unsaltedPassword)
        {
            // Salzwert zum Hash addieren.
            var RawSalted = new byte[(unsaltedPassword.Length + saltValue.Length)];
            unsaltedPassword.CopyTo(RawSalted, 0);
            saltValue.CopyTo(RawSalted, unsaltedPassword.Length);

            // Saltzwert-Hash erstellen.
            var Sha1 = new SHA1Managed();
            byte[] SaltedPassword = Sha1.ComputeHash(RawSalted);

            // Salzwert zum Saltwert-Hash addieren.
            var DbPassword = new byte[(SaltedPassword.Length + saltValue.Length)];
            SaltedPassword.CopyTo(DbPassword, 0);
            saltValue.CopyTo(DbPassword, SaltedPassword.Length);

            return DbPassword;
        }

        // Diese Funktion vergleicht ein gehashtes Passwort mit
        // einem salzwertbasierendem Passwort aus der Datenbank.
        // Falls der Vergleich zutraf, wird True zurückgeliefert.
        private bool CompareToUncryptedPassword(string UncryptedPassword)
        {
            // Salzwert vom salzwertbasierten Hash abziehen.
            var SaltValue = new byte[4];
            int SaltOffset = myCryptedPassword.Length - SaltLength;
            int i;
            for (i = 0; i <= SaltLength - 1; i++)
                SaltValue[i] = myCryptedPassword[SaltOffset + i];

            // Das vom Benutzer eingegebene Passwort zum salzbasierten Passwort
            // konvertieren. Dazu wird der Salzwert aus dem Datenbanksatz verwendet.
            byte[] HashedPassword = CreatePasswordHash(UncryptedPassword);
            byte[] SaltedPassword = CreateSaltedPassword(SaltValue, HashedPassword);

            // Zwei salzwertbasierte Hashes miteinander vergleichen.
            // Falls der Vergleich zutraf, war die Authentifizierung erfolgreich.
            return CompareByteArray(myCryptedPassword, SaltedPassword);
        }

        // Diese Hilfsfunktion vergleicht zwei Byte-Arrays, und sie liefert
        // True zurück, wenn die Byteserien übereinstimmten.
        private bool CompareByteArray(byte[] arrayA, byte[] arrayB)
        {
            // Sicherstellen, dass beide Arrays gleich groß sind.
            if (arrayA.Length != arrayB.Length)
                return false;

            // Jedes Byte der beiden Arrays miteinander vergleichen.
            int i;
            var loopTo = arrayA.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (!arrayA[i].Equals(arrayB[i]))
                    return false;
            }

            // Beide Tests waren erfolgreich, die Arrays stimmen überein.
            return true;
        }

        public static bool operator ==(ADCryptedPassword cryptedPassword, string uncryptedPassword)
        {
            return cryptedPassword.CompareToUncryptedPassword(uncryptedPassword);
        }

        public static bool operator !=(ADCryptedPassword cryptedPassword, string uncryptedPassword)
        {
            return !cryptedPassword.CompareToUncryptedPassword(uncryptedPassword);
        }

        public byte[] CryptedPassword
        {
            get
            {
                return myCryptedPassword;
            }
        }

    }
}