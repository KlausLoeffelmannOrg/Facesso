using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Users
    {
        public Users()
        {
            ApplicationSettings = new HashSet<ApplicationSettings>();
            FunctionLog = new HashSet<FunctionLog>();
        }

        public Guid Iduser { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IduserInternal { get; set; }
        public Guid IdcostCenter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? IdaddressDetails { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public long ClearanceLevel { get; set; }
        public bool HasWorkstationAccess { get; set; }
        public bool HasInternetAccess { get; set; }
        public bool IsActivated { get; set; }
        public bool? IsCurrent { get; set; }
        public bool DoesExpire { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsSystemAccount { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public string Comment { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<ApplicationSettings> ApplicationSettings { get; set; }
        public virtual ICollection<FunctionLog> FunctionLog { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
        public virtual AddressDetails Id { get; set; }
        public virtual CostCenters IdNavigation { get; set; }
    }
}
