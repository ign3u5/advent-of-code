using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayElevenTests : BaseTests<DayEleven>
{
    private const string InputOne = """
    .......#..
    #.........
    ..........
    ......#...
    .#........
    .........#
    ..........
    .......#..
    #...#.....
    """;

    private const string InputTwo = """

    """;

    [Theory]
    [InlineData(InputOne, 374)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputTwo, 0)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
