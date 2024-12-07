using AdventOfCode.Common;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles.Twenty;
public partial class DayTwo : IPuzzle
{
    [GeneratedRegex("""(\d+)-(\d+) ([a-z]): (.+)""")]
    private static partial Regex GetRegex();

    public object RunTaskOne(string[] inputLines)
    {
        int totalValidPasswords = 0;

        foreach (string line in inputLines)
        {
            var match = GetRegex().Match(line);

            int lowerBound = int.Parse(match.Groups[1].Value);
            int upperBound = int.Parse(match.Groups[2].Value);

            int charCount = 0;

            bool invalid = false;

            foreach (char c in match.Groups[4].Value)
            {
                if (c == match.Groups[3].Value[0]) charCount++;

                if (charCount > upperBound)
                {
                    invalid = true;
                    break;
                }
            }

            if (charCount < lowerBound || invalid) continue;

            totalValidPasswords++;
        }

        return totalValidPasswords;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int totalValidPasswords = 0;

        foreach (string line in inputLines)
        {
            var match = GetRegex().Match(line);

            int firstIndex = int.Parse(match.Groups[1].Value);
            int secondIndex = int.Parse(match.Groups[2].Value);

            string currentPassword = match.Groups[4].Value;
            char requiredCharacter = match.Groups[3].Value[0];

            bool firstIndexMatchesCharacter = (currentPassword.Length > firstIndex - 1 && currentPassword[firstIndex - 1] == requiredCharacter);
            bool secondIndexMatchesCharacter = (currentPassword.Length > secondIndex - 1 && currentPassword[secondIndex - 1] == requiredCharacter);

            if (firstIndexMatchesCharacter != secondIndexMatchesCharacter)
            {
                totalValidPasswords++;

                continue;
            }
        }

        return totalValidPasswords;
    }
}
