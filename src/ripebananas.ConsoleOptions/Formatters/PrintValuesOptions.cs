using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class PrintValuesOptions<T>
    {
        public int CurrentIndex { get; set; }

        public int[] SelectedIndices { get; set; } = Array.Empty<int>();

        public string? Prompt { get; set; }

        public OptionDescription<T>[] Values { get; set; } = Array.Empty<OptionDescription<T>>();
    }
}
