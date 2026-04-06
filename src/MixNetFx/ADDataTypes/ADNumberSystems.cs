using System;

namespace ActiveDev
{
    [CLSCompliant(false)]
    public struct ADNumberSystems
    {
        private ulong myUnderlyingValue;
        private int myNumberSystem;
        private static char[] myDigits;

        static ADNumberSystems()
        {
            myDigits = new[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            };
        }

        public ADNumberSystems(int value)
            : this(unchecked((ulong)value), 16)
        {
        }

        public ADNumberSystems(ulong value)
            : this(value, 16)
        {
        }

        public ADNumberSystems(ulong value, int numberSystem)
        {
            myUnderlyingValue = value;
            if (numberSystem < 2 || numberSystem > 33)
            {
                throw new OverflowException("Kennziffer des Zahlensystems ausserhalb des gueltigen Bereichs!");
            }

            myNumberSystem = numberSystem;
        }

        public ulong Value
        {
            get { return myUnderlyingValue; }
            set { myUnderlyingValue = value; }
        }

        public int NumberSystem
        {
            get { return myNumberSystem; }
            set
            {
                if (value < 2 || value > 33)
                {
                    throw new OverflowException("Kennziffer des Zahlensystems ausserhalb des gueltigen Bereichs!");
                }

                myNumberSystem = value;
            }
        }

        public override string ToString()
        {
            var locResult = string.Empty;
            var locValue = myUnderlyingValue;

            do
            {
                var digit = (byte)(locValue % (ulong)NumberSystem);
                locResult = myDigits[digit] + locResult;
                locValue /= (ulong)NumberSystem;
            }
            while (locValue != 0);

            return locResult;
        }

        public string ToString(int minChars)
        {
            var locRetString = ToString();
            if (locRetString.Length < minChars)
            {
                locRetString = new string('0', minChars - locRetString.Length) + locRetString;
            }

            return locRetString;
        }

        public static ADNumberSystems Parse(string value, int numberSystem)
        {
            ulong locValue = 0;

            for (var count = 0; count <= value.Length - 1; count++)
            {
                var locTmpChar = value.Substring(count, 1);
                var locDigitValue = Array.BinarySearch(myDigits, Convert.ToChar(locTmpChar));

                if (locDigitValue >= numberSystem || locDigitValue < 0)
                {
                    throw new FormatException("Ziffer '" + locTmpChar + "' ist nicht Bestandteil des Zahlensystems!");
                }

                locValue += (ulong)(Math.Pow(numberSystem, value.Length - count - 1) * locDigitValue);
            }

            return new ADNumberSystems(locValue, numberSystem);
        }
    }
}
