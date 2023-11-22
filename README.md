# Interactive Console Options
NOTE: Still in early development. Breaking changes are likely to occur with each new version.

Very simple interactive options for .NET console apps. Instead of using command line arguments, this package allows interactive selection of options.

Supports single option selection, as well as multiple options selection.

The selected results are returned as values from a user-defined `Enum`s.

## Usage
### Single selection
```c#
enum Options
{
    [OptionDescription("This is option 1")]
    Option1,
    [OptionDescription("This is option 2")]
    Option2,
    [OptionDescription("This is option 3")]
    Option3
}

var result = ConsoleOptionsBuilder.SingleSelection<Options>()
    .Prompt("Select an option with up/down arrows, Enter/Space to submit, Escape to exit:")
    .FormatterOptions(x => x.CurrentIndicator = "→" /* this is the default value */)
    .WaitForSelection();
// result will be Options.Option2, if selected as below
```

In console:
```
Select an option with up/down arrows, Enter/Space to submit, Escape to exit:
 This is option 1
→This is option 2
 This is option 3
```

### Multiple selection
The enum used for the different options should be attributed with the `[Flags]`, otherwise unpredictable results will be yielded.
```c#
[Flags]
enum OptionsFlags
{
    [OptionDescription("This is option 1")]
    Option1 = 1 << 0,
    [OptionDescription("This is option 2")]
    Option2 = 1 << 1,
    [OptionDescription("This is option 3")]
    Option3 = 1 << 2
}

var result = ConsoleOptionsBuilder.MultiSelection<OptionsFlags>()
    .Prompt("Select an option with up/down arrows, Spacebar to mark an option, Enter to submit, Escape to exit:")
    .FormatterOptions(x =>
    {
        x.SelectedIndicator = "[✓]"; /* default value is "[*]" */
        x.NotSelectedIndicator = "[ ]"; /* this is the default value */
    })
    .WaitForSelection();
// result will be OptionsFlags.Option1 | OptionsFlags.Option2, if selected as below
```

In console:
```
Select an option with up/down arrows, Space to mark an option, Enter to submit, Escape to exit:
 [✓]This is option 1
 [ ]This is option 2
→[✓]This is option 3
```

## Customization
Customization possibilities are available by creating custom classes that inherit from `Formatter<,>` (or implement `IFormatter<,>`) and `FormatterOptions`.
See the samples folder for details.