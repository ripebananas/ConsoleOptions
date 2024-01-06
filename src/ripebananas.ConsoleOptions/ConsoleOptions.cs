using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptions<T>
    {
        public PrintValuesOptions<T> PrintOptions { get; }

        public IFormatter<T> Formatter { get; set; }

        public ConsoleOptions(IFormatter<T> formatter, OptionDescription<T>[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentException($"The enum {typeof(T).Name} has no values.");
            }

            PrintOptions = new PrintValuesOptions<T>
            {
                Values = values
            };

            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }
    }
}
