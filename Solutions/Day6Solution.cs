namespace AdventOfCode.Solutions;

public class Day6Solution : Solution
{
    private readonly string _input;
    public Day6Solution() 
        : base("Day6.txt")
    {
        _input = Input.Single();
    }

    public override object Part1()
    {
        Dictionary<char, int> charCounts = new();
        int start = 0;
        int end = 3;
        for(int i = start; i <= end; i++)
        {
            AddOccurence(charCounts, _input[i]);
        }

        while(end < _input.Length)
        {
            if(IsWindowUnique(charCounts)){
                return end + 1;
            }
            
            AddOccurence(charCounts, _input[++end]);
            RemoveOccurence(charCounts, _input[start++]);
        }

        return _input.Length;
    }

    public override object Part2()
    {
        Dictionary<char, int> charCounts = new();
        int start = 0;
        int end = 13;
        for(int i = start; i <= end; i++)
        {
            AddOccurence(charCounts, _input[i]);
        }

        while(end < _input.Length)
        {
            if(IsWindowUnique(charCounts)){
                return end + 1;
            }
            
            AddOccurence(charCounts, _input[++end]);
            RemoveOccurence(charCounts, _input[start++]);
        }

        return _input.Length;
    }

    private bool IsWindowUnique(Dictionary<char, int> charCounts)
    {
        foreach((char key, int count) in charCounts)
        {
            if(count > 1)
            {
                return false;
            }
        }

        return true;
    }

    private void AddOccurence(Dictionary<char, int> charCounts, char key)
    {
        charCounts.TryGetValue(key, out int count);
        charCounts[key] = count + 1;
    }

    private void RemoveOccurence(Dictionary<char, int> charCounts, char key)
    {
        charCounts[key] = charCounts[key] - 1;
        if(charCounts[key] == 0)
        {
            charCounts.Remove(key);
        }
    }
}