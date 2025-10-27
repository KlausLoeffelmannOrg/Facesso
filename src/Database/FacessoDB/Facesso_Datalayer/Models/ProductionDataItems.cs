using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ProductionDataItems
    {
        public Guid IdproductionDataItem { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdproductionData { get; set; }
        public Guid IdlabourValue { get; set; }
        public Guid Idarticle { get; set; }
        public double Amount { get; set; }
        public double AmountViaInterface { get; set; }
        public int OrdinalNumber { get; set; }
        public bool ManuallyEdited { get; set; }

        public virtual ProductionData Id { get; set; }
    }
}
