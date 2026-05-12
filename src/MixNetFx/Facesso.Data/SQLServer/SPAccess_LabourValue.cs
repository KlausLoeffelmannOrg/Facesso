using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool LabourValues_DoesNumberExist(int idSubsidiary, int labourValueNumber, ADDBNullable<int> excludeIDLabourValue)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("LabourValues_DoesNumberExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@LabourValueNumber", SqlDbType.Int).Value = labourValueNumber;
                locCmd.Parameters.Add("@ExcludeIDLabourValue", SqlDbType.Int).Value = excludeIDLabourValue.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int LabourValues_Add(LabourValueInfo lvi, int createdByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("LabourValues_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter;
                locCmd.Parameters.Add("@LabourValueNumber", SqlDbType.Int).Value = lvi.LabourValueNumber;
                locCmd.Parameters.Add("@LabourValueName", SqlDbType.NVarChar, 100).Value = lvi.LabourValueName;
                locCmd.Parameters.Add("@LabourValueDescription", SqlDbType.NVarChar, 4000).Value = lvi.LabourValueDescription.Value;
                locCmd.Parameters.Add("@TeHMin", SqlDbType.Float).Value = lvi.TeHMin;
                locCmd.Parameters.Add("@Dimension", SqlDbType.NVarChar, 100).Value = lvi.Dimension;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = lvi.IsActive;
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@IDLabourValueNew", SqlDbType.Int);
                locCmd.Parameters["@IDLabourValueNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDLabourValueNew"].Value;
            }
        }

        public bool LabourValues_IsInUse(LabourValueInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("LabourValues_IsInUse", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IsInUse", SqlDbType.Bit);
                locCmd.Parameters["@IsInUse"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return (bool)locCmd.Parameters["@IsInUse"].Value;
            }
        }

        public void LabourValues_Delete(LabourValueInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("LabourValues_Delete", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.ExecuteNonQuery();
            }
        }

        public int LabourValues_Edit(LabourValueInfo lvi, int lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("LabourValues_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter;
                locCmd.Parameters.Add("@LabourValueNumber", SqlDbType.Int).Value = lvi.LabourValueNumber;
                locCmd.Parameters.Add("@LabourValueName", SqlDbType.NVarChar, 100).Value = lvi.LabourValueName;
                locCmd.Parameters.Add("@LabourValueDescription", SqlDbType.NVarChar, 4000).Value = lvi.LabourValueDescription.Value;
                locCmd.Parameters.Add("@TeHMin", SqlDbType.Float).Value = lvi.TeHMin;
                locCmd.Parameters.Add("@Dimension", SqlDbType.NVarChar, 100).Value = lvi.Dimension;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = lvi.IsActive;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                locCmd.Parameters.Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = FacessoGeneric.ConsiderHistoryMaintenance;
                locCmd.Parameters.Add("@IDLabourValueNew", SqlDbType.Int);
                locCmd.Parameters["@IDLabourValueNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDLabourValueNew"].Value;
            }
        }

        public LabourValueInfoCollection GetLabourValueInfoCollection()
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [LabourValues].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName], [CostCenters].[BaseValuePrecision], [CostCenters].[BaseValueSynonym] From [LabourValues] " +
                    "[LabourValues] INNER JOIN [CostCenters] ON " +
                    "[LabourValues].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " +
                    "[LabourValues].[IDSubsidiary]=@IDSubsidiary" +
                    " AND [LabourValues].[IsCurrent]='true'", locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    var locLic = new LabourValueInfoCollection();
                    while (locDR.Read())
                    {
                        var locLabourValueInfo = new LabourValueInfo(locDR, true);
                        locLic.Add(locLabourValueInfo);
                    }
                    return locLic;
                }
                return null;
            }
        }

        public LabourValueInfoCollection GetLabourValueInfoCollection(string orderByString)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    BuildGetLabourValueInfoCollectionOrderBySql(orderByString),
                    locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    var locLic = new LabourValueInfoCollection();
                    while (locDR.Read())
                    {
                        var locLabourValueInfo = new LabourValueInfo(locDR, true);
                        locLic.Add(locLabourValueInfo);
                    }
                    return locLic;
                }
                return null;
            }
        }

        private static string BuildGetLabourValueInfoCollectionOrderBySql(string orderByColumn)
        {
            return "SELECT [LabourValues].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName], [CostCenters].[BaseValuePrecision], [CostCenters].[BaseValueSynonym] From [LabourValues] " +
                   "[LabourValues] INNER JOIN [CostCenters] ON " +
                   "[LabourValues].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " +
                   "[LabourValues].[IDSubsidiary]=@IDSubsidiary" +
                   " AND [LabourValues].[IsCurrent]='true'" +
                   " ORDER BY " + QuoteSqlIdentifier(orderByColumn);
        }

        public LabourValueInfo GetLabourValueByID(int idSubsidiary, int idLabourValue)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT * From [LabourValues] " +
                    " WHERE [IDSubsidiary]=@IDSubsidiary" +
                    " AND [IDLabourValue]=@IDLabourValue" +
                    " AND [IsCurrent]='true'", locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCommand.Parameters.Add("@IDLabourValue", SqlDbType.Int).Value = idLabourValue;
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new LabourValueInfo(locDR);
                }
                return null;
            }
        }

        public LabourValueInfo GetLabourValueByNumber(int idSubsidiary, int labourValueNumber)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT * From [LabourValues] " +
                    " WHERE [IDSubsidiary]=@IDSubsidiary" +
                    " AND [LabourValueNumber]=@LabourValueNumber" +
                    " AND [IsCurrent]='true'", locConnection);
                locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                locCommand.Parameters.Add("@LabourValueNumber", SqlDbType.Int).Value = labourValueNumber;
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new LabourValueInfo(locDR);
                }
                return null;
            }
        }
    }
}
