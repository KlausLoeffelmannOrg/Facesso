using Microsoft.Build.Locator;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Entry point for the <c>vbconvert</c> command line tool, which converts a Visual Basic project's
///  source files to C# using the WARP <c>VisualBasicConverter</c> and an MSBuild-loaded semantic model.
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
        CliOptions? options = CliOptions.Parse(args);
        if (options is null)
        {
            CliOptions.PrintUsage();
            return 1;
        }

        try
        {
            ProjectConverter converter = new(options);
            return await converter.RunAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"FATAL: {ex.GetType().Name}: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            return 2;
        }
    }
}
