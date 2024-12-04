using System;
using System.ComponentModel;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;

public class DayOne : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        int[][] lists = [new int[inputLines.Length], new int[inputLines.Length]];

        for(var i = 0; i < inputLines.Length; i++)
        {
            string line = inputLines[i];

            var splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (splitLine is not [string sNumberOne, string sNumberTwo] || 
                !int.TryParse(sNumberOne, out int iNumberOne) || 
                !int.TryParse(sNumberTwo, out int iNumberTwo)) 
            {
                return "Failed";
            }

            lists[0][i] = iNumberOne;
            lists[1][i] = iNumberTwo;
        }

        int total = 0;

        var orderedList1 = lists[0].Order();
        var orderedList2 = lists[1].Order();

        var enumerator = orderedList2.GetEnumerator();
        foreach(var item in orderedList1) {
            enumerator.MoveNext();
            int output = Math.Abs(item - enumerator.Current);
            total += output;
        }
        return total;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        throw new NotImplementedException();
    }
}
