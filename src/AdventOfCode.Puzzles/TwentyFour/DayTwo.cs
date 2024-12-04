using System;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;

public class DayTwo : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        const int maxDiff = 3;

        int[][] reports = inputLines.Select(report => report.Split(' ').Select(level => int.Parse(level)).ToArray()).ToArray();

        int total = 0;

        for (int iReport = 0; iReport < reports.Length; iReport++)
        {
            int[] report = reports[iReport];

            int direction = 0;

            for (int iLevel = 0; iLevel < report.Length - 1; iLevel++)
            {
                if (report[iLevel] == report[iLevel + 1] || Math.Abs(report[iLevel] - report[iLevel + 1]) > maxDiff)
                {
                    direction = 0;
                    break;
                }

                if (report[iLevel] < report[iLevel + 1])
                {
                    if (direction == -1)
                    {
                        direction = 0;
                        break;
                    }

                    direction = 1;
                }

                if (report[iLevel] > report[iLevel + 1])
                {
                    if (direction == 1)
                    {
                        direction = 0;
                        break;
                    }

                    direction = -1;
                }
            }

            if (direction != 0)
            {
                total++;
            }
        }

        return total;
    }

    // 618 is too low
    public object RunTaskTwo(string[] inputLines)
    {
        const int maxDiff = 3;

        int[][] reports = inputLines.Select(report => report.Split(' ').Select(level => int.Parse(level)).ToArray()).ToArray();

        int total = 0;

        for (int iReport = 0; iReport < reports.Length; iReport++)
        {
            int[] report = reports[iReport];

            if (!IsReportValid(report)) {
                bool isValid = false;

                for (int iLevel = 0; iLevel < report.Length; iLevel++) {
                    isValid = IsReportValid([.. report.Take(iLevel), .. report.Skip(iLevel + 1)]);
                    if (isValid) break;
                }

                if (!isValid) continue;
            }
            
            total++;


        }


        return total;
    }

    private bool IsReportValid(int[] report)
    {
        const int maxDiff = 3;
        int direction = 0;

        for (int iLevel = 0; iLevel < report.Length - 1; iLevel++)
        {
            if (report[iLevel] == report[iLevel + 1] || Math.Abs(report[iLevel] - report[iLevel + 1]) > maxDiff)
            {
                direction = 0;
                break;
            }

            if (report[iLevel] < report[iLevel + 1])
            {
                if (direction == -1)
                {
                    direction = 0;
                    break;
                }

                direction = 1;
            }

            if (report[iLevel] > report[iLevel + 1])
            {
                if (direction == 1)
                {
                    direction = 0;
                    break;
                }

                direction = -1;
            }
        }

        return direction != 0;
    }
}
