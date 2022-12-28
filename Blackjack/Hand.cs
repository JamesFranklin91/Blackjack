using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack
{
    internal class Hand
    {
        private List<Card> hand = new List<Card>();
        private int value = 0;
        private string name;
        private bool hidden;

        //Hand constructor. Name is for printing, hidden determines whether dealer hole card is visible - false by default
        public Hand(string _name, bool _hidden = false)
        {
            name = _name;
            hidden = _hidden;
        }

        //Adds the parameter card into the hand
        public void hit(Card card)
        {
            hand.Add(card);
            value += card.GetValue();
            //If hand value is over 21, check to see if hand has ace valued at 11, if so, -10 from the value of the hand and set value of that ace to 1
            if(value > 21)
            {
                for(int i = 0; i < hand.Count; i++)
                {
                    if (hand[i].CheckAce())
                    {
                        hand[i].ToggleAce();
                        value -= 10;
                        break;
                    }
                }
            }
        }

        //Get hand value
        public int GetHandValue()
        {
            return value;
        }

        //Get list of cards in hand 
        public List<Card> GetHand()
        {
            return hand;
        }

        //Prints hand cards and hand value
        public void PrintHandInfo()
        {
            PrintHand();
            //If dealer hand is still hidden, do not print value
            if (!hidden)
                PrintHandValue();
            else
                Console.WriteLine(" ");

            Thread.Sleep(500);
        }

        public void PrintHand()
        {
            Console.WriteLine("{0} hand:", name);
            Thread.Sleep(100);
            if (hidden)
            {
                hand[0].PrintCard();
                Thread.Sleep(100);
                Console.WriteLine("?");
            } else
            {
                foreach (Card card in hand)
                {
                    card.PrintCard();
                    Thread.Sleep(100);
                }
                RenderHand();
            }
        }

        public void PrintHandValue()
        {
            Console.WriteLine("({0} hand value: {1})\n", name, value);
        }

        public void ToggleHidden()
        {
            hidden = false;
        }

        //Renders entire hand, one line at a time
        public void RenderHand()
        {
            //Each card render is 14 lines tall
            for (int i = 0; i < 14; i++)
            {
                //Build each line by creating a StringBuilder of each card on each row
                StringBuilder sb = new StringBuilder();
                foreach (Card card in hand)
                {
                    sb.Append(String.Format("{0, -20}", card.Render()[i]));
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
