using System.Configuration;

namespace Facesso
{
    public class FacessoApplicationSettings : ApplicationSettingsBase
    {
        public FacessoApplicationSettings() : base("FacessoGlobal") { }

        [UserScopedSetting]
        public LoginHistory LoginHistory
        {
            get { return (LoginHistory)this["LoginHistory"]; }
            set { this["LoginHistory"] = value; }
        }

        [UserScopedSetting]
        public string LastLoginName
        {
            get { return (string)this["LastLoginName"]; }
            set { this["LastLoginName"] = value; }
        }

        [UserScopedSetting]
        public int LastSubsidiaryID
        {
            get { return (int)this["LastSubsidiaryID"]; }
            set { this["LastSubsidiaryID"] = value; }
        }
    }

    [System.Serializable]
    public class FacessoDynamicSettingsList : System.Collections.Hashtable
    {
        public object GetItem(string key, object defaultValue)
        {
            if (ContainsKey(key))
                return this[key];
            Add(key, defaultValue);
            return defaultValue;
        }

        public void SetItem(string key, object value)
        {
            if (ContainsKey(key))
            {
                this[key] = value;
                return;
            }
            Add(key, value);
        }
    }
}
