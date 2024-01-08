using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Tests;

public class SingleSelectionTests
{
    public SingleSelectionTests()
    {
        Wrapper.Console = new Mock<IConsole>().Object;
    }

    [Theory]
    [InlineData(ConsoleKey.Enter)]
    [InlineData(ConsoleKey.Spacebar)]
    public void DownOrUpArrowKeysPressedRandomly_SelectedOptionShouldBeReturnedCorrectly(ConsoleKey selectKey)
    {
        // arrange
        var formatter = new Mock<IFormatter<Options>>().Object;
        var selector = new SingleSelector<Options>();
        selector.Options.Values = OptionDescriptions.GetFromEnum<Options>().ToArray();

        var optionsCount = selector.Options.Values.Length;

        var index = -1;
        const int iterations = 10;

        // act
        for (var i = 0; i < iterations; i++)
        {
            var down = RandomBool.Next();

            index += down ? 1 : -1;
            if (index < 0)
            {
                index = optionsCount - 1;
            }
            else if (index >= optionsCount)
            {
                index = 0;
            }
            selector.OnKey(down ? ConsoleKey.DownArrow : ConsoleKey.UpArrow, formatter, out var _);
        }

        var result = selector.OnKey(selectKey, formatter, out var selectedOption);

        // assert
        result.Should().BeTrue();
        selectedOption.First().Should().Be(selector.Options.Values[index % optionsCount].Value);
    }
}