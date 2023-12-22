namespace Day15;

public static class Part1
{
    static int Hash(string source)
    {
        int currentValue = 0;
        foreach (char c in source)
        {
            int ascii = (int)c;
            currentValue += ascii;
            currentValue *= 17;
            currentValue %= 256;
        }

        return currentValue;
    }

    public static void Part1Main()
    {
        string input = File.ReadAllText("input.txt");

        int sum = 0;
        foreach (var step in input.Split(','))
        {
            var hash = Hash(step);
            sum += hash;
        }

        Console.WriteLine($"Part 1 result, {sum}");
    }
}
