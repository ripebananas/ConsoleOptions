using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class HighlightFormatterOptions : FormatterOptions
    {
        public ConsoleColor SelectedForegroundColor { get; set; } = Console.BackgroundColor;

        public ConsoleColor SelectedBackgroundColor { get; set; } = Console.ForegroundColor;

        public Direction Direction { get; set; } = Direction.Vertical;
    }
}
