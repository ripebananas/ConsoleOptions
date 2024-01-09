using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

public static class Runner
{
    public static void Run()
    {
        Wrapper.Console.OutputEncoding = System.Text.Encoding.UTF8;

        Customization1();

        Wrapper.Console.WriteLine("Press any key to continue");
        Wrapper.Console.ReadKey();
        Wrapper.Console.Clear();

        Customization2();
    }

    private static void Customization1()
    {
        var selected = ConsoleOptionsBuilder
            .MultiSelector<Options>(Direction.Vertical)
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

        Wrapper.Console.WriteLine($"You selected {(selected.Any() ? selected.BitwiseOr().ToString() : "<none>")}");
    }


    private static void Customization2()
    {
        var selected = ConsoleOptionsBuilder
            .MultiSelector<Options>(Direction.Horizontal)
            .ConfigureFormatter(x =>
            {
                x.CurrentIndicator = "→".BlackForeground().DarkGreenBackground();
                x.SelectedIndicator = "[X]";
            })
            .Prompt("Select an option with left/right arrows, Spacebar to mark an option, Enter to submit:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {(selected.Any() ? selected.BitwiseOr().ToString() : "<none>")}");
    }
}