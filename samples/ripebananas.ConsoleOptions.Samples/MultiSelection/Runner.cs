namespace ripebananas.ConsoleOptions.Samples.MultiSelection;

public static class Runner
{
    public static void Run()
    {
        Wrapper.Console.OutputEncoding = System.Text.Encoding.UTF8;

        var selected = ConsoleOptionsBuilder
            .MultiSelector<Options>(Direction.Vertical)
            .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {(selected.Any() ? selected.BitwiseOr().ToString() : "<none>")}");
    }
}