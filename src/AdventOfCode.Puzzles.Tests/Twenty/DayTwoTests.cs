using AdventOfCode.Puzzles.Twenty;

namespace AdventOfCode.Puzzles.Tests.Twenty;
public class DayTwoTests : BaseTests<DayTwo>
{
    const string InputOne = """
    1-3 a: abcde
    1-3 b: cdefg
    2-9 c: ccccccccc
    """;

    [Theory]
    [InlineData(InputOne, 2)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 1)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
