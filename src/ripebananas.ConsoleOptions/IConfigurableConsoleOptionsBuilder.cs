using System;
using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public interface IConfigurableConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
    {
        IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureSelector(Action<SelectorOptions<T>> configure);

        IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureFormatter(Action<TFO> configure);

        IEnumerable<T> WaitForSelection();
    }
}
