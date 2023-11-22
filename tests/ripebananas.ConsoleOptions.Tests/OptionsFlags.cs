namespace ripebananas.ConsoleOptions.Tests;

[Flags]
public enum OptionsFlags
{
    Option1 = 1 << 0,
    Option2 = 1 << 1,
    Option3 = 1 << 2
}