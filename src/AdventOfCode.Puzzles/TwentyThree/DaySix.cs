using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DaySix : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        Race[] races = ParseRaces(inputLines);

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

    private Race[] ParseRaces(string[] inputLines)
    {
        var times = inputLines[0].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var distances = inputLines[1].Split(':')[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Race[] races = new Race[times.Length];
        for (int i = 0; i < times.Length; i++)
        {
            races[i] = new Race(int.Parse(times[i]), int.Parse(distances[i]));
        }

        return races;
    }

    private record Race(int Time, int Distance);

    public object RunTaskTwo(string[] inputLines)
    {
        throw new NotImplementedException();
    }
}
