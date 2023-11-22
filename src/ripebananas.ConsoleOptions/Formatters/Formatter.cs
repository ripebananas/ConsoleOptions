using System;
using System.Reflection;

namespace ripebananas.ConsoleOptions.Formatters
{
    public abstract class Formatter<T, TFO> : IFormatter<T, TFO>
        where T : struct, Enum
        where TFO : FormatterOptions, new()
    {
        protected readonly TFO _formatterOptions;

        public TFO Options => _formatterOptions;

        public Formatter()
            : this(new TFO())
        {
        }

        public Formatter(TFO formatterOptions)
        {
            _formatterOptions = formatterOptions;
        }

        public virtual void Print(PrintValueOptions<T> options)
        {
            PrintCurrentIndicator(options);
            PrintSelectedIndicator(options);
            PrintDescription(options);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a string that denotes the line where the selection cursor is.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintCurrentIndicator(PrintValueOptions<T> options) =>
            Console.Write(GetCurrentIndicator(options));

        /// <summary>
        /// Returns a string that denotes the line where the selection cursor is.
        /// </summary>
        /// <param name="options"></param>
        protected virtual string? GetCurrentIndicator(PrintValueOptions<T> options) =>
            options.IsCurrent ? _formatterOptions.CurrentIndicator : _formatterOptions.NotCurrentIndicator;

        /// <summary>
        /// Prints a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintSelectedIndicator(PrintValueOptions<T> options) =>
            Console.Write(GetSelectedIndicator(options));

        /// <summary>
        /// Returns a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        /// <param name="options"></param>
        protected virtual string? GetSelectedIndicator(PrintValueOptions<T> options) =>
            options.IsSelected ? _formatterOptions.SelectedIndicator : _formatterOptions.NotSelectedIndicator;

        /// <summary>
        /// Prints a string that represents the text of the option.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintDescription(PrintValueOptions<T> options) =>
            Console.Write(GetDescription(options));

        /// <summary>
        /// Returns a string that represents the text of the option.
        /// </summary>
        /// <param name="options"></param>
        protected virtual string? GetDescription(PrintValueOptions<T> options)
        {
            var name = options.Value.ToString();

            var attr = typeof(T)
                .GetField(name)?
                .GetCustomAttribute<OptionDescriptionAttribute>();

            return attr?.Description ?? name;
        }
    }
}