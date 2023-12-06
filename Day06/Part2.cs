using static Day06.Part1;

namespace Day06;

public static class Part2
{
    static RaceScenario LoadInput()
    {
        var input = File.ReadAllLines("input.txt");

        string timeStr = input[0].Split(':')[1] .Replace(" ", "");
        long time = long.Parse(timeStr);

        string distanceStr = input[1].Split(':')[1].Replace(" ", "");
        long distance = long.Parse(distanceStr);

        return new RaceScenario()
        {
            Time = time,
            Distance = distance,
        };
    }

    public static void Part2Main()
    {
        RaceScenario raceScenario = LoadInput();

        long winningHoldingTimes = 0;    
        for (int holdSceonds = 0; holdSceonds < raceScenario.Time; holdSceonds++)
        {
            long distance = raceScenario.GetTraveledDistance(holdSceonds);
            if (distance > raceScenario.Distance)
            {
                winningHoldingTimes += 1;
            }
        }

        Console.WriteLine($"Part 2, result => {winningHoldingTimes}");
    }
}
