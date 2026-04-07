using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool WageGroups_DoesTokenExist(int idSubsidiary, string wageGroupToken, ADDBNullable<int> excludeIDWageGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WageGroups_DoesTokenExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = wageGroupToken;
                locCmd.Parameters.Add("@ExcludeIDWageGroup", SqlDbType.Int).Value = excludeIDWageGroup.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int WageGroups_Add(WageGroupInfo wgi, int createdByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WageGroups_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary;
                locCmd.Parameters.Add("@IDCurrency", SqlDbType.Int).Value = wgi.IDCurrency;
                locCmd.Parameters.Add("@IsTemplate", SqlDbType.Bit).Value = wgi.IsTemplate;
                locCmd.Parameters.Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = wgi.WageGroupToken;
                locCmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 4000).Value = wgi.Comment.Value;
                locCmd.Parameters.Add("@HourlyRate", SqlDbType.Money).Value = wgi.HourlyRate;
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@IDWageGroupNew", SqlDbType.Int);
                locCmd.Parameters["@IDWageGroupNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDWageGroupNew"].Value;
            }
        }

        public int WageGroups_Edit(WageGroupInfo wgi, int lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WageGroups_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary;
                locCmd.Parameters.Add("@IDCurrency", SqlDbType.Int).Value = wgi.IDCurrency;
                locCmd.Parameters.Add("@IDWageGroup", SqlDbType.Int).Value = wgi.IDWageGroup;
                locCmd.Parameters.Add("@IsTemplate", SqlDbType.Bit).Value = wgi.IsTemplate;
                locCmd.Parameters.Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = wgi.WageGroupToken;
                locCmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 4000).Value = wgi.Comment.Value;
                locCmd.Parameters.Add("@HourlyRate", SqlDbType.Money).Value = wgi.HourlyRate;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                locCmd.Parameters.Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = FacessoGeneric.ConsiderHistoryMaintenance;
                locCmd.Parameters.Add("@IDWageGroupNew", SqlDbType.Int);
                locCmd.Parameters["@IDWageGroupNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDWageGroupNew"].Value;
            }
        }

        public WageGroupInfoCollection WageGroupInfoCollection
        {
            get
            {
                SqlConnection locConnection = GetOpenedConnectionSafely();
                if (locConnection == null) return null;
                using (locConnection)
                {
                    var locCommand = new SqlCommand(
                        "SELECT [WageGroups].*,[Currencies].[CurrencyToken] From [WageGroups] " +
                        "[WageGroups] INNER JOIN [Currencies] ON " +
                        "[WageGroups].[IDCurrency] = [Currencies].[IDCurrency] WHERE " +
                        "[WageGroups].[IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary +
                        " AND [WageGroups].[IsCurrent]='true'", locConnection);
                    SqlDataReader locDR = locCommand.ExecuteReader();
                    if (locDR.HasRows)
                    {
                        var locWic = new WageGroupInfoCollection();
                        while (locDR.Read())
                        {
                            var locWageGroupInfo = new WageGroupInfo(locDR, true);
                            locWic.Add(locWageGroupInfo);
                        }
                        return locWic;
                    }
                    return null;
                }
            }
        }

        public WageGroupInfo GetWageGroup(int idSubsidiary, int idWageGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [WageGroups].*,[WageGroups].[CurrencyToken] From [WageGroups] " +
                    "[WageGroups] INNER JOIN [Currencies] ON " +
                    "[WageGroups].[IDCurrency] = [Currencies].[IDCurrency] WHERE " +
                    "[WageGroups].[IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary +
                    " AND [WageGroups].[IDWageGroups]=" + idWageGroup, locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new WageGroupInfo(locDR, true);
                }
                return null;
            }
        }
    }
}
