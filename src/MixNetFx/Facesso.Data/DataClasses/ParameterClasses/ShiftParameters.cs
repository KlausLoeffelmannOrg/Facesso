using System;
using System.Collections;

namespace Facesso.Data
{
    /// <summary>
    /// Hält die Schichteinstellungen (Schichten, Alternierende Schritte, etc.) für Auswertungen
    /// </summary>
    [Serializable]
    public class ShiftParameters
    {
        private bool myConsiderShift1;
        private bool myConsiderShift2;
        private bool myConsiderShift3;
        private bool myConsiderShift4;
        private bool myAlternateShifts;
        private int myDaysAfterToAlternate;
        private int myAlternatingFirstShift;
        private int myAlternatingSecondShift;

        public ShiftParameters()
        {
            myAlternateShifts = false;
            myAlternatingFirstShift = 1;
            myAlternatingSecondShift = 2;
            myDaysAfterToAlternate = 7;
        }

        public ShiftParameters(bool cShift1, bool cShift2, bool cShift3, bool cShift4,
            bool alternateShifts, int daysAfterToAlternate,
            int alternatingFirstShift, int alternatingSecondShift)
        {
            myConsiderShift1 = cShift1;
            myConsiderShift2 = cShift2;
            myConsiderShift3 = cShift3;
            myConsiderShift4 = cShift4;
            myAlternateShifts = alternateShifts;
            myDaysAfterToAlternate = daysAfterToAlternate;
            myAlternatingFirstShift = alternatingFirstShift;
            myAlternatingSecondShift = alternatingSecondShift;
        }

        public bool ConsiderShift1
        {
            get { return myConsiderShift1; }
            set { myConsiderShift1 = value; }
        }

        public bool ConsiderShift2
        {
            get { return myConsiderShift2; }
            set { myConsiderShift2 = value; }
        }

        public bool ConsiderShift3
        {
            get { return myConsiderShift3; }
            set { myConsiderShift3 = value; }
        }

        public bool ConsiderShift4
        {
            get { return myConsiderShift4; }
            set { myConsiderShift4 = value; }
        }

        public bool AlternateShifts
        {
            get { return myAlternateShifts; }
            set { myAlternateShifts = value; }
        }

        public int DaysAfterToAlternate
        {
            get { return myDaysAfterToAlternate; }
            set { myDaysAfterToAlternate = value; }
        }

        public int AlternatingFirstShift
        {
            get { return myAlternatingFirstShift; }
            set { myAlternatingFirstShift = value; }
        }

        public int AlternatingSecondShift
        {
            get { return myAlternatingSecondShift; }
            set { myAlternatingSecondShift = value; }
        }

        public override string ToString()
        {
            if (AlternateShifts)
                return "Wechselschicht zwischen Schicht " + AlternatingFirstShift + " und Schicht " + AlternatingSecondShift + " alle " + DaysAfterToAlternate + " Tage.";

            var locShiftCol = new ArrayList();
            if (ConsiderShift1) locShiftCol.Add(1);
            if (ConsiderShift2) locShiftCol.Add(2);
            if (ConsiderShift3) locShiftCol.Add(3);

            string locRetString = "Schicht ";
            for (int c = 0; c < locShiftCol.Count; c++)
            {
                locRetString += locShiftCol[c].ToString();
                if (c < (locShiftCol.Count - 2))
                    locRetString += ", ";
                if (c == (locShiftCol.Count - 2) && locShiftCol.Count > 1)
                    locRetString += " und ";
            }
            return locRetString;
        }
    }
}
