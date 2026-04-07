using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    public class EmployeeTimeLogInfoItem
    {
        private long _IDTimeLog;
        private int _IDWorkGroup;
        private EmployeeInfo _Employee;
        private byte _Shift;
        private DateTime _ProductionDate;
        private DateTime _ShiftStart;
        private ADDBNullable<DateTime> _ShiftStartViaInterface;
        private DateTime _ShiftEnd;
        private ADDBNullable<DateTime> _ShiftEndViaInterface;
        private int _WorkBreak;
        private ADDBNullable<int> _WorkBreakViaInterface;
        private int _DownTime;
        private ADDBNullable<int> _DownTimeViaInterface;
        private double _Handicap;
        private int _AttendanceTime;
        private int _WorkingTime;
        private double _IncentiveWageTime;
        private double _IncentiveWageTimeAdj;
        private double _IncentiveWageTimeAct;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;
        private double _DegreeOfTimeAct;
        private double _ReferenceWageTimeProRata;
        private bool _InsertedByInterface;
        private bool _ManuallyEdited;
        private DateTime _LastEdited;
        private int _EditedByIDUser;
        private OverlapsInfo _Overlaps;
        private bool _IsSuspended;

        private EmployeeTimeLogInfo _ParentEmployeeTimeLogItems;
        private bool _Deleted;

        public EmployeeTimeLogInfoItem()
        {
            _Overlaps = new OverlapsInfo();
        }

        public EmployeeTimeLogInfoItem(SqlDataReader dr, EmployeeInfo employee)
        {
            AssignGenericProperties(dr);
            EmployeeInfo = employee;
        }

        public EmployeeTimeLogInfoItem(SqlDataReader dr, bool joinedWithEmployeesAndCostcenters)
        {
            AssignGenericProperties(dr);
            EmployeeInfo = new EmployeeInfo(dr, true);
        }

        private void AssignGenericProperties(SqlDataReader dr)
        {
            IDTimeLog = dr.GetInt64(dr.GetOrdinal("IDTimeLog"));
            IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"));
            Shift = dr.GetByte(dr.GetOrdinal("Shift"));
            SetShiftTimes(dr.GetDateTime(dr.GetOrdinal("ShiftStart")),
                dr.GetDateTime(dr.GetOrdinal("ShiftEnd")),
                dr.GetDateTime(dr.GetOrdinal("ProductionDate")));
            _ShiftStartViaInterface = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("ShiftStartViaInterface")));
            _ShiftEndViaInterface = ADDBNullable.FromObject<DateTime>(dr.GetValue(dr.GetOrdinal("ShiftEndViaInterface")));
            WorkBreak = dr.GetInt32(dr.GetOrdinal("WorkBreak"));
            DownTime = dr.GetInt32(dr.GetOrdinal("DownTime"));
            _WorkBreakViaInterface = ADDBNullable.FromObject<int>(dr.GetValue(dr.GetOrdinal("WorkBreakViaInterface")));
            _DownTimeViaInterface = ADDBNullable.FromObject<int>(dr.GetValue(dr.GetOrdinal("DownTimeViaInterface")));
            Handicap = dr.GetDouble(dr.GetOrdinal("Handicap"));
            _ReferenceWageTimeProRata = dr.GetDouble(dr.GetOrdinal("ReferenceWageTimeProRata"));
            InsertedByInterface = dr.GetBoolean(dr.GetOrdinal("InsertedByInterface"));
            ManuallyEdited = dr.GetBoolean(dr.GetOrdinal("ManuallyEdited"));
            IsSuspended = dr.GetBoolean(dr.GetOrdinal("IsSuspended"));
            LastEdited = dr.GetDateTime(dr.GetOrdinal("LastEdited"));
            EditedByIDUser = dr.GetInt32(dr.GetOrdinal("EditedByIDUser"));
        }

        internal EmployeeTimeLogInfo ParentEmployeeTimeLogItems
        {
            set { _ParentEmployeeTimeLogItems = value; }
        }

        public long IDTimeLog
        {
            get { return _IDTimeLog; }
            set { _IDTimeLog = value; }
        }

        public int IDWorkGroup
        {
            get { return _IDWorkGroup; }
            set { _IDWorkGroup = value; }
        }

        public EmployeeInfo EmployeeInfo
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        public byte Shift
        {
            get { return _Shift; }
            set { _Shift = value; }
        }

        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value.Date; }
        }

        public bool IsSuspended
        {
            get { return _IsSuspended; }
            set { _IsSuspended = value; }
        }

        /// <summary>
        /// Bestimmt den Schichtbeginn. ACHTUNG: Löst keine Neuberechnung der Klasse aus!
        /// </summary>
        public DateTime ShiftStart
        {
            get { return _ShiftStart; }
            set { _ShiftStart = value; }
        }

        /// <summary>
        /// Bestimmt das Schichtende. ACHTUNG: Löst keine Neuberechnung der Klasse aus!
        /// </summary>
        public DateTime ShiftEnd
        {
            get { return _ShiftEnd; }
            set { _ShiftEnd = value; }
        }

        public override string ToString()
        {
            return EmployeeInfo.PersonnelNumber + ": " + EmployeeInfo.LastName + ", " + EmployeeInfo.FirstName +
                   " (" + ShiftStart.ToShortTimeString() + "  -  " + ShiftEnd.ToShortTimeString() + ")";
        }

        /// <summary>
        /// Setzt Produktionsdatum, Schichtstart- und Endzeiten, und stößt, anders als die entsprechenden Eigenschaften, die Berechnung an.
        /// </summary>
        public void SetShiftTimes(DateTime shiftStart, DateTime shiftEnd, DateTime productionDate)
        {
            ProductionDate = productionDate.Date;
            if (shiftStart > shiftEnd)
                shiftEnd = shiftStart;
            TimeSpan locStartDifference;
            TimeSpan locEndDifference;

            if (shiftStart.Date == productionDate || shiftStart.Date == productionDate.AddDays(1))
            {
                locStartDifference = shiftStart.Subtract(productionDate);
                locEndDifference = shiftEnd.Subtract(productionDate);
            }
            else
            {
                locStartDifference = shiftStart.Subtract(shiftStart.Date);
                locEndDifference = shiftEnd.Subtract(shiftStart.Date);
            }

            ShiftStart = productionDate.Date.Add(locStartDifference);
            ShiftEnd = productionDate.Date.Add(locEndDifference);
            Recalculate();
        }

        public int WorkBreak
        {
            get { return _WorkBreak; }
            set { _WorkBreak = value; Recalculate(); }
        }

        public int DownTime
        {
            get { return _DownTime; }
            set { _DownTime = value; Recalculate(); }
        }

        public double Handicap
        {
            get { return _Handicap; }
            set { _Handicap = value; Recalculate(); }
        }

        public int AttendanceTime => _AttendanceTime;

        public int WorkingTime => _WorkingTime;

        public double IncentiveWageTime => _IncentiveWageTime;

        public double IncentiveWageTimeAdj => _IncentiveWageTimeAdj;

        public double IncentiveWageTimeAct => _IncentiveWageTimeAct;

        public double DegreeOfTime => _DegreeOfTime;

        public double DegreeOfTimeAdj => _DegreeOfTimeAdj;

        public double DegreeOfTimeAct => _DegreeOfTimeAct;

        internal void SetDegreesOfTime(double dot, double dotAdj)
        {
            _DegreeOfTime = dot;
            _DegreeOfTimeAdj = dotAdj;
            _ReferenceWageTimeProRata = _DegreeOfTime / 100 * _IncentiveWageTime;
        }

        public double ReferenceWageTimeProRata
        {
            get { return _ReferenceWageTimeProRata; }
            internal set { _ReferenceWageTimeProRata = value; Recalculate(); }
        }

        public bool InsertedByInterface
        {
            get { return _InsertedByInterface; }
            set { _InsertedByInterface = value; }
        }

        public bool ManuallyEdited
        {
            get { return _ManuallyEdited; }
            set { _ManuallyEdited = value; }
        }

        public DateTime LastEdited
        {
            get { return _LastEdited; }
            set { _LastEdited = value; }
        }

        public int EditedByIDUser
        {
            get { return _EditedByIDUser; }
            set { _EditedByIDUser = value; }
        }

        public bool Deleted
        {
            get { return _Deleted; }
            internal set { _Deleted = value; }
        }

        public OverlapsInfo Overlaps
        {
            get { return _Overlaps; }
            set { _Overlaps = value; }
        }

        public string TimeDeltaStrings
        {
            get
            {
                string locString = "Gesamtpräsenz:  " + AttendanceTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Arbeitszeit:  " + WorkingTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Effektivzeit:  " + IncentiveWageTime.ToString("#,##0") + " Min.";
                return locString;
            }
        }

        public EmployeeTimeLogInfoItem Clone()
        {
            var locEtli = new EmployeeTimeLogInfoItem();
            locEtli._AttendanceTime = this._AttendanceTime;
            locEtli._DegreeOfTime = this._DegreeOfTime;
            locEtli._DegreeOfTimeAdj = this._DegreeOfTimeAdj;
            locEtli._DownTime = this._DownTime;
            locEtli._EditedByIDUser = this._EditedByIDUser;
            locEtli._Employee = this._Employee;
            locEtli._ShiftEnd = this._ShiftEnd;
            locEtli._IDTimeLog = this._IDTimeLog;
            locEtli._IDWorkGroup = this._IDWorkGroup;
            locEtli._IncentiveWageTime = this._IncentiveWageTime;
            locEtli._IncentiveWageTimeAdj = this._IncentiveWageTimeAdj;
            locEtli._InsertedByInterface = this._InsertedByInterface;
            locEtli._LastEdited = this._LastEdited;
            locEtli._ManuallyEdited = this._ManuallyEdited;
            locEtli._ParentEmployeeTimeLogItems = this._ParentEmployeeTimeLogItems;
            locEtli._Handicap = this._Handicap;
            locEtli._ProductionDate = this._ProductionDate;
            locEtli._ReferenceWageTimeProRata = this._ReferenceWageTimeProRata;
            locEtli._Shift = this._Shift;
            locEtli._ShiftStart = this._ShiftStart;
            locEtli._WorkBreak = this._WorkBreak;
            locEtli._WorkingTime = this._WorkingTime;
            return locEtli;
        }

        private void Recalculate()
        {
            _AttendanceTime = Convert.ToInt32((ShiftEnd - ShiftStart).TotalMinutes);
            _WorkingTime = _AttendanceTime - _WorkBreak;
            _IncentiveWageTime = _WorkingTime - _DownTime;
            _IncentiveWageTimeAct = _IncentiveWageTime + _IncentiveWageTime * Handicap / 100;
            _IncentiveWageTimeAdj = _IncentiveWageTime - ((_IncentiveWageTime * Handicap) / 100);

            _DegreeOfTime = _ReferenceWageTimeProRata / _IncentiveWageTime * 100;
            _DegreeOfTimeAdj = _ReferenceWageTimeProRata / _IncentiveWageTimeAdj * 100;
            _DegreeOfTimeAct = _ReferenceWageTimeProRata / _IncentiveWageTimeAct * 100;

            if (_ParentEmployeeTimeLogItems != null)
                _ParentEmployeeTimeLogItems.Recalculate();
        }
    }

    public class EmployeeTimeLogInfo : KeyedCollection<long, EmployeeTimeLogInfoItem>
    {
        private WorkGroupInfo _WorkGroup;
        private DateTime _ProductionDate;
        private byte _Shift;
        private int _NextAutoCountID;
        private double _TotalReferenceIWT;
        private int _TotalAttendanceTime;
        private int _TotalDownTime;
        private int _TotalWorkingTime;
        private double _TotalEffectiveIWT;
        private double _TotalEffectiveIWTAdj;
        private double _TotalEffectiveIWTAct;
        private int _TotalWorkBreakTime;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;
        private double _DegreeOfTimeAct;
        private bool _RecalculateTotalReferenceIWT;
        private EmployeeInfo _Employee;
        private DateTime _StartDate;
        private DateTime _EndDate;

        public event EventHandler<EmployeeTimeLogItemsResultsChangedEventArgs> EmployeeTimeLogItemsResultsChangedChanged;

        public EmployeeTimeLogInfo() { }

        public EmployeeTimeLogInfo(CombinedParametersInfo combinedParameters)
        {
            _WorkGroup = combinedParameters.WorkGroup;
            _ProductionDate = combinedParameters.ProductionDate;
            _Shift = combinedParameters.Shift;
            SPAccess.GetInstance().GetEmployeeTimeLog(this);
        }

        public EmployeeTimeLogInfo(CombinedParametersInfo combinedParameters, EmployeeTimeLogInfo timeLogItems)
        {
            _WorkGroup = combinedParameters.WorkGroup;
            _ProductionDate = combinedParameters.ProductionDate;
            _Shift = combinedParameters.Shift;
            AddRange(timeLogItems);
        }

        public EmployeeTimeLogInfo(EmployeeInfo employee, DateTime startDate, DateTime endDate)
        {
            _Employee = employee;
            _StartDate = startDate;
            _EndDate = endDate;
            SPAccess.GetInstance().GetEmployeeTimeLog(employee, startDate, endDate, this);
        }

        public void DeleteFromDatabase(EmployeeTimeLogInfoItem empTimeLogItem)
        {
            SPAccess.GetInstance().TimeLog_DeleteItemFromDatabase(WorkGroup, empTimeLogItem);
        }

        public void AddRange(EmployeeTimeLogInfo timeLogItems)
        {
            foreach (EmployeeTimeLogInfoItem locItem in timeLogItems)
                this.Add(locItem);
        }

        protected override void InsertItem(int index, EmployeeTimeLogInfoItem item)
        {
            item.ParentEmployeeTimeLogItems = this;
            if (item.IDTimeLog <= 0)
            {
                item.IDTimeLog = _NextAutoCountID;
                _NextAutoCountID -= 1;
            }
            base.InsertItem(index, item);
            Recalculate();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Recalculate();
        }

        protected override void RemoveItem(int index)
        {
            if (this[index].IDTimeLog > 0)
                this[index].Deleted = true;
            else
                base.RemoveItem(index);
            Recalculate();
        }

        public void RemoveAllItems()
        {
            while (this.Count > 0)
                RemoveItem(0);
        }

        public void SetItem(long key, EmployeeTimeLogInfoItem item)
        {
            SetItem(this.IndexOf(item), item);
        }

        protected override void SetItem(int index, EmployeeTimeLogInfoItem item)
        {
            item.ParentEmployeeTimeLogItems = this;
            base.SetItem(index, item);
            Recalculate();
        }

        protected override long GetKeyForItem(EmployeeTimeLogInfoItem item)
        {
            return item.IDTimeLog;
        }

        public WorkGroupInfo WorkGroup
        {
            get { return _WorkGroup; }
            set { _WorkGroup = value; }
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

        public int NextAutoCountID => _NextAutoCountID;

        public double TotalReferenceIWT
        {
            get { return _TotalReferenceIWT; }
            set { _TotalReferenceIWT = value; Recalculate(); }
        }

        public double TotalEffectiveIWT => _TotalEffectiveIWT;

        public double TotalEffectiveIWTAdj => _TotalEffectiveIWTAdj;

        public double TotalEffectiveIWTAct => _TotalEffectiveIWTAct;

        public double DegreeOfTime => _DegreeOfTime;

        public double DegreeOfTimeAdj => _DegreeOfTimeAdj;

        public double DegreeOfTimeAct => _DegreeOfTimeAct;

        public int TotalWorkBreakTime => _TotalWorkBreakTime;

        public int TotalDownTime => _TotalDownTime;

        public int TotalWorkingTime => _TotalWorkingTime;

        public int TotalAttendanceTime => _TotalAttendanceTime;

        public string AttendanceTimeDeltaStrings
        {
            get
            {
                string locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Arbeit:  " + TotalWorkingTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") + " Min.";
                return locString;
            }
        }

        public string IncentiveTimeDeltaStrings
        {
            get
            {
                string locString = "Referenz:  " + TotalReferenceIWT.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Effektiv:  " + TotalEffectiveIWT.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "angepasst:  " + TotalEffectiveIWTAdj.ToString("#,##0") + " Min.";
                return locString;
            }
        }

        public bool RecalculateTotalReferenceIWT
        {
            get { return _RecalculateTotalReferenceIWT; }
            set { _RecalculateTotalReferenceIWT = value; }
        }

        public void SaveToDatabase(int idUser, bool updateResultSet)
        {
            if (updateResultSet)
            {
                this.Clear();
                foreach (EmployeeTimeLogInfoItem locItem in SPAccess.GetInstance().TimeLog_AddEditEmployeeTimeLogItems(this, idUser, true))
                    this.Add(locItem);
            }
            else
            {
                SPAccess.GetInstance().TimeLog_AddEditEmployeeTimeLogItems(this, idUser, true);
            }
        }

        internal void Recalculate()
        {
            _TotalAttendanceTime = 0;
            _TotalWorkingTime = 0;
            _TotalDownTime = 0;
            _TotalEffectiveIWT = 0;
            _TotalEffectiveIWTAdj = 0;
            _TotalEffectiveIWTAct = 0;
            _TotalWorkBreakTime = 0;
            if (RecalculateTotalReferenceIWT)
                _TotalReferenceIWT = 0;

            foreach (EmployeeTimeLogInfoItem locItem in this)
            {
                if (!locItem.Deleted)
                {
                    _TotalAttendanceTime += locItem.AttendanceTime;
                    _TotalWorkingTime += locItem.WorkingTime;
                    _TotalDownTime += locItem.DownTime;
                    _TotalEffectiveIWT += locItem.IncentiveWageTime;
                    _TotalEffectiveIWTAdj += locItem.IncentiveWageTimeAdj;
                    _TotalEffectiveIWTAct += locItem.IncentiveWageTimeAct;
                    _TotalWorkBreakTime += locItem.WorkBreak;
                    if (RecalculateTotalReferenceIWT)
                        _TotalReferenceIWT += locItem.ReferenceWageTimeProRata;
                }
            }
            _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100;
            _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100;
            _DegreeOfTimeAct = _TotalReferenceIWT / _TotalEffectiveIWTAct * 100;

            if (!RecalculateTotalReferenceIWT)
            {
                foreach (EmployeeTimeLogInfoItem locItem in this)
                {
                    if (!locItem.Deleted)
                        locItem.SetDegreesOfTime(_DegreeOfTime, _DegreeOfTimeAdj);
                }
            }
            EmployeeTimeLogItemsResultsChangedChanged?.Invoke(this, new EmployeeTimeLogItemsResultsChangedEventArgs(
                _TotalAttendanceTime, _TotalWorkingTime, _TotalDownTime, _TotalEffectiveIWT,
                _TotalEffectiveIWTAdj, _TotalWorkBreakTime));
        }

        public EmployeeInfo Employee => _Employee;

        public DateTime StartDate => _StartDate;

        public DateTime EndDate => _EndDate;
    }

    public class EmployeeTimeLogItemsResultsChangedEventArgs : EventArgs
    {
        private int _NewTotalAttendanceTime;
        private int _NewTotalWorkingTime;
        private int _NewTotalDownTime;
        private double _NewTotalEffectiveIWT;
        private double _NewTotalEffectiveIWTAdj;
        private int _NewTotalWorkBreakTime;

        public EmployeeTimeLogItemsResultsChangedEventArgs() { }

        public EmployeeTimeLogItemsResultsChangedEventArgs(int newTotalAttendanceTime, int newTotalWorkingTime,
            int newTotalDownTime, double newTotalEffectiveIWT,
            double newTotalEffectiveIWTAdj, int newTotalWorkBreakTime)
        {
            _NewTotalAttendanceTime = newTotalAttendanceTime;
            _NewTotalWorkBreakTime = newTotalWorkBreakTime;
            _NewTotalDownTime = newTotalDownTime;
            _NewTotalEffectiveIWT = newTotalEffectiveIWT;
            _NewTotalEffectiveIWTAdj = newTotalEffectiveIWTAdj;
            _NewTotalWorkingTime = newTotalWorkingTime;
        }

        public int NewTotalAttendanceTime
        {
            get { return _NewTotalAttendanceTime; }
            set { _NewTotalAttendanceTime = value; }
        }

        public int NewTotalWorkingTime
        {
            get { return _NewTotalWorkingTime; }
            set { _NewTotalWorkingTime = value; }
        }

        public int NewTotalDownTime
        {
            get { return _NewTotalDownTime; }
            set { _NewTotalDownTime = value; }
        }

        public double NewTotalEffectiveIWT
        {
            get { return _NewTotalEffectiveIWT; }
            set { _NewTotalEffectiveIWT = value; }
        }

        public double NewTotalEffectiveIWTAdj
        {
            get { return _NewTotalEffectiveIWTAdj; }
            set { _NewTotalEffectiveIWTAdj = value; }
        }

        public int NewTotalWorkBreakTime
        {
            get { return _NewTotalWorkBreakTime; }
            set { _NewTotalWorkBreakTime = value; }
        }
    }

    public class EmployeeTimeLogInfoCollection : Collection<EmployeeTimeLogInfo>
    {
        private double _TotalReferenceIWT;
        private double _TotalAttendanceTime;
        private double _TotalDownTime;
        private double _TotalWorkingTime;
        private double _TotalEffectiveIWT;
        private double _TotalEffectiveIWTAdj;
        private double _TotalEffectiveIWTAct;
        private double _TotalWorkBreakTime;

        public EmployeeTimeLogInfoCollection() : base() { }

        protected override void InsertItem(int index, EmployeeTimeLogInfo item)
        {
            base.InsertItem(index, item);
            Recalculate();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Recalculate();
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Recalculate();
        }

        protected override void SetItem(int index, EmployeeTimeLogInfo item)
        {
            base.SetItem(index, item);
            Recalculate();
        }

        public double TotalReferenceIWT => _TotalReferenceIWT;

        public double TotalEffectiveIWT => _TotalEffectiveIWT;

        public double TotalEffectiveIWTAdj => _TotalEffectiveIWTAdj;

        public double TotalEffectiveIWTAct => _TotalEffectiveIWTAct;

        public double DegreeOfTime => _TotalReferenceIWT / _TotalEffectiveIWT * 100;

        public double DegreeOfTimeAdj => _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100;

        public double DegreeOfTimeAct => _TotalReferenceIWT / _TotalEffectiveIWTAct * 100;

        public double TotalWorkBreakTime => _TotalWorkBreakTime;

        public double TotalDownTime => _TotalDownTime;

        public double TotalWorkingTime => _TotalWorkingTime;

        public double TotalAttendanceTime => _TotalAttendanceTime;

        internal void Recalculate()
        {
            _TotalAttendanceTime = 0;
            _TotalWorkingTime = 0;
            _TotalDownTime = 0;
            _TotalEffectiveIWT = 0;
            _TotalEffectiveIWTAdj = 0;
            _TotalEffectiveIWTAct = 0;
            _TotalWorkBreakTime = 0;
            _TotalReferenceIWT = 0;
            foreach (EmployeeTimeLogInfo locItem in this)
            {
                _TotalAttendanceTime += locItem.TotalAttendanceTime;
                _TotalWorkingTime += locItem.TotalWorkingTime;
                _TotalDownTime += locItem.TotalDownTime;
                _TotalEffectiveIWT += locItem.TotalEffectiveIWT;
                _TotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj;
                _TotalEffectiveIWTAct += locItem.TotalEffectiveIWTAct;
                _TotalWorkBreakTime += locItem.TotalWorkBreakTime;
                _TotalReferenceIWT += locItem.TotalReferenceIWT;
            }
        }
    }
}
