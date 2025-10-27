using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class TimeLogForInsert
    {
        public Guid IdtimeLogForInsert { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdtimeLog { get; set; }
        public Guid Iduser { get; set; }
        public Guid IdworkGroup { get; set; }
        public Guid Idemployee { get; set; }
        public byte Shift { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int WorkBreak { get; set; }
        public int DownTime { get; set; }
        public double Handicap { get; set; }
        public bool InsertedByInterface { get; set; }
        public bool ManuallyEdited { get; set; }
        public Guid EditedByIduser { get; set; }
        public bool Deleted { get; set; }
        public DateTime Ticket { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
