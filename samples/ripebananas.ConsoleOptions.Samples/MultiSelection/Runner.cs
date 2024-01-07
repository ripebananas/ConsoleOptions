namespace ripebananas.ConsoleOptions.Samples.MultiSelection;

public static class Runner
{
    public static void Run()
    {
        ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

        var selected = ConsoleOptionsBuilder
            .MultiSelector(OptionDescriptions.GetFromEnum<Options>().ToArray())
            .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit:")
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.BitwiseOr()}");
    }
}