namespace AdventOfCode2022;

public class Day08
{
    public int PartOne()
    {
        var grid = GetInput();
        var gridWithoutEdges = grid.Where(g => g.Key.X != 0 && g.Key.X != grid.Keys.Max(x => x.X) && g.Key.Y != 0 && g.Key.Y != grid.Keys.Max(x => x.Y)).ToGrid();

        var visibleTrees = grid.Count() - gridWithoutEdges.Count();
        foreach (var currentPos in gridWithoutEdges)
        {
            var visibleTop = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToTop).All(x => x.Value < currentPos.Value);
            var visibleDown = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToDown).All(x => x.Value < currentPos.Value);
            var visibleLeft = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToLeft).All(x => x.Value < currentPos.Value);
            var visibleRight = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToRight).All(x => x.Value < currentPos.Value);

            if (visibleTop || visibleDown || visibleLeft || visibleRight)
            {
                visibleTrees++;
            }
        }

        return visibleTrees;
    }

    public int PartTwo()
    {
        var grid = GetInput();
        var gridWithoutEdges = grid.Where(g => g.Key.X != 0 && g.Key.X != grid.Keys.Max(x => x.X) && g.Key.Y != 0 && g.Key.Y != grid.Keys.Max(x => x.Y)).ToGrid();

        var scenicScores = new List<int>();

        foreach (var currentPos in gridWithoutEdges)
        {
            var top = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToTop).OrderByDescending(x => x.Key.Y);
            var topScore = top.Count();
            foreach (var pos in top.Select((value, index) => new { value, index}))
            {
                if (pos.value.Value >= currentPos.Value)
                {
                    topScore = pos.index + 1;
                    break;
                }
            }


            var down = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToDown).OrderBy(x => x.Key.Y);
            var downScore = down.Count();
            foreach (var pos in down.Select((value, index) => new { value, index}))
            {
                if (pos.value.Value >= currentPos.Value)
                {
                    downScore = pos.index + 1;
                    break;
                }
            }

            var right = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToRight).OrderBy(x => x.Key.X);
            var rightScore = right.Count();
            foreach (var pos in right.Select((value, index) => new { value, index}))
            {
                if (pos.value.Value >= currentPos.Value)
                {
                    rightScore = pos.index + 1;
                    break;
                }
            }

            var left = grid.GetNeighbourPositions(currentPos, Extentions.NeighbourPositions.AllToLeft).OrderByDescending(x => x.Key.X);
            var leftScore = left.Count();
            foreach (var pos in left.Select((value, index) => new { value, index}))
            {
                if (pos.value.Value >= currentPos.Value)
                {
                    leftScore = pos.index + 1;
                    break;
                }
            }


            scenicScores.Add(topScore * downScore * rightScore * leftScore);
        }
        return scenicScores.OrderByDescending(x => x).First();
    }

    private Dictionary<(int X, int Y), int> GetInput()
    {
        var input = Input.Select(x => x.ToCharArray()).Select(x => x.Select(c => int.Parse(c.ToString())).ToList()).ToList();
        var grid = input.ToGrid();
        return grid;
    }

    public virtual string[] Input => new Input().ReadLines(8).Result;
}