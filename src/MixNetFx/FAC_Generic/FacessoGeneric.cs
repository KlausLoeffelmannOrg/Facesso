using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace Facesso
{
    [CLSCompliant(false)]
    public static class FacessoGeneric
    {
        private const string ENTITY_CONNSTRING_METADATA =
            "res://*/FacessoModel.csdl|res://*/FacessoModel.ssdl|res://*/FacessoModel.msl";

        private static FacessoLicenseManager myFacessoLicense;
        private static string mySqlConnectionString;
        private static string myEntityConnectionString;
        private static UserInfo myLoginInfo;
        private static SubsidiaryInfoCollection mySubsidiaries;
        private static FacessoApplicationSettings mySettings;
        private static XmlFacessoApplicationSettings myFacessoGlobalSettings;
        private static XmlFacessoApplicationSettings myFacessoUserSettings;

        static FacessoGeneric() { }

        public static void InitializeComponent()
        {
            mySqlConnectionString = RegistryHelper.ConnectionString;
            RebuildSubsidiaries();
            mySettings = new FacessoApplicationSettings();
            myFacessoGlobalSettings = XmlFacessoApplicationSettings.FromFacessoDatabase(0, 0);
        }

        public static void RebuildSubsidiaries()
        {
            mySubsidiaries = new SubsidiaryInfoCollection(mySqlConnectionString);
        }

        public static void SaveGlobalSettings()
        {
            SaveXMLSettingsToDB(FacessoGlobalSettings);
        }

        public static void SaveAllSettings()
        {
            SaveGlobalSettings();
            SaveUserSettings();
        }

        public static void SaveUserSettings()
        {
            SaveXMLSettingsToDB(FacessoUserSettings);
        }

        private static void SaveXMLSettingsToDB(XmlFacessoApplicationSettings settings)
        {
            var locConnection = new SqlConnection(FacessoGeneric.SQLConnectionString);
            locConnection.Open();
            using (locConnection)
            {
                var locCmd = new SqlCommand();
                locCmd.Connection = locConnection;
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.CommandText = "ApplicationSettings_Set";

                locCmd.Parameters.Add("@IDApplicationSettings", SqlDbType.Int).Value = settings.IDApplicationSettings;
                if (settings.IsGlobal == true)
                {
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = 0;
                    locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = 0;
                }
                else
                {
                    locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = LoginInfo.IDSubsidiary;
                    locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = LoginInfo.IDUser;
                }
                locCmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = settings.IsGlobal;
                locCmd.Parameters.Add("@Settings", SqlDbType.Xml).Value =
                    settings.ToXml(typeof(XmlFacessoApplicationSettings));
                locCmd.Parameters.Add("@IDAppSettingsNew", SqlDbType.Int);
                locCmd.Parameters["@IDAppSettingsNew"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();
                settings.IDApplicationSettings = (int)locCmd.Parameters["@IDAppSettingsNew"].Value;
            }
        }

        public static bool IsSetup()
        {
            string locGuid = RegistryHelper.ProgramGUID;
            if (locGuid == null)
                return false;
            return RegistryHelper.IsRegistered();
        }

        public static bool IsDatabaseSetup()
        {
            return mySubsidiaries.Count != 0;
        }

        public static void SetupLicenseInfoAndLogin()
        {
            myFacessoLicense = new FacessoLicenseManager(new Guid(RegistryHelper.ProgramGUID),
                RegistryHelper.InstallationDate, RegistryHelper.LastRunDate,
                RegistryHelper.LastRegisteredDate, RegistryHelper.SerialNumber);

            if (myLoginInfo == null)
                Login();
        }

        public static DateTime OpenCurrentToDate => new DateTime(2199, 12, 31);

        public static int FirstShiftThresholdInMin
        {
            get { return RegistryHelper.FirstShiftThresholdInMin; }
            set { RegistryHelper.FirstShiftThresholdInMin = value; }
        }

        public static DateTime FallbackStartTime
        {
            get { return RegistryHelper.FallbackStartTime; }
            set { RegistryHelper.FallbackStartTime = value; }
        }

        public static DateTime FallbackEndTime
        {
            get { return RegistryHelper.FallbackEndTime; }
            set { RegistryHelper.FallbackEndTime = value; }
        }

        public static FacessoLicenseManager FacessoLicenseInfo
        {
            get
            {
                if (myFacessoLicense == null)
                    SetupLicenseInfoAndLogin();
                return myFacessoLicense;
            }
        }

        public static string SQLConnectionString => mySqlConnectionString;

        public static string SqlEntityConnectionString
        {
            get
            {
                var entityConn = new EntityConnectionStringBuilder();
                entityConn.ProviderConnectionString = SQLConnectionString;
                entityConn.Metadata = ENTITY_CONNSTRING_METADATA;
                entityConn.Provider = "System.Data.SqlClient";
                return entityConn.ConnectionString;
            }
        }

        public static string SerialNumber => RegistryHelper.SerialNumber;

        public static string InstallationFolder
        {
            get { return RegistryHelper.InstallationFolder; }
            set { RegistryHelper.InstallationFolder = value; }
        }

        public static string UpdateUrl
        {
            get { return RegistryHelper.UpdateUrl; }
            set { RegistryHelper.UpdateUrl = value; }
        }

        public static string UpdateFolder
        {
            get { return RegistryHelper.UpdateFolder; }
            set { RegistryHelper.UpdateFolder = value; }
        }

        public static string SharedFolder
        {
            get { return RegistryHelper.SharedFolder; }
            set { RegistryHelper.SharedFolder = value; }
        }

        public static SubsidiaryInfoCollection Subsidiaries => mySubsidiaries;

        public static string SubsidiarySynonym
        {
            get
            {
                return FacessoGlobalSettings.Settings.GetItem(
                    "SubsidiarySynonym",
                    global::Facesso.My.Resources.Resources.SubsidiaryDefaultSynonym).ToString();
            }
            set { FacessoGlobalSettings.Settings.SetItem("SubsidiarySynonym", value); }
        }

        public static UserInfo LoginInfo => myLoginInfo;

        public static FacessoApplicationSettings AppSettings => mySettings;

        public static XmlFacessoApplicationSettings FacessoUserSettings
        {
            get { return myFacessoUserSettings; }
            set { myFacessoUserSettings = value; }
        }

        public static XmlFacessoApplicationSettings FacessoGlobalSettings
        {
            get { return myFacessoGlobalSettings; }
            set { myFacessoGlobalSettings = value; }
        }

        public static bool ConsiderHistoryMaintenance => false;

        public static bool PermitFunctionForVersion(IVersionPermissionInfo versionPI)
        {
            var locVpi = (FacessoVersionPermissionInfo)versionPI;
            return locVpi.FacessoVersion <= FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion;
        }

        public static bool PermitFunctionForRole(IRolePermissionInfo rolePI)
        {
            var locRpi = (FacessoRolePermissionInfo)rolePI;
            return (FacessoGeneric.LoginInfo.ClearanceLevel & locRpi.ClearanceLevel) == locRpi.ClearanceLevel;
        }

        public static void Login()
        {
            LoginHistory locLoginHistory = AppSettings.LoginHistory;

            if (locLoginHistory == null)
            {
                locLoginHistory = new LoginHistory();
                locLoginHistory.Add("Administrator");
                locLoginHistory.LastLoginName = "Administrator";
                FacessoGeneric.FacessoGlobalSettings.Settings.SetItem("LoginHistory", locLoginHistory);
                AppSettings.LoginHistory = locLoginHistory;
            }
            else
            {
                locLoginHistory.LastLoginName = AppSettings.LastLoginName;
            }

            var locLoginForm = new frmLogin();

            UserInfo locLoginInfo = locLoginForm.Login(Subsidiaries, AppSettings.LastSubsidiaryID, locLoginHistory) 
                ?? throw new FacessoLoginException("Login-Abbruch führte zu Ausnahme (kein kritischer Fehler).", null);

            myLoginInfo = locLoginInfo;
            FacessoUserSettings = XmlFacessoApplicationSettings.FromFacessoDatabase(LoginInfo.IDUser, LoginInfo.IDSubsidiary);
            AppSettings.LoginHistory.LastLoginDate = DateTime.Now;
            AppSettings.LoginHistory.Add(myLoginInfo.Username);
            AppSettings.LastLoginName = myLoginInfo.Username;
            AppSettings.LastSubsidiaryID = myLoginInfo.IDSubsidiary;
        }

        public static string RoleList 
            => global::Facesso.My.Resources.Resources.RolesList;
    }

    [Serializable]
    [XmlInclude(typeof(MonthRangePickerResult))]
    [XmlInclude(typeof(LoginHistory))]
    [XmlInclude(typeof(TimeSettingDetail))]
    [XmlInclude(typeof(TimeSettingDetails))]
    [XmlInclude(typeof(LayoutAndNumberformats))]
    [XmlInclude(typeof(FacessoShellWindowsControl))]
    [XmlInclude(typeof(FacessoGeneralOptions))]
    public class XmlFacessoApplicationSettings : ADXmlSettings
    {
        private int myIDApplicationSettings;
        private bool myIsGlobal;
        private int myIDUser;

        public int IDApplicationSettings
        {
            get { return myIDApplicationSettings; }
            set { myIDApplicationSettings = value; }
        }

        public bool IsGlobal
        {
            get { return myIsGlobal; }
            set { myIsGlobal = value; }
        }

        public int IDUser
        {
            get { return myIDUser; }
            set { myIDUser = value; }
        }

        public static XmlFacessoApplicationSettings FromXML(string xmlString, Type xmlType)
        {
            var locXml = new XmlSerializer(xmlType);
            var locSr = new StringReader(xmlString);
            return (XmlFacessoApplicationSettings)locXml.Deserialize(locSr);
        }

        public static XmlFacessoApplicationSettings FromFacessoDatabase(int idUser, int idSubsidiary)
        {
            XmlFacessoApplicationSettings locSettings;
            var locConnection = new SqlConnection(FacessoGeneric.SQLConnectionString);
            locConnection.Open();
            using (locConnection)
            {
                var locCmd = new SqlCommand();
                locCmd.Connection = locConnection;
                locCmd.CommandType = CommandType.StoredProcedure;
                locCmd.CommandText = "ApplicationSettings_Get";

                locCmd.Parameters.Add("@IDSubsidiary", SqlDbType.Int).Value = idSubsidiary;
                locCmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = (idUser == 0);
                locCmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = idUser;
                locCmd.Parameters.Add("@Settings", SqlDbType.Xml, -1);
                locCmd.Parameters["@Settings"].Direction = ParameterDirection.Output;
                locCmd.Parameters.Add("@IDApplicationSettings", SqlDbType.Int);
                locCmd.Parameters["@IDApplicationSettings"].Direction = ParameterDirection.Output;
                locCmd.ExecuteNonQuery();

                if (locCmd.Parameters["@IDApplicationSettings"].Value != DBNull.Value)
                {
                    string locXML = locCmd.Parameters["@Settings"].Value.ToString();
                    locSettings = FromXML(locXML, typeof(XmlFacessoApplicationSettings));
                    locSettings.IDApplicationSettings = (int)locCmd.Parameters["@IDApplicationSettings"].Value;
                    return locSettings;
                }
                else
                {
                    locSettings = new XmlFacessoApplicationSettings();
                    locSettings.IsGlobal = (idUser == 0);
                    return locSettings;
                }
            }
        }
    }

    [Serializable]
    [XmlRoot("ActiveDev.ADXmlSettings")]
    [XmlInclude(typeof(System.Drawing.Point))]
    [XmlInclude(typeof(System.Drawing.Size))]
    public class ADXmlSettings
    {
        private ADXmlSettingsValues mySettings;

        public ADXmlSettings()
        {
            mySettings = new ADXmlSettingsValues();
        }

        public ADXmlSettingsValues Settings
        {
            get { return mySettings; }
            set { mySettings = value; }
        }

        public string ToXml(Type xmlType)
        {
            var locXml = new XmlSerializer(xmlType);
            var locSw = new StringWriter();
            locXml.Serialize(locSw, this);
            return locSw.ToString();
        }
    }

    public class ADXmlSettingsValue
    {
        private string myUniqueKey;
        private object myValue;

        public ADXmlSettingsValue() { }

        public ADXmlSettingsValue(string uniqueKey, object value)
        {
            myUniqueKey = uniqueKey;
            myValue = value;
        }

        public string UniqueKey
        {
            get { return myUniqueKey; }
            set { myUniqueKey = value; }
        }

        public object Value
        {
            get { return myValue; }
            set { myValue = value; }
        }
    }

    [Serializable]
    public class ADXmlSettingsValues : KeyedCollection<string, ADXmlSettingsValue>
    {
        public object GetItem(string key)
        {
            if (Contains(key))
                return this[key].Value;
            return null;
        }

        public object GetItem(int index)
        {
            return this[index].Value;
        }

        public object GetItem(string key, object defaultValue)
        {
            if (Contains(key))
                return this[key].Value;
            SetItem(key, defaultValue);
            return defaultValue;
        }

        public new void SetItem(string key, object value)
        {
            if (Contains(key))
            {
                this[key].Value = value;
                return;
            }
            Add(new ADXmlSettingsValue(key, value));
        }

        protected override string GetKeyForItem(ADXmlSettingsValue item)
        {
            return item.UniqueKey;
        }
    }

    [Serializable]
    public class FacessoShellWindowsControl
    {
        private bool myOnlyShowActiveEmployees;
        private bool myOnlyShowActiveWorkGroups;
        private bool myShowEmployees;
        private bool myShowWorkGroupInfo;
        private int myEmpWorkgroupSplitterDistance;
        private int myWorkgroupSplitterDistance;

        public event EventHandler WindowsControlSettingsChange;

        public FacessoShellWindowsControl() { }

        public FacessoShellWindowsControl(bool onlyShowActiveEmployees, bool onlyShowActiveWorkGroups,
            bool showEmployees, bool showWorkGroups, bool showWorkGroupInfo)
        {
            myOnlyShowActiveEmployees = onlyShowActiveEmployees;
            myOnlyShowActiveWorkGroups = onlyShowActiveWorkGroups;
            myShowEmployees = showEmployees;
            myShowWorkGroupInfo = showWorkGroupInfo;
        }

        protected void OnSettingsChange()
        {
            WindowsControlSettingsChange?.Invoke(this, EventArgs.Empty);
        }

        public bool OnlyShowActiveEmployees
        {
            get { return myOnlyShowActiveEmployees; }
            set
            {
                if (value != myOnlyShowActiveEmployees)
                {
                    myOnlyShowActiveEmployees = value;
                    OnSettingsChange();
                }
            }
        }

        public bool OnlyShowActiveWorkGroups
        {
            get { return myOnlyShowActiveWorkGroups; }
            set
            {
                if (value != myOnlyShowActiveWorkGroups)
                {
                    myOnlyShowActiveWorkGroups = value;
                    OnSettingsChange();
                }
            }
        }

        public bool ShowEmployees
        {
            get { return myShowEmployees; }
            set
            {
                if (value != myShowEmployees)
                {
                    myShowEmployees = value;
                    OnSettingsChange();
                }
            }
        }

        public bool ShowWorkGroupInfo
        {
            get { return myShowWorkGroupInfo; }
            set
            {
                if (value != myShowWorkGroupInfo)
                {
                    myShowWorkGroupInfo = value;
                    OnSettingsChange();
                }
            }
        }

        public int EmpWorkgroupSplitterDistance
        {
            get { return myEmpWorkgroupSplitterDistance; }
            set { myEmpWorkgroupSplitterDistance = value; }
        }

        public int WorkgroupSplitterDistance
        {
            get { return myWorkgroupSplitterDistance; }
            set { myWorkgroupSplitterDistance = value; }
        }

        public string EmployeeStateDisplayString()
        {
            return OnlyShowActiveEmployees
                ? "Aktive bzw. beteiligte Mitarbeiter"
                : "Alle bzw. beteiligte Mitarbeiter";
        }

        public string WorkGroupStateDisplayString()
        {
            return OnlyShowActiveEmployees
                ? "Aktive Produktiv-Sites"
                : "Alle Produktiv-Sites";
        }
    }
}
