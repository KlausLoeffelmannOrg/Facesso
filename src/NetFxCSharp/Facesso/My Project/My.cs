namespace Facesso.My
{
    /// <summary>
    ///  Minimal C# stand-in for Visual Basic's <c>My.MyProject</c>. Holds the single
    ///  <see cref="MyApplication"/> instance and re-exposes it as <c>Application</c>, so the generated
    ///  designers and forms can reach the running application's <c>Info</c>, settings auto-save plumbing
    ///  and <c>Shutdown</c> event exactly as they did under the VB Application Framework.
    /// </summary>
    internal static class MyProject
    {
        private static readonly MyApplication s_application = new MyApplication();

        internal static MyApplication Application => s_application;
    }

    /// <summary>
    ///  Minimal C# stand-in for Visual Basic's <c>My.Settings</c>, forwarding to the generated
    ///  <see cref="Settings"/> singleton.
    /// </summary>
    internal static class MySettings
    {
        internal static void Save() => Settings.Default.Save();
    }
}
