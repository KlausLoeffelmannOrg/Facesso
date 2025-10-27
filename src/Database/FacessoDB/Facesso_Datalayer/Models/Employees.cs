using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Employees
    {
        public Employees()
        {
            SkillProvided = new HashSet<SkillProvided>();
            TimeLog = new HashSet<TimeLog>();
        }

        public Guid Idemployee { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdemployeeInternal { get; set; }
        public Guid IdcostCenter { get; set; }
        public Guid? IdwageGroup { get; set; }
        public bool UseFixedWage { get; set; }
        public decimal? FixedWage { get; set; }
        public Guid IdaddressDetails { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Matchcode { get; set; }
        public int PersonnelNumber { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsActive { get; set; }
        public bool IsIncentive { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfSeparation { get; set; }
        public string TimeCardNo { get; set; }
        public string Comment { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<SkillProvided> SkillProvided { get; set; }
        public virtual ICollection<TimeLog> TimeLog { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
        public virtual AddressDetails Id { get; set; }
        public virtual CostCenters IdNavigation { get; set; }
        public virtual WageGroups Id1 { get; set; }
    }
}
