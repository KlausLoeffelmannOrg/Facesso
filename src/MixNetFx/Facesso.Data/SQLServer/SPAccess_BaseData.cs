using System;
using System.Data;
using System.Data.SqlClient;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool Basedata_DoEmployeesExist()
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("Basedata_DoEmployeesExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                locCmd.Parameters.Add("@DoExist", SqlDbType.Bit);
                locCmd.Parameters["@DoExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return Convert.ToBoolean(locCmd.Parameters["@DoExist"].Value);
            }
        }

        public bool Basedata_DoWorkGroupsExist()
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("Basedata_DoWorkGroupsExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                locCmd.Parameters.Add("@DoExist", SqlDbType.Bit);
                locCmd.Parameters["@DoExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return Convert.ToBoolean(locCmd.Parameters["@DoExist"].Value);
            }
        }

        public bool Basedata_DoLabourValuesExist()
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null)
                throw new FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", null);

            using (locConnection)
            {
                var locCmd = new SqlCommand("Basedata_DoLabourValuesExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                locCmd.Parameters.Add("@DoExist", SqlDbType.Bit);
                locCmd.Parameters["@DoExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return Convert.ToBoolean(locCmd.Parameters["@DoExist"].Value);
            }
        }
    }
}
