using System;

namespace ripebananas.ConsoleOptions.Selectors
{
    public interface ISelector<T>
        where T : struct, Enum
    {
        T? WaitForSelection(ConsoleOptions<T> options);
    }
}