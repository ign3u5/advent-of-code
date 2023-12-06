using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayThree : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        int total = 0;

        for (int lNum = 0; lNum < inputLines.Length; lNum++)
        {
            string currentLine = inputLines[lNum];
            int currentNum = 0;
            bool currentNumCounts = false;

            for (int cNum = 0; cNum < currentLine.Length; cNum++)
            {
                char currentChar = currentLine[cNum];

                if (!char.IsDigit(currentChar))
                {
                    if (currentNumCounts)
                    {
                        total += currentNum;
                    }

                    currentNumCounts = false;
                    currentNum = 0;

                    continue;
                }

                bool isTopLine = lNum == 0;
                bool isBottomLine = lNum == inputLines.Length - 1;
                bool isFirstChar = cNum == 0;
                bool isLastChar = cNum == currentLine.Length - 1;

                bool isSpecialN = !isTopLine && isSpecial(0, -1);
                bool isSpecialS = !isBottomLine && isSpecial(0, 1);
                bool isSpecialW = !isFirstChar && isSpecial(-1, 0);
                bool isSpecialNW = !isFirstChar && !isTopLine && isSpecial(-1, -1);
                bool isSpecialSW = !isFirstChar && !isBottomLine && isSpecial(-1, 1);
                bool isSpecialE = !isLastChar && isSpecial(1, 0);
                bool isSpecialNE = !isLastChar && !isTopLine && isSpecial(1, -1);
                bool isSpecialSE = !isLastChar && !isBottomLine && isSpecial(1, 1);

                bool isSpecial(int xDelta, int yDelta) => 
                    inputLines[lNum + yDelta][cNum + xDelta] != '.' 
                    && !char.IsDigit(inputLines[lNum + yDelta][cNum + xDelta]);

                if (currentNum == 0)
                {
                    if (isSpecialW || isSpecialNW || isSpecialSW)
                    {
                        AddToCurrentNum(currentChar);
                        continue;
                    }
                }

                if (isSpecialN || isSpecialS || isSpecialE || isSpecialNE || isSpecialSE)
                {
                    AddToCurrentNum(currentChar);
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    currentNum *= 10;
                    currentNum += int.Parse(currentChar.ToString());
                }

                if (isLastChar)
                {
                    if (currentNumCounts)
                    {
                        total += currentNum;
                    }

                    currentNumCounts = false;
                    currentNum = 0;

                    continue;
                }

                void AddToCurrentNum(char c)
                {
                    currentNum *= 10;
                    currentNum += int.Parse(c.ToString());
                    currentNumCounts = true;
                }
            }
        }


        return total;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int total = 0;

        Dictionary<Coord, Gear> gears = new();

        for (int lNum = 0; lNum < inputLines.Length; lNum++)
        {
            string currentLine = inputLines[lNum];
            int currentNum = 0;
            HashSet<Coord> starMatches = new();

            for (int cNum = 0; cNum < currentLine.Length; cNum++)
            {
                bool isTopLine = lNum == 0;
                bool isBottomLine = lNum == inputLines.Length - 1;
                bool isFirstChar = cNum == 0;
                bool isLastChar = cNum == currentLine.Length - 1;
                char currentChar = currentLine[cNum];

                if (!char.IsDigit(currentChar))
                {
                    foreach (var starMatch in starMatches.ToArray())
                    {
                        if (gears.ContainsKey(starMatch))
                        {
                            gears[starMatch] = gears[starMatch] with
                            {
                                numberOfParts = gears[starMatch].numberOfParts + 1,
                                gearRatio = gears[starMatch].gearRatio * currentNum
                            };
                        }
                        else
                        {
                            gears[starMatch] = new Gear(1, currentNum);
                        }
                    }

                    currentNum = 0;
                    starMatches = new();
                    continue;
                }

                bool isSpecialN = !isTopLine && isSpecial(0, -1);
                bool isSpecialS = !isBottomLine && isSpecial(0, 1);
                bool isSpecialW = !isFirstChar && isSpecial(-1, 0);
                bool isSpecialNW = !isFirstChar && !isTopLine && isSpecial(-1, -1);
                bool isSpecialSW = !isFirstChar && !isBottomLine && isSpecial(-1, 1);
                bool isSpecialE = !isLastChar && isSpecial(1, 0);
                bool isSpecialNE = !isLastChar && !isTopLine && isSpecial(1, -1);
                bool isSpecialSE = !isLastChar && !isBottomLine && isSpecial(1, 1);

                bool isSpecial(int xDelta, int yDelta) => inputLines[lNum + yDelta][cNum + xDelta] == '*';

                if (isSpecialN)
                {
                    AddToCurrentNum(currentChar, new(cNum, lNum - 1));
                    continue;
                }

                if (isSpecialS)
                {
                    AddToCurrentNum(currentChar, new(cNum, lNum + 1));
                    continue;
                }

                if (currentNum == 0)
                {
                    if (isSpecialW)
                    {
                        AddToCurrentNum(currentChar, new(cNum - 1, lNum));
                        continue;
                    }
                    if (isSpecialNW)
                    {
                        AddToCurrentNum(currentChar, new(cNum - 1, lNum - 1));
                        continue;
                    }
                    if (isSpecialSW)
                    {
                        AddToCurrentNum(currentChar, new(cNum - 1, lNum + 1));
                        continue;
                    }
                }

                if (isSpecialE)
                {
                    AddToCurrentNum(currentChar, new(cNum + 1, lNum));
                    continue;
                }
                if (isSpecialNE)
                {
                    AddToCurrentNum(currentChar, new(cNum + 1, lNum - 1));
                    continue;
                }
                if (isSpecialSE)
                {
                    AddToCurrentNum(currentChar, new(cNum + 1, lNum + 1));
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    currentNum *= 10;
                    currentNum += int.Parse(currentChar.ToString());
                }

                if (isLastChar)
                {
                    foreach (var starMatch in starMatches.ToArray())
                    {
                        if (gears.ContainsKey(starMatch))
                        {
                            gears[starMatch] = gears[starMatch] with
                            {
                                numberOfParts = gears[starMatch].numberOfParts + 1,
                                gearRatio = gears[starMatch].gearRatio * currentNum
                            };
                        }
                        else
                        {
                            gears[starMatch] = new Gear(1, currentNum);
                        }
                    }

                    currentNum = 0;
                    starMatches = new();

                    continue;
                }

                void AddToCurrentNum(char c, Coord coordOfStar)
                {
                    currentNum *= 10;
                    currentNum += int.Parse(c.ToString());
                    starMatches.Add(coordOfStar);
                }
            }
        }

        foreach (var gear in gears)
        {
            if (gear.Value.numberOfParts == 2)
            {
                total += gear.Value.gearRatio;
            }
        }

        return total;
    }

    private record Coord(int X, int Y);

    private record Gear(int numberOfParts, int gearRatio);
}
