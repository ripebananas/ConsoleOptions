using System;
using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public interface IConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
    {
        IConsoleOptionsBuilder<T, TFO> Prompt(string prompt);

        IConsoleOptionsBuilder<T, TFO> DefaultIndex(int index);

        IConsoleOptionsBuilder<T, TFOOther> Formatter<TFOOther>(IFormatter<T, TFOOther> formatter)
            where TFOOther : FormatterOptions;

        IConsoleOptionsBuilder<T, TFOOther> Formatter<TF, TFOOther>()
            where TFOOther : FormatterOptions
            where TF : IFormatter<T, TFOOther>, new();

        IConsoleOptionsBuilder<T, TFO> FormatterOptions(Action<TFO> configure);

        IEnumerable<T> WaitForSelection();
    }
}
