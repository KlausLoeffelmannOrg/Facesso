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

namespace Facesso.My
{
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class Settings : System.Configuration.ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings()));
        private static bool addedHandler;
        private static object addedHandlerLockObject = new object ();
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static void AutoSaveSettings(System.Object sender, System.EventArgs e)
        {
            if (Facesso.My.MyProject.Application.SaveMySettingsOnExit)
            {
                Settings.Default.Save();
            }
        }

        public static Settings Default
        {
            get
            {
                if (!(addedHandler))
                {
                    lock (addedHandlerLockObject)
                    {
                        if (!(addedHandler))
                        {
                            Facesso.My.MyProject.Application.Shutdown += AutoSaveSettings;
                            addedHandler = true;
                        }
                    }
                }

                return defaultInstance;
            }
        }
    }
}

namespace Facesso.My
{
    [Microsoft.VisualBasic.HideModuleNameAttribute()]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal static class MySettingsProperty
    {
        [System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]
        internal static Facesso.My.Settings Settings
        {
            get
            {
                return global::Facesso.My.Settings.Default;
            }
        }
    }
}