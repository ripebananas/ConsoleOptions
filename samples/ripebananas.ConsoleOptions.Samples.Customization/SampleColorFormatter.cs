using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleColorFormatter : Formatter<Options, SampleColorFormatterOptions>
{
    protected override void PrintCurrentIndicator(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            Console.ForegroundColor = Options.CurrentIndicatorForegroundColor;
            base.PrintCurrentIndicator(options);
        }
    }

    protected override void PrintSelectedIndicator(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            Console.ForegroundColor = Options.SelectedIndicatorForegroundColor;
            base.PrintSelectedIndicator(options);
        }
    }

    protected override void PrintDescription(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            if (options.IsSelected)
            {
                Console.ForegroundColor = Options.SelectedTextForegroundColor;
                Console.BackgroundColor = Options.SelectedTextBackgroundColor;
            }
            base.PrintDescription(options);
        }
    }
}
