using System;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class EmployeeInfo : InfoItemBase
    {
        protected internal int myIDEmployee;
        protected internal int myIDSubsidiary;
        protected internal int myIDEmployeeInternal;
        protected internal int myIDCostCenter;
        protected internal ADDBNullable<int> myIDWageGroup;
        protected internal bool myUseFixedWage;
        protected internal ADDBNullable<double> myFixedWage;
        protected internal int myIDAddressDetails;
        protected internal string myLastName;
        protected internal string myFirstName;
        protected internal ADDBNullable<string> myMatchcode;
        protected internal int myPersonnelNumber;
        protected internal bool myIsCurrent;
        protected internal bool myIsActive;
        protected internal bool myIsIncentive;
        protected internal DateTime myWasCurrentFrom;
        protected internal DateTime myWasCurrentTo;
        protected internal ADDBNullable<DateTime> myDateOfBirth;
        protected internal ADDBNullable<DateTime> myDateOfJoining;
        protected internal ADDBNullable<DateTime> myDateOfSeparation;
        protected internal ADDBNullable<string> myTimeCardNo;
        protected internal ADDBNullable<string> myComment;

        protected internal int myCostCenterNo;
        protected internal string myCostCenterName;

        public EmployeeInfo() { }

        public EmployeeInfo(SqlDataReader dr)
        {
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDEmployeeInternal = dr.GetInt32(dr.GetOrdinal("IDEmployeeInternal"));
            IDEmployee = dr.GetInt32(dr.GetOrdinal("IDEmployee"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"));
            UseFixedWage = dr.GetBoolean(dr.GetOrdinal("UseFixedWage"));
            FixedWage = ADDBNullable.FromObject<double>(dr.GetValue(dr.GetOrdinal("FixedWage")));
            IDAddressDetails = dr.GetInt32(dr.GetOrdinal("IDAddressDetails"));
            LastName = dr.GetString(dr.GetOrdinal("LastName"));
            FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
            Matchcode = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Matchcode")));
            PersonnelNumber = dr.GetInt32(dr.GetOrdinal("PersonnelNumber"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsIncentive = dr.GetBoolean(dr.GetOrdinal("IsIncentive"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
            DateOfBirth = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfBirth")));
            DateOfJoining = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfJoining")));
            DateOfSeparation = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfSeparation")));
            TimeCardNo = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("TimeCardNo")));
            Comment = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Comment")));
        }

        public EmployeeInfo(SqlDataReader dr, bool joinedWithCostCenter)
        {
            IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"));
            IDEmployeeInternal = dr.GetInt32(dr.GetOrdinal("IDEmployeeInternal"));
            IDEmployee = dr.GetInt32(dr.GetOrdinal("IDEmployee"));
            IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"));
            IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"));
            UseFixedWage = dr.GetBoolean(dr.GetOrdinal("UseFixedWage"));
            FixedWage = ADDBNullable.FromObject<double>(dr.GetValue(dr.GetOrdinal("FixedWage")));
            IDAddressDetails = dr.GetInt32(dr.GetOrdinal("IDAddressDetails"));
            LastName = dr.GetString(dr.GetOrdinal("LastName"));
            FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
            Matchcode = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Matchcode")));
            PersonnelNumber = dr.GetInt32(dr.GetOrdinal("PersonnelNumber"));
            IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"));
            IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
            IsIncentive = dr.GetBoolean(dr.GetOrdinal("IsIncentive"));
            WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"));
            WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"));
            DateOfBirth = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfBirth")));
            DateOfJoining = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfJoining")));
            DateOfSeparation = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("DateOfSeparation")));
            TimeCardNo = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("TimeCardNo")));
            Comment = ADDBNullable.FromObject<string>(dr.GetValue(dr.GetOrdinal("Comment")));

            myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"));
            myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"));
        }

        public int IDEmployee
        {
            get { return myIDEmployee; }
            set { myIDEmployee = value; }
        }

        public int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public int IDEmployeeInternal
        {
            get { return myIDEmployeeInternal; }
            set { myIDEmployeeInternal = value; }
        }

        public int IDCostCenter
        {
            get { return myIDCostCenter; }
            set { myIDCostCenter = value; }
        }

        public ADDBNullable<int> IDWageGroup
        {
            get { return myIDWageGroup; }
            set { myIDWageGroup = value; }
        }

        public bool UseFixedWage
        {
            get { return myUseFixedWage; }
            set { myUseFixedWage = value; }
        }

        public ADDBNullable<double> FixedWage
        {
            get { return myFixedWage; }
            set { myFixedWage = value; }
        }

        public int IDAddressDetails
        {
            get { return myIDAddressDetails; }
            set { myIDAddressDetails = value; }
        }

        [ADAutoReportColumn("Nachname", -1, 2)]
        public string LastName
        {
            get { return myLastName; }
            set { myLastName = value; }
        }

        [ADAutoReportColumn("Vorname", -1, 3)]
        public string FirstName
        {
            get { return myFirstName; }
            set { myFirstName = value; }
        }

        public ADDBNullable<string> Matchcode
        {
            get { return myMatchcode; }
            set { myMatchcode = value; }
        }

        [ADAutoReportColumn("Personalnr.", -2, 1)]
        public int PersonnelNumber
        {
            get { return myPersonnelNumber; }
            set { myPersonnelNumber = value; }
        }

        public bool IsCurrent
        {
            get { return myIsCurrent; }
            set { myIsCurrent = value; }
        }

        public bool IsActive
        {
            get { return myIsActive; }
            set { myIsActive = value; }
        }

        public bool IsIncentive
        {
            get { return myIsIncentive; }
            set { myIsIncentive = value; }
        }

        public DateTime WasCurrentFrom
        {
            get { return myWasCurrentFrom; }
            set { myWasCurrentFrom = value; }
        }

        public DateTime WasCurrentTo
        {
            get { return myWasCurrentTo; }
            set { myWasCurrentTo = value; }
        }

        public ADDBNullable<DateTime> DateOfBirth
        {
            get { return myDateOfBirth; }
            set { myDateOfBirth = value; }
        }

        public ADDBNullable<DateTime> DateOfJoining
        {
            get { return myDateOfJoining; }
            set { myDateOfJoining = value; }
        }

        public ADDBNullable<DateTime> DateOfSeparation
        {
            get { return myDateOfSeparation; }
            set { myDateOfSeparation = value; }
        }

        [ADAutoReportColumn("Karten-Nr.:", -2, 4)]
        public ADDBNullable<string> TimeCardNo
        {
            get { return myTimeCardNo; }
            set { myTimeCardNo = value; }
        }

        public ADDBNullable<string> Comment
        {
            get { return myComment; }
            set { myComment = value; }
        }

        public override int DataID => myIDEmployee;

        public override string DisplayName => PersonnelNumber.ToString() + ": " + LastName.ToString() + ", " + FirstName.ToString();

        public virtual int CostCenterNo => myCostCenterNo;

        public virtual string CostCenterName => myCostCenterName;

        public EmployeeInfo Clone()
        {
            var locEInfo = new EmployeeInfo();
            locEInfo.myComment = this.Comment;
            locEInfo.myCostCenterName = this.CostCenterName;
            locEInfo.myCostCenterNo = this.CostCenterNo;
            locEInfo.myDateOfBirth = this.DateOfBirth;
            locEInfo.myDateOfJoining = this.DateOfJoining;
            locEInfo.myDateOfSeparation = this.DateOfSeparation;
            locEInfo.myFirstName = this.FirstName;
            locEInfo.myFixedWage = this.FixedWage;
            locEInfo.myIDAddressDetails = this.IDAddressDetails;
            locEInfo.myIDCostCenter = this.IDCostCenter;
            locEInfo.myIDEmployee = this.IDEmployee;
            locEInfo.myIDEmployeeInternal = this.IDEmployeeInternal;
            locEInfo.myIDSubsidiary = this.IDSubsidiary;
            locEInfo.myIDWageGroup = this.IDWageGroup;
            locEInfo.myIsActive = this.IsActive;
            locEInfo.myIsCurrent = this.IsCurrent;
            locEInfo.myIsIncentive = this.IsIncentive;
            locEInfo.myLastName = this.LastName;
            locEInfo.myMatchcode = this.Matchcode;
            locEInfo.myPersonnelNumber = this.PersonnelNumber;
            locEInfo.myTimeCardNo = this.TimeCardNo;
            locEInfo.myUseFixedWage = this.UseFixedWage;
            locEInfo.myWasCurrentFrom = this.WasCurrentFrom;
            locEInfo.myWasCurrentTo = this.WasCurrentTo;
            return locEInfo;
        }
    }

    [System.CLSCompliant(true)]
    public class EmployeeInfoItems : InfoItems<EmployeeInfo>
    {
        public EmployeeInfoItems() : base() { }

        public EmployeeInfoItems(int idCostCenter) : this()
        {
            SqlConnection locConnection = SPAccess.GetInstance().GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCommand = new SqlCommand(SPAccess.GetInstance().EmployeeInfoCollectionCommandString(), locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        var locEmployeeInfo = new EmployeeInfo(locDR, true);
                        this.Add(locEmployeeInfo);
                    }
                }
            }
        }

        public EmployeeInfoItems(string orderByString) : this()
        {
            SqlConnection locConnection = SPAccess.GetInstance().GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCommand = new SqlCommand(SPAccess.GetInstance().EmployeeInfoCollectionCommandString(orderByString), locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        var locEmployeeInfo = new EmployeeInfo(locDR, true);
                        this.Add(locEmployeeInfo);
                    }
                }
            }
        }

        public EmployeeInfoItems(CombinedParametersInfo combinedParameters) : this()
        {
            SPAccess.GetInstance().Employees_GetInWorkGroupOnShiftDate(combinedParameters, this);
        }

        public EmployeeInfo GetByPersonnelNumber(int personnelNumber)
        {
            foreach (EmployeeInfo locItem in this)
            {
                if (locItem.PersonnelNumber == personnelNumber)
                    return locItem;
            }
            throw new FacessoGenericApplicationException("The requested PersonnelNumber could not be found in the EmployeeInfoCollection!", null);
        }
    }
}
