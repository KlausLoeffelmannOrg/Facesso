using System;
using System.IO;
using System.Xml.Serialization;
using ActiveDev;

namespace Facesso
{
    [Serializable]
    public class TimeSettingDetails
    {
        private TimeSettingDetail[] myGenericTimeSettingDetails = new TimeSettingDetail[5];
        private TimeSettingDetail[] myTimeSettingDetail = new TimeSettingDetail[29];
        private DateTime myFallBackStartTime;
        private DateTime myFallBackEndTime;
        private DateTime myNextShiftStart;

        public TimeSettingDetails()
        {
            CreateObjects();
        }

        public TimeSettingDetails(DateTime shift1Start, DateTime shift2Start,
            DateTime shift3Start, DateTime shift3End,
            ADDBNullable<DateTime> shift4Start, ADDBNullable<DateTime> shift4End,
            ADDBNullable<int> standardPauseTime)
        {
            myGenericTimeSettingDetails[0] = new TimeSettingDetail(shift1Start, shift2Start, standardPauseTime,
                2, TimeSettingDetailsWeekdays.ForAll, 1);
            myGenericTimeSettingDetails[1] = new TimeSettingDetail(shift2Start, shift3Start, standardPauseTime,
                3, TimeSettingDetailsWeekdays.ForAll, 2);
            myGenericTimeSettingDetails[2] = new TimeSettingDetail(shift3Start, shift3End, standardPauseTime,
                new ADDBNullable<int>(), TimeSettingDetailsWeekdays.ForAll, 3);
            myGenericTimeSettingDetails[3] = new TimeSettingDetail(shift4Start, shift4End, standardPauseTime,
                new ADDBNullable<int>(), TimeSettingDetailsWeekdays.ForAll, 4);
            CreateObjects(myGenericTimeSettingDetails);
        }

        private void CreateObjects()
        {
            var locTSD = new TimeSettingDetail();
            CreateObjects(locTSD);
        }

        private void CreateObjects(TimeSettingDetail tsdTemplate)
        {
            for (int z = 0; z <= 3; z++)
                myGenericTimeSettingDetails[z] = tsdTemplate.Clone(z + 1, TimeSettingDetailsWeekdays.ForAll);
            CreateObjects(myGenericTimeSettingDetails);
        }

        private void CreateObjects(TimeSettingDetail[] tsdTemplates)
        {
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 6; j++)
                {
                    myTimeSettingDetail[i * 7 + j] = tsdTemplates[i].Clone(i + 1, (TimeSettingDetailsWeekdays)(j + 1));
                    myTimeSettingDetail[i * 7 + j].IsDerived = true;
                }
        }

        public TimeSettingDetails Clone()
        {
            var locClone = new TimeSettingDetails();
            for (int i = 0; i <= 3; i++)
            {
                locClone.myGenericTimeSettingDetails[i] = myGenericTimeSettingDetails[i].Clone();
                for (int j = 0; j <= 6; j++)
                    locClone.myTimeSettingDetail[i * 7 + j] = myTimeSettingDetail[i * 7 + j].Clone();
            }
            return locClone;
        }

        public TimeSettingDetail[] GenericTimeSettingDetail
        {
            get { return myGenericTimeSettingDetails; }
            set { myGenericTimeSettingDetails = value; }
        }

        public TimeSettingDetail[] TimeSettingDetail
        {
            get { return myTimeSettingDetail; }
            set { myTimeSettingDetail = value; }
        }

        public TimeSettingDetail GetTimeSettingDetail(DateTime workDate, int shift)
        {
            int locDay = (int)workDate.DayOfWeek == 0 ? 7 : (int)workDate.DayOfWeek;
            locDay -= 1;
            return myTimeSettingDetail[(shift - 1) * 7 + locDay];
        }

        public TimeSettingDetail GetTimeSettingDetail(DateTime workDate, int shift, bool alignedToCurrentDate)
        {
            if (!alignedToCurrentDate)
                return GetTimeSettingDetail(workDate, shift);

            var retTSD = GetTimeSettingDetail(workDate, shift).Clone();
            var difToBaseDate = workDate.Date - new DateTime(2003, 1, 1);

            if (retTSD.ImportShiftStart.HasValue)
                retTSD.ImportShiftStart = retTSD.ImportShiftStart.TypedValue.Add(difToBaseDate);
            if (retTSD.ImportShiftEnd.HasValue)
                retTSD.ImportShiftEnd = retTSD.ImportShiftEnd.TypedValue.Add(difToBaseDate);
            if (retTSD.ShiftStart.HasValue)
                retTSD.ShiftStart = retTSD.ShiftStart.TypedValue.Add(difToBaseDate);
            if (retTSD.ShiftEnd.HasValue)
                retTSD.ShiftEnd = retTSD.ShiftEnd.TypedValue.Add(difToBaseDate);

            return retTSD;
        }

