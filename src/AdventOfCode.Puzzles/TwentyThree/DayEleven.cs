using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

using Coord = (int x, int y);
public class DayEleven : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        List<Coord> positionsOfGalaxy = new();
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
                    positionsOfGalaxy.Add((charNum, lineNum));
                }
            }
        }



        return 0;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
