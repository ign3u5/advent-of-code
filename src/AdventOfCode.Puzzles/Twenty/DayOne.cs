using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.Twenty;
public class DayOne : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        bool[] values = new bool[2019];

        foreach (string line in inputLines)
        {
            int val = int.Parse(line);

            if (values[2020 - val]) return val * (2020 - val);

            values[int.Parse(line)] = true;
        }

        return 0;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int[] orderedVals = [.. inputLines.Select(int.Parse).OrderDescending()];

        bool tooBig = false;

        for (int i = 0; i < orderedVals.Length; i++)
        {
            for (int lowestI = orderedVals.Length - 1; lowestI > i + 1; lowestI--)
            {
                tooBig = false;

                for (int midI = lowestI - 1; midI > i; midI--)
                {
                    int currentTotal = orderedVals[i] + orderedVals[midI] + orderedVals[lowestI];
                    if (currentTotal > 2020)
                    {
                        if (midI > lowestI - 3)
                        {
                            tooBig = true;

                            break;
                        }

                        break;
                    }

                    if (currentTotal == 2020) return orderedVals[i] * orderedVals[midI] * orderedVals[lowestI];
                }

                if (tooBig) break;
            }

            if (tooBig) continue;
        }

        return 0;
    }
}
