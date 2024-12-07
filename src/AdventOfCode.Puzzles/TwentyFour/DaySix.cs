using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyFour;

public class DaySix : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        HashSet<(int x, int y)> obstructionPoints = [];
        bool[][] obstructPoints = new bool[inputLines[0].Length][];
        bool[][] distinctGuardPositions = new bool[inputLines[0].Length][];
        (int x, int y) guardPoint = (0, 0);

        for (int y = 0; y < inputLines.Length; y++)
        {
            for (int x = 0; x < inputLines[y].Length; x++)
            {
                if (y == 0)
                {
                    obstructPoints[x] = new bool[inputLines.Length];
                    distinctGuardPositions[x] = new bool[inputLines.Length];
                }

                if (inputLines[y][x] == '^')
                {
                    guardPoint = (x, y);
                    continue;
                }

                if (inputLines[y][x] == '#')
                {
                    obstructPoints[x][y] = true;
                    obstructionPoints.Add((x, y));
                    continue;
                }
            }
        }

        bool guardOnMap = true;
        char guardDirection = 'n';

        while (guardOnMap)
        {
            if (guardDirection == 'n')
            {
                distinctGuardPositions[guardPoint.x][guardPoint.y] = true;

                if (guardPoint.y == 0)
                {
                    guardOnMap = false;
                    break;
                }

                if (obstructPoints[guardPoint.x][guardPoint.y - 1])
                {
                    guardDirection = 'e';
                }
                else
                {
                    guardPoint = (guardPoint.x, guardPoint.y - 1);
                }
            }

            else if (guardDirection == 'e')
            {
                distinctGuardPositions[guardPoint.x][guardPoint.y] = true;

                if (guardPoint.x == inputLines[0].Length - 1)
                {
                    guardOnMap = false;
                    break;
                }

                if (obstructPoints[guardPoint.x + 1][guardPoint.y])
                {
                    guardDirection = 's';
                }
                else
                {
                    guardPoint = (guardPoint.x + 1, guardPoint.y);
                }
            }

            else if (guardDirection == 's')
            {
                distinctGuardPositions[guardPoint.x][guardPoint.y] = true;

                if (guardPoint.y == inputLines.Length - 1)
                {
                    guardOnMap = false;
                    break;
                }

                if (obstructPoints[guardPoint.x][guardPoint.y + 1])
                {
                    guardDirection = 'w';
                }
                else
                {
                    guardPoint = (guardPoint.x, guardPoint.y + 1);
                }
            }

            else if (guardDirection == 'w')
            {
                distinctGuardPositions[guardPoint.x][guardPoint.y] = true;

                if (guardPoint.x == 0)
                {
                    guardOnMap = false;
                    break;
                }

                if (obstructPoints[guardPoint.x - 1][guardPoint.y])
                {
                    guardDirection = 'n';
                }
                else
                {
                    guardPoint = (guardPoint.x - 1, guardPoint.y);
                }
            }
        }

        int distinctPositionsTotal = distinctGuardPositions.SelectMany(x => x).Count(x => x);

        return distinctPositionsTotal;
    }

    // 380 too low & 381 too low & 382 too low
    public object RunTaskTwo(string[] inputLines)
    {
        HashSet<(int x, int y)> obstructionPoints = [];
        (bool exists, char[] dirs)[][] obstructPoints = new (bool, char[])[inputLines[0].Length][];
        List<(int x, int y, char dir)> guardPositions = [];
        (int x, int y) guardPoint = (0, 0);

        for (int y = 0; y < inputLines.Length; y++)
        {
            for (int x = 0; x < inputLines[y].Length; x++)
            {
                if (y == 0)
                {
                    obstructPoints[x] = new (bool, char[])[inputLines.Length];
                }

                if (inputLines[y][x] == '^')
                {
                    guardPoint = (x, y);
                    continue;
                }

                if (inputLines[y][x] == '#')
                {
                    obstructPoints[x][y] = (true, []);
                    obstructionPoints.Add((x, y));
                    continue;
                }
            }
        }

        bool guardOnMap = true;
        char guardDirection = 'n';

        int curNCount = 0;
        int curECount = 0;
        int curSCount = 0;
        int curWCount = 0;

        // if I can hit the same obstruction again from the same direction by doing a right turn, then that is a loop

        List<(int x, int y)> newObstacle = [];

        int loopCount = 0;

        while (guardOnMap)
        {
            if (guardDirection == 'n')
            {
                guardPositions.Add((guardPoint.x, guardPoint.y, 'n'));

                if (guardPoint.y == 0)
                {
                    guardOnMap = false;
                    break;
                }

                for (var x = guardPoint.x; x < inputLines[0].Length; x++)
                {
                    var obstPoint = obstructPoints[x][guardPoint.y];

                    if (obstPoint.exists)
                    {
                        if (obstPoint.dirs.Contains('e'))
                        {
                            newObstacle.Add((guardPoint.x, guardPoint.y - 1));
                            loopCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (obstructPoints[guardPoint.x][guardPoint.y - 1] is { exists: true } obstructPoint)
                {
                    guardDirection = 'e';
                    obstructPoints[guardPoint.x][guardPoint.y - 1] = (true, [.. obstructPoint.dirs, 'n']);
                }
                else
                {
                    guardPoint = (guardPoint.x, guardPoint.y - 1);
                }
            }

            else if (guardDirection == 'e')
            {
                guardPositions.Add((guardPoint.x, guardPoint.y, 'e'));

                if (guardPoint.x == inputLines[0].Length - 1)
                {
                    guardOnMap = false;
                    break;
                }

                for (var y = guardPoint.y; y < inputLines.Length; y++)
                {
                    var obstPoint = obstructPoints[guardPoint.x][y];

                    if (obstPoint.exists)
                    {
                        if (obstPoint.dirs.Contains('s'))
                        {
                            newObstacle.Add((guardPoint.x + 1, guardPoint.y));
                            loopCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (obstructPoints[guardPoint.x + 1][guardPoint.y] is { exists: true } obstructPoint)
                {
                    guardDirection = 's';
                    obstructPoints[guardPoint.x + 1][guardPoint.y] = (true, [.. obstructPoint.dirs, 'e']);
                }
                else
                {
                    guardPoint = (guardPoint.x + 1, guardPoint.y);
                }
            }

            else if (guardDirection == 's')
            {
                guardPositions.Add((guardPoint.x, guardPoint.y, 's'));

                if (guardPoint.y == inputLines.Length - 1)
                {
                    guardOnMap = false;
                    break;
                }

                for (var x = guardPoint.x; x > -1; x--)
                {
                    var obstPoint = obstructPoints[x][guardPoint.y];

                    if (obstPoint.exists)
                    {
                        if (obstPoint.dirs.Contains('w'))
                        {
                            newObstacle.Add((guardPoint.x, guardPoint.y + 1));
                            loopCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (obstructPoints[guardPoint.x][guardPoint.y + 1] is { exists: true } obstructPoint)
                {
                    guardDirection = 'w';
                    obstructPoints[guardPoint.x][guardPoint.y + 1] = (true, [.. obstructPoint.dirs, 's']);
                }
                else
                {
                    guardPoint = (guardPoint.x, guardPoint.y + 1);
                }
            }

            else if (guardDirection == 'w')
            {
                guardPositions.Add((guardPoint.x, guardPoint.y, 'w'));

                if (guardPoint.x == 0)
                {
                    guardOnMap = false;
                    break;
                }

                for (var y = guardPoint.y; y > -1; y--)
                {
                    var obstPoint = obstructPoints[guardPoint.x][y];

                    if (obstPoint.exists)
                    {
                        if (obstPoint.dirs.Contains('n'))
                        {
                            newObstacle.Add((guardPoint.x - 1, guardPoint.y));
                            loopCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (obstructPoints[guardPoint.x - 1][guardPoint.y] is { exists: true } obstructPoint)
                {
                    guardDirection = 'n';
                    obstructPoints[guardPoint.x - 1][guardPoint.y] = (true, [.. obstructPoint.dirs, 'w']);
                }
                else
                {
                    guardPoint = (guardPoint.x - 1, guardPoint.y);
                }
            }
        }

        return loopCount;
    }
}
