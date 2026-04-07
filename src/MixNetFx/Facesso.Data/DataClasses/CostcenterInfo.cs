using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class CostcenterInfo : InfoItemBase
    {
        private int myIDCostCenter;
        private int myIDSubsidiary;
        private int myIDCostCenterInternal;
        private bool myIsCurrent;
        private int myCostCenterNo;
        private string myCostCenterName;
        private ADDBNullable<string> myCostCenterDescription;
        private int myIDCurrency;
        private string myCurrencyToken;
        private string myIncentiveIndicatorSynonym;
        private string myIncentiveWageSynonym;
        private string myIncentiveIndicatorDimension;
        private byte myIncentiveIndicatorPrecision;
        private byte myBaseValuePrecision;
        private string myBaseValueSynonym;
        private bool myUseFixValuedBonus;
        private double myIncentiveIndicatorFactor;
        private System.DateTime myWasCurrentFrom;
        private System.DateTime myWasCurrentTo;

        public CostcenterInfo() { }

        public CostcenterInfo(SqlDataReader dr)
        {
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDCostCenterInternal = dr.GetInt32(dr.GetOrdinal("IDCostcenterInternal"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            CostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"));
            CostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"));
            CostCenterDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("CostcenterDescription")));
            IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"));
            IncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"));
            IncentiveWageSynonym = dr.GetString(dr.GetOrdinal("IncentiveWageSynonym"));
            IncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"));
            IncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"));
            UseFixValuedBonus = dr.GetBoolean(dr.GetOrdinal("UseFixValuedBonus"));
            IncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"));
            BaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"));
            BaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
        }

        public CostcenterInfo(SqlDataReader dr, bool joinedWithCurrency)
        {
            IDCostCenter = ADDBNullable.FromObject<int>(dr.GetValue(dr.GetOrdinal("IDCostCenter")));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDCostCenterInternal = dr.GetInt32(dr.GetOrdinal("IDCostcenterInternal"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            CostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"));
            CostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"));
            CostCenterDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("CostcenterDescription")));
            IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"));
            CurrencyToken = dr.GetString(dr.GetOrdinal("CurrencyToken"));
            IncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"));
            IncentiveWageSynonym = dr.GetString(dr.GetOrdinal("IncentiveWageSynonym"));
            IncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"));
            IncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"));
            UseFixValuedBonus = dr.GetBoolean(dr.GetOrdinal("UseFixValuedBonus"));
            IncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"));
            BaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"));
            BaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
        }

        public virtual int IDCostCenter
        {
            get { return myIDCostCenter; }
            set { myIDCostCenter = value; }
        }

        public virtual int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public virtual int IDCostCenterInternal
        {
            get { return myIDCostCenterInternal; }
            set { myIDCostCenterInternal = value; }
        }

        public virtual bool IsCurrent
        {
            get { return myIsCurrent; }
            set { myIsCurrent = value; }
        }

        [ADAutoReportColumn("Kostenstellen-Nr.", -2, 1)]
        public virtual int CostCenterNo
        {
            get { return myCostCenterNo; }
            set { myCostCenterNo = value; }
        }

        [ADAutoReportColumn("Kostenstellenname", -1, 2)]
        public virtual string CostCenterName
        {
            get { return myCostCenterName; }
            set { myCostCenterName = value; }
        }

        public virtual ADDBNullable<string> CostCenterDescription
        {
            get { return myCostCenterDescription; }
            set { myCostCenterDescription = value; }
        }

        public virtual int IDCurrency
        {
            get { return myIDCurrency; }
            set { myIDCurrency = value; }
        }

        [ADAutoReportColumn("Währung", -2, 4)]
        public virtual string CurrencyToken
        {
            get { return myCurrencyToken; }
            set { myCurrencyToken = value; }
        }

        [ADAutoReportColumn("Leistungsbezeichnung", -2, 5)]
        public virtual string IncentiveIndicatorSynonym
        {
            get { return myIncentiveIndicatorSynonym; }
            set { myIncentiveIndicatorSynonym = value; }
        }

        [ADAutoReportColumn("Vergütungsbezeichnung", -2, 3)]
        public virtual string IncentiveWageSynonym
        {
            get { return myIncentiveWageSynonym; }
            set { myIncentiveWageSynonym = value; }
        }

        [ADAutoReportColumn("Einht.", -2, 6)]
        public virtual string IncentiveIndicatorDimension
        {
            get { return myIncentiveIndicatorDimension; }
            set { myIncentiveIndicatorDimension = value; }
        }

        public virtual byte IncentiveIndicatorPrecision
        {
            get { return myIncentiveIndicatorPrecision; }
            set { myIncentiveIndicatorPrecision = value; }
        }

        public virtual string IncentiveFormatString
        {
            get
            {
                string locFormat = "#,##0";
                if (IncentiveIndicatorPrecision > 0)
                    locFormat += "." + new string('0', IncentiveIndicatorPrecision);
                return locFormat;
            }
        }

        public virtual bool UseFixValuedBonus
        {
            get { return myUseFixValuedBonus; }
            set { myUseFixValuedBonus = value; }
        }

        public virtual double IncentiveIndicatorFactor
        {
            get { return myIncentiveIndicatorFactor; }
            set { myIncentiveIndicatorFactor = value; }
        }

        public virtual byte BaseValuePrecision
        {
            get { return myBaseValuePrecision; }
            set { myBaseValuePrecision = value; }
        }

        public virtual string BaseValueSynonym
        {
            get { return myBaseValueSynonym; }
            set { myBaseValueSynonym = value; }
        }

        public virtual System.DateTime WasCurrentFrom
        {
            get { return myWasCurrentFrom; }
            set { myWasCurrentFrom = value; }
        }

        public virtual System.DateTime WasCurrentTo
        {
            get { return myWasCurrentTo; }
            set { myWasCurrentTo = value; }
        }

        public override int DataID => myIDCostCenter;

        public override string DisplayName => CostCenterName;

        public string ListItemText => CostCenterNo.ToString("000000") + ": " + CostCenterName;

        public override string ToString() => ListItemText;
    }

    [System.CLSCompliant(true)]
    public class CostcenterInfoItems : InfoItems<CostcenterInfo>
    {
        public CostcenterInfoItems() : base() { }

        public static CostcenterInfoItems GetCostCenterInfoItems()
        {
            return SPAccess.GetInstance().CostCenterInfoItems;
        }
    }
}
