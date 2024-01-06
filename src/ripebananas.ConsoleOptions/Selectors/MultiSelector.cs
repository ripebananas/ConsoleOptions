using System;
using System.Collections.Generic;
using System.Linq;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class MultiSelector<T> : Selector<T>
    {
        private readonly bool[] _optionsSelected;

        public MultiSelector()
        {
            _optionsSelected = new bool[Enum.GetValues(typeof(T)).Length];
        }

        public override bool IsSelected(int index) => _optionsSelected[index];

        protected internal override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();
            var printValuesOptions = options.PrintOptions;

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (printValuesOptions.CurrentIndex > -1)
                    {
                        ConsoleWrapper.Instance.CursorVisible = true;
                        result = BuildResult(options);
                        return true;
                    }
                    return false;
                case ConsoleKey.Spacebar:
                    if (printValuesOptions.CurrentIndex > -1)
                    {
                        _optionsSelected[printValuesOptions.CurrentIndex] = !_optionsSelected[printValuesOptions.CurrentIndex];
                        printValuesOptions.SelectedIndices = _optionsSelected
                            .Select((selected, index) => (selected, index))
                            .Where(x => x.selected)
                            .Select(x => x.index)
                            .ToArray();
                        options.Formatter.Print(printValuesOptions);
                    }
                    return false;
                default:
                    return base.OnKey(options, key, out result);
            }
        }

        private IEnumerable<T> BuildResult(ConsoleOptions<T> options)
        {
            for (var i = 0; i < _optionsSelected.Length; i++)
            {
                if (!_optionsSelected[i])
                {
                    continue;
                }

                yield return options.PrintOptions.Values[i].Value;
            }
        }
    }
}
