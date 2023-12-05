namespace Day01
{
    public static class Part2
    {
        static IEnumerable<KeyValuePair<int, int>> FindStrNummbers(string input)
        {
            string[] numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {

                    var foundNumber = input.Substring(i).StartsWith(numbers[j]);
                    if (foundNumber)
                    {
                        var sub = input.Substring(i);
                        int startIndex = i;
                        int number = j;
                        yield return new KeyValuePair<int, int>(startIndex, number);
                    }
                }
            }
        }

        public static void Part2Main()
        {

            var input = File.ReadAllLines("input.txt");
            int sum = 0;
            foreach (var line in input)
            {
                char firstNumericChar = line.First(x => char.IsDigit(x));
                int firstNumericCharIndex = line.IndexOf(firstNumericChar);
                string firstNumber = $"{firstNumericChar}";

                char lastNumericChar = line.Last(x => char.IsDigit(x));
                int lastNumericCharIndex = line.LastIndexOf(lastNumericChar);
                string lastNumber = $"{lastNumericChar}";

                var strNumbers = FindStrNummbers(line).OrderBy(x => x.Key).ToList();

                if (strNumbers.Count > 0)
                {
                    if (strNumbers[0].Key < firstNumericCharIndex)
                    {
                        firstNumber = strNumbers[0].Value.ToString();
                        // Ok the string number comes first;
                    }

                    if (strNumbers[^1].Key > lastNumericCharIndex)
                    {
                        lastNumber = strNumbers[^1].Value.ToString();
                        // Ok the string number comes first;
                    }
                }

                int result = int.Parse(firstNumber + lastNumber);
                sum += result;
            }

            Console.WriteLine($"Part 2 result = {sum}");
        }
    }
}
