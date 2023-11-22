using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public class HighlightFormatterOptions : FormatterOptions
    {
        public ConsoleColor SelectedForegroundColor { get; set; } = Console.BackgroundColor;

        public ConsoleColor SelectedBackgroundColor { get; set; } = Console.ForegroundColor;

        public Direction Direction { get; set; } = Direction.Vertical;
    }
}
