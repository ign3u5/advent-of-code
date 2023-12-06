using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayTwo : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        var idTotal = 0;
        foreach (var line in inputLines)
        {
            string[] gameSplit = line.Split(':');

            int currentId = int.Parse(gameSplit[0].AsSpan(gameSplit[0].IndexOf(' ')..));
            bool isGameValid = true;

            string[] gameSets = gameSplit[1].Split(';');
            foreach (string gameSet in gameSets)
            {
                var splitByColours = gameSet.Split(',');

                foreach (string colourData in splitByColours)
                {
                    string[] colourDataSplit = colourData.Trim().Split(' ');

                    int totalCubesOfColour = int.Parse(colourDataSplit[0].Trim());
                    string colour = colourDataSplit[1].Trim();

                    if (!IsColourValid(colour, totalCubesOfColour))
                    {
                        isGameValid = false;
                        break;
                    }
                }

                if (!isGameValid)
                {
                    break;
                }
            }

            if (isGameValid)
            {
                idTotal += currentId;
            }
        }

        return idTotal;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        var powerTotal = 0;
        foreach (var line in inputLines)
        {
            Dictionary<string, int> cubeColourTotals = new()
            {
                ["red"] = 0,
                ["green"] = 0,
                ["blue"] = 0
            };

            string[] gameSplit = line.Split(':');

            string[] gameSets = gameSplit[1].Split(';');
            foreach (string gameSet in gameSets)
            {
                var splitByColours = gameSet.Split(',');

                foreach (string colourData in splitByColours)
                {
                    string[] colourDataSplit = colourData.Trim().Split(' ');

                    string colour = colourDataSplit[1].Trim();
                    int totalCubesOfColour = int.Parse(colourDataSplit[0].Trim());

                    UpdateMaxCubesOfColour(colour, totalCubesOfColour);
                }
            }

            powerTotal += cubeColourTotals["red"] * cubeColourTotals["green"] * cubeColourTotals["blue"];

            void UpdateMaxCubesOfColour(string colour, int total)
            {
                if (cubeColourTotals[colour] < total)
                {
                    cubeColourTotals[colour] = total;
                }
            }
        }

        return powerTotal;
    }

    private bool IsColourValid(string colour, int total) => colour switch
    {
        "red" => total <= 12,
        "green" => total <= 13,
        "blue" => total <= 14,
        _ => false
    };
}
