using System.Linq;

namespace ripebananas.ConsoleOptions.Formatters
{
    public abstract class Formatter<T, TFO> : IFormatter<T, TFO>
        where TFO : FormatterOptions, new()
    {
        protected readonly TFO _options;
        protected readonly int _cursorLeft, _cursorTop;

        public TFO Options => _options;

        public Formatter()
            : this(new TFO())
        {
        }

        public Formatter(TFO options)
        {
            ConsoleWrapper.Instance.CursorVisible = false;
            _options = options;
            _cursorLeft = ConsoleWrapper.Instance.CursorLeft;
            _cursorTop = ConsoleWrapper.Instance.CursorTop;
        }

        public virtual void Print(FormatterPrintOptions.All<T> options)
        {
            ConsoleWrapper.Instance.SetCursorPosition(_cursorLeft, _cursorTop);

            if (!string.IsNullOrWhiteSpace(Options.Prompt))
            {
                ConsoleWrapper.Instance.WriteLine(Options.Prompt);
            }

            for (var i = 0; i < options.Values.Length; i++)
            {
                Print(new FormatterPrintOptions.Single<T>(options.Values[i])
                {
                    Index = i,
                    IsCurrent = i == options.CurrentIndex,
                    IsSelected = options.SelectedIndices.Contains(i)
                });
            }

            if (Options.Direction == Direction.Horizontal)
            {
                ConsoleWrapper.Instance.WriteLine();
            }
        }

        public virtual void Print(FormatterPrintOptions.Single<T> options)
        {
            PrintCurrentIndicator(options);
            PrintSelectedIndicator(options);
            PrintDescription(options);

            if (Options.Direction == Direction.Vertical)
            {
                ConsoleWrapper.Instance.WriteLine();
            }
            else
            {
                ConsoleWrapper.Instance.Write(" ");
            }
        }

        /// <summary>
        /// Prints a string that denotes the line where the selection cursor is.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintCurrentIndicator(FormatterPrintOptions.Single<T> options) =>
            ConsoleWrapper.Instance.Write(GetCurrentIndicator(options));

        /// <summary>
        /// Returns a string that denotes the line where the selection cursor is.
        /// </summary>
        protected virtual string? GetCurrentIndicator(FormatterPrintOptions.Single<T> options) =>
            options.IsCurrent ? Options.CurrentIndicator : Options.NotCurrentIndicator;

        /// <summary>
        /// Prints a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        protected virtual void PrintSelectedIndicator(FormatterPrintOptions.Single<T> options) =>
            ConsoleWrapper.Instance.Write(GetSelectedIndicator(options));

        /// <summary>
        /// Returns a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        protected virtual string? GetSelectedIndicator(FormatterPrintOptions.Single<T> options) =>
            options.IsSelected ? Options.SelectedIndicator : Options.NotSelectedIndicator;

        /// <summary>
        /// Prints a string that represents the text of the option.
        /// </summary>
        protected virtual void PrintDescription(FormatterPrintOptions.Single<T> options) =>
            ConsoleWrapper.Instance.Write(options.Value.Description);
    }
}