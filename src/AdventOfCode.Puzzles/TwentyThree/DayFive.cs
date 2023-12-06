using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayFive : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        long[] seeds = inputLines[0].Split(':')[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToArray();

        List<RangeData> rangeDatas = new();

        for (int lineNo = 2; lineNo < inputLines.Length; lineNo++)
        {
            string line = inputLines[lineNo];

            if (string.IsNullOrWhiteSpace(line))
            {
                UpdateSeeds();
            }

            if (line.Length == 0 || !char.IsDigit(line[0]))
            {
                continue;
            }

            long[] mapParts = line.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToArray();

            rangeDatas.Add(new RangeData(mapParts[0], mapParts[1], mapParts[2]));
        }

        UpdateSeeds();

        return seeds.Min();

        void UpdateSeeds()
        {
            for (int seedNo = 0; seedNo < seeds.Length; seedNo++)
            {
                long seed = seeds[seedNo];

                foreach (RangeData rangeData in rangeDatas)
                {
                    if (seed >= rangeData.SourceRangeStart && seed < rangeData.SourceRangeStart + rangeData.RangeLength)
                    {
                        seeds[seedNo] = rangeData.DestinationRangeStart + (seed - rangeData.SourceRangeStart);
                    }
                }
            }

            rangeDatas = new();
        }
    }

    public object RunTaskTwo(string[] inputLines)
    {
        string[] initialSeeds = inputLines[0].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        List<long> seeders = new();
        for (int iSeedNo = 0; iSeedNo < initialSeeds.Length; iSeedNo += 2)
        {
            var seed = long.Parse(initialSeeds[iSeedNo]);
            var range = long.Parse(initialSeeds[iSeedNo + 1]);
            for (var start = seed; start < seed + range; start++)
            {
                seeders.Add(start);
            }
        }

        long[] seeds = seeders.ToArray();
        long[] ogSeeds = seeds.ToArray();
        Console.WriteLine($"Total seeds {seeds.Length}");

        for (int lineNo = 2; lineNo < inputLines.Length; lineNo++)
        {
            string line = inputLines[lineNo];

            if (string.IsNullOrWhiteSpace(line))
            {
                ogSeeds = seeds.ToArray();
            }

            if (line.Length == 0 || !char.IsDigit(line[0]))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine(line);
                }

                continue;
            }

            string[] mapParts = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            long sourceRangeStart = long.Parse(mapParts[1]);
            long destinationRangeStart = long.Parse(mapParts[0]);
            long rangeLength = long.Parse(mapParts[2]);

            for (int seedNo = 0; seedNo < seeds.Length; seedNo++)
            {
                long seed = ogSeeds[seedNo];
                if (seed >= sourceRangeStart && seed < sourceRangeStart + rangeLength)
                {
                    seeds[seedNo] = destinationRangeStart + (seed - sourceRangeStart);
                }
            }
        }

        return seeds.Min();
    }

    private record struct RangeData(long DestinationRangeStart, long SourceRangeStart, long RangeLength);
}
