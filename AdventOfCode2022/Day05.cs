namespace AdventOfCode2022;

public class Day05
{
    // 1h 23min
    public string PartOne()
    {
        var stacks = GetStacks();

        foreach (var procedure in Input)
        {
            stacks = MoveCratesOneByOne(procedure, stacks);
        }

        return new string(stacks.Skip(1).Select(x => x.ToArray()[0]).ToArray());
    }

    private List<Stack<char>> MoveCratesOneByOne(string procedure, List<Stack<char>> stacks)
    {
        var parameters = procedure
            .Replace("move ", "")
            .Replace("from ", "")
            .Replace("to ", "")
            .Split(" ")
            .Select(x => int.Parse(x))
            .ToArray();

        var pcs = parameters[0];
        var from = parameters[1];
        var to = parameters[2];

        for (var i = 0; i < pcs; i++)
        {
            var pop = stacks[from].Pop();
            stacks[to].Push(pop);
        }

        return stacks;
    }

    private List<Stack<char>> MoveAllCrates(string procedure, List<Stack<char>> stacks)
    {
        var parameters = procedure
            .Replace("move ", "")
            .Replace("from ", "")
            .Replace("to ", "")
            .Split(" ")
            .Select(x => int.Parse(x))
            .ToArray();

        var pcs = parameters[0];
        var from = parameters[1];
        var to = parameters[2];

        var pickedCrates = new List<char>();
        for (var i = 0; i < pcs; i++)
        {
            pickedCrates.Add(stacks[from].Pop());
        }

        pickedCrates.Reverse();
        foreach (var crate in pickedCrates)
        {
            stacks[to].Push(crate);
        }

        return stacks;
    }

    public string PartTwo()
    {
        var stacks = GetStacks();

        foreach (var procedure in Input)
        {
            stacks = MoveAllCrates(procedure, stacks);
        }

        return new string(stacks.Skip(1).Select(x => x.ToArray()[0]).ToArray());
    }

    private List<Stack<char>> GetStacks()
    {
        var stacks = new List<Stack<char>>();
        var zeroStack = new Stack<char>();
        stacks.Add(zeroStack);

        foreach (var stackAsString in Stacks)
        {
            var stack = new Stack<char>();
            var charArray = stackAsString.ToCharArray();
            foreach (var c in charArray)
            {
                stack.Push(c);
            }

            stacks.Add(stack);
        }

        return stacks;
    }

    public virtual string[] Stacks => new[] { "BVSNTCHQ", "WDBG", "FWRTSQB", "LGWSZJDN", "MPDVF", "FWJ", "LNQBJV", "GTRCJQSN", "JSQCWDM" };
    public virtual string[] Input => new Input().ReadLines(5).Result.Skip(10).ToArray();
}