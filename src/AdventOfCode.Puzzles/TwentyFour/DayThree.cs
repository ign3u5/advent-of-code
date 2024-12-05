using AdventOfCode.Common;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles.TwentyFour;
public partial class DayThree : IPuzzle
{
    [GeneratedRegex("""do\(\)|don't\(\)|mul\((\d+),(\d+)\)""")]
    private static partial Regex GetRegex();

    public object RunTaskOne(string[] inputLines)
    {
        int total = 0;

        foreach (var line in inputLines)
        {
            var matches = GetRegex().Matches(line);

            foreach (Match match in matches)
            {
                if (!match.Value.StartsWith("mul")) continue;
                total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }
        }

        return total;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int total = 0;

        bool isDo = true;

        foreach (var line in inputLines)
        {
            var matches = GetRegex().Matches(line);

            foreach (Match match in matches)
            {
                if (match.Value == "do()") 
                {
                    isDo = true;
                    continue;
                }

                if (match.Value == "don't()")
                {
                    isDo = false;
                    continue;
                }

                if (isDo)
                {
                    total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }
        }

        return total;
    }
}
