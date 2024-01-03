namespace ripebananas.ConsoleOptions.Formatters
{
    public class PrintValueOptions<T>
    {
        public T Value { get; set; }

        public int Index { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsSelected { get; set; }
    }
}
