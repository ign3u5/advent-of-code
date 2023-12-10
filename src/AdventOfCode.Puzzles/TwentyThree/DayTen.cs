using System.Runtime.CompilerServices;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DayTen : IPuzzle
{
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

    public object RunTaskTwo(string[] inputLines)
    {
        return 0;
    }


    private record struct Coord(int X, int Y);

    private enum Direction {
        North,
        East,
        South,
        West
    }
}