using AdventOfCode.Solutions;

namespace AdventOfCode;

public class AdventOfCode 
{
    public static void Main()
    {
        int today = DateTime.Now.Day;
        Solution solution = GetSolutionForDay(today);
        Console.WriteLine($"Day {today}\n    Part 1 : {solution.Part1()}\n    Part 2 : {solution.Part2()}");
    }

    private static Solution GetSolutionForDay(int day)
    {
        return day switch
        {
            1 => new Day1Solution(),
            _ => throw new ArgumentException($"Invalid/unimplemented day of month: {day}")
        };
    }
}
