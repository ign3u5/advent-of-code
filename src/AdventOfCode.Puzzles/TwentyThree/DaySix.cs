using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DaySix : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        Race[] races = ParseRaces(inputLines, separateRaces: true);

        return SolveRaces(races);
    }
    public object RunTaskTwo(string[] inputLines)
    {
        Race[] races = ParseRaces(inputLines, separateRaces: false);

        return SolveRaces(races);
    }
    
    private Race[] ParseRaces(string[] inputLines, bool separateRaces)
    {
        var times = inputLines[0].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distances = inputLines[1].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return separateRaces ? GetAsSeparateRaces() : [GetAsSingleRace()];

        Race[] GetAsSeparateRaces()
        {
            Race[] races = new Race[times.Length];
            for (int i = 0; i < times.Length; i++)
            {
                races[i] = new Race(double.Parse(times[i]), double.Parse(distances[i]));
            }

            return races;
        }

        Race GetAsSingleRace()
        {
            double timeMulitplier = 1;
            double distanceMultiplier = 1;
            double time = 0;
            double distance = 0;
            for (int i = times.Length - 1; i >= 0; i--)
            {
                time += double.Parse(times[i]) * timeMulitplier;
                distance += double.Parse(distances[i]) * distanceMultiplier;

                timeMulitplier *= Math.Pow(10, times[i].Length);
                distanceMultiplier *= Math.Pow(10, distances[i].Length);
            }

            return new(time, distance);
        }
    }

    private record Race(double Time, double Distance);

    private double SolveRaces(Race[] races)
    {
        double total = 1;

        foreach (var race in races)
        {
            double numberOfWinningRaces = 0;
            double lowerCenter = Math.Floor(race.Time / 2);
            double upperCenter = race.Time % 2 == 0 ? lowerCenter : lowerCenter + 1;

            for (double timeDelta = 0; timeDelta < lowerCenter; timeDelta++)
            {
                double prospectiveDistance = (lowerCenter - timeDelta) * (upperCenter + timeDelta);

                if (prospectiveDistance > race.Distance)
                {
                    numberOfWinningRaces++;
                }
            }

            numberOfWinningRaces = race.Time % 2 == 0 ? numberOfWinningRaces * 2 - 1 : numberOfWinningRaces * 2;

            total *= numberOfWinningRaces;
        }

        return total;
    }
}
