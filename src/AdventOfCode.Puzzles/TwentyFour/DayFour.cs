using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;
public class DayFour : IPuzzle
{
    const string XMAS = nameof(XMAS);

    public object RunTaskOne(string[] inputLines)
    {
        int xmasCount = 0;

        for (int y = 0; y < inputLines.Length; y++)
        {
            for (int x = 0; x < inputLines[y].Length; x++)
            {
                if (inputLines[y][x] != 'X')
                {
                    continue;
                }

                bool couldFitEast = x < inputLines[y].Length - XMAS.Length + 1;
                bool couldFitSouth = y < inputLines.Length - XMAS.Length + 1;
                bool couldFitWest = x > XMAS.Length - 2;
                bool couldFitNorth = y > XMAS.Length - 2;

                (int xDir, int yDir, bool check)[] directionsToCheck = 
                    [
                        (1, 0, couldFitEast),
                        (1, 1, couldFitSouth && couldFitEast),
                        (0, 1, couldFitSouth),
                        (-1, 1, couldFitSouth && couldFitWest),
                        (-1, 0, couldFitWest),
                        (-1, -1, couldFitNorth && couldFitWest),
                        (0, -1, couldFitNorth),
                        (1, -1, couldFitNorth && couldFitEast)
                    ];

                foreach (var (xDir, yDir, check) in directionsToCheck)
                {
                    if (check && CheckDirection(xDir, yDir)) xmasCount++;
                }

                bool CheckDirection(int xDir, int yDir)
                {
                    int count = 1;
                    bool isXmas = false;

                    while (count < 4)
                    {
                        char currentChar = inputLines[y + (count * yDir)][x + (count * xDir)];
                        char checkChar = XMAS[count];
                        if (currentChar != checkChar)
                        {
                            isXmas = false;
                            break;
                        }

                        count++;
                        isXmas = true;
                    }

                    return isXmas;
                }
            }
        }

        return xmasCount;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int xMasCount = 0;

        const string MS = nameof(MS);

        for (int y = 0; y < inputLines.Length; y++)
        {
            for (int x = 0; x < inputLines[y].Length; x++)
            {
                if (inputLines[y][x] != 'A')
                {
                    continue;
                }

                bool couldFit = x > 0 && y > 0 && x < inputLines[y].Length - 1 && y < inputLines.Length - 1;

                if (couldFit)
                {
                    char ne = inputLines[y - 1][x + 1];

                    if (!MS.Any(c => c == ne)) continue;

                    char sw = inputLines[y + 1][x - 1];

                    if (!MS.Any(c => c == sw) || sw == ne) continue;

                    char nw = inputLines[y - 1][x - 1];

                    if (!MS.Any(c => c == nw)) continue;

                    char se = inputLines[y + 1][x + 1];

                    if (!MS.Any(c => c == se) || se == nw) continue;

                    xMasCount++;
                }

            }
        }

        return xMasCount;
    }
}
