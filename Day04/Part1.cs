namespace Day04;

public static class Part1
{
    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        int totalPoints = 0;
        foreach (var card in input)
        {
            var split = card.Split('|');

            var numbers = split[0]
                .Split(": ")[1]
                .Split(' ')
                .Where(x => x != "")
                .Select(x => int.Parse(x))
                .ToList();

            var winningNumbers = split[1]
                .Split(' ')
                .Where(x => x != "")
                .Select(x => int.Parse(x))
                .ToList();

            var correctNumbers = numbers.Where(number => winningNumbers.Contains(number)).ToList();
            if (correctNumbers.Count < 1)
                continue;

            if (correctNumbers.Count == 1)
            {
                totalPoints += 1;
            }
            else
            {
                var points = Math.Pow(2, correctNumbers.Count) - Math.Pow(2, correctNumbers.Count - 1);
                totalPoints += (int)points;
            }
        }
        Console.WriteLine($"Part 1, Total Points =>  {totalPoints}");
    }
}
