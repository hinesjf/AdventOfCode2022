namespace AdventOfCode.Solutions;

public class Day1Solution : Solution
{
    private readonly List<int> _calorieCounts;

    public Day1Solution() 
        : base("Day1.txt")
    {
        _calorieCounts = GetTotalCalorieCounts();
    }

    public override object Part1() => _calorieCounts[0];

    public override object Part2() => _calorieCounts[0] + _calorieCounts[1] + _calorieCounts[2];

    private List<int> GetTotalCalorieCounts()
    {
        int calorieCount = 0;
        List<int> calorieCounts = new();
        foreach(var line in Input)
        {
            if(string.IsNullOrEmpty(line))
            {
                calorieCounts.Add(calorieCount);
                calorieCount = 0;
                continue;
            }

            calorieCount += int.Parse(line);
        }

        calorieCounts.Sort();
        calorieCounts.Reverse();

        return calorieCounts;
    }
}