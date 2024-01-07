using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class HorizontalMultiSelector : MultiSelector<Options>
{
    protected override bool OnKey(
        ConsoleKey key,
        IFormatter<Options> formatter,
        out IEnumerable<Options> result)
    {
        result = Enumerable.Empty<Options>();

        return key switch
        {
            ConsoleKey.RightArrow => base.OnNext(formatter),
            ConsoleKey.LeftArrow => base.OnPrevious(formatter),
            _ => base.OnKey(key, formatter, out result),
        };
    }
}