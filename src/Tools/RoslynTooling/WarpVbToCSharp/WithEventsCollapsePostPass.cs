using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using WarpToolkit.Desktop.Roslyn.CSharp.WithEvents;

namespace Warp.VbToCSharp.Cli;

/// <summary>
///  Post-processes the freshly converted C# files with the WARP <see cref="WithEventsCollapser"/> so that
///  the behavior-faithful re-wiring properties emitted by the converter become idiomatic classic C#
///  WinForms wiring. This realizes <see cref="WarpToolkit.Desktop.Roslyn.VisualBasic.Conversion.WithEventsStyle.ClassicEventWiring"/>
///  by reusing the proven C#→C# collapse pass instead of duplicating its analysis in the text converter.
/// </summary>
internal static class WithEventsCollapsePostPass
{
    /// <summary>The outcome of a collapse post-pass over a converted project.</summary>
    internal readonly record struct Result(int Collapsed, int Retained, int FilesRewritten);

    /// <summary>
    ///  Builds a C# compilation from the converted files plus the original project's references, runs the
    ///  collapser, and overwrites the affected <c>.cs</c> files on disk.
    /// </summary>
    public static Result Run(
        IReadOnlyList<FileConversion> conversions,
        IReadOnlyList<MetadataReference> references)
    {
        CSharpParseOptions parseOptions = new(LanguageVersion.Latest);

        List<SyntaxTree> trees = [];
        foreach (FileConversion conversion in conversions)
        {
            trees.Add(CSharpSyntaxTree.ParseText(conversion.CSharp, parseOptions, path: conversion.OutputPath));
        }

        CSharpCompilation compilation = CSharpCompilation.Create(
            "ConvertedOutput",
            trees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        WithEventsCollapseReport report = WithEventsCollapser.Collapse(compilation);

        int filesRewritten = 0;
        foreach ((SyntaxTree tree, SyntaxNode root) in report.RewrittenRoots)
        {
            if (string.IsNullOrEmpty(tree.FilePath))
            {
                continue;
            }

            File.WriteAllText(tree.FilePath, root.ToFullString());
            filesRewritten++;
            Console.Error.WriteLine($"  [collapse] rewrote {tree.FilePath}");
        }

        return new Result(report.Collapsed.Count, report.Retained.Count, filesRewritten);
    }
}
