using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Subsidiaries
    {
        public Subsidiaries()
        {
            AddressDetails = new HashSet<AddressDetails>();
            Articles = new HashSet<Articles>();
            Employees = new HashSet<Employees>();
            LabourValues = new HashSet<LabourValues>();
            NotificationRecipients = new HashSet<NotificationRecipients>();
            ParamsEmployees = new HashSet<ParamsEmployees>();
            ParamsProductionDates = new HashSet<ParamsProductionDates>();
            ParamsWorkGroups = new HashSet<ParamsWorkGroups>();
            ProductionData = new HashSet<ProductionData>();
            Skills = new HashSet<Skills>();
            TimeLog = new HashSet<TimeLog>();
            TimeLogForInsert = new HashSet<TimeLogForInsert>();
            Users = new HashSet<Users>();
            WageGroups = new HashSet<WageGroups>();
            WorkGroupAssignments = new HashSet<WorkGroupAssignments>();
            WorkGroups = new HashSet<WorkGroups>();
        }

        public Guid Idsubsidiary { get; set; }
        public string SubsidiaryName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string PrimaryPhone { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<AddressDetails> AddressDetails { get; set; }
        public virtual ICollection<Articles> Articles { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<LabourValues> LabourValues { get; set; }
        public virtual ICollection<NotificationRecipients> NotificationRecipients { get; set; }
        public virtual ICollection<ParamsEmployees> ParamsEmployees { get; set; }
        public virtual ICollection<ParamsProductionDates> ParamsProductionDates { get; set; }
        public virtual ICollection<ParamsWorkGroups> ParamsWorkGroups { get; set; }
        public virtual ICollection<ProductionData> ProductionData { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<TimeLog> TimeLog { get; set; }
        public virtual ICollection<TimeLogForInsert> TimeLogForInsert { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<WageGroups> WageGroups { get; set; }
        public virtual ICollection<WorkGroupAssignments> WorkGroupAssignments { get; set; }
        public virtual ICollection<WorkGroups> WorkGroups { get; set; }
    }
}
