using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool Employees_DoesPersonnelNumberExist(int idSubsidiary, int personnelNumber, ADDBNullable<int> excludeIDEmployee)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_DoesPersonnelNumberExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@PersonnelNumber", SqlDbType.Int).Value = personnelNumber;
                locCmd.Parameters.Add("@ExcludeIDEmployee", SqlDbType.Int).Value = excludeIDEmployee.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteScalar();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public bool Employees_DoesMatchcodeExist(int idSubsidiary, ADDBNullable<string> matchcode, ADDBNullable<int> excludeIDEmployee)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_DoesMatchcodeExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@Matchcode", SqlDbType.Int).Value = matchcode;
                locCmd.Parameters.Add("@ExcludeIDEmployee", SqlDbType.Int).Value = excludeIDEmployee.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int Employees_Add(EmployeeInfo ei, int createdByIDUser, AddressDetailsInfo addrDet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = ei.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = ei.IDCostCenter;
                locCmd.Parameters.Add("@IDWageGroup", SqlDbType.Int).Value = ei.IDWageGroup.Value;
                locCmd.Parameters.Add("@UseFixedWage", SqlDbType.Bit).Value = ei.UseFixedWage;
                locCmd.Parameters.Add("@FixedWage", SqlDbType.Money).Value = ei.FixedWage.Value;
                locCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = ei.FirstName;
                locCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = ei.LastName;
                locCmd.Parameters.Add("@MatchCode", SqlDbType.NVarChar, 20).Value = ei.Matchcode.Value;
                locCmd.Parameters.Add("@PersonnelNumber", SqlDbType.Int).Value = ei.PersonnelNumber;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = ei.IsActive;
                locCmd.Parameters.Add("@IsIncentive", SqlDbType.Bit).Value = ei.IsIncentive;
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = ei.DateOfBirth.Value;
                locCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime).Value = ei.DateOfJoining.Value;
                locCmd.Parameters.Add("@DateOfSeparation", SqlDbType.DateTime).Value = ei.DateOfSeparation.Value;
                locCmd.Parameters.Add("@TimeCardNo", SqlDbType.NText).Value = ei.TimeCardNo.Value;
                locCmd.Parameters.Add("@Comment", SqlDbType.NText).Value = ei.Comment.Value;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                // Address details
                locCmd.Parameters.Add("@PersonnelNo", SqlDbType.Int).Value = addrDet.PersonnelNo.Value;
                locCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 100).Value = addrDet.MiddleName.Value;
                locCmd.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = addrDet.Titel.Value;
                locCmd.Parameters.Add("@Street", SqlDbType.NVarChar, 100).Value = addrDet.Street.Value;
                locCmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 10).Value = addrDet.Zip.Value;
                locCmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = addrDet.City.Value;
                locCmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar, 10).Value = addrDet.CountryCode.Value;
                locCmd.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = addrDet.Country.Value;
                locCmd.Parameters.Add("@CompanyPhone", SqlDbType.NVarChar, 100).Value = addrDet.CompanyPhone.Value;
                locCmd.Parameters.Add("@PrivatePhone", SqlDbType.NVarChar, 100).Value = addrDet.PrivatePhone.Value;
                locCmd.Parameters.Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = addrDet.CompanyEmail.Value;
                locCmd.Parameters.Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = addrDet.PrivateEmail.Value;
                locCmd.Parameters.Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = addrDet.CompanyMobile.Value;
                locCmd.Parameters.Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = addrDet.PrivateMobile.Value;
                locCmd.Parameters.Add("@URL", SqlDbType.NVarChar, 100).Value = addrDet.URL.Value;
                locCmd.Parameters.Add("@IDEmployeeNew", SqlDbType.Int);
                locCmd.Parameters["@IDEmployeeNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDEmployeeNew"].Value;
            }
        }

        public bool Employees_IsInUse(EmployeeInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_IsInUse", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = lvi.IDEmployee;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.Parameters.Add("@IsInUse", SqlDbType.Bit);
                locCmd.Parameters["@IsInUse"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                return (bool)locCmd.Parameters["@IsInUse"].Value;
            }
        }

        public void Employees_Delete(EmployeeInfo lvi)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_Delete", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = lvi.IDEmployee;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary;
                locCmd.ExecuteNonQuery();
            }
        }

        public int Employees_Edit(EmployeeInfo ei, int lastEditedByIDUser, AddressDetailsInfo addrDet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = ei.IDSubsidiary;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = ei.IDEmployee;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = ei.IDCostCenter;
                locCmd.Parameters.Add("@IDWageGroup", SqlDbType.Int).Value = ei.IDWageGroup.Value;
                locCmd.Parameters.Add("@UseFixedWage", SqlDbType.Bit).Value = ei.UseFixedWage;
                locCmd.Parameters.Add("@FixedWage", SqlDbType.Money).Value = ei.FixedWage.Value;
                locCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = ei.FirstName;
                locCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = ei.LastName;
                locCmd.Parameters.Add("@MatchCode", SqlDbType.NVarChar, 20).Value = ei.Matchcode.Value;
                locCmd.Parameters.Add("@PersonnelNumber", SqlDbType.Int).Value = ei.PersonnelNumber;
                locCmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = ei.IsActive;
                locCmd.Parameters.Add("@IsIncentive", SqlDbType.Bit).Value = ei.IsIncentive;
                locCmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = ei.DateOfBirth.Value;
                locCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime).Value = ei.DateOfJoining.Value;
                locCmd.Parameters.Add("@DateOfSeparation", SqlDbType.DateTime).Value = ei.DateOfSeparation.Value;
                locCmd.Parameters.Add("@TimeCardNo", SqlDbType.NText).Value = ei.TimeCardNo.Value;
                locCmd.Parameters.Add("@Comment", SqlDbType.NText).Value = ei.Comment.Value;
                locCmd.Parameters.Add("@LastEditedByIDUser", SqlDbType.Int).Value = lastEditedByIDUser;
                // Address details
                locCmd.Parameters.Add("@PersonnelNo", SqlDbType.Int).Value = addrDet.PersonnelNo.Value;
                locCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 100).Value = addrDet.MiddleName.Value;
                locCmd.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = addrDet.Titel.Value;
                locCmd.Parameters.Add("@Street", SqlDbType.NVarChar, 100).Value = addrDet.Street.Value;
                locCmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 10).Value = addrDet.Zip.Value;
                locCmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = addrDet.City.Value;
                locCmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar, 10).Value = addrDet.CountryCode.Value;
                locCmd.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = addrDet.Country.Value;
                locCmd.Parameters.Add("@CompanyPhone", SqlDbType.NVarChar, 100).Value = addrDet.CompanyPhone.Value;
                locCmd.Parameters.Add("@PrivatePhone", SqlDbType.NVarChar, 100).Value = addrDet.PrivatePhone.Value;
                locCmd.Parameters.Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = addrDet.CompanyEmail.Value;
                locCmd.Parameters.Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = addrDet.PrivateEmail.Value;
                locCmd.Parameters.Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = addrDet.CompanyMobile.Value;
                locCmd.Parameters.Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = addrDet.PrivateMobile.Value;
                locCmd.Parameters.Add("@URL", SqlDbType.NVarChar, 100).Value = addrDet.URL.Value;
                locCmd.Parameters.Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = FacessoGeneric.ConsiderHistoryMaintenance;
                locCmd.Parameters.Add("@IDEmployeeNew", SqlDbType.Int);
                locCmd.Parameters["@IDEmployeeNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDEmployeeNew"].Value;
            }
        }

        public void Employees_GetInWorkGroupOnShiftDate(CombinedParametersInfo cp, EmployeeInfoItems eic)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_GetInWorkGroupOnShiftDate", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                locCmd.Parameters.Add("@IDWorkGroup", SqlDbType.Int).Value = cp.WorkGroup.IDWorkGroup;
                locCmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = cp.ProductionDate;
                locCmd.Parameters.Add("@Shift", SqlDbType.TinyInt).Value = cp.Shift;
                SqlDataReader locDR = locCmd.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        var locEmployeeInfo = new EmployeeInfo(locDR, true);
                        eic.Add(locEmployeeInfo);
                    }
                }
            }
        }

        public string EmployeeInfoCollectionCommandString()
        {
            return "SELECT [Employees].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName] FROM [Employees] " +
                "[Employees] INNER JOIN [CostCenters] ON " +
                "[Employees].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " +
                "[Employees].[IDSubsidiary]=@IDSubsidiary AND [Employees].[IsCurrent]='true'";
        }

        public string EmployeeInfoCollectionCommandString(string orderByString)
        {
            return EmployeeInfoCollectionCommandString() + " ORDER BY " + QuoteSqlIdentifier(orderByString);
        }

        internal void Employees_LookUpWageData(EmployeeWageInfo employee)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Employees_LookUpWageData", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = employee.IDSubsidiary;
                locCmd.Parameters.Add("@IDEmployee", SqlDbType.Int).Value = employee.IDEmployee;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = employee.IDCostCenter;
                locCmd.Parameters.Add("@DegreeOfTime", SqlDbType.Float).Value = (double)employee.DegreeOfTime;
                locCmd.Parameters.Add("@UseFixValuedBonus", SqlDbType.Bit); locCmd.Parameters["@UseFixValuedBonus"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@BaseWage", SqlDbType.Float); locCmd.Parameters["@BaseWage"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@Percentage", SqlDbType.Float); locCmd.Parameters["@Percentage"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@AbsoluteValue", SqlDbType.Float); locCmd.Parameters["@AbsoluteValue"].Direction = ParameterDirection.Output;
                locCmd.ExecuteScalar();
                employee.UseFixValuedBonus = (bool)locCmd.Parameters["@UseFixValuedBonus"].Value;
                try
                {
                    employee.BaseWage = (double)locCmd.Parameters["@BaseWage"].Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Basislohn für Mitarbeiter " + employee.LastName + " (" + employee.PersonnelNumber.ToString() +
                        ") wurde nicht richtig zugeordnet." + Environment.NewLine +
                        "Bitte überprüfen Sie daher die durchgeführten Berechnungen für die Facesso keine Richtigkeit garantieren kann!",
                        "Fehler in Mitarbeiterstammdaten", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                employee.Percentage = (double)locCmd.Parameters["@Percentage"].Value;
                employee.AbsoluteValue = (double)locCmd.Parameters["@AbsoluteValue"].Value;
            }
        }
    }
}
