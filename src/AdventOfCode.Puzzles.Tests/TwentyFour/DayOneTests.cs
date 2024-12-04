using System;
using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;

public class DayOneTests : BaseTests<DayOne>
{
    const string InputOne = """
    3   4
    4   3
    2   5
    1   3
    3   9
    3   3
    """;

    [Theory]
    [InlineData(InputOne, 11)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);
}
