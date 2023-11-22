namespace ripebananas.ConsoleOptions.Samples.Customization;

[Flags]
internal enum Options
{
    [OptionDescription("This is option 1")]
    Option1 = 1 << 0,

    [OptionDescription("This is option 2")]
    Option2 = 1 << 1,

    [OptionDescription("This is option 3")]
    Option3 = 1 << 2
}
