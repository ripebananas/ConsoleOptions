using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Samples.SingleSelection;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var selected = ConsoleOptionsBuilder.SingleSelection<Options>()
    .Prompt("Select an option with up/down arrows, Enter/Space to submit, Escape to exit:")
    .WaitForSelection();

Console.WriteLine($"You selected {selected?.ToString() ?? "<none>"}");