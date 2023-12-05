namespace Day03;

public static class Part1
{

    public static bool IsDigit(this char c)
    {
        return char.IsDigit(c);
    }

    public static bool IsSymbol(this char c)
    {
        if (c == '.' || char.IsDigit(c))
            return false;
        return true;
    }

    public static bool HasSymbolNeighbour(this string[] input, int row, int column)
    {
        // Check Left
        if ((column - 1) >= 0)
        {
            if (input[row][column - 1].IsSymbol())
                return true;
        }
        // Check Right
        if ((column + 1) < input[row].Length)
        {
            if (input[row][column + 1].IsSymbol())
                return true;
        }
        // Check up
        if ((row - 1) >= 0)
        {
            if (input[row - 1][column].IsSymbol())
                return true;
        }

        // Check down
        if ((row + 1) < input.Length)
        {
            if (input[row + 1][column].IsSymbol())
                return true;
        }

        // Check Left Up
        if ((column - 1) >= 0 && (row - 1) >= 0)
        {
            if (input[row - 1][column - 1].IsSymbol())
                return true;
        }

        // Check Right Up
        if ((column + 1) < input[row].Length && (row - 1) >= 0)
        {
            if (input[row - 1][column + 1].IsSymbol())
                return true;
        }

        // Check Left Down
        if ((column - 1) >= 0 && (row + 1) < input.Length)
        {
            if (input[row + 1][column - 1].IsSymbol())
                return true;
        }

        // Check Right Up
        if ((column + 1) < input[row].Length && (row + 1) < input.Length)
        {
            if (input[row + 1][column + 1].IsSymbol())
                return true;
        }
        return false;
    }


    public static void Part1Main()
    {
        string[] input = File.ReadAllLines("input.txt");

        int result = 0;
        for (int row = 0; row < input.Length; row++)
        {
            var line = input[row];
            for (int column = 0; column < line.Length; column++)
            {
                char c = line[column];
                if (!char.IsDigit(c))
                    continue;

                string currentNumber = $"";
                bool foundSymbolNeighbour = false;
                List<int> neighboursToCheck = [];
                neighboursToCheck.Add(column);
                for (int j = column; j < line.Length; j++, column++)
                {
                    if (!char.IsDigit(line[j]))
                        break;
                    currentNumber += $"{line[j]}";
                    neighboursToCheck.Add(j);
                    if (input.HasSymbolNeighbour(row, column))
                    {
                        foundSymbolNeighbour = true;
                    }
                }
                column--;

                if (foundSymbolNeighbour)
                {
                    result += int.Parse(currentNumber);
                }
            }
        }

        Console.WriteLine($"Part 1 Result = {result}");
    }
}
