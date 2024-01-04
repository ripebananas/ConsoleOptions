using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatterOptions : FormatterOptions
    {
        public ConsoleColor SelectedForegroundColor { get; set; } = ConsoleWrapper.Instance.BackgroundColor;

        public ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleWrapper.Instance.ForegroundColor;

        public Direction Direction { get; set; } = Direction.Vertical;

        public HighlightFormatterOptions()
        {
            CurrentIndicator = string.Empty;
            NotCurrentIndicator = string.Empty;
            SelectedIndicator = string.Empty;
            NotSelectedIndicator = string.Empty;
        }
    }
}
