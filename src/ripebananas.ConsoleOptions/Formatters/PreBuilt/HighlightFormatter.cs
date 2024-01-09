namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatter<T> : Formatter<T, HighlightFormatterOptions>
    {
        protected override void PrintDescription(FormatterPrintOptions.Single<T> options)
        {
            using (new DefaultColorizer())
            {
                if (options.IsCurrent)
                {
                    Wrapper.Console.ForegroundColor = Options.SelectedForegroundColor;
                    Wrapper.Console.BackgroundColor = Options.SelectedBackgroundColor;
                }
                base.PrintDescription(options);
            }
        }
    }
}
