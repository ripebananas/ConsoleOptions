//
// ███╗   ██╗ ██████╗ ████████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   █████╗
// ██║╚██╗██║██║   ██║   ██║   ██╔══╝
// ██║ ╚████║╚██████╔╝   ██║   ███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚══════╝
// ------------------------------------------------
//
// The tests are only runnable with `dotnet test` command, because of dependency on System.Console.
//

using ripebananas.ConsoleOptions.Formatters;
using ripebananas.ConsoleOptions.Selectors;

namespace ripebananas.ConsoleOptions.Tests;

public class MultiSelectionTests
{
    [Fact]
    public void DownOrUpArrowKeysPressedRandomly_SelectedOptionsShouldBeReturnedCorrectly()
    {
        // arrange
        var consoleOptions = new ConsoleOptions<OptionsFlags>(
            new Mock<IFormatter<OptionsFlags>>().Object,
            OptionDescriptions.GetFromEnum<OptionsFlags>().ToArray());
        var console = new MultiSelector<OptionsFlags>();
        var index = -1;
        var options = Enum.GetValues<OptionsFlags>();
        var selectedOptions = new bool[options.Length];
        const int iterations = 10;

        // act
        for (var i = 0; i < iterations; i++)
        {
            var down = RandomBool.Next();
            var toggle = RandomBool.Next();

            index += down ? 1 : -1;
            if (index < 0)
            {
                index = options.Length - 1;
            }
            else if (index >= options.Length)
            {
                index = 0;
            }

            console.OnKey(consoleOptions, down ? ConsoleKey.DownArrow : ConsoleKey.UpArrow, out var _);

            if (toggle)
            {
                console.OnKey(consoleOptions, ConsoleKey.Spacebar, out var _);
                selectedOptions[index] = !selectedOptions[index];
            }
        }

        var resultReturned = console.OnKey(consoleOptions, ConsoleKey.Enter, out var result);

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
                result.ElementAt(resultIndex).Should().Be(options[i]);
                resultIndex++;
            }
        }
    }
}