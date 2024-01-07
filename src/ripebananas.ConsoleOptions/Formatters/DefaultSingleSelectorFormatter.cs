using System.Collections.Generic;
using System.Linq;
using System;

namespace ripebananas.ConsoleOptions.Formatters
{
    public class DefaultSingleSelectorFormatter<T, TFO> : Formatter<T, TFO>
        where TFO : FormatterOptions, new()
    {
        public DefaultSingleSelectorFormatter()
            : this(new TFO())
        {
        }

        public DefaultSingleSelectorFormatter(TFO formatterOptions)
            : base(formatterOptions)
        {
        }

        protected override void PrintSelectedIndicator(FormatterPrintOptions.Single<T> options) { }
    }
}