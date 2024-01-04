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

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (options.CurrentIndex > -1)
                    {
                        ConsoleWrapper.Instance.CursorVisible = true;
                        result = BuildResult(options);
                        return true;
                    }
                    return false;
                case ConsoleKey.Spacebar:
                    if (options.CurrentIndex > -1)
                    {
                        _optionsSelected[options.CurrentIndex] = !_optionsSelected[options.CurrentIndex];
                        Print(options);
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

                yield return options.Values[i].Value;
            }
        }
    }
}
