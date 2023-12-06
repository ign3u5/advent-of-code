using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DaySevenTests : BaseTests<DaySeven>
{
    private const string InputOne = """

    """;

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
