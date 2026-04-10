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

        private static string QuoteSqlIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("SQL identifier cannot be null or whitespace.", nameof(identifier));

            string trimmed = identifier.Trim();
            if (trimmed.StartsWith("[") && trimmed.EndsWith("]") && trimmed.Length >= 2)
                trimmed = trimmed.Substring(1, trimmed.Length - 2).Replace("]]", "]");

            return "[" + trimmed.Replace("]", "]]") + "]";
        }

        private static SqlConnection CreateConnectionForDatabase(string connectionString, string databaseName)
        {
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = databaseName
            };

            return new SqlConnection(builder.ConnectionString);
        }

        private static string EscapeSqlLiteral(string value)
        {
            return (value ?? string.Empty).Replace("'", "''");
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

                command = new SqlCommand("SELECT name FROM sys.databases where name=@DatabaseName");
                command.Connection = connection;
                command.Parameters.Add("@DatabaseName", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
                SqlDataReader reader = command.ExecuteReader();
                _databaseExists = reader.HasRows;
                reader.Close();
            }

            if (_databaseExists)
            {
                connection = CreateConnectionForDatabase(_sqlInstanceConnString, _databaseName);
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

                    command = new SqlCommand("SELECT name, physical_name FROM sys.database_files where name=@DatabaseName");
                    command.Connection = connection;
                    command.Parameters.Add("@DatabaseName", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
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
            string quotedDatabaseName = QuoteSqlIdentifier(databasename);

            if (string.IsNullOrEmpty(logFilename))
            {
                command = new SqlCommand("CREATE DATABASE " + quotedDatabaseName + " ON " +
                    "( FILENAME = N'" + EscapeSqlLiteral(databaseFilename) + "' )" +
                    " FOR ATTACH_REBUILD_LOG", connection);
            }
            else
            {
                command = new SqlCommand("CREATE DATABASE " + quotedDatabaseName + " ON " +
                    "( FILENAME = N'" + EscapeSqlLiteral(databaseFilename) + "' )," +
                    "( FILENAME = N'" + EscapeSqlLiteral(logFilename) + "' )" +
                    " FOR ATTACH", connection);
            }

            using (connection)
            {
                connection.Open();
                command.ExecuteScalar();

                if (!string.IsNullOrEmpty(newDbOwner))
                {
                    command = new SqlCommand(
                        "if not exists (select name from master.sys.databases sd where name = @DatabaseName " +
                        "and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC " + quotedDatabaseName + ".dbo.sp_changedbowner " +
                        "@loginame=@LoginName, @map=false",
                        connection);
                    command.Parameters.Add("@DatabaseName", System.Data.SqlDbType.NVarChar, 128).Value = databasename;
                    command.Parameters.Add("@LoginName", System.Data.SqlDbType.NVarChar, 128).Value = newDbOwner;
                    command.ExecuteScalar();
                }
            }
            return new ADSqlDatabaseManager(sqlInstanceConnString, databasename);
        }

        public void DetachDatabase()
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand("EXEC master.dbo.sp_detach_db @dbname=@DatabaseName, @keepfulltextindexfile=N'true'");
                command.Parameters.Add("@DatabaseName", System.Data.SqlDbType.NVarChar, 128).Value = _databaseName;
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
                var command = new SqlCommand("ALTER DATABASE " + QuoteSqlIdentifier(_databaseName) + " SET Single_User WITH ROLLBACK IMMEDIATE");
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

        public void CreateDatabase(string dbName, string filenameOnSqlServer, int dbSizeInKb,
            int dbFileGrowthInKb, string dbLogname, string logFilenameOnSqlServer,
            int logSizeInKb, int logFileGrowthInPercent)
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand("CREATE DATABASE " + QuoteSqlIdentifier(dbName) + " ON PRIMARY " +
                    "( NAME = N'" + EscapeSqlLiteral(dbName) + "', FILENAME = N'" + EscapeSqlLiteral(filenameOnSqlServer) + "'" +
                    " , SIZE = " + dbSizeInKb + "KB , FILEGROWTH = " + dbFileGrowthInKb + "KB )" +
                    " LOG ON ( NAME = N'" + EscapeSqlLiteral(dbLogname) + "', FILENAME = N'" + EscapeSqlLiteral(logFilenameOnSqlServer) + "'" +
                    " , SIZE = " + logSizeInKb + "KB , FILEGROWTH = " + logFileGrowthInPercent + "%)");
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
