using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleColorFormatterOptions : FormatterOptions
{
    public ConsoleColor CurrentIndicatorForegroundColor { get; set; } = ConsoleColor.Gray;

    public ConsoleColor SelectedIndicatorForegroundColor { get; set; } = ConsoleColor.Gray;

    public ConsoleColor SelectedTextForegroundColor { get; set; } = ConsoleColor.Gray;

    public ConsoleColor SelectedTextBackgroundColor { get; set; } = ConsoleColor.Black;
}
