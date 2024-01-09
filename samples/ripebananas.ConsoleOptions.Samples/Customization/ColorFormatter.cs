using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class ColorFormatter : Formatter<Options, ColorFormatterOptions>
{
    protected override void PrintCurrentIndicator(FormatterPrintOptions.Single<Options> options)
    {
        using (new DefaultColorizer())
        {
            Wrapper.Console.ForegroundColor = Options.CurrentIndicatorForegroundColor;
            base.PrintCurrentIndicator(options);
        }
    }

    protected override void PrintSelectedIndicator(FormatterPrintOptions.Single<Options> options)
    {
        using (new DefaultColorizer())
        {
            Wrapper.Console.ForegroundColor = Options.SelectedIndicatorForegroundColor;
            base.PrintSelectedIndicator(options);
        }
    }

    protected override void PrintDescription(FormatterPrintOptions.Single<Options> options)
    {
        using (new DefaultColorizer())
        {
            if (options.IsSelected)
            {
                Wrapper.Console.ForegroundColor = Options.SelectedTextForegroundColor;
                Wrapper.Console.BackgroundColor = Options.SelectedTextBackgroundColor;
            }
            base.PrintDescription(options);
        }
    }
}
