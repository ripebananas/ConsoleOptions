using System;
using System.Text;

namespace ripebananas.ConsoleOptions.Internals
{
    internal class SystemConsole : IConsole
    {
        public bool CursorVisible
        {
            get => Console.CursorVisible;
            set => Console.CursorVisible = value;
        }

        public int CursorLeft
        {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        public int CursorTop
        {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        public ConsoleColor BackgroundColor
        {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        public ConsoleColor ForegroundColor
        {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        public Encoding OutputEncoding
        {
            get => Console.OutputEncoding;
            set => Console.OutputEncoding = value;
        }

        public void Clear() => Console.Clear();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

        public void SetCursorPosition(int cursorLeft, int cursorTop) =>
            Console.SetCursorPosition(cursorLeft, cursorTop);

        public void Write(string value) => Console.Write(value);

        public void WriteLine() => Console.WriteLine();

        public void WriteLine(string value) => Console.WriteLine(value);
    }
}
