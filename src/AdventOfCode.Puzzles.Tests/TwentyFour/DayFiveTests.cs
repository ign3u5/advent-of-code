using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;
public class DayFiveTests : BaseTests<DayFive>
{
    const string InputOne = """
        47|53
        97|13
        97|61
        97|47
        75|29
        61|13
        75|53
        29|13
        97|29
        53|29
        61|53
        97|53
        61|29
        47|13
        75|47
        97|75
        47|61
        75|61
        47|29
        75|13
        53|13

        75,47,61,53,29
        97,61,53,29,13
        75,29,13
        75,97,47,61,53
        61,13,29
        97,13,75,29,47
        """;

    [Theory]
    [InlineData(InputOne, 143)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 9)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
