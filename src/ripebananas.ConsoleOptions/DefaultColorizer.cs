using System;

namespace ripebananas.ConsoleOptions
{
    public sealed class DefaultColorizer : IDisposable
    {
        private readonly ConsoleColor _foregroundColor;
        private readonly ConsoleColor _backgroundColor;

        public DefaultColorizer()
        {
            _foregroundColor = Wrapper.Console.ForegroundColor;
            _backgroundColor = Wrapper.Console.BackgroundColor;
        }

        public void Dispose()
        {
            Wrapper.Console.ForegroundColor = _foregroundColor;
            Wrapper.Console.BackgroundColor = _backgroundColor;
        }
    }
}