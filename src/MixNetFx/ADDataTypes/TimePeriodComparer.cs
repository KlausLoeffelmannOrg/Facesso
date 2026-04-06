using System;
using System.Collections.Generic;

namespace ActiveDev
{
    public class TimePeriodComparer : IComparable, ICloneable
    {
        public TimePeriodComparer(DateTime? startTime, DateTime? endtime)
        {
            StartTime = startTime;
            EndTime = endtime;
        }

        public TimeSpan? TimeSpan
        {
            get
            {
                if (!EndTime.HasValue || !StartTime.HasValue)
                {
                    return null;
                }

                return EndTime.Value - StartTime.Value;
            }
        }

        public bool? IsEndtimePriorToStartTime
        {
            get
            {
                if (!EndTime.HasValue || !StartTime.HasValue)
                {
                    return null;
                }

                return EndTime.Value < StartTime.Value;
            }
        }

        public bool? IsIn(DateTime pointOfTime)
        {
            if (!EndTime.HasValue || !StartTime.HasValue)
            {
                return false;
            }

            return pointOfTime >= StartTime.Value && pointOfTime <= EndTime.Value;
        }

        public List<TimePeriodComparer> InsertOrCloseSimpleEvent(DateTime pointOfTime)
        {
            var retTimeSpans = new List<TimePeriodComparer>();

            if (!StartTime.HasValue && !EndTime.HasValue)
            {
                return null;
            }

            if (StartTime.HasValue && !EndTime.HasValue && pointOfTime > StartTime.Value)
            {
                retTimeSpans.Add(new TimePeriodComparer(StartTime, pointOfTime));
                return retTimeSpans;
            }

            if (!StartTime.HasValue && EndTime.HasValue && pointOfTime < EndTime.Value)
            {
                retTimeSpans.Add(new TimePeriodComparer(pointOfTime, EndTime));
                return retTimeSpans;
            }

            if (IsIn(pointOfTime) != true)
            {
                return null;
            }

            if (pointOfTime == StartTime.Value || pointOfTime == EndTime.Value)
            {
                retTimeSpans.Add(this);
                return retTimeSpans;
            }

            retTimeSpans.Add(new TimePeriodComparer(StartTime, pointOfTime));
            retTimeSpans.Add(new TimePeriodComparer(pointOfTime, EndTime));
            return retTimeSpans;
        }

        public OverlappingTimeInfo OverlappingTimeInfo(TimePeriodComparer timePeriod)
        {
            if (timePeriod == null)
            {
                throw new ArgumentException("Overlapping minutes can't be calculated if instance is null!");
            }

            if (!timePeriod.StartTime.HasValue && !timePeriod.EndTime.HasValue)
            {
                throw new ArgumentException("Overlapping minutes can't be calculated if instance is null!");
            }

            if (!StartTime.HasValue || !EndTime.HasValue)
            {
                return new OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.NotDefinable);
            }

            if (!timePeriod.StartTime.HasValue)
            {
                return new OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.OpenStart);
            }

