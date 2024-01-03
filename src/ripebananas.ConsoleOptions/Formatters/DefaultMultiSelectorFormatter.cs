namespace ripebananas.ConsoleOptions.Formatters
{
    public class DefaultMultiSelectorFormatter<T, TFO> : Formatter<T, TFO>
        where TFO : FormatterOptions, new()
    {
        public DefaultMultiSelectorFormatter()
            : this(new TFO())
        {
        }

        public DefaultMultiSelectorFormatter(TFO formatterOptions)
            : base(formatterOptions)
        {
        }
    }
}