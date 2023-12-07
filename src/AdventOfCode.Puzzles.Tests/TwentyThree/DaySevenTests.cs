using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DaySevenTests : BaseTests<DaySeven>
{
    private const string InputOne = """
    32T3K 765
    T55J5 684
    KK677 28
    KTJJT 220
    QQQJA 483
    """;

    [Theory]
    [InlineData(InputOne, 6440)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 5905)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
