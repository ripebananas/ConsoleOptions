using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public static class FormatterPrintOptions
    {
        public class All<T>
        {
            public int CurrentIndex { get; set; }

            public int[] SelectedIndices { get; set; } = Array.Empty<int>();

            public OptionDescription<T>[] Values { get; set; } = Array.Empty<OptionDescription<T>>();
        }

        public class Single<T>
        {
            public int Index { get; set; }

            public bool IsCurrent { get; set; }

            public bool IsSelected { get; set; }

            public OptionDescription<T> Value { get; }

            public Single(OptionDescription<T> value)
            {
                Value = value;
            }
        }
    }
}
