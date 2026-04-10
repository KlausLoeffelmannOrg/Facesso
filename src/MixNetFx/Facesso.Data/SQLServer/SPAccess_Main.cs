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

        internal static string QuoteSqlIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("SQL identifier cannot be null or whitespace.", nameof(identifier));

            string[] parts = identifier.Split('.');

            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i].Trim();
                if (part.Length == 0)
                    throw new ArgumentException("SQL identifier contains an empty name segment.", nameof(identifier));

                if (part.StartsWith("[", StringComparison.Ordinal) && part.EndsWith("]", StringComparison.Ordinal) && part.Length >= 2)
                    part = part.Substring(1, part.Length - 2).Replace("]]", "]");

                parts[i] = "[" + part.Replace("]", "]]") + "]";
            }

            return string.Join(".", parts);
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
