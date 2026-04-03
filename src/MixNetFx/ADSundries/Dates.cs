using System;
using Microsoft.VisualBasic;

namespace ActiveDev
{

    public sealed class Dates
    {

        /// <summary>
    /// Errechnet das Datum, das dem 1. des Monats entspricht, 
    /// der sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Monat für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime FirstDayOfMonth(DateTime CurrentDate)
        {
            return new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
        }

        /// <summary>
    /// Errechnet das Datum, das dem Letzen des Monats entspricht, 
    /// der sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Monat für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime LastDayOfMonth(DateTime CurrentDate)
        {
            return new DateTime(CurrentDate.Year, CurrentDate.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
    /// Errechnet das Datum, das dem 1. des Jahres entspricht, 
    /// das sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Jahr für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime FirstOfYear(DateTime CurrentDate)
        {
            return new DateTime(CurrentDate.Year, 1, 1);
        }

        /// <summary>
    /// Errechnet das Datum, das dem ersten Montag der ersten Woche des Monats entspricht, 
    /// der sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime MondayOfFirstWeekOfMonth(DateTime CurrentDate)
        {
            var locDate = FirstDayOfMonth(CurrentDate);
            if (DateAndTime.Weekday(locDate) == (int)DayOfWeek.Monday)
            {
                return locDate;
            }
            return locDate.AddDays(6 - DateAndTime.Weekday(CurrentDate));
        }

        /// <summary>
    /// Errechnet das Datum, das dem Montag Woche entspricht, 
    /// die sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime MondayOfWeek(DateTime CurrentDate)
        {
            if (DateAndTime.Weekday(CurrentDate) == (int)DayOfWeek.Monday)
            {
                return CurrentDate;
            }
            else
            {
                return CurrentDate.AddDays(-DateAndTime.Weekday(CurrentDate) + 1);
            }
        }

        /// <summary>
    /// Errechnet das Datum, das dem ersten Montag der zweiten Woche des Monats entspricht, 
    /// der sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime MondayOfSecondWeekOfMonth(DateTime currentDate)
        {
            return MondayOfFirstWeekOfMonth(currentDate).AddDays(7d);
        }

        /// <summary>
    /// Errechnet das Datum, das dem ersten Montag der letzten Woche des Monats entspricht, 
    /// der sich aus dem angegebenen Datum ergibt.
    /// </summary>
    /// <param name="CurrentDate">Datum, dessen Woche für die Berechnung zugrunde gelegt wird.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime MondayOfLastWeekOfMonth(DateTime CurrentDate)
        {
            var locDate = FirstDayOfMonth(CurrentDate).AddDays(-1);
            if (DateAndTime.Weekday(locDate) == (int)DayOfWeek.Monday)
            {
                return locDate;
            }
            return locDate.AddDays(-DateAndTime.Weekday(CurrentDate) + 1);
        }

        /// <summary>
    /// Ergibt das Datum des nächsten Arbeitstages.
    /// </summary>
    /// <param name="CurrentDate">Datum der Berechnungsgrundlage</param>
    /// <param name="WorkOnSaturdays">True, wenn Samstag Arbeitstag ist.</param>
    /// <param name="WorkOnSundays">True, wenn Sonntag Arbeitstag ist.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime NextWorkday(DateTime CurrentDate, bool WorkOnSaturdays, bool WorkOnSundays)
        {
            CurrentDate = CurrentDate.AddDays(1d);
            if (DateAndTime.Weekday(CurrentDate, FirstDayOfWeek.System) == (int)DayOfWeek.Saturday & !WorkOnSaturdays)
            {
                CurrentDate = CurrentDate.AddDays(1d);
            }
            if (DateAndTime.Weekday(CurrentDate, FirstDayOfWeek.System) == 7 & !WorkOnSundays)
            {
                CurrentDate = CurrentDate.AddDays(1d);
            }
            return CurrentDate;
        }

        /// <summary>
    /// Ergibt das Datum des vorherigen Arbeitstages.
    /// </summary>
    /// <param name="CurrentDate">Datum der Berechnungsgrundlage</param>
    /// <param name="WorkOnSaturdays">True, wenn Samstag Arbeitstag ist.</param>
    /// <param name="WorkOnSundays">True, wenn Sonntag Arbeitstag ist.</param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static DateTime PreviousWorkday(DateTime CurrentDate, bool WorkOnSaturdays, bool WorkOnSundays)
        {
            CurrentDate = CurrentDate.AddDays(-1);
            if (DateAndTime.Weekday(CurrentDate, FirstDayOfWeek.System) == 7 & !WorkOnSundays)
            {
                CurrentDate = CurrentDate.AddDays(-1);
            }
            if (DateAndTime.Weekday(CurrentDate, FirstDayOfWeek.System) == (int)DayOfWeek.Saturday & !WorkOnSaturdays)
            {
                CurrentDate = CurrentDate.AddDays(-1);
            }
            return CurrentDate;
        }
    }
}