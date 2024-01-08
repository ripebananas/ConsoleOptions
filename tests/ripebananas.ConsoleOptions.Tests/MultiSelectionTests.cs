using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Tests;

public class MultiSelectionTests
{
    public MultiSelectionTests()
    {
        Wrapper.Console = new Mock<IConsole>().Object;
    }

    [Fact]
    public void DownOrUpArrowKeysPressedRandomly_SelectedOptionsShouldBeReturnedCorrectly()
    {
        // arrange
        var formatter = new Mock<IFormatter<OptionsFlags>>().Object;
        var selector = new SingleSelector<OptionsFlags>();
        selector.Options.Values = OptionDescriptions.GetFromEnum<OptionsFlags>().ToArray();

        var optionsCount = selector.Options.Values.Length;
        var selectedOptions = new bool[optionsCount];

        var index = -1;
        const int iterations = 10;

        // act
        for (var i = 0; i < iterations; i++)
        {
            var down = RandomBool.Next();
            var toggle = RandomBool.Next();

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

            if (toggle)
            {
                selector.OnKey(ConsoleKey.Spacebar, formatter, out var _);
                selectedOptions[index] = !selectedOptions[index];
            }
        }

        var resultReturned = selector.OnKey(ConsoleKey.Enter, formatter, out var result);

        // assert
        resultReturned.Should().BeTrue();
        if (selectedOptions.Contains(true))
        {
            result.Should().NotBeEmpty();
        }
        var resultIndex = 0;
        for (var i = 0; i < selectedOptions.Length; i++)
        {
            if (selectedOptions[i])
            {
                result.ElementAt(resultIndex).Should().Be(selector.Options.Values[i].Value);
                resultIndex++;
            }
        }
    }
}