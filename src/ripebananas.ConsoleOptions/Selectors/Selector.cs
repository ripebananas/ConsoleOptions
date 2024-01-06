using System;
using System.Collections.Generic;
using System.Linq;

namespace ripebananas.ConsoleOptions.Selectors
{
    public abstract class Selector<T> : ISelector<T>
    {
        protected Selector()
        {
        }

        public abstract bool IsSelected(int index);

        public virtual IEnumerable<T> WaitForSelection(ConsoleOptions<T> options)
        {
            options.Formatter.Print(options.PrintOptions);

            while (true)
            {
                var key = ConsoleWrapper.Instance.ReadKey(true);

                switch (key.Key)
                {
                    default:
                        if (OnKey(options, key.Key, out var keyResult))
                        {
                            return keyResult;
                        }
                        break;
                }
            }
        }

        protected internal virtual bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();

            return key switch
            {
                ConsoleKey.UpArrow => OnPrevious(options),
                ConsoleKey.DownArrow => OnNext(options),
                _ => false,
            };
        }

        protected virtual bool OnPrevious(ConsoleOptions<T> options)
        {
            options.PrintOptions.CurrentIndex--;
            if (options.PrintOptions.CurrentIndex < 0)
            {
                options.PrintOptions.CurrentIndex = options.PrintOptions.Values.Length - 1;
            }
            options.Formatter.Print(options.PrintOptions);

            return false;
        }

        protected virtual bool OnNext(ConsoleOptions<T> options)
        {
            options.PrintOptions.CurrentIndex++;
            if (options.PrintOptions.CurrentIndex > options.PrintOptions.Values.Length - 1)
            {
                options.PrintOptions.CurrentIndex = 0;
            }
            options.Formatter.Print(options.PrintOptions);

            return false;
        }
    }
}