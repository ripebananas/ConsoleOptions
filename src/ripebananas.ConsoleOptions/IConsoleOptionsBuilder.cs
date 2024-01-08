using System;
using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public interface IConsoleOptionsBuilder<T, TFO> : IConfigurableConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
    {
        IConsoleOptionsBuilder<T, TFONew> Formatter<TFONew>(
            IFormatter<T, TFONew> formatter,
            Action<TFONew>? configure = null)
            where TFONew : FormatterOptions;

        IConsoleOptionsBuilder<T, TFONew> Formatter<TF, TFONew>(Action<TFONew>? configure = null)
            where TFONew : FormatterOptions
            where TF : IFormatter<T, TFONew>, new();
    }

    public interface IConfigurableConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
    {
        IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureSelector(Action<SelectorOptions<T>> configure);

        IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureFormatter(Action<TFO> configure);

        IEnumerable<T> WaitForSelection();
    }
}
