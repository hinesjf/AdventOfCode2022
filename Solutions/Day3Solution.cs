namespace AdventOfCode.Solutions;

public class Day3Solution : Solution
{
    public Day3Solution()
        : base("Day3.txt")
    {
    }

    public override object Part1()
    {
        int sum = 0;
        foreach(var rucksack in Input)
        {
            HashSet<char> firstCompartment = new();
            for(int i = 0; i < rucksack.Length; i++)
            {
                if(i < rucksack.Length / 2)
                {
                    firstCompartment.Add(rucksack[i]);
                }
                else if(firstCompartment.Contains(rucksack[i]))
                {
                    sum += GetPriority(rucksack[i]);
                    break;
                }
            }
        }

        return sum;
    }

    public override object Part2()
    {
        int sum = 0;
        IEnumerator<string> elves = Input.GetEnumerator();
        while(elves.MoveNext())
        {
            HashSet<char> firstElf = new ();
            foreach(char c in elves.Current)
            {
                firstElf.Add(c);
            }

            elves.MoveNext();
            HashSet<char> secondElf = new ();
            foreach(char c in elves.Current)
            {
                secondElf.Add(c);
            }

            elves.MoveNext();
            HashSet<char> thirdElf = new ();
            foreach(char c in elves.Current)
            {
                thirdElf.Add(c);
            }

            foreach(char c in firstElf)
            {
                if(secondElf.Contains(c) && thirdElf.Contains(c))
                {
                    sum += GetPriority(c);
                    break;
                }
            }
        }

        return sum;
    }

    private int GetPriority(char c)
    {
        if(char.IsUpper(c))
        {
            return (c - 'A') + 27;
        }

        return (c - 'a') + 1;
    }
}