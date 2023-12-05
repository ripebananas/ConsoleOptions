using ripebananas.ConsoleOptions;

namespace System
{
    public static class StringExtensions
    {
        public static string Foreground(this string value, ConsoleColor color) =>
            $"{Colors.Foreground(color)}{value}{Colors.DefaultForegroundColor}";

        public static string Background(this string value, ConsoleColor color) =>
            $"{Colors.Background(color)}{value}{Colors.DefaultBackgroundColor}";

        public static string BlackFG(this string value) =>
            value.Foreground(ConsoleColor.Black);

        public static string DarkRedFG(this string value) =>
            value.Foreground(ConsoleColor.DarkRed);

        public static string DarkGreenFG(this string value) =>
            value.Foreground(ConsoleColor.DarkGreen);

        public static string DarkYellowFG(this string value) =>
            value.Foreground(ConsoleColor.DarkYellow);

        public static string DarkBlueFG(this string value) =>
            value.Foreground(ConsoleColor.DarkBlue);

        public static string DarkMagentaFG(this string value) =>
            value.Foreground(ConsoleColor.DarkMagenta);

        public static string DarkCyanFG(this string value) =>
            value.Foreground(ConsoleColor.DarkCyan);

        // Note: "\x1B[37m" seems to be lighter than ConsoleColor.Gray
        public static string GrayFG(this string value) =>
            value.Foreground(ConsoleColor.Gray);

        public static string RedFG(this string value) =>
            value.Foreground(ConsoleColor.Red);

        public static string GreenFG(this string value) =>
            value.Foreground(ConsoleColor.Green);

        public static string YellowFG(this string value) =>
            value.Foreground(ConsoleColor.Yellow);

        public static string BlueFG(this string value) =>
            value.Foreground(ConsoleColor.Blue);

        public static string MagentaFG(this string value) =>
            value.Foreground(ConsoleColor.Magenta);

        public static string CyanFG(this string value) =>
            value.Foreground(ConsoleColor.Cyan);

        public static string WhiteFG(this string value) =>
            value.Foreground(ConsoleColor.White);

        public static string BlackBG(this string value) =>
            value.Background(ConsoleColor.Black);

        public static string DarkRedBG(this string value) =>
            value.Background(ConsoleColor.DarkRed);

        public static string DarkGreenBG(this string value) =>
            value.Background(ConsoleColor.DarkGreen);

        public static string DarkYellowBG(this string value) =>
            value.Background(ConsoleColor.DarkYellow);

        public static string DarkBlueBG(this string value) =>
            value.Background(ConsoleColor.DarkBlue);

        public static string DarkMagentaBG(this string value) =>
            value.Background(ConsoleColor.DarkMagenta);

        public static string DarkCyanBG(this string value) =>
            value.Background(ConsoleColor.DarkCyan);

        public static string GrayBG(this string value) =>
            value.Background(ConsoleColor.Gray);
    }
}