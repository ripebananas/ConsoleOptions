using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleHorizontalSelectorFormatter : Formatter<Options, FormatterOptions>
{
    public override void Print(PrintValueOptions<Options> options)
    {
        PrintCurrentIndicator(options);
        PrintSelectedIndicator(options);
        PrintDescription(options);
        Console.Write("   ");
    }
}
