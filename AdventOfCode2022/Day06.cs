namespace AdventOfCode2022;

public class Day06
{
    // 1h 18min
    public int PartOne()
    {
        var input = Input.ToCharArray();
        var characters = new List<string>();
        var queue = new Queue<char>();
        var count = 0;
        foreach (var c in input)
        {
            count++;

            queue.Enqueue(c);
            if (queue.Count > 4)
            {
                queue.Dequeue();
            }
            if (queue.Count == 4)
            {
                if (characters.Count() > 0)
                {
                    var q = new string(queue.ToArray());
                    var b = q.Distinct().Count() == 4;
                    if (b)
                    {
                        break;
                    }
                }
                characters.Add(new string(queue.ToArray()));
            }
        }
        return count;
    }

    public int PartTwo()
    {
        var input = Input.ToCharArray();
        var queue = new Queue<char>();
        var count = 0;
        foreach (var c in input)
        {
            count++;

            queue.Enqueue(c);
            if (queue.Count > 14)
            {
                queue.Dequeue();
            }
            if (queue.Count == 14)
            {
                    var q = new string(queue.ToArray());
                    var b = q.Distinct().Count() == 14;
                    if (b)
                    {
                        break;
                    }
            }
        }
        return count;
    }

    public virtual string Input => new Input().ReadText(6).Result;
}