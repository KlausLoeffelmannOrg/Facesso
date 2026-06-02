using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class Settings : System.Configuration.ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings()));
        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [System.Configuration.UserScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Configuration.DefaultSettingValueAttribute("")]
        public string Testsetting
        {
            get
            {
                return ((string)this["Testsetting"]);
            }

            set
            {
                this["Testsetting"] = value;
            }
        }

        [System.Configuration.ApplicationScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [System.Configuration.DefaultSettingValueAttribute("Data Source=.;Initial Catalog=Facesso;Integrated Security=True")]
        public string FacessoConnectionString
        {
            get
            {
                return ((string)this["FacessoConnectionString"]);
            }
        }
    }
}

namespace Facesso.Functions.My
{
    [Microsoft.VisualBasic.HideModuleNameAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal static class MySettingsProperty
    {
        [System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]
        internal static Facesso.Functions.Settings Settings
        {
            get
            {
                return global::Facesso.Functions.Settings.Default;
            }
        }
    }
}