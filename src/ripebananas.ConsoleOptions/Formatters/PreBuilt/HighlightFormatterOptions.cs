using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatterOptions : FormatterOptions
    {
        public ConsoleColor SelectedForegroundColor { get; set; } = Wrapper.Console.BackgroundColor;

        public ConsoleColor SelectedBackgroundColor { get; set; } = Wrapper.Console.ForegroundColor;

        public HighlightFormatterOptions()
        {
            CurrentIndicator = string.Empty;
            NotCurrentIndicator = string.Empty;
        }
    }
}
