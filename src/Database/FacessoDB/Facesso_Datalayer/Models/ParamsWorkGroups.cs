using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ParamsWorkGroups
    {
        public Guid IdparamsWorkGroups { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid Iduser { get; set; }
        public DateTime Ticket { get; set; }
        public Guid IdworkGroup { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
