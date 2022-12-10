using System.Diagnostics;

namespace AdventOfCode2022;

public static class Extentions
{
    public static Dictionary<(int X, int Y), TValue> ToGrid<TValue>(this List<List<TValue>> input)
    {
        var grid = new Dictionary<(int X, int Y), TValue>();

        var y = 0;
        foreach (var row in input)
        {
            var x = 0;
            foreach (var value in row)
            {
                grid.Add((x, y), value);
                x++;
            }

            y++;
        }

        return grid;
    }

    public static Dictionary<(int X, int Y), TValue> ToGrid<TValue>(this IEnumerable<KeyValuePair<(int X, int Y),TValue>> input)
    {
        return input.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static Dictionary<(int X, int Y), TValue> GetNeighbourPositions<TValue>(this Dictionary<(int X, int Y), TValue> grid,
        KeyValuePair<(int X, int Y), TValue> current, NeighbourPositions neighbourPositions)
    {
        return neighbourPositions switch
        {
            NeighbourPositions.Row => grid.Where(g => g.Key.X == current.Key.X).Except(new[] { current }).ToGrid(),
            NeighbourPositions.Column => grid.Where(g => g.Key.Y == current.Key.Y).Except(new[] { current }).ToGrid(),
            NeighbourPositions.AllToDown => grid.Where(g => g.Key.Y > current.Key.Y && g.Key.X == current.Key.X).ToGrid(),
            NeighbourPositions.AllToTop => grid.Where(g => g.Key.Y < current.Key.Y && g.Key.X == current.Key.X).ToGrid(),
            NeighbourPositions.AllToRight => grid.Where(g => g.Key.X > current.Key.X && g.Key.Y == current.Key.Y).ToGrid(),
            NeighbourPositions.AllToLeft => grid.Where(g => g.Key.X < current.Key.X && g.Key.Y == current.Key.Y).ToGrid(),
        };
    }

    public enum NeighbourPositions
    {
        Row,
        Column,
        AllToLeft,
        AllToRight,
        AllToTop,
        AllToDown,
    }

    public static string Draw<T>(this Dictionary<(int X, int Y), T> input)
    {
        var output = "";
        foreach (var n in input)
        {
            if (n.Key.X == 0 && n.Key.Y != 0)
            {
                output += Environment.NewLine;
                Console.Write(Environment.NewLine);
            }

            output += n.Value;
            Console.Write(n.Value);
        }
        output += Environment.NewLine + Environment.NewLine;
        Console.Write(Environment.NewLine + Environment.NewLine);

        return output;
    }
}