using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Samples.PreBuilt;

public static class Runner
{
    public static void Run()
    {
        Wrapper.Console.OutputEncoding = System.Text.Encoding.UTF8;

        HorizontalHighlightSingleSelection();
        Clear();
        HorizontalHighlightMultiSelection();
        Clear();
        VerticalHighlightSingleSelection();
        Clear();
        VerticalHighlightMultiSelection();
    }

    private static void HorizontalHighlightSingleSelection()
    {
        var selected = ConsoleOptionsBuilder
            .SingleSelector<Options, SingleSelector<Options>>(Direction.Horizontal)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .Prompt("Horizontal single-selection:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {selected.Single()}");
    }

    private static void HorizontalHighlightMultiSelection()
    {
        var selected = ConsoleOptionsBuilder
            .MultiSelector<Options, MultiSelector<Options>>(Direction.Horizontal)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .ConfigureFormatter(x => x.Prompt = "Horizontal multi-selection:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {(selected.Any() ? selected.BitwiseOr().ToString() : "<none>")}");
    }

    private static void VerticalHighlightSingleSelection()
    {
        var selected = ConsoleOptionsBuilder
            .SingleSelector<Options, SingleSelector<Options>>(Direction.Vertical)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .Prompt("Vertical single-selection:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {selected.Single()}");
    }

    private static void VerticalHighlightMultiSelection()
    {
        var selected = ConsoleOptionsBuilder
            .MultiSelector<Options, MultiSelector<Options>>(Direction.Vertical)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .ConfigureFormatter(x => x.Prompt = "Vertical multi-selection:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {(selected.Any() ? selected.BitwiseOr().ToString() : "<none>")}");
    }

    private static void Clear()
    {
        Wrapper.Console.WriteLine("Press any key to continue");
        Wrapper.Console.ReadKey();
        Wrapper.Console.Clear();
    }
}