using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class HorizontalFormatter : Formatter<Options, FormatterOptions>
{
    public override void Print(FormatterPrintOptions.Single<Options> options)
    {
        PrintCurrentIndicator(options);
        PrintSelectedIndicator(options);
        PrintDescription(options);
        ConsoleWrapper.Instance.Write(" ");
    }
}
