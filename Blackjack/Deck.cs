using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            BuildDeck();
            ShuffleDeck();
        }

        private void BuildDeck()
        {
            foreach (Card.suits suit in Enum.GetValues(typeof(Card.suits)))
            {
                foreach(Card.numbers num in Enum.GetValues(typeof(Card.numbers)))
                {
                    Card card = new Card(suit, num);
                    deck.Add(card);
                }
            }
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
            deck = deck.OrderBy(card => rng.Next()).ToList();
        }

        public void PrintDeck()
        {
            Console.WriteLine("Total cards in deck: {0}", deck.Count);
            foreach(Card card in deck)
            {
                card.PrintCard();
            }
        }
        
        public Card DrawCard()
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            return drawnCard;
        }
    }
}
