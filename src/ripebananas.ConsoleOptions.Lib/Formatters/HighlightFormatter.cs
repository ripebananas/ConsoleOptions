using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatter<T> : Formatter<T, HighlightFormatterOptions>
        where T : struct, Enum
    {
        public override void Print(PrintValueOptions<T> options)
        {
            PrintCurrentIndicator(options);
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
