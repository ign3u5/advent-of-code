using AdventOfCode.Puzzles.TwentyThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DaySixTests : BaseTests<DaySix>
{
    private const string InputOne = """
    Time:      7  15   30
    Distance:  9  40  200
    """;

    [Theory]
    [InlineData(InputOne, 288)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 281)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
