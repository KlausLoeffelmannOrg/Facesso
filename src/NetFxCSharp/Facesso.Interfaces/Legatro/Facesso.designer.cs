using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "Facesso")]
    public partial class FacessoDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
        partial void OnCreated();
        partial void InsertTimeLog(TimeLog instance);
        partial void UpdateTimeLog(TimeLog instance);
        partial void DeleteTimeLog(TimeLog instance);
        public FacessoDataContext() : base(global::Facesso.Interfaces.My.MySettings.Default.FacessoConnectionString, mappingSource)
        {
            OnCreated();
        }

        public FacessoDataContext(string connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public FacessoDataContext(System.Data.IDbConnection connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public FacessoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public FacessoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<TimeLog> TimeLog
        {
            get
            {
                return this.GetTable<TimeLog>();
            }
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.TimeLog_AddItemsForAddEdit")]
        public int TimeLog_AddItemsForAddEdit(System.Nullable<int> iDSubsidiary, System.Nullable<long> iDTimeLog, System.Nullable<int> iDUser, System.Nullable<long> iDWorkGroup, System.Nullable<int> iDEmployee, System.Nullable<System.DateTime> productionDate, System.Nullable<byte> shift, System.Nullable<System.DateTime> shiftStart, System.Nullable<System.DateTime> shiftEnd, System.Nullable<int> workBreak, System.Nullable<int> downTime, System.Nullable<double> handicap, System.Nullable<bool> insertedByInterface, System.Nullable<bool> manuallyEdited, System.Nullable<int> lastEditedByIDUser, System.Nullable<System.DateTime> ticket, System.Nullable<bool> deleted)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), iDSubsidiary, iDTimeLog, iDUser, iDWorkGroup, iDEmployee, productionDate, shift, shiftStart, shiftEnd, workBreak, downTime, handicap, insertedByInterface, manuallyEdited, lastEditedByIDUser, ticket, deleted);
            return ((int)result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.TimeLog_HandleAddEdit")]
        public int TimeLog_HandleAddEdit(System.Nullable<int> iDSubsidiary, System.Nullable<int> iDUser, System.Nullable<System.DateTime> ticket)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), iDSubsidiary, iDUser, ticket);
            return ((int)result.ReturnValue);
        }
    }

    [System.Data.Linq.Mapping.TableAttribute(Name = "dbo.TimeLog")]
    public partial class TimeLog : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private long _IDTimeLog;
        private int _IDSubsidiary;
        private int _IDWorkGroup;
        private int _IDWorkGroupInternal;
        private int _IDEmployee;
        private int _IDEmployeeInternal;
        private int _IDBonusLists;
        private int _IDWageGroup;
        private byte _Shift;
        private System.DateTime _ProductionDate;
        private System.DateTime _ShiftStart;
        private System.Nullable<System.DateTime> _ShiftStartViaInterface;
        private System.DateTime _ShiftEnd;
        private System.Nullable<System.DateTime> _ShiftEndViaInterface;
        private int _WorkBreak;
        private System.Nullable<int> _WorkBreakViaInterface;
        private int _DownTime;
        private System.Nullable<int> _DownTimeViaInterface;
        private double _Handicap;
        private int _AttendanceTime;
        private int _WorkingTime;
        private double _IncentiveWageTime;
        private double _IncentiveWageTimeAdj;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;
        private double _ReferenceWageTimeProRata;
        private bool _InsertedByInterface;
        private bool _ManuallyEdited;
        private bool _IsSuspended;
        private System.DateTime _LastEdited;
        private int _EditedByIDUser;
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDTimeLogChanging(long value);
        partial void OnIDTimeLogChanged();
        partial void OnIDSubsidiaryChanging(int value);
        partial void OnIDSubsidiaryChanged();
        partial void OnIDWorkGroupChanging(int value);
        partial void OnIDWorkGroupChanged();
        partial void OnIDWorkGroupInternalChanging(int value);
        partial void OnIDWorkGroupInternalChanged();
        partial void OnIDEmployeeChanging(int value);
        partial void OnIDEmployeeChanged();
        partial void OnIDEmployeeInternalChanging(int value);
        partial void OnIDEmployeeInternalChanged();
        partial void OnIDBonusListsChanging(int value);
        partial void OnIDBonusListsChanged();
        partial void OnIDWageGroupChanging(int value);
        partial void OnIDWageGroupChanged();
        partial void OnShiftChanging(byte value);
        partial void OnShiftChanged();
        partial void OnProductionDateChanging(System.DateTime value);
        partial void OnProductionDateChanged();
        partial void OnShiftStartChanging(System.DateTime value);
        partial void OnShiftStartChanged();
        partial void OnShiftStartViaInterfaceChanging(System.Nullable<System.DateTime> value);
        partial void OnShiftStartViaInterfaceChanged();
        partial void OnShiftEndChanging(System.DateTime value);
        partial void OnShiftEndChanged();
        partial void OnShiftEndViaInterfaceChanging(System.Nullable<System.DateTime> value);
        partial void OnShiftEndViaInterfaceChanged();
        partial void OnWorkBreakChanging(int value);
        partial void OnWorkBreakChanged();
        partial void OnWorkBreakViaInterfaceChanging(System.Nullable<int> value);
        partial void OnWorkBreakViaInterfaceChanged();
        partial void OnDownTimeChanging(int value);
        partial void OnDownTimeChanged();
        partial void OnDownTimeViaInterfaceChanging(System.Nullable<int> value);
        partial void OnDownTimeViaInterfaceChanged();
        partial void OnHandicapChanging(double value);
        partial void OnHandicapChanged();
        partial void OnAttendanceTimeChanging(int value);
        partial void OnAttendanceTimeChanged();
        partial void OnWorkingTimeChanging(int value);
        partial void OnWorkingTimeChanged();
        partial void OnIncentiveWageTimeChanging(double value);
        partial void OnIncentiveWageTimeChanged();
        partial void OnIncentiveWageTimeAdjChanging(double value);
        partial void OnIncentiveWageTimeAdjChanged();
        partial void OnDegreeOfTimeChanging(double value);
        partial void OnDegreeOfTimeChanged();
        partial void OnDegreeOfTimeAdjChanging(double value);
        partial void OnDegreeOfTimeAdjChanged();
        partial void OnReferenceWageTimeProRataChanging(double value);
        partial void OnReferenceWageTimeProRataChanged();
        partial void OnInsertedByInterfaceChanging(bool value);
        partial void OnInsertedByInterfaceChanged();
        partial void OnManuallyEditedChanging(bool value);
        partial void OnManuallyEditedChanged();
        partial void OnIsSuspendedChanging(bool value);
        partial void OnIsSuspendedChanged();
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        partial void OnEditedByIDUserChanging(int value);
        partial void OnEditedByIDUserChanged();
        public TimeLog() : base()
        {
            OnCreated();
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLog", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public long IDTimeLog
        {
            get
            {
                return this._IDTimeLog;
            }

            set
            {
                if (((this._IDTimeLog == value) == false))
                {
                    this.OnIDTimeLogChanging(value);
                    this.SendPropertyChanging();
                    this._IDTimeLog = value;
                    this.SendPropertyChanged("IDTimeLog");
                    this.OnIDTimeLogChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDSubsidiary", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int IDSubsidiary
        {
            get
            {
                return this._IDSubsidiary;
            }

            set
            {
                if (((this._IDSubsidiary == value) == false))
                {
                    this.OnIDSubsidiaryChanging(value);
                    this.SendPropertyChanging();
                    this._IDSubsidiary = value;
                    this.SendPropertyChanged("IDSubsidiary");
                    this.OnIDSubsidiaryChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDWorkGroup", DbType = "Int NOT NULL")]
        public int IDWorkGroup
        {
            get
            {
                return this._IDWorkGroup;
            }

            set
            {
                if (((this._IDWorkGroup == value) == false))
                {
                    this.OnIDWorkGroupChanging(value);
                    this.SendPropertyChanging();
                    this._IDWorkGroup = value;
                    this.SendPropertyChanged("IDWorkGroup");
                    this.OnIDWorkGroupChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDWorkGroupInternal", DbType = "Int NOT NULL")]
        public int IDWorkGroupInternal
        {
            get
            {
                return this._IDWorkGroupInternal;
            }

            set
            {
                if (((this._IDWorkGroupInternal == value) == false))
                {
                    this.OnIDWorkGroupInternalChanging(value);
                    this.SendPropertyChanging();
                    this._IDWorkGroupInternal = value;
                    this.SendPropertyChanged("IDWorkGroupInternal");
                    this.OnIDWorkGroupInternalChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDEmployee", DbType = "Int NOT NULL")]
        public int IDEmployee
        {
            get
            {
                return this._IDEmployee;
            }

            set
            {
                if (((this._IDEmployee == value) == false))
                {
                    this.OnIDEmployeeChanging(value);
                    this.SendPropertyChanging();
                    this._IDEmployee = value;
                    this.SendPropertyChanged("IDEmployee");
                    this.OnIDEmployeeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDEmployeeInternal", DbType = "Int NOT NULL")]
        public int IDEmployeeInternal
        {
            get
            {
                return this._IDEmployeeInternal;
            }

            set
            {
                if (((this._IDEmployeeInternal == value) == false))
                {
                    this.OnIDEmployeeInternalChanging(value);
                    this.SendPropertyChanging();
                    this._IDEmployeeInternal = value;
                    this.SendPropertyChanged("IDEmployeeInternal");
                    this.OnIDEmployeeInternalChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDBonusLists", DbType = "Int NOT NULL")]
        public int IDBonusLists
        {
            get
            {
                return this._IDBonusLists;
            }

            set
            {
                if (((this._IDBonusLists == value) == false))
                {
                    this.OnIDBonusListsChanging(value);
                    this.SendPropertyChanging();
                    this._IDBonusLists = value;
                    this.SendPropertyChanged("IDBonusLists");
                    this.OnIDBonusListsChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDWageGroup", DbType = "Int NOT NULL")]
        public int IDWageGroup
        {
            get
            {
                return this._IDWageGroup;
            }

            set
            {
                if (((this._IDWageGroup == value) == false))
                {
                    this.OnIDWageGroupChanging(value);
                    this.SendPropertyChanging();
                    this._IDWageGroup = value;
                    this.SendPropertyChanged("IDWageGroup");
                    this.OnIDWageGroupChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Shift", DbType = "TinyInt NOT NULL")]
        public byte Shift
        {
            get
            {
                return this._Shift;
            }

            set
            {
                if (((this._Shift == value) == false))
                {
                    this.OnShiftChanging(value);
                    this.SendPropertyChanging();
                    this._Shift = value;
                    this.SendPropertyChanged("Shift");
                    this.OnShiftChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ProductionDate", DbType = "DateTime NOT NULL")]
        public System.DateTime ProductionDate
        {
            get
            {
                return this._ProductionDate;
            }

            set
            {
                if (((this._ProductionDate == value) == false))
                {
                    this.OnProductionDateChanging(value);
                    this.SendPropertyChanging();
                    this._ProductionDate = value;
                    this.SendPropertyChanged("ProductionDate");
                    this.OnProductionDateChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShiftStart", DbType = "DateTime NOT NULL")]
        public System.DateTime ShiftStart
        {
            get
            {
                return this._ShiftStart;
            }

            set
            {
                if (((this._ShiftStart == value) == false))
                {
                    this.OnShiftStartChanging(value);
                    this.SendPropertyChanging();
                    this._ShiftStart = value;
                    this.SendPropertyChanged("ShiftStart");
                    this.OnShiftStartChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShiftStartViaInterface", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ShiftStartViaInterface
        {
            get
            {
                return this._ShiftStartViaInterface;
            }

            set
            {
                if ((this._ShiftStartViaInterface.Equals(value) == false))
                {
                    this.OnShiftStartViaInterfaceChanging(value);
                    this.SendPropertyChanging();
                    this._ShiftStartViaInterface = value;
                    this.SendPropertyChanged("ShiftStartViaInterface");
                    this.OnShiftStartViaInterfaceChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShiftEnd", DbType = "DateTime NOT NULL")]
        public System.DateTime ShiftEnd
        {
            get
            {
                return this._ShiftEnd;
            }

            set
            {
                if (((this._ShiftEnd == value) == false))
                {
                    this.OnShiftEndChanging(value);
                    this.SendPropertyChanging();
                    this._ShiftEnd = value;
                    this.SendPropertyChanged("ShiftEnd");
                    this.OnShiftEndChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShiftEndViaInterface", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ShiftEndViaInterface
        {
            get
            {
                return this._ShiftEndViaInterface;
            }

            set
            {
                if ((this._ShiftEndViaInterface.Equals(value) == false))
                {
                    this.OnShiftEndViaInterfaceChanging(value);
                    this.SendPropertyChanging();
                    this._ShiftEndViaInterface = value;
                    this.SendPropertyChanged("ShiftEndViaInterface");
                    this.OnShiftEndViaInterfaceChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkBreak", DbType = "Int NOT NULL")]
        public int WorkBreak
        {
            get
            {
                return this._WorkBreak;
            }

            set
            {
                if (((this._WorkBreak == value) == false))
                {
                    this.OnWorkBreakChanging(value);
                    this.SendPropertyChanging();
                    this._WorkBreak = value;
                    this.SendPropertyChanged("WorkBreak");
                    this.OnWorkBreakChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkBreakViaInterface", DbType = "Int")]
        public System.Nullable<int> WorkBreakViaInterface
        {
            get
            {
                return this._WorkBreakViaInterface;
            }

            set
            {
                if ((this._WorkBreakViaInterface.Equals(value) == false))
                {
                    this.OnWorkBreakViaInterfaceChanging(value);
                    this.SendPropertyChanging();
                    this._WorkBreakViaInterface = value;
                    this.SendPropertyChanged("WorkBreakViaInterface");
                    this.OnWorkBreakViaInterfaceChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DownTime", DbType = "Int NOT NULL")]
        public int DownTime
        {
            get
            {
                return this._DownTime;
            }

            set
            {
                if (((this._DownTime == value) == false))
                {
                    this.OnDownTimeChanging(value);
                    this.SendPropertyChanging();
                    this._DownTime = value;
                    this.SendPropertyChanged("DownTime");
                    this.OnDownTimeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DownTimeViaInterface", DbType = "Int")]
        public System.Nullable<int> DownTimeViaInterface
        {
            get
            {
                return this._DownTimeViaInterface;
            }

            set
            {
                if ((this._DownTimeViaInterface.Equals(value) == false))
                {
                    this.OnDownTimeViaInterfaceChanging(value);
                    this.SendPropertyChanging();
                    this._DownTimeViaInterface = value;
                    this.SendPropertyChanged("DownTimeViaInterface");
                    this.OnDownTimeViaInterfaceChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Handicap", DbType = "Float NOT NULL")]
        public double Handicap
        {
            get
            {
                return this._Handicap;
            }

            set
            {
                if (((this._Handicap == value) == false))
                {
                    this.OnHandicapChanging(value);
                    this.SendPropertyChanging();
                    this._Handicap = value;
                    this.SendPropertyChanged("Handicap");
                    this.OnHandicapChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AttendanceTime", DbType = "Int NOT NULL")]
        public int AttendanceTime
        {
            get
            {
                return this._AttendanceTime;
            }

            set
            {
                if (((this._AttendanceTime == value) == false))
                {
                    this.OnAttendanceTimeChanging(value);
                    this.SendPropertyChanging();
                    this._AttendanceTime = value;
                    this.SendPropertyChanged("AttendanceTime");
                    this.OnAttendanceTimeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkingTime", DbType = "Int NOT NULL")]
        public int WorkingTime
        {
            get
            {
                return this._WorkingTime;
            }

            set
            {
                if (((this._WorkingTime == value) == false))
                {
                    this.OnWorkingTimeChanging(value);
                    this.SendPropertyChanging();
                    this._WorkingTime = value;
                    this.SendPropertyChanged("WorkingTime");
                    this.OnWorkingTimeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IncentiveWageTime", DbType = "Float NOT NULL")]
        public double IncentiveWageTime
        {
            get
            {
                return this._IncentiveWageTime;
            }

            set
            {
                if (((this._IncentiveWageTime == value) == false))
                {
                    this.OnIncentiveWageTimeChanging(value);
                    this.SendPropertyChanging();
                    this._IncentiveWageTime = value;
                    this.SendPropertyChanged("IncentiveWageTime");
                    this.OnIncentiveWageTimeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IncentiveWageTimeAdj", DbType = "Float NOT NULL")]
        public double IncentiveWageTimeAdj
        {
            get
            {
                return this._IncentiveWageTimeAdj;
            }

            set
            {
                if (((this._IncentiveWageTimeAdj == value) == false))
                {
                    this.OnIncentiveWageTimeAdjChanging(value);
                    this.SendPropertyChanging();
                    this._IncentiveWageTimeAdj = value;
                    this.SendPropertyChanged("IncentiveWageTimeAdj");
                    this.OnIncentiveWageTimeAdjChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DegreeOfTime", DbType = "Float NOT NULL")]
        public double DegreeOfTime
        {
            get
            {
                return this._DegreeOfTime;
            }

            set
            {
                if (((this._DegreeOfTime == value) == false))
                {
                    this.OnDegreeOfTimeChanging(value);
                    this.SendPropertyChanging();
                    this._DegreeOfTime = value;
                    this.SendPropertyChanged("DegreeOfTime");
                    this.OnDegreeOfTimeChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DegreeOfTimeAdj", DbType = "Float NOT NULL")]
        public double DegreeOfTimeAdj
        {
            get
            {
                return this._DegreeOfTimeAdj;
            }

            set
            {
                if (((this._DegreeOfTimeAdj == value) == false))
                {
                    this.OnDegreeOfTimeAdjChanging(value);
                    this.SendPropertyChanging();
                    this._DegreeOfTimeAdj = value;
                    this.SendPropertyChanged("DegreeOfTimeAdj");
                    this.OnDegreeOfTimeAdjChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ReferenceWageTimeProRata", DbType = "Float NOT NULL")]
        public double ReferenceWageTimeProRata
        {
            get
            {
                return this._ReferenceWageTimeProRata;
            }

            set
            {
                if (((this._ReferenceWageTimeProRata == value) == false))
                {
                    this.OnReferenceWageTimeProRataChanging(value);
                    this.SendPropertyChanging();
                    this._ReferenceWageTimeProRata = value;
                    this.SendPropertyChanged("ReferenceWageTimeProRata");
                    this.OnReferenceWageTimeProRataChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InsertedByInterface", DbType = "Bit NOT NULL")]
        public bool InsertedByInterface
        {
            get
            {
                return this._InsertedByInterface;
            }

            set
            {
                if (((this._InsertedByInterface == value) == false))
                {
                    this.OnInsertedByInterfaceChanging(value);
                    this.SendPropertyChanging();
                    this._InsertedByInterface = value;
                    this.SendPropertyChanged("InsertedByInterface");
                    this.OnInsertedByInterfaceChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ManuallyEdited", DbType = "Bit NOT NULL")]
        public bool ManuallyEdited
        {
            get
            {
                return this._ManuallyEdited;
            }

            set
            {
                if (((this._ManuallyEdited == value) == false))
                {
                    this.OnManuallyEditedChanging(value);
                    this.SendPropertyChanging();
                    this._ManuallyEdited = value;
                    this.SendPropertyChanged("ManuallyEdited");
                    this.OnManuallyEditedChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsSuspended", DbType = "Bit NOT NULL")]
        public bool IsSuspended
        {
            get
            {
                return this._IsSuspended;
            }

            set
            {
                if (((this._IsSuspended == value) == false))
                {
                    this.OnIsSuspendedChanging(value);
                    this.SendPropertyChanging();
                    this._IsSuspended = value;
                    this.SendPropertyChanged("IsSuspended");
                    this.OnIsSuspendedChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastEdited", DbType = "DateTime NOT NULL")]
        public System.DateTime LastEdited
        {
            get
            {
                return this._LastEdited;
            }

            set
            {
                if (((this._LastEdited == value) == false))
                {
                    this.OnLastEditedChanging(value);
                    this.SendPropertyChanging();
                    this._LastEdited = value;
                    this.SendPropertyChanged("LastEdited");
                    this.OnLastEditedChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EditedByIDUser", DbType = "Int NOT NULL")]
        public int EditedByIDUser
        {
            get
            {
                return this._EditedByIDUser;
            }

            set
            {
                if (((this._EditedByIDUser == value) == false))
                {
                    this.OnEditedByIDUserChanging(value);
                    this.SendPropertyChanging();
                    this._EditedByIDUser = value;
                    this.SendPropertyChanged("EditedByIDUser");
                    this.OnEditedByIDUserChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            if (((this.PropertyChanging == null) == false))
            {
                PropertyChanging?.Invoke(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if (((this.PropertyChanged == null) == false))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}