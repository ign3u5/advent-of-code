using AdventOfCode.Puzzles.TwentyFour;

namespace AdventOfCode.Puzzles.Tests.TwentyFour;
public class DayThreeTests : BaseTests<DayThree>
{
    const string InputOne = """
        xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
        """;

    const string InputTwo = """
        xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
        """;

    [Theory]
    [InlineData(InputOne, 161)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputTwo, 48)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
