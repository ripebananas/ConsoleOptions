using System;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptionsBuilder
    {
        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelection<T>()
            where T : struct, Enum =>
            new ConsoleOptionsBuilder<T, FormatterOptions, SingleSelector<T>>(
                new DefaultSingleSelectorFormatter<T, FormatterOptions>());

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelection<T>()
            where T : struct, Enum =>
            new ConsoleOptionsBuilder<T, FormatterOptions, MultiSelector<T>>(
                new DefaultMultiSelectorFormatter<T, FormatterOptions>());

        public static IConsoleOptionsBuilder<T, FormatterOptions> Selection<T, TS>()
            where T : struct, Enum
            where TS : ISelector<T>, new() =>
            new ConsoleOptionsBuilder<T, FormatterOptions, TS>(
                new DefaultSingleSelectorFormatter<T, FormatterOptions>());
    }

    internal class ConsoleOptionsBuilder<T, TFO, TS> : IConsoleOptionsBuilder<T, TFO>
        where T : struct, Enum
        where TFO : FormatterOptions
        where TS : ISelector<T>, new()
    {
        private readonly IFormatter<T, TFO> _formatter;

        internal ConsoleOptions<T> Options { get; set; }

        internal ConsoleOptionsBuilder(IFormatter<T, TFO> formatter)
            : this(null, formatter)
        {
        }

        internal ConsoleOptionsBuilder(ConsoleOptions<T>? options, IFormatter<T, TFO> formatter)
        {
            Options = options ?? new ConsoleOptions<T>(formatter);
            Options.Formatter = formatter;
            _formatter = formatter;
        }

        public IConsoleOptionsBuilder<T, TFO> Prompt(string prompt)
        {
            Options.Prompt = prompt;
            return this;
        }

        public IConsoleOptionsBuilder<T, TFO> DefaultIndex(int index)
        {
            if (index < -1 || index > Options.Values.Length - 1)
            {
                Options.CurrentIndex = -1;
            }
            else
            {
                Options.CurrentIndex = index;
            }
            return this;
        }

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TFONew>(IFormatter<T, TFONew> formatter)
            where TFONew : FormatterOptions
        {
            return new ConsoleOptionsBuilder<T, TFONew, TS>(Options, formatter);
        }

        public IConsoleOptionsBuilder<T, TFONew> Formatter<TF, TFONew>()
            where TF : IFormatter<T, TFONew>, new()
            where TFONew : FormatterOptions =>
            Formatter(new TF());

        public IConsoleOptionsBuilder<T, TFO> FormatterOptions(Action<TFO> configure)
        {
            configure(_formatter.Options);
            return this;
        }

        public T? WaitForSelection()
        {
            return new TS().WaitForSelection(Options);
        }
    }
}
