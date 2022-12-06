namespace AdventOfCode2022;

public class Day04
{
    // 33 min
    public int PartOne()
    {
        var input = GetInput();
        var resultCount = 0;
        foreach (var pairAssigment in input)
        {
            var intersect = pairAssigment.FirstElf.Intersect(pairAssigment.SecondElf).Sum();
            if (intersect == pairAssigment.FirstElf.Sum() || intersect == pairAssigment.SecondElf.Sum())
            {
                resultCount++;
            }
        }
        return resultCount;
    }

    public int PartTwo()
    {
        var result = GetInput().Select(x => x.FirstElf.Intersect(x.SecondElf)).Count(x => x.Any());
        return result;
    }

    private IEnumerable<PairAssigment> GetInput()
    {
        var input = Input.Select(x => new PairAssigment(x)).ToList();
        return input;
    }

    public class PairAssigment
    {
        public int[] FirstElf { get; }
        public int[] SecondElf { get; }

        public PairAssigment(string input)
        {
            var strings = input.Split(",").ToArray().Select(x => x.Split("-")).ToArray();
            FirstElf = Enumerable.Range(int.Parse(strings[0][0]), int.Parse(strings[0][1]) - int.Parse(strings[0][0]) + 1).ToArray();
            SecondElf = Enumerable.Range(int.Parse(strings[1][0]), int.Parse(strings[1][1]) - int.Parse(strings[1][0]) + 1).ToArray();
        }
    }
    public virtual string[] Input => new Input().ReadLines(4).Result;
}