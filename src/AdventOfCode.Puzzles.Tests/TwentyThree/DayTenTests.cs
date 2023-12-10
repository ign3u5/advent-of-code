using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayTenTests : BaseTests<DayTen>
{
    private const string ExtractedSimpleLoop = """
    .....
    .S-7.
    .|.|.
    .L-J.
    .....
    """;
    
    private const string RawSimpleLoop = """
    -L|F7
    7S-7|
    L|7||
    -L-J|
    L|-JF
    """;
    
    private const string ExtractedComplexLoop = """
    ..F7.
    .FJ|.
    SJ.L7
    |F--J
    LJ...
    """;

    private const string RawComplexLoop = """
    7-F7-
    .FJ|7
    SJLL7
    |F--J
    LJ.LJ
    """;

    [Theory]
    [InlineData(ExtractedSimpleLoop, 4)]
    [InlineData(RawSimpleLoop, 4)]
    [InlineData(ExtractedComplexLoop, 8)]
    [InlineData(RawComplexLoop, 8)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    private const string PartTwoTestOne = """
    ...........
    .S-------7.
    .|F-----7|.
    .||.....||.
    .||.....||.
    .|L-7.F-J|.
    .|..|.|..|.
    .L--J.L--J.
    ...........
    """;
    
    private const string PartTwoTestOne2 = """
    ..........
    .S------7.
    .|F----7|.
    .||....||.
    .||....||.
    .|L-7F-J|.
    .|..||..|.
    .L--JL--J.
    ..........
    """;

    private const string PartTwoTestTwo = """
    .F----7F7F7F7F-7....
    .|F--7||||||||FJ....
    .||.FJ||||||||L7....
    FJL7L7LJLJ||LJ.L-7..
    L--J.L7...LJS7F-7L7.
    ....F-J..F7FJ|L7L7L7
    ....L7.F7||L7|.L7L7|
    .....|FJLJ|FJ|F7|.LJ
    ....FJL-7.||.||||...
    ....L---J.LJ.LJLJ...
    """;

    private const string PartTwoTestThree = """
    FF7FSF7F7F7F7F7F---7
    L|LJ||||||||||||F--J
    FL-7LJLJ||||||LJL-77
    F--JF--7||LJLJ7F7FJ-
    L---JF-JLJ.||-FJLJJ7
    |F|F-JF---7F7-L7L|7|
    |FFJF7L7F-JF7|JL---7
    7-L-JL7||F7|L7F-7F7|
    L.L7LFJ|||||FJL7||LJ
    L7JLJL-JLJLJL--JLJ.L
    """;

    [Theory]
    [InlineData(PartTwoTestOne, 4)]
    [InlineData(PartTwoTestOne2, 4)]
    [InlineData(PartTwoTestTwo, 8)]
    [InlineData(PartTwoTestThree, 10)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}