using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace FacessoSetup
{
    internal partial class Program
    {
        static int RunDatabaseMaintenance(
            string connStr,
            bool removeExistingUserAdmins,
            bool deleteUsers,
            string subsidiaryName)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Database Maintenance");
            Console.WriteLine("===================================");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        WriteWarning("No maintenance changes were applied.");
                        return 0;
                    }

                    if (removeExistingUserAdmins)
                    {
                        int removedAdmins = RemoveExistingUserAdmins(conn);
                        WriteSuccess($"Removed {removedAdmins} extra administrator account(s).");
                    }

                    if (deleteUsers)
                    {
                        int removedUsers = DeleteNonAdminUsers(conn);
                        WriteSuccess($"Removed {removedUsers} non-admin user account(s).");
                    }

                    if (subsidiaryName != null)
                    {
                        int updatedSubsidiaries = ChangeSubsidiaryName(conn, subsidiaryName);
                        if (updatedSubsidiaries > 0)
                            WriteSuccess($"Updated the subsidiary name to '{subsidiaryName}' on {updatedSubsidiaries} record(s).");
                        else
                            WriteWarning("No subsidiary records were found.");
                    }
                }
            }
            catch (SqlException ex) { WriteException($"Database error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Database error", ex); return 1; }

            return 0;
        }

        static int RunSetup(string connStr, string adminUser, string adminPassword)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Registry & Database Setup");
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("Writing registry values...");

            try
            {
                DateTime today = DateTime.Today;
                string oaDateStr = today.ToOADate().ToString();
                string readableDate = today.ToString("dd.MM.yyyy");

                foreach (var view in new[] { RegistryView.Registry32, RegistryView.Registry64 })
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                    {
                        WriteReg(hklm, RegClasses, "SerialNumber", UniversalSerial, RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, ProgramGuid, ProgramGuid, RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, "ConnectionString", connStr, RegistryValueKind.String);
                        WriteReg(hklm, RegClasses, "RegObject", 1, RegistryValueKind.DWord);
                        WriteReg(hklm, RegBase, "ForceReapplication", 0, RegistryValueKind.DWord);
                        WriteReg(hklm, RegBase, "InstallationDate", readableDate, RegistryValueKind.String);
                        WriteReg(hklm, RegBase, "LastRunDate", readableDate, RegistryValueKind.String);
                        WriteReg(hklm, RegIntel, "SUD_Intel_Private", oaDateStr, RegistryValueKind.String);
                        WriteReg(hklm, RegIntel, "DRL_Intel_Private", oaDateStr, RegistryValueKind.String);
                        WriteReg(hklm, RegIntel, "DgeRL_Intel_Private", oaDateStr, RegistryValueKind.String);
                    }
                }

                using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    WriteReg(hkcu, RegClasses, "SerialNumber", UniversalSerial, RegistryValueKind.String);
                    WriteReg(hkcu, RegClasses, ProgramGuid, ProgramGuid, RegistryValueKind.String);
                    WriteReg(hkcu, RegClasses, "ConnectionString", connStr, RegistryValueKind.String);
                    WriteReg(hkcu, RegBase, "ForceReapplication", 0, RegistryValueKind.DWord);
                    WriteReg(hkcu, RegBase, "LastRunDate", readableDate, RegistryValueKind.String);
                }

                WriteSuccess("Registry configured.");
            }
            catch (UnauthorizedAccessException)
            {
                WriteError("Access denied writing to HKLM. Please run FacessoSetup as Administrator.");
                return 1;
            }
            catch (Exception ex)
            {
                WriteException("Registry error", ex);
                return 1;
            }

            Console.WriteLine();
            Console.WriteLine("Updating administrator accounts in database...");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        WriteWarning("Admin user password was not changed.");
                        return 0;
                    }

                    byte[] hash = HashPassword(adminPassword);
                    var updateResult = UpdateAdminUsers(conn, adminUser, hash);

                    if (updateResult.UpdatedUsers > 0)
                        WriteSuccess($"Password updated for {updateResult.UpdatedUsers} administrator account(s).");
                    else
                        WriteWarning("No active administrator accounts were updated.");

                    if (updateResult.InsertedUser)
                        WriteSuccess($"Administrator user '{adminUser}' was added to [dbo].[Users].");
                    else if (updateResult.PromotedExistingUser)
                        WriteSuccess($"Existing user '{adminUser}' was granted administrator rights.");
                }
            }
            catch (SqlException ex) { WriteException($"Database error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Database error", ex); return 1; }

            return 0;
        }

        static int RunAddAdmin(string connStr, string adminUser)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - Add Administrator");
            Console.WriteLine("================================");

            if (!TryPromptNewPassword($"Enter password for '{adminUser}'", "Add-admin", out string password))
                return 1;

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        WriteWarning("No administrator user was added.");
                        return 0;
                    }

                    byte[] hash = HashPassword(password);
                    var result = AddOrUpdateSingleAdmin(conn, adminUser, hash);

                    if (result.InsertedUser)
                        WriteSuccess($"Administrator user '{adminUser}' was added successfully.");
                    else if (result.PromotedExistingUser)
                        WriteSuccess($"Existing user '{adminUser}' was updated and granted administrator rights.");
                    else
                        WriteWarning($"No administrator changes were applied for '{adminUser}'.");
                }
            }
            catch (SqlException ex) { WriteException($"Database error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Database error", ex); return 1; }

            return 0;
        }

        static byte[] HashPassword(string plainPassword)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] hash1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

                byte[] salt = new byte[4];
                using (var rng = new RNGCryptoServiceProvider())
                    rng.GetBytes(salt);

                byte[] saltedInput = new byte[24];
                Buffer.BlockCopy(hash1, 0, saltedInput, 0, 20);
                Buffer.BlockCopy(salt, 0, saltedInput, 20, 4);

                byte[] hash2 = sha1.ComputeHash(saltedInput);
                byte[] stored = new byte[24];
                Buffer.BlockCopy(hash2, 0, stored, 0, 20);
                Buffer.BlockCopy(salt, 0, stored, 20, 4);
                return stored;
            }
        }

        static AdminPasswordUpdateResult UpdateAdminUsers(SqlConnection conn, string adminUser, byte[] passwordHash)
        {
            var result = new AdminPasswordUpdateResult();

            using (var tx = conn.BeginTransaction())
            {
                result.UpdatedUsers = UpdateAdminPasswords(conn, tx, adminUser, passwordHash);

                if (UserExists(conn, tx, adminUser))
                    result.PromotedExistingUser = EnsureAdminRights(conn, tx, adminUser, passwordHash);
                else
                    result.InsertedUser = InsertAdminUser(conn, tx, adminUser, passwordHash);

                tx.Commit();
            }

            return result;
        }

        static AdminPasswordUpdateResult AddOrUpdateSingleAdmin(SqlConnection conn, string adminUser, byte[] passwordHash)
        {
            var result = new AdminPasswordUpdateResult();

            using (var tx = conn.BeginTransaction())
            {
                if (UserExists(conn, tx, adminUser))
                {
                    result.UpdatedUsers = PromoteOrUpdateAdminUser(conn, tx, adminUser, passwordHash);
                    result.PromotedExistingUser = result.UpdatedUsers > 0;
                }
                else
                {
                    result.InsertedUser = InsertAdminUser(conn, tx, adminUser, passwordHash);
                    result.UpdatedUsers = result.InsertedUser ? 1 : 0;
                }

                tx.Commit();
            }

            return result;
        }

        static int UpdateAdminPasswords(SqlConnection conn, SqlTransaction tx, string adminUser, byte[] passwordHash)
        {
            using (var cmd = new SqlCommand(
                @"UPDATE [dbo].[Users]
                  SET [Password] = @pwd,
                      [LastEdited] = GETDATE()
                  WHERE ISNULL([IsCurrent], 1) = 1
                    AND [IsSystemAccount] = 0
                    AND (
                        [IDUserInternal] = 0 OR
                        [ClearanceLevel] = @adminClearance OR
                        [Username] IN (N'Admin', N'Administrator') OR
                        [Username] = @adminUser
                    )", conn, tx))
            {
                cmd.Parameters.Add("@pwd", SqlDbType.VarBinary, 128).Value = passwordHash;
                cmd.Parameters.Add("@adminClearance", SqlDbType.BigInt).Value = AdminClearance;
                cmd.Parameters.Add("@adminUser", SqlDbType.NVarChar, 100).Value = adminUser;
                return ExecuteNonQueryLogged(cmd);
            }
        }

        static bool UserExists(SqlConnection conn, SqlTransaction tx, string userName)
        {
            using (var cmd = new SqlCommand(
                @"SELECT COUNT(1)
                  FROM [dbo].[Users]
                  WHERE ISNULL([IsCurrent], 1) = 1 AND [Username] = @userName", conn, tx))
            {
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 100).Value = userName;
                return Convert.ToInt32(ExecuteScalarLogged(cmd), System.Globalization.CultureInfo.InvariantCulture) > 0;
            }
        }

        static bool EnsureAdminRights(SqlConnection conn, SqlTransaction tx, string adminUser, byte[] passwordHash) =>
            PromoteOrUpdateAdminUser(conn, tx, adminUser, passwordHash) > 0;

        static int PromoteOrUpdateAdminUser(SqlConnection conn, SqlTransaction tx, string adminUser, byte[] passwordHash)
        {
            using (var cmd = new SqlCommand(
                @"UPDATE [dbo].[Users]
                  SET [Password] = @pwd,
                      [ClearanceLevel] = @adminClearance,
                      [HasWorkstationAccess] = 1,
                      [HasInternetAccess] = 1,
                      [IsActivated] = 1,
                      [IsSystemAccount] = 0,
                      [DoesExpire] = 0,
                      [ExpireDate] = @neverExpires,
                      [LastEdited] = GETDATE()
                  WHERE ISNULL([IsCurrent], 1) = 1
                    AND [Username] = @adminUser
                    AND [IsSystemAccount] = 0", conn, tx))
            {
                cmd.Parameters.Add("@pwd", SqlDbType.VarBinary, 128).Value = passwordHash;
                cmd.Parameters.Add("@adminClearance", SqlDbType.BigInt).Value = AdminClearance;
                cmd.Parameters.Add("@adminUser", SqlDbType.NVarChar, 100).Value = adminUser;
                cmd.Parameters.Add("@neverExpires", SqlDbType.DateTime).Value = new DateTime(2199, 12, 31);
                return ExecuteNonQueryLogged(cmd);
            }
        }

        static bool InsertAdminUser(SqlConnection conn, SqlTransaction tx, string adminUser, byte[] passwordHash)
        {
            using (var cmd = new SqlCommand(
                @"DECLARE @NextIDUserInternal INT;

                  SELECT @NextIDUserInternal = ISNULL(MAX([IDUserInternal]), 0) + 1
                  FROM [dbo].[Users]
                  WHERE [IDUserInternal] >= 0;

                  INSERT INTO [dbo].[Users]
                             ([IDSubsidiary], [IDUserInternal], [IDCostCenter], [FirstName], [LastName],
                              [IDAddressDetails], [Username], [Password], [ClearanceLevel],
                              [HasWorkstationAccess], [HasInternetAccess], [IsActivated], [IsCurrent],
                              [DoesExpire], [ExpireDate], [IsSystemAccount], [WasCurrentFrom],
                              [WasCurrentTo], [Comment])
                  SELECT TOP (1)
                         [IDSubsidiary],
                         @NextIDUserInternal,
                         [IDCostCenter],
                         N'Facesso',
                         @adminUser,
                         NULL,
                         @adminUser,
                         @pwd,
                         @adminClearance,
                         1,
                         1,
                         1,
                         1,
                         0,
                         @neverExpires,
                         0,
                         GETDATE(),
                         @neverExpires,
                         N'Administratorkonto - angelegt durch FacessoSetup'
                  FROM [dbo].[CostCenters]
                  WHERE ISNULL([IsCurrent], 1) = 1
                  ORDER BY CASE WHEN [IDCostCenterInternal] = 0 THEN 0 ELSE 1 END, [CostCenterNo];", conn, tx))
            {
                cmd.Parameters.Add("@adminUser", SqlDbType.NVarChar, 100).Value = adminUser;
                cmd.Parameters.Add("@pwd", SqlDbType.VarBinary, 128).Value = passwordHash;
                cmd.Parameters.Add("@adminClearance", SqlDbType.BigInt).Value = AdminClearance;
                cmd.Parameters.Add("@neverExpires", SqlDbType.DateTime).Value = new DateTime(2199, 12, 31);
                return ExecuteNonQueryLogged(cmd) > 0;
            }
        }

        static int RemoveExistingUserAdmins(SqlConnection conn) =>
            DeleteUsersByPredicate(conn,
                "u.[IsSystemAccount] = 0 AND ISNULL(u.[IsCurrent], 1) = 1 " +
                "AND ISNULL(u.[Username], N'') NOT LIKE N'Facesso!%' " +
                "AND ISNULL(u.[Username], N'') NOT IN (N'Admin', N'Administrator') " +
                "AND u.[ClearanceLevel] = @adminClearance");

        static int DeleteNonAdminUsers(SqlConnection conn) =>
            DeleteUsersByPredicate(conn,
                "u.[IsSystemAccount] = 0 AND ISNULL(u.[IsCurrent], 1) = 1 " +
                "AND ISNULL(u.[Username], N'') NOT LIKE N'Facesso!%' " +
                "AND ISNULL(u.[Username], N'') NOT IN (N'Admin', N'Administrator') " +
                "AND u.[ClearanceLevel] <> @adminClearance");

        static int DeleteUsersByPredicate(SqlConnection conn, string userPredicate)
        {
            using (var tx = conn.BeginTransaction())
            {
                if (TableExists(conn, "ApplicationSettings", tx))
                {
                    ExecuteDelete(conn, tx,
                        @"DELETE app
                          FROM [dbo].[ApplicationSettings] app
                          INNER JOIN [dbo].[Users] u
                                  ON app.[IDSubsidiary] = u.[IDSubsidiary]
                                 AND app.[IDUser] = u.[IDUser]
                          WHERE " + userPredicate);
                }

                if (TableExists(conn, "FunctionLog", tx))
                {
                    ExecuteDelete(conn, tx,
                        @"DELETE logItems
                          FROM [dbo].[FunctionLog] logItems
                          INNER JOIN [dbo].[Users] u
                                  ON logItems.[IDSubsidiary] = u.[IDSubsidiary]
                                 AND logItems.[CalledByIDUser] = u.[IDUser]
                          WHERE " + userPredicate);
                }

                int deletedUsers = ExecuteDelete(conn, tx,
                    @"DELETE u
                      FROM [dbo].[Users] u
                      WHERE " + userPredicate);

                tx.Commit();
                return deletedUsers;
            }
        }

        static int ExecuteDelete(SqlConnection conn, SqlTransaction tx, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@adminClearance", SqlDbType.BigInt).Value = AdminClearance;
                return ExecuteNonQueryLogged(cmd);
            }
        }

        static int ChangeSubsidiaryName(SqlConnection conn, string subsidiaryName, SqlTransaction tx = null)
        {
            using (var cmd = new SqlCommand(
                @"UPDATE [dbo].[Subsidiaries]
                  SET [SubsidiaryName] = @subsidiaryName,
                      [LastEdited] = GETDATE()", conn, tx))
            {
                cmd.Parameters.Add("@subsidiaryName", SqlDbType.NVarChar, 100).Value = subsidiaryName;
                return ExecuteNonQueryLogged(cmd);
            }
        }

        static int ListUsers(string connStr)
        {
            Console.WriteLine();
            Console.WriteLine("FacessoSetup - User List");
            Console.WriteLine("========================");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    if (!IsFacessoDatabase(conn))
                    {
                        WriteWarning("Connected database does not appear to be a Facesso database.");
                        return 0;
                    }

                    using (var cmd = new SqlCommand(
                        @"SELECT [IDUserInternal], [Username], [FirstName], [LastName],
                                 [IsSystemAccount], [ClearanceLevel], [IsActivated]
                          FROM [dbo].[Users]
                          WHERE ISNULL([IsCurrent], 1) = 1
                          ORDER BY [IsSystemAccount] DESC,
                                   CASE WHEN [ClearanceLevel] = @adminClearance THEN 0 ELSE 1 END,
                                   [Username]", conn))
                    {
                        cmd.Parameters.Add("@adminClearance", SqlDbType.BigInt).Value = AdminClearance;

                        using (var reader = ExecuteReaderLogged(cmd))
                        {
                            Console.WriteLine("{0,-30} {1,-6} {2,-6} {3,-8} {4}",
                                "Username", "Admin", "System", "Active", "Name");
                            Console.WriteLine(new string('-', 75));

                            int rows = 0;
                            while (reader.Read())
                            {
                                rows++;
                                string userName = reader["Username"].ToString();
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                bool isSystem = Convert.ToBoolean(reader["IsSystemAccount"]);
                                bool isActive = Convert.ToBoolean(reader["IsActivated"]);
                                long clearance = Convert.ToInt64(reader["ClearanceLevel"]);
                                bool isAdmin = !isSystem &&
                                               (clearance == AdminClearance ||
                                                string.Equals(userName, "Admin", StringComparison.OrdinalIgnoreCase) ||
                                                string.Equals(userName, "Administrator", StringComparison.OrdinalIgnoreCase));

                                Console.WriteLine("{0,-30} {1,-6} {2,-6} {3,-8} {4}",
                                    Truncate(userName, 30),
                                    isAdmin ? "yes" : "no",
                                    isSystem ? "yes" : "no",
                                    isActive ? "yes" : "no",
                                    $"{firstName} {lastName}".Trim());
                            }

                            if (rows == 0)
                                WriteWarning("No users were found.");
                        }
                    }
                }
            }
            catch (SqlException ex) { WriteException($"Database error ({ex.Number})", ex); return 1; }
            catch (Exception ex) { WriteException("Database error", ex); return 1; }

            return 0;
        }

        static void WriteReg(RegistryKey hive, string subKeyPath, string valueName,
                             object value, RegistryValueKind kind)
        {
            using (var key = hive.CreateSubKey(subKeyPath, writable: true))
                key.SetValue(valueName, value, kind);
            Console.WriteLine($"  SET {hive.Name}\\{subKeyPath} => {valueName}");
        }
    }
}
