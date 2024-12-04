﻿using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayElevenTests : BaseTests<DayEleven>
{
    private const string InputOne = """
    ...#......
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

    private const string InputTwo10 = """
    ...#......
    .......#..
    #.........
    ..........
    ......#...
    .#........
    .........#
    ..........
    .......#..
    #...#.....
    10
    """;

    private const string InputTwo100 = """
    ...#......
    .......#..
    #.........
    ..........
    ......#...
    .#........
    .........#
    ..........
    .......#..
    #...#.....
    100
    """;

    [Theory]
    [InlineData(InputOne, 374)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputTwo10, 1030)]
    [InlineData(InputTwo100, 8410)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}