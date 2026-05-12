using System;
using System.Data;
using System.Data.SqlClient;

namespace ActiveDevelop.SqlTools
{
    public class DatabaseSchemaUpdateManager
    {
        private readonly string myConnectionStr;
        private readonly bool mySilent;
        private readonly SqlConnection myConnection;
        private SqlTransaction myTransaction;

        public DatabaseSchemaUpdateManager(string connection, bool silent)
        {
            myConnectionStr = connection;
            mySilent = silent;
            myConnection = new SqlConnection(myConnectionStr);
            myConnection.Open();
        }

        public bool CheckTableExists(string tablename)
        {
            int reti;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = "SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@tablename) AND type in (N'U') ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 776).Value = tablename;

                reti = (int)(cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void StartTransaction()
        {
            myTransaction = myConnection.BeginTransaction();
        }

        public void Rollback()
        {
            if (myTransaction == null)
            {
                throw new InvalidOperationException("There is no Transaction. Please call StartTransaction first.");
            }

            myTransaction.Rollback();
        }

        public void Commit()
        {
            if (myTransaction == null)
            {
                throw new InvalidOperationException("There is no Transaction. Please call StartTransaction first.");
            }

            myTransaction.Commit();
        }

        public void Close()
        {
            if (myConnection.State != ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public void DeleteTable(string tablename)
        {
            ValidateIdentifier(tablename);

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = BuildDropTableIfExistsSql(tablename);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 776).Value = tablename;
                cmd.ExecuteNonQuery();
            }
        }

        private static string BuildDropTableIfExistsSql(string tablename)
        {
            return "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@tablename) AND type in (N'U')) " +
                   "DROP TABLE " + QuoteIdentifier(tablename);
        }

        private static string QuoteIdentifier(string identifier)
        {
            ValidateIdentifier(identifier);
            return "[" + identifier.Replace("]", "]]") + "]";
        }

        private static void ValidateIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException("Identifier must not be null or empty.", nameof(identifier));

            foreach (char c in identifier)
            {
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '$' || c == '#' || c == '@'))
                    throw new ArgumentException(
                        "Identifier contains invalid characters: " + identifier, nameof(identifier));
            }
        }

        public void ExecDDLStmt(string ddlCmd)
        {
            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = ddlCmd;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckConstraintExists(string tablename, string constraintName)
        {
            int reti;

            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = "select distinct 1 FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE " +
                                  "where table_name = @tablename AND CONSTRAINT_NAME = @constraintName";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 776).Value = tablename;
                cmd.Parameters.Add("@constraintName", SqlDbType.NVarChar, 776).Value = constraintName;
                reti = (int)(cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void CreateContraintIfNotExits(string tablename, string contraintName, string constraintBody)
        {
            if (!CheckConstraintExists(tablename, contraintName))
            {
                ExecDDLStmt(BuildAddConstraintSql(tablename, contraintName, constraintBody));
            }
        }

        private static string BuildAddConstraintSql(string tablename, string constraintName, string constraintBody)
        {
            return "alter table " + QuoteIdentifier(tablename) +
                   " add constraint " + QuoteIdentifier(constraintName) + " " + constraintBody;
        }

        public bool CheckColumnExists(string tablename, string columnName)
        {
            int reti;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " +
                                  "WHERE TABLE_NAME = @tablename AND COLUMN_NAME = @columnName";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 776).Value = tablename;
                cmd.Parameters.Add("@columnName", SqlDbType.NVarChar, 776).Value = columnName;
                reti = (int) (cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void CreateColumnIfNotExits(string tablename, string columnName, string datatype, bool notNull, string nnDefaultValueStr)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                ExecDDLStmt(BuildAddColumnSql(tablename, columnName, datatype));

                if (notNull)
                {
                    using (var updateCmd = myConnection.CreateCommand())
                    {
                        updateCmd.Transaction = myTransaction;
                        updateCmd.CommandText = BuildUpdateColumnDefaultSql(tablename, columnName, nnDefaultValueStr);
                        updateCmd.CommandType = CommandType.Text;
                        updateCmd.ExecuteNonQuery();
                    }

                    using (var alterCmd = myConnection.CreateCommand())
                    {
                        alterCmd.Transaction = myTransaction;
                        alterCmd.CommandText = BuildAlterColumnNotNullSql(tablename, columnName, datatype);
                        alterCmd.CommandType = CommandType.Text;
                        alterCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private static string BuildAddColumnSql(string tablename, string columnName, string datatype)
        {
            return "alter table " + QuoteIdentifier(tablename) +
                   " add " + QuoteIdentifier(columnName) + " " + datatype;
        }

        private static string BuildUpdateColumnDefaultSql(string tablename, string columnName, string defaultValueLiteral)
        {
            return "update " + QuoteIdentifier(tablename) +
                   " set " + QuoteIdentifier(columnName) + "=" + defaultValueLiteral;
        }

        private static string BuildAlterColumnNotNullSql(string tablename, string columnName, string datatype)
        {
            return "alter table " + QuoteIdentifier(tablename) +
                   " alter column " + QuoteIdentifier(columnName) + " " + datatype + " not null";
        }

        public void DeleteColumnIfExits(string tablename, string columnName)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                ExecDDLStmt(BuildDropColumnSql(tablename, columnName));
            }
        }

        private static string BuildDropColumnSql(string tablename, string columnName)
        {
            return "alter table " + QuoteIdentifier(tablename) +
                   " drop column " + QuoteIdentifier(columnName);
        }
    }
}
