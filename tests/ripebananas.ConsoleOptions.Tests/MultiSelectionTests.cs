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
        var consoleOptions = new ConsoleOptions<OptionsFlags>(new Mock<IFormatter<OptionsFlags>>().Object);
        var console = new MultiSelector<OptionsFlags>();
        var randomBool = new RandomBool();
        var index = -1;
        var options = Enum.GetValues<OptionsFlags>();
        var optionsSelected = new bool[options.Length];
        const int iterations = 10;

        // act
        for (var i = 0; i < iterations; i++)
        {
            var down = randomBool.Next();
            var toggle = randomBool.Next();

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
                optionsSelected[index] = !optionsSelected[index];
            }
        }

        var result = console.OnKey(consoleOptions, ConsoleKey.Enter, out var selectedOptions);

        // assert
        result.Should().BeTrue();
        if (optionsSelected.Contains(true))
        {
            selectedOptions.Should().NotBeNull();
        }
        for (var i = 0; i < optionsSelected.Length; i++)
        {
            if (optionsSelected[i])
            {
                (selectedOptions & options[i]).Should().Be(options[i]);
            }
        }
    }

    [Fact]
    public void EscapePressed_NoResultReturned()
    {
        // arrange
        var consoleOptions = new ConsoleOptions<OptionsFlags>(new Mock<IFormatter<OptionsFlags>>().Object);
        var console = new MultiSelector<OptionsFlags>();

        // act
        console.OnKey(consoleOptions, ConsoleKey.DownArrow, out var _);
        console.OnKey(consoleOptions, ConsoleKey.Spacebar, out var _);
        var result = console.OnKey(consoleOptions, ConsoleKey.Escape, out var selectedOption);

        // assert
        result.Should().BeFalse();
        selectedOption.Should().BeNull();
    }
}