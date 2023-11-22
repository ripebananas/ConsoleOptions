using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public interface IConsoleOptionsBuilder<T, TFO>
        where T : struct, Enum
        where TFO : FormatterOptions
    {
        IConsoleOptionsBuilder<T, TFO> Prompt(string prompt);

        IConsoleOptionsBuilder<T, TFO> DefaultIndex(int index);

        IConsoleOptionsBuilder<T, TFONew> Formatter<TFONew>(IFormatter<T, TFONew> formatter)
            where TFONew : FormatterOptions;

        IConsoleOptionsBuilder<T, TFONew> Formatter<TF, TFONew>()
            where TFONew : FormatterOptions
            where TF : IFormatter<T, TFONew>, new();

        IConsoleOptionsBuilder<T, TFO> FormatterOptions(Action<TFO> configure);

        T? WaitForSelection();
    }
}
