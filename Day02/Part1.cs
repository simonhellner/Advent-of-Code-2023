namespace Day02;

public static class Part1
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


    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        int red = 12, green = 13, blue = 14;
        int possibleGames = 0;

        foreach (var line in input)
        {
            var split = line.Split(':');
            var gameNumber = int.Parse(split[0].Split(' ')[1]);

            var subGames = split[1].Split(';');
            bool gamePossible = true;
            foreach (var subGame in subGames)
            {

                int redCount = CountCubes(subGame, "red");
                if (redCount > red)
                {
                    gamePossible = false;
                    break;
                }

                int blueCount = CountCubes(subGame, "blue");
                if (blueCount > blue)
                {
                    gamePossible = false;
                    break;
                }

                int greenCount = CountCubes(subGame, "green");
                if (greenCount > green)
                {
                    gamePossible = false;
                    break;
                }
            }

            if (gamePossible)
                possibleGames += gameNumber;
        }

        Console.WriteLine($"Part 1, Possible Games = {possibleGames}");
    }
}