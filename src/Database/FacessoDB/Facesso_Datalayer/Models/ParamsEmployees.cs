using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ParamsEmployees
    {
        public Guid IdparamsEmployees { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid Iduser { get; set; }
        public DateTime Ticket { get; set; }
        public Guid Idemployee { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
