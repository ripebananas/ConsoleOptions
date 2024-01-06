using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleHorizontalMultiSelector : MultiSelector<Options>
{
    protected override bool OnKey(ConsoleOptions<Options> options, ConsoleKey key, out IEnumerable<Options> result)
    {
        result = Enumerable.Empty<Options>();

        return key switch
        {
            ConsoleKey.RightArrow => base.OnNext(options),
            ConsoleKey.LeftArrow => base.OnPrevious(options),
            _ => base.OnKey(options, key, out result),
        };
    }
}