using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.EntityModel.My
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
    }
}

namespace Facesso.EntityModel.My
{
    [Microsoft.VisualBasic.HideModuleNameAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal static class MySettingsProperty
    {
        [System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]
        internal static Facesso.EntityModel.My.MySettings Settings
        {
            get
            {
                return global::Facesso.EntityModel.My.MySettings.Default;
            }
        }
    }
}