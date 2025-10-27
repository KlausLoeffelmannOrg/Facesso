using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class AddressDetails
    {
        public AddressDetails()
        {
            Employees = new HashSet<Employees>();
            Users = new HashSet<Users>();
        }

        public Guid IdaddressDetail { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int? PersonnelNo { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string CompanyPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string CompanyEmail { get; set; }
        public string PrivateEmail { get; set; }
        public string CompanyMobile { get; set; }
        public string PrivateMobile { get; set; }
        public string Url { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
