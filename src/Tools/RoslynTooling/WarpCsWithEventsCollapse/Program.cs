using Microsoft.Build.Locator;

namespace Warp.CsWithEventsCollapse.Cli;

/// <summary>
///  Entry point for the <c>cswithevents</c> command line tool, which collapses VB-faithful
///  <c>WithEvents</c> re-wiring properties in an already-converted C# project or solution into the
///  classic C# WinForms event-wiring pattern, using the WARP <c>WithEventsCollapser</c>.
/// </summary>
internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        // MSBuildLocator must register a real MSBuild instance BEFORE any Microsoft.Build or
        // MSBuildWorkspace type is loaded, so the actual work lives in a separate type.
        if (!MSBuildLocator.IsRegistered)
        {
            VisualStudioInstance instance = MSBuildLocator.QueryVisualStudioInstances()
                .OrderByDescending(i => i.Version)
                .First();
            MSBuildLocator.RegisterInstance(instance);
            Console.Error.WriteLine($"Using MSBuild {instance.Version} at {instance.MSBuildPath}");
        }

        return await RunAsync(args).ConfigureAwait(false);
    }

    private static async Task<int> RunAsync(string[] args)
    {
        CollapseCliOptions? options = CollapseCliOptions.Parse(args);
        if (options is null)
        {
            CollapseCliOptions.PrintUsage();
            return 1;
        }

        try
        {
            CollapseRunner runner = new(options);
            return await runner.RunAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"FATAL: {ex.GetType().Name}: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            return 2;
        }
    }
}
