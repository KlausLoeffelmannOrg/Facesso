using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    /// <summary>
    /// Kapselt die Daten des kleinsten Berechnungselements (bestimmte Arbeitsgruppe, Schicht und Datum) für eine
    /// Produktiv-Site-Analyse, und stellt ein Element der WorkGroupAnalysisInfo-Auflistung dar.
    /// </summary>
    [System.CLSCompliant(true)]
    public class WorkGroupAnalysisInfoItem
    {
        private long _IDProductionData;
        private WorkGroupInfo _WorkGroup;
        private DateTime _ProductionDate;
        private byte _Shift;
        private double _TotalReferenceIWT;
        private double _TotalEffectiveIWT;
        private double _TotalEffectiveIWTAdj;
        private double _TotalDownTime;
        private double _TotalWorkBreakTime;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;
        private bool _IsSuspended;
        private bool _HasData;

        private WorkGroupAnalysisInfo _ParentWorkGroupAnalysisInfo;
        private bool _Deleted;
        private bool _CombinedData;

        public WorkGroupAnalysisInfoItem() { }

        public static WorkGroupAnalysisInfoItem operator +(WorkGroupAnalysisInfoItem val1, WorkGroupAnalysisInfoItem val2)
        {
            var locRet = val1.Clone();
            locRet.Add(val2);
            return locRet;
        }

        internal void Add(WorkGroupAnalysisInfoItem val2)
        {
            _TotalDownTime += val2._TotalDownTime;
            _TotalEffectiveIWT += val2._TotalEffectiveIWT;
            _TotalEffectiveIWTAdj += val2._TotalEffectiveIWTAdj;
            _TotalReferenceIWT += val2._TotalReferenceIWT;
            _TotalWorkBreakTime += val2._TotalWorkBreakTime;
            RecalculateInternal();
            _CombinedData = true;
            _HasData = _HasData || val2.HasData;
        }

        public WorkGroupAnalysisInfoItem(int idSubsidiary, CombinedParametersInfo cp)
        {
            _ProductionDate = cp.ProductionDate;
            _Shift = cp.Shift;
            _WorkGroup = cp.WorkGroup;
            SPAccess.GetInstance().ProductionData_GetWorkGroupAnalysisItem(this, idSubsidiary, cp);
        }

        internal WorkGroupAnalysisInfo ParentWorkGroupAnalysisInfo
        {
            set { _ParentWorkGroupAnalysisInfo = value; }
        }

        public WorkGroupInfo WorkGroup
        {
            get { return _WorkGroup; }
            set { _WorkGroup = value; }
        }

        public long IDProductionData
        {
            get { return _IDProductionData; }
            set { _IDProductionData = value; }
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

        public double TotalReferenceIWT
        {
            get { return _TotalReferenceIWT; }
            set { _TotalReferenceIWT = value; }
        }

        public double TotalEffectiveIWT
        {
            get { return _TotalEffectiveIWT; }
            set { _TotalEffectiveIWT = value; }
        }

        public double TotalEffectiveIWTAdj
        {
            get { return _TotalEffectiveIWTAdj; }
            set { _TotalEffectiveIWTAdj = value; }
        }

        public double TotalDownTime
        {
            get { return _TotalDownTime; }
            set { _TotalDownTime = value; }
        }

        public double TotalWorkBreakTime
        {
            get { return _TotalWorkBreakTime; }
            set { _TotalWorkBreakTime = value; }
        }

        public double TotalAttendanceTime => TotalEffectiveIWT + TotalDownTime + TotalWorkBreakTime;

        public double TotalWorkingTime => TotalEffectiveIWT + TotalDownTime;

        public double DegreeOfTime
        {
            get { return _DegreeOfTime; }
            set { _DegreeOfTime = value; }
        }

        public double DegreeOfTimeAdj
        {
            get { return _DegreeOfTimeAdj; }
            set { _DegreeOfTimeAdj = value; }
        }

        public bool IsSuspended
        {
            get { return _IsSuspended; }
            set { _IsSuspended = value; }
        }

        public bool HasData
        {
            get { return _HasData; }
            set { _HasData = value; }
        }

        public string AttendanceTimeDeltaStrings
        {
            get
            {
                string locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Arbeit:  " + TotalWorkingTime.ToString("#,##0") + " Min.";
                return locString;
            }
        }

        public string GeneralBreakTimeStrings
        {
            get
            {
                string locString = "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Ausfall:  " + TotalDownTime.ToString("#,##0") + " Min.";
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

        public bool CombinedData => _CombinedData;

        public WorkGroupAnalysisInfoItem Clone()
        {
            var retItem = new WorkGroupAnalysisInfoItem();
            retItem._CombinedData = _CombinedData;
            retItem._DegreeOfTime = _DegreeOfTime;
            retItem._DegreeOfTimeAdj = _DegreeOfTimeAdj;
            retItem._Deleted = _Deleted;
            retItem._HasData = _HasData;
            retItem._IDProductionData = _IDProductionData;
            retItem._IsSuspended = _IsSuspended;
            retItem._ParentWorkGroupAnalysisInfo = _ParentWorkGroupAnalysisInfo;
            retItem._ProductionDate = _ProductionDate;
            retItem._Shift = _Shift;
            retItem._TotalDownTime = _TotalDownTime;
            retItem._TotalEffectiveIWT = _TotalEffectiveIWT;
            retItem._TotalEffectiveIWTAdj = _TotalEffectiveIWTAdj;
            retItem._TotalReferenceIWT = _TotalReferenceIWT;
            retItem._TotalWorkBreakTime = _TotalWorkBreakTime;
            retItem._WorkGroup = _WorkGroup;
            return retItem;
        }

        private void RecalculateInternal()
        {
            _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100;
            _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100;
        }
    }

    public class WorkGroupAnalysisInfo : KeyedCollection<long, WorkGroupAnalysisInfoItem>
    {
        private WorkGroupInfo _WorkGroup;
        private ProductionPeriod _Period;
        private DateTime _UsedTicket;
        private int _IDSubsidiary;
        private int _IDUser;
        private bool _HasData;
        private int _NextAutoCountID;

        private double _TotalReferenceIWT;
        private double _TotalAttendanceTime;
        private double _TotalDownTime;
        private double _TotalWorkingTime;
        private double _TotalEffectiveIWT;
        private double _TotalEffectiveIWTAdj;
        private double _TotalWorkBreakTime;
        private double _TotalWorkloadIWT;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;

        internal WorkGroupAnalysisInfo(WorkGroupAnalysisInfo wgi) : base()
        {
            _WorkGroup = wgi._WorkGroup;
            _Period = wgi._Period;
            _UsedTicket = wgi._UsedTicket;
            _IDSubsidiary = wgi._IDSubsidiary;
            _IDUser = wgi._IDUser;
        }

        public WorkGroupAnalysisInfo(int idSubsidiary, int idUser, WorkGroupInfo workGroup, ProductionPeriod period)
        {
            DateTime locTicket = DateTime.Now;
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _Period = period;
            _WorkGroup = workGroup;
            period.PrepareProductionDates(idSubsidiary, idUser, locTicket);
            _HasData = SPAccess.GetInstance().ProductionData_GetWorkGroupAnalysisItems(idSubsidiary, idUser, locTicket, workGroup, this);
            SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(idSubsidiary, idUser, locTicket);
        }

        public WorkGroupAnalysisInfo(int idSubsidiary, int idUser, WorkGroupInfo workGroup, ProductionPeriod period, bool keepParamsTable)
        {
            DateTime locTicket = DateTime.Now;
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _Period = period;
            _WorkGroup = workGroup;
            _UsedTicket = locTicket;
            period.PrepareProductionDates(idSubsidiary, idUser, locTicket);
            _HasData = SPAccess.GetInstance().ProductionData_GetWorkGroupAnalysisItems(idSubsidiary, idUser, locTicket, workGroup, this);
            if (!keepParamsTable)
                SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(idSubsidiary, idUser, locTicket);
        }

        public WorkGroupAnalysisInfo(int idSubsidiary, int idUser, WorkGroupInfo workGroup, DateTime ticket)
        {
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _WorkGroup = workGroup;
            _UsedTicket = ticket;
            _HasData = SPAccess.GetInstance().ProductionData_GetWorkGroupAnalysisItems(idSubsidiary, idUser, ticket, workGroup, this);
        }

        public void CleanUp()
        {
            SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(_IDSubsidiary, _IDUser, _UsedTicket);
        }

        public WorkGroupInfo WorkGroupInfo
        {
            get { return _WorkGroup; }
            set { _WorkGroup = value; }
        }

        public bool HasData => _HasData;

        public DateTime UsedTicket => _UsedTicket;

        protected override long GetKeyForItem(WorkGroupAnalysisInfoItem item)
        {
            return item.IDProductionData;
        }

        protected override void InsertItem(int index, WorkGroupAnalysisInfoItem item)
        {
            item.ParentWorkGroupAnalysisInfo = this;
            if (item.IDProductionData <= 0)
            {
                item.IDProductionData = _NextAutoCountID;
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

        protected override void SetItem(int index, WorkGroupAnalysisInfoItem item)
        {
            item.ParentWorkGroupAnalysisInfo = this;
            base.SetItem(index, item);
            Recalculate();
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Recalculate();
        }

        public int NextAutoCountID => _NextAutoCountID;

        public double TotalReferenceIWT
        {
            get { return _TotalReferenceIWT; }
            set { _TotalReferenceIWT = value; Recalculate(); }
        }

        public double TotalEffectiveIWT => _TotalEffectiveIWT;

        public double TotalEffectiveIWTAdj => _TotalEffectiveIWTAdj;

        public double DegreeOfTime => _DegreeOfTime;

        public double DegreeOfTimeAdj => _DegreeOfTimeAdj;

        public double TotalWorkBreakTime => _TotalWorkBreakTime;

        public double TotalDownTime => _TotalDownTime;

        public double TotalWorkloadIWT => _TotalWorkloadIWT;

        public double PercentageWorkload => TotalEffectiveIWT / TotalWorkloadIWT * 100;

        public double TotalWorkingTime => _TotalWorkingTime;

        public double TotalAttendanceTime => _TotalAttendanceTime;

        public string AttendanceTimeDeltaStrings
        {
            get
            {
                string locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Arbeit:  " + TotalWorkingTime.ToString("#,##0") + " Min.";
                return locString;
            }
        }

        public string GeneralBreakTimeStrings
        {
            get
            {
                string locString = "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") + " Min." + Environment.NewLine;
                locString += "Ausfall:  " + TotalDownTime.ToString("#,##0") + " Min.";
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

        internal void Recalculate()
        {
            _TotalAttendanceTime = 0;
            _TotalWorkingTime = 0;
            _TotalDownTime = 0;
            _TotalEffectiveIWT = 0;
            _TotalEffectiveIWTAdj = 0;
            _TotalWorkBreakTime = 0;
            _TotalReferenceIWT = 0;
            _TotalWorkloadIWT = 0;
            _HasData = this.Count > 0;

            foreach (WorkGroupAnalysisInfoItem locItem in this)
            {
                _TotalAttendanceTime += locItem.TotalAttendanceTime;
                _TotalWorkingTime += locItem.TotalWorkingTime;
                _TotalDownTime += locItem.TotalDownTime;
                _TotalEffectiveIWT += locItem.TotalEffectiveIWT;
                _TotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj;
                _TotalWorkBreakTime += locItem.TotalWorkBreakTime;
                _TotalReferenceIWT += locItem.TotalReferenceIWT;
                _TotalWorkloadIWT += locItem.WorkGroup.WorkloadIWT;
            }
            _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100;
            _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100;
        }

        public static WorkGroupAnalysisInfo CompressShifts(WorkGroupAnalysisInfo wai)
        {
            if (wai == null) return null;

            var retWai = new WorkGroupAnalysisInfo(wai);
            bool locFound;

            foreach (WorkGroupAnalysisInfoItem locItem in wai)
            {
                if (retWai.Count == 0)
                {
                    retWai.Add(locItem);
                    retWai._HasData = true;
                    continue;
                }

                locFound = false;
                foreach (WorkGroupAnalysisInfoItem retItem in retWai)
                {
                    if ((retItem.ProductionDate == locItem.ProductionDate) && (retItem.WorkGroup == locItem.WorkGroup))
                    {
                        retItem.Shift = 0;
                        retItem.Add(locItem);
                        locFound = true;
                        break;
                    }
                }
                if (!locFound)
                    retWai.Add(locItem);
            }
            return retWai;
        }

        public static WorkGroupAnalysisInfo CompressDates(WorkGroupAnalysisInfo wai)
        {
            if (wai == null) return null;

            var retWai = new WorkGroupAnalysisInfo(wai);
            bool locFound;

            foreach (WorkGroupAnalysisInfoItem locItem in wai)
            {
                if (retWai.Count == 0)
                {
                    retWai.Add(locItem);
                    retWai._HasData = true;
                    continue;
                }

                locFound = false;
                foreach (WorkGroupAnalysisInfoItem retItem in retWai)
                {
                    if ((retItem.Shift == locItem.Shift) && (retItem.WorkGroup == locItem.WorkGroup))
                    {
                        retItem.Add(locItem);
                        locFound = true;
                        break;
                    }
                }
                if (!locFound)
                    retWai.Add(locItem);
            }
            return retWai;
        }
    }

    public class WorkGroupAnalysisInfoItems : KeyedCollection<IntKey, WorkGroupAnalysisInfo>
    {
        private ProductionPeriod myPeriod;
        private WorkGroupInfoItems myWorkgroups;
        private WorkGroupAnalysisProcessInformerDelegate myProcessInformerDelegate;
        private bool myCompressDates;
        private bool myCompressShifts;

        public delegate void WorkGroupAnalysisProcessInformerDelegate(WorkGroupInfo currentWorkgroup, int processedWorkgroups);

        public WorkGroupAnalysisInfoItems() : base() { }

        public WorkGroupAnalysisInfoItems(ProductionPeriod period, WorkGroupInfoItems workgroups,
            WorkGroupAnalysisProcessInformerDelegate processInformerDelegate,
            bool compressDates, bool compressShifts)
        {
            myPeriod = period;
            myWorkgroups = workgroups;
            myProcessInformerDelegate = processInformerDelegate;
            myCompressDates = compressDates;
            myCompressShifts = compressShifts;
        }

        protected override IntKey GetKeyForItem(WorkGroupAnalysisInfo item)
        {
            return new IntKey(item.WorkGroupInfo.IDWorkGroup);
        }

        public void ExecuteQuery()
        {
            bool blnFirst = false;
            DateTime locTicket = default(DateTime);
            WorkGroupAnalysisInfo locAnalysisInfo = null;
            int locCount = 0;

            foreach (WorkGroupInfo locWorkGroup in Workgroups)
            {
                myProcessInformerDelegate?.Invoke(locWorkGroup, locCount);
                locCount++;

                if (!blnFirst)
                {
                    locAnalysisInfo = new WorkGroupAnalysisInfo(
                        FacessoGeneric.LoginInfo.IDSubsidiary,
                        FacessoGeneric.LoginInfo.IDUser,
                        locWorkGroup, Period, true);
                    if (myCompressDates)
                        locAnalysisInfo = WorkGroupAnalysisInfo.CompressDates(locAnalysisInfo);
                    if (myCompressShifts)
                        locAnalysisInfo = WorkGroupAnalysisInfo.CompressShifts(locAnalysisInfo);

                    locTicket = locAnalysisInfo.UsedTicket;
                    this.Add(locAnalysisInfo);
                    blnFirst = true;
                }
                else
                {
                    locAnalysisInfo = new WorkGroupAnalysisInfo(
                        FacessoGeneric.LoginInfo.IDSubsidiary,
                        FacessoGeneric.LoginInfo.IDUser,
                        locWorkGroup, locTicket);
                    if (myCompressDates)
                        locAnalysisInfo = WorkGroupAnalysisInfo.CompressDates(locAnalysisInfo);
                    if (myCompressShifts)
                        locAnalysisInfo = WorkGroupAnalysisInfo.CompressShifts(locAnalysisInfo);
                    this.Add(locAnalysisInfo);
                }
            }
            locAnalysisInfo?.CleanUp();
        }

        public ProductionPeriod Period
        {
            get { return myPeriod; }
            set { myPeriod = value; }
        }

        public WorkGroupInfoItems Workgroups
        {
            get { return myWorkgroups; }
            set { myWorkgroups = value; }
        }

        public WorkGroupAnalysisProcessInformerDelegate ProcessInformerDelegate
        {
            get { return myProcessInformerDelegate; }
            set { myProcessInformerDelegate = value; }
        }
    }
}
