using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Currencies
    {
        public Currencies()
        {
            CostCenters = new HashSet<CostCenters>();
            WageGroups = new HashSet<WageGroups>();
        }

        public Guid Idcurrency { get; set; }
        public string CurrencyToken { get; set; }
        public string CurrencyCode { get; set; }
        public decimal FactorToEuroAverage { get; set; }
        public string CurrencyPlainText { get; set; }

        public virtual ICollection<CostCenters> CostCenters { get; set; }
        public virtual ICollection<WageGroups> WageGroups { get; set; }
    }
}
