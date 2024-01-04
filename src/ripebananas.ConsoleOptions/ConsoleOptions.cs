using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptions<T>
    {
        public OptionDescription<T>[] Values { get; }

        public IFormatter<T> Formatter { get; set; }

        public string? Prompt { get; set; }

        public int CurrentIndex { get; set; }

        public int CursorLeft { get; }

        public int CursorTop { get; }

        public ConsoleOptions(IFormatter<T> formatter, OptionDescription<T>[] values)
        {
            if (values?.Length == 0)
            {
                throw new ArgumentException($"The enum {typeof(T).Name} has no values.");
            }
            Values = values;
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            CursorLeft = ConsoleWrapper.Instance.CursorLeft;
            CursorTop = ConsoleWrapper.Instance.CursorTop;
        }
    }
}
