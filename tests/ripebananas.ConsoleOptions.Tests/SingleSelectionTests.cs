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

public class SingleSelectionTests
{
    [Theory]
    [InlineData(ConsoleKey.Enter)]
    [InlineData(ConsoleKey.Spacebar)]
    public void DownOrUpArrowKeysPressedRandomly_SelectedOptionShouldBeReturnedCorrectly(ConsoleKey selectKey)
    {
        // arrange
        var consoleOptions = new ConsoleOptions<Options>(new Mock<IFormatter<Options>>().Object);
        var console = new SingleSelector<Options>();
        var randomBool = new RandomBool();
        var index = -1;
        var options = Enum.GetValues<Options>();
        const int iterations = 10;

        // act
        for (var i = 0; i < iterations; i++)
        {
            var down = randomBool.Next();

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
        }

        var result = console.OnKey(consoleOptions, selectKey, out var selectedOption);

        // assert
        result.Should().BeTrue();
        selectedOption.Should().NotBeNull();
        selectedOption.Should().Be(options[index % options.Length]);
    }

    [Fact]
    public void EscapePressed_NoResultReturned()
    {
        // arrange
        var consoleOptions = new ConsoleOptions<Options>(new Mock<IFormatter<Options>>().Object);
        var console = new SingleSelector<Options>();

        // act
        console.OnKey(consoleOptions, ConsoleKey.DownArrow, out var _);
        var result = console.OnKey(consoleOptions, ConsoleKey.Escape, out var selectedOption);

        // assert
        result.Should().BeFalse();
        selectedOption.Should().BeNull();
    }
}