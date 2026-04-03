using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ActiveDev.Data.SqlClient
{
    /// <summary>
    /// Dient zum Versenden eines T-SQL-Skripts an eine SQL-Server-Instanz oder eine SQL-Server-Datenbank.
    /// Die einzelnen T-SQL-Befehle müssen per "GO" (in einer einzelnen Zeile stehend) von einander getrennt sein.
    /// </summary>
    [Serializable]
    public class AdTSqlScriptProcessor : System.Collections.ObjectModel.Collection<AdTSqlScriptChunk>
    {
        private SqlConnection _connection;

        public AdTSqlScriptProcessor() : base()
        {
        }

        public AdTSqlScriptProcessor(string script, SqlConnection connection)
        {
            _connection = connection;
            BuildChunks(script);
        }

        /// <summary>
        /// Erstellt aus einem Skript, das als Zeichenkette vorliegt, einzelne AdTSqlScriptChunk-Elemente.
        /// </summary>
        public void BuildChunks(string script)
        {
            this.Items.Clear();
            AppendChunks(script);
        }

        /// <summary>
        /// Hängt ein weiteres Skript als verschiedene AdTSqlScriptChunk-Elemente an bestehende Elemente an.
        /// </summary>
        public void AppendChunks(string script)
        {
            string[] chunkStrings = script.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in chunkStrings)
            {
                var chunk = new AdTSqlScriptChunk(item, _connection.ConnectionString, "Facesso");
                this.Add(chunk);
            }
        }

        /// <summary>
        /// Erstellt eine Instanz dieser Klasse und füllt die Auflistung aus einer T-SQL-Skript-Datei.
        /// </summary>
        public static AdTSqlScriptProcessor FromFile(string filename, SqlConnection connection)
        {
            using (var sr = new StreamReader(filename))
            {
                string content = sr.ReadToEnd();
                return new AdTSqlScriptProcessor(content, connection);
            }
        }
    }

    [Serializable]
    public class AdTSqlScriptChunk
    {
        private string _chunkText;
        private string _lastResult;
        private bool _lastExecutionSuccessfull;
        private DateTime _lastExecutionDate;
        private string _connectionString;
        private string _databaseToUse;

        private static SqlConnection _connection;

        public AdTSqlScriptChunk()
        {
            _chunkText = null;
            _lastResult = null;
        }

        public AdTSqlScriptChunk(string chunkText, string connectionString, string databaseToUse)
        {
            _chunkText = chunkText;
            _connectionString = connectionString;
            _databaseToUse = databaseToUse;
        }

        public string ExecuteChunk()
        {
            string result = "OK";
            if (_connection == null)
            {
                _connection = new SqlConnection(ConnectionString);
            }
            else
            {
                if (_connection.ConnectionString != ConnectionString)
                {
                    _connection.Dispose();
                    _connection = new SqlConnection(ConnectionString);
                }
            }

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var command = new SqlCommand(ChunkText, _connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                if (ex.InnerException != null)
                    result += "\r\n" + ex.InnerException.Message;
            }
            return result;
        }

        public string DatabaseToUse
        {
            get => _databaseToUse;
            set => _databaseToUse = value;
        }

        public string ChunkText
        {
            get => _chunkText;
            set => _chunkText = value;
        }

        public string LastResult
        {
            get => _lastResult;
            set => _lastResult = value;
        }

        public bool LastExecutionSuccessfull
        {
            get => _lastExecutionSuccessfull;
            set => _lastExecutionSuccessfull = value;
        }

        public DateTime LastExecutionDate
        {
            get => _lastExecutionDate;
            set => _lastExecutionDate = value;
        }

        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
    }
}
