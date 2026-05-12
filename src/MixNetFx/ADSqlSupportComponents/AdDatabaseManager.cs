using System;
using System.Data.SqlClient;

namespace ActiveDev.Data.SqlClient
{
    public class ADSqlDatabaseManager
    {
        private readonly string _sqlInstanceConnString;
        private readonly string _databaseName;
        private string _filenameOnSqlServer;
        private bool _databaseExists;
        private bool _lastSqlResult;
        private Exception _lastSqlException;

        public ADSqlDatabaseManager(string sqlInstanceConnString, string databasename)
        {
            _sqlInstanceConnString = sqlInstanceConnString;
            _databaseName = databasename;
        }

        public void QueryProperties()
        {
            var connection = new SqlConnection(_sqlInstanceConnString);
            SqlCommand command;

            using (connection)
            {
                try
                {
                    connection.Open();
                    _lastSqlResult = true;
                }
                catch (Exception ex)
                {
                    _lastSqlException = ex;
                    _lastSqlResult = false;
                    return;
                }

                command = new SqlCommand("SELECT name FROM sys.databases where name = @name");
                command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();
                _databaseExists = reader.HasRows;
                reader.Close();
            }

            if (_databaseExists)
            {
                connection = new SqlConnection(_sqlInstanceConnString + "; Initial Catalog='" + _databaseName + "'");
                using (connection)
                {
                    try
                    {
                        connection.Open();
                        _lastSqlResult = true;
                    }
                    catch (Exception ex)
                    {
                        _lastSqlException = ex;
                        _lastSqlResult = false;
                        return;
                    }

                    command = new SqlCommand("SELECT name, physical_name FROM sys.database_files where name = @name");
                    command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        _filenameOnSqlServer = reader.GetString(reader.GetOrdinal("physical_name"));
                    }
                    reader.Close();
                }
            }
            _lastSqlResult = true;
        }

        public static ADSqlDatabaseManager AttachDatabase(string sqlInstanceConnString, string databasename, string databaseFilename)
        {
            return AttachDatabase(sqlInstanceConnString, databasename, databaseFilename, null, null);
        }

        public static ADSqlDatabaseManager AttachDatabase(string sqlInstanceConnString, string databasename, string databaseFilename, string newDbOwner)
        {
            return AttachDatabase(sqlInstanceConnString, databasename, databaseFilename, null, newDbOwner);
        }

        public static ADSqlDatabaseManager AttachDatabase(string sqlInstanceConnString, string databasename,
            string databaseFilename, string logFilename, string newDbOwner)
        {
            var connection = new SqlConnection(sqlInstanceConnString);
            SqlCommand command;

            if (string.IsNullOrEmpty(logFilename))
            {
                command = new SqlCommand(
                    BuildAttachDatabaseSql(databasename, databaseFilename),
                    connection);
            }
            else
            {
                command = new SqlCommand(
                    BuildAttachDatabaseWithLogSql(databasename, databaseFilename, logFilename),
                    connection);
            }

            using (connection)
            {
                connection.Open();
                command.ExecuteScalar();

                if (!string.IsNullOrEmpty(newDbOwner))
                {
                    command = new SqlCommand(
                        BuildChangeDbOwnerSql(databasename, newDbOwner),
                        connection);
                    command.ExecuteScalar();
                }
            }
            return new ADSqlDatabaseManager(sqlInstanceConnString, databasename);
        }

        private static string BuildAttachDatabaseSql(string databaseName, string databaseFilename)
        {
            return "CREATE DATABASE " + QuoteIdentifier(databaseName) + " ON " +
                   "( FILENAME = N'" + EscapeStringLiteral(databaseFilename) + "' )" +
                   " FOR ATTACH_REBUILD_LOG";
        }

        private static string BuildAttachDatabaseWithLogSql(string databaseName, string databaseFilename, string logFilename)
        {
            return "CREATE DATABASE " + QuoteIdentifier(databaseName) + " ON " +
                   "( FILENAME = N'" + EscapeStringLiteral(databaseFilename) + "' )," +
                   "( FILENAME = N'" + EscapeStringLiteral(logFilename) + "' )" +
                   " FOR ATTACH";
        }

        private static string BuildChangeDbOwnerSql(string databaseName, string newDbOwner)
        {
            return "if not exists (select name from master.sys.databases sd where name = @dbname and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME()) " +
                   "EXEC " + QuoteIdentifier(databaseName) +
                   ".dbo.sp_changedbowner @loginame = N'" + EscapeStringLiteral(newDbOwner) + "', @map = false";
        }

