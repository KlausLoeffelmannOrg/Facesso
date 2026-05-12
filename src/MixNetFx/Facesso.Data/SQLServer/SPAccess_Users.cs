using System;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    public sealed partial class SPAccess
    {
        public bool Users_DoesUsernameExist(int idSubsidiary, string username, ADDBNullable<int> excludeIDUser)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return false;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Users_DoesUsernameExist", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = username;
                locCmd.Parameters.Add("@ExcludeIDUser", SqlDbType.Int).Value = excludeIDUser.Value;
                locCmd.Parameters.Add("@DoesExist", SqlDbType.Bit);
                locCmd.Parameters["@DoesExist"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (bool)locCmd.Parameters["@DoesExist"].Value;
            }
        }

        public int Users_Add(UserInfo ui, int createdByIDUser, AddressDetailsInfo addrDet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Users_Add", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = ui.IDSubsidiary;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = ui.IDCostCenter;
                locCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = ui.FirstName;
                locCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = ui.LastName;
                locCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = ui.Username;
                locCmd.Parameters.Add("@Password", SqlDbType.VarBinary, 128).Value = ui.Password;
                locCmd.Parameters.Add("@ClearanceLevel", SqlDbType.BigInt).Value = ui.ClearanceLevel;
                locCmd.Parameters.Add("@HasWorkstationAccess", SqlDbType.Bit).Value = ui.HasWorkstationAccess;
                locCmd.Parameters.Add("@HasInternetAccess", SqlDbType.Bit).Value = ui.HasInternetAccess;
                locCmd.Parameters.Add("@IsActivated", SqlDbType.Bit).Value = ui.IsActivated;
                locCmd.Parameters.Add("@DoesExpire", SqlDbType.Bit).Value = ui.DoesExpire;
                locCmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ui.ExpireDate;
                locCmd.Parameters.Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate;
                locCmd.Parameters.Add("@CreatedByIDUser", SqlDbType.Int).Value = createdByIDUser;
                locCmd.Parameters.Add("@Comment", SqlDbType.NText).Value = ui.Comment.Value;
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
                locCmd.Parameters.Add("@IDUserNew", SqlDbType.Int);
                locCmd.Parameters["@IDUserNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDUserNew"].Value;
            }
        }

        public int Users_Edit(UserInfo ui, int lastEditedByIDUser, AddressDetailsInfo addrDet)
        {
            SqlConnection locConnection = GetOpenedConnectionSafely();
            if (locConnection == null) return 0;
            using (locConnection)
            {
                var locCmd = new SqlCommand("Users_Edit", locConnection);
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = ui.IDSubsidiary;
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = ui.IDUser;
                locCmd.Parameters.Add("@IDCostCenter", SqlDbType.Int).Value = ui.IDCostCenter;
                locCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = ui.FirstName;
                locCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = ui.LastName;
                locCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = ui.Username;
                locCmd.Parameters.Add("@Password", SqlDbType.VarBinary, 128).Value = ui.Password;
                locCmd.Parameters.Add("@ClearanceLevel", SqlDbType.BigInt).Value = ui.ClearanceLevel;
                locCmd.Parameters.Add("@HasWorkstationAccess", SqlDbType.Bit).Value = ui.HasWorkstationAccess;
                locCmd.Parameters.Add("@HasInternetAccess", SqlDbType.Bit).Value = ui.HasInternetAccess;
                locCmd.Parameters.Add("@IsActivated", SqlDbType.Bit).Value = ui.IsActivated;
                locCmd.Parameters.Add("@DoesExpire", SqlDbType.Bit).Value = ui.DoesExpire;
                locCmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ui.ExpireDate;
                locCmd.Parameters.Add("@Comment", SqlDbType.NText).Value = ui.Comment.Value;
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
                locCmd.Parameters.Add("@IDUserNew", SqlDbType.Int);
                locCmd.Parameters["@IDUserNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteReader();
                return (int)locCmd.Parameters["@IDUserNew"].Value;
            }
        }

        public UserInfoCollection UserInfoCollection
        {
            get
            {
                SqlConnection locConnection = GetOpenedConnectionSafely();
                if (locConnection == null) return null;
                using (locConnection)
                {
                    var locCommand = new SqlCommand(
                        "SELECT * From [Users] WHERE [IDSubsidiary]=@IDSubsidiary AND [IsSystemAccount]=0",
                        locConnection);
                    locCommand.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary;
                    SqlDataReader locDR = locCommand.ExecuteReader();
                    if (locDR.HasRows)
                    {
                        var locUIC = new UserInfoCollection();
                        while (locDR.Read())
                        {
                            var locUserInfo = new UserInfo();
                            locUserInfo.AssignFieldsFromDataReader(locDR);
                            locUIC.Add(locUserInfo);
                        }
                        return locUIC;
                    }
                    return null;
                }
            }
        }
    }
}
