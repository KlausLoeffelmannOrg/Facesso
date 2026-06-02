namespace FacessoConfig
{
    /// <summary>
    ///  Application entry point. Emulates the Visual Basic Application Framework
    ///  (<c>MySubMain</c>) by running the <see cref="FacessoConfig.My.MyApplication"/> instance, which
    ///  applies the startup form, visual styles, settings persistence and the Startup/Shutdown/
    ///  UnhandledException hooks declared in <c>ApplicationEvents</c>.
    /// </summary>
    internal static class Program
    {
        [System.STAThread]
        private static void Main(string[] args)
        {
            FacessoConfig.My.Application.Instance.Run(args);
        }
    }
}
