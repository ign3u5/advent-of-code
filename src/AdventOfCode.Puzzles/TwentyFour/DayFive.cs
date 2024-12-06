using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;
public class DayFive : IPuzzle
{
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
            int[] curNums = nums;

            bool isChanged = true;

            while (isChanged)
            {
                List<(int num, bool[] notBefore)> cannotComeNextCol = [];

                List<int> newNums = [];

                isChanged = false;
                for (int i = 0; i < curNums.Length; i++)
                {
                    var added = false;
                    int curNum = curNums[i];

                    for (int iNext = 0; iNext < cannotComeNextCol.Count; iNext++)
                    {
                        var numInfo = cannotComeNextCol[iNext];
                        if (numInfo.notBefore[curNum])
                        {
                            newNums.Insert(newNums.IndexOf(numInfo.num), curNum);
                            isValid = false;
                            added = true;
                            isChanged = true;
                            break;
                        }
                    }

                    if (!added)
                    {
                        newNums.Add(curNum);
                    }

                    if (pageOrderingRules[curNum] is { Length: 100 } pageRules)
                    {
                        cannotComeNextCol.Add((curNum, pageRules));
                    }
                }

                curNums = newNums.ToArray();
            }


            if (!isValid)
            {
                int middle = (int)Math.Floor(curNums.Length / 2d);

                total += curNums[middle];
            }
        }

        return total;
    }
}
