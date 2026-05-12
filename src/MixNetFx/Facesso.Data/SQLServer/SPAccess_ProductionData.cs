using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;
using Facesso.Data.My.Resources;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        internal void ProductionData_GetProductionData(ProductionData productionItems, byte orderBy)
        {
            productionItems.Clear();
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_GetProductionData", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = productionItems.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = productionItems.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = productionItems.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = productionItems.Shift;
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt); locCmd.Parameters["@IDProductionData"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@TotalReferenceIWT", SqlDbType.Float); locCmd.Parameters["@TotalReferenceIWT"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@DegreeOfTime", SqlDbType.Float); locCmd.Parameters["@DegreeOfTime"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@DegreeOfTimeAdj", SqlDbType.Float); locCmd.Parameters["@DegreeOfTimeAdj"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@InsertedByInterface", SqlDbType.Bit); locCmd.Parameters["@InsertedByInterface"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@IsSuspended", SqlDbType.Bit); locCmd.Parameters["@IsSuspended"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@LastEdited", SqlDbType.DateTime); locCmd.Parameters["@LastEdited"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int); locCmd.Parameters["@LastEditedByIDUser"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();

                if (locCmd.Parameters["@IDProductionData"].Value == DBNull.Value)
                {
                    productionItems.DoDataExist = false;
                }
                else
                {
                    productionItems.DoDataExist = true;
                    productionItems.IDProductionData = (long)locCmd.Parameters["@IDProductionData"].Value;
                    productionItems.DegreeOfTime = (double)locCmd.Parameters["@DegreeOfTime"].Value;
                    productionItems.DegreeOfTimeAdj = (double)locCmd.Parameters["@DegreeOfTimeAdj"].Value;
                    productionItems.InsertedByInterface = (bool)locCmd.Parameters["@InsertedByInterface"].Value;
                    productionItems.IsSuspended = (bool)locCmd.Parameters["@IsSuspended"].Value;
                    productionItems.LastEdited = (DateTime)locCmd.Parameters["@LastEdited"].Value;
                    productionItems.LastEditedByIDUser = (int)locCmd.Parameters["@LastEditedByIDUser"].Value;
                }

                locCmd = new SqlCommand("ProductionData_GetProductionOrTemplateItems", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = productionItems.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = productionItems.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = productionItems.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = productionItems.Shift;
                locCmd.Parameters.Add("@OrderBy", SqlDbType.TinyInt).Value = orderBy;
                locCmd.Parameters.Add("@DoExist", SqlDbType.Bit); locCmd.Parameters["@DoExist"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt); locCmd.Parameters["@IDProductionData"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@TotalReferenceIWT", SqlDbType.Float); locCmd.Parameters["@TotalReferenceIWT"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@DegreeOfTime", SqlDbType.Float); locCmd.Parameters["@DegreeOfTime"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@DegreeOfTimeAdj", SqlDbType.Float); locCmd.Parameters["@DegreeOfTimeAdj"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@InsertedByInterface", SqlDbType.Bit); locCmd.Parameters["@InsertedByInterface"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@IsSuspended", SqlDbType.Bit); locCmd.Parameters["@IsSuspended"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@LastEdited", SqlDbType.DateTime); locCmd.Parameters["@LastEdited"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int); locCmd.Parameters["@LastEditedByIDUser"].Direction = ParameterDirection.Output;
                locCmd.CommandTimeout = 5 * 60;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locProductionItem = new ProductionDataItem(locDR);
                    productionItems.Add(locProductionItem);
                }
            }
        }

        internal ShiftDateWorkResultInfo ProductionData_AddEditShiftDateWorkResults(ShiftDateWorkResultInfo sdwResults)
        {
            sdwResults.EmployeeTimeLogItems = TimeLog_AddEditEmployeeTimeLogItems(sdwResults.EmployeeTimeLogItems, FacessoGeneric.LoginInfo.IDUser, true);
            sdwResults.ProductionData = ProductionData_AddEditProductionData(sdwResults.ProductionData, FacessoGeneric.LoginInfo.IDUser, true);
            sdwResults.ProductionData.ResetSavingState();
            return sdwResults;
        }

        internal ProductionData ProductionData_AddEditProductionData(ProductionData prodData, int idUser, bool returnResultSet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_AddEdit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = prodData.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = prodData.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = prodData.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = prodData.Shift;
                locCmd.Parameters.Add("@InsertedByInterface", SqlDbType.Bit).Value = false;
                locCmd.Parameters.Add("@IsSuspended", SqlDbType.Bit).Value = false;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = prodData.LastEditedByIDUser;
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt).Value = prodData.IDProductionData;
                locCmd.Parameters["@IDProductionData"].Direction = ParameterDirection.InputOutput;
                locCmd.ExecuteNonQuery();
                prodData.IDProductionData = (long)locCmd.Parameters["@IDProductionData"].Value;

                foreach (ProductionDataItem locPI in prodData)
                {
                    locCmd = new SqlCommand("ProductionData_AddItemsForAddEdit", locConnection);
                    locCmd.CommandType = CommandType.StoredProcedure;
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = prodData.WorkGroup.IDSubsidiary;
                    locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt).Value = prodData.IDProductionData;
                    locCmd.Parameters.Add("@IDProductionDataItem", SqlDbType.BigInt).Value = locPI.IDProductionDataItem;
                    locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                    locCmd.Parameters.Add("@IDLabourValue", SqlDbType.Int).Value = locPI.LabourValue.IDLabourValue;
                    locCmd.Parameters.Add("@IDArticle", SqlDbType.Int).Value = 0;
                    locCmd.Parameters.Add("@Amount", SqlDbType.Float).Value = locPI.Amount;
                    locCmd.Parameters.Add("@AmountViaInterface", SqlDbType.Float).Value = locPI.AmountViaInterface;
                    locCmd.Parameters.Add("@OrdinalNumber", SqlDbType.Int).Value = locPI.OrdinalNo;
                    locCmd.Parameters.Add("@ManuallyEdited", SqlDbType.Bit).Value = locPI.ManuallyEdited;
                    locCmd.ExecuteNonQuery();
                }

                locCmd = new SqlCommand("ProductionData_HandleAddEdit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = prodData.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt).Value = prodData.IDProductionData;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                locCmd.Parameters.Add("@ReturnResultSet", SqlDbType.Bit).Value = returnResultSet;
                locCmd.CommandTimeout = 60;
                locCmd.ExecuteNonQuery();

                if (returnResultSet)
                {
                    ProductionData_GetProductionData(prodData, 1);
                    return prodData;
                }
                return null;
            }
        }

        internal void ProductionData_GetWorkGroupAnalysisItem(WorkGroupAnalysisInfoItem analysisItem, int idSubsidiary, CombinedParametersInfo cp)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_Analysis_GetShiftDateResultSet", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = cp.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = cp.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = cp.Shift;
                SqlDataReader locDR = locCmd.ExecuteReader();
                if (locDR.HasRows)
                {
                    locDR.Read();
                    WorkGroupAnalysisItem_AssignData(locDR, analysisItem);
                    analysisItem.WorkGroup = new WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter);
                }
                else
                {
                    analysisItem.HasData = false;
                }
            }
        }

        internal bool ProductionData_GetWorkGroupAnalysisItems(int idSubsidiary, int idUser, DateTime ticket,
            WorkGroupInfo workGroup, WorkGroupAnalysisInfo analysisInfo)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_Analysis_GetPeriodResultSet", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = workGroup.IDWorkGroup;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = ticket;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locItem = new WorkGroupAnalysisInfoItem();
                    WorkGroupAnalysisItem_AssignData(locDR, locItem);
                    locItem.WorkGroup = workGroup;
                    analysisInfo.Add(locItem);
                }
            }
            return analysisInfo.Count > 0;
        }

        private void WorkGroupAnalysisItem_AssignData(SqlDataReader sqlDr, WorkGroupAnalysisInfoItem analysisItem)
        {
            analysisItem.HasData = true;
            analysisItem.TotalDownTime = sqlDr.GetDouble(sqlDr.GetOrdinal("TotalDownTime"));
            analysisItem.TotalReferenceIWT = sqlDr.GetDouble(sqlDr.GetOrdinal("TotalReferenceIWT"));
            analysisItem.TotalEffectiveIWT = sqlDr.GetDouble(sqlDr.GetOrdinal("TotalEffectiveIWT"));
            analysisItem.TotalEffectiveIWTAdj = sqlDr.GetDouble(sqlDr.GetOrdinal("TotalEffectiveIWTAdj"));
            analysisItem.TotalWorkBreakTime = sqlDr.GetDouble(sqlDr.GetOrdinal("TotalWorkBreakTime"));
            analysisItem.DegreeOfTime = sqlDr.GetDouble(sqlDr.GetOrdinal("DegreeOfTime"));
            analysisItem.DegreeOfTimeAdj = sqlDr.GetDouble(sqlDr.GetOrdinal("DegreeOfTimeAdj"));
            analysisItem.IDProductionData = sqlDr.GetInt64(sqlDr.GetOrdinal("IDProductionData"));
            analysisItem.IsSuspended = sqlDr.GetBoolean(sqlDr.GetOrdinal("IsSuspended"));
            analysisItem.ProductionDate = sqlDr.GetDateTime(sqlDr.GetOrdinal("ProductionDate"));
            analysisItem.Shift = sqlDr.GetByte(sqlDr.GetOrdinal("Shift"));
            if (analysisItem.DegreeOfTime == -2 || analysisItem.TotalDownTime == -1 ||
                analysisItem.TotalWorkBreakTime == -1 || analysisItem.TotalEffectiveIWT == -1)
            {
                analysisItem.TotalDownTime = 0;
                analysisItem.TotalReferenceIWT = 0;
                analysisItem.TotalEffectiveIWT = 0;
                analysisItem.TotalEffectiveIWTAdj = 0;
                analysisItem.TotalWorkBreakTime = 0;
                analysisItem.DegreeOfTime = 0;
                analysisItem.DegreeOfTimeAdj = 0;
            }
        }

        internal void ProductionData_PrepareProductionDates(int idSubsidiary, int idUser, DateTime ticket, ProductionPeriod period)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_Analysis_AddProductionDateItem", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                foreach (ProductionPeriodItem locItem in period)
                {
                    locCmd.Parameters.Clear();
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                    locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                    locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = ticket;
                    locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = locItem.ProductionDate;
                    locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = locItem.Shift;
                    locCmd.ExecuteScalar();
                }
            }
        }

        internal void ProductionData_DeleteProductionDateItems(int idSubsidiary, int idUser, DateTime ticket)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("ProductionData_Analysis_DeleteProductionDateItems", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Clear();
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = ticket;
                locCmd.ExecuteScalar();
            }
        }

        internal bool ProductionData_DeleteItems(int idSubsidiary, WorkGroupInfo workgroup, DateTime productionDate, byte shift)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand(
                    "SELECT IDProductionData FROM ProductionData WHERE " +
                    "[IDWorkgroup]=@IDWorkgroup AND " +
                    "[ProductionDate]=@ProductionDate AND " +
                    "[Shift]=@Shift", locConnection);
                locCmd.Parameters.Add("@IDWorkgroup", SqlDbType.Int).Value = workgroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = productionDate.Date;
                locCmd.Parameters.Add("@Shift", SqlDbType.Int).Value = shift;
                SqlDataReader locReader = locCmd.ExecuteReader();
                if (!locReader.HasRows)
                    return false;
                locReader.Read();
                long locIDProductionData = locReader.GetInt64(locReader.GetOrdinal("IDProductionData"));
                locReader.Close();

                locCmd = new SqlCommand("DELETE FROM ProductionDataItems WHERE IDProductionData=@IDProductionData", locConnection);
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt).Value = locIDProductionData;
                locCmd.ExecuteScalar();

                locCmd = new SqlCommand("DELETE FROM ProductionData WHERE IDProductionData=@IDProductionData", locConnection);
                locCmd.Parameters.Add("@IDProductionData", SqlDbType.BigInt).Value = locIDProductionData;
                locCmd.ExecuteScalar();

                return true;
            }
        }

        internal void ProductionData_CollectAmounts(int idSubsidiary, int idWorkGroup,
            DateTime fromDate, DateTime toDate, WorkgroupProductionDataAmounts pda)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand(Resources.SELECT_ProductionDataAmount, locConnection);
                locCmd.Parameters.Clear();
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = idWorkGroup;
                locCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                locCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
                SqlDataReader locReader = locCmd.ExecuteReader();
                while (locReader.Read())
                {
                    pda.Add(new WorkgroupProductionDataAmount(
                        locReader.GetDouble(locReader.GetOrdinal("AmountTotal")),
                        new LabourValueInfo(locReader, true)));
                }
            }
        }
    }
}
