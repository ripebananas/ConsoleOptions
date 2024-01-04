using System;
using System.Collections.Generic;
using System.Linq;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class HorizontalSingleSelector<T> : SingleSelector<T>
    {
        protected override void Print(ConsoleOptions<T> options)
        {
            base.Print(options);
            ConsoleWrapper.Instance.WriteLine();
        }

        protected override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();

            return key switch
            {
                ConsoleKey.RightArrow => base.OnNext(options),
                ConsoleKey.LeftArrow => base.OnPrevious(options),
                ConsoleKey.DownArrow => false,
                ConsoleKey.UpArrow => false,
                _ => base.OnKey(options, key, out result),
            };
        }
    }
}
