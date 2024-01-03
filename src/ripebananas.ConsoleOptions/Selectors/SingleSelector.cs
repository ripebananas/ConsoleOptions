using System;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class SingleSelector<T> : Selector<T>
    {
        public override bool IsSelected(int index) => false;

        protected internal override bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out T? result)
        {
            result = default;

            switch (key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (options.CurrentIndex > -1)
                    {
                        Console.CursorVisible = true;
                        result = options.Values[options.CurrentIndex];
                        return true;
                    }
                    return false;
                default:
                    return base.OnKey(options, key, out result);
            }
        }
    }
}
