using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Articles
    {
        public Guid Idarticle { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int Idmachine { get; set; }
        public int IdcostCenter { get; set; }
        public int IdlabourValue { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public DateTime LastEdited { get; set; }
        public string Test { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
