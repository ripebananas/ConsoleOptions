using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Samples.PreBuilt;

public static class Runner
{
    public static void Run()
    {
        ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

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
        var values = OptionDescriptions.GetFromEnum<Options>().ToArray();

        var selected = ConsoleOptionsBuilder
            .Selector<Options, SingleSelector<Options>>(values)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>(x =>
            {
                x.Direction = Direction.Horizontal;
            })
            .ConfigureSelector(x => x.Direction = Direction.Horizontal)
            .Prompt("Horizontal single-selection:")
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");
    }

    private static void HorizontalHighlightMultiSelection()
    {
        var values = OptionDescriptions.GetFromEnum<Options>().ToArray();

        var selected = ConsoleOptionsBuilder
            .Selector<Options, MultiSelector<Options>>(values)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .ConfigureSelector(x => x.Direction = Direction.Horizontal)
            .ConfigureFormatter(x =>
            {
                x.Direction = Direction.Horizontal;
                x.Prompt = "Horizontal multi-selection:";
                x.MultiSelection = true;
            })
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
    }

    private static void VerticalHighlightSingleSelection()
    {
        var values = OptionDescriptions.GetFromEnum<Options>().ToArray();

        var selected = ConsoleOptionsBuilder
            .Selector<Options, SingleSelector<Options>>(values)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>(x =>
            {
                x.Direction = Direction.Vertical;
            })
            .ConfigureSelector(x => x.Direction = Direction.Vertical)
            .Prompt("Vertical single-selection:")
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");
    }

    private static void VerticalHighlightMultiSelection()
    {
        var values = OptionDescriptions.GetFromEnum<Options>().ToArray();

        var selected = ConsoleOptionsBuilder
            .Selector<Options, MultiSelector<Options>>(values)
            .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
            .ConfigureSelector(x => x.Direction = Direction.Vertical)
            .ConfigureFormatter(x =>
            {
                x.Direction = Direction.Vertical;
                x.Prompt = "Vertical multi-selection:";
                x.MultiSelection = true;
            })
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
    }

    private static void Clear()
    {
        ConsoleWrapper.Instance.WriteLine("Press any key to continue");
        ConsoleWrapper.Instance.ReadKey();
        ConsoleWrapper.Instance.Clear();
    }
}