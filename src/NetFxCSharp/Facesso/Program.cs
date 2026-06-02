namespace Facesso
{
    /// <summary>
    ///  Application entry point. Emulates the Visual Basic Application Framework
    ///  (<c>MySubMain</c>) by running the <see cref="Facesso.My.MyApplication"/> instance, which applies
    ///  the startup form, single-instance behaviour, visual styles, settings persistence and the
    ///  Startup/Shutdown/UnhandledException hooks declared in <c>ApplicationEvents</c>.
    /// </summary>
    internal static class Program
    {
        [System.STAThread]
        private static void Main(string[] args)
        {
            Facesso.My.MyProject.Application.Run(args);
        }
    }
}
