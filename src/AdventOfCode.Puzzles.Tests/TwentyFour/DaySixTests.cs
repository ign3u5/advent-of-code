using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;

public class DaySixTests : BaseTests<DaySix>
{
    const string InputOne = """
    ....#.....
    .........#
    ..........
    ..#.......
    .......#..
    ..........
    .#..^.....
    ........#.
    #.........
    ......#...
    """;

    [Theory]
    [InlineData(InputOne, 41)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 6)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
