using System;
using Facesso;

namespace Facesso.Data
{
    public class CombinedParametersInfo
    {
        private EmployeeInfo myEmployeeInfo;
        private WorkGroupInfo myWorkGroupInfo;
        private byte myShift;
        private DateTime myProductionDate;

        public CombinedParametersInfo() { }

        public CombinedParametersInfo(WorkGroupInfo wg, DateTime prodDate, byte shift)
        {
            myWorkGroupInfo = wg;
            myProductionDate = prodDate;
            myShift = shift;
        }

        public EmployeeInfo EmployeeInfo
        {
            get { return myEmployeeInfo; }
            set { myEmployeeInfo = value; }
        }

        public WorkGroupInfo WorkGroup
        {
            get { return myWorkGroupInfo; }
            set { myWorkGroupInfo = value; }
        }

        public byte Shift
        {
            get { return myShift; }
            set { myShift = value; }
        }

        public DateTime ProductionDate
        {
            get { return myProductionDate; }
            set { myProductionDate = value; }
        }

        public string CurrentShiftText => ShiftText(Shift);

        public string ShiftText(bool includeShiftNr)
        {
            return includeShiftNr ? Shift.ToString() + ": " + ShiftText(Shift) : ShiftText(Shift);
        }

        public string ShiftText(byte shiftNr)
        {
            string locString = "(";
            if (WorkGroup == null)
                return "(-- : --  -  -- : --)";
            TimeSettingDetail locTSD = WorkGroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, shiftNr);
            if (locTSD.ShiftStart.HasValue)
            {
                locString += locTSD.ShiftStart.TypedValue.ToShortTimeString() + "  -  ";
                locString += locTSD.ShiftEnd.TypedValue.ToShortTimeString() + ")";
            }
            else
            {
                locString += "-- : --  -  -- : --)";
            }
            return locString;
        }
    }

    public class ProductionPeriodItem
    {
        private DateTime _ProductionDate;
        private byte _Shift;

        public ProductionPeriodItem(DateTime productionDate, byte shift)
        {
            _ProductionDate = productionDate;
            _Shift = shift;
        }

        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }

        public byte Shift
        {
            get { return _Shift; }
            set { _Shift = value; }
        }
    }
}
