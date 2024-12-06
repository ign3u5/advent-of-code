using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles.TwentyFour;
public class DayFive : IPuzzle
{
    // 5243 too low
    public object RunTaskOne(string[] inputLines)
    {
        bool isPageOrderingRules = true;

        bool[][] pageOrderingRules = new bool[100][];

        List<int[]> inputs = new List<int[]>();

        int total = 0;

        for (int i = 0; i < inputLines.Length; i++)
        {
            string curLine = inputLines[i];

            if (isPageOrderingRules && (string.IsNullOrWhiteSpace(curLine) || curLine[2] == ','))
            {
                isPageOrderingRules = false;

                if (string.IsNullOrWhiteSpace(curLine)) continue;
            }

            if (isPageOrderingRules)
            {
                string[] rawNums = curLine.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                (int first, int last) = (int.Parse(rawNums[0]), int.Parse(rawNums[1]));

                if (pageOrderingRules[last] is not { Length: 100 } pageRules)
                {
                    pageOrderingRules[last] = new bool[100];
                }

                pageOrderingRules[last][first] = true;
            }

            if (!isPageOrderingRules)
            {
                string[] rawNums = curLine.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                int[] nums = rawNums.Select(int.Parse).ToArray();

                inputs.Add(nums);
            }
        }

        int count = 0;

        foreach (int[] nums in inputs)
        {
            count++;
            bool isValid = true;

            List<bool[]> cannotComeNextCol = [];

            for (int i = 0; i < nums.Length; i++)
            {
                foreach (bool[] cannotComeNext in cannotComeNextCol)
                {
                    if (cannotComeNext[nums[i]])
                    {
                        isValid = false;
                        break;
                    }
                }
                
                if (pageOrderingRules[nums[i]] is { Length: 100 } pageRules)
                {
                    cannotComeNextCol.Add(pageRules);
                }

                if (!isValid) break;
            }

            if (isValid)
            {
                int middle = (int)Math.Floor(nums.Length / 2d);

                total += nums[middle];
            }
        }

        return total;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
