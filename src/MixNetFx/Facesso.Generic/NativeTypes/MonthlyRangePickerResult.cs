using System;

namespace Facesso
{
    public class MonthRangePickerResult
    {
        private MonthRangeBase myRangeBase;
        private RelatedMonth myMonthBase;
        private DateTime myFromDate;
        private DateTime myToDate;

        public MonthRangePickerResult() { }

        public MonthRangePickerResult(MonthRangeBase rangeBase, RelatedMonth monthBase)
        {
            myRangeBase = rangeBase;
            myMonthBase = monthBase;
            SetDateInternal();
        }

        private void SetDateInternal()
        {
            DateTime currentDate = DateTime.Now.AddMonths(-1);
            if (RelatedMonth == RelatedMonth.PreviousMonth)
                currentDate = currentDate.AddMonths(-1);
            else if (RelatedMonth == RelatedMonth.SecondLastMonth)
                currentDate = currentDate.AddMonths(-2);

            myFromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            if (MonthRangeBase == MonthRangeBase.FirstToLastPrevious)
                myToDate = myFromDate.AddMonths(1).AddDays(-1);
            else if (MonthRangeBase == MonthRangeBase.FirstToLastCurrent)
            {
                myFromDate = myFromDate.AddMonths(1);
                myToDate = myFromDate.AddMonths(1).AddDays(-1);
            }
            else if (MonthRangeBase == MonthRangeBase.FifteenthToFourteenth)
            {
                myFromDate = myFromDate.AddDays(14);
                myToDate = myFromDate.AddMonths(1).AddDays(-1);
            }
            else if (MonthRangeBase == MonthRangeBase.TenthToNinth)
            {
                myFromDate = myFromDate.AddDays(9);
                myToDate = myFromDate.AddMonths(1).AddDays(-1);
            }
            else if (MonthRangeBase == MonthRangeBase.TwentiethToNineteenth)
            {
                myFromDate = myFromDate.AddDays(19);
                myToDate = myFromDate.AddMonths(1).AddDays(-1);
            }
        }

        public MonthRangeBase MonthRangeBase
        {
            get { return myRangeBase; }
            set { myRangeBase = value; SetDateInternal(); }
        }

        public RelatedMonth RelatedMonth
        {
            get { return myMonthBase; }
            set { myMonthBase = value; SetDateInternal(); }
        }

        public DateTime ToDate
        {
            get { return myToDate; }
            set { myToDate = value; }
        }

        public DateTime FromDate
        {
            get { return myFromDate; }
            set { myFromDate = value; }
        }
    }

    public enum MonthRangeBase
    {
        FirstToLastPrevious,
        FirstToLastCurrent,
        TenthToNinth,
        FifteenthToFourteenth,
        TwentiethToNineteenth
    }

    public enum RelatedMonth
    {
        CurrentMonth,
        PreviousMonth,
        SecondLastMonth
    }
}
