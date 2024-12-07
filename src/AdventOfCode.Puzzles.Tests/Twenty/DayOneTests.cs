using AdventOfCode.Puzzles.Twenty;

namespace AdventOfCode.Puzzles.Tests.Twenty;
public class DayOneTests : BaseTests<DayOne>
{
    const string InputOne = """
    1721
    979
    366
    299
    675
    1456
    """;

    [Theory]
    [InlineData(InputOne, 514579)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 241861950)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
