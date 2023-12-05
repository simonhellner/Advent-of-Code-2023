namespace Day04;

public static class Part2
{
    public class Card
    {
        public int CopiesOfThisCard { get; set; } = 1;

        public List<int> CorrectNumbers { get; set; }
    }


    static List<Card> GetInputPart2()
    {
        var input = File.ReadAllLines("input.txt");
        List<Card> cards = [];
        foreach (var card in input)
        {
            var split = card.Split('|');

            var numbers = split[0]
                .Split(": ")[1]
                .Split(' ')
                .Where(x => x != "")
                .Select(x => int.Parse(x))
                .ToList();

            var winningNumbers = split[1]
                .Split(' ')
                .Where(x => x != "")
                .Select(x => int.Parse(x))
                .ToList();

            cards.Add(new Card()
            {
                CorrectNumbers = numbers.Where(number => winningNumbers.Contains(number)).ToList(),
            });
        }

        return cards;

    }


    public static void Part2Main()
    {
        List<Card> cards = GetInputPart2();

        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];

            for (int copies = 0; copies < card.CopiesOfThisCard; copies++)
            {
                int correctNumbers = card.CorrectNumbers.Count;

                if (correctNumbers < 1)
                    continue;

                var cardsToCopy = i + correctNumbers;
                for (int j = i + 1; j <= (i + correctNumbers) && j < cards.Count; j++)
                {
                    cards[j].CopiesOfThisCard += 1;
                }
            }
        }

        var totalCards = cards.Sum(x => x.CopiesOfThisCard);

        Console.WriteLine($"Part 2, Total Cards =>  {totalCards}");
    }
}
