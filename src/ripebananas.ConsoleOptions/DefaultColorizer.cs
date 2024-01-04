using System;

namespace ripebananas.ConsoleOptions
{
    public sealed class DefaultColorizer : IDisposable
    {
        private readonly ConsoleColor _foregroundColor;
        private readonly ConsoleColor _backgroundColor;

        public DefaultColorizer()
        {
            _foregroundColor = ConsoleWrapper.Instance.ForegroundColor;
            _backgroundColor = ConsoleWrapper.Instance.BackgroundColor;
        }

        public void Dispose()
        {
            ConsoleWrapper.Instance.ForegroundColor = _foregroundColor;
            ConsoleWrapper.Instance.BackgroundColor = _backgroundColor;
        }
    }
}