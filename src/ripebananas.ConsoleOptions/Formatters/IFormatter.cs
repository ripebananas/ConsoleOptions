using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public interface IFormatter<T, out TFO> : IFormatter<T>
        where T : struct, Enum
        where TFO : FormatterOptions
    {
        TFO Options { get; }
    }

    public interface IFormatter<T>
        where T : struct, Enum
    {
        void Print(PrintValueOptions<T> options);
    }
}
