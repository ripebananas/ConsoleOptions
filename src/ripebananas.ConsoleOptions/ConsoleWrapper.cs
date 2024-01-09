using System;
using System.Text;

namespace ripebananas.ConsoleOptions
{
    public static class Wrapper
    {
        public static IConsole Console { get; internal set; } = new SystemConsole();

        private class SystemConsole : IConsole
        {
            public bool CursorVisible
            {
                get => System.Console.CursorVisible;
                set => System.Console.CursorVisible = value;
            }

            public int CursorLeft
            {
                get => System.Console.CursorLeft;
                set => System.Console.CursorLeft = value;
            }

            public int CursorTop
            {
                get => System.Console.CursorTop;
                set => System.Console.CursorTop = value;
            }

            public ConsoleColor BackgroundColor
            {
                get => System.Console.BackgroundColor;
                set => System.Console.BackgroundColor = value;
            }

            public ConsoleColor ForegroundColor
            {
                get => System.Console.ForegroundColor;
                set => System.Console.ForegroundColor = value;
            }

            public Encoding OutputEncoding
            {
                get => System.Console.OutputEncoding;
                set => System.Console.OutputEncoding = value;
            }

            public void Clear() => System.Console.Clear();

            public ConsoleKeyInfo ReadKey() => System.Console.ReadKey();

            public ConsoleKeyInfo ReadKey(bool intercept) => System.Console.ReadKey(intercept);

            public void SetCursorPosition(int cursorLeft, int cursorTop) =>
                System.Console.SetCursorPosition(cursorLeft, cursorTop);

            public void Write(string? value) => System.Console.Write(value);

            public void Write<T>(T value) => System.Console.Write(value);

            public void WriteLine() => System.Console.WriteLine();

            public void WriteLine(string? value) => System.Console.WriteLine(value);

            public void WriteLine<T>(T value) => System.Console.WriteLine(value);
        }
    }
}