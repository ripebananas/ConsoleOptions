using System;

namespace ripebananas.ConsoleOptions
{
    public sealed class DefaultColorizer : IDisposable
    {
        private readonly ConsoleColor _foregroundColor;
        private readonly ConsoleColor _backgroundColor;

        public DefaultColorizer()
        {
            _foregroundColor = Console.ForegroundColor;
            _backgroundColor = Console.BackgroundColor;
        }

        public void Dispose()
        {
            Console.ForegroundColor = _foregroundColor;
            Console.BackgroundColor = _backgroundColor;
        }
    }
}