        public static TimeSettingDetails FromXmlString(string xmlString)
        {
            var locXml = new XmlSerializer(typeof(TimeSettingDetails));
            var locSr = new StringReader(xmlString);
            return (TimeSettingDetails)locXml.Deserialize(locSr);
        }

        public string XMLString()
        {
            var locXml = new XmlSerializer(typeof(TimeSettingDetails));
            var locSw = new StringWriter();
            locXml.Serialize(locSw, this);
            return locSw.ToString();
        }

        public TimeSplitDataTable DistributeTimes(DateTime startTime, DateTime endTime)
        {
            var locTimes = new TimeSplitDataTable();
            return locTimes;
        }

        public ShiftTimeSpan FindShiftForPeriod(DateTime proddate, DateTime startTime, DateTime endTime)
        {
            TimeSettingDetail currentTsd;
            var bookingRange = new TimePeriodComparer(startTime, endTime);
            var longestTimeInShift = new ShiftTimeSpan();

            int firstShift = 0;
            int lastShift = 0;
            var tsdFirstShift = new TimeSettingDetail();
            var tsdLastShift = new TimeSettingDetail();

            for (int sCount = 1; sCount <= 4; sCount++)
            {
                var currShift = GetTimeSettingDetail(proddate, sCount, true);
                if (currShift.ImportShiftStart.HasValue)
                {
                    if (firstShift == 0)
                    {
                        firstShift = sCount;
                        tsdFirstShift = currShift;
                    }
                }
                currShift = GetTimeSettingDetail(proddate, 5 - sCount, true);
                if (currShift.ImportShiftEnd.HasValue)
                {
                    if (lastShift == 0)
                    {
                        lastShift = 5 - sCount;
                        tsdLastShift = currShift;
                    }
                }
                if (firstShift != 0 && lastShift != 0) break;
            }

            for (byte shiftCount = (byte)firstShift; shiftCount <= (byte)lastShift; shiftCount++)
            {
                currentTsd = GetTimeSettingDetail(proddate, shiftCount, true);
                var shiftRange = new TimePeriodComparer(currentTsd.ImportShiftStart, currentTsd.ImportShiftEnd);
                var overlapInfo = shiftRange.OverlappingTimeInfo(bookingRange);

                if (overlapInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.EndsBefore ||
                    overlapInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.StartsAfter)
                    continue;

                if (overlapInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.IncludesCompletely)
                {
                    longestTimeInShift.OverlappingTime = (int)overlapInfo.OverlappingMinutes;
                    longestTimeInShift.ShiftNo = shiftCount;
                    goto SkipToReturnValue;
                }

                if (overlapInfo.OverlappingMinutes > longestTimeInShift.OverlappingTime)
                {
                    longestTimeInShift.OverlappingTime = (int)overlapInfo.OverlappingMinutes;
                    longestTimeInShift.ShiftNo = shiftCount;
                }
            }

            if (longestTimeInShift.OverlappingTime == 0)
                return null;

        SkipToReturnValue:
            currentTsd = GetTimeSettingDetail(proddate, longestTimeInShift.ShiftNo, true);
            return new ShiftTimeSpan(proddate, longestTimeInShift.ShiftNo, currentTsd.ShiftStart, currentTsd.ShiftEnd);
        }

