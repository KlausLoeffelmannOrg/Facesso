using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ParamsProductionDates
    {
        public Guid IdparamsProductionDates { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid Iduser { get; set; }
        public DateTime Ticket { get; set; }
        public DateTime ProductionDate { get; set; }
        public byte Shift { get; set; }
        public long? Tag { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
