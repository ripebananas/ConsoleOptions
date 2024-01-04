using System;

namespace ripebananas.ConsoleOptions
{
    public static class ConsoleWrapper
    {
        public static IConsole Instance { get; }

        static ConsoleWrapper()
        {
            if (Console.LargestWindowWidth > 0)
            {
                Instance = new Internals.SystemConsole();
            }
            else
            {
                Instance = new Internals.MockConsole();
            }
        }
    }
}