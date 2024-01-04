using System.Collections.Generic;

namespace ripebananas.ConsoleOptions.Selectors
{
    public interface ISelector<T>
    {
        IEnumerable<T> WaitForSelection(ConsoleOptions<T> options);
    }
}