using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ActiveDev.My
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal sealed partial class Settings : ApplicationSettingsBase
    {
        private static readonly Settings defaultInstance =
            (Settings)Synchronized(new Settings());

        public static Settings Default
        {
            get { return defaultInstance; }
        }
    }

    [CompilerGenerated]
    internal static class MySettingsProperty
    {
        internal static Settings Settings
        {
            get { return ActiveDev.My.Settings.Default; }
        }
    }
}
