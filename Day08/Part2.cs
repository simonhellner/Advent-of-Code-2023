using static Day08.Part1;

namespace Day08;

public static class Part2
{
    static List<int> FindMapPointIndexes(this List<MapPoint> mapPoints, char endsCharacter)
    {
        List<int> indexes = [];
        for (int i = 0; i < mapPoints.Count; i++)
        {
            if (mapPoints[i].Position.EndsWith(endsCharacter))
            {
                indexes.Add(i);
            }
        }
        return indexes;
    }

    static ulong GCD(ulong a, ulong b)
    {
        while (b != 0)
        {
            ulong temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static ulong LCM(ulong[] numbers)
    {
        ulong result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = LCM(result, numbers[i]);
        }
        return result;
    }

    static ulong LCM(ulong a, ulong b)
    {
        return (a * b) / GCD(a, b);
    }


    public class Ghost
    {
        public int StepsToZ { get; set; }
        public int CurrentIndex { get; set; }
        public string CurrentPosition { get; set; } = "";
    }

    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");

        var instructions = input[0];


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


        var ghosts = mapPoints.FindMapPointIndexes('A').Select(startIndex => new Ghost() { CurrentIndex = startIndex }).ToList();
        foreach (var ghost in ghosts)
        {
            int instructionsIndex = 0;
            while (ghost.CurrentPosition.EndsWith('Z') == false)
            {
                char instruction = instructions[instructionsIndex++];
                string nextPosition;
                if (instruction == 'L')
                {
                    nextPosition = mapPoints[ghost.CurrentIndex].Left;
                }
                else
                {
                    nextPosition = mapPoints[ghost.CurrentIndex].Right;
                }

                ghost.CurrentIndex = indexDictionary[nextPosition];
                ghost.CurrentPosition = mapPoints[ghost.CurrentIndex].Position;

                ghost.StepsToZ++;

                if (ghost.StepsToZ % 5_000_000 == 0)
                {
                    Console.Title = $"Steps => {ghost.StepsToZ}";
                }

                if (instructionsIndex >= instructions.Length)
                {
                    instructionsIndex = 0;
                }
            }
        }

        var stepsResult = LCM(ghosts.Select(x => (ulong)x.StepsToZ).ToArray());

        Console.WriteLine($"Part 2, Steps => {stepsResult}");
    }
}