using System.Linq;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class Formatter<T, TFO> : IFormatter<T, TFO>
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
            Wrapper.Console.CursorVisible = false;
            _options = options;
            _cursorLeft = Wrapper.Console.CursorLeft;
            _cursorTop = Wrapper.Console.CursorTop;
        }

        public virtual void Print(FormatterPrintOptions.All<T> options)
        {
            Wrapper.Console.SetCursorPosition(_cursorLeft, _cursorTop);

            if (!string.IsNullOrWhiteSpace(Options.Prompt))
            {
                Wrapper.Console.WriteLine(Options.Prompt);
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
                Wrapper.Console.WriteLine();
            }
        }

        public virtual void Print(FormatterPrintOptions.Single<T> options)
        {
            PrintCurrentIndicator(options);
            PrintSelectedIndicator(options);
            PrintDescription(options);

            if (Options.Direction == Direction.Vertical)
            {
                Wrapper.Console.WriteLine();
            }
            else
            {
                Wrapper.Console.Write(" ");
            }
        }

        /// <summary>
        /// Prints a string that denotes the line where the selection cursor is.
        /// </summary>
        /// <param name="options"></param>
        protected virtual void PrintCurrentIndicator(FormatterPrintOptions.Single<T> options) =>
            Wrapper.Console.Write(GetCurrentIndicator(options));

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
            Wrapper.Console.Write(GetSelectedIndicator(options));

        /// <summary>
        /// Returns a string that denotes if an option is selected.
        /// Used mainly with multi-selection.
        /// </summary>
        protected virtual string? GetSelectedIndicator(FormatterPrintOptions.Single<T> options)
        {
            if (!Options.MultiSelection)
            {
                return string.Empty;
            }
            return options.IsSelected ? Options.SelectedIndicator : Options.NotSelectedIndicator;
        }

        /// <summary>
        /// Prints a string that represents the text of the option.
        /// </summary>
        protected virtual void PrintDescription(FormatterPrintOptions.Single<T> options) =>
            Wrapper.Console.Write(options.Value.Description);
    }
}