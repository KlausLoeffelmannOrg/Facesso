using System.Data.SqlClient;
using ActiveDevelop.SqlTools;

namespace Facesso.Data
{
    public class DatenModelUpdater : DatabaseSchemaUpdateManager
    {
        public DatenModelUpdater(string connection, bool silent)
            : base(connection, silent)
        {
        }

        public bool CheckIfUpdateRequired()
        {
            if (!CheckTableExists("[dbo].[EmployeeHandicaps]"))
                return true;
            return false;
        }

        public void PerformSchemaUpdate()
        {
            try
            {
                StartTransaction();
                if (!CheckTableExists("[dbo].[EmployeeHandicaps]"))
                {
                    ExecDDLStmt("CREATE TABLE [dbo].[EmployeeHandicaps](" +
                        "[IDEmployee] [int] NOT NULL," +
                        "[IDSubsidiary] [int] NOT NULL," +
                        "[Handicap] [float] NOT NULL," +
                        "[ValidFrom] [datetime] NOT NULL)");

                    ExecDDLStmt("Create Index IX_EmployeeHandicap on [dbo].[EmployeeHandicaps] (IDSubsidiary, IDEmployee)");

                    ExecDDLStmt("ALTER TABLE [dbo].[EmployeeHandicaps]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeHandicap_Employees] FOREIGN KEY([IDSubsidiary], [IDEmployee]) " +
                                    "REFERENCES [dbo].[Employees] ([IDSubsidiary], [IDEmployee])");

                    ExecDDLStmt("ALTER TABLE [dbo].[EmployeeHandicaps] CHECK CONSTRAINT [FK_EmployeeHandicap_Employees]");

                    Commit();
                }
            }
            catch (System.Exception ex)
            {
                Rollback();
                throw ex;
            }
        }
    }
}
