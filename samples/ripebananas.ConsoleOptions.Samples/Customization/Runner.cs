using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

public static class Runner
{
    public static void Run()
    {
        ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

        Colorization();

        ConsoleWrapper.Instance.WriteLine("Press any key to continue");
        ConsoleWrapper.Instance.ReadKey();
        ConsoleWrapper.Instance.Clear();

        HorizontalSelection();
    }

    private static void Colorization()
    {
        var selected = ConsoleOptionsBuilder
            .MultiSelector(OptionDescriptions.GetFromEnum<Options>().ToArray())
            .Formatter<ColorFormatter, ColorFormatterOptions>(x =>
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


    private static void HorizontalSelection()
    {
        var selected = ConsoleOptionsBuilder
            .Selector<Options, HorizontalMultiSelector>(OptionDescriptions.GetFromEnum<Options>().ToArray())
            .Formatter<HorizontalFormatter, FormatterOptions>(x =>
            {
                x.CurrentIndicator = "→";
                x.SelectedIndicator = "[X]";
            })
            .Prompt("Select an option with left/right arrows, Spacebar to mark an option, Enter to submit:")
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
    }
}