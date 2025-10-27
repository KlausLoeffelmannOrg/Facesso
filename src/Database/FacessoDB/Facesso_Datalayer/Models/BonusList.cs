using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class BonusList
    {
        public Guid IdbonusList { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdbonusLists { get; set; }
        public decimal DegreeOfTime { get; set; }
        public decimal Percentage { get; set; }
        public decimal AbsoluteValue { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual BonusLists Id { get; set; }
    }
}
