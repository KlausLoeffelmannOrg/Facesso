using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class WorkGroupInfo : InfoItemBase
    {
        private int myIDWorkGroup;
        private int myIDSubsidiary;
        private int myIDCostCenter;
        private int myIDWorkGroupInternal;
        private bool myIsCurrent;
        private int myWorkGroupNumber;
        private string myWorkGroupName;
        private ADDBNullable<string> myWorkGroupDescription;
        private bool myIsActive;
        private bool myIsPeaceWork;
        private bool myIsConceptional;
        private int myOrdinalNo;
        private TimeSettingDetails myTimeSettingDetails;
        private double myWorkloadIWT;
        private DateTime myWasCurrentFrom;
        private DateTime myWasCurrentTo;

        private int myCostCenterNo;
        private string myCostCenterName;
        private string myIncentiveIndicatorSynonym;
        private string myIncentiveIndicatorDimension;
        private byte myIncentiveIndicatorPrecision;
        private double myIncentiveIndicatorFactor;
        private byte myBaseValuePrecision;
        private string myBaseValueSynonym;

        private bool myHasProductionData;
        private double myCurrentDegreeOfTime;

        public WorkGroupInfo() { }

        public WorkGroupInfo(SqlDataReader dr)
        {
            IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDWorkGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWorkGroupInternal"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            WorkGroupNumber = dr.GetInt32(dr.GetOrdinal("WorkGroupNumber"));
            WorkGroupName = dr.GetString(dr.GetOrdinal("WorkGroupName"));
            WorkGroupDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("WorkGroupDescription")));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            IsPeaceWork = dr.GetBoolean(dr.GetOrdinal("IsPeaceWork"));
            IsConceptional = dr.GetBoolean(dr.GetOrdinal("IsConceptional"));
            OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNo"));
            TimeSettingDetails = TimeSettingDetails.FromXmlString(dr.GetString(dr.GetOrdinal("TimeSettingDetails")));
            WorkloadIWT = dr.GetDouble(dr.GetOrdinal("WorkloadIWT"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
        }

        public WorkGroupInfo(bool initializeDefaultsOnly)
        {
            IDCostCenter = SPAccess.GetInstance().GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter;
            IsActive = true;
            IsPeaceWork = false;
            myTimeSettingDetails = (TimeSettingDetails)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem(
                "GlobalTimeSettingDetailsTemplate",
                new TimeSettingDetails(
                    new DateTime(2003, 1, 1, 6, 0, 0),
                    new DateTime(2003, 1, 1, 14, 0, 0),
                    new DateTime(2003, 1, 1, 22, 0, 0),
                    new DateTime(2003, 1, 2, 5, 0, 0),
                    null, null, 30));
        }

        public WorkGroupInfo(SqlDataReader dr, WorkGroupInfoItemsGetType wgiGetType)
        {
            IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDWorkGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWorkGroupInternal"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            WorkGroupNumber = dr.GetInt32(dr.GetOrdinal("WorkGroupNumber"));
            WorkGroupName = dr.GetString(dr.GetOrdinal("WorkGroupName"));
            WorkGroupDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("WorkGroupDescription")));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            IsPeaceWork = dr.GetBoolean(dr.GetOrdinal("IsPeaceWork"));
            IsConceptional = dr.GetBoolean(dr.GetOrdinal("IsConceptional"));
            WorkloadIWT = dr.GetDouble(dr.GetOrdinal("WorkloadIWT"));
            OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNo"));
            TimeSettingDetails = TimeSettingDetails.FromXmlString(dr.GetString(dr.GetOrdinal("TimeSettingDetails")));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));

            if ((wgiGetType & WorkGroupInfoItemsGetType.JoinedWithCostCenter) == WorkGroupInfoItemsGetType.JoinedWithCostCenter)
            {
                myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"));
                myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"));
                myIncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"));
                myIncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"));
                myIncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"));
                myIncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"));
                myBaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"));
                myBaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"));
            }

            if ((wgiGetType & WorkGroupInfoItemsGetType.IncludeProductionDataStatus) == WorkGroupInfoItemsGetType.IncludeProductionDataStatus)
            {
                myHasProductionData = dr.GetBoolean(dr.GetOrdinal("HasProductionData"));
            }
        }

        public static bool operator ==(WorkGroupInfo val1, WorkGroupInfo val2)
        {
            if (ReferenceEquals(val1, null) && ReferenceEquals(val2, null)) return true;
            if (ReferenceEquals(val1, null) || ReferenceEquals(val2, null)) return false;
            return val1.IDWorkGroup == val2.IDWorkGroup;
        }

        public static bool operator !=(WorkGroupInfo val1, WorkGroupInfo val2)
        {
            return !(val1 == val2);
        }

        public override bool Equals(object obj) => obj is WorkGroupInfo wgi && wgi.IDWorkGroup == IDWorkGroup;
        public override int GetHashCode() => IDWorkGroup.GetHashCode();

        public static WorkGroupInfo FromID(int idSubsidiary, int idWorkgroup)
        {
            return SPAccess.GetInstance().GetWorkGroup(idSubsidiary, idWorkgroup);
        }

        public static WorkGroupInfo FromWorkGroupNumber(int idSubsidiary, int workGroupNumber)
        {
            return SPAccess.GetInstance().GetWorkGroupByWorkGroupNumber(idSubsidiary, workGroupNumber);
        }

        public virtual int IDWorkGroup
        {
            get { return myIDWorkGroup; }
            set { myIDWorkGroup = value; }
        }

        public virtual int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public virtual int IDWorkGroupInternal
        {
            get { return myIDWorkGroupInternal; }
            set { myIDWorkGroupInternal = value; }
        }

        public virtual int IDCostCenter
        {
            get { return myIDCostCenter; }
            set { myIDCostCenter = value; }
        }

        public virtual bool HasProductionData => myHasProductionData;

        [ADAutoReportColumn("Produktiv-Site-Nr.", -2, 1)]
        public virtual int WorkGroupNumber
        {
            get { return myWorkGroupNumber; }
            set { myWorkGroupNumber = value; }
        }

        [ADAutoReportColumn("Produktiv-Site-Name:", -1, 2)]
        public virtual string WorkGroupName
        {
            get { return myWorkGroupName; }
            set { myWorkGroupName = value; }
        }

        public virtual ADDBNullable<string> WorkGroupDescription
        {
            get { return myWorkGroupDescription; }
            set { myWorkGroupDescription = value; }
        }

        public virtual bool IsCurrent
        {
            get { return myIsCurrent; }
            set { myIsCurrent = value; }
        }

        public virtual bool IsActive
        {
            get { return myIsActive; }
            set { myIsActive = value; }
        }

        public virtual bool IsPeaceWork
        {
            get { return myIsPeaceWork; }
            set { myIsPeaceWork = value; }
        }

        public virtual bool IsConceptional
        {
            get { return myIsConceptional; }
            set { myIsConceptional = value; }
        }

        public virtual int OrdinalNo
        {
            get { return myOrdinalNo; }
            set { myOrdinalNo = value; }
        }

        public virtual double WorkloadIWT
        {
            get { return myWorkloadIWT; }
            set { myWorkloadIWT = value; }
        }

        public virtual TimeSettingDetails TimeSettingDetails
        {
            get { return myTimeSettingDetails; }
            set { myTimeSettingDetails = value; }
        }

        public virtual DateTime WasCurrentFrom
        {
            get { return myWasCurrentFrom; }
            set { myWasCurrentFrom = value; }
        }

        public virtual DateTime WasCurrentTo
        {
            get { return myWasCurrentTo; }
            set { myWasCurrentTo = value; }
        }

        public override int DataID => myIDWorkGroup;

        public override string DisplayName => WorkGroupName;

        public string ListItemText => WorkGroupNumber.ToString("000000") + ": " + WorkGroupName;

        public virtual int CostCenterNo => myCostCenterNo;

        public virtual string CostCenterName => myCostCenterName;

        public string IncentiveIndicatorSynonym => myIncentiveIndicatorSynonym;

        public string IncentiveIndicatorDimension => myIncentiveIndicatorDimension;

        public byte IncentiveIndicatorPrecision => myIncentiveIndicatorPrecision;

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

        public string BaseValueSynonym => myBaseValueSynonym;

        public byte BaseValuePrecision => myBaseValuePrecision;

        public virtual string BaseValueFormatString
        {
            get
            {
                string locFormat = "#,##0";
                if (BaseValuePrecision > 0)
                    locFormat += "." + new string('0', BaseValuePrecision);
                return locFormat;
            }
        }

        public double CurrentDegreeOfTime
        {
            get { return myCurrentDegreeOfTime; }
            set { myCurrentDegreeOfTime = value; }
        }

        public override string ToString()
        {
            return WorkGroupNumber + ": " + WorkGroupName + (HasProductionData ? " (D)" : "");
        }
    }

    [System.CLSCompliant(true)]
    public class WorkGroupInfoItems : InfoItems<WorkGroupInfo>
    {
        public WorkGroupInfoItems() : base() { }

        public WorkGroupInfoItems(bool joinedWithCostCenter) : base()
        {
            if (joinedWithCostCenter)
                SPAccess.GetInstance().GetWorkGroupInfoCollection(null, this, WorkGroupInfoItemsGetType.JoinedWithCostCenter);
            else
                SPAccess.GetInstance().GetWorkGroupInfoCollection(null, this, WorkGroupInfoItemsGetType.None);
        }

        public WorkGroupInfoItems(CombinedParametersInfo combinedParameters)
        {
            SPAccess.GetInstance().GetWorkGroupInfoCollection(combinedParameters, this,
                WorkGroupInfoItemsGetType.IncludeProductionDataStatus | WorkGroupInfoItemsGetType.JoinedWithCostCenter);
        }

        public WorkGroupInfo GetByWorkGroupNumber(int workGroupNumber)
        {
            foreach (WorkGroupInfo locItem in this)
            {
                if (locItem.WorkGroupNumber == workGroupNumber)
                    return locItem;
            }
            throw new FacessoGenericApplicationException("The requested WorkGroupNumber could not be found in the WorkGroupCollection!", null);
        }
    }

    public enum WorkGroupInfoItemsGetType
    {
        None = 0,
        JoinedWithCostCenter = 1,
        IncludeProductionDataStatus = 2
    }
}
