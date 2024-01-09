using ripebananas.ConsoleOptions;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var options = new OptionDescription<string>[]
{
    new("cust", "Customization"),
    new("prebuilt", "PreBuilt"),
    new("multi", "Multi-selection"),
    new("single", "Single-selection"),
};

var selected = ConsoleOptionsBuilder
    .SingleSelector(options, Direction.Vertical)
    .Prompt("Select which samples to run:")
    .WaitForSelection()
    .Single();

Console.Clear();

switch (selected)
{
    case "cust":
        ripebananas.ConsoleOptions.Samples.Customization.Runner.Run();
        break;
    case "prebuilt":
        ripebananas.ConsoleOptions.Samples.PreBuilt.Runner.Run();
        break;
    case "multi":
        ripebananas.ConsoleOptions.Samples.MultiSelection.Runner.Run();
        break;
    case "single":
        ripebananas.ConsoleOptions.Samples.SingleSelection.Runner.Run();
        break;
    default:
        throw new InvalidOperationException($"Unknown option: {selected}");
}