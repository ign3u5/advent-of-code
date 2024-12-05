using AdventOfCode.Puzzles.TwentyThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayThirteenTests : BaseTests<DayThirteen>
{
    private const string InputOne = """
    #.##..##.
    ..#.##.#.
    ##......#
    ##......#
    ..#.##.#.
    ..##..##.
    #.#.##.#.

    #...##..#
    #....#..#
    ..##..###
    #####.##.
    #####.##.
    ..##..###
    #....#..#
    """;

    [Theory]
    [InlineData(InputOne, 405)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
