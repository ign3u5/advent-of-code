using System;
using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;

public class DayTwoTests : BaseTests<DayTwo>
{
    const string InputOne = """
    7 6 4 2 1
    1 2 7 8 9
    9 7 6 2 1
    1 3 2 4 5
    8 6 4 4 1
    1 3 6 7 9
    """;

    const string InputTwo = """
    1 3 4 5 12
    12 5 4 3 1
    """;

    [Theory]
    [InlineData(InputOne, 2)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 4)]
    [InlineData(InputTwo, 2)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
