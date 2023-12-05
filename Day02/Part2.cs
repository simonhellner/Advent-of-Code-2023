namespace Day02;

public static class Part2
{

    static int CountCubes(string line, string color)
    {
        int sum = 0;
        foreach (var x in line.Replace(';', ',').Split(','))
        {
            if (x.Contains(color))
            {
                var str = new string(x.Where(c => char.IsDigit(c)).ToArray());
                int number = int.Parse(str);
                sum += number;
            }
        }
        return sum;
    }

    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");

        int totalPower = 0;
        foreach (var line in input)
        {
            var split = line.Split(':');
            var gameNumber = int.Parse(split[0].Split(' ')[1]);

            var subGames = split[1].Split(';');

            int gameMinRed = int.MinValue;
            int gameMinGreen = int.MinValue;
            int gameMinBlue = int.MinValue;
            foreach (var subGame in subGames)
            {
                int redCount = CountCubes(subGame, "red");
                if (redCount > gameMinRed)
                    gameMinRed = redCount;


                int blueCount = CountCubes(subGame, "blue");
                if (blueCount > gameMinBlue)
                    gameMinBlue = blueCount;

                int greenCount = CountCubes(subGame, "green");
                if (greenCount > gameMinGreen)
                    gameMinGreen = greenCount;

            }

            int power = gameMinRed * gameMinGreen * gameMinBlue;
            totalPower += power;
        }
        Console.WriteLine($"Part 2, Total power = {totalPower}");
    }
}
