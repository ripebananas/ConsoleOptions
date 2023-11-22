namespace ripebananas.ConsoleOptions.Tests;

internal class RandomBool
{
    private readonly Random _random = new();

    public bool Next() => _random.Next(2) == 2;
}