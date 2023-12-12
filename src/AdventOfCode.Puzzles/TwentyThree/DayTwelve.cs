using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
using ContiguousElement = (int contH, string pattern);
public class DayTwelve : IPuzzle
{
    // ???.### 1,1,3

    // .??..??...?### 1,1,3
    // .??..

    // ?#?#?#?#?#?#?#? 1,3,1,6
    //   .###.#.######
    // 
    public object RunTaskOne(string[] inputLines)
    {
        long total = 0;
        foreach (var line in inputLines)
        {
            string[] puzzleParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            int[] targetContiguousSizes = puzzleParts[1].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();

            int qs = 0;

            string pattern = puzzleParts[0];

            for (int pNum = 0; pNum < pattern.Length; pNum++)
            {
                if (pattern[pNum] == '?')
                {
                    qs++;
                }
            }

            total += GetArrangements(0, new char[qs]);

            long thing = total;

            long GetArrangements(int currentQ, char[] currentSwap) {
                if (currentQ != qs) {
                    long total = 0;

                    currentSwap[currentQ] = '#';
                    total += GetArrangements(currentQ + 1, currentSwap);

                    currentSwap[currentQ] = '.';
                    total += GetArrangements(currentQ + 1, currentSwap);

                    return total;
                }

                string pattern = puzzleParts[0];
                int qsIndex = 0;
                int contiguousIndex = 0;
                int currentHLength = 0;

                for (var i = 0; i < pattern.Length; i++)
                {
                    char patternChar = pattern[i];

                    if (pattern[i] == '?')
                    {
                        patternChar = currentSwap[qsIndex];
                        qsIndex++;
                    }

                    if (patternChar == '#') {
                        currentHLength++;

                        continue;
                    } 
                    
                    if (currentHLength == targetContiguousSizes[contiguousIndex]) {
                        contiguousIndex++;
                        currentHLength = 0;
                    } else {
                        return 0;
                    }
                }

                return 1;
            }
        }    

        return total;
    }


    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }
}
