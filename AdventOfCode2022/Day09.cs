namespace AdventOfCode2022;

public class Day09
{
    // 5h 51min
    public int PartOne()
    {
        var rope = new Rope();
        foreach (var command in Input)
        {
            rope.Move(command);
        }

        return rope.TailPositions.Distinct().Count();
    }

    public int PartTwo()
    {
        var rope = new LongRope();
        foreach (var command in Input)
        {
            rope.Move(command);
        }

        return rope.TailPositions.Distinct().Count();
    }

    public virtual string[] Input => new Input().ReadLines(9).Result;

    public class Rope
    {
        public Position Head { get; private set; }
        public Position Tail { get; private set; }
        public List<Position> TailPositions { get; } = new();

        public Rope()
        {
            Head = new Position(0, 0);
            Tail = new Position(0, 0);
            TailPositions.Add(Tail);
        }

        private bool IsTailNextToHead()
        {
            var xRange = Tail.X - Head.X;
            var yRange = Tail.Y - Head.Y;
            return xRange >= -1 && xRange <= 1 && yRange >= -1 && yRange <= 1;
        }

        public void Move(string command)
        {
            var direction = command.Split(" ")[0];
            var steps = int.Parse(command.Split(" ")[1]);
            if (direction == "R")
                MoveRight(steps);
            if (direction == "L")
                MoveLeft(steps);
            if (direction == "U")
                MoveUp(steps);
            if (direction == "D")
                MoveDown(steps);
        }

        private void MoveRight(int steps)
        {
            Head = new Position(Head.X + 1, Head.Y);

            if (!IsTailNextToHead())
            {
                Tail = Head with { X = Head.X - 1 };
                TailPositions.Add(Tail);
            }

            steps--;
            if (steps > 0)
            {
                MoveRight(steps);
            }
        }

        private void MoveLeft(int steps)
        {
            Head = new Position(Head.X - 1, Head.Y);

            if (!IsTailNextToHead())
            {
                Tail = Head with { X = Head.X + 1 };
                TailPositions.Add(Tail);
            }

            steps--;
            if (steps > 0)
            {
                MoveLeft(steps);
            }
        }

        private void MoveDown(int steps)
        {
            Head = new Position(Head.X, Head.Y + 1);

            if (!IsTailNextToHead())
            {
                Tail = Head with { Y = Head.Y - 1 };
                TailPositions.Add(Tail);
            }

            steps--;
            if (steps > 0)
            {
                MoveDown(steps);
            }
        }

        private void MoveUp(int steps)
        {
            Head = new Position(Head.X, Head.Y - 1);

            if (!IsTailNextToHead())
            {
                Tail = Head with { Y = Head.Y + 1 };
                TailPositions.Add(Tail);
            }

            steps--;
            if (steps > 0)
            {
                MoveUp(steps);
            }
        }
    }

    public class LongRope
    {
        public Position Tail => Knots.Last();
        public Position[] Knots { get; }
        public List<Position> TailPositions { get; } = new();

        public LongRope()
        {
            Knots = Enumerable.Range(0, 10).Select(x => new Position(0, 0)).ToArray();
            TailPositions.Add(new Position(0, 0));
        }

        private bool IsChildNextToParentKnot(int index)
        {
            var childIndex = index + 1;
            if (childIndex >= Knots.Length)
            {
                return true;
            }

            var xRange = Knots[childIndex].X - Knots[index].X;
            var yRange = Knots[childIndex].Y - Knots[index].Y;
            return xRange >= -1 && xRange <= 1 && yRange >= -1 && yRange <= 1;
        }

        public void Move(string command)
        {
            var direction = command.Split(" ")[0];
            var steps = int.Parse(command.Split(" ")[1]);
            if (direction == "R")
                MoveTo(1, 0, steps, 0);
            if (direction == "L")
                MoveTo(-1, 0, steps, 0);
            if (direction == "U")
                MoveTo(0, -1, steps, 0);
            if (direction == "D")
                MoveTo(0, 1, steps, 0);
        }

        private void MoveTo(int xOffset, int yOffset, int steps, int index)
        {
            var childIndex = index + 1;
            Knots[index] = new Position(Knots[index].X + xOffset, Knots[index].Y + yOffset);

            if (!IsChildNextToParentKnot(index))
            {
                var xCorrection = 0;
                var yCorrection = 0;
                if (Knots[index].X != Knots[childIndex].X)
                {
                    xCorrection = Knots[index].X > Knots[childIndex].X ? +1 : -1;
                }

                if (Knots[index].Y != Knots[childIndex].Y)
                {
                    yCorrection = Knots[index].Y > Knots[childIndex].Y ? +1 : -1;
                }

                MoveTo(xCorrection, yCorrection, 1, childIndex);
                if (childIndex >= Knots.Length - 1)
                    TailPositions.Add(Tail);
            }

            steps--;
            if (steps > 0)
            {
                MoveTo(xOffset, yOffset, steps, index);
            }
        }
    }

    public record Position
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}