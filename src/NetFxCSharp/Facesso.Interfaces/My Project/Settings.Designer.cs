using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces.My
{
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class MySettings : System.Configuration.ApplicationSettingsBase
    {
        private static MySettings defaultInstance = ((MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings()));
        public static MySettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [System.Configuration.ApplicationScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [System.Configuration.DefaultSettingValueAttribute("Data Source=SBS-Server1\\SQL2008EX;Initial Catalog=Legatro;User ID=sa;Password=Leg" + "atro!")]
        public string LegatroConnectionString
        {
            get
            {
                return ((string)this["LegatroConnectionString"]);
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

        [System.Configuration.ApplicationScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [System.Configuration.DefaultSettingValueAttribute("Data Source=pdc;Initial Catalog=MISDB;User ID=KabusUser;Password=KabusUser")]
        public string MISDBConnectionString
        {
            get
            {
                return ((string)this["MISDBConnectionString"]);
            }
        }
    }
}

namespace Facesso.Interfaces.My
{
    [Microsoft.VisualBasic.HideModuleNameAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal static class MySettingsProperty
    {
        [System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]
        internal static Facesso.Interfaces.My.MySettings Settings
        {
            get
            {
                return global::Facesso.Interfaces.My.MySettings.Default;
            }
        }
    }
}