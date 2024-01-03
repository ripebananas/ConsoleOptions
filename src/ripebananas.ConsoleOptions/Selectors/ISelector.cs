using System.Diagnostics.CodeAnalysis;

namespace ripebananas.ConsoleOptions.Selectors
{
    public interface ISelector<T>
    {
        [return: MaybeNull]
        T WaitForSelection(ConsoleOptions<T> options);
    }
}