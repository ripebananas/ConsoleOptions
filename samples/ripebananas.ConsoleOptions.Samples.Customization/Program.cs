using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Samples.Customization;

ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

Colorization();

ConsoleWrapper.Instance.WriteLine("Press any key to continue");
ConsoleWrapper.Instance.ReadKey();
ConsoleWrapper.Instance.Clear();

HorizontalSelection();

static void Colorization()
{
    var selected = ConsoleOptionsBuilder.MultiSelection(OptionDescriptions.GetFromEnum<Options>().ToArray())
        .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit:")
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

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
}


static void HorizontalSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, SampleHorizontalMultiSelector>(OptionDescriptions.GetFromEnum<Options>().ToArray())
        .Prompt("Select an option with left/right arrows, Spacebar to mark an option, Enter to submit:")
        .Formatter<SampleHorizontalSelectorFormatter, FormatterOptions>()
        .FormatterOptions(x =>
        {
            x.CurrentIndicator = "→";
            x.SelectedIndicator = "[X]";
        })
        .WaitForSelection();

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
}