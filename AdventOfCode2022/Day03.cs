namespace AdventOfCode2022;

public class Day03
{
    // 1h 51min
    public int PartOne()
    {
        var input = GetInput();
        var doubleItems = new List<int>();
        foreach (var rucksack in input)
        {
            var duplicateItem = FindDuplicateItem(rucksack);
            var priority = GetPriority(duplicateItem);
            doubleItems.Add(priority);
        }

        return doubleItems.Sum();
    }

    private static int GetPriority(char duplicateItem)
    {
        if (char.IsLower(duplicateItem))
        {
            return duplicateItem - 96;
        }

        return duplicateItem - 38;
    }

    private char FindDuplicateItem((string, string) rucksack)
    {
        foreach (var item in rucksack.Item1)
        {
            if (rucksack.Item2.Contains(item))
            {
                return item;
            }
        }

        throw new InvalidOperationException();
    }

    public int PartTwo()
    {
        var groupOf3Rucksacks = GetInput2();
        var score = new List<int>();
        foreach (var group in groupOf3Rucksacks)
        {
            var commonItem = GetCommonItem(group);
            var priority = GetPriority(commonItem);
            score.Add(priority);
        }
        return score.Sum();
    }

    private char GetCommonItem(List<string> @group)
    {
        foreach (var item in group[0])
        {
            if (group[1].Contains(item) && group[2].Contains(item))
            {
                return item;
            }
        }

        throw new InvalidOperationException();
    }

    private List<(string, string)> GetInput()
    {
        var input = Input.Select(i =>
        {
            var rucksackSize = i.Length / 2;
            var list = (i.Substring(0, rucksackSize), i.Substring(rucksackSize));
            return list;
        });
        return input.ToList();
    }

    private List<List<string>> GetInput2()
    {
        var list = Input.Select(s => new String(s.ToCharArray().Distinct().OrderBy(x => x).ToArray())).ToList();
        var input = new List<List<string>>();

        for (var i = 0; i < list.Count; i=i+3)
        {
            var list1 = new List<string>();
            list1.Add(list[i]);
            list1.Add(list[i+1]);
            list1.Add(list[i+2]);
            input.Add(list1);
        }

        return input;
    }

    public virtual string[] Input => new Input().ReadLines(3).Result;
}

// var score = File.ReadLines("input.txt")
//     .Select(e => e.ToCharArray())
//     .Chunk(3)
//     .Select(e => e[0].Intersect(e[1]).Intersect(e[2]).First())
//     .Select(e => char.IsUpper(e) ? e - 38 : e - 96)
//     .Sum();