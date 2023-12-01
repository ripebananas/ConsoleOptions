using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Samples.Lib;
using ripebananas.ConsoleOptions.Selectors;

HorizontalHighlightSingleSelection();
Clear();
VerticalHighlightSingleSelection();

static void HorizontalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, HorizontalSingleSelector<Options>>()
        .Prompt("Horizontal single selection:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x =>
        {
            x.Direction = Direction.Horizontal;
            x.CurrentIndicator = "> ".BlueFG();
            x.NotCurrentIndicator = "  ";
        })
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}

static void VerticalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, VerticalSingleSelector<Options>>()
        .Prompt("Vertical single selection:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x =>
        {
            x.Direction = Direction.Vertical;
            x.CurrentIndicator = "> ".BlueFG();
            x.NotCurrentIndicator = "  ";
        })
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}

static void Clear()
{
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}