using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        //Declare Deck list, which is a list of Card objects
        private List<Card> deck = new List<Card>();

        //Deck constructor, which calls BuildDeck and ShuffleDeck functions
        public Deck()
        {
            BuildDeck();
            ShuffleDeck();
        }

        //For each suit and number, create a card and add it to the empty deck list
        //Results in a 52 card deck with all available cards
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

        //Pseudo-randomly shuffles the order of the deck
        public void ShuffleDeck()
        {
            Random rng = new Random();
            deck = deck.OrderBy(card => rng.Next()).ToList();
        }

        //Prints each card in the deck for debugging purposes
        public void PrintDeck()
        {
            Console.WriteLine("Total cards in deck: {0}", deck.Count);
            foreach(Card card in deck)
            {
                card.PrintCard();
            }
        }
        
        //Removes the first card from the deck list, and returns it
        public Card DrawCard()
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            return drawnCard;
        }

        //Returns deck list
        public List<Card> GetDeck()
        {
            return deck;
        }
    }
}
