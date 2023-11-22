using System;
using System.Linq;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptions<T>
        where T : struct, Enum
    {
        public T[] Values { get; }

        public IFormatter<T> Formatter { get; set; }

        public string? Prompt { get; set; }

        public int CurrentIndex { get; set; }

        public int CursorLeft { get; }

        public int CursorTop { get; }

        public ConsoleOptions(IFormatter<T> formatter)
        {
            Values = Enum.GetValues(typeof(T)).OfType<T>().ToArray();
            if (Values.Length == 0)
            {
                throw new ArgumentException($"The enum {typeof(T).Name} has no values.");
            }
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;
        }
    }
}
