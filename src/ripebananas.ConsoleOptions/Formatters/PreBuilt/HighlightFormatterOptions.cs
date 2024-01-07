using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatterOptions : FormatterOptions
    {
        public ConsoleColor SelectedForegroundColor { get; set; } = ConsoleWrapper.Instance.BackgroundColor;

        public ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleWrapper.Instance.ForegroundColor;

        public HighlightFormatterOptions()
        {
            CurrentIndicator = string.Empty;
            NotCurrentIndicator = string.Empty;
        }
    }
}
