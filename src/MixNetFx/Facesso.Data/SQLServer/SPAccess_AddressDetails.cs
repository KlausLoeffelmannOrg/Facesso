using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        /// <summary>
        /// Adds address details. Returns the new IDAddressDetails.
        /// Note: The VB original accessed the output parameter by index 18, but only 17 parameters
        /// are added (indices 0-16). This is corrected here to use named parameter access.
        /// </summary>
        public int SP_CostCenters_AddAddressDetails(AddressDetailsInfo addressDetails)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("sp_AddressDetails_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = addressDetails.IDSubsidiary;
                locCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = addressDetails.LastName.Value;
                locCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 100).Value = addressDetails.MiddleName.Value;
                locCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = addressDetails.FirstName.Value;
                locCmd.Parameters.Add("@Titel", SqlDbType.NVarChar, 100).Value = addressDetails.Titel.Value;
                locCmd.Parameters.Add("@Street", SqlDbType.NVarChar, 100).Value = addressDetails.Street.Value;
                locCmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 10).Value = addressDetails.Zip.Value;
                locCmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = addressDetails.City.Value;
                locCmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar, 10).Value = addressDetails.CountryCode.Value;
                locCmd.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = addressDetails.Country.Value;
                locCmd.Parameters.Add("@CompanyTel", SqlDbType.NVarChar, 100).Value = addressDetails.CompanyPhone.Value;
                locCmd.Parameters.Add("@PrivateTel", SqlDbType.NVarChar, 100).Value = addressDetails.PrivatePhone.Value;
                locCmd.Parameters.Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = addressDetails.CompanyEmail.Value;
                locCmd.Parameters.Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = addressDetails.PrivateEmail.Value;
                locCmd.Parameters.Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = addressDetails.CompanyMobile.Value;
                locCmd.Parameters.Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = addressDetails.PrivateMobile.Value;
                locCmd.Parameters.Add("@URL", SqlDbType.NVarChar, 255).Value = addressDetails.URL.Value;
                // Output parameter — VB code used index 18 but only 17 params were added (indices 0-16);
                // corrected here to add the parameter explicitly and access by name.
                locCmd.Parameters.Add("@IDAddressDetailsNew", SqlDbType.Int);
                locCmd.Parameters["@IDAddressDetailsNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDAddressDetailsNew"].Value;
            }
        }
    }
}
