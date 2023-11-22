using System;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions
{
    public class VerticalSingleSelector<T> : SingleSelector<T>
        where T : struct, Enum
    {
    }
}
