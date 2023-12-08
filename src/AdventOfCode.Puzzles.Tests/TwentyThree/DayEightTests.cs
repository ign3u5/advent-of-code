using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayEightTests : BaseTests<DayEight>
{
    private const string InputOne = """
    RL
    AAA = (BBB, CCC)
    BBB = (DDD, EEE)
    CCC = (ZZZ, GGG)
    DDD = (DDD, DDD)
    EEE = (EEE, EEE)
    GGG = (GGG, GGG)
    ZZZ = (ZZZ, ZZZ)
    """;

    private const string InputTwo = """
    LLR
    AAA = (BBB, BBB)
    BBB = (AAA, ZZZ)
    ZZZ = (ZZZ, ZZZ)
    """;

    private const string TaskTwoInput = """"
    LR
    11A = (11B, XXX)
    11B = (XXX, 11Z)
    11Z = (11B, XXX)
    22A = (22B, XXX)
    22B = (22C, 22C)
    22C = (22Z, 22Z)
    22Z = (22B, 22B)
    XXX = (XXX, XXX)
    """";

    [Theory]
    [InlineData(InputOne, 2)]
    [InlineData(InputTwo, 6)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(TaskTwoInput, 6)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}