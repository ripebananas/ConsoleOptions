using System;
using System.Collections.Generic;

namespace ripebananas.ConsoleOptions.Selectors
{
    public class SelectorOptions<T>
    {
        public int CurrentIndex { get; set; }

        public HashSet<int> SelectedIndices { get; } = new HashSet<int>();

        public OptionDescription<T>[] Values { get; internal set; } = Array.Empty<OptionDescription<T>>();

        public virtual Direction Direction { get; internal set; } = Direction.Vertical;
    }
}
