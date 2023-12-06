using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentFox
{
    class Player
    {
        public string Name { get; }
        private List<Card> hand;
        private Deck deck;

        public Player(string name)
        {
            Name = name;
            hand = new List<Card>();
        }

        public void DrawCards(Deck deck, int count)
        {
            for (int i = 0; i < count; i++)
            {
                hand.Add(deck.DrawCard());
            }
        }

        public void DisplayHand()
        {
            Console.WriteLine($"{Name}'s рука: {string.Join(", ", hand)}");
        }

        public void PlayTurn(Player opponent)
        {
            Console.Write("Введите ранг карты, которую хотите запросить: ");
            string requestedRank = Console.ReadLine();

            List<Card> matchingCards = opponent.hand.Where(card => card.Rank == requestedRank).ToList();

            if (matchingCards.Count > 0)
            {
                Console.WriteLine($"{opponent.Name} отдал вам {matchingCards.Count} карт: {string.Join(", ", matchingCards)}");
                hand.AddRange(matchingCards);
                opponent.hand.RemoveAll(card => card.Rank == requestedRank);
            }
            else
            {
                Console.WriteLine($"{opponent.Name} сказал 'Взять!'");
                Card drawnCard = opponent.DrawCardsFromDeck(1).First();
                hand.Add(drawnCard);
            }
        }

        public List<Card> DrawCardsFromDeck(int count)
        {
            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                drawnCards.Add(deck.DrawCard());
            }

            return drawnCards;
        }

        public bool HasWon()
        {
            var groupedByRank = hand.GroupBy(card => card.Rank);
            return groupedByRank.Any(group => group.Count() == 4);
        }
    }
}
