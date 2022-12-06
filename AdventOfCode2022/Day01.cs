namespace AdventOfCode2022;

public class Day01
{
    // 26 min
    public int PartOne()
    {
        var input = GetInput();
        var caloriesByElf = new List<int>();
        var elf = 0;

        foreach (var i in input)
        {
            if (int.TryParse(i, out var calories))
            {
                elf += calories;
            }
            else
            {
                caloriesByElf.Add(elf);
                elf = 0;
            }
        }

        caloriesByElf.Add(elf);


        return caloriesByElf.Max();
    }

    public int PartTwo()
    {
        var input = GetInput();
        var caloriesByElf = new List<int>();
        var elf = 0;

        foreach (var i in input)
        {
            if (int.TryParse(i, out var calories))
            {
                elf += calories;
            }
            else
            {
                caloriesByElf.Add(elf);
                elf = 0;
            }
        }

        caloriesByElf.Add(elf);

        return caloriesByElf.OrderByDescending(x => x).Take(3).Sum();
    }

    private string[] GetInput()
    {
        var input = Input;
        return input;
    }
    public virtual string[] Input => new Input().ReadLines(1).Result;
}