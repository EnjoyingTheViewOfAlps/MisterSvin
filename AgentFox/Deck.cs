using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentFox
{
    class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = GenerateDeck();
        }

        public void Shuffle()
        {
            Random random = new Random();
            cards = cards.OrderBy(card => random.Next()).ToList();
        }

        public Card DrawCard()
        {
            Card drawnCard = cards.First();
            cards.Remove(drawnCard);
            return drawnCard;
        }

        private static List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();

            string[] suits = { "Черви", "Бубны", "Трефы", "Пики" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }

            return deck;
        }
    }
}
