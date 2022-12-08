using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions;

public class Day5Solution : Solution
{
    // Change to match input.
    private const int ROW_NUM = 8;
    private const int STACK_NUM = 9;

    public Day5Solution() 
        : base("Day5.txt")
    {
    }

    public override object Part1()
    {
        (Stack<char>[] stacks, List<(int, int, int)> moves) = ParseInput();
        foreach((int quant, int from, int to) in moves)
        {
            for(int i = 0; i < quant; i++)
            {
                stacks[to - 1].Push(stacks[from - 1].Pop());
            }
        }

        return CollectOutput(stacks);
    }

    public override object Part2()
    {
        (Stack<char>[] stacks, List<(int, int, int)> moves) = ParseInput();
        foreach((int quant, int from, int to) in moves)
        {
            Stack<char> temp = new();
            for(int i = 0; i < quant; i++)
            {
                temp.Push(stacks[from - 1].Pop());
            }

            while(temp.Count > 0)
            {
                stacks[to - 1].Push(temp.Pop());
            }
        }

        return CollectOutput(stacks);
    }

    private (Stack<char>[] stacks, List<(int, int, int)> moves) ParseInput()
    {
        Stack<char>[] stacks = new Stack<char>[STACK_NUM];

        for(int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<char>();
            int col = 4 * i + 1;
            for(int j = ROW_NUM - 1; j >= 0; j--)
            {
                if(Input[j][col] != ' ')
                stacks[i].Push(Input[j][col]);
            }
        }

        // Line number where the moves part of the input begins.
        int lineNumber = ROW_NUM + 2;

        List<(int, int, int)> moves = new List<(int, int, int)>();
        while (lineNumber < Input.Count)
        {
            Match match = Regex.Match(Input[lineNumber], @"move (?<quant>[0-9]+) from (?<from>[0-9]+) to (?<to>[0-9]+)");
            int quant = int.Parse(match.Groups["quant"].Value);
            int from = int.Parse(match.Groups["from"].Value);
            int to = int.Parse(match.Groups["to"].Value);

            moves.Add((quant, from, to));
            lineNumber++;
        }

        return (stacks, moves);
    }

    private string CollectOutput(Stack<char>[] stacks)
    {
        StringBuilder sb = new();
        foreach(var stack in stacks)
        {
            sb.Append(stack.Peek());
        }

        return sb.ToString();
    }
}