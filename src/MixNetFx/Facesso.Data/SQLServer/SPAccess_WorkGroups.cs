using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool WorkGroups_DoesWorkGroupNumberExist(int idSubsidiary, int workGroupNumber, ADDBNullable<int> excludeIDWorkGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_DoesWorkGroupNumberExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@WorkGroupNumber", SqlDbType.Int).Value = workGroupNumber;
                locCmd.Parameters.Add("@ExcludeIDWorkGroup", SqlDbType.Int).Value = excludeIDWorkGroup.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public bool WorkGroups_DoesWorkGroupNameExist(int idSubsidiary, string workGroupName, ADDBNullable<int> excludeIDWorkGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_DoesWorkGroupNameExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@WorkGroupName", SqlDbType.NVarChar, 20).Value = workGroupName;
                locCmd.Parameters.Add("@ExcludeIDWorkGroup", SqlDbType.Int).Value = excludeIDWorkGroup.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int WorkGroups_Add(WorkGroupInfo wgi, int createdByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = wgi.IDCostCenter;
                locCmd.Parameters.Add("@WorkGroupNumber", SqlDbType.Int).Value = wgi.WorkGroupNumber;
                locCmd.Parameters.Add("@WorkGroupName", SqlDbType.NVarChar, 100).Value = wgi.WorkGroupName;
                locCmd.Parameters.Add("@WorkGroupDescription", SqlDbType.NVarChar, 4000).Value = wgi.WorkGroupDescription.Value;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = wgi.IsActive;
                locCmd.Parameters.Add("@IsPeaceWork", SqlDbType.Bit).Value = wgi.IsPeaceWork;
                locCmd.Parameters.Add("@IsConceptional", SqlDbType.Bit).Value = wgi.IsConceptional;
                locCmd.Parameters.Add("@OrdinalNo", SqlDbType.Int).Value = wgi.OrdinalNo;
                locCmd.Parameters.Add("@TimeSettingDetails", SqlDbType.Xml).Value = wgi.TimeSettingDetails.XMLString();
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@IDWorkGroupNew", SqlDbType.Int);
                locCmd.Parameters["@IDWorkGroupNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDWorkGroupNew"].Value;
            }
        }

        public bool WorkGroups_IsInUse(WorkGroupInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_IsInUse", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IsInUse", SqlDbType.Bit);
                locCmd.Parameters["@IsInUse"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return (bool)locCmd.Parameters["@IsInUse"].Value;
            }
        }

        public void WorkGroups_Delete(WorkGroupInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                // Remove assignments first
                var locCmd = new SqlCommand("WorkGroups_DeleteAssignment", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup;
                locCmd.ExecuteNonQuery();

                // Delete workgroup
                locCmd = new SqlCommand("WorkGroups_Delete", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.ExecuteNonQuery();
            }
        }

        public int WorkGroups_Edit(WorkGroupInfo wgi, int lastEditedByIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = wgi.IDWorkGroup;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = wgi.IDCostCenter;
                locCmd.Parameters.Add("@WorkGroupNumber", SqlDbType.Int).Value = wgi.WorkGroupNumber;
                locCmd.Parameters.Add("@WorkGroupName", SqlDbType.NVarChar, 100).Value = wgi.WorkGroupName;
                locCmd.Parameters.Add("@WorkGroupDescription", SqlDbType.NVarChar, 4000).Value = wgi.WorkGroupDescription.Value;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = wgi.IsActive;
                locCmd.Parameters.Add("@IsPeaceWork", SqlDbType.Bit).Value = wgi.IsPeaceWork;
                locCmd.Parameters.Add("@OrdinalNo", SqlDbType.Int).Value = wgi.OrdinalNo;
                locCmd.Parameters.Add("@IsConceptional", SqlDbType.Bit).Value = wgi.IsConceptional;
                locCmd.Parameters.Add("@TimeSettingDetails", SqlDbType.Xml).Value = wgi.TimeSettingDetails.XMLString();
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                locCmd.Parameters.Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = FacessoGeneric.ConsiderHistoryMaintenance;
                locCmd.Parameters.Add("@IDWorkGroupNew", SqlDbType.Int);
                locCmd.Parameters["@IDWorkGroupNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDWorkGroupNew"].Value;
            }
        }

        internal void GetWorkGroupInfoCollection(CombinedParametersInfo cpInfo, WorkGroupInfoItems wgi, WorkGroupInfoItemsGetType wgiGetType)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_GetItems", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                if (cpInfo == null)
                {
                    locCmd.Parameters.Add("@Shift", SqlDbType.Int).Value = DBNull.Value;
                    locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    locCmd.Parameters.Add("@Shift", SqlDbType.Int).Value = cpInfo.Shift;
                    locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = cpInfo.ProductionDate;
                }
                locCmd.Parameters.Add("@JoinedWithCostCenter", SqlDbType.Bit).Value =
                    (wgiGetType & WorkGroupInfoItemsGetType.JoinedWithCostCenter) == WorkGroupInfoItemsGetType.JoinedWithCostCenter;

                SqlDataReader locDr = locCmd.ExecuteReader();
                if (locDr.HasRows)
                {
                    while (locDr.Read())
                    {
                        var locWorkGroupInfo = new WorkGroupInfo(locDr, wgiGetType);
                        wgi.Add(locWorkGroupInfo);
                    }
                }
            }
        }

        public void AssignLabourValuesToWorkGroup(int idSubsidiary, int idWorkGroup, LabourValueInfoCollection labourValues)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            int locCount = 1;
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_DeleteAssignment", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = idWorkGroup;
                locCmd.ExecuteNonQuery();

                foreach (LabourValueInfo locLvi in labourValues)
                {
                    locCmd = new SqlCommand("WorkGroups_AddAssignmentRecord", locConnection);
                    locCmd.CommandType = CommandType.StoredProcedure;
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                    locCmd.Parameters.Add("@IDLabourValueInternal", SqlDbType.Int).Value = locLvi.IDLabourValueInternal;
                    locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = idWorkGroup;
                    locCmd.Parameters.Add("@OrdinalNumber", SqlDbType.Int).Value = locCount;
                    locCmd.ExecuteNonQuery();
                    locCount++;
                }
            }
        }

        internal LabourValueInfoCollection WorkGroups_GetAssignedLabourValues(int idSubsidiary, int idWorkGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCmd = new SqlCommand("WorkGroups_GetAssignedLabourValues", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = idWorkGroup;
                SqlDataReader locDr = locCmd.ExecuteReader();
                if (locDr.HasRows)
                {
                    var locLic = new LabourValueInfoCollection();
                    while (locDr.Read())
                    {
                        var locLabourValueInfo = new LabourValueInfo(locDr, true);
                        locLic.Add(locLabourValueInfo);
                    }
                    return locLic;
                }
                return null;
            }
        }

        internal WorkGroupInfo GetWorkGroup(int idSubsidiary, int idWorkGroup)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [WorkGroups].*,CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension," +
                    "CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym FROM [WorkGroups] " +
                    "[WorkGroups] INNER JOIN [CostCenters] ON " +
                    "[WorkGroups].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " +
                    "[WorkGroups].[IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary +
                    " AND [WorkGroups].[IsCurrent]='true' AND" +
                    "[WorkGroups].[IDWorkGroup]=" + idWorkGroup, locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter);
                }
                return null;
            }
        }

        internal WorkGroupInfo GetWorkGroupByWorkGroupNumber(int idSubsidiary, int workGroupNumber)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                var locCommand = new SqlCommand(
                    "SELECT [WorkGroups].*,CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension," +
                    "CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym FROM [WorkGroups] " +
                    "[WorkGroups] INNER JOIN [CostCenters] ON " +
                    "[WorkGroups].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " +
                    "[WorkGroups].[IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary +
                    " AND [WorkGroups].[IsCurrent]=1 AND" +
                    "[WorkGroups].[WorkGroupNumber]=" + workGroupNumber, locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    return new WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter);
                }
                return null;
            }
        }
    }
}
