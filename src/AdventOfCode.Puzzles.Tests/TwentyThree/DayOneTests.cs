using AdventOfCode.Puzzles.Tests;
using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;

public class DayOneTests : BaseTests<DayOne>
{
    private const string InputOne = """
    1abc2
    pqr3stu8vwx
    a1b2c3d4e5f
    treb7uchet
    """;

    private const string InputTwo = """
    two1nine
    eightwothree
    abcone2threexyz
    xtwone3four
    4nineeightseven2
    zoneight234
    7pqrstsixteen
    """;

    [Theory]
    [InlineData(InputOne, 142)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);
    
    [Theory]
    [InlineData(InputTwo, 281)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}