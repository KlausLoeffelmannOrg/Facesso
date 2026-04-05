using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Facesso
{
    public static class RegistryHelper
    {
        internal const string VERSION_GUID = "{face2470-bae0-20cd-b579-08002b30bfeb}";
        internal const string CLASS_VERSION_GUID = "{face0100-bae0-20cd-b579-08002b30bfeb}";

        /// <summary>
        /// Universal installation serial for testing purposes.
        /// When this value is stored as the SerialNumber in the registry, the hardware
        /// component check is skipped and the license is always considered valid.
        /// </summary>
        internal const string UNIVERSAL_INST_SERIAL_MIT_FOR_TESTING = "{face2407-6913-1068-1111-43002b30bfeb}";

        internal static readonly DateTime EARLIEST_DEFAULT_DATE = new DateTime(2026, 1, 1);

        internal static bool IsRegistered()
        {
            bool locIsRegistered = Convert.ToBoolean(Registry.GetValue(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "RegObject", false));
            if (locIsRegistered)
            {
                if (Convert.ToBoolean(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false)) ||
                    Convert.ToBoolean(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false)))
                {
                    try
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false);
                        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false);
                    }
                    catch { }
                    return false;
                }
            }
            return locIsRegistered;
        }

        internal static void Register(bool doUnDo)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "RegObject", doUnDo);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "Registered", doUnDo);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes", "RegObject", doUnDo);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "Registered", doUnDo);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", false);
        }

        internal static DateTime InstallationDate
        {
            get
            {
                object locObject = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "SUD_Intel_Private", null);
                if (locObject == null)
                    return EARLIEST_DEFAULT_DATE;

                DateTime returnValue;
                try
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString()));
                }
                catch
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString(), CultureInfo.InvariantCulture));
                }
                return returnValue;
            }
            set
            {
                if (value < EARLIEST_DEFAULT_DATE)
                    value = EARLIEST_DEFAULT_DATE;

                if (InstallationDate > EARLIEST_DEFAULT_DATE)
                    return;

                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "SUD_Intel_Private", value.ToOADate().ToString());
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                    "InstallationDate", value.ToString());
            }
        }

        internal static int FirstShiftThresholdInMin
        {
            get { return TryGetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FirstShiftThresholdInMin", 0); }
            set { TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FirstShiftThresholdInMin", value); }
        }

        internal static DateTime FallbackStartTime
        {
            get { return TryGetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FallbackStartTime", new DateTime(2003, 1, 1, 4, 0, 0)); }
            set { TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FallbackStartTime", value); }
        }

        internal static DateTime FallbackEndTime
        {
            get { return TryGetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FallbackEndTime", new DateTime(2003, 1, 1, 14, 0, 0)); }
            set { TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "FallbackEndTime", value); }
        }

        internal static DateTime LastRunDate
        {
            get
            {
                object locObject = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "DRL_Intel_Private", null);
                if (locObject == null)
                    return EARLIEST_DEFAULT_DATE;

                DateTime returnValue;
                try
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString()));
                }
                catch
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString(), CultureInfo.InvariantCulture));
                }
                return returnValue;
            }
            set
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "LastRunDate", value.ToString());
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "LastRunDate", value.ToString());

                if (value < EARLIEST_DEFAULT_DATE)
                    value = EARLIEST_DEFAULT_DATE;

                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "DRL_Intel_Private", value.ToOADate().ToString());
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "DRL_Intel_Private", value.ToOADate().ToString());
            }
        }

        internal static DateTime LastRegisteredDate
        {
            get
            {
                object locObject = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "DgeRL_Intel_Private", null);
                if (locObject == null)
                    return EARLIEST_DEFAULT_DATE;

                DateTime returnValue;
                try
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString()));
                }
                catch
                {
                    returnValue = DateTime.FromOADate(double.Parse(locObject.ToString(), CultureInfo.InvariantCulture));
                }
                return returnValue;
            }
            set
            {
                if (value < EARLIEST_DEFAULT_DATE)
                    value = EARLIEST_DEFAULT_DATE;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                    "DgeRL_Intel_Private", value.ToOADate().ToString());
            }
        }

        internal static string ProgramGUID
        {
            get
            {
                object locObject = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", VERSION_GUID, null);
                if (locObject == null)
                    return null;
                return locObject.ToString();
            }
            set
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", VERSION_GUID, value);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes", VERSION_GUID, value);
            }
        }

        internal static string ConnectionString
        {
            get
            {
                object locObject = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "ConnectionString", null);
                return locObject.ToString();
            }
            set
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "ConnectionString", value);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes", "ConnectionString", value);
            }
        }

        internal static string SerialNumber
        {
            get
            {
                string locSerial = (string)Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "SerialNumber", null);
                if (locSerial == null)
                    locSerial = "000000000000000000000000000000";
                return locSerial;
            }
            set
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", "SerialNumber", value);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes", "SerialNumber", value);
            }
        }

        internal static string SubsidiarySubstitutionName
        {
            get
            {
                string locRetString = (string)Registry.GetValue(
                    @"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "SubsidiarySubstitutionName", null);
                if (string.IsNullOrWhiteSpace(locRetString))
                {
                    locRetString = (string)Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "SubsidiarySubstitutionName", null);
                    if (!string.IsNullOrWhiteSpace(locRetString))
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                            "SubsidiarySubstitutionName", locRetString);
                        return locRetString;
                    }
                }

                if (locRetString == null)
                {
                    try
                    {
                        locRetString = "Filiale";
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                            "SubsidiarySubstitutionName", locRetString);
                        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "SubsidiarySubstitutionName", locRetString);
                    }
                    catch { }
                }
                return locRetString;
            }
        }

        internal static string SharedFolder
        {
            get
            {
                return TryGetReplicatedLocalMachineValue(
                    @"SOFTWARE\ActiveDev\Facesso\Classes", "SharedFolder",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Shared");
            }
            set { TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "SharedFolder", value); }
        }

        internal static string UpdateFolder
        {
            get
            {
                const string notDefined = "- not defined -";
                string tempReturn = TryGetReplicatedLocalMachineValue(
                    @"SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder", notDefined);
                return tempReturn == notDefined ? null : tempReturn;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder", "- not defined -");
                else
                    TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder", value);
            }
        }

        internal static string UpdateUrl
        {
            get { return TryGetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "UpdateUrl", @"http://facesso.de\update"); }
            set
            {
                if (value == null)
                    value = @"http://facesso.de\update";
                TrySetReplicatedLocalMachineValue(@"SOFTWARE\ActiveDev\Facesso\Classes", "UpdateUrl", value);
            }
        }

        internal static string InstallationFolder
        {
            get
            {
                string locRetString = (string)Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "InstallationFolder", null);
                if (locRetString == null)
                {
                    string dirPath = System.IO.Path.GetDirectoryName(
                        System.Reflection.Assembly.GetExecutingAssembly().Location);
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                        "InstallationFolder", dirPath);
                    try
                    {
                        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "InstallationFolder", dirPath);
                    }
                    catch { }
                    locRetString = dirPath;
                }
                return locRetString;
            }
            set
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                    "InstallationFolder", value.ToString());
            }
        }

        public static void SetConnectionString(string connString)
        {
            ConnectionString = connString;
        }

        internal static T TryGetReplicatedLocalMachineValue<T>(string keyName, string valueName, T defaultValue)
        {
            object returnValue = Registry.GetValue(@"HKEY_CURRENT_USER\" + keyName, valueName, null);
            if (returnValue == null)
            {
                returnValue = Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + keyName, valueName, null);
                if (returnValue == null)
                {
                    returnValue = defaultValue;
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + keyName, valueName, defaultValue);
                }
            }
            return (T)returnValue;
        }

        internal static string TrySetReplicatedLocalMachineValue<T>(string keyName, string valueName, T defaultValue)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\" + keyName, valueName, defaultValue);
            try
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\" + keyName, valueName, defaultValue);
                return "OK";
            }
            catch (Exception)
            {
                return $"'{keyName}' could not be written - access denied. Login as Administrator and try again.";
            }
        }
    }
}
