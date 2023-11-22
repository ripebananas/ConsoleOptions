using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Samples.Lib;

HorizontalHighlightSingleSelection();

Console.WriteLine("Press any key to continue");
Console.ReadKey();
Console.Clear();

VerticalHighlightSingleSelection();

static void HorizontalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, HorizontalSingleSelector<Options>>()
        .Prompt("Select an option:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x => x.Direction = Direction.Horizontal)
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}

static void VerticalHighlightSingleSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, VerticalSingleSelector<Options>>()
        .Prompt("Select an option:")
        .Formatter<HighlightFormatter<Options>, HighlightFormatterOptions>()
        .FormatterOptions(x => x.Direction = Direction.Vertical)
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}