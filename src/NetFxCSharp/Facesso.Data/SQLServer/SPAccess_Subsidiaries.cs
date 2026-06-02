using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool Subsidiaries_DoesNameExist(string subsidiaryName, ADDBNullable<int> excludeIDSubsidiary)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Subsidiaries_DoesNameExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = subsidiaryName;
                locCmd.Parameters.Add("@ExcludeIDSubsidiary", SqlDbType.Int).Value = excludeIDSubsidiary.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int Subsidiaries_Add(SubsidiaryInfo si, int createdByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Subsidiaries_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = si.SubsidiaryName;
                locCmd.Parameters.Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = si.Street;
                locCmd.Parameters.Add("@SubsidiaryZip", SqlDbType.NVarChar, 10).Value = si.Zip;
                locCmd.Parameters.Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = si.City;
                locCmd.Parameters.Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = si.CountryCode;
                locCmd.Parameters.Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = si.Country;
                locCmd.Parameters.Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = si.PrimaryPhone;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@IDSubsidiaryCreated", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary;
                locCmd.Parameters.Add("@IDSubsidiaryNew", SqlDbType.Int);
                locCmd.Parameters["@IDSubsidiaryNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDSubsidiaryNew"].Value;
            }
        }

        public void Subsidiaries_Edit(SubsidiaryInfo si, int lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Subsidiaries_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = si.IDSubsidiary;
                locCmd.Parameters.Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = si.SubsidiaryName;
                locCmd.Parameters.Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = si.Street;
                locCmd.Parameters.Add("@SubsidiaryZip", SqlDbType.NVarChar, 10).Value = si.Zip;
                locCmd.Parameters.Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = si.City;
                locCmd.Parameters.Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = si.CountryCode;
                locCmd.Parameters.Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = si.Country;
                locCmd.Parameters.Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = si.PrimaryPhone;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                locCmd.Parameters.Add("@IDSubsidiaryEdited", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary;
                locCmd.ExecuteReader();
            }
        }

        public void Subsidiaries_Delete(SubsidiaryInfo si, UserInfo lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Subsidiaries_Delete", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = si.IDSubsidiary;
                locCmd.Parameters.Add("@DeletedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser.IDUser;
                locCmd.Parameters.Add("@IDSubsidiaryContainingUser", SqlDbType.Int).Value = lastEditedByIDUser.IDSubsidiary;
                locCmd.ExecuteReader();
            }
        }
    }
}
