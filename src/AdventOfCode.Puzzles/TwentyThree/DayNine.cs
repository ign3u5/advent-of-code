using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

public class DayNine : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        return GetTotal(inputLines, (curr, diff) => curr[^1] + diff);
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return GetTotal(inputLines, (curr, diff) => curr[0] - diff);
    }

    private delegate long PredictionCalculator(long[] currPattern, long diff);

    private long GetTotal(string[] inputLines, PredictionCalculator predictionCalculator)
    {
        long total = 0;
        foreach (string line in inputLines)
        {
            List<long[]> oasisNetwork = [line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray()];

            int currentDepth = 0;

            while (oasisNetwork[currentDepth].Any(x => x != 0))
            {
                oasisNetwork.Add(new long[oasisNetwork[currentDepth].Length - 1]);

                long previousReading = oasisNetwork[currentDepth][0];

                for (int measurementNum = 1; measurementNum < oasisNetwork[currentDepth].Length; measurementNum++)
                {
                    long diff = (previousReading - oasisNetwork[currentDepth][measurementNum]) * -1;

                    oasisNetwork[currentDepth + 1][measurementNum - 1] = diff;
                    previousReading = oasisNetwork[currentDepth][measurementNum];
                }

                currentDepth++;
            }

            long difference = 0;

            for (int depth = currentDepth - 1; depth >= 0; depth--)
            {
                difference = predictionCalculator(oasisNetwork[depth], difference);
            }

            total += difference;
        }

        return total;
    }
}
