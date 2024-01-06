using System;
using System.Collections.Generic;
using System.Linq;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class SingleSelector<T> : Selector<T>
    {
        public override bool IsSelected(int index) => false;

        protected internal override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();

            switch (key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (options.PrintOptions.CurrentIndex > -1)
                    {
                        ConsoleWrapper.Instance.CursorVisible = true;
                        result = new[] { options.PrintOptions.Values[options.PrintOptions.CurrentIndex].Value };
                        return true;
                    }
                    return false;
                default:
                    return base.OnKey(options, key, out result);
            }
        }
    }
}
