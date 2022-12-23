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

        public Hand(string _name, bool _hidden = false)
        {
            name = _name;
            hidden = _hidden;
        }

        public void hit(Card card)
        {
            hand.Add(card);
            value += card.GetValue();
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

        public int GetHandValue()
        {
            return value;
        }

        public List<Card> GetHand()
        {
            return hand;
        }

        public void PrintHandInfo()
        {
            PrintHand();
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
            Console.WriteLine("({0} hand value: {1})", name, value);
            Console.WriteLine(" ");
        }

        public void ToggleHidden()
        {
            hidden = false;
        }

        public void RenderHand()
        {
            for (int i = 0; i < 14; i++)
            {
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
