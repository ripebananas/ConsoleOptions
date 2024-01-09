using System;
using System.Text;

namespace ripebananas.ConsoleOptions
{
    public interface IConsole
    {
        int CursorLeft { get; set; }

        int CursorTop { get; set; }

        bool CursorVisible { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        ConsoleColor ForegroundColor { get; set; }

        Encoding OutputEncoding { get; set; }

        void Clear();

        ConsoleKeyInfo ReadKey();

        ConsoleKeyInfo ReadKey(bool intercept);

        void SetCursorPosition(int cursorLeft, int cursorTop);

        void Write(string? value);

        void WriteLine();

        void WriteLine(string? value);
    }
}
