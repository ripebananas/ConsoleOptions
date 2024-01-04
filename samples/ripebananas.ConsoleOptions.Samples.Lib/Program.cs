using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Samples.Lib;
using ripebananas.ConsoleOptions.Selectors;

ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

HorizontalHighlightSingleSelection();
Clear();
VerticalHighlightSingleSelection();

static void HorizontalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, HorizontalSingleSelector<Options>>(OptionDescriptions.GetFromEnum<Options>().ToArray())
        .Prompt("Horizontal single selection:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x =>
        {
            x.Direction = Direction.Horizontal;
            x.CurrentIndicator = "> ".BlueForeground();
            x.NotCurrentIndicator = "  ";
        })
        .WaitForSelection();

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");
}

static void VerticalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, VerticalSingleSelector<Options>>(OptionDescriptions.GetFromEnum<Options>().ToArray())
        .Prompt("Vertical single selection:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x =>
        {
            x.Direction = Direction.Vertical;
            x.CurrentIndicator = "> ".BlueForeground();
            x.NotCurrentIndicator = "  ";
        })
        .WaitForSelection();

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");
}

static void Clear()
{
    ConsoleWrapper.Instance.WriteLine("Press any key to continue");
    ConsoleWrapper.Instance.ReadKey();
    ConsoleWrapper.Instance.Clear();
}