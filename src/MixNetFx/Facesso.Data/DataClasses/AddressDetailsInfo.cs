using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    [System.CLSCompliant(true)]
    public class AddressDetailsInfo : InfoItemBase
    {
        protected int myIDAddressDetail;
        protected int myIDSubsidiary;
        protected ADDBNullable<int> myPersonnelNo;
        protected ADDBNullable<string> myLastName;
        protected ADDBNullable<string> myMiddleName;
        protected ADDBNullable<string> myFirstName;
        protected ADDBNullable<string> myTitle;
        protected ADDBNullable<string> myStreet;
        protected ADDBNullable<string> myZip;
        protected ADDBNullable<string> myCity;
        protected ADDBNullable<string> myCountryCode;
        protected ADDBNullable<string> myCountry;
        protected ADDBNullable<string> myCompanyEmail;
        protected ADDBNullable<string> myPrivateEmail;
        protected ADDBNullable<string> myCompanyPhone;
        protected ADDBNullable<string> myPrivatePhone;
        protected ADDBNullable<string> myCompanyMobile;
        protected ADDBNullable<string> myPrivateMobile;
        protected ADDBNullable<string> myURL;

        public AddressDetailsInfo() { }

        public AddressDetailsInfo(int idAddressDetail, int idSubsidiary,
            ADDBNullable<int> personnelNo, ADDBNullable<string> lastName,
            ADDBNullable<string> middleName, ADDBNullable<string> firstName,
            ADDBNullable<string> titel, ADDBNullable<string> street,
            ADDBNullable<string> zip, ADDBNullable<string> city,
            ADDBNullable<string> countryCode, ADDBNullable<string> country,
            ADDBNullable<string> companyTel, ADDBNullable<string> companyEmail,
            ADDBNullable<string> privateTel,
            ADDBNullable<string> companyMobile, ADDBNullable<string> privateMobile,
            ADDBNullable<string> privateEmail, ADDBNullable<string> url)
        {
            myIDAddressDetail = idAddressDetail;
            myIDSubsidiary = idSubsidiary;
            myPersonnelNo = personnelNo;
            myLastName = lastName;
            myMiddleName = middleName;
            myFirstName = firstName;
            myTitle = titel;
            myStreet = street;
            myZip = zip;
            myCity = city;
            myCountry = country;
            myCountryCode = countryCode;
            myCompanyPhone = companyTel;
            myPrivatePhone = privateTel;
            myCompanyMobile = companyMobile;
            myCompanyEmail = companyEmail;
            myPrivateMobile = privateMobile;
            myPrivateEmail = privateEmail;
            myURL = url;
        }

        public int IDAddressDetail
        {
            get { return myIDAddressDetail; }
            set { myIDAddressDetail = value; }
        }

        public int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        public ADDBNullable<int> PersonnelNo
        {
            get { return myPersonnelNo; }
            set { myPersonnelNo = value; }
        }

        public ADDBNullable<string> LastName
        {
            get { return myLastName; }
            set { myLastName = value; }
        }

        public ADDBNullable<string> MiddleName
        {
            get { return myMiddleName; }
            set { myMiddleName = value; }
        }

        public ADDBNullable<string> FirstName
        {
            get { return myFirstName; }
            set { myFirstName = value; }
        }

        public ADDBNullable<string> Titel
        {
            get { return myTitle; }
            set { myTitle = value; }
        }

        public ADDBNullable<string> Street
        {
            get { return myStreet; }
            set { myStreet = value; }
        }

        public ADDBNullable<string> Zip
        {
            get { return myZip; }
            set { myZip = value; }
        }

        public ADDBNullable<string> City
        {
            get { return myCity; }
            set { myCity = value; }
        }

        public ADDBNullable<string> CountryCode
        {
            get { return myCountryCode; }
            set { myCountryCode = value; }
        }

        public ADDBNullable<string> Country
        {
            get { return myCountry; }
            set { myCountry = value; }
        }

        public ADDBNullable<string> CompanyPhone
        {
            get { return myCompanyPhone; }
            set { myCompanyPhone = value; }
        }

        public ADDBNullable<string> PrivatePhone
        {
            get { return myPrivatePhone; }
            set { myPrivatePhone = value; }
        }

        public ADDBNullable<string> CompanyMobile
        {
            get { return myCompanyMobile; }
            set { myCompanyMobile = value; }
        }

        public ADDBNullable<string> CompanyEmail
        {
            get { return myCompanyEmail; }
            set { myCompanyEmail = value; }
        }

        public ADDBNullable<string> PrivateMobile
        {
            get { return myPrivateMobile; }
            set { myPrivateMobile = value; }
        }

        public ADDBNullable<string> PrivateEmail
        {
            get { return myPrivateEmail; }
            set { myPrivateEmail = value; }
        }

        public ADDBNullable<string> URL
        {
            get { return myURL; }
            set { myURL = value; }
        }

        public override int DataID => myIDAddressDetail;

        public override string DisplayName => (string)LastName;
    }
}
