using System;
using System.Text;

namespace ripebananas.ConsoleOptions.Internals
{
    internal class MockConsole : IConsole
    {
        public bool CursorVisible { get => false; set { } }

        public int CursorLeft { get => default; set { } }

        public int CursorTop { get => default; set { } }

        public ConsoleColor BackgroundColor { get => default; set { } }

        public ConsoleColor ForegroundColor { get => default; set { } }

        public Encoding OutputEncoding { get => default; set { } }

        public void Clear() { }

        public ConsoleKeyInfo ReadKey() => default;

        public ConsoleKeyInfo ReadKey(bool intercept) => default;

        public void SetCursorPosition(int cursorLeft, int cursorTop) { }

        public void Write(string value) { }

        public void WriteLine() { }

        public void WriteLine(string value) { }
    }
}
