namespace ripebananas.ConsoleOptions.Tests;

internal static class RandomBool
{
    public static bool Next() => Random.Shared.Next(2) == 2;
}