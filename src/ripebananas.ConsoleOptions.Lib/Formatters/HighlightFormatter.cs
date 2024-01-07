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
                    ConsoleWrapper.Instance.ForegroundColor = Options.SelectedForegroundColor;
                    ConsoleWrapper.Instance.BackgroundColor = Options.SelectedBackgroundColor;
                }
                base.PrintDescription(options);
            }
        }
    }
}
