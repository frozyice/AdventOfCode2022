namespace AdventOfCode2022;

public class Day02
{
    // 53 min
    public int PartOne()
    {
        var input = GetInput();
        var score = 0;
        foreach (var game in input)
        {
            score += game.GetVictoryPoints() + (int) game.You;
        }

        return score;
    }

    public int PartTwo()
    {
        var input = GetInput2();
        var score = 0;
        foreach (var game in input)
        {
            score += game.GetVictoryPoints() + (int) game.GetYourSelection();
        }

        return score;
    }

    private List<Game> GetInput()
    {
        var input = Input;
        var games = new List<Game>();
        foreach (var i in input)
        {
            games.Add(new Game(i));
        }

        return games;
    }

    public class Game
    {
        public RPS Opponent { get; private set; }
        public RPS You { get; private set; }

        public Game(string input)
        {
            var strings = input.Split(" ");

            if (strings[0] == "A")
            {
                Opponent = RPS.Rock;
            }

            if (strings[0] == "B")
            {
                Opponent = RPS.Paper;
            }

            if (strings[0] == "C")
            {
                Opponent = RPS.Scissors;
            }

            if (strings[1] == "X")
            {
                You = RPS.Rock;
            }

            if (strings[1] == "Y")
            {
                You = RPS.Paper;
            }

            if (strings[1] == "Z")
            {
                You = RPS.Scissors;
            }
        }

        public int GetVictoryPoints()
        {
            if (Opponent == You)
                return 3;

            if (You == RPS.Paper && Opponent == RPS.Rock || You == RPS.Rock && Opponent == RPS.Scissors || You == RPS.Scissors && Opponent == RPS.Paper)
                return 6;

            return 0;
        }
    }

    private List<Game2> GetInput2()
    {
        var input = Input;
        var games = new List<Game2>();
        foreach (var i in input)
        {
            games.Add(new Game2(i));
        }

        return games;
    }

    public class Game2
    {
        public RPS Opponent { get; private set; }
        public string You { get; private set; }

        public Game2(string input)
        {
            var strings = input.Split(" ");

            if (strings[0] == "A")
            {
                Opponent = RPS.Rock;
            }

            if (strings[0] == "B")
            {
                Opponent = RPS.Paper;
            }

            if (strings[0] == "C")
            {
                Opponent = RPS.Scissors;
            }

            You = strings[1];
        }

        public RPS GetYourSelection()
        {
            if (You == "Y")
            {
                return Opponent;
            }

            if (Opponent == RPS.Paper)
            {
                return You == "Z" ? RPS.Scissors : RPS.Rock;
            }

            if (Opponent == RPS.Rock)
            {
                return You == "Z" ? RPS.Paper : RPS.Scissors;
            }

            if (Opponent == RPS.Scissors)
            {
                return You == "Z" ? RPS.Rock : RPS.Paper;
            }

            throw new InvalidOperationException();
        }

        public int GetVictoryPoints() => You switch
        {
            "X" => 0,
            "Y" => 3,
            "Z" => 6,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public virtual string[] Input => new Input().ReadLines(2).Result;
}