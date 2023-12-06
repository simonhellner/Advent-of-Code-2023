namespace Day06;

public static class Part1
{
    public class RaceScenario
    {
        public long Time { get; set; }
        public long Distance { get; set; }

        public long GetTraveledDistance(int holdSeconds)
        {
            long timeLeft = holdSeconds - Time;
            int speed = holdSeconds;

            long distance = timeLeft * speed;
            return Math.Abs(distance);

        }
    }

    static IEnumerable<RaceScenario> LoadInput()
    {
        var input = File.ReadAllLines("input.txt");

        var times = input[0]
            .Split(':')[1]
            .Split(' ')
            .Where(x => x.Length > 0)
            .Select(int.Parse)
            .ToList();

        var distances = input[1]
            .Split(':')[1]
            .Split(' ')
            .Where(x => x.Length > 0)
            .Select(int.Parse)
            .ToList();


        for (int i = 0; i < times.Count; i++)
        {
            yield return new RaceScenario()
            {
                Time = times[i],
                Distance = distances[i],
            };
        }
    }


    public static void Part1Main()
    {        
        var input = LoadInput();  

        long result = 1;
        foreach (var scenario in input)
        {
            long winningHoldingTimes = 0;
            for(int holdSceonds = 0; holdSceonds<scenario.Time; holdSceonds++)
            {
                long distance = scenario.GetTraveledDistance(holdSceonds);
                if(distance > scenario.Distance)
                {
                    winningHoldingTimes += 1;
                }
            }
            result *= winningHoldingTimes;
        }

        Console.WriteLine($"Part 1, result => {result}");
    }
}
