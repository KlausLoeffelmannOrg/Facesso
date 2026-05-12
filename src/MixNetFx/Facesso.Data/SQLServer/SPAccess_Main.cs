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

        /// <summary>
        /// Validates that <paramref name="identifier"/> is a safe SQL identifier
        /// (column/table/order-by name) and returns a bracket-quoted form.
        /// Throws <see cref="ArgumentException"/> for anything that could enable
        /// SQL injection.
        /// </summary>
        internal static string QuoteSqlIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException("SQL identifier must not be null or empty.", nameof(identifier));

            foreach (char c in identifier)
            {
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '$' || c == '#' || c == '@'))
                    throw new ArgumentException(
                        "SQL identifier contains invalid characters: " + identifier, nameof(identifier));
            }

            return "[" + identifier + "]";
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
