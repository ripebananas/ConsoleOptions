using System;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class HorizontalSingleSelector<T> : SingleSelector<T>
        where T : struct, Enum
    {
        protected override void Print(ConsoleOptions<T> options)
        {
            base.Print(options);
            Console.WriteLine();
        }

        protected override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out T? result)
        {
            result = null;

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
