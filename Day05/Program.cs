namespace Day05;

internal class Program
{
    public static Input GetInput()
    {
        const string file = "input.txt";
        var seeds = File.ReadAllLines(file)[0].Split(": ")[1].Split(' ').Select(x => long.Parse(x)).ToList();
        var mapSplit = File.ReadAllText(file).Split($"{Environment.NewLine}{Environment.NewLine}").Skip(1);

        Dictionary<string, List<AlmanacThing>> Almanacs = [];
        Input input = new();
        foreach (var line in mapSplit)
        {
            var split = line.Split(" map:\r\n");
            var type = split[0];
            var rows = split[1].Split(Environment.NewLine);

            List<AlmanacThing> almanacThings = new();
            foreach (var row in rows)
            {
                if (row == null || row.Length == 0)
                    continue;

                var rowSplit = row.Split(' ');
                almanacThings.Add(new AlmanacThing()
                {
                    DescRangeStart = long.Parse(rowSplit[0]),
                    SourceRangeStart = long.Parse(rowSplit[1]),
                    Lenght = long.Parse(rowSplit[2]),
                });
            }

            Almanacs.Add(type, almanacThings);

        }

        return new Input()
        {
            Seeds = seeds,
            Almanacs = Almanacs
        };
    }

    static void Main(string[] args)
    {
        Part1.Part1Main();
        Part2.Part2Main();
        Console.ReadKey();
    }
}
