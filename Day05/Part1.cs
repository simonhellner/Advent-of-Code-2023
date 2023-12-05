namespace Day05;

public static class Part1
{

    public static long GetDestination(this List<AlmanacThing> list, long number)
    {
        foreach (var line in list)
        {
            var dest = line.GetDestinatio(number);
            if (dest != -1)
                return dest;

        }

        return -1;
    }


    public static IEnumerable<long> Part1Iterator(Input input)
    {
        foreach (var seed in input.Seeds)
        {
            var sourceForNextAlmanac = seed;
            foreach (var almanac in input.Almanacs)
            {
                var key = almanac.Key;
                // first one is seed to soil.
                var dest = almanac.Value.GetDestination(sourceForNextAlmanac);

                if (dest > 0)
                {
                    sourceForNextAlmanac = dest;
                }

                if (almanac.Key == "humidity-to-location")
                {
                    yield return sourceForNextAlmanac;
                }
            }
        }
    }

    public static void Part1Main()
    {
        Input maps = Program.GetInput();        
        var minLocation = Part1Iterator(maps).Min();
        Console.WriteLine($"Part 1, lowest location => {minLocation} ");
    }
}
