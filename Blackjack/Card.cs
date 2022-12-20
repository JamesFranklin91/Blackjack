using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        public enum suits
        {
            Hearts, Diamonds, Clubs, Spades
        }

        public enum numbers
        {
            Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        private suits suit;
        private numbers number;
        private int value;
        private bool ace = false;

        public Card(suits _suit, numbers _number)
        {
            suit = _suit;
            number = _number;
            SetValue(number);
        }

        public void PrintCard()
        {
            Console.WriteLine("{0} of {1} ({2})", number, suit, value);
        }

        public suits GetSuit()
        {
            return suit;
        }

        public numbers GetNumber()
        {
            return number;
        }

        public int GetValue()
        {
            return value;
        }

        private void SetValue(numbers number)
        {
            switch (number)
            {
                case numbers.Ace:
                    value = 11;
                    ace = true;
                    break;
                case numbers.Two:
                    value = 2;
                    break;
                case numbers.Three:
                    value = 3;
                    break;
                case numbers.Four:
                    value = 4;
                    break;
                case numbers.Five:
                    value = 5;
                    break;
                case numbers.Six:
                    value = 6;
                    break;
                case numbers.Seven:
                    value = 7;
                    break;
                case numbers.Eight:
                    value = 8;
                    break;
                case numbers.Nine:
                    value = 9;
                    break;
                case numbers.Ten:
                case numbers.Jack:
                case numbers.Queen:
                case numbers.King:
                    value = 10;
                    break;

            }
        }

        public bool CheckAce()
        {
            return ace;
        }

        public void ToggleAce()
        {
            ace = false;
            value = 1;
        }
    }
}
