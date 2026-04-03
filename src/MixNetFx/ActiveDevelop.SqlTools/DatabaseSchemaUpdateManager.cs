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
            var sel = "SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'" + tablename + "') AND type in (N'U') ";
            var reti = -1;
            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                reti = Convert.ToInt32(cmd.ExecuteScalar());
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
            var sel = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + tablename + "') AND type in (N'U')) " +
                      "   DROP TABLE " + tablename;
            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecDDLStmt(string ddlCmd)
        {
            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = ddlCmd;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckConstraintExists(string tablename, string constraintName)
        {
            var sel = "select distinct 1 FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE " +
                      "where table_name ='" + tablename + "' AND CONSTRAINT_NAME = '" + constraintName + "'";
            var reti = -1;
            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                reti = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return reti == 1;
        }

        public void CreateContraintIfNotExits(string tablename, string contraintName, string constraintBody)
        {
            if (!CheckConstraintExists(tablename, contraintName))
            {
                ExecDDLStmt("alter table " + tablename + " add constraint " + contraintName + " " + constraintBody);
            }
        }

        public bool CheckColumnExists(string tablename, string columnName)
        {
            var sel = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " +
                      "WHERE TABLE_NAME = '" + tablename + "' AND COLUMN_NAME = '" + columnName + "'";
            var reti = -1;
            using (var cmd = myConnection.CreateCommand())
            {
                cmd.Transaction = myTransaction;
                cmd.CommandText = sel;
                cmd.CommandType = CommandType.Text;
                reti = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return reti == 1;
        }

        public void CreateColumnIfNotExits(string tablename, string columnName, string datatype, bool notNull, string nnDefaultValueStr)
        {
            if (!CheckColumnExists(tablename, columnName))
            {
                ExecDDLStmt("alter table " + tablename + " add " + columnName + " " + datatype);
                if (notNull)
                {
                    using (var updateCmd = myConnection.CreateCommand())
                    {
                        updateCmd.Transaction = myTransaction;
                        updateCmd.CommandText = "update " + tablename + " set " + columnName + "=" + nnDefaultValueStr;
                        updateCmd.CommandType = CommandType.Text;
                        updateCmd.ExecuteNonQuery();
                    }

                    using (var alterCmd = myConnection.CreateCommand())
                    {
                        alterCmd.Transaction = myTransaction;
                        alterCmd.CommandText = "alter table " + tablename + " alter column " + columnName + " " + datatype + " not null";
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
                ExecDDLStmt("alter table " + tablename + " drop column " + columnName);
            }
        }
    }
}
