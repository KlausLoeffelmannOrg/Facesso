using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class WorkGroups
    {
        public WorkGroups()
        {
            ProductionData = new HashSet<ProductionData>();
            SkillNeeded = new HashSet<SkillNeeded>();
            TimeLog = new HashSet<TimeLog>();
        }

        public Guid IdworkGroup { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdworkGroupInternal { get; set; }
        public Guid IdcostCenter { get; set; }
        public int WorkGroupNumber { get; set; }
        public string WorkgroupName { get; set; }
        public string WorkGroupDescription { get; set; }
        public double WorkloadIwt { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsPeaceWork { get; set; }
        public bool IsConceptional { get; set; }
        public int OrdinalNo { get; set; }
        public string TimeSettingDetails { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<ProductionData> ProductionData { get; set; }
        public virtual ICollection<SkillNeeded> SkillNeeded { get; set; }
        public virtual ICollection<TimeLog> TimeLog { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
        public virtual CostCenters Id { get; set; }
    }
}
