namespace ripebananas.ConsoleOptions.Samples.SingleSelection;

public static class Runner
{
    public static void Run()
    {
        ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

        var selected = ConsoleOptionsBuilder
            .SingleSelector(OptionDescriptions.GetFromEnum<Options>().ToArray())
            .Prompt("Select an option with up/down arrows, Enter/Space to submit:")
            .WaitForSelection();

        ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");
    }
}