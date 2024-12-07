using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;
public class DaySeven : IPuzzle
{
    public object RunTaskOne(string[] inputLines) =>
        Solve(inputLines, includeConcatenationOperator: false);

    public object RunTaskTwo(string[] inputLines) =>
        Solve(inputLines, includeConcatenationOperator: true);

    private static (long[] testValues, long[][] inputValuesCol) ParseInput(string[] inputLines)
    {
        long[] testValues = new long[inputLines.Length];
        long[][] inputValuesCol = new long[inputLines.Length][];

        for (int i = 0; i < inputLines.Length; i++)
        {
            string[] valueInputSplit = inputLines[i].Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            testValues[i] = long.Parse(valueInputSplit[0]);

            string[] rawInputValues = valueInputSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            inputValuesCol[i] = rawInputValues.Select(long.Parse).ToArray();
        }

        return (testValues, inputValuesCol);
    }

    private static long Solve(string[] inputLines, bool includeConcatenationOperator)
    {
        var (testValues, inputValuesCol) = ParseInput(inputLines);

        long total = 0;

        for (int i = 0; i < inputLines.Length; i++)
        {
            long testValue = testValues[i];
            long[] inputValues = inputValuesCol[i];

            List<long> aggregations = [inputValues[0] * inputValues[1], inputValues[0] + inputValues[1]];

            if (includeConcatenationOperator)
            {
                aggregations.Add(GetConcatenated(inputValues[0], inputValues[1]));
            }

            if (aggregations.Any(l => l == testValue))
            {
                total += testValue;
                continue;
            }

            for (int j = 2; j < inputValues.Length; j++)
            {
                List<long> tempAggregations = [];
                foreach (long aggregation in aggregations)
                {
                    long[] aggs = GetAggregations(aggregation, inputValues[j]);

                    if (j == inputValues.Length - 1 && aggs.Any(a => a == testValue))
                    {
                        total += testValue;
                        break;
                    }

                    tempAggregations.AddRange(aggs.Where(a => a <= testValue));
                }

                aggregations = tempAggregations;
            }
        }

        return total;

        long[] GetAggregations(long aggregation, long currentVal)
        {
            long[] aggs = [aggregation * currentVal, aggregation + currentVal];

            if (includeConcatenationOperator)
            {
                aggs = [.. aggs, GetConcatenated(aggregation, currentVal)];
            }

            return aggs;
        }

        static long GetConcatenated(long aggregation, long currentVal) =>
            (long)(aggregation * Math.Pow(10, Math.Floor(Math.Log10(currentVal) + 1)) + currentVal);
    }
}
