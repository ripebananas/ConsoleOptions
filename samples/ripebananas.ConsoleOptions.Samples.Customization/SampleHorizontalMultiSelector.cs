using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Samples.Customization;

internal class SampleHorizontalMultiSelector : MultiSelector<Options>
{
    protected override void Print(ConsoleOptions<Options> options)
    {
        base.Print(options);
        Console.WriteLine();
    }

    protected override bool OnKey(ConsoleOptions<Options> options, ConsoleKey key, out Options? result)
    {
        return key switch
        {
            ConsoleKey.RightArrow => base.OnKey(options, ConsoleKey.DownArrow, out result),
            ConsoleKey.LeftArrow => base.OnKey(options, ConsoleKey.UpArrow, out result),
            _ => base.OnKey(options, key, out result),
        };
    }
}