using System.Linq;

namespace ripebananas.ConsoleOptions.Formatters
{
    public abstract class Formatter<T, TFO> : IFormatter<T, TFO>
        where TFO : FormatterOptions, new()
    {
        protected readonly TFO _formatterOptions;
        protected readonly int _cursorLeft, _cursorTop;

        public TFO Options => _formatterOptions;

        public Formatter()
            : this(new TFO())
        {
        }

        public Formatter(TFO formatterOptions)
        {
            ConsoleWrapper.Instance.CursorVisible = false;
            _formatterOptions = formatterOptions;
            _cursorLeft = ConsoleWrapper.Instance.CursorLeft;
            _cursorTop = ConsoleWrapper.Instance.CursorTop;
        }

        public virtual void Print(PrintValuesOptions<T> options)
        {
            ConsoleWrapper.Instance.SetCursorPosition(_cursorLeft, _cursorTop);

            if (!string.IsNullOrWhiteSpace(options.Prompt))
            {
                ConsoleWrapper.Instance.WriteLine(options.Prompt);
            }

            for (var i = 0; i < options.Values.Length; i++)
            {
                var printValueOptions = new PrintValueOptions<T>(options.Values[i])
                {
                    Index = i,
                    IsCurrent = i == options.CurrentIndex,
                    IsSelected = options.SelectedIndices.Contains(i)
                };
                PrintCurrentIndicator(printValueOptions);
                PrintSelectedIndicator(printValueOptions);
                PrintDescription(printValueOptions);
                ConsoleWrapper.Instance.WriteLine();
            }
        }

        public virtual void Print(PrintValueOptions<T> options)
        {
            PrintCurrentIndicator(options);
            PrintSelectedIndicator(options);
            PrintDescription(options);
            ConsoleWrapper.Instance.WriteLine();
        }

        /// <summary>
        /// Prints a string that denotes the line where the selection cursor is.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintCurrentIndicator(PrintValueOptions<T> options) =>
            ConsoleWrapper.Instance.Write(GetCurrentIndicator(options));

        /// <summary>
        /// Returns a string that denotes the line where the selection cursor is.
        /// </summary>
        protected virtual string? GetCurrentIndicator(PrintValueOptions<T> options) =>
            options.IsCurrent ? _formatterOptions.CurrentIndicator : _formatterOptions.NotCurrentIndicator;

        /// <summary>
        /// Prints a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        protected virtual void PrintSelectedIndicator(PrintValueOptions<T> options) =>
            ConsoleWrapper.Instance.Write(GetSelectedIndicator(options));

        /// <summary>
        /// Returns a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        protected virtual string? GetSelectedIndicator(PrintValueOptions<T> options) =>
            options.IsSelected ? _formatterOptions.SelectedIndicator : _formatterOptions.NotSelectedIndicator;

        /// <summary>
        /// Prints a string that represents the text of the option.
        /// </summary>
        protected virtual void PrintDescription(PrintValueOptions<T> options) =>
            ConsoleWrapper.Instance.Write(options.Value.Description);
    }
}