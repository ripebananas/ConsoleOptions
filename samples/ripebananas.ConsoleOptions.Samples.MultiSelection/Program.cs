using ripebananas.ConsoleOptions;
using ripebananas.ConsoleOptions.Samples.MultiSelection;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var selected = ConsoleOptionsBuilder.MultiSelection<Options>()
    .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit:")
    .WaitForSelection();

Console.WriteLine($"You selected {selected}");