        public void DetachDatabase()
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand(
                    "EXEC master.dbo.sp_detach_db @dbname = @dbname, @keepfulltextindexfile = N'true'");
                command.Parameters.Add("@dbname", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
                try
                {
                    connection.Open();
                    _lastSqlResult = true;
                }
                catch (Exception ex)
                {
                    _lastSqlException = ex;
                    _lastSqlResult = false;
                    return;
                }

                command.Connection = connection;
                command.ExecuteScalar();
                _lastSqlResult = true;
            }
        }

        public void CutAllConnections()
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand(BuildCutAllConnectionsSql(_databaseName));
                try
                {
                    connection.Open();
                    _lastSqlResult = true;
                }
                catch (Exception ex)
                {
                    _lastSqlException = ex;
                    _lastSqlResult = false;
                    return;
                }

                command.Connection = connection;
                command.ExecuteScalar();
                _lastSqlResult = true;
            }
        }

        private static string BuildCutAllConnectionsSql(string databaseName)
        {
            return "ALTER DATABASE " + QuoteIdentifier(databaseName) +
                   " SET Single_User WITH ROLLBACK IMMEDIATE";
        }

        public void CreateDatabase(string dbName, string filenameOnSqlServer, int dbSizeInKb,
            int dbFileGrowthInKb, string dbLogname, string logFilenameOnSqlServer,
            int logSizeInKb, int logFileGrowthInPercent)
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand(BuildCreateDatabaseSql(
                    dbName, filenameOnSqlServer, dbSizeInKb, dbFileGrowthInKb,
                    dbLogname, logFilenameOnSqlServer, logSizeInKb, logFileGrowthInPercent));
                try
                {
                    connection.Open();
                    _lastSqlResult = true;
                }
                catch (Exception ex)
                {
                    _lastSqlException = ex;
                    _lastSqlResult = false;
                    return;
                }

                command.Connection = connection;
                command.ExecuteScalar();
                _lastSqlResult = true;
            }
        }

        private static string BuildCreateDatabaseSql(
            string dbName, string filenameOnSqlServer, int dbSizeInKb, int dbFileGrowthInKb,
            string dbLogname, string logFilenameOnSqlServer, int logSizeInKb, int logFileGrowthInPercent)
        {
            return "CREATE DATABASE  " + QuoteIdentifier(dbName) + " ON  PRIMARY " +
                   "( NAME = N'" + EscapeStringLiteral(dbName) + "', FILENAME = N'" + EscapeStringLiteral(filenameOnSqlServer) +
                   "' , SIZE = " + dbSizeInKb + "KB , FILEGROWTH = " + dbFileGrowthInKb + "KB )" +
                   " LOG ON ( NAME = N'" + EscapeStringLiteral(dbLogname) + "', FILENAME = N'" + EscapeStringLiteral(logFilenameOnSqlServer) +
                   "' , SIZE = " + logSizeInKb + "KB , FILEGROWTH = " + logFileGrowthInPercent + "%)";
        }

        private static string QuoteIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException("Identifier must not be null or empty.", nameof(identifier));

            foreach (char c in identifier)
            {
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '$' || c == '#' || c == '@'))
                    throw new ArgumentException(
                        "Identifier contains invalid characters: " + identifier, nameof(identifier));
            }

            return "[" + identifier.Replace("]", "]]") + "]";
        }

        private static string EscapeStringLiteral(string value)
        {
            if (value == null)
                return string.Empty;
            return value.Replace("'", "''");
        }

        /// <summary>
        /// Sendet ein T-Sql-Script zur aktuellen Datenbankinstanz (nicht zur Datenbank!)
        /// </summary>
        /// <param name="script">Zeichenkette, die das Skript enthält, das zur Datenbank gesendet werden soll.</param>
        public void SendSqlScript(string script)
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                try
                {
                    connection.Open();
                    _lastSqlResult = true;
                }
                catch (Exception ex)
                {
                    _lastSqlException = ex;
                    _lastSqlResult = false;
                    return;
                }

                _lastSqlResult = true;
            }
        }

        public bool DatabaseExists => _databaseExists;
        public string FilenameOnSqlServer => _filenameOnSqlServer;
        public bool LastSqlResult => _lastSqlResult;
    }
}
