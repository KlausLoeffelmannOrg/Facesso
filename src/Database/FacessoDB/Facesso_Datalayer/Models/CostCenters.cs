using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class CostCenters
    {
        public CostCenters()
        {
            BonusLists = new HashSet<BonusLists>();
            Employees = new HashSet<Employees>();
            Users = new HashSet<Users>();
            WorkGroups = new HashSet<WorkGroups>();
        }

        public Guid IdcostCenter { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdcostCenterInternal { get; set; }
        public bool IsCurrent { get; set; }
        public int CostCenterNo { get; set; }
        public string CostCenterName { get; set; }
        public string CostCenterDescription { get; set; }
        public Guid Idcurrency { get; set; }
        public string IncentiveIndicatorSynonym { get; set; }
        public string IncentiveWageSynonym { get; set; }
        public string IncentiveIndicatorDimension { get; set; }
        public byte IncentiveIndicatorPrecision { get; set; }
        public bool UseFixValuedBonus { get; set; }
        public double IncentiveIndicatorFactor { get; set; }
        public byte BaseValuePrecision { get; set; }
        public string BaseValueSynonym { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<BonusLists> BonusLists { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<WorkGroups> WorkGroups { get; set; }
        public virtual Currencies IdcurrencyNavigation { get; set; }
    }
}
