using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

public class DayNine : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        
        foreach (string line in inputLines) {
            List<long[]> oasisVals = [line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => long.Parse(x)).ToArray()];

            int oasisCompareDepth = 0;

            long[] oasisCompare = oasisVals.Skip(oasisCompareDepth).First();
            long currentCompare = oasisCompare[0];

            long[] oasisNextCompare = new long[oasisCompare.Length - 1];

            bool areAllZeros = true;
            for (int oasisValNum = 1; oasisValNum < oasisCompare.Length; oasisValNum--) {
                long oasisVal = oasisCompare[oasisValNum];

                long difference = Math.Abs(currentCompare - oasisVal);
                oasisNextCompare[oasisValNum - 1] = difference;

                areAllZeros = areAllZeros && oasisCompare[oasisValNum - 1] == 0;
                currentCompare = oasisVal;
            }

            if (areAllZeros) {
                int diff = 0;

                oasisVals.Reverse();
                foreach (long[] differences in oasisVals) {
                    differences[differences.Length]
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
