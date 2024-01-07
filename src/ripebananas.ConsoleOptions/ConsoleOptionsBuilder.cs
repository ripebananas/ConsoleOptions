using System;
using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptionsBuilder
    {
        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelection<T>(OptionDescription<T>[] values) =>
            new ConsoleOptionsBuilder<T, SingleSelector<T>, FormatterOptions>(
                values, new DefaultSingleSelectorFormatter<T, FormatterOptions>());

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelection<T>(OptionDescription<T>[] values) =>
            new ConsoleOptionsBuilder<T, MultiSelector<T>, FormatterOptions>(
                values, new DefaultMultiSelectorFormatter<T, FormatterOptions>());

        public static IConsoleOptionsBuilder<T, FormatterOptions> Selection<T, TS>(OptionDescription<T>[] values)
            where TS : ISelector<T>, new() =>
            new ConsoleOptionsBuilder<T, TS, FormatterOptions>(
                values, new DefaultSingleSelectorFormatter<T, FormatterOptions>());
    }

    internal class ConsoleOptionsBuilder<T, TS, TFO> : IConsoleOptionsBuilder<T, TFO>, IConfigurableConsoleOptionsBuilder<T, TFO>
        where TS : ISelector<T>, new()
        where TFO : FormatterOptions
    {
        private readonly ISelector<T> _selector;
        private readonly IFormatter<T, TFO> _formatter;

        internal ConsoleOptionsBuilder(OptionDescription<T>[] values, IFormatter<T, TFO> formatter)
        {
            _selector = new TS();
            _selector.Options.Values = values;
            _formatter = formatter;
        }

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TFONew>(
            IFormatter<T, TFONew> formatter,
            Action<TFONew>? configure = null)
            where TFONew : FormatterOptions
        {
            configure?.Invoke(formatter.Options);
            return new ConsoleOptionsBuilder<T, TS, TFONew>(_selector.Options.Values, formatter);
        }

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TF, TFONew>(Action<TFONew>? configure = null)
            where TF : IFormatter<T, TFONew>, new()
            where TFONew : FormatterOptions =>
            Formatter(new TF(), configure);

        public IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureSelector(Action<SelectorOptions<T>> configure)
        {
            configure?.Invoke(_selector.Options);
            return this;
        }

        public IConfigurableConsoleOptionsBuilder<T, TFO> ConfigureFormatter(Action<TFO> configure)
        {
            configure(_formatter.Options);
            return this;
        }

        public IEnumerable<T> WaitForSelection() =>
            _selector.WaitForSelection(_formatter);
    }
}
