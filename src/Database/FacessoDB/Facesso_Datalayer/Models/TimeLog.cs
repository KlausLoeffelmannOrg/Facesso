using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class TimeLog
    {
        public Guid IdtimeLog { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdworkGroup { get; set; }
        public int IdworkGroupInternal { get; set; }
        public Guid Idemployee { get; set; }
        public int IdemployeeInternal { get; set; }
        public Guid IdbonusLists { get; set; }
        public Guid IdwageGroup { get; set; }
        public byte Shift { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime? ShiftStartViaInterface { get; set; }
        public DateTime ShiftEnd { get; set; }
        public DateTime? ShiftEndViaInterface { get; set; }
        public int WorkBreak { get; set; }
        public int? WorkBreakViaInterface { get; set; }
        public int DownTime { get; set; }
        public int? DownTimeViaInterface { get; set; }
        public double Handicap { get; set; }
        public int AttendanceTime { get; set; }
        public int WorkingTime { get; set; }
        public double IncentiveWageTime { get; set; }
        public double IncentiveWageTimeAdj { get; set; }
        public double DegreeOfTime { get; set; }
        public double DegreeOfTimeAdj { get; set; }
        public double ReferenceWageTimeProRata { get; set; }
        public bool InsertedByInterface { get; set; }
        public bool ManuallyEdited { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime LastEdited { get; set; }
        public Guid EditedByIduser { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
        public virtual Employees Id { get; set; }
        public virtual WorkGroups IdNavigation { get; set; }
    }
}
