using AdventOfCode.Puzzles.TwentyThree;

namespace AdventOfCode.Puzzles.Tests.TwentyThree;
public class DayTwelveTests : BaseTests<DayTwelve>
{
    private const string InputOne = """
    ???.### 1,1,3
    .??..??...?##. 1,1,3
    ?#?#?#?#?#?#?#? 1,3,1,6
    ????.#...#... 4,1,1
    ????.######..#####. 1,6,5
    ?###???????? 3,2,1
    """;

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskOne(string input, int expected) => TaskOne(input, expected);

    [Theory]
    [InlineData(InputOne, 0)]
    public void RunTaskTwo(string input, int expected) => TaskTwo(input, expected);
}
