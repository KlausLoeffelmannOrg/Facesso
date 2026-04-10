using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool CostCenters_DoesNumberExist(int idSubsidiary, int costCenterNo, ADDBNullable<int> excludeIDCostCenter)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("CostCenters_DoesNumberExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@CostCenterNo", SqlDbType.Int).Value = costCenterNo;
                locCmd.Parameters.Add("@ExcludeIDCostCenter", SqlDbType.Int).Value = excludeIDCostCenter.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters[3].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters[3].Value;
            }
        }

        public int CostCenters_Add(CostcenterInfo cci, int createdByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("CostCenters_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = cci.IDSubsidiary;
                locCmd.Parameters.Add("@CostCenterNo", SqlDbType.Int).Value = cci.CostCenterNo;
                locCmd.Parameters.Add("@CostCenterName", SqlDbType.NVarChar, 100).Value = cci.CostCenterName;
                locCmd.Parameters.Add("@CostCenterDescription", SqlDbType.NVarChar, 4000).Value = cci.CostCenterDescription.Value;
                locCmd.Parameters.Add("@IDCurrency", SqlDbType.NVarChar, 50).Value = cci.IDCurrency;
                locCmd.Parameters.Add("@IncentiveIndicatorSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorSynonym;
                locCmd.Parameters.Add("@IncentiveWageSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveWageSynonym;
                locCmd.Parameters.Add("@IncentiveIndicatorDimension", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorDimension;
                locCmd.Parameters.Add("@IncentiveIndicatorPrecision", SqlDbType.TinyInt).Value = cci.IncentiveIndicatorPrecision;
                locCmd.Parameters.Add("@UseFixValuedBonus", SqlDbType.Bit).Value = cci.UseFixValuedBonus;
                locCmd.Parameters.Add("@IncentiveIndicatorFactor", SqlDbType.Decimal).Value = cci.IncentiveIndicatorFactor;
                locCmd.Parameters.Add("@BaseValuePrecision", SqlDbType.TinyInt).Value = cci.BaseValuePrecision;
                locCmd.Parameters.Add("@BaseValueSynonym", SqlDbType.NVarChar, 50).Value = cci.BaseValueSynonym;
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@IDCostCenterNew", SqlDbType.Int);
                locCmd.Parameters["@IDCostCenterNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDCostCenterNew"].Value;
            }
        }

        public int CostCenters_Edit(CostcenterInfo cci, int lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("CostCenters_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = cci.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = cci.IDCostCenter;
                locCmd.Parameters.Add("@CostCenterNo", SqlDbType.Int).Value = cci.CostCenterNo;
                locCmd.Parameters.Add("@CostCenterName", SqlDbType.NVarChar, 100).Value = cci.CostCenterName;
                locCmd.Parameters.Add("@CostCenterDescription", SqlDbType.NVarChar, 4000).Value = cci.CostCenterDescription.Value;
                locCmd.Parameters.Add("@IDCurrency", SqlDbType.NVarChar, 50).Value = cci.IDCurrency;
                locCmd.Parameters.Add("@IncentiveIndicatorSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorSynonym;
                locCmd.Parameters.Add("@IncentiveWageSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveWageSynonym;
                locCmd.Parameters.Add("@IncentiveIndicatorDimension", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorDimension;
                locCmd.Parameters.Add("@IncentiveIndicatorPrecision", SqlDbType.TinyInt).Value = cci.IncentiveIndicatorPrecision;
                locCmd.Parameters.Add("@UseFixValuedBonus", SqlDbType.Bit).Value = cci.UseFixValuedBonus;
                locCmd.Parameters.Add("@IncentiveIndicatorFactor", SqlDbType.Decimal).Value = cci.IncentiveIndicatorFactor;
                locCmd.Parameters.Add("@BaseValuePrecision", SqlDbType.TinyInt).Value = cci.BaseValuePrecision;
                locCmd.Parameters.Add("@BaseValueSynonym", SqlDbType.NVarChar, 50).Value = cci.BaseValueSynonym;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                locCmd.Parameters.Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = FacessoGeneric.ConsiderHistoryMaintenance;
                locCmd.Parameters.Add("@IDCostCenterNew", SqlDbType.Int);
                locCmd.Parameters["@IDCostCenterNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDCostCenterNew"].Value;
            }
        }

        public bool CostCenters_IsInUse(CostcenterInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("CostCenters_IsInUse", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IsInUse", SqlDbType.Bit);
                locCmd.Parameters["@IsInUse"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return (bool)locCmd.Parameters["@IsInUse"].Value;
            }
        }

        public void CostCenters_Delete(CostcenterInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("CostCenters_Delete", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.ExecuteNonQuery();
            }
        }

        public CostcenterInfoItems CostCenterInfoItems
        {
            get
            {
                SqlConnection locConnection = GetOpenedConnectionSafely();
                if (locConnection == null) return null;
                using (locConnection)
                {
                    var locCommand = new SqlCommand(
                        "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " +
                        "[CostCenters] INNER JOIN [Currencies] ON " +
                        "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " +
                        "[CostCenters].[IDSubsidiary]=@IDSubsidiary" +
                        " AND [CostCenters].[IsCurrent]=1", locConnection);
                    locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                    SqlDataReader locDR = locCommand.ExecuteReader();
                    if (locDR.HasRows)
                    {
                        var locUIC = new CostcenterInfoItems();
                        while (locDR.Read())
                        {
                            var locCostcenterInfo = new CostcenterInfo(locDR, true);
                            locUIC.Add(locCostcenterInfo);
                        }
                        return locUIC;
                    }
                    return null;
                }
            }
        }

        public CostcenterInfo GetCostCenter(int idSubsidiary, int idCostCenter)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " +
                    "[CostCenters] INNER JOIN [Currencies] ON " +
                    "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " +
                    "[CostCenters].[IDSubsidiary]=@IDSubsidiary" +
                    " AND [CostCenters].[IDCostCenter]=@IDCostCenter", locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCommand.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = idCostCenter;
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new CostcenterInfo(locDR, true);
                }
                return null;
            }
        }

        public CostcenterInfo GetCurrentBaseCostCenter(int idSubsidiary)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " +
                    "[CostCenters] INNER JOIN [Currencies] ON " +
                    "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " +
                    "[CostCenters].[IDSubsidiary]=@IDSubsidiary" +
                    " AND [CostCenters].[IDCostCenterInternal]=@IDCostCenterInternal", locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCommand.Parameters.Add("@IDCostCenterInternal", SqlDbType.Int).Value = 0;
                SqlDataReader locDR = locCommand.ExecuteReader();
                locDR.Read();
                return new CostcenterInfo(locDR, true);
            }
        }
    }
}
