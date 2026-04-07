using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        internal void TimeLog_DeleteItemFromDatabase(WorkGroupInfo workGroup, EmployeeTimeLogInfoItem empTimeLogItem)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("TimeLog_DeleteItem", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = workGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDTimeLog", SqlDbType.BigInt).Value = empTimeLogItem.IDTimeLog;
                locCmd.ExecuteNonQuery();
            }
        }

        internal void GetEmployeeTimeLog(EmployeeTimeLogInfo timeLogItems)
        {
            timeLogItems.Clear();
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("TimeLog_GetLogItemsForShiftDate", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = timeLogItems.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = timeLogItems.Shift;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locTimeLogItem = new EmployeeTimeLogInfoItem(locDR, true);
                    timeLogItems.Add(locTimeLogItem);
                }
            }
        }

        internal void GetEmployeeTimeLog(EmployeeInfo employee, DateTime startdate, DateTime enddate, EmployeeTimeLogInfo timeLogItems)
        {
            timeLogItems.Clear();
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("TimeLog_GetLogItemsForRange", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = employee.IDSubsidiary;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = employee.IDEmployee;
                locCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startdate;
                locCmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = enddate;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locTimeLogItem = new EmployeeTimeLogInfoItem(locDR, true);
                    timeLogItems.Add(locTimeLogItem);
                }
            }
        }

        internal void TimeLog_GetOverlappingLogItems(EmployeeInfo employeeInfo, DateTime shiftStart, DateTime shiftEnd,
            OverlapsInfo overlapsInfo, ADDBNullable<long> excludeIDTimelog)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("TimeLog_GetOverlappingLogItems", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = employeeInfo.IDSubsidiary;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = employeeInfo.IDEmployee;
                locCmd.Parameters.Add("@ShiftStart", SqlDbType.DateTime).Value = shiftStart;
                locCmd.Parameters.Add("@ShiftEnd", SqlDbType.DateTime).Value = shiftEnd;
                locCmd.Parameters.Add("@ExcludeIDTimeLog", SqlDbType.BigInt).Value = excludeIDTimelog.Value;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locItem = new OverlapsInfoItem(employeeInfo, locDR);
                    overlapsInfo.Add(locItem);
                }
            }
        }

        internal EmployeeTimeLogInfo TimeLog_AddEditEmployeeTimeLogItems(EmployeeTimeLogInfo timeLogItems, int idUser, bool returnResultSet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                SqlCommand locCmd;
                DateTime locTicket = DateTime.Now;

                foreach (EmployeeTimeLogInfoItem locItem in timeLogItems)
                {
                    if (locItem.Deleted && locItem.IDTimeLog < 1) continue;

                    locCmd = new SqlCommand("TimeLog_AddItemsForAddEdit", locConnection);
                    locCmd.CommandType = CommandType.StoredProcedure;
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDSubsidiary;
                    locCmd.Parameters.Add("@IDTimeLog", SqlDbType.BigInt).Value = locItem.IDTimeLog;
                    locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDUser;
                    locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = locItem.IDWorkGroup;
                    locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = locItem.EmployeeInfo.IDEmployee;
                    locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = locItem.ProductionDate;
                    locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = locItem.Shift;
                    locCmd.Parameters.Add("@ShiftStart", SqlDbType.DateTime).Value = locItem.ShiftStart;
                    locCmd.Parameters.Add("@ShiftEnd", SqlDbType.DateTime).Value = locItem.ShiftEnd;
                    locCmd.Parameters.Add("@WorkBreak", SqlDbType.Int).Value = locItem.WorkBreak;
                    locCmd.Parameters.Add("@DownTime", SqlDbType.Int).Value = locItem.DownTime;
                    locCmd.Parameters.Add("@Handicap", SqlDbType.Int).Value = locItem.Handicap;
                    locCmd.Parameters.Add("@InsertedByInterface", SqlDbType.Bit).Value = locItem.InsertedByInterface;
                    locCmd.Parameters.Add("@ManuallyEdited", SqlDbType.Bit).Value = locItem.ManuallyEdited;
                    locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = idUser;
                    locCmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = locItem.Deleted;
                    locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = locTicket;
                    locCmd.ExecuteNonQuery();
                }

                locCmd = new SqlCommand("TimeLog_HandleAddEdit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDSubsidiary;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDUser;
                locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = locTicket;
                locCmd.CommandTimeout = 300;
                locCmd.ExecuteNonQuery();

                if (returnResultSet)
                {
                    locCmd = new SqlCommand("TimeLog_GetLogItemsForShiftDate", locConnection);
                    locCmd.CommandType = CommandType.StoredProcedure;
                    timeLogItems.Clear();
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDSubsidiary;
                    locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = timeLogItems.WorkGroup.IDWorkGroup;
                    locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = timeLogItems.ProductionDate;
                    locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = timeLogItems.Shift;
                    SqlDataReader locDR = locCmd.ExecuteReader();
                    while (locDR.Read())
                    {
                        var locTimeLogItem = new EmployeeTimeLogInfoItem(locDR, true);
                        timeLogItems.Add(locTimeLogItem);
                    }
                    return timeLogItems;
                }
                return null;
            }
        }

        internal void TimeLog_GetEmployeeResult(int idSubsidiary, int idUser, DateTime ticket,
            EmployeeInfo employee, EmployeeTimeLogInfo timeLogItems)
        {
            timeLogItems.Clear();
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("TimeLog_Analysis_GetEmployeeResult", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                locCmd.Parameters.Add("@Ticket", SqlDbType.DateTime).Value = ticket;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = employee.IDEmployee;
                SqlDataReader locDR = locCmd.ExecuteReader();
                while (locDR.Read())
                {
                    var locTimeLogItem = new EmployeeTimeLogInfoItem(locDR, employee);
                    timeLogItems.Add(locTimeLogItem);
                }
            }
        }
    }
}
