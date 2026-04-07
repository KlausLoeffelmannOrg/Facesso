using System;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class LabourValueInfo : InfoItemBase
    {
        private int myIDLabourValue;
        private int myIDSubsidiary;
        private int myIDCostCenter;
        private int myIDLabourValueInternal;
        private int myLabourValueNumber;
        private string myLabourValueName;
        private ADDBNullable<string> myLabourValueDescription;
        private double myTe;
        private string myDimension;
        private bool myIsActive;
        private bool myIsCurrent;
        private DateTime myWasCurrentFrom;
        private DateTime myWasCurrentTo;

        private int myCostCenterNo;
        private string myCostCenterName;
        private string myBaseValueSynonym;
        private byte myBaseValuePrecision;

        public LabourValueInfo() { }

        public LabourValueInfo(SqlDataReader dr)
        {
            IDLabourValue = dr.GetInt32(dr.GetOrdinal("IDLabourValue"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            IDLabourValueInternal = dr.GetInt32(dr.GetOrdinal("IDLabourValueInternal"));
            LabourValueNumber = dr.GetInt32(dr.GetOrdinal("LabourValueNumber"));
            LabourValueName = dr.GetString(dr.GetOrdinal("LabourValueName"));
            LabourValueDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("LabourValueDescription")));
            TeHMin = dr.GetDouble(dr.GetOrdinal("TeHMin"));
            Dimension = dr.GetString(dr.GetOrdinal("Dimension"));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
        }

        public LabourValueInfo(SqlDataReader dr, bool joinedWithCostCenter)
        {
            IDLabourValue = dr.GetInt32(dr.GetOrdinal("IDLabourValue"));
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            IDLabourValueInternal = dr.GetInt32(dr.GetOrdinal("IDLabourValueInternal"));
            LabourValueNumber = dr.GetInt32(dr.GetOrdinal("LabourValueNumber"));
            LabourValueName = dr.GetString(dr.GetOrdinal("LabourValueName"));
            LabourValueDescription = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("LabourValueDescription")));
            TeHMin = dr.GetDouble(dr.GetOrdinal("TeHMin"));
            Dimension = dr.GetString(dr.GetOrdinal("Dimension"));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));

            myBaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"));
            myBaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"));
            myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"));
            myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"));
        }

        public virtual int IDLabourValue
        {
            get { return myIDLabourValue; }
            set { myIDLabourValue = value; }
        }

        public virtual int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public virtual int IDCostCenter
        {
            get { return myIDCostCenter; }
            set { myIDCostCenter = value; }
        }

        public virtual int IDLabourValueInternal
        {
            get { return myIDLabourValueInternal; }
            set { myIDLabourValueInternal = value; }
        }

        [ADAutoReportColumn("Arbeitswert-Nr.", -2, 1)]
        public virtual int LabourValueNumber
        {
            get { return myLabourValueNumber; }
            set { myLabourValueNumber = value; }
        }

        [ADAutoReportColumn("Arbeitswertname", -1, 2)]
        public virtual string LabourValueName
        {
            get { return myLabourValueName; }
            set { myLabourValueName = value; }
        }

        public virtual ADDBNullable<string> LabourValueDescription
        {
            get { return myLabourValueDescription; }
            set { myLabourValueDescription = value; }
        }

        [ADAutoReportColumn("te (in H/Min)", -2, 3)]
        public virtual double TeHMin
        {
            get { return myTe; }
            set { myTe = value; }
        }

        [ADAutoReportColumn("Einheit (Dimension):", -2, 4)]
        public virtual string Dimension
        {
            get { return myDimension; }
            set { myDimension = value; }
        }

        public virtual bool IsActive
        {
            get { return myIsActive; }
            set { myIsActive = value; }
        }

        public virtual bool IsCurrent
        {
            get { return myIsCurrent; }
            set { myIsCurrent = value; }
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

        public override int DataID => myIDLabourValue;

        public override string DisplayName => LabourValueName;

        public string ListItemText => LabourValueNumber.ToString("000000") + ": " + LabourValueName;

        public virtual int CostCenterNo => myCostCenterNo;

        public virtual string CostCenterName => myCostCenterName;

        public virtual byte BaseValuePrecision => myBaseValuePrecision;

        public virtual string BaseValueSynonym => myBaseValueSynonym;
    }

    [System.CLSCompliant(true)]
    public class LabourValueInfoCollection : InfoItems<LabourValueInfo>
    {
        public LabourValueInfoCollection() : base() { }

        public LabourValueInfo GetByLabourValueNumber(int labourValueNumber)
        {
            foreach (LabourValueInfo locItem in this)
            {
                if (locItem.LabourValueNumber == labourValueNumber)
                    return locItem;
            }
            throw new FacessoGenericApplicationException("The requested LabourValueNumber could not be found in the LabourValueInfoCollection!", null);
        }

        public static LabourValueInfoCollection GetWorkGroupAssignedLabourValues(int idSubsidiary, WorkGroupInfo workgroup)
        {
            return SPAccess.GetInstance().WorkGroups_GetAssignedLabourValues(idSubsidiary, workgroup.IDWorkGroup);
        }
    }
}
