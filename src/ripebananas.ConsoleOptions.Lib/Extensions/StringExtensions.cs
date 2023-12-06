using ripebananas.ConsoleOptions;

namespace System
{
    public static class StringExtensions
    {
        public static string Foreground(this string value, ConsoleColor color) =>
            $"{Colors.Foreground(color)}{value}{Colors.DefaultForegroundColor}";

        public static string Background(this string value, ConsoleColor color) =>
            $"{Colors.Background(color)}{value}{Colors.DefaultBackgroundColor}";

        public static string BlackForeground(this string value) =>
            value.Foreground(ConsoleColor.Black);

        public static string DarkRedForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkRed);

        public static string DarkGreenForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkGreen);

        public static string DarkYellowForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkYellow);

        public static string DarkBlueForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkBlue);

        public static string DarkMagentaForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkMagenta);

        public static string DarkCyanForeground(this string value) =>
            value.Foreground(ConsoleColor.DarkCyan);

        // Note: "\x1B[37m" seems to be lighter than ConsoleColor.Gray
        public static string GrayForeground(this string value) =>
            value.Foreground(ConsoleColor.Gray);

        public static string RedForeground(this string value) =>
            value.Foreground(ConsoleColor.Red);

        public static string GreenForeground(this string value) =>
            value.Foreground(ConsoleColor.Green);

        public static string YellowForeground(this string value) =>
            value.Foreground(ConsoleColor.Yellow);

        public static string BlueForeground(this string value) =>
            value.Foreground(ConsoleColor.Blue);

        public static string MagentaForeground(this string value) =>
            value.Foreground(ConsoleColor.Magenta);

        public static string CyanForeground(this string value) =>
            value.Foreground(ConsoleColor.Cyan);

        public static string WhiteForeground(this string value) =>
            value.Foreground(ConsoleColor.White);

        public static string BlackBackground(this string value) =>
            value.Background(ConsoleColor.Black);

        public static string DarkRedBackground(this string value) =>
            value.Background(ConsoleColor.DarkRed);

        public static string DarkGreenBackground(this string value) =>
            value.Background(ConsoleColor.DarkGreen);

        public static string DarkYellowBackground(this string value) =>
            value.Background(ConsoleColor.DarkYellow);

        public static string DarkBlueBackground(this string value) =>
            value.Background(ConsoleColor.DarkBlue);

        public static string DarkMagentaBackground(this string value) =>
            value.Background(ConsoleColor.DarkMagenta);

        public static string DarkCyanBackground(this string value) =>
            value.Background(ConsoleColor.DarkCyan);

        public static string GrayBackground(this string value) =>
            value.Background(ConsoleColor.Gray);
    }
}