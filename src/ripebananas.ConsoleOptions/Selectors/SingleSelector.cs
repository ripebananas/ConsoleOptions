using System;
using System.Collections.Generic;
using System.Linq;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class SingleSelector<T> : Selector<T>
    {
        public override bool IsSelected(int index) => false;

        protected internal override bool OnKey(
            ConsoleKey key,
            IFormatter<T> formatter,
            out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();

            switch (key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (Options.CurrentIndex > -1)
                    {
                        Wrapper.Console.CursorVisible = true;
                        result = new[] { Options.Values[Options.CurrentIndex].Value };
                        return true;
                    }
                    return false;
                default:
                    return base.OnKey(key, formatter, out result);
            }
        }
    }
}
