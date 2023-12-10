using System.Runtime.CompilerServices;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayTen : IPuzzle
{
    public object RunTaskTwo(string[] inputLines)
    {
        Coord startingCoord = new(0, 0);

        Dictionary<Coord, char> map = inputLines
            .SelectMany((line, y) => line.Select((c, x) => {
                if (c == 'S') {
                    startingCoord = new Coord(x, y);
                }
                return (new Coord(x, y), c);
                }))
            .ToDictionary(x => x.Item1, x => x.Item2);

        Direction[] allDirections = [Direction.North, Direction.East, Direction.South, Direction.West];

        (Direction outboundDirection, Coord coord) nextMove = (Direction.North, startingCoord);
        int numberOfMoves = 0;

        HashSet<Coord> encapsed = new();
        HashSet<Coord> pipe = new();

        var firstMove = nextMove;

        foreach (var direction in allDirections) {
            if (IsValidPipe(startingCoord, direction)) {
                nextMove = new(direction, GetNextCoord(startingCoord, direction));
                break;
            }
        }
        firstMove = nextMove;
        int whichSide = 1; // 0 = left, 1 = right

        while (map.TryGetValue(nextMove.coord, out var c) && c != 'S') {
            pipe.Add(nextMove.coord);
            nextMove = CoordTranslator(nextMove.coord, nextMove.outboundDirection);
            numberOfMoves++;
        }

        nextMove = firstMove;
        
        while (map.TryGetValue(nextMove.coord, out var c) && c != 'S') {
            PipeAdder(nextMove.coord, nextMove.outboundDirection);
            nextMove = CoordTranslator(nextMove.coord, nextMove.outboundDirection);
        }

        int totalEncapsed = 0;
        List<Coord> encapsedList = new();

        foreach(var coord in encapsed) {
            if (!pipe.Contains(coord)) {
                if (coord == startingCoord) {
                    continue;
                }
                totalEncapsed++;
                encapsedList.Add(coord);
            }
        }

        return totalEncapsed;

        void PipeAdder(Coord coord, Direction inboundDirection) {
            if (map[coord] == '7') {
                if ((inboundDirection == Direction.North && whichSide == 1) || (inboundDirection == Direction.East && whichSide == 0)) {
                    var coordPos = new Coord(coord.X + 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X + 1, coordPos.Y);
                    }
                    coordPos = new Coord(coord.X, coord.Y - 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y - 1);
                    }
                }
            }
            if (map[coord] == 'F') {
                if ((inboundDirection == Direction.North && whichSide == 0) || (inboundDirection == Direction.West && whichSide == 1)) {
                    var coordPos = new Coord(coord.X - 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X - 1, coordPos.Y);
                    }
                    coordPos = new Coord(coord.X, coord.Y - 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y - 1);
                    }
                }
            }
            if (map[coord] == 'L') {
                if ((inboundDirection == Direction.South && whichSide == 1) || (inboundDirection == Direction.West && whichSide == 0)) {
                    var coordPos = new Coord(coord.X - 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X - 1, coordPos.Y);
                    }
                    coordPos = new Coord(coord.X, coord.Y + 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y + 1);
                    }
                }
            }
            if (map[coord] == 'J') {
                if ((inboundDirection == Direction.South && whichSide == 0) || (inboundDirection == Direction.East && whichSide == 1)) {
                    var coordPos = new Coord(coord.X + 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X + 1, coordPos.Y);
                    }
                    coordPos = new Coord(coord.X, coord.Y - 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y - 1);
                    }
                }
            }
            if (map[coord] == '|') {
                if ((inboundDirection == Direction.North && whichSide == 1) || (inboundDirection == Direction.South && whichSide == 0)) {
                    var coordPos = new Coord(coord.X + 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X + 1, coordPos.Y);
                    }
                }
                if ((inboundDirection == Direction.North && whichSide == 0) || (inboundDirection == Direction.South && whichSide == 1)) {
                    var coordPos = new Coord(coord.X - 1, coord.Y);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X - 1, coordPos.Y);
                    }
                }
            }
            if (map[coord] == '-') {
                if ((inboundDirection == Direction.East && whichSide == 1) || (inboundDirection == Direction.West && whichSide == 0)) {
                    var coordPos = new Coord(coord.X, coord.Y + 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y + 1);
                    }
                }
                if ((inboundDirection == Direction.East && whichSide == 0) || (inboundDirection == Direction.West && whichSide == 1)) {
                    var coordPos = new Coord(coord.X, coord.Y - 1);
                    while (map.ContainsKey(coordPos) && !pipe.Contains(coordPos)) {
                        encapsed.Add(coordPos);
                        coordPos = new Coord(coordPos.X, coordPos.Y - 1);
                    }
                }
            }
        }

        (Direction outboundDirection, Coord nextCoord) CoordTranslator(Coord incomingCoord, Direction inboundDirection) {
            return inboundDirection switch {
                Direction.North =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == '7' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    true when c == '|' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    true when c == 'F' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.East =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'J' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    true when c == '-' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    true when c == '7' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.South => map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'L' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    true when c == '|' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    true when c == 'J' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.West =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'F' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    true when c == '-' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    true when c == 'L' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    _ => throw new Exception("Invalid pipe")
                },
            };
        }

        bool IsValidPipe(Coord coord, Direction inboundDirection) {
            return inboundDirection switch {
                Direction.North =>  map.TryGetValue(new Coord(coord.X, coord.Y - 1), out var c) && (c == '7' || c == '|' || c == 'F'),
                Direction.East =>  map.TryGetValue(new Coord(coord.X + 1, coord.Y), out var c) && (c == 'J' || c == '-' || c == '7'),
                Direction.South => map.TryGetValue(new Coord(coord.X, coord.Y + 1), out var c) && (c == 'L' || c == '|' || c == 'J'),
                Direction.West =>  map.TryGetValue(new Coord(coord.X - 1, coord.Y), out var c) && (c == 'F' || c == '-' || c == 'L'),
            };
        } 

        Coord GetNextCoord(Coord coord, Direction direction) {
            return direction switch {
                Direction.North => new Coord(coord.X, coord.Y - 1),
                Direction.East => new Coord(coord.X + 1, coord.Y),
                Direction.South => new Coord(coord.X, coord.Y + 1),
                Direction.West => new Coord(coord.X - 1, coord.Y),
            };
        }
    }

    public object RunTaskOne(string[] inputLines)
    {
        Coord startingCoord = new(0, 0);

        Dictionary<Coord, char> map = inputLines
            .SelectMany((line, y) => line.Select((c, x) => {
                if (c == 'S') {
                    startingCoord = new Coord(x, y);
                }
                return (new Coord(x, y), c);
                }))
            .ToDictionary(x => x.Item1, x => x.Item2);

        Direction[] allDirections = [Direction.North, Direction.East, Direction.South, Direction.West];

        (Direction outboundDirection, Coord coord) nextMove = (Direction.North, startingCoord);
        int numberOfMoves = 0;

        foreach (var direction in allDirections) {
            if (IsValidPipe(startingCoord, direction)) {
                nextMove = new(direction, GetNextCoord(startingCoord, direction));
                break;
            }
        }

        while (map.TryGetValue(nextMove.coord, out var c) && c != 'S') {
            nextMove = CoordTranslator(nextMove.coord, nextMove.outboundDirection);
            numberOfMoves++;
        }

        return Math.Ceiling(numberOfMoves / 2d);

        (Direction outboundDirection, Coord nextCoord) CoordTranslator(Coord incomingCoord, Direction inboundDirection) {
            return inboundDirection switch {
                Direction.North =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == '7' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    true when c == '|' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    true when c == 'F' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.East =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'J' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    true when c == '-' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    true when c == '7' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.South => map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'L' => (Direction.East, new Coord(incomingCoord.X + 1, incomingCoord.Y)),
                    true when c == '|' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    true when c == 'J' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    _ => throw new Exception("Invalid pipe")
                },
                Direction.West =>  map.TryGetValue(new Coord(incomingCoord.X, incomingCoord.Y), out var c) switch {
                    true when c == 'F' => (Direction.South, new Coord(incomingCoord.X, incomingCoord.Y + 1)),
                    true when c == '-' => (Direction.West, new Coord(incomingCoord.X - 1, incomingCoord.Y)),
                    true when c == 'L' => (Direction.North, new Coord(incomingCoord.X, incomingCoord.Y - 1)),
                    _ => throw new Exception("Invalid pipe")
                },
            };
        }

        bool IsValidPipe(Coord coord, Direction inboundDirection) {
            return inboundDirection switch {
                Direction.North =>  map.TryGetValue(new Coord(coord.X, coord.Y - 1), out var c) && (c == '7' || c == '|' || c == 'F'),
                Direction.East =>  map.TryGetValue(new Coord(coord.X + 1, coord.Y), out var c) && (c == 'J' || c == '-' || c == '7'),
                Direction.South => map.TryGetValue(new Coord(coord.X, coord.Y + 1), out var c) && (c == 'L' || c == '|' || c == 'J'),
                Direction.West =>  map.TryGetValue(new Coord(coord.X - 1, coord.Y), out var c) && (c == 'F' || c == '-' || c == 'L'),
            };
        } 

        Coord GetNextCoord(Coord coord, Direction direction) {
            return direction switch {
                Direction.North => new Coord(coord.X, coord.Y - 1),
                Direction.East => new Coord(coord.X + 1, coord.Y),
                Direction.South => new Coord(coord.X, coord.Y + 1),
                Direction.West => new Coord(coord.X - 1, coord.Y),
            };
        }
    }


    private record struct Coord(int X, int Y);

    private enum Direction {
        North,
        East,
        South,
        West
    }
}