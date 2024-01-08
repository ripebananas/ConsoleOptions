using System;
using System.Collections.Generic;
using System.Linq;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Selectors
{
    public abstract class Selector<T> : ISelector<T>
    {
        protected readonly SelectorOptions<T> _options;

        public SelectorOptions<T> Options => _options;

        protected Selector()
        {
            _options = new SelectorOptions<T>();
        }

        public abstract bool IsSelected(int index);

        public virtual IEnumerable<T> WaitForSelection(IFormatter<T> formatter)
        {
            formatter.Print(CreatePrintAllOptions());

            while (true)
            {
                var key = Wrapper.Console.ReadKey(true);

                switch (key.Key)
                {
                    default:
                        if (OnKey(key.Key, formatter, out var keyResult))
                        {
                            return keyResult;
                        }
                        break;
                }
            }
        }

        protected internal virtual bool OnKey(
            ConsoleKey key,
            IFormatter<T> formatter,
            out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();

            return key switch
            {
                ConsoleKey.UpArrow => Options.Direction == Direction.Vertical ? OnPrevious(formatter) : false,
                ConsoleKey.LeftArrow => Options.Direction == Direction.Horizontal ? OnPrevious(formatter) : false,
                ConsoleKey.DownArrow => Options.Direction == Direction.Vertical ? OnNext(formatter) : false,
                ConsoleKey.RightArrow => Options.Direction == Direction.Horizontal ? OnNext(formatter) : false,
                _ => false,
            };
        }

        protected virtual bool OnPrevious(IFormatter<T> formatter)
        {
            _options.CurrentIndex--;
            if (_options.CurrentIndex < 0)
            {
                _options.CurrentIndex = _options.Values.Length - 1;
            }
            formatter.Print(CreatePrintAllOptions());

            return false;
        }

        protected virtual bool OnNext(IFormatter<T> formatter)
        {
            _options.CurrentIndex++;
            if (_options.CurrentIndex > _options.Values.Length - 1)
            {
                _options.CurrentIndex = 0;
            }
            formatter.Print(CreatePrintAllOptions());

            return false;
        }

        protected virtual FormatterPrintOptions.All<T> CreatePrintAllOptions() =>
            new FormatterPrintOptions.All<T>
            {
                CurrentIndex = _options.CurrentIndex,
                SelectedIndices = _options.SelectedIndices.ToArray(),
                Values = _options.Values,
            };
    }
}