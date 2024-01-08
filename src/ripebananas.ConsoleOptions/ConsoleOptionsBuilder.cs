using System;
using System.Collections.Generic;
using System.Linq;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptionsBuilder
    {
        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T>(Direction direction)
            where T : struct, Enum =>
            SingleSelector<T>(OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T, TS>(Direction direction)
            where T : struct, Enum
            where TS : ISelector<T>, new() =>
            SingleSelector(OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T, TS>(TS selector, Direction direction)
            where T : struct, Enum
            where TS : ISelector<T> =>
            SingleSelector(selector, OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T>(
            OptionDescription<T>[] values,
            Direction direction) =>
            Selector<T, SingleSelector<T>>(new SingleSelector<T>(), values, direction, false);

        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T, TS>(
            OptionDescription<T>[] values,
            Direction direction)
            where TS : ISelector<T>, new() =>
            Selector<T, TS>(values, direction, false);

        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelector<T, TS>(
            TS selector,
            OptionDescription<T>[] values,
            Direction direction)
            where TS : ISelector<T> =>
            Selector<T, TS>(selector, values, direction, false);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T>(Direction direction)
            where T : struct, Enum =>
            MultiSelector(new MultiSelector<T>(), OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T, TS>(Direction direction)
            where T : struct, Enum
            where TS : ISelector<T>, new() =>
            MultiSelector(new TS(), OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T, TS>(TS selector, Direction direction)
            where T : struct, Enum
            where TS : ISelector<T> =>
            MultiSelector(selector, OptionDescriptions.GetFromEnum<T>().ToArray(), direction);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T>(
            OptionDescription<T>[] values,
            Direction direction) =>
            Selector<T, MultiSelector<T>>(new MultiSelector<T>(), values, direction, true);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T, TS>(
            OptionDescription<T>[] values,
            Direction direction)
            where TS : ISelector<T>, new() =>
            Selector<T, TS>(new TS(), values, direction, true);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelector<T, TS>(
            TS selector,
            OptionDescription<T>[] values,
            Direction direction)
            where TS : ISelector<T> =>
            Selector<T, TS>(selector, values, direction, true);

        private static IConsoleOptionsBuilder<T, FormatterOptions> Selector<T, TS>(
            OptionDescription<T>[] values,
            Direction direction,
            bool multi)
            where TS : ISelector<T>, new() =>
            Selector<T, TS>(new TS(), values, direction, multi);

        private static IConsoleOptionsBuilder<T, FormatterOptions> Selector<T, TS>(
            ISelector<T> selector,
            OptionDescription<T>[] values,
            Direction direction,
            bool multi)
        {
            selector.Options.Values = values;
            selector.Options.Direction = direction;

            var formatter = new Formatter<T, FormatterOptions>();
            formatter.Options.Direction = direction;
            formatter.Options.MultiSelection = multi;

            return new ConsoleOptionsBuilder<T, TS, FormatterOptions>(selector, formatter);
        }
    }

    internal class ConsoleOptionsBuilder<T, TS, TFO> : IConsoleOptionsBuilder<T, TFO>, IConfigurableConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
    {
        private readonly ISelector<T> _selector;
        private readonly IFormatter<T, TFO> _formatter;

        internal ConsoleOptionsBuilder(ISelector<T> selector, IFormatter<T, TFO> formatter)
        {
            _selector = selector;
            _formatter = formatter;
        }

        public IConsoleOptionsBuilder<T, TFO> Formatter<TF>(Action<TFO>? configure = null)
            where TF : IFormatter<T, TFO>, new() =>
            Formatter(new TF(), configure);

        public IConsoleOptionsBuilder<T, TFO> Formatter(IFormatter<T, TFO> formatter, Action<TFO>? configure = null)
        {
            formatter.Options.Direction = _formatter.Options.Direction;
            formatter.Options.MultiSelection = _formatter.Options.MultiSelection;
            configure?.Invoke(formatter.Options);
            return new ConsoleOptionsBuilder<T, TS, TFO>(_selector, formatter);
        }

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TF, TFONew>(Action<TFONew>? configure = null)
            where TF : IFormatter<T, TFONew>, new()
            where TFONew : FormatterOptions =>
            Formatter(new TF(), configure);

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TFONew>(IFormatter<T, TFONew> formatter, Action<TFONew>? configure = null)
            where TFONew : FormatterOptions
        {
            formatter.Options.Direction = _formatter.Options.Direction;
            formatter.Options.MultiSelection = _formatter.Options.MultiSelection;
            configure?.Invoke(formatter.Options);
            return new ConsoleOptionsBuilder<T, TS, TFONew>(_selector, formatter);
        }

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
