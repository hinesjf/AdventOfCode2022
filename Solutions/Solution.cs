namespace AdventOfCode.Solutions;

public abstract class Solution
{
    protected Solution(string inputFile)
    {
        Input = File.ReadAllLines(Path.Join("Inputs", inputFile)).ToList();
    }

    public abstract object Part1();

    public abstract object Part2();

    protected List<string> Input { get; init; }
}