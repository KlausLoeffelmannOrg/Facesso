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

        private static string QuoteSqlIdentifier(string identifier)
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

        public bool CheckTableExists(string tablename)
        {
            const string sel = "SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@TableName) AND type in (N'U') ";
            int reti;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = tablename;

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
            string sel = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@TableName) AND type in (N'U')) " +
                      "DROP TABLE " + QuoteSqlIdentifier(tablename);

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = tablename;
                cmd.ExecuteNonQuery();
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
            const string sel = "select distinct 1 FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE " +
                      "where table_name = @TableName AND CONSTRAINT_NAME = @ConstraintName";
 
            int reti;

            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = tablename;
                cmd.Parameters.Add("@ConstraintName", SqlDbType.NVarChar, 256).Value = constraintName;
                reti = (int)(cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void CreateContraintIfNotExits(string tablename, string contraintName, string constraintBody)
        {
            if (!CheckConstraintExists(tablename, contraintName))
            {
                ExecDDLStmt("alter table " + QuoteSqlIdentifier(tablename) + " add constraint " +
                    QuoteSqlIdentifier(contraintName) + " " + constraintBody);
            }
        }

        public bool CheckColumnExists(string tablename, string columnName)
        {
            const string sel = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " +
                      "WHERE TABLE_NAME = @TableName AND COLUMN_NAME = @ColumnName";
            int reti;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = tablename;
                cmd.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 256).Value = columnName;
                reti = (int) (cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void CreateColumnIfNotExits(string tablename, string columnName, string datatype, bool notNull, string nnDefaultValueStr)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                string quotedTableName = QuoteSqlIdentifier(tablename);
                string quotedColumnName = QuoteSqlIdentifier(columnName);
                ExecDDLStmt("alter table " + quotedTableName + " add " + quotedColumnName + " " + datatype);

                if (notNull)
                {
                    using (var updateCmd = myConnection.CreateCommand())
                    {
                        updateCmd.Transaction = myTransaction;
                        updateCmd.CommandText = "update " + quotedTableName + " set " + quotedColumnName + "=" + nnDefaultValueStr;
                        updateCmd.CommandType = CommandType.Text;
                        updateCmd.ExecuteNonQuery();
                    }

                    using (var alterCmd = myConnection.CreateCommand())
                    {
                        alterCmd.Transaction = myTransaction;
                        alterCmd.CommandText = "alter table " + quotedTableName + " alter column " + quotedColumnName + " " + datatype + " not null";
                        alterCmd.CommandType = CommandType.Text;
                        alterCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteColumnIfExits(string tablename, string columnName)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                ExecDDLStmt("alter table " + QuoteSqlIdentifier(tablename) + " drop column " + QuoteSqlIdentifier(columnName));
            }
        }
    }
}
