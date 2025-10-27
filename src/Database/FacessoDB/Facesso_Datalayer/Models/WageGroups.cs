using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class WageGroups
    {
        public WageGroups()
        {
            Employees = new HashSet<Employees>();
        }

        public Guid IdwageGroup { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdwageGroupInternal { get; set; }
        public Guid Idcurrency { get; set; }
        public bool IsTemplate { get; set; }
        public string WageGroupToken { get; set; }
        public string Comment { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual Currencies IdcurrencyNavigation { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
