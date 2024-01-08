namespace ripebananas.ConsoleOptions.Samples.SingleSelection;

public static class Runner
{
    public static void Run()
    {
        Wrapper.Console.OutputEncoding = System.Text.Encoding.UTF8;

        var selected = ConsoleOptionsBuilder
            .SingleSelector(OptionDescriptions.GetFromEnum<Options>().ToArray(), Direction.Vertical)
            .Prompt("Select an option with up/down arrows, Enter/Space to submit:")
            .WaitForSelection();

        Wrapper.Console.WriteLine($"You selected {selected.Single()}");
    }
}