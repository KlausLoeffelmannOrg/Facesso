using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FacessoConfig.My
{
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class MySettings : System.Configuration.ApplicationSettingsBase
    {
        private static MySettings defaultInstance = ((MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings()));
        private static bool addedHandler;
        private static object addedHandlerLockObject = new object ();
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static void AutoSaveSettings(System.Object sender, System.EventArgs e)
        {
            if (FacessoConfig.My.Application.SaveMySettingsOnExit)
            {
                FacessoConfig.My.Settings.Save();
            }
        }

        public static MySettings Default
        {
            get
            {
                if (!(addedHandler))
                {
                    lock (addedHandlerLockObject)
                    {
                        if (!(addedHandler))
                        {
                            FacessoConfig.My.Application.Shutdown += AutoSaveSettings;
                            addedHandler = true;
                        }
                    }
                }

                return defaultInstance;
            }
        }
    }
}

namespace FacessoConfig.My
{
    [Microsoft.VisualBasic.HideModuleNameAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal static class MySettingsProperty
    {
        [System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]
        internal static FacessoConfig.My.MySettings Settings
        {
            get
            {
                return global::FacessoConfig.My.MySettings.Default;
            }
        }
    }
}