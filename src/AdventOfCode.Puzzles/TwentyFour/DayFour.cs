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
        return 0;
    }
}