        public ShiftTimeSpan FindShiftForStartTime(DateTime prodDate, DateTime startTime)
        {
            DateTime locProductionDate = startTime.Date;
            TimeSettingDetail locTimeSettingDetail = GetTimeSettingDetail(locProductionDate, 1);
            DateTime locShift1Date = locTimeSettingDetail.ImportShiftStart.TypedValue.Date;
            TimeSpan locOffset = locProductionDate.Subtract(locShift1Date);

            for (byte locShift = 1; locShift <= 4; locShift++)
            {
                locTimeSettingDetail = GetTimeSettingDetail(locProductionDate, locShift);
                int locThreshold;

                if (locShift == 1)
                {
                    try
                    {
                        myFallBackStartTime = locTimeSettingDetail.ImportShiftStart.TypedValue;
                        myFallBackEndTime = locTimeSettingDetail.ImportShiftEnd.TypedValue;
                    }
                    catch
                    {
                        myFallBackStartTime = FacessoGeneric.FallbackStartTime;
                        myFallBackEndTime = FacessoGeneric.FallbackEndTime;
                    }
                    myNextShiftStart = myFallBackStartTime.AddMinutes(-FacessoGeneric.FirstShiftThresholdInMin);
                }

                if (locTimeSettingDetail.Threshold.IsNull)
                    locThreshold = 0;
                else
                    locThreshold = locTimeSettingDetail.Threshold;

                DateTime locShiftStart, locShiftEndUnaligned, locShiftEnd;

                locShiftStart = myNextShiftStart.AddMinutes(-locThreshold).Add(locOffset);
                try
                {
                    locShiftEnd = locTimeSettingDetail.ImportShiftEnd.TypedValue;
                    locShiftEndUnaligned = locShiftEnd;
                    locShiftEnd = locShiftEnd.Add(locOffset);
                }
                catch
                {
                    locShiftEnd = myFallBackEndTime;
                    locShiftEndUnaligned = locShiftEnd;
                    locShiftEnd = locShiftEnd.Add(locOffset);
                }
                if (locShiftEnd < locShiftStart)
                {
                    locShiftEnd.AddHours(7);       // preserves original VB behaviour (return value discarded)
                    locShiftEndUnaligned.AddHours(7);
                }

                ShiftTimeSpan retShiftTimeSpan = null;

                if (startTime >= locShiftStart && startTime <= locShiftEnd)
                    retShiftTimeSpan = new ShiftTimeSpan(locProductionDate, locShift, locShiftStart, locShiftEnd);

                myNextShiftStart = locShiftEndUnaligned;
                if (retShiftTimeSpan != null)
                    return retShiftTimeSpan;
            }
            return null;
        }
    }

    [Serializable]
    public class TimeSettingDetail
    {
        private ADDBNullable<DateTime> myShiftStart;
        private ADDBNullable<DateTime> myShiftEnd;
        private ADDBNullable<DateTime> myImportShiftStart;
        private ADDBNullable<DateTime> myImportShiftEnd;
        private ADDBNullable<DateTime> myRoundUpBefore;
        private ADDBNullable<DateTime> myRoundDownAfter;
        private ADDBNullable<int> myPauseTime;
        private ADDBNullable<int> myThreshold;
        private bool myForceToHavePause;
        private ADDBNullable<int> myChainEndTimeTo;
        private bool mySpecialShiftIsShift4;
        private bool myIsDerived;
        private TimeSettingDetailsWeekdays myForWeekday;
        private int myForShift;

        public TimeSettingDetail() { }

        public TimeSettingDetail(ADDBNullable<DateTime> shiftStart, ADDBNullable<DateTime> shiftEnd,
            ADDBNullable<int> pauseTime, ADDBNullable<int> chainEndTimeTo,
            TimeSettingDetailsWeekdays forWeekDay, int forShift)
        {
            myShiftStart = shiftStart;
            myShiftEnd = shiftEnd;
            myImportShiftStart = shiftStart;
            myImportShiftEnd = shiftEnd;
            myChainEndTimeTo = chainEndTimeTo;
            myForWeekday = forWeekDay;
            myForShift = forShift;
            myPauseTime = pauseTime;
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> ShiftStart
        {
            get { return myShiftStart; }
            set { myShiftStart = value; }
        }

        public DateTime XMLShiftStart
        {
            get { return myShiftStart.IsNull ? default(DateTime) : myShiftStart.TypedValue; }
            set { myShiftStart = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> ShiftEnd
        {
            get { return myShiftEnd; }
            set { myShiftEnd = value; }
        }

        public DateTime XMLShiftEnd
        {
            get { return myShiftEnd.IsNull ? default(DateTime) : myShiftEnd.TypedValue; }
            set { myShiftEnd = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> ImportShiftStart
        {
            get { return myImportShiftStart; }
            set { myImportShiftStart = value; }
        }

        public DateTime XMLImportShiftStart
        {
            get { return myImportShiftStart.IsNull ? default(DateTime) : myImportShiftStart.TypedValue; }
            set { myImportShiftStart = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> ImportShiftEnd
        {
            get { return myImportShiftEnd; }
            set { myImportShiftEnd = value; }
        }

        public DateTime XMLImportShiftEnd
        {
            get { return myImportShiftEnd.IsNull ? default(DateTime) : myImportShiftEnd.TypedValue; }
            set { myImportShiftEnd = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> RoundUpBefore
        {
            get { return myRoundUpBefore; }
            set { myRoundUpBefore = value; }
        }

        public DateTime XMLShiftRoundUpBefore
        {
            get { return myRoundUpBefore.IsNull ? default(DateTime) : myRoundUpBefore.TypedValue; }
            set { myRoundUpBefore = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<DateTime> RoundDownAfter
        {
            get { return myRoundDownAfter; }
            set { myRoundDownAfter = value; }
        }

        public DateTime XMLRoundDownAfter
        {
            get { return myRoundUpBefore.IsNull ? default(DateTime) : myRoundUpBefore.TypedValue; }
            set { myRoundDownAfter = value == default(DateTime) ? new ADDBNullable<DateTime>() : (ADDBNullable<DateTime>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<int> WorkBreak
        {
            get { return myPauseTime; }
            set { myPauseTime = value; }
        }

        public int XMLPauseTime
        {
            get { return myPauseTime.IsNull ? -1 : myPauseTime.TypedValue; }
            set { myPauseTime = value == -1 ? new ADDBNullable<int>() : (ADDBNullable<int>)value; }
        }

        [XmlIgnore]
        public ADDBNullable<int> Threshold
        {
            get { return myThreshold; }
            set { myThreshold = value; }
        }

        public int XMLThreshold
        {
            get { return myThreshold.IsNull ? -1 : myThreshold.TypedValue; }
            set { myThreshold = value == -1 ? new ADDBNullable<int>() : (ADDBNullable<int>)value; }
        }

        public bool ForceToHavePause
        {
            get { return myForceToHavePause; }
            set { myForceToHavePause = value; }
        }

        [XmlIgnore]
        public ADDBNullable<int> ChainEndTimeTo
        {
            get { return myChainEndTimeTo; }
            set { myChainEndTimeTo = value; }
        }

        public int XMLChainEndTimeTo
        {
            get { return myChainEndTimeTo.IsNull ? -1 : myChainEndTimeTo.TypedValue; }
            set { myChainEndTimeTo = value == -1 ? new ADDBNullable<int>() : (ADDBNullable<int>)value; }
        }

        public bool IsDerived
        {
            get { return myIsDerived; }
            set { myIsDerived = value; }
        }

        public TimeSettingDetailsWeekdays ForWeekday
        {
            get { return myForWeekday; }
            set { myForWeekday = value; }
        }

        public int ForShift
        {
            get { return myForShift; }
            set { myForShift = value; }
        }

        public TimeSettingDetail Clone()
        {
            var locTSD = new TimeSettingDetail();
            locTSD.ChainEndTimeTo = ChainEndTimeTo;
            locTSD.ForceToHavePause = ForceToHavePause;
            locTSD.ForShift = ForShift;
            locTSD.ForWeekday = ForWeekday;
            locTSD.IsDerived = true;
            locTSD.WorkBreak = WorkBreak;
            locTSD.RoundDownAfter = RoundDownAfter;
            locTSD.RoundUpBefore = RoundUpBefore;
            locTSD.ShiftEnd = ShiftEnd;
            locTSD.ShiftStart = ShiftStart;
            locTSD.ImportShiftStart = ImportShiftStart;
            locTSD.ImportShiftEnd = ImportShiftEnd;
            locTSD.Threshold = Threshold;
            return locTSD;
        }

        public void NullAll()
        {
            ChainEndTimeTo = new ADDBNullable<int>();
            ForceToHavePause = false;
            ForShift = 0;
            ForWeekday = default(TimeSettingDetailsWeekdays);
            IsDerived = false;
            WorkBreak = new ADDBNullable<int>();
            RoundDownAfter = new ADDBNullable<DateTime>();
            RoundUpBefore = new ADDBNullable<DateTime>();
            ShiftEnd = new ADDBNullable<DateTime>();
            ShiftStart = new ADDBNullable<DateTime>();
            ImportShiftEnd = new ADDBNullable<DateTime>();
            ImportShiftStart = new ADDBNullable<DateTime>();
            Threshold = new ADDBNullable<int>();
        }

        public TimeSettingDetail Clone(int forShift, TimeSettingDetailsWeekdays forWeekday)
        {
            var locTSD = Clone();
            locTSD.ForShift = forShift;
            locTSD.ForWeekday = forWeekday;
            return locTSD;
        }

        public bool IsEqual(TimeSettingDetail tsd)
        {
            if (tsd.ChainEndTimeTo != ChainEndTimeTo) return false;
            if (tsd.ForceToHavePause != ForceToHavePause) return false;
            if (tsd.ForShift != ForShift) return false;
            if (tsd.WorkBreak != WorkBreak) return false;
            if (tsd.RoundDownAfter != RoundDownAfter) return false;
            if (tsd.RoundUpBefore != RoundUpBefore) return false;
            if (tsd.ShiftEnd != ShiftEnd) return false;
            if (tsd.ShiftStart != ShiftStart) return false;
            if (tsd.ImportShiftEnd != ImportShiftEnd) return false;
            if (tsd.ImportShiftStart != ImportShiftStart) return false;
            if (tsd.Threshold != Threshold) return false;
            return true;
        }

        public override string ToString()
        {
            string locString = "S:" + ForShift.ToString("0");
            if (ShiftStart.HasValue)
                locString += "    S: " + ShiftStart.TypedValue.ToString("HH:mm (dd)") +
                             "    E: " + ShiftEnd.TypedValue.ToString("HH:mm (dd)");
            else
                locString += "    S: --:-- (--)    E: --:-- (--)";

            if (ImportShiftStart.HasValue)
                locString += "   IS:" + ImportShiftStart.TypedValue.ToString("HH:mm (dd)");
            else
                locString += "   IS:--:-- (--)";

            if (ImportShiftEnd.HasValue)
                locString += "   IE:" + ImportShiftEnd.TypedValue.ToString("HH:mm (dd)") + "     ";
            else
                locString += "   IE:--:-- (--)     ";

            string locWeekday = ForWeekday.ToString();
            if (System.Globalization.CultureInfo.CurrentUICulture.Name.StartsWith("de"))
            {
                switch (ForWeekday)
                {
                    case TimeSettingDetailsWeekdays.ForAll: locWeekday = "Für alle Wochentage"; break;
                    case TimeSettingDetailsWeekdays.Friday: locWeekday = "Für freitags"; break;
                    case TimeSettingDetailsWeekdays.Monday: locWeekday = "Für montags"; break;
                    case TimeSettingDetailsWeekdays.Saturday: locWeekday = "Für samstags"; break;
                    case TimeSettingDetailsWeekdays.Sunday: locWeekday = "Für sonntags"; break;
                    case TimeSettingDetailsWeekdays.Thursday: locWeekday = "Für donnerstags"; break;
                    case TimeSettingDetailsWeekdays.Tuesday: locWeekday = "Für dienstags"; break;
                    case TimeSettingDetailsWeekdays.Wednesday: locWeekday = "Für mittwochs"; break;
                }
            }
            locString += locWeekday;
            return locString;
        }
    }

    [Serializable]
    public enum TimeSettingDetailsWeekdays
    {
        ForAll = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class ShiftTimeSpan
    {
        private DateTime myProductionDate;
        private byte myShift;
        private DateTime myShiftStart;
        private DateTime myShiftEnd;
        private int myOverlappingTime;
        private int myDistanceToAStartTime;

        public ShiftTimeSpan() { }

        public ShiftTimeSpan(DateTime productionDate, byte shift, DateTime shiftStart, DateTime shiftEnd)
        {
            myProductionDate = productionDate;
            myShift = shift;
            myShiftStart = shiftStart;
            myShiftEnd = shiftEnd;
        }

        public DateTime ProductionDate
        {
            get { return myProductionDate; }
            set { myProductionDate = value; }
        }

        public byte ShiftNo
        {
            get { return myShift; }
            set { myShift = value; }
        }

        public DateTime ShiftStart
        {
            get { return myShiftStart; }
            set { myShiftStart = value; }
        }

        public DateTime ShiftEnd
        {
            get { return myShiftEnd; }
            set { myShiftEnd = value; }
        }

        public int OverlappingTime
        {
            get { return myOverlappingTime; }
            set { myOverlappingTime = value; }
        }

        public int DistanceToAStartTime
        {
            get { return myDistanceToAStartTime; }
            set { myDistanceToAStartTime = value; }
        }
    }
}
