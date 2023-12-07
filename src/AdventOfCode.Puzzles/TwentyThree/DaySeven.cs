using AdventOfCode.Common;

namespace AdventOfCode.Puzzles.TwentyThree;
public class DaySeven : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        return CalculateBidTotal(inputLines, GetHandType);
    }

    public object RunTaskTwo(string[] inputLines)
    {
        return CalculateBidTotal(inputLines, GetHandTypePartTwo);
    }

    private double CalculateBidTotal(string[] inputLines, Func<string, (HandType, int)> handTypeExtractor)
    {
        List<Hand>[] handsByType =
        {
            new List<Hand>(),
            new List<Hand>(),
            new List<Hand>(),
            new List<Hand>(),
            new List<Hand>(),
            new List<Hand>(),
            new List<Hand>(),
        };

        foreach (var line in inputLines)
        {
            string[] handData = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var (type, score) = handTypeExtractor(handData[0]);

            var hand = new Hand(type, score, int.Parse(handData[1]));
            handsByType[(int)type].Add(hand);
        }

        double total = 0;
        int multiplier = 1;

        foreach (List<Hand> handsOfType in handsByType)
        {
            int numberOfHands = handsOfType.Count;
            if (numberOfHands == 0) continue;

            if (numberOfHands == 1)
            {
                total += handsOfType.First().Bid * multiplier;
                multiplier++;

                continue;
            }

            IList<Hand> sortedHands = handsOfType.QuickSort((curr, pivot) => curr.Score < pivot.Score);

            foreach (Hand hand in sortedHands)
            {
                total += hand.Bid * multiplier;
                multiplier++;
            }
        }

        return total;
    }

    private (HandType type, int score) GetHandTypePartTwo(string hand)
    {
        Dictionary<char, int> cardCount = new();

        int typesOfCard = 0;
        int handScore = 0;
        int multiplier = 100000000;

        for (int cNum = 0; cNum < hand.Length; cNum++)
        {
            handScore += GetScore(hand[cNum]) * multiplier;
            multiplier /= 100;

            if (cardCount.ContainsKey(hand[cNum]))
            {
                cardCount[hand[cNum]]++;
                continue;
            }

            cardCount[hand[cNum]] = 1;
            typesOfCard++;
        }

        int GetScore(char card)
        {
            if (char.IsDigit(card))
            {
                // 48 is ascii for 0
                return card - 48;
            }

            return card switch
            {
                'T' => 10,
                'J' => 1,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new UnknownCardTypeException()
            };
        }

        if (typesOfCard == 1)
        {
            return (HandType.FiveOfAKind, handScore);
        }

        // can be FourOfAKind or FullHouse
        if (typesOfCard == 2)
        {
            // either JJJJK or KKKJ or KKKJJ or JJJKK
            if (cardCount.ContainsKey('J'))
            {
                return (HandType.FiveOfAKind, handScore);
            }

            foreach (var card in cardCount)
            {
                if (card.Value == 4)
                {
                    return (HandType.FourOfAKind, handScore);
                }
            }

            return (HandType.FullHouse, handScore);
        }

        // can be ThreeOfAKind or TwoPair
        if (typesOfCard == 3)
        {
            foreach (var card in cardCount)
            {
                if (card.Value == 3)
                {
                    // KKKJA or JJJKA
                    if (cardCount.ContainsKey('J'))
                    {
                        return (HandType.FourOfAKind, handScore);
                    }
                    return (HandType.ThreeOfAKin, handScore);
                }
            }

            if (cardCount.ContainsKey('J'))
            {
                // KKJAA
                if (cardCount['J'] == 1)
                {
                    return (HandType.FullHouse, handScore);
                }

                // KKJJA
                return (HandType.FourOfAKind, handScore);
            }

            return (HandType.TwoPair, handScore);
        }

        // OnePair
        if (typesOfCard == 4)
        {
            // KKJAQ or JJKAQ
            if (cardCount.ContainsKey('J'))
            {
                return (HandType.ThreeOfAKin, handScore);
            }

            return (HandType.OnePair, handScore);
        }

        if (typesOfCard == 5)
        {
            // JAQK2
            if (cardCount.ContainsKey('J'))
            {
                return (HandType.OnePair, handScore);
            }

            return (HandType.HighCard, handScore);
        }

        throw new UnknownCardTypeException();
    }

    private (HandType type, int score) GetHandType(string hand)
    {
        Dictionary<char, int> cardCount = new();

        int typesOfCard = 0;
        int handScore = 0;
        int multiplier = 100000000;

        for (int cNum = 0; cNum < hand.Length; cNum++)
        {
            handScore += GetScore(hand[cNum]) * multiplier;
            multiplier /= 100;

            if (cardCount.ContainsKey(hand[cNum]))
            {
                cardCount[hand[cNum]]++;
                continue;
            }

            cardCount[hand[cNum]] = 1;
            typesOfCard++;
        }

        int GetScore(char card)
        {
            if (char.IsDigit(card))
            {
                // 48 is ascii for 0
                return card - 48;
            }

            return card switch
            {
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new UnknownCardTypeException()
            };
        }

        if (typesOfCard == 1)
        {
            return (HandType.FiveOfAKind, handScore);
        }

        // can be FourOfAKind or FullHouse
        if (typesOfCard == 2)
        {
            foreach (var card in cardCount)
            {
                if (card.Value == 4)
                {
                    return (HandType.FourOfAKind, handScore);
                }
            }

            return (HandType.FullHouse, handScore);
        }

        // can be ThreeOfAKind or TwoPair
        if (typesOfCard == 3)
        {
            foreach (var card in cardCount)
            {
                if (card.Value == 3)
                {
                    return (HandType.ThreeOfAKin, handScore);
                }
            }

            return (HandType.TwoPair, handScore);
        }

        // OnePair
        if (typesOfCard == 4)
        {
            return (HandType.OnePair, handScore);
        }

        if (typesOfCard == 5)
        {
            return (HandType.HighCard, handScore);
        }

        throw new UnknownCardTypeException();
    }

    private record Hand(HandType HandType, int Score, int Bid);

    private enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKin,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }

    private class UnknownCardTypeException : Exception { }
}
