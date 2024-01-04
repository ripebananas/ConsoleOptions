namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatter<T> : Formatter<T, HighlightFormatterOptions>
    {
        public override void Print(PrintValueOptions<T> options)
        {
            PrintCurrentIndicator(options);
            PrintDescription(options);

            if (Options.Direction == Direction.Vertical)
            {
                ConsoleWrapper.Instance.WriteLine();
            }
            else
            {
                ConsoleWrapper.Instance.Write(" ");
            }
        }

        protected override void PrintDescription(PrintValueOptions<T> options)
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
