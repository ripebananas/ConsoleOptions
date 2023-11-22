using System;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class MultiSelector<T> : Selector<T>
        where T : struct, Enum
    {
        private readonly bool[] _optionsSelected;

        public MultiSelector()
        {
            _optionsSelected = new bool[Enum.GetValues(typeof(T)).Length];
        }

        public override bool IsSelected(int index) => _optionsSelected[index];

        protected internal override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out T? result)
        {
            result = null;

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (options.CurrentIndex > -1)
                    {
                        Console.CursorVisible = true;
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

        private T? BuildResult(ConsoleOptions<T> options)
        {
            if (Array.TrueForAll(_optionsSelected, x => !x))
            {
                return null;
            }

            T? result = null;

            for (var i = 0; i < _optionsSelected.Length; i++)
            {
                if (!_optionsSelected[i])
                {
                    continue;
                }

                if (result == null)
                {
                    result = options.Values[i];
                }
                else
                {
                    // no bitwise OR for generic enums, hence the casts
                    result = (T)(object)((int)(object)result | (int)(object)options.Values[i]);
                }
            }

            return result;
        }
    }
}
