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
            const string sel = "SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@TableName) AND type in (N'U') ";
            int reti;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = QuoteSqlIdentifier(tablename);

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
            string safeTableName = QuoteSqlIdentifier(tablename);
            string sel = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@TableName) AND type in (N'U')) " +
                      "   DROP TABLE " + safeTableName;

            using (SqlCommand cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 256).Value = safeTableName;
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
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 128).Value = GetLeafIdentifier(tablename);
                cmd.Parameters.Add("@ConstraintName", SqlDbType.NVarChar, 128).Value = GetLeafIdentifier(constraintName);
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
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 128).Value = GetLeafIdentifier(tablename);
                cmd.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 128).Value = GetLeafIdentifier(columnName);
                reti = (int) (cmd.ExecuteScalar() ?? -1);
            }

            return reti == 1;
        }

        public void CreateColumnIfNotExits(string tablename, string columnName, string datatype, bool notNull, string nnDefaultValueStr)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                string safeTableName = QuoteSqlIdentifier(tablename);
                string safeColumnName = QuoteSqlIdentifier(columnName);
                ExecDDLStmt("alter table " + safeTableName + " add " + safeColumnName + " " + datatype);

                if (notNull)
                {
                    using (var updateCmd = myConnection.CreateCommand())
                    {
                        updateCmd.Transaction = myTransaction;
                        updateCmd.CommandText = "update " + safeTableName + " set " + safeColumnName + "=" + nnDefaultValueStr;
                        updateCmd.CommandType = CommandType.Text;
                        updateCmd.ExecuteNonQuery();
                    }

                    using (var alterCmd = myConnection.CreateCommand())
                    {
                        alterCmd.Transaction = myTransaction;
                        alterCmd.CommandText = "alter table " + safeTableName + " alter column " + safeColumnName + " " + datatype + " not null";
                        alterCmd.CommandType = CommandType.Text;
                        alterCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteColumnIfExits(string tablename, string columnName)
        {
            if (CheckColumnExists(tablename, columnName))
            {
                ExecDDLStmt("alter table " + QuoteSqlIdentifier(tablename) + " drop column " + QuoteSqlIdentifier(columnName));
            }
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

        private static string GetLeafIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                return string.Empty;

            string[] parts = identifier.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string leaf = parts.Length == 0 ? identifier : parts[parts.Length - 1];
            leaf = leaf.Trim();
            if (leaf.StartsWith("[", StringComparison.Ordinal) &&
                leaf.EndsWith("]", StringComparison.Ordinal) &&
                leaf.Length >= 2)
            {
                leaf = leaf.Substring(1, leaf.Length - 2);
            }

            return leaf.Replace("]]", "]");
        }
    }
}
