using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class BonusLists
    {
        public BonusLists()
        {
            BonusList = new HashSet<BonusList>();
        }

        public Guid IdbonusLists { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdcostCenter { get; set; }
        public DateTime? WasCurrentFrom { get; set; }
        public DateTime? WasCurrentTo { get; set; }
        public bool? IsCurrent { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<BonusList> BonusList { get; set; }
        public virtual CostCenters Id { get; set; }
    }
}
