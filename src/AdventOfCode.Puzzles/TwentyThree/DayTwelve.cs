using AdventOfCode.Common;
using System;

namespace AdventOfCode.Puzzles.TwentyThree;
using ContiguousElement = (int contH, string pattern);
public class DayTwelve : IPuzzle
{
    //???.### 1,1,3
    public object RunTaskOne(string[] inputLines)
    {
        foreach (var line in inputLines)
        {
            string[] puzzleParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            int[] targetContiguousSizes = puzzleParts[1].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();

            List<ContiguousElement> contiguousElements = [];


            int contiguousElementsCount = -1;
            bool inContiguousElement = false;
            bool inContiguousHash = false;

            foreach (char c in puzzleParts[0])
            {
                if (c == '.' && inContiguousElement)
                {
                    inContiguousElement = false;
                    inContiguousHash = false;

                    continue;
                }

                if (c == '#')
                {
                    if (!inContiguousElement)
                    {
                        inContiguousElement = true;
                        inContiguousHash = true;
                        contiguousElements.Add((1, "#"));
                        contiguousElementsCount++;

                        continue;
                    }

                    var (elH, pat) = contiguousElements[contiguousElementsCount];
                    
                    contiguousElements[contiguousElementsCount] = (inContiguousHash ? elH + 1 : elH, $"{pat}#");

                    continue;
                }

                if (c == '?')
                {
                    inContiguousHash = false;
                    if (!inContiguousElement)
                    {
                        inContiguousElement = true;
                        contiguousElements.Add((0, "?"));
                        contiguousElementsCount++;

                        continue;
                    }

                    var (elH, pat) = contiguousElements[contiguousElementsCount];
                    contiguousElements[contiguousElementsCount] = (elH, $"{pat}?");
                    continue;
                }
            }

            int elementNum = contiguousElements.Count - 1;

            for (int tNum = targetContiguousSizes.Length - 1; tNum >= 0; tNum--)
            {
                for (int elNum = elementNum; elementNum >= 0; elNum--)
                {
                    // Skip any that aren't big enough and don't check again
                    if (contiguousElements[elNum].pattern.Length < targetContiguousSizes[tNum])
                    {
                        elementNum--;
                        
                        continue;
                    }


                }
            }

            int thing = 0;
        }

        return 0;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
