namespace Facesso.Data
{
    public struct DegreeOfTime
    {
        private static double myDefaultFactor = 1;
        private static string myDefaultDimension = "%";
        private static byte myDefaultDecimalPlaces = 0;

        private double myValue;
        private byte myDecimalPlaces;
        private string myDimension;
        private double myFactor;

        public DegreeOfTime(double baseValue)
        {
            myValue = baseValue;
            myFactor = myDefaultFactor;
            myDecimalPlaces = myDefaultDecimalPlaces;
            myDimension = myDefaultDimension;
        }

        public DegreeOfTime(double baseValue, double factor)
        {
            myValue = baseValue;
            myFactor = factor;
            myDecimalPlaces = myDefaultDecimalPlaces;
            myDimension = myDefaultDimension;
        }

        public DegreeOfTime(double baseValue, double factor, byte decimalPlaces)
        {
            myValue = baseValue;
            myFactor = factor;
            myDecimalPlaces = decimalPlaces;
            myDimension = myDefaultDimension;
        }

        public DegreeOfTime(double baseValue, double factor, byte decimalPlaces, string dimension)
        {
            myValue = baseValue;
            myFactor = factor;
            myDecimalPlaces = decimalPlaces;
            myDimension = dimension;
        }

        public double Value
        {
            get { return myValue * myFactor; }
            set { myValue = value / myFactor; }
        }

        public double Factor
        {
            get { return myFactor; }
            set { myFactor = value; }
        }

        public string Dimension
        {
            get { return myDimension; }
            set { myDimension = value; }
        }

        public byte DecimalPlaces
        {
            get { return myDecimalPlaces; }
            set { myDecimalPlaces = value; }
        }

        public double UnderlyingValue => myValue;

        public override string ToString()
        {
            string locDec = "0";
            if (DecimalPlaces > 0)
                locDec += "." + new string('0', DecimalPlaces);
            return Value.ToString(locDec) + " " + Dimension;
        }

        public static implicit operator DegreeOfTime(double value)
        {
            return new DegreeOfTime(value);
        }
    }
}
