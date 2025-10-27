using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class WorkGroupAssignments
    {
        public Guid IdworkGroupAssignment { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdlabourValueInternal { get; set; }
        public int IdworkGroupInternal { get; set; }
        public int OrdinalNumber { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
