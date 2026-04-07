using System;
using System.Collections.ObjectModel;
using System.Globalization;
using ActiveDev;

namespace Facesso.Data
{
    public class ProductionPeriod : Collection<ProductionPeriodItem>
    {
        private DateTime _StartDate;
        private DateTime _EndDate;
        private ShiftParameters _ShiftParameters;

        public ProductionPeriod(DateTime certainDate, byte certainShift) : base()
        {
            certainDate = certainDate.Date;
            _StartDate = certainDate;
            _EndDate = certainDate;
            this.Add(new ProductionPeriodItem(certainDate, certainShift));
        }

        /// <summary>
        /// Erstellt einen neuen Produktionsdaten-Auswertungszeitraum über alle Schichten im entsprechenden Zeitraum
        /// </summary>
        public ProductionPeriod(DateTime startdate, DateTime endDate) : base()
        {
            startdate = startdate.Date;
            endDate = endDate.Date;
            _StartDate = startdate;
            _EndDate = endDate;
            for (double locDouble = startdate.ToOADate(); locDouble <= endDate.ToOADate(); locDouble++)
            {
                for (byte locShift = 1; locShift <= 4; locShift++)
                {
                    this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble), locShift));
                }
            }
        }

        public ProductionPeriod(DateTime startdate, DateTime endDate, byte shift)
            : this(startdate, endDate, shift, shift, 1) { }

        public ProductionPeriod(DateRangeParameter dateRange, ShiftParameters shifts) : base()
        {
            _StartDate = dateRange.StartDate.Date;
            _EndDate = dateRange.EndDate.Date;
            _ShiftParameters = shifts;

            int locShiftDaysChangeCount = 0;
            bool locShiftChangeFlag = false;
            for (double locDouble = _StartDate.ToOADate(); locDouble <= _EndDate.ToOADate(); locDouble++)
            {
                if (!shifts.AlternateShifts)
                {
                    if (shifts.ConsiderShift1) this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble), 1));
                    if (shifts.ConsiderShift2) this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble), 2));
                    if (shifts.ConsiderShift3) this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble), 3));
                    if (shifts.ConsiderShift4) this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble), 4));
                }
                else
                {
                    this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble),
                        (byte)(locShiftChangeFlag ? shifts.AlternatingFirstShift : shifts.AlternatingSecondShift)));
                    locShiftDaysChangeCount += 1;
                    if (locShiftDaysChangeCount > 0)
                    {
                        if (locShiftDaysChangeCount == shifts.DaysAfterToAlternate)
                            locShiftChangeFlag = !locShiftChangeFlag;
                    }
                    else
                    {
                        int vbWeekday = VbWeekdayMondayFirst(DateTime.FromOADate(locDouble));
                        if (vbWeekday == -locShiftDaysChangeCount)
                            locShiftChangeFlag = !locShiftChangeFlag;
                    }
                }
            }
        }

        public ProductionPeriod(DateTime startDate, DateTime endDate,
            byte alternatingShift1, byte alternatingShift2, int shiftChangeAfterDays) : base()
        {
            startDate = startDate.Date;
            endDate = endDate.Date;
            _StartDate = startDate;
            _EndDate = endDate;
            int locShiftDaysChangeCount = 0;
            bool locShiftChangeFlag = false;
            for (double locDouble = startDate.ToOADate(); locDouble <= endDate.ToOADate(); locDouble++)
            {
                this.Add(new ProductionPeriodItem(DateTime.FromOADate(locDouble),
                    (byte)(locShiftChangeFlag ? alternatingShift2 : alternatingShift1)));
                locShiftDaysChangeCount += 1;
                if (locShiftDaysChangeCount > 0)
                {
                    if (locShiftDaysChangeCount == shiftChangeAfterDays)
                        locShiftChangeFlag = !locShiftChangeFlag;
                }
                else
                {
                    int vbWeekday = VbWeekdayMondayFirst(DateTime.FromOADate(locDouble));
                    if (vbWeekday == -locShiftDaysChangeCount)
                        locShiftChangeFlag = !locShiftChangeFlag;
                }
            }
        }

        private static int VbWeekdayMondayFirst(DateTime d)
        {
            int dow = (int)d.DayOfWeek;
            return (dow == 0) ? 7 : dow;
        }

        public void PrepareProductionDates(int idSubsidiary, int idUser, DateTime ticket)
        {
            SPAccess.GetInstance().ProductionData_PrepareProductionDates(idSubsidiary, idUser, ticket, this);
        }

        public DateTime StartDate => _StartDate;

        public DateTime EndDate => _EndDate;

        public string RangeDescription
        {
            get
            {
                if (StartDate == EndDate)
                {
                    if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de")
                        return "Am " + StartDate.ToLongDateString();
                    else
                        return "On " + StartDate.ToLongDateString();
                }
                else
                {
                    if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de")
                        return "Von " + StartDate.ToLongDateString() + " bis " + EndDate.ToLongDateString();
                    else
                        return "From " + StartDate.ToLongDateString() + " to " + EndDate.ToLongDateString();
                }
            }
        }

        public string StartDateMonthDescription => StartDate.ToString("MMMM yyyy");

        public ShiftParameters ShiftParameters => _ShiftParameters;
    }

    public struct DateRangeParameter
    {
        private DateRangePresets myDateRangePreset;
        private DateTime myStartDate;
        private DateTime myEndDate;
        private int myMonthIntoPast;
        private LastWorkingdays myLastWorkingDay;

        public DateRangeParameter(DateRangePresets dateRangePreset, LastWorkingdays lastWorkingDay)
        {
            myLastWorkingDay = lastWorkingDay;
            myMonthIntoPast = 0;
            myStartDate = default;
            myEndDate = default;
            myDateRangePreset = DateRangePresets.CustomPeriod;
            DateRangePreset = dateRangePreset;
        }

        public DateRangeParameter(DateRangePresets dateRangePreset)
        {
            myLastWorkingDay = LastWorkingdays.Friday;
            myMonthIntoPast = 0;
            myStartDate = default;
            myEndDate = default;
            myDateRangePreset = DateRangePresets.CustomPeriod;
            DateRangePreset = dateRangePreset;
        }

        public DateRangeParameter(DateRangePresets dateRangePreset, int monthIntoPast)
        {
            myMonthIntoPast = monthIntoPast;
            myLastWorkingDay = LastWorkingdays.Friday;
            myStartDate = default;
            myEndDate = default;
            myDateRangePreset = DateRangePresets.CustomPeriod;
            DateRangePreset = dateRangePreset;
        }

        public DateRangeParameter(DateTime startdate, DateTime enddate)
        {
            myDateRangePreset = DateRangePresets.CustomPeriod;
            myStartDate = startdate;
            myEndDate = enddate;
            myMonthIntoPast = 0;
            myLastWorkingDay = LastWorkingdays.Friday;
        }

        public LastWorkingdays LastWorkingday
        {
            get { return myLastWorkingDay; }
            set { myLastWorkingDay = value; }
        }

        public DateRangePresets DateRangePreset
        {
            get { return myDateRangePreset; }
            set
            {
                switch (value)
                {
                    case DateRangePresets.YesterdayOrLastWorkingDay:
                        if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Monday)
                        {
                            if (myLastWorkingDay == LastWorkingdays.Sunday)
                                myStartDate = DateTime.Now.Date.AddDays(-1);
                            else if (myLastWorkingDay == LastWorkingdays.Saturday)
                                myStartDate = DateTime.Now.Date.AddDays(-2);
                            else
                                myStartDate = DateTime.Now.Date.AddDays(-3);
                        }
                        else
                            myStartDate = DateTime.Now.Date.AddDays(-1);
                        myEndDate = myStartDate;
                        break;
                    case DateRangePresets.FromStartOfCurrentMonthToNow:
                        myStartDate = Dates.FirstDayOfMonth(DateTime.Now.Date);
                        myEndDate = DateTime.Now.Date;
                        break;
                    case DateRangePresets.FromStartOfCurrentWeekToNow:
                        myStartDate = Dates.MondayOfWeek(DateTime.Now.Date);
                        myEndDate = DateTime.Now.Date;
                        break;
                    case DateRangePresets.FromStartToEndOfSpecifiedMonth:
                        if (myMonthIntoPast == -1) myMonthIntoPast = 0;
                        myStartDate = Dates.FirstDayOfMonth(DateTime.Now.AddMonths(-MonthIntoPast));
                        myEndDate = Dates.LastDayOfMonth(DateTime.Now.AddMonths(-MonthIntoPast));
                        break;
                    case DateRangePresets.LastWeek:
                        myStartDate = Dates.MondayOfWeek(DateTime.Now.Date).AddDays(-7);
                        myEndDate = myStartDate.AddDays(7);
                        break;
                    case DateRangePresets.Today:
                        myStartDate = DateTime.Now.Date;
                        myEndDate = myStartDate;
                        break;
                    case DateRangePresets.SinceYearBeganToNow:
                        myStartDate = new DateTime(DateTime.Now.Year, 1, 1);
                        myEndDate = DateTime.Now.Date;
                        break;
                    case DateRangePresets.WeekBeforeLastWeek:
                        myStartDate = Dates.MondayOfWeek(DateTime.Now.Date).AddDays(-14);
                        myEndDate = myStartDate.AddDays(7);
                        break;
                }
                myDateRangePreset = value;
            }
        }

        public int MonthIntoPast
        {
            get { return myMonthIntoPast; }
            set { myMonthIntoPast = value; }
        }

        public DateTime StartDate
        {
            get { return myStartDate; }
            set { myStartDate = value; }
        }

        public DateTime EndDate
        {
            get { return myEndDate; }
            set { myEndDate = value; }
        }

        public override string ToString()
        {
            string locString = "";
            switch (myDateRangePreset)
            {
                case DateRangePresets.CustomPeriod:
                    locString = "Freidefinierter Zeitraum."; break;
                case DateRangePresets.FromStartOfCurrentMonthToNow:
                    locString = "Vom Anfang des aktuellen Monats bis heute."; break;
                case DateRangePresets.FromStartOfCurrentWeekToNow:
                    locString = "Vom Anfang der aktuellen Woche bis heute."; break;
                case DateRangePresets.FromStartToEndOfSpecifiedMonth:
                    locString = "Vom Anfang bis zum Ende des Monats " + StartDate.ToString("MMMM yyyy") + "."; break;
                case DateRangePresets.LastWeek:
                    locString = "Die letzte Woche."; break;
                case DateRangePresets.SinceYearBeganToNow:
                    locString = "Von Anfang des laufenden Jahres bis heute."; break;
                case DateRangePresets.Today:
                    locString = "Heute."; break;
                case DateRangePresets.WeekBeforeLastWeek:
                    locString = "Die vorletzte Woche."; break;
                case DateRangePresets.YesterdayOrLastWorkingDay:
                    locString = "Gestern."; break;
            }
            locString += Environment.NewLine;
            if (StartDate == EndDate)
                locString += "Aus heutiger Sicht ist das am " + StartDate.ToLongDateString();
            else
                locString += "Aus heutiger Sicht ist das vom " + StartDate.ToLongDateString() + " bis " + EndDate.ToLongDateString();
            return locString;
        }
    }

    public enum LastWorkingdays
    {
        Friday,
        Saturday,
        Sunday
    }

    public enum DateRangePresets
    {
        CustomPeriod = 0,
        FromStartOfCurrentMonthToNow,
        FromStartToEndOfSpecifiedMonth,
        SinceYearBeganToNow,
        FromStartOfCurrentWeekToNow,
        LastWeek,
        YesterdayOrLastWorkingDay,
        Today,
        WeekBeforeLastWeek
    }
}
