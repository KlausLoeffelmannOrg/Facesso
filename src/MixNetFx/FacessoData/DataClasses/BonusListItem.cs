using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    public class BonusListItem
    {
        private int myIDBonusList;
        private int myIDSubsidiary;
        private int myIDBonusLists;
        private double myDegreeOfTime;
        private DegreeOfTime myDegreeOfTimeInternal;
        private double myPercentage;
        private decimal myAbsoluteValue;
        private CostcenterInfo myCostCenterInfo;

        public BonusListItem() { }

        public BonusListItem(SqlDataReader dr, CostcenterInfo cci)
        {
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDBonusList = dr.GetInt32(dr.GetOrdinal("IDBonusList"));
            IDBonusLists = dr.GetInt32(dr.GetOrdinal("IDBonusLists"));
            CostCenterInfo = cci;
            DegreeOfTime = (double)dr.GetDecimal(dr.GetOrdinal("DegreeOfTime"));
            Percentage = (double)dr.GetDecimal(dr.GetOrdinal("Percentage"));
            AbsoluteValue = dr.GetDecimal(dr.GetOrdinal("AbsoluteValue"));
        }

        public int IDBonusList
        {
            get { return myIDBonusList; }
            set { myIDBonusList = value; }
        }

        public int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public int IDBonusLists
        {
            get { return myIDBonusLists; }
            set { myIDBonusLists = value; }
        }

        public double DegreeOfTime
        {
            get { return myDegreeOfTime; }
            set
            {
                myDegreeOfTime = value;
                if (myCostCenterInfo != null)
                {
                    myDegreeOfTimeInternal = new DegreeOfTime(value,
                        myCostCenterInfo.IncentiveIndicatorFactor,
                        myCostCenterInfo.IncentiveIndicatorPrecision,
                        myCostCenterInfo.IncentiveIndicatorDimension);
                }
                else
                {
                    myDegreeOfTimeInternal = value;
                }
            }
        }

        public double DegreeOfTimeAligned
        {
            get { return myDegreeOfTimeInternal.Value; }
            set { myDegreeOfTimeInternal.Value = value; }
        }

        public double Percentage
        {
            get { return myPercentage; }
            set { myPercentage = value; }
        }

        public decimal AbsoluteValue
        {
            get { return myAbsoluteValue; }
            set { myAbsoluteValue = value; }
        }

        public string DegreeOfTimeAlignedText
        {
            get { return DegreeOfTimeAligned.ToString() + " " + myCostCenterInfo.IncentiveIndicatorDimension; }
        }

        public CostcenterInfo CostCenterInfo
        {
            get { return myCostCenterInfo; }
            set
            {
                myCostCenterInfo = value;
                myDegreeOfTimeInternal = new DegreeOfTime(myDegreeOfTime,
                    myCostCenterInfo.IncentiveIndicatorFactor,
                    myCostCenterInfo.IncentiveIndicatorPrecision,
                    myCostCenterInfo.IncentiveIndicatorDimension);
            }
        }
    }

    public class BonusListItems : KeyedCollection<int, BonusListItem>
    {
        protected override int GetKeyForItem(BonusListItem item)
        {
            return item.IDBonusList;
        }
    }
}
