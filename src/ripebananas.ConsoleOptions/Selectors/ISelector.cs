using System.Collections.Generic;
using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions.Selectors
{
    public interface ISelector<T>
    {
        SelectorOptions<T> Options { get; }


        IEnumerable<T> WaitForSelection(IFormatter<T> formatter);
    }
}