using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso
{
    public class SubsidiaryInfo : InfoItemBase
    {
        private int myIDSubsidiary;
        private string mySubsidiaryName;
        private string myStreet;
        private string myCity;
        private string myZip;
        private string myCountryCode;
        private string myCountry;
        private string myPrimaryPhone;

        private static string sharedSName;

        static SubsidiaryInfo()
        {
            sharedSName = RegistryHelper.SubsidiarySubstitutionName;
        }

        public override string DisplayName => mySubsidiaryName;

        public virtual int IDSubsidiary
        {
            get { return myIDSubsidiary; }
            set { myIDSubsidiary = value; }
        }

        [ActiveDev.ADAutoReportColumn("Name Subsidiarität", -2, 0)]
        public virtual string SubsidiaryName
        {
            get { return mySubsidiaryName; }
            set { mySubsidiaryName = value; }
        }

        [ActiveDev.ADAutoReportColumn("Straße", -2, 1)]
        public virtual string Street
        {
            get { return myStreet; }
            set { myStreet = value; }
        }

        [ActiveDev.ADAutoReportColumn("Ort", -2, 3)]
        public virtual string City
        {
            get { return myCity; }
            set { myCity = value; }
        }

        [ActiveDev.ADAutoReportColumn("PLZ", -2, 2)]
        public virtual string Zip
        {
            get { return myZip; }
            set { myZip = value; }
        }

        public virtual string CountryCode
        {
            get { return myCountryCode; }
            set { myCountryCode = value; }
        }

        [ActiveDev.ADAutoReportColumn("Land", -2, 4)]
        public virtual string Country
        {
            get { return myCountry; }
            set { myCountry = value; }
        }

        public virtual string PrimaryPhone
        {
            get { return myPrimaryPhone; }
            set { myPrimaryPhone = value; }
        }

        public override string ToString() => SubsidiaryName;

        public override int DataID => IDSubsidiary;
    }

    public class SubsidiaryInfoCollection : KeyedCollection<int, SubsidiaryInfo>
    {
        public SubsidiaryInfoCollection(string connectionString) : base()
        {
            var locConnection = new SqlConnection(FacessoGeneric.SQLConnectionString);
            using (locConnection)
            {
                locConnection.Open();
                var locCommand = new SqlCommand("SELECT * FROM [Subsidiaries] ORDER by [SubsidiaryName]", locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                while (locDR.Read())
                {
                    var locSi = new SubsidiaryInfo();
                    locSi.IDSubsidiary = locDR.GetInt32(locDR.GetOrdinal("IDSubsidiary"));
                    locSi.SubsidiaryName = locDR.GetString(locDR.GetOrdinal("SubsidiaryName"));
                    locSi.Street = locDR.GetString(locDR.GetOrdinal("Street"));
                    locSi.Zip = locDR.GetString(locDR.GetOrdinal("Zip"));
                    locSi.City = locDR.GetString(locDR.GetOrdinal("City"));
                    locSi.CountryCode = locDR.GetString(locDR.GetOrdinal("CountryCode"));
                    locSi.Country = locDR.GetString(locDR.GetOrdinal("Country"));
                    locSi.PrimaryPhone = locDR.GetString(locDR.GetOrdinal("PrimaryPhone"));
                    Add(locSi);
                }
            }
        }

        protected override int GetKeyForItem(SubsidiaryInfo item) => item.IDSubsidiary;
    }
}
