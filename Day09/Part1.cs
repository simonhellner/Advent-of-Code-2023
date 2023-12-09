namespace Day09;

public static class Part1
{
    static int Something(int[] row)
    {
        List<int> NextRow = [];
        for (int i = 0; i < row.Length-1; i++)
        {
            var diff = row[i + 1] - row[i];
            NextRow.Add(diff);
        }

        int lastNubmerNextRow = 0;
        if (NextRow.Any(diff => diff != 0))
        {
            lastNubmerNextRow = Something(NextRow.ToArray());
        }

        var lastNumberThisRow = row.Last();
        var newLastNumber = lastNumberThisRow + lastNubmerNextRow;

        return newLastNumber;
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt")
            .Select(line => line.Split(' ').Select(int.Parse).ToArray())
            .ToArray();

        int sum = 0;
        foreach (var line in input)
        {
            var output =   Something(line);
            sum += output;
        }

        Console.WriteLine($"Part 1, result => {sum}");
    }
}
