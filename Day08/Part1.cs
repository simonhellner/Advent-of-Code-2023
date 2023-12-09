namespace Day08;

public static class Part1
{
    public class MapPoint
    {
        public string Position { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        var instructions = input[0];
        int instructionsIndex = 0;

        List<MapPoint> mapPoints = [];
        foreach (var line in input.Skip(2))
        {
            var split1 = line.Split(" = ");
            var position = split1[0];

            var split2 = split1[1]
                .Replace("(", "")
                .Replace(")", "")
                .Replace(" ", "")
                .Split(',');

            var left = split2[0];
            var right = split2[1];

            mapPoints.Add(new MapPoint()
            {
                Position = position,
                Left = left,
                Right = right
            });
        }


        var indexDictionary = mapPoints
            .Select((mapPoint, index) => new { mapPoint, index })
            .ToDictionary(x => x.mapPoint.Position, x => x.index);

        long steps = 0;
        int currentMapPoint = mapPoints.FindIndex(x => x.Position == "AAA");

        while (mapPoints[currentMapPoint].Position != "ZZZ")
        {
            if (steps % 10 == 0)
            {
                Console.Title = ($"Steps = {steps}");
            }

            char instruction = instructions[instructionsIndex++];
            string nextPosition;
            if (instruction == 'L')
            {
                nextPosition = mapPoints[currentMapPoint].Left;
            }
            else
            {
                nextPosition = mapPoints[currentMapPoint].Right;
            }

            currentMapPoint = mapPoints.FindIndex(x => x.Position == nextPosition);
            if (instructionsIndex >= instructions.Length)
            {
                instructionsIndex = 0;
            }

            steps++;
        }

        Console.WriteLine($"Part 1, Steps => {steps}");
    }
}
