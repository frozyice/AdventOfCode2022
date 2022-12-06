namespace AdventOfCode2022;

public class Template
{
    public int PartOne()
    {
        var input = GetInput();
        return 0;
    }

    public int PartTwo()
    {
        return 0;
    }

    private string[] GetInput()
    {
        var input = Input;
        return input;
    }

    public virtual string[] Input => new Input().ReadLines(0).Result;
}