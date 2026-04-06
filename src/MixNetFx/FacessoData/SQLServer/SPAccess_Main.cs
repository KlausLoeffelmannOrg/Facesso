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
        private static SPAccess myInstance;

        private SPAccess() { }

        public static SPAccess GetInstance()
        {
            if (myInstance == null)
            {
                if (FacessoGeneric.FacessoLicenseInfo.IsLicensed())
                {
                    myInstance = new SPAccess();
                }
                else
                {
                    throw new FacessoLicenseViolationException(Resources.Sp_Main_FailedInstancingDueToLicence, null);
                }
            }
            return myInstance;
        }

        public SqlConnection GetOpenedConnectionSafely()
        {
            var locConnection = new SqlConnection(FacessoGeneric.SQLConnectionString);
            try
            {
                locConnection.Open();
            }
            catch (Exception ex)
            {
                string locString = Resources.Sp_Main_OpenFacessoConnectionFailed + Environment.NewLine + Environment.NewLine;
                locString += ex.Message;
                throw new FacessoSqlDbException(locString, ex);
            }
            return locConnection;
        }

        public string SQLConnectionString => FacessoGeneric.SQLConnectionString;

        public void DeleteDataForOleDbImport(int idSubsidiary)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("DeleteDataForOleDbImport", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.ExecuteReader();
            }
        }
    }
}
