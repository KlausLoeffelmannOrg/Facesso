namespace FacessoConfig.My
{
    /// <summary>
    ///  Minimal C# stand-in for Visual Basic's <c>My.Application</c>. Holds the single
    ///  <see cref="MyApplication"/> instance and re-exposes the members the generated settings
    ///  auto-save plumbing consumes, so it can subscribe to the running application's shutdown.
    /// </summary>
    internal static class Application
    {
        private static readonly MyApplication s_instance = new MyApplication();

        internal static MyApplication Instance => s_instance;

        internal static bool SaveMySettingsOnExit => s_instance.SaveMySettingsOnExit;

        internal static event global::Microsoft.VisualBasic.ApplicationServices.ShutdownEventHandler Shutdown
        {
            add => s_instance.Shutdown += value;
            remove => s_instance.Shutdown -= value;
        }
    }

    /// <summary>
    ///  Minimal C# stand-in for Visual Basic's <c>My.Settings</c>, forwarding to the generated
    ///  <see cref="MySettings"/> singleton.
    /// </summary>
    internal static class Settings
    {
        internal static void Save() => MySettings.Default.Save();
    }
}
