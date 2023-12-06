using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DaySix : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        Race<int>[] races = ParseRaces(inputLines);

        var total = 1;

        foreach (var race in races)
        {
            int numberOfWinningRaces = 0;
            int lowerCenter = race.Time / 2;
            int upperCenter = race.Time % 2 == 0 ? lowerCenter : lowerCenter + 1;

            for (int timeDelta = 0; timeDelta < lowerCenter; timeDelta++)
            {
                int prospectiveDistance = (lowerCenter - timeDelta) * (upperCenter + timeDelta);

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

    private Race<int>[] ParseRaces(string[] inputLines)
    {
        var times = inputLines[0].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distances = inputLines[1].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Race<int>[] races = new Race<int>[times.Length];
        for (int i = 0; i < times.Length; i++)
        {
            races[i] = new Race<int>(int.Parse(times[i]), int.Parse(distances[i]));
        }

        return races;
    }
    
    private Race<double> ParseRacesPartTwo(string[] inputLines)
    {
        var times = inputLines[0].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distances = inputLines[1].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        double timeMulitplier = 1;
        double distanceMultiplier = 1;
        double time = 0;
        double distance = 0;
        for (int i = times.Length - 1; i >= 0; i--)
        {
            time += double.Parse(times[i]) * timeMulitplier;
            distance += double.Parse(distances[i]) * distanceMultiplier;

            timeMulitplier *= Math.Pow(10, times[i].Length);
            distanceMultiplier *= Math.Pow(10,distances[i].Length);
        }

        return new(time, distance);
    }

    private record Race<T>(T Time, T Distance);

    public object RunTaskTwo(string[] inputLines)
    {
        Race<double> race = ParseRacesPartTwo(inputLines);

        double total = 1;

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

        return total;
    }
}