            if (!timePeriod.EndTime.HasValue)
            {
                return new OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.OpenEnd);
            }

            if (timePeriod.IsEndtimePriorToStartTime.Value || IsEndtimePriorToStartTime.Value)
            {
                throw new ArgumentOutOfRangeException("Endtime can't be prior to Starttime!");
            }

            if (timePeriod.EndTime.Value < StartTime.Value)
            {
                return new OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.EndsBefore);
            }

            if (timePeriod.StartTime.Value >= EndTime.Value)
            {
                return new OverlappingTimeInfo(0, 0, TimeSpanOverlappingTypes.StartsAfter);
            }

            if (timePeriod.StartTime.Value >= StartTime.Value && timePeriod.EndTime.Value <= EndTime.Value)
            {
                var tmpTotalInnerMinutes = (timePeriod.EndTime.Value - timePeriod.StartTime.Value).TotalMinutes;
                return new OverlappingTimeInfo(
                    tmpTotalInnerMinutes,
                    (EndTime.Value - StartTime.Value).TotalMinutes - tmpTotalInnerMinutes,
                    TimeSpanOverlappingTypes.IsInside);
            }

            if (timePeriod.StartTime.Value >= StartTime.Value && timePeriod.StartTime.Value <= EndTime.Value)
            {
                var tmpOverlappingMinutes = (EndTime.Value - timePeriod.StartTime.Value).TotalMinutes;
                return new OverlappingTimeInfo(
                    tmpOverlappingMinutes,
                    (timePeriod.EndTime.Value - EndTime.Value).TotalMinutes,
                    TimeSpanOverlappingTypes.StartsInside);
            }

            if (timePeriod.EndTime.Value <= EndTime.Value && timePeriod.EndTime.Value >= StartTime.Value)
            {
                var tmpOverlappingMinutes = (timePeriod.EndTime.Value - StartTime.Value).TotalMinutes;
                return new OverlappingTimeInfo(
                    tmpOverlappingMinutes,
                    (StartTime.Value - timePeriod.StartTime.Value).TotalMinutes,
                    TimeSpanOverlappingTypes.EndsInside);
            }

            if (timePeriod.StartTime.Value < StartTime.Value && timePeriod.EndTime.Value > EndTime.Value)
            {
                var tmpTotalInnerMinutes = (EndTime.Value - StartTime.Value).TotalMinutes;
                return new OverlappingTimeInfo(
                    tmpTotalInnerMinutes,
                    (timePeriod.EndTime.Value - timePeriod.StartTime.Value).TotalMinutes - tmpTotalInnerMinutes,
                    TimeSpanOverlappingTypes.IncludesCompletely);
            }

            throw new ArgumentException("This case schouldn't actually get reached! :-)");
        }

        public int CompareTo(object obj)
        {
            if (!(obj is TimeSpan) && !(obj is TimePeriodComparer))
            {
                throw new ArgumentException("Argument must be of type Nullable<System.TimeSpan> or EventTimeSpan", "obj");
            }

            TimeSpan? tmpTimeSpan;
            if (obj is TimeSpan)
            {
                tmpTimeSpan = (TimeSpan)obj;
            }
            else
            {
                tmpTimeSpan = ((TimePeriodComparer)obj).TimeSpan;
            }

            if (tmpTimeSpan.HasValue && TimeSpan.HasValue)
            {
                return TimeSpan.Value.CompareTo(tmpTimeSpan.Value);
            }

            if (TimeSpan.HasValue && !tmpTimeSpan.HasValue)
            {
                return 1;
            }

            if (!TimeSpan.HasValue && tmpTimeSpan.HasValue)
            {
                return -1;
            }

            return 0;
        }

        private DateTime? myStartTime;
        public DateTime? StartTime
        {
            get { return myStartTime; }
            set { myStartTime = value; }
        }

        private DateTime? myEndTime;
        public DateTime? EndTime
        {
            get { return myEndTime; }
            set { myEndTime = value; }
        }

        private object myTag;
        public object Tag
        {
            get { return myTag; }
            set { myTag = value; }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public struct OverlappingTimeInfo
    {
        private double myOverlappingMinutes;
        private double myNonOverlappingMinutes;
        private TimeSpanOverlappingTypes myTimeSpanOverlappingType;
        private object myTag;

        public OverlappingTimeInfo(double overlappingMinutes, double nonOverlappingMinutes, TimeSpanOverlappingTypes timeSpanOverlappingType)
        {
            myOverlappingMinutes = overlappingMinutes;
            myNonOverlappingMinutes = nonOverlappingMinutes;
            myTimeSpanOverlappingType = timeSpanOverlappingType;
            myTag = null;
        }

        public double OverlappingMinutes
        {
            get { return myOverlappingMinutes; }
            set { myOverlappingMinutes = value; }
        }

        public double NonOverlappingMinutes
        {
            get { return myNonOverlappingMinutes; }
            set { myNonOverlappingMinutes = value; }
        }

        public TimeSpanOverlappingTypes TimeSpanOverlappingType
        {
            get { return myTimeSpanOverlappingType; }
            set { myTimeSpanOverlappingType = value; }
        }

        public object Tag
        {
            get { return myTag; }
            set { myTag = value; }
        }

        public override string ToString()
        {
            return string.Format(
                "Overlapping:{0:#,##0}min;Nonoverlapping:{1:#,##0}min,Type:{2]",
                OverlappingMinutes,
                NonOverlappingMinutes,
                TimeSpanOverlappingType);
        }
    }

    public enum TimeSpanOverlappingTypes
    {
        NotDefinable,
        EndsBefore,
        StartsAfter,
        IncludesCompletely,
        IsInside,
        EndsInside,
        StartsInside,
        OpenStart,
        OpenEnd
    }
}
