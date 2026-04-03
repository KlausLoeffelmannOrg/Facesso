using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class WageGroupInfo : InfoItemBase
    {
        private int myIDWageGroup;
        private int myIDSubsidiary;
        private string myWageGroupName;
        private ADDBNullable<string> myComment;
        private int myIDCurrency;
        private bool myIsTemplate;
        private string myWageGroupToken;
        private double myHourlyRate;
        private string myCurrencyToken;

        public WageGroupInfo() { }

        public WageGroupInfo(SqlDataReader dr)
        {
            IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            WageGroupName = dr.GetString(dr.GetOrdinal("WageGroupName"));
            Comment = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Comment")));
        }

        public WageGroupInfo(SqlDataReader dr, bool joinedWithCurrency)
        {
            IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            WageGroupName = dr.GetString(dr.GetOrdinal("WageGroupName"));
            Comment = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Comment")));
            IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"));
            IsTemplate = dr.GetBoolean(dr.GetOrdinal("IsTemplate"));
            WageGroupToken = dr.GetString(dr.GetOrdinal("WageGroupToken"));
            HourlyRate = dr.GetDouble(dr.GetOrdinal("HourlyRate"));
            if (joinedWithCurrency)
                CurrencyToken = dr.GetString(dr.GetOrdinal("CurrencyToken"));
        }

        public virtual int IDWageGroup
        {
            get { return myIDWageGroup; }
            set { myIDWageGroup = value; }
        }

        public virtual int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public virtual string WageGroupName
        {
            get { return myWageGroupName; }
            set { myWageGroupName = value; }
        }

        public virtual ADDBNullable<string> Comment
        {
            get { return myComment; }
            set { myComment = value; }
        }

        public virtual int IDCurrency
        {
            get { return myIDCurrency; }
            set { myIDCurrency = value; }
        }

        public virtual bool IsTemplate
        {
            get { return myIsTemplate; }
            set { myIsTemplate = value; }
        }

        public virtual string WageGroupToken
        {
            get { return myWageGroupToken; }
            set { myWageGroupToken = value; }
        }

        public virtual double HourlyRate
        {
            get { return myHourlyRate; }
            set { myHourlyRate = value; }
        }

        public virtual string CurrencyToken
        {
            get { return myCurrencyToken; }
            set { myCurrencyToken = value; }
        }

        public override int DataID => myIDWageGroup;

        public override string DisplayName => WageGroupName;
    }

    [System.CLSCompliant(true)]
    public class WageGroupInfoCollection : InfoItems<WageGroupInfo>
    {
        public WageGroupInfoCollection() : base() { }
    }
}
