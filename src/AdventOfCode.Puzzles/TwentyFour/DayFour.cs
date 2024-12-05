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

                bool couldFitEast = x < inputLines[y].Length - XMAS.Length;
                bool couldFitSouth = y < inputLines.Length - XMAS.Length;
                bool couldFitWest = x > XMAS.Length;
                bool couldFitNorth = y > XMAS.Length;

                if (couldFitSouth && couldFitEast)
                {
                    if (CheckDirection(inputLines, x, y, 1, 1)) xmasCount++;
                }

                if (couldFitSouth && couldFitWest)
                {
                    if (CheckDirection(inputLines, x, y, -1, 1)) xmasCount++;
                }
                
                if (couldFitNorth && couldFitWest)
                {
                    if (CheckDirection(inputLines, x, y, -1, -1)) xmasCount++;
                }
                
                if (couldFitNorth && couldFitEast)
                {
                    if (CheckDirection(inputLines, x, y, 1, -1)) xmasCount++;
                }

                // If could fit left to right
                if (x < inputLines[y].Length - XMAS.Length)
                {
                    if (inputLines[y][(x+1)..(x+4)] == "MAS")
                    {
                        xmasCount++;
                    }
                }

                // If could fit top to bottom
                if (y < inputLines.Length - XMAS.Length)
                {
                    if (inputLines[(y + 1)..(y + 4)][x] == "MAS")
                    {
                        xmasCount++;
                    }
                }

                // If could fit right to left
                if (x > XMAS.Length)
                {
                    if (inputLines[y][(x - 3)..x] == "SAM")
                    {
                        xmasCount++;
                    }
                }

                // If could fit bottom to top
                if (y > XMAS.Length)
                {
                    if (inputLines[(y - 3)..y][x] == "SAM")
                    {
                        xmasCount++;
                    }
                }
            }
        }

        return 0;
    }

    private bool CheckDirection(string[] inputLines, int x, int y, int xDir, int yDir)
    {
        int count = 0;
        bool isXmas = false;

        while (count < 4)
        {
            count++;
            if (inputLines[y + (count*yDir)][x + (count*xDir)] != XMAS[count])
            {
                isXmas = false;
                break;
            }

            isXmas = true;
        }

        return isXmas;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
