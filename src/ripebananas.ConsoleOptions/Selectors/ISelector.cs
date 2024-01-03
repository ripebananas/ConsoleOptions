namespace ripebananas.ConsoleOptions.Selectors
{
    public interface ISelector<T>
    {
        T? WaitForSelection(ConsoleOptions<T> options);
    }
}