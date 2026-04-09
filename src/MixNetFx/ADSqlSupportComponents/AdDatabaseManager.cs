using System;
using System.Data;
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

                command = new SqlCommand("SELECT name FROM sys.databases where name=@DatabaseName");
                command.Connection = connection;
                command.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = _databaseName;
                SqlDataReader reader = command.ExecuteReader();
                _databaseExists = reader.HasRows;
                reader.Close();
            }

            if (_databaseExists)
            {
                connection = new SqlConnection(BuildCatalogConnectionString(_sqlInstanceConnString, _databaseName));
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
                    command.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = _databaseName;
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
            string safeDatabaseName = QuoteSqlIdentifier(databasename);

            if (string.IsNullOrEmpty(logFilename))
            {
                command = new SqlCommand("CREATE DATABASE " + safeDatabaseName + " ON " +
                    "( FILENAME = " + QuoteSqlLiteral(databaseFilename) + " )" +
                    " FOR ATTACH_REBUILD_LOG", connection);
            }
            else
            {
                command = new SqlCommand("CREATE DATABASE " + safeDatabaseName + " ON " +
                    "( FILENAME = " + QuoteSqlLiteral(databaseFilename) + " )," +
                    "( FILENAME = " + QuoteSqlLiteral(logFilename) + " )" +
                    " FOR ATTACH", connection);
            }

            using (connection)
            {
                connection.Open();
                command.ExecuteScalar();

                if (!string.IsNullOrEmpty(newDbOwner))
                {
                    command = new SqlCommand("if not exists (select name from master.sys.databases sd where name = @DatabaseName " +
                        "and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC " + safeDatabaseName + ".dbo.sp_changedbowner " +
                        "@loginame=@NewDbOwner, @map=false", connection);
                    command.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = databasename;
                    command.Parameters.Add("@NewDbOwner", SqlDbType.NVarChar, 128).Value = newDbOwner;
                    command.ExecuteScalar();
                }
            }
            return new ADSqlDatabaseManager(sqlInstanceConnString, databasename);
        }

        public void DetachDatabase()
        {
            using (var connection = new SqlConnection(_sqlInstanceConnString))
            {
                var command = new SqlCommand("EXEC master.dbo.sp_detach_db @dbname = @DatabaseName, @keepfulltextindexfile=N'true'");
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
                command.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = _databaseName;
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
                var command = new SqlCommand("CREATE DATABASE " + QuoteSqlIdentifier(dbName) + " ON  PRIMARY " +
                    "( NAME = " + QuoteSqlLiteral(dbName) + ", FILENAME = " + QuoteSqlLiteral(filenameOnSqlServer) +
                    " , SIZE = " + dbSizeInKb + "KB , FILEGROWTH = " + dbFileGrowthInKb + "KB )" +
                    " LOG ON ( NAME = " + QuoteSqlLiteral(dbLogname) + ", FILENAME = " + QuoteSqlLiteral(logFilenameOnSqlServer) +
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

        private static string BuildCatalogConnectionString(string connectionString, string databaseName)
        {
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = databaseName
            };
            return builder.ConnectionString;
        }

        private static string QuoteSqlIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("SQL identifier must not be empty.", nameof(identifier));

            string[] parts = identifier.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i].Trim();
                if (part.StartsWith("[", StringComparison.Ordinal) &&
                    part.EndsWith("]", StringComparison.Ordinal) &&
                    part.Length >= 2)
                {
                    part = part.Substring(1, part.Length - 2);
                }

                parts[i] = "[" + part.Replace("]", "]]") + "]";
            }

            return string.Join(".", parts);
        }

        private static string QuoteSqlLiteral(string value)
        {
            return "N'" + (value ?? string.Empty).Replace("'", "''") + "'";
        }
    }
}
