using System;
using ripebananas.ConsoleOptions.Formatters;

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
}
