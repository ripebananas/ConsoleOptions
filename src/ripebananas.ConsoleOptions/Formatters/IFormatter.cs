namespace ripebananas.ConsoleOptions.Formatters
{
    public interface IFormatter<T, out TFO> : IFormatter<T>
        where TFO : FormatterOptions
    {
        TFO Options { get; }
    }

    public interface IFormatter<T>
    {
        void Print(FormatterPrintOptions.All<T> options);
    }
}
