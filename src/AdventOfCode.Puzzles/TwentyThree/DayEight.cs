using System.Diagnostics;
using System.Security.Cryptography;
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

        return nodeSteps.Aggregate(Maths.LowestCommonMultiple);
    }

    private static List<long> CalculateStepsForNodes(Func<string, bool> isStartOfPath, Func<string, bool> isEndOfPath, string lRInstructions, Dictionary<string, (string L, string R)> nodes)
    {
        List<long> nodeSteps = [];

        var startingNodeKeys = nodes.Keys.Where(isStartOfPath);

        foreach (var startingNodeKey in startingNodeKeys)
        {
            bool reachedEnd = false;
            int stepsForNode = 0;
            var nextNode = startingNodeKey;

            while (!reachedEnd)
            {
                char currentInstruction = lRInstructions[stepsForNode % lRInstructions.Length];

                nextNode = currentInstruction switch
                {
                    'L' => nodes[nextNode].L,
                    'R' => nodes[nextNode].R,
                    _ => throw new UnreachableException()
                };

                reachedEnd = isEndOfPath(nextNode);

                stepsForNode++;
            }

            nodeSteps.Add(stepsForNode);
        }

        return nodeSteps;
    }
}
