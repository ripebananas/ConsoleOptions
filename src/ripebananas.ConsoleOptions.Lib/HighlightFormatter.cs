using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public class HighlightFormatter<T> : Formatter<T, HighlightFormatterOptions>
        where T : struct, Enum
    {
        protected override string GetCurrentIndicator(PrintValueOptions<T> options) => string.Empty;

        protected override string GetSelectedIndicator(PrintValueOptions<T> options) => string.Empty;

        public override void Print(PrintValueOptions<T> options)
        {
            PrintDescription(options);

            if (Options.Direction == Direction.Vertical)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write(" ");
            }
        }

        protected override void PrintDescription(PrintValueOptions<T> options)
        {
            using (new DefaultColorizer())
            {
                if (options.IsCurrent)
                {
                    Console.ForegroundColor = Options.SelectedForegroundColor;
                    Console.BackgroundColor = Options.SelectedBackgroundColor;
                }
                base.PrintDescription(options);
            }
        }
    }
}
