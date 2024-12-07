using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;
public class DaySeven : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
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

        long total = 0;

        for (int i = 0; i < inputLines.Length; i++)
        {
            long testValue = testValues[i];
            long[] inputValues = inputValuesCol[i];

            List<long> aggregations = [inputValues[0] * inputValues[1], inputValues[0] + inputValues[1]];

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
                    long mulAgg = aggregation * inputValues[j];
                    long sumAgg = aggregation + inputValues[j];

                    if (j == inputValues.Length - 1 && (mulAgg == testValue || sumAgg == testValue))
                    {
                        total += testValue;
                        break;
                    }

                    if (mulAgg <= testValue) tempAggregations.Add(mulAgg);
                    if (sumAgg <= testValue) tempAggregations.Add(sumAgg);
                }

                aggregations = tempAggregations;
            }
        }

        return total;
    }

    public object RunTaskTwo(string[] inputLines)
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

        long total = 0;

        for (int i = 0; i < inputLines.Length; i++)
        {
            long testValue = testValues[i];
            long[] inputValues = inputValuesCol[i];

            List<long> aggregations = [inputValues[0] * inputValues[1], inputValues[0] + inputValues[1], (long)(inputValues[0] * Math.Pow(10, Math.Floor(Math.Log10(inputValues[1]) + 1)) + inputValues[1])];

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
                    long mulAgg = aggregation * inputValues[j];
                    long sumAgg = aggregation + inputValues[j];
                    long conAgg = (long)(aggregation * Math.Pow(10, Math.Floor(Math.Log10(inputValues[j]) + 1)) + inputValues[j]);

                    if (j == inputValues.Length - 1 && (mulAgg == testValue || sumAgg == testValue || conAgg == testValue))
                    {
                        total += testValue;
                        break;
                    }

                    if (mulAgg <= testValue) tempAggregations.Add(mulAgg);
                    if (sumAgg <= testValue) tempAggregations.Add(sumAgg);
                    if (conAgg <= testValue) tempAggregations.Add(conAgg);
                }

                aggregations = tempAggregations;
            }
        }

        return total;
    }
}
