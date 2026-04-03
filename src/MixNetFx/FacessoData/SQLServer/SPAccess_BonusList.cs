using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public void BonusList_AddEntry(BonusListItem bli, int idUserCreated)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("BonusList_AddEntry", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = bli.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = bli.CostCenterInfo.IDCostCenter;
                locCmd.Parameters.Add("@DegreeOfTime", SqlDbType.Float).Value = bli.DegreeOfTime;
                locCmd.Parameters.Add("@Percentage", SqlDbType.Float).Value = bli.Percentage;
                locCmd.Parameters.Add("@AbsoluteValue", SqlDbType.Float).Value = bli.AbsoluteValue;
                locCmd.Parameters.Add("@IDUserCreated", SqlDbType.Int).Value = idUserCreated;
                locCmd.ExecuteReader();
            }
        }

        public void BonusList_CreateBaseList(int idSubsidiary, int idCostCenter, int idUserCreated)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("BonusList_CreateBaseList", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = idCostCenter;
                locCmd.Parameters.Add("@IDUserCreated", SqlDbType.Int).Value = idUserCreated;
                locCmd.ExecuteReader();
            }
        }

        public void BonusList_DeleteList(int idSubsidiary, int idCostCenter, int idUserCalled)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("BonusList_DeleteList", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = idCostCenter;
                locCmd.Parameters.Add("@IDUserCalled", SqlDbType.Int).Value = idUserCalled;
                locCmd.ExecuteReader();
            }
        }

        public void BonusList_FromBaseCostCenter(int idSubsidiary, int idBaseCostCenter, int forIDCostCenter, int idUserCalled)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("BonusList_FromBaseCostCenter", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDBaseCostCenter", SqlDbType.Int).Value = idBaseCostCenter;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = forIDCostCenter;
                locCmd.Parameters.Add("@IDUserCalled", SqlDbType.Int).Value = idUserCalled;
                locCmd.ExecuteReader();
            }
        }

        public void BonusList_ReplaceEntry(BonusListItem bli, int idUserCalled)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("BonusList_ReplaceEntry", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = bli.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = bli.CostCenterInfo.IDCostCenter;
                locCmd.Parameters.Add("@DegreeOfTime", SqlDbType.Float).Value = bli.DegreeOfTime;
                locCmd.Parameters.Add("@Percentage", SqlDbType.Float).Value = bli.Percentage;
                locCmd.Parameters.Add("@AbsoluteValue", SqlDbType.Float).Value = bli.AbsoluteValue;
                locCmd.Parameters.Add("@IDUserCalled", SqlDbType.Int).Value = idUserCalled;
                locCmd.ExecuteReader();
            }
        }

        public CostcenterInfoItems BonusList_GetCostCenterInfoCollection(int idSubsidiary, bool invert)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                string locCommandString = "SELECT DISTINCT CostCenters.*" +
                    "FROM CostCenters INNER JOIN " +
                    "BonusLists ON BonusLists.IDSubsidiary = CostCenters.IDSubsidiary ";
                if (invert)
                    locCommandString += "AND BonusLists.IDCostCenter <> CostCenters.IDCostCenter WHERE CostCenters.IDSubsidiary=" + idSubsidiary;
                else
                    locCommandString += "AND BonusLists.IDCostCenter = CostCenters.IDCostCenter WHERE CostCenters.IDSubsidiary=" + idSubsidiary;

                var locCommand = new SqlCommand(locCommandString, locConnection);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    var locUIC = new CostcenterInfoItems();
                    while (locDR.Read())
                    {
                        var locCostcenterInfo = new CostcenterInfo(locDR);
                        locUIC.Add(locCostcenterInfo);
                    }
                    return locUIC;
                }
                return null;
            }
        }

        public BonusListItems BonusList_GetBonusListItems(int idSubsidiary, int idCostCenter)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return null;
            using (locConnection)
            {
                string locCommandString = "SELECT [BonusList].* FROM [BonusList] INNER JOIN [BonusLists] " +
                    "ON BonusList.IDBonusLists = BonusLists.IDBonusLists AND BonusList.IDSubsidiary = BonusLists.IDSubsidiary " +
                    " WHERE [BonusLists].[IDSubsidiary]=" + idSubsidiary + " AND [BonusLists].[IDCostCenter]=" + idCostCenter +
                    " ORDER BY [DegreeOfTime]";

                var locCommand = new SqlCommand(locCommandString, locConnection);
                CostcenterInfo locCci = SPAccess.GetInstance().GetCostCenter(idSubsidiary, idCostCenter);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    var locBlis = new BonusListItems();
                    while (locDR.Read())
                    {
                        var locBli = new BonusListItem(locDR, locCci);
                        locBlis.Add(locBli);
                    }
                    return locBlis;
                }
                return null;
            }
        }
    }
}
