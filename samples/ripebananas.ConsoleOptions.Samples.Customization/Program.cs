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
        .Formatter<SampleColorFormatter, SampleColorFormatterOptions>(x =>
        {
            x.CurrentIndicator = "→";
            x.SelectedIndicator = "(X)";
            x.NotSelectedIndicator = "( )";
            x.CurrentIndicatorForegroundColor = ConsoleColor.Red;
            x.SelectedIndicatorForegroundColor = ConsoleColor.Green;
            x.SelectedTextForegroundColor = ConsoleColor.Black;
            x.SelectedTextBackgroundColor = ConsoleColor.Gray;
        })
        .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit:")
        .WaitForSelection();

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
}


static void HorizontalSelection()
{
    var selected = ConsoleOptionsBuilder.Selection<Options, SampleHorizontalMultiSelector>(OptionDescriptions.GetFromEnum<Options>().ToArray())
        .Formatter<SampleHorizontalFormatter, FormatterOptions>(x =>
        {
            x.CurrentIndicator = "→";
            x.SelectedIndicator = "[X]";
        })
        .Prompt("Select an option with left/right arrows, Spacebar to mark an option, Enter to submit:")
        .WaitForSelection();

    ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
}