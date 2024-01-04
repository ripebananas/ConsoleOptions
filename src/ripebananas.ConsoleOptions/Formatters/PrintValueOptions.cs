namespace ripebananas.ConsoleOptions.Formatters
{
    public class PrintValueOptions<T>
    {
        public OptionDescription<T> Value { get; }

        public int Index { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsSelected { get; set; }

        public PrintValueOptions(OptionDescription<T> value)
        {
            Value = value;
        }
    }
}
