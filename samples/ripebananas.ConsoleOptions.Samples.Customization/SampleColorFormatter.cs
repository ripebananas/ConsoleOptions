using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleColorFormatter : Formatter<Options, SampleColorFormatterOptions>
{
    protected override void PrintCurrentIndicator(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            ConsoleWrapper.Instance.ForegroundColor = Options.CurrentIndicatorForegroundColor;
            base.PrintCurrentIndicator(options);
        }
    }

    protected override void PrintSelectedIndicator(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            ConsoleWrapper.Instance.ForegroundColor = Options.SelectedIndicatorForegroundColor;
            base.PrintSelectedIndicator(options);
        }
    }

    protected override void PrintDescription(PrintValueOptions<Options> options)
    {
        using (new DefaultColorizer())
        {
            if (options.IsSelected)
            {
                ConsoleWrapper.Instance.ForegroundColor = Options.SelectedTextForegroundColor;
                ConsoleWrapper.Instance.BackgroundColor = Options.SelectedTextBackgroundColor;
            }
            base.PrintDescription(options);
        }
    }
}
