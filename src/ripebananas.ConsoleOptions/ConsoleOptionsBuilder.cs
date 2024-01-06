using System;
using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class ConsoleOptionsBuilder
    {
        public static IConsoleOptionsBuilder<T, FormatterOptions> SingleSelection<T>(OptionDescription<T>[] values) =>
            new ConsoleOptionsBuilder<T, FormatterOptions, SingleSelector<T>>(
                new DefaultSingleSelectorFormatter<T, FormatterOptions>(), values);

        public static IConsoleOptionsBuilder<T, FormatterOptions> MultiSelection<T>(OptionDescription<T>[] values) =>
            new ConsoleOptionsBuilder<T, FormatterOptions, MultiSelector<T>>(
                new DefaultMultiSelectorFormatter<T, FormatterOptions>(), values);

        public static IConsoleOptionsBuilder<T, FormatterOptions> Selection<T, TS>(OptionDescription<T>[] values)
            where TS : ISelector<T>, new() =>
            new ConsoleOptionsBuilder<T, FormatterOptions, TS>(
                new DefaultSingleSelectorFormatter<T, FormatterOptions>(), values);
    }

    internal class ConsoleOptionsBuilder<T, TFO, TS> : IConsoleOptionsBuilder<T, TFO>
        where TFO : FormatterOptions
        where TS : ISelector<T>, new()
    {
        private readonly IFormatter<T, TFO> _formatter;

        internal ConsoleOptions<T> Options { get; set; }

        internal ConsoleOptionsBuilder(IFormatter<T, TFO> formatter, OptionDescription<T>[] values)
            : this(new ConsoleOptions<T>(formatter, values), formatter)
        {
        }

        internal ConsoleOptionsBuilder(ConsoleOptions<T> options, IFormatter<T, TFO> formatter)
        {
            Options = options;
            Options.Formatter = formatter;
            _formatter = formatter;
        }

        public IConsoleOptionsBuilder<T, TFO> Prompt(string prompt)
        {
            Options.PrintOptions.Prompt = prompt;
            return this;
        }

        public IConsoleOptionsBuilder<T, TFO> DefaultIndex(int index)
        {
            if (index < -1 || index > Options.PrintOptions.Values.Length - 1)
            {
                Options.PrintOptions.CurrentIndex = -1;
            }
            else
            {
                Options.PrintOptions.CurrentIndex = index;
            }
            return this;
        }

        public IConsoleOptionsBuilder<T, TFOOther> Formatter<TFOOther>(IFormatter<T, TFOOther> formatter)
            where TFOOther : FormatterOptions =>
            new ConsoleOptionsBuilder<T, TFOOther, TS>(Options, formatter);

        public IConsoleOptionsBuilder<T, TFOOther> Formatter<TF, TFOOther>()
            where TF : IFormatter<T, TFOOther>, new()
            where TFOOther : FormatterOptions =>
            Formatter(new TF());

        public IConsoleOptionsBuilder<T, TFO> FormatterOptions(Action<TFO> configure)
        {
            configure(_formatter.Options);
            return this;
        }

        public IEnumerable<T> WaitForSelection() =>
            new TS().WaitForSelection(Options);
    }
}
