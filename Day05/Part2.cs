namespace Day05;

public static class Part2
{

    static IEnumerable<long> Part2Iterator(Input maps)
    {
        foreach (var seed in maps.SeedsP2)
        {
            var sourceForNextAlmanac = seed;
            foreach (var almanac in maps.Almanacs)
            {
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

    static IEnumerable<long> SeedsForPart2(List<long> seedsPart1)
    {
        List<Task<IEnumerable<long>>> tasks = [];
        for (int i = 0; i < seedsPart1.Count; i += 2)
        {
            long startRange = seedsPart1[i];
            long endRange = seedsPart1[i] + seedsPart1[i + 1];
            for (long j = startRange; j < endRange; j++)
            {
                if (j % 10_000_000 == 0)
                {
                    Console.WriteLine($"Progress: {j}/{endRange} ({i + 1}/{seedsPart1.Count})");
                }
                yield return j;
            }
        }      
    }

    public static void Part2Main()
    {
        Input maps = Program. GetInput();
        maps.SeedsP2 = SeedsForPart2(maps.Seeds);
        var lowestLocation = Part2Iterator(maps).Min();
        Console.WriteLine($"Part 2, lowest location => {lowestLocation} ");
    }
}
