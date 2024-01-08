using System;
using System.Collections.Generic;
using System.Linq;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class MultiSelector<T> : Selector<T>
    {
        public override bool IsSelected(int index) => Options.SelectedIndices.Contains(index);

        protected internal override bool OnKey(
            ConsoleKey key,
            IFormatter<T> formatter,
            out IEnumerable<T> result)
        {
            result = Enumerable.Empty<T>();
            var printAllOptions = CreatePrintAllOptions();

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (printAllOptions.CurrentIndex > -1)
                    {
                        Wrapper.Console.CursorVisible = true;
                        result = BuildResult(printAllOptions);
                        return true;
                    }
                    return false;
                case ConsoleKey.Spacebar:
                    if (printAllOptions.CurrentIndex > -1)
                    {
                        if (Options.SelectedIndices.Contains(printAllOptions.CurrentIndex))
                        {
                            Options.SelectedIndices.Remove(printAllOptions.CurrentIndex);
                        }
                        else
                        {
                            Options.SelectedIndices.Add(printAllOptions.CurrentIndex);
                        }
                        printAllOptions.SelectedIndices = Options.SelectedIndices.ToArray();
                        formatter.Print(printAllOptions);
                    }
                    return false;
                default:
                    return base.OnKey(key, formatter, out result);
            }
        }

        private IEnumerable<T> BuildResult(FormatterPrintOptions.All<T> options)
        {
            return Options.SelectedIndices.Select(x => options.Values[x].Value);
        }
    }
}
