# Interactive Console Options
Very simple interactive options selection for .NET console apps.
Supports single option selection, as well as multiple options selection.
The options to select from, can be taken from an user-defined `Enum`s or supplied dynamically.

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

var result = ConsoleOptionsBuilder
    .SingleSelector<Options>(Direction.Vertical)
    .Prompt("Select an option with up/down arrows, Enter/Space to submit:")
    .WaitForSelection()
    .Single();
// result will be Options.Option2, if selected as below
```

In console:
```
Select an option with up/down arrows, Enter/Space to submit:
 This is option 1
→This is option 2
 This is option 3
```

### Multiple selection
If an `Enum` is used, it should be attributed with the `[Flags]` attribute, but this is not strictly necessary.
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

var result = var result = ConsoleOptionsBuilder
    .MultiSelector<OptionsFlags>(Direction.Vertical)
    .ConfigureFormatter(x =>
    {
        x.Prompt = "Select options with up/down arrows, Spacebar to mark an option, Enter to submit:";
        x.SelectedIndicator = "[✓]";
        x.NotSelectedIndicator = "[ ]";
    })
    .WaitForSelection()
    .BitwiseOr();
// result will be OptionsFlags.Option1 | OptionsFlags.Option2, if selected as below
```

In console:
```
Select options with up/down arrows, Space to mark an option, Enter to submit:
 [✓]This is option 1
 [ ]This is option 2
→[✓]This is option 3
```

### Dynamically supplied options
```c#
OptionDescription<int>[] values = [new(1, "One"), new(2, "Two"), new(3, "Three")];

var result = ConsoleOptionsBuilder
    .MultiSelector(values, Direction.Vertical)
    .ConfigureFormatter(x =>
    {
        x.Prompt = "Select an option:";
    })
    .WaitForSelection();
// result will be [1, 3], if selected as below
```

In console:
```
Select an option:
 [*]One
 [ ]Two
→[*]Three
```

## Customization
Customization possibilities are available by creating custom classes that inherit from `Formatter<,>` (or implement `IFormatter<,>`) and `FormatterOptions`.
See the samples folder for details.

## Changes

### Version 1.0.0
 - The library is largely re-written. Lot's of breaking changes from previous version.

### Version 0.0.8
 - Added ANSI coloring codes and related string extension methods to make console colored output easier.
   E.g. to change the foreground color to red, you could just use
   ```c#
   Console.WriteLine("test".RedForeground());
   ```
