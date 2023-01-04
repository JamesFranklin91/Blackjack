using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Card
    {
        //Enum for playing card suits
        public enum suits
        {
            Hearts, Diamonds, Clubs, Spades
        }

        //Enum for playing card numbers
        public enum numbers
        {
            Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        private suits suit;
        private numbers number;
        private int value;
        private bool ace = false;

        private string suitSymbol;
        private string numSymbol;

        //Constructor, accepts suit and number as parameters
        public Card(suits _suit, numbers _number)
        {
            suit = _suit;
            number = _number;

            //Sets symbol and number for card rendering 
            SetSymbol(suit);
            SetValue(number);
        }

        //Get string of the card
        public string GetCard()
        {
            return String.Format("{0} of {1} ({2})", number, suit, value);
        }

        //Print card to the console
        public void PrintCard()
        {
            Console.WriteLine(GetCard());
        }

        //Gets value of card
        public int GetValue()
        {
            return value;
        }

        //Sets value of card
        private void SetValue(numbers number)
        {
            switch (number)
            {
                case numbers.Ace:
                    value = 11;
                    numSymbol = "A";
                    ace = true;
                    break;
                case numbers.Two:
                    value = 2;
                    numSymbol = "2";
                    break;
                case numbers.Three:
                    value = 3;
                    numSymbol = "3";
                    break;
                case numbers.Four:
                    value = 4;
                    numSymbol = "4";
                    break;
                case numbers.Five:
                    value = 5;
                    numSymbol = "5";
                    break;
                case numbers.Six:
                    value = 6;
                    numSymbol = "6";
                    break;
                case numbers.Seven:
                    value = 7;
                    numSymbol = "7";
                    break;
                case numbers.Eight:
                    value = 8;
                    numSymbol = "8";
                    break;
                case numbers.Nine:
                    value = 9;
                    numSymbol = "9";
                    break;
                case numbers.Ten:
                    value = 10;
                    numSymbol = "10";
                    break;
                case numbers.Jack:
                    value = 10;
                    numSymbol = "J";
                    break;
                case numbers.Queen:
                    value = 10;
                    numSymbol = "Q";
                    break;
                case numbers.King:
                    value = 10;
                    numSymbol = "K";
                    break;

            }
        }

        //Check status of ace
        public bool CheckAce()
        {
            return ace;
        }

        //Changes value of ace to 1, and status to false
        public void ToggleAce()
        {
            ace = false;
            value = 1;
        }

        //Card rendering functions
        private void SetSymbol(suits suit)
        {
            switch (suit)
            {
                case suits.Spades:
                    suitSymbol = "♠";
                    break;
                case suits.Clubs:
                    suitSymbol = "♣";
                    break;
                case suits.Diamonds:
                    suitSymbol = "♦";
                    break;
                case suits.Hearts:
                    suitSymbol = "♥";
                    break;
            }
        }

        //Card layouts for each type of card
        public List<string> Render()
        {
            switch (numSymbol)
            {
                case "A":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "2":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "3":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "4":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "5":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "6":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "7":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "8":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "9":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "10":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        RenderPattern(1, suitSymbol),
                        RenderPattern(2, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                case "J":
                case "Q":
                case "K":
                    return new List<string>
                    {
                        " _______________",
                        String.Format("{0, -8} {1, 8}", "/", "\\"),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", numSymbol),
                        String.Format("{0, -1} {1, -6} {0, 8}", "|", suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(1, "☺"),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        RenderPattern(0, suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", suitSymbol),
                        String.Format("{0, -8} {1, 6} {0, 1}", "|", numSymbol),
                        "\\_______________/"
                    };
                default:
                    return new List<string>();
            }
        }

        //Pattern of suit symbols on the card
        private string RenderPattern(int pattern, string suit)
        {
            switch (pattern)
            {
                //Blank row
                case (0):
                    return String.Format("{0, -8} {0, 8}", "|");
                //Single suit symbol
                case (1):
                    return String.Format("{0, -7} {1, 0} {0, 7}", "|", suit);
                //Pair of suit symbols
                case (2):
                    return String.Format("{0, -4} {1, -3} {1, 3} {0, 4}", "|", suit);
                default:
                    return "";
            }
        }
    }
}
