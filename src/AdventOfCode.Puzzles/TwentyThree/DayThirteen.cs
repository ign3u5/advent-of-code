using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayThirteen : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        List<List<string>> puzzles = GetPuzzles();

        int total = 0;

        foreach (var puzzle in puzzles)
        {
            // check vertical symmetry
            for (int x = 0; x < puzzle.Count; x++)
            {
                var (isVerticalSymmetrical, column) = CheckSymmetry(puzzle, 0, puzzle[0].Length - 1);

                if (isVerticalSymmetrical)
                {
                    total += column;
                    break;
                }
            }

            int thing = total;
            //for (var x = 0; x < puzzle.Count; x++)
            //{
            //    for (var compareX = x + 1; x < puzzle.Count; compareX+=2)
            //    {
            //        bool isSymmetrical = true;
            //        for (int y = 0; y < puzzle[x].Length; y++)
            //        {
            //            if (puzzle[x][y] != puzzle[compareX][y])
            //            {
            //                isSymmetrical = false;
            //            }
            //        }
            //    }
            //}
        }

        return 0;

        (bool, int) CheckSymmetry(List<string> puzzle, int startingX, int maxCompareX)
        {
            for (var compareX = startingX + 1; compareX < maxCompareX; compareX += 2)
            {
                bool isSymmetrical = true;
                for (int y = 0; y < puzzle[startingX].Length; y++)
                {
                    if (puzzle[startingX][y] != puzzle[compareX][y])
                    {
                        isSymmetrical = false;
                        break;
                    }
                }

                if (isSymmetrical)
                {
                    if (compareX == startingX + 1)
                    {
                        return (true, startingX);
                    }

                    return CheckSymmetry(puzzle, startingX + 1, compareX);
                }

            }

            return (false, 0);
        }

        List<List<string>> GetPuzzles()
        {
            List<List<string>> puzzles = [[]];
            int currentPuzzle = 0;

            foreach (string line in inputLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    currentPuzzle++;
                    puzzles.Add(new List<string>());
                    continue;
                }

                puzzles[currentPuzzle].Add(line);
            }

            return puzzles;
        }
    }


    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
