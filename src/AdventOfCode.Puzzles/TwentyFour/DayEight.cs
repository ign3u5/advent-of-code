using AdventOfCode.Common;
using Point = (int x, int y);

namespace AdventOfCode.Puzzles.TwentyFour;
public class DayEight : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        const int Zero = '0';
        const int A = 'A' - 10;
        const int a = 'a' - 10 - 26;

        List<(int x, int y)>[] antennaPointsLists = new List<(int, int)>[10 + 26 + 26];
        bool[][] antinodePoints = new bool[inputLines[0].Length][];

        for (int y = 0; y < inputLines.Length; y++)
        {
            for (int x = 0; x < inputLines[y].Length; x++)
            {
                antinodePoints[y] = new bool[inputLines.Length];

                char currentVal = inputLines[y][x];

                if (currentVal == '.') continue;

                if (isNumber(currentVal))
                {
                    int index = currentVal - '0';
                    antennaPointsLists[index] ??= [];
                    antennaPointsLists[index].Add((x, y));
                }

                if (isUpper(currentVal))
                {
                    int index = currentVal - 'A' + 10;
                    antennaPointsLists[index] ??= [];
                    antennaPointsLists[index].Add((x, y));
                }

                if (isLower(currentVal))
                {
                    int index = currentVal - 'a' + 10 + 26;
                    antennaPointsLists[index] ??= [];
                    antennaPointsLists[index].Add((x, y));
                }
            }
        }

        foreach (List<(int x, int y)> antennaPointsList in antennaPointsLists)
        {
            if (antennaPointsList is null) continue;

            for (int i = 0; i < antennaPointsList.Count; i++)
            {
                for (int j = i + 1; j < antennaPointsList.Count; j++)
                {
                    var (iX, iY) = antennaPointsList[i];

                    var (jX, jY) = antennaPointsList[j];

                    var (dX, dY) = (iX = jX, iY = jY);

                    if (iX + dX == jX)
                    {
                        Point possibleAntinodeOne = (iX - dX, iY - dY);
                        if (isInBounds(possibleAntinodeOne)) antinodePoints[possibleAntinodeOne.x][possibleAntinodeOne.y] = true;

                        Point possibleAntinodeTwo = (jX + dX, jY + dY);
                        if (isInBounds(possibleAntinodeTwo)) antinodePoints[possibleAntinodeTwo.x][possibleAntinodeTwo.y] = true;
                    }
                    else
                    {
                        Point possibleAntinodeOne = (iX + dX, iY + dY);
                        if (isInBounds(possibleAntinodeOne)) antinodePoints[possibleAntinodeOne.x][possibleAntinodeOne.y] = true;

                        Point possibleAntinodeTwo = (jX - dX, jY - dY);
                        if (isInBounds(possibleAntinodeTwo)) antinodePoints[possibleAntinodeTwo.x][possibleAntinodeTwo.y] = true;
                    }
                }
            }
        }

        return antinodePoints.SelectMany(ap => ap).Count(ap => ap);

        bool isInBounds(Point point) => point.x >= 0 && point.x < inputLines[0].Length && point.y >= 0 && point.y < inputLines.Length;

        bool isNumber(int val) => val >= '0' && val <= '9';

        bool isUpper(int val) => val >= 'A' && val <= 'Z';

        bool isLower(int val) => val >= 'a' && val <= 'z';
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
