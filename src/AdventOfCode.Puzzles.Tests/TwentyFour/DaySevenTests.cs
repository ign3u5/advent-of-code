using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;
public class DaySevenTests : BaseTests<DaySeven>
{
    const string InputOne = """
    190: 10 19
    3267: 81 40 27
    83: 17 5
    156: 15 6
    7290: 6 8 6 15
    161011: 16 10 13
    192: 17 8 14
    21037: 9 7 18 13
    292: 11 6 16 20
    """;

    [Theory]
    [InlineData(InputOne, 3749)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
