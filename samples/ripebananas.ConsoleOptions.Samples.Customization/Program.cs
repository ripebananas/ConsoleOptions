using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Samples.Customization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Colorization();

Console.WriteLine("Press any key to continue");
Console.ReadKey();
Console.Clear();

HorizontalSelection();

static void Colorization()
{
    var selected = ConsoleOptionsBuilder.MultiSelection<Options>()
        .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit, Escape to exit:")
        .Formatter<SampleColorFormatter, SampleColorFormatterOptions>()
        .FormatterOptions(x =>
        {
            x.CurrentIndicator = "→";
            x.SelectedIndicator = "(X)";
            x.NotSelectedIndicator = "( )";
            x.CurrentIndicatorForegroundColor = ConsoleColor.Red;
            x.SelectedIndicatorForegroundColor = ConsoleColor.Green;
            x.SelectedTextForegroundColor = ConsoleColor.Black;
            x.SelectedTextBackgroundColor = ConsoleColor.Gray;
        })
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}


static void HorizontalSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, SampleHorizontalMultiSelector>()
        .Prompt("Select an option with left/right arrows, Spacebar to mark an option, Enter to submit, Escape to exit:")
        .Formatter<SampleHorizontalSelectorFormatter, FormatterOptions>()
        .FormatterOptions(x =>
        {
            x.CurrentIndicator = "→";
            x.SelectedIndicator = "[X]";
        })
        .WaitForSelection();

    Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");
}