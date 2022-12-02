namespace AdventOfCode.Solutions;

public class Day2Solution : Solution
{

    private readonly List<(char, char)> _throws;

    public Day2Solution()
        : base("Day2.txt")
    {
        _throws = ParseInput();
    }

    public override object Part1()
    {
        int sum = 0;
        foreach((char opponent, char you) in _throws)
        {
            int score = GetBaseScore(you);

            score += (opponent, you) switch {
                ('A', 'X') => 3,
                ('A', 'Y') => 6,
                ('A', 'Z') => 0,
                ('B', 'X') => 0,
                ('B', 'Y') => 3,
                ('B', 'Z') => 6,
                ('C', 'X') => 6,
                ('C', 'Y') => 0,
                ('C', 'Z') => 3,
                _ => throw new ArgumentException($"Invalid character from input: ({opponent}), ({you})")
            };

            sum += score;
        }

        return sum;
    }

    public override object Part2()
    {
        int sum = 0;
        foreach((char opponent, char result) in _throws)
        {
            sum += (opponent, result) switch {
                ('A', 'X') => 3,
                ('A', 'Y') => 4,
                ('A', 'Z') => 8,
                ('B', 'X') => 1,
                ('B', 'Y') => 5,
                ('B', 'Z') => 9,
                ('C', 'X') => 2,
                ('C', 'Y') => 6,
                ('C', 'Z') => 7,
                _ => throw new ArgumentException($"Invalid character from input: ({opponent}), ({result})")
            };
        }

        return sum;
    }

    private List<(char, char)> ParseInput()
    {
        List<(char, char)> parsedInput = new();
        foreach(var line in Input)
        {
            if(string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] input = line.Split(" ");
            parsedInput.Add((input[0][0], input[1][0]));
        }

        return parsedInput;
    }

    private int GetBaseScore(char you)
    {
        return you switch {
                'X' => 1,
                'Y' => 2,
                'Z' => 3,
                _ => throw new ArgumentException($"Invalid character from input: {you}")
            };
    }
}