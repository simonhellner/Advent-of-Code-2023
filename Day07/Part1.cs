namespace Day07;

public static class Part1
{
    public enum HandTypes
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        FourOfAKind = 6,
        FiveOfAKind =7
    }

    public static int GetCardStrenght(char c)
    {
        return c switch
        {
            '2' => 1,
            '3' => 2,
            '4' => 3,
            '5' => 4,
            '6' => 5,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => throw new NotImplementedException()
        };
    }

    public class Hand
    {
        public string Cards { get; set; }

        public int Bid { get; set; }


        public HandTypes HandType => GetHandType();

        public HandTypes GetHandType()
        {
            var cardGroups = Cards
                 .GroupBy(c => c);

            var maxPairCounts = cardGroups.Max(x => x.Count());

            if (maxPairCounts == 5)
                return HandTypes.FiveOfAKind;

            if (maxPairCounts == 4)
                return HandTypes.FourOfAKind;

            if (maxPairCounts == 3 && cardGroups.FirstOrDefault(x => x.Count() == 2) != null)
                return HandTypes.FullHouse; // 3 same, 2 same.


            if (cardGroups.Count() == 3 && cardGroups.Any(x => x.Count() == 3)) // 3 grupper, 1 av grupperna har 3 kort
                return HandTypes.ThreeOfAKind;

            if (cardGroups.Where(x => x.Count() == 2).Count() == 2)
                return HandTypes.TwoPair;

            if (cardGroups.Where(x => x.Count() == 2).Count() == 1)
                return HandTypes.OnePair;


            if (Cards.Distinct().Count() == Cards.Length)
                return HandTypes.HighCard;

            throw new NotImplementedException();
        }
    }


    static void SortSwap(Hand[] hands, int index1, int index2)
    {
        var temp = hands[index1];
        hands[index1] = hands[index2];
        hands[index2] = temp;
    }

    static void SortHands(Hand[] hands)
    {
        for (int i = 0; i < hands.Length - 1; i++)
        {
            for (int j = 0; j < hands.Length - i - 1; j++)
            {
                if(hands[j].HandType > hands[j+1].HandType)
                    SortSwap(hands, j, j + 1);           

                if (hands[j].HandType != hands[j + 1].HandType)
                    continue;

                for (int k = 0; k < hands[i].Cards.Length; k++)
                {
                    if (hands[j].Cards[k] != hands[j + 1].Cards[k])
                    {
                        var cardStrenghtHand1 = GetCardStrenght(hands[j].Cards[k]);
                        var cardStrenghtHand2 = GetCardStrenght(hands[j + 1].Cards[k]);

                        if (cardStrenghtHand2 < cardStrenghtHand1)
                        {
                            SortSwap(hands, j, j + 1);
                        }

                        break;
                    } 
                }              
            }
        }
    }

    public static void Part1Main()
    {
        var hands = File.ReadAllLines("input.txt")
            .Select(hand => hand.Split(' '))
            .Select(split => new Hand() { Cards = split[0], Bid = Convert.ToInt32(split[1]) })
            .ToArray();

        SortHands(hands);

        var resuslt = hands
            .Select((hand, i) => hand.Bid * (i + 1))
            .Sum();

        Console.WriteLine($"Part 1 result => {resuslt}");
    }
}