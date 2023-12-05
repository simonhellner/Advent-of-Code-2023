namespace Day01;

public static class Part1
{
    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");
        int result = input.Sum(line =>
        {
            char num1 = line.First(x => char.IsDigit(x));
            char num2 = line.Last(x => char.IsDigit(x));
            return int.Parse($"{num1}{num2}");
        });

        Console.WriteLine($"Part 1 result = {result}");
    }
}
