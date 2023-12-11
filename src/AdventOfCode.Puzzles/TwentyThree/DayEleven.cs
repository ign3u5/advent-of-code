using System.Dynamic;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

using Coord = (long x, long y);
public class DayEleven : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        return FindSumOfMinimumDistancesBetweenGalaxies(inputLines, 1);
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int increaseBy = GetTestingExpansionExponentOrDefault() - 1;

        return FindSumOfMinimumDistancesBetweenGalaxies(inputLines, increaseBy);

        int GetTestingExpansionExponentOrDefault() => int.TryParse(inputLines[^1], out int increaseBy) ? increaseBy : 1000000;
    }

    private long FindSumOfMinimumDistancesBetweenGalaxies(string[] inputLines, int increaseBy) 
    {
        Coord[] positionsOfGalaxy = GetListOfGalaxyCoords(inputLines, increaseBy).ToArray();

        long totalDistance = 0;
        for (int pos = 0; pos < positionsOfGalaxy.Length; pos++)
        {
            for (int comparePos = pos + 1; comparePos < positionsOfGalaxy.Length; comparePos++)
            {
                totalDistance += Math.Abs(positionsOfGalaxy[pos].x - positionsOfGalaxy[comparePos].x) + Math.Abs(positionsOfGalaxy[pos].y - positionsOfGalaxy[comparePos].y);
            }
        }

        return totalDistance;
    }

    private List<Coord> GetListOfGalaxyCoords(string[] inputLines, long increaseBy) 
    {
        HashSet<int> verticalExpansion = Enumerable.Range(0, inputLines.Length -1).ToHashSet();
        HashSet<int> horizontalExpansion = Enumerable.Range(0, inputLines[0].Length - 1).ToHashSet();

        for (int lineNum = 0; lineNum < inputLines.Length; lineNum++)
        {
            for (int charNum = 0; charNum < inputLines[lineNum].Length; charNum++)
            {
                if (inputLines[lineNum][charNum] == '#')
                {
                    verticalExpansion.Remove(lineNum);
                    horizontalExpansion.Remove(charNum);
                }
            }
        }

        List<Coord> positionsOfGalaxy = new();
        long currentY = 0;

        for (int lineNum = 0; lineNum < inputLines.Length; lineNum++)
        {
            if (verticalExpansion.Contains(lineNum))
            {
                currentY += increaseBy;
                continue;
            }
            
            long currentX = 0;

            for (int charNum = 0; charNum < inputLines[lineNum].Length; charNum++)
            {
                if (horizontalExpansion.Contains(charNum))
                {
                    currentX += increaseBy;
                    continue;
                }

                if (inputLines[lineNum][charNum] == '#')
                {
                    positionsOfGalaxy.Add((charNum + currentX, lineNum + currentY));
                }
            }
        }
        
        return positionsOfGalaxy;
    }
}
