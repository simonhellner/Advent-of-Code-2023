namespace Day03;

public static class Part2
{
    static List<Tuple<int, int>> VisitedNumbers = [];
    public static int GetFullNummber(this string[] input, int row, int column)
    {

        int numberStartColumn = column;
        while (numberStartColumn >= 0)
        {
            if (input[row][numberStartColumn].IsDigit())
            {
                numberStartColumn--;
            }
            else
            {
                numberStartColumn++;
                break;
            }
        }

        if (numberStartColumn < 0)
            numberStartColumn = 0;


        int numberEndColumn = column;
        while (numberEndColumn < input[row].Length)
        {
            if (input[row][numberEndColumn].IsDigit())
                numberEndColumn++;
            else
                break;
        }

        var numba = input[row].Take(new Range(numberStartColumn, numberEndColumn));
        int gear = int.Parse(new string(numba.ToArray()));
        for (int i = numberStartColumn; i < numberEndColumn; i++)
        {
            VisitedNumbers.Add(new(row, i));
        }
        return gear;
    }

    public static bool TryGetNumber(this string[] input, int row, int column, out int outNumber)
    {
        outNumber = 0;

        if (VisitedNumbers.Contains(new(row, column)))
            return false;

        if (row < 0 || row > input.Length || column < 0 || column > input[row].Length)
            return false;

        if (input[row][column].IsDigit())
        {
            if (!VisitedNumbers.Contains(new(row, column)))
            {
                outNumber = input.GetFullNummber(row, column);
                return true;
            }
        }

        return false;
    }


    public static int CountNeighbourPartNumbers(this string[] input, int row, int column)
    {
        if (VisitedNumbers.Contains(new(row, column)))
            return 0;

        List<int> neighbourParts = [];

        int number = 0;
        if (TryGetNumber(input, row, column - 1, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row, column + 1, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row - 1, column, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row + 1, column, out number))
        {
            neighbourParts.Add(number);
        }

        if (TryGetNumber(input, row - 1, column - 1, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row - 1, column + 1, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row + 1, column + 1, out number))
        {
            neighbourParts.Add(number);
        }
        if (TryGetNumber(input, row + 1, column - 1, out number))
        {
            neighbourParts.Add(number);
        }

        if (neighbourParts.Count != 2)
        {
            return 0;
        }
        return neighbourParts[0] * neighbourParts[1];
    }




    public static void Part2Main()
    {
        string[] input = File.ReadAllLines("input.txt");

        var test = input.GetFullNummber(0, 5);

        int result = 0;
        for (int row = 0; row < input.Length; row++)
        {
            var line = input[row];
            for (int column = 0; column < line.Length; column++)
            {
                if (line[column] == '*')
                {
                    int gearRatio = input.CountNeighbourPartNumbers(row, column);
                    if (gearRatio > 0)
                    {
                        result += gearRatio;
                    }
                }
            }
        }
        Console.WriteLine($"Part 2 result, {result}");
    }
}
