using System.Diagnostics;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;

public class DayEight : IPuzzle
{
    public object RunTaskOne(string[] inputLines) => GetMinimumNodeSteps(inputLines, 
            isStartOfPath: node => node == "AAA",
            isEndOfPath: node => node == "ZZZ");

    public object RunTaskTwo(string[] inputLines) => GetMinimumNodeSteps(inputLines, 
            isStartOfPath: node => node[2] == 'A',
            isEndOfPath: node => node[2] == 'Z');

    private static long GetMinimumNodeSteps(string[] inputLines, Func<string, bool> isStartOfPath, Func<string, bool> isEndOfPath) {
        string instructions = inputLines[0];

        Dictionary<string, (string L, string R)> nodes = inputLines
            .Skip(1)
            .ToDictionary(l => l[..3], l => (l[7..10], l[12..^1]));

        List<long> nodeSteps = CalculateStepsForNodes(
            isStartOfPath,
            isEndOfPath,
            instructions, nodes);

        // Find the minimum number of steps (which could mean looping) before all paths reach their end node
        // e.g. if they were to reach their end in 5, 12, and 10 respectively, the minimum number of steps would be 60.
        // The first would have to loop 12 times, the second 5 times, and the third 6 times.
        return nodeSteps.Aggregate(Maths.LowestCommonMultiple);
    }

    private static List<long> CalculateStepsForNodes(Func<string, bool> isStartOfPath, Func<string, bool> isEndOfPath, string lRInstructions, Dictionary<string, (string L, string R)> nodes)
    {
        List<long> nodeSteps = [];

        IEnumerable<string> startingNodeKeys = nodes.Keys.Where(isStartOfPath);

        foreach (string startingNodeKey in startingNodeKeys)
        {
            int stepsForNode = 0;
            string nextNode = startingNodeKey;

            while (!isEndOfPath(nextNode))
            {
                char currentInstruction = lRInstructions[stepsForNode % lRInstructions.Length];

                nextNode = currentInstruction switch
                {
                    'L' => nodes[nextNode].L,
                    'R' => nodes[nextNode].R,
                    _ => throw new UnreachableException()
                };

                stepsForNode++;
            }

            nodeSteps.Add(stepsForNode);
        }

        return nodeSteps;
    }
}
