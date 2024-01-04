using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Samples.SingleSelection;

ConsoleWrapper.Instance.OutputEncoding = System.Text.Encoding.UTF8;

var selected = ConsoleOptionsBuilder.SingleSelection(OptionDescriptions.GetFromEnum<Options>().ToArray())
    .Prompt("Select an option with up/down arrows, Enter/Space to submit:")
    .WaitForSelection();

ConsoleWrapper.Instance.WriteLine($"You selected {selected.Single()}");