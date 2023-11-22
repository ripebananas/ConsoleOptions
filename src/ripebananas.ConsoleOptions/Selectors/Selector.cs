using System;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Selectors
{
    public abstract class Selector<T> : ISelector<T>
        where T : struct, Enum
    {
        protected Selector()
        {
            Console.CursorVisible = false;
        }

        public abstract bool IsSelected(int index);

        public virtual T? WaitForSelection(ConsoleOptions<T> options)
        {
            Print(options);

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Console.CursorVisible = true;
                        return null;
                    default:
                        if (OnKey(options, key.Key, out var keyResult))
                        {
                            return keyResult;
                        }
                        break;
                }
            }
        }

        protected virtual void Print(ConsoleOptions<T> options)
        {
            Console.SetCursorPosition(options.CursorLeft, options.CursorTop);

            if (!string.IsNullOrWhiteSpace(options.Prompt))
            {
                Console.WriteLine(options.Prompt);
            }

            for (var i = 0; i < options.Values.Length; i++)
            {
                options.Formatter.Print(new PrintValueOptions<T>
                {
                    Value = options.Values[i],
                    Index = i,
                    IsCurrent = i == options.CurrentIndex,
                    IsSelected = IsSelected(i)
                });
            }
        }

        protected internal virtual bool OnKey(ConsoleOptions<T> options, ConsoleKey key, out T? result)
        {
            result = null;

            return key switch
            {
                ConsoleKey.UpArrow => OnPrevious(options),
                ConsoleKey.DownArrow => OnNext(options),
                _ => false,
            };
        }

        protected virtual bool OnPrevious(ConsoleOptions<T> options)
        {
            options.CurrentIndex--;
            if (options.CurrentIndex < 0)
            {
                options.CurrentIndex = options.Values.Length - 1;
            }
            Print(options);

            return false;
        }

        protected virtual bool OnNext(ConsoleOptions<T> options)
        {
            options.CurrentIndex++;
            if (options.CurrentIndex > options.Values.Length - 1)
            {
                options.CurrentIndex = 0;
            }
            Print(options);

            return false;
        }
    }
}