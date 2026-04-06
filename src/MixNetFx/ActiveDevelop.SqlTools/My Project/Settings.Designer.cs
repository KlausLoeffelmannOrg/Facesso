using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ActiveDevelop.SqlTools.My
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal sealed partial class MySettings : ApplicationSettingsBase
    {
        private static readonly MySettings defaultInstance =
            (MySettings)Synchronized(new MySettings());

        public static MySettings Default
        {
            get { return defaultInstance; }
        }
    }

    [CompilerGenerated]
    internal static class MySettingsProperty
    {
        internal static MySettings Settings
        {
            get { return ActiveDevelop.SqlTools.My.MySettings.Default; }
        }
    }
}
