namespace AdventOfCode.Solutions;

public class Day4Solution : Solution
{
    private readonly List<(int, int, int, int)> _intervals;

    public Day4Solution()
        : base("Day4.txt")
    {
        _intervals = ParseIntervals();
    }

    public override object Part1()
    {
        int overlaps = 0;
        foreach ((int a, int b, int x, int y) in _intervals)
        {
            if(OneIntervalContainsTheOther(a,b,x,y))
            {
                overlaps++;
            }
        }

        return overlaps;
    }

    public override object Part2()
    {
        int overlaps = 0;
        foreach ((int a, int b, int x, int y) in _intervals)
        {
            if((a <= x && b >= x) || (a <= y && b >= y) || OneIntervalContainsTheOther(a,b,x,y))
            {
                overlaps++;
            }
        }

        return overlaps;
    }

    private bool OneIntervalContainsTheOther(int a, int b, int x, int y)
    {
        return (a <= x && b >= y) || (a >= x && b <= y);
    }

    private List<(int, int, int, int)> ParseIntervals()
    {
        List<(int, int, int, int)> values = new();
        foreach (var pair in Input)
        {
            string[] intervals = pair.Split(',');
            (int a, int b) = ParseInterval(intervals[0]);
            (int x, int y) = ParseInterval(intervals[1]);

            values.Add((a,b,x,y));
        }

        return values;
    }

    private (int,int) ParseInterval(string interval)
    {
        string[] intervalStr = interval.Split('-');
        return (int.Parse(intervalStr[0]), int.Parse(intervalStr[1]));
    }
}