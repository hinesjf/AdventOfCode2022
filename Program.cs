using AdventOfCode.Solutions;

namespace AdventOfCode;

public class AdventOfCode 
{
    public static void Main()
    {
        var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var today = TimeZoneInfo.ConvertTime(DateTime.UtcNow, est);
        Solution solution = GetSolutionForDay(today.Day);
        Console.WriteLine($"Day {today}\n    Part 1 : {solution.Part1()}\n    Part 2 : {solution.Part2()}");
    }

    private static Solution GetSolutionForDay(int day)
    {
        return day switch
        {
            1 => new Day1Solution(),
            2 => new Day2Solution(),
            _ => throw new ArgumentException($"Invalid/unimplemented day of month: {day}")
        };
    }
}
