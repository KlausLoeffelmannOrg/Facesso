using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public enum SqlCredentialMethods
    {
        WindowsIntegratedSecurity,
        MixedMode
    }

    public enum SqlDatabaseSource
    {
        FromSqlServerInstance,
        FromFile
    }

    public class SqlMixedModeCredentialParameters
    {
        private string _userID;
        private string _password;

        public SqlMixedModeCredentialParameters(string username, string password)
        {
            _userID = username;
            _password = password;
        }

        public string UserID
        {
            get => _userID;
            set => _userID = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public static implicit operator SqlMixedModeCredentialParameters(string combined)
        {
            char[] sepChars = new char[] { ',', ';', '/', '\\' };
            if (combined.IndexOfAny(sepChars) > -1)
            {
                string[] arr = combined.Split(sepChars);
                return new SqlMixedModeCredentialParameters(arr[0], arr[1]);
            }
            else
            {
                return new SqlMixedModeCredentialParameters(combined, null);
            }
        }
    }

    public class ADSqlDriveFoldersAndFilesListing
    {
        public static Collection<DBDriveItem> GetDrivenames(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("master.dbo.xp_fixeddrives", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new Collection<DBDriveItem>();
                        while (reader.Read())
                            items.Add(new DBDriveItem(reader.GetString(0), reader.GetInt32(1)));
                        return items;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    string msg = "Beim Lesen der Laufwerksstruktur auf dem SQL-Server ist ein Fehler aufgetreten!" +
                        "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace;
                    MessageBox.Show(msg, "Fehler beim SQL Server-Zugriff:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public static Collection<DBDirOrFileItem> GetSubfoldersAndFiles(string connectionString, string baseDir)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("master.dbo.xp_dirtree", connection);
                    command.Parameters.Add("subdirectory", SqlDbType.NVarChar, 255).Value = baseDir;
                    command.Parameters.Add("depth", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("file", SqlDbType.Int).Value = 1;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new Collection<DBDirOrFileItem>();
                        while (reader.Read())
                            items.Add(new DBDirOrFileItem(reader.GetString(0), reader.GetInt32(2) != 0));
                        return items;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    string msg = "Beim Lesen der Laufwerksstruktur auf dem SQL-Server ist ein Fehler aufgetreten!" +
                        "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace;
                    MessageBox.Show(msg, "Fehler beim SQL Server-Zugriff:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }

    public class ADSqlConnectionBuilderException : ApplicationException
    {
        public ADSqlConnectionBuilderException(string message) : base(message)
        {
        }
    }

    public struct DBDriveItem
    {
        private string _driveLetter;
        private int _freeSpaceInMb;

        public DBDriveItem(string driveLetter, int freeSpaceInMb)
        {
            _driveLetter = driveLetter;
            _freeSpaceInMb = freeSpaceInMb;
        }

        public string DriveLetter
        {
            get => _driveLetter;
            set => _driveLetter = value;
        }

        public int FreeSpaceInMb
        {
            get => _freeSpaceInMb;
            set => _freeSpaceInMb = value;
        }
    }

    public struct DBDirOrFileItem
    {
        private string _name;
        private bool _isFile;

        public DBDirOrFileItem(string name, bool isFile)
        {
            _name = name;
            _isFile = isFile;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public bool IsFile
        {
            get => _isFile;
            set => _isFile = value;
        }
    }
}
