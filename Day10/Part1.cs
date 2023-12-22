namespace Day10;

public static class Part1
{
    public class Pos (int row, int column)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;
    }

    public static bool HasVisited(this bool[][] visits, int row, int column)
    {
        bool visited = visits[row][column];

        Console.WriteLine($" Visited, [{row}][{column}] = {visited}");
        return visited;
    }


    public static char? GetPipe(this char[][] map, int row, int column)
    {
        if (row < 0 || row > map.Length)
            return null;
        if (column < 0 || column > map[row].Length)
            return null;

        return map[row][column];
    }

    public static Pos GetNextPipe(this char[][] map, Pos position, long steps, bool[][] visits)
    {
        // 250 rader if, inte snyggttt jag veeet 
        int row = position.Row;
        int column = position.Column;

        char currentPipe = map[row][column];

        if (map[row][column] == '║')
        {
            var upPipe = map.GetPipe(row - 1, column);
            if(upPipe == '╗' || upPipe == '╔' || upPipe == '║')
            {
                if (!visits[row - 1][column])
                {
                    return new Pos(row - 1, column);
                }
            }

            if(upPipe == 'S' && steps > 1)
            {
                return new Pos(row - 1, column);
            }

            var downPipe = map.GetPipe(row + 1, column);
            if (downPipe == '╚' || downPipe == '╝' || downPipe == '║')
            {
                if (!visits[row+1][column])
                {
                    return new Pos(row + 1, column);
                }
            }

            if (downPipe == 'S' && steps > 1)
            {
                return new Pos(row + 1, column);
            }
        }



        if (map[row][column] == '═')
        {
            var leftPipe = map.GetPipe(row, column-1);
            if (leftPipe == '╚' || leftPipe == '╔' || leftPipe == '═')
            {
                if (!visits[row][column-1])
                {
                    return new Pos(row, column-1);
                }
            }

            if (leftPipe == 'S' && steps > 1)
            {
                return new Pos(row, column-1);
            }

            var rightPipe = map.GetPipe(row, column+1);
            if (rightPipe == '╝' || rightPipe == '╗' || rightPipe == '═')
            {
                if (!visits[row][column+1])
                {
                    return new Pos(row, column+1);
                }
            }

            if (rightPipe == 'S' && steps > 1)
            {
                return new Pos(row, column +1);
            }
        }



        if (map[row][column] == '╚')
        {
            var upPipe = map.GetPipe(row - 1, column);
            if (upPipe == '╗' || upPipe == '╔' || upPipe == '║')
            {
                if (!visits[row-1][column])
                {
                    return new Pos(row - 1, column);
                }
            }
            if (upPipe == 'S' && steps > 1)
            {
                return new Pos(row - 1, column);
            }

            var rightPipe = map.GetPipe(row, column + 1);
            if (rightPipe == '╝' || rightPipe == '╗' || rightPipe == '═')
            {
                if (!visits[row][column+1])
                {
                    return new Pos(row, column + 1);
                }
            }
            if (rightPipe == 'S' && steps > 1)
            {
                return new Pos(row, column + 1);
            }
        }



        if (map[row][column] == '╝')
        {
            var upPipe = map.GetPipe(row - 1, column);
            if (upPipe == '╗' || upPipe == '╔' || upPipe == '║')
            {
                if (!visits[row-1][column])
                {
                    return new Pos(row - 1, column);
                }
            }
            if (upPipe == 'S' && steps > 1)
            {
                return new Pos(row - 1, column);
            }

            var leftPipe = map.GetPipe(row, column - 1);
            if (leftPipe == '╚' || leftPipe == '╔' || leftPipe == '═')
            {
                if (!visits[row][column-1])
                {
                    return new Pos(row, column - 1);
                }
            }
            if (leftPipe == 'S' && steps > 1)
            {
                return new Pos(row, column - 1);
            }

        }



        if (map[row][column] == '╗')
        {
            var leftPipe = map.GetPipe(row, column - 1);
            if (leftPipe == '╚' || leftPipe == '╔' || leftPipe == '═')
            {
                if (!visits[row][column - 1])
                {
                    return new Pos(row, column - 1);
                }
            }
            if (leftPipe == 'S' && steps > 1)
            {
                return new Pos(row, column - 1);
            }

            var downPipe = map.GetPipe(row + 1, column);
            if (downPipe == '╚' || downPipe == '╝' || downPipe == '║')
            {
                if (!visits[row + 1][column])
                {
                    return new Pos(row + 1, column);
                }
            }
            if (downPipe == 'S' && steps > 1)
            {
                return new Pos(row + 1, column);
            }
        }


        if (map[row][column] == '╔')
        {
            var rightPipe = map.GetPipe(row, column + 1);
            if (rightPipe == '╝' || rightPipe == '╗' || rightPipe == '═')
            {
                if (!visits[row][column+1])
                {
                    return new Pos(row, column + 1);
                }
            }
            if (rightPipe == 'S' && steps > 1)
            {
                return new Pos(row, column + 1);
            }

            var downPipe = map.GetPipe(row + 1, column);
            if (downPipe == '╚' || downPipe == '╝' || downPipe == '║')
            {
                if (!visits[row + 1][column])
                {
                    return new Pos(row + 1, column);
                }
            }
            if (downPipe == 'S' && steps > 1)
            {
                return new Pos(row + 1, column);
            }
        }


        if (map[row][column] == 'S')
        {
            var upPipe = map.GetPipe(row - 1, column);
            if (upPipe == '╗' || upPipe == '╔' || upPipe == '║')
            {
                if (!visits[row-1][column])
                {
                    return new Pos(row - 1, column);
                }
            }

            var downPipe = map.GetPipe(row + 1, column);
            if (downPipe == '╚' || downPipe == '╝' || downPipe == '║')
            {
                if (!visits[row+1][column])
                {
                    return new Pos(row + 1, column);
                }
            }

            var rightPipe = map.GetPipe(row, column + 1);
            if (rightPipe == '╝' || rightPipe == '╗' || rightPipe == '═')
            {
                if (!visits[row][column+1])
                {
                    return new Pos(row, column + 1);
                }
            }

            var leftPipe = map.GetPipe(row, column - 1);
            if (leftPipe == '╚' || leftPipe == '╔' || leftPipe == '═')
            {
                if (!visits[row][column-1])
                {
                    return new Pos(row, column - 1);
                }
            }

        }


        throw new NotImplementedException();
    }


    static void PrintMap(this char[][] map, bool[][] visits)
    {
        for(int row = 0; row < map.Length; row++)
        {
            for(int column = 0;  column < map[row].Length; column++)
            {
                var prevColor = Console.ForegroundColor;
                if (visits[row][column])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(map[row][column]);
                Console.ForegroundColor = prevColor;
            }
            Console.Write('\n');
        }
        Console.Write('\n');

    }



    public static void Part1Main()
    {
        //Tile[][] map = File.ReadAllLines("input-test.txt").Select(row => row.Select(column => new Tile(column)).ToArray()).ToArray()!;
        var input = File.ReadAllLines("input.txt")
             .Select(line =>
             {
                 return line
                 .Replace('|', '║')
                 .Replace('-', '═')
                 .Replace('L', '╚')
                 .Replace('J', '╝')
                 .Replace('7', '╗')
                 .Replace('F', '╔')
                 .ToArray()!; // BETTER PIPES

             }).ToArray()!;



        bool[][] visits = new bool[input.Length][];

        int startRow = 0; int endRow = 0;
        for(int row = 0; row < input.Length; row++)
        {
            visits[row] = new bool[input[row].Length];
            for(int col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == 'S')
                {
                    startRow = row;
                    endRow = col;
                    break;
                }
            }
        }

        var map = input;

        long steps = 0;
        Pos currentPos = new Pos(startRow, endRow);
        while (true)
        {


            var currentPipe = map.GetPipe(currentPos.Row, currentPos.Column);
            if(currentPipe != 'S')
            {
                visits[currentPos.Row][currentPos.Column] = true; 
            }
            //if (steps > 0)
            //{
            //    Visited2[currentPos.Row][currentPos.Column] = true;
            //    if(currentPipe == 'S')
            //    {
            //        break;
            //    }
            //}
             
            //Visited.Add(currentPos);
            var newPos = map.GetNextPipe(currentPos, steps, visits);           
            var newPipe = map.GetPipe(newPos.Row, newPos.Column);

            if(newPipe == 'S')
            {
                break;
            }
            steps++;
            currentPos = newPos;
            if(steps % 10_000 == 0)
                Console.Title = $"Pipe {steps}";

        }

        var maxDistance = Math.Ceiling(steps / 2.0);



        map.PrintMap(visits);
        Console.WriteLine($"Part 1, result => {maxDistance}");
    }
}