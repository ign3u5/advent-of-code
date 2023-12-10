using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;

public class DayNineTests : BaseTests<DayNine>
{
    private const string InputOne = """
    0 3 6 9 12 15
    1 3 6 10 15 21
    10 13 16 21 30 45
    """;

    [Theory]
    [InlineData(InputOne, 114)]
    public void RunTaskOne(string input, long expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 2)]
    public void RunTaskTwo(string input, long expected) => TaskTwo(input, expected);
}