using ripebananas.ConsoleOptions.Formatters;

namespace ripebananas.ConsoleOptions
{
    public static class ConsoleOptionsBuilderExtensions
    {
        public static IConfigurableConsoleOptionsBuilder<T, TFO> Prompt<T, TFO>(
            this IConfigurableConsoleOptionsBuilder<T, TFO> builder,
            string prompt)
            where TFO : FormatterOptions
        {
            return builder.ConfigureFormatter(x => x.Prompt = prompt);
        }

        public static IConfigurableConsoleOptionsBuilder<T, TFO> MultiSelection<T, TFO>(
            this IConfigurableConsoleOptionsBuilder<T, TFO> builder)
            where TFO : FormatterOptions
        {
            return builder.ConfigureFormatter(x => x.MultiSelection = true);
        }

        public static IConfigurableConsoleOptionsBuilder<T, TFO> DefaultIndex<T, TFO>(
            this IConfigurableConsoleOptionsBuilder<T, TFO> builder,
            int index)
            where TFO : FormatterOptions
        {
            return builder.ConfigureSelector(x =>
            {
                x.CurrentIndex = index < -1 || index > x.Values.Length - 1
                    ? -1
                    : index;
            });
        }
    }
}
