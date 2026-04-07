namespace Facesso.Data
{
    public class EmployeeWageInfo : EmployeeInfo
    {
        protected internal double myDegreeOfTime;
        protected internal double myBonusFactor;
        protected internal bool myUseFixValuedBonus;
        protected internal double myPercentage;
        protected internal double myAbsoluteValue;
        protected internal double myIncentiveWageTime;
        protected internal double myBaseWage;
        protected internal double myTotalIncentiveWage;

        public EmployeeWageInfo(EmployeeInfo employee, double degreeOfTime, double incentiveWageTime)
        {
            this.myComment = employee.Comment;
            this.myCostCenterName = employee.CostCenterName;
            this.myCostCenterNo = employee.CostCenterNo;
            this.myDateOfBirth = employee.DateOfBirth;
            this.myDateOfJoining = employee.DateOfJoining;
            this.myDateOfSeparation = employee.DateOfSeparation;
            this.myFirstName = employee.FirstName;
            this.myFixedWage = employee.FixedWage;
            this.myIDAddressDetails = employee.IDAddressDetails;
            this.myIDCostCenter = employee.IDCostCenter;
            this.myIDEmployee = employee.IDEmployee;
            this.myIDEmployeeInternal = employee.IDEmployeeInternal;
            this.myIDSubsidiary = employee.IDSubsidiary;
            this.myIDWageGroup = employee.IDWageGroup;
            this.myIsActive = employee.IsActive;
            this.myIsCurrent = employee.IsCurrent;
            this.myIsIncentive = employee.IsIncentive;
            this.myLastName = employee.LastName;
            this.myMatchcode = employee.Matchcode;
            this.myPersonnelNumber = employee.PersonnelNumber;
            this.myTimeCardNo = employee.TimeCardNo;
            this.myUseFixedWage = employee.UseFixedWage;
            this.myWasCurrentFrom = employee.WasCurrentFrom;
            this.myWasCurrentTo = employee.WasCurrentTo;

            myDegreeOfTime = degreeOfTime;
            myIncentiveWageTime = incentiveWageTime;
            if (incentiveWageTime == 0)
            {
                myDegreeOfTime = -1;
                myTotalIncentiveWage = -1;
            }
            else
            {
                LookUpWageDataInternal();
            }
        }

        public double DegreeOfTime
        {
            get { return myDegreeOfTime; }
            set { myDegreeOfTime = value; }
        }

        public double IncentiveWageTime
        {
            get { return myIncentiveWageTime; }
            set { myIncentiveWageTime = value; }
        }

        public bool UseFixValuedBonus
        {
            get { return myUseFixValuedBonus; }
            internal set { myUseFixValuedBonus = value; }
        }

        public double Percentage
        {
            get { return myPercentage; }
            internal set { myPercentage = value; }
        }

        public string PercentageDescription
        {
            get
            {
                if (UseFixValuedBonus)
                    return "(Fixbonus: " + AbsoluteValue.ToString("#,##0.00") + " €)";
                else
                    return "(Faktor: " + Percentage + " %)";
            }
        }

        public double AbsoluteValue
        {
            get { return myAbsoluteValue; }
            internal set { myAbsoluteValue = value; }
        }

        public double BaseWage
        {
            get { return myBaseWage; }
            internal set { myBaseWage = value; }
        }

        public double TotalIncentiveWage => myTotalIncentiveWage;

        private void LookUpWageDataInternal()
        {
            SPAccess.GetInstance().Employees_LookUpWageData(this);
            Recalculate();
        }

        private void Recalculate()
        {
            if (IncentiveWageTime == 0)
            {
                myDegreeOfTime = -1;
                myTotalIncentiveWage = -1;
            }
            double locHours = IncentiveWageTime / 60;
            if (UseFixValuedBonus)
            {
                myTotalIncentiveWage = locHours * AbsoluteValue;
            }
            else
            {
                double locTemp = locHours * BaseWage;
                myTotalIncentiveWage = (locTemp * Percentage / 100) - locTemp;
            }
        }
    }
}
