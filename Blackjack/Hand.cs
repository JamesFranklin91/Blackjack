using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack
{
    public class Hand
    {
        //hand is a list of Cards
        private List<Card> hand = new List<Card>();

        private int value = 0;
        private string name;
        private bool hidden;

        //Hand constructor. Name is for printing purposes, hidden determines whether dealer hole card is visible - false by default
        public Hand(string _name, bool _hidden = false)
        {
            name = _name;
            hidden = _hidden;
        }

        //Toggle hidden for dealer hole card, so it can be revealed
        public void ToggleHidden()
        {
            hidden = false;
        }

        //Adds the parameter card into the hand, and calculates the new value of the hand
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
                        hand[i].AceToOne();
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

        //Prints and renders hand cards and hand value
        public void PrintHandInfo()
        {
            Console.WriteLine("{0} hand:", name);
            Thread.Sleep(100);

            //If dealer hole card is hidden, only print and render 1st card, print card back for hole card
            if (hidden)
            {
                Console.WriteLine(String.Format("{0}, ?", hand[0].GetCard()));
                //Render cards side by side
                RenderHand();
                Console.WriteLine("({0} hand value at least: {1})\n", name, hand[0].GetValue());
            }
            else
            {
                //Print each card on one line
                StringBuilder sb = new StringBuilder();
                foreach (Card card in hand)
                {
                    sb.Append(String.Format("{0}, ", card.GetCard()));
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
                //Render cards side by side
                RenderHand();
                Console.WriteLine("({0} hand value: {1})\n", name, value);
            }
            Thread.Sleep(500);
        }

        //Renders entire hand, one line at a time
        public void RenderHand()
        {
            //Each card render is 14 lines tall
            for (int i = 0; i < 14; i++)
            {
                //Build each line by creating a StringBuilder of each card on each row
                StringBuilder sb = new StringBuilder();

                //If dealer hole card is hidden, only render 1st card and card back, otherwise render entire hand
                if (hidden)
                {
                    sb.Append(String.Format("{0, -20}", hand[0].Render()[i]));
                    sb.Append(String.Format("{0, -20}", hand[1].CardBackRender()[i]));
                } else
                {
                    foreach (Card card in hand)
                    {
                        sb.Append(String.Format("{0, -20}", card.Render()[i]));
                    }
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
