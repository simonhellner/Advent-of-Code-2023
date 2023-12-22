namespace Day11;

public static class Part2
{

    class Tile(char c)
    {
        public char C { get; set; } = c;
        public bool Visited { get; set; }
        public bool Duplicated { get; set; }

        public bool EmptyRow { get; set; }
        public bool EmptyColumn { get; set; }


        public bool IsGalaxy => C == '#';

        public int GalaxyId { get; set; } = -1;

        public int Row { get; set; }
        public int Column { get; set; }

        public Dictionary<int, int> DistanceToGalaxies { get; set; } = new Dictionary<int, int>();
    }


    static List<List<Tile>> GetSpaceMap()
    {
        var input = File.ReadAllLines("input.txt").Select(line => line.Select(c => new Tile(c)).ToList()).ToList();

        for (int row = 0; row < input.Count; row++)
        {
            var xxx = input[row];
            if (input[row].All(x => x.IsGalaxy == false))
            {
                foreach (var column in input[row])
                {
                    column.EmptyRow = true;
                }
            }
        }

        for (int column = 0; column < input[0].Count; column++)
        {
            bool noGalaxies = true;
            for (int row = 0; row < input.Count; row++)
            {
                if (input[row][column].IsGalaxy)
                {
                    noGalaxies = false;
                    break;
                }
            }

            if (noGalaxies)
            {
                for (int row = 0; row < input.Count; row++)
                {
                    input[row][column].EmptyColumn = true;
                }
            }
        }


        int galaxyCount = 0;
        foreach (var row in input)
        {
            foreach (var column in row)
            {
                if (column.IsGalaxy)
                {
                    galaxyCount++;
                    column.GalaxyId = galaxyCount;
                }
            }
        }

        return input;
    }



    static void SetPositionOnGalaxies(List<List<Tile>> spaceMap)
    {
        for (int row = 0; row < spaceMap.Count; row++)
        {
            for (int column = 0; column < spaceMap[row].Count; column++)
            {
                if (spaceMap[row][column].IsGalaxy)
                {
                    spaceMap[row][column].Row = row;
                    spaceMap[row][column].Column = column;
                }
            }
        }
    }


    static int CountEmptyRowsAndColumns(List<List<Tile>> spaceMap, int startRow, int startColumn, int endRow, int endColumn)
    {
        int emptyCount = 0;

        if (startRow > endRow)
        {
            var temp = startRow;
            startRow = endRow;
            endRow = temp;
        }

        if (startColumn > endColumn)
        {
            var temp = startColumn;
            startColumn = endColumn;
            endColumn = temp;
        }
        for (int row = startRow; row < endRow; row++)
        {
            if (spaceMap[row][0].EmptyRow)
            {
                emptyCount++;
            }
        }
        for (int column = startColumn; column < endColumn; column++)
        {
            if (spaceMap[0][column].EmptyColumn)
            {
                emptyCount++;
            }
        }


        return emptyCount;
    }

    static void FindDistanceToGalaxies(List<List<Tile>> spaceMap, int startRow, int startColumn)
    {
        // very ineffective ik
        for (int row = 0; row < spaceMap.Count; row++)
        {
            for (int column = 0; column < spaceMap[row].Count; column++)
            {
                if (row == startRow && column == startColumn)
                    continue;

                if (spaceMap[row][column].IsGalaxy)
                {
                    var rowDistance = Math.Abs(startRow - row);
                    var columnDistance = Math.Abs(startColumn - column);
                    var distance = rowDistance + columnDistance;

                    var emptyRowsAndColumns = CountEmptyRowsAndColumns(spaceMap, startRow, startColumn, row, column);

                    distance -= emptyRowsAndColumns;
                    var abc = emptyRowsAndColumns * 1_000_000;

                    distance += abc;

                    spaceMap[startRow][startColumn].DistanceToGalaxies.Add(spaceMap[row][column].GalaxyId, distance);
                }
            }
        }
    }

    static void AssignDistanceBetweenGalaxies(List<List<Tile>> spaceMap)
    {
        for (int row = 0; row < spaceMap.Count; row++)
        {
            for (int column = 0; column < spaceMap[row].Count; column++)
            {
                var tile = spaceMap[row][column];
                if (tile.IsGalaxy)
                {
                    FindDistanceToGalaxies(spaceMap, row, column);
                }
            }
        }
    }


    static void PrintMap(List<List<Tile>> spaceMap)
    {
        for (int row = 0; row < spaceMap.Count; row++)
        {
            for (int column = 0; column < spaceMap[row].Count; column++)
            {
                var tile = spaceMap[row][column];
                var ogColor = Console.ForegroundColor;

                if (tile.EmptyColumn)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (tile.EmptyRow)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }

                Console.Write(spaceMap[row][column].C);
                Console.ForegroundColor = ogColor;
            }
            Console.Write('\n');
        }
    }

    public static void Part2Main()
    {
        var spaceMap = GetSpaceMap();
        SetPositionOnGalaxies(spaceMap);
        AssignDistanceBetweenGalaxies(spaceMap);

        HashSet<Tuple<int, int>> visitLog = new();

        long totalDistance = 0;
        foreach (var galaxy in spaceMap.SelectMany(x => x).Where(x => x.IsGalaxy))
        {
            foreach (var distance in galaxy.DistanceToGalaxies)
            {
                int galaxy1Id = galaxy.GalaxyId;
                int galaxy2Id = distance.Key;

                var alreadyVisited11 = visitLog.Contains(new(galaxy1Id, galaxy2Id));
                var alreadyVisited22 = visitLog.Contains(new(galaxy2Id, galaxy1Id));

                if(alreadyVisited11 == false && alreadyVisited22 == false)
                {
                    totalDistance += distance.Value;
                    visitLog.Add(new(galaxy.GalaxyId, distance.Key));
                }
            }
        }

        Console.WriteLine($"Part 2, total distance => {totalDistance}");
    }
}