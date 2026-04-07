using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    public class OverlapsInfoItem
    {
        private int _IDOverlapInfo;
        private EmployeeInfo _EmployeeInfo;
        private WorkGroupInfo _WorkgroupInfo;
        private DateTime _ProductionDate;
        private byte _Shift;
        private DateTime _ShiftStart;
        private DateTime _ShiftEnd;
        private bool _OverlapsExternal;

        public OverlapsInfoItem(EmployeeInfo employeeInfo, WorkGroupInfo workgroupInfo,
            DateTime productionDate, byte shift,
            DateTime shiftStart, DateTime shiftEnd)
        {
            _EmployeeInfo = employeeInfo;
            _WorkgroupInfo = workgroupInfo;
            _ProductionDate = productionDate;
            _Shift = shift;
            _ShiftStart = shiftStart;
            _ShiftEnd = shiftEnd;
        }

        public OverlapsInfoItem(EmployeeInfo employeeInfo, SqlDataReader dr)
        {
            _EmployeeInfo = employeeInfo;
            _OverlapsExternal = true;
            WorkgroupInfo = new WorkGroupInfo(dr, WorkGroupInfoItemsGetType.JoinedWithCostCenter);
            ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
            Shift = dr.GetByte(dr.GetOrdinal("Shift"));
            ShiftStart = dr.GetDateTime(dr.GetOrdinal("ShiftStart"));
            ShiftEnd = dr.GetDateTime(dr.GetOrdinal("ShiftEnd"));
        }

        public int IDOverlapInfo
        {
            get { return _IDOverlapInfo; }
            set { _IDOverlapInfo = value; }
        }

        public EmployeeInfo EmployeeInfo
        {
            get { return _EmployeeInfo; }
            set { _EmployeeInfo = value; }
        }

        public WorkGroupInfo WorkgroupInfo
        {
            get { return _WorkgroupInfo; }
            set { _WorkgroupInfo = value; }
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

        public DateTime ShiftStart
        {
            get { return _ShiftStart; }
            set { _ShiftStart = value; }
        }

        public DateTime ShiftEnd
        {
            get { return _ShiftEnd; }
            set { _ShiftEnd = value; }
        }

        public bool OverlapsExternal => _OverlapsExternal;

        public override string ToString()
        {
            string locString = EmployeeInfo.DisplayName + ": ";
            locString += "hat schon gearbeitet in Site " + WorkgroupInfo.WorkGroupNumber + " ";
            locString += WorkgroupInfo.WorkGroupName + ". ";
            locString += "(" + ShiftStart.ToShortTimeString() + "  -  " + ShiftEnd.ToShortTimeString() + ")";
            return locString;
        }
    }

    public class OverlapsInfo : KeyedCollection<int, OverlapsInfoItem>
    {
        private int _myNextID;

        public OverlapsInfo()
        {
            _myNextID = 1;
        }

        public OverlapsInfo(EmployeeInfo employeeInfo, DateTime shiftStart, DateTime shiftEnd, ADDBNullable<long> excludeIDTimeLog)
        {
            _myNextID = 1;
            SPAccess.GetInstance().TimeLog_GetOverlappingLogItems(employeeInfo, shiftStart, shiftEnd, this, excludeIDTimeLog);
        }

        public void Add(EmployeeTimeLogInfoItem logItem, WorkGroupInfo workGroup)
        {
            var locItem = new OverlapsInfoItem(logItem.EmployeeInfo, workGroup,
                logItem.ProductionDate, logItem.Shift, logItem.ShiftStart, logItem.ShiftEnd);
            this.Add(locItem);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            _myNextID = 1;
        }

        protected override void InsertItem(int index, OverlapsInfoItem item)
        {
            if (item.IDOverlapInfo == 0)
                item.IDOverlapInfo = _myNextID;
            base.InsertItem(index, item);
            _myNextID += 1;
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, OverlapsInfoItem item)
        {
            base.SetItem(index, item);
        }

        public bool DoesOverlap => this.Count > 0;

        protected override int GetKeyForItem(OverlapsInfoItem item)
        {
            return item.IDOverlapInfo;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool supressLastFillLine)
        {
            if (this.Count == 0) return "";
            string locString = "";
            foreach (OverlapsInfoItem locItem in this)
            {
                locString += locItem.ToString() + Environment.NewLine;
            }

            if (supressLastFillLine)
            {
                locString = locString.Substring(0, locString.Length - 2);
            }
            return locString;
        }
    }
}